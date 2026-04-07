# TRAIN/COMF/COMF320_スキンシップ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF320_スキンシップ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME320, COM_ABLE320, COM320, COM_ORDER_PLAYER320, COM_TEXT_BEFORE320, COM_TEXT_LAST320, COM_AVAILABLE_WHEN320; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;スキンシップ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME320
;温泉なら裸のスキンシップ
IF TFLAG:54 == 7
	RESULTS:0 = スキンシップをはかる(裸)
	RESULTS:1 = スキンシップをねだられる(裸)
	RESULTS:2 = スキンシップをねだる(裸)
	RESULTS:3 = スキンシップされる(裸)
ELSE
	RESULTS:0 = スキンシップをはかる
	RESULTS:1 = スキンシップをねだられる
	RESULTS:2 = スキンシップをねだる
	RESULTS:3 = スキンシップされる
ENDIF

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE320
;共通部分
CALL COM_ABLE_COMMON(320)
SIF RESULT == 0
	RETURN 0
;主人公以外が実行する場合、好感度が500以上必要
SIF MPLY:0 != MASTER && CFLAG:(MPLY:0):2 < 500
	RETURN 0
;怪我なら不可
SIF CFLAG:(MTAR:0):行動不能状態 == 3
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM320
;実行判定
CALL COM_ORDER_COMMON
IF RESULT == 0
	RETURN 0
ENDIF

IF MPLY:0 == MASTER
	;コマンドの成否をTFLAG:18にセット
	CALL JUDGE_COM_RESULT(MTAR:0, 5, 10)
	LOCAL:1 = MTAR:0
ELSE
	;コマンドの成否をTFLAG:18にセット
	CALL JUDGE_COM_RESULT(MPLY:0, 5, 10)
	LOCAL:1 = MPLY:0
ENDIF

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_N(MPLY:0, 100, 100)
CALL ADD_SOURCE_INITIATIVE_N(MTAR:0, 100, 100)

;温泉なら裸でのスキンシップ
IF TFLAG:54 == 7
	TFLAG:17 = 2

	SOURCE:(MPLY:0):接触 = 450
	SOURCE:(MTAR:0):接触 = 450
	SOURCE:(MPLY:0):露出 = 50
	SOURCE:(MTAR:0):露出 = 50

	;親密に応じた歓楽のソース追加
	SOURCE:(MPLY:0):歓楽 = -30
	SOURCE:(MTAR:0):歓楽 = -30
	CALL ADD_SOURCE_KANRAKU(MPLY:0, 150)
	CALL ADD_SOURCE_KANRAKU(MTAR:0, 150)
	SOURCE:(MPLY:0):歓楽 = MAX(SOURCE:(MPLY:0):歓楽, 0)
	SOURCE:(MTAR:0):歓楽 = MAX(SOURCE:(MTAR:0):歓楽, 0)

	;親密に応じた愛情のソース追加
	CALL ADD_SOURCE_AIZYOU(MPLY:0, 130)
	CALL ADD_SOURCE_AIZYOU(MTAR:0, 130)

	;主導権に応じたソースの追加
	CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 30, 30)
	CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 30, 30)

	;レズ・ＢＬ経験基準値
	TFLAG:51 = 2

ELSE
	;恋人or烙印で濃厚なスキンシップ
	IF TALENT:(LOCAL:1):恋人 || TALENT:(LOCAL:1):烙印
		TFLAG:17 = 1

		;レズ・ＢＬ経験基準値
		TFLAG:51 = 1
	ELSE
		TFLAG:17 = 0
	ENDIF

	SOURCE:(MPLY:0):接触 = 150
	SOURCE:(MTAR:0):接触 = 150

	;親密に応じた歓楽のソース追加
	SOURCE:(MPLY:0):歓楽 = -30
	SOURCE:(MTAR:0):歓楽 = -30
	CALL ADD_SOURCE_KANRAKU(MPLY:0, 140)
	CALL ADD_SOURCE_KANRAKU(MTAR:0, 140)
	SOURCE:(MPLY:0):歓楽 = MAX(SOURCE:(MPLY:0):歓楽, 0)
	SOURCE:(MTAR:0):歓楽 = MAX(SOURCE:(MTAR:0):歓楽, 0)

	;親密に応じた愛情のソース追加
	CALL ADD_SOURCE_AIZYOU(MPLY:0, 90)
	CALL ADD_SOURCE_AIZYOU(MTAR:0, 90)

	;主導権に応じたソースの追加
	CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 20, 20)
	CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 20, 20)
ENDIF

;失敗
IF TFLAG:18 == -1
	TIMES SOURCE:(MPLY:0):歓楽, 0.10
	TIMES SOURCE:(MPLY:0):優越, 0.50
	TIMES SOURCE:(MPLY:0):愛情, 0.50
	TIMES SOURCE:(MTAR:0):歓楽, 0.10
	TIMES SOURCE:(MTAR:0):優越, 0.50
	TIMES SOURCE:(MTAR:0):愛情, 0.50
	SOURCE:(MPLY:0):不満 += 500
	SOURCE:(MTAR:0):不満 += 500
	TFLAG:37 -= 5
;成功
ELSEIF TFLAG:18 == 0

;大成功
ELSE
	TIMES SOURCE:(MPLY:0):歓楽, 2.00
	TIMES SOURCE:(MPLY:0):優越, 2.00
	TIMES SOURCE:(MPLY:0):愛情, 2.00
	TIMES SOURCE:(MTAR:0):歓楽, 2.00
	TIMES SOURCE:(MTAR:0):優越, 2.00
	TIMES SOURCE:(MTAR:0):愛情, 2.00
	TFLAG:37 += 5
ENDIF

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = -1

RETURN 1

;-------------------------------------------------
;固有の実行判定(プレイヤー側)
;-------------------------------------------------
@COM_ORDER_PLAYER320(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 35

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 2)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 3)

;好感度
IF CFLAG:(ARG:0):2 < 400
	IF CFLAG:(ARG:0):2 < 50
		LOCAL:0 = -40
	ELSEIF CFLAG:(ARG:0):2 < 150
		LOCAL:0 = -20
	ELSEIF CFLAG:(ARG:0):2 < 300
		LOCAL:0 = -10
	ELSE
		LOCAL:0 = -5
	ENDIF
	CALL COM_ORDER_ELEMENT(ARG:0, @"好感度不足", LOCAL:0)
ELSE
	LOCAL:0 = CFLAG:(ARG:0):2 / 75
	CALL COM_ORDER_ELEMENT(ARG:0, @"好感度", LOCAL:0)
ENDIF

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -3)
ENDIF
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 5)
ENDIF
IF TFLAG:54
	CALL COM_ORDER_ELEMENT(ARG:0, "デート中", 4)
ENDIF
RETURN 1

;-------------------------------------------------
;地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE320
;キス中
IF IS_EQUIP(MPLY:0, 342)
	LOCALS:0 = キスをしながら
	;地の文カット
```
