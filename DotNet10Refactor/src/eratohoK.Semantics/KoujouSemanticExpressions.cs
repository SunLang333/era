namespace eratohoK.Semantics;

public abstract record KoujouSemanticExpression(string RawText);

public sealed record KoujouRawExpression(string RawText) : KoujouSemanticExpression(RawText);

public sealed record KoujouIdentifierExpression(string RawText, string Name) : KoujouSemanticExpression(RawText);

public sealed record KoujouNumberLiteralExpression(string RawText, decimal Value) : KoujouSemanticExpression(RawText);

public sealed record KoujouStringLiteralExpression(string RawText, string Value) : KoujouSemanticExpression(RawText);

public sealed record KoujouUnaryExpression(string RawText, string Operator, KoujouSemanticExpression Operand)
    : KoujouSemanticExpression(RawText);

public sealed record KoujouBinaryExpression(string RawText, KoujouSemanticExpression Left, string Operator, KoujouSemanticExpression Right)
    : KoujouSemanticExpression(RawText);

public sealed record KoujouQualifiedExpression(string RawText, KoujouSemanticExpression Target, KoujouSemanticExpression Member)
    : KoujouSemanticExpression(RawText);

public sealed record KoujouInvocationExpression(string RawText, KoujouSemanticExpression Callee, IReadOnlyList<KoujouSemanticExpression> Arguments)
    : KoujouSemanticExpression(RawText);

public sealed record KoujouGroupingExpression(string RawText, KoujouSemanticExpression Inner)
    : KoujouSemanticExpression(RawText);

public static class KoujouSemanticExpressionParser
{
    public static KoujouSemanticExpression ParseOrRaw(string rawText)
        => TryParse(rawText, out var expression) ? expression : new KoujouRawExpression(rawText.Trim());

    public static bool TryParse(string rawText, out KoujouSemanticExpression expression)
    {
        expression = new KoujouRawExpression(rawText.Trim());
        if (string.IsNullOrWhiteSpace(rawText))
        {
            return false;
        }

        try
        {
            var parser = new Parser(rawText);
            var parsed = parser.ParseExpression();
            if (!parser.IsAtEnd)
            {
                return false;
            }

            expression = parsed;
            return true;
        }
        catch
        {
            expression = new KoujouRawExpression(rawText.Trim());
            return false;
        }
    }

    public static IReadOnlyList<KoujouSemanticExpression> ParseArguments(string rawArguments)
    {
        if (string.IsNullOrWhiteSpace(rawArguments))
        {
            return Array.Empty<KoujouSemanticExpression>();
        }

        return SplitTopLevel(rawArguments)
            .Select(ParseOrRaw)
            .ToArray();
    }

    public static IReadOnlyList<string> SplitTopLevel(string rawArguments)
    {
        if (string.IsNullOrWhiteSpace(rawArguments))
        {
            return Array.Empty<string>();
        }

        var results = new List<string>();
        var start = 0;
        var depthParen = 0;
        var depthBrace = 0;
        bool inString = false;
        char stringDelimiter = '\0';

        for (int i = 0; i < rawArguments.Length; i++)
        {
            var ch = rawArguments[i];
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

            switch (ch)
            {
                case '(':
                    depthParen++;
                    break;
                case ')':
                    depthParen = Math.Max(0, depthParen - 1);
                    break;
                case '{':
                    depthBrace++;
                    break;
                case '}':
                    depthBrace = Math.Max(0, depthBrace - 1);
                    break;
                case ',':
                    if (depthParen == 0 && depthBrace == 0)
                    {
                        results.Add(rawArguments[start..i].Trim());
                        start = i + 1;
                    }
                    break;
            }
        }

        if (start <= rawArguments.Length)
        {
            results.Add(rawArguments[start..].Trim());
        }

        return results.Where(static item => !string.IsNullOrWhiteSpace(item)).ToArray();
    }

    private enum TokenKind
    {
        Identifier,
        Number,
        String,
        LeftParen,
        RightParen,
        Comma,
        Colon,
        Plus,
        Minus,
        Star,
        Slash,
        Percent,
        Bang,
        Equal,
        EqualEqual,
        BangEqual,
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        AndAnd,
        OrOr,
        End
    }

    private readonly record struct Token(TokenKind Kind, string Text);

    private sealed class Parser
    {
        private static readonly HashSet<char> SingleCharTokens = ['(', ')', ',', ':', '+', '-', '*', '/', '%', '!', '=', '<', '>'];

        private readonly List<Token> _tokens;
        private readonly string _rawText;
        private int _position;

        public Parser(string rawText)
        {
            _rawText = rawText.Trim();
            _tokens = Tokenize(_rawText);
        }

        public bool IsAtEnd => Peek().Kind == TokenKind.End;

        public KoujouSemanticExpression ParseExpression() => ParseOr();

        private KoujouSemanticExpression ParseOr()
        {
            var expression = ParseAnd();
            while (Match(TokenKind.OrOr, out var op))
            {
                var right = ParseAnd();
                expression = new KoujouBinaryExpression($"{expression.RawText} {op.Text} {right.RawText}", expression, op.Text, right);
            }
            return expression;
        }

        private KoujouSemanticExpression ParseAnd()
        {
            var expression = ParseEquality();
            while (Match(TokenKind.AndAnd, out var op))
            {
                var right = ParseEquality();
                expression = new KoujouBinaryExpression($"{expression.RawText} {op.Text} {right.RawText}", expression, op.Text, right);
            }
            return expression;
        }

        private KoujouSemanticExpression ParseEquality()
        {
            var expression = ParseComparison();
            while (MatchAny([TokenKind.EqualEqual, TokenKind.BangEqual, TokenKind.Equal], out var op))
            {
                var right = ParseComparison();
                expression = new KoujouBinaryExpression($"{expression.RawText} {op.Text} {right.RawText}", expression, op.Text, right);
            }
            return expression;
        }

        private KoujouSemanticExpression ParseComparison()
        {
            var expression = ParseAdditive();
            while (MatchAny([TokenKind.Less, TokenKind.LessEqual, TokenKind.Greater, TokenKind.GreaterEqual], out var op))
            {
                var right = ParseAdditive();
                expression = new KoujouBinaryExpression($"{expression.RawText} {op.Text} {right.RawText}", expression, op.Text, right);
            }
            return expression;
        }

        private KoujouSemanticExpression ParseAdditive()
        {
            var expression = ParseMultiplicative();
            while (MatchAny([TokenKind.Plus, TokenKind.Minus], out var op))
            {
                var right = ParseMultiplicative();
                expression = new KoujouBinaryExpression($"{expression.RawText} {op.Text} {right.RawText}", expression, op.Text, right);
            }
            return expression;
        }

        private KoujouSemanticExpression ParseMultiplicative()
        {
            var expression = ParseUnary();
            while (MatchAny([TokenKind.Star, TokenKind.Slash, TokenKind.Percent], out var op))
            {
                var right = ParseUnary();
                expression = new KoujouBinaryExpression($"{expression.RawText} {op.Text} {right.RawText}", expression, op.Text, right);
            }
            return expression;
        }

        private KoujouSemanticExpression ParseUnary()
        {
            if (MatchAny([TokenKind.Bang, TokenKind.Minus, TokenKind.Plus], out var op))
            {
                var operand = ParseUnary();
                return new KoujouUnaryExpression($"{op.Text}{operand.RawText}", op.Text, operand);
            }

            return ParsePostfix();
        }

        private KoujouSemanticExpression ParsePostfix()
        {
            var expression = ParsePrimary();

            while (true)
            {
                if (Match(TokenKind.Colon, out _))
                {
                    var member = ParsePrimary();
                    expression = new KoujouQualifiedExpression($"{expression.RawText}:{member.RawText}", expression, member);
                    continue;
                }

                if (Match(TokenKind.LeftParen, out _))
                {
                    var arguments = new List<KoujouSemanticExpression>();
                    if (!Check(TokenKind.RightParen))
                    {
                        do
                        {
                            arguments.Add(ParseExpression());
                        }
                        while (Match(TokenKind.Comma, out _));
                    }

                    Consume(TokenKind.RightParen);
                    expression = new KoujouInvocationExpression(
                        $"{expression.RawText}({string.Join(", ", arguments.Select(static a => a.RawText))})",
                        expression,
                        arguments);
                    continue;
                }

                break;
            }

            return expression;
        }

        private KoujouSemanticExpression ParsePrimary()
        {
            if (Match(TokenKind.Number, out var numberToken))
            {
                return new KoujouNumberLiteralExpression(numberToken.Text, decimal.Parse(numberToken.Text, System.Globalization.CultureInfo.InvariantCulture));
            }

            if (Match(TokenKind.String, out var stringToken))
            {
                var value = stringToken.Text.Length >= 2
                    ? stringToken.Text[1..^1]
                    : stringToken.Text;
                return new KoujouStringLiteralExpression(stringToken.Text, value);
            }

            if (Match(TokenKind.Identifier, out var identifierToken))
            {
                return new KoujouIdentifierExpression(identifierToken.Text, identifierToken.Text);
            }

            if (Match(TokenKind.LeftParen, out _))
            {
                var inner = ParseExpression();
                Consume(TokenKind.RightParen);
                return new KoujouGroupingExpression($"({inner.RawText})", inner);
            }

            throw new InvalidOperationException($"Unexpected token while parsing expression '{_rawText}': {Peek().Text}");
        }

        private bool Match(TokenKind kind, out Token token)
        {
            if (Check(kind))
            {
                token = Advance();
                return true;
            }

            token = default;
            return false;
        }

        private bool MatchAny(TokenKind[] kinds, out Token token)
        {
            foreach (var kind in kinds)
            {
                if (Match(kind, out token))
                {
                    return true;
                }
            }

            token = default;
            return false;
        }

        private bool Check(TokenKind kind) => Peek().Kind == kind;

        private Token Consume(TokenKind kind)
        {
            if (!Check(kind))
            {
                throw new InvalidOperationException($"Expected token {kind} while parsing expression '{_rawText}', but got {Peek().Kind}.");
            }

            return Advance();
        }

        private Token Advance()
        {
            if (_position < _tokens.Count)
            {
                _position++;
            }
            return _tokens[_position - 1];
        }

        private Token Peek(int offset = 0)
        {
            var index = Math.Min(_position + offset, _tokens.Count - 1);
            return _tokens[index];
        }

        private static List<Token> Tokenize(string text)
        {
            var tokens = new List<Token>();
            var index = 0;

            while (index < text.Length)
            {
                var ch = text[index];
                if (char.IsWhiteSpace(ch))
                {
                    index++;
                    continue;
                }

                if (ch is '"' or '\'')
                {
                    var quote = ch;
                    var start = index++;
                    while (index < text.Length && text[index] != quote)
                    {
                        index++;
                    }
                    if (index < text.Length)
                    {
                        index++;
                    }
                    tokens.Add(new Token(TokenKind.String, text[start..index]));
                    continue;
                }

                if (char.IsDigit(ch))
                {
                    var start = index++;
                    while (index < text.Length && (char.IsDigit(text[index]) || text[index] == '.'))
                    {
                        index++;
                    }
                    tokens.Add(new Token(TokenKind.Number, text[start..index]));
                    continue;
                }

                if (index + 1 < text.Length)
                {
                    var twoChars = text.Substring(index, 2);
                    switch (twoChars)
                    {
                        case "&&":
                            tokens.Add(new Token(TokenKind.AndAnd, twoChars));
                            index += 2;
                            continue;
                        case "||":
                            tokens.Add(new Token(TokenKind.OrOr, twoChars));
                            index += 2;
                            continue;
                        case "==":
                            tokens.Add(new Token(TokenKind.EqualEqual, twoChars));
                            index += 2;
                            continue;
                        case "!=":
                            tokens.Add(new Token(TokenKind.BangEqual, twoChars));
                            index += 2;
                            continue;
                        case "<=":
                            tokens.Add(new Token(TokenKind.LessEqual, twoChars));
                            index += 2;
                            continue;
                        case ">=":
                            tokens.Add(new Token(TokenKind.GreaterEqual, twoChars));
                            index += 2;
                            continue;
                    }
                }

                if (SingleCharTokens.Contains(ch))
                {
                    tokens.Add(new Token(ch switch
                    {
                        '(' => TokenKind.LeftParen,
                        ')' => TokenKind.RightParen,
                        ',' => TokenKind.Comma,
                        ':' => TokenKind.Colon,
                        '+' => TokenKind.Plus,
                        '-' => TokenKind.Minus,
                        '*' => TokenKind.Star,
                        '/' => TokenKind.Slash,
                        '%' => TokenKind.Percent,
                        '!' => TokenKind.Bang,
                        '=' => TokenKind.Equal,
                        '<' => TokenKind.Less,
                        '>' => TokenKind.Greater,
                        _ => throw new InvalidOperationException($"Unexpected token: {ch}")
                    }, ch.ToString()));
                    index++;
                    continue;
                }

                var identStart = index++;
                while (index < text.Length
                       && !char.IsWhiteSpace(text[index])
                       && !SingleCharTokens.Contains(text[index])
                       && !(index + 1 < text.Length && (text.Substring(index, 2) is "&&" or "||" or "==" or "!=" or "<=" or ">=")))
                {
                    index++;
                }

                tokens.Add(new Token(TokenKind.Identifier, text[identStart..index]));
            }

            tokens.Add(new Token(TokenKind.End, string.Empty));
            return tokens;
        }
    }
}
