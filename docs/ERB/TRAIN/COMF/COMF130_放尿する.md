# TRAIN/COMF/COMF130_放尿する.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF130_放尿する.ERB`

类型: .ERB

自动摘要: functions: COM_NAME130, COM_ABLE130, COM130, COM_IS_EQUIP130, COM_ORDER_PLAYER130, COM_TEXT_BEFORE130, COM_TEXT_LAST130, COM_AVAILABLE_WHEN130, COM_PREFERENCE_PLAYER_130, COM_PREFERENCE_TARGET_130; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;放尿する

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME130
LOCALS:0 = 放尿

RESULTS:0 = %LOCALS:0%を見せつける
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%を見せつけられる
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

LOCAL = GET_INSERT_TARGET(MPLY:0)

SIF LOCAL == -1 || !HAS_PENIS(MPLY:0)
	RETURN 0

SELECTCASE IS_INSERT_MUTUAL(MPLY:0, LOCAL)
	CASE 1
		LOCALS:0 = 膣内放尿
	CASE 2
		LOCALS:0 = 肛内放尿
	CASEELSE
		LOCALS:0 = 放尿
ENDSELECT

IF MTAR:0 == LOCAL
	RESULTS:0 =  %LOCALS:0%する
ELSEIF MTAR:0 != LOCAL
	RESULTS:0 = %LOCALS:0%を見せつける
ENDIF
IF MTAR:0 == MASTER && LOCAL == MASTER
	RESULTS:2 = %LOCALS:0%させる
	RESULTS:3 = %LOCALS:0%される
ELSEIF MTAR:0 == MASTER && LOCAL != MASTER
	RESULTS:2 = %LOCALS:0%させる
	RESULTS:3 = %LOCALS:0%を見せつけられる
ENDIF


RESULTS:1 = %LOCALS:0%させられる
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE130
;共通部分
CALL COM_ABLE_COMMON(130)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人以上
SIF MPLY_NUM <= 0
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0
;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;プレイヤーが行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:LOCAL)
		RETURN 0
	;尿残量が十分でないなら不可
	SIF TCVAR:(MPLY:(LOCAL:0)):54 < 1000
		RETURN 0
	;顔面騎乗中は不可
	SIF IS_RIDE(MPLY:(LOCAL:0))
		RETURN 0
	;フェラ・亀頭フェラされているなら不可
	SIF IS_EQUIP_TARGET(MPLY:(LOCAL:0), 11, 107)
		RETURN 0
	;facefucking
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 90)
		RETURN 0
	;竿がなく、クンニされているなら不可
	SIF !HAS_PENIS(MPLY:(LOCAL:0)) && IS_EQUIP_TARGET(MPLY:(LOCAL:0), 1)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM130
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):排泄経験値 += 1

	LOCAL:3 = 800
	LOCAL:4 = 300

	SELECTCASE ABL:(LOCAL:2):排泄
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
			LOCAL:3 = LOCAL:3 * (100 + (ABL:(LOCAL:2):排泄 - 5) * 2) / 100
			LOCAL:4 = 0
	ENDSELECT
	SOURCE:(LOCAL:2):快Ｕ = 200
	SOURCE:(LOCAL:2):露出 = 1200
	SOURCE:(LOCAL:2):逸脱 = 500
	SOURCE:(LOCAL:2):中毒充足 = LOCAL:3
	SOURCE:(LOCAL:2):性行動 = 150
	SOURCE:(LOCAL:2):反感 = LOCAL:4

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 80, 150)

	;尿残量を0にする
	TCVAR:(LOCAL:2):54 = 0
NEXT

;主導権の所在を取得
LOCAL:11 = GET_COM_INITIATIVE()

;全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	SOURCE:(LOCAL:1):性行動 = 90

	;ターゲットに主導権
	IF LOCAL:11 == 1 || LOCAL:11 == 2
		SOURCE:(LOCAL:1):嗜虐 = 150
		SOURCE:(LOCAL:1):逸脱 = 250
	;ターゲットに主導権がない
	ELSE
		SOURCE:(LOCAL:1):逸脱 = 500
		SOURCE:(LOCAL:1):恐怖 = MAX(150 - 40 * ABL:(LOCAL:1):欲望, 0)
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 100, 80)
NEXT

;主導度変化基準値
TFLAG:49 = 4

;倒錯度変化基準値
TFLAG:50 = 4

;レズ・ＢＬ経験基準値
TFLAG:51 = 2

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP130
RETURN 0

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER130(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 90

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 2)
CALL COM_ORDER_ELEMENT(ARG:0, @"露出Lv{ABL:(ARG:0):露出}", ABL:(ARG:0):露出 * 4)
CALL COM_ORDER_ELEMENT(ARG:0, @"排泄Lv{ABL:(ARG:0):排泄}", ABL:(ARG:0):排泄 * 7)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -12)
ENDIF
IF TALENT:(ARG:0):恥薄い
	CALL COM_ORDER_ELEMENT(ARG:0, "恥薄い", 8)
ENDIF
IF TALENT:(ARG:0):自制心
```
