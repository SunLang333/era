# TRAIN/COMF/COMF43_Ａ背面座位.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF43_Ａ背面座位.ERB`

类型: .ERB

自动摘要: functions: COM_NAME43, COM_ABLE43, COM43, COM_IS_EQUIP43, COM_EQUIP43, EQUIP_MESSAGE43, COM_TEXT_BEFORE_EQUIP43, COM_TEXT_RELEASE_EQUIP43, COM_ORDER_PLAYER43, COM_TEXT_BEFORE43, COM_TEXT_LAST43, COM_AVAILABLE_WHEN43, COM_PREFERENCE_PLAYER_43, COM_PREFERENCE_TARGET_43, COM_STACK_SPERM_MPLY_TO_MTAR_43; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;Ａ背面座位

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME43
IF IS_INSERT_SINGLE(MTAR:0, "Ｖ") && GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｖ"), 1, 3, 30) && IS_INSERT_MUTUAL(MPLY:0, MTAR:0) != 1
	LOCALS:0 = 二穴Ａ背面座位
ELSE
	LOCALS:0 = Ａ背面座位
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
@COM_ABLE43
;共通部分
CALL COM_ABLE_COMMON(43)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
SIF IS_A_HOLD(MTAR:0)
	RETURN 0
;being fucked in the vagina, unless it's sitting or missionary
SIF IS_INSERT_SINGLE(MTAR:0, "Ｖ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｖ"), 1, 3, 30)
	RETURN 0
SIF !CAN_FUCK(MPLY:0, MTAR:0, 43)
	RETURN 0
SIF REACHING_BODY(MTAR, MPLY)
	RETURN 0
SIF REACHING_GROIN(MTAR, MPLY)
	RETURN 0
SIF LICKING_BODY(MTAR, MPLY) || LICKING_BODY(MPLY, MTAR)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM43
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;既に挿入中なら現在の体位を取得
TFLAG:17 = 0
IF IS_INSERT_MUTUAL(MPLY:0, MTAR:0) == 2
	SELECTCASE GET_SEX_POSITION(MPLY:0, MTAR:0)
		CASE 1
			TFLAG:17 = 3
		CASE 2
			TFLAG:17 = 2
		CASE 3
			TFLAG:17 = 3
		CASE 4
			TFLAG:17 = 1
		CASE 5
			TFLAG:17 = 3
		CASE 6
			TFLAG:17 = 2
		CASE 7
			TFLAG:17 = 2
		CASE 8
			TFLAG:17 = 3
	ENDSELECT
ENDIF
IF TFLAG:17 == 0
	SELECTCASE PREVCOM
		CASE 40
			TFLAG:17 = 3
		CASE 41
			TFLAG:17 = 2
		CASE 42
			TFLAG:17 = 3
		CASE 43
			TFLAG:17 = 1
		CASE 44
			TFLAG:17 = 3
		CASE 45
			TFLAG:17 = 2
		CASE 47
			TFLAG:17 = 2
		CASE 48
			TFLAG:17 = 3
	ENDSELECT
ENDIF

;挿入関係を一時リセット
CALL CLEAR_INSERT_FLAG(MPLY:0, "Ｐ")

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 180

EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):性交経験値 += 2

SOURCE:(MPLY:0):快Ｐ = SENSE_SEX_PLAYER_P(MTAR:0, MPLY:0, 900)
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
DOWNBASE:(MTAR:0):体力 += 160

EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):性交経験値 += 2

SOURCE:(MTAR:0):快Ｃ = SENSE_SEX_TARGET(MPLY:0, MTAR:0, 500)
SOURCE:(MTAR:0):快Ｂ = SENSE_SEX_TARGET(MPLY:0, MTAR:0, 500)
SOURCE:(MTAR:0):快Ａ = SENSE_SEX_TARGET(MPLY:0, MTAR:0, 900)
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
TCVAR:(MPLY:0):31 = 4
TCVAR:(MTAR:0):35 = 4

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 3

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP43
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP43(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):性交経験値 += 1

SOURCE:(LOCAL:2):快Ｐ += SENSE_SEX_PLAYER_P(LOCAL:3, LOCAL:2, 450)
SOURCE:(LOCAL:2):性行動 += 80

;Ａ性交の共通処理
CALL COM_COMMON_ASEX_P(LOCAL:2, LOCAL:3)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 += 3
```
