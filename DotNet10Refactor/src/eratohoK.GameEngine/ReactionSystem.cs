namespace eratohoK.GameEngine;

using System;
using System.Threading.Tasks;
using eratohoK.Core;

/// <summary>
/// キャラクター反応システム
/// 調教アクション・ステータス・天賦に基づいた短いフレーバーテキストを返す。
/// 原版 ERA の口上（こうじょう）システムを簡易化した静的テキスト版。
/// </summary>
public static class ReactionSystem
{
    private static readonly Random Rng = Random.Shared;

    public static IDynamicTextGenerator? TextGenerator { get; set; }

    /// <summary>
    /// LLM を使用した非同期での動的口上・反応生成。
    /// 指定された LLM ジェネレータが設定されていない場合は既存の静的テキストにフォールバックする。
    /// </summary>
    public static Task<string> GetTrainingReactionAsync(Character target, TrainingActionType actionType)
        => GenerateWithFallbackAsync(
            () => SemanticPromptBuilder.BuildReactionPrompt(target, actionType.ToString(), "玩家执行了本次调教指令"),
            () => GetTrainingReaction(target, actionType),
            target.Name);

    /// <summary>
    /// 基于结构化语义事件生成训练反应。
    /// </summary>
    public static Task<string> GetTrainingReactionAsync(DialogueSemanticEvent semanticEvent)
        => GenerateWithFallbackAsync(
            () => SemanticPromptBuilder.BuildReactionPrompt(semanticEvent),
            () => GetTrainingReaction(semanticEvent.Target.ToCharacter(), semanticEvent.ActionType),
            semanticEvent.Target.Name);

    /// <summary>
    /// アクション実行時のターゲットの反応テキストを返す（旧・同期版）。
    /// </summary>
    public static string GetTrainingReaction(Character target, TrainingActionType actionType)
    {
        int joy         = target.BaseStatus.Joy;
        int resistance  = target.BaseStatus.Resistance;
        int obedience   = target.BaseStatus.Obedience;
        bool isShy      = target.Talent.IsShy;
        bool isTsundere = target.Talent.IsTsundere;

        bool isHighResist   = resistance > 400;
        bool isLowResist    = resistance <= 150;
        bool isHighObedient = obedience > 400;
        bool isHighJoy      = joy > 400;
        bool isMidJoy       = joy is > 150 and <= 400;

        string[] lines = (actionType, isHighResist, isHighObedient, isHighJoy) switch
        {
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

            (TrainingActionType.Daily, _, _, _) =>
            [
                "...ふーん", "...まあいいか", "...そう?", "...うん", "...どういたしまして"
            ],

            (_, _, _, true) =>
            [
                "あっ..あっ..!", "んっ..だめ..もっと..!", "はぁ..はぁ..止まらない..!",
                "あああ..っ!", "やぁ..もっと..そこ..!"
            ],

            (_, false, _, _) when isMidJoy && isShy =>
            [
                "んっ..はずかし..い...", "見ないで..っ...", "あ..そこは..だめ...",
                "や...変な声..でちゃう...", "..恥ずかしい...!"
            ],

            (_, true, _, _) when actionType is
                TrainingActionType.Caress or TrainingActionType.Oral or
                TrainingActionType.Vaginal or TrainingActionType.Anal or
                TrainingActionType.Toy =>
            [
                "やめろ！", "触るな！", "嫌..っ!", "こんなこと..!", "放せ!"
            ],

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

    public static Task<string> GetCharacterReactionAsync(Character target, TrainingActionType action)
        => GenerateWithFallbackAsync(
            () => SemanticPromptBuilder.BuildReactionPrompt(target, action.ToString(), "玩家正在执行本次调教指令..."),
            () => GetCharacterReaction(target, action),
            target.Name);

    public static Task<string> GetCharacterReactionAsync(DialogueSemanticEvent semanticEvent)
        => GenerateWithFallbackAsync(
            () => SemanticPromptBuilder.BuildReactionPrompt(semanticEvent),
            () => GetCharacterReaction(semanticEvent.Target.ToCharacter(), semanticEvent.ActionType),
            semanticEvent.Target.Name);

    /// <summary>
    /// キャラクター固有のセリフ付き反応テキストを返す。
    /// キャラクター番号が一致しない場合は汎用テキストにフォールバックする。
    /// </summary>
    public static string GetCharacterReaction(Character target, TrainingActionType action)
    {
        string[]? lines = (target.No, action) switch
        {
            (1, TrainingActionType.Caress)  => new[] { "「…ちょっと、何するのよ」" },
            (1, TrainingActionType.Oral)    => new[] { "「やっ、そんな…」" },
            (1, TrainingActionType.Vaginal) => new[] { "「あっ、あっ…♥」" },
            (2, TrainingActionType.Caress)  => new[] { "「な、なんだよ急に」" },
            (2, TrainingActionType.Oral)    => new[] { "「う、うわっ…」" },
            (2, TrainingActionType.Vaginal) => new[] { "「くっ、気持ちいいじゃないか」" },
            (9, TrainingActionType.Caress)  => new[] { "「お嬢様の許可を…んっ」" },
            (9, TrainingActionType.Oral)    => new[] { "「…私には似合わない、でも…」" },
            (10, TrainingActionType.Caress) => new[] { "「吸血鬼に触れるとは無礼よ…でも悪くはない」" },
            (8, TrainingActionType.Caress)  => new[] { "「本を読んでいたのに…もう」" },
            _ => null
        };

        if (lines != null)
        {
            return lines[Rng.Next(lines.Length)];
        }

        return GetTrainingReaction(target, action);
    }

    public static Task<string> GetSessionEndReactionAsync(Character target)
    {
        var semanticEvent = ReactionSemanticEventFactory.CreateSessionEndEvent(target);
        return GenerateWithFallbackAsync(
            () => SemanticPromptBuilder.BuildReactionPrompt(semanticEvent),
            () => GetSessionEndReaction(target),
            target.Name);
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

    public static Task<string> GetFirstTimeReactionAsync(Character target, string milestone)
    {
        var semanticEvent = ReactionSemanticEventFactory.CreateMilestoneEvent(target, milestone);
        return GenerateWithFallbackAsync(
            () => SemanticPromptBuilder.BuildReactionPrompt(semanticEvent),
            () => GetFirstTimeReaction(milestone),
            target.Name);
    }

    /// <summary>
    /// 素質ロック解除（初体験等）時の特別反応テキストを返す。
    /// </summary>
    public static string GetFirstTimeReaction(string milestone)
    {
        return milestone switch
        {
            "初キス"       => Pick("「...これが..キス..?」", "(唇をそっと触れる)", "(顔が真っ赤になる)"),
            "処女喪失"     => Pick("(静かに泣いている)", "「..なんか..変な感じ..」", "(震えている)"),
            "アナル初体験" => Pick("「..ひっ..!こんなの..」", "(目を見開く)", "(体が震える)"),
            "恋慕"         => Pick("(あなたをそっと見つめる)", "「..好きって..何?」", "(胸が高鳴っている)"),
            "恋人"         => Pick("「...私の...そばにいて」", "(恥ずかしそうに微笑む)", "「ずっと..一緒にいてほしい」"),
            _              => "(何か特別なことが起きた)"
        };

        static string Pick(params string[] arr) => arr[Rng.Next(arr.Length)];
    }

    private static async Task<string> GenerateWithFallbackAsync(
        Func<string> promptFactory,
        Func<string> fallbackFactory,
        string targetName)
    {
        if (TextGenerator == null)
        {
            return fallbackFactory();
        }

        var basePrompt = promptFactory();

        for (int attempt = 1; attempt <= 2; attempt++)
        {
            var prompt = attempt == 1
                ? basePrompt
                : basePrompt + "\n【补充要求】你可以先在<think>...</think>里思考，但最终给玩家看的台词必须放在think块之后单独输出；不要把分析过程混进最终台词。";

            try
            {
                var generated = await TextGenerator.GenerateReactionAsync(prompt);
                if (generated.HasVisibleText && generated.VisibleText != "……")
                {
                    return generated.VisibleText;
                }

                LlmBadOutputLogger.Log(targetName, attempt, "empty-visible-output", prompt, generated.RawText);
            }
            catch (Exception ex)
            {
                LlmBadOutputLogger.Log(targetName, attempt, $"generator-exception:{ex.GetType().Name}:{ex.Message}", prompt, ex.ToString());
            }
        }

        return "……";
    }
}
