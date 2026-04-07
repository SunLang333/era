# TRAIN/COMF/COMF3_指挿入れ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF3_指挿入れ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME3, COM_ABLE3, COM3, COM_IS_EQUIP3, COM_EQUIP3, EQUIP_MESSAGE3, COM_TEXT_BEFORE_EQUIP3, COM_TEXT_RELEASE_EQUIP3, COM_ORDER_PLAYER3, COM_TEXT_BEFORE3, COM_TEXT_LAST3, COM_AVAILABLE_WHEN3, COM_PREFERENCE_PLAYER_3, COM_PREFERENCE_TARGET_3; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;指挿入れ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME3
IF IS_EQUIP_TARGET(MTAR:0, 61)
	IF MTAR_NUM >= 2
		LOCALS:0 = 同時バイブ責め
	ELSE
		LOCALS:0 = バイブ責め
	ENDIF
ELSE
	IF MTAR_NUM >= 2
		LOCALS:0 = 同時指挿入
	ELSE
		LOCALS:0 = 指挿入
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
@COM_ABLE3
;共通部分
CALL COM_ABLE_COMMON(3)
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
		SIF !CAN_REACH_GROIN(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) 
			RETURN 0
	NEXT
NEXT

FOR LOCAL:0, 0, MTAR_NUM
	SIF !HAS_VAGINA(MTAR:(LOCAL:0))
		RETURN 0
	;v occupied except by a vibrator
	SIF IS_V_HOLD(MTAR:(LOCAL:0)) && !IS_EQUIP_TARGET(MTAR:(LOCAL:0), 61)
		RETURN 0
	;If any target has a vibe inserted, then they all must
	SIF IS_EQUIP_TARGET(MTAR:0, 61) != IS_EQUIP_TARGET(MTAR:(LOCAL:0), 61)
		RETURN 0
NEXT

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM3
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MTAR_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 100

	EXP:(LOCAL:2):性技経験値 += MTAR_NUM / 2 + 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 200)
	SOURCE:(LOCAL:2):接触 = 60
	SOURCE:(LOCAL:2):性行動 = 180

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 100, 40)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		LOCAL:4 = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1200) * LOCAL:10 / 100

		;ターゲットが処女なら快感減少
		IF TALENT:(LOCAL:3):処女 == 1
			TIMES LOCAL:4, 0.75
		ENDIF

		SOURCE:(LOCAL:3):快Ｖ += LOCAL:4

	NEXT
NEXT

;全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:1):体力 += 60

	SOURCE:(LOCAL:1):露出 = 80
	SOURCE:(LOCAL:1):接触 = 60
	SOURCE:(LOCAL:1):性行動 = 300

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 50, 50)

	;無自覚処女なら処女喪失フラグを立てる
	IF TALENT:(LOCAL:1):処女 == 2
		IF IS_MPLY(MASTER)
			;処女喪失フラグ(主人に性交以外で奪われる)
			TCVAR:(LOCAL:1):13 = 2
		ELSE
			;処女喪失フラグ(主人以外に性交以外で奪われる)
			TCVAR:(LOCAL:1):13 = 4
		ENDIF
	ENDIF
NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP3
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP3(ARG:0)
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

	EXP:(LOCAL:2):性技経験値 += MAX(MEQUIP_TARGET_NUM:(ARG:0) / 2 + 1, 1)

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 60)
	SOURCE:(LOCAL:2):接触 += 30
	SOURCE:(LOCAL:2):性行動 += 60

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(ARG:0)
		LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｖ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 400) * LOCAL:10 / 100

	NEXT
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):露出 += 40
	SOURCE:(LOCAL:2):接触 += 30
	SOURCE:(LOCAL:2):性行動 += 100

NEXT
```
