using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace eratohoK.Cli
{
    public static class ExtractionHelper
    {
        public static void RunDiagnostic(string targetChar)
        {
            Console.WriteLine($"キャラクター {targetChar} の口上セマンティクスを抽出します...");
            var factory = new eratohoK.Semantics.SemanticTextFactory();
            var assets = factory.BuildFromKoujouCsv(targetChar);
            
            foreach (var asset in assets)
            {
                Console.WriteLine($"種類: {asset.SemanticCategory}");
                
                var variationsList = asset.Variations?.ToList() ?? new List<string>();
                if (variationsList.Count > 0)
                {
                    var text = variationsList[0].Replace("\n", "\\n");
                    Console.WriteLine($"- {text}");
                }
                
                if (asset.NormalizedConditions != null)
                {
                    foreach (var cond in asset.NormalizedConditions)
                    {
                        Console.WriteLine($"  条件: {cond.RawText}");
                    }
                }
            }
            
            Console.WriteLine($"--- 抽出終了: {assets.Count}件のセマンティクス ---");
            Console.WriteLine("データベースに保存中...");
            
            var dbPath = "koujou.db";
            using var db = new eratohoK.Data.KoujouDatabase(dbPath);
            db.Initialize();
            db.InsertAssets(assets);
            
            Console.WriteLine($"データベース {dbPath} への保存が完了しました。");
        }
    }
}