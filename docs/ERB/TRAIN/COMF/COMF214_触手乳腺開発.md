# TRAIN/COMF/COMF214_触手乳腺開発.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF214_触手乳腺開発.ERB`

类型: .ERB

自动摘要: functions: COM_NAME214, COM_ABLE214, COM214, COM_IS_EQUIP214, COM_EQUIP214, EQUIP_MESSAGE214, COM_TEXT_BEFORE_EQUIP214, COM_TEXT_RELEASE_EQUIP214, COM_ORDER_PLAYER214, COM_TEXT_BEFORE214, COM_TEXT_LAST214, COM_AVAILABLE_WHEN214, COM_PREFERENCE_PLAYER_214, COM_PREFERENCE_TARGET_214; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手搾乳

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME214
IF TALENT:(MTAR:(LOCAL:0)):母乳体質
	LOCALS:0 = 触手乳腺責め
ELSE
	LOCALS:0 = 触手乳腺開発
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
@COM_ABLE214
;共通部分
CALL COM_ABLE_COMMON(214)
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
;全てのターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	;nipples occupied
	SIF IS_N_HOLD(MTAR:(LOCAL:0))
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM214
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;触手胸愛撫を解除
;FOR LOCAL:0, 0, MTAR_NUM
;	CALL RELEASE_EQUIP_EX(204, MPLY:0, MTAR:(LOCAL:0))
;NEXT

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):妖術経験値 += 1
EXP:(MPLY:0):触手経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 200)
SOURCE:(MPLY:0):嗜虐 = 50
SOURCE:(MPLY:0):逸脱 = 100
SOURCE:(MPLY:0):触手 = 30
SOURCE:(MPLY:0):性行動 = 90

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 140, 30)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	EXP:(LOCAL:2):触手経験値 += 1
	EXP:(LOCAL:2):搾乳経験値 += !RAND:3

	LOCAL:3 = 1000 + ABL:(MPLY:0):妖術 * 8
	SOURCE:(LOCAL:2):快Ｂ = SENSE_HOUSHI(MPLY:0, LOCAL:2, LOCAL:3 * 3 / 5) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SIF TALENT:(LOCAL:2):母乳体質
		SOURCE:(LOCAL:2):搾乳 = SENSE_HOUSHI(MPLY:0, LOCAL:2, LOCAL:3 * 3 / 5) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SOURCE:(LOCAL:2):苦痛 = 1000
	SOURCE:(LOCAL:2):逸脱 = 500 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 250)
	SOURCE:(LOCAL:2):触手 = 400 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
	SOURCE:(LOCAL:2):性行動 = 180 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 90)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 80)
NEXT

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 4

;レズ・ＢＬ経験基準値
TFLAG:51 = 1

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP214
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP214(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

SOURCE:(LOCAL:2):性行動 += 30

;全てのターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	;ソースを退避
	CALL PUTOUT_SOURCE(LOCAL:3)

	EXP:(LOCAL:3):触手経験値 += 1
	EXP:(LOCAL:3):搾乳経験値 += 1
	LOCAL:4 = 800 + ABL:(LOCAL:2):妖術 * 6
	SOURCE:(LOCAL:3):快Ｂ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, LOCAL:4 * 3 / 5) + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 400)
	SIF TALENT:(LOCAL:3):母乳体質
		SOURCE:(LOCAL:3):搾乳 += SENSE_HOUSHI(LOCAL:2, LOCAL:3, LOCAL:4 * 3 / 5) + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 400)
	SOURCE:(LOCAL:3):苦痛 += 500
	SOURCE:(LOCAL:3):逸脱 += 150 - (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 75)
	SOURCE:(LOCAL:3):触手 += 200 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 100)
	SOURCE:(LOCAL:3):性行動 += 60 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 30)

	;倒錯度変化
	TCVAR:(LOCAL:3):50 += 2

	;退避したソースを加算
	CALL SUM_SOURCE(LOCAL:3)
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE214(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%に対して%EQUIP_PLAYER_ANAME(ARG:0)%の触手が乳腺開発中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP214(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%の乳首に潜り込み乳腺を責め立てている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP214(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER214(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 120

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 2)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 3)
CALL COM_ORDER_ELEMENT(ARG:0, @"触手Lv{ABL:(ARG:0):触手}", ABL:(ARG:0):触手 * 6)

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

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド) || GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_マゾ) || ABL:(ARG:0):倒錯度 >= 800
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 32)
ELSEIF ABL:(ARG:0):倒錯度 >= 500
```
