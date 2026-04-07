# TRAIN/COMF/COMF132_口内放尿.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF132_口内放尿.ERB`

类型: .ERB

自动摘要: functions: COM_NAME132, COM_ABLE132, COM132, COM_IS_EQUIP132, COM_ORDER_PLAYER132, COM_TEXT_BEFORE132, COM_TEXT_LAST132, COM_AVAILABLE_WHEN132, COM_PREFERENCE_PLAYER_132, COM_PREFERENCE_TARGET_132; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;口内放尿

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME132
IF IS_RIDE(MPLY:0)
	LOCALS:0 = 顔騎口内放尿
ELSE
	LOCALS:0 = 口内放尿
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
@COM_ABLE132
;共通部分
CALL COM_ABLE_COMMON(132)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;プレイヤーの尿残量が十分でないなら不可
SIF TCVAR:(MPLY:0):54 < 1000
	RETURN 0
;プレイヤーが顔面騎乗中で、プレイヤーに竿があるまたはターゲット以外のキャラに跨ってるなら不可
SIF IS_RIDE(MPLY:0) && (HAS_PENIS(MPLY:0) || !IS_RIDE(MPLY:0, MTAR:0))
	RETURN 0
;fucking each other
SIF IS_INSERT_MUTUAL(MPLY:0, MTAR:0)
	RETURN 0
;Player's penis occupied
SIF IS_P_HOLD(MPLY:0)
	RETURN 0
;target's mouth occupied (except by cunni/blowjob/titjob/glans blowjob/facefuck with the target)
SIF IS_M_HOLD(MTAR:0) && (SEARCH_EQUIP_M(MTAR:0, MPLY:0, 2, 11, 12, 107) < 0) && (SEARCH_EQUIP(90, MPLY:0, MTAR:0) < 0)
	RETURN 0
;プレイヤー以外に顔面騎乗されているなら不可
SIF (IS_RIDDEN(MTAR:0) && !IS_RIDDEN(MTAR:0, MPLY:0))
	RETURN 0
;プレイヤーが土下座しているなら不可
SIF IS_EQUIP_PLAYER(MPLY:0, 110)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM132
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	EXP:(LOCAL:2):排泄経験値 += 1
	EXP:(LOCAL:2):嗜虐経験値 += 1

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
	SOURCE:(LOCAL:2):逸脱 = 800
	SOURCE:(LOCAL:2):性行動 = 150
	SOURCE:(LOCAL:2):中毒充足 = LOCAL:3
	SOURCE:(LOCAL:2):反感 = LOCAL:4

	;プレイヤーに主導権がある場合
	IF IS_INITIATIVE(LOCAL:2)
		SOURCE:(LOCAL:2):嗜虐 = 300
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 120, 150)

	;尿残量を0にする
	TCVAR:(LOCAL:2):54 = 0
NEXT

;主導権の所在を取得
LOCAL:11 = GET_COM_INITIATIVE()

;全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	EXP:(LOCAL:2):被虐経験値 += 1


	SOURCE:(LOCAL:1):性行動 = 90

	;ターゲットに主導権
	IF LOCAL:11 == 1 || LOCAL:11 == 2
		SOURCE:(LOCAL:1):嗜虐 = 150
		SOURCE:(LOCAL:1):逸脱 = 700
	;ターゲットに主導権がない
	ELSE
		SOURCE:(LOCAL:1):逸脱 = 1000
		SOURCE:(LOCAL:1):恐怖 = MAX(200 - 50 * ABL:(LOCAL:1):欲望, 0)
	ENDIF

	;ターゲットが気絶している場合
	IF TCVAR:(LOCAL:1):52
		SOURCE:(LOCAL:1):気絶回復 = 500
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 130, 170)

	IF HAS_PENIS(MPLY:0)
		;ペニスへのキス
		CALL KISS_COMMON(LOCAL:1, @"%ANAME(MPLY:0)%のペニス")
	ENDIF


NEXT

;主導度変化基準値
TFLAG:49 = 4

;倒錯度変化基準値
TFLAG:50 = 6

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP132
RETURN 0

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER132(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 105

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
	CALL COM_ORDER_ELEMENT(ARG:0, "自制心", -6)
ENDIF
IF TALENT:(ARG:0):目立ちたがり
```
