namespace eratohoK.GameEngine;

using System;
using System.IO;
using System.Text;

/// <summary>
/// 记录被判定为无效的 LLM 输出，便于后续调 prompt 或采样参数。
/// </summary>
public static class LlmBadOutputLogger
{
    private static readonly object SyncRoot = new();
    private static readonly string LogPath = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "logs", "llm-bad-output.log"));

    public static void Log(string targetName, int attempt, string reason, string prompt, string output)
    {
        try
        {
            var directory = Path.GetDirectoryName(LogPath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var builder = new StringBuilder();
            builder.AppendLine($"[{DateTimeOffset.Now:O}] target={targetName} attempt={attempt} reason={reason}");
            builder.AppendLine("--- prompt ---");
            builder.AppendLine(prompt.Trim());
            builder.AppendLine("--- output ---");
            builder.AppendLine(string.IsNullOrWhiteSpace(output) ? "<empty>" : output.Trim());
            builder.AppendLine(new string('-', 80));

            lock (SyncRoot)
            {
                File.AppendAllText(LogPath, builder.ToString(), Encoding.UTF8);
            }
        }
        catch
        {
            // 日志失败不影响主流程。
        }
    }
}
