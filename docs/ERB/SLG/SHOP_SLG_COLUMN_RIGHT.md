# SLG/SHOP_SLG_COLUMN_RIGHT.ERB — 自动生成文档

源文件: `ERB/SLG/SHOP_SLG_COLUMN_RIGHT.ERB`

类型: .ERB

自动摘要: functions: COLUMN_RIGHT_CLEAR_SLG, COLUMN_RIGHT_PRINTL_SLG; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;右カラムに何も表示しない場合
;左カラムメニューのボタンを呼び出すための空行埋め
;-------------------------------------------------
@COLUMN_RIGHT_CLEAR_SLG
FOR LOCAL:0, LINECOUNT - FIRST_COLUMN_RIGHT_LINE_SLG, LINES_SHOP_DRAW
	CALL COLUMN_RIGHT_PRINTL_SLG
NEXT
RETURN 0

;-------------------------------------------------
;右カラムでPRINTL の代わりに使用する
;-------------------------------------------------
@COLUMN_RIGHT_PRINTL_SLG
;改行に伴う処理であるため改行を行う
PRINTL 
;カラムの行番号を計算して返す
LOCAL:0 = LINECOUNT - FIRST_COLUMN_RIGHT_LINE_SLG
;最大行数に到達していなければメニューを表示する
IF LOCAL:0 < LINES_SHOP_DRAW
	CALL COLUMN_LEFT_MENU_SHOW_SLG(LOCAL:0)
ENDIF

```
