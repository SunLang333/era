# 口上/35 小町口上/_KOJO_EVENT_K35.ERB — 自动生成文档

源文件: `ERB/口上/35 小町口上/_KOJO_EVENT_K35.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K35; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;イベント口上
;-------------------------------------------------

;=================================================
;●各種イベント
;※ARGにイベント番号が入る。詳しくは資料フォルダの「era恋姫 イベント表」を参照
;※RETURNの値を0→1に変えると、デフォルトのメッセージが表示されなくなる
;=================================================
@KOJO_EVENT_K35(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		;PRINTFORMW 
	;恋人
	ELSEIF TALENT:恋人
		;PRINTFORMW 
	;それ以外
	ELSE
		;PRINTFORMW 
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	PRINTL
	;恋慕
	SETCOLOR カラー_パ赤
	IF TALENT:恋慕
		PRINTFORMW 「…ほ、本気かい？　あんた……」
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、己の思いを伝えた
		PRINTFORML 
		PRINTFORMW 「わ、分かってんのかい？　あたいは死神だよ？　そんなのと付き合いたいなんて、嫌じゃないのかい？」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は戸惑いつつも、思いを寄せていた%ANAME(MASTER)%に告白されて内心喜んでいるようだ
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%が%ANAME(TARGET)%の手を取り、そんなことは気にしない　と伝えると、彼女の顔に満面の笑みが浮かんだ
		PRINTFORML 
		PRINTFORMW 「……まったく、死神に惚れるなんて…。本当に物好きなんだから…♥」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の告白を受け入れ、ぎゅっと抱きしめてきた
		PRINTFORML 
		PRINTFORMW 「私もあんたのこと、大好きだよ…。これからも、一緒にいておくれよ……♥」
		PRINTFORML 
		PRINTFORMW 甘い雰囲気の中、二人はしばらくの間ずっと抱き合っていた……
		PRINTFORML 
		PRINTFORMW 二人は晴れて恋人となった
		PRINTFORML 
		RESETCOLOR
		RETURN 1
	ELSEIF TALENT:服従
		RESETCOLOR
		RETURN 0
	;それ以外
	ELSE
		PRINTFORMW 「…本気かい？　死神のあたいと？」
		PRINTFORML 
		PRINTFORMW 「冗談とかじゃあないだろうね？　そういうのは嫌いだよ？」
		PRINTFORML 
		PRINTFORMW この気持ちは嘘じゃない。%ANAME(MASTER)%は%ANAME(TARGET)%に己の思いを伝えた
		PRINTFORML 
		PRINTFORMW 「……本気なんだね。ふむ……」
		PRINTFORML 
		PRINTFORMW しばし考えた後、%ANAME(TARGET)%はにかっと笑い%ANAME(MASTER)%に顔を向けた
		PRINTFORML 
		PRINTFORMW 「死神と付き合いたいとか面白いこと考えるねぇ。いいよ、付き合ってあげる」
		PRINTFORML 
		PRINTFORMW 「あんたのことも、別に嫌いじゃないしね。その代わり、ちゃんと恋人らしく扱っておくれよ？」
		PRINTFORML 
		PRINTFORMW 二人は笑顔で手を繋ぎ、晴れて恋人となった
		PRINTFORML 
		RESETCOLOR
		RETURN 1
	ENDIF
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTL
	PRINTFORMW 「あー…、悪いね。今はまだそんな気になれないんだよ」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL 
	PRINTFORML 「ふあ、あぁ～…、だ、だめだってぇ……」
	PRINTFORMW %ANAME(TARGET)%は酔いが回って%ANAME(MASTER)%を拒みきれないようだ
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL 
	;恋慕
	IF TALENT:恋慕
		PRINTFORML 「きゃんっ！　……つ、ついに、するんだね…。あたいと…♥」
		PRINTFORML %ANAME(TARGET)%はやや緊張気味にしつつも、%ANAME(MASTER)%のことを受け入れている
		PRINTFORMW 「ちゃんと優しくしておくれよ？　%ANAME(MASTER)%」
	;服従
	ELSEIF TALENT:服従
		PRINTFORML 「きゃんっ！　……ち、ちゃんと抱いてくれるんですね…。私を…♥」
		PRINTFORML %ANAME(TARGET)%はやや緊張気味にしつつも、%ANAME(MASTER)%のことを受け入れている
		PRINTFORMW 「ちゃんと抱くなら、その……優しくしてほしいです」
	;それ以外
	ELSE
		PRINTFORML 「きゃんっ！　……もう。しょうがないなぁ」
		PRINTFORMW %ANAME(TARGET)%は力を抜いて、%ANAME(MASTER)%のことを受け入れている
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL 
	PRINTFORMW 「あたいはそんな安い女じゃないよ」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL 
	;恋慕
	IF TALENT:恋慕
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「きゃん！　…もう♥　我慢できないのかい？」
				PRINTFORMW 「ふふ、しょうがないねぇ♪　そのかわり、あたいもキモチよくしておくれよ♥」
			CASE 1
				PRINTFORML 「きゃっ！　……もう、そんなにあたいが欲しいのかい？　この助平♥」
				PRINTFORML %ANAME(TARGET)%は押し倒してきた%ANAME(MASTER)%をキスで受け入れた
				PRINTFORMW 「ま、あたいも%ANAME(MASTER)%が欲しかったところだし、おあいこだね♥」
			CASE 2
				PRINTFORML 「きゃん！　…ふふ、もう辛抱たまらないって顔だねぇ♥」
				PRINTFORML %ANAME(TARGET)%は自慢の巨乳で、%ANAME(MASTER)%の顔を抱き包む
				PRINTFORMW 「今日もあたいを、愛しておくれ……♥」
		ENDSELECT
	;隷属
	ELSEIF TALENT:隷属
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「きゃん！　…もう我慢できませんか？」
				PRINTFORMW 「ふふ、いいですよぉ…♥　私のこと、めちゃくちゃにしてください♥」
			CASE 1
				PRINTFORML 「きゃっ！　……私のこと、そんなに求めてくれるんですね♥」
				PRINTFORML %ANAME(TARGET)%は押し倒してきた%ANAME(MASTER)%をキスで受け入れた
				PRINTFORMW 「私も%ANAME(MASTER)%様のが欲しいです。どうかお恵みください♥」
			CASE 2
				PRINTFORML 「ああ、%ANAME(MASTER)%様♥　…どうぞ私を好きにしてください♥」
				PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%専用の巨乳で、主人の顔を抱き包む
				PRINTFORMW 「はあぁ♥　今日も私を、めちゃくちゃにして……♥」
		ENDSELECT
	;服従
	ELSEIF TALENT:服従
		SELECTCASE RAND:3
			CASE 0
				PRINTFORMW 「きゃん！　…も、もう我慢できませんか？」
			CASE 1
				PRINTFORMW 「きゃっ！　……そ、そんなにあたいが欲しいんですか？」
			CASE 2
				PRINTFORMW 「きゃん！　…あ、あたいの身体、好きにしてください…」
		ENDSELECT
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	;恋慕
	IF TALENT:恋慕
		PRINTFORML 「ちょ…ちょっと休憩させとくれよぉ……」
	;服従
	ELSEIF TALENT:服従
		PRINTFORML 「す、すいません……身体が持ちません…」
	ELSE
		PRINTFORML 「がっつきすぎだよ…」
	ENDIF
	RETURN 0
ENDIF

```
