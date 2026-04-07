# TRAIN/COMF/COMF17_尻尾コキ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF17_尻尾コキ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME17, COM_ABLE17, COM17, COM_IS_EQUIP17, COM_EQUIP17, EQUIP_MESSAGE17, COM_TEXT_BEFORE_EQUIP17, COM_TEXT_RELEASE_EQUIP17, COM_ORDER_PLAYER17, COM_TEXT_BEFORE17, COM_AVAILABLE_WHEN17, COM_PREFERENCE_PLAYER_17, COM_PREFERENCE_TARGET_17, COM_STACK_SPERM_MTAR_TO_MPLY_17; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;尻尾コキ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME17
IF MPLY_NUM == 4
	LOCALS:0 = Ｑ尻尾コキ
ELSEIF MPLY_NUM == 3
	LOCALS:0 = Ｔ尻尾コキ
ELSEIF MPLY_NUM == 2
	LOCALS:0 = Ｗ尻尾コキ
ELSE
	LOCALS:0 = 尻尾コキ
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
@COM_ABLE17
;共通部分
CALL COM_ABLE_COMMON(17)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で4人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 4
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;ターゲットに竿が必要
SIF !HAS_PENIS(MTAR:0)
	RETURN 0
;全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;尻尾が必要
	SIF !TALENT:(MPLY:(LOCAL:0)):しっぽ
		RETURN 0
	;尻尾を使用中なら不可
	SIF IS_EQUIP_PLAYER(MPLY:0, 6, 7, 17)
		RETURN 0
	;行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
		RETURN 0
NEXT
SIF !P_STACKABLE(MPLY:0, MTAR:0, 17)
	RETURN 0
;竿が挿入中なら1-1限定
SIF IS_INSERT_SINGLE(MTAR:(LOCAL:0), "Ｐ") && MPLY_NUM >= 2
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM17
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MPLY_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
	CASE 3
		TIMES LOCAL:10, 0.60
	CASE 4
		TIMES LOCAL:10, 0.50
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 350)
	SOURCE:(LOCAL:2):接触 = 80
	SOURCE:(LOCAL:2):性行動 = 210

	SELECTCASE ABL:(LOCAL:2):奉仕
		CASE 0
			TIMES SOURCE:(LOCAL:2):不潔, 4.00
		CASE 1
			TIMES SOURCE:(LOCAL:2):不潔, 2.50
		CASE 2
			TIMES SOURCE:(LOCAL:2):不潔, 1.50
		CASE 3
			TIMES SOURCE:(LOCAL:2):不潔, 1.00
		CASE 4
			TIMES SOURCE:(LOCAL:2):不潔, 0.50
		CASEELSE
			TIMES SOURCE:(LOCAL:2):不潔, 0.10
	ENDSELECT

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 150, 80)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;ターゲットに与える快感系ソースを計算
	SOURCE:(MTAR:0):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, MTAR:0, 1000) * LOCAL:10 / 100
	SOURCE:(MTAR:0):快Ｃ += SENSE_HOUSHI(LOCAL:2, MTAR:0, 100) * LOCAL:10 / 100

NEXT

;●ターゲットについて判定
SOURCE:(MTAR:0):接触 = 40
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
@COM_IS_EQUIP17
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP17(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_PLAYER_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
	CASE 3
		TIMES LOCAL:10, 0.60
	CASE 4
		TIMES LOCAL:10, 0.50
ENDSELECT

LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)
	EXP:(LOCAL:2):性技経験値 += 1

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 120)
	SOURCE:(LOCAL:2):接触 += 40
	SOURCE:(LOCAL:2):性行動 += 70

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;ターゲットに与える快感系ソースを計算
	SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 300) * LOCAL:10 / 100
	SOURCE:(LOCAL:3):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 50) * LOCAL:10 / 100

NEXT

;●ターゲットについて判定
SOURCE:(LOCAL:3):接触 += 20
SOURCE:(LOCAL:3):性行動 += 60

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE17(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に尻尾コキ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP17(ARG:0)
LOCAL:2 = 0
IF MEQUIP_PLAYER_NUM:(ARG:0) == 1 && MEQUIP_TARGET_NUM:(ARG:0) == 1
	IF GROUPMATCH(IS_INSERT_MUTUAL(MEQUIP_PLAYER:(ARG:0):0, MEQUIP_TARGET:(ARG:0):0), 3, 4)
		LOCAL:2 = 1
	ELSEIF GROUPMATCH(SELECTCOM, 30, 31, 32, 33, 34, 35, 36, 37, 40, 41, 42, 43, 44, 45, 46, 47) && MTAR:0 == MEQUIP_PLAYER:(ARG:0):0 && MPLY:0 == MEQUIP_TARGET:(ARG:0):0
		LOCAL:2 = 1
	ENDIF
ENDIF
```
