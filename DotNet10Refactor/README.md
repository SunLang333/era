# eratohoK Reborn - .NET 10 リファクタリング版

## 概要

eratohoK を .NET 10 でリファクタリングしたバージョンです。
元の ERB スクリプトから脱却し、現代的な C# アーキテクチャで再構築されています。

## 主な特徴

### 1. リソースの解離

- **CSV データとの互換性**: 既存の CSV フォーマットを完全にサポート
- **型安全なデータアクセス**: CsvHelper を使用した型安全な CSV パース
- **遅延ロード**: 必要なデータのみをメモリに読み込む

### 2. セマンティックテキストシステム

- **基本意味への分解**: 重複した会話・描写をセマンティックカテゴリに分類
- **コンテキストベース**: 時間帯、感情状態、関係性などのコンテキスト情報を保持
- **LLM 潤色対応**: AI によるテキスト生成・润色のための構造を提供

### 3. アーキテクチャ

```
eratohoK.Core         - コアエンティティとインターフェース
eratohoK.Data         - CSV データアクセス層
eratohoK.Semantics    - セマンティックテキスト処理
eratohoK.GameEngine   - ゲームロジックエンジン
eratohoK.Cli          - コマンドラインインターフェース
```

## プロジェクト構造

```
DotNet10Refactor/
├── eratohoK.Reborn.sln
└── src/
    ├── eratohoK.Core/
    │   ├── Enums.cs              - 列挙型定義
    │   ├── Interfaces.cs         - インターフェース定義
    │   ├── CharacterStats.cs     - ステータスレコード
    │   ├── Character.cs          - キャラクターエンティティ
    │   └── CountryAndCity.cs     - 勢力・都市エンティティ
    ├── eratohoK.Data/
    │   └── CsvDataReader.cs      - CSV データリーダー
    ├── eratohoK.Semantics/
    │   ├── SemanticText.cs       - セマンティックテキスト
    │   └── SemanticTextFactory.cs - ファクトリー
    ├── eratohoK.GameEngine/
    │   └── GameEngine.cs         - ゲームエンジン
    └── eratohoK.Cli/
        └── Program.cs            - エントリーポイント
```

## ビルド方法

### 前提条件

- .NET 10 SDK

### ビルド

```bash
cd DotNet10Refactor
dotnet build
```

### 実行

```bash
dotnet run --project src/eratohoK.Cli/eratohoK.Cli.csproj -- ../CSV
```

## セマンティックテキストシステム

### 基本意味カテゴリ

| カテゴリ | 説明 |
|---------|------|
| Greeting | 挨拶 |
| Farewell | 別れ |
| Thanks | 感謝 |
| Apology | 謝罪 |
| Joy | 喜び |
| Anger | 怒り |
| Sorrow | 悲しみ |
| Fear | 恐怖 |
| Morning | 朝 |
| Night | 夜 |
| TrainingStart | 調教開始 |
| Pleasure | 快感 |
| Pain | 痛み |

### LLM 潤色の使用方法

```csharp
var assetManager = new SemanticTextAssetManager();

// LLM 用プロンプト生成
var prompt = assetManager.GenerateLlmPrompt(
    category: "Greeting",
    baseText: "おはようございます",
    style: "polite"
);

// 結果を LLM API に送信して润色
// ...
```

## CSV 互換性

### サポートされている CSV ファイル

- `Talent.csv` - 素質定義
- `Train.csv` - 調教コマンド
- `Abl.csv` - 能力
- `Base.csv` - 基礎ステータス
- `Exp.csv` - 経験値
- `Item.csv` - アイテム
- `Chara/*.csv` - キャラクターデータ

### 使用例

```csharp
using var csvReader = new CsvDataReader("../CSV");

// 素質定義を読み込み
var talentDefs = csvReader.ReadTalentDefinitions();

// 調教定義を読み込み
var trainDefs = csvReader.ReadTrainDefinitions();

// キャラクター CSV を読み込み
var charaData = csvReader.ReadCharacterCsvs();
```

## 今後の拡張予定

1. **完全な CSV パース**: すべての CSV フォーマットをサポート
2. **口上システム**: 既存の口上ファイルをセマンティックテキストに変換
3. **デイリーイベント**: イベントシステムの再実装
4. **戦略フェーズ**: SLG 要素の実装
5. **バトルシステム**: 戦闘ロジックの実装
6. **UI フロントエンド**: Blazor または Avalonia による UI

## ライセンス

元の eratohoK のライセンスに従います。

## 貢献

バグ報告や機能提案は GitHub Issues で受け付けています。
