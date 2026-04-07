# SHOP/SHOP_LIFE/領地探索/領地探索_通常/WHIRLWIND_突風.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/WHIRLWIND_突風.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_WHIRLWIND_EXISTS, TERRITORY_EVENT_WHIRLWIND_DECISION, TERRITORY_EVENT_WHIRLWIND; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_WHIRLWIND_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_WHIRLWIND_DECISION(対象)
#DIM 対象
RETURN IS_FEMALE(対象)

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_WHIRLWIND(対象)
#DIM 対象
PRINTFORMW ビュオッ！
PRINTFORML 郊外を歩いていると突然突風が吹いた
PRINTFORML 服がまくれるのを、あわてて抑えた
PRINTFORML ……通りすがった者に見られてしまったようだ
CALL PRINT_ADD_EXP(対象, "露出経験値", 3)

RETURN 1
```
