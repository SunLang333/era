# TRAIN/COMF/COMF19_玉舐め.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF19_玉舐め.ERB`

类型: .ERB

自动摘要: functions: COM_NAME19, COM_ABLE19, COM19_RATE_M, COM19, COM_IS_EQUIP19, COM_EQUIP19, EQUIP_MESSAGE19, COM_TEXT_BEFORE_EQUIP19, COM_TEXT_RELEASE_EQUIP19, COM_ORDER_PLAYER19, COM_TEXT_BEFORE19, COM_TEXT_LAST19, COM_AVAILABLE_WHEN19, COM_PREFERENCE_PLAYER_19, COM_PREFERENCE_TARGET_19, COM_STACK_SPERM_MTAR_TO_MPLY_19; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;フェラチオ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME19
	;プレイヤーからターゲットにフェラ中
IF SEARCH_EQUIP(11, MPLY:0, MTAR:0) >= 0
	LOCALS:0 = フェラ玉舐め
	;手コキ中
ELSEIF SEARCH_EQUIP(10, MPLY:0, MTAR:0) >= 0
	LOCALS:0 = 手コキ玉舐め
	;アナル舐め中
ELSEIF SEARCH_EQUIP(8, MPLY:0, MTAR:0) >= 0
	LOCALS:0 = Ａ玉舐め
ELSE
	LOCALS:0 = 玉舐め
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
@COM_ABLE19
;共通部分
CALL COM_ABLE_COMMON(19)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で3人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 3
	RETURN 0
;ターゲットはひとり
SIF MTAR_NUM != 1
	RETURN 0
;おちんちんが必要です
SIF !HAS_PENIS(MTAR:0)
	RETURN 0

FOR LOCAL, 0, MPLY_NUM
	SIF !CAN_LICK_GROIN(MPLY:LOCAL, MTAR)
		RETURN 0
NEXT

;vaginal facesitting
SIF IS_EQUIP_PLAYER(MTAR:0, 101)
	RETURN 0

RETURN 1

;-------------------------------------------------
;快Ｍソースの倍率を取得する関数 ARG:0=PLAYERのキャラ番号
;-------------------------------------------------
@COM19_RATE_M(ARG:0)
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
@COM19
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

TFLAG:16 = 0
;挿入中
FOR LOCAL, 0, MTAR_NUM
	IF IS_INSERT_SINGLE(MTAR:LOCAL, "Ｐ")
		TFLAG:16 = IS_INSERT_SINGLE(MTAR:LOCAL, "Ｐ")
		BREAK
	ENDIF
NEXT


;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MPLY_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
	CASE 3
		TIMES LOCAL:10, 0.60
ENDSELECT

SELECTCASE MTAR_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 120

	EXP:(LOCAL:2):性技経験値 += MAX(MTAR_NUM / 2 + 1, 1)
	EXP:(LOCAL:2):口淫経験 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 600)
	SOURCE:(LOCAL:2):接触 = 50
	SOURCE:(LOCAL:2):快Ｍ = 300 * COM19_RATE_M(LOCAL:2) / 1000
	SOURCE:(LOCAL:2):性行動 = 300

	;主導権に応じた優越・受動のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 150, 120)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		LOCAL:4 = SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 1500) * LOCAL:10 / 100
		IF TALENT:(LOCAL:2):舌使い
			TIMES LOCAL:4, 1.50
		ENDIF
		SOURCE:(LOCAL:3):快Ｐ += LOCAL:4
	NEXT
	IF MTAR_NUM == 1
		;ペニスへのキス
		CALL KISS_COMMON(LOCAL:2, @"%ANAME(MTAR:0)%の睾丸", GET_SITUATION_BY_TRAIN_MODE())
	ELSE
		CALL KISS_COMMON(LOCAL:2, @"%ANAME(MTAR:0)%たちの睾丸", (GET_SITUATION_BY_TRAIN_MODE() == "和姦" ? "乱交" # "輪姦"))
	ENDIF
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	;●ソースの計算
	DOWNBASE:(LOCAL:1):体力 += 60

	SOURCE:(LOCAL:1):接触 = 50
	SOURCE:(LOCAL:1):性行動 = 180

	;主導権に応じた優越・受動のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 150, 70)
NEXT

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
@COM_IS_EQUIP19
RETURN 1
```
