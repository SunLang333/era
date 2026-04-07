# SHOP/SHOP_LIFE/領地探索/領地探索_通常/PICKPOCKET_スリにあう.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/PICKPOCKET_スリにあう.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_PICKPOCKET_EXISTS, TERRITORY_EVENT_PICKPOCKET_DECISION, TERRITORY_EVENT_PICKPOCKET; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_PICKPOCKET_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_PICKPOCKET_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_PICKPOCKET(対象)
#DIM 対象

LOCAL = MIN(MONEY, 3000)

PRINTFORML …あれ？
PRINTFORML なんとなく懐を調べると財布がない！
PRINTFORMW どうやら、スリにあってしまったようだ
MONEY -= LOCAL
CALL COLOR_PRINTL(@"金{LOCAL}を盗まれた", カラー_注意)

RETURN 1
```
