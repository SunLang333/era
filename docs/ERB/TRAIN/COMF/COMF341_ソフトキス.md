# TRAIN/COMF/COMF341_ソフトキス.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF341_ソフトキス.ERB`

类型: .ERB

自动摘要: functions: COM_NAME341, COM_ABLE341, COM341, COM_ORDER_PLAYER341, COM_ORDER_TARGET341, COM_TEXT_BEFORE341, COM_TEXT_LAST341, COM_AVAILABLE_WHEN341; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;ソフトキス

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME341
RESULTS:0 = ソフトキスする
RESULTS:1 = ソフトキスをねだられる
RESULTS:2 = ソフトキスさせる
RESULTS:3 = ソフトキスされる

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE341
;共通部分
CALL COM_ABLE_COMMON(341)
SIF RESULT == 0
	RETURN 0
;主人公以外が実行する場合、好感度が800以上必要
SIF MPLY:0 != MASTER && CFLAG:(MPLY:0):2 < 800
	RETURN 0
;怪我なら不可
SIF CFLAG:(MTAR:0):行動不能状態 == 3
	RETURN 0
;ディープキス中は不可
SIF IS_EQUIP(MPLY:0, 342)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM341
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

;●プレイヤー側の処理
;固定で獲得するソース
SOURCE:(MPLY:0):歓楽 = -25
SOURCE:(MPLY:0):接触 = 150
SOURCE:(MPLY:0):愛情 = -48

;親密に応じた歓楽のソース追加
CALL ADD_SOURCE_KANRAKU(MPLY:0, 50)
SOURCE:(MPLY:0):歓楽 = MAX(SOURCE:(MPLY:0):歓楽, 0)

;親密に応じた愛情のソース追加
CALL ADD_SOURCE_AIZYOU(MPLY:0, 160)
SOURCE:(MPLY:0):愛情 = MAX(SOURCE:(MPLY:0):愛情, 0)

SOURCE:(MPLY:0):快Ｍ = SENSE_HOUSHI(MTAR:0, MPLY:0, 100)
SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 80)

;主導権に応じたソースの追加
CALL ADD_SOURCE_INITIATIVE_N(MPLY:0, 100, 100)
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 20, 20)

;●ターゲット側の処理
;固定で獲得するソース
SOURCE:(MTAR:0):歓楽 = -25
SOURCE:(MTAR:0):接触 = 150
SOURCE:(MTAR:0):愛情 = -48

;親密に応じた歓楽のソース追加
CALL ADD_SOURCE_KANRAKU(MTAR:0, 50)
SOURCE:(MTAR:0):歓楽 = MAX(SOURCE:(MTAR:0):歓楽, 0)

;親密に応じた愛情のソース追加
CALL ADD_SOURCE_AIZYOU(MTAR:0, 160)
SOURCE:(MTAR:0):愛情 = MAX(SOURCE:(MTAR:0):愛情, 0)

SOURCE:(MTAR:0):快Ｍ = SENSE_HOUSHI(MPLY:0, MTAR:0, 100)
SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 80)

;主導権に応じたソースの追加
CALL ADD_SOURCE_INITIATIVE_N(MTAR:0, 100, 100)
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 20, 20)

IF CFLAG:(MTAR:0):2 < 300
	SOURCE:(MTAR:0):反感 = 400
ELSEIF CFLAG:(MTAR:0):2 < 500
	SOURCE:(MTAR:0):反感 = 200
ELSEIF CFLAG:(MTAR:0):2 < 800
	SOURCE:(MTAR:0):反感 = 30
ENDIF

IF TALENT:(MTAR:0):キス未経験
	TIMES SOURCE:(MTAR:0):反感, 2.00
	IF TALENT:(MTAR:0):貞操観念
		TIMES SOURCE:(MTAR:0):反感, 3.00
	ENDIF
ENDIF

;●共通処理
IF TFLAG:18 == -1
	TIMES SOURCE:(MPLY:0):歓楽, 0.20
	TIMES SOURCE:(MPLY:0):愛情, 0.20
	TIMES SOURCE:(MPLY:0):快Ｍ, 0.20
	TIMES SOURCE:(MTAR:0):歓楽, 0.20
	TIMES SOURCE:(MTAR:0):愛情, 0.20
	TIMES SOURCE:(MTAR:0):快Ｍ, 0.20
	SOURCE:(MPLY:0):不満 += 500
	SOURCE:(MTAR:0):不満 += 500
	TFLAG:37 -= 5
ELSEIF TFLAG:18 == 0

ELSE
	TIMES SOURCE:(MPLY:0):歓楽, 2.00
	TIMES SOURCE:(MPLY:0):愛情, 2.00
	TIMES SOURCE:(MPLY:0):快Ｍ, 2.00
	TIMES SOURCE:(MTAR:0):歓楽, 2.00
	TIMES SOURCE:(MTAR:0):愛情, 2.00
	TIMES SOURCE:(MTAR:0):快Ｍ, 2.00
	TFLAG:37 += 5
ENDIF

EXP:(MPLY:0):キス経験 += 1
EXP:(MTAR:0):キス経験 += 1
CALL KISS_COMMON(MPLY:0, @"%ANAME(MTAR:0)%の唇", GET_SITUATION_BY_TRAIN_MODE(), MPLY:0 != MASTER)
CALL KISS_COMMON(MTAR:0, @"%ANAME(MPLY:0)%の唇", GET_SITUATION_BY_TRAIN_MODE(), MTAR:0 != MASTER)
;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = -1

;レズ・ＢＬ経験基準値
TFLAG:51 = 2

RETURN 1

;-------------------------------------------------
;固有の実行判定(プレイヤー側)
;-------------------------------------------------
@COM_ORDER_PLAYER341(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 55

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 2)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 3)

;好感度
IF CFLAG:(ARG:0):2 < 500
	IF CFLAG:(ARG:0):2 < 100
		LOCAL:0 = -40
	ELSEIF CFLAG:(ARG:0):2 < 200
		LOCAL:0 = -20
	ELSEIF CFLAG:(ARG:0):2 < 400
		LOCAL:0 = -10
	ELSE
		LOCAL:0 = -5
	ENDIF
	CALL COM_ORDER_ELEMENT(ARG:0, @"好感度不足", LOCAL:0)
ELSE
	LOCAL:0 = CFLAG:(ARG:0):2 / 75
	CALL COM_ORDER_ELEMENT(ARG:0, @"好感度", LOCAL:0)
ENDIF

IF TALENT:(ARG:0):キス未経験
	CALL COM_ORDER_ELEMENT(ARG:0, "キス未経験", -7)
ENDIF
IF TALENT:(ARG:0):貞操観念
	CALL COM_ORDER_ELEMENT(ARG:0, "貞操観念", -6)
ENDIF
IF TALENT:(ARG:0):貞操無頓着
	CALL COM_ORDER_ELEMENT(ARG:0, "貞操無頓着", 3)
ENDIF
IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -3)
ENDIF
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 5)
ENDIF
IF TFLAG:54
	CALL COM_ORDER_ELEMENT(ARG:0, "デート中", 6)
ENDIF
RETURN 1

;-------------------------------------------------
;固有の実行判定(ターゲット側)
;-------------------------------------------------
@COM_ORDER_TARGET341(ARG:0)
;実行値の設定
```
