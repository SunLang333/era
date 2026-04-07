# TRAIN/COMF/COMF98_遠隔調教.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF98_遠隔調教.ERB`

类型: .ERB

自动摘要: functions: COM_NAME98, COM_ABLE98, COM98, COM_IS_EQUIP98, COM_ORDER_PLAYER98, COM_TEXT_BEFORE98, COM_AVAILABLE_WHEN98, COM_PREFERENCE_PLAYER_98, COM_PREFERENCE_TARGET_98; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;遠隔調教

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME98
LOCALS:0  = 遠隔調教
RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE98
;共通部分
CALL COM_ABLE_COMMON(98)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人
SIF MPLY_NUM != 1
	RETURN 0
;ターゲットも1人
SIF MTAR_NUM != 1
	RETURN 0
;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0

SIF ITEM:スキマ == 0
	RETURN 0

LOCAL:5 = 0
LOCAL:6 = 0
;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;顔面騎乗されているなら不可
	SIF IS_RIDDEN(MPLY:(LOCAL:0))
		RETURN 0
	;顔面騎乗しているなら不可
	SIF IS_RIDDEN(MPLY:(LOCAL:0))
		RETURN 0
	;キス中、貝合中なら不可
	SIF IS_EQUIP(MPLY:(LOCAL:0), 20, 21)
		RETURN 0
	;手コキ、脚コキ、素股, パイズリ、オナホコキ中なら不可
	SIF IS_EQUIP_PLAYER(MPLY:(LOCAL:0), 10, 12, 14, 13, 17)
		RETURN 0
	;挿入中なら不可
	SIF IS_INSERT_SINGLE(MPLY:(LOCAL:0), "全")
		RETURN 0
	;拘束されているなら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
NEXT
;全てのターゲットについて判定
FOR LOCAL:0, 0, MTAR_NUM
	;女のみ
	SIF !IS_FEMALE(MTAR:(LOCAL:0))
		RETURN 0
	;顔面騎乗されているなら不可
	SIF IS_RIDDEN(MTAR:(LOCAL:0))
		RETURN 0
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM98
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●全プレイヤーについて処理
FOR LOCAL:0, 0, MPLY_NUM
	LOCAL:2 = MPLY:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 50

	SOURCE:(LOCAL:2):嗜虐 = 50
	SOURCE:(LOCAL:2):露出 = 30
	SOURCE:(LOCAL:2):逸脱 = 20
	SOURCE:(LOCAL:2):接触 = 30

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 50, 200)
NEXT

;●全ターゲットについて処理
FOR LOCAL:0, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:0)

	DOWNBASE:(LOCAL:2):体力 += 200

	SOURCE:(LOCAL:2):露出 = 1200
	SOURCE:(LOCAL:2):逸脱 = 300
	SOURCE:(LOCAL:2):不安 = 300
	SOURCE:(LOCAL:2):性行動 = 240
	SOURCE:(LOCAL:2):快Ｖ = SENSE_HOUSHI(MPLY:0, MTAR:0, 1500)
	SOURCE:(LOCAL:2):快Ａ = SENSE_HOUSHI(MPLY:0, MTAR:0, 1500)

	EXP:(LOCAL:2):精愛経験値 += 1
	EXP:(LOCAL:2):露出経験値 += 3

	CALL RECORD_CREAMPIE(LOCAL:2, -1, CUM_AMOUNT_CORRECTION(-1, LOCAL:2, 射精部位_膣内, RAND(3, 7)), 射精部位_膣内)
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
@COM_IS_EQUIP98
RETURN 0


;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER98(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 98

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -2)
ENDIF
IF TALENT:(ARG:0):汚臭鈍感
	CALL COM_ORDER_ELEMENT(ARG:0, "汚臭鈍感", 1)
ENDIF
IF TALENT:(ARG:0):汚臭敏感
	CALL COM_ORDER_ELEMENT(ARG:0, "汚臭敏感", -4)
ENDIF
IF TALENT:(ARG:0):献身的
	CALL COM_ORDER_ELEMENT(ARG:0, "献身的", 6)
ENDIF


RETURN 1

;-------------------------------------------------
;地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE98
#DIMS 場所
#DIMS 内容
#DIMS 相手
#DIMS シチュ
;#DIMS 衣服
LOCALS:0 = %ANAME(MPLY:0)%
LOCALS:1 = %ANAME(MTAR:0)%

;-----------選択肢表示-----------

;PRINTFORML %LOCALS:1%に服を着せて送り出しますか？
;PRINTFORML [0] 服を着せる
;PRINTFORML [1] 服を着せない
;$INPUT_LOOP
;INPUT
;IF RESULT == 0
;	PRINTFORMW 服を着せることにしました
;	衣服 = 着衣
;ELSEIF RESULT == 1
;	PRINTFORMW 服を着せないことにしました
;	衣服 = 全裸
;ELSE
;	GOTO INPUT_LOOP
;ENDIF
;

IF MPLY:0 == MASTER
	PRINTFORML
	PRINTFORML %LOCALS:1%をどこに送り出しますか？
	CALL ASK_MULTI("歓楽街", "スラム", "公衆便所", "森林", "水辺", "温泉", "やめておく")
```
