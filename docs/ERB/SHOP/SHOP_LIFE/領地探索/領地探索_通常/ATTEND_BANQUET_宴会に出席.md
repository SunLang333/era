# SHOP/SHOP_LIFE/領地探索/領地探索_通常/ATTEND_BANQUET_宴会に出席.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/ATTEND_BANQUET_宴会に出席.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_ATTEND_BANQUET_EXISTS, TERRITORY_EVENT_ATTEND_BANQUET_DECISION, TERRITORY_EVENT_ATTEND_BANQUET; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_ATTEND_BANQUET_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_ATTEND_BANQUET_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_ATTEND_BANQUET(対象)
#DIM 対象
PRINTFORML 宴会に遭遇した
PRINTFORML 人間と妖怪が混ざって盛り上がっている
PRINTFORML ……酔っ払いの一人が手招きしてきた
PRINTL
CALL PRINT_ABILITY(対象, GETNUM(ABL, "肝臓"))

CALL ASK_YN("参加する" ,"その場を後にする")
IF RESULT == 1
	PRINTFORML そんな気分じゃない
	PRINTFORML %ANAME(対象)%はその場を後にした
	RETURN 1
ENDIF
PRINTFORML 折角なので参加することにした
PRINTFORMW 彼らは%ANAME(対象)%を歓迎し、さっそく酒を勧めてきた
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
IF ABL:対象:肝臓 >= 3 + RAND:4
	PRINTFORML %ANAME(対象)%の呑みっぷりに喝采が起こった
	PRINTFORMW 楽しい宴は夜通し続いた
ELSE
	PRINTFORML %ANAME(対象)%は酔い潰れてしまった
	PRINTFORMW ガンガン響く頭を抱えながら帰路についた
	CALL ADD_COOLTIME(対象, 1)
ENDIF
CALL PRINT_ADD_EXP(対象, "肝臓経験値", RAND(50, 100), 1)

RETURN 1
```
