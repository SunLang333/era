# TRAIN/COMF/COMF13_素股.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF13_素股.ERB`

类型: .ERB

自动摘要: functions: COM_NAME13, COM_ABLE13, COM13_RATE_C, COM13, COM_IS_EQUIP13, COM_EQUIP13, EQUIP_MESSAGE13, COM_TEXT_BEFORE_EQUIP13, COM_TEXT_RELEASE_EQUIP13, COM_ORDER_PLAYER13, COM_TEXT_BEFORE13, COM_TEXT_LAST13, COM_AVAILABLE_WHEN13, COM_PREFERENCE_PLAYER_13, COM_PREFERENCE_TARGET_13; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;素股

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME13

IF MPLY_NUM == 2
	LOCALS:0 = Ｗ
ELSE
	LOCALS:0 = 
ENDIF

IF !HAS_VAGINA(MPLY:0)
	LOCALS:0 += "玉ズリ"
ELSE
	LOCALS:0 += "素股"
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
@COM_ABLE13
;共通部分
CALL COM_ABLE_COMMON(13)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 2
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;潤滑が高くないとダメ
FOR LOCAL, 0, MPLY_NUM
	SIF PALAM:(MPLY:LOCAL):潤滑 < 1500
		RETURN 0
	SIF !HAS_PENIS(MTAR:0)
		RETURN 0
	SIF !CAN_FUCK(MTAR:0, MPLY:LOCAL, 13)
		RETURN 0
	SIF !P_STACKABLE(MPLY:LOCAL, MTAR:0, 13)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;快Ｃソースの倍率を取得する関数 ARG:0=PLAYERのキャラ番号
;-------------------------------------------------
@COM13_RATE_C(ARG:0)
#FUNCTION
LOCAL:5 = 1000
SELECTCASE ABL:(ARG:0):奉仕
	CASE 0
		TIMES LOCAL:5, 0.50
	CASE 1
		TIMES LOCAL:5, 0.80
	CASE 2
		TIMES LOCAL:5, 1.00
	CASE 3
		TIMES LOCAL:5, 1.20
	CASE 4
		TIMES LOCAL:5, 1.40
	CASEELSE
		LOCAL:5 = LOCAL:5 * ((ABL:(MPLY:0):奉仕 - 5) * 2 + 150) / 100
ENDSELECT

SELECTCASE ABL:(ARG:0):性技
	CASE 0
		TIMES LOCAL:5, 1.00
	CASE 1
		TIMES LOCAL:5, 1.10
	CASE 2
		TIMES LOCAL:5, 1.20
	CASE 3
		TIMES LOCAL:5, 1.30
	CASE 4
		TIMES LOCAL:5, 1.40
	CASEELSE
		LOCAL:5 = LOCAL:5 * ((ABL:(MPLY:0):性技 - 5) * 2 + 150) / 100
ENDSELECT

RETURNF LOCAL:5

;-------------------------------------------------
;素股
;-------------------------------------------------
@COM13
;実行できるかの判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;対Ｐ奉仕系コマンドの継続フラグを解除
CALL RELEASE_SERVE_P

;●プレイヤーの潤滑に応じた快感倍率の設定
IF PALAM:(MPLY:0):潤滑 < PALAMLV:5
	LOCAL:10 = 500
ELSEIF PALAM:(MPLY:0):潤滑 < PALAMLV:6
	LOCAL:10 = 700
ELSEIF PALAM:(MPLY:0):潤滑 < PALAMLV:7
	LOCAL:10 = 800
ELSEIF PALAM:(MPLY:0):潤滑 < PALAMLV:8
	LOCAL:10 = 900
ELSE
	LOCAL:10 = 1000
ENDIF

FOR LOCAL, 0, MPLY_NUM
	;●プレイヤーについて処理
	DOWNBASE:(MPLY:LOCAL):体力 += 120

	EXP:(MPLY:LOCAL):性技経験値 += 1

	SOURCE:(MPLY:LOCAL):奉仕 = SERVE_HOUSHI(MPLY:LOCAL, 350)
	SOURCE:(MPLY:LOCAL):露出 = 50
	SOURCE:(MPLY:LOCAL):接触 = 100
	SOURCE:(MPLY:LOCAL):性行動 = 300
	IF HAS_VAGINA(MPLY:LOCAL)
		SOURCE:(MPLY:LOCAL):快Ｃ = 500 * COM13_RATE_C(MPLY:LOCAL) / 1000 * LOCAL:10 / 1000
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(MPLY:LOCAL, 130, 100)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(MPLY:LOCAL):4 = 1
NEXT

;●ターゲットについて処理
DOWNBASE:(MTAR:0):体力 += 60

SOURCE:(MTAR:0):露出 = 50
SOURCE:(MTAR:0):接触 = 100
SOURCE:(MTAR:0):快Ｐ = SENSE_HOUSHI_P(MPLY:0, MTAR:0, 1400 * LOCAL:10 / 1000)
SOURCE:(MTAR:0):性行動 = 180

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 130, 50)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 7

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP13
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP13(ARG:0)

LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

FOR LOCAL, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):LOCAL

	;●プレイヤーの潤滑に応じた快感倍率の設定
	IF PALAM:(LOCAL:2):潤滑 < PALAMLV:5
		LOCAL:10 = 500
	ELSEIF PALAM:(LOCAL:2):潤滑 < PALAMLV:6
		LOCAL:10 = 700
	ELSEIF PALAM:(LOCAL:2):潤滑 < PALAMLV:7
		LOCAL:10 = 800
	ELSEIF PALAM:(LOCAL:2):潤滑 < PALAMLV:8
		LOCAL:10 = 900
	ELSE
		LOCAL:10 = 1000
	ENDIF

	;●プレイヤーについて処理
	DOWNBASE:(LOCAL:2):体力 += 20

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 130)
	SOURCE:(LOCAL:2):露出 += 25
	SOURCE:(LOCAL:2):接触 += 50
	SOURCE:(LOCAL:2):性行動 += 100
```
