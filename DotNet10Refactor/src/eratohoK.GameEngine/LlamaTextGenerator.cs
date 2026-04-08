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

        var promptTemplate = $"<|im_start|>system\n你是一个文字游戏口上润色器。\n允许你在<think>...</think>中进行内部思考，但最终给玩家看的台词请直接写出。\n受动角色必须使用第一人称。\n<|im_end|>\n<|im_start|>user\n{prompt}<|im_end|>\n<|im_start|>assistant\n";

        var inferenceParams = new InferenceParams()
        {
            SamplingPipeline = new LLama.Sampling.DefaultSamplingPipeline
            {
                Temperature = 0.6f,
                TopK = 20,
                TopP = 0.95f,
                MinP = 0f
            },
            MaxTokens = 4096,
            AntiPrompts = new List<string> { "<|im_end|>" }
        };

        await _generationLock.WaitAsync().ConfigureAwait(false);
        try
        {
            _context.NativeHandle.MemoryClear(true);
            _context.LoadState(_initialContextState);
            await _executor.LoadState(_initialState, CancellationToken.None).ConfigureAwait(false);

            var sb = new StringBuilder();
            
            // Console text color logic to distinguish generation if needed, or just plain Console.Write
            Console.ForegroundColor = ConsoleColor.DarkGray; // For <think> etc., wait we can just print it
            await foreach (var text in _executor.InferAsync(promptTemplate, inferenceParams, CancellationToken.None).ConfigureAwait(false))
            {
                Console.Write(text);
                sb.Append(text);
            }
            Console.ResetColor();
            Console.WriteLine();

            var resultText = sb.ToString().Replace("<|im_end|>", "").Trim();
            return new LlmGenerationResult(resultText, resultText, string.Empty);
        }
        finally
        {
            _generationLock.Release();
        }
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
