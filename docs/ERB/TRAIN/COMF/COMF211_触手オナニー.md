# TRAIN/COMF/COMF211_触手オナニー.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF211_触手オナニー.ERB`

类型: .ERB

自动摘要: functions: COM_NAME211, COM_ABLE211, COM211, COM_IS_EQUIP211, COM_EQUIP211, EQUIP_MESSAGE211, COM_TEXT_BEFORE_EQUIP211, COM_TEXT_RELEASE_EQUIP211, COM_ORDER_PLAYER211, COM_TEXT_BEFORE211, COM_TEXT_LAST211, COM_AVAILABLE_WHEN211, COM_PREFERENCE_PLAYER_211, COM_PREFERENCE_TARGET_211, COM_STACK_SPERM_MPLY_TO_MPLY_211; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手オナニー

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME211
LOCALS:0 = 触手オナニー

RESULTS:0 = %LOCALS:0%見せつけ
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%を見せつけられる
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE211
;共通部分
CALL COM_ABLE_COMMON(211)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人以上
SIF MPLY_NUM <= 0
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0) && !FLAG:RECHECKING
	RETURN 0
;多対多は不可
SIF MPLY_NUM >= 2 && MTAR_NUM >= 2
	RETURN 0
;プレイヤーが触手召喚中でないなら不可
SIF !IS_EQUIP_PLAYER(MPLY:0, 200)
	RETURN 0
;todo. Should honestly be split into two actions
;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;todo this action really needs to be split into penis masturbation and vaginal masturbation to make sense
	SIF !(HAS_VAGINA(MPLY:LOCAL) || (HAS_PENIS(MPLY:LOCAL) && P_STACKABLE(MPLY:0, MPLY:0, 211)))
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM211
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●全てのプレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):性技経験値 += 1
	EXP:(LOCAL:2):妖術経験値 += 1
	EXP:(LOCAL:2):触手経験値 += 2
	EXP:(LOCAL:2):自慰経験値 += 3

	SOURCE:(LOCAL:2):露出 = 1200 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 600)
	SOURCE:(LOCAL:2):触手 = 300 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:2):逸脱 = 300 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:2):性行動 = 240 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 120)

	LOCAL:3 = 400 + ABL:(LOCAL:2):妖術 * 4

	SELECTCASE ABL:(LOCAL:2):自慰
		CASE 0
			TIMES LOCAL:3, 1.00
		CASE 1
			TIMES LOCAL:3, 1.20
		CASE 2
			TIMES LOCAL:3, 1.50
		CASE 3
			TIMES LOCAL:3, 1.80
		CASE 4
			TIMES LOCAL:3, 2.00
		CASEELSE
			LOCAL:3 = LOCAL:3 * (420 + (ABL:(LOCAL:2):自慰 - 5)) / 200
	ENDSELECT

	IF HAS_PENIS(LOCAL:2)
		SOURCE:(LOCAL:2):快Ｐ = SENSE_HOUSHI_P(LOCAL:2, LOCAL:2, LOCAL:3 * 3 / 2) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
	ELSE
		SOURCE:(LOCAL:2):快Ｃ = SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
		SOURCE:(LOCAL:2):快Ｂ = SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3 / 2) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 80, 120)

NEXT

;主導権の所在を取得
LOCAL:11 = GET_COM_INITIATIVE()

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	SOURCE:(LOCAL:1):触手 = 50
	SOURCE:(LOCAL:1):性行動 = 120

	;ターゲットに主導権
	IF LOCAL:11 == 1 || LOCAL:11 == 2
		SOURCE:(LOCAL:1):嗜虐 = 60
	;ターゲットに主導権がない
	ELSE
		SOURCE:(LOCAL:1):逸脱 = 150
		SOURCE:(LOCAL:1):恐怖 = MAX(200 - 30 * ABL:(LOCAL:1):欲望 - 60 * ABL:(LOCAL:1):触手, 0)
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 90, 90)
NEXT

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 4

;レズ・ＢＬ経験基準値
TFLAG:51 = 1

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP211
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP211(ARG:0)
;●全プレイヤーについて処理
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	EXP:(LOCAL:2):自慰経験値 += 1

	SOURCE:(LOCAL:2):露出 += 600 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 300)
	SOURCE:(LOCAL:2):触手 += 100 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 50)
	SOURCE:(LOCAL:2):逸脱 += 100 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 50)
	SOURCE:(LOCAL:2):性行動 += 80 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 40)

	LOCAL:3 = 400 + ABL:(LOCAL:2):妖術 * 4

	SELECTCASE ABL:(LOCAL:2):自慰
		CASE 0
			TIMES LOCAL:3, 1.00
		CASE 1
			TIMES LOCAL:3, 1.20
		CASE 2
			TIMES LOCAL:3, 1.50
		CASE 3
			TIMES LOCAL:3, 1.80
		CASE 4
			TIMES LOCAL:3, 2.00
		CASEELSE
			LOCAL:3 = LOCAL:3 * (420 + (ABL:(LOCAL:2):自慰 - 5)) / 200
	ENDSELECT

	IF HAS_PENIS(LOCAL:2)
		SOURCE:(LOCAL:2):快Ｐ = SENSE_HOUSHI_P(LOCAL:2, LOCAL:2, LOCAL:3 * 3 / 2)  + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
	ELSE
		SOURCE:(LOCAL:2):快Ｃ = SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
		SOURCE:(LOCAL:2):快Ｂ = SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3 / 2) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
	ENDIF

NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	SOURCE:(LOCAL:2):性行動 += 40
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE211(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が触手オナニー中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP211(ARG:0)
LOCAL:1 = 1
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
```
