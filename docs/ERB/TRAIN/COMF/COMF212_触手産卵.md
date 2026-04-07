# TRAIN/COMF/COMF212_触手産卵.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF212_触手産卵.ERB`

类型: .ERB

自动摘要: functions: COM_NAME212, COM_ABLE212, COM212, COM_COMMON212, COM_ORDER_PLAYER212, COM_TEXT_BEFORE212, COM_TEXT_LAST212, COM_AVAILABLE_WHEN212, COM_PREFERENCE_PLAYER_212, COM_PREFERENCE_TARGET_212; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手産卵

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME212
LOCALS:0 = 触手産卵

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE212
;共通部分
CALL COM_ABLE_COMMON(212)
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
	;Ｖが必要
	SIF !HAS_VAGINA(MTAR:(LOCAL:0))
		RETURN 0
	;ターゲットのＶが塞がっているなら不可(プレイヤーからターゲットへの触手挿入中は可)
	SIF IS_V_HOLD(MTAR:(LOCAL:0)) && SEARCH_EQUIP(201, MPLY:0, MTAR:(LOCAL:0)) == -1
		RETURN 0
	;既に触手妊娠中なら不可
	SIF TALENT:(MTAR:(LOCAL:0)):触手妊娠 && !FLAG:RECHECKING
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM212
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

	SOURCE:(LOCAL:2):快Ｖ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 500 + ABL:(MPLY:0):妖術 * 6) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 1000)
	SOURCE:(LOCAL:2):逸脱 = 1000 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SOURCE:(LOCAL:2):触手 = 1500 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 1500)
	SOURCE:(LOCAL:2):性行動 = 450 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 450)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 120)

	;基本処理
	CALL COM_COMMON212(LOCAL:2)

	TALENT:(LOCAL:2):触手妊娠 = 1

	;触手Ｖ産卵したキャラのIDを記録
	CFLAG:(LOCAL:2):触手産卵実行者 = GET_ID(MPLY:0)

	CALL VIRGIN_COMMON(LOCAL:2, "触手", GET_SITUATION_BY_TRAIN_MODE())


	IF TALENT:(LOCAL:2):処女
		IF MPLY:0 == MASTER
			;処女喪失フラグ(主人に性交以外で奪われる)
			TCVAR:(LOCAL:2):13 = 2
		ELSE
			;処女喪失フラグ(主人以外に性交以外で奪われる)
			TCVAR:(LOCAL:2):13 = 4
		ENDIF
	ENDIF
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
@COM_COMMON212(ARG:0)
SELECTCASE ABL:(ARG:0):Ｖ感
	CASE 0
		SOURCE:(ARG:0):苦痛 += 450
	CASE 1
		SOURCE:(ARG:0):苦痛 += 150
	CASE 2
		SOURCE:(ARG:0):苦痛 += 45
ENDSELECT

IF PALAM:(ARG:0):潤滑 < PALAMLV:1
	TIMES SOURCE:(ARG:0):快Ｖ, 0.05
	SOURCE:(ARG:0):苦痛 = SOURCE:(ARG:0):苦痛 * 4 + 1000
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:3
	TIMES SOURCE:(ARG:0):快Ｖ, 0.20
	SOURCE:(ARG:0):苦痛 = SOURCE:(ARG:0):苦痛 * 2 + 300
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:5
	TIMES SOURCE:(ARG:0):快Ｖ, 0.60
	TIMES SOURCE:(ARG:0):苦痛, 1.00
ELSEIF PALAM:(ARG:0):潤滑 < PALAMLV:7
	TIMES SOURCE:(ARG:0):快Ｖ, 0.85
	TIMES SOURCE:(ARG:0):苦痛, 0.70
ELSE
	TIMES SOURCE:(ARG:0):快Ｖ, 1.00
	TIMES SOURCE:(ARG:0):苦痛, 0.50
ENDIF

IF TALENT:(ARG:0):体格 == 体格_小柄
	TIMES SOURCE:(ARG:0):苦痛, 1.50
ENDIF

IF TALENT:(ARG:0):処女 == 1
	SOURCE:(ARG:0):苦痛 = SOURCE:(ARG:0):苦痛 * 2 + 500
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
@COM_ORDER_PLAYER212(ARG:0)
;実行値の設定
```
