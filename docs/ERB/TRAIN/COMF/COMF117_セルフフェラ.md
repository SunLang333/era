# TRAIN/COMF/COMF117_セルフフェラ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF117_セルフフェラ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME117, COM_ABLE117, COM117_RATE_M, COM117, COM_IS_EQUIP117, COM_EQUIP117, EQUIP_MESSAGE117, COM_TEXT_BEFORE_EQUIP117, COM_TEXT_RELEASE_EQUIP117, COM_ORDER_PLAYER117, COM_TEXT_BEFORE117, COM_TEXT_LAST117, COM_AVAILABLE_WHEN117, COM_PREFERENCE_PLAYER_117, COM_PREFERENCE_TARGET_117, COM_STACK_SPERM_MPLY_TO_MPLY_117; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;自慰

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME117
LOCALS:0 = 
IF TFLAG:70 == 1
	LOCALS:0 = 撮影
ELSEIF TFLAG:104 >= 2
	LOCALS:0 = 公開
ELSEIF TFLAG:54 == 8
	LOCALS:0 = 野外
ENDIF

LOCALS:0 '= LOCALS:0 + "セルフフェラ"

RESULTS:0 = %LOCALS:0%を見せつける
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%を見せつけられる
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE117
;共通部分
CALL COM_ABLE_COMMON(117)
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
;スキマが必要
SIF !ITEM:スキマ
	RETURN 0
;多対多は不可
SIF MPLY_NUM >= 2 && MTAR_NUM >= 2
	RETURN 0

FOR LOCAL, 0, MPLY_NUM
	;拘束中なら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0

	;プレイヤーに竿が必要
	SIF !HAS_PENIS(MPLY:(LOCAL:0))
		RETURN 0
	SIF !P_STACKABLE(MPLY:LOCAL, MPLY:LOCAL, 117)
		RETURN 0
	;プレイヤーの口が埋まってるなら駄目
	SIF IS_M_HOLD(MPLY:0)
		RETURN 0
NEXT


RETURN 1

;-------------------------------------------------
;快Ｍソースの倍率を取得する関数 ARG:0=PLAYERのキャラ番号
;-------------------------------------------------
@COM117_RATE_M(ARG:0)
#FUNCTION
LOCAL:5 = 1000
SELECTCASE ABL:(ARG:0):奉仕
	CASE 0
		TIMES LOCAL:5, 0.00
		;TIMES SOURCE:(LOCAL:2):不潔, 4.00
	CASE 1
		TIMES LOCAL:5, 0.10
		;TIMES SOURCE:(LOCAL:2):不潔, 2.50
	CASE 2
		TIMES LOCAL:5, 0.30
		;TIMES SOURCE:(LOCAL:2):不潔, 1.50
	CASE 3
		TIMES LOCAL:5, 0.80
		;TIMES SOURCE:(LOCAL:2):不潔, 1.00
	CASE 4
		TIMES LOCAL:5, 1.00
		;TIMES SOURCE:(LOCAL:2):不潔, 0.50
	CASEELSE
		LOCAL:5 = LOCAL:5 * (100 + (ABL:(ARG:0):奉仕 - 5) * 3) / 100
		;TIMES SOURCE:(LOCAL:2):不潔, 0.10
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
		LOCAL:5 = LOCAL:5 * ((ABL:(ARG:0):性技 - 5) * 2 + 150) / 100
ENDSELECT

RETURNF LOCAL:5


;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM117
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;対Ｐ奉仕系コマンドの継続フラグを解除
CALL RELEASE_SERVE_P

;●全てのプレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):自慰経験値 += 3
	EXP:(LOCAL:2):口淫経験 += 1

	SOURCE:(LOCAL:2):露出 = 1300
	SOURCE:(LOCAL:2):逸脱 = 200
	SOURCE:(LOCAL:2):性行動 = 300

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

	SOURCE:(LOCAL:2):快Ｐ = SENSE_HOUSHI_P(LOCAL:2, LOCAL:2, LOCAL:3 * 3 / 2)
	SOURCE:(LOCAL:2):快Ｍ = 600 * COM117_RATE_M(LOCAL:2) / 1000
	;ペニスへのキス
	CALL KISS_COMMON(LOCAL:2, @"%ANAME(LOCAL:2)%のペニス", GET_SITUATION_BY_TRAIN_MODE())

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
		SOURCE:(LOCAL:1):逸脱 = 100
		SOURCE:(LOCAL:1):恐怖 = MAX(117 - 30 * ABL:(LOCAL:1):欲望, 0)
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
@COM_IS_EQUIP117
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
```
