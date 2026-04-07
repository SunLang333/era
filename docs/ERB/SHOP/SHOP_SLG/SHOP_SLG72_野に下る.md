# SHOP/SHOP_SLG/SHOP_SLG72_野に下る.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_SLG/SHOP_SLG72_野に下る.ERB`

类型: .ERB

自动摘要: functions: SHOP_SLG_NAME72, SHOP_SLG_CHECK72, SHOP_SLG_EVENTBUY72, SHOP_RESIGN; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「野に下る」の名称
;-------------------------------------------------
@SHOP_SLG_NAME72
RESULTS:0 '= "野に下る"

;-------------------------------------------------
;「野に下る」の選択可否
;-------------------------------------------------
@SHOP_SLG_CHECK72
SIF CFLAG:MASTER:所属 == 0
	RETURN 0
SIF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == MASTER
	RETURN 0
SIF PLAYER_HIRED_COUNTER != 0
	RETURN 0
RETURN 1

;-------------------------------------------------
;「野に下る」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_SLG_EVENTBUY72
CALL SHOP_RESIGN
RETURN 1

;-------------------------------------------------
;「野に下る」本体
;-------------------------------------------------
@SHOP_RESIGN()
CALL SINGLE_DRAWLINE
PRINTFORML %ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%の元を去り、野に下ります
PRINTFORML 本当によろしいですか？
CALL ASK_YN()
IF RESULT == 0
	ARRAYSHIFT COUNTRY_PLAYER_BELONGED, 1, 0
	COUNTRY_PLAYER_BELONGED:0 = CFLAG:MASTER:所属
	PRINTFORMW 下野しました
	IF MATCH(COUNTRY_PLAYER_BELONGED, 0) < VARSIZE("COUNTRY_PLAYER_BELONGED") - 2
		CALL COLOR_PRINTW(@"所属を転々とする%ANAME(MASTER)%は、諸国から警戒されています", カラー_警告)
		FOR LOCAL, 0, MAX_COUNTRY
			SIF IS_COUNTRY(LOCAL)
				CALL CHANGE_RELATION_C_TO_O(LOCAL, MASTER, RAND(-100, -50), RAND(50, 100))
		NEXT
	ENDIF
	CALL CHANGE_COUNTRY(MASTER, 0, 1)
ELSE
	PRINTFORMW 思いとどまりました
ENDIF

```
