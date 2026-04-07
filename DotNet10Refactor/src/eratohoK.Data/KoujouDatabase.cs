namespace eratohoK.Data;

using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using eratohoK.Semantics;

public class KoujouDatabase : IDisposable
{
    private readonly SqliteConnection _connection;

    public KoujouDatabase(string dbPath)
    {
        var connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = dbPath
        }.ToString();

        _connection = new SqliteConnection(connectionString);
    }

    public void Initialize()
    {
        _connection.Open();

        using var command = _connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS SemanticAssets (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                CharacterId INTEGER,
                CharacterName TEXT,
                Category TEXT,
                SourceFile TEXT,
                SourceLineStart INTEGER,
                SourceLineEnd INTEGER,
                SourceSymbol TEXT,
                IsDialogue BOOLEAN,
                RawConditionSnippet TEXT
            );

            CREATE TABLE IF NOT EXISTS SemanticConditions (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                AssetId INTEGER,
                ConditionType TEXT,
                RawText TEXT,
                VariableName TEXT,
                ActorTarget TEXT,
                IndexString TEXT,
                Operator TEXT,
                ValueString TEXT,
                FunctionName TEXT,
                FOREIGN KEY(AssetId) REFERENCES SemanticAssets(Id)
            );

            CREATE TABLE IF NOT EXISTS SemanticVariations (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                AssetId INTEGER,
                TextContent TEXT,
                FOREIGN KEY(AssetId) REFERENCES SemanticAssets(Id)
            );
        ";
        command.ExecuteNonQuery();
    }

    public void InsertAssets(IEnumerable<SemanticText> assets)
    {
        using var transaction = _connection.BeginTransaction();
        try
        {
            using var assetCmd = _connection.CreateCommand();
            assetCmd.Transaction = transaction;
            assetCmd.CommandText = @"
                INSERT INTO SemanticAssets (
                    CharacterId, CharacterName, Category, SourceFile, SourceLineStart, SourceLineEnd, SourceSymbol, IsDialogue, RawConditionSnippet
                ) VALUES (
                    @CharacterId, @CharacterName, @Category, @SourceFile, @SourceLineStart, @SourceLineEnd, @SourceSymbol, @IsDialogue, @RawConditionSnippet
                );
                SELECT last_insert_rowid();
            ";

            var pCharId = assetCmd.Parameters.Add("@CharacterId", SqliteType.Integer);
            var pCharName = assetCmd.Parameters.Add("@CharacterName", SqliteType.Text);
            var pCategory = assetCmd.Parameters.Add("@Category", SqliteType.Text);
            var pSourceFile = assetCmd.Parameters.Add("@SourceFile", SqliteType.Text);
            var pSourceLineStart = assetCmd.Parameters.Add("@SourceLineStart", SqliteType.Integer);
            var pSourceLineEnd = assetCmd.Parameters.Add("@SourceLineEnd", SqliteType.Integer);
            var pSourceSymbol = assetCmd.Parameters.Add("@SourceSymbol", SqliteType.Text);
            var pIsDialogue = assetCmd.Parameters.Add("@IsDialogue", SqliteType.Integer);
            var pRawConditionSnippet = assetCmd.Parameters.Add("@RawConditionSnippet", SqliteType.Text);

            using var condCmd = _connection.CreateCommand();
            condCmd.Transaction = transaction;
            condCmd.CommandText = @"
                INSERT INTO SemanticConditions (
                    AssetId, ConditionType, RawText, VariableName, ActorTarget, IndexString, Operator, ValueString, FunctionName
                ) VALUES (
                    @AssetId, @ConditionType, @RawText, @VariableName, @ActorTarget, @IndexString, @Operator, @ValueString, @FunctionName
                );
            ";

            var pcAssetId = condCmd.Parameters.Add("@AssetId", SqliteType.Integer);
            var pcType = condCmd.Parameters.Add("@ConditionType", SqliteType.Text);
            var pcRawText = condCmd.Parameters.Add("@RawText", SqliteType.Text);
            var pcVarName = condCmd.Parameters.Add("@VariableName", SqliteType.Text);
            var pcActor = condCmd.Parameters.Add("@ActorTarget", SqliteType.Text);
            var pcIndex = condCmd.Parameters.Add("@IndexString", SqliteType.Text);
            var pcOp = condCmd.Parameters.Add("@Operator", SqliteType.Text);
            var pcVal = condCmd.Parameters.Add("@ValueString", SqliteType.Text);
            var pcFunc = condCmd.Parameters.Add("@FunctionName", SqliteType.Text);

            using var varCmd = _connection.CreateCommand();
            varCmd.Transaction = transaction;
            varCmd.CommandText = "INSERT INTO SemanticVariations (AssetId, TextContent) VALUES (@AssetId, @TextContent)";
            var pvAssetId = varCmd.Parameters.Add("@AssetId", SqliteType.Integer);
            var pvText = varCmd.Parameters.Add("@TextContent", SqliteType.Text);

            foreach (var asset in assets)
            {
                pCharId.Value = asset.CharacterId.HasValue ? asset.CharacterId.Value : DBNull.Value;
                pCharName.Value = asset.CharacterName ?? (object)DBNull.Value;
                pCategory.Value = asset.SemanticCategory ?? "";
                pSourceFile.Value = asset.SourceFilePath ?? (object)DBNull.Value;
                pSourceLineStart.Value = asset.SourceLineStart.HasValue ? asset.SourceLineStart.Value : DBNull.Value;
                pSourceLineEnd.Value = asset.SourceLineEnd.HasValue ? asset.SourceLineEnd.Value : DBNull.Value;
                pSourceSymbol.Value = asset.SourceSymbol ?? (object)DBNull.Value;
                pIsDialogue.Value = asset is Dialogue ? 1 : 0;
                pRawConditionSnippet.Value = asset.RawConditionSnippet ?? (object)DBNull.Value;

                var assetId = (long)(assetCmd.ExecuteScalar() ?? 0L);

                if (asset.NormalizedConditions != null)
                {
                    foreach (var cond in asset.NormalizedConditions)
                    {
                        pcAssetId.Value = assetId;
                        pcType.Value = cond.GetType().Name;
                        pcRawText.Value = cond.RawText;

                        pcVarName.Value = DBNull.Value;
                        pcActor.Value = DBNull.Value;
                        pcIndex.Value = DBNull.Value;
                        pcOp.Value = DBNull.Value;
                        pcVal.Value = DBNull.Value;
                        pcFunc.Value = DBNull.Value;

                        if (cond is KoujouVariableCondition varCond)
                        {
                            pcVarName.Value = varCond.VariableName ?? (object)DBNull.Value;
                            pcActor.Value = varCond.ActorTarget ?? (object)DBNull.Value;
                            pcIndex.Value = varCond.Index ?? (object)DBNull.Value;
                            pcOp.Value = varCond.Operator ?? (object)DBNull.Value;
                            pcVal.Value = varCond.Value ?? (object)DBNull.Value;
                        }
                        else if (cond is KoujouFunctionCondition funcCond)
                        {
                            pcFunc.Value = funcCond.FunctionName ?? (object)DBNull.Value;
                            pcOp.Value = funcCond.Operator ?? (object)DBNull.Value;
                            pcVal.Value = funcCond.Value ?? (object)DBNull.Value;
                        }

                        condCmd.ExecuteNonQuery();
                    }
                }

                if (asset.Variations != null)
                {
                    foreach (var variation in asset.Variations)
                    {
                        pvAssetId.Value = assetId;
                        pvText.Value = variation ?? "";
                        varCmd.ExecuteNonQuery();
                    }
                }
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}
