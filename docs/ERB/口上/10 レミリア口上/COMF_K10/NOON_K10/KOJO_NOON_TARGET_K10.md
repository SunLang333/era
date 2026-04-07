# 口上/10 レミリア口上/COMF_K10/NOON_K10/KOJO_NOON_TARGET_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/COMF_K10/NOON_K10/KOJO_NOON_TARGET_K10.ERB`

类型: .ERB

自动摘要: functions: KOJO_K10_NOON_BEFORE_TARGET, KOJO_K10_NOON_AFTER_TARGET; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■日常_レミリア_対象_実行前
;─────────────────────────────────────── 
@KOJO_K10_NOON_BEFORE_TARGET(レミリア_対象)
#DIM レミリア
#DIM レミリア_対象
#DIMS レミリア機嫌

IF !レミリア_対象
	レミリア_対象 = MASTER
ENDIF

レミリア = NAME_TO_CHARA("レミリア")
レミリア機嫌 '= TOSTR_EMOTION(レミリア)

;─────────────────────────────────────── 
;●機嫌が悪ければ通常のコマンド口上は喋らない
;─────────────────────────────────────── 
レミリア機嫌 = %TOSTR_EMOTION(レミリア)%
SELECTCASE レミリア機嫌
	CASE "恨", "怒", "憤"
		IF PALAM:レミリア:怒主 <= PALAM:レミリア:怒外

		ELSE
			PRINTDATAL
				DATAFORM 「あいつは何やってるの」
				DATAFORM 「もう！　しっかりしてよね」
				DATAFORM 「短絡ね」
				DATAFORM 「理由が分からない」
				DATAFORM 「ふん」
			ENDDATA
		ENDIF
		RETURN 0

	CASE "鬱", "悲", "憂"
		IF PALAM:レミリア:哀主 <= PALAM:レミリア:哀外

		ELSE
			PRINTDATAL
				DATAFORM 「退屈なの」
				DATAFORM 「太陽は嫌いよ」
				DATAFORM 「眠いわ」
			ENDDATA
		ENDIF
		RETURN 0

	CASE  "狂", "恐", "怯"
		IF PALAM:レミリア:怖主 <= PALAM:レミリア:怖外

		ELSE
			PRINTDATAL
				DATAFORM 「おかしなことにしたでしょ」
				DATAFORM 「な、訳ない」
				DATAFORM 「何言ってるのよ」
			ENDDATA
		ENDIF
		RETURN 0

	CASEELSE

ENDSELECT

;─────────────────────────────────────── 
;●同一コマンド
;─────────────────────────────────────── 
IF SELECTCOM == PREVCOM
	;レミリアに主導権なし
	IF !IS_INITIATIVE(レミリア)
		PRINTDATAL
			DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たいのね。いいわ」
			DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たいかしら。いいわ」
			DATAFORM 「私もまだ、%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいわ」
			DATAFORM 「いいわ。このままね」
		ENDDATA
	;レミリアに主導権あり
	ELSE
		PRINTDATAL
			DATAFORM 「まだ%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たくはないかしら？」
			DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいわ。いいわよね？」
			DATAFORM 「このまま？　いいわよ」
			DATAFORM 「もう少しこうして%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいわ」
		ENDDATA
	ENDIF
;─────────────────────────────────────── 
;●同一コマンドでない
;─────────────────────────────────────── 
ELSE
	;レミリアに主導権なし
	IF !IS_INITIATIVE(レミリア)
		PRINTDATAL
			DATAFORM 「%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たいの？　いいわよ」
			DATAFORM 「%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たいのね。わかったわ」
			DATAFORM 「%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たいかしら。そうね」
			DATAFORM 「私も%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいわ」
		ENDDATA
	;レミリアに主導権あり
	ELSE
		PRINTDATAL
			DATAFORM 「%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいわ。いいわよね？」
			DATAFORM 「%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいわ」
			DATAFORM 「%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいから、付き合いなさい」
			DATAFORM 「%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たくはない？」
		ENDDATA
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●会話
;─────────────────────────────────────── 
IF SELECTCOM == 300
	;レミリアに主導権あり（話し手）
	IF IS_INITIATIVE(レミリア)
		IF RAND:13 == 0
			IF CSTR:レミリア_対象:99 != "咲夜"
				PRINTFORML 「うちのメイドは優秀なんだけど、空間を広げ過ぎなのよね」
			ELSE
				PRINTFORML 「うちのメイドは優秀だと思ってるわよ。空間を広げ過ぎること以外はね」
			ENDIF
		ELSEIF RAND:12 == 0
			IF CSTR:レミリア_対象:99 != "フラン"
				PRINTFORML 「そうそう、いい家庭教師はいない？　たまに妹が私をあいつって呼ぶの」
			ELSE
				PRINTFORML 「そうそう、死なない家庭教師を探しているわ」
			ENDIF
		ELSE
			PRINTDATAL
				DATAFORM 「あーあ、月へ行きたいわ」
				DATAFORM 「うーむ。霧が薄いかしら」
				DATAFORM 「面白いことはないの」
				DATAFORM 「部屋？　紅いほうが血の汚れが目立たないでしょ」
				DATAFORM 「え？　蝙蝠は可愛いでしょ」
				DATAFORM 「大図書館？　あの部屋はかび臭いわ。何がいいの」
				DATAFORM 「そうね。人間の里にはあまり行かないわ」
				DATAFORM 「放っておくの？　知識人は本ばっかり読んでて、あんまり役に立たないわね」
				DATAFORM 「やるわよ。何時ぞやの借りを返すチャンスなの」
				DATAFORM 「棺桶は死人の入るものだったら」
				DATAFORM 「寝るのは４時くらい。早寝早起きが自慢なの」
				DATAFORM 「ねぇ鬼ごっこしない？　勝ったら血をちょうだい」
			ENDDATA
		ENDIF
	;レミリアに主導権なし（聞き手）
	ELSE
		PRINTDATAL
			DATAFORM 「部屋？　紅いほうが血が目立たないからよ」
			DATAFORM 「牙が短いのかしらね。零さないで飲むのは難しいわ」
			DATAFORM 「これ？　霧を作っているの」
			DATAFORM 「面白そうね、それ」
			DATAFORM 「他にもそういう話はある？　話してみなさいよ」
			DATAFORM 「それであんなに兵が増えてたのね」
			DATAFORM 「いいわ。その作戦、協力してあげる」
			DATAFORM 「楽しそうね。私にもさせて」
			DATAFORM 「私は小食なの」
			DATAFORM 「食べてもいいのよ」
			DATAFORM 「あんまり外に出して貰えないの。病弱っ娘なのよ」
		ENDDATA
	ENDIF
	RETURN 0

;─────────────────────────────────────── 
;●酒
;─────────────────────────────────────── 
ELSEIF SELECTCOM == 310
	IF IS_INITIATIVE(レミリア)
		PRINTFORML 「いいもの持ってるじゃない」
		PRINTFORML 「紅いのがいいわ」
	ELSE
		PRINTFORML 「紅いのはある？　早くちょうだい」
	ENDIF

;─────────────────────────────────────── 
;●蜂蜜水
;─────────────────────────────────────── 
ELSEIF SELECTCOM == 311
	PRINTFORML 「私は紅いほうが元気出るけど、気持ちは受け取っておくわ」

;─────────────────────────────────────── 
;●水浴び
;─────────────────────────────────────── 
ELSEIF SELECTCOM == 354
	PRINTDATAL
		DATAFORM 「冷たぁい！　水かけたでしょ」
		DATAFORM 「服がぺたぺたくっつくわ」
		DATAFORM 「木陰で潜っちゃえば太陽も平気ね」
		DATAFORM 「こっちにいらっしゃいよ。日陰に休めそうな岩があるわ」
	ENDDATA

;─────────────────────────────────────── 
;●泳ぐ
;─────────────────────────────────────── 
ELSEIF SELECTCOM == 355
	IF TFLAG:18 == 1
		PRINTFORML 「%CALLNAME_K10(レミリア_対象)%の泳ぎ上手だわ。教えてよぉ」
	ELSEIF TFLAG:18 == -1
		IF TFLAG:17 == 1
			PRINTFORML 「%CALLNAME_K10(レミリア_対象)%！？　何してるの」
		ELSEIF TFLAG:17 == 2
			PRINTFORML 「ごぽっ！　うぷっ！　う～～～っ！」
		ELSE
			PRINTFORML 「%CALLNAME_K10(レミリア_対象)%！？　何してるの！　こっちに……ごぽっ！　う～～～っ！」
		ENDIF
```
