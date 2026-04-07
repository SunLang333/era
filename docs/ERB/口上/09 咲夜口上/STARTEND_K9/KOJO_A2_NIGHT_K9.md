# 口上/09 咲夜口上/STARTEND_K9/KOJO_A2_NIGHT_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/STARTEND_K9/KOJO_A2_NIGHT_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A2_K9, KOJO_TRAIN_END_A2_K9; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●「閨に呼ぶ」の開始時
;─────────────────────────────────────── 
@KOJO_TRAIN_START_A2_K9
#DIM 咲夜_対象
#DIM 咲夜

咲夜_対象 = MASTER
咲夜 = NAME_TO_CHARA("咲夜")

;咲夜口上の使用可否設定と初期化
SIF CFLAG:咲夜:400 == 0
	CALL KOJO_ASK_RESET_K9

;口上を使用しない設定なら戻る
SIF CFLAG:咲夜:400 == 1
	RETURN 0

SETCOLOR 咲夜_口上カラー

;─────────────────────────────────────── 
;○初回
;─────────────────────────────────────── 
IF CFLAG:咲夜:201 == 0

	;閨に呼ぶ口上初回呼び出しフラグオン
	CFLAG:咲夜:201 = 1

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:咲夜:虚ろ
		PRINTFORML 「う……んん……」
		PRINTFORMDL どうにか連れて来たが、%ANAME(咲夜)%は座り込んでしまった……
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常
	;───────────────────────────────────── 
	IF CHECK_K9("敬語")
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%です」
		PRINTFORML 「お待たせ致しました。お招きくださってありがとうございます」
		PRINTFORMDL %ANAME(咲夜)%は頬を紅潮させ期待に潤んだ瞳で%ANAME(咲夜_対象)%を見つめている
	ELSEIF KDVAR:咲夜:咲夜_主の客は
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%よ。……呼んでくれたのね。待っていたわ」
		PRINTFORMDL %ANAME(咲夜)%は頬を紅潮させ期待に潤んだ瞳で%ANAME(咲夜_対象)%を見つめている
	ELSEIF IS_LOVER(咲夜)
		PRINTFORML 「今夜は一緒に眠ってもいいのね」
		PRINTFORML 「ふふ、どきどきしているわ。触って確かめる？」
		PRINTFORMDL %ANAME(咲夜)%は頬を紅潮させ期待に潤んだ瞳で%ANAME(咲夜_対象)%を見つめている
	ELSEIF CFLAG:咲夜:好感度 >= 500
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、来たわよ。夜這いに」
		PRINTFORML 「……冗談よ。呼んだのは%CALLNAME_K9(咲夜_対象)%でしょう？」
		PRINTFORMDL %ANAME(咲夜)%は照れくさそうに頬を染めている
	ELSE
		IF IS_MALE(咲夜_対象)
			PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、来たわよ。ふふっ。女をベッドに呼びつけるなんてね？」
		ELSE
			PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、来たわよ。添い寝が欲しいなんて、寂しくて眠れなかったのかしら？」
		ENDIF
		PRINTFORMDL %ANAME(咲夜)%は照れくさそうに頬を染めている
	ENDIF

;─────────────────────────────────────── 
;○二回目以降
;─────────────────────────────────────── 
ELSE

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:咲夜:虚ろ
		PRINTFORML 「う……んん……」
		PRINTFORMDL どうにか連れて来たが、%ANAME(咲夜)%は座り込んでしまった……
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常
	;───────────────────────────────────── 
	IF IS_SLAVE(咲夜)
		PRINTDATA
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%です❤　
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%です。
		ENDDATA
		PRINTDATAL
			DATAFORM お待たせいたしました」
			DATAFORM 今夜もよろしくお躾ください」
		ENDDATA
		PRINTDATADL
			DATAFORM %ANAME(咲夜)%の白い頬がピンク色に染まっている
			DATAFORM 挨拶をした%ANAME(咲夜)%の声は既に喘ぎ声のように甘く、呼吸も乱れている
			DATAFORM %ANAME(咲夜)%は微かに震えて涙目になっているが、%ANAME(咲夜_対象)%の首に腕を絡めてきた
		ENDDATA

	ELSEIF CHECK_K9("敬語") && IS_LOVER(咲夜)
		PRINTDATA
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%です❤　
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%です。
		ENDDATA
		PRINTDATAL
			DATAFORM お招きくださってありがとうございます」
			DATAFORM お待たせいたしました」
		ENDDATA
		PRINTDATADL
			DATAFORM %ANAME(咲夜)%は頬を紅潮させ期待に潤んだ瞳で%ANAME(咲夜_対象)%を見つめている
			DATAFORM %ANAME(咲夜)%は待ちきれない様子で%ANAME(咲夜_対象)%の首に腕を絡めてきた
			DATAFORM %ANAME(咲夜)%は%ANAME(咲夜_対象)%に身を擦り寄せてきた
			DATAFORM %ANAME(咲夜)%は涼しい表情で%ANAME(咲夜_対象)%の指示を待っているが微かに雌の匂いをさせている
		ENDDATA

	ELSEIF CHECK_K9("敬語")
		PRINTDATAL
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%です。お招きくださってありがとうございます」
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、%ANAME(咲夜)%です。お待たせいたしました」
		ENDDATA
		PRINTDATADL
			DATAFORM %ANAME(咲夜)%はまだ緊張しているのか視線を合わせようとしない
			DATAFORM %ANAME(咲夜)%は%ANAME(咲夜_対象)%の指示を待って動きを止めている
		ENDDATA

	ELSEIF IS_LOVER(咲夜)
		PRINT 「
		PRINTDATA
			DATAFORM %CALLNAME_K9(咲夜_対象)%
			DATAFORM 来たわ
			DATAFORM こんばんは
			DATAFORM お待たせ
			DATAFORM お待たせしちゃったかしら
			DATAFORM ねえ
			DATAFORM 良い夜ね
		ENDDATA
		PRINTDATA
			DATAFORM 、
			DATAFORM 。
			DATAFORM ❤　
		ENDDATA
		PRINTDATAL
			DATAFORM 夜這いよ。ふふっ❤」
			DATAFORM 会いたかったわ」
			DATAFORM 呼んでくれるのを待っていたのよ？」
			DATAFORM 今夜は一緒に眠っていいのね」
			DATAFORM ……なんだか照れくさいのよ。おかしいかしら？」
			DATAFORM 眠る前に一人じゃないのって、幸せね」
		ENDDATA
		PRINTDATADL
			DATAFORM %ANAME(咲夜)%は頬を紅潮させ期待に潤んだ瞳で%ANAME(咲夜_対象)%を見つめている
			DATAFORM %ANAME(咲夜)%は待ちきれない様子で%ANAME(咲夜_対象)%の首に腕を絡めてきた
			DATAFORM %ANAME(咲夜)%は%ANAME(咲夜_対象)%に身を擦り寄せてきた
			DATAFORM %ANAME(咲夜)%は涼しい表情で%ANAME(咲夜_対象)%を待っているが微かに雌の匂いをさせている
			DATAFORM %ANAME(咲夜)%を呼んで自室に戻ると、綺麗に整えられたベッドに%ANAME(咲夜)%が座っていた
		ENDDATA
		;他キャラの行動とかみ合わない可能性
		;%ANAME(咲夜)%は早速%ANAME(咲夜_対象)%を抱きしめ、足で足を絡めとり寝台へと押し倒した

	ELSEIF CFLAG:咲夜:好感度 >= 800
		PRINTDATAL
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、来たわよ。夜這いに。……冗談よ。呼んだのは%CALLNAME_K9(咲夜_対象)%でしょう？」
			DATAFORM 「会いたかったわ。呼んでくれるのを待っていたのよ？」
			DATAFORM 「こんばんは、%CALLNAME_K9(咲夜_対象)%。一人で寝るのは寂しいものね」
		ENDDATA

	ELSE
		IF IS_MALE(咲夜_対象)
			PRINTDATAL
				DATAFORM 「%CALLNAME_K9(咲夜_対象)%、来たわよ。ふふっ。来たからには、すぐには帰らないわよ？」
				DATAFORM 「%CALLNAME_K9(咲夜_対象)%、来たわよ。女をベッドに呼びつけるなんて、どういうつもりかしらね？」
				DATAFORM 「来たわよ。夜に女性を呼ぶのは感心できないけど、まぁいいわ。%CALLNAME_K9(咲夜_対象)%と過ごせばよく眠れるものね」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「%CALLNAME_K9(咲夜_対象)%、来たわよ。添い寝が欲しいなんて、寂しくて眠れなかったのかしら？」
				DATAFORM 「来たわよ、%CALLNAME_K9(咲夜_対象)%。暗いと眠れないのかしらね？　ふふっ」
				DATAFORM 「来たわよ、%CALLNAME_K9(咲夜_対象)%。可愛がって欲しかったのかしら？」
			ENDDATA
		ENDIF
	ENDIF
ENDIF

WAIT
RESETCOLOR
RETURN 0

;─────────────────────────────────────── 
;●「閨に呼ぶ」の終了時
;─────────────────────────────────────── 
@KOJO_TRAIN_END_A2_K9
#DIM 咲夜_対象
#DIM 咲夜
#DIMS 咲夜機嫌

咲夜_対象 = MASTER
咲夜 = NAME_TO_CHARA("咲夜")
咲夜機嫌 '= TOSTR_EMOTION(咲夜)

```
