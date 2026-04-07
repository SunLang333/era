# R_CHARA/RANDOM_CHARA_CLOTH.ERB — 自动生成文档

源文件: `ERB/R_CHARA/RANDOM_CHARA_CLOTH.ERB`

类型: .ERB

自动摘要: functions: RANDOM_CHARA_CLOTH_SETTING; definition/data

前 200 行源码片段:

```text
﻿;-------------------------
;汎用武将に衣装を設定する
;ランダム衣装強化・修正パッチ追記
;SET_CLOTH_BY_NAMEを多用したので重くなったかもしれません
;SET_CLOTHにするべきか？しかし視認性が悪くなる・決め打ちはよくない
;-------------------------
@RANDOM_CHARA_CLOTH_SETTING()
;0-15男女兼用+TARGETが男なら16-19男専用or女なら20-30女専用
SELECTCASE IFRAND("0TO15", 1, "16TO19", IS_MALE(TARGET), "20TO30", IS_FEMALE(TARGET))
	;0-15男女兼用
	;汎用
	CASE 0
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "帽子")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "服")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "靴")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ズボン")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "トランクス")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "スカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "ブラ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
		ENDIF
	;戦士
	CASE 1
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "兜")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_腕, "ガントレット")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "グリーブ")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "鎧")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "ビキニアーマー")
		ENDIF
	;スーツ
	CASE 2
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "ワイシャツ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上着, "スーツ")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_首, "ネクタイ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "スラックス")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "トランクス")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "靴")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "タイトスカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "ブラ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "ストッキング")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "ハイヒール")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_アクセサリ, "眼鏡")
		ENDIF
	;空手家
	CASE 3
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "はちまき")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "道着")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "ふんどし")
		SIF IS_FEMALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "さらし")
	;忍
	CASE 4
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "忍装束")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "ふんどし")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_腕, "手甲")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "地下足袋")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "頭巾")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "はちまき")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "さらし")
		ENDIF
	;和服
	CASE 5
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "和服")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "足袋")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "下駄")
	;コック
	CASE 6
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "コック帽")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_首, "スカーフ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "服")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上着, "エプロン")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "靴")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ズボン")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "トランクス")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "スカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "ブラ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
		ENDIF
	;ライダー
	CASE 7
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "ヘルメット")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "ライダースーツ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_腕, "レザーグローブ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "ブーツソックス")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "レザーブーツ")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "ボーイレッグ")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "ブラ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
		ENDIF
	;ジャージ
	CASE 8
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "ジャージ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "サンダル")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "トランクス")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
		ENDIF
	;スケーター
	CASE 9
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "ヘルメット")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "タンクトップ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_腕, "グローブ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "ローラースケート")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_アクセサリ, "ゴーグル")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ショートパンツ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "ボーイレッグ")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ミニスカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "スポーツブラ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "スパッツ")
		ENDIF
	;軍服
	CASE 10
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "帽子")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_首, "ネクタイ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "軍服")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_腕, "手袋")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "ブーツ")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ズボン")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "トランクス")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "スカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "ブラ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
		ENDIF
	;囚人
	CASE 11
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_首, "管理タグ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上下服, "囚人服")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_腕, "手錠")
	;研究者
	CASE 12
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "ワイシャツ")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上着, "白衣")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "靴")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_アクセサリ, "眼鏡")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ズボン")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "ブリーフ")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "スカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
		ENDIF
	;寒冷地
	CASE 13
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "帽子")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_首, "マフラー")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "セーター")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上着, "ダウンジャケット")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_腕, "手袋")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "ブーツ")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ズボン")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "トランクス")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "スカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着上, "ブラ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "パンティ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "タイツ")
		ENDIF
	;園児
	CASE 14
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "帽子")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_上服, "スモック")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴下, "靴下")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_靴, "靴")
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_アクセサリ, "名札")
		IF IS_MALE(TARGET)
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "ショートパンツ")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "ブリーフ")
		ELSE
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下服, "サスペンダースカート")
			CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_下着下, "ドロワーズ")
		ENDIF
	;魔導師
	CASE 15
		CALL SET_CLOTH_BY_NAME(TARGET, 衣装部位_頭, "帽子")
```
