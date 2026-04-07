# TRAIN/COMF/COMF203_触手クリ責め.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF203_触手クリ責め.ERB`

类型: .ERB

自动摘要: functions: COM_NAME203, COM_ABLE203, COM203, COM_IS_EQUIP203, COM_EQUIP203, EQUIP_MESSAGE203, COM_TEXT_BEFORE_EQUIP203, COM_TEXT_RELEASE_EQUIP203, COM_ORDER_PLAYER203, COM_TEXT_BEFORE203, COM_TEXT_LAST203, COM_COMMON203, COM_AVAILABLE_WHEN203, COM_PREFERENCE_PLAYER_203, COM_PREFERENCE_TARGET_203; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手クリ責め

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME203
LOCALS:0 = 触手クリ責め

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE203
;共通部分
CALL COM_ABLE_COMMON(203)
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
	;Ｖが必要
	SIF !HAS_VAGINA(MTAR:(LOCAL:0))
		RETURN 0
	;using clit cap
	SIF IS_EQUIP_TARGET(MTAR:(LOCAL:0), 63)
		RETURN 0
	;ターゲットが顔面騎乗中なら不可
	SIF IS_RIDE(MTAR:(LOCAL:0))
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM203
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

	SOURCE:(LOCAL:2):快Ｃ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 1000 + ABL:(MPLY:0):妖術 * 8) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SOURCE:(LOCAL:2):逸脱 = 300 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:2):触手 = 300 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 300)
	SOURCE:(LOCAL:2):性行動 = 180 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 90)


	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 60)

	;共通処理
	CALL COM_COMMON203(LOCAL:2)
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
@COM_IS_EQUIP203
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP203(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

SOURCE:(LOCAL:2):性行動 += 30

;全てのターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	;ソースを退避
	CALL PUTOUT_SOURCE(LOCAL:3)

	EXP:(LOCAL:3):触手経験値 += 1

	SOURCE:(LOCAL:3):快Ｃ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 800 + ABL:(LOCAL:2):妖術 * 6) + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 400)
	SOURCE:(LOCAL:3):逸脱 += 120 - (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 60)
	SOURCE:(LOCAL:3):触手 += 150 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 75)
	SOURCE:(LOCAL:3):性行動 += 60 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 30)

	;倒錯度変化
	TCVAR:(LOCAL:3):50 += 2

	;共通処理
	CALL COM_COMMON203(LOCAL:3)

	;退避したソースを加算
	CALL SUM_SOURCE(LOCAL:3)
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE203(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%に対して%EQUIP_PLAYER_ANAME(ARG:0)%の触手がクリ責め中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP203(ARG:0)
IF TALENT:(MEQUIP_TARGET:(ARG:0):0):Ｃ敏感
	PRINTFORM %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%の\@ RAND:2 ? 敏感な # 可愛い \@クリトリス
ELSE
	PRINTFORM %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%のクリトリス
ENDIF
	SELECTCASE RAND:14
	CASE 0
		PRINTL を擦り上げている…
	CASE 1
		PRINTL を弄んでいる…
	CASE 2
		PRINTL を撫で回している…
	CASE 3
		PRINTL をキュッとつまみ上げている…
	CASE 4
		PRINTL に何度もキスを浴びせている…
	CASE 5
		PRINTL をピンッと弾いている…
	CASE 6
		PRINTL を突っついて刺激し続けている…
	CASE 7
		PRINTL をぐりぐりと摩擦している…
	CASE 8
		PRINTL をくりくりと磨いている…
	CASE 9
		PRINTL を取り囲んでこね上げている…
	CASE 10
		PRINTL を器用に挟み込んでいる…
	CASE 11
		PRINTL の皮を剝いで扱き上げている…
	CASE 12
		PRINTL を下から押し上げて弄んでいる…
	CASE 13
		PRINTL の細部を綺麗に掃除している…
	ENDSELECT
;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP203(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER203(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 120

```
