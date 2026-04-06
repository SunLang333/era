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
}
