# TRAIN/COMF/COMF100_C自慰.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF100_C自慰.ERB`

类型: .ERB

自动摘要: functions: COM_NAME100, COM_ABLE100, COM100, COM_IS_EQUIP100, COM_EQUIP100, EQUIP_MESSAGE100, COM_TEXT_BEFORE_EQUIP100, COM_TEXT_RELEASE_EQUIP100, COM_ORDER_PLAYER100, COM_TEXT_BEFORE100, COM_TEXT_LAST100, COM_AVAILABLE_WHEN100, COM_PREFERENCE_PLAYER_100, COM_PREFERENCE_TARGET_100, COM_STACK_SPERM_MPLY_TO_MPLY_100, COM_STACK_SPERM_MPLY_TO_MTAR_100; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;自慰

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME100
LOCALS:0 = 
IF TFLAG:70 == 1
	LOCALS:0 = 撮影
ELSEIF TFLAG:104 >= 2
	LOCALS:0 = 公開
ELSEIF TFLAG:54 == 8
	LOCALS:0 = 野外
ENDIF

IF IS_EQUIP_TARGET(MPLY:0, 61) && IS_EQUIP_TARGET(MPLY:0, 62)
	LOCALS:0 '= LOCALS:0 + "両穴バイブ"
ELSEIF IS_EQUIP_TARGET(MPLY:0, 61)
	LOCALS:0 '= LOCALS:0 +"バイブ"
ELSEIF IS_EQUIP_TARGET(MPLY:0, 62)
	LOCALS:0 '= LOCALS:0 +"アナルバイブ"
ENDIF

LOCALS:0 '= LOCALS:0 + "オナニー"

RESULTS:0 = %LOCALS:0%を見せつける
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%を見せつけられる
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE100
;共通部分
CALL COM_ABLE_COMMON(100)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人以上
SIF MPLY_NUM <= 0
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;拘束中なら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
	;todo this action really needs to be split into penis masturbation and vaginal masturbation to make sense
	SIF !HAS_VAGINA(MPLY:LOCAL)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM100
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;各プレイヤーの絡む自慰・触手オナニーの継続状態を解除
FOR LOCAL:0, 0, MPLY_NUM
	CALL RELEASE_EQUIP_EX(100, MPLY:(LOCAL:0), -1)
	CALL RELEASE_EQUIP_EX(211, MPLY:(LOCAL:0), -1)
NEXT

;●全てのプレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):自慰経験値 += 3

	SOURCE:(LOCAL:2):露出 = 1300
	SOURCE:(LOCAL:2):逸脱 = 100
	SOURCE:(LOCAL:2):性行動 = 240

	LOCAL:3 = 500

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

	SIF GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_自慰狂い)
		TIMES LOCAL:3, 2.0

	SOURCE:(LOCAL:2):快Ｃ = SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3)
	SOURCE:(LOCAL:2):快Ｂ = SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3 / 2)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 120)


NEXT

;主導権の所在を取得
LOCAL:11 = GET_COM_INITIATIVE()

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	SOURCE:(LOCAL:1):性行動 = 120

	;ターゲットに主導権
	IF LOCAL:11 == 1 || LOCAL:11 == 2
		SOURCE:(LOCAL:1):嗜虐 = 60
	;ターゲットに主導権がない
	ELSE
		SOURCE:(LOCAL:1):逸脱 = 60
		SOURCE:(LOCAL:1):恐怖 = MAX(100 - 30 * ABL:(LOCAL:1):欲望, 0)
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 80, 80)
NEXT

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 1

;レズ・ＢＬ経験基準値
TFLAG:51 = 1

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP100
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP100(ARG:0)
;●全プレイヤーについて処理
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	EXP:(LOCAL:2):自慰経験値 += 1

	SIF IS_EQUIP_TARGET(LOCAL:2, 61)
		EXP:(LOCAL:2):自慰経験値 += 1

	SIF IS_EQUIP_TARGET(LOCAL:2, 62)
		EXP:(LOCAL:2):自慰経験値 += 1

	SOURCE:(LOCAL:2):露出 += 600
	SOURCE:(LOCAL:2):逸脱 += 50
	SOURCE:(LOCAL:2):性行動 += 80

	LOCAL:3 = 500

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

	SIF GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_自慰狂い)
		TIMES LOCAL:3, 2.0


	SOURCE:(LOCAL:2):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3)
	SOURCE:(LOCAL:2):快Ｂ += SENSE_HOUSHI(LOCAL:2, LOCAL:2, LOCAL:3 / 2)
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
```
