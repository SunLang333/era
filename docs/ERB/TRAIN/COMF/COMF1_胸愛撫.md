# TRAIN/COMF/COMF1_胸愛撫.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF1_胸愛撫.ERB`

类型: .ERB

自动摘要: functions: COM_NAME1, COM_ABLE1, COM1, COM_IS_EQUIP1, COM_EQUIP1, EQUIP_MESSAGE1, COM_TEXT_BEFORE_EQUIP1, COM_TEXT_RELEASE_EQUIP1, COM_ORDER_PLAYER1, COM_TEXT_BEFORE1, COM_TEXT_LAST1, COM_AVAILABLE_WHEN1, COM_PREFERENCE_PLAYER_1, COM_PREFERENCE_TARGET_1; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;胸愛撫

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME1
IF TALENT:(MTAR:0):母乳体質
	LOCALS:1 = 搾乳
ELSEIF IS_FEMALE(MTAR:0) || (MTAR_NUM == 2 && IS_FEMALE(MTAR:1))
	LOCALS:1 = 胸愛撫
ELSE
	LOCALS:1 = 乳首責め
ENDIF

IF MTAR_NUM >= 2
	LOCALS:0 = 同時%LOCALS:1%
ELSE
	LOCALS:0 = %LOCALS:1%
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
@COM_ABLE1
;共通部分
CALL COM_ABLE_COMMON(1)
SIF RESULT == 0
	RETURN 0
;1+ players
SIF MPLY_NUM <= 0
	RETURN 0
;ターゲットはプレイヤーの倍まで
SIF MTAR_NUM <= 0 || MTAR_NUM > MPLY_NUM * 2
	RETURN 0

FOR LOCAL:0, 0, MPLY_NUM
	FOR LOCAL:1, 0, MTAR_NUM
		SIF !CAN_REACH_BODY(MPLY:(LOCAL:0),MTAR:(LOCAL:1)) 
			RETURN 0
	NEXT
NEXT

FOR LOCAL:0, 0, MTAR_NUM
    ;breasts occupied - tentacle B caress
	SIF IS_EQUIP_TARGET(MTAR:(LOCAL:0), 204)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM1
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

SELECTCASE MTAR_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 100

	EXP:(LOCAL:2):性技経験値 += MAX(MTAR_NUM / 2 + 1, 1)

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 200)
	SOURCE:(LOCAL:2):接触 = 60
	SOURCE:(LOCAL:2):性行動 = 90

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 100, 40)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｂ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1200) * LOCAL:10 / 100

	NEXT
NEXT

;全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:1):体力 += 60

	SOURCE:(LOCAL:1):露出 = 100
	SOURCE:(LOCAL:1):接触 = 60
	SOURCE:(LOCAL:1):性行動 = 180

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 80, 0)

NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = -1

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP1
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP1(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_PLAYER_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
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


	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 60)
	SOURCE:(LOCAL:2):接触 += 30
	SOURCE:(LOCAL:2):性行動 += 30

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(ARG:0)
		LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｂ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 400) * LOCAL:10 / 100

	NEXT

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 -= 1
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):露出 += 50
	SOURCE:(LOCAL:2):接触 += 30
	SOURCE:(LOCAL:2):性行動 += 60


	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 -= 1
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE1(ARG:0)
LOCAL:2 = 0
```
