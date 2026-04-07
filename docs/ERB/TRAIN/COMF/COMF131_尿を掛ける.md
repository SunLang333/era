# TRAIN/COMF/COMF131_尿を掛ける.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF131_尿を掛ける.ERB`

类型: .ERB

自动摘要: functions: COM_NAME131, COM_ABLE131, COM131, COM_IS_EQUIP131, COM_ORDER_PLAYER131, COM_TEXT_BEFORE131, COM_TEXT_LAST131, COM_AVAILABLE_WHEN131, COM_PREFERENCE_PLAYER_131, COM_PREFERENCE_TARGET_131; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;尿を掛ける

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME131
LOCAL:1 = 1
FOR LOCAL:0, 0, MTAR_NUM
	IF TCVAR:(MTAR:(LOCAL:0)):52 == 0
		LOCAL:1 = 0
	ENDIF
NEXT

IF LOCAL:1
	LOCALS:0 = 気付け放尿

	RESULTS:0 = %LOCALS:0%する
	RESULTS:4 = %LOCALS:0%させる
	RESULTS:5 = %LOCALS:0%見せつけ

ELSEIF IS_RIDE(MPLY:0)
	LOCALS:0 = 顔騎放尿

	RESULTS:0 = %LOCALS:0%する
	RESULTS:1 = %LOCALS:0%させられる
	RESULTS:2 = %LOCALS:0%させる
	RESULTS:3 = %LOCALS:0%される
	RESULTS:4 = %LOCALS:0%させる
	RESULTS:5 = %LOCALS:0%見せつけ

ELSE
	LOCALS:0 = 尿を掛け

	RESULTS:0 = %LOCALS:0%る
	RESULTS:1 = %LOCALS:0%させられる
	RESULTS:2 = %LOCALS:0%させる
	RESULTS:3 = %LOCALS:0%られる
	RESULTS:4 = %LOCALS:0%させる
	RESULTS:5 = 尿掛け見せつけ
ENDIF

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE131
;共通部分
CALL COM_ABLE_COMMON(131)
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

LOCAL:1 = 0
;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;尿残量が十分でないなら不可
	SIF TCVAR:(MPLY:(LOCAL:0)):54 < 1000
		RETURN 0
	;顔面騎乗中は1-1かつプレイヤーがターゲットに跨っている必要がある
	IF IS_RIDE(MPLY:(LOCAL:0))
		SIF MPLY_NUM >= 2 || MTAR_NUM >= 2
			RETURN 0
		SIF !IS_RIDE(MPLY:(LOCAL:0), MTAR:0)
			RETURN 0
	ENDIF
	;プレイヤーが挿入中なら不可
	SIF IS_INSERT_SINGLE(MPLY:(LOCAL:0), "全")
		RETURN 0
	;フェラ・亀頭フェラされているなら不可
	SIF IS_EQUIP_TARGET(MPLY:(LOCAL:0), 11, 107)
		RETURN 0
	;facefucking
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 90)
		RETURN 0
		;プレイヤーが土下座しているなら不可
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 110)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM131
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

	SOURCE:(LOCAL:2):露出 = 1200
	SOURCE:(LOCAL:2):逸脱 = 600
	SOURCE:(LOCAL:2):性行動 = 150
	SOURCE:(LOCAL:2):中毒充足 = LOCAL:3
	SOURCE:(LOCAL:2):反感 = LOCAL:4
	

	;プレイヤーに主導権がある場合
	IF IS_INITIATIVE(LOCAL:2)
		SOURCE:(LOCAL:2):嗜虐 = 200
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

	SOURCE:(LOCAL:1):性行動 = 90
	EXP:(LOCAL:2):被虐経験値 += 1
	;ターゲットに主導権
	IF LOCAL:11 == 1 || LOCAL:11 == 2
		SOURCE:(LOCAL:1):嗜虐 = 150
		SOURCE:(LOCAL:1):逸脱 = 500
	;ターゲットに主導権がない
	ELSE
		SOURCE:(LOCAL:1):逸脱 = 700
		SOURCE:(LOCAL:1):恐怖 = MAX(200 - 50 * ABL:(LOCAL:1):欲望, 0)
	ENDIF

	;ターゲットが気絶している場合
	IF TCVAR:(LOCAL:1):52
		SOURCE:(LOCAL:1):気絶回復 = 500
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 110, 130)
NEXT

;主導度変化基準値
TFLAG:49 = 4

;倒錯度変化基準値
TFLAG:50 = 5

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP131
RETURN 0

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER131(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 100

;共通部分
CALL COM_ORDER(ARG:0)
```
