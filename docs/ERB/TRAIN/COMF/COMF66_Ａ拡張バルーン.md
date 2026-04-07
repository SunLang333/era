# TRAIN/COMF/COMF66_Ａ拡張バルーン.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF66_Ａ拡張バルーン.ERB`

类型: .ERB

自动摘要: functions: COM_NAME66, COM_ABLE66, COM66, COM_IS_EQUIP66, COM_EQUIP66, EQUIP_MESSAGE66, COM_TEXT_BEFORE_EQUIP66, COM_TEXT_RELEASE_EQUIP66, COM_ORDER_PLAYER66, COM_TEXT_BEFORE66, COM_TEXT_LAST66, COM_COMMON66, COM_AVAILABLE_WHEN66, COM_PREFERENCE_PLAYER_66, COM_PREFERENCE_TARGET_66; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;Ａ拡張バルーン

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME66
LOCALS:0 = Ａ拡張バルーン

RESULTS:0 = %LOCALS:0%で責める
RESULTS:1 = %LOCALS:0%で奉仕する
RESULTS:2 = %LOCALS:0%で奉仕させる
RESULTS:3 = %LOCALS:0%で責められる
RESULTS:4 = %LOCALS:0%で責めさせる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE66
;共通部分
CALL COM_ABLE_COMMON(66)
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
;拡張バルーンが必要
SIF !ITEM:拡張バルーン && !ITEM:A_拡張バルーン
	RETURN 0
SIF IS_A_HOLD(MTAR:0)
	RETURN 0
SIF !CAN_REACH_GROIN(MPLY:0, MTAR:0) && !FLAG:RECHECKING
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM66
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;ターゲットのＡ拡張経験による諸々の倍率
LOCAL:10 = MIN(100 + EXP:(MTAR:0):Ａ拡張経験 * 10 + MIN(ABL:(MTAR:0):Ａ感, 6) * 40, 600)

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += MTAR_NUM / 2 + 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 200)
SOURCE:(MPLY:0):接触 = 10
SOURCE:(MPLY:0):逸脱 = 150
SOURCE:(MPLY:0):性行動 = 90

IF IS_INITIATIVE(MPLY:0)
	SOURCE:(MPLY:0):嗜虐 = 150
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 50)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲットについて処理
EXP:(MTAR:0):Ａ拡張経験 += 1

SOURCE:(MTAR:0):露出 = 90
SOURCE:(MTAR:0):逸脱 = 400
SOURCE:(MTAR:0):接触 = 10
SOURCE:(MTAR:0):性行動 = 150

IF TALENT:(MPLY:0):技師
	SOURCE:(MTAR:0):快Ａ += SENSE_HOUSHI(MPLY:0, MTAR:0, 400) * (LOCAL:10 + 50) / 150
	SOURCE:(MTAR:0):苦痛 = 1500 * 100 / LOCAL:10
ELSE
	SOURCE:(MTAR:0):快Ａ += SENSE_HOUSHI(MPLY:0, MTAR:0, 300) * (LOCAL:10 + 50) / 150
	SOURCE:(MTAR:0):苦痛 = 2000 * 100 / LOCAL:10
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 50, 110)

;Ａ拡張バルーンの共通処理
CALL COM_COMMON66(MTAR:0)

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
@COM_IS_EQUIP66
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP66(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

SOURCE:(LOCAL:2):性行動 += 30

;ターゲットのＡ拡張経験による諸々の倍率
LOCAL:10 = MIN(100 + EXP:(LOCAL:3):Ａ拡張経験 * 10 + MIN(ABL:(LOCAL:3):Ａ感, 6) * 40, 600)

EXP:(LOCAL:3):Ａ拡張経験 += 1

SOURCE:(LOCAL:3):露出 += 40
SOURCE:(LOCAL:3):逸脱 += 140
SOURCE:(LOCAL:3):性行動 += 50

IF TALENT:(LOCAL:2):技師
	SOURCE:(LOCAL:3):快Ａ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 200) * (LOCAL:10 + 50) / 150
	SOURCE:(LOCAL:3):苦痛 = 750 * 100 / LOCAL:10
ELSE
	SOURCE:(LOCAL:3):快Ａ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 150) * (LOCAL:10 + 50) / 150
	SOURCE:(LOCAL:3):苦痛 = 1000 * 100 / LOCAL:10
ENDIF

;倒錯度変化
TCVAR:(LOCAL:3):50 += 1

;Ａ拡張バルーンの共通処理
CALL COM_COMMON66(LOCAL:3)

;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)
CALL SUM_SOURCE(LOCAL:3)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE66(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%のアナルに拡張バルーンを挿入中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP66(ARG:0)
PRINTFORML %EQUIP_TARGET_ANAME(ARG:0)%のアナルは拡張バルーンで押し広げられている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP66(ARG:0)
PRINTFORMW %EQUIP_TARGET_ANAME(ARG:0)%のアナルから拡張バルーンを取り出した

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER66(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 90

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

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

```
