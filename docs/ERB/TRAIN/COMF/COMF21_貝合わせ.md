# TRAIN/COMF/COMF21_貝合わせ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF21_貝合わせ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME21, COM_ABLE21, COM21, COM_IS_EQUIP21, COM_EQUIP21, EQUIP_MESSAGE21, COM_TEXT_BEFORE_EQUIP21, COM_TEXT_RELEASE_EQUIP21, COM_ORDER_PLAYER21, COM_ORDER_TARGET21, COM_ORDER_COMMON21, COM_TEXT_BEFORE21, COM_AVAILABLE_WHEN21, COM_PREFERENCE_PLAYER_21, COM_PREFERENCE_TARGET_21; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;貝合わせ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME21
LOCALS:0 = 貝合わせ

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE21
;共通部分
CALL COM_ABLE_COMMON(21)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;プレイヤーとターゲットが共に行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
SIF !HAS_VAGINA(MPLY:0) || !HAS_VAGINA(MTAR:0)
	RETURN 0
SIF IS_RIDE(MPLY:0) || IS_RIDE(MTAR:0)
	RETURN 0
;grovelling
SIF IS_EQUIP_PLAYER(MPLY:0, 110) || IS_EQUIP_PLAYER(MTAR:0, 110)
	RETURN 0
;プレイヤーとターゲットが共に拘束中なら不可
SIF IS_BIND(MPLY:0) && IS_BIND(MTAR:0)
	RETURN 0
;Todo - vibrators and balloons should perhaps be exempted
SIF IS_V_HOLD(MPLY:0) || IS_V_HOLD(MTAR:0)
	RETURN 0
;either is fucking or fucked by anyone
SIF IS_INSERT_SINGLE(MPLY:0, "全") || IS_INSERT_SINGLE(MTAR:0, "全")
	RETURN 0
SIF REACHING_BODY(MPLY, MTAR) || REACHING_BODY(MTAR, MPLY)
	RETURN 0
SIF LICKING_GROIN(MPLY, MTAR) || LICKING_GROIN(MTAR, MPLY)
	RETURN 0
SIF LICKING_BODY(MPLY, MTAR) || LICKING_BODY(MTAR, MPLY)
	RETURN 0
;giving/receiving assjob, trampling, footjob
SIF SEARCH_EQUIP_IC_M(MPLY:0, MTAR:0, 14, 15, 103) >= 0
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM21
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●潤滑による各種倍率の計算
LOCAL:10 = 0
IF PALAM:(MPLY:0):潤滑 < PALAMLV:1
	LOCAL:10 += 10
ELSEIF PALAM:(MPLY:0):潤滑 < PALAMLV:3
	LOCAL:10 += 20
ELSEIF PALAM:(MPLY:0):潤滑 < PALAMLV:5
	LOCAL:10 += 30
ELSEIF PALAM:(MPLY:0):潤滑 < PALAMLV:7
	LOCAL:10 += 40
ELSE
	LOCAL:10 += 50
ENDIF
IF PALAM:(MTAR:0):潤滑 < PALAMLV:1
	LOCAL:10 += 10
ELSEIF PALAM:(MTAR:0):潤滑 < PALAMLV:3
	LOCAL:10 += 20
ELSEIF PALAM:(MTAR:0):潤滑 < PALAMLV:5
	LOCAL:10 += 30
ELSEIF PALAM:(MTAR:0):潤滑 < PALAMLV:7
	LOCAL:10 += 40
ELSE
	LOCAL:10 += 50
ENDIF

;●プレイヤーについて処理
DOWNBASE:(MPLY:0):体力 += 120

EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):快Ｃ = SENSE_HOUSHI(MTAR:0, MPLY:0, 1600) * LOCAL:10 / 100
SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 100)
SOURCE:(MPLY:0):接触 = 120
SOURCE:(MPLY:0):性行動 = 300

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 40, 40)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲットについて処理
DOWNBASE:(MTAR:0):体力 += 120

EXP:(MTAR:0):性技経験値 += 1

SOURCE:(MTAR:0):快Ｃ = SENSE_HOUSHI(MPLY:0, MTAR:0, 1600) * LOCAL:10 / 100
SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 100)
SOURCE:(MTAR:0):接触 = 120
SOURCE:(MTAR:0):性行動 = 300

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 40, 40)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 7

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP21
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP21(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●潤滑による各種倍率の計算
LOCAL:10 = 0
IF PALAM:(LOCAL:2):潤滑 < PALAMLV:1
	LOCAL:10 += 10
ELSEIF PALAM:(LOCAL:2):潤滑 < PALAMLV:3
	LOCAL:10 += 20
ELSEIF PALAM:(LOCAL:2):潤滑 < PALAMLV:5
	LOCAL:10 += 30
ELSEIF PALAM:(LOCAL:2):潤滑 < PALAMLV:7
	LOCAL:10 += 40
ELSE
	LOCAL:10 += 50
ENDIF
IF PALAM:(LOCAL:3):潤滑 < PALAMLV:1
	LOCAL:10 += 10
ELSEIF PALAM:(LOCAL:3):潤滑 < PALAMLV:3
	LOCAL:10 += 20
ELSEIF PALAM:(LOCAL:3):潤滑 < PALAMLV:5
	LOCAL:10 += 30
ELSEIF PALAM:(LOCAL:3):潤滑 < PALAMLV:7
	LOCAL:10 += 40
ELSE
	LOCAL:10 += 50
ENDIF

;●プレイヤーについて処理
DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):快Ｃ += SENSE_HOUSHI(LOCAL:3, LOCAL:2, 800) * LOCAL:10 / 100
SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 50)
SOURCE:(LOCAL:2):接触 += 60
SOURCE:(LOCAL:2):性行動 += 100

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1


;●ターゲットについて処理
DOWNBASE:(LOCAL:3):体力 += 20

EXP:(LOCAL:3):性技経験値 += 1

SOURCE:(LOCAL:3):快Ｃ = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 800) * LOCAL:10 / 100
SOURCE:(LOCAL:3):奉仕 = SERVE_HOUSHI(LOCAL:3, 50)
SOURCE:(LOCAL:3):接触 = 60
SOURCE:(LOCAL:3):性行動 += 100

;奉仕経験値を得られるコマンドのフラグ
```
