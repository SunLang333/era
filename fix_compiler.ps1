$filepath = '.\DotNet10Refactor\src\eratohoK.Semantics\KoujouSemanticCompiler.cs'
$content = Get-Content $filepath -Raw

$newAppend = @"
    private static IReadOnlyList<KoujouNormalizedCondition> AppendNormalizedCondition(IReadOnlyList<KoujouNormalizedCondition> existing, KoujouNormalizedCondition condition)
    {
        if (existing.Count == 0)
        {
            return [condition];
        }

        var copy = new KoujouNormalizedCondition[existing.Count + 1];
        for (int i = 0; i < existing.Count; i++)
        {
            copy[i] = existing[i];
        }
        copy[^1] = condition;
        return copy;
    }

    private static IReadOnlyList<string> AppendCondition
"@

$content = $content.Replace("    private static IReadOnlyList<string> AppendCondition", $newAppend)

Set-Content $filepath $content
