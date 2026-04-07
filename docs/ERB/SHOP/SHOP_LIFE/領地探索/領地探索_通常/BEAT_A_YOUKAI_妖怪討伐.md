# SHOP/SHOP_LIFE/領地探索/領地探索_通常/BEAT_A_YOUKAI_妖怪討伐.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/BEAT_A_YOUKAI_妖怪討伐.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_BEAT_A_YOUKAI_EXISTS, TERRITORY_EVENT_BEAT_A_YOUKAI_DECISION, TERRITORY_EVENT_BEAT_A_YOUKAI; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_BEAT_A_YOUKAI_EXISTS()
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_BEAT_A_YOUKAI_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_BEAT_A_YOUKAI(対象)
#DIM 対象
PRINTFORML この辺りで妖怪が暴れているらしい
PRINTFORML 何とかしてくれと頼まれた
PRINTL
CALL PRINT_ABILITY(対象, GETNUM(ABL, "武闘"))
CALL ASK_YN("討伐を試みる", "やめておく")

IF RESULT == 1
	PRINTFORML 危険だし、やめておいたほうがいいだろう
	PRINTFORMW やめておくことにした
	RETURN 1
ENDIF

PRINTFORML 領民に害が及ぶのは見過ごせない
PRINTFORMW %ANAME(対象)%は妖怪の巣へと乗り込んだ
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・

IF LIMIT(ABL:対象:武闘, 50, 100) > RAND:100
	PRINTFORML やった！
	PRINTFORML %ANAME(対象)%は見事妖怪を討伐することに成功した
	CALL ICPRINT("報酬として金<3000>を手に入れた", "L", カラー_注意)
	CALL PRINT_ADD_EXP(対象, "武闘経験値", RAND:8 + 1, 1)
	MONEY += 3000
	RETURN 1
ENDIF

PRINTFORML やられた！
PRINTFORML 妖怪は想像以上に手強く、返り討ちにあった%ANAME(対象)%は命からがら逃げかえった
CALL ADD_COOLTIME(対象, 2)

RETURN 1
```
