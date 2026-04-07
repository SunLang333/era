# SHOP/SHOP_LIFE/領地探索/領地探索_通常/FIND_A_OZIZOU_お地蔵さんを見つける.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/FIND_A_OZIZOU_お地蔵さんを見つける.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_FIND_A_OZIZOU_EXISTS, TERRITORY_EVENT_FIND_A_OZIZOU_DECISION, TERRITORY_EVENT_FIND_A_OZIZOU; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_FIND_A_OZIZOU_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_FIND_A_OZIZOU_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_FIND_A_OZIZOU(対象)
#DIM 対象

PRINTFORML 人里離れた道端に、さびれたお地蔵さんを見つけた
PRINTFORML 人通りの少ない道なので、忘れられて放置されているのだろう

PRINTL
CALL ASK_MULTI("掃除してやる", "お供えをする", "放っておく")

SELECTCASE RESULT
	CASE 0
		PRINTFORML このままでは哀れだ
		PRINTFORML %ANAME(対象)%は掃除してやることにした
		PRINTFORML ……疲れたがさっきより大分ましになった
		PRINTFORMW 良い気分で拠点へ戻った
		CALL ADD_COOLTIME(対象, 1)
		MAXBASE:対象:体力 += 100
		CALL COLOR_PRINTW(@"体力最大値が100上がって、{MAXBASE:対象:体力}になった", カラー_注意)
	CASE 1
		PRINTFORML 手持ちのお菓子を備えて手を合わせた
		PRINTFORMW …心なしか気分がよくなった気がする
		MAXBASE:対象:体力 += 50
		CALL COLOR_PRINTW(@"体力最大値が50上がって、{MAXBASE:対象:体力}になった", カラー_注意)
	CASE 2
		PRINTFORML 面倒だから放っておこう
		PRINTFORMW 一応手を合わせて、その場を立ち去った
ENDSELECT

RETURN 1

```
