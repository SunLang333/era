# SHOP/SHOP_LIFE/領地探索/領地探索_通常/GHOST_MASS_GENERATION_怨霊大量発生.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/GHOST_MASS_GENERATION_怨霊大量発生.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_GHOST_MASS_GENERATION_EXISTS, TERRITORY_EVENT_GHOST_MASS_GENERATION_DECISION, TERRITORY_EVENT_GHOST_MASS_GENERATION; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_GHOST_MASS_GENERATION_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_GHOST_MASS_GENERATION_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_GHOST_MASS_GENERATION(対象)
#DIM 対象
#DIM 対象都市

CALL DAILY_EVENT_RAND_CITYSELECT(!IS_COUNTRY(CFLAG:対象:所属))
対象都市 = RESULT
PRINTFORML %CITY_NAME:対象都市%で怨霊が大量発生した
PRINTFORML 害はないようだが住民たちが不安がり、一部が暴徒化したようだ
PRINTFORMW すぐに鎮圧できたものの、混乱で街に被害が出た
LOCAL = MIN(CITY_GUARD:対象都市, 10)
CITY_GUARD:対象都市 -= LOCAL
CALL ICPRINT(@"%CITY_NAME:対象都市%の防衛率が<{LOCAL}>減少し、<{CITY_GUARD:対象都市}>になった", "W", カラー_注意)
RETURN 1


RETURN 1
```
