# 口上/09 咲夜口上/COMF_K9/KOJO_HOLLOW_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/KOJO_HOLLOW_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_K9_HOLLOW; UI/print

前 200 行源码片段:

```text
﻿;虚ろ
@KOJO_K9_HOLLOW(咲夜_対象)
#DIM 咲夜_対象
#DIM 咲夜

IF !咲夜_対象
	咲夜_対象 = MASTER
ENDIF

咲夜 = NAME_TO_CHARA("咲夜")

PRINT 「
PRINTDATA
	DATAFORM うー、
	DATAFORM あ
	DATAFORM ……ふぁ
	DATAFORM ん……う
	DATAFORM ふぁ、
	DATAFORM ……ん
	DATAFORM ……は、あ
	DATAFORM あー、
	DATAFORM あう
ENDDATA

PRINTDATA
	DATAFORM うー
	DATAFORM あー……ぁ
	DATAFORM ぅふ
	DATAFORM あ
	DATAFORM ふ
	DATAFORM ぅん
	DATAFORM う
	DATAFORM あー
	DATAFORM あう
ENDDATA
PRINTFORM %BREAK_K9("中", 咲夜_対象)%

PRINTDATA
	DATAFORM あ
	DATAFORM う
	DATAFORM くぅ
	DATAFORM は
	DATAFORM ふぇ
	DATAFORM ん
ENDDATA

PRINTDATA
	DATAFORM ぅ、んう
	DATAFORM う
	DATAFORM ぁ
	DATAFORM ……
ENDDATA
PRINTFORM %BREAK_K9("末", 咲夜_対象)%
PRINTL 」

;─────────────────────────────────────── 
;●戻る
;─────────────────────────────────────── 
RETURN 0

```
