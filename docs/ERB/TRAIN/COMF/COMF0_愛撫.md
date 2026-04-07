# TRAIN/COMF/COMF0_愛撫.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF0_愛撫.ERB`

类型: .ERB

自动摘要: functions: COM_NAME0, COM_ABLE0, COM0, COM_IS_EQUIP0, COM_EQUIP0, EQUIP_MESSAGE0, COM_TEXT_BEFORE_EQUIP0, COM_TEXT_RELEASE_EQUIP0, COM_ORDER_PLAYER0, COM_TEXT_BEFORE0, COM_TEXT_LAST0, COM_AVAILABLE_WHEN0, COM_PREFERENCE_PLAYER_0, COM_PREFERENCE_TARGET_0; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;愛撫

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME0
IF MTAR_NUM >= 2
	LOCALS:0 = 同時愛撫
ELSEIF MPLY_NUM >= 2
	LOCALS:0 = 一斉愛撫
ELSE
	LOCALS:0 = 愛撫
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
@COM_ABLE0
CALL COM_ABLE_COMMON(0)
SIF RESULT == 0
	RETURN 0
;1+
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
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM0
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

;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 100

	EXP:(LOCAL:2):性技経験値 += MAX(MTAR_NUM / 2 + 1, 1)

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 100)
	SOURCE:(LOCAL:2):接触 = 100
	SOURCE:(LOCAL:2):性行動 = 90

	;主人公がターゲットなら愛情のソース追加
	IF IS_MTAR(MASTER)
		CALL ADD_SOURCE_AIZYOU(LOCAL:2, 50)
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 100, 20)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1200) * LOCAL:10 / 100

	NEXT
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 60

	SOURCE:(LOCAL:2):露出 = 100
	SOURCE:(LOCAL:2):接触 = 100
	SOURCE:(LOCAL:2):性行動 = 180

	;主人公がプレイヤーなら愛情のソース追加
	IF IS_MPLY(MASTER)
		CALL ADD_SOURCE_AIZYOU(LOCAL:2, 100)
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 0)


NEXT

;1-1のときのみキスを追加
IF MPLY_NUM == 1 && MTAR_NUM == 1
	;どちらもキス未経験でない and 口が絡む行為を行っていない and キスができない態勢ではない
	IF !TALENT:(MPLY:0):キス未経験 && !TALENT:(MTAR:0):キス未経験 && !IS_EQUIP_PLAYER(MPLY:0, 2, 11, 12, 20, 104) && !IS_EQUIP_PLAYER(MTAR:0, 2, 11, 12, 20, 104) && !IS_RIDDEN(MPLY:0) && !IS_RIDDEN(MTAR:0)
		TFLAG:17 = 1

		EXP:(MPLY:0):キス経験 += 1
		EXP:(MTAR:0):キス経験 += 1

		SOURCE:(MPLY:0):快Ｍ = SENSE_HOUSHI(MTAR:0, MPLY:0, 100)
		SOURCE:(MTAR:0):快Ｍ = SENSE_HOUSHI(MPLY:0, MTAR:0, 100)

		SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(LOCAL:2, 50)

		TIMES SOURCE:(MPLY:0):愛情, 2.00
		TIMES SOURCE:(MTAR:0):愛情, 2.00
	ENDIF
ENDIF

;●全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	;挿入中だと性能低下
	IF IS_INSERT_SINGLE(LOCAL:1, "全")
		TIMES SOURCE:(LOCAL:1):快Ｃ, 0.80
	ENDIF
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
@COM_IS_EQUIP0
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP0(ARG:0)
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
```
