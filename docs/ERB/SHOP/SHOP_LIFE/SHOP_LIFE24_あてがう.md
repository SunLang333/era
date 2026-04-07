# SHOP/SHOP_LIFE/SHOP_LIFE24_あてがう.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE24_あてがう.ERB`

类型: .ERB

自动摘要: functions: SHOP_LIFE_NAME24, SHOP_LIFE_CHECK24, SHOP_LIFE_CHECKCHARA24, SHOP_LIFE_CHECKCHARA_SUB24, SHOP_LIFE_EVENTBUY24, SHOP_LIFE_LIST1_BUTTON24, SHOP_LIFE_LIST2_BUTTON24, SHOP_LIFE_BUTTON_ADD_TOP24, SHOP_LIFE_BUTTON_ADD_BOTTOM24, SHOP_LIFE_EVENTBUY_SHOW24, SHOP_LIFE_EVENTBUY_SUB24, SHOP_LIFE_USERSHOP24, SHOP_LIFE_USERSHOP_SUB24, DECIDE_ATEGAU_MEMBER; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「あてがう」の名称
;-------------------------------------------------
@SHOP_LIFE_NAME24
RESULTS:0 '= "あてがう"

;-------------------------------------------------
;「あてがう」の選択可否
;-------------------------------------------------
@SHOP_LIFE_CHECK24
SIF CFLAG:MASTER:捕虜先
	RETURN 0
SIF !CFLAG:MASTER:所属
	RETURN 0
RETURN 1

;-------------------------------------------------
;「あてがう」でヤられる側の選択可能キャラ存在判定
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA24(ARG:0)
;主人公はダメ
SIF ARG:0 == MASTER
	RETURN 0
;閨に呼ぶの選択可能キャラ存在判定
CALL SHOP_LIFE_CHECKCHARA_NEYA(ARG:0)
SIF RESULT && CFLAG:(ARG:0):慰安参加者
	RETURN 2
RETURN CHECK91(ARG:0, 2, RESULT)

;-------------------------------------------------
;「あてがう」であてがう先になる可否判定
;　無限ループ回避のため性知識が必要
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA_SUB24(ARG:0)
SIF CFLAG:(ARG:0):閨に呼ぶで選択中 && !CFLAG:(ARG:0):慰安参加者
	RETURN 2

LOCAL:0 = TMP_COUNTRY_RELATION:(CFLAG:MASTER:所属):(CFLAG:(ARG:0):所属)
;捕虜でない、非主人公、同一勢力or共闘勢力、性知識1以上
RETURN CHECK91(ARG:0, 2, ARG:0 != MASTER && !CFLAG:(ARG:0):捕虜先 && LOCAL:0 >= 2 && ABL:(ARG:0):性知識 > 0 && CFLAG:(ARG:0):行動不能状態 != 行動不能_臨月)
RETURN 0

;-------------------------------------------------
;「あてがう」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY24
FLAG:拠点フェイズページ = 1
FLAG:夜這い = 0
RETURN 0

;-------------------------------------------------
;「あてがう」の右カラムキャラリスト１のボタン（関数未指定なら選択中色なし表示）
;-------------------------------------------------
@SHOP_LIFE_LIST1_BUTTON24(ARG:0, ARG:1)
;キャラ, 選択中カラー表示フラグ, ボタン番号に追加する数値, CHECKCHARAの戻り値
CALL COLUMN_RIGHT_CHARALIST_BUTTON(ARG:0, CFLAG:(ARG:0):閨に呼ぶで選択中, SHOP_LIFE_LIST1_ADD_INPUT, ARG:1, 0, "TOP")
RETURN 0

;-------------------------------------------------
;「あてがう」の右カラムキャラリスト２のボタン（関数未指定なら選択中色なし表示）
;-------------------------------------------------
@SHOP_LIFE_LIST2_BUTTON24(ARG:0, ARG:1)
;キャラ, 選択中カラー表示フラグ, ボタン番号に追加する数値, CHECKCHARAの戻り値
CALL COLUMN_RIGHT_CHARALIST_BUTTON(ARG:0, CFLAG:(ARG:0):慰安参加者, SHOP_LIFE_LIST2_ADD_INPUT, ARG:1, 0, "BUTTOM")
RETURN 0

;-------------------------------------------------
;「あてがう」の右カラムキャラリストボタン（上）表示に追尾させる情報
;　デフォルトの情報を表示しない場合はRETURN 1
;-------------------------------------------------
@SHOP_LIFE_BUTTON_ADD_TOP24(ARG:0)
CALL SHOP_LIFE_BUTTON_ADD_BOTTOM_PRISONER(ARG:0)
RETURN RESULT

;-------------------------------------------------
;「あてがう」の右カラムキャラリストボタン（上）表示に追尾させる情報
;　デフォルトの情報を表示しない場合はRETURN 1
;-------------------------------------------------
@SHOP_LIFE_BUTTON_ADD_BOTTOM24(ARG:0)
CALL SHOP_LIFE_BUTTON_ADD_TOP_PRISONER(ARG:0)
RETURN RESULT


;-------------------------------------------------
;「あてがう」の右カラム表示処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SHOW24
#DIM 選択人数
#DIM あてがう先
#DIM あてがわれる側
#DIM 最大人数

最大人数 = MIN(CALC_SHOP_TIME() - SHOP_TIME, 8)
選択人数 = 0
あてがう先 = 0
あてがわれる側 = 0

FOR LOCAL:0, 0, CHARANUM
	;選択可能な条件を満たしているかどうか判定
	RESULT = 0
	IF CFLAG:(LOCAL:0):慰安参加者
		選択人数 ++
		あてがう先 ++
	ENDIF
	TRYCALLFORM SHOP_LIFE_CHECKCHARA{FLAG:拠点フェイズ選択コマンド}(LOCAL:0)
	IF RESULT == 1
		;選択中の人数を数える
		IF CFLAG:(LOCAL:0):閨に呼ぶで選択中
			選択人数 ++
			あてがわれる側 ++
			IF 選択人数 > 最大人数
				CFLAG:(LOCAL:0):閨に呼ぶで選択中 = 0
			ENDIF
		ENDIF
	ELSE
		;条件を満たしていなければ強制的にＯＦＦ
		CFLAG:(LOCAL:0):閨に呼ぶで選択中 = 0
	ENDIF
NEXT

CALL COLUMN_RIGHT_TITLE("対象者選択", TOSTR(選択人数), TOSTR(最大人数), "人数", "避妊時のみ3,000")
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

IF あてがう先 > 0 && あてがわれる側 > 0
	PRINTBUTTON "[このメンバーで決定]", 1
ELSE
	SETCOLOR カラー_選択不可
	PRINTPLAINFORM [このメンバーで決定]
	RESETCOLOR
ENDIF

PRINTPLAIN   
IF FLAG:慰安避妊薬
	PRINTBUTTON "[避妊あり]", 2
ELSE
	IF MONEY > 選択人数 * 3000
		PRINTBUTTON "[避妊なし]", 2
	ELSE
		SETCOLOR カラー_選択不可
		PRINTPLAINFORM [避妊なし]
		RESETCOLOR
	ENDIF
ENDIF

PRINTPLAIN   
CALL COLOR_PRINT("贈り物↑と贈る相手↓の計2名選択が必要です", カラー_注釈)
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

;２段組キャラリスト上とページ移動
CALL COLUMN_RIGHT_CHARALIST_TOP(1)
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

PRINTFORM あてがう先（する側）のキャラを選択してください
PRINTPLAIN   
SIF 選択人数 >= 最大人数
	SETCOLOR カラー_オレンジ
PRINTFORM (現在{選択人数}/{最大人数}人)
RESETCOLOR
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL

;２段組キャラリスト下とページ移動
CALL COLUMN_RIGHT_CHARALIST_BOTTOM(1)

RETURN 0

;-------------------------------------------------
;「あてがう」の右カラムボタン入力処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SUB24(ARG:0)
;このメンバーで決定
IF ARG:0 == 1
	CALL DECIDE_ATEGAU_MEMBER()
	SIF !RESULT
		RETURN 0
;避妊ありなし
ELSEIF ARG:0 == 2
	LOCAL:1 = 0
	FOR LOCAL, 0, CHARANUM
		SIF CFLAG:LOCAL:閨に呼ぶで選択中
			LOCAL:1 ++
	NEXT
	SIF FLAG:慰安避妊薬 || MONEY >= LOCAL:1 * 3000
		FLAG:慰安避妊薬 = !FLAG:慰安避妊薬
	RETURN 0
ENDIF
RETURN 0

;-------------------------------------------------
;「あてがう」のリスト１入力処理
;-------------------------------------------------
@SHOP_LIFE_USERSHOP24(ARG:0)
;参加キャラの数を数える
```
