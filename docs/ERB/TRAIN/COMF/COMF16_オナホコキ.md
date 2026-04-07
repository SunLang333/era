# TRAIN/COMF/COMF16_オナホコキ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF16_オナホコキ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME16, COM_ABLE16, COM16, COM_IS_EQUIP16, COM_EQUIP16, EQUIP_MESSAGE16, COM_TEXT_BEFORE_EQUIP16, COM_TEXT_RELEASE_EQUIP16, COM_ORDER_PLAYER16, COM_TEXT_BEFORE16, COM_AVAILABLE_WHEN16, COM_PREFERENCE_PLAYER_16, COM_PREFERENCE_TARGET_16, COM_STACK_SPERM_MTAR_TO_MPLY_16; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;オナホコキ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME16
IF MPLY_NUM == 2
	LOCALS:0 = Ｗオナホコキ
ELSE
	LOCALS:0 = オナホコキ
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
@COM_ABLE16
;共通部分
CALL COM_ABLE_COMMON(16)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で2人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 2
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;オナホールが必要
SIF !ITEM:オナホール && !ITEM:A_オナホール
	RETURN 0
;全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
		RETURN 0
	;拘束中なら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
	SIF !CAN_REACH_BODY(MPLY:0, MTAR:0)
		RETURN 0
NEXT
;ターゲットに竿が必要
SIF !HAS_PENIS(MTAR:0)
	RETURN 0
SIF !P_STACKABLE(MPLY:0, MTAR:0, 16)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM16
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

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 250)
	SOURCE:(LOCAL:2):接触 = 40
	SOURCE:(LOCAL:2):性行動 = 210

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 160, 80)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	IF TALENT:(MPLY:0):技師
		LOCAL:11 = 2400
	ELSE
		LOCAL:11 = 1600
	ENDIF

	;ターゲットに与える快感系ソースを計算
	SOURCE:(MTAR:0):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, MTAR:0, LOCAL:11) * LOCAL:10 / 100

NEXT

;●ターゲットについて判定
SOURCE:(MTAR:0):接触 = 20
SOURCE:(MTAR:0):性行動 = 180

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 120, 60)

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
@COM_IS_EQUIP16
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP16(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_PLAYER_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):0
	EXP:(LOCAL:2):性技経験値 += MAX(MEQUIP_TARGET_NUM:(ARG:0) / 2 + 1, 1)

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 60)
	SOURCE:(LOCAL:2):接触 += 20
	SOURCE:(LOCAL:2):性行動 += 70

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	IF TALENT:(LOCAL:2):技師
		LOCAL:11 = 750
	ELSE
		LOCAL:11 = 500
	ENDIF

	;ターゲットに与える快感系ソースを計算
	SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, LOCAL:11) * LOCAL:10 / 100

NEXT

;●ターゲットについて判定
SOURCE:(LOCAL:3):接触 += 10
SOURCE:(LOCAL:3):性行動 += 60

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE16(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%にオナホコキ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP16(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%のペニスをオナホでシゴき上げている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP16(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER16(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 75

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)
CALL COM_ORDER_ELEMENT(ARG:0, @"精愛Lv{ABL:(ARG:0):精愛}", ABL:(ARG:0):精愛 * 1)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -1)
ENDIF
```
