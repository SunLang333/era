# SYSTEM/TURNEND.ERB — 自动生成文档

源文件: `ERB/SYSTEM/TURNEND.ERB`

类型: .ERB

自动摘要: functions: EVENTTURNEND, TURNEND_LIFE, TURNEND_POLITICS, TURNEND_COMMON, TURNEND_CHARA_PROCESS, MEET_CHECK_CANDIDATES, SELECT_CHARA_RANDOM_LOGIC_MEET_CHECK_CANDIDATES, MASTER_ESCAPE_FROM_PRISON, RELEASE_PRISONERS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;時間経過イベント
;-------------------------------------------------
@EVENTTURNEND
#PRI

FLAG:戦略フェイズページ = 1

;拠点フェイズ
IF TIME == 0
	IF SHOP_TIME >= CALC_SHOP_TIME() || CFLAG:MASTER:捕虜先
		CALL TURNEND_LIFE
	ELSE
		BASE:MASTER:体力 = MAXBASE:MASTER:体力
		BASE:MASTER:気力 = MAXBASE:MASTER:気力
		BEGIN SHOP
	ENDIF
;戦略フェイズ
ELSE
	CALL TURNEND_POLITICS
ENDIF

;逆調教要求日数が残っている場合
IF DIPLOMACY_TRAINED_DAY > 0 && !FLAG:ターンエンド調教 && !FLAG:調教要求フラグ
	DIPLOMACY_TRAINED_DAY --
	;全員の調教参加フラグを解除
	CVARSET CFLAG, 6, 0
	CFLAG:DIPLOMACY_TRAINING_CHARA:調教参加フラグ = 1
	;捕虜逆調教モード
	FLAG:調教モード = 5
	;ウフフモード
	FLAG:ウフフフラグ = 1
	PRINTFORML %ANAME(MASTER)%は外交交渉の見返りとして、%ANAME(DIPLOMACY_TRAINING_CHARA)%の寝室へ向かった……
	CALL START_TRAIN_COMMON
	RETURN
ENDIF

;君主逆調教要求日数が残っている場合
IF DIPLOMACY_TRAINED_DAY < 0 && !FLAG:調教要求フラグ
	DIPLOMACY_TRAINED_DAY ++
	;捕虜逆調教モード
	FLAG:調教モード = 調教_慰安
	FLAG:慰安モード = 3
	FLAG:慰安場所 = 慰安_行き先_貴族の居住地
	;ウフフモード
	FLAG:ウフフフラグ = 1
	FLAG:調教要求フラグ = 1
	FLAG:夜這い = 0
	;アイテムを一通り追加
	ITEM:A_ローター = 1
	ITEM:A_バイブ = 1
	ITEM:A_アナルバイブ = 1
	ITEM:A_ペニスバンド = 1
	ITEM:A_オナホール = 1
	ITEM:A_クリキャップ = 1
	ITEM:A_ニプルキャップ = 1
	ITEM:A_媚薬 = 99
	ITEM:A_排卵誘発剤 = 99
	;全員の調教参加フラグを解除
	CVARSET CFLAG, 6, 0
	CFLAG:DIPLOMACY_TRAINING_CHARA:調教参加フラグ = 1
	CFLAG:DIPLOMACY_TRAINING_CHARA:慰安参加者 = 1
	CFLAG:DIPLOMACY_TRAINING_CHARA:行動済み = 1
	CFLAG:GET_COUNTRY_BOSS(CFLAG:MASTER:所属):調教参加フラグ = 1
	PRINTFORMW %ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%は外交交渉の見返りとして、%ANAME(DIPLOMACY_TRAINING_CHARA)%の寝室へ向かった……

	;時間の処理をしないと、「拠点フェイズの終了時にここに到達、調教→調教終了でSLGフェイズのターンエンドが呼ばれ、次期の拠点フェイズに飛ぶ」みたいな挙動になる
	;IF TIME == 0
	;	DAY --
	;	SIF !FLAG:クリアフラグ
	;		TIME = 1
	;ELSEIF TIME == 1
	;	TIME = 0
	;	SHOP_TIME = CALC_SHOP_TIME()
	;ENDIF

	;行動開始時の共通設定
	CALL START_TRAIN_COMMON
	REDRAW 1
	RETURN
ENDIF

$SKIPPED

;デッドエンディングならBEGIN TITLE
IF FLAG:強制エンドフラグ == 1

	SETCOLOR カラー_注意
	PRINTFORMW 現時点でのデータを利用し、「周回用セーブ」を作ることができます
	PRINTFORMW 周回用セーブをロードすることで、今の武将やアイテムを引き継いで新規にシナリオを開始できます
	RESETCOLOR

	FLAG:クリア直後フラグ = 1

	CALL SAVE_GAME

	BEGIN TITLE
;ターンエンド調教が立っているなら即時調教モードに入る
ELSEIF FLAG:ターンエンド調教
	SELECTCASE FLAG:ターンエンド調教
		CASE 1
			FLAG:調教モード = 1
		CASE 2
			FLAG:調教モード = 5
			FLAG:ウフフフラグ = 1
		CASE 3
			FLAG:調教モード = 7
			FLAG:慰安モード = 3
	ENDSELECT
	FLAG:ターンエンド調教 = 0
	FLAG:ウフフフラグ = 1
	FLAG:夜這い = 0
	;時間の処理をしないと、「拠点フェイズの終了時にここに到達、調教→調教終了でSLGフェイズのターンエンドが呼ばれ、次期の拠点フェイズに飛ぶ」みたいな挙動になる
	IF TIME == 0
		IF !FLAG:クリアフラグ
			TIME = 1
			DAY --
		ENDIF
	ELSEIF TIME == 1
		TIME = 0
		SHOP_TIME = CALC_SHOP_TIME()
	ENDIF
	FLAG:イベント発生禁止 = 1
	CALL START_TRAIN_COMMON
ELSE
	SIF FLAG:調教要求フラグ
		FLAG:調教要求フラグ = 0
	FLAG:イベント発生禁止 = 0
	BEGIN SHOP
ENDIF

;-------------------------------------------------
;拠点フェイズ終了時の処理
;-------------------------------------------------
@TURNEND_LIFE
SHOP_TIME = 0
SHOP_WORK_COUNT = 0

SIF FLAG:イベント発生禁止
	GOTO SKIPPED

;夜に起こるイベント(夜這いなど)
;CALL EVENT_NIGHT

CALL EVENT_WORK

IF CONFIG:7 == 0
	;捕虜の扱いを設定
	CALL SETSTATE_PRISONER
ELSE
	;捕虜の人数をカウント
	LOCAL:5 = 0
	FOR LOCAL:0, 0, CHARANUM
		IF LOCAL:0 != MASTER && CFLAG:(LOCAL:0):捕虜先 != 0 && CFLAG:(LOCAL:0):捕虜先 == CFLAG:MASTER:所属 && CFLAG:(LOCAL:0):軟禁中 == 0
			LOCAL:5 ++
		ENDIF
	NEXT
	;捕虜が一人でもいればラインを引く
	IF LOCAL:5 >= 1
		CALL SINGLE_DRAWLINE
	ENDIF
ENDIF


CALL EVENT_PRISONER

;捕虜でなければ、FLAG:逆調教回数（捕虜調教回数）を消す
IF !CFLAG:MASTER:捕虜先
	FLAG:逆調教メイン調教者 = 0
	FLAG:逆調教回数 = 0
ENDIF

;口上呼び出し
FOR LOCAL:0, 0, CHARANUM
	;主人公と同一勢力の仕官で、捕虜でない
	IF CFLAG:(LOCAL:0):所属 != 0 && LOCAL:0 != MASTER && CFLAG:(LOCAL:0):所属 == CFLAG:MASTER:所属 && CFLAG:(LOCAL:0):捕虜先 == 0
		CALL KOJO_EVENT(LOCAL:0, 30)
	ENDIF
NEXT

;デイリーイベント
CALL EVENT_DAILY
CALL EVENT_KOJO_DAILY

$SKIPPED


;統一後の場合
IF FLAG:クリアフラグ
	;一期終了時の処理
	SIF !FLAG:ターンエンド調教
		CALL TURNEND_COMMON
	;クールタイムのリセット
	CVARSET COOLTIME, 0
	;ターンを進める
	DAY ++
;捕虜の場合
ELSEIF CFLAG:MASTER:捕虜先 != 0
	;強制的に自動行動
	LOCAL:0 = CONFIG:302
```
