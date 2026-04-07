# TRAIN/COMF/COMF342_ディープキス.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF342_ディープキス.ERB`

类型: .ERB

自动摘要: functions: COM_NAME342, COM_ABLE342, COM342, COM_IS_EQUIP342, COM_EQUIP342, EQUIP_MESSAGE342, COM_TEXT_BEFORE_EQUIP342, COM_TEXT_RELEASE_EQUIP342, COM_ORDER_PLAYER342, COM_ORDER_TARGET342, COM_TEXT_BEFORE342, COM_TEXT_LAST342, COM_AVAILABLE_WHEN342; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;ディープキス

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME342
RESULTS:0 = ディープキスする
RESULTS:1 = ディープキスをねだられる
RESULTS:2 = ディープキスさせる
RESULTS:3 = ディープキスされる

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE342
;共通部分
CALL COM_ABLE_COMMON(342)
SIF RESULT == 0
	RETURN 0
;主人公以外が実行する場合、好感度が800以上必要
SIF MPLY:0 != MASTER && CFLAG:(MPLY:0):2 < 800
	RETURN 0
;怪我なら不可
SIF CFLAG:(MTAR:0):行動不能状態 == 3
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM342
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
SOURCE:(MPLY:0):接触 = 200
SOURCE:(MPLY:0):愛情 = -54
SOURCE:(MPLY:0):性行動 = 90

;親密に応じた歓楽のソース追加
CALL ADD_SOURCE_KANRAKU(MPLY:0, 50)
SOURCE:(MPLY:0):歓楽 = MAX(SOURCE:(MPLY:0):歓楽, 0)

;親密に応じた愛情のソース追加
CALL ADD_SOURCE_AIZYOU(MPLY:0, 180)
SOURCE:(MPLY:0):愛情 = MAX(SOURCE:(MPLY:0):愛情, 0)

SOURCE:(MPLY:0):快Ｍ = SENSE_HOUSHI(MTAR:0, MPLY:0, 300)
SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 120)

IF TALENT:(MTAR:0):舌使い
	TIMES SOURCE:(MPLY:0):快Ｍ, 2.00
	TIMES SOURCE:(MPLY:0):愛情, 1.20
ENDIF

IF MPLY:0 != MASTER && !TALENT:(MPLY:0):恋人
	SOURCE:(MPLY:0):逸脱 = 200
	IF TALENT:(MPLY:0):キス未経験
		SOURCE:(MPLY:0):逸脱 += 800
	ENDIF
ENDIF

IF MPLY:0 != MASTER
	IF CFLAG:(MPLY:0):2 < 300
		SOURCE:(MPLY:0):反感 = 500
	ELSEIF CFLAG:(MPLY:0):2 < 500
		SOURCE:(MPLY:0):反感 = 300
	ELSEIF CFLAG:(MPLY:0):2 < 800
		SOURCE:(MPLY:0):反感 = 50
	ENDIF
ENDIF

;主導権に応じたソースの追加
CALL ADD_SOURCE_INITIATIVE_N(MPLY:0, 100, 100)
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 40, 40)

;●ターゲット側の処理
;固定で獲得するソース
SOURCE:(MTAR:0):歓楽 = -25
SOURCE:(MTAR:0):接触 = 200
SOURCE:(MTAR:0):愛情 = -54
SOURCE:(MTAR:0):性行動 = 90

;親密に応じた歓楽のソース追加
CALL ADD_SOURCE_KANRAKU(MTAR:0, 50)
SOURCE:(MTAR:0):歓楽 = MAX(SOURCE:(MTAR:0):歓楽, 0)

;親密に応じた愛情のソース追加
CALL ADD_SOURCE_AIZYOU(MTAR:0, 180)
SOURCE:(MTAR:0):愛情 = MAX(SOURCE:(MTAR:0):愛情, 0)

SOURCE:(MTAR:0):快Ｍ = SENSE_HOUSHI(MPLY:0, MTAR:0, 300)
SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 120)

IF TALENT:(MPLY:0):舌使い
	TIMES SOURCE:(MTAR:0):快Ｍ, 2.00
	TIMES SOURCE:(MTAR:0):愛情, 1.20
ENDIF

IF MTAR:0 != MASTER && !TALENT:(MTAR:0):恋人
	SOURCE:(MTAR:0):逸脱 = 200
	IF TALENT:(MTAR:0):キス未経験
		SOURCE:(MTAR:0):逸脱 += 800
	ENDIF
ENDIF

IF MTAR:0 != MASTER
	IF CFLAG:(MTAR:0):2 < 300
		SOURCE:(MTAR:0):反感 = 500
	ELSEIF CFLAG:(MTAR:0):2 < 500
		SOURCE:(MTAR:0):反感 = 300
	ELSEIF CFLAG:(MTAR:0):2 < 800
		SOURCE:(MTAR:0):反感 = 50
	ENDIF
ENDIF

IF TALENT:(MTAR:0):キス未経験
	TIMES SOURCE:(MTAR:0):反感, 2.00
	IF TALENT:(MTAR:0):貞操観念
		TIMES SOURCE:(MTAR:0):反感, 3.00
	ENDIF
ENDIF

;主導権に応じたソースの追加
CALL ADD_SOURCE_INITIATIVE_N(MTAR:0, 100, 100)
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 40, 40)

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
TFLAG:49 = 4

;倒錯度変化基準値
TFLAG:50 = -1

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP342
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP342(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

;●プレイヤーの処理
```
