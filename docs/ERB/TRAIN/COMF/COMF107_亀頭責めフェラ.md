# TRAIN/COMF/COMF107_亀頭責めフェラ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF107_亀頭責めフェラ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME107, COM_ABLE107, COM107, COM_IS_EQUIP107, COM_EQUIP107, EQUIP_MESSAGE107, COM_TEXT_BEFORE_EQUIP107, COM_TEXT_RELEASE_EQUIP107, COM_ORDER_PLAYER107, COM_TEXT_BEFORE107, COM_AVAILABLE_WHEN107, COM_PREFERENCE_PLAYER_107, COM_PREFERENCE_TARGET_107, COM_STACK_SPERM_MTAR_TO_MPLY_107; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;亀頭責めフェラ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME107
IF SEARCH_EQUIP(12, MPLY:0, MTAR:0) >= 0
	IF MPLY_NUM == 3
		LOCALS:0 = Ｔパイズリフェラ
	ELSEIF MPLY_NUM == 2
		LOCALS:0 = Ｗパイズリフェラ
	ELSE
		LOCALS:0 = パイズリフェラ
	ENDIF
ELSEIF MPLY_NUM == 3
	LOCALS:0 = Ｔ亀頭責めフェラ
ELSEIF MPLY_NUM == 2
	LOCALS:0 = Ｗ亀頭責めフェラ
ELSE
	LOCALS:0 = 亀頭責めフェラ
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
@COM_ABLE107
;共通部分
CALL COM_ABLE_COMMON(107)
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
	SIF !P_STACKABLE(MPLY:(LOCAL:0), MTAR:0, 107)
		RETURN 0
	SIF !CAN_LICK_GROIN(MPLY:(LOCAL:0), MTAR:0)
		RETURN 0
NEXT

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM107
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

	DOWNBASE:(LOCAL:2):体力 += 120

	EXP:(LOCAL:2):性技経験値 += 1
	EXP:(LOCAL:2):口淫経験 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 350)
	SOURCE:(LOCAL:2):接触 = 50
	SOURCE:(LOCAL:2):性行動 = 300
	SOURCE:(LOCAL:2):快Ｍ = 150 * COM11_RATE_M(LOCAL:2) / 1000

	IF IS_INITIATIVE(LOCAL:2)
		SOURCE:(LOCAL:2):嗜虐 = 50
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 180, 100)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		LOCAL:4 = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1400) * LOCAL:10 / 100
		IF TALENT:(LOCAL:2):舌使い
			TIMES LOCAL:4, 1.50
		ENDIF
		SOURCE:(LOCAL:3):快Ｐ += LOCAL:4
;		SOURCE:(LOCAL:3):快Ｃ += LOCAL:4

	NEXT

	IF HAS_PENIS(MTAR:0)
		;ペニスへのキス
		CALL KISS_COMMON(LOCAL:2, @"%ANAME(MTAR:0)%のペニス", GET_SITUATION_BY_TRAIN_MODE())
	ENDIF
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	SOURCE:(LOCAL:1):接触 = 50
	SOURCE:(LOCAL:1):性行動 = 180

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 110, 120)
NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 1

;レズ・ＢＬ経験基準値
TFLAG:51 = 7

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP107
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP107(ARG:0)
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
	EXP:(LOCAL:2):口淫経験 += 1

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
	SOURCE:(LOCAL:2):接触 += 25
	SOURCE:(LOCAL:2):性行動 += 100
	SOURCE:(LOCAL:2):快Ｍ += 50 * COM11_RATE_M(LOCAL:2) / 1000

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(ARG:0)
		LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:1)
		LOCAL:4 = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 600) * LOCAL:10 / 100
		IF TALENT:(LOCAL:3):舌使い
			TIMES LOCAL:4, 1.50
		ENDIF
;		SOURCE:(LOCAL:3):快Ｃ += LOCAL:4
		SOURCE:(LOCAL:3):快Ｐ += LOCAL:4

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
@EQUIP_MESSAGE107(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に亀頭責めフェラ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP107(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の亀頭を舐め回している…
```
