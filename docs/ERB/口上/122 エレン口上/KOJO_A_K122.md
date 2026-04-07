# 口上/122 エレン口上/KOJO_A_K122.ERB — 自动生成文档

源文件: `ERB/口上/122 エレン口上/KOJO_A_K122.ERB`

类型: .ERB

自动摘要: functions: CHANGE_TALENT_ELLEN, KOJO_TRAIN_START_A1_K122, KOJO_TRAIN_END_A1_K122, KOJO_TRAIN_START_A2_K122, KOJO_TRAIN_END_A2_K122, KOJO_COM_BEFORE_TARGET_A_K122, KOJO_COM_BEFORE_PLAYER_A_K122, KOJO_COM_A_K122, KOJO_COM_TARGET_A_K122, KOJO_COM_PLAYER_A_K122, KOJO_COM_AFTER_A_K122; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------
;めも
;CSTR:90 特別な呼び名

;CFLAG:300 呼び名変更イベ
;CFLAG:350 初絶頂
;CFLAG:351 初めてペニスを観察した
;CFLAG:400 素質等変更処理
;CFLAG:401 空白（旧 性的嗜好を変更した場合の借金）
;TCVAR:650 続きは夜で
;TCVAR:651 C絶頂回数
;TCVAR:652 V絶頂回数
;TCVAR:653 A絶頂回数
;TCVAR:654 B絶頂回数
;TCVAR:655 M絶頂回数
;TCVAR:656 MASTERの射精･絶頂回数

;素質などの変更処理。SELECT_SP_COUNTRYのパクリ
@CHANGE_TALENT_ELLEN
#DIM 消去行
$SHOW_LOOP
消去行 = 10
PRINTFORMDL バストサイズ
CALL PRINTBUTTON_EX("{普通（デフォルト）}", 0, 1, TALENT:バストサイズ == 0)
CALL PRINTBUTTON_EX("{絶壁}", 1, 1, TALENT:バストサイズ == -2)
PRINTL

PRINTFORMDL 髪の長さ
CALL PRINTBUTTON_EX("{夢時空準拠（デフォルト）}", 5, 1, TALENT:髪の長さ == 5)
CALL PRINTBUTTON_EX("{原作準拠}", 6, 1, TALENT:髪の長さ == 4)
PRINTL

PRINTFORMDL 野心
CALL PRINTBUTTON_EX("{普通（デフォルト）}", 10, 1, ABL:野心 == 47)
CALL PRINTBUTTON_EX("{やや低い}", 11, 1, ABL:野心 == 32)
CALL PRINTBUTTON_EX("{低い}", 12, 1, ABL:野心 == 22)
PRINTL

PRINTL
PRINTL
PRINTBUTTON "[これで決定]", 999
INPUT
IF RESULT == 999
	RETURN
ELSEIF RESULT == 0
	TALENT:バストサイズ = 0
ELSEIF RESULT == 1
	TALENT:バストサイズ = -2
ELSEIF RESULT == 5
	TALENT:髪の長さ = 5
ELSEIF RESULT == 6
	TALENT:髪の長さ = 4
ELSEIF RESULT == 10
	ABL:野心 = 47
ELSEIF RESULT == 11
	ABL:野心 = 32
ELSEIF RESULT == 12
	ABL:野心 = 22
ENDIF
CLEARLINE 消去行
GOTO SHOW_LOOP

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K122
;今は使っていないCFLAG:401を消しておく
SIF CFLAG:401
	CFLAG:401 = 0
;CSTR:90が空白ならMASTERの名前を入れておく
SIF CSTR:90 == ""
	CSTR:90 = %ANAME(MASTER)%
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
;[服従]でも口上を表示しない
ELSEIF TALENT:服従
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;素質変更処理
	IF CFLAG:400 == 0
		CFLAG:400 = 1
		PRINTFORMDL 素質等の変更を行いますか？
		CALL ASK_YN("はい", "いいえ")
		SIF RESULT == 0
			CALL CHANGE_TALENT_ELLEN
		PRINTW 
		CALL SINGLE_DRAWLINE
	ENDIF
	;初対面の場合
	IF !CFLAG:17
		;捕虜の場合
		IF CFLAG:9
			PRINTFORMW 「まあ、一応自己紹介しないとね」
			PRINTFORMW 「わたしはふわふわエレンよ、それでこの子がソクラテス」
			$hatu1
			PRINTFORMDL [0] ご丁寧な挨拶をどうも、私は%ANAME(MASTER)%と申します。以後お見知りおきを
			PRINTDL [1] ふわふわ？
			PRINTDL [2] うっわー、はずかしい名前！
			INPUT
			IF RESULT == 0
				PRINTFORMW 「あなたも丁寧な挨拶をどうも、よろしくね」
			ELSEIF RESULT == 1
				PRINTFORMW 「おじいちゃんがつけてくれたの。　まあそれはともかく、よろしくね」
			ELSEIF RESULT == 2
				PRINTFORMW 「そうかしら？　まあそれはともかく、よろしくね」
			ELSE
				GOTO hatu1
			ENDIF
		ELSE
			PRINTFORMW 「あら、初めて会う人ね」
			PRINTFORMW 「わたしはふわふわエレンよ、それでこの子がソクラテス」
			$hatu2
			PRINTFORMDL [0] ご丁寧な挨拶をどうも、私は%ANAME(MASTER)%と申します。以後お見知りおきを
			PRINTDL [1] ふわふわ？
			PRINTDL [2] うっわー、はずかしい名前！
			INPUT
			IF RESULT == 0
				PRINTFORMW 「あなたも丁寧な挨拶をどうも%UNICODE(0x2665)% これからよろしくね%UNICODE(0x2665)%」
			ELSEIF RESULT == 1
				PRINTFORMW 「おじいちゃんがつけてくれたの。　まあそれはともかく、これからよろしくね%UNICODE(0x2665)%」
			ELSEIF RESULT == 2
				PRINTFORMW 「そうかしら？　まあそれはともかく、これからよろしくね%UNICODE(0x2665)%」
			ELSE
				GOTO hatu2
			ENDIF
		ENDIF
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「こうして顔を会わせるのは初めてね」
		PRINTFORMW 「わたしはふわふわエレンよ、それでこの子がソクラテス」
		GOTO hatu2
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORMW 「ええと…こんにちは//」
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTFORMW 「こんにちは、%CSTR:90%%UNICODE(0x2665)%」
	SIF TALENT:恋慕
		PRINTFORMDW エレンは嬉しそうに%ANAME(MASTER)%の元に寄って来た
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	IF CFLAG:好感度 >= 1000
		PRINTFORMW 「いらっしゃい%UNICODE(0x2665)% どうぞあがって%UNICODE(0x2665)%」
	ELSE
		PRINTFORMW 「こんにちは、よく来たわね」
		PRINTFORMW 「……もう怒ってないからそうかしこまらなくていいわよ」
	ENDIF
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「こんにちは%UNICODE(0x2665)% いまお茶を淹れてくるわ」

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
;ELSEIF TALENT:合意
;	
;既成事実Lv3(セックス済み)
;ELSEIF TALENT:合意
;	
;恋人かつ恋慕
ELSEIF TALENT:恋人 && TALENT:恋慕
	SELECTCASE RAND:3
		CASE 1
			PRINTFORMW 「あ%UNICODE(0x2665)% %CSTR:90%じゃない%UNICODE(0x2665)% 何の用かしら%UNICODE(0x2665)%」
		CASE 2
			LOCAL:1 = RAND:2
			PRINTFORMW 「いらっしゃい%UNICODE(0x2665)% \@ LOCAL:1 == 1 ? コーヒー # お茶 \@を淹れてくるからちょっと待ってて%UNICODE(0x2665)%」
			PRINTFORMDW %ANAME(MASTER)%にそう伝えると、エレンは台所へと向かっていった…
			$LOOP2
			PRINTDL [0] 大人しく待つ
			PRINTDL [1] エレンを手伝う
			SIF TALENT:合意 && !TALENT:妊娠
				PRINTDL [2] いたずらする
			INPUT
			IF RESULT == 0
				PRINTFORMDW %ANAME(MASTER)%は待っている事にした
				PRINTDW …
				PRINTFORMDW 暫くするとエレンが\@ LOCAL:1 == 1 ? コーヒー # お茶 \@とお菓子を持って戻ってきた
				PRINTFORMW 「お待たせ%UNICODE(0x2665)% それでなんの用かしら%UNICODE(0x2665)%」
			ELSEIF RESULT == 1
				PRINTFORMDW %ANAME(MASTER)%はエレンの後を追いかけ、何か手伝える事はないか尋ねた
```
