# DEBUGMENU/DEBUG.ERB — 自动生成文档

源文件: `ERB/DEBUGMENU/DEBUG.ERB`

类型: .ERB

自动摘要: functions: DEBUGMENU; UI/print

前 200 行源码片段:

```text
﻿[SKIPSTART]
DEBUG.ERB
=========
概要
----
　eratohoKマップ製作支援を作っていくしていく中でそれらのマップ読み込み、表示が適正に行われるかを確かめるためのシステムが必要だと思ったので作成。
今後類似した機能がほしいと思った場合はここに突っ込んでいく。
[SKIPEND]

@DEBUGMENU()

ALIGNMENT CENTER
CALL SINGLE_DRAWLINE
PRINTL Welcome Debug
CALL SINGLE_DRAWLINE
ALIGNMENT LEFT
WHILE 1
	CALL SINGLE_DRAWLINE
	PRINTL DEBUG MENU
	CALL SINGLE_DRAWLINE
	PRINTBUTTON "0[        やめる]", 0
	PRINTL
	PRINTBUTTON "1[マップデバッグ]", 1
	PRINTL
	INPUT
	SELECTCASE RESULT
		CASE 0
			RETURN
		CASE 1
			CALL MAPDEBUG()
	ENDSELECT
WEND
```
