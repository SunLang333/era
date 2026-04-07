namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// キャラクター反応システム
/// 調教アクション・ステータス・天賦に基づいた短いフレーバーテキストを返す。
/// 原版 ERA の口上（こうじょう）システムを簡易化した静的テキスト版。
/// </summary>
public static class ReactionSystem
{
    private static readonly Random Rng = Random.Shared;

    /// <summary>
    /// アクション実行時のターゲットの反応テキストを返す。
    /// </summary>
    public static string GetTrainingReaction(Character target, TrainingActionType actionType)
    {
        int joy        = target.BaseStatus.Joy;
        int resistance = target.BaseStatus.Resistance;
        int obedience  = target.BaseStatus.Obedience;
        bool isStoic   = target.Talent.IsStoic;
        bool isShy     = target.Talent.IsShy;
        bool isTsundere = target.Talent.IsTsundere;

        // 抵抗段階
        bool isHighResist   = resistance > 400;
        bool isMidResist    = resistance is > 150 and <= 400;
        bool isLowResist    = resistance <= 150;

        // 服従段階
        bool isHighObedient = obedience > 400;

        // 快感段階
        bool isHighJoy = joy > 400;
        bool isMidJoy  = joy is > 150 and <= 400;

        string[] lines = (actionType, isHighResist, isHighObedient, isHighJoy) switch
        {
            // ── 精神調教 (Mental) ──────────────────────────────────────
            (TrainingActionType.Mental, true, _, _) =>
            [
                "黙れ！こんなこと...", "触るな！気持ち悪い！", "あなたなんか大嫌い！",
                "絶対許さない...", "これは支配じゃない！"
            ],
            (TrainingActionType.Mental, false, true, _) =>
            [
                "...はい...", "ご主人様の言う通りです...", "...承知しました...",
                "もっと...ご命令を...", "何でも...聞きます..."
            ],
            (TrainingActionType.Mental, false, false, _) =>
            [
                "...む...", "...なんで...", "...わかった...", "...そう、ですか...",
                "...それが望みなの?"
            ],

            // ── 制裁 (Punishment) ─────────────────────────────────────
            (TrainingActionType.Punishment, true, _, _) =>
            [
                "いたっ!! 何するの!", "やめろ!! 許さない!", "鬼！悪魔！",
                "絶対に仕返しする...", "痛い..痛い..やめてよ!"
            ],
            (TrainingActionType.Punishment, false, _, _) when target.Talent.IsWeakToPain =>
            [
                "あっ..いた..やっ..!", "ひっ..！いたい..っ!", "だめ..そんなに...あっ!",
                "や...やぁ...!", "こんなの...はじめて...!"
            ],
            (TrainingActionType.Punishment, false, _, _) =>
            [
                "っ..くっ...", "...痛い...", "...", "んっ...くっ...", "...うぅ..."
            ],

            // ── 褒美 (Reward) ─────────────────────────────────────────
            (TrainingActionType.Reward, _, true, _) =>
            [
                "ありがとう...ご主人様...", "嬉しい...幸せ...", "もっと...もっとください...",
                "大好き...大好きです...", "こんな優しくしてくれて..."
            ],
            (TrainingActionType.Reward, _, false, _) =>
            [
                "...あの...ありがとう", "...うれし..い？", "...これ...いいの?",
                "...なんか照れる...", "...ふん、感謝はしないけど"
            ],

            // ── 日常 (Daily) ──────────────────────────────────────────
            (TrainingActionType.Daily, _, _, _) =>
            [
                "...ふーん", "...まあいいか", "...そう?", "...うん", "...どういたしまして"
            ],

            // ── 愛撫・肉体系（高快感） ────────────────────────────────
            (_, _, _, true) =>
            [
                "あっ..あっ..!", "んっ..だめ..もっと..!", "はぁ..はぁ..止まらない..!",
                "あああ..っ!", "やぁ..もっと..そこ..!"
            ],

            // ── 愛撫（中快感・羞恥） ──────────────────────────────────
            (_, false, _, _) when isMidJoy && isShy =>
            [
                "んっ..はずかし..い...", "見ないで..っ...", "あ..そこは..だめ...",
                "や...変な声..でちゃう...", "..恥ずかしい...!"
            ],

            // ── 愛撫（高抵抗） ────────────────────────────────────────
            (_, true, _, _) when actionType is
                TrainingActionType.Caress or TrainingActionType.Oral or
                TrainingActionType.Vaginal or TrainingActionType.Anal or
                TrainingActionType.Toy =>
            [
                "やめろ！", "触るな！", "嫌..っ!", "こんなこと..!", "放せ!"
            ],

            // ── デフォルト（低抵抗） ──────────────────────────────────
            _ when isLowResist && isTsundere =>
            [
                "べ、別に気持ちよくなんかないけど...", "んっ..感じてないし...",
                "..ち、違う..これは..!", "な、なによ..勘違いしないで...",
                "あっ..!..な、なんでもない.."
            ],
            _ when isHighObedient =>
            [
                "はい..もっとお願いします...", "..続けて..ください...",
                "ご主人様...好き...", "もっと...触れて..ください...", "あなたのなら..いい..."
            ],
            _ =>
            [
                "..ん...", "..っ...", "..んんっ...", "..やっ...",
                "..はっ..", "..あ.."
            ]
        };

        return lines[Rng.Next(lines.Length)];
    }

    /// <summary>
    /// セッション終了後のターゲットのまとめ反応テキストを返す。
    /// </summary>
    public static string GetSessionEndReaction(Character target)
    {
        int obedience = target.BaseStatus.Obedience;
        int joy       = target.BaseStatus.Joy;
        bool isLover  = target.IsLover;
        bool isInLove = target.IsInLove;

        return (obedience, joy, isLover, isInLove) switch
        {
            (_, _, true, _)              => Pick("...(あなたの傍にいたい)", "(嬉しそうに微笑む)", "「ありがとう...また来てね」"),
            (_, _, _, true)              => Pick("(頬を赤らめている)", "「..またね」", "(チラリとあなたを見る)"),
            (> 500, _, false, false)     => Pick("「..はい、ご主人様」", "(従順に頷く)", "「お望みのままに」"),
            (> 200, > 300, false, false) => Pick("「..もっと、したい」", "(熱い視線)", "(息が荒い)"),
            (_, > 400, _, _)             => Pick("(ぐったりしているが満足そう)", "(甘い息)", "「もう...疲れた...でも良かった」"),
            _                            => Pick("(じっとあなたを見る)", "「...終わり?」", "(そっぽを向く)")
        };

        static string Pick(params string[] arr) => arr[Rng.Next(arr.Length)];
    }

    /// <summary>
    /// 素質ロック解除（初体験等）時の特別反応テキストを返す。
    /// </summary>
    public static string GetFirstTimeReaction(string milestone)
    {
        return milestone switch
        {
            "初キス"     => Pick("「...これが..キス..?」", "(唇をそっと触れる)", "(顔が真っ赤になる)"),
            "処女喪失"   => Pick("(静かに泣いている)", "「..なんか..変な感じ..」", "(震えている)"),
            "アナル初体験" => Pick("「..ひっ..!こんなの..」", "(目を見開く)", "(体が震える)"),
            "恋慕"       => Pick("(あなたをそっと見つめる)", "「..好きって..何?」", "(胸が高鳴っている)"),
            "恋人"       => Pick("「...私の...そばにいて」", "(恥ずかしそうに微笑む)", "「ずっと..一緒にいてほしい」"),
            _            => "(何か特別なことが起きた)"
        };

        static string Pick(params string[] arr) => arr[Rng.Next(arr.Length)];
    }
}
