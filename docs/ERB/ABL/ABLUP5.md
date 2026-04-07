# ABL/ABLUP5.ERB — 自动生成文档

源文件: `ERB/ABL/ABLUP5.ERB`

类型: .ERB

自动摘要: functions: ABLUP_EXPNAME5, CALC_ABLUP_EXP5; assigns RESULTS

前 200 行源码片段:

```text
﻿;能力上昇 Ｕ感

;-------------------------------------------------
;能力上昇に必要な経験を設定
;-------------------------------------------------
@ABLUP_EXPNAME5
RESULTS = Ｕ感経験値

;-------------------------------------------------
;能力上昇に必要な経験量を返す関数
;-------------------------------------------------
@CALC_ABLUP_EXP5(ARG:0)
SELECTCASE ABL:(ARG:0):Ｕ感
	CASE 0
		LOCAL:0 = 10
	CASE 1
		LOCAL:0 = 30
	CASE 2
		LOCAL:0 = 60
	CASE 3
		LOCAL:0 = 150
	CASE 4
		LOCAL:0 = 450
	CASEELSE
		LOCAL:0 = 600 + 300 * (ABL:(ARG:0):Ｕ感 - 5)
ENDSELECT

IF ARG:0 == MASTER
	TIMES LOCAL:0, 2.00
ENDIF

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_淫乱)
	TIMES LOCAL:0, 0.80
ENDIF
IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_尿道狂い)
	TIMES LOCAL:0, 0.80
ENDIF

RETURN MAX(LOCAL:0, 1)
```
