namespace eratohoK.Core;

/// <summary>
/// キャラクターの基礎能力値 (BASE)
/// </summary>
public record BaseStatus(
    int Physical = 100,   // 体力
    int Mental = 100,     // 気力
    int Anger = 0,        // 怒气
    int Sorrow = 0,       // 哀伤
    int Fear = 0,         // 恐怖
    int Joy = 0,          // 愉悦
    int Humiliation = 0,  // 屈辱
    int Corruption = 0,   // 堕落
    int Resistance = 0,   // 反抗
    int Obedience = 0     // 服从
);

/// <summary>
/// キャラクターの能力 (ABL)
/// </summary>
public record Ability(
    int Desire = 0,           // 欲望
    int SexualKnowledge = 0,  // 性知识
    int Dominance = 0,        // 主导度
    int Masochism = 0,        // 受虐度
    int Talk = 0,             // 说话
    int Heal = 0,             // 治疗
    int Fight = 0,            // 战斗
    int Magic = 0,            // 魔法
    int Command = 0,          // 指挥
    int Politics = 0,         // 政治
    int Intelligence = 0      // 智力
);

/// <summary>
/// キャラクターの素質/天赋 (TALENT)
/// </summary>
public record Talent(
    Gender Gender = Gender.Female,
    bool IsVirgin = true,          // 処女
    bool IsMaleVirgin = true,      // 童貞
    bool IsKissInexperienced = true, // キス未経験
    bool IsAnalVirgin = true,      // アナル処女
    bool IsCowardly = false,       // 臆病
    bool IsRebellious = false,     // 反抗的
    bool IsStoic = false,          // 気丈
    bool IsHonest = false,         // 素直
    bool IsQuiet = false,          // 大人しい
    bool IsProud = false,          // プライド高い
    bool IsArrogant = false,       // 生意気
    bool IsLowPride = false,       // プライド低い
    bool IsTsundere = false,       // ツンデレ
    bool IsSelfControlled = false, // 自制心
    bool IsIndifferent = false,    // 無関心
    bool IsEmotionless = false,    // 感情乏しい
    bool IsCurious = false,        // 好奇心
    bool IsConservative = false,   // 保守的
    bool IsOptimistic = false,     // 楽観的
    bool IsPessimistic = false,    // 悲観的
    bool IsNotCrossingLine = false, // 一線越えない
    bool IsAttentionSeeker = false, // 目立ちたがり
    bool HasChastityConcept = false, // 貞操観念
    bool IsChastityIndifferent = false, // 貞操無頓着
    bool IsSuppressed = false,     // 抑圧
    bool IsLiberated = false,      // 解放
    bool IsSolitary = false,       // 孤高
    bool IsShy = false,            // 恥じらい
    bool IsShameless = false,      // 恥薄い
    bool IsSlacker = false,        // サボり魔
    bool IsWeakToPain = false,     // 痛みに弱い
    bool IsStrongToPain = false,   // 痛みに強い
    bool IsEasilyWet = false,      // 濡れやすい
    bool IsHardlyWet = false,      // 濡れにくい
    bool LearnsFast = false,       // 習得早い
    bool LearnsSlow = false,       // 習得遅い
    bool IsSkilledWithTongue = false, // 舌使い
    bool HasUrinationQuirk = false,   // おもらし癖
    bool MasturbatesEasily = false,   // 自慰しやすい
    bool IsInsensitiveToOdor = false, // 汚臭鈍感
    bool IsSensitiveToOdor = false,   // 汚臭敏感
    bool IsDevoted = false,        // 献身的
    bool IgnoresDirt = false       // 汚れ無視
);

/// <summary>
/// 経験値 (EXP)
/// </summary>
public record Experience(
    int Vaginal = 0,
    int Anal = 0,
    int Oral = 0,
    int Hand = 0,
    int Breast = 0,
    int Foot = 0,
    int Torture = 0,
    int Masochistic = 0,
    int Sadistic = 0,
    int Public = 0,
    int Group = 0
);
