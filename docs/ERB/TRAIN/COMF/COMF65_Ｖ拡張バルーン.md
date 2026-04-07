# TRAIN/COMF/COMF65_Ｖ拡張バルーン.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF65_Ｖ拡張バルーン.ERB`

类型: .ERB

自动摘要: functions: COM_NAME65, COM_ABLE65, COM65, COM_IS_EQUIP65, COM_EQUIP65, EQUIP_MESSAGE65, COM_TEXT_BEFORE_EQUIP65, COM_TEXT_RELEASE_EQUIP65, COM_ORDER_PLAYER65, COM_TEXT_BEFORE65, COM_TEXT_LAST65, COM_COMMON65, COM_AVAILABLE_WHEN65, COM_PREFERENCE_PLAYER_65, COM_PREFERENCE_TARGET_65; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;Ｖ拡張バルーン

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME65
LOCALS:0 = Ｖ拡張バルーン

RESULTS:0 = %LOCALS:0%で責める
RESULTS:1 = %LOCALS:0%で奉仕する
RESULTS:2 = %LOCALS:0%で奉仕させる
RESULTS:3 = %LOCALS:0%で責められる
RESULTS:4 = %LOCALS:0%で責めさせる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE65
;共通部分
CALL COM_ABLE_COMMON(65)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;拡張バルーンが必要
SIF !ITEM:拡張バルーン && !ITEM:A_拡張バルーン
	RETURN 0
;対象にＶが必要
SIF !HAS_VAGINA(MTAR:0)
	RETURN 0
;ターゲットのＶが塞がっていれば不可
SIF IS_V_HOLD(MTAR:0)
	RETURN 0
SIF !CAN_REACH_GROIN(MPLY:0, MTAR:0) && !FLAG:RECHECKING
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM65
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;ターゲットのＶ拡張経験による諸々の倍率
LOCAL:10 = MIN(100 + EXP:(MTAR:0):Ｖ拡張経験 * 10 + MIN(ABL:(MTAR:0):Ｖ感, 6) * 40, 600)

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += MTAR_NUM / 2 + 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 200)
SOURCE:(MPLY:0):接触 = 10
SOURCE:(MPLY:0):逸脱 = 100
SOURCE:(MPLY:0):性行動 = 150

IF IS_INITIATIVE(MPLY:0)
	SOURCE:(MPLY:0):嗜虐 = 120
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 50)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲットについて処理
EXP:(MTAR:0):Ｖ拡張経験 += 1

SOURCE:(MTAR:0):露出 = 70
SOURCE:(MTAR:0):逸脱 = 300
SOURCE:(MTAR:0):接触 = 10
SOURCE:(MTAR:0):性行動 = 300

IF TALENT:(MPLY:0):技師
	SOURCE:(MTAR:0):快Ｖ += SENSE_HOUSHI(MPLY:0, MTAR:0, 400) * (LOCAL:10 + 50) / 150
	SOURCE:(MTAR:0):苦痛 = 1200 * 100 / LOCAL:10
ELSE
	SOURCE:(MTAR:0):快Ｖ += SENSE_HOUSHI(MPLY:0, MTAR:0, 300) * (LOCAL:10 + 50) / 150
	SOURCE:(MTAR:0):苦痛 = 1600 * 100 / LOCAL:10
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 50, 80)

;Ｖ拡張バルーンの共通処理
CALL COM_COMMON65(MTAR:0)

IF TALENT:(MTAR:0):処女
	IF MPLY:0 == MASTER
		;処女喪失フラグ(主人に性交以外で奪われる)
		TCVAR:(MTAR:0):13 = 2
	ELSE
		;処女喪失フラグ(主人以外に性交以外で奪われる)
		TCVAR:(MTAR:0):13 = 4
	ENDIF
ENDIF

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 2

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP65
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP65(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

SOURCE:(LOCAL:2):性行動 += 50

;ターゲットのＶ拡張経験による諸々の倍率
LOCAL:10 = MIN(100 + EXP:(LOCAL:3):Ｖ拡張経験 * 10 + MIN(ABL:(LOCAL:3):Ｖ感, 6) * 40, 600)

EXP:(LOCAL:3):Ｖ拡張経験 += 1

SOURCE:(LOCAL:3):露出 += 30
SOURCE:(LOCAL:3):逸脱 += 120
SOURCE:(LOCAL:3):性行動 += 100

IF TALENT:(LOCAL:2):技師
	SOURCE:(LOCAL:3):快Ｖ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 200) * (LOCAL:10 + 50) / 150
	SOURCE:(LOCAL:3):苦痛 = 600 * 100 / LOCAL:10
ELSE
	SOURCE:(LOCAL:3):快Ｖ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 150) * (LOCAL:10 + 50) / 150
	SOURCE:(LOCAL:3):苦痛 = 800 * 100 / LOCAL:10
ENDIF

;倒錯度変化
TCVAR:(LOCAL:3):50 += 1

;Ｖ拡張バルーンの共通処理
CALL COM_COMMON65(LOCAL:3)

;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)
CALL SUM_SOURCE(LOCAL:3)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE65(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%の膣内に拡張バルーンを挿入中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP65(ARG:0)
PRINTFORML %EQUIP_TARGET_ANAME(ARG:0)%の膣は拡張バルーンで押し広げられている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP65(ARG:0)
PRINTFORMW %EQUIP_TARGET_ANAME(ARG:0)%の膣内から拡張バルーンを取り出した

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER65(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 85

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
```
