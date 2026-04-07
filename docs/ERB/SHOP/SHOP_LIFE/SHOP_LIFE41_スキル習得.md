# SHOP/SHOP_LIFE/SHOP_LIFE41_スキル習得.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE41_スキル習得.ERB`

类型: .ERB

自动摘要: functions: SHOP_LIFE_NAME41, SHOP_LIFE_CHECK41, SHOP_LIFE_CHECKCHARA41, SHOP_LIFE_EVENTBUY41, SHOP_LIFE_EVENTBUY_SHOW41, SHOP_LIFE_USERSHOP41, SHOP_LEARN_SKILL, SHOP_FORGET_SKILL, SHOP_LIFE_SKILL_PRINT_TABS, SHOP_LIFE_SKILL_PRINT_LEARN_LIST, SHOP_LIFE_SKILL_PRINT_FORGET_LIST, SHOP_LIFE_SKILL_CREATE_LIST, SHOP_LIFE_SKILL_SORT; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「スキル習得」の名称
;-------------------------------------------------
@SHOP_LIFE_NAME41
RESULTS:0 '= "スキル習得"

;-------------------------------------------------
;「スキル習得」の選択可否
;-------------------------------------------------
@SHOP_LIFE_CHECK41
SIF FLAG:クリアフラグ
	RETURN 0
SIF CFLAG:MASTER:捕虜先
	RETURN 0
RETURN 1

;-------------------------------------------------
;「スキル習得」の選択可能キャラ存在判定
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA41(ARG:0)
;捕虜でない、同一勢力、通常状態または育児中
RETURN CFLAG:MASTER:所属 && CFLAG:MASTER:所属 == CFLAG:(ARG:0):所属 && !CFLAG:(ARG:0):捕虜先

;-------------------------------------------------
;「スキル習得」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY41
FLAG:拠点フェイズページ = 1
FLAG:夜這い = 0
RETURN 0

;-------------------------------------------------
;「スキル習得」の右カラム表示処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SHOW41
CALL COLUMN_RIGHT_TITLE("習得者選択", "0", "1", "", @"%NUM_FORMAT(SKILL_LEARN_PRICE:1)%~")
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL
;標準的なキャラリストとページ移動
CALL COLUMN_RIGHT_CHARALIST
RETURN 0

;-------------------------------------------------
;「スキル習得」のリスト１入力処理
;-------------------------------------------------
@SHOP_LIFE_USERSHOP41(対象, 編集モード= 0)
#DIM 対象
#DIM FIRST_LINE
#DIM ジャンル
#DIM 編集モード
#DIM ソート順
#DIMS ソート順文字列 = "NO", "NO降順", "レベル", "レベル降順"

;あなたを選択するとここで弾かれる？
IF !編集モード
	TRYCALLFORM SHOP_LIFE_CHECKCHARA{FLAG:拠点フェイズ選択コマンド}(対象)
	SIF !RESULT
		RETURN 0
ENDIF


REDRAW 0
FIRST_LINE = LINECOUNT

CALL SHOP_LIFE_SKILL_CREATE_LIST(対象, 編集モード, ソート順)

FOR LOCAL, 0, VARSIZE("SHOP_SKILL_PAGE")
	SHOP_SKILL_PAGE:LOCAL = 1
NEXT

$SHOW_LOOP

CALL SINGLE_DRAWLINE

IF !編集モード
	CALL ICPRINT(@"金を消費し、<%ANAME(対象)%>にスキルを習得・忘却させます%TOSTR_SPACE(10)%所持金:%NUM_FORMAT(MONEY)%", "", カラー_注意)
ELSE
	CALL ICPRINT(@"<%ANAME(対象)%>にスキルを習得・忘却させます", "", カラー_注意)
ENDIF

PRINTL
CALL SINGLE_DRAWLINE
CALL SHOP_LIFE_SKILL_PRINT_TABS(ジャンル)

IF ジャンル == SKILL_GENRE_NUM
	CALL SHOP_LIFE_SKILL_PRINT_FORGET_LIST(対象, 編集モード)
ELSE
	CALL SHOP_LIFE_SKILL_PRINT_LEARN_LIST(ジャンル,対象, 編集モード)
ENDIF
CALL SINGLE_DRAWLINE
PRINTBUTTON @"[ソート:%ソート順文字列:ソート順%]", 99997
PRINTBUTTON "[習得済スキル並べ替え]", 99998
PRINTL
PRINTBUTTON "[戻る]", 99999

INPUT 99999


SELECTCASE RESULT
	CASE 0 TO 3000
		IF ジャンル != SKILL_GENRE_NUM
			CALL SHOP_LEARN_SKILL(対象, ジャンル, RESULT, 編集モード)
		ELSE
			CALL SHOP_FORGET_SKILL(対象, RESULT, 編集モード)
		ENDIF
		LOCAL = RESULT
		CALL SHOP_LIFE_SKILL_CREATE_LIST(対象, 編集モード, ソート順)
		IF LOCAL == 1 && !編集モード
			CLEARLINE LINECOUNT - FIRST_LINE
			GOTO SHOW_LOOP			
		ENDIF
	CASE 4000 TO (4000 + SKILL_GENRE_NUM)
		ジャンル = RESULT - 4000
	;タブ切り替え処理
	CASE 5000
		SHOP_SKILL_PAGE:ジャンル --
	CASE 5001
		SHOP_SKILL_PAGE:ジャンル ++
	CASE 5002
		SHOP_SKILL_PAGE:ジャンル -= 5
	CASE 5003
		SHOP_SKILL_PAGE:ジャンル += 5
	CASE 99997
		ソート順 = ROUND_INCREMENT(ソート順, 0, VARSIZE("ソート順文字列") - 1)
		CALL SHOP_LIFE_SKILL_CREATE_LIST(対象,編集モード,ソート順)
		CLEARLINE LINECOUNT - FIRST_LINE
		GOTO SHOW_LOOP
	CASE 99998
		CALL SHOP_LIFE_SWAP_SKILL(対象)
		CLEARLINE LINECOUNT - FIRST_LINE
		GOTO SHOW_LOOP
	;戻る
	CASE 99999
		RETURN 0
ENDSELECT

CLEARLINE LINECOUNT - FIRST_LINE
GOTO SHOW_LOOP

;----------------------------
;スキル習得をこころみる
;----------------------------
@SHOP_LEARN_SKILL(対象, ジャンル, 番号, 編集モード = 0)
#DIM 対象
#DIM 教師
#DIM 番号
#DIM ジャンル
#DIM スキル
#DIM スキル位置
#DIM レベル
#DIMS スキル名
#DIM 編集モード

レベル = SHOP_SKILL_LEVEL_LIST:ジャンル:番号

;資金不足ならだめ
IF SKILL_LEARN_PRICE:レベル > MONEY && !編集モード
	PRINTFORMW (資金不足です)
	RETURN
ENDIF

CALL SKILL_LEARN(対象, ジャンル, SHOP_SKILL_NO_LIST:ジャンル:番号, SHOP_SKILL_ID_LIST:ジャンル:番号)

;いっぱいならだめ
IF RESULT == 0
	PRINTFORML (このジャンルのスキルは既に覚えきっています)
	PRINTFORMW (新たなものを覚えるには、何かを忘れる必要があります)
	RETURN 
ENDIF

CALLFORM SKILL_{SHOP_SKILL_NO_LIST:ジャンル:番号}_%SKILL_GENRE_ENG:ジャンル%_{SHOP_SKILL_ID_LIST:ジャンル:番号}_NAME
スキル名 = %RESULTS%

SIF 編集モード
	RETURN 1

教師 = NO_TO_CHARA(SHOP_SKILL_NO_LIST:ジャンル:番号)

IF 教師 == -1 || 教師 == 対象 || 教師 == NAME_TO_CHARA("あなた")
	CALL COLOR_PRINTW(@"%ANAME(対象)%は『%スキル名%』を習得した！", カラー_注意)
ELSE
	CALL COLOR_PRINTW(@"%ANAME(対象)%は%ANAME(教師)%から『%スキル名%』を習得した！", カラー_注意)
ENDIF

MONEY -= SKILL_LEARN_PRICE:レベル

RETURN 1

;----------------------------
;スキル忘却をこころみる
;----------------------------
@SHOP_FORGET_SKILL(対象, 番号, 編集モード)
#DIM 対象
#DIM 番号
#DIM ジャンル
#DIM スキル
#DIM スキル位置
#DIM レベル
#DIM 編集モード
```
