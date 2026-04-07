namespace eratohoK.Semantics;

using System.Collections.Generic;
using System.Linq;

public static class KoujouConditionNormalizer
{
    public static KoujouNormalizedCondition Normalize(KoujouSemanticExpression expression)
    {
        if (expression == null)
        {
            return new KoujouFallbackCondition("");
        }

        switch (expression)
        {
            case KoujouGroupingExpression grouping:
                return Normalize(grouping.Inner);

            case KoujouUnaryExpression unary:
                if (unary.Operator == "!")
                {
                    return new KoujouNotCondition(unary.RawText, Normalize(unary.Operand));
                }
                break;

            case KoujouBinaryExpression binary:
                if (binary.Operator == "&&" || binary.Operator == "||")
                {
                    var left = Normalize(binary.Left);
                    var right = Normalize(binary.Right);

                    // Flatten AND/OR if possible
                    if (left is KoujouCompositeCondition compLeft && compLeft.Operator == binary.Operator)
                    {
                        var list = compLeft.Conditions.ToList();
                        if (right is KoujouCompositeCondition compRight && compRight.Operator == binary.Operator)
                            list.AddRange(compRight.Conditions);
                        else
                            list.Add(right);
                        return new KoujouCompositeCondition(binary.RawText, binary.Operator, list);
                    }

                    return new KoujouCompositeCondition(binary.RawText, binary.Operator, new[] { left, right });
                }

                // Relational operators
                if (binary.Operator is "==" or "!=" or ">" or "<" or ">=" or "<=")
                {
                    // Target is likely Left. Value is likely Right.
                    var target = binary.Left as KoujouQualifiedExpression ?? (binary.Left as KoujouIdentifierExpression as KoujouSemanticExpression);
                    if (target is KoujouQualifiedExpression qe)
                    {
                        var (varName, actor, index) = FlattenQualified(qe);
                        if (varName != null && index != null)
                        {
                            return new KoujouVariableCondition(binary.RawText, varName, actor, index, binary.Operator, StringifyValue(binary.Right));
                        }
                    }
                    else if (binary.Left is KoujouIdentifierExpression id)
                    {
                        return new KoujouVariableCondition(binary.RawText, id.Name, null, "", binary.Operator, StringifyValue(binary.Right));
                    }
                    else if (binary.Left is KoujouInvocationExpression inv)
                    {
                        var funcName = (inv.Callee as KoujouIdentifierExpression)?.Name ?? inv.Callee.RawText;
                        var args = inv.Arguments.Select(StringifyValue).ToArray();
                        return new KoujouFunctionCondition(binary.RawText, funcName, args, binary.Operator, StringifyValue(binary.Right));
                    }
                }
                break;

            case KoujouQualifiedExpression qe:
                {
                    // Implicit boolean check: TALENT:1 != 0
                    var (varName, actor, index) = FlattenQualified(qe);
                    if (varName != null && index != null)
                    {
                        return new KoujouVariableCondition(qe.RawText, varName, actor, index, "!=", "0");
                    }
                    break;
                }

            case KoujouIdentifierExpression id:
                // Implicit boolean check
                return new KoujouVariableCondition(id.RawText, id.Name, null, "", "!=", "0");

            case KoujouNumberLiteralExpression num:
                return new KoujouLiteralCondition(num.RawText, num.Value != 0);

            case KoujouInvocationExpression inv:
                {
                    var funcName = (inv.Callee as KoujouIdentifierExpression)?.Name ?? inv.Callee.RawText;
                    var args = inv.Arguments.Select(StringifyValue).ToArray();
                    return new KoujouFunctionCondition(inv.RawText, funcName, args, "!=", "0");
                }
        }

        return new KoujouFallbackCondition(expression.RawText);
    }

    private static (string? VariableName, string? Actor, string? Index) FlattenQualified(KoujouQualifiedExpression qe)
    {
        // TALENT:恋慕 => Variable=TALENT, Index=恋慕
        // CFLAG:MASTER:所属 => Variable=CFLAG, Actor=MASTER, Index=所属
        if (qe.Target is KoujouIdentifierExpression rootId)
        {
            var varName = rootId.Name;
            var index = StringifyValue(qe.Member);
            return (varName, null, index);
        }
        else if (qe.Target is KoujouQualifiedExpression innerQe && innerQe.Target is KoujouIdentifierExpression innerRootId)
        {
            var varName = innerRootId.Name;
            var actor = StringifyValue(innerQe.Member);
            var index = StringifyValue(qe.Member);
            return (varName, actor, index);
        }
        
        return (null, null, null);
    }

    private static string StringifyValue(KoujouSemanticExpression expr)
    {
        return expr switch
        {
            KoujouIdentifierExpression id => id.Name,
            KoujouNumberLiteralExpression num => num.Value.ToString(),
            KoujouStringLiteralExpression str => str.Value,
            _ => expr.RawText
        };
    }
}
