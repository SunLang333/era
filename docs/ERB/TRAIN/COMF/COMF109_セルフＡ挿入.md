# TRAIN/COMF/COMF109_セルフＡ挿入.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF109_セルフＡ挿入.ERB`

类型: .ERB

自动摘要: functions: COM_NAME109, COM_ABLE109, COM109, COM_IS_EQUIP109, COM_EQUIP109, EQUIP_MESSAGE109, COM_TEXT_BEFORE_EQUIP109, COM_TEXT_RELEASE_EQUIP109, COM_ORDER_PLAYER109, COM_TEXT_BEFORE109, COM_TEXT_LAST109, COM_AVAILABLE_WHEN109, COM_PREFERENCE_PLAYER_109, COM_PREFERENCE_TARGET_109, COM_STACK_SPERM_MPLY_TO_MPLY_109; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;尻尾A挿入

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME109
LOCALS:0 = セルフＡ挿入

RESULTS:0 = %LOCALS:0%を見せつける
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%を見せつけられる
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE109
;共通部分
CALL COM_ABLE_COMMON(109)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人以上
SIF MPLY_NUM <= 0
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0

SIF ITEM:スキマ == 0
	RETURN 0

FOR LOCAL, 0, MPLY_NUM
	;プレイヤーが行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:LOCAL)
		RETURN 0
	;実行者に竿がなく、ペニスバンド装着中でもないと不可
	SIF !HAS_PENIS(MPLY:0) && !IS_EQUIP_PLAYER(MPLY:0, 50)
		RETURN 0
	;プレイヤーが足コキ・電気按摩中なら不可
	SIF IS_EQUIP_PLAYER(MPLY:LOCAL, 14, 103)
		RETURN 0
	;プレイヤーのＡが埋まっているなら不可
	SIF IS_A_HOLD(MPLY:LOCAL)
		RETURN 0
	;プレイヤーのチンポが埋まってるなら駄目
	SIF IS_P_HOLD(MPLY:0)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM109
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;各プレイヤーの絡むセルフ挿入・セルフA挿入の継続状態を解除
;FOR LOCAL:0, 0, MPLY_NUM
;	CALL RELEASE_EQUIP_EX(109, MPLY:(LOCAL:0), -1)
;	CALL RELEASE_EQUIP_EX(109, MPLY:(LOCAL:0), -1)
;NEXT

;●全てのプレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):自慰経験値 += 3

	SOURCE:(LOCAL:2):露出 = 1200
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

	EXP:(LOCAL:2):性交経験値 += 2

	SOURCE:(LOCAL:2):快Ｐ = SENSE_SEX_PLAYER_P(LOCAL:2, LOCAL:2, LOCAL:3)
	SOURCE:(LOCAL:2):露出 = 100
	SOURCE:(LOCAL:2):性行動 = 450

	;性交系の共通処理
	CALL COM_COMMON_ASEX_P(LOCAL:2, LOCAL:2)

	SOURCE:(LOCAL:2):快Ａ += SENSE_SEX_TARGET((LOCAL:2), (LOCAL:2), LOCAL:3)

	CALL COM_COMMON_ASEX_A(LOCAL:2, LOCAL:2)


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
@COM_IS_EQUIP109
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP109(ARG:0)
;●全プレイヤーについて処理
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	EXP:(LOCAL:2):自慰経験値 += 1
	EXP:(LOCAL:2):性技経験値 += 1
	EXP:(LOCAL:2):性交経験値 += 1

	SOURCE:(LOCAL:2):快Ｐ += SENSE_SEX_PLAYER_P(LOCAL:2, LOCAL:2, 750)
	SOURCE:(LOCAL:2):露出 += 600
	SOURCE:(LOCAL:2):性行動 += 150

	;性交系の共通処理
	CALL COM_COMMON_ASEX_P(LOCAL:2, LOCAL:2)

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

	SOURCE:(LOCAL:2):快Ａ = SENSE_SEX_TARGET(LOCAL:2, LOCAL:2, LOCAL:3)
	CALL COM_COMMON_ASEX_A(LOCAL:2, LOCAL:2)
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)
	SOURCE:(LOCAL:2):性行動 += 40
NEXT

;-------------------------------------------------
;継続中の表示
```
