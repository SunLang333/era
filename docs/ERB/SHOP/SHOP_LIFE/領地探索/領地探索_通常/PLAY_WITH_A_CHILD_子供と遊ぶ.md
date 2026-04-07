# SHOP/SHOP_LIFE/領地探索/領地探索_通常/PLAY_WITH_A_CHILD_子供と遊ぶ.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/PLAY_WITH_A_CHILD_子供と遊ぶ.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_PLAY_WITH_A_CHILD_EXISTS, TERRITORY_EVENT_PLAY_WITH_A_CHILD_DECISION, TERRITORY_EVENT_PLAY_WITH_A_CHILD; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_PLAY_WITH_A_CHILD_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_PLAY_WITH_A_CHILD_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_PLAY_WITH_A_CHILD(対象)
#DIM 対象
PRINTFORML 探索中、遊んでる子供達に出会った
PRINTFORML 見学していると、ねだられて%ANAME(対象)%も参加させられた
PRINTFORML 
PRINTFORML ……結局一日中付き合う事になった
PRINTFORMW 子供達の遊びに付き合い%ANAME(対象)%は心が穏やかになった
MAXBASE:対象:気力 += 50
CALL ICPRINT(@"気力が<50>上がって、<{MAXBASE:対象:気力}>になった", "L", カラー_注意)

RETURN 1
```
