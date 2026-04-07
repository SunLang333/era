# TRAIN/COMF/COMF215_触手尿道挿入.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF215_触手尿道挿入.ERB`

类型: .ERB

自动摘要: functions: COM_NAME215, COM_ABLE215, COM215, COM_IS_EQUIP215, COM_EQUIP215, EQUIP_MESSAGE215, COM_TEXT_BEFORE_EQUIP215, COM_TEXT_RELEASE_EQUIP215, COM_ORDER_PLAYER215, COM_TEXT_BEFORE215, COM_TEXT_LAST215, COM_COMMON215, COM_AVAILABLE_WHEN215, COM_PREFERENCE_PLAYER_215, COM_PREFERENCE_TARGET_215; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手挿入

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME215
LOCALS:0 = 触手尿道挿入

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE215
;共通部分
CALL COM_ABLE_COMMON(215)
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
	SIF IS_U_HOLD(MTAR:(LOCAL:0))
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM215
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤーについて処理
EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):妖術経験値 += 1
EXP:(MPLY:0):触手経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 150)
SOURCE:(MPLY:0):嗜虐 = 50
SOURCE:(MPLY:0):逸脱 = 100
SOURCE:(MPLY:0):触手 = 30
SOURCE:(MPLY:0):性行動 = 150

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 170, 30)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●全てのターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	EXP:(LOCAL:2):触手経験値 += 1
	EXP:(LOCAL:2):Ｕ開発経験 += 1
	SOURCE:(LOCAL:2):快Ｕ = SENSE_HOUSHI(MPLY:0, LOCAL:2, 800 + ABL:(MPLY:0):妖術 * 8) + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 500)
	SOURCE:(LOCAL:2):逸脱 = 500 - (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 200)
	SOURCE:(LOCAL:2):触手 = 600 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 300)
	SOURCE:(LOCAL:2):性行動 = 300 + (GETBIT(TALENT:(LOCAL:2):淫乱系, 素質_淫乱_苗床) * 150)

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 60, 80)

	;共通処理
	CALL COM_COMMON215(LOCAL:2)

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
@COM_IS_EQUIP215
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP215(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

SOURCE:(LOCAL:2):性行動 += 50

;全てのターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	;ソースを退避
	CALL PUTOUT_SOURCE(LOCAL:3)

	EXP:(LOCAL:3):触手経験値 += 1

	SOURCE:(LOCAL:3):快Ｕ += SENSE_HOUSHI(LOCAL:2, LOCAL:3, 600 + ABL:(LOCAL:2):妖術 * 6) + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 400)
	SOURCE:(LOCAL:3):逸脱 += 200 - (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 50)
	SOURCE:(LOCAL:3):触手 += 300 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 150)
	SOURCE:(LOCAL:3):性行動 += 100 + (GETBIT(TALENT:(LOCAL:3):淫乱系, 素質_淫乱_苗床) * 50)

	;倒錯度変化
	TCVAR:(LOCAL:3):50 += 2
	EXP:(LOCAL:3):Ｕ開発経験 += 1

	;共通処理
	CALL COM_COMMON215(LOCAL:3)

	;退避したソースを加算
	CALL SUM_SOURCE(LOCAL:3)
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE215(ARG:0)
RESULTS = %EQUIP_TARGET_ANAME(ARG:0)%の尿道に%EQUIP_PLAYER_ANAME(ARG:0)%の触手を挿入中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP215(ARG:0)
IF TALENT:(MEQUIP_TARGET:(ARG:0):0):Ｕ敏感
	PRINTFORM %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%の\@ RAND:2 ? 敏感な # 良く締まる \@
ELSE
	PRINTFORM %EQUIP_PLAYER_ANAME(ARG:0)%の操る触手が%EQUIP_TARGET_ANAME(ARG:0)%の
ENDIF
SELECTCASE RAND:18
	CASE 0
		PRINTL 尿道を欲望のままに突き上げている…
	CASE 1
		PRINTL 尿道を撫で廻している…
	CASE 2
		PRINTL 尿道へ入り込み、子宮を擦り続けている…
	CASE 3
		PRINTL 尿道口を打ちつけるように突き上げている…
	CASE 4
		PRINTL 尿道をかき混ぜるように突き上げている…
	CASE 5
		PRINTL 尿道をぐりぐり弄んでいる…
	CASE 6
		PRINTL 尿道へゆっくりと突き入れている…
	CASE 7
		PRINTL 尿道から肉壁を擦るよう突き入れている…
	CASE 8
		PRINTL 尿道へ入り込み、膀胱内で腹裏を舐め上げている…
	CASE 9
		PRINTL 尿道へ角度をつけて、何度も突き入れている…
	CASE 10
		PRINTL 尿道へ入り込み、膀胱奥を叩くように突き入れている…
	CASE 11
		PRINTL 尿道へ進入し、膀胱内でキスを降らしている…
	CASE 12
		PRINTL 尿道へ入り込み、膀胱を穿り続けている…
	CASE 13
		PRINTL 尿道を嬲り犯し、粘液を撒き散らしている…
	CASE 14
		PRINTL 尿道を犯し、結合部からは細い糸が垂れている…
	CASE 15
		PRINTL 尿道を犯し、奥で尿を混ぜ合わせている…
	CASE 16
		PRINTL 尿道へ入り込み、膀胱を開発しつづけている…
	CASE 17
		PRINTL 尿道へ入り込み、尿道を勢い良く吸い上げた…
ENDSELECT

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP215(ARG:0)
PRINTFORMW %EQUIP_PLAYER_ANAME(ARG:0)%は%EQUIP_TARGET_ANAME(ARG:0)%の尿道から触手を引き抜いた…

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
```
