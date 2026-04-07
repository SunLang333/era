# TRAIN/COMF/COMF20_キス.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF20_キス.ERB`

类型: .ERB

自动摘要: functions: COM_NAME20, COM_ABLE20, COM20, COM_IS_EQUIP20, COM_EQUIP20, EQUIP_MESSAGE20, COM_TEXT_BEFORE_EQUIP20, COM_TEXT_RELEASE_EQUIP20, COM_ORDER_PLAYER20, COM_ORDER_TARGET20, COM_ORDER_COMMON20, COM_TEXT_BEFORE20, COM_AVAILABLE_WHEN20, COM_PREFERENCE_PLAYER_20, COM_PREFERENCE_TARGET_20; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;キス

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME20
IF MTAR_NUM >= 2 || MPLY_NUM >= 2
	LOCALS:0 = Ｗキス
ELSE
	LOCALS:0 = キス
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
@COM_ABLE20
;共通部分
CALL COM_ABLE_COMMON(20)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で2人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 2
	RETURN 0
;ターゲットは最大で2人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 2
	RETURN 0
;2-2は不可
SIF MPLY_NUM == 2 && MTAR_NUM == 2
	RETURN 0
FOR LOCAL:0, 0, MPLY_NUM
	SIF IS_M_HOLD(MPLY:(LOCAL:0))
		RETURN 0
NEXT
FOR LOCAL:0, 0, MTAR_NUM
	SIF IS_M_HOLD(MTAR:(LOCAL:0))
		RETURN 0
NEXT
FOR LOCAL:0, 0, MPLY_NUM
	FOR LOCAL:1, 0, MTAR_NUM
        ;unconscious
		SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
			RETURN 0
        ;both bound
		SIF (IS_BIND(MPLY:(LOCAL:0)) && IS_BIND(MTAR:(LOCAL:0)))
			RETURN 0
        ;giving/receiving tribadism, doubleidlo, trampling, footlicking, footjob)
		SIF SEARCH_EQUIP_IC_M(MPLY:(LOCAL:0), MTAR:(LOCAL:0), 21, 22, 103, 104, 14) >= 0
			RETURN 0
        ;one participant grovelling, but not the other
		SIF (IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 110) + IS_EQUIP_PLAYER(MTAR:(LOCAL:0), 110)) == 1
			RETURN 0
	NEXT
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM20
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

;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 60

	EXP:(LOCAL:2):性技経験値 += MTAR_NUM / 2 + 1
	EXP:(LOCAL:2):キス経験 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 100)
	SOURCE:(LOCAL:2):接触 = 50
	SOURCE:(LOCAL:2):性行動 = 90

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 30)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1
	IF MTAR_NUM == 1
		;ペニスへのキス
		CALL KISS_COMMON(LOCAL:2, @"%ANAME(MTAR:0)%の唇", GET_SITUATION_BY_TRAIN_MODE())
	ELSE
		CALL KISS_COMMON(LOCAL:2, @"%ANAME(MTAR:0)%たちの唇", (GET_SITUATION_BY_TRAIN_MODE() == "和姦" ? "乱交" # "輪姦"))
	ENDIF	

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｍ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1000) * LOCAL:10 / 100
	NEXT
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 60

	EXP:(LOCAL:2):性技経験値 += MPLY_NUM / 2 + 1
	EXP:(LOCAL:2):キス経験 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 100)
	SOURCE:(LOCAL:2):接触 = 50
	SOURCE:(LOCAL:2):性行動 = 90

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 30)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	CALL KISS_COMMON(LOCAL:2, @"%ANAME(MPLY:0)%の唇", GET_SITUATION_BY_TRAIN_MODE())

	;全プレイヤーに与える快感系ソースを計算
	FOR LOCAL:1, 0, MPLY_NUM
		LOCAL:3 = MPLY:(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｍ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1000) * LOCAL:10 / 100
	NEXT
NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = -2

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP20
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP20(ARG:0)
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

	DOWNBASE:(LOCAL:2):体力 += 10

	EXP:(LOCAL:2):性技経験値 += MAX(MEQUIP_TARGET_NUM:(ARG:0) / 2 + 1, 1)
	EXP:(LOCAL:2):キス経験 += 1

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 40)
	SOURCE:(LOCAL:2):接触 += 25
	SOURCE:(LOCAL:2):性行動 += 30

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 -= 2

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(ARG:0)
```
