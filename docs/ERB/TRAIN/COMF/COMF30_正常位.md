# TRAIN/COMF/COMF30_正常位.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF30_正常位.ERB`

类型: .ERB

自动摘要: functions: COM_NAME30, COM_ABLE30, COM30, COM_IS_EQUIP30, COM_EQUIP30, EQUIP_MESSAGE30, COM_TEXT_BEFORE_EQUIP30, COM_TEXT_RELEASE_EQUIP30, COM_ORDER_PLAYER30, COM_TEXT_BEFORE30, COM_TEXT_LAST30, COM_AVAILABLE_WHEN30, COM_PREFERENCE_PLAYER_30, COM_PREFERENCE_TARGET_30, COM_STACK_SPERM_MPLY_TO_MTAR_30; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;正常位

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME30

IF IS_INSERT_SINGLE(MTAR:0, "Ａ") && GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ａ"), 4, 6, 30) && IS_INSERT_MUTUAL(MPLY:0, MTAR:0) != 2
	LOCALS:0 = 二穴正常位
ELSE
	LOCALS:0 = 正常位
ENDIF
RESULTS:0 = %LOCALS:0%で挿入
RESULTS:1 = %LOCALS:0%で挿入させられる
RESULTS:2 = %LOCALS:0%で挿入させる
RESULTS:3 = %LOCALS:0%で挿入される
RESULTS:4 = %LOCALS:0%で挿入させる
RESULTS:5 = %LOCALS:0%見せつけ
IF SEARCH_EQUIP(20, MPLY:0, MTAR:0) != -1 || SEARCH_EQUIP(20, MTAR:0, MPLY:0) != -1 
	IF IS_INSERT_SINGLE(MTAR:0, "Ａ") && GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ａ"), 4, 6, 30)
		LOCALS:0 = 二穴キスハメ
	ELSE
		LOCALS:0 = キスハメ
	ENDIF

	RESULTS:0 = %LOCALS:0%する
	RESULTS:1 = %LOCALS:0%させられる
	RESULTS:2 = %LOCALS:0%させる
	RESULTS:3 = %LOCALS:0%される
	RESULTS:4 = %LOCALS:0%させる
	RESULTS:5 = %LOCALS:0%見せつけ
ENDIF

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE30
CALL COM_ABLE_COMMON(30)
SIF RESULT == 0
	RETURN 0
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
SIF !HAS_VAGINA(MTAR:0)
	RETURN 0
SIF IS_V_HOLD(MTAR:0)
	RETURN 0
;Target is getting assfucked, unless it's sitting backwards or reverse cowgirl
SIF IS_INSERT_SINGLE(MTAR:0, "Ａ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ａ"), 4, 6, 30)
	RETURN 0
SIF !CAN_FUCK(MPLY:0, MTAR:0, 30)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM30
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;既に挿入中なら現在の体位を取得
TFLAG:17 = 0
IF IS_INSERT_MUTUAL(MPLY:0, MTAR:0) == 1
	SELECTCASE GET_SEX_POSITION(MPLY:0, MTAR:0)
		CASE 1
			TFLAG:17 = 1
		CASE 2
			TFLAG:17 = 3
		CASE 3
			TFLAG:17 = 2
		CASE 4
			TFLAG:17 = 3
		CASE 5
			TFLAG:17 = 2
		CASE 6
			TFLAG:17 = 3
		CASE 7
			TFLAG:17 = 3
		CASE 8
			TFLAG:17 = 1
	ENDSELECT
ENDIF
IF TFLAG:17 == 0
	SELECTCASE PREVCOM
		CASE 30
			TFLAG:17 = 1
		CASE 31
			TFLAG:17 = 3
		CASE 32
			TFLAG:17 = 2
		CASE 33
			TFLAG:17 = 3
		CASE 34
			TFLAG:17 = 2
		CASE 35
			TFLAG:17 = 3
		CASE 37
			TFLAG:17 = 3
		CASE 38
			TFLAG:17 = 1
	ENDSELECT
ENDIF

;挿入関係を一時リセット
CALL CLEAR_INSERT_FLAG(MPLY:0, "Ｐ")

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 160

EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):性交経験値 += 2

SOURCE:(MPLY:0):快Ｐ = SENSE_SEX_PLAYER_P(MTAR:0, MPLY:0, 1500)
SOURCE:(MPLY:0):露出 = 100
SOURCE:(MPLY:0):性行動 = 450

;性交系の共通処理
CALL COM_COMMON_SEX_P(MPLY:0, MTAR:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 80)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲット側の処理
DOWNBASE:(MTAR:0):体力 += 120

EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):性交経験値 += 2

SOURCE:(MTAR:0):快Ｖ = SENSE_SEX_TARGET(MPLY:0, MTAR:0, 1500)
SOURCE:(MTAR:0):露出 = 200
SOURCE:(MTAR:0):性行動 = 450

;性交系の共通処理
CALL COM_COMMON_SEX_V(MTAR:0, MPLY:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 150, 100)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;体位フラグのセット
TCVAR:(MPLY:0):31 = 1
TCVAR:(MTAR:0):33 = 1

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = -1

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP30
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP30(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):性交経験値 += 1

SOURCE:(LOCAL:2):快Ｐ += SENSE_SEX_PLAYER_P(LOCAL:3, LOCAL:2, 750)
SOURCE:(LOCAL:2):露出 += 50
SOURCE:(LOCAL:2):性行動 += 150

;性交系の共通処理
CALL COM_COMMON_SEX_P(LOCAL:2, LOCAL:3)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 -= 1

DOWNBASE:(LOCAL:3):体力 += 20

```
