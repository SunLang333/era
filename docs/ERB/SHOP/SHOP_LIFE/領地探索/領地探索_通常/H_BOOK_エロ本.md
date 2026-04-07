# SHOP/SHOP_LIFE/領地探索/領地探索_通常/H_BOOK_エロ本.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/H_BOOK_エロ本.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_H_BOOK_EXISTS, TERRITORY_EVENT_H_BOOK_DECISION, TERRITORY_EVENT_H_BOOK; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_H_BOOK_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_H_BOOK_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_H_BOOK(対象)
#DIM 対象

PRINTFORML 夕暮れどき、河原で古びた本を拾った
PRINTFORML 何の気もなしに読んでみると、エロ本だった
PRINTFORMW 女性が首輪をつけ、犬のように犯されている

IF IS_MALE(対象)
	PRINTFORML 良い拾いものをしたと喜んで持ち帰った
	PRINTFORML 自室でじっくり読み込んだ
	CALL FUCK(対象, "性技")
ELSE
	PRINTFORML 恥じらいながらも釘付けになってしまった
	PRINTFORML こっそり持ち帰り、自室で自慰に耽った
	CALL FUCK(対象, "性技, 自慰, Ｃ, Ｖ, Ｂ" + (HAS_PENIS(対象) ? ", 射精" # ""))
ENDIF

RETURN 1
```
