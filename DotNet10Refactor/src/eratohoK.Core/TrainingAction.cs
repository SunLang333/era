namespace eratohoK.Core;

/// <summary>
/// 調教アクション定義
/// 原版 ERB の各 COM_{ID} コマンド定義に対応
/// </summary>
public record TrainingActionDef(
    int Id,
    string Name,
    int TimeRequired = 10,
    int[]? SkillRequirements = null,
    /// <summary>コマンドの調教カテゴリ（原版 ERB カテゴリ分類）</summary>
    TrainingActionType ActionType = TrainingActionType.Caress,
    /// <summary>快感 SOURCE 倍率</summary>
    double PleasureMultiplier = 1.0,
    /// <summary>服従 SOURCE 倍率</summary>
    double ObedienceMultiplier = 1.0,
    /// <summary>堕落 SOURCE 倍率</summary>
    double CorruptionMultiplier = 1.0,
    /// <summary>時間コスト (消費体力)</summary>
    int StaminaCost = 60
);

/// <summary>
/// SOURCE 値の蓄積コンテナ
/// 原版 ERB の SOURCE_* グローバル変数群をカプセル化。
/// 各アクション実行後に <see cref="TrainingSession"/> に累積され、
/// セッション終了時に <c>APPLY_SOURCE()</c> 相当の最終演算に渡す。
/// </summary>
public record SourceValues
{
    /// <summary>快感系 SOURCE (快C/M/V/A の合計) – 愉悦・堕落に変換</summary>
    public int Pleasure { get; init; }
    /// <summary>爱情 SOURCE – 好感度変化に変換</summary>
    public int Love { get; init; }
    /// <summary>屈辱 SOURCE – 屈辱・服从に変換</summary>
    public int Humiliation { get; init; }
    /// <summary>痛苦 SOURCE – 恐怖・反抗に変換</summary>
    public int Pain { get; init; }
    /// <summary>奉仕 SOURCE – トレーナー側の奉仕行動量</summary>
    public int Service { get; init; }
    /// <summary>接触 SOURCE – 身体接触量</summary>
    public int Contact { get; init; }
    /// <summary>性行動 SOURCE – 性的行動強度</summary>
    public int SexualActivity { get; init; }

    /// <summary>二つの <see cref="SourceValues"/> を加算して返す</summary>
    public SourceValues Add(SourceValues other) => new()
    {
        Pleasure        = Pleasure        + other.Pleasure,
        Love            = Love            + other.Love,
        Humiliation     = Humiliation     + other.Humiliation,
        Pain            = Pain            + other.Pain,
        Service         = Service         + other.Service,
        Contact         = Contact         + other.Contact,
        SexualActivity  = SexualActivity  + other.SexualActivity
    };
}

/// <summary>
/// 調教セッション
/// 一回の調教フェーズ全体を表し、複数アクション実行結果と SOURCE 累積を保持する
/// </summary>
public class TrainingSession
{
    /// <summary>実行者キャラクター ID</summary>
    public int TrainerId { get; set; }
    /// <summary>対象キャラクター ID</summary>
    public int TargetId { get; set; }
    /// <summary>実行済みアクション結果一覧</summary>
    public List<TrainingActionResult> Actions { get; set; } = new();
    /// <summary>消費時間 (分)</summary>
    public int TimeUsed { get; set; }
    /// <summary>強制調教フラグ</summary>
    public bool IsForced { get; set; }

    /// <summary>
    /// セッション内の累積 SOURCE 値 (原版 ERB の SOURCE_* 変数群に対応)
    /// 各アクション終了時に加算され、セッション終了時に APPLY_SOURCE 演算に利用される
    /// </summary>
    public SourceValues AccumulatedSource { get; set; } = new();

    /// <summary>
    /// SOURCE 値を加算する拡張ポイント
    /// 原版 ERB の <c>APPLY_SOURCE()</c> 前の累積フック
    /// </summary>
    public void AccumulateSource(SourceValues delta)
        => AccumulatedSource = AccumulatedSource.Add(delta);
}

/// <summary>調教アクション結果</summary>
public record TrainingActionResult(
    int ActionId,
    string ActionName,
    bool Success,
    string Message,
    IDictionary<string, int>? StatChanges = null,
    /// <summary>このアクションが生成した SOURCE デルタ値</summary>
    SourceValues? SourceDelta = null,
    /// <summary>LLM 用に構造化された口上セマンティクス</summary>
    DialogueSemanticEvent? SemanticEvent = null
);
