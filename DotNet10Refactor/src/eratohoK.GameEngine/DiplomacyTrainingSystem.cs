namespace eratohoK.GameEngine;

using eratohoK.Core;

public class DiplomacyTrainingSystem
{
    public int DiplomacyTrainedDay { get; set; }
    public int DiplomacyTrainingCharaId { get; set; }
    public bool TrainingRequestPending { get; set; }

    public DiplomacyResult ProposeTraining(Country playerCountry, Country targetCountry,
        Character targetChara, SlgEngine slgEngine, Random rng)
    {
        int relation = slgEngine.GetRelation(playerCountry.Id, targetCountry.Id);
        double successRate = 0.3 + relation / 500.0;
        if (rng.NextDouble() < successRate)
        {
            DiplomacyTrainedDay = 3;
            DiplomacyTrainingCharaId = targetChara.Id;
            TrainingRequestPending = true;
            return new DiplomacyResult(true, $"{targetCountry.Name}との外交調教提案が受け入れられた。3日後に開始。");
        }
        return new DiplomacyResult(false, $"{targetCountry.Name}の提案は断られた。");
    }

    public DiplomacyTrainingEvent? ProcessCountdown(GameStateManager gameState,
        TrainingEngine trainEngine, Random rng)
    {
        if (DiplomacyTrainedDay <= 0) return null;
        DiplomacyTrainedDay--;
        if (DiplomacyTrainedDay > 0) return null;

        TrainingRequestPending = false;
        var target = gameState.GetCharacter(DiplomacyTrainingCharaId);
        if (target == null) return null;

        var caressAction = trainEngine.AvailableActions.FirstOrDefault(a => a.ActionType == TrainingActionType.Caress);
        if (caressAction == null) return new DiplomacyTrainingEvent($"外交調教イベント: {target.Name}との交流が行われた。");

        var playerChar = gameState.GetAllCharacters().FirstOrDefault(c => c.CountryId == gameState.PlayerCountryId);
        if (playerChar == null) return new DiplomacyTrainingEvent($"外交調教: {target.Name}");

        var session = trainEngine.CreateSession(playerChar.Id, target.Id);
        trainEngine.ExecuteAction(session, playerChar, target, caressAction.Id);
        return new DiplomacyTrainingEvent($"外交調教イベント: {target.Name}に愛撫を行った。");
    }
}

public record DiplomacyResult(bool Success, string Message);
public record DiplomacyTrainingEvent(string Message);
