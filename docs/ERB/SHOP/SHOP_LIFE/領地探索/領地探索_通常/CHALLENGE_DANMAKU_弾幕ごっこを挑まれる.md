# SHOP/SHOP_LIFE/領地探索/領地探索_通常/CHALLENGE_DANMAKU_弾幕ごっこを挑まれる.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/CHALLENGE_DANMAKU_弾幕ごっこを挑まれる.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_CHALLENGE_DANMAKU_EXISTS, TERRITORY_EVENT_CHALLENGE_DANMAKU_DECISION, TERRITORY_EVENT_CHALLENGE_DANMAKU; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_CHALLENGE_DANMAKU_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_CHALLENGE_DANMAKU_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_CHALLENGE_DANMAKU(対象)
#DIM 対象
PRINTFORML 道を歩いていると、野良妖怪に弾幕ごっこを挑まれた
PRINTFORML 勝てば金をくれるというが……
PRINTL
CALL PRINT_ABILITY(対象, GETNUM(ABL, "武闘"))
CALL PRINT_ABILITY(対象, GETNUM(ABL, "知略"))
CALL ASK_YN("受けて立つ", "断る")
IF RESULT == 1
	PRINTFORML そんな暇はない
	PRINTFORML 断った
	RETURN 1
ENDIF

PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
IF LIMIT(ABL:対象:武闘 + ABL:対象:知略, 75, 150) > RAND:150
	PRINTFORML 見事勝利した！
	PRINTFORML 良い勝負で自信がついた
	CALL ICPRINT("賞金として金<5000>を手に入れた", "L", カラー_注意)
	CALL PRINT_ADD_EXP(対象, "武闘経験値", RAND:8 + 6, 1)
	CALL PRINT_ADD_EXP(対象, "知略経験値", RAND:8 + 6, 1)
	MONEY += 5000
	RETURN 1
ENDIF

PRINTFORML 負けてしまった
PRINTFORMW 野良妖怪に負けて自信を失った…
CALL ADD_COOLTIME(対象:0, 2)
RETURN 1
```
