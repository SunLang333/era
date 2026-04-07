# 口上/09 咲夜口上/COMF_K9/NOON_K9/KOJO_NOON_PLAYER_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/NOON_K9/KOJO_NOON_PLAYER_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_K9_NOON_BEFORE_PLAYER, KOJO_K9_NOON_AFTER_PLAYER; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■日常_実行_実行前
;─────────────────────────────────────── 
@KOJO_K9_NOON_BEFORE_PLAYER(咲夜_対象)
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
IF SELECTCOM == PREVCOM && RAND:10 == 0
	;咲夜に主導権なし
	IF !IS_INITIATIVE(咲夜)
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですね。喜んで」
				DATAFORM 「このままですか？　かしこまりました」
				DATAFORM 「はい。もう少し、このまま……」
				DATAFORM 「私もまだ、%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいです」
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですね」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのね。ふふっ」
				DATAFORM 「このままね？　わかっているわ」
				DATAFORM 「そうね。もう少し、このままがいいわ」
				DATAFORM 「私もまだ、%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいわ」
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのでしょう？」
			ENDDATA
		ENDIF
	;咲夜に主導権あり
	ELSE
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「まだ%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいです……」
				DATAFORM 「もう少しお付き合い頂けませんか？」
				DATAFORM 「どうかこのままご一緒ください」
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たくはありませんか？」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいわ」
				DATAFORM 「もう少し付き合ってもらえるかしら？」
				DATAFORM 「まだしてもいいかしら？」
				DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たくはないかしら？」
			ENDDATA
		ENDIF
	ENDIF
;─────────────────────────────────────── 
;●同一コマンドでない
;─────────────────────────────────────── 
ELSEIF RAND:10 == 0
	;咲夜に主導権なし
	IF !IS_INITIATIVE(咲夜)
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですね」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですね。喜んで」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのですね。かしこまりました」
				DATAFORM 「私も%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいです」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのね」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのね。ふふっ。いいわ」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たいのね。わかっているわ」
				DATAFORM 「私も%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいわ」
			ENDDATA
		ENDIF
	;咲夜に主導権あり
	ELSE
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいのですが、お付き合い頂けませんか？」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいです。よろしいでしょうか？」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たくはありませんか？」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいわ。付き合ってもらえるかしら？」
				DATAFORM 「%KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たいわ。いいかしら？」
				DATAFORM 「%KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たくはないかしら？」
			ENDDATA
		ENDIF
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●スキンシップ・背中を洗う
;─────────────────────────────────────── 
IF GROUPMATCH(SELECTCOM, 320, 358)
	;咲夜に主導権なし
	IF !IS_INITIATIVE(咲夜)
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「こうでしょうか……くすぐったいですか？」
				DATAFORM 「もっと近寄ってもいいのですね。嬉しいです」
				DATAFORM 「こうしていると優しい気持ちになれます」
				DATAFORM 「このくらいでしょうか？」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「こうかしら？　……くすぐったい？」
				DATAFORM 「こう？　ふふ、近いわね。可愛いわ」
				DATAFORM 「こうしていると優しい気持ちになれるわ」
				DATAFORM 「このくらいかしら」
			ENDDATA
		ENDIF
	;咲夜に主導権あり
	ELSE
		IF CHECK_K9("敬語")
			PRINTDATAL
				DATAFORM 「ふふっ。くすぐったいでしょうか？」
				DATAFORM 「少し近寄ってみたくなって……失礼でしょうか？」
				DATAFORM 「こういうのって優しい気持ちになれるんですね」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「ふふっ。くすぐったいかしら」
				DATAFORM 「ちょっと仲良くしてみたくなったのよ」
				DATAFORM 「こういうのって優しい気持ちになるのね」
				DATAFORM 「このくらいかしら」
			ENDDATA
		ENDIF
	ENDIF
	RETURN 0
ENDIF

```
