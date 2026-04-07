# TRAIN/COMF/COMF5_泡踊り.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF5_泡踊り.ERB`

类型: .ERB

自动摘要: functions: COM_NAME5, COM_ABLE5, COM5, COM_IS_EQUIP5, COM_EQUIP5, EQUIP_MESSAGE5, COM_TEXT_BEFORE_EQUIP5, COM_TEXT_RELEASE_EQUIP5, COM_ORDER_PLAYER5, COM_TEXT_BEFORE5, COM_TEXT_LAST5, COM_AVAILABLE_WHEN5, COM_PREFERENCE_PLAYER_5, COM_PREFERENCE_TARGET_5; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;泡踊り

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME5
IF MPLY_NUM >= 2
	LOCALS:0 = サンドイッチ泡踊り
ELSE
	LOCALS:0 = 泡踊り
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
@COM_ABLE5
;共通部分
CALL COM_ABLE_COMMON(5)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で2人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 2
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;ローションが必要
SIF !ITEM:ローション && !ITEM:A_ローション
	RETURN 0

FOR LOCAL:0, 0, MPLY_NUM
	SIF !CAN_REACH_BODY(MPLY:(LOCAL:0) , MTAR:0)
		RETURN 0
	;fucking someone other than the target
	SIF IS_INSERT_SINGLE(MPLY:(LOCAL:0)) && IS_INSERT_MUTUAL(MPLY:(LOCAL:0), MTAR:0) == 0
		RETURN 0
	SIF IS_RIDE(MPLY:(LOCAL:0)) || IS_RIDDEN(MPLY:(LOCAL:0))
		RETURN 0
NEXT
SIF IS_RIDE(MTAR:0) || IS_RIDDEN(MTAR:0)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM5
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

SIF !ITEM:A_ローション
	ITEM:ローション -= 1

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

;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 400)
	SOURCE:(LOCAL:2):露出 = 50
	SOURCE:(LOCAL:2):接触 = 250
	SOURCE:(LOCAL:2):性行動 = 360

	IF HAS_PENIS(LOCAL:2)
		SOURCE:(LOCAL:2):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:2, 600)
	ELSE
		SOURCE:(LOCAL:2):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:2, 600)
	ENDIF
	SOURCE:(LOCAL:2):快Ｂ += SENSE_HOUSHI(LOCAL:2, LOCAL:2, 450)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 120, 100)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1
NEXT

;●ターゲットについて処理
SOURCE:(MTAR:0):露出 = 50
SOURCE:(MTAR:0):接触 = 250
SOURCE:(MTAR:0):性行動 = 360

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 120, 60)

FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:1 = MPLY:(LOCAL:0)

	IF HAS_PENIS(MTAR:0)
		SOURCE:(MTAR:0):快Ｐ += SENSE_HOUSHI_P(LOCAL:1, MTAR:0, 1200) * LOCAL:10 / 100
	ELSE
		SOURCE:(MTAR:0):快Ｃ += SENSE_HOUSHI(LOCAL:1, MTAR:0, 1200) * LOCAL:10 / 100
	ENDIF
	SOURCE:(MTAR:0):快Ｂ += SENSE_HOUSHI(LOCAL:1, MTAR:0, 900) * LOCAL:10 / 100

NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 8

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP5
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP5(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_PLAYER_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて処理
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
	SOURCE:(LOCAL:2):露出 += 20
	SOURCE:(LOCAL:2):接触 += 150
	SOURCE:(LOCAL:2):性行動 += 120

	IF HAS_PENIS(LOCAL:2)
		SOURCE:(LOCAL:2):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:2, 200)
	ELSE
		SOURCE:(LOCAL:2):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:2, 200)
	ENDIF
	SOURCE:(LOCAL:2):快Ｂ += SENSE_HOUSHI(LOCAL:2, LOCAL:2, 150)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1
NEXT

;●ターゲットについて処理
LOCAL:2 = MEQUIP_TARGET:(ARG:0):0

SOURCE:(LOCAL:2):露出 += 20
SOURCE:(LOCAL:2):接触 += 150
SOURCE:(LOCAL:2):性行動 += 120

FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:1 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	IF HAS_PENIS(LOCAL:2)
		SOURCE:(LOCAL:2):快Ｐ += SENSE_HOUSHI_P(LOCAL:1, LOCAL:2, 400) * LOCAL:10 / 100
	ELSE
		SOURCE:(LOCAL:2):快Ｃ += SENSE_HOUSHI(LOCAL:1, LOCAL:2, 400) * LOCAL:10 / 100
	ENDIF
	SOURCE:(LOCAL:2):快Ｂ += SENSE_HOUSHI(LOCAL:1, LOCAL:2, 300) * LOCAL:10 / 100
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE5(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に泡踊り中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP5(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に全身を擦りつけている…
```
