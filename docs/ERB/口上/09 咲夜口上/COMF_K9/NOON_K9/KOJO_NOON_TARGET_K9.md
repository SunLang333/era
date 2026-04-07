# 口上/09 咲夜口上/COMF_K9/NOON_K9/KOJO_NOON_TARGET_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/NOON_K9/KOJO_NOON_TARGET_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_K9_NOON_BEFORE_TARGET, KOJO_K9_NOON_AFTER_TARGET; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■日常_咲夜_対象_実行前
;─────────────────────────────────────── 
@KOJO_K9_NOON_BEFORE_TARGET(咲夜_対象)
#DIM 咲夜
#DIM 咲夜_対象
#DIMS 咲夜機嫌

IF !咲夜_対象
	咲夜_対象 = MASTER
ENDIF

咲夜 = NAME_TO_CHARA("咲夜")
咲夜機嫌 '= TOSTR_EMOTION(咲夜)

;─────────────────────────────────────── 
;●機嫌が悪ければ通常のコマンド口上は喋らない
;─────────────────────────────────────── 
咲夜機嫌 = %TOSTR_EMOTION(咲夜)%
SELECTCASE 咲夜機嫌
	CASE "恨", "怒", "憤"
		IF PALAM:咲夜:怒主 <= PALAM:咲夜:怒外
			PRINTDATAL
				DATALIST
					DATAFORM 「ちょっと気分が悪いのよ」
					DATAFORM 「心配はいらないわ、%CALLNAME_K9(咲夜_対象)%のせいではないから」
				ENDLIST
				DATAFORM 「ごめんなさい、少し他の事でイライラしていて」
				DATALIST
					DATAFORM 「はぁ、もう……あ。%CALLNAME_K9(咲夜_対象)%に怒っている訳ではないのよ」
					DATAFORM 「機嫌の悪いところを見せちゃってごめんなさいね」
				ENDLIST
				DATAFORM 「嫌なことがあったのよ。聞いてくれるかしら」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「はぁ……」
				DATAFORM 「もうっ」
				DATAFORM 「イライラするわ」
			ENDDATA
		ENDIF
		RETURN 0

	CASE "鬱", "悲", "憂"
		IF PALAM:咲夜:哀主 <= PALAM:咲夜:哀外
			PRINTDATAL
				DATAFORM 「ちょっと気分が塞いでいるの。いえ、%CALLNAME_K9(咲夜_対象)%のせいではないわ」
				DATAFORM 「ごめんなさい。少し落ち込むことがあったの」
				DATAFORM 「はぁ……あ。%CALLNAME_K9(咲夜_対象)%に溜息を吐いた訳ではないのよ。ごめんなさい」
				DATAFORM 「そうね……ちょっと、嫌なことがあって、憂鬱だったの」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「はぁ……」
				DATAFORM 「滅入るわね」
				DATAFORM 「憂鬱だわ」
			ENDDATA
		ENDIF
		RETURN 0

	CASE  "狂", "恐", "怯"
		IF PALAM:咲夜:怖主 <= PALAM:咲夜:怖外
			PRINTDATAL
				DATAFORM 「何なのかしら……いえ、%CALLNAME_K9(咲夜_対象)%のことではないの」
				DATAFORM 「ちょっと怖いのよね……%CALLNAME_K9(咲夜_対象)%がそばにいてくれないかしら」
				DATAFORM 「わけがわからないわね……いえ、%CALLNAME_K9(咲夜_対象)%ではなくて」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「何なのかしら」
				DATAFORM 「正直、怖いのだけれど」
				DATAFORM 「わけがわからないわね」
			ENDDATA
		ENDIF
		RETURN 0

	CASEELSE

ENDSELECT

;─────────────────────────────────────── 
;●同一コマンド
;─────────────────────────────────────── 
IF SELECTCOM == PREVCOM
	;咲夜に主導権なし
	IF !IS_INITIATIVE(咲夜)
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのですね。嬉しいです」
				DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのでしょうか？　喜んで、どうぞ」
				DATAFORM 「私もまだ、%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいと思っていました」
				DATAFORM 「はい。このまま……」
				DATAFORM 「かしこまりました。このままで」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのね。嬉しいわ」
				DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいかしら。いいわ、どうぞ」
				DATAFORM 「私もまだ、%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいと思っていたわ」
				DATAFORM 「そうね。このまま……」
				DATAFORM 「そうしましょう。このままで」
			ENDDATA
		ENDIF
	;咲夜に主導権あり
	ELSE
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですが、お願いしてもよろしいでしょうか」
				DATAFORM 「このままでいられたら嬉しいです」
				DATAFORM 「もう少しこうして%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいです」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「まだ%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たくはないかしら？」
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいわ。いいかしら」
				DATAFORM 「このままがいいわ」
				DATAFORM 「もう少しこうして%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいわ」
			ENDDATA
		ENDIF
	ENDIF
;─────────────────────────────────────── 
;●同一コマンドでない
;─────────────────────────────────────── 
ELSE
	;咲夜に主導権なし
	IF !IS_INITIATIVE(咲夜)
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのですね。嬉しいです」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのですね。そう致しましょう」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのでしょうか？　喜んで、どうぞ」
				DATAFORM 「私も%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいと思っていました」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのね。嬉しいわ」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのね。そうしましょう」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいかしら。いいわ、どうぞ」
				DATAFORM 「私も%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいと思っていたわ」
			ENDDATA
		ENDIF
	;咲夜に主導権あり
	ELSE
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですが、お願いしてもよろしいでしょうか」
				DATAFORM 「あの、%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですけど、よろしいでしょうか？」
				DATAFORM 「あの、%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいです。お付き合い頂けますか？」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいご気分ではありませんか？」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいわ。いいかしら」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいわ」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのだけれど、いいかしら？」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たくはないかしら？」
			ENDDATA
		ENDIF
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●会話
;─────────────────────────────────────── 
IF SELECTCOM == 300
	;咲夜に主導権なし（聞き手）
	IF !IS_INITIATIVE(咲夜)
		PRINTDATAL
			DATAFORM 「あら、%POLITE_K9("そう", "ありがとうございます")%。それは助か%POLITE_K9("るわね", "ります")%」
			DATAFORM 「ええ、楽しみ%POLITE_K9("だわ", "です")%」
			DATAFORM 「%POLITE_K9("あら、さすがね", "さすがです")%」
			DATAFORM 「%POLITE_K9("あら？　感心していたのよ", "いえ。感心しておりました")%」
			DATAFORM 「%POLITE_K9("あら。そうだったのね。知らなかったわ", "そんなこともあったのですね。存じませんでした")%」
			DATAFORM 「%POLITE_K9("そうよね、体が資本だわ", "はい。お体を大事になさってください")%」
			DATAFORM 「%POLITE_K9("あら、それはもったいないわね", "あら、それはもったいないですね")%」
			DATAFORM 「%POLITE_K9("あら、そうなの？　意外な一面が聞けて面白かったわ", "そうだったんですね。意外な一面が聞けて嬉しいです")%」
			DATAFORM 「%POLITE_K9("良い話が聞けたわ", "良いお話を伺えました")%」
			DATAFORM 「ええ、相変わらず%POLITE_K9("よ", "です")%」
			DATAFORM 「聞かせて%POLITE_K9("？　", "ください。")%面白そう%POLITE_K9("だわ", "です")%」
		ENDDATA
	;咲夜に主導権あり（話し手）
	ELSE
		PRINTDATAL
			DATAFORM 「何か困って%POLITE_K9("いるなら手伝うわよ", "いらっしゃるならお手伝いしましょうか")%」
			DATAFORM 「妖精メイドがもう少し役に立って%POLITE_K9(@"くれるといいのだけど", @"くれるといいのですけれど")%」
			DATAFORM 「広すぎて時間でも止めないとやっていられない%POLITE_K9("のよね", "のですよね")%」
			DATAFORM 「この辺りは霧が濃くて涼しい%POLITE_K9("から、体を冷やさないようにね", "ので、体を冷やさないようにしてくださいね")%」
			DATAFORM 「%POLITE_K9("頼りにしているわよ", "頼りにしています")%」
			DATAFORM 「%POLITE_K9("ふう。話せて気が晴れたわ", "聞いてくださってありがとうございます。気が晴れました")%」
			DATAFORM 「本に興味は%POLITE_K9("あるかしら", "ありますか")%？　……えっちな本%POLITE_K9("のことじゃないわよ？", "のことではありませんよ")%」
			DATALIST
				DATAFORM 「今日はお掃除が%POLITE_K9("捗っていたの", "捗っていました")%」
				DATAFORM 「%CALLNAME_K9(咲夜_対象)%が%POLITE_K9("遊びに来る", "来てくださる")%予兆だった%POLITE_K9("のかもしれないわね", "のかもしれません")%」
			ENDLIST
			DATALIST
				DATAFORM 「この辺りの空間、広げ過ぎた%POLITE_K9("かしら", "かもしれません")%」
				DATAFORM 「%POLITE_K9("ごめんなさいね", "申し訳ありません")%。迷わないように%POLITE_K9("気を付けてちょうだいね", "お気を付けください")%」
			ENDLIST
		ENDDATA
	ENDIF
```
