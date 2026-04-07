# TRAIN/COMF/COMF142_浣腸＆プラグ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF142_浣腸＆プラグ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME142, COM_ABLE142, COM142, COM_IS_EQUIP142, COM_EQUIP142, EQUIP_MESSAGE142, COM_TEXT_BEFORE_EQUIP142, COM_TEXT_RELEASE_EQUIP142, COM_ORDER_PLAYER142, COM_TEXT_BEFORE142, COM_TEXT_LAST142, COM_AVAILABLE_WHEN142, COM_PREFERENCE_PLAYER_142, COM_PREFERENCE_TARGET_142; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;浣腸＆プラグ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME142
LOCALS:0 = 浣腸＆プラグ

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE142
;共通部分
CALL COM_ABLE_COMMON(142)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは一人以上
SIF MTAR_NUM <= 0
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0) && !FLAG:RECHECKING
	RETURN 0
;浣腸が必要
SIF ITEM:浣腸 <= 0 && ITEM:A_浣腸 <= 0
	RETURN 0
;プレイヤーが拘束中なら不可
SIF IS_BIND(MPLY:0) && !FLAG:RECHECKING
	RETURN 0
FOR LOCAL, 0, MTAR_NUM
	LOCAL:1 = MTAR:LOCAL
	;ケツ塞がってたらダメ
	SIF IS_A_HOLD(LOCAL:1)
		RETURN 0
	SIF IS_EQUIP_TARGET(LOCAL:1, 142)
		RETURN 0
	SIF !CAN_REACH_GROIN(MPLY:0, LOCAL:1) && !FLAG:RECHECKING
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM142
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;主導権の所在を取得
LOCAL:11 = GET_COM_INITIATIVE()

;●プレイヤー側の処理
SOURCE:(MPLY:0):性行動 = 90

;プレイヤーに主導権
IF LOCAL:11 == 0 || LOCAL:11 == 2
	SOURCE:(MPLY:0):嗜虐 = 200
	SOURCE:(MPLY:0):逸脱 = 300
;プレイヤーに主導権がない
ELSE
	SOURCE:(MPLY:0):逸脱 = 600
	SOURCE:(MPLY:0):恐怖 = MAX(150 - 40 * ABL:(MPLY:0):欲望, 0)
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 100, 80)

;●ターゲット側の処理
FOR LOCAL, 0, MTAR_NUM
	LOCAL:1 = MTAR:LOCAL
	LOCAL:3 = 1000
	LOCAL:4 = 600

	SELECTCASE ABL:(LOCAL:1):排泄
		CASE 0
			TIMES LOCAL:3, 0.00
			TIMES LOCAL:4, 1.00
		CASE 1
			TIMES LOCAL:3, 0.10
			TIMES LOCAL:4, 0.60
		CASE 2
			TIMES LOCAL:3, 0.20
			TIMES LOCAL:4, 0.25
		CASE 3
			TIMES LOCAL:3, 0.40
			TIMES LOCAL:4, 0.05
		CASE 4
			TIMES LOCAL:3, 0.70
			TIMES LOCAL:4, 0.00
		CASEELSE
			LOCAL:3 = LOCAL:3 * (100 + (ABL:(LOCAL:1):排泄 - 5) * 2) / 100
			LOCAL:4 = 0
	ENDSELECT

	SOURCE:(LOCAL:1):露出 = 1400
	SOURCE:(LOCAL:1):逸脱 = 600
	SOURCE:(LOCAL:1):中毒充足 = LOCAL:3
	SOURCE:(LOCAL:1):反感 = LOCAL:4
	SOURCE:(LOCAL:1):性行動 = 150

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 80, 170)

	;屁残量をゼロにする
	TCVAR:(LOCAL:1):55 = 0
NEXT

;主導度変化基準値
TFLAG:49 = 1

;倒錯度変化基準値
TFLAG:50 = 6

;レズ・ＢＬ経験基準値
TFLAG:51 = 0

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP142
;継続コマンドかつフィルタリング不可
RETURN 2

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP142(ARG:0)
FOR LOCAL, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):LOCAL

	LOCAL:5 = 500
	LOCAL:6 = 300

	SELECTCASE ABL:(LOCAL:3):排泄
		CASE 0
			TIMES LOCAL:5, 0.00
			TIMES LOCAL:6, 1.00
		CASE 1
			TIMES LOCAL:5, 0.10
			TIMES LOCAL:6, 0.60
		CASE 2
			TIMES LOCAL:5, 0.20
			TIMES LOCAL:6, 0.25
		CASE 3
			TIMES LOCAL:5, 0.40
			TIMES LOCAL:6, 0.05
		CASE 4
			TIMES LOCAL:5, 0.70
			TIMES LOCAL:6, 0.00
		CASEELSE
			LOCAL:5 = LOCAL:5 * (100 + (ABL:(MTAR:0):排泄 - 5) * 2) / 100
			LOCAL:6 = 0
	ENDSELECT

	SOURCE:(LOCAL:3):苦痛 += 80
	SOURCE:(LOCAL:3):逸脱 += 200
	SOURCE:(LOCAL:3):中毒充足 += LOCAL:5
	SOURCE:(LOCAL:3):反感 += LOCAL:6

	IF GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_マゾ)
		SOURCE:(LOCAL:3):中毒充足 += 300
	ENDIF

;倒錯度変化
	TCVAR:(LOCAL:3):50 += 4
NEXT
;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE142(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%のアナルにプラグを挿入中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP142(ARG:0)
PRINTFORML %EQUIP_TARGET_ANAME(ARG:0)%はプラグで肛門をせき止められ、苦しそうにしている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP142(ARG:0)

LOCAL:2 = MEQUIP_TURN:(ARG:0) / 2 + 2

PRINTFORMW %ANAME(MEQUIP_TARGET:(ARG:0):0, MEQUIP_TARGET_NUM:(ARG:0))%の肛門からプラグを引き抜いた

```
