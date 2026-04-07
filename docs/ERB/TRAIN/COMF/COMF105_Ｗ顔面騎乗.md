# TRAIN/COMF/COMF105_Ｗ顔面騎乗.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF105_Ｗ顔面騎乗.ERB`

类型: .ERB

自动摘要: functions: COM_NAME105, COM_ABLE105, COM105, COM_IS_EQUIP105, COM_EQUIP105, EQUIP_MESSAGE105, COM_TEXT_BEFORE_EQUIP105, COM_TEXT_RELEASE_EQUIP105, COM_ORDER_PLAYER105, COM_TEXT_BEFORE105, COM_TEXT_LAST105, COM_AVAILABLE_WHEN105, COM_PREFERENCE_PLAYER_105, COM_PREFERENCE_TARGET_105; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;Ｗ顔面騎乗

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME105
LOCALS:0 = Ｗ顔面騎乗

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE105
;共通部分
CALL COM_ABLE_COMMON(105)
SIF RESULT == 0
	RETURN 0
;プレイヤーが2人のとき限定
SIF MPLY_NUM != 2
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;ターゲットがＰ挿入中かつ体位が騎乗位以外なら不可
SIF IS_INSERT_SINGLE(MTAR:0, "Ｐ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｐ"), 5)
	RETURN 0
;ターゲットがＶ挿入中かつ体位が正常位以外なら不可
SIF IS_INSERT_SINGLE(MTAR:0, "Ｖ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｖ"), 1)
	RETURN 0
;ターゲットがＶ挿入中かつ体位が正常位以外なら不可
SIF IS_INSERT_SINGLE(MTAR:0, "Ａ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ａ"), 1)
	RETURN 0
;target ridden or riding
SIF IS_RIDE(MTAR:0) || IS_RIDDEN(MTAR:0)
	RETURN 0
;target's mouth occupied
SIF IS_M_HOLD(MTAR:0)
	RETURN 0

;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
		RETURN 0
	;拘束中なら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
	;挿入中は不可
	SIF IS_INSERT_SINGLE(MPLY:(LOCAL:0), "全")
		RETURN 0
	;尻コキ中なら不可
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 15)
		RETURN 0
    ;foam play with target
    SIF SEARCH_EQUIP_IC(5, MPLY:(LOCAL:0), MTAR:0) >= 0
		RETURN 0
	;player ridden or already riding
	SIF IS_RIDDEN(MPLY:(LOCAL:0)) || IS_RIDE(MPLY:(LOCAL:0))
			RETURN 0
	;プレイヤーからターゲットに足舐め中なら不可
	SIF SEARCH_EQUIP(104, MPLY:(LOCAL:0), MTAR:0) >= 0
		RETURN 0
NEXT

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM105
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	SOURCE:(LOCAL:2):露出 = 200
	SOURCE:(LOCAL:2):逸脱 = 150
	SOURCE:(LOCAL:2):接触 = 40
	SOURCE:(LOCAL:2):性行動 = 150
	EXP:(LOCAL:2):嗜虐経験値 += 1

	;主導権がプレイヤー側にある場合
	IF GET_COM_INITIATIVE() == 0
		SOURCE:(MPLY:0):嗜虐 = 130
	ENDIF

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 170, 120)
NEXT

;●ターゲットについて処理
EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):被虐経験値 += 1

SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 300)
SOURCE:(MTAR:0):逸脱 = 150
SOURCE:(MTAR:0):接触 = 60
SOURCE:(MTAR:0):性行動 = 150

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 120, 140)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 2

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP105
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP105(ARG:0)
;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	SOURCE:(LOCAL:2):露出 += 100
	SOURCE:(LOCAL:2):逸脱 += 80
	SOURCE:(LOCAL:2):接触 += 20
	SOURCE:(LOCAL:2):性行動 += 50
	EXP:(LOCAL:2):嗜虐経験値 += 1

	;倒錯度変化
	TCVAR:(LOCAL:2):50 += 2
NEXT

;●ターゲットについて判定
LOCAL:2 = MEQUIP_TARGET:(ARG:0):0

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):被虐経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
SOURCE:(LOCAL:2):逸脱 += 80
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 50

;倒錯度変化
TCVAR:(LOCAL:2):50 += 2

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE105(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に顔面騎乗中(尻)

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP105(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の顔の上に跨っている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP105(ARG:0)
PRINTFORMW %EQUIP_PLAYER_ANAME(ARG:0)%は%EQUIP_TARGET_ANAME(ARG:0)%の顔から腰を上げた…

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER105(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 75

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
```
