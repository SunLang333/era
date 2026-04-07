# TRAIN/COMF/COMF68_ペニバン口枷.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF68_ペニバン口枷.ERB`

类型: .ERB

自动摘要: functions: COM_NAME68, COM_ABLE68, COM68, COM_IS_EQUIP68, COM_EQUIP68, EQUIP_MESSAGE68, COM_TEXT_BEFORE_EQUIP68, COM_TEXT_RELEASE_EQUIP68, COM_ORDER_PLAYER68, COM_TEXT_BEFORE68, COM_TEXT_LAST68, COM_COMMON68, COM_AVAILABLE_WHEN68, COM_PREFERENCE_PLAYER_68, COM_PREFERENCE_TARGET_68; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;バイブ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME68
LOCALS:0 = ペニバン口枷

RESULTS:0 = %LOCALS:0%で責める
RESULTS:1 = %LOCALS:0%で奉仕する
RESULTS:2 = %LOCALS:0%で奉仕させる
RESULTS:3 = %LOCALS:0%で責められる
RESULTS:4 = %LOCALS:0%で責めさせる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE68
;共通部分
CALL COM_ABLE_COMMON(68)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0
;requires strapon
SIF (!ITEM:ペニスバンド && !ITEM:A_ペニスバンド)
	RETURN 0
FOR LOCAL:0, 0, MTAR_NUM
	;ターゲットの口が塞がっているなら不可
	SIF IS_M_HOLD(MTAR:(LOCAL:0))
		RETURN 0
	SIF !CAN_REACH_BODY(MPLY:0, MTAR:0) && !FLAG:RECHECKING
		RETURN 0
    ;already equipped
	SIF IS_EQUIP_TARGET(MTAR:(LOCAL:0), 68)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM68
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤーについて処理
DOWNBASE:(MPLY:0):体力 += 80

EXP:(MPLY:0):性技経験値 += MTAR_NUM / 2 + 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 200)
SOURCE:(MPLY:0):接触 = 10
SOURCE:(MPLY:0):性行動 = 150

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 20)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)
	;●ターゲットについて処理
	DOWNBASE:(LOCAL:2):体力 += 80
	EXP:(LOCAL:2):性技経験値 += 1
	SOURCE:(LOCAL:2):露出 = 50
	SOURCE:(LOCAL:2):逸脱 = 120
	SOURCE:(LOCAL:2):接触 = 10
	SOURCE:(LOCAL:2):性行動 = 300
	IF TALENT:(MPLY:0):技師
		SOURCE:(LOCAL:2):快Ｍ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 900)
	ELSE
		SOURCE:(LOCAL:2):快Ｍ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 600)
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 20)

	;バイブの共通処理
	CALL COM_COMMON68(LOCAL:2)
NEXT
;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 1

;レズ・ＢＬ経験基準値
TFLAG:51 = 2

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP68
RETURN 2

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP68(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
SOURCE:(LOCAL:2):性行動 += 50
;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)

FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)
	CALL PUTOUT_SOURCE(LOCAL:3)
	EXP:(LOCAL:2):性技経験値 += 1
	IF TALENT:(LOCAL:2):技師
		SOURCE:(LOCAL:3):快Ｍ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 600)
	ELSE
		SOURCE:(LOCAL:3):快Ｍ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 300)
	ENDIF
	SOURCE:(LOCAL:3):露出 += 20
	SOURCE:(LOCAL:3):逸脱 += 50
	SOURCE:(LOCAL:3):性行動 += 100

	;倒錯度変化
	TCVAR:(LOCAL:3):50 += 1

	;共通処理
	CALL COM_COMMON68(LOCAL:3)

	;退避したソースを加算
	CALL SUM_SOURCE(LOCAL:3)
NEXT
;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE68(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%
RESULTS += "の口をペニバン責め中"

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP68(ARG:0)
PRINTFORM %EQUIP_TARGET_ANAME(ARG:0)%
PRINTFORML の口内をペニスバンドが責めている

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP68(ARG:0)
PRINTFORM %EQUIP_TARGET_ANAME(ARG:0)%
PRINTFORMW の口からペニスバンドを引き抜いた

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER68(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 70

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

;-------------------------------------------------
;地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE68

IF MTAR_NUM >= 2
	LOCALS:1 = %ANAME(MTAR:0)%たち
ELSE
```
