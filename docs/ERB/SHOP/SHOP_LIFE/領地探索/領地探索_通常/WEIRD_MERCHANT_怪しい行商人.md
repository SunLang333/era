# SHOP/SHOP_LIFE/領地探索/領地探索_通常/WEIRD_MERCHANT_怪しい行商人.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/WEIRD_MERCHANT_怪しい行商人.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_WEIRD_MERCHANT_EXISTS, TERRITORY_EVENT_WEIRD_MERCHANT_DECISION, TERRITORY_EVENT_WEIRD_MERCHANT; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_WEIRD_MERCHANT_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_WEIRD_MERCHANT_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_WEIRD_MERCHANT(対象)
#DIM 対象

PRINTFORML 行商人に声をかけられた
PRINTFORML なんでも新発売の薬の試供を行っているとのことだ
PRINTFORML 精力がつく自信作らしい
PRINTL
CALL ASK_YN("飲む", "やめておく")

IF RESULT == 1
	PRINTFORML そんな怪しいものはいらない
	PRINTFORML 断った
	RETURN 1
ENDIF

PRINTFORML 面白そうだ
PRINTFORML 試しに飲んでみることにした

PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・

IF !RAND:4
	PRINTFORML ……心なしか気分がよくなった
	MAXBASE:対象:気力 += 100
	CALL ICPRINT(@"気力最大値が<100>上がって、{MAXBASE:対象:気力}になった", "L", カラー_注意)
ELSE
	PRINTFORML ……何も起こらなかった
	PRINTFORML 効果は個人差だと告げて、行商人は立ち去った
ENDIF

RETURN 1
```
