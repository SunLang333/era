namespace eratohoK.GameEngine;

using System;
using System.Threading.Tasks;

public interface IDynamicTextGenerator
{
    Task<string> GenerateReactionAsync(string prompt);
}

public class MockLlmTextGenerator : IDynamicTextGenerator
{
    public async Task<string> GenerateReactionAsync(string prompt)
    {
        // 模拟外部 LLM API 的异步请求延迟 (如 Ollama / llama.cpp / HTTP API)
        await Task.Delay(1500); 
        
        return "「...变态。不过如果你非要这样的话，哼。」\n(根据 Semantic Context 标签实时渲染的口上占位符)";
    }
}