namespace eratohoK.Core;

/// <summary>ゲーム設定</summary>
public class GameConfig
{
    public string Title { get; set; } = "eratohoK";
    public string Author { get; set; } = "";
    public int Version { get; set; }
    public bool UseCondom { get; set; } = false;
    public bool AllowPregnancy { get; set; } = true;
    public int MaxTrainingActionsPerDay { get; set; } = 5;

    // ── 調教数値演算定数 ──────────────────────────────────────────
    /// <summary>最大抵抗値（原版 ERB MaxResistance 定数相当）</summary>
    public double MaxResistance { get; set; } = 1000.0;
    /// <summary>最小抵抗係数（抵抗が最大でも効果がゼロにならない下限）</summary>
    public double MinResistanceFactor { get; set; } = 0.3;
    /// <summary>好感度スケール除数（原版 LikeabilityScaleDivisor 相当）</summary>
    public double LikeabilityScaleDivisor { get; set; } = 200.0;
    /// <summary>好感度の下限（-100）</summary>
    public int MinLikeability { get; set; } = -100;
    /// <summary>好感度の上限（+100）</summary>
    public int MaxLikeability { get; set; } = 100;
    /// <summary>ステータス最大値（Joy/Obedience/Resistance/Corruption の上限）</summary>
    public int MaxStatValue { get; set; } = 1000;
    /// <summary>各調教ステータスの最小値</summary>
    public int MinStatValue { get; set; } = 0;
    /// <summary>天賦「反抗的」がある場合の反抗値低下ペナルティ倍率</summary>
    public double RebelliousPenaltyFactor { get; set; } = 0.5;
    /// <summary>天賦「素直」がある場合の服従ボーナス倍率</summary>
    public double HonestObedienceBonus { get; set; } = 1.3;
    /// <summary>天賦「気丈」がある場合の快感低下倍率</summary>
    public double StoicPleasurePenalty { get; set; } = 0.7;
    /// <summary>天賦「濡れやすい」がある場合の快感ボーナス倍率</summary>
    public double EasilyWetBonus { get; set; } = 1.4;
    /// <summary>天賦「献身的」で好感度正の場合の服従ボーナス倍率</summary>
    public double DevotedObedienceBonus { get; set; } = 1.2;
}
