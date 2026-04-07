# TRAIN/COMF/COMF7_尻尾Ａ挿入.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF7_尻尾Ａ挿入.ERB`

类型: .ERB

自动摘要: functions: COM_NAME7, COM_ABLE7, COM7, COM_IS_EQUIP7, COM_EQUIP7, EQUIP_MESSAGE7, COM_TEXT_BEFORE_EQUIP7, COM_TEXT_RELEASE_EQUIP7, COM_ORDER_PLAYER7, COM_TEXT_BEFORE7, COM_TEXT_LAST7, COM_AVAILABLE_WHEN7, COM_PREFERENCE_PLAYER_7, COM_PREFERENCE_TARGET_7; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;尻尾Ａ挿入

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME7
LOCALS:0 = 尻尾Ａ挿入

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE7
;共通部分
CALL COM_ABLE_COMMON(7)
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
;プレイヤーが尻尾を使用中なら不可
SIF IS_EQUIP_PLAYER(MPLY:0, 6, 7, 17)
	RETURN 0
;ターゲットのＶがプレイヤーの尻尾以外で埋まっているなら不可
SIF IS_A_HOLD(MTAR:0)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM7
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(LOCAL:2, 200)
SOURCE:(MPLY:0):接触 = 60
SOURCE:(MPLY:0):性行動 = 60

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 120, 50)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲットについて処理
SOURCE:(MTAR:0):露出 = 50
SOURCE:(MTAR:0):接触 = 60
SOURCE:(MTAR:0):性行動 = 150
SOURCE:(MTAR:0):快Ａ += SENSE_HOUSHI(MPLY:0, MTAR:0, 1400)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 60, 100)

CALL VIRGIN_COMMON_A(MTAR:0, @"%ANAME(MPLY:0)%の尻尾", GET_SITUATION_BY_TRAIN_MODE())


;対象の膣が緩む
CALL TIGHTNESS_DECREASE_A(MTAR:0, RAND(1, 4))

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 3

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP7
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP7(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●プレイヤーについて処理
EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 60)
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 20

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;●ターゲットについて処理
SOURCE:(LOCAL:3):快Ａ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 500)
SOURCE:(LOCAL:3):露出 += 20
SOURCE:(LOCAL:3):接触 += 30
SOURCE:(LOCAL:3):性行動 += 50

CALL VIRGIN_COMMON_A(LOCAL:3, @"%ANAME(LOCAL:2)%の尻尾", GET_SITUATION_BY_TRAIN_MODE())

;対象の膣が緩む
CALL TIGHTNESS_DECREASE_A(LOCAL:3, RAND(1, 4))

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE7(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%のアナルに尻尾を挿入中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP7(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%の尻尾が%EQUIP_TARGET_ANAME(ARG:0)%のアナルを抉っている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP7(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER7(ARG:0)
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
@COM_TEXT_BEFORE7
IF ABL:(MTAR:0):Ａ感 >= 3
	LOCALS:0 = 十分に開発されたアナル
ELSEIF ABL:(MTAR:0):Ａ感 >= 2
	LOCALS:0 = 開発途上のアナル
ELSE
	LOCALS:0 = キツく閉じたアナル
ENDIF

IF TALENT:(MTAR:0):美尻
	LOCALS:1 = %STR_BODY("尻：尻肉：長：接触", MTAR:0)%を割り開き、
ELSEIF GET_HIPSIZE(MTAR:0) >= 1
	LOCALS:1 = %STR_BODY("尻肉：長：接触", MTAR:0)%をかきわけ、
ELSE
	LOCALS:1 = 
ENDIF

;既に尻尾を挿入中の場合
IF SEARCH_EQUIP(7, MPLY:0, MTAR:0) >= 0
	SELECTCASE GET_COM_INITIATIVE()
		;プレイヤーに主導権
		CASE 0
```
