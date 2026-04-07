namespace eratohoK.Core;

/// <summary>
/// 調教コマンドのカテゴリ
/// 原版 ERB の調教コマンドカテゴリ（0=愛撫系、1=口系、2=V系、3=A系 …）に対応
/// </summary>
public enum TrainingActionType
{
    /// <summary>愛撫系 – 一般的な愛撫・接触 (ERB カテゴリ 0)</summary>
    Caress = 0,
    /// <summary>口技系 – 口によるプレイ (ERB カテゴリ 1)</summary>
    Oral = 1,
    /// <summary>挿入系 – 指・異物などの膣内挿入 (ERB カテゴリ 2)</summary>
    Vaginal = 2,
    /// <summary>アナル系 – アナル関連 (ERB カテゴリ 3)</summary>
    Anal = 3,
    /// <summary>器具系 – 器具・玩具を使用 (ERB カテゴリ 5)</summary>
    Toy = 5,
    /// <summary>精神調教系 – 言葉・精神的圧力 (ERB カテゴリ 6)</summary>
    Mental = 6,
    /// <summary>日常系 – 非性的な日常行動・会話 (ERB カテゴリ 7)</summary>
    Daily = 7,
    /// <summary>制裁系 – 痛みや罰を与える (拡張)</summary>
    Punishment = 8,
    /// <summary>褒美系 – 快楽的な報酬を与える (拡張)</summary>
    Reward = 9,
    /// <summary>カスタム – 未定義の拡張コマンド</summary>
    Custom = 99
}

/// <summary>
/// 性別の列挙型
/// </summary>
public enum Gender
{
    Male = 0,           // 男性
    Female = 1,         // 女性
    FutanariFemale = 2, // 女双
    FutanariMale = 3,   // 男双
    Otokonoko = 4,      // 男の娘
    OtokonokoFutanari = 5 // 男の娘双
}

/// <summary>
/// キャラクターの特殊状態
/// </summary>
public enum SpecialState
{
    Normal = 0,     // 正常
    Dead = 1,       // 死亡
    Wanderer = 2,   // 流浪
    Pregnant = 3,   // 臨月
    Childcare = 4,  // 育児
    Injured = 5     // 受傷
}

/// <summary>
/// 行動不能状態
/// </summary>
public enum ActionDisabledState
{
    Normal = 0,
    Pregnant = 1,   // 臨月
    Childcare = 2,  // 育児
    Injured = 3     // 受傷
}
