# TRAIN/COMF/COMF171_尿道指挿入れ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF171_尿道指挿入れ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME171, COM_ABLE171, COM171, COM_IS_EQUIP171, COM_EQUIP171, EQUIP_MESSAGE171, COM_TEXT_BEFORE_EQUIP171, COM_TEXT_RELEASE_EQUIP171, COM_ORDER_PLAYER171, COM_TEXT_BEFORE171, COM_TEXT_LAST171, COM_AVAILABLE_WHEN171, COM_PREFERENCE_PLAYER_171, COM_PREFERENCE_TARGET_171; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;指挿入れ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME171
IF IS_EQUIP_TARGET(MTAR:0, GETNUM(TRAINNAME, "尿道ブジー"))
	IF MTAR_NUM >= 2
		LOCALS:0 = 同時尿道ブジー責め
	ELSE
		LOCALS:0 = 尿道ブジー責め
	ENDIF
ELSE
	IF MTAR_NUM >= 2
		LOCALS:0 = 同時尿道指挿入
	ELSE
		LOCALS:0 = 尿道指挿入
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
@COM_ABLE171
;共通部分
CALL COM_ABLE_COMMON(171)
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
	;v occupied except by a vibrator
	SIF IS_U_HOLD(MTAR:(LOCAL:0)) && !IS_EQUIP_TARGET(MTAR:(LOCAL:0), 170)
		RETURN 0
	;If any target has a vibe inserted, then they all must
	SIF IS_EQUIP_TARGET(MTAR:0, 170) != IS_EQUIP_TARGET(MTAR:(LOCAL:0), 170)
		RETURN 0
NEXT

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM171
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

		SOURCE:(LOCAL:3):快Ｕ += LOCAL:4

	NEXT
NEXT

;全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:1):体力 += 60

	SOURCE:(LOCAL:1):露出 = 80
	SOURCE:(LOCAL:1):接触 = 60
	SOURCE:(LOCAL:1):性行動 = 300
	SOURCE:(LOCAL:1):苦痛 = 600
	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 50, 50)
	EXP:(LOCAL:1):Ｕ開発経験 += 1
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
@COM_IS_EQUIP171
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP171(ARG:0)
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
		SOURCE:(LOCAL:3):快Ｕ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 400) * LOCAL:10 / 100

	NEXT
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10
	SOURCE:(LOCAL:2):苦痛 += 400
	SOURCE:(LOCAL:2):露出 += 40
	SOURCE:(LOCAL:2):接触 += 30
	SOURCE:(LOCAL:2):性行動 += 100
	EXP:(LOCAL:2):Ｕ開発経験 += 1
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE171(ARG:0)
IF IS_EQUIP_TARGET(MEQUIP_TARGET:(ARG:0):0, 61)
	RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%を尿道ブジー責め中
ELSE
	RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の尿道に指を挿入中
ENDIF

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP171(ARG:0)
IF IS_EQUIP_TARGET(MEQUIP_TARGET:(ARG:0):0, 61)
	PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の尿道に挿入されたブジーを前後させている…
ELSE
```
