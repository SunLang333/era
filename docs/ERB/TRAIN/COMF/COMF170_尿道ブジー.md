# TRAIN/COMF/COMF170_尿道ブジー.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF170_尿道ブジー.ERB`

类型: .ERB

自动摘要: functions: COM_NAME170, COM_ABLE170, COM170, COM_IS_EQUIP170, COM_EQUIP170, EQUIP_MESSAGE170, COM_TEXT_BEFORE_EQUIP170, COM_TEXT_RELEASE_EQUIP170, COM_ORDER_PLAYER170, COM_TEXT_BEFORE170, COM_TEXT_LAST170, COM_COMMON170, COM_AVAILABLE_WHEN170, COM_PREFERENCE_PLAYER_170, COM_PREFERENCE_TARGET_170; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;尿道ブジー

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME170
LOCALS:0 = 尿道ブジー

RESULTS:0 = %LOCALS:0%で責める
RESULTS:1 = %LOCALS:0%で奉仕する
RESULTS:2 = %LOCALS:0%で奉仕させる
RESULTS:3 = %LOCALS:0%で責められる
RESULTS:4 = %LOCALS:0%で責めさせる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE170
;共通部分
CALL COM_ABLE_COMMON(170)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0

;アイテムが必要
SIF ITEM:尿道ブジー == 0 && ITEM:A_尿道ブジー == 0
	RETURN 0

FOR LOCAL:0, 0, MTAR_NUM
	;V not occupied (Unless by fingering, in Recheck mode)
	SIF IS_U_HOLD(MTAR:(LOCAL:0)) && !(FLAG:RECHECKING && IS_EQUIP_TARGET(MTAR:LOCAL, 3))
		RETURN 0
	SIF !CAN_REACH_GROIN(MPLY:0, MTAR:LOCAL) && !FLAG:RECHECKING
		RETURN 0
	;ターゲットが挿入中なら不可
	SIF IS_INSERT_SINGLE(MTAR:LOCAL, "全")
		RETURN 0
NEXT


RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM170
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤーについて処理
DOWNBASE:(MPLY:0):体力 += 80

EXP:(MPLY:0):性技経験値 += MTAR_NUM / 2 + 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 200)
SOURCE:(MPLY:0):接触 = 10
SOURCE:(MPLY:0):性行動 = 90

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 180, 20)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)
	;●ターゲットについて処理
	EXP:(LOCAL:2):Ｕ開発経験 += 1
	DOWNBASE:(LOCAL:2):体力 += 80

	SOURCE:(LOCAL:2):露出 = 70
	SOURCE:(LOCAL:2):逸脱 = 300
	SOURCE:(LOCAL:2):接触 = 10
	SOURCE:(LOCAL:2):性行動 = 150
	SOURCE:(LOCAL:2):快Ｕ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 700)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 20, 100)

	IF TALENT:(MPLY:0):技師
		TIMES SOURCE:(LOCAL:2):快Ｕ, 1.30
	ENDIF

	;尿道ブジーの共通処理
	CALL COM_COMMON170(LOCAL:2)

	TCVAR:(LOCAL:2):54 = 0

NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 3

;レズ・ＢＬ経験基準値
TFLAG:51 = 2

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP170
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP170(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
SOURCE:(LOCAL:2):性行動 += 30
;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)

FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)

	LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)
	CALL PUTOUT_SOURCE(LOCAL:3)
	EXP:(LOCAL:3):Ｕ開発経験 += 1
	IF TALENT:(LOCAL:2):技師
		SOURCE:(LOCAL:3):快Ｕ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 500)
	ELSE
		SOURCE:(LOCAL:3):快Ｕ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 300)
	ENDIF
	SOURCE:(LOCAL:3):露出 += 20
	SOURCE:(LOCAL:3):逸脱 += 200
	SOURCE:(LOCAL:3):性行動 += 50

	;倒錯度変化
	TCVAR:(LOCAL:3):50 += 3

	;尿道ブジーの共通処理
	CALL COM_COMMON170(LOCAL:3)

	;退避したソースを加算
	CALL SUM_SOURCE(LOCAL:3)
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE170(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%
RESULTS += "に尿道ブジーを挿入中"

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP170(ARG:0)
PRINTFORM  %EQUIP_TARGET_ANAME(ARG:0)%
PRINTFORML の尿道にブジーが入っている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP170(ARG:0)
PRINTFORM  %EQUIP_TARGET_ANAME(ARG:0)%
PRINTFORMW の尿道からブジーを引き抜いた
;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER170(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 75

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
IF !TALENT:(ARG:0):合意 && !TALENT:(ARG:0):烙印
	CALL COM_ORDER_ELEMENT(ARG:0, "合意なし", -10)
ENDIF
```
