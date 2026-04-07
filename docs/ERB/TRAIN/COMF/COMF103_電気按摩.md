# TRAIN/COMF/COMF103_電気按摩.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF103_電気按摩.ERB`

类型: .ERB

自动摘要: functions: COM_NAME103, COM_ABLE103, COM103, COM_IS_EQUIP103, COM_EQUIP103, EQUIP_MESSAGE103, COM_TEXT_BEFORE_EQUIP103, COM_TEXT_RELEASE_EQUIP103, COM_ORDER_PLAYER103, COM_TEXT_BEFORE103, COM_AVAILABLE_WHEN103, COM_PREFERENCE_PLAYER_103, COM_PREFERENCE_TARGET_103, COM_STACK_SPERM_MTAR_TO_MPLY_103; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;電気按摩

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME103
LOCALS:0 = 電気按摩

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE103
;共通部分
CALL COM_ABLE_COMMON(103)
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
;プレイヤーが拘束中なら不可
SIF IS_BIND(MPLY:0)
	RETURN 0
;プレイヤーが顔面騎乗されているなら不可
SIF IS_RIDDEN(MPLY:0)
	RETURN 0
;either is grovelling
SIF IS_EQUIP_PLAYER(MPLY:0, 110) || IS_EQUIP_PLAYER(MTAR:0, 110)
	RETURN 0
;either is fucking
SIF IS_INSERT_SINGLE(MPLY:0, "全") ||IS_INSERT_SINGLE(MTAR:0, "全")
	RETURN 0
;giving/receiving footlicking or buttjob
SIF SEARCH_EQUIP_IC_M(MPLY:0, MTAR:0, 104, 15) >= 0
	RETURN 0
SIF !P_STACKABLE(MPLY:0, MTAR:0, 103)
	RETURN 0
SIF REACHING_BODY(MPLY:0, MTAR:0) || REACHING_BODY(MTAR:0, MPLY:0)
	RETURN 0
SIF REACHING_GROIN(MPLY:0, MTAR:0) || REACHING_GROIN(MTAR:0, MPLY:0)
	RETURN 0
SIF LICKING_BODY(MPLY:0, MTAR:0) || LICKING_BODY(MTAR:0, MPLY:0)
	RETURN 0
SIF LICKING_GROIN(MPLY:0, MTAR:0) || LICKING_GROIN(MTAR:0, MPLY:0)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM103
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●プレイヤーについて判定
DOWNBASE:(MPLY:0):体力 += 120

EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 150)
SOURCE:(MPLY:0):接触 = 60
SOURCE:(MPLY:0):逸脱 = 40
SOURCE:(MPLY:0):性行動 = 150
EXP:(MPLY:0):嗜虐経験値 += 1

;プレイヤー主導の場合
IF GET_COM_INITIATIVE() == 0
	SOURCE:(MPLY:0):嗜虐 = 100
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 190, 80)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲットについて判定
DOWNBASE:(MTAR:0):体力 += 80

SOURCE:(MTAR:0):接触 = 60
SOURCE:(MTAR:0):逸脱 = 40
SOURCE:(MTAR:0):苦痛 = 60
SOURCE:(MTAR:0):露出 = 80
SOURCE:(MTAR:0):性行動 = 150
EXP:(MTAR:0):被虐経験値 += 1

IF HAS_PENIS(MTAR:0)
	SOURCE:(MTAR:0):快Ｐ = SENSE_HOUSHI_P(MPLY:0, MTAR:0, 1200 + TALENT:(MPLY:0):美脚 * 300)
ELSE
	SOURCE:(MTAR:0):快Ｃ = SENSE_HOUSHI(MPLY:0, MTAR:0, 1200 + TALENT:(MPLY:0):美脚 * 300)
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 80, 140)

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
@COM_IS_EQUIP103
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP103(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●プレイヤーの処理
DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 50)
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):逸脱 += 20
SOURCE:(LOCAL:2):性行動 += 50
EXP:(LOCAL:2):嗜虐経験値 += 1

;プレイヤーに主導権がある場合
IF IS_INITIATIVE(LOCAL:2)
	SOURCE:(LOCAL:2):嗜虐 += 50
ENDIF

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 += 3

;●ターゲットの処理
DOWNBASE:(LOCAL:3):体力 += 10

SOURCE:(LOCAL:3):接触 += 30
SOURCE:(LOCAL:3):逸脱 += 20
SOURCE:(LOCAL:3):苦痛 += 30
SOURCE:(LOCAL:3):露出 += 40
SOURCE:(LOCAL:3):性行動 += 50
IF HAS_PENIS(LOCAL:3)
	SOURCE:(LOCAL:3):快Ｐ = SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 400 + TALENT:(LOCAL:2):美脚 * 100)
ELSE
	SOURCE:(LOCAL:3):快Ｃ = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 400 + TALENT:(LOCAL:2):美脚 * 100)
ENDIF
EXP:(LOCAL:3):被虐経験値 += 1

;倒錯度変化基準値
TCVAR:(LOCAL:3):50 += 3

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE103(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に電気按摩中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP103(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の股間を踏みつけ振動を与えている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP103(ARG:0)
PRINTFORMW %EQUIP_PLAYER_ANAME(ARG:0)%は%EQUIP_TARGET_ANAME(ARG:0)%の股間から足を離した…

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER103(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 85

;共通部分
```
