# TRAIN/COMF/COMF8_アナル舐め.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF8_アナル舐め.ERB`

类型: .ERB

自动摘要: functions: COM_NAME8, COM_ABLE8, COM8, COM_IS_EQUIP8, COM_EQUIP8, EQUIP_MESSAGE8, COM_TEXT_BEFORE_EQUIP8, COM_TEXT_RELEASE_EQUIP8, COM_ORDER_PLAYER8, COM_TEXT_BEFORE8, COM_TEXT_LAST8, COM_AVAILABLE_WHEN8, COM_PREFERENCE_PLAYER_8, COM_PREFERENCE_TARGET_8, COM_STACK_SPERM_MTAR_TO_MPLY_8; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;クンニ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME8
LOCAL:0 = IS_RIDE(MPLY:0, MTAR:0)

;男性プレイヤーがターゲットに顔面騎乗中
IF LOCAL:0 && !HAS_VAGINA(MPLY:0)
	LOCALS:0 = 顔騎アナル舐め
;非男性プレイヤーがターゲットに顔面騎乗中 or ターゲットからプレイヤーにフェラ・クンニ・アナル舐め中
ELSEIF LOCAL:0 || SEARCH_EQUIP(11, MTAR:0, MPLY:0) >= 0 || SEARCH_EQUIP(2, MTAR:0, MPLY:0) >= 0 || SEARCH_EQUIP(8, MTAR:0, MPLY:0) >= 0
	LOCALS:0 = Ａシックスナイン
ELSE
	LOCALS:0 = アナル舐め
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
@COM_ABLE8
;共通部分
CALL COM_ABLE_COMMON(8)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
SIF !CAN_LICK_GROIN(MPLY:0 ,MTAR:0)
	RETURN 0
;target already getting a rimjob
SIF IS_EQUIP_TARGET(MTAR:0, 8)
	RETURN 0
;vaginal facesitting is a special case
SIF IS_EQUIP_PLAYER(MTAR:0, 101)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM8
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●プレイヤーについて処理
DOWNBASE:(MPLY:0):体力 += 120

EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 300)
SOURCE:(MPLY:0):接触 = 50
SOURCE:(MPLY:0):性行動 = 300

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 100)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;膣口へのキス
CALL KISS_COMMON(MPLY:0, @"%ANAME(MTAR:0)%のアナル", GET_SITUATION_BY_TRAIN_MODE())

;●ターゲットについて処理
DOWNBASE:(MTAR:0):体力 += 60

SOURCE:(MTAR:0):液体追加 = 300
SOURCE:(MTAR:0):露出 = 150
SOURCE:(MTAR:0):逸脱 = 50
SOURCE:(MTAR:0):接触 = 50
SOURCE:(MTAR:0):快Ａ = SENSE_HOUSHI(MPLY:0, MTAR:0, 1500)
SOURCE:(MTAR:0):性行動 = 300

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 150, 0)

IF TALENT:(MPLY:0):舌使い
	TIMES SOURCE:(MTAR:0):快Ａ, 1.50
ENDIF

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP8
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP8(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●プレイヤーの処理
DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
SOURCE:(LOCAL:2):接触 += 25
SOURCE:(LOCAL:2):性行動 += 100

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;●ターゲットの処理
DOWNBASE:(LOCAL:3):体力 += 10

SOURCE:(LOCAL:3):液体追加 += 150
SOURCE:(LOCAL:3):露出 += 75
SOURCE:(LOCAL:3):逸脱 += 25
SOURCE:(LOCAL:3):接触 += 25
SOURCE:(LOCAL:3):性行動 += 100

IF TALENT:(LOCAL:2):舌使い
	SOURCE:(LOCAL:3):快Ａ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 1125)
ELSE
	SOURCE:(LOCAL:3):快Ａ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 750)
ENDIF

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE8(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%にアナル舐め中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP8(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%のアナルを舌で舐めている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP8(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER8(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 90

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 2, 20))

IF TCVAR:(ARG:0):60
	CALL COM_ORDER_ELEMENT(ARG:0, "媚薬", 6)
ENDIF

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -1)
ENDIF
IF TALENT:(ARG:0):汚臭鈍感
	CALL COM_ORDER_ELEMENT(ARG:0, "汚臭鈍感", 1)
ENDIF
IF TALENT:(ARG:0):汚臭敏感
	CALL COM_ORDER_ELEMENT(ARG:0, "汚臭敏感", -3)
ENDIF
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 6)
ENDIF
IF TALENT:(ARG:0):快感の否定
	CALL COM_ORDER_ELEMENT(ARG:0, "快感の否定", -1)
ENDIF
;合意
IF !TALENT:(ARG:0):合意 && !TALENT:(ARG:0):親友
	CALL COM_ORDER_ELEMENT(ARG:0, "合意なし", -10)
```
