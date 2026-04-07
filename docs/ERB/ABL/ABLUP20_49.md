# ABL/ABLUP20_49.ERB — 自动生成文档

源文件: `ERB/ABL/ABLUP20_49.ERB`

类型: .ERB

自动摘要: functions: ABLUP_EXPNAME20, CALC_ABLUP_EXP20, ABLUP_EXPNAME21, CALC_ABLUP_EXP21, ABLUP_EXPNAME22, CALC_ABLUP_EXP22, ABLUP_EXPNAME23, CALC_ABLUP_EXP23, ABLUP_EXPNAME24, CALC_ABLUP_EXP24, ABLUP_EXPNAME25, CALC_ABLUP_EXP25, ABLUP_EXPNAME26, CALC_ABLUP_EXP26, ABLUP_EXPNAME27, CALC_ABLUP_EXP27, ABLUP_EXPNAME28, CALC_ABLUP_EXP28, ABLUP_EXPNAME29, CALC_ABLUP_EXP29; assigns RESULTS

前 200 行源码片段:

```text
﻿;経験値のみによる能力上昇

;-------------------------------------------------
;奉仕
;-------------------------------------------------
@ABLUP_EXPNAME20
RESULTS = 奉仕経験値

@CALC_ABLUP_EXP20(ARG:0)
SELECTCASE ABL:(ARG:0):奉仕
	CASE 0
		LOCAL:0 = 5
	CASE 1
		LOCAL:0 = 30
	CASE 2
		LOCAL:0 = 60
	CASE 3
		LOCAL:0 = 150
	CASE 4
		LOCAL:0 = 300
	CASEELSE
		LOCAL:0 = 500 + 250 * (ABL:(ARG:0):奉仕 - 5)
ENDSELECT

;素質による補正
IF TALENT:(ARG:0):中毒しやすい
	TIMES LOCAL:0, 0.80
ENDIF
IF TALENT:(ARG:0):献身的
	TIMES LOCAL:0, 0.80
ENDIF
IF TALENT:(ARG:0):無関心
	TIMES LOCAL:0, 1.20
ENDIF
IF TALENT:(ARG:0):感情乏しい
	TIMES LOCAL:0, 1.20
ENDIF

RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;性交
;-------------------------------------------------
@ABLUP_EXPNAME21
RESULTS = 性交経験値

@CALC_ABLUP_EXP21(ARG:0)
SELECTCASE ABL:(ARG:0):性交
	CASE 0
		LOCAL:0 = 5
	CASE 1
		LOCAL:0 = 15
	CASE 2
		LOCAL:0 = 40
	CASE 3
		LOCAL:0 = 80
	CASE 4
		LOCAL:0 = 160
	CASEELSE
		LOCAL:0 = 240 + 120 * (ABL:(ARG:0):性交 - 5)
ENDSELECT

;素質による補正
IF TALENT:(ARG:0):中毒しやすい
	TIMES LOCAL:0, 0.80
ENDIF

RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;レズ
;-------------------------------------------------
@ABLUP_EXPNAME22
RESULTS = レズ経験値

@CALC_ABLUP_EXP22(ARG:0)
SELECTCASE ABL:(ARG:0):レズ
	CASE 0
		LOCAL:0 = 50
	CASE 1
		LOCAL:0 = 100
	CASE 2
		LOCAL:0 = 200
	CASE 3
		LOCAL:0 = 350
	CASE 4
		LOCAL:0 = 550
	CASEELSE
		LOCAL:0 = 800 + 400 * (ABL:(ARG:0):レズ - 5)
ENDSELECT

;素質による補正
IF TALENT:(ARG:0):中毒しやすい
	TIMES LOCAL:0, 0.80
ENDIF
IF TALENT:(ARG:0):女嫌い
	TIMES LOCAL:0, 2.00
ENDIF
IF TALENT:(ARG:0):両刀
	TIMES LOCAL:0, 0.50
ENDIF

RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;ＢＬ
;-------------------------------------------------
@ABLUP_EXPNAME23
RESULTS = ＢＬ経験値

@CALC_ABLUP_EXP23(ARG:0)
SELECTCASE ABL:(ARG:0):ＢＬ
	CASE 0
		LOCAL:0 = 50
	CASE 1
		LOCAL:0 = 100
	CASE 2
		LOCAL:0 = 200
	CASE 3
		LOCAL:0 = 350
	CASE 4
		LOCAL:0 = 550
	CASEELSE
		LOCAL:0 = 800 + 400 * (ABL:(ARG:0):ＢＬ - 5)
ENDSELECT

;素質による補正
IF TALENT:(ARG:0):中毒しやすい
	TIMES LOCAL:0, 0.80
ENDIF
IF TALENT:(ARG:0):男嫌い
	TIMES LOCAL:0, 2.00
ENDIF
IF TALENT:(ARG:0):両刀
	TIMES LOCAL:0, 0.50
ENDIF

RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;露出
;-------------------------------------------------
@ABLUP_EXPNAME24
RESULTS = 露出経験値

@CALC_ABLUP_EXP24(ARG:0)
SELECTCASE ABL:(ARG:0):露出
	CASE 0
		LOCAL:0 = 15
	CASE 1
		LOCAL:0 = 60
	CASE 2
		LOCAL:0 = 120
	CASE 3
		LOCAL:0 = 250
	CASE 4
		LOCAL:0 = 400
	CASEELSE
		LOCAL:0 = 600 + 300 * (ABL:(ARG:0):露出 - 5)
ENDSELECT

;素質による補正
IF TALENT:(ARG:0):中毒しやすい
	TIMES LOCAL:0, 0.80
ENDIF
IF TALENT:(ARG:0):目立ちたがり
	TIMES LOCAL:0, 0.60
ENDIF
IF TALENT:(ARG:0):恥じらい
	TIMES LOCAL:0, 1.50
ENDIF
IF TALENT:(ARG:0):恥薄い
	TIMES LOCAL:0, 0.80
ENDIF

RETURN MAX(LOCAL:0, 1)

;-------------------------------------------------
;自慰
;-------------------------------------------------
@ABLUP_EXPNAME25
RESULTS = 自慰経験値

@CALC_ABLUP_EXP25(ARG:0)
SELECTCASE ABL:(ARG:0):自慰
	CASE 0
		LOCAL:0 = 10
	CASE 1
		LOCAL:0 = 20
	CASE 2
		LOCAL:0 = 40
	CASE 3
		LOCAL:0 = 80
	CASE 4
		LOCAL:0 = 150
	CASEELSE
		LOCAL:0 = 200 + 100 * (ABL:(ARG:0):自慰 - 5)
ENDSELECT

;素質による補正
```
