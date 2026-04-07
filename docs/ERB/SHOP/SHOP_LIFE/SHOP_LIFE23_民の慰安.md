# SHOP/SHOP_LIFE/SHOP_LIFE23_民の慰安.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE23_民の慰安.ERB`

类型: .ERB

自动摘要: functions: SHOP_LIFE_NAME23, SHOP_LIFE_CHECK23, SHOP_LIFE_CHECKCHARA23, SHOP_LIFE_EVENTBUY23, SHOP_LIFE_LIST1_BUTTON23, SHOP_LIFE_BUTTON_ADD23, SHOP_LIFE_EVENTBUY_SHOW23, SHOP_LIFE_EVENTBUY_SUB23, SHOP_LIFE_USERSHOP23, DECIDE_IAN_MEMBER, RESET_IAN_MEMBER, CREATE_IAN_MOB, CREATE_IAN_MOB_GET_CHARA, CREATE_IAN_MOB_GET_SEX, CREATE_IAN_MOB_GET_NAME, CREATE_IAN_MOB_SET_STATUS, SHOW_IAN_MESSAGE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「民の慰安」の名称
;-------------------------------------------------
@SHOP_LIFE_NAME23
IF CFLAG:MASTER:所属
	RESULTS:0 '= "民の慰安"
ELSE
	RESULTS:0 '= "春を売る"
ENDIF

;-------------------------------------------------
;「民の慰安」の選択可否
;-------------------------------------------------
@SHOP_LIFE_CHECK23
SIF CFLAG:MASTER:捕虜先
	RETURN 0
SIF !CAN_ADD_RANDOM_CHARA()
	RETURN 0
RETURN 1

;-------------------------------------------------
;「民の慰安」の選択可能キャラ存在判定（ヤられる側）
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA23(ARG:0)
;主人公
IF ARG:0 == MASTER
	SIF COOLTIME:MASTER:0 < 2 && CFLAG:(ARG:0):行動不能状態 != 行動不能_臨月
		RETURN CHECK91(ARG:0, 2, 1)
;主人公でない
ELSE
	;閨に呼ぶの選択可能キャラ存在判定
	CALL SHOP_LIFE_CHECKCHARA_NEYA(ARG:0)
	RETURN CHECK91(ARG:0, 2, RESULT && !IS_ANIMAL(ARG:0) && CFLAG:(ARG:0):所属 && CFLAG:(ARG:0):所属 == CFLAG:MASTER:所属)
ENDIF
RETURN 0

;-------------------------------------------------
;「民の慰安」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY23
FLAG:拠点フェイズページ = 1
FLAG:夜這い = 0
RETURN 0

;-------------------------------------------------
;「民の慰安」の右カラムキャラリスト１のボタン（関数未指定なら選択中色なし表示）
;-------------------------------------------------
@SHOP_LIFE_LIST1_BUTTON23(ARG:0, ARG:1)
;キャラ, 選択中カラー表示フラグ, ボタン番号に追加する数値, CHECKCHARAの戻り値, 行動済みマークをオフにするフラグ
CALL COLUMN_RIGHT_CHARALIST_BUTTON(ARG:0, CFLAG:(ARG:0):閨に呼ぶで選択中, SHOP_LIFE_LIST1_ADD_INPUT, ARG:1)
RETURN 0

;-------------------------------------------------
;「民の慰安」の右カラムキャラリストボタン（上）表示に追尾させる情報
;　デフォルトの情報を表示しない場合はRETURN 1
;-------------------------------------------------
@SHOP_LIFE_BUTTON_ADD23(ARG:0)
CALL SHOP_LIFE_BUTTON_ADD_BOTTOM_PRISONER(ARG:0)
RETURN RESULT


;-------------------------------------------------
;「民の慰安」の右カラム表示処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SHOW23
#DIM 選択人数
#DIM 最大人数
最大人数 = MIN(CALC_SHOP_TIME() - SHOP_TIME, 3)

選択人数 = 0
FOR LOCAL:0, 0, CHARANUM
	;選択可能な条件を満たしているかどうか判定
	RESULT = 0
	TRYCALLFORM SHOP_LIFE_CHECKCHARA{FLAG:拠点フェイズ選択コマンド}(LOCAL:0)
	IF RESULT == 1
		;選択中の人数を数える
		IF CFLAG:(LOCAL:0):閨に呼ぶで選択中
			選択人数 ++
			SIF 選択人数 > 最大人数
				CFLAG:(LOCAL:0):閨に呼ぶで選択中 = 0
		ENDIF
	ELSE
		;条件を満たしていなければ強制的にＯＦＦ
		CFLAG:(LOCAL:0):閨に呼ぶで選択中 = 0
	ENDIF
NEXT

SIF 選択人数 * 2000 > MONEY
	FLAG:慰安避妊薬 = 0

;右カラムタイトル表示
CALL COLUMN_RIGHT_TITLE("実行者選択", TOSTR(選択人数), TOSTR(最大人数), "人数", "避妊時のみ2,000×人数")
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL
IF 選択人数 >= 1
	PRINTBUTTON "[このメンバーで決定]", 1
	PRINTPLAIN   
	PRINTBUTTON "[リセット]", 2
ELSE
	SETCOLOR カラー_選択不可
	PRINTPLAINFORM [このメンバーで決定]
	PRINTPLAIN   
	PRINTPLAINFORM [リセット]
	RESETCOLOR
ENDIF

PRINTPLAIN   
IF FLAG:慰安避妊薬
	PRINTBUTTON "[避妊あり]", 3
ELSE
	IF MONEY > 選択人数 * 2000
		PRINTBUTTON "[避妊なし]", 3
	ELSE
		SETCOLOR カラー_選択不可
		PRINTPLAINFORM [避妊なし]
		RESETCOLOR
	ENDIF
ENDIF
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

;標準的なキャラリストとページ移動
CALL COLUMN_RIGHT_CHARALIST(1)

RETURN 0

;-------------------------------------------------
;「民の慰安」の右カラムボタンの入力処理補佐
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SUB23(ARG:0)
;このメンバーで決定
IF ARG:0 == 1
	CALL DECIDE_IAN_MEMBER()
	SIF !RESULT
		RETURN 0
;メンバーをリセット
ELSEIF ARG:0 == 2
	CALL RESET_IAN_MEMBER
;避妊ありなし
ELSEIF ARG:0 == 3
	LOCAL:1 = 0
	FOR LOCAL, 0, CHARANUM
		SIF CFLAG:LOCAL:閨に呼ぶで選択中
			LOCAL:1 ++
	NEXT
	SIF FLAG:慰安避妊薬 || MONEY >= LOCAL:1 * 2000
		FLAG:慰安避妊薬 = !FLAG:慰安避妊薬
	RETURN 0
ENDIF
RETURN 1

;-------------------------------------------------
;「民の慰安」のリスト１入力処理
;-------------------------------------------------
@SHOP_LIFE_USERSHOP23(ARG:0)
;参加キャラの数を数える
LOCAL:5 = 0
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):閨に呼ぶで選択中
		LOCAL:5 ++
	ENDIF
NEXT
IF CFLAG:(ARG:0):閨に呼ぶで選択中 || LOCAL:5 < MIN(CALC_SHOP_TIME() - SHOP_TIME, 3)
	;調教参加フラグを反転
	CFLAG:(ARG:0):閨に呼ぶで選択中 = !CFLAG:(ARG:0):閨に呼ぶで選択中
	LOCAL:5 += CFLAG:(ARG:0):閨に呼ぶで選択中 == 0 ? -1 # 1
	SIF FLAG:慰安避妊薬 && LOCAL:5 * 2000 > MONEY
		FLAG:慰安避妊薬 = 0
ENDIF
RETURN 0

;-------------------------------------------------
;「民の慰安」の右カラムボタンの入力処理補佐本体
;-------------------------------------------------
@DECIDE_IAN_MEMBER()
#DIM 行き先
#DIM 人数
#DIM メイン
#DIM 放浪リスト, MAX_CHARA_NUM
#DIM 放浪者数
#DIM FIRST_LINE
FIRST_LINE = LINECOUNT

人数 = 0
FOR LOCAL, 0, CHARANUM
	SIF CFLAG:(LOCAL:0):閨に呼ぶで選択中
		人数 ++
NEXT

IF 人数 == 0
	CLEARLINE LINECOUNT - FIRST_LINE
	RETURN 0
ENDIF

;放浪者のリスト生成
VARSET 放浪リスト
VARSET 放浪者数
FOR LOCAL, 0, CHARANUM
```
