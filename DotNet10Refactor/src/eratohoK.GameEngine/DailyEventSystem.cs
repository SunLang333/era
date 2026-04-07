namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class DailyEventSystem
{
    private record EventDef(string Name, int RatePerMille,
        Func<Character, IReadOnlyList<Character>, bool> Condition,
        Func<Character, IReadOnlyList<Character>, Random, DailyEventResult?> Execute);

    private static readonly IReadOnlyList<EventDef> Events = BuildEvents();

    public static DailyEventResult? TryFireEvent(GameStateManager gameState, Character player, Random rng)
    {
        var allChars = gameState.GetAllCharacters();
        foreach (var ev in Events)
        {
            if (rng.Next(1000) >= ev.RatePerMille) continue;
            if (!ev.Condition(player, allChars)) continue;
            var result = ev.Execute(player, allChars, rng);
            if (result != null) return result;
        }
        return null;
    }

    private static IReadOnlyList<EventDef> BuildEvents() => [
        new("見知らぬ手紙", 30,
            (p, chars) => chars.Any(c => c.Id != p.Id),
            (p, chars, rng) => {
                var others = chars.Where(c => c.Id != p.Id).ToList();
                var c = others[rng.Next(others.Count)];
                c.Likeability += 20;
                return new DailyEventResult("見知らぬ手紙", $"{c.Name}から謎めいた手紙と贈り物が届いた。", [$"{c.Name}:好感度 +20"]);
            }),
        new("訓練中の事故", 40,
            (p, chars) => chars.Any(c => c.Id != p.Id),
            (p, chars, rng) => {
                var others = chars.Where(c => c.Id != p.Id).ToList();
                var c = others[rng.Next(others.Count)];
                c.BaseStatus = c.BaseStatus with { Physical = Math.Max(0, c.BaseStatus.Physical - 200), Fear = Math.Min(1000, c.BaseStatus.Fear + 100) };
                return new DailyEventResult("訓練中の事故", $"{c.Name}が訓練中に怪我をした。", [$"{c.Name}: 体力-200、恐怖+100"]);
            }),
        new("夢を見た", 60,
            (p, chars) => chars.Any(c => c.IsInLove),
            (p, chars, rng) => {
                var inLove = chars.Where(c => c.IsInLove).ToList();
                var c = inLove[rng.Next(inLove.Count)];
                c.Likeability += 50;
                return new DailyEventResult("夢を見た", $"{c.Name}があなたの夢を見たらしい。", [$"{c.Name}: 好感度+50"]);
            }),
        new("宴会", 50,
            (_, chars) => chars.Count > 0,
            (p, chars, rng) => {
                foreach (var c in chars) c.BaseStatus = c.BaseStatus with { Joy = Math.Min(1000, c.BaseStatus.Joy + 30) };
                return new DailyEventResult("宴会", "宴会が開かれ、皆の気分が上がった。", ["全員: 愉悦+30"]);
            }),
        new("好意的な噂", 35,
            (p, chars) => chars.Any(c => c.Id != p.Id),
            (p, chars, rng) => {
                var others = chars.Where(c => c.Id != p.Id).ToList();
                var c = others[rng.Next(others.Count)];
                c.UpdateLikeability(p.Id, 30);
                return new DailyEventResult("好意的な噂", $"{c.Name}があなたの良い噂を聞いた。", [$"{c.Name}: 好感度+30"]);
            }),
        new("戦場の噂", 25,
            (p, chars) => true,
            (p, chars, rng) =>
                new DailyEventResult("戦場の噂", "遠くで戦いが起きているという噂が流れた。", [])),
        new("技術発見", 20,
            (p, chars) => true,
            (p, chars, rng) =>
                new DailyEventResult("技術発見", "新たな技術の片鱗が発見された。", ["技術ポイント+1（将来実装）"])),
        new("謀反の気配", 15,
            (p, chars) => chars.Any(c => c.BaseStatus.Resistance > 500),
            (p, chars, rng) => {
                var rebels = chars.Where(c => c.BaseStatus.Resistance > 500).ToList();
                var c = rebels[rng.Next(rebels.Count)];
                c.SpecialState = SpecialState.Wanderer;
                return new DailyEventResult("謀反の気配", $"{c.Name}が姿を消した...", [$"{c.Name}: 流浪状態になった"]);
            })
    ];
}

public record DailyEventResult(string EventName, string Message, IReadOnlyList<string> Details);
