# SHOP/SHOP_LIFE/SHOP_LIFE31_捕虜の調教.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE31_捕虜の調教.ERB`

类型: .ERB

自动摘要: functions: SHOP_LIFE_NAME31, SHOP_LIFE_CHECK31, SHOP_LIFE_CHECKCHARA31, SHOP_LIFE_CHECK_ADDITIONAL_CHECK31, SHOP_LIFE_CHECKCHARA_SUB31, SHOP_LIFE_EVENTBUY31, SHOP_LIFE_LIST1_BUTTON31, SHOP_LIFE_LIST2_BUTTON31, SHOP_LIFE_BUTTON_ADD_TOP31, SHOP_LIFE_BUTTON_ADD_BOTTOM31, SHOP_LIFE_EVENTBUY_SHOW31, SHOP_LIFE_EVENTBUY_SUB31, SHOP_LIFE_USERSHOP31, SHOP_LIFE_USERSHOP_SUB31, DECIDE_PRISONER_MEMBER, PRISONER_BULK_MANAGEMENT, SELECT_CHARA_LIST_SHOW_LOGIC_PRISONER_MANAGE_PURGE, SELECT_CHARA_LIST_SHOW_LOGIC_PRISONER_MANAGE_BANISH, SELECT_CHARA_LIST_SHOW_LOGIC_PRISONER_MANAGE_NANKIN, SELECT_CHARA_LIST_SHOW_LOGIC_PRISONER_MANAGE_EXECUTE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜の調教」の名称
;-------------------------------------------------
@SHOP_LIFE_NAME31
RESULTS:0 '= "捕虜の調教"

;-------------------------------------------------
;「捕虜の調教」の選択可否判定
;-------------------------------------------------
@SHOP_LIFE_CHECK31
SIF CFLAG:MASTER:行動不能状態 == 行動不能_臨月 || COOLTIME:MASTER:0 > 1
	RETURN 0
SIF CFLAG:MASTER:捕虜先
	RETURN 0
SIF !CFLAG:MASTER:所属
	RETURN 0
RETURN 1

;-------------------------------------------------
;「捕虜の調教」の選択可能キャラ存在判定
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA31(ARG:0)
;非主人公、主人公勢力の捕虜、牢獄で監禁中
RETURN CHECK91(ARG:0, 2, (ARG:0 != MASTER && CFLAG:(ARG:0):捕虜先 == CFLAG:MASTER:所属 && CFLAG:(ARG:0):軟禁中 == 0) || CFLAG:(ARG:0):外交調教中)

;-------------------------------------------------
;「捕虜の調教」の追加チェック
;-------------------------------------------------
@SHOP_LIFE_CHECK_ADDITIONAL_CHECK31()
FOR LOCAL, 0, CHARANUM
	SIF CFLAG:LOCAL:捕虜先 == CFLAG:MASTER:所属 && CFLAG:LOCAL:軟禁中 != 1
		RETURN 1
NEXT


;-------------------------------------------------
;「捕虜の調教」の助手の選択可能キャラ存在判定
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA_SUB31(ARG:0)
;閨に呼ぶの選択可能キャラ存在判定
CALL SHOP_LIFE_CHECKCHARA_NEYA(ARG:0)
RETURN CHECK91(ARG:0, 2, RESULT && SHOP_LIFE_CHECKCHARA_ZYOSYU(ARG:0) && CFLAG:(ARG:0):所属 == CFLAG:MASTER:所属)
RETURN 0

;-------------------------------------------------
;「捕虜の調教」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY31
FLAG:拠点フェイズページ = 1
FLAG:夜這い = 0
RETURN 0

;-------------------------------------------------
;「捕虜の調教」の右カラムキャラリスト１のボタン（関数未指定なら選択中色なし表示）
;-------------------------------------------------
@SHOP_LIFE_LIST1_BUTTON31(ARG:0, ARG:1)
;キャラ, 選択中カラー表示フラグ, ボタン番号に追加する数値, CHECKCHARAの戻り値
CALL COLUMN_RIGHT_CHARALIST_BUTTON(ARG:0, FINDELEMENT(PRISONER_TARGET, ARG:0) != -1, SHOP_LIFE_LIST1_ADD_INPUT, ARG:1, 0, "TOP")
RETURN

;-------------------------------------------------
;「捕虜の調教」の右カラムキャラリスト２のボタン（関数未指定なら選択中色なし表示）
;-------------------------------------------------
@SHOP_LIFE_LIST2_BUTTON31(ARG:0, ARG:1)
;キャラ, 選択中カラー表示フラグ, ボタン番号に追加する数値, CHECKCHARAの戻り値
CALL COLUMN_RIGHT_CHARALIST_BUTTON(ARG:0, CFLAG:(ARG:0):捕虜調教の助手, SHOP_LIFE_LIST2_ADD_INPUT, ARG:1, 0, "BOTTOM")
RETURN 0

;-------------------------------------------------
;「捕虜の調教」の右カラムキャラリストボタン（上）表示に追尾させる情報
;　デフォルトの情報を表示しない場合はRETURN 1
;-------------------------------------------------
@SHOP_LIFE_BUTTON_ADD_TOP31(ARG:0)
CALL SHOP_LIFE_BUTTON_ADD_TOP_PRISONER(ARG:0)
RETURN RESULT

;-------------------------------------------------
;「捕虜の調教」の右カラムキャラリストボタン（上）表示に追尾させる情報
;　デフォルトの情報を表示しない場合はRETURN 1
;-------------------------------------------------
@SHOP_LIFE_BUTTON_ADD_BOTTOM31(ARG:0)
CALL SHOP_LIFE_BUTTON_ADD_BOTTOM_PRISONER(ARG:0)
RETURN RESULT

;-------------------------------------------------
;「捕虜の調教」の右カラム表示処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SHOW31
#DIM 選択人数
選択人数 = INRANGEARRAY(PRISONER_TARGET, 0, CHARANUM + 1)

CALL COLUMN_RIGHT_TITLE("対象者選択", TOSTR(選択人数), TOSTR(VARSIZE("PRISONER_TARGET")), "1", "0", "助手選択可  管理も可")
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

IF 選択人数 >= 1
	PRINTBUTTON "[このメンバーで決定]", 1
ELSE
	SETCOLOR カラー_選択不可
	PRINTPLAINFORM [このメンバーで決定]
	RESETCOLOR
ENDIF
PRINTPLAIN   
CALL COLOR_PRINT("管理(軟禁/解放/兵士の性奴隷化/処刑等)は行動消費なし", カラー_注釈)
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL
CALL COLOR_PRINT("一括管理", カラー_注釈)
PRINTPLAIN   
PRINTBUTTON "[解放]", 2
PRINTBUTTON "[追放]", 3
PRINTBUTTON "[軟禁]", 4
PRINTBUTTON "[処刑]", 5
SIF ITEM:触手部屋 && ID_TO_CHARA(FLAG:触手部屋管理者) >= 0
	PRINTBUTTON "[触手処刑]", 6

CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

;右カラムの上下２のキャラリスト上とページ移動を呼ぶ
CALL COLUMN_RIGHT_CHARALIST_TOP(1)
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

;助手を数える
LOCAL:1 = 0
FOR LOCAL:0, 0, CHARANUM
	;選択可能な条件を満たしているかどうかを判定
	TRYCALLFORM SHOP_LIFE_CHECKCHARA_SUB{FLAG:拠点フェイズ選択コマンド}(LOCAL:0)
	IF RESULT == 1
		;選択中の人数を数える
		IF CFLAG:(LOCAL:0):捕虜調教の助手
			LOCAL:1 ++
		ENDIF
	ELSE
		;条件を満たしていなければ強制的にＯＦＦ
		CFLAG:(LOCAL:0):捕虜調教の助手 = 0
	ENDIF
NEXT

PRINTFORM 助手を最大4人まで連れて行く事が可能です
SIF LOCAL:1 >= 4
	SETCOLOR カラー_オレンジ
PRINTFORM (現在{LOCAL:1}/4人)
RESETCOLOR
PRINTPLAIN   
PRINTBUTTON @"[%ZYOSYU_MODE()%]", 7
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

;右カラムの上下２のキャラリスト下とページ移動を呼ぶ
CALL COLUMN_RIGHT_CHARALIST_BOTTOM(1)
RETURN 0

;-------------------------------------------------
;「捕虜の調教」の右カラムボタンの入力処理補佐
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SUB31(ARG:0)
;このメンバーで決定
SELECTCASE ARG:0 
	CASE 1
		SELECTCASE INRANGEARRAY(PRISONER_TARGET, 0, CHARANUM + 1)
			CASE 0
				;ないと思うんだけど一応
			CASE 1
				CALL PRISONER_TRAIT(PRISONER_TARGET:0)
			CASEELSE
				CALL DECIDE_PRISONER_MEMBER()
		ENDSELECT
		IF RESULT
			RETURN 1
		ENDIF
	CASE 2, 3, 4, 5, 6
		CALL PRISONER_BULK_MANAGEMENT(ARG:0)
		RETURN RESULT
	CASE 7
		FLAG:助手フィルタ = ROUND_INCREMENT(FLAG:助手フィルタ, 0, 3)
ENDSELECT
RETURN 0

;-------------------------------------------------
;「捕虜の調教」のリスト１入力処理
;-------------------------------------------------
@SHOP_LIFE_USERSHOP31(ARG:0)
LOCAL = FINDELEMENT(PRISONER_TARGET, ARG:0)
;いたら消す
IF LOCAL != -1
	PRISONER_TARGET:LOCAL = -1
	;配列のケツ以外を消した場合は、その一個後ろからケツまでを、一個手前にずらす
	SIF LOCAL != VARSIZE("PRISONER_TARGET") -1
		ARRAYSHIFT PRISONER_TARGET, -1, -1, LOCAL, VARSIZE("PRISONER_TARGET")
;いなかったら追加する
ELSE
	FOR LOCAL, 0, VARSIZE("PRISONER_TARGET")
		IF PRISONER_TARGET:LOCAL == -1
			PRISONER_TARGET:LOCAL = ARG:0
```
