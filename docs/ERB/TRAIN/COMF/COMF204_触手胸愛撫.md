# TRAIN/COMF/COMF204_触手胸愛撫.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF204_触手胸愛撫.ERB`

类型: .ERB

自动摘要: functions: COM_NAME204, COM_ABLE204, COM204, COM_IS_EQUIP204, COM_EQUIP204, EQUIP_MESSAGE204, COM_TEXT_BEFORE_EQUIP204, COM_TEXT_RELEASE_EQUIP204, COM_ORDER_PLAYER204, COM_TEXT_BEFORE204, COM_TEXT_LAST204, COM_AVAILABLE_WHEN204, COM_PREFERENCE_PLAYER_204, COM_PREFERENCE_TARGET_204; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手胸愛撫

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME204
LOCALS:0 = 触手胸愛撫

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE204
;共通部分
CALL COM_ABLE_COMMON(204)
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
	SIF IS_EQUIP_TARGET(MTAR:(LOCAL:0), 1)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM204
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):妖術経験値 += 1
EXP:(MPLY:0):触手経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 150)
SOURCE:(MPLY:0):嗜虐 = 30
SOURCE:(MPLY:0):逸脱 = 80
SOURCE:(MPLY:0):触手 = 30
SOURCE:(MPLY:0):性行動 = 90

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 130, 30)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	EXP:(LOCAL:2):触手経験値 += 1

	LOCAL:3 = 1000 + ABL:(MPLY:0):妖術 * 8
	SOURCE:(LOCAL:2):快Ｂ = SENSE_HOUSHI(MPLY:0, LOCAL:2, LOCAL:3 * 4 / 5) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SOURCE:(LOCAL:2):搾乳 = SENSE_HOUSHI(MPLY:0, LOCAL:2, LOCAL:3 * 1 / 5) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SOURCE:(LOCAL:2):逸脱 = 300 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:2):触手 = 300 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:2):性行動 = 180 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 90)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 60)
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
@COM_IS_EQUIP204
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP204(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

SOURCE:(LOCAL:2):性行動 += 30

;全てのターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	;ソースを退避
	CALL PUTOUT_SOURCE(LOCAL:3)

	EXP:(LOCAL:3):触手経験値 += 1

	LOCAL:4 = 800 + ABL:(MPLY:0):妖術 * 6
	SOURCE:(LOCAL:3):快Ｂ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, LOCAL:4 * 4 / 5) + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 400)
	SOURCE:(LOCAL:3):搾乳 += SENSE_HOUSHI(LOCAL:2, LOCAL:3, LOCAL:4 * 1 / 5) + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 400)
	SOURCE:(LOCAL:3):逸脱 += 120 - (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 60)
	SOURCE:(LOCAL:3):触手 += 150 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 75)
	SOURCE:(LOCAL:3):性行動 += 60 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 30)

	;倒錯度変化
	TCVAR:(LOCAL:3):50 += 2

	;退避したソースを加算
	CALL SUM_SOURCE(LOCAL:3)
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE204(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%に対して%EQUIP_PLAYER_ANAME(ARG:0)%の触手が胸愛撫中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP204(ARG:0)
IF TALENT:(MEQUIP_TARGET:(ARG:0):0):Ｂ敏感
	PRINTFORM %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%の\@ RAND:2 ? 敏感な # 形の良い \@
ELSE
	PRINTFORM %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%の
ENDIF
	SELECTCASE RAND:9
	CASE 0
		PRINTL 胸を弄び、乳首に吸い付いている…
	CASE 1
		PRINTL 胸を弄び、乳首を刺激し続けている…
	CASE 2
		PRINTL 胸を弄び、胸へ粘液を擦り付けている…
	CASE 3
		PRINTL 胸を持ち上げるようし、乳首をなぞっている…
	CASE 4
		PRINTL 胸を擦り、弾いて弄んでいる…
	CASE 5
		PRINTL 胸を掴み、自由に動かしている…
	CASE 6
		PRINTL 乳首を掴み、引っ張り上げている…
	CASE 7
		PRINTL 乳首を潰し、こね回している…
	CASE 8
		PRINTL 胸へ粘液をこすり付けている…
	ENDSELECT
	
;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP204(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER204(ARG:0)
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
```
