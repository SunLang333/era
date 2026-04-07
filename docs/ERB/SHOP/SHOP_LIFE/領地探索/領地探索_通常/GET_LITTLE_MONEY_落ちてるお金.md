# SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_LITTLE_MONEY_落ちてるお金.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_LITTLE_MONEY_落ちてるお金.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_GET_LITTLE_MONEY_EXISTS, TERRITORY_EVENT_GET_LITTLE_MONEY_DECISION, TERRITORY_EVENT_GET_LITTLE_MONEY; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_GET_LITTLE_MONEY_EXISTS()
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_GET_LITTLE_MONEY_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_GET_LITTLE_MONEY(対象)
#DIM 対象
PRINTFORML %ANAME(対象)%は道ばたにお金が落ちているのを見つけた……
CALL ICPRINT("金<500>を手に入れた", "L", カラー_注意)
MONEY += 500
RETURN 1
```
