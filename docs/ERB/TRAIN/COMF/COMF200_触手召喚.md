# TRAIN/COMF/COMF200_触手召喚.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF200_触手召喚.ERB`

类型: .ERB

自动摘要: functions: COM_NAME200, COM_ABLE200, COM200, COM_IS_EQUIP200, COM_EQUIP200, EQUIP_MESSAGE200, COM_TEXT_BEFORE_EQUIP200, COM_BEFORE_RELEASE_EQUIP200, COM_TEXT_RELEASE_EQUIP200, COM_ORDER_PLAYER200, COM_TEXT_BEFORE200, COM_TEXT_LAST200, COM_AVAILABLE_WHEN200, COM_PREFERENCE_PLAYER_200, COM_PREFERENCE_TARGET_200; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;触手召喚

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME200
RESULTS:0 = 触手召喚する
RESULTS:1 = 触手召喚させられる
RESULTS:2 = 触手召喚させる
RESULTS:3 = 触手召喚される
RESULTS:4 = 触手召喚させる
RESULTS:5 = 触手召喚見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE200
;共通部分
CALL COM_ABLE_COMMON(200)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人以上
SIF MPLY_NUM <= 0
	RETURN 0
;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;行動不能なら不可
	SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
		RETURN 0
	;妖術知識が必要
	SIF !TALENT:(MPLY:(LOCAL:0)):妖術知識
		RETURN 0
	;既に触手召喚中なら不可
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 200)
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM200
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	EXP:(MPLY:(LOCAL:0)):妖術経験値 += 1
	EXP:(MPLY:(LOCAL:0)):触手経験値 += 1
NEXT

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP200
;継続コマンドかつフィルタリング不可
RETURN 2

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP200(ARG:0)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE200(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が触手を召喚中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP200(ARG:0)

;-------------------------------------------------
;継続を解除する前にやらなくちゃならんこと
;-------------------------------------------------
@COM_BEFORE_RELEASE_EQUIP200(ARG:0)
;触手召喚を解除したキャラがプレイヤーとなっている全ての触手系EQUIPを解除
FOR LOCAL:0, 0, MEQUIP_TARGET_NUM:(ARG:0)
	FOR LOCAL:1, 201, 215
		CALL RELEASE_EQUIP_EX(LOCAL:1, MEQUIP_PLAYER:(ARG:0):(LOCAL:0), -1)
	NEXT
NEXT

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP200(ARG:0)
PRINTFORMW %EQUIP_PLAYER_ANAME(ARG:0)%は触手を戻した

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER200(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 120

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 4)
CALL COM_ORDER_ELEMENT(ARG:0, @"露出Lv{ABL:(ARG:0):露出}", ABL:(ARG:0):露出 * 2)

IF TALENT:(ARG:0):プライド高い
	CALL COM_ORDER_ELEMENT(ARG:0, "プライド高い", -12)
ENDIF
IF TALENT:(ARG:0):好奇心
	CALL COM_ORDER_ELEMENT(ARG:0, "好奇心", 10)
ENDIF
IF TALENT:(ARG:0):保守的
	CALL COM_ORDER_ELEMENT(ARG:0, "保守的", -20)
ENDIF
IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -20)
ENDIF
IF TALENT:(ARG:0):恥薄い
	CALL COM_ORDER_ELEMENT(ARG:0, "恥薄い", 25)
ENDIF
IF TALENT:(ARG:0):貞操観念
	CALL COM_ORDER_ELEMENT(ARG:0, "貞操観念", -15)
ENDIF
IF TALENT:(ARG:0):貞操無頓着
	CALL COM_ORDER_ELEMENT(ARG:0, "貞操無頓着", 15)
ENDIF
IF TALENT:(ARG:0):目立ちたがり
	CALL COM_ORDER_ELEMENT(ARG:0, "目立ちたがり", 12)
ENDIF
IF TALENT:(ARG:0):快感の否定
	CALL COM_ORDER_ELEMENT(ARG:0, "快感の否定", -15)
ENDIF

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド) || GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_マゾ) || ABL:(ARG:0):倒錯度 >= 800
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 40)
ELSEIF ABL:(ARG:0):倒錯度 >= 500
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 30)
ELSEIF ABL:(ARG:0):倒錯度 >= 300
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 20)
ELSEIF ABL:(ARG:0):倒錯度 >= 100
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 10)
ELSE
	CALL COM_ORDER_ELEMENT(ARG:0, "倒錯度", 0)
ENDIF
RETURN 1

;-------------------------------------------------
;地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE200
FOR LOCAL:0, 0, MPLY_NUM
	PRINTFORML %ANAME(MPLY:(LOCAL:0))%は触手を召喚した
NEXT
WAIT

;--------------------------------------------------------
;地の文(パラメータ・刻印変動後)
;--------------------------------------------------------
@COM_TEXT_LAST200

FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:1 = MTAR:(LOCAL:0)

	IF (LOCAL:1 != MASTER || CONFIG:441) && !IS_ANIMAL(LOCAL:1)
		IF TCVAR:(LOCAL:1):52
	 		;気絶中
			PRINTFORML 意識を失った%ANAME(LOCAL:1)%の体に触手はゆっくり忍び寄った
		ELSEIF TALENT:(LOCAL:1):虚ろ || TALENT:(LOCAL:1):崩壊
	 		;虚ろ、崩壊中
			PRINTFORML 虚ろなまま四肢を放り出している%ANAME(LOCAL:1)%の体に触手はゆっくり忍び寄った
		ELSEIF IS_EQUIP_TARGET(MTAR:0, 84)
			;目隠し中
			IF  TALENT:(LOCAL:1):プライド高い ||TALENT:(LOCAL:1): 恥じらい ||TALENT:(LOCAL:1): 保守的 ||TALENT:(LOCAL:1): 貞操観念 ||TALENT:(LOCAL:1): 臆病
				PRINTFORML 身の危険を感じ取ったのか、%ANAME(LOCAL:1)%は硬く身構えた
			ELSEIF TALENT:(LOCAL:1):好奇心 ||TALENT:(LOCAL:1): 目立ちたがり ||TALENT:(LOCAL:1): 楽観的 ||TALENT:(LOCAL:1): 生意気
				PRINTFORML 触手が立てた音が気になるのか、%ANAME(LOCAL:1)%は首を傾けている
			ELSE
				PRINTFORML 周りが見えない%ANAME(LOCAL:1)%は不安そうにしている
			ENDIF
		ELSEIF ABL:(LOCAL:1):触手 >= 10
			;触手は恋人
			IF TALENT:(LOCAL:1):プライド高い || TALENT:(LOCAL:1): ツンデレ || TALENT:(LOCAL:1): 一線越えない
				PRINTFORML %ANAME(LOCAL:1)%は目を伏せると現われた触手を手に取り、軽く口付けをした
			ELSEIF TALENT:(LOCAL:1):貞操観念 || TALENT:(LOCAL:1):恥じらい || TALENT:(LOCAL:1):感情乏しい
				PRINTFORML %ANAME(LOCAL:1)%は耳まで赤くしつつ、股を触手に向けて襲われるのを待っている
			ELSEIF TALENT:(LOCAL:1):貞操無頓着 || TALENT:(LOCAL:1):人気 || TALENT:(LOCAL:1): 目立ちたがり
				PRINTFORML %ANAME(LOCAL:1)%は上気した顔で触手に股を向け、指で秘部を開いて誘惑している
			ELSEIF TALENT:(LOCAL:1):臆病 || TALENT:(LOCAL:1):大人しい || TALENT:(LOCAL:1): 献身的
				PRINTFORML %ANAME(LOCAL:1)%は潤んだ目で触手を見つめている。完全に虜になっているようだ
			ELSEIF TALENT:(LOCAL:1):好奇心 || TALENT:(LOCAL:1): 生意気 || TALENT:(LOCAL:1): 楽観的
				PRINTFORML %ANAME(LOCAL:1)%は触手に自分を犯すようねだっている。完全に虜になっているようだ
			ELSE
				PRINTFORML %ANAME(LOCAL:1)%からはドキドキと鼓動の音が聞こえてくる。触手に犯される事を期待しているようだ
			ENDIF
		ELSEIF ABL:(LOCAL:1):触手 >= 9 || GETBIT(TALENT:(LOCAL:1):淫乱系, 素質_淫乱_苗床)
			;触手は盟友
			IF TALENT:(LOCAL:1):プライド高い || TALENT:(LOCAL:1): ツンデレ || TALENT:(LOCAL:1): 一線越えない
```
