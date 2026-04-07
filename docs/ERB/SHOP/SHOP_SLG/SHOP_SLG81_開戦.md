# SHOP/SHOP_SLG/SHOP_SLG81_開戦.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_SLG/SHOP_SLG81_開戦.ERB`

类型: .ERB

自动摘要: functions: SHOP_SLG_NAME81, SHOP_SLG_CHECK81, SHOP_SLG_EVENTBUY81; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「開戦」の名称
;-------------------------------------------------
@SHOP_SLG_NAME81
IF DAY >= SLG_PP:1
	RESULTS:0 '= "開戦"
ELSE
	RESULTS:0 '= "次期へ"
ENDIF

;-------------------------------------------------
;「開戦」の選択可否
;-------------------------------------------------
@SHOP_SLG_CHECK81
;SIF FLAG:観戦モード && FLAG:クリアフラグ
;	RETURN 0
;SIF CFLAG:MASTER:所属 == 0 && FLAG:クリアフラグ
;	RETURN 0
RETURN 1

;-------------------------------------------------
;「開戦」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_SLG_EVENTBUY81
RESULT = 1

IF IS_COUNTRY(CFLAG:MASTER:所属) && TECHNOLOGY_RESEARCH_TARGET:(CFLAG:MASTER:所属) == -1 && CONFIG:302 == 0
	PRINTFORML 技術研究対象を指定していませんが、
	PRINTFORML よろしいですか？
	CALL ASK_YN()
	SIF RESULT == 1
		RETURN
ENDIF

BEGIN TURNEND

```
