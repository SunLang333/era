# 口上/_KOJO_DEFAULT_MESSAGE.ERB — 自动生成文档

源文件: `ERB/口上/_KOJO_DEFAULT_MESSAGE.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_DEFAULT; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;共通で発生させる地の文
;-------------------------------------------------
@KOJO_EVENT_DEFAULT(ARG)

;-------------------------------------------------
;ファーストキス
;-------------------------------------------------
IF ARG == 1

;-------------------------------------------------
;告白成功
;-------------------------------------------------
ELSEIF ARG == 2
	PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に自分の思いを告げた

	IF IS_SAMESEX(MASTER, TARGET) && !TALENT:両刀
		PRINTFORMW %ANAME(MASTER)%を恋愛の対象として見ていなかった%ANAME(TARGET)%は突然の告白に驚いているようだ…
		PRINTFORMW 少し戸惑いながらも、%ANAME(TARGET)%は%ANAME(MASTER)%の思いを受け入れた
	ELSEIF GET_INITIATIVE_RATE(TARGET) <= 0
		PRINTFORMW ……%ANAME(TARGET)%は、笑顔でその思いを受け入れた
	ELSE
		PRINTFORMW ……%ANAME(TARGET)%は、少し顔を赤くしながらその思いを受け入れた
	ENDIF

	IF TALENT:キス未経験
		PRINTFORMW 恋人となった%ANAME(MASTER)%と%ANAME(TARGET)%は、長く、熱い口づけを交わした
	ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
ELSEIF ARG == 3
	PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に自分の思いを告げた

	IF IS_SAMESEX(MASTER, TARGET) && !TALENT:両刀
		PRINTFORMW %ANAME(MASTER)%を恋愛の対象として見ていなかった%ANAME(TARGET)%は突然の告白に驚いているようだ…
		PRINTFORMW 結局ただの冗談だと思われて、軽くあしらわれてしまった
	ELSEIF GET_INITIATIVE_RATE(TARGET) <= 0
		IF TALENT:恋慕
			PRINTFORMW ……%ANAME(TARGET)%は顔を真っ赤にして逃げ出してしまった
		ELSE
			PRINTFORMW ……%ANAME(TARGET)%は困ったような表情を浮かべると、遠回しに拒絶の意思を伝えてきた
		ENDIF
	ELSE
		IF TALENT:恋慕
			PRINTFORMW ……%ANAME(TARGET)%は顔を真っ赤にして慌てながら拒否した
		ELSE
			PRINTFORMW ……%ANAME(TARGET)%にきっぱりと断られてしまった
		ENDIF
	ENDIF

;-------------------------------------------------
;押し倒し成功(合意は得られない)
;-------------------------------------------------
ELSEIF ARG == 4
	IF ABL:性知識 == 0
		PRINTFORML %ANAME(MASTER)%が%ANAME(TARGET)%の服に手を掛けると、%ANAME(TARGET)%は不思議そうな顔をした
		PRINTFORMW どうやら、これから何をするかよくわかっていないようだ…
	ELSE
		PRINTFORMW すっかり酔いの回った%ANAME(TARGET)%は、%ANAME(MASTER)%が%ANAME(TARGET)%の服に手を掛けても抵抗せずなすがままだ…
	ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
ELSEIF ARG == 5
	IF ABL:性知識 == 0
		PRINTFORML %ANAME(MASTER)%が%ANAME(TARGET)%の服に手を掛けると、%ANAME(TARGET)%は不思議そうな顔をした
		PRINTFORMW どうやら、これから何をするかよくわかっていないようだ…
	ELSEIF TALENT:ツンデレ
		PRINTFORML %ANAME(MASTER)%が服を脱がせようとすると、%ANAME(TARGET)%は%ANAME(MASTER)%を激しく罵ってきた
		PRINTFORMW ……だが、抵抗する気はないようだ
	ELSEIF TALENT:貞操観念
		PRINTFORML %ANAME(MASTER)%が服を脱がせようとすると、%ANAME(TARGET)%は素直に受け入れながらも
		PRINTFORMW 責任を取ってくれるよう迫っている
	ELSE
		PRINTFORMW %ANAME(MASTER)%が服を脱がせようとすると、%ANAME(TARGET)%は素直に受け入れた
	ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
ELSEIF ARG == 6
	IF TALENT:合意
		PRINTFORMW %ANAME(MASTER)%が服を脱がせようとすると、%ANAME(TARGET)%は今はそんな気分ではないと言って断った
	ELSE
		PRINTFORMW %ANAME(MASTER)%が服を脱がせようとすると、%ANAME(TARGET)%は激しく抵抗した
	ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
ELSEIF ARG == 7

;-------------------------------------------------
;真名を許すイベント
;-------------------------------------------------
ELSEIF ARG == 10
	;睡姦を行った場合
	IF TFLAG:8
		PRINTFORMW どうやら%NAME%は%ANAME(MASTER)%が介抱してくれたと思い込んでいるらしく、%ANAME(MASTER)%に感謝の言葉を述べた
		PRINTFORMW %NAME%は%ANAME(MASTER)%に対し、これからは真名の%CALLNAME%で呼ぶように言った
	ELSE
		PRINTFORMW どうやら十分に%NAME%の信頼を得たようだ…
		PRINTFORMW %NAME%は%ANAME(MASTER)%に対し、これからは真名の%CALLNAME%で呼ぶように言った
	ENDIF

;-------------------------------------------------
;怒りの限界で追い返される
;-------------------------------------------------
ELSEIF ARG == 13
	IF FLAG:ウフフフラグ || ABL:武闘 < 60
		PRINTFORML %ANAME(TARGET)%は激しい剣幕で怒鳴りながら\@ FLAG:調教モード != 調教_捕虜調教 ? %ANAME(MASTER)%を追い返した… # 帰っていった… \@
	ELSE
		PRINTFORML %ANAME(TARGET)%は激高して%ANAME(MASTER)%に斬り掛かってきた…
	ENDIF

;-------------------------------------------------
;哀しみの限界で追い返される
;-------------------------------------------------
ELSEIF ARG == 14
	PRINTFORML %ANAME(TARGET)%は一人にして欲しいと言って%ANAME(MASTER)%を追い返した…

;-------------------------------------------------
;怒りの限界で勝手に帰る
;-------------------------------------------------
ELSEIF ARG == 15
	PRINTFORML %ANAME(TARGET)%は怒って帰ってしまった…

;-------------------------------------------------
;哀しみの限界で勝手に帰る
;-------------------------------------------------
ELSEIF ARG == 16
	PRINTFORML %ANAME(TARGET)%はその場から走り去って帰ってしまった…

;-------------------------------------------------
;行動終了時に向こうからキス
;-------------------------------------------------
ELSEIF ARG == 20
	PRINTFORMW %ANAME(MASTER)%が帰ろうとすると、突然%ANAME(TARGET)%に呼び止められた
	IF GROUPMATCH(TALENT:性別, 0, 3)
		IF TALENT:小悪魔
			PRINTFORMW 振り返ってみると、その途端、%ANAME(TARGET)%は強引に%ANAME(MASTER)%の唇を奪った
			PRINTFORMW 唇を離すと、%ANAME(TARGET)%は何事もなかったかのように%ANAME(MASTER)%の手を取って歩き始めた…
			PRINTL 
		ELSEIF TALENT:ツンデレ
			PRINTFORMW 振り返ってみると、その途端、%ANAME(TARGET)%は強引に%ANAME(MASTER)%の唇を奪った
			PRINTFORMW 唇を離すと、%ANAME(TARGET)%は勘違いするなと言って、露骨に不機嫌そうな様子で顔を背けた…
			PRINTL 
		ELSE
			PRINTFORMW 振り返ってみると、そこには緊張した面持ちの%ANAME(TARGET)%が立っていた
			IF GET_INITIATIVE_RATE(TARGET) <= 0
				PRINTFORMW %ANAME(TARGET)%はそっと%ANAME(MASTER)%を抱きしめ、ぎこちない動きで口づけた
				PRINTL 
			ELSE
				PRINTFORMW %ANAME(TARGET)%は強引に%ANAME(MASTER)%を抱きしめると、少し乱暴に口づけてきた
				PRINTL 
			ENDIF
		ENDIF
	ELSE
		IF TALENT:小悪魔
			PRINTFORMW 振り返ってみると、その途端、%ANAME(TARGET)%が抱きついてきて%ANAME(MASTER)%の唇を奪った
			PRINTFORMW 唇を離すと、%ANAME(TARGET)%はイタズラっぽく%ANAME(MASTER)%に微笑んだ…
			PRINTL 
		ELSEIF TALENT:ツンデレ
			PRINTFORMW 振り返ってみると、その途端、%ANAME(TARGET)%は強引に%ANAME(MASTER)%の唇を奪った
			PRINTFORMW 唇を離すと、%ANAME(TARGET)%は勘違いするなと言って、露骨に不機嫌そうな様子で顔を背けた…
			PRINTL 
		ELSE
			PRINTFORMW 振り返ってみると、そこには顔を真っ赤にした%ANAME(TARGET)%が俯いて立っていた
			IF GET_INITIATIVE_RATE(TARGET) <= 0
				PRINTFORMW %ANAME(TARGET)%は、ゆっくりと近付いてきて、そっと%ANAME(MASTER)%に口づけた
				PRINTL 
			ELSE
				PRINTFORMW %ANAME(TARGET)%は、%ANAME(MASTER)%を近くに呼びつけると、少し乱暴に口づけてきた
				PRINTL 
			ENDIF
		ENDIF
	ENDIF

;-------------------------------------------------
;行動終了時に向こうから告白
;キス未経験の場合、このタイミングで一緒にファーストキスもする
;-------------------------------------------------
ELSEIF ARG == 21
	PRINTFORMW %ANAME(MASTER)%が帰ろうとすると、突然%ANAME(TARGET)%に呼び止められた
	;一回目
	IF CFLAG:44 == 0
		PRINTFORMW 振り返ってみると、そこには顔を真っ赤にした%ANAME(TARGET)%が俯いて立っていた
		IF GET_INITIATIVE_RATE(TARGET) <= 0
			PRINTFORMW そして%ANAME(TARGET)%は、恥ずかしがりながら、%ANAME(MASTER)%の事が好きだと伝えてきた
			PRINTL  
		ELSE
			PRINTFORMW そして%ANAME(TARGET)%は、少し乱暴な口調で、%ANAME(MASTER)%の事が好きだと伝えてきた
			PRINTL  
		ENDIF
	;二回目以降
	ELSE
		IF GET_INITIATIVE_RATE(TARGET) <= 0
```
