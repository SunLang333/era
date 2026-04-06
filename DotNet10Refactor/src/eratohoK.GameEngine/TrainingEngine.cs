namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// 調教エンジン
/// トレーナーがターゲットに調教アクションを実行する
/// </summary>
public class TrainingEngine
{
    private readonly List<TrainingActionDef> _actions;
    private readonly Random _rng = Random.Shared;

    public TrainingEngine(IEnumerable<TrainingActionDef> actions)
    {
        _actions = actions.ToList();
    }

    public IReadOnlyList<TrainingActionDef> AvailableActions => _actions.AsReadOnly();

    public TrainingSession CreateSession(int trainerId, int targetId, bool isForced = false)
        => new() { TrainerId = trainerId, TargetId = targetId, IsForced = isForced };

    /// <summary>指定アクションを実行してターゲットのステータスを変化させる</summary>
    public TrainingActionResult ExecuteAction(
        TrainingSession session, Character trainer, Character target, int actionId)
    {
        var action = _actions.FirstOrDefault(a => a.Id == actionId);
        if (action == null)
            return new TrainingActionResult(actionId, "Unknown", false, "アクションが見つかりません。");

        var statChanges = new Dictionary<string, int>();

        // Base effects with random variance
        int pleasureBase = 5 + _rng.Next(10);
        int obedienceBase = 3 + _rng.Next(8);
        int resistanceDelta = -(2 + _rng.Next(5));
        int corruptionBase = 2 + _rng.Next(5);

        // Resistance reduces positive effects
        double resistFactor = Math.Max(0.3, 1.0 - target.BaseStatus.Resistance / 1000.0);

        // Trainer's likeability towards target boosts outcomes
        int like = trainer.GetLikeabilityTowards(target.Id);
        double loveFactor = 1.0 + Math.Clamp(like, -100, 100) / 200.0;

        int pleasureChange = (int)(pleasureBase * resistFactor * loveFactor);
        int obedienceChange = (int)(obedienceBase * resistFactor * loveFactor);
        int corruptionChange = (int)(corruptionBase * resistFactor);

        statChanges["Pleasure"] = pleasureChange;
        statChanges["Obedience"] = obedienceChange;
        statChanges["Resistance"] = resistanceDelta;
        statChanges["Corruption"] = corruptionChange;

        target.BaseStatus = target.BaseStatus with
        {
            Joy = Math.Clamp(target.BaseStatus.Joy + pleasureChange, 0, 1000),
            Obedience = Math.Clamp(target.BaseStatus.Obedience + obedienceChange, 0, 1000),
            Resistance = Math.Clamp(target.BaseStatus.Resistance + resistanceDelta, 0, 1000),
            Corruption = Math.Clamp(target.BaseStatus.Corruption + corruptionChange, 0, 1000)
        };

        session.TimeUsed += action.TimeRequired;

        var result = new TrainingActionResult(
            actionId, action.Name, true,
            $"{action.Name}を実行しました。", statChanges);
        session.Actions.Add(result);

        return result;
    }
}
