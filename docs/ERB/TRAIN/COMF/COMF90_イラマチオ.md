# TRAIN/COMF/COMF90_イラマチオ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF90_イラマチオ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME90, COM_ABLE90, COM90_RATE_M, COM90, COM_IS_EQUIP90, COM_EQUIP90, EQUIP_MESSAGE90, COM_TEXT_BEFORE_EQUIP90, COM_TEXT_RELEASE_EQUIP90, COM_ORDER_PLAYER90, COM_TEXT_BEFORE90, COM_TEXT_LAST90, COM_AVAILABLE_WHEN90, COM_PREFERENCE_PLAYER_90, COM_PREFERENCE_TARGET_90, COM_STACK_SPERM_MPLY_TO_MTAR_90; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;イラマチオ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME90
;挿入中
LOCALS:0 = 
SIF IS_INSERT_SINGLE(MPLY:0, "Ｐ")
	LOCALS:0 += "お掃除"

SELECTCASE MPLY_NUM
	CASE 1
	CASE 2
		LOCALS:0 += "二本"
	CASE 3
		LOCALS:0 += "三本"
	CASEELSE
		LOCALS:0 += "輪"
ENDSELECT

LOCALS:0 += "イラマチオ"

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE90
;共通部分
CALL COM_ABLE_COMMON(90)
SIF RESULT == 0
	RETURN 0
;プレイヤーが必要
SIF MPLY_NUM <= 0
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;プレイヤーに竿がなく、ペニスバンド装着中でもないと不可
SIF !HAS_PENIS(MPLY:0) && !IS_EQUIP_PLAYER((MPLY:0), 50)
	RETURN 0
SIF !CAN_LICK_GROIN(MTAR:0, MPLY:0, 1)
	RETURN 0
SIF !P_STACKABLE(MTAR:0, MPLY:0, 90)
	RETURN 0
SIF IS_INSERT_MUTUAL(MPLY:0, MTAR:0) > 0
	RETURN 0
SIF IS_RIDE(MPLY:0, MTAR:0)
	RETURN 0
RETURN 1

;-------------------------------------------------
;快Ｍソースの倍率を取得する関数 ARG:0=PLAYERのキャラ番号
;-------------------------------------------------
@COM90_RATE_M(ARG:0)
#FUNCTION
LOCAL:5 = 1000
SELECTCASE ABL:(ARG:0):奉仕
	CASE 0
		TIMES LOCAL:5, 0.25
		;TIMES SOURCE:(LOCAL:2):不潔, 4.00
	CASE 1
		TIMES LOCAL:5, 0.50
		;TIMES SOURCE:(LOCAL:2):不潔, 2.50
	CASE 2
		TIMES LOCAL:5, 0.60
		;TIMES SOURCE:(LOCAL:2):不潔, 1.50
	CASE 3
		TIMES LOCAL:5, 0.80
		;TIMES SOURCE:(LOCAL:2):不潔, 1.00
	CASE 4
		TIMES LOCAL:5, 1.00
		;TIMES SOURCE:(LOCAL:2):不潔, 0.50
	CASEELSE
		LOCAL:5 = LOCAL:5 * (100 + (ABL:(ARG:0):奉仕 - 5) * 3) / 100
		;TIMES SOURCE:(LOCAL:2):不潔, 0.10
ENDSELECT

SELECTCASE ABL:(ARG:0):性技
	CASE 0
		TIMES LOCAL:5, 1.00
	CASE 1
		TIMES LOCAL:5, 1.10
	CASE 2
		TIMES LOCAL:5, 1.20
	CASE 3
		TIMES LOCAL:5, 1.30
	CASE 4
		TIMES LOCAL:5, 1.40
	CASEELSE
		LOCAL:5 = LOCAL:5 * ((ABL:(ARG:0):性技 - 5) * 2 + 150) / 100
ENDSELECT

RETURNF LOCAL:5

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM90
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;プレイヤーの挿入状態を解除


;●プレイヤーについて判定
FOR LOCAL, 0, MPLY_NUM
	LOCAL:1 = MPLY:LOCAL
	CALL CLEAR_INSERT_FLAG(LOCAL:1, "Ｐ")
	SOURCE:(LOCAL:1):接触 = 50
	SOURCE:(LOCAL:1):嗜虐 = 50
	SOURCE:(LOCAL:1):逸脱 = 50
	SOURCE:(LOCAL:1):性行動 = 180
	EXP:(LOCAL:1):嗜虐経験値 += 1

	LOCAL:2 = SENSE_HOUSHI_P(MTAR:0, LOCAL:1, 600)
	IF TALENT:(MTAR:0):舌使い
		TIMES LOCAL:2, 1.50
	ENDIF

	SOURCE:(LOCAL:1):快Ｐ += SENSE_HOUSHI_P(LOCAL:1, LOCAL:1, 800) + LOCAL:2

	;主導権に応じた優越・受動のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 160, 60)

NEXT

;●ターゲットについて判定
EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):口淫経験 += 1
EXP:(MTAR:0):被虐経験値 += 1

SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 100)
SOURCE:(MTAR:0):接触 = 50
SOURCE:(MTAR:0):快Ｍ = 600 * COM90_RATE_M(MTAR:0) / 1000
SOURCE:(MTAR:0):逸脱 = 100
SOURCE:(MTAR:0):苦痛 = 130 + MIN(ABL:(MPLY:0):武闘, 90) / 2
SOURCE:(MTAR:0):性行動 = 300

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 50, 150)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;ペニスへのキス
IF MTAR_NUM == 1
		;ペニスへのキス
	CALL KISS_COMMON(MTAR:0, @"%ANAME(MPLY:0)%のペニス", GET_SITUATION_BY_TRAIN_MODE())
ELSE
	CALL KISS_COMMON(MTAR:0, @"%ANAME(MPLY:0)%たちのペニス", (GET_SITUATION_BY_TRAIN_MODE() == "和姦" ? "乱交" # "輪姦"))
ENDIF

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 3

;レズ・ＢＬ経験基準値
TFLAG:51 = 7

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP90
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP90(ARG:0)
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●プレイヤーについて判定
FOR LOCAL, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):LOCAL
	SOURCE:(LOCAL:2):接触 += 25
	SOURCE:(LOCAL:2):嗜虐 += 25
	SOURCE:(LOCAL:2):性行動 += 60
	EXP:(LOCAL:2):嗜虐経験値 += 1

	LOCAL:4 = SENSE_HOUSHI_P(LOCAL:3, LOCAL:2, 200)
	IF TALENT:(LOCAL:3):舌使い
		TIMES LOCAL:4, 1.50
	ENDIF

	SOURCE:(LOCAL:2):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:2, 250) + LOCAL:4


```
