# SHOP/SHOP_LIFE/領地探索/領地探索_通常/SWIMMING_水遊び.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/SWIMMING_水遊び.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_SWIMMING_EXISTS, TERRITORY_EVENT_SWIMMING_DECISION, TERRITORY_EVENT_SWIMMING; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_SWIMMING_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_SWIMMING_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_SWIMMING(対象)
#DIM 対象
PRINTFORML 探索中、森の奥で水浴びに丁度良い水場を見つけた
PRINTFORMW どうしよう？
PRINTL
CALL ASK_MULTI("水浴びをする", "水を飲む")

IF RESULT == 1
	PRINTFORML 水はとても冷たく、飲むと力が湧いてきた
	PRINTFORMW 喉を潤した%ANAME(対象)%は充足して拠点へ戻った
	RETURN 1
ENDIF
PRINTFORML 折角だから水浴びをしていくことにした
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
IF IS_MALE(対象)
	PRINTFORML 気持ちがよかった
	PRINTFORMW さっぱりした%ANAME(対象)%は拠点に戻った
	CALL PRINT_ADD_EXP(対象, "武闘経験値", 1)
ELSE
	PRINTFORML ……どうやら覗かれていたらしい
	PRINTFORML 気づいたときには逃げられてしまっていた
	CALL PRINT_ADD_EXP(対象, "露出経験値", 3)
ENDIF
```
