# SYSTEM/_FUNCTION_TATOO.ERB — 自动生成文档

源文件: `ERB/SYSTEM/_FUNCTION_TATOO.ERB`

类型: .ERB

自动摘要: functions: SET_TATTOO, CAN_TATTOO, CAN_TATTOO_ANYWHERE, REMOVE_TATTOO, GET_TATTOO_NAME, IS_TATTOOED, SET_TATTOO_RANKED, SET_TATTOO_RANDOM, PRINT_TATTOO, STR_FOR_TATTOO, CREATE_TATTOO_LIST, ADD_TATTOO_SAMPLE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿@TATTOO_MENU(対象, 編集モード = 0)
#DIM 対象
#DIM 編集モード
#DIM FIRST_LINE, 2
FIRST_LINE = LINECOUNT

FOR LOCAL, 0, VARSIZE("TATTOO")
	IF IS_TATTOOED(対象, LOCAL:0)
		PRINTBUTTON @"[{LOCAL:0}] %GET_TATTOO_NAME(LOCAL:0)% : %TATTOO:(対象):(LOCAL:0)%", LOCAL:0
		PRINTL
	ELSE
		PRINTBUTTON @"[{LOCAL:0}] %GET_TATTOO_NAME(LOCAL:0), 8, LEFT%", LOCAL:0
		PRINTBUTTON @"[{LOCAL:0 + 100}] %GET_TATTOO_NAME(LOCAL:0) + "(ランダム)", 20, LEFT%", LOCAL:0 + 100
		PRINTL
	ENDIF
NEXT
PRINTFORML [99] 戻る

INPUT
LOCAL:1 = RESULT
IF LOCAL:1 == 99
	PRINTFORML やはりやめておいた
	RETURN 0
ELSEIF INRANGE(LOCAL:1, 0, VARSIZE("TATTOO") - 1) && CAN_TATTOO(対象, LOCAL:1)
	PRINTFORML 何と彫り入れますか？(未入力でキャンセル)
	INPUTS
	CALL SET_TATTOO(対象, LOCAL:1, RESULTS:0)
	IF 編集モード
		CLEARLINE LINECOUNT - FIRST_LINE
		RESTART
	ELSE
		RETURN 1
	ENDIF
ELSEIF INRANGE(LOCAL:1, 0, VARSIZE("TATTOO") - 1) && 編集モード
	PRINTFORML %ANAME(対象)%の%GET_TATTOO_NAME(RESULT:0)%のタトゥーを消去しました
	TATTOO:(対象):RESULT = 
	CLEARLINE LINECOUNT - FIRST_LINE
	RESTART
ELSEIF INRANGE(LOCAL:1, 100, 99 + VARSIZE("TATTOO")) && CAN_TATTOO(対象, LOCAL:1 - 100)
	FIRST_LINE:1 = LINECOUNT
	$RANDOM_LOOP_TATTOO
	LOCALS:0 = %STR_FOR_TATTOO(LOCAL:1 - 100)%
	PRINTFORML 「%LOCALS:0%」を彫り入れるのはどうだろう……
	CALL ASK_MULTI("彫る", "別ので", "やめる")
	IF RESULT == 0
		CALL SET_TATTOO(対象, LOCAL:1 - 100, LOCALS:0)
		IF 編集モード
			CLEARLINE LINECOUNT - FIRST_LINE
			RESTART
		ELSE
			RETURN 1
		ENDIF
	ELSEIF RESULT == 1
		CLEARLINE LINECOUNT - FIRST_LINE:1
		GOTO RANDOM_LOOP_TATTOO
	ELSEIF RESULT == 2
		CLEARLINE LINECOUNT -FIRST_LINE
		RESTART
	ENDIF
ENDIF

CLEARLINE LINECOUNT - FIRST_LINE
RESTART

;---------------------------
;ARG:0のARG:1番にARG:2でタトゥーを入れる関数
;既に入っている場合は無理
;ARG:2はメッセージを表示するフラグ
;---------------------------
@SET_TATTOO(ARG:0, ARG:1, ARGS:0, ARG:2 = 1)
SIF !CAN_TATTOO(ARG:0, ARG:1)
	RETURN 0
SIF ARG:2
CALL COLOR_PRINTW(@"%ANAME(ARG:0)%の%GET_TATTOO_NAME(ARG:1)%に「%ARGS:0%」が刻まれた……", カラー_注意)
TATTOO:(ARG:0):(ARG:1) = %ARGS:0%
RETURN 1

;---------------------------
;ARG:0番のキャラが、ARG:1番のビットにタトゥーできるか
;---------------------------
@CAN_TATTOO(ARG:0, ARG:1)
#FUNCTION
;範囲外なら不可
SIF ARG:1 < 0 || VARSIZE("TATTOO") <= ARG:1
	RETURNF 0
;装着済みなら不可
SIF IS_TATTOOED(ARG:0, ARG:1)
	RETURNF 0
;それ以外は通す
RETURNF 1

;---------------------------
;ARG:0番のキャラが、どこでもいいからタトゥーできるか
;---------------------------
@CAN_TATTOO_ANYWHERE(ARG:0)
#FUNCTION
FOR LOCAL, 0, VARSIZE("TATTOO")
	SIF !IS_TATTOOED(ARG:0, LOCAL)
		RETURNF 1
NEXT
RETURNF 0

;---------------------------
;ARG:0のARG:1ビットのタトゥーを消す関数
;消したら1、そもそもなかったら0が返る
;タトゥーについてはピアスと違って、ゲーム内でユーザが任意に削除できる正規の方法を与えるつもりはない。この関数はデバッグ用
;というわけで、この関数を使用するパッチを作成するつもりの方はその辺お願いします
;---------------------------
@REMOVE_TATTOO(ARG:0, ARG:1, ARG:2 = 1)
IF IS_TATTOOED(ARG:0, ARG:1)
	TATTOO:(ARG:0):(ARG:1) = 
	RETURN 1
ENDIF
RETURN 0

;---------------------------
;TATTOO:キャラ名:部位　の部位の各番号に対応する部位名を返す関数
;---------------------------
@GET_TATTOO_NAME(ARG:0)
#FUNCTIONS
SELECTCASE ARG:0
	CASE タトゥー_額
		RETURNF "額"
	CASE タトゥー_頬
		RETURNF "頬"
	CASE タトゥー_肩
		RETURNF "肩"
	CASE タトゥー_胸
		RETURNF "胸"
	CASE タトゥー_背
		RETURNF "背"
	CASE タトゥー_腹
		RETURNF "腹"
	CASE タトゥー_秘部
		RETURNF "秘部"
	CASE タトゥー_尻
		RETURNF "尻"
	CASE タトゥー_腿
		RETURNF "腿"
	CASE タトゥー_足首
		RETURNF "足首"
	CASEELSE
		RETURNF "不明"
ENDSELECT

;---------------------------
;ARG:0のARG:1部位のタトゥーの有無を調べる関数
;---------------------------
@IS_TATTOOED(ARG:0, ARG:1)
#FUNCTION
SIF ARG:1 < 0 || VARSIZE("TATTOO") <= ARG:1
	RETURNF 0
RETURNF TATTOO:(ARG:0):(ARG:1) != ""

;---------------------------
;ARG:0に、ARG:2 ~ ARG:12番の優先順でARGS:0のタトゥーを入れる関数
;ARG:1を1にするとメッセージを表示。
;一部だけ設定するとかいうこともできる
;取り付けた場合は、彫ったタトゥーの部位番号が返る
;---------------------------
@SET_TATTOO_RANKED(ARG:0, ARGS:0, ARG:1, ARG:2 = 99, ARG:3 = 99, ARG:4 = 99, ARG:5 = 99, ARG:6 = 99, ARG:7 = 99, ARG:8 = 99, ARG:9 = 99, ARG:10 = 99, ARG:11 = 99)
FOR LOCAL:0, 2, VARSIZE("TATTOO") + 2
	CALL SET_TATTOO(ARG:0, ARG:(LOCAL:0), ARGS:0, ARG:1)
	SIF RESULT
		RETURN ARG:(LOCAL:0)
NEXT
RETURN -1

;---------------------------
;ARG:0番のキャラの、ランダムな部位にタトゥーを入れる
;ARG:1はメッセージ表示フラグ。0なら非表示。
;戻り値は取り付けた部位番号
;どこも空いてなかったら-1が戻ってくるので、その辺考えずに単純にRESULTをGET_TATTOO_NAMEにかけたりしないことこと
;---------------------------
@SET_TATTOO_RANDOM(ARG:0, ARGS:0, ARG:1  = 1)
#DIM 空き部位, VARSIZE("TATTOO")
#DIM 空き数
VARSET 空き部位, -1
VARSET 空き数

FOR LOCAL, 0, VARSIZE("TATTOO")
	IF CAN_TATTOO(ARG:0, LOCAL:0)
		空き部位:空き数 = LOCAL:0
		空き数 ++
	ENDIF
NEXT

;どこも空いてなかったら-1
SIF 空き数 == 0
	RETURN -1

LOCAL = 空き部位:(RAND:空き数)
CALL SET_TATTOO(ARG:0, LOCAL, ARGS:0, ARG:1)
SIF RESULT
	RETURN LOCAL
;多分こないはず
RETURN -1
;---------------------------
;ARG:0番のキャラがつけているタトゥーについて、PRINTする
;---------------------------
```
