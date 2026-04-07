# SHOP/SHOP_LIFE/領地探索/領地探索_通常/BUY_TACTICAL_BOOK_兵法書を買う.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/BUY_TACTICAL_BOOK_兵法書を買う.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_BUY_TACTICAL_BOOK_EXISTS, TERRITORY_EVENT_BUY_TACTICAL_BOOK_DECISION, TERRITORY_EVENT_BUY_TACTICAL_BOOK; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_BUY_TACTICAL_BOOK_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_BUY_TACTICAL_BOOK_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_BUY_TACTICAL_BOOK(対象)
#DIM 対象

PRINTFORML ふらっと入った書店で気になる本を見かけた
PRINTFORML どうやら兵法書のようだ
PRINTFORMW 折角なので買って読んでみることにした
CALL PRINT_ADD_EXP(対象, "防衛経験値", RAND:10 + 1, 1)

RETURN 1
```
