namespace eratohoK.Core;

/// <summary>
/// コマンド前置条件バリデーター
/// 原版 ERB の <c>COM_ABLE_{ID}()</c> および <c>COM_ABLE_COMMON()</c> 関数に対応。
/// 複数のバリデーターを組み合わせてコンポジット検証も可能（<see cref="Func{T, TResult}"/> と互換）。
/// </summary>
public interface ICommandValidator
{
    /// <summary>
    /// 指定コンテキストでコマンドが実行可能かを判定する。
    /// </summary>
    /// <param name="context">コマンド実行コンテキスト</param>
    /// <returns><see langword="true"/> なら実行可能</returns>
    bool CanExecute(CommandContext context);

    /// <summary>
    /// 実行不可の場合の理由メッセージを返す。
    /// 実行可能な場合は <see langword="null"/> を返す。
    /// </summary>
    /// <param name="context">コマンド実行コンテキスト</param>
    /// <returns>失敗理由文字列、または <see langword="null"/></returns>
    string? GetFailureReason(CommandContext context);
}

/// <summary>
/// コマンド実行エグゼキューター
/// 原版 ERB の <c>COM_{ID}()</c> 本体ロジックに対応。
/// </summary>
public interface ICommandExecutor
{
    /// <summary>
    /// コマンドを実行し、ステータス変化と SOURCE デルタを含む結果を返す。
    /// </summary>
    /// <param name="context">コマンド実行コンテキスト</param>
    /// <returns>アクション実行結果</returns>
    TrainingActionResult Execute(CommandContext context);
}

/// <summary>
/// SOURCE 値蓄積サービス
/// 原版 ERB の <c>APPLY_SOURCE()</c> 前の累積フックを抽象化したインターフェース。
/// セッション終了時にキャラクターへの最終ステータス変換を行う実装を注入できる。
/// </summary>
public interface ISourceAccumulator
{
    /// <summary>
    /// 蓄積された SOURCE 値をキャラクターへ適用し、最終的なステータス変化を返す。
    /// 原版 ERB の <c>APPLY_SOURCE()</c> に相当。
    /// </summary>
    /// <param name="source">セッション累積 SOURCE 値</param>
    /// <param name="target">変化を受ける対象キャラクター</param>
    /// <param name="config">演算定数を含むゲーム設定</param>
    /// <returns>ステータス名と変化量のマップ</returns>
    IDictionary<string, int> ApplySource(SourceValues source, Character target, GameConfig config);
}
