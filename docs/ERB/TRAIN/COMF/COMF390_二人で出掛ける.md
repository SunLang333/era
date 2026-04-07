# TRAIN/COMF/COMF390_二人で出掛ける.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF390_二人で出掛ける.ERB`

类型: .ERB

自动摘要: functions: COM_NAME390, COM_ABLE390, COM390, COM_ORDER_PLAYER390, COM_ORDER_TARGET390, COM_ORDER_COMMON390, COM_TEXT_BEFORE390, COM_TEXT_LAST390, PARTNER_SELECT_DATE, SELECT_DATE_PLACE, EQUIP_DATE, GET_PLACENAME, GET_GROUND_NAME, DATE_START_BYPLACE, DATE_EQUIP_BYPLACE, UP_DATE_CHECK1, UP_DATE_CHECK2, DATE_PLACE_ABLE7, DATE_PLACE_ABLE8, COM_AVAILABLE_WHEN390; assigns RESULTS; UI/print; references CSV; definition/data

前 200 行源码片段:

```text
﻿;二人で出掛ける

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME390
RESULTS:0 = 外に誘う
RESULTS:1 = 外に誘われる

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE390
;共通部分
CALL COM_ABLE_COMMON(390)
SIF RESULT == 0
	RETURN 0
;捕虜会話では不可
SIF FLAG:調教モード == 6
	RETURN 0
;主人公がプレイヤーのとき限定
SIF MPLY:0 != MASTER
	RETURN 0
;既にデート中なら選択不可
SIF TFLAG:54
	RETURN 0
;既に出掛けた後なら不可
SIF TFLAG:57 > 0
	RETURN 0
;臨月、育児、怪我なら不可
SIF CFLAG:(MTAR:0):行動不能状態 == 行動不能_臨月 || CFLAG:(MTAR:0):行動不能状態 == 行動不能_育児 || CFLAG:(MTAR:0):行動不能状態 == 3
	RETURN 0
;キス中は不可
SIF IS_EQUIP(MPLY:0, 342)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM390
;実行できるかの判定
CALL COM_ORDER_COMMON
IF RESULT == 0
	RETURN 0
ENDIF

;TFLAG:17にデートの種類を設定
;0=通常、1=パートナーが勝手に決定、2=パートナーの行きたいデート先、3=パートナーが行きたいデート先以外
TFLAG:17 = 0

;相手が行きたいデート先を取得
CALL PARTNER_SELECT_DATE
LOCAL:0 = RESULT

;主導権ポイント計算
LOCAL:2 = GET_INITIATIVE_RATE(MTAR:0)

;相手の主導権ポイントが極端に高い＆パートナーに主導権があると、たまにデートの行き先を勝手に決定される
IF LOCAL:2 >= 40 && MIN(50, LOCAL:2 / 2) > RAND:100 && TFLAG:45 == 1
	;相手が握る
	PRINTFORMW %ANAME(MTAR:0)%の行きたいところに連れて行かれた…
	;強制的に大成功になる
	TFLAG:18 = 1
	TFLAG:54 = LOCAL:0
	TFLAG:17 = 1

ELSE
	;1/10の確率でパートナーに行きたいデート先あり。選んだデート先が同じ場合ボーナス追加
	IF RAND:10 == 0
		PRINTFORMW %ANAME(MTAR:0)%は%GET_PLACENAME(LOCAL:0)%に行きたいようだ…
	ELSE
		;パートナーに行きたいデート先がない場合LOCAL:0をクリア
		LOCAL:0 = 0
	ENDIF

	;デート先の選択
	CALL SELECT_DATE_PLACE
	IF RESULT == 0
		;キャンセルした場合コマンドを中止
		RETURN 0
	ENDIF
	TFLAG:54 = RESULT

	;相手に行きたい場所の希望がない場合
	IF LOCAL:0 == 0
		;コマンドの成否をTFLAG:18にセット
		CALL JUDGE_COM_RESULT(MTAR:0, 5, 5)

	;相手の行きたい場所を選択した場合
	ELSEIF TFLAG:54 == LOCAL:0
		;強制的に大成功になる
		TFLAG:18 = 1
		TFLAG:17 = 2

	;相手の行きたい場所と異なる場所を選択した場合
	ELSE
		;コマンドの成否をTFLAG:18にセット(通常より厳しい)
		CALL JUDGE_COM_RESULT(MTAR:0, 0, 50)
		TFLAG:17 = 3
	ENDIF
ENDIF

;好感度に応じた歓楽のソース追加
CALL ADD_SOURCE_KANRAKU(MTAR:0, 120)

LOCAL:1 = 0
IF TALENT:(MTAR:0):親愛
	TIMES SOURCE:(MTAR:0):歓楽, 1.20
	SOURCE:(MTAR:0):接触 += 100
	LOCAL:1 += 40
ENDIF

IF TALENT:(MTAR:0):恋慕
	TIMES SOURCE:(MTAR:0):歓楽, 1.20
	SOURCE:(MTAR:0):接触 += 50
	LOCAL:1 += 30
ENDIF

IF TALENT:(MTAR:0):恋人
	TIMES SOURCE:(MTAR:0):歓楽, 1.10
	SOURCE:(MTAR:0):接触 += 100
	LOCAL:1 += 30
ELSEIF CFLAG:(MTAR:0):2 > 800
	SOURCE:(MTAR:0):接触 += 50
ENDIF

;親密に応じた愛情のソース追加
CALL ADD_SOURCE_AIZYOU(MTAR:0, LOCAL:1)

;主導権に応じたソースの追加
CALL ADD_SOURCE_INITIATIVE_N(MPLY:0, 100, 100)
CALL ADD_SOURCE_INITIATIVE_N(MTAR:0, 100, 100)

;失敗
IF TFLAG:18 == -1
	TIMES SOURCE:(MTAR:0):歓楽, 0.20
	TIMES SOURCE:(MTAR:0):愛情, 0.20
	TIMES SOURCE:(MTAR:0):接触, 0.20
	SOURCE:(MTAR:0):不満 += 500
	TFLAG:37 -= 5
;成功
ELSEIF TFLAG:18 == 0

;大成功
ELSE
	TIMES SOURCE:(MTAR:0):歓楽, 2.00
	TIMES SOURCE:(MTAR:0):愛情, 2.00
	TIMES SOURCE:(MTAR:0):接触, 2.00
ENDIF

EXP:(MPLY:0):デート経験 += 1
EXP:(MTAR:0):デート経験 += 1

;行き先に応じた処理
CALL DATE_START_BYPLACE

TSTR:0 = %TRAIN_PLACE%
TRAIN_PLACE = %GET_PLACENAME(TFLAG:54)%

SIF CFLAG:(MTAR:0):行動不能状態 != 行動不能_子供 || !TALENT:(MTAR:0):幼児
	TFLAG:56 += 3

;経過時間のカウント開始
TFLAG:57 ++

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = -1

RETURN 1

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER390(ARG:0)
CALL COM_ORDER_COMMON390(ARG:0)
RETURN 1

@COM_ORDER_TARGET390(ARG:0)
CALL COM_ORDER_COMMON390(ARG:0)
RETURN 1

@COM_ORDER_COMMON390(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 20

;共通部分
CALL COM_ORDER(ARG:0)

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -5)
ENDIF
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 3)
ENDIF
IF TALENT:(ARG:0):サボり魔
	CALL COM_ORDER_ELEMENT(ARG:0, "サボり魔", 10)
```
