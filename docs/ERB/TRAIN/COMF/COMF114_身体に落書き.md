# TRAIN/COMF/COMF114_身体に落書き.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF114_身体に落書き.ERB`

类型: .ERB

自动摘要: functions: COM_NAME114, COM_ABLE114, COM114, COM_IS_EQUIP114, COM_EQUIP114, EQUIP_MESSAGE114, COM_TEXT_BEFORE_EQUIP114, COM_TEXT_RELEASE_EQUIP114, COM_ORDER_PLAYER114, COM_TEXT_BEFORE114, COM_AVAILABLE_WHEN114, COM_PREFERENCE_PLAYER_114, COM_PREFERENCE_TARGET_114; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;露出プレイ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME114
LOCALS:0 = 身体に落書き
RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE114
;共通部分
CALL COM_ABLE_COMMON(114)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人
SIF MPLY_NUM != 1
	RETURN 0

;ターゲット1人以上
SIF MTAR_NUM <= 0
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0) && !FLAG:RECHECKING
	RETURN 0

SIF ITEM:マジック == 0 && ITEM:A_マジック == 0
	RETURN 0
FOR LOCAL:0, 0, MTAR_NUM
	;ターゲットが既に落書き済みなら不可
	SIF IS_EQUIP_TARGET(MTAR:0, 114)
		RETURN 0
	SIF !CAN_REACH_BODY(MPLY:0, MTAR:0) && !FLAG:RECHECKING
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM114
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 30

	SOURCE:(LOCAL:2):嗜虐 = 30
	SOURCE:(LOCAL:2):露出 = 20
	SOURCE:(LOCAL:2):逸脱 = 20
	SOURCE:(LOCAL:2):不安 = 30

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 100)
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 40

	SOURCE:(LOCAL:2):逸脱 = 80
	SOURCE:(LOCAL:2):露出 = 1000
	SOURCE:(LOCAL:2):不安 = 30

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 140, 80)
NEXT

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 2

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1


;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP114
;継続コマンドかつフィルタリング不可
RETURN 2
;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP114(ARG:0)
;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):嗜虐 = 10
	SOURCE:(LOCAL:2):露出 = 300
	SOURCE:(LOCAL:2):逸脱 = 10
	SOURCE:(LOCAL:2):不安 = 15

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 10, 50)

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 2
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 30

	SOURCE:(LOCAL:2):逸脱 = 10
	SOURCE:(LOCAL:2):露出 = 600
	SOURCE:(LOCAL:2):不安 = 10
	
	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 80, 20)

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 2
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE114(ARG:0)
LOCALS:0 = %EQUIP_TARGET_ANAME(ARG:0)%
RESULTS = %LOCALS:0%の身体に卑猥な落書きがされている

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP114(ARG:0)
	LOCALS:0 = %EQUIP_TARGET_ANAME(ARG:0)%
PRINTFORML %LOCALS:0%の肌に描かれた卑猥な落書きが目をひく……

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP114(ARG:0)
	LOCALS:0 = %EQUIP_TARGET_ANAME(ARG:0)%

PRINTFORMW %LOCALS:0%の落書きをよく拭き取ってやった

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER114(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 105

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド)
	CALL COM_ORDER_ELEMENT(ARG:0, "サド", 10)
ENDIF
IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -5)
ENDIF
IF TALENT:(ARG:0):恥薄い
	CALL COM_ORDER_ELEMENT(ARG:0, "恥薄い", 5)
ENDIF

RETURN 1

;-------------------------------------------------
;地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE114

LOCALS:0 = %ANAME(MPLY:0)%
;ターゲットが２人以上
IF MTAR_NUM >= 2
	LOCALS:1 = %ANAME(MTAR:0)%たち
;ターゲットが１人
ELSE
```
