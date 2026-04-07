# TRAIN/COMF/COMF47_Ａ側位.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF47_Ａ側位.ERB`

类型: .ERB

自动摘要: functions: COM_NAME47, COM_ABLE47, COM47, COM_IS_EQUIP47, COM_EQUIP47, EQUIP_MESSAGE47, COM_TEXT_BEFORE_EQUIP47, COM_TEXT_RELEASE_EQUIP47, COM_ORDER_PLAYER47, COM_TEXT_BEFORE47, COM_TEXT_LAST47, COM_AVAILABLE_WHEN47, COM_PREFERENCE_PLAYER_47, COM_PREFERENCE_TARGET_47, COM_STACK_SPERM_MPLY_TO_MTAR_47; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;Ａ後背位

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME47
IF IS_INSERT_SINGLE(MTAR:0, "Ｖ") && GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｖ"), 5, 30) && IS_INSERT_MUTUAL(MPLY:0, MTAR:0) != 1
	LOCALS:0 = 二穴Ａ側位
ELSE
	LOCALS:0 = Ａ側位
ENDIF
RESULTS:0 = %LOCALS:0%で挿入
RESULTS:1 = %LOCALS:0%で挿入させられる
RESULTS:2 = %LOCALS:0%で挿入させる
RESULTS:3 = %LOCALS:0%で挿入される
RESULTS:4 = %LOCALS:0%で挿入させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE47
;共通部分
CALL COM_ABLE_COMMON(47)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
SIF IS_INSERT_SINGLE(MTAR:0, "Ｖ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｖ"), 5, 30)
	RETURN 0
SIF IS_A_HOLD(MTAR:0)
	RETURN 0
SIF !CAN_FUCK(MPLY:0, MTAR:0, 47)
	RETURN 0
;player and target have to face each other
SIF LICKING_BODY(MPLY:0, MTAR:0) || LICKING_BODY(MTAR:0, MPLY:0)
	RETURN 0
;target has to face player
SIF REACHING_BODY(MTAR:0, MPLY:0)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM47
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;既に挿入中なら現在の体位を取得
TFLAG:17 = 0
IF IS_INSERT_MUTUAL(MPLY:0, MTAR:0) == 1
	SELECTCASE GET_SEX_POSITION(MPLY:0, MTAR:0)
		CASE 1
			TFLAG:17 = 3
		CASE 2
			TFLAG:17 = 3
		CASE 3
			TFLAG:17 = 3
		CASE 4
			TFLAG:17 = 2
		CASE 5
			TFLAG:17 = 3
		CASE 6
			TFLAG:17 = 2
		CASE 7
			TFLAG:17 = 1
		CASE 8
			TFLAG:17 = 3
	ENDSELECT
ENDIF
IF TFLAG:17 == 0
	SELECTCASE PREVCOM
		CASE 40
			TFLAG:17 = 3
		CASE 41
			TFLAG:17 = 3
		CASE 42
			TFLAG:17 = 3
		CASE 43
			TFLAG:17 = 2
		CASE 44
			TFLAG:17 = 3
		CASE 45
			TFLAG:17 = 2
		CASE 46
			TFLAG:17 = 1
		CASE 47
			TFLAG:17 = 3
	ENDSELECT
ENDIF

;挿入関係を一時リセット
CALL CLEAR_INSERT_FLAG(MPLY:0, "Ｐ")

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 160

EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):性交経験値 += 2

SOURCE:(MPLY:0):快Ｐ = SENSE_SEX_PLAYER_P(MTAR:0, MPLY:0, 1500)
SOURCE:(MPLY:0):性行動 = 240

IF MTAR:0 == MASTER
	CALL ADD_SOURCE_AIZYOU(MPLY:0, 20)
ELSEIF MPLY:0 != MASTER
	SOURCE:(MPLY:0):露出 += 200
ENDIF

;性交系の共通処理
CALL COM_COMMON_ASEX_P(MPLY:0, MTAR:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 200, 80)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲット側の処理
DOWNBASE:(MTAR:0):体力 += 140

EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):性交経験値 += 2

SOURCE:(MTAR:0):快Ａ = SENSE_SEX_TARGET(MPLY:0, MTAR:0, 1500)
SOURCE:(MTAR:0):露出 = 400
SOURCE:(MTAR:0):性行動 = 240

IF MPLY:0 == MASTER
	CALL ADD_SOURCE_AIZYOU(MTAR:0, 20)
ELSEIF MTAR:0 != MASTER
	SOURCE:(MTAR:0):露出 += 200
ENDIF

;性交系の共通処理
CALL COM_COMMON_ASEX_A(MTAR:0, MPLY:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 120, 180)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;体位フラグのセット
TCVAR:(MPLY:0):31 = 2
TCVAR:(MTAR:0):35 = 2

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 3

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP47
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP47(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):性交経験値 += 1

SOURCE:(LOCAL:2):快Ｐ += SENSE_SEX_PLAYER_P(LOCAL:3, LOCAL:2, 750)
SOURCE:(LOCAL:2):性行動 += 80

;Ａ性交の共通処理
CALL COM_COMMON_ASEX_P(LOCAL:2, LOCAL:3)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 += 3

DOWNBASE:(LOCAL:3):体力 += 30
```
