namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// 共通前置条件バリデーター
/// 原版 ERB の <c>COM_ABLE_COMMON()</c> に対応。
/// キャラクターが行動可能な基本状態かを検証する。
/// </summary>
public sealed class CommonPreconditionValidator : ICommandValidator
{
    /// <inheritdoc/>
    public bool CanExecute(CommandContext context)
    {
        var trainer = context.Trainer;
        var target  = context.Target;

        // トレーナーが行動不能でないか
        if (trainer.ActionDisabledState != ActionDisabledState.Normal)
            return false;

        // 対象が死亡・特殊状態でないか
        if (target.SpecialState == SpecialState.Dead)
            return false;

        // 基本体力チェック（体力 0 以下は行動不可）
        if (trainer.BaseStatus.Physical <= 0 || target.BaseStatus.Physical <= 0)
            return false;

        // Clothing/restraint check
        if (ClothingSystem.IsActionBlocked(target, context.Action.ActionType))
            return false;

        return true;
    }

    /// <inheritdoc/>
    public string? GetFailureReason(CommandContext context)
    {
        if (context.Trainer.ActionDisabledState != ActionDisabledState.Normal)
            return $"{context.Trainer.Name}は行動不能状態です。";
        if (context.Target.SpecialState == SpecialState.Dead)
            return $"{context.Target.Name}はこの世にいません。";
        if (context.Trainer.BaseStatus.Physical <= 0)
            return $"{context.Trainer.Name}の体力が不足しています。";
        if (context.Target.BaseStatus.Physical <= 0)
            return $"{context.Target.Name}の体力が不足しています。";
        if (ClothingSystem.IsActionBlocked(context.Target, context.Action.ActionType))
            return $"{context.Target.Name}の装備がこのアクションを阻んでいます。";
        return null;
    }
}

/// <summary>
/// アクション時間バリデーター
/// 原版 ERB の TFLAG:56（調教時間残量）チェックに対応。
/// セッション消費時間がアクションの所要時間を超えないか検証する。
/// </summary>
public sealed class ActionTimeValidator : ICommandValidator
{
    private readonly int _maxTimePerSession;

    /// <param name="maxTimePerSession">1 セッションで使用できる最大時間 (分)</param>
    public ActionTimeValidator(int maxTimePerSession = 60)
    {
        _maxTimePerSession = maxTimePerSession;
    }

    /// <inheritdoc/>
    public bool CanExecute(CommandContext context)
        => context.Session.TimeUsed + context.Action.TimeRequired <= _maxTimePerSession;

    /// <inheritdoc/>
    public string? GetFailureReason(CommandContext context)
    {
        int remaining = _maxTimePerSession - context.Session.TimeUsed;
        if (context.Action.TimeRequired > remaining)
            return $"時間が不足しています（残り {remaining} 分、必要 {context.Action.TimeRequired} 分）。";
        return null;
    }
}

/// <summary>
/// スキル要件バリデーター
/// 原版 ERB の <c>COM_ABLE_{ID}</c> 内スキルチェックに対応。
/// トレーナーが必要スキルをすべて保有しているか検証する。
/// </summary>
public sealed class SkillRequirementValidator : ICommandValidator
{
    /// <inheritdoc/>
    public bool CanExecute(CommandContext context)
    {
        var requirements = context.Action.SkillRequirements;
        if (requirements == null || requirements.Length == 0)
            return true;

        var trainerSkillIds = new HashSet<int>(context.Trainer.Skills.Select(s => s.Id));
        return requirements.All(req => trainerSkillIds.Contains(req));
    }

    /// <inheritdoc/>
    public string? GetFailureReason(CommandContext context)
    {
        var requirements = context.Action.SkillRequirements;
        if (requirements == null || requirements.Length == 0)
            return null;

        var trainerSkillIds = new HashSet<int>(context.Trainer.Skills.Select(s => s.Id));
        var missing = requirements.Where(req => !trainerSkillIds.Contains(req)).ToList();
        if (missing.Count > 0)
            return $"必要スキルが不足しています（ID: {string.Join(", ", missing)}）。";
        return null;
    }
}

/// <summary>
/// コンポジット（AND）バリデーター
/// 複数の <see cref="ICommandValidator"/> をすべて満たす場合のみ実行可と判定する。
/// 原版 ERB で各 <c>COM_ABLE_{ID}</c> が複数条件を連続チェックする構造に対応。
/// </summary>
public sealed class CompositeValidator : ICommandValidator
{
    private readonly IReadOnlyList<ICommandValidator> _validators;

    /// <param name="validators">AND 結合するバリデーターのコレクション</param>
    public CompositeValidator(IEnumerable<ICommandValidator> validators)
    {
        _validators = validators.ToList();
    }

    /// <inheritdoc/>
    public bool CanExecute(CommandContext context)
        => _validators.All(v => v.CanExecute(context));

    /// <inheritdoc/>
    public string? GetFailureReason(CommandContext context)
    {
        foreach (var validator in _validators)
        {
            var reason = validator.GetFailureReason(context);
            if (reason != null)
                return reason;
        }
        return null;
    }
}

/// <summary>
/// ラムダ式ベースのアドホックバリデーター
/// <see cref="Func{T, TResult}"/> から <see cref="ICommandValidator"/> を生成するファクトリ的クラス。
/// シンプルな条件を1行で定義したい場合に使用する。
/// </summary>
public sealed class FuncValidator : ICommandValidator
{
    private readonly Func<CommandContext, bool> _predicate;
    private readonly Func<CommandContext, string?> _reason;

    /// <param name="predicate">実行可否を返す述語</param>
    /// <param name="reason">失敗理由を返す関数（省略時は null 固定）</param>
    public FuncValidator(Func<CommandContext, bool> predicate, Func<CommandContext, string?>? reason = null)
    {
        _predicate = predicate;
        _reason    = reason ?? (_ => null);
    }

    /// <inheritdoc/>
    public bool CanExecute(CommandContext context) => _predicate(context);

    /// <inheritdoc/>
    public string? GetFailureReason(CommandContext context)
        => _predicate(context) ? null : _reason(context);
}
