namespace eratohoK.Semantics;

using System.Collections.ObjectModel;
using eratohoK.Core;

/// <summary>
/// 口上 ERB をセマンティック中間表現へコンパイルする前端
/// </summary>
public sealed class KoujouSemanticCompiler
{
    private readonly string? _contentRoot;

    public KoujouSemanticCompiler(string? contentRoot = null)
    {
        _contentRoot = contentRoot;
    }

    public KoujouSemanticCompilation? CompileCharacter(string characterId)
    {
        var koujouRoot = ResolveKoujouRoot();
        if (koujouRoot == null)
        {
            return null;
        }

        var characterDirectory = FindCharacterDirectory(koujouRoot, characterId);
        if (characterDirectory == null)
        {
            return null;
        }

        var metadata = ParseCharacterMetadata(Path.GetFileName(characterDirectory));
        var compilation = new KoujouSemanticCompilation
        {
            RequestedCharacterId = characterId,
            CharacterId = metadata.CharacterId?.ToString() ?? characterId,
            CharacterName = metadata.CharacterName,
            KoujouRoot = koujouRoot,
            CharacterDirectory = characterDirectory
        };

        foreach (var filePath in Directory.EnumerateFiles(characterDirectory, "*.*", SearchOption.AllDirectories)
                     .Where(IsSupportedKoujouFile)
                     .OrderBy(static path => path, StringComparer.OrdinalIgnoreCase))
        {
            var relativePath = Path.GetRelativePath(characterDirectory, filePath);
            compilation.Files.Add(CompileFile(filePath, relativePath));
        }

        BuildCallGraph(compilation);

        return compilation;
    }

    public IEnumerable<KoujouSemanticEmission> EnumerateTextEmissions(KoujouSemanticCompilation compilation)
    {
        foreach (var file in compilation.Files)
        {
            foreach (var emission in EnumerateTextEmissions(compilation, file, file.Prelude, procedure: null, [], []))
            {
                yield return emission;
            }

            foreach (var procedure in file.Procedures)
            {
                foreach (var emission in EnumerateTextEmissions(compilation, file, procedure.Body, procedure, [], []))
                {
                    yield return emission;
                }
            }
        }
    }

    private KoujouSemanticSourceFile CompileFile(string filePath, string relativePath)
    {
        var parser = new Parser(filePath, relativePath, File.ReadAllLines(filePath));
        return parser.Parse();
    }

    private static void BuildCallGraph(KoujouSemanticCompilation compilation)
    {
        var proceduresByName = compilation.Procedures
            .GroupBy(static procedure => procedure.Name, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(static group => group.Key, static group => group.First(), StringComparer.OrdinalIgnoreCase);

        foreach (var file in compilation.Files)
        {
            foreach (var call in EnumerateCallStatements(file.Prelude, "__PRELUDE__", file.FilePath))
            {
                compilation.CallEdges.Add(BuildCallEdge(call, proceduresByName));
            }

            foreach (var procedure in file.Procedures)
            {
                foreach (var call in EnumerateCallStatements(procedure.Body, procedure.Name, file.FilePath))
                {
                    compilation.CallEdges.Add(BuildCallEdge(call, proceduresByName));
                }
            }
        }
    }

    private static IEnumerable<(string SourceProcedureName, string SourceFilePath, KoujouSemanticCallStatement Call)> EnumerateCallStatements(
        KoujouSemanticBlock block,
        string sourceProcedureName,
        string sourceFilePath)
    {
        foreach (var statement in block.Statements)
        {
            switch (statement)
            {
                case KoujouSemanticCallStatement callStatement:
                    yield return (sourceProcedureName, sourceFilePath, callStatement);
                    break;

                case KoujouSemanticIfStatement ifStatement:
                    foreach (var nested in EnumerateCallStatements(ifStatement.ThenBlock, sourceProcedureName, sourceFilePath))
                        yield return nested;
                    foreach (var elseIfClause in ifStatement.ElseIfClauses)
                    {
                        foreach (var nested in EnumerateCallStatements(elseIfClause.Body, sourceProcedureName, sourceFilePath))
                            yield return nested;
                    }
                    if (ifStatement.ElseBlock != null)
                    {
                        foreach (var nested in EnumerateCallStatements(ifStatement.ElseBlock, sourceProcedureName, sourceFilePath))
                            yield return nested;
                    }
                    break;

                case KoujouSemanticShortIfStatement shortIfStatement when shortIfStatement.Statement != null:
                    foreach (var nested in EnumerateCallStatements(
                                 new KoujouSemanticBlock { Statements = { shortIfStatement.Statement } },
                                 sourceProcedureName,
                                 sourceFilePath))
                    {
                        yield return nested;
                    }
                    break;

                case KoujouSemanticSelectCaseStatement selectCaseStatement:
                    foreach (var caseClause in selectCaseStatement.Cases)
                    {
                        foreach (var nested in EnumerateCallStatements(caseClause.Body, sourceProcedureName, sourceFilePath))
                            yield return nested;
                    }
                    break;
            }
        }
    }

    private static KoujouSemanticCallEdge BuildCallEdge(
        (string SourceProcedureName, string SourceFilePath, KoujouSemanticCallStatement Call) source,
        IReadOnlyDictionary<string, KoujouSemanticProcedure> proceduresByName)
    {
        var resolvedTarget = source.Call.StaticTargetName != null
                             && proceduresByName.TryGetValue(source.Call.StaticTargetName, out var procedure)
            ? procedure.Name
            : null;

        return new KoujouSemanticCallEdge
        {
            SourceProcedureName = source.SourceProcedureName,
            SourceFilePath = source.SourceFilePath,
            StartLine = source.Call.StartLine,
            EndLine = source.Call.EndLine,
            CallKind = source.Call.CallKind,
            RawTarget = source.Call.RawTarget,
            StaticTargetName = source.Call.StaticTargetName,
            ResolvedTargetProcedureName = resolvedTarget,
            IsDynamicTarget = source.Call.IsDynamicTarget,
            ArgumentCount = source.Call.Arguments.Count
        };
    }

    private IEnumerable<KoujouSemanticEmission> EnumerateTextEmissions(
        KoujouSemanticCompilation compilation,
        KoujouSemanticSourceFile file,
        KoujouSemanticBlock block,
        KoujouSemanticProcedure? procedure,
        IReadOnlyList<string> conditionTrail,
        IReadOnlyList<KoujouNormalizedCondition> normalizedConditionTrail)
    {
        foreach (var statement in block.Statements)
        {
            switch (statement)
            {
                case KoujouSemanticTextStatement textStatement:
                    yield return new KoujouSemanticEmission
                    {
                        CharacterId = compilation.CharacterId,
                        CharacterName = compilation.CharacterName,
                        FilePath = file.FilePath,
                        RelativeFilePath = file.RelativePath,
                        ProcedureName = procedure?.Name ?? "__PRELUDE__",
                        ProcedureSignature = procedure?.Signature,
                        Command = textStatement.Command,
                        Text = textStatement.Text,
                        SourceLineStart = textStatement.StartLine,
                        SourceLineEnd = textStatement.EndLine,
                        ConditionTrail = new System.Collections.ObjectModel.ReadOnlyCollection<string>(conditionTrail.ToArray()),
                        NormalizedConditionTrail = new System.Collections.ObjectModel.ReadOnlyCollection<KoujouNormalizedCondition>(normalizedConditionTrail.ToArray()),
                        IsDialogue = IsDialogueLike(textStatement.Text)
                    };
                    break;

                case KoujouSemanticIfStatement ifStatement:
                    foreach (var emission in EnumerateTextEmissions(
                                 compilation,
                                 file,
                                 ifStatement.ThenBlock,
                                 procedure,
                                 AppendCondition(conditionTrail, $"IF {ifStatement.Condition}"),
                                 AppendNormalizedCondition(normalizedConditionTrail, KoujouConditionNormalizer.Normalize(ifStatement.ConditionExpression))))
                    {
                        yield return emission;
                    }

                    foreach (var elseIfClause in ifStatement.ElseIfClauses)
                    {
                        foreach (var emission in EnumerateTextEmissions(
                                     compilation,
                                     file,
                                     elseIfClause.Body,
                                     procedure,
                                     AppendCondition(conditionTrail, $"ELSEIF {elseIfClause.Condition}"),
                                     AppendNormalizedCondition(normalizedConditionTrail, KoujouConditionNormalizer.Normalize(elseIfClause.ConditionExpression))))
                        {
                            yield return emission;
                        }
                    }

                    if (ifStatement.ElseBlock != null)
                    {
                        foreach (var emission in EnumerateTextEmissions(
                                     compilation,
                                     file,
                                     ifStatement.ElseBlock,
                                     procedure,
                                     AppendCondition(conditionTrail, "ELSE"),
                                     AppendNormalizedCondition(normalizedConditionTrail, new KoujouFallbackCondition("ELSE"))))
                        {
                            yield return emission;
                        }
                    }
                    break;

                case KoujouSemanticShortIfStatement shortIfStatement:
                    if (shortIfStatement.Statement != null)
                    {
                        foreach (var emission in EnumerateTextEmissions(
                                     compilation,
                                     file,
                                     new KoujouSemanticBlock { Statements = { shortIfStatement.Statement } },
                                     procedure,
                                     AppendCondition(conditionTrail, $"SIF {shortIfStatement.Condition}"),
                                     AppendNormalizedCondition(normalizedConditionTrail, KoujouConditionNormalizer.Normalize(shortIfStatement.ConditionExpression))))
                        {
                            yield return emission;
                        }
                    }
                    break;

                case KoujouSemanticSelectCaseStatement selectCaseStatement:
                    foreach (var caseClause in selectCaseStatement.Cases)
                    {
                        var caseTrail = AppendCondition(conditionTrail, $"SELECTCASE {selectCaseStatement.Expression}");
                        caseTrail = AppendCondition(caseTrail, caseClause.IsElse ? "CASEELSE" : $"CASE {caseClause.MatchExpression}");
                        
                        var normalizedCaseTrail = AppendNormalizedCondition(
                            AppendNormalizedCondition(normalizedConditionTrail, KoujouConditionNormalizer.Normalize(selectCaseStatement.SelectorExpression)),
                            KoujouConditionNormalizer.Normalize(caseClause.MatchExpressionNode));

                        foreach (var emission in EnumerateTextEmissions(
                                     compilation,
                                     file,
                                     caseClause.Body,
                                     procedure,
                                     caseTrail,
                                     normalizedCaseTrail))
                        {
                            yield return emission;
                        }
                    }
                    break;
            }
        }
    }

    private string? ResolveKoujouRoot()
    {
        var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var candidate in EnumerateCandidateRoots())
        {
            if (string.IsNullOrWhiteSpace(candidate))
            {
                continue;
            }

            var root = Path.GetFullPath(candidate);
            if (!visited.Add(root))
            {
                continue;
            }

            if (Directory.Exists(root) && string.Equals(Path.GetFileName(root), "口上", StringComparison.OrdinalIgnoreCase))
            {
                return root;
            }

            var koujouRoot = Path.Combine(root, "ERB", "口上");
            if (Directory.Exists(koujouRoot))
            {
                return koujouRoot;
            }

            var direct = Path.Combine(root, "口上");
            if (Directory.Exists(direct))
            {
                return direct;
            }
        }

        return null;
    }

    private IEnumerable<string> EnumerateCandidateRoots()
    {
        if (!string.IsNullOrWhiteSpace(_contentRoot))
        {
            yield return _contentRoot;
        }

        yield return Directory.GetCurrentDirectory();
        yield return AppContext.BaseDirectory;

        foreach (var seed in new[] { _contentRoot, Directory.GetCurrentDirectory(), AppContext.BaseDirectory }
                     .Where(static path => !string.IsNullOrWhiteSpace(path))
                     .Distinct(StringComparer.OrdinalIgnoreCase)
                     .Cast<string>())
        {
            var current = new DirectoryInfo(Path.GetFullPath(seed));
            while (current != null)
            {
                yield return current.FullName;
                current = current.Parent;
            }
        }
    }

    private static string? FindCharacterDirectory(string koujouRoot, string characterId)
    {
        var directories = Directory.EnumerateDirectories(koujouRoot).ToList();
        if (TryParseLeadingNumber(characterId, out var requestedId))
        {
            return directories.FirstOrDefault(directory =>
                TryParseLeadingNumber(Path.GetFileName(directory), out var currentId) && currentId == requestedId);
        }

        return directories.FirstOrDefault(directory =>
            Path.GetFileName(directory).Contains(characterId, StringComparison.OrdinalIgnoreCase));
    }

    private static (int? CharacterId, string CharacterName) ParseCharacterMetadata(string? directoryName)
    {
        directoryName ??= string.Empty;

        int? characterId = null;
        if (TryParseLeadingNumber(directoryName, out var parsedId))
        {
            characterId = parsedId;
        }

        var nameStart = 0;
        while (nameStart < directoryName.Length && char.IsDigit(directoryName[nameStart]))
        {
            nameStart++;
        }

        var characterName = directoryName[nameStart..]
            .Replace("口上", string.Empty, StringComparison.Ordinal)
            .Trim();

        if (string.IsNullOrWhiteSpace(characterName))
        {
            characterName = directoryName.Trim();
        }

        return (characterId, characterName);
    }

    private static bool TryParseLeadingNumber(string value, out int number)
    {
        var length = 0;
        while (length < value.Length && char.IsDigit(value[length]))
        {
            length++;
        }

        if (length == 0)
        {
            number = 0;
            return false;
        }

        return int.TryParse(value[..length], out number);
    }

    private static bool IsSupportedKoujouFile(string filePath)
    {
        var extension = Path.GetExtension(filePath);
        return extension.Equals(".ERB", StringComparison.OrdinalIgnoreCase)
            || extension.Equals(".ERH", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsDialogueLike(string text)
    {
        var trimmed = text.TrimStart();
        return trimmed.StartsWith('「')
               || trimmed.StartsWith('『')
               || trimmed.StartsWith('（')
               || trimmed.StartsWith('“')
               || (trimmed.StartsWith('"') && trimmed.EndsWith('"'));
    }

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

    private static IReadOnlyList<string> AppendCondition(IReadOnlyList<string> existing, string condition)
    {
        if (existing.Count == 0)
        {
            return [condition];
        }

        var copy = new string[existing.Count + 1];
        for (int i = 0; i < existing.Count; i++)
        {
            copy[i] = existing[i];
        }
        copy[^1] = condition;
        return copy;
    }

    private sealed class Parser
    {
        private static readonly string[] CallKeywords = ["TRYCCALLFORM", "TRYCALLFORM", "TRYCCALL", "TRYCALL", "CALLFORM", "CALL"];
        private static readonly string[] PrintCommands = ["PRINTFORMW", "PRINTFORML", "PRINTFORM"];

        private readonly string _filePath;
        private readonly string _relativePath;
        private readonly string[] _lines;
        private int _index;

        public Parser(string filePath, string relativePath, string[] lines)
        {
            _filePath = filePath;
            _relativePath = relativePath;
            _lines = lines;
        }

        public KoujouSemanticSourceFile Parse()
        {
            var file = new KoujouSemanticSourceFile
            {
                FilePath = _filePath,
                RelativePath = _relativePath,
                Prelude = ParseBlock(stopAtProcedureBoundary: true)
            };

            while (!IsAtEnd())
            {
                SkipIgnorable();
                if (IsAtEnd())
                {
                    break;
                }

                if (CurrentTrimmed().StartsWith('@'))
                {
                    file.Procedures.Add(ParseProcedure());
                    continue;
                }

                var statement = ParseStatement(stopAtProcedureBoundary: true);
                if (statement != null)
                {
                    file.Prelude.Statements.Add(statement);
                }
            }

            return file;
        }

        private KoujouSemanticProcedure ParseProcedure()
        {
            var signature = CurrentTrimmed();
            var name = ParseProcedureName(signature);
            var startLine = CurrentLineNumber();
            Advance();

            var body = ParseBlock(stopAtProcedureBoundary: true);
            var endLine = body.EndLine ?? startLine;

            return new KoujouSemanticProcedure
            {
                Name = name,
                Signature = signature,
                StartLine = startLine,
                EndLine = endLine,
                Body = body
            };
        }

        private KoujouSemanticBlock ParseBlock(bool stopAtProcedureBoundary, params string[] terminators)
        {
            var block = new KoujouSemanticBlock();

            while (true)
            {
                SkipIgnorable();
                if (IsAtEnd())
                {
                    break;
                }

                var trimmed = CurrentTrimmed();
                if (stopAtProcedureBoundary && trimmed.StartsWith('@'))
                {
                    break;
                }

                if (IsTerminator(trimmed, terminators))
                {
                    break;
                }

                var statement = ParseStatement(stopAtProcedureBoundary);
                if (statement != null)
                {
                    block.Statements.Add(statement);
                }
            }

            return block;
        }

        private KoujouSemanticStatement? ParseStatement(bool stopAtProcedureBoundary)
        {
            SkipIgnorable();
            if (IsAtEnd())
            {
                return null;
            }

            var rawLine = CurrentRaw();
            var trimmed = CurrentTrimmed();
            var lineNumber = CurrentLineNumber();

            if (stopAtProcedureBoundary && trimmed.StartsWith('@'))
            {
                return null;
            }

            if (trimmed.StartsWith("IF ", StringComparison.OrdinalIgnoreCase))
            {
                return ParseIfStatement();
            }

            if (trimmed.StartsWith("SIF ", StringComparison.OrdinalIgnoreCase))
            {
                return ParseShortIfStatement();
            }

            if (trimmed.StartsWith("SELECTCASE", StringComparison.OrdinalIgnoreCase))
            {
                return ParseSelectCaseStatement();
            }

            if (trimmed.StartsWith('$'))
            {
                Advance();
                return new KoujouSemanticLabelStatement(lineNumber, lineNumber, rawLine, trimmed);
            }

            if (trimmed.StartsWith("RETURN", StringComparison.OrdinalIgnoreCase))
            {
                Advance();
                var valueExpression = trimmed.Length > "RETURN".Length
                    ? trimmed["RETURN".Length..].Trim()
                    : string.Empty;
                var parsedValueExpression = TryParseExpression(valueExpression);
                return new KoujouSemanticReturnStatement(lineNumber, lineNumber, rawLine, valueExpression, parsedValueExpression);
            }

            if (TryMatchCallDirective(trimmed, out var callKind, out var remainder))
            {
                Advance();
                return ParseCallStatement(lineNumber, rawLine, callKind, remainder);
            }

            if (TryExtractPrintedText(rawLine, out var command, out var text))
            {
                Advance();
                return new KoujouSemanticTextStatement(lineNumber, lineNumber, rawLine, command, text);
            }

            Advance();
            return new KoujouSemanticDirectiveStatement(lineNumber, lineNumber, rawLine, InferDirectiveKind(trimmed), trimmed);
        }

        private KoujouSemanticIfStatement ParseIfStatement()
        {
            var startLine = CurrentLineNumber();
            var rawLine = CurrentRaw();
            var condition = CurrentTrimmed()["IF".Length..].Trim();
            var parsedCondition = TryParseExpression(condition);
            Advance();

            var thenBlock = ParseBlock(stopAtProcedureBoundary: false, "ELSEIF", "ELSE", "ENDIF");
            var elseIfClauses = new List<KoujouSemanticElseIfClause>();
            KoujouSemanticBlock? elseBlock = null;
            var endLine = thenBlock.EndLine ?? startLine;

            while (!IsAtEnd() && CurrentTrimmed().StartsWith("ELSEIF", StringComparison.OrdinalIgnoreCase))
            {
                var clauseStart = CurrentLineNumber();
                var elseIfCondition = CurrentTrimmed()["ELSEIF".Length..].Trim();
                Advance();
                var body = ParseBlock(stopAtProcedureBoundary: false, "ELSEIF", "ELSE", "ENDIF");
                endLine = body.EndLine ?? clauseStart;
                elseIfClauses.Add(new KoujouSemanticElseIfClause(
                    clauseStart,
                    endLine,
                    elseIfCondition,
                    TryParseExpression(elseIfCondition),
                    body));
            }

            if (!IsAtEnd() && CurrentTrimmed().Equals("ELSE", StringComparison.OrdinalIgnoreCase))
            {
                Advance();
                elseBlock = ParseBlock(stopAtProcedureBoundary: false, "ENDIF");
                endLine = elseBlock.EndLine ?? endLine;
            }

            if (!IsAtEnd() && CurrentTrimmed().Equals("ENDIF", StringComparison.OrdinalIgnoreCase))
            {
                endLine = CurrentLineNumber();
                Advance();
            }

            return new KoujouSemanticIfStatement(startLine, endLine, rawLine, condition, parsedCondition, thenBlock, elseIfClauses, elseBlock);
        }

        private KoujouSemanticShortIfStatement ParseShortIfStatement()
        {
            var startLine = CurrentLineNumber();
            var rawLine = CurrentRaw();
            var condition = CurrentTrimmed()["SIF".Length..].Trim();
            var parsedCondition = TryParseExpression(condition);
            Advance();
            var statement = ParseStatement(stopAtProcedureBoundary: false);
            var endLine = statement?.EndLine ?? startLine;
            return new KoujouSemanticShortIfStatement(startLine, endLine, rawLine, condition, parsedCondition, statement);
        }

        private KoujouSemanticSelectCaseStatement ParseSelectCaseStatement()
        {
            var startLine = CurrentLineNumber();
            var rawLine = CurrentRaw();
            var expression = CurrentTrimmed()["SELECTCASE".Length..].Trim();
            var parsedExpression = TryParseExpression(expression);
            Advance();

            var clauses = new List<KoujouSemanticCaseClause>();
            var endLine = startLine;

            while (!IsAtEnd())
            {
                SkipIgnorable();
                if (IsAtEnd())
                {
                    break;
                }

                var trimmed = CurrentTrimmed();
                if (trimmed.Equals("ENDSELECT", StringComparison.OrdinalIgnoreCase))
                {
                    endLine = CurrentLineNumber();
                    Advance();
                    break;
                }

                if (trimmed.StartsWith("CASEELSE", StringComparison.OrdinalIgnoreCase))
                {
                    var clauseStart = CurrentLineNumber();
                    Advance();
                    var body = ParseBlock(stopAtProcedureBoundary: false, "CASE", "CASEELSE", "ENDSELECT");
                    endLine = body.EndLine ?? clauseStart;
                    clauses.Add(new KoujouSemanticCaseClause(clauseStart, endLine, string.Empty, null, body, isElse: true));
                    continue;
                }

                if (trimmed.StartsWith("CASE", StringComparison.OrdinalIgnoreCase))
                {
                    var clauseStart = CurrentLineNumber();
                    var matchExpression = trimmed["CASE".Length..].Trim();
                    Advance();
                    var body = ParseBlock(stopAtProcedureBoundary: false, "CASE", "CASEELSE", "ENDSELECT");
                    endLine = body.EndLine ?? clauseStart;
                    clauses.Add(new KoujouSemanticCaseClause(
                        clauseStart,
                        endLine,
                        matchExpression,
                        TryParseCaseExpression(matchExpression),
                        body,
                        isElse: false));
                    continue;
                }

                var directive = ParseStatement(stopAtProcedureBoundary: false);
                if (directive != null)
                {
                    clauses.Add(new KoujouSemanticCaseClause(
                        directive.StartLine,
                        directive.EndLine,
                        "__IMPLICIT__",
                        null,
                        new KoujouSemanticBlock { Statements = { directive } },
                        isElse: false));
                }
            }

            return new KoujouSemanticSelectCaseStatement(startLine, endLine, rawLine, expression, parsedExpression, clauses);
        }

        private KoujouSemanticCallStatement ParseCallStatement(int lineNumber, string rawLine, KoujouSemanticCallKind callKind, string remainder)
        {
            var trimmedRemainder = remainder.Trim();
            var (rawTarget, rawArguments) = SplitCallTargetAndArguments(trimmedRemainder);
            var parsedTarget = ShouldParseStructuredExpression(rawTarget)
                ? KoujouSemanticExpressionParser.ParseOrRaw(rawTarget)
                : new KoujouRawExpression(rawTarget);
            var arguments = rawArguments.Count == 0
                ? Array.Empty<KoujouSemanticExpression>()
                : rawArguments.Select(KoujouSemanticExpressionParser.ParseOrRaw).ToArray();

            return new KoujouSemanticCallStatement(
                lineNumber,
                lineNumber,
                rawLine,
                callKind,
                rawTarget,
                parsedTarget,
                rawArguments,
                arguments,
                TryResolveStaticCallTargetName(rawTarget),
                IsDynamicCallTarget(rawTarget));
        }

        private void SkipIgnorable()
        {
            while (!IsAtEnd())
            {
                var trimmed = CurrentTrimmed();
                if (!string.IsNullOrWhiteSpace(trimmed) && !trimmed.StartsWith(';'))
                {
                    break;
                }
                Advance();
            }
        }

        private bool IsTerminator(string trimmed, string[] terminators)
        {
            foreach (var terminator in terminators)
            {
                if (trimmed.Equals(terminator, StringComparison.OrdinalIgnoreCase)
                    || trimmed.StartsWith(terminator + " ", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsAtEnd() => _index >= _lines.Length;
        private string CurrentRaw() => _lines[_index];
        private string CurrentTrimmed() => _lines[_index].Trim();
        private int CurrentLineNumber() => _index + 1;
        private void Advance() => _index++;

        private static string ParseProcedureName(string signature)
        {
            var body = signature.TrimStart('@').Trim();
            var parenthesisIndex = body.IndexOf('(');
            return parenthesisIndex >= 0 ? body[..parenthesisIndex].Trim() : body;
        }

        private static bool TryExtractPrintedText(string rawLine, out string command, out string text)
        {
            var trimmedStart = rawLine.TrimStart();
            foreach (var candidate in PrintCommands)
            {
                if (!trimmedStart.StartsWith(candidate, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                command = candidate;
                text = trimmedStart[candidate.Length..].Trim(' ', '\t', '　');
                return !string.IsNullOrWhiteSpace(text);
            }

            command = string.Empty;
            text = string.Empty;
            return false;
        }

        private static bool TryMatchCallDirective(string trimmed, out KoujouSemanticCallKind callKind, out string remainder)
        {
            foreach (var keyword in CallKeywords)
            {
                if (trimmed.StartsWith(keyword, StringComparison.OrdinalIgnoreCase)
                    && (trimmed.Length == keyword.Length || char.IsWhiteSpace(trimmed[keyword.Length])))
                {
                    callKind = ParseCallKind(keyword);
                    remainder = trimmed[keyword.Length..].Trim();
                    return true;
                }
            }

            callKind = KoujouSemanticCallKind.Unknown;
            remainder = string.Empty;
            return false;
        }

        private static KoujouSemanticCallKind ParseCallKind(string keyword)
            => keyword.ToUpperInvariant() switch
            {
                "CALL" => KoujouSemanticCallKind.Call,
                "CALLFORM" => KoujouSemanticCallKind.CallForm,
                "TRYCALL" => KoujouSemanticCallKind.TryCall,
                "TRYCCALL" => KoujouSemanticCallKind.TryCcCall,
                "TRYCALLFORM" => KoujouSemanticCallKind.TryCallForm,
                "TRYCCALLFORM" => KoujouSemanticCallKind.TryCcCallForm,
                _ => KoujouSemanticCallKind.Unknown
            };

        private static (string RawTarget, IReadOnlyList<string> RawArguments) SplitCallTargetAndArguments(string remainder)
        {
            if (string.IsNullOrWhiteSpace(remainder))
            {
                return (string.Empty, Array.Empty<string>());
            }

            if (TrySplitFunctionStyleCall(remainder, out var callee, out var argumentPayload))
            {
                return (callee, KoujouSemanticExpressionParser.SplitTopLevel(argumentPayload));
            }

            var splitArguments = KoujouSemanticExpressionParser.SplitTopLevel(remainder);
            if (splitArguments.Count == 0)
            {
                return (remainder, Array.Empty<string>());
            }

            return (splitArguments[0], splitArguments.Skip(1).ToArray());
        }

        private static bool TrySplitFunctionStyleCall(string remainder, out string callee, out string argumentPayload)
        {
            callee = string.Empty;
            argumentPayload = string.Empty;
            if (string.IsNullOrWhiteSpace(remainder) || !remainder.EndsWith(')'))
            {
                return false;
            }

            var depth = 0;
            var openIndex = -1;
            bool inString = false;
            char stringDelimiter = '\0';

            for (int i = 0; i < remainder.Length; i++)
            {
                var ch = remainder[i];
                if (inString)
                {
                    if (ch == stringDelimiter)
                    {
                        inString = false;
                    }
                    continue;
                }

                if (ch is '"' or '\'')
                {
                    inString = true;
                    stringDelimiter = ch;
                    continue;
                }

                if (ch == '(')
                {
                    if (depth == 0)
                    {
                        openIndex = i;
                    }
                    depth++;
                }
                else if (ch == ')')
                {
                    depth--;
                    if (depth == 0 && i != remainder.Length - 1)
                    {
                        return false;
                    }
                }
            }

            if (openIndex <= 0 || depth != 0)
            {
                return false;
            }

            callee = remainder[..openIndex].Trim();
            argumentPayload = remainder[(openIndex + 1)..^1].Trim();
            return !string.IsNullOrWhiteSpace(callee);
        }

        private static bool ShouldParseStructuredExpression(string rawTarget)
            => !string.IsNullOrWhiteSpace(rawTarget)
               && !rawTarget.Contains('%')
               && !rawTarget.Contains('{')
               && !rawTarget.Contains('}')
               && !rawTarget.Contains('@');

        private static KoujouSemanticExpression? TryParseExpression(string rawExpression)
        {
            if (string.IsNullOrWhiteSpace(rawExpression))
            {
                return null;
            }

            return KoujouSemanticExpressionParser.ParseOrRaw(rawExpression);
        }

        private static KoujouSemanticExpression? TryParseCaseExpression(string rawExpression)
        {
            if (string.IsNullOrWhiteSpace(rawExpression))
            {
                return null;
            }

            var normalized = rawExpression.Trim();
            if (normalized.StartsWith("IS ", StringComparison.OrdinalIgnoreCase)
                || normalized.StartsWith("TO", StringComparison.OrdinalIgnoreCase))
            {
                return new KoujouRawExpression(normalized);
            }

            return TryParseExpression(normalized);
        }

        private static string? TryResolveStaticCallTargetName(string rawTarget)
        {
            if (string.IsNullOrWhiteSpace(rawTarget) || IsDynamicCallTarget(rawTarget))
            {
                return null;
            }

            if (TrySplitFunctionStyleCall(rawTarget, out var callee, out _))
            {
                rawTarget = callee;
            }

            var end = rawTarget.IndexOfAny([' ', '\t', ',', ':']);
            var candidate = (end >= 0 ? rawTarget[..end] : rawTarget).Trim();
            return string.IsNullOrWhiteSpace(candidate) ? null : candidate;
        }

        private static bool IsDynamicCallTarget(string rawTarget)
            => rawTarget.Contains('%') || rawTarget.Contains('{') || rawTarget.Contains('}');

        private static string InferDirectiveKind(string trimmed)
        {
            if (string.IsNullOrWhiteSpace(trimmed))
            {
                return "Empty";
            }

            var separators = new[] { ' ', '\t', '(', ':', '=', '+', '-', ',' };
            var end = trimmed.IndexOfAny(separators);
            return end <= 0 ? trimmed : trimmed[..end];
        }
    }
}

public sealed class KoujouSemanticCompilation
{
    public string RequestedCharacterId { get; init; } = string.Empty;
    public string CharacterId { get; init; } = string.Empty;
    public string CharacterName { get; init; } = string.Empty;
    public string KoujouRoot { get; init; } = string.Empty;
    public string CharacterDirectory { get; init; } = string.Empty;
    public List<KoujouSemanticSourceFile> Files { get; } = [];
    public List<KoujouSemanticCallEdge> CallEdges { get; } = [];

    public IEnumerable<KoujouSemanticProcedure> Procedures => Files.SelectMany(static file => file.Procedures);

    public int RecursiveStatementCount => Files.Sum(static file => file.RecursiveStatementCount);
    public int TextStatementCount => Files.Sum(static file => file.TextStatementCount);
    public int StructuredExpressionCount => Files.Sum(static file => file.StructuredExpressionCount);
    public int CallStatementCount => CallEdges.Count;
    public int ResolvedCallEdgeCount => CallEdges.Count(static edge => edge.ResolvedTargetProcedureName != null);
}

public sealed class KoujouSemanticSourceFile
{
    public string FilePath { get; init; } = string.Empty;
    public string RelativePath { get; init; } = string.Empty;
    public KoujouSemanticBlock Prelude { get; init; } = new();
    public List<KoujouSemanticProcedure> Procedures { get; } = [];

    public int RecursiveStatementCount => Prelude.CountStatementsRecursive() + Procedures.Sum(static procedure => procedure.Body.CountStatementsRecursive());
    public int TextStatementCount => Prelude.CountTextStatementsRecursive() + Procedures.Sum(static procedure => procedure.Body.CountTextStatementsRecursive());
    public int StructuredExpressionCount => Prelude.CountStructuredExpressionsRecursive() + Procedures.Sum(static procedure => procedure.Body.CountStructuredExpressionsRecursive());
}

public sealed class KoujouSemanticProcedure
{
    public string Name { get; init; } = string.Empty;
    public string Signature { get; init; } = string.Empty;
    public int StartLine { get; init; }
    public int EndLine { get; init; }
    public KoujouSemanticBlock Body { get; init; } = new();
}

public sealed class KoujouSemanticEmission
{
    public string CharacterId { get; init; } = string.Empty;
    public string CharacterName { get; init; } = string.Empty;
    public string FilePath { get; init; } = string.Empty;
    public string RelativeFilePath { get; init; } = string.Empty;
    public string ProcedureName { get; init; } = string.Empty;
    public string? ProcedureSignature { get; init; }
    public string Command { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public int SourceLineStart { get; init; }
    public int SourceLineEnd { get; init; }
    public IReadOnlyList<string> ConditionTrail { get; init; } = Array.Empty<string>();
    public IReadOnlyList<KoujouNormalizedCondition> NormalizedConditionTrail { get; init; } = Array.Empty<KoujouNormalizedCondition>();
    public bool IsDialogue { get; init; }
}

public enum KoujouSemanticCallKind
{
    Unknown = 0,
    Call,
    CallForm,
    TryCall,
    TryCcCall,
    TryCallForm,
    TryCcCallForm
}

public sealed class KoujouSemanticCallEdge
{
    public string SourceProcedureName { get; init; } = string.Empty;
    public string SourceFilePath { get; init; } = string.Empty;
    public int StartLine { get; init; }
    public int EndLine { get; init; }
    public KoujouSemanticCallKind CallKind { get; init; }
    public string RawTarget { get; init; } = string.Empty;
    public string? StaticTargetName { get; init; }
    public string? ResolvedTargetProcedureName { get; init; }
    public bool IsDynamicTarget { get; init; }
    public int ArgumentCount { get; init; }
}

public sealed class KoujouSemanticBlock
{
    public List<KoujouSemanticStatement> Statements { get; } = [];

    public int? EndLine => Statements.Count == 0 ? null : Statements.Max(static statement => statement.EndLine);

    public int CountStatementsRecursive() => Statements.Sum(CountRecursive);
    public int CountTextStatementsRecursive() => Statements.Sum(CountTextRecursive);
    public int CountStructuredExpressionsRecursive() => Statements.Sum(CountStructuredExpressionsRecursive);

    private static int CountRecursive(KoujouSemanticStatement statement)
        => statement switch
        {
            KoujouSemanticIfStatement ifStatement =>
                1
                + ifStatement.ThenBlock.CountStatementsRecursive()
                + ifStatement.ElseIfClauses.Sum(static clause => clause.Body.CountStatementsRecursive())
                + (ifStatement.ElseBlock?.CountStatementsRecursive() ?? 0),
            KoujouSemanticShortIfStatement shortIfStatement =>
                1 + (shortIfStatement.Statement == null ? 0 : CountRecursive(shortIfStatement.Statement)),
            KoujouSemanticSelectCaseStatement selectCaseStatement =>
                1 + selectCaseStatement.Cases.Sum(static clause => clause.Body.CountStatementsRecursive()),
            _ => 1
        };

    private static int CountTextRecursive(KoujouSemanticStatement statement)
        => statement switch
        {
            KoujouSemanticTextStatement => 1,
            KoujouSemanticIfStatement ifStatement =>
                ifStatement.ThenBlock.CountTextStatementsRecursive()
                + ifStatement.ElseIfClauses.Sum(static clause => clause.Body.CountTextStatementsRecursive())
                + (ifStatement.ElseBlock?.CountTextStatementsRecursive() ?? 0),
            KoujouSemanticShortIfStatement shortIfStatement =>
                shortIfStatement.Statement == null ? 0 : CountTextRecursive(shortIfStatement.Statement),
            KoujouSemanticSelectCaseStatement selectCaseStatement =>
                selectCaseStatement.Cases.Sum(static clause => clause.Body.CountTextStatementsRecursive()),
            _ => 0
        };

    private static int CountStructuredExpressionsRecursive(KoujouSemanticStatement statement)
        => statement switch
        {
            KoujouSemanticIfStatement ifStatement =>
                CountStructuredExpression(ifStatement.ConditionExpression)
                + ifStatement.ThenBlock.CountStructuredExpressionsRecursive()
                + ifStatement.ElseIfClauses.Sum(static clause => CountStructuredExpression(clause.ConditionExpression) + clause.Body.CountStructuredExpressionsRecursive())
                + (ifStatement.ElseBlock?.CountStructuredExpressionsRecursive() ?? 0),
            KoujouSemanticShortIfStatement shortIfStatement =>
                CountStructuredExpression(shortIfStatement.ConditionExpression)
                + (shortIfStatement.Statement == null ? 0 : CountStructuredExpressionsRecursive(shortIfStatement.Statement)),
            KoujouSemanticSelectCaseStatement selectCaseStatement =>
                CountStructuredExpression(selectCaseStatement.SelectorExpression)
                + selectCaseStatement.Cases.Sum(static clause => CountStructuredExpression(clause.MatchExpressionNode) + clause.Body.CountStructuredExpressionsRecursive()),
            KoujouSemanticReturnStatement returnStatement => CountStructuredExpression(returnStatement.ValueExpressionNode),
            KoujouSemanticCallStatement callStatement =>
                CountStructuredExpression(callStatement.TargetExpression)
                + callStatement.Arguments.Sum(CountStructuredExpression),
            _ => 0
        };

    private static int CountStructuredExpression(KoujouSemanticExpression? expression)
        => expression == null || expression is KoujouRawExpression ? 0 : 1;
}

public abstract class KoujouSemanticStatement
{
    protected KoujouSemanticStatement(int startLine, int endLine, string rawText)
    {
        StartLine = startLine;
        EndLine = endLine;
        RawText = rawText;
    }

    public int StartLine { get; }
    public int EndLine { get; }
    public string RawText { get; }
}

public sealed class KoujouSemanticTextStatement : KoujouSemanticStatement
{
    public KoujouSemanticTextStatement(int startLine, int endLine, string rawText, string command, string text)
        : base(startLine, endLine, rawText)
    {
        Command = command;
        Text = text;
    }

    public string Command { get; }
    public string Text { get; }
}

public sealed class KoujouSemanticDirectiveStatement : KoujouSemanticStatement
{
    public KoujouSemanticDirectiveStatement(int startLine, int endLine, string rawText, string directiveKind, string content)
        : base(startLine, endLine, rawText)
    {
        DirectiveKind = directiveKind;
        Content = content;
    }

    public string DirectiveKind { get; }
    public string Content { get; }
}

public sealed class KoujouSemanticLabelStatement : KoujouSemanticStatement
{
    public KoujouSemanticLabelStatement(int startLine, int endLine, string rawText, string label)
        : base(startLine, endLine, rawText)
    {
        Label = label;
    }

    public string Label { get; }
}

public sealed class KoujouSemanticReturnStatement : KoujouSemanticStatement
{
    public KoujouSemanticReturnStatement(int startLine, int endLine, string rawText, string valueExpression, KoujouSemanticExpression? valueExpressionNode)
        : base(startLine, endLine, rawText)
    {
        ValueExpression = valueExpression;
        ValueExpressionNode = valueExpressionNode;
    }

    public string ValueExpression { get; }
    public KoujouSemanticExpression? ValueExpressionNode { get; }
}

public sealed class KoujouSemanticCallStatement : KoujouSemanticStatement
{
    public KoujouSemanticCallStatement(
        int startLine,
        int endLine,
        string rawText,
        KoujouSemanticCallKind callKind,
        string rawTarget,
        KoujouSemanticExpression? targetExpression,
        IReadOnlyList<string> rawArguments,
        IReadOnlyList<KoujouSemanticExpression> arguments,
        string? staticTargetName,
        bool isDynamicTarget)
        : base(startLine, endLine, rawText)
    {
        CallKind = callKind;
        RawTarget = rawTarget;
        TargetExpression = targetExpression;
        RawArguments = rawArguments;
        Arguments = arguments;
        StaticTargetName = staticTargetName;
        IsDynamicTarget = isDynamicTarget;
    }

    public KoujouSemanticCallKind CallKind { get; }
    public string RawTarget { get; }
    public KoujouSemanticExpression? TargetExpression { get; }
    public IReadOnlyList<string> RawArguments { get; }
    public IReadOnlyList<KoujouSemanticExpression> Arguments { get; }
    public string? StaticTargetName { get; }
    public bool IsDynamicTarget { get; }
}

public sealed class KoujouSemanticIfStatement : KoujouSemanticStatement
{
    public KoujouSemanticIfStatement(
        int startLine,
        int endLine,
        string rawText,
        string condition,
        KoujouSemanticExpression? conditionExpression,
        KoujouSemanticBlock thenBlock,
        IReadOnlyList<KoujouSemanticElseIfClause> elseIfClauses,
        KoujouSemanticBlock? elseBlock)
        : base(startLine, endLine, rawText)
    {
        Condition = condition;
        ConditionExpression = conditionExpression;
        ThenBlock = thenBlock;
        ElseIfClauses = elseIfClauses;
        ElseBlock = elseBlock;
    }

    public string Condition { get; }
    public KoujouSemanticExpression? ConditionExpression { get; }
    public KoujouSemanticBlock ThenBlock { get; }
    public IReadOnlyList<KoujouSemanticElseIfClause> ElseIfClauses { get; }
    public KoujouSemanticBlock? ElseBlock { get; }
}

public sealed class KoujouSemanticShortIfStatement : KoujouSemanticStatement
{
    public KoujouSemanticShortIfStatement(
        int startLine,
        int endLine,
        string rawText,
        string condition,
        KoujouSemanticExpression? conditionExpression,
        KoujouSemanticStatement? statement)
        : base(startLine, endLine, rawText)
    {
        Condition = condition;
        ConditionExpression = conditionExpression;
        Statement = statement;
    }

    public string Condition { get; }
    public KoujouSemanticExpression? ConditionExpression { get; }
    public KoujouSemanticStatement? Statement { get; }
}

public sealed class KoujouSemanticSelectCaseStatement : KoujouSemanticStatement
{
    public KoujouSemanticSelectCaseStatement(
        int startLine,
        int endLine,
        string rawText,
        string expression,
        KoujouSemanticExpression? selectorExpression,
        IReadOnlyList<KoujouSemanticCaseClause> cases)
        : base(startLine, endLine, rawText)
    {
        Expression = expression;
        SelectorExpression = selectorExpression;
        Cases = cases;
    }

    public string Expression { get; }
    public KoujouSemanticExpression? SelectorExpression { get; }
    public IReadOnlyList<KoujouSemanticCaseClause> Cases { get; }
}

public sealed class KoujouSemanticElseIfClause
{
    public KoujouSemanticElseIfClause(int startLine, int endLine, string condition, KoujouSemanticExpression? conditionExpression, KoujouSemanticBlock body)
    {
        StartLine = startLine;
        EndLine = endLine;
        Condition = condition;
        ConditionExpression = conditionExpression;
        Body = body;
    }

    public int StartLine { get; }
    public int EndLine { get; }
    public string Condition { get; }
    public KoujouSemanticExpression? ConditionExpression { get; }
    public KoujouSemanticBlock Body { get; }
}

public sealed class KoujouSemanticCaseClause
{
    public KoujouSemanticCaseClause(
        int startLine,
        int endLine,
        string matchExpression,
        KoujouSemanticExpression? matchExpressionNode,
        KoujouSemanticBlock body,
        bool isElse)
    {
        StartLine = startLine;
        EndLine = endLine;
        MatchExpression = matchExpression;
        MatchExpressionNode = matchExpressionNode;
        Body = body;
        IsElse = isElse;
    }

    public int StartLine { get; }
    public int EndLine { get; }
    public string MatchExpression { get; }
    public KoujouSemanticExpression? MatchExpressionNode { get; }
    public KoujouSemanticBlock Body { get; }
    public bool IsElse { get; }
}



