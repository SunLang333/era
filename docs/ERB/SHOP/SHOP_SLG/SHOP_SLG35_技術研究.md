# SHOP/SHOP_SLG/SHOP_SLG35_技術研究.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_SLG/SHOP_SLG35_技術研究.ERB`

类型: .ERB

自动摘要: functions: SHOP_SLG_NAME35, SHOP_SLG_CHECK35, SHOP_SLG_EVENTBUY35, SHOW_TECHNOLOGY_RESEARCH, SHOW_TECHNOLOGY_TREE, GET_RESEARCH_PERIOD, GET_TECHNOLOGY_NAME, GET_TECHNOLOGY_DESCRIPTION, IS_TECHNOLOGY_EXISTS, IS_TECHNOLOGY_RESEARCHABLE, INIT_TECHNOLOGY; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「国家方針・研究」の名称
;-------------------------------------------------
@SHOP_SLG_NAME35
RESULTS:0 '= "技術研究"

;-------------------------------------------------
;「国家方針・研究」の選択可否
;-------------------------------------------------
@SHOP_SLG_CHECK35
SIF FLAG:クリアフラグ
	RETURN 0
SIF FLAG:観戦モード
	RETURN 0
SIF !IS_COUNTRY(CFLAG:MASTER:所属)
	RETURN 0
SIF CONFIG:302
	RETURN 0
RETURN 1

;-------------------------------------------------
;「国家方針・研究」の右カラムオン判定
;-------------------------------------------------
;@SHOP_SLG_EVENTBUY_COLUMN_RIGHT_ON_CHECK35

;-------------------------------------------------
;「国家方針・研究」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_SLG_EVENTBUY35
CALL SHOW_TECHNOLOGY_RESEARCH
RETURN 1

;-------------------------------------------------
;「勢力方針・研究」の表示処理本体
;-------------------------------------------------
@SHOW_TECHNOLOGY_RESEARCH(勢力)
#DIM 勢力
#DIM 勢力方針
#DIM 君主
#DIM 研究予定
#DIMS 技術名
#DIMS 説明
#DIM ジャンル
#DIM ステージ
#DIM 表示中研究番号
#DIM FIRST_LINE

FIRST_LINE = LINECOUNT

;ショップから飛んできた場合は引数勢力が0
SIF !IS_COUNTRY(勢力)
	勢力 = CFLAG:MASTER:所属

;UI部分
CALL SINGLE_DRAWLINE
君主 = GET_COUNTRY_BOSS(勢力)

ジャンル = TECHNOLOGY_RESEARCH_TARGET:勢力 / 100
ステージ = TECHNOLOGY_RESEARCH_TARGET:勢力 % 100

PRINTFORML 君主：%ANAME(君主), MAX_CHARANAME_LENGTH, LEFT% 勢力方針：%TOSTR_AI_TYPE(COUNTRY_AI_TYPE:勢力)%

IF IS_TECHNOLOGY_EXISTS(ジャンル, ステージ)
	技術名 = %GET_TECHNOLOGY_NAME(ジャンル, ステージ)%
	PRINTFORM 現在進行中の研究(進捗/総期間)：
	SETCOLOR カラー_選択中
	PRINTFORM %技術名%
	RESETCOLOR
	PRINTFORML ({TECHNOLOGY_RESEARCH_PROGRESS:勢力}/{GET_RESEARCH_PERIOD(勢力, ジャンル, ステージ)}期)
ELSE 
	PRINTL
ENDIF
CALL SINGLE_DRAWLINE
CALL SHOW_TECHNOLOGY_TREE(勢力)
CALL SINGLE_DRAWLINE

ジャンル = 表示中研究番号 / 100
ステージ = 表示中研究番号 % 100

IF !IS_TECHNOLOGY_EXISTS(ジャンル, ステージ)
	PRINTL
	PRINTL
	PRINTL
	PRINTL
ELSE
	技術名 = %GET_TECHNOLOGY_NAME(ジャンル, ステージ)%
	説明 = %GET_TECHNOLOGY_DESCRIPTION(ジャンル, ステージ)%
	PRINTFORML %技術名%
	PRINTFORML 効果：%説明%
	PRINTFORML 完了まで{GET_RESEARCH_PERIOD(勢力, ジャンル, ステージ)}期
	IF 勢力 == CFLAG:MASTER:所属 && IS_TECHNOLOGY_RESEARCHABLE(勢力, ジャンル, ステージ) && 表示中研究番号 != TECHNOLOGY_RESEARCH_TARGET:勢力
		PRINTBUTTON "[研究開始]", 1001
		PRINTL
	ELSE
		PRINTL
	ENDIF
ENDIF
CALL SINGLE_DRAWLINE

PRINTBUTTON "[戻る]", 1000

$TECHNOLOGY_RESEARCH_START
INPUT

IF RESULT == 1000
	RETURN
ELSEIF RESULT == 1001 && 勢力 == CFLAG:MASTER:所属 && IS_TECHNOLOGY_RESEARCHABLE(勢力, ジャンル, ステージ)
	PRINTFORML 完了まで{GET_RESEARCH_PERIOD(勢力, ジャンル, ステージ)}期
	PRINTL 
	PRINTFORML 研究を開始しますか？（現在研究中の進捗状況はリセットされます）
	CALL ASK_YN()
	IF RESULT == 0 && TECHNOLOGY_RESEARCH_TARGET:勢力 != 表示中研究番号
		TECHNOLOGY_RESEARCH_TARGET:勢力 = 表示中研究番号
		TECHNOLOGY_RESEARCH_PROGRESS:勢力 = 0
		PRINTFORMW 研究を開始しました
	ENDIF
ELSE
	ジャンル = RESULT / 100
	ステージ = RESULT % 100
	SIF IS_TECHNOLOGY_EXISTS(ジャンル, ステージ)
		表示中研究番号 = RESULT
ENDIF
CLEARLINE LINECOUNT - FIRST_LINE
RESTART

;------------------
; 技術ツリーの表示
;------------------
@SHOW_TECHNOLOGY_TREE(勢力)
#DIM 勢力
#DIM 技術進捗
#DIMS 技術名
#DIMS CONST 技術ジャンル = "戦闘", "防衛", "外交", "徴兵", "徴税", "雇用"
#DIM ジャンル
#DIM ステージ

FOR ジャンル, 0, TECHNOLOGY_MAX_GENRE
	CALL PRINTBUTTON_CENTER(@"%技術ジャンル:ジャンル%", 0, 9, 0)
NEXT
PRINTL

FOR ステージ, 1, TECHNOLOGY_MAX_STAGE
	FOR ジャンル, 0, TECHNOLOGY_MAX_GENRE
		IF !IS_TECHNOLOGY_EXISTS(ジャンル, ステージ)
			PRINTFORM %TOSTR_SPACE(18)%
			CONTINUE
		ENDIF
		技術進捗 = TECHNOLOGY_STATUS:勢力:ジャンル
		技術名 = %GET_TECHNOLOGY_NAME(ジャンル, ステージ)%
		IF 技術進捗 >= ステージ
			SETCOLOR カラー_緑
		ELSEIF (ジャンル * 100 + ステージ) == TECHNOLOGY_RESEARCH_TARGET:勢力
			SETCOLOR カラー_選択中
		ELSE
			SETCOLOR GETDEFCOLOR()
		ENDIF
		CALL PRINTBUTTON_CENTER(@"[%技術名%]", ジャンル * 100 + ステージ, 9)
	NEXT
	PRINTL

	FOR ジャンル, 0, TECHNOLOGY_MAX_GENRE
		IF !IS_TECHNOLOGY_EXISTS(ジャンル, ステージ + 1)
			PRINTFORM %TOSTR_SPACE(18)%
			CONTINUE
		ENDIF
		技術進捗 = TECHNOLOGY_STATUS:勢力:ジャンル
		IF 技術進捗 >= ステージ + 1
			SETCOLOR カラー_緑
		ELSEIF (ジャンル * 100 + ステージ + 1) == TECHNOLOGY_RESEARCH_TARGET:勢力
			SETCOLOR カラー_選択中
		ELSE
			SETCOLOR カラー_選択不可
		ENDIF
		PRINTFORM %TOSTR_SPACE(8)%↓%TOSTR_SPACE(8)%
		RESETCOLOR
	NEXT
	PRINTL
NEXT
RESETCOLOR

;------------------
; 研究期間
;------------------
@GET_RESEARCH_PERIOD(勢力, ジャンル, ステージ)
#FUNCTION
#DIM 勢力
#DIM ジャンル
#DIM ステージ
#DIM ウェイト
#DIM CONST 基礎研究期間 = 10
#DIM 研究機関

SIF !IS_COUNTRY(勢力)
	RETURNF 0

研究機関 = GET_DEVELOPMENT_COUNT(建造物_研究所, 勢力) > 0 ? 1 # 0
IF GET_DEVELOPMENT_COUNT(建造物_忍びの里, 勢力)
	FOR LOCAL, 0, MAX_COUNTRY
		SIF !IS_COUNTRY(LOCAL)
			CONTINUE
```
