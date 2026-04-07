# TRAIN/COMF/COMF102_Ａ顔面騎乗.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF102_Ａ顔面騎乗.ERB`

类型: .ERB

自动摘要: functions: COM_NAME102, COM_ABLE102, COM102, COM_IS_EQUIP102, COM_EQUIP102, EQUIP_MESSAGE102, COM_TEXT_BEFORE_EQUIP102, COM_TEXT_RELEASE_EQUIP102, COM_ORDER_PLAYER102, COM_TEXT_BEFORE102, COM_TEXT_LAST102, COM_AVAILABLE_WHEN102, COM_PREFERENCE_PLAYER_102, COM_PREFERENCE_TARGET_102; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;Ａ顔面騎乗

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME102
LOCALS:0 = Ａ顔面騎乗

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE102
;共通部分
CALL COM_ABLE_COMMON(102)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
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
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;拘束中なら不可
SIF IS_BIND(MPLY:0)
	RETURN 0
;挿入中は不可
SIF IS_INSERT_SINGLE(MPLY:0, "全")
	RETURN 0
;尻コキ中なら不可
SIF IS_EQUIP_PLAYER(MPLY:0, 15)
	RETURN 0
;プレイヤーが顔面騎乗されているなら不可
SIF IS_RIDDEN(MPLY:0)
	RETURN 0
;プレイヤーが既に他の相手に顔面騎乗しているなら不可
SIF IS_RIDE(MPLY:0) && !(SEARCH_EQUIP(101, MPLY:0, MTAR:0) >= 0 || SEARCH_EQUIP(102, MPLY:0, MTAR:0) >= 0 || SEARCH_EQUIP(105, MPLY:0, MTAR:0) >= 0)
	RETURN 0
;ターゲットが既に他の相手に顔面騎乗されているなら不可
SIF IS_RIDDEN(MTAR:0) && !(SEARCH_EQUIP(101, MPLY:0, MTAR:0) >= 0 || SEARCH_EQUIP(102, MPLY:0, MTAR:0) >= 0 || SEARCH_EQUIP(105, MPLY:0, MTAR:0) >= 0)
	RETURN 0
;プレイヤーからターゲットに足舐め中なら不可
SIF SEARCH_EQUIP(104, MPLY:0, MTAR:0) >= 0
	RETURN 0
;ターゲットが顔面騎乗中なら不可
SIF IS_RIDE(MTAR:0)
	RETURN 0
;プレイヤーが土下座しているなら不可
SIF IS_EQUIP_PLAYER(MPLY:0, 110)
	RETURN 0
;ターゲットが土下座しているなら不可
SIF IS_EQUIP_PLAYER(MTAR:0, 110)
	RETURN 0
;ターゲットがキス中なら不可
SIF IS_EQUIP(MTAR:0, 20)
	RETURN 0
;ターゲットが足舐め中なら不可
SIF IS_EQUIP_PLAYER(MTAR:0, 104)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM102
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;クンニ、顔面騎乗、Ｗ顔面騎乗のフラグを解除
FOR LOCAL:0, 0, MPLY_NUM
	FOR LOCAL:1, 0, MTAR_NUM
		CALL RELEASE_EQUIP_EX(2, MTAR:(LOCAL:1), -1)
		CALL RELEASE_EQUIP_EX(101, MPLY:(LOCAL:0), -1)
		CALL RELEASE_EQUIP_EX(105, MPLY:(LOCAL:0), -1)
	NEXT
NEXT

;●プレイヤーについて処理
SOURCE:(MPLY:0):液体追加 = 100
SOURCE:(MPLY:0):露出 = 300
SOURCE:(MPLY:0):逸脱 = 200
SOURCE:(MPLY:0):接触 = 60
SOURCE:(MPLY:0):性行動 = 150
SOURCE:(MPLY:0):快Ａ = SENSE_HOUSHI(MTAR:0, MPLY:0, 1000)
EXP:(MPLY:0):嗜虐経験値 += 1

;主導権がプレイヤー側にある場合
IF GET_COM_INITIATIVE() == 0
	SOURCE:(MPLY:0):嗜虐 = 130
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 170, 120)

;●ターゲットについて処理
DOWNBASE:(MTAR:0):体力 += 100

EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):被虐経験値 += 1

SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 300 + (GET_HIPSIZE(MPLY:0) >= 1 || TALENT:(MPLY:0):美尻) * 100)
SOURCE:(MTAR:0):逸脱 = 150
SOURCE:(MTAR:0):接触 = 60
SOURCE:(MTAR:0):性行動 = 150

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 120, 140)

IF TALENT:(MTAR:0):舌使い
	TIMES SOURCE:(MPLY:0):快Ａ, 1.50
ENDIF

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;アナルへのキス
CALL KISS_COMMON(MTAR:0, @"%ANAME(MPLY:0)%のアナル", GET_SITUATION_BY_TRAIN_MODE())

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
@COM_IS_EQUIP102
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP102(ARG:0)
;●プレイヤーについて処理
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

SOURCE:(LOCAL:2):液体追加 += 100
SOURCE:(LOCAL:2):露出 += 150
SOURCE:(LOCAL:2):逸脱 += 100
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 50
EXP:(LOCAL:2):嗜虐経験値 += 1
IF HAS_VAGINA(LOCAL:2)
	SOURCE:(LOCAL:2):快Ａ += SENSE_HOUSHI(LOCAL:2, MEQUIP_TARGET:(ARG:0):0, 500)
ENDIF

;倒錯度変化
TCVAR:(LOCAL:2):50 += 2

;●ターゲットについて処理
LOCAL:2 = MEQUIP_TARGET:(ARG:0):0

DOWNBASE:(LOCAL:2):体力 += 10

EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
SOURCE:(LOCAL:2):逸脱 += 80
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 50
EXP:(LOCAL:2):被虐経験値 += 1

;倒錯度変化
TCVAR:(LOCAL:2):50 += 2

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE102(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に顔面騎乗中(Ａ)

```
