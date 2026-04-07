namespace eratohoK.Core;

/// <summary>
/// コマンド実行コンテキスト
/// 一つのコマンド実行に必要なすべての情報を保持するイミュータブルな値オブジェクト。
/// <see cref="ICommandValidator"/> および <see cref="ICommandExecutor"/> の両インターフェースに渡される。
/// </summary>
public record CommandContext
{
    /// <summary>コマンドを実行するトレーナーキャラクター（原版の MPLY 要素）</summary>
    public required Character Trainer { get; init; }

    /// <summary>コマンドの対象キャラクター（原版の MTAR 要素）</summary>
    public required Character Target { get; init; }

    /// <summary>実行する調教アクション定義（原版の COM_{ID} に対応）</summary>
    public required TrainingActionDef Action { get; init; }

    /// <summary>現在の調教セッション（時間・SOURCE 累積を共有）</summary>
    public required TrainingSession Session { get; init; }

    /// <summary>ゲーム設定（演算定数・フラグを含む）</summary>
    public GameConfig Config { get; init; } = new();

    /// <summary>
    /// コマンド固有の追加パラメータ
    /// 例：強制フラグ、複数対象リスト、特殊イベントIDなど
    /// </summary>
    public IDictionary<string, object>? Parameters { get; init; }
}
