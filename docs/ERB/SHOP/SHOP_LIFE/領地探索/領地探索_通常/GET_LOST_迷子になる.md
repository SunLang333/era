# SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_LOST_迷子になる.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_LOST_迷子になる.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_GET_LOST_EXISTS, TERRITORY_EVENT_GET_LOST_DECISION, TERRITORY_EVENT_GET_LOST; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_GET_LOST_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_GET_LOST_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_GET_LOST(対象)
#DIM 対象

PRINTFORML …ここはどこだろう？
PRINTFORML 見慣れぬ道を進み過ぎて迷子になってしまったようだ
PRINTFORMW 散々歩き回り疲れ果て、結局通りすがった人力車を頼んで宮殿へ帰り着いた
LOCAL = MIN(MONEY, 2000)
MONEY -= LOCAL
CALL ADD_COOLTIME(対象, 1)
CALL COLOR_PRINTL(@"金{LOCAL}を支払った", カラー_注意)
RETURN 1
```
