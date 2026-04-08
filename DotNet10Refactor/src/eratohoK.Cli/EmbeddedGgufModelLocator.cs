namespace eratohoK.Cli;

using System.Reflection;

internal static class EmbeddedGgufModelLocator
{
    private const string ModelExtension = ".gguf";
    private const string ExtractedModelPrefix = "embedded-model";

    public static string ResolveModelPath()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var embeddedResources = assembly
            .GetManifestResourceNames()
            .Where(name => name.EndsWith(ModelExtension, StringComparison.OrdinalIgnoreCase))
            .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        return embeddedResources.Length switch
        {
            1 => ExtractEmbeddedModel(assembly, embeddedResources[0]),
            > 1 => throw new InvalidOperationException(
                $"複数の埋め込み GGUF が見つかりました: {string.Join(", ", embeddedResources)}。models フォルダには 1 つだけ配置してください。"),
            _ => ResolveSidecarModelPath()
        };
    }

    private static string ResolveSidecarModelPath()
    {
        var candidateDirectories = new[]
        {
            AppContext.BaseDirectory,
            Path.Combine(AppContext.BaseDirectory, "models")
        }
            .Where(Directory.Exists)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        var candidates = candidateDirectories
            .SelectMany(directory => Directory.GetFiles(directory, $"*{ModelExtension}", SearchOption.TopDirectoryOnly))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        return candidates.Length switch
        {
            1 => Path.GetFullPath(candidates[0]),
            > 1 => throw new InvalidOperationException(
                $"複数の GGUF ファイルが見つかりました: {string.Join(", ", candidates)}。1 つだけ残してください。"),
            _ => throw new FileNotFoundException(
                "GGUF モデルが見つかりませんでした。ビルド前に eratohoK.Cli/models/ に .gguf を 1 つ置くと exe に埋め込まれます。")
        };
    }

    private static string ExtractEmbeddedModel(Assembly assembly, string resourceName)
    {
        using var resourceStream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException($"埋め込みリソース '{resourceName}' を開けませんでした。");

        var cacheDirectory = GetCacheDirectory();
        Directory.CreateDirectory(cacheDirectory);

        var buildStamp = GetBuildStamp();
        var outputFileName = buildStamp > 0
            ? $"{ExtractedModelPrefix}-{buildStamp}{ModelExtension}"
            : $"{ExtractedModelPrefix}{ModelExtension}";
        var outputPath = Path.Combine(cacheDirectory, outputFileName);

        if (File.Exists(outputPath))
        {
            if (!resourceStream.CanSeek)
            {
                return outputPath;
            }

            var existingLength = new FileInfo(outputPath).Length;
            if (existingLength == resourceStream.Length)
            {
                return outputPath;
            }

            resourceStream.Position = 0;
        }

        var tempPath = outputPath + ".tmp";
        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            resourceStream.CopyTo(fileStream);
        }

        File.Move(tempPath, outputPath, overwrite: true);
        CleanupOldExtractedModels(cacheDirectory, outputPath);
        return outputPath;
    }

    private static string GetCacheDirectory()
    {
        var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return string.IsNullOrWhiteSpace(localAppData)
            ? Path.Combine(AppContext.BaseDirectory, ".model-cache")
            : Path.Combine(localAppData, "eratohoK", "model-cache");
    }

    private static long GetBuildStamp()
    {
        var entryAssemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
        var candidatePaths = new[]
        {
            Environment.ProcessPath,
            !string.IsNullOrWhiteSpace(entryAssemblyName)
                ? Path.Combine(AppContext.BaseDirectory, $"{entryAssemblyName}.exe")
                : null,
            !string.IsNullOrWhiteSpace(entryAssemblyName)
                ? Path.Combine(AppContext.BaseDirectory, $"{entryAssemblyName}.dll")
                : null
        }
            .Where(path => !string.IsNullOrWhiteSpace(path) && File.Exists(path!))
            .Select(path => path!)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var candidatePath in candidatePaths)
        {
            return File.GetLastWriteTimeUtc(candidatePath).ToFileTimeUtc();
        }

        return 0;
    }

    private static void CleanupOldExtractedModels(string cacheDirectory, string activeModelPath)
    {
        foreach (var candidatePath in Directory.EnumerateFiles(cacheDirectory, $"{ExtractedModelPrefix}*{ModelExtension}", SearchOption.TopDirectoryOnly))
        {
            if (string.Equals(candidatePath, activeModelPath, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            try
            {
                File.Delete(candidatePath);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}