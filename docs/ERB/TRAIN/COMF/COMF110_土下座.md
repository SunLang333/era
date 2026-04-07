# TRAIN/COMF/COMF110_土下座.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF110_土下座.ERB`

类型: .ERB

自动摘要: functions: COM_NAME110, COM_ABLE110, COM110, COM_IS_EQUIP110, COM_EQUIP110, EQUIP_MESSAGE110, COM_TEXT_BEFORE_EQUIP110, COM_TEXT_RELEASE_EQUIP110, COM_ORDER_PLAYER110, COM_TEXT_BEFORE110, COM_TEXT_LAST110, COM_AVAILABLE_WHEN110, COM_PREFERENCE_PLAYER_110, COM_PREFERENCE_TARGET_110; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;足を舐める

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME110
RESULTS:0 = 土下座する
RESULTS:1 = 土下座させられる
RESULTS:2 = 土下座させる
RESULTS:3 = 土下座される
RESULTS:4 = 土下座させる
RESULTS:5 = 土下座見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE110
;共通部分
CALL COM_ABLE_COMMON(110)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で5人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 5
	RETURN 0
;ターゲットは最大で5人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 5
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0

;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	SIF IS_RIDE(MPLY:(LOCAL:0))
		RETURN 0
	SIF IS_RIDDEN(MPLY:(LOCAL:0))
		RETURN 0
		
	;Ｖ挿入中かつ体位が後背位以外なら不可
	SIF IS_INSERT_SINGLE(MPLY:(LOCAL:0), "Ｖ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MPLY:0, "Ｖ"), 2)
		RETURN 0
	;Ａ挿入中かつ体位が後背位以外なら不可
	SIF IS_INSERT_SINGLE(MPLY:(LOCAL:0), "Ａ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MPLY:0, "Ａ"), 2)
		RETURN 0
	;拘束されていたらダメ
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
    ;receiving nipple sucking, boobjob, buttjob
    SIF IS_EQUIP_TARGET(MPLY:(LOCAL:0), 9, 12, 15)
		RETURN 0
		
    ;exisiting action requires mobility
    ;There is no good way to do this. We just manually list every action that is restricted
    SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 0, 1, 3, 4, 5, 9, 10)
		RETURN 0
    SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 12, 14, 15, 16, 18, 23)
        RETURN 0
    SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 87, 88, 90, 94)
        RETURN 0
    SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 100, 101, 102, 103, 105, 106, 116)
        RETURN 0
    ;fucking actions. Can't use INSERT_SINGLE because it includes cowgirl etc.
    SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 13, 30, 31, 34, 35, 36, 37, 38, 39, 40, 41, 44, 45)
		RETURN 0
    SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 46, 47, 48, 49, 52, 53, 55, 56, 57, 58, 160, 161)
        RETURN 0
    ;giving/receiving tribadism, doubledildo, frotting
    SIF IS_EQUIP(MPLY:(LOCAL:0), 21, 22, 23)
        RETURN 0
        
NEXT

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM110
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 50

	SOURCE:(LOCAL:2):奉仕 = SERVE_HOUSHI(LOCAL:2, 150)
	SOURCE:(LOCAL:2):逸脱 = 80
	SOURCE:(LOCAL:2):接触 = 30
	SOURCE:(LOCAL:2):露出 = 600
	EXP:(LOCAL:2):被虐経験値 += 1

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(MPLY:0):4 = 1

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 200)
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 40

	SOURCE:(LOCAL:2):嗜虐 = 50
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
@COM_IS_EQUIP110
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP110(ARG:0)
;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 50)
	SOURCE:(LOCAL:2):逸脱 += 40
	SOURCE:(LOCAL:2):接触 += 15
	SOURCE:(LOCAL:2):露出 += 400
	EXP:(LOCAL:2):被虐経験値 += 1

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 10, 50)

	;奉仕経験値を得られるコマンドのフラグ     TCVAR:(LOCAL:2):4 = 1

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 3
NEXT

;●全ターゲットについて判定
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):嗜虐 += 30
	SOURCE:(LOCAL:2):逸脱 += 10
	SOURCE:(LOCAL:2):接触 += 15
	EXP:(LOCAL:2):嗜虐経験値 += 1

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 80, 20)

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 3
NEXT

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE110(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が土下座中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP110(ARG:0)
LOCAL:2 = 1
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	IF !IS_INITIATIVE(MEQUIP_TARGET:(ARG:0):(LOCAL:0))
		LOCAL:2 = 0
	ENDIF
NEXT
IF LOCAL:2
	PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が土下座している…
ELSE
	PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が土下座している…
ENDIF

```
