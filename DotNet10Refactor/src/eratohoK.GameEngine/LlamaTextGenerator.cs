namespace eratohoK.GameEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using LLama;
using LLama.Common;
using LLama.Native;

public class LlamaTextGenerator : IDynamicTextGenerator, IDisposable
{
    private static readonly object SharedInstanceLock = new();
    private static readonly NativeLogConfig.LLamaLogCallback NativeLogCallback = HandleNativeLog;
    private static LlamaTextGenerator? _sharedInstance;
    private static string? _sharedModelPath;
    private static int _nativeLogConfigured;

    private readonly LLamaWeights _weights;
    private readonly LLamaContext _context;
    private readonly InteractiveExecutor _executor;
    private readonly LLamaContext.State _initialContextState;
    private readonly StatefulExecutorBase.ExecutorBaseState _initialState;
    private readonly SemaphoreSlim _generationLock = new(1, 1);
    private readonly string _modelPath;
    private bool _disposed;

    public static LlamaTextGenerator GetOrCreateShared(string modelPath)
    {
        var normalizedPath = System.IO.Path.GetFullPath(modelPath);

        lock (SharedInstanceLock)
        {
            if (_sharedInstance is not null)
            {
                if (!string.Equals(_sharedModelPath, normalizedPath, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException($"LLM shared instance is already initialized with '{_sharedModelPath}', cannot switch to '{normalizedPath}' in the same process.");
                }

                return _sharedInstance;
            }

            _sharedInstance = new LlamaTextGenerator(normalizedPath);
            _sharedModelPath = normalizedPath;
            return _sharedInstance;
        }
    }

    public static void DisposeShared()
    {
        lock (SharedInstanceLock)
        {
            _sharedInstance?.Dispose();
            _sharedInstance = null;
            _sharedModelPath = null;
        }
    }

    public LlamaTextGenerator(string modelPath)
    {
        _modelPath = System.IO.Path.GetFullPath(modelPath);
        EnsureNativeLoggingConfigured();

        var parameters = new ModelParams(_modelPath)
        {
            ContextSize = 1024,
            GpuLayerCount = 0 // CPU backend
        };

        _weights = LLamaWeights.LoadFromFile(parameters);
        NativeLogConfig.llama_log_set(NativeLogCallback);
        _context = _weights.CreateContext(parameters);
        _executor = new InteractiveExecutor(_context);
        _initialContextState = _context.GetState();
        _initialState = _executor.GetStateData();
    }

    public async Task<LlmGenerationResult> GenerateReactionAsync(string prompt)
    {
        ThrowIfDisposed();

        var promptTemplate = $"<|im_start|>system\n你是一个文字游戏口上润色器。\n你可以先在<think>...</think>中进行内部思考，然后在think块之后单独给出最终台词。\n严格规则：\n1. 最终给玩家显示的内容只保留think块之后的正文，所以最终台词必须完整、简短、可直接显示。\n2. 受动角色必须使用第一人称，最多允许补一小句极短动作描写。\n3. 不要把受动角色写成施动者，不要让角色对自己执行当前动作。\n4. 不要长篇第三人称小说式描写。\n5. 除非用户提示明确要求，否则不要直接重复角色姓名。\n6. think内容可以较长，但最终台词不要夹带规则解释、系统说明或分析过程。\n<|im_end|>\n<|im_start|>user\n{prompt}<|im_end|>\n<|im_start|>assistant\n";

        var inferenceParams = new InferenceParams()
        {
            SamplingPipeline = new LLama.Sampling.DefaultSamplingPipeline
            {
                Temperature = 0.6f,
                TopK = 20,
                TopP = 0.95f,
                MinP = 0f
            },
            MaxTokens = 256,
            AntiPrompts = new List<string> { "<|im_end|>" }
        };

        await _generationLock.WaitAsync().ConfigureAwait(false);
        try
        {
            _context.NativeHandle.MemoryClear(true);
            _context.LoadState(_initialContextState);
            await _executor.LoadState(_initialState, CancellationToken.None).ConfigureAwait(false);

            var sb = new StringBuilder();
            await foreach (var text in _executor.InferAsync(promptTemplate, inferenceParams, CancellationToken.None).ConfigureAwait(false))
            {
                sb.Append(text);
            }

            return SanitizeModelOutput(sb.ToString());
        }
        finally
        {
            _generationLock.Release();
        }
    }

    private static LlmGenerationResult SanitizeModelOutput(string raw)
    {
        string cleanedRaw = raw.Replace("<|im_end|>", string.Empty, StringComparison.Ordinal)
                               .Replace("<|im_start|>", string.Empty, StringComparison.Ordinal)
                               .Trim();

        var thoughtMatches = Regex.Matches(cleanedRaw, @"<think>(.*?)</think>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        string thinkingText = string.Join("\n\n", thoughtMatches
            .Select(match => match.Groups[1].Value.Trim())
            .Where(text => !string.IsNullOrWhiteSpace(text)));

        string visible = Regex.Replace(cleanedRaw, @"<think>.*?</think>", string.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        visible = Regex.Replace(visible, @"</?think>", string.Empty, RegexOptions.IgnoreCase);
        visible = NormalizeVisibleOutput(visible);

        if (string.IsNullOrWhiteSpace(visible))
        {
            visible = ExtractVisibleCandidate(cleanedRaw);
        }

        visible = string.IsNullOrWhiteSpace(visible) ? "……" : visible;
        return new LlmGenerationResult(cleanedRaw, visible, thinkingText);
    }

    private static string NormalizeVisibleOutput(string text)
    {
        var lines = text
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
            .Select(CleanVisibleLine)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Where(line => !LooksLikeMetaLine(line))
            .ToList();

        return lines.Count == 0 ? string.Empty : string.Join(" ", lines);
    }

    private static string ExtractVisibleCandidate(string raw)
    {
        var candidates = raw
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
            .Select(CleanVisibleLine)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Where(line => !LooksLikeMetaLine(line))
            .ToList();

        string? quoted = candidates.LastOrDefault(line => line.Contains('「') || line.Contains('」'));
        if (!string.IsNullOrWhiteSpace(quoted))
        {
            return quoted;
        }

        string? shortLine = candidates.LastOrDefault(line => line.Length <= 80);
        return shortLine ?? string.Empty;
    }

    private static string CleanVisibleLine(string line)
    {
        return line.Trim()
                   .Replace("assistant", string.Empty, StringComparison.OrdinalIgnoreCase)
                   .Trim();
    }

    private static bool LooksLikeMetaLine(string line)
    {
        string[] metaMarkers =
        {
            "好的",
            "首先",
            "接下来",
            "用户",
            "规则",
            "输出规则",
            "当前情境",
            "施动者",
            "受动者",
            "需要处理",
            "请不要返回",
            "/no_think"
        };

        return metaMarkers.Any(marker => line.Contains(marker, StringComparison.Ordinal));
    }

    private static void EnsureNativeLoggingConfigured()
    {
        if (Interlocked.Exchange(ref _nativeLogConfigured, 1) == 1)
        {
            return;
        }

        try
        {
            if (!NativeLibraryConfig.LLama.LibraryHasLoaded)
            {
                NativeLibraryConfig.All.WithLogCallback(NativeLogCallback);
            }
            else
            {
                NativeLogConfig.llama_log_set(NativeLogCallback);
            }
        }
        catch (InvalidOperationException)
        {
            NativeLogConfig.llama_log_set(NativeLogCallback);
        }
        catch (NotImplementedException)
        {
            // Some backends may not support callback wiring here; best effort only.
        }
    }

    private static void HandleNativeLog(LLamaLogLevel level, string message)
    {
        if (level != LLamaLogLevel.Error || string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        Console.Error.Write(message.TrimEnd());
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        _generationLock.Dispose();
        _context.Dispose();
        _weights.Dispose();
    }
}
