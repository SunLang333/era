# TRAIN/COMF/COMF213_触手Ａ産卵.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF213_触手Ａ産卵.ERB`

类型: .ERB

自动摘要: functions: COM_NAME213, COM_ABLE213, COM213, COM_COMMON213, COM_ORDER_PLAYER213, COM_TEXT_BEFORE213, COM_TEXT_LAST213, COM_AVAILABLE_WHEN213, COM_PREFERENCE_PLAYER_213, COM_PREFERENCE_TARGET_213; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手Ａ産卵

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME213
LOCALS:0 = 触手Ａ産卵

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE213
;共通部分
CALL COM_ABLE_COMMON(213)
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
	;ターゲットのＡが塞がっているなら不可(プレイヤーからターゲットへの触手Ａ挿入中は可)
	SIF IS_A_HOLD(MTAR:(LOCAL:0)) && SEARCH_EQUIP(202, MPLY:0, MTAR:(LOCAL:0)) == -1
		RETURN 0
	;既にＡ触手妊娠中なら不可
	SIF TALENT:(MTAR:(LOCAL:0)):Ａ触手妊娠 && !FLAG:RECHECKING
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM213
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):妖術経験値 += 1
EXP:(MPLY:0):触手経験値 += 1

SOURCE:(MPLY:0):嗜虐 = 150
SOURCE:(MPLY:0):逸脱 = 200
SOURCE:(MPLY:0):触手 = 200
SOURCE:(MPLY:0):性行動 = 180

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 170, 30)

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	EXP:(LOCAL:2):触手経験値 += 2

	SOURCE:(LOCAL:2):快Ａ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 500 + ABL:(MPLY:0):妖術 * 6) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 1000)
	SOURCE:(LOCAL:2):逸脱 = 1100 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 550)
	SOURCE:(LOCAL:2):触手 = 1500 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 1500)
	SOURCE:(LOCAL:2):性行動 = 240 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 240)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 140)

	;基本処理
	CALL COM_COMMON213(LOCAL:2)

	TALENT:(LOCAL:2):Ａ触手妊娠 = 1

	;触手Ａ産卵したキャラのIDを記録
	CFLAG:(LOCAL:2):触手Ａ産卵実行者 = GET_ID(MPLY:0)
	CALL VIRGIN_COMMON_A(LOCAL:2, "触手", GET_SITUATION_BY_TRAIN_MODE())

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
@COM_COMMON213(ARG:0)
SELECTCASE ABL:(ARG:0):Ａ感
	CASE 0
		SOURCE:(ARG:0):苦痛 += 1800
	CASE 1
		SOURCE:(ARG:0):苦痛 += 750
	CASE 2
		SOURCE:(ARG:0):苦痛 += 300
	CASE 3
		SOURCE:(ARG:0):苦痛 += 120
	CASE 4
		SOURCE:(ARG:0):苦痛 += 45
ENDSELECT

IF PALAM:(ARG:0):潤滑 < PALAMLV:1
	TIMES SOURCE:(ARG:0):快Ａ, 0.05
	SOURCE:(ARG:0):苦痛 = SOURCE:(ARG:0):苦痛 * 3 + 1000
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:3
	TIMES SOURCE:(ARG:0):快Ａ, 0.20
	SOURCE:(ARG:0):苦痛 = SOURCE:(ARG:0):苦痛 * 3 / 2 + 300
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:5
	TIMES SOURCE:(ARG:0):快Ａ, 0.60
	TIMES SOURCE:(ARG:0):苦痛, 1.00
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:7
	TIMES SOURCE:(ARG:0):快Ａ, 0.85
	TIMES SOURCE:(ARG:0):苦痛, 0.70
ELSE
	TIMES SOURCE:(ARG:0):快Ａ, 1.00
	TIMES SOURCE:(ARG:0):苦痛, 0.50
ENDIF

IF TALENT:(ARG:0):体格 == 体格_小柄
	TIMES SOURCE:(ARG:0):苦痛, 1.50
ENDIF

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER213(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 150

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
	CALL COM_ORDER_ELEMENT(ARG:0, "保守的", -7)
ENDIF
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 4)
ENDIF
IF TALENT:(ARG:0):快感の否定
	CALL COM_ORDER_ELEMENT(ARG:0, "快感の否定", -2)
ENDIF

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド) || GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_マゾ) || ABL:(ARG:0):倒錯度 >= 800
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 32)
ELSEIF ABL:(ARG:0):倒錯度 >= 500
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 24)
ELSEIF ABL:(ARG:0):倒錯度 >= 300
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 16)
ELSEIF ABL:(ARG:0):倒錯度 >= 100
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 8)
ELSE
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 0)
ENDIF

IF !TALENT:(ARG:0):合意 && !TALENT:(ARG:0):親友
	CALL COM_ORDER_ELEMENT(ARG:0, "合意なし", -10)
ENDIF
RETURN 1

;-------------------------------------------------
;地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE213
LOCAL:1 = 1
FOR LOCAL:0, 0, MTAR_NUM
	IF SEARCH_EQUIP(202, MPLY:0, MTAR:(LOCAL:0)) == -1
		LOCAL:1 = 0
```
