# SHOP/SHOP_LIFE/領地探索/領地探索_通常/CAPTURE_TUTINOKO_つちのこの捕獲.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/CAPTURE_TUTINOKO_つちのこの捕獲.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_CAPTURE_TUTINOKO_EXISTS, TERRITORY_EVENT_CAPTURE_TUTINOKO_DECISION, TERRITORY_EVENT_CAPTURE_TUTINOKO; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_CAPTURE_TUTINOKO_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_CAPTURE_TUTINOKO_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_CAPTURE_TUTINOKO(対象)
#DIM 対象

PRINTFORML このあたりでツチノコが出たらしい
PRINTFORML 好事家が賞金を出している。小遣い稼ぎになりそうだ
PRINTL
CALL PRINT_ABILITY(対象, GETNUM(ABL, "知略"))

CALL ASK_YN("捕獲を試みる", "やめておく")

IF RESULT == 1
	PRINTFORML そんなことをするほど暇じゃない
	PRINTFORML やめておいた
	RETURN 1
ENDIF

PRINTFORML %ANAME(対象)%は早速、罠を張ることにした……
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
IF LIMIT(ABL:対象:知略, 50, 100) > RAND:100
	PRINTFORML やった！
	PRINTFORML %ANAME(対象)%は見事ツチノコを捕獲した
	PRINTFORMW 好事家から賞金を受け取り、拠点に戻った
	MONEY += 3000
	CALL ICPRINT("金<3000>を手に入れた", "L", カラー_注意)
	RETURN 1
ENDIF

PRINTFORML やられた！
PRINTFORML 餌だけを奪われてしまった
PRINTFORMW 本当にツチノコがいたのかもわからぬまま、%ANAME(対象)%は拠点へ戻った

RETURN 1
```
