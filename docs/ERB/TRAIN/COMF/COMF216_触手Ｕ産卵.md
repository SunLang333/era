# TRAIN/COMF/COMF216_触手Ｕ産卵.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF216_触手Ｕ産卵.ERB`

类型: .ERB

自动摘要: functions: COM_NAME216, COM_ABLE216, COM216, COM_COMMON216, COM_ORDER_PLAYER216, COM_TEXT_BEFORE216, COM_TEXT_LAST216, COM_AVAILABLE_WHEN216, COM_PREFERENCE_PLAYER_216, COM_PREFERENCE_TARGET_216; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手産卵

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME216
LOCALS:0 = 触手Ｕ産卵

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE216
;共通部分
CALL COM_ABLE_COMMON(216)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0) && !FLAG:RECHECKING
	RETURN 0
;プレイヤーが触手召喚中でないなら不可
SIF !IS_EQUIP_PLAYER(MPLY:0, 200)
	RETURN 0
;全てのターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	;ターゲットのＵが塞がっているなら不可(プレイヤーからターゲットへの触手挿入中は可)
	SIF IS_U_HOLD(MTAR:(LOCAL:0)) && SEARCH_EQUIP(215, MPLY:0, MTAR:(LOCAL:0)) == -1
		RETURN 0
	;既に触手妊娠中なら不可
	SIF TALENT:(MTAR:(LOCAL:0)):Ｕ触手妊娠 && !FLAG:RECHECKING
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM216
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):妖術経験値 += 1
EXP:(MPLY:0):触手経験値 += 1

SOURCE:(MPLY:0):嗜虐 = 100
SOURCE:(MPLY:0):逸脱 = 150
SOURCE:(MPLY:0):触手 = 200
SOURCE:(MPLY:0):性行動 = 180

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 170, 30)

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	EXP:(LOCAL:2):触手経験値 += 2

	SOURCE:(LOCAL:2):快Ｕ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 500 + ABL:(MPLY:0):妖術 * 6) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 1000)
	SOURCE:(LOCAL:2):逸脱 = 1500 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SOURCE:(LOCAL:2):触手 = 1500 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 1500)
	SOURCE:(LOCAL:2):性行動 = 450 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 450)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 120)

	;基本処理
	CALL COM_COMMON216(LOCAL:2)

	TALENT:(LOCAL:2):Ｕ触手妊娠 = 1

	;触手Ｖ産卵したキャラのIDを記録
	CFLAG:(LOCAL:2):触手Ｕ産卵実行者 = GET_ID(MPLY:0)

NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 10

;レズ・ＢＬ経験基準値
TFLAG:51 = 1

RETURN 1

;--------------------------------------------------------
;ターゲットに対する諸々の処理
;--------------------------------------------------------
@COM_COMMON216(ARG:0)
SELECTCASE ABL:(ARG:0):Ｕ感
	CASE 0
		SOURCE:(ARG:0):苦痛 += 800
	CASE 1
		SOURCE:(ARG:0):苦痛 += 500
	CASE 2
		SOURCE:(ARG:0):苦痛 += 300
ENDSELECT

IF PALAM:(ARG:0):潤滑 < PALAMLV:1
	TIMES SOURCE:(ARG:0):快Ｕ, 0.05
	SOURCE:(ARG:0):苦痛 = SOURCE:(ARG:0):苦痛 * 4 + 1000
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:3
	TIMES SOURCE:(ARG:0):快Ｕ, 0.20
	SOURCE:(ARG:0):苦痛 = SOURCE:(ARG:0):苦痛 * 2 + 300
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:5
	TIMES SOURCE:(ARG:0):快Ｕ, 0.60
	TIMES SOURCE:(ARG:0):苦痛, 1.00
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:7
	TIMES SOURCE:(ARG:0):快Ｕ, 0.85
	TIMES SOURCE:(ARG:0):苦痛, 0.70
ELSE
	TIMES SOURCE:(ARG:0):快Ｕ, 1.00
	TIMES SOURCE:(ARG:0):苦痛, 0.50
ENDIF

IF TALENT:(ARG:0):体格 == 体格_小柄
	TIMES SOURCE:(ARG:0):苦痛, 1.50
ENDIF

IF ARG:0 != MASTER
	IF !(TALENT:(ARG:0):恋慕 || TALENT:(ARG:0):親友)
		IF TALENT:(ARG:0):貞操観念
			IF TALENT:(ARG:0):処女
				SOURCE:(ARG:0):反感 = 5000
			ELSE
				SOURCE:(ARG:0):反感 = 1000
			ENDIF
		ELSEIF TALENT:(ARG:0):貞操無頓着
			IF TALENT:(ARG:0):処女
				SOURCE:(ARG:0):反感 = 300
			ENDIF
		ELSE
			IF TALENT:(ARG:0):処女
				SOURCE:(ARG:0):反感 = 2500
			ENDIF
		ENDIF
		IF TALENT:(ARG:0):恋人
			TIMES SOURCE:(ARG:0):反感, 0.10
		ENDIF
	ENDIF

	;好感度・従属度・支配度の影響
	LOCAL:0 = MAX(CFLAG:(ARG:0):2, CFLAG:(ARG:0):4, CFLAG:(ARG:0):5)
	IF LOCAL:0 < 100
		TIMES SOURCE:(ARG:0):反感, 1.00
	ELSEIF LOCAL:0 < 300
		TIMES SOURCE:(ARG:0):反感, 0.90
	ELSEIF LOCAL:0 < 500
		TIMES SOURCE:(ARG:0):反感, 0.80
	ELSEIF LOCAL:0 < 800
		TIMES SOURCE:(ARG:0):反感, 0.40
	ELSEIF LOCAL:0 < 1500
		TIMES SOURCE:(ARG:0):反感, 0.15
	ELSE
		SOURCE:(ARG:0):反感 = SOURCE:(ARG:0):反感 / ((LOCAL:0 - 1500) / 50 + 10)
	ENDIF
ENDIF

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER216(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 160

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 2)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 3)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):触手}", ABL:(ARG:0):触手 * 6)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -2)
ENDIF
IF TALENT:(ARG:0):好奇心
	CALL COM_ORDER_ELEMENT(ARG:0, "好奇心", 2)
ENDIF
IF TALENT:(ARG:0):保守的
```
