# TRAIN/COMF/COMF206_触手コキ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF206_触手コキ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME206, COM_ABLE206, COM206, COM_IS_EQUIP206, COM_EQUIP206, EQUIP_MESSAGE206, COM_TEXT_BEFORE_EQUIP206, COM_TEXT_RELEASE_EQUIP206, COM_ORDER_PLAYER206, COM_TEXT_BEFORE206, COM_TEXT_LAST206, COM_AVAILABLE_WHEN206, COM_PREFERENCE_PLAYER_206, COM_PREFERENCE_TARGET_206; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手コキ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME206
LOCALS:0 = 触手コキ

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE206
;共通部分
CALL COM_ABLE_COMMON(206)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM <= 0
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0) && !FLAG:RECHECKING
	RETURN 0
;プレイヤーが触手召喚中でないなら不可
SIF !IS_EQUIP_PLAYER(MPLY:0, 200)
	RETURN 0
FOR LOCAL:0, 0, MTAR_NUM
	SIF !HAS_PENIS(MTAR:LOCAL)
		RETURN 0
	SIF !P_STACKABLE(MPLY:0, MTAR:LOCAL, 206)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM206
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

FOR LOCAL:0, 0, MTAR_NUM
	;ターゲットの触手オナホを解除
	CALL RELEASE_EQUIP(SEARCH_EQUIP(205, -1, MTAR:(LOCAL:0)), 1, 0)
NEXT

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):妖術経験値 += 1
EXP:(MPLY:0):触手経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 150)
SOURCE:(MPLY:0):嗜虐 = 30
SOURCE:(MPLY:0):逸脱 = 80
SOURCE:(MPLY:0):触手 = 30
SOURCE:(MPLY:0):性行動 = 210

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 130, 30)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	EXP:(LOCAL:2):触手経験値 += 1

	SOURCE:(LOCAL:2):快Ｐ = SENSE_HOUSHI_P(MPLY:0, LOCAL:2, 400 + ABL:(MPLY:0):妖術 * 4) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
	SOURCE:(LOCAL:2):逸脱 = 300 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:2):触手 = 300 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:2):性行動 = 180 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 90)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 70)
NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 3

;レズ・ＢＬ経験基準値
TFLAG:51 = 1

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP206
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP206(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

SOURCE:(LOCAL:2):性行動 += 70

;全てのターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	;ソースを退避
	CALL PUTOUT_SOURCE(LOCAL:3)

	EXP:(LOCAL:3):触手経験値 += 1

	SOURCE:(LOCAL:3):快Ｐ += SENSE_HOUSHI_P(LOCAL:2, LOCAL:3, 300 + ABL:(LOCAL:2):妖術 * 3) + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:3):逸脱 += 120 - (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 60)
	SOURCE:(LOCAL:3):触手 += 150 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 750)
	SOURCE:(LOCAL:3):性行動 += 60 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 30)

	;倒錯度変化
	TCVAR:(LOCAL:3):50 += 2

	;退避したソースを加算
	CALL SUM_SOURCE(LOCAL:3)
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE206(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%に対して%EQUIP_PLAYER_ANAME(ARG:0)%の触手が触手コキ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP206(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%のペニスに巻き付き弄んでいる…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP206(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER206(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 120

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 2)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 3)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):触手}", ABL:(ARG:0):触手 * 6)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -2)
ENDIF
IF TALENT:(ARG:0):好奇心
	CALL COM_ORDER_ELEMENT(ARG:0, "好奇心", 2)
ENDIF
IF TALENT:(ARG:0):保守的
	CALL COM_ORDER_ELEMENT(ARG:0, "保守的", -7)
ENDIF
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 4)
ENDIF
IF TALENT:(ARG:0):快感の否定
	CALL COM_ORDER_ELEMENT(ARG:0, "快感の否定", -2)
ENDIF
IF TALENT:(ARG:0):男嫌い
	CALL COM_ORDER_ELEMENT(ARG:0, "男嫌い", -6)
ENDIF

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド) || GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_マゾ) || ABL:(ARG:0):倒錯度 >= 800
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 32)
ELSEIF ABL:(ARG:0):倒錯度 >= 500
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 24)
ELSEIF ABL:(ARG:0):倒錯度 >= 300
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 16)
ELSEIF ABL:(ARG:0):倒錯度 >= 100
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 8)
ELSE
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 0)
ENDIF

```
