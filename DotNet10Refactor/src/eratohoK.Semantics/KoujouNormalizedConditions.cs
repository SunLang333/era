namespace eratohoK.Semantics;

public abstract record KoujouNormalizedCondition(string RawText);

public sealed record KoujouCompositeCondition(
    string RawText,
    string Operator, // "AND", "OR"
    IReadOnlyList<KoujouNormalizedCondition> Conditions) : KoujouNormalizedCondition(RawText);

public sealed record KoujouNotCondition(
    string RawText,
    KoujouNormalizedCondition Inner) : KoujouNormalizedCondition(RawText);

public sealed record KoujouVariableCondition(
    string RawText,
    string VariableName,     // e.g. "TALENT", "CFLAG"
    string? ActorTarget,     // e.g. "MASTER", "TARGET"
    string Index,            // e.g. "恋慕", "1"
    string Operator,         // e.g. "==", ">="
    string Value             // e.g. "1", "0"
) : KoujouNormalizedCondition(RawText);

public sealed record KoujouFunctionCondition(
    string RawText,
    string FunctionName,
    IReadOnlyList<string> Arguments,
    string Operator,         // e.g. "==", ">"
    string Value             // e.g. "1", "0"
) : KoujouNormalizedCondition(RawText);

public sealed record KoujouLiteralCondition(
    string RawText,
    bool IsTrue) : KoujouNormalizedCondition(RawText);

public sealed record KoujouFallbackCondition(
    string RawText) : KoujouNormalizedCondition(RawText);
