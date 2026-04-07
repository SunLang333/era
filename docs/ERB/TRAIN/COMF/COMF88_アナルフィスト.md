# TRAIN/COMF/COMF88_アナルフィスト.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF88_アナルフィスト.ERB`

类型: .ERB

自动摘要: functions: COM_NAME88, COM_ABLE88, COM88, COM_IS_EQUIP88, COM_EQUIP88, EQUIP_MESSAGE88, COM_TEXT_BEFORE_EQUIP88, COM_TEXT_RELEASE_EQUIP88, COM_ORDER_PLAYER88, COM_TEXT_BEFORE88, COM_AVAILABLE_WHEN88, COM_PREFERENCE_PLAYER_88, COM_PREFERENCE_TARGET_88; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;アナルフィスト

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME88
LOCALS:0 = アナルフィスト

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE88
;共通部分
CALL COM_ABLE_COMMON(88)
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
SIF !CAN_REACH_GROIN(MPLY:0, MTAR:0)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM88
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;ターゲットのＡ拡張経験による諸々の倍率
LOCAL:10 = MIN(100 + EXP:(MTAR:0):Ａ拡張経験 * 10 + MIN(ABL:(MTAR:0):Ａ感, 6) * 30, 600)

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 120
EXP:(MPLY:0):嗜虐経験値 += RAND(1, 4)

SOURCE:(MPLY:0):嗜虐 = 1000
SOURCE:(MPLY:0):逸脱 = 600
SOURCE:(MPLY:0):性行動 = 90

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 80)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲット側の処理
DOWNBASE:(MTAR:0):体力 += 180

EXP:(MTAR:0):Ａ拡張経験 += 1
EXP:(MTAR:0):被虐経験値 += RAND(1, 4)

SOURCE:(MTAR:0):快Ａ += SENSE_HOUSHI(MPLY:0, MTAR:0, 500) * LOCAL:10 / 100
SOURCE:(MTAR:0):苦痛 = 5000 * 100 / LOCAL:10
SOURCE:(MTAR:0):逸脱 = 600
SOURCE:(MTAR:0):露出 = 400
SOURCE:(MTAR:0):性行動 = 150

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 50, 160)

IF PALAM:(MTAR:0):潤滑 < PALAMLV:1
	TIMES SOURCE:(MTAR:0):快Ａ, 0.05
	TIMES SOURCE:(MTAR:0):苦痛, 2.50
ELSEIF PALAM:(MTAR:0):潤滑 < PALAMLV:3
	TIMES SOURCE:(MTAR:0):快Ａ, 0.20
	TIMES SOURCE:(MTAR:0):苦痛, 2.00
ELSEIF PALAM:(MTAR:0):潤滑 < PALAMLV:5
	TIMES SOURCE:(MTAR:0):快Ａ, 0.60
	TIMES SOURCE:(MTAR:0):苦痛, 1.50
ELSEIF PALAM:(MTAR:0):潤滑 < PALAMLV:7
	TIMES SOURCE:(MTAR:0):快Ａ, 0.85
	TIMES SOURCE:(MTAR:0):苦痛, 1.20
ELSE
	TIMES SOURCE:(MTAR:0):快Ａ, 1.00
	TIMES SOURCE:(MTAR:0):苦痛, 1.00
ENDIF

IF GETBIT(TALENT:(MPLY:0):淫乱系, 素質_淫乱_サド)
	TIMES SOURCE:(MTAR:0):苦痛, 1.30
ENDIF

IF TALENT:(MTAR:0):体格 == 体格_小柄 && !TALENT:(MPLY:0):体格 == 体格_小柄
	TIMES SOURCE:(MTAR:0):苦痛, 1.30
ENDIF

CALL TIGHTNESS_DECREASE_A(MTAR:0, RAND(5, 8))
CALL VIRGIN_COMMON_A(MTAR:0, @"%ANAME(MPLY:0)%の腕", GET_SITUATION_BY_TRAIN_MODE())

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 12

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP88
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP88(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

;ターゲットのＶ拡張経験による諸々の倍率
LOCAL:10 = MIN(100 + EXP:(LOCAL:3):Ａ拡張経験 * 10 + MIN(ABL:(LOCAL:3):Ａ感, 6) * 30, 600)

;●プレイヤーの処理
DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):嗜虐経験値 += 1

SOURCE:(LOCAL:2):嗜虐 += 500
SOURCE:(LOCAL:2):逸脱 += 300
SOURCE:(LOCAL:2):性行動 += 30

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 += 12

;●ターゲットの処理
DOWNBASE:(LOCAL:3):体力 += 30

EXP:(LOCAL:3):Ａ拡張経験 += 1
EXP:(LOCAL:3):被虐経験値 += 1

SOURCE:(LOCAL:3):快Ａ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 300) * LOCAL:10 / 100
SOURCE:(LOCAL:3):苦痛 += 2000 * 100 / LOCAL:10
SOURCE:(LOCAL:3):逸脱 += 300
SOURCE:(LOCAL:3):露出 += 200
SOURCE:(LOCAL:3):性行動 += 50

IF PALAM:(LOCAL:3):潤滑 < PALAMLV:1
	TIMES SOURCE:(LOCAL:3):快Ａ, 0.05
	TIMES SOURCE:(LOCAL:3):苦痛, 2.50
ELSEIF PALAM:(LOCAL:3):潤滑 < PALAMLV:3
	TIMES SOURCE:(LOCAL:3):快Ａ, 0.20
	TIMES SOURCE:(LOCAL:3):苦痛, 2.00
ELSEIF PALAM:(LOCAL:3):潤滑 < PALAMLV:5
	TIMES SOURCE:(LOCAL:3):快Ａ, 0.60
	TIMES SOURCE:(LOCAL:3):苦痛, 1.50
ELSEIF PALAM:(LOCAL:3):潤滑 < PALAMLV:7
	TIMES SOURCE:(LOCAL:3):快Ａ, 0.85
	TIMES SOURCE:(LOCAL:3):苦痛, 1.20
ELSE
	TIMES SOURCE:(LOCAL:3):快Ａ, 1.00
	TIMES SOURCE:(LOCAL:3):苦痛, 1.00
ENDIF

IF GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_サド)
	TIMES SOURCE:(LOCAL:3):苦痛, 1.30
ENDIF

IF TALENT:(LOCAL:3):体格 == 体格_小柄 && !TALENT:(LOCAL:2):体格 == 体格_小柄
	TIMES SOURCE:(LOCAL:3):苦痛, 1.30
ENDIF

CALL TIGHTNESS_DECREASE_A(LOCAL:3, RAND(5, 8))

;倒錯度変化基準値
TCVAR:(LOCAL:3):50 += 12

;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)
CALL SUM_SOURCE(LOCAL:3)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
```
