# TRAIN/COMF/COMF106_亀頭責め手コキ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF106_亀頭責め手コキ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME106, COM_ABLE106, COM106, COM_IS_EQUIP106, COM_EQUIP106, EQUIP_MESSAGE106, COM_TEXT_BEFORE_EQUIP106, COM_TEXT_RELEASE_EQUIP106, COM_ORDER_PLAYER106, COM_TEXT_BEFORE106, COM_AVAILABLE_WHEN106, COM_PREFERENCE_PLAYER_106, COM_PREFERENCE_TARGET_106, COM_STACK_SPERM_MTAR_TO_MPLY_106; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;亀頭責め手コキ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME106
IF MPLY_NUM == 2
	LOCALS:0 = Ｗ亀頭責め手コキ
ELSE
	LOCALS:0 = 亀頭責め手コキ
ENDIF

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE106
;共通部分
CALL COM_ABLE_COMMON(106)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で2人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 2
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
SIF !HAS_PENIS(MTAR:0)
	RETURN 0
FOR LOCAL:0, 0, MPLY_NUM
	SIF !P_STACKABLE(MPLY:(LOCAL:0), MTAR:0, 106)
		RETURN 0
	SIF !CAN_REACH_GROIN(MPLY:(LOCAL:0), MTAR:0)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM106
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MPLY_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 250)
	SOURCE:(LOCAL:2):接触 = 100
	SOURCE:(LOCAL:2):性行動 = 210

	IF IS_INITIATIVE(LOCAL:2)
		SOURCE:(LOCAL:2):嗜虐 = 50
	ENDIF

	SELECTCASE ABL:(LOCAL:2):奉仕
		CASE 0
			TIMES SOURCE:(LOCAL:2):不潔, 4.00
		CASE 1
			TIMES SOURCE:(LOCAL:2):不潔, 2.50
		CASE 2
			TIMES SOURCE:(LOCAL:2):不潔, 1.50
		CASE 3
			TIMES SOURCE:(LOCAL:2):不潔, 1.00
		CASE 4
			TIMES SOURCE:(LOCAL:2):不潔, 0.50
		CASEELSE
			TIMES SOURCE:(LOCAL:2):不潔, 0.10
	ENDSELECT

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 180, 80)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
;		SOURCE:(LOCAL:3):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1200) * LOCAL:10 / 100
		SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1200) * LOCAL:10 / 100
	NEXT
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	SOURCE:(LOCAL:1):接触 = 50
	SOURCE:(LOCAL:1):性行動 = 180

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 100, 110)
NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 1

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP106
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP106(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_PLAYER_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 70)
	SOURCE:(LOCAL:2):接触 += 50
	SOURCE:(LOCAL:2):性行動 += 70

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(ARG:0)
		LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:1)
;		SOURCE:(LOCAL:3):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 500) * LOCAL:10 / 100
		SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 500) * LOCAL:10 / 100
	NEXT
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:1 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	SOURCE:(LOCAL:1):接触 += 25
	SOURCE:(LOCAL:1):性行動 += 60
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE106(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に亀頭責め手コキ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP106(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の亀頭を掌で撫で回している…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP106(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER106(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 75

;共通部分
CALL COM_ORDER(ARG:0)

```
