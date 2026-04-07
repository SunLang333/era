# TRAIN/COMF/COMF14_足コキ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF14_足コキ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME14, COM_ABLE14, COM14, COM_IS_EQUIP14, COM_EQUIP14, EQUIP_MESSAGE14, COM_TEXT_BEFORE_EQUIP14, COM_TEXT_RELEASE_EQUIP14, COM_ORDER_PLAYER14, COM_TEXT_BEFORE14, COM_AVAILABLE_WHEN14, COM_PREFERENCE_PLAYER_14, COM_PREFERENCE_TARGET_14, COM_STACK_SPERM_MTAR_TO_MPLY_14; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;足コキ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME14
IF MTAR_NUM == 2
	LOCALS:0 = 同時足コキ
ELSEIF MPLY_NUM == 3
	LOCALS:0 = Ｔ足コキ
ELSEIF MPLY_NUM == 2
	LOCALS:0 = Ｗ足コキ
ELSE
	LOCALS:0 = 足コキ
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
@COM_ABLE14
;共通部分
CALL COM_ABLE_COMMON(14)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で3人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 3
	RETURN 0
;ターゲットは最大で2人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 2
	RETURN 0
;複数-複数は不可
SIF MPLY_NUM >= 2 && MTAR_NUM >= 2
	RETURN 0
;全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
		RETURN 0
	;拘束中なら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
	SIF IS_RIDDEN(MPLY:(LOCAL:0), MTAR:0)
		RETURN 0
	;プレイヤーが土下座しているなら不可
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 110)
		RETURN 0
	;ターゲットからプレイヤーに足舐め中なら不可
	SIF SEARCH_EQUIP(104, MTAR:0, MPLY:(LOCAL:0)) >= 0
		RETURN 0
NEXT
;全ターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	;竿が必要
	SIF !HAS_PENIS(MTAR:(LOCAL:0))
		RETURN 0
	SIF !P_STACKABLE(MPLY:0, MTAR:(LOCAL:0), 14)
		RETURN 0
	;ターゲットのＶが他のキャラの竿で埋まっていて、体位が後背位・背面座位・騎乗位・背面騎乗位以外なら不可
	SIF IS_INSERT_SINGLE(MTAR:0, "Ｖ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｖ"), 2, 4, 5, 6)
		RETURN 0
	;ターゲットのＡが他のキャラの竿で埋まっていて、体位がＡ後背位・Ａ背面座位・Ａ騎乗位・Ａ背面騎乗位以外なら不可
	SIF IS_INSERT_SINGLE(MTAR:0, "Ａ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ａ"), 2, 4, 5, 6)
		RETURN 0
	;土下座しているなら不可
	SIF IS_EQUIP_PLAYER(MTAR:(LOCAL:0), 110)
		RETURN 0
NEXT


FOR LOCAL:0, 0, MPLY_NUM
	FOR LOCAL:1, 0, MTAR_NUM
		SIF IS_INSERT_MUTUAL(MPLY:(LOCAL:0), MTAR:(LOCAL:1))
			RETURN 0
		SIF REACHING_BODY(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) || REACHING_BODY(MTAR:(LOCAL:1), MPLY:(LOCAL:0))
			RETURN 0
		SIF REACHING_GROIN(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) || REACHING_GROIN(MTAR:(LOCAL:1), MPLY:(LOCAL:0))
			RETURN 0
		SIF LICKING_GROIN(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) || LICKING_GROIN(MTAR:(LOCAL:1), MPLY:(LOCAL:0))
			RETURN 0
		SIF LICKING_BODY(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) || LICKING_BODY(MTAR:(LOCAL:1), MPLY:(LOCAL:0))
			RETURN 0
        ;buttjob (giving or receiving)
		SIF SEARCH_EQUIP_IC(15, MPLY:(LOCAL:0), MTAR:(LOCAL:1)) >= 0
			RETURN 0
	NEXT
NEXT


RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM14
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
ENDSELECT

SELECTCASE MTAR_NUM
	CASE 2
		TIMES LOCAL:10, 0.75
ENDSELECT

;●全プレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 100

	EXP:(LOCAL:2):性技経験値 += MAX(MTAR_NUM / 2 + 1, 1)

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 200)
	SOURCE:(LOCAL:2):接触 = 50
	SOURCE:(LOCAL:2):逸脱 = 30
	SOURCE:(LOCAL:2):性行動 = 210

	;プレイヤー主導の場合
	IF GET_COM_INITIATIVE() == 0
		SOURCE:(LOCAL:2):嗜虐 = 80
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 170, 90)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;全ターゲットに与える快感系ソースを計算
	FOR LOCAL:1, 0, MTAR_NUM
		LOCAL:3 = MTAR:(LOCAL:1)
		SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 1100 + TALENT:(LOCAL:2):美脚 * 300) * LOCAL:10 / 100

	NEXT
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:1):体力 += 60

	SOURCE:(LOCAL:1):接触 = 50
	SOURCE:(LOCAL:1):逸脱 = 30
	SOURCE:(LOCAL:1):苦痛 = 20
	SOURCE:(LOCAL:1):性行動 = 180

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 100, 120)
NEXT

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 2

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP14
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP14(ARG:0)
;●人数補正の設定
LOCAL:10 = 100

SELECTCASE MEQUIP_PLAYER_NUM:(ARG:0)
	CASE 2
		TIMES LOCAL:10, 0.75
	CASE 3
		TIMES LOCAL:10, 0.60
ENDSELECT

SELECTCASE MEQUIP_TARGET_NUM:(ARG:0)
```
