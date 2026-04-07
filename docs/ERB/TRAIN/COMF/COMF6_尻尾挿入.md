# TRAIN/COMF/COMF6_尻尾挿入.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF6_尻尾挿入.ERB`

类型: .ERB

自动摘要: functions: COM_NAME6, COM_ABLE6, COM6, COM_IS_EQUIP6, COM_EQUIP6, EQUIP_MESSAGE6, COM_TEXT_BEFORE_EQUIP6, COM_TEXT_RELEASE_EQUIP6, COM_ORDER_PLAYER6, COM_TEXT_BEFORE6, COM_TEXT_LAST6, COM_AVAILABLE_WHEN6, COM_PREFERENCE_PLAYER_6, COM_PREFERENCE_TARGET_6; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;尻尾挿入

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME6
LOCALS:0 = 尻尾挿入

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE6
;共通部分
CALL COM_ABLE_COMMON(6)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;プレイヤーに尻尾が必要
SIF !TALENT:(MPLY:0):しっぽ
	RETURN 0
;ターゲットにＶが必要
SIF !HAS_VAGINA(MTAR:0)
	RETURN 0
;ターゲットのＶがプレイヤーの尻尾以外で埋まっているなら不可
SIF IS_V_HOLD(MTAR:0)
	RETURN 0
;プレイヤーが尻尾を使用中なら不可
SIF IS_EQUIP_PLAYER(MPLY:0, 6, 7, 17)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM6
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(LOCAL:2, 200)
SOURCE:(MPLY:0):接触 = 60
SOURCE:(MPLY:0):性行動 = 120

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 120, 50)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲットについて処理
SOURCE:(MTAR:0):露出 = 50
SOURCE:(MTAR:0):接触 = 60
SOURCE:(MTAR:0):性行動 = 300

IF TALENT:(MTAR:0):処女 == 1
	SOURCE:(MTAR:0):快Ｖ += SENSE_HOUSHI(MPLY:0, MTAR:0, 1050)
ELSE
	SOURCE:(MTAR:0):快Ｖ += SENSE_HOUSHI(MPLY:0, MTAR:0, 1400)
ENDIF

CALL VIRGIN_COMMON(MTAR:0, @"%ANAME(MPLY:0)%の尻尾", GET_SITUATION_BY_TRAIN_MODE())

;対象の膣が緩む
CALL TIGHTNESS_DECREASE_V(MTAR:0, RAND(1, 4))

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 60, 60)

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 1

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP6
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP6(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●プレイヤーについて処理
EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 60)
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 40

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;●ターゲットについて処理
SOURCE:(LOCAL:3):快Ｖ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 500)
SOURCE:(LOCAL:3):露出 += 20
SOURCE:(LOCAL:3):接触 += 30
SOURCE:(LOCAL:3):性行動 += 100

CALL VIRGIN_COMMON(LOCAL:3, @"%ANAME(LOCAL:2)%の尻尾", GET_SITUATION_BY_TRAIN_MODE())

;対象の膣が緩む
CALL TIGHTNESS_DECREASE_V(LOCAL:3, RAND(1, 4))

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE6(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の膣に尻尾を挿入中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP6(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%の尻尾が%EQUIP_TARGET_ANAME(ARG:0)%の膣壁を擦り上げている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP6(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER6(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 65

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
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 6)
ENDIF
IF TALENT:(ARG:0):快感の否定
	CALL COM_ORDER_ELEMENT(ARG:0, "快感の否定", -1)
ENDIF

;合意
IF !TALENT:(ARG:0):合意 && !TALENT:(ARG:0):親友
	CALL COM_ORDER_ELEMENT(ARG:0, "合意なし", -10)
ENDIF
RETURN 1

;-------------------------------------------------
;地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE6
IF TALENT:(MTAR:0):処女 == 1
	LOCALS:0 = まだ乙女の
ELSEIF PALAM:(MTAR:0):潤滑 >= PALAMLV:7
	LOCALS:0 = 濡れそぼった
ELSE
	LOCALS:0 = 
ENDIF

IF TALENT:(MTAR:0):体格 == 体格_子供
	LOCALS:0 = %LOCALS:0%幼いワレメ
ELSE
	LOCALS:0 = %LOCALS:0%ワレメ
ENDIF

```
