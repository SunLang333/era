# TRAIN/COMF/COMF104_足を舐める.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF104_足を舐める.ERB`

类型: .ERB

自动摘要: functions: COM_NAME104, COM_ABLE104, COM104, COM_IS_EQUIP104, COM_EQUIP104, EQUIP_MESSAGE104, COM_TEXT_BEFORE_EQUIP104, COM_TEXT_RELEASE_EQUIP104, COM_ORDER_PLAYER104, COM_TEXT_BEFORE104, COM_AVAILABLE_WHEN104, COM_PREFERENCE_PLAYER_104, COM_PREFERENCE_TARGET_104; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;足を舐める

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME104
RESULTS:0 = 足を舐める
RESULTS:1 = 足を舐めさせられる
RESULTS:2 = 足を舐めさせる
RESULTS:3 = 足を舐められる
RESULTS:4 = 足を舐めさせる
RESULTS:5 = 足舐め見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE104
;共通部分
CALL COM_ABLE_COMMON(104)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で2人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 2
	RETURN 0
;ターゲットは最大で2人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 2
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;2-2は無理
SIF MPLY_NUM == 2 && MTAR_NUM == 2
	RETURN 0

LOCAL:5 = 0
LOCAL:6 = 0
;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;顔面騎乗されているなら不可
	SIF IS_RIDDEN(MPLY:(LOCAL:0))
		RETURN 0
	;口枷装着中なら不可
	SIF IS_M_HOLD(MPLY:(LOCAL:0))
		RETURN 0
	;拘束のチェック
	SIF IS_BIND(MPLY:(LOCAL:0))
		LOCAL:5 = 1
NEXT
;全てのターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	SIF IS_BIND(MTAR:(LOCAL:0))
		LOCAL:6 = 1
NEXT

;プレイヤーとターゲットが両方拘束されていれば不可
SIF LOCAL:5 && LOCAL:6
	RETURN 0
    
FOR LOCAL:0, 0, MPLY_NUM
    FOR LOCAL:1, 0, MTAR_NUM
    	;giving/receiving trample or buttjob
		SIF SEARCH_EQUIP_IC_M(MTAR:(LOCAL:1), MPLY:(LOCAL:0), 15, 103) >= 0
			RETURN 0
    	;player getting footjob from target
		SIF SEARCH_EQUIP(14, MTAR:(LOCAL:1), MPLY:(LOCAL:0)) >= 0
			RETURN 0
        ;mutual insertion is allowed only for the player being fucked by the target in the backwards sitting position, or tribadism/doubledildo
        SIF IS_INSERT_MUTUAL(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) > 0 && (GET_SEX_POSITION(MTAR:(LOCAL:1), MPLY:(LOCAL:0)) != 4) && (GET_SEX_POSITION(MTAR:(LOCAL:1), MPLY:(LOCAL:0)) != 20) && (GET_SEX_POSITION(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) != 20)
            RETURN 0
        SIF REACHING_BODY(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) || REACHING_BODY(MTAR:(LOCAL:1), MPLY:(LOCAL:0))
            RETURN 0
        SIF LICKING_GROIN(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) || LICKING_GROIN(MTAR:(LOCAL:1), MPLY:(LOCAL:0))
            RETURN 0
        SIF LICKING_BODY(MPLY:(LOCAL:0), MTAR:(LOCAL:1)) || LICKING_BODY(MTAR:(LOCAL:1), MPLY:(LOCAL:0))
            RETURN 0
    NEXT
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM104
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 80

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 150)
	SOURCE:(LOCAL:2):逸脱 = 80
	SOURCE:(LOCAL:2):接触 = 30
	SOURCE:(LOCAL:2):不潔 = 20
	EXP:(LOCAL:2):被虐経験値 += 1

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 160)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(MPLY:0):4 = 1

	;足へのキス
	IF MTAR_NUM == 1
		CALL KISS_COMMON(MPLY:0, @"%ANAME(MTAR:0)%の足", GET_SITUATION_BY_TRAIN_MODE())
	ELSE
		CALL KISS_COMMON(MPLY:0, @"%ANAME(MTAR:0)%たちの足", (GET_SITUATION_BY_TRAIN_MODE() == "和姦" ? "乱交" # "輪姦"))
	ENDIF
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 40

	SOURCE:(LOCAL:2):嗜虐 = 20
	SOURCE:(LOCAL:2):露出 = 30
	SOURCE:(LOCAL:2):逸脱 = 20
	SOURCE:(LOCAL:2):接触 = 30
	EXP:(LOCAL:2):嗜虐経験値 += 1

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 160, 80)
NEXT

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
@COM_IS_EQUIP104
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP104(ARG:0)
;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 50)
	SOURCE:(LOCAL:2):逸脱 += 40
	SOURCE:(LOCAL:2):接触 += 15
	SOURCE:(LOCAL:2):不潔 += 10
	EXP:(LOCAL:2):嗜虐経験値 += 1

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 10, 50)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 3
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):嗜虐 += 10
	SOURCE:(LOCAL:2):露出 += 15
	SOURCE:(LOCAL:2):逸脱 += 10
	SOURCE:(LOCAL:2):接触 += 15
	EXP:(LOCAL:2):被虐経験値 += 1

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 80, 20)

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 3
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE104(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に足舐め中

;-------------------------------------------------
```
