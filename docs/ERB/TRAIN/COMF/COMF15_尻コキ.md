# TRAIN/COMF/COMF15_尻コキ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF15_尻コキ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME15, COM_ABLE15, COM15, COM_IS_EQUIP15, COM_EQUIP15, EQUIP_MESSAGE15, COM_TEXT_BEFORE_EQUIP15, COM_TEXT_RELEASE_EQUIP15, COM_ORDER_PLAYER15, COM_TEXT_BEFORE15, COM_AVAILABLE_WHEN15, COM_PREFERENCE_PLAYER_15, COM_PREFERENCE_TARGET_15, COM_STACK_SPERM_MTAR_TO_MPLY_15; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;尻コキ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME15
LOCALS:0 = 尻コキ

IF MPLY_NUM == 2 && MTAR_NUM == 1
	LOCALS:0 = Ｗ尻コキ
ELSE
	LOCALS:0 = 尻コキ
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
@COM_ABLE15
;共通部分
CALL COM_ABLE_COMMON(15)
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
SIF !P_STACKABLE(MPLY:0, MTAR:0, 15)
	RETURN 0
;grovelling
SIF IS_EQUIP_PLAYER(MTAR:0, 110)
	RETURN 0

;全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
		RETURN 0
	;拘束中なら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
	;プレイヤーが挿入中なら不可
	SIF IS_INSERT_SINGLE(MPLY:(LOCAL:0), "全")
		RETURN 0
	SIF IS_RIDE(MPLY:(LOCAL:0)) || IS_RIDDEN(MPLY:(LOCAL:0))
		RETURN 0
	SIF IS_RIDE(MTAR:0) || IS_RIDDEN(MTAR:0)
		RETURN 0
    ;anal caress/ using Avibe
	SIF IS_EQUIP_TARGET(MPLY:(LOCAL:0), 4)
		RETURN 0
    ;grovelling
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL), 110)
		RETURN 0
    ;getting/receiving tribadism, double dildo, trampling, footlicking
	SIF (SEARCH_EQUIP_IC_M(MPLY:(LOCAL:0), MTAR:0, 21, 22, 103, 104) >= 0)
		RETURN 0
    ;receiving footjob, boobjob, buttjob from target
	SIF SEARCH_EQUIP_M(MTAR:0, MPLY:(LOCAL:0), 14, 12, 15) >= 0
		RETURN 0
	SIF REACHING_BODY(MPLY:(LOCAL:0), MTAR)
		RETURN 0
	SIF LICKING_GROIN(MPLY:(LOCAL:0), MTAR) || LICKING_GROIN(MTAR:0, MPLY:(LOCAL:0))
		RETURN 0
	SIF LICKING_BODY(MPLY:(LOCAL:0), MTAR) || LICKING_BODY(MTAR:0, MPLY:(LOCAL:0))
		RETURN 0
NEXT


RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM15
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	DOWNBASE:(MPLY:(LOCAL:0)):体力 += 120

	EXP:(MPLY:(LOCAL:0)):性技経験値 += MAX(MTAR_NUM / 2 + 1, 1)


	SOURCE:(MPLY:(LOCAL:0)):露出 = 50
	SOURCE:(MPLY:(LOCAL:0)):奉仕 = SERVE_HOUSHI(MPLY:(LOCAL:0), 300)
	SOURCE:(MPLY:(LOCAL:0)):接触 = 150
	SOURCE:(MPLY:(LOCAL:0)):逸脱 = 50
	SOURCE:(MPLY:(LOCAL:0)):性行動 = 240

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(MPLY:(LOCAL:0), 160, 90)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(MPLY:(LOCAL:0)):4 = 1

	SOURCE:(MTAR:0):快Ｐ += SENSE_HOUSHI_P(MPLY:(LOCAL:0), MTAR:0, 1350 + (TALENT:(MPLY:(LOCAL:0)):美尻 || GET_HIPSIZE(MPLY:(LOCAL:0)) >= 1) * 200)
NEXT


;●ターゲットについて判定
DOWNBASE:(MTAR:0):体力 += 60

SOURCE:(MTAR:0):接触 = 100
SOURCE:(MTAR:0):逸脱 = 50
SOURCE:(MTAR:0):性行動 = 180


;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 130, 100)

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 1

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP15
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP15(ARG:0)
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0




;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):LOCAL
	;●プレイヤーについて処理
	DOWNBASE:(LOCAL:2):体力 += 20

	EXP:(LOCAL:2):性技経験値 += MAX(MEQUIP_TARGET_NUM:(ARG:0) / 2 + 1, 1)

	SOURCE:(LOCAL:2):露出 += 25
	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
	SOURCE:(LOCAL:2):接触 += 75
	SOURCE:(LOCAL:2):逸脱 += 25
	SOURCE:(LOCAL:2):性行動 += 80

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1
	SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 450 + (TALENT:(LOCAL:2):美尻 || GET_HIPSIZE(LOCAL:2) >= 1) * 100)

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 1

NEXT

;●ターゲットについて処理
DOWNBASE:(LOCAL:3):体力 += 10

SOURCE:(LOCAL:3):接触 += 50
SOURCE:(LOCAL:3):逸脱 += 25
SOURCE:(LOCAL:3):性行動 += 60

;倒錯度変化基準値
TCVAR:(LOCAL:3):50 += 1

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE15(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に尻コキ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP15(ARG:0)
PRINTFORML %EQUIP_TARGET_ANAME(ARG:0)%が%EQUIP_PLAYER_ANAME(ARG:0)%のお尻でペニスを扱き上げている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP15(ARG:0)
```
