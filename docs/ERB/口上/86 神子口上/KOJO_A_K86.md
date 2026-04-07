# 口上/86 神子口上/KOJO_A_K86.ERB — 自动生成文档

源文件: `ERB/口上/86 神子口上/KOJO_A_K86.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K86, KOJO_TRAIN_END_A1_K86, KOJO_TRAIN_START_A2_K86, KOJO_TRAIN_END_A2_K86, KOJO_COM_BEFORE_TARGET_A_K86, KOJO_COM_BEFORE_PLAYER_A_K86, KOJO_COM_A_K86, KOJO_COM_TARGET_A_K86, KOJO_COM_PLAYER_A_K86, KOJO_COM_AFTER_A_K86; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K86
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		;自分が君主
		IF GET_COUNTRY_BOSS(CFLAG:MASTER:1) == MASTER
			;相手が同盟国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:TARGET:1) == TARGET
				PRINTFORMW 鼻孔をくすぐるのは、謎めいた、しかし安らぐ香の香り。
				PRINTFORMW 眼に飛び込むのは、華やか、しかし品の良い調度品の数々。
				PRINTFORML 
				PRINTFORMW そんな雰囲気に飲まれかけた%ANAME(MASTER)%の耳に、凛々しくも和らかな声が「やぁ」と、響く。
				PRINTFORML 
				PRINTFORML 「あなたが、%CSTR:MASTER:0%の主かな」
				PRINTFORMW 
				PRINTFORMW 「私が%CSTR:TARGET:0%、ここの主だ」
				PRINTFORML 
				PRINTFORMW 
				PRINTFORMW 「知っての通り今の幻想郷はバラバラだ」
				PRINTFORMW 「ここはこの私が皆を導いてあげなくてはね」
				PRINTFORML
				PRINTFORMW 「どうかあなたも私に力を貸してほしい」
				PRINTFORMW 「以後、よろしく頼むよ」
				PRINTFORML 
				PRINTFORMW そうして、かの聖徳王――%CSTR:TARGET:0%%CSTR:TARGET:1%は、ただ優雅な笑みを浮かべ、まるで総てを見通すかのような瞳で%ANAME(MASTER)%を見つめていた。
			;相手が同盟国の士官の場合
			ELSEIF CFLAG:TARGET:1 != CFLAG:MASTER:1
				;PRINTFORMW
			;相手が自国で軟禁状態の場合
			ELSEIF CFLAG:TARGET:捕虜先 == CFLAG:MASTER:1
				PRINTFORMW 「これはこれは、自らお出でになるとは」
				PRINTFORMW 「お前がここの主、だね？」
				PRINTFORML
				PRINTFORMW 「まあ、ここの居心地は悪くないよ」
				PRINTFORMW 「それで、お前はこの私をどうする気かな？」
			;その他(相手が自国の士官)
			ELSE
				PRINTFORMW 「こんにちは」
				PRINTFORMW 「君が私が仕えるべき君主様かな」
				PRINTFORMW 「私の理想と違わぬ限り君の力になろう」
			ENDIF
		;自分が士官
		ELSEIF GET_COUNTRY_BOSS(CFLAG:MASTER:1) != MASTER
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:1) == TARGET
				PRINTFORMW 鼻孔をくすぐるのは、謎めいた、しかし安らぐ香の香り。
				PRINTFORMW 眼に飛び込むのは、華やか、しかし品の良い調度品の数々。
				PRINTFORML 
				PRINTFORMW そんな雰囲気に飲まれかけた%ANAME(MASTER)%の耳に、凛々しくも和らかな声が「やぁ」と、響く。
				PRINTFORML 
				PRINTFORML 「君が、%CSTR:MASTER:0%%CSTR:MASTER:1%くんだね」
				PRINTFORMW 
				PRINTFORMW 「私が%CSTR:TARGET:0%、ここの主である」
				PRINTFORML 
				PRINTFORMW 
				PRINTFORMW 「知っての通り今の幻想郷はバラバラだ」
				PRINTFORMW 「ここはこの私が皆を導いてあげなくてはね」
				PRINTFORML
				PRINTFORMW 「どうか君も私の力になってほしい」
				PRINTFORMW 「以後、よろしく頼むよ」
				PRINTFORML 
				PRINTFORMW そうして、かの聖徳王――%CSTR:TARGET:0%%CSTR:TARGET:1%は、ただ優雅な笑みを浮かべ、まるで総てを見通すかのような瞳で%ANAME(MASTER)%を見つめていた。
			;相手が同盟国の君主の場合
			ELSEIF GET_COUNTRY_BOSS(CFLAG:TARGET:1) == TARGET
				PRINTFORMW 「やぁ、君が%ANAME(MASTER)%くんだね」
				PRINTFORML
				PRINTFORMW 「私が豊聡耳神子、ここの者達を率いている」
				PRINTFORML
				PRINTFORML 「知っての通り今の幻想郷はバラバラだ」
				PRINTFORMW 「ここはこの私が皆を導いてあげなくてはね」
			;相手が同盟国の士官の場合
			ELSEIF CFLAG:TARGET:1 != CFLAG:MASTER:1
				;PRINTFORMW
			;相手が自国で軟禁状態の場合
			ELSEIF CFLAG:TARGET:捕虜先 == CFLAG:MASTER:1
				PRINTFORMW 「まあ、ここの居心地は悪くないよ」
				PRINTFORMW 「それで、この私をどうする気かな？」
			;その他(相手が自国の士官)
			ELSE
				PRINTFORMW 「やあ、こんにちは」
			ENDIF
		;その他
		ELSE
			;PRINTFORMW
		ENDIF
	;既に会ったことがある場合
	ELSE
		;PRINTFORMW 
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	;PRINTFORMW 
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人 
	CFLAG:200 = 4
	;PRINTFORMW 
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	;PRINTFORMW 
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	;PRINTFORMW 

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	;PRINTFORMW 
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	;PRINTFORMW 
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人 
	;PRINTFORMW 
;既成事実Lv1(キス済み)
ELSEIF CFLAG:250 == 1
	;PRINTFORMW 
;既成事実Lv0で恋慕
ELSEIF !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	;PRINTFORMW 
;既成事実Lv0
ELSEIF CFLAG:250 < 1
	;PRINTFORMW 
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K86
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	;PRINTFORMW 
;快感のあまり気絶
ELSEIF TCVAR:52
	;PRINTFORMW 
;疲労による行動不能
ELSEIF TCVAR:51
	;PRINTFORMW 
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした)
IF CFLAG:201 < 5 && TALENT:合意
	CFLAG:201 = 5
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF
;既成事実Lv2(恋人になった)
ELSEIF CFLAG:201 < 4 && TALENT:恋人 
	CFLAG:201 = 4
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF
;既成事実Lv1(初めてキスをした)
ELSEIF CFLAG:201 < 3 && CFLAG:250 == 1
	CFLAG:201 = 3
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
```
