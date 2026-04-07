# TRAIN/TALENT_CHECK.ERB — 自动生成文档

源文件: `ERB/TRAIN/TALENT_CHECK.ERB`

类型: .ERB

自动摘要: functions: TALENT_CHECK, TALENT_LOSE_PRIDE, TALENT_LOSE_TEISOU, TALENT_CHECK_LOSE_MIND, TALENT_CHECK_FALLEN, GET_FALLEN_BONUS, TALENT_CHECK_OTHERS, TALENT_CHECK_EROS, TALENT_CHECK_PART; UI/print

前 200 行源码片段:

```text
﻿;調教終了時のイベント、特に素質関連

;-------------------------------------------------
;恋慕等の取得
;-------------------------------------------------
@TALENT_CHECK(ARG:0)

SIF IS_ANIMAL(ARG:0) || TALENT:(ARG:0):慰安モブ
	RETURN 0

CALL TALENT_CHECK_LOSE_MIND(ARG:0)

SIF !(TALENT:(ARG:0):虚ろ || TALENT:(ARG:0):崩壊)
	CALL TALENT_CHECK_FALLEN(ARG:0)

CALL GET_FALLEN_BONUS(ARG:0)

CALL TALENT_CHECK_OTHERS(ARG:0)

CALL TALENT_CHECK_EROS(ARG:0)

SIF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_淫乱)
	CALL TALENT_CHECK_PART(ARG:0)

;-------------------------------------------------
;プライド高いを所有するキャラクターが主人した場合の処理
;ARG:1は色変更を行わないフラグ	ARG:2は先頭の改行を行わないフラグ
;-------------------------------------------------
@TALENT_LOSE_PRIDE(ARG:0, ARG:1, ARG:2)
SIF !ARG:1
	SETCOLOR カラー_注意
IF TALENT:(ARG:0):プライド高い
	SIF !ARG:2
		PRINTL 
	PRINTFORML 自尊心を失った%ANAME(ARG:0)%はすっかり弱気になったようだ……
	PRINTFORMW %ANAME(ARG:0)%は<プライド高い>を失った
	TALENT:(ARG:0):プライド高い = 0
	IF TALENT:(ARG:0):孤高 || TALENT:(ARG:0):気丈 || !TALENT:(ARG:0):臆病 || TALENT:(ARG:0):生意気 || TALENT:(ARG:0):ツンデレ || TALENT:(ARG:0):反抗的
		ABL:(ARG:0):主導度Ｎ -= (ABL:(ARG:0):主導度Ｎ + 1000) / 5 * (TALENT:(ARG:0):気丈 + 1)
		ABL:(ARG:0):主導度Ｕ -= (ABL:(ARG:0):主導度Ｕ + 1000) / 5 * (TALENT:(ARG:0):気丈 + 1)
		ABL:(ARG:0):主導度Ｎ = LIMIT(ABL:(ARG:0):主導度Ｎ, -1000, 1000)
		ABL:(ARG:0):主導度Ｕ = LIMIT(ABL:(ARG:0):主導度Ｕ, -1000, 1000)
		IF TALENT:(ARG:0):孤高
			PRINTFORMW %ANAME(ARG:0)%は<孤高>を失った
			TALENT:(ARG:0):孤高 = 0
		ENDIF
		IF TALENT:(ARG:0):気丈
			PRINTFORMW %ANAME(ARG:0)%は<気丈>を失った
			TALENT:(ARG:0):気丈 = 0
		ELSEIF !TALENT:(ARG:0):臆病
			PRINTFORMW %ANAME(ARG:0)%は<臆病>を得た
			TALENT:(ARG:0):臆病 = 1
		ENDIF
		;反発系の素質から一つだけ失う
		IF TALENT:(ARG:0):反抗的
			PRINTFORMW %ANAME(ARG:0)%は<反抗的>を失った
			TALENT:(ARG:0):反抗的 = 0
		ELSEIF TALENT:(ARG:0):生意気
			PRINTFORMW %ANAME(ARG:0)%は<生意気>を失った
			TALENT:(ARG:0):生意気 = 0
		ELSEIF TALENT:(ARG:0):ツンデレ
			PRINTFORMW %ANAME(ARG:0)%は<ツンデレ>を失った
			TALENT:(ARG:0):ツンデレ = 0
		ENDIF
	ENDIF
ENDIF
SIF !ARG:1
	RESETCOLOR

;-------------------------------------------------
;特殊勢力による淫乱取得時などの貞操観念喪失・貞操無頓着入手時の処理
;ARG:1は色変更を行わないフラグ
;-------------------------------------------------
@TALENT_LOSE_TEISOU(ARG:0, ARG:1)
SIF !ARG:1
	SETCOLOR カラー_注意
IF TALENT:(ARG:0):貞操観念
	PRINTFORMW %ANAME(ARG:0)%は<貞操観念>を失い、<貞操無頓着>を得た
	TALENT:(ARG:0):貞操観念 = 0
	TALENT:(ARG:0):貞操無頓着 = 1
ELSEIF !TALENT:(ARG:0):貞操無頓着
	PRINTFORMW %ANAME(ARG:0)%は<貞操無頓着>を得た
	TALENT:(ARG:0):貞操無頓着 = 1
ENDIF
SIF !ARG:1
	RESETCOLOR

;-------------------------------------------------
;虚ろの喪失・回復処理
;-------------------------------------------------
@TALENT_CHECK_LOSE_MIND(ARG:0)

SIF TALENT:(ARG:0):崩壊
	RETURN 0

IF !TALENT:(ARG:0):虚ろ && CFLAG:(ARG:0):崩壊 >= 1000 + MAX(MAXBASE:(ARG:0):精神力, 1000)
	CALL SINGLE_EMPTY_LINE()
	CALL KOJO_EVENT(ARG:0, 78)
	SETCOLOR カラー_注意
	PRINTFORMW %ANAME(ARG:0)%は<虚ろ>を得た
	RESETCOLOR
	TALENT:(ARG:0):虚ろ = 1

;[虚ろ]の回復
ELSEIF TALENT:(ARG:0):虚ろ && CFLAG:(ARG:0):崩壊 < -500 + MAX(MAXBASE:(ARG:0):精神力, 1000)
	CALL SINGLE_EMPTY_LINE()
	PRINTFORMW %ANAME(ARG:0)%の様子が変わった…
	PRINTFORML 疲弊していた%ANAME(ARG:0)%の心はどうにか平常に戻ったようだ
	SETCOLOR カラー_注意
	PRINTFORMW %ANAME(ARG:0)%は<虚ろ>を失った
	RESETCOLOR
	TALENT:(ARG:0):虚ろ = 0
ENDIF

;[崩壊]の取得
IF !TALENT:(ARG:0):崩壊 && CFLAG:(ARG:0):崩壊 >= 3500 + MAX(MAXBASE:(ARG:0):精神力, 1000)
	CALL SINGLE_EMPTY_LINE()
	CALL KOJO_EVENT(ARG:0, 79)
	SETCOLOR カラー_注意
	PRINTFORMW %ANAME(ARG:0)%は<崩壊>を得た
	RESETCOLOR
	TALENT:(ARG:0):崩壊 = 1
ENDIF

;-------------------------------------------------
;恋慕・服従・淫乱
;-------------------------------------------------
@TALENT_CHECK_FALLEN(ARG:0)

LOCAL:1 = 0


IF !IS_SLAVE(ARG:0) && !IS_LOVER(ARG:0) && !IS_SLAVED_BY(ARG:0) && !TALENT:(ARG:0):親友 && IS_SAMESEX(MASTER, ARG:0) && !TALENT:(ARG:0):両刀 && CFLAG:(ARG:0):好感度 >= 1500
	CALL SINGLE_EMPTY_LINE()
	CALL KOJO_EVENT(ARG:0, 61)
	SETCOLOR カラー_注意
	PRINTFORMW %ANAME(ARG:0)%は<親友>を得た
	RESETCOLOR
	TALENT:(ARG:0):親友 = 1
ENDIF

SIF CFLAG:(ARG:0):陥落するな
	GOTO LEWDNESS_CHECK

IF !IS_SLAVE(ARG:0) && !IS_SLAVED_BY(ARG:0) 
	IF !TALENT:(ARG:0):恋慕 && CFLAG:(ARG:0):好感度 > CFLAG:(ARG:0):従属度 && CFLAG:(ARG:0):好感度 >= 1500  && CFLAG:(ARG:0):依存度 >= 300 && (!IS_SAMESEX(MASTER, ARG:0) || TALENT:(ARG:0):両刀 || TALENT:(ARG:0):恋人)
		CALL SINGLE_EMPTY_LINE()
		CALL KOJO_EVENT(ARG:0, 60)
		SETCOLOR カラー_注意
		IF TALENT:(ARG:0):親友
			PRINTFORMW %ANAME(ARG:0)%は<親友>を失い<恋慕>を得た
		ELSE
			PRINTFORMW %ANAME(ARG:0)%は<恋慕>を得た
		ENDIF
		RESETCOLOR
		TALENT:(ARG:0):恋慕 = 1
		TALENT:(ARG:0):親友 = 0
		;堕とした人数＋１
		FLAG:陥落人数 += !(CFLAG:(ARG:0):陥落済み)
		CFLAG:(ARG:0):陥落済み = 1
		LOCAL:1 = 1
	ENDIF

	IF !TALENT:(ARG:0):親愛 && CFLAG:(ARG:0):好感度 >= 10000 && CFLAG:(ARG:0):依存度 >= 3000 && ABL:(ARG:0):奉仕 >= ランク閾値:ランク_その他:ランク_C && TALENT:(ARG:0):恋慕
		CALL SINGLE_EMPTY_LINE()
		CALL KOJO_EVENT(ARG:0, 62)
		SETCOLOR カラー_注意
		PRINTFORMW %ANAME(ARG:0)%は<親愛>を得た
		RESETCOLOR
		TALENT:(ARG:0):親愛 = 1
		LOCAL:1 = 2
	ENDIF
ENDIF

IF !IS_LOVER(ARG:0) && !IS_SLAVED_BY(ARG:0) 
	IF !TALENT:(ARG:0):服従 && CFLAG:(ARG:0):従属度 >= 1500 && CFLAG:(ARG:0):依存度 >= 300 && !TALENT:(ARG:0):恋慕
		CALL SINGLE_EMPTY_LINE()
		CALL KOJO_EVENT(ARG:0, 63)
		SETCOLOR カラー_注意
		IF TALENT:(ARG:0):親友
			PRINTFORMW %ANAME(ARG:0)%は<親友>を失い<服従>を得た
		ELSE
			PRINTFORMW %ANAME(ARG:0)%は<服従>を得た
		ENDIF
		RESETCOLOR
		SIF TALENT:(ARG:0):プライド高い
			CALL TALENT_LOSE_PRIDE(ARG:0)
		TALENT:(ARG:0):親友 = 0
		TALENT:(ARG:0):服従 = 1
		;堕とした人数＋１
		FLAG:陥落人数 += !(CFLAG:(ARG:0):陥落済み)
		CFLAG:(ARG:0):陥落済み = 1
		LOCAL:1 = 3
	ENDIF

	IF !TALENT:(ARG:0):隷属 && CFLAG:(ARG:0):従属度 >= 10000 && CFLAG:(ARG:0):依存度 >= 3000 && ABL:(ARG:0):奉仕 >= ランク閾値:ランク_その他:ランク_C && TALENT:(ARG:0):服従
		CALL SINGLE_EMPTY_LINE()
		CALL KOJO_EVENT(ARG:0, 64)
		SETCOLOR カラー_注意
		PRINTFORMW %ANAME(ARG:0)%は<隷属>を得た
```
