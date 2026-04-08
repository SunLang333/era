namespace eratohoK.GameEngine;

using System;
using System.Threading.Tasks;

public sealed record LlmGenerationResult(string RawText, string VisibleText, string ThinkingText)
{
    public bool HasVisibleText => !string.IsNullOrWhiteSpace(VisibleText);
}

public interface IDynamicTextGenerator
{
    Task<LlmGenerationResult> GenerateReactionAsync(string prompt);
}

public class MockLlmTextGenerator : IDynamicTextGenerator
{
    public async Task<LlmGenerationResult> GenerateReactionAsync(string prompt)
    {
        // 模拟外部 LLM API 的异步请求延迟 (如 Ollama / llama.cpp / HTTP API)
        await Task.Delay(1500); 
        
        const string output = "「...变态。不过如果你非要这样的话，哼。」\n(根据 Semantic Context 标签实时渲染的口上占位符)";
        return new LlmGenerationResult(output, output, string.Empty);
    }
}