namespace eratohoK.Core;

/// <summary>調教アクション定義</summary>
public record TrainingActionDef(int Id, string Name, int TimeRequired = 10, int[]? SkillRequirements = null);

/// <summary>調教セッション</summary>
public class TrainingSession
{
    public int TrainerId { get; set; }
    public int TargetId { get; set; }
    public List<TrainingActionResult> Actions { get; set; } = new();
    public int TimeUsed { get; set; }
    public bool IsForced { get; set; }
}

/// <summary>調教アクション結果</summary>
public record TrainingActionResult(
    int ActionId,
    string ActionName,
    bool Success,
    string Message,
    IDictionary<string, int>? StatChanges = null
);
