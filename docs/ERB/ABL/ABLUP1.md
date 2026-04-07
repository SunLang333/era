# ABL/ABLUP1.ERB — 自动生成文档

源文件: `ERB/ABL/ABLUP1.ERB`

类型: .ERB

自动摘要: functions: ABLUP_EXPNAME1, CALC_ABLUP_EXP1; assigns RESULTS

前 200 行源码片段:

```text
﻿;能力上昇 Ｖ感

;-------------------------------------------------
;能力上昇に必要な経験を設定
;-------------------------------------------------
@ABLUP_EXPNAME1
RESULTS = Ｖ感経験値

;-------------------------------------------------
;能力上昇に必要な経験量を返す関数
;-------------------------------------------------
@CALC_ABLUP_EXP1(ARG:0)
SELECTCASE ABL:(ARG:0):Ｖ感
	CASE 0
		LOCAL:0 = 8
	CASE 1
		LOCAL:0 = 25
	CASE 2
		LOCAL:0 = 50
	CASE 3
		LOCAL:0 = 150
	CASE 4
		LOCAL:0 = 300
	CASEELSE
		LOCAL:0 = 500 + 400 * (ABL:(ARG:0):Ｖ感 - 5)
ENDSELECT

IF ARG:0 == MASTER
	TIMES LOCAL:0, 2.00
ENDIF

;素質による補正
IF TALENT:(ARG:0):Ｖ鈍感
	TIMES LOCAL:0, 1.20
ENDIF
IF TALENT:(ARG:0):Ｖ敏感
	TIMES LOCAL:0, 0.80
ENDIF
IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_淫乱)
	TIMES LOCAL:0, 0.80
ENDIF
IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_淫壷)
	TIMES LOCAL:0, 0.80
ENDIF

RETURN MAX(LOCAL:0, 1)
```
