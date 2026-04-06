namespace eratohoK.Core;

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
