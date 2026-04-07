# ABL/ABLUP50_69.ERB — 自动生成文档

源文件: `ERB/ABL/ABLUP50_69.ERB`

类型: .ERB

自动摘要: functions: ABLUP_EXPNAME50, CALC_ABLUP_EXP50, ABLUP_EXPNAME51, CALC_ABLUP_EXP51, ABLUP_EXPNAME52, CALC_ABLUP_EXP52, ABLUP_EXPNAME53, CALC_ABLUP_EXP53, ABLUP_EXPNAME54, CALC_ABLUP_EXP54, ABLUP_EXPNAME60, CALC_ABLUP_EXP60, ABLUP_EXPNAME61, CALC_ABLUP_EXP61, ABLUP_NEED_EXP_SLG; assigns RESULTS

前 200 行源码片段:

```text
﻿;経験値のみによる能力上昇(SLG能力)

;-------------------------------------------------
;武闘
;-------------------------------------------------
@ABLUP_EXPNAME50
RESULTS = 武闘経験値

@CALC_ABLUP_EXP50(ARG:0)
;最大値は300
IF ABL:(ARG:0):武闘 >= 300
	RETURN -1
ENDIF

LOCAL:0 = ABLUP_NEED_EXP_SLG(ABL:(ARG:0):武闘) / GROWTYPE_RATE(ARG:0, "武闘")

SIF FIND_PASSIVE_SKILL(ARG:0, "超成長力")
	TIMES LOCAL:0, 0.80

SIF ID_TO_CHARA(FLAG:お気に入り指定キャラ) == ARG:0
	TIMES LOCAL:0, 0.80

IF TALENT:(ARG:0):サボり魔
	SELECTCASE ABL:(ARG:0):武闘
		CASE IS >= 90
			TIMES LOCAL:0, 1.50
		CASE IS >= 80
			TIMES LOCAL:0, 1.25
		CASEELSE
			TIMES LOCAL:0, 1.1
	ENDSELECT
ENDIF
RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;防衛
;-------------------------------------------------
@ABLUP_EXPNAME51
RESULTS = 防衛経験値

@CALC_ABLUP_EXP51(ARG:0)
;最大値は300
IF ABL:(ARG:0):防衛 >= 300
	RETURN -1
ENDIF

LOCAL:0 = ABLUP_NEED_EXP_SLG(ABL:(ARG:0):防衛) / GROWTYPE_RATE(ARG:0, "防衛")

SIF FIND_PASSIVE_SKILL(ARG:0, "超成長力")
	TIMES LOCAL:0, 0.80

SIF ID_TO_CHARA(FLAG:お気に入り指定キャラ) == ARG:0
	TIMES LOCAL:0, 0.80

IF TALENT:(ARG:0):サボり魔
	SELECTCASE ABL:(ARG:0):防衛
		CASE IS >= 90
			TIMES LOCAL:0, 1.50
		CASE IS >= 80
			TIMES LOCAL:0, 1.25
		CASEELSE
			TIMES LOCAL:0, 1.1
	ENDSELECT
ENDIF
RETURN MAX(LOCAL:0, 1)


;-------------------------------------------------
;知略
;-------------------------------------------------
@ABLUP_EXPNAME52
RESULTS = 知略経験値

@CALC_ABLUP_EXP52(ARG:0)
;最大値は300
IF ABL:(ARG:0):知略 >= 300
	RETURN -1
ENDIF

LOCAL:0 = ABLUP_NEED_EXP_SLG(ABL:(ARG:0):知略) / GROWTYPE_RATE(ARG:0, "知略")

SIF FIND_PASSIVE_SKILL(ARG:0, "超成長力")
	TIMES LOCAL:0, 0.80

SIF ID_TO_CHARA(FLAG:お気に入り指定キャラ) == ARG:0
	TIMES LOCAL:0, 0.80

IF TALENT:(ARG:0):サボり魔
	SELECTCASE ABL:(ARG:0):知略
		CASE IS >= 90
			TIMES LOCAL:0, 1.50
		CASE IS >= 80
			TIMES LOCAL:0, 1.25
		CASEELSE
			TIMES LOCAL:0, 1.1
	ENDSELECT
ENDIF
RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;政治
;-------------------------------------------------
@ABLUP_EXPNAME53
RESULTS = 政治経験値

@CALC_ABLUP_EXP53(ARG:0)
;最大値は300
IF ABL:(ARG:0):政治 >= 300
	RETURN -1
ENDIF

LOCAL:0 = ABLUP_NEED_EXP_SLG(ABL:(ARG:0):政治) / GROWTYPE_RATE(ARG:0, "政治")

SIF FIND_PASSIVE_SKILL(ARG:0, "超成長力")
	TIMES LOCAL:0, 0.80

SIF ID_TO_CHARA(FLAG:お気に入り指定キャラ) == ARG:0
	TIMES LOCAL:0, 0.80

IF TALENT:(ARG:0):サボり魔
	SELECTCASE ABL:(ARG:0):政治
		CASE IS >= 90
			TIMES LOCAL:0, 1.50
		CASE IS >= 80
			TIMES LOCAL:0, 1.25
		CASEELSE
			TIMES LOCAL:0, 1.1
	ENDSELECT
ENDIF
RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;妖術
;-------------------------------------------------
@ABLUP_EXPNAME54
RESULTS = 妖術経験値

@CALC_ABLUP_EXP54(ARG:0)
;最大値は300
IF ABL:(ARG:0):妖術 >= 300
	RETURN -1
ENDIF

LOCAL:0 = ABLUP_NEED_EXP_SLG(ABL:(ARG:0):妖術) * 5 / GROWTYPE_RATE(ARG:0, "妖術")

SIF FIND_PASSIVE_SKILL(ARG:0, "超成長力")
	TIMES LOCAL:0, 0.80

SIF ID_TO_CHARA(FLAG:お気に入り指定キャラ) == ARG:0
	TIMES LOCAL:0, 0.80

IF TALENT:(ARG:0):サボり魔
	SELECTCASE ABL:(ARG:0):妖術
		CASE IS >= 50
			TIMES LOCAL:0, 1.50
		CASE IS >= 30
			TIMES LOCAL:0, 1.25
		CASEELSE
			TIMES LOCAL:0, 1.1
	ENDSELECT
ENDIF
RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;歌唱
;-------------------------------------------------
@ABLUP_EXPNAME60
RESULTS = 歌唱経験値

@CALC_ABLUP_EXP60(ARG:0)
;最大値は300
IF ABL:(ARG:0):歌唱 >= 300
	RETURN -1
ENDIF

LOCAL:0 = ABLUP_NEED_EXP_SLG(ABL:(ARG:0):歌唱) / GROWTYPE_RATE(ARG:0, "歌唱")

SIF FIND_PASSIVE_SKILL(ARG:0, "超成長力")
	TIMES LOCAL:0, 0.80

SIF ID_TO_CHARA(FLAG:お気に入り指定キャラ) == ARG:0
	TIMES LOCAL:0, 0.80

IF TALENT:(ARG:0):サボり魔
	SELECTCASE ABL:(ARG:0):歌唱
		CASE IS >= 50
			TIMES LOCAL:0, 1.50
		CASE IS >= 30
			TIMES LOCAL:0, 1.25
		CASEELSE
			TIMES LOCAL:0, 1.1
	ENDSELECT
ENDIF

RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;料理
;-------------------------------------------------
@ABLUP_EXPNAME61
```
