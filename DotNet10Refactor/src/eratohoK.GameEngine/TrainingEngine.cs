namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// 調教エンジン
/// トレーナーがターゲットに調教アクションを実行するための公開 API。
/// 内部では <see cref="CommandRoutingService"/> に委譲し、
/// バリデーション → 実行 → SOURCE 蓄積のパイプラインを透過的に呼び出す。
/// </summary>
public class TrainingEngine
{
    private readonly List<TrainingActionDef> _actions;
    private readonly CommandRoutingService   _router;

    /// <summary>
    /// 指定のアクション定義リストとデフォルト設定でエンジンを初期化する。
    /// </summary>
    /// <param name="actions">利用可能な調教アクション定義</param>
    /// <param name="config">ゲーム設定（省略時はデフォルト値）</param>
    public TrainingEngine(IEnumerable<TrainingActionDef> actions, GameConfig? config = null)
    {
        _actions = actions.ToList();
        _router  = new CommandRoutingService(config: config);
    }

    /// <summary>
    /// 指定のルーティングサービスを使用してエンジンを初期化する（DI 用）。
    /// </summary>
    /// <param name="actions">利用可能な調教アクション定義</param>
    /// <param name="router">カスタムルーティングサービス</param>
    public TrainingEngine(IEnumerable<TrainingActionDef> actions, CommandRoutingService router)
    {
        _actions = actions.ToList();
        _router  = router;
    }

    /// <summary>利用可能な調教アクション定義の読み取り専用リスト</summary>
    public IReadOnlyList<TrainingActionDef> AvailableActions => _actions.AsReadOnly();

    /// <summary>
    /// 新しい調教セッションを作成する。
    /// </summary>
    /// <param name="trainerId">トレーナーキャラクター ID</param>
    /// <param name="targetId">対象キャラクター ID</param>
    /// <param name="isForced">強制調教フラグ</param>
    public TrainingSession CreateSession(int trainerId, int targetId, bool isForced = false)
        => new() { TrainerId = trainerId, TargetId = targetId, IsForced = isForced };

    /// <summary>
    /// 指定アクションを実行してターゲットのステータスを変化させる。
    /// バリデーション・数値演算・SOURCE 蓄積は <see cref="CommandRoutingService"/> が担う。
    /// </summary>
    /// <param name="session">現在の調教セッション</param>
    /// <param name="trainer">コマンドを実行するトレーナー</param>
    /// <param name="target">対象キャラクター</param>
    /// <param name="actionId">実行するアクション ID</param>
    /// <returns>アクション実行結果</returns>
    public TrainingActionResult ExecuteAction(
        TrainingSession session,
        Character       trainer,
        Character       target,
        int             actionId)
    {
        var action = _actions.FirstOrDefault(a => a.Id == actionId);
        if (action == null)
            return new TrainingActionResult(actionId, "Unknown", false, "アクションが見つかりません。");

        return _router.RouteTrainCommand(trainer, target, action, session);
    }

    /// <summary>
    /// セッション終了後に蓄積された SOURCE を対象キャラクターへ適用する。
    /// 原版 ERB の <c>AFTER_TRAIN → APPLY_SOURCE()</c> に対応。
    /// </summary>
    /// <param name="session">終了した調教セッション</param>
    /// <param name="target">SOURCE を受けるキャラクター</param>
    /// <returns>最終的なステータス変化マップ</returns>
    public IDictionary<string, int> FinalizeSession(TrainingSession session, Character target)
        => _router.FinalizeSession(session, target);
}

