# SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_A_GRIMOIRE_魔術書を拾う.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_A_GRIMOIRE_魔術書を拾う.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_GET_A_GRIMOIRE_EXISTS, TERRITORY_EVENT_GET_A_GRIMOIRE_DECISION, TERRITORY_EVENT_GET_A_GRIMOIRE; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_GET_A_GRIMOIRE_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_GET_A_GRIMOIRE_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_GET_A_GRIMOIRE(対象)
#DIM 対象

PRINTFORML 探索途中、古びた本を見つけた
PRINTFORMW どうやら魔術書のようだ
IF TALENT:対象:妖術知識 == 1
	PRINTFORML 中には妖術に関する知識が書かれていた
	PRINTFORML 中々面白い内容だ
	PRINTFORMW 魔術書を懐にしまい込むと、探索に戻った
	CALL PRINT_ADD_EXP(対象, "妖術経験値", RAND:15 + 6, 1)
ELSE
	PRINTFORML ……ページをめくってみても何が書かれているのかもわからない
	PRINTFORML どうせ内容は出鱈目だろう
	PRINTFORMW そこらに放り投げると、探索に戻った
ENDIF
RETURN 1

```
