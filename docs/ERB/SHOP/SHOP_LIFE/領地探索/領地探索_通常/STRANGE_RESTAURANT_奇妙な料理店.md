# SHOP/SHOP_LIFE/領地探索/領地探索_通常/STRANGE_RESTAURANT_奇妙な料理店.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/STRANGE_RESTAURANT_奇妙な料理店.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_STRANGE_RESTAURANT_EXISTS, TERRITORY_EVENT_STRANGE_RESTAURANT_DECISION, TERRITORY_EVENT_STRANGE_RESTAURANT; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_STRANGE_RESTAURANT_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_STRANGE_RESTAURANT_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------    
@TERRITORY_EVENT_STRANGE_RESTAURANT(対象)
#DIM 対象

PRINTFORML 商店街を歩いていると気になる飲食店を見かけた
PRINTFORML 一見ただの料理屋に見えるが……
PRINTFORML 
CALL ASK_YN("入ってみる", "やめておく")

IF RESULT == 1 
	PRINTFORML 腹も減っていない
	PRINTFORML やめておいた
	RETURN 1
ENDIF

PRINTFORML ちょうど腹が減っていたところだ
PRINTFORMW 入ってみることにした
PRINTFORML 
PRINTFORML 店の中は薄暗く、妙な雰囲気だった
PRINTFORML 店員もどこかよそよそしい雰囲気を醸し出している
PRINTFORMW 訝しみながら注文すると、出てきた料理は非常に美味だった
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・

IF RAND:3
	PRINTFORML たっぷり食べて満足した
ELSE
	PRINTFORML 腹を壊してしまった
	PRINTFORML 二度と行くものかと心に誓った
	CALL ADD_COOLTIME(対象, 2)
ENDIF

RETURN 1
```
