# TRAIN/COMF/COMF112_露出プレイ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF112_露出プレイ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME112, COM_ABLE112, COM112, COM_IS_EQUIP112, COM_EQUIP112, EQUIP_MESSAGE112, COM_TEXT_BEFORE_EQUIP112, COM_TEXT_RELEASE_EQUIP112, COM_ORDER_PLAYER112, COM_TEXT_BEFORE112, COM_AVAILABLE_WHEN112, COM_PREFERENCE_PLAYER_112, COM_PREFERENCE_TARGET_112; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;露出プレイ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME112
LOCALS:0 = 露出プレイ
RESULTS:0 = %LOCALS:0%に出かける
RESULTS:1 = %LOCALS:0%に出かけさせられる
RESULTS:2 = %LOCALS:0%に出かけさせる
RESULTS:3 = %LOCALS:0%に出かけられる
RESULTS:4 = %LOCALS:0%に出かけさせる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE112
;共通部分
CALL COM_ABLE_COMMON(112)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人
SIF MPLY_NUM != 1
	RETURN 0

SIF ITEM:首輪 == 0
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0) && !FLAG:RECHECKING
	RETURN 0

;宮殿以外or既に露出プレイ中なら不可
SIF TFLAG:54 > 0 && !FLAG:RECHECKING
	RETURN 0

SIF IS_BIND(MPLY:0) && !FLAG:RECHECKING
	RETURN 0

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM112
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

IF MPLY:0 == MASTER
	PRINTFORML どこにいこう……？

	FOR LOCAL, 0, VARSIZE("IAN_PLACE")
		PRINTFORML [{LOCAL}] %IAN_PLACE:LOCAL%
	NEXT
	PRINTFORML [99] やめておく

	$INPUT_LOOP
	INPUT
ELSE
	RESULT = RAND(0, VARSIZE("IAN_PLACE"))
	PRINTFORM %ANAME(MPLY:0)%は
ENDIF

IF RESULT == 99
	PRINTFORML やはりやめておいた
	RETURN 0
ELSEIF INRANGE(RESULT, 0, VARSIZE("IAN_PLACE"))
	PRINTFORML %IAN_PLACE:RESULT%に行くことにした
	TFLAG:105 = RESULT
	TSTR:0 = %TRAIN_PLACE%
	TRAIN_PLACE = %IAN_PLACE:RESULT%
ELSE
	CLEARLINE 1
	GOTO INPUT_LOOP
ENDIF


;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 40

	SOURCE:(LOCAL:2):嗜虐 = 20
	SOURCE:(LOCAL:2):露出 = 800
	SOURCE:(LOCAL:2):逸脱 = 20
	SOURCE:(LOCAL:2):不安 = 30

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 160)
NEXT

;●プレイヤー以外の全参加者について処理
FOR LOCAL:0, 0, CHARANUM
	SIF !IS_PARTICIPATE_TRAIN(LOCAL) || LOCAL:0 == MPLY:0
		CONTINUE

	DOWNBASE:LOCAL:体力 += 80

	SOURCE:LOCAL:逸脱 = 80
	SOURCE:LOCAL:露出 = 1500
	SOURCE:LOCAL:不安 = 30

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL, 160, 80)
NEXT

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 2

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

TFLAG:54 = 8
TFLAG:103 = 0

RETURN 1


;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP112
;継続コマンドかつフィルタリング不可
RETURN 2
;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP112(ARG:0)
;●全プレイヤーについて判定
FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:2 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 10

	SOURCE:(LOCAL:2):嗜虐 += 10
	SOURCE:(LOCAL:2):露出 += 500 + 50 * TFLAG:104
	SOURCE:(LOCAL:2):逸脱 += 10
	SOURCE:(LOCAL:2):不安 += 15

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 10, 50)

	;倒錯度変化基準値
	TCVAR:(LOCAL:2):50 += 3
NEXT


;●プレイヤー以外の全参加者について処理
FOR LOCAL:0, 0, CHARANUM
	SIF !IS_PARTICIPATE_TRAIN(LOCAL) || LOCAL:0 == MPLY:0
		CONTINUE

	DOWNBASE:LOCAL:体力 += 40

	SOURCE:LOCAL:逸脱 = 10
	SOURCE:LOCAL:露出 = 1000 + 100 * TFLAG:104
	SOURCE:LOCAL:不安 = 10

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL, 80, 20)

	;倒錯度変化基準値
	TCVAR:LOCAL:50 += 3
NEXT

;継続ターン増加
TFLAG:103 ++

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE112(ARG:0)
RESULTS = 露出プレイ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP112(ARG:0)

IF TFLAG:44 >= 8
	RETURN 
ENDIF

IF RAND:MAX(TFLAG:103, 1) * 4 - TFLAG:104 > RAND:20
	CALL CREATE_IAN_MOB(TFLAG:105, 1, 0)
	LOCAL:2 = CHARANUM - 1
	TALENT:(LOCAL:2):露出プレイモブ = 1
	PRINTFORML 騒ぎを聞きつけた%ANAME(LOCAL:2)%が参加した…
	TFLAG:104 ++
	TFLAG:44 ++
ENDIF

;-------------------------------------------------
;継続を解除したときの地の文
```
