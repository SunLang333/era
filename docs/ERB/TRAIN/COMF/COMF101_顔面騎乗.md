# TRAIN/COMF/COMF101_顔面騎乗.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF101_顔面騎乗.ERB`

类型: .ERB

自动摘要: functions: COM_NAME101, COM_ABLE101, COM101, COM_IS_EQUIP101, COM_EQUIP101, EQUIP_MESSAGE101, COM_TEXT_BEFORE_EQUIP101, COM_TEXT_RELEASE_EQUIP101, COM_ORDER_PLAYER101, COM_TEXT_BEFORE101, COM_TEXT_LAST101, COM_AVAILABLE_WHEN101, COM_PREFERENCE_PLAYER_101, COM_PREFERENCE_TARGET_101; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;顔面騎乗

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME101
LOCALS:0 = 顔面騎乗

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE101
;共通部分
CALL COM_ABLE_COMMON(101)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;拘束中なら不可
SIF IS_BIND(MPLY:0)
	RETURN 0
SIF IS_M_HOLD(MTAR:0)
	RETURN 0
;Target is fucking someone in any position except cowgirl/reverse cowgirl
SIF IS_INSERT_SINGLE(MTAR:0, "Ｐ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｐ"), 5, 6)
	RETURN 0
;target being fucked in any position except missionary
SIF IS_INSERT_SINGLE(MTAR:0, "Ｖ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ｖ"), 1)
	RETURN 0
;target being fucked in any position except missionary
SIF IS_INSERT_SINGLE(MTAR:0, "Ａ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ａ"), 1)
	RETURN 0
;player fucking
SIF IS_INSERT_SINGLE(MPLY:0, "全")
	RETURN 0
;player giving buttjob to anyone
SIF IS_EQUIP_PLAYER(MPLY:0, 15)
	RETURN 0
;player ridden or already riding
SIF IS_RIDDEN(MPLY:0) || IS_RIDE(MPLY:0)
	RETURN 0
;target already ridden or riding
SIF IS_RIDE(MTAR:0) || IS_RIDDEN(MTAR:0)
	RETURN 0
;either is grovelling
SIF IS_EQUIP_PLAYER(MPLY:0, 110) || IS_EQUIP_PLAYER(MTAR:0, 110)
	RETURN 0
;player or target footlicking, buttjob, or foam playing each other
SIF SEARCH_EQUIP_IC_M(MPLY:0, MTAR:0, 5, 15, 104) >= 0
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM101
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;ターゲット側の屈従のソース基本量
LOCAL:11 = 120

;プレイヤー側の嗜虐のソース基本量
LOCAL:12 = 100

;●プレイヤーについて処理
SOURCE:(MPLY:0):液体追加 = 100
SOURCE:(MPLY:0):露出 = 300
SOURCE:(MPLY:0):逸脱 = 150
SOURCE:(MPLY:0):接触 = 60
SOURCE:(MPLY:0):性行動 = 300
EXP:(MPLY:0):嗜虐経験値 += 1
IF HAS_VAGINA(MPLY:0)
	SOURCE:(MPLY:0):快Ｃ = SENSE_HOUSHI(MTAR:0, MPLY:0, 1000)
ELSE
	LOCAL:11 = 150
	LOCAL:12 = 120
ENDIF

;主導権がプレイヤー側にある場合
IF GET_COM_INITIATIVE() == 0
	SOURCE:(MPLY:0):嗜虐 = LOCAL:12
ENDIF

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 170, 120)

;●ターゲットについて処理
DOWNBASE:(MTAR:0):体力 += 100

EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):被虐経験値 += 1
SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 300)
SOURCE:(MTAR:0):逸脱 = 100
SOURCE:(MTAR:0):接触 = 60
SOURCE:(MTAR:0):性行動 = 300

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 120, LOCAL:11)

;プレイヤーが１人のとき
IF MPLY_NUM == 1
	IF TALENT:(MTAR:0):舌使い
		TIMES SOURCE:(MPLY:0):快Ｃ, 1.50
	ENDIF
ENDIF

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;キス
CALL KISS_COMMON(MTAR:0, @"%ANAME(MPLY:0)%の\@ IS_MALE(MPLY:0) ? 玉 # 秘貝\@", GET_SITUATION_BY_TRAIN_MODE())

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
@COM_IS_EQUIP101
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP101(ARG:0)
;●プレイヤーについて処理
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

SOURCE:(LOCAL:2):液体追加 += 100
SOURCE:(LOCAL:2):露出 += 100
SOURCE:(LOCAL:2):逸脱 += 80
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 100
EXP:(LOCAL:2):嗜虐経験値 += 1
IF HAS_VAGINA(LOCAL:2)
	SOURCE:(LOCAL:2):快Ｃ += SENSE_HOUSHI(LOCAL:2, MEQUIP_TARGET:(ARG:0):0, 500)
ENDIF

;倒錯度変化
TCVAR:(LOCAL:2):50 += 2

;●ターゲットについて処理
LOCAL:2 = MEQUIP_TARGET:(ARG:0):0

EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
SOURCE:(LOCAL:2):逸脱 += 60
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 100
EXP:(LOCAL:2):被虐経験値 += 1
;倒錯度変化
TCVAR:(LOCAL:2):50 += 2

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE101(ARG:0)
IF IS_MALE(MEQUIP_PLAYER:(ARG:0):0)
	LOCALS:0 = Ｃ
ELSE
	LOCALS:0 = Ｖ
ENDIF
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に顔面騎乗中(%LOCALS%)

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP101(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の顔の上に跨っている…

```
