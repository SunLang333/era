# SHOP/SHOP_LIFE/SHOP_LIFE31_捕虜の調教_単体.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE31_捕虜の調教_単体.ERB`

类型: .ERB

自动摘要: functions: PRISONER_TRAIT, PRISONER_TRAIT_PRINTBUTTONS, PRISONER_TRAIT_START_TRAIN, PRISONER_TRAIT_FORGIVE, PRISONER_TRAIT_EXAMPLE, PRISONER_TRAIT_LENIENT, PRISONER_TRAIT_RELEASE, PRISONER_TRAIT_FREE, PRISONER_TRAIT_BANISH, PRISONER_TRAIT_EXECUTE, PRISONER_TRAIT_EXECUTE_TENTACLE, PRISONER_TRAIT_EXECUTE_PREGNANT, PRISONER_TRAIT_EXECUTE_PREGNANT_TENTACLE; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;捕虜の調教でターゲットが一人だけのときの処理
;-------------------------------------------------
@PRISONER_TRAIT(ARG:0)
#DIM FIRST_LINE
#DIM CONST 選択肢_調教 = 0
#DIM CONST 選択肢_許す = 1
#DIM CONST 選択肢_見せしめ = 2
#DIM CONST 選択肢_軟禁 = 3
#DIM CONST 選択肢_釈放 = 4
#DIM CONST 選択肢_解放 = 5
#DIM CONST 選択肢_追放 = 6
#DIM CONST 選択肢_処刑 = 7
#DIM CONST 選択肢_触手処刑 = 8
#DIM CONST 選択肢_キャンセル = 99

FIRST_LINE = LINECOUNT

;SHOW_INFOの初期画面を基本情報にする
FLAG:能力表示モード = 0

;対象キャラの情報を表示
CALL SINGLE_DRAWLINE
CALL SHOW_INFO(ARG:0)
CALL SINGLE_DRAWLINE

PRINTFORML %ANAME(ARG:0)%をどうしますか？
CALL SINGLE_DRAWLINE
CALL PRISONER_TRAIT_PRINTBUTTONS(ARG:0)

INPUT

SELECTCASE RESULT
	CASE 選択肢_調教
		CALL PRISONER_TRAIT_START_TRAIN(ARG:0)
	CASE 選択肢_許す
		CALL PRISONER_TRAIT_FORGIVE(ARG:0)
	CASE 選択肢_見せしめ
		CALL PRISONER_TRAIT_EXAMPLE(ARG:0)
	CASE 選択肢_軟禁
		CALL PRISONER_TRAIT_LENIENT(ARG:0)
	CASE 選択肢_釈放
		CALL PRISONER_TRAIT_RELEASE(ARG:0)
	CASE 選択肢_解放
		CALL PRISONER_TRAIT_FREE(ARG:0)
	CASE 選択肢_追放
		CALL PRISONER_TRAIT_BANISH(ARG:0)
	CASE 選択肢_処刑
		CALL PRISONER_TRAIT_EXECUTE(ARG:0)
	CASE 選択肢_触手処刑
		CALL PRISONER_TRAIT_EXECUTE_TENTACLE(ARG:0)
	CASE 選択肢_キャンセル
		RETURN 1
ENDSELECT

SIF RESULT == 1
	RETURN 

CLEARLINE LINECOUNT - FIRST_LINE
RESTART

;-------------------------------------------------
;捕虜の調教でターゲットが一人だけのときの処理中のボタン描画処理
;-------------------------------------------------
@PRISONER_TRAIT_PRINTBUTTONS(ARG:0)
#DIM CONST 選択肢_調教 = 0
#DIM CONST 選択肢_許す = 1
#DIM CONST 選択肢_見せしめ = 2
#DIM CONST 選択肢_軟禁 = 3
#DIM CONST 選択肢_釈放 = 4
#DIM CONST 選択肢_解放 = 5
#DIM CONST 選択肢_追放 = 6
#DIM CONST 選択肢_処刑 = 7
#DIM CONST 選択肢_触手処刑 = 8
#DIM CONST 選択肢_キャンセル = 99

PRINTBUTTON "[調教]", 選択肢_調教
PRINTPLAIN   

IF CFLAG:(ARG:0):外交調教中
	PRINTBUTTON "[許す]", 選択肢_許す
	PRINTPLAIN   
	PRINTBUTTON "[見せしめ]", 選択肢_見せしめ
	PRINTPLAIN   
	PRINTBUTTON "[キャンセル]", 選択肢_キャンセル
	PRINTL
	RETURN
ENDIF

IF CFLAG:(ARG:0):所属 != CFLAG:MASTER:所属
	PRINTBUTTON "[軟禁]", 選択肢_軟禁
	PRINTPLAIN   
	IF !FLAG:クリアフラグ
		PRINTBUTTON "[解放]", 選択肢_解放
		PRINTPLAIN   
	ENDIF
ELSE
	PRINTBUTTON "[釈放]", 選択肢_釈放
	PRINTPLAIN   
	IF !FLAG:クリアフラグ
		PRINTBUTTON "[追放]", 選択肢_追放
		PRINTPLAIN   
	ENDIF
ENDIF
PRINTBUTTON "[処刑]", 選択肢_処刑
PRINTPLAIN   
IF ITEM:触手部屋 && ID_TO_CHARA(FLAG:触手部屋管理者) >= 0
	PRINTBUTTON "[触手処刑]", 選択肢_触手処刑
	PRINTPLAIN   
ENDIF
PRINTBUTTON "[キャンセル]", 選択肢_キャンセル
PRINTL

;-------------------------------------------------
;捕虜の調教 調教開始
;-------------------------------------------------
@PRISONER_TRAIT_START_TRAIN(ARG:0)
CALL PRISONER_SCAPEGOAT(ARG:0)
CALL DECIDE_PRISONER_MEMBER()
RETURN 1

;-------------------------------------------------
;外交　許す
;-------------------------------------------------
@PRISONER_TRAIT_FORGIVE(ARG:0)

SIF !CFLAG:(ARG:0):外交調教中
	RETURN 0

PRINTFORML %ANAME(ARG:0)%の体を自由にする権利を手放します
PRINTFORML よろしいですか？
CALL ASK_YN

SIF RESULT == 1
	RETURN 0

PRINTFORMW %ANAME(ARG:0)%を許してやりました

CFLAG:(ARG:0):外交調教中 = 0
SIF FINDELEMENT(PRISONER_TARGET, ARG:0) != -1
	PRISONER_TARGET:(FINDELEMENT(PRISONER_TARGET, ARG:0)) = -1

RETURN 1

;-------------------------------------------------
;見せしめ
;-------------------------------------------------
@PRISONER_TRAIT_EXAMPLE(ARG:0)

SIF !CFLAG:(ARG:0):外交調教中
	RETURN 0

CVARSET CFLAG, GETNUM(CFLAG, "閨に呼ぶで選択中"), 0
CFLAG:(ARG:0):閨に呼ぶで選択中 = 1
CFLAG:(ARG:0):調教参加フラグ = 1
CFLAG:(ARG:0):強制友好化 = 1

;全員の慰安参加者フラグをクリア（あてがうメニューで操作されるため）
CVARSET CFLAG, GETNUM(CFLAG, "慰安参加者") , 0

;慰安モブの生成
LOCAL:1 = RAND(3, 6) - LOCAL:2
FOR LOCAL, 0, LOCAL:1
	CALL CREATE_IAN_MOB(慰安_行き先_一般住宅街, LOCAL + 1)
	SIF RESULT == -1
		BREAK
NEXT

FLAG:慰安モード = 3
FLAG:慰安場所 = 慰安_行き先_一般住宅街
ITEM:A_ローター = 1
ITEM:A_バイブ = 1
ITEM:A_アナルバイブ = 1
ITEM:A_ペニスバンド = 1
ITEM:A_オナホール = 1
ITEM:A_クリキャップ = 1
ITEM:A_ニプルキャップ = 1
ITEM:A_麻薬 = 99
ITEM:A_縄 = 1
ITEM:A_鞭 = 1
ITEM:A_目隠し = 1
ITEM:A_口枷 = 1
ITEM:A_鼻フック = 1
ITEM:A_マジック = 1
ITEM:A_ローション = 99
ITEM:A_コンドーム = 99
ITEM:A_媚薬 = 99
ITEM:A_排卵誘発剤 = 99
ITEM:A_桃源香 = 99
FLAG:調教モード = 7
;ウフフフラグをONに
FLAG:ウフフフラグ = 1

PRINTFORMW 裸にした%ANAME(ARG:0)%を町の広場まで連れてきた
PRINTFORMW 領民を慰めるのに、せいぜい役立ってもらうとしよう……

;行動開始時の共通処理
CALL START_TRAIN_COMMON

RETURN 1
```
