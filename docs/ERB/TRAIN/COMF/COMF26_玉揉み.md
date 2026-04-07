# TRAIN/COMF/COMF26_玉揉み.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF26_玉揉み.ERB`

类型: .ERB

自动摘要: functions: COM_NAME26, COM_ABLE26, COM26, COM_IS_EQUIP26, COM_EQUIP26, EQUIP_MESSAGE26, COM_TEXT_BEFORE_EQUIP26, COM_TEXT_RELEASE_EQUIP26, COM_ORDER_PLAYER26, COM_TEXT_BEFORE26, COM_AVAILABLE_WHEN26, COM_PREFERENCE_PLAYER_26, COM_PREFERENCE_TARGET_26, COM_STACK_SPERM_MTAR_TO_MPLY_26; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;手淫

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME26

IF MTAR_NUM > 1
	LOCALS:0 = 同時玉揉み
ELSEIF MPLY_NUM == 3
	LOCALS:0 = Ｔ玉揉み
ELSEIF MPLY_NUM == 2
	LOCALS:0 = Ｗ玉揉み
ELSE
	LOCALS:0 = 玉揉み
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
@COM_ABLE26
;共通部分
CALL COM_ABLE_COMMON(26)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で3人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 3
	RETURN 0
;ターゲットは最大でプレイヤーの二倍まで
SIF MTAR_NUM <= 0 || MTAR_NUM > MPLY_NUM * 2
	RETURN 0

FOR LOCAL:1, 0, MTAR_NUM
	SIF !HAS_PENIS(MTAR:(LOCAL:1))
		RETURN 0
	FOR LOCAL, 0, MPLY_NUM
		SIF !CAN_REACH_GROIN(MPLY:LOCAL, MTAR:(LOCAL:1))
			RETURN 0
		SIF !P_STACKABLE(MPLY:LOCAL, MTAR:(LOCAL:1), 26)
			RETURN 0
	NEXT
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM26
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MPLY_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
	CASE 3
		TIMES LOCAL:10, 0.60
ENDSELECT

SELECTCASE MTAR_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 100

	EXP:(LOCAL:2):性技経験値 += MAX(MTAR_NUM / 2 + 1, 1)

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 2200)
	SOURCE:(LOCAL:2):接触 = 50
	SOURCE:(LOCAL:2):性行動 = 100

	SELECTCASE ABL:(LOCAL:2):奉仕
		CASE 0
			TIMES SOURCE:(LOCAL:2):不潔, 4.50
		CASE 1
			TIMES SOURCE:(LOCAL:2):不潔, 3.00
		CASE 2
			TIMES SOURCE:(LOCAL:2):不潔, 2.00
		CASE 3
			TIMES SOURCE:(LOCAL:2):不潔, 1.00
		CASE 4
			TIMES SOURCE:(LOCAL:2):不潔, 0.75
		CASEELSE
			TIMES SOURCE:(LOCAL:2):不潔, 0.30
	ENDSELECT

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 150, 80)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 800) * LOCAL:10 / 100

	NEXT
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:1):体力 += 60

	SOURCE:(LOCAL:1):接触 = 50
	SOURCE:(LOCAL:1):性行動 = 180

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 120, 50)
NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP26
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP26(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_PLAYER_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
	CASE 3
		TIMES LOCAL:10, 0.60
ENDSELECT

SELECTCASE MEQUIP_TARGET_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 20

	EXP:(LOCAL:2):性技経験値 += MAX(MEQUIP_TARGET_NUM:(ARG:0) / 2 + 1, 1)

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 80)
	SOURCE:(LOCAL:2):接触 += 50
	SOURCE:(LOCAL:2):性行動 += 70

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(ARG:0)
		LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 300) * LOCAL:10 / 100

	NEXT
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:1 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:1):体力 += 10

	SOURCE:(LOCAL:1):接触 += 25
	SOURCE:(LOCAL:1):性行動 += 60
NEXT

;-------------------------------------------------
```
