# TRAIN/COMF/COMF4_アナル愛撫.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF4_アナル愛撫.ERB`

类型: .ERB

自动摘要: functions: COM_NAME4, COM_ABLE4, COM4, COM_IS_EQUIP4, COM_EQUIP4, EQUIP_MESSAGE4, COM_TEXT_BEFORE_EQUIP4, COM_TEXT_RELEASE_EQUIP4, COM_ORDER_PLAYER4, COM_TEXT_BEFORE4, COM_TEXT_LAST4, COM_AVAILABLE_WHEN4, COM_PREFERENCE_PLAYER_4, COM_PREFERENCE_TARGET_4; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;アナル愛撫

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME4
IF IS_EQUIP_TARGET(MTAR:0, 62)
	IF MTAR_NUM >= 2
		LOCALS:0 = 同時Ａバイブ責め
	ELSE
		LOCALS:0 = Ａバイブ責め
	ENDIF
ELSE
	IF MTAR_NUM >= 2
		LOCALS:0 = 同時アナル愛撫
	ELSE
		LOCALS:0 = アナル愛撫
	ENDIF
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
@COM_ABLE4
;共通部分
CALL COM_ABLE_COMMON(4)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で5人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 5
	RETURN 0
;ターゲットはプレイヤーの倍まで
SIF MTAR_NUM <= 0 || MTAR_NUM > MPLY_NUM * 2
	RETURN 0

FOR LOCAL:0, 0, MPLY_NUM
	FOR LOCAL:1, 0, MTAR_NUM
		SIF !CAN_REACH_GROIN(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) 
			RETURN 0
	NEXT
NEXT

FOR LOCAL:0, 0, MTAR_NUM
	;a occupied except by a vibrator
	SIF IS_A_HOLD(MTAR:(LOCAL:0)) && !IS_EQUIP_TARGET(MTAR:(LOCAL:0), 62)
		RETURN 0
	;If any target has a vibe inserted, then they all must
	SIF IS_EQUIP_TARGET(MTAR:0, 62) != IS_EQUIP_TARGET(MTAR:(LOCAL:0), 62)
		RETURN 0
NEXT

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM4
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
	CASE 4
		TIMES LOCAL:10, 0.50
	CASE 5
		TIMES LOCAL:10, 0.45
ENDSELECT

SELECTCASE MTAR_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 100

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 200)
	SOURCE:(LOCAL:2):接触 = 60
	SOURCE:(LOCAL:2):性行動 = 90

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 120, 60)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		LOCAL:4 = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1200) * LOCAL:10 / 100

		SOURCE:(LOCAL:3):快Ａ += LOCAL:4

	NEXT
NEXT

;全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:1):体力 += 60

	SOURCE:(LOCAL:1):露出 = 120
	SOURCE:(LOCAL:1):接触 = 60
	SOURCE:(LOCAL:1):性行動 = 90

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 70, 100)


NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 2

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP4
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP4(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_TARGET_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 20

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 60)
	SOURCE:(LOCAL:2):接触 += 30
	SOURCE:(LOCAL:2):性行動 += 30

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(ARG:0)
		LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:1)
		SOURCE:(LOCAL:3):快Ａ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 400) * LOCAL:10 / 100

	NEXT

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 2
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):露出 += 40
	SOURCE:(LOCAL:2):接触 += 30
	SOURCE:(LOCAL:2):性行動 += 30

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 2
NEXT
```
