namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// コマンドルーティングサービス
/// <see cref="CommandType.Train"/> を受け取り、登録済みの <see cref="ICommandValidator"/> と
/// <see cref="ICommandExecutor"/> のパイプラインへ振り分ける。
///
/// 設計方針:
/// <list type="bullet">
///   <item>全状態は注入済みの依存物のみ（静的状態なし）</item>
///   <item>バリデーターとエグゼキューターは個別に登録可能（拡張容易）</item>
///   <item><see cref="SlgEngine.ExecutePlayerTurn"/> から呼び出し可能な契約を維持</item>
/// </list>
/// </summary>
public sealed class CommandRoutingService
{
    private readonly ICommandValidator _validator;
    private readonly ICommandExecutor  _executor;
    private readonly ISourceAccumulator _sourceAccumulator;
    private readonly GameConfig _config;

    /// <summary>
    /// 標準パイプラインでルーティングサービスを初期化する。
    /// </summary>
    /// <param name="validator">
    /// 使用するバリデーター（省略時は <see cref="CompositeValidator"/> の標準セット）
    /// </param>
    /// <param name="executor">
    /// 使用するエグゼキューター（省略時は <see cref="TrainingCommandExecutor"/>）
    /// </param>
    /// <param name="sourceAccumulator">
    /// SOURCE 適用サービス（省略時は <see cref="SourceApplicator"/>）
    /// </param>
    /// <param name="config">ゲーム設定（省略時はデフォルト値）</param>
    public CommandRoutingService(
        ICommandValidator?   validator        = null,
        ICommandExecutor?    executor         = null,
        ISourceAccumulator?  sourceAccumulator = null,
        GameConfig?          config            = null)
    {
        _config            = config ?? new GameConfig();
        _validator         = validator        ?? BuildDefaultValidator(_config);
        _executor          = executor         ?? new TrainingCommandExecutor();
        _sourceAccumulator = sourceAccumulator ?? new SourceApplicator();
    }

    /// <summary>
    /// 調教コマンドをルーティングして実行する。
    /// <para>
    /// パイプライン: バリデーション → 実行 → SOURCE 蓄積
    /// </para>
    /// </summary>
    /// <param name="trainer">コマンドを実行するトレーナー</param>
    /// <param name="target">対象キャラクター</param>
    /// <param name="action">実行する調教アクション定義</param>
    /// <param name="session">現在の調教セッション</param>
    /// <returns>アクション実行結果</returns>
    public TrainingActionResult RouteTrainCommand(
        Character          trainer,
        Character          target,
        TrainingActionDef  action,
        TrainingSession    session)
    {
        var context = new CommandContext
        {
            Trainer = trainer,
            Target  = target,
            Action  = action,
            Session = session,
            Config  = _config
        };

        // ── バリデーション ──────────────────────────────────────────
        if (!_validator.CanExecute(context))
        {
            var reason = _validator.GetFailureReason(context) ?? "実行条件を満たしていません。";
            return new TrainingActionResult(action.Id, action.Name, false, reason);
        }

        // ── 実行 ────────────────────────────────────────────────────
        return _executor.Execute(context);
    }

    /// <summary>
    /// セッション終了後に蓄積された SOURCE 値を対象キャラクターへ適用する。
    /// 原版 ERB の <c>AFTER_TRAIN → APPLY_SOURCE()</c> 呼び出しに対応。
    /// </summary>
    /// <param name="session">終了したセッション</param>
    /// <param name="target">SOURCE を適用するキャラクター</param>
    /// <returns>ステータス変化マップ</returns>
    public IDictionary<string, int> FinalizeSession(TrainingSession session, Character target)
        => _sourceAccumulator.ApplySource(session.AccumulatedSource, target, _config);

    // ──────────────────────────────────────────────────────────────────────────
    // Private helpers
    // ──────────────────────────────────────────────────────────────────────────

    /// <summary>デフォルトのコンポジットバリデーターを構築する</summary>
    private static ICommandValidator BuildDefaultValidator(GameConfig config)
        => new CompositeValidator(
        [
            new CommonPreconditionValidator(),
            new ActionTimeValidator(config.MaxTrainingActionsPerDay * 12), // 12 分/アクション想定
            new SkillRequirementValidator()
        ]);
}
