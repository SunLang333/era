# 口上/10 レミリア口上/COMF_K10/KOJO_HOLLOW_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/COMF_K10/KOJO_HOLLOW_K10.ERB`

类型: .ERB

自动摘要: functions: KOJO_K10_HOLLOW; UI/print

前 200 行源码片段:

```text
﻿;虚ろ
@KOJO_K10_HOLLOW(レミリア_対象)
#DIM レミリア_対象
#DIM レミリア

IF !レミリア_対象
	レミリア_対象 = MASTER
ENDIF

レミリア = NAME_TO_CHARA("レミリア")

PRINT 「

PRINTDATA
	DATAFORM んうー、
	DATAFORM うあぁ
	DATAFORM ……ふぁ
	DATAFORM う……う
	DATAFORM ふぁ、
	DATAFORM ……あ
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

PRINTFORM %BREAK_K10("中", レミリア_対象)%

PRINTDATA
	DATAFORM あ
	DATAFORM う
	DATAFORM うぅ
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

PRINTFORM %BREAK_K10("末", レミリア_対象)%

PRINTL 」

;─────────────────────────────────────── 
;●戻る
;─────────────────────────────────────── 
RETURN 0

```
