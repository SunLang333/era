# 口上/77 白蓮口上/_KOJO_EVENT_K77.ERB — 自动生成文档

源文件: `ERB/口上/77 白蓮口上/_KOJO_EVENT_K77.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K77; UI/print

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
@KOJO_EVENT_K77(ARG)
#DIM 対象
#DIM 命蓮
対象 = NAME_TO_CHARA("白蓮")
命蓮 = NAME_TO_CHARA("命蓮")

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
;KOJO_A_K77、KOJO_B_K77に移植

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	PRINTFORML 
	IF MASTER == NAME_TO_CHARA("命蓮")
		;恋慕
		IF TALENT:恋慕 && CFLAG:振られた回数 > 5
			PRINTFORML 「……酷い……こんなの狡いわ%ANAME(MASTER)%っ……！！
			PRINTFORMW   何度もお姉ちゃんを泣かせてまで今更なんて……そんなの酷いわっ……！」
			PRINTFORML 
			PRINTFORML  ……一度は断った%ANAME(TARGET)%の告白を、
			PRINTFORMW  %ANAME(MASTER)%はとうとう覚悟を決めて受ける事にした
			PRINTFORML 
			PRINTFORML  いつもと変わらぬ、諭すような口調で決意を語る%ANAME(MASTER)%の言葉を
			PRINTFORMW  聞き入る%ANAME(TARGET)%は、溢れる涙に零れる笑みを隠せないでいた。

		ELSEIF TALENT:恋慕 && CFLAG:振られた回数 < 5
			PRINTFORML 「本当にわかってるの……？　姉弟、なのよ……？　それでも、本当にいいの？」
			PRINTFORML 
			PRINTFORML  意を決した%ANAME(MASTER)%の告白は、
			PRINTFORMW  目を丸くして聞き入る%ANAME(TARGET)%が段々と顔を赤らめてゆく。
			PRINTFORML 
			PRINTFORML  そして指を唇に宛てると、暫し物思いに耽るように視線を落とし、
			PRINTFORMW  何度も躊躇いながら視線を交互に送っていた。
			PRINTFORML 
			PRINTFORML 「……わかりました…………だって、本当は私も――」
			PRINTFORMW 
			PRINTFORMW  そうなりたかったと、消え入り聞こえなくなった言葉を、唇だけが震えたまま紡がれていたのだった...

		ELSE
			PRINTFORML 「えっ、%ANAME(MASTER)%？！　あ、あの……だって……そんな……」
			PRINTFORMW  
			PRINTFORML  意を決した%ANAME(MASTER)%の告白は、
			PRINTFORMW  驚き目を丸くした%ANAME(TARGET)%が硬直してしまう
			PRINTFORML  
			PRINTFORML  そしてじりじりと解けてゆく硬直は、姉弟なのにそれを喜んでしまった姉は如何なものか、
			PRINTFORMW  受けてしまえば畜生道まっしぐらに爛れた未来が見えます、等々……%PRONOUN(TARGET)%の逡巡と混乱は尚続く
			PRINTFORML  
			PRINTFORML 「……こ、恋人ごっこです……
			PRINTFORMW   %ANAME(MASTER)%に……悪い虫がつかない様にする為の、恋人ごっこなら……」
			PRINTFORML  
			PRINTFORMW  それは本音を隠すために必要な建前、%ANAME(TARGET)%にとって唯一の譲歩だった...、
		ENDIF
	ELSE
		;恋慕
		IF TALENT:恋慕 && CFLAG:振られた回数 >= 1
			PRINTFORML 「…………本当に、本当なのですね……？」
			PRINTFORMW 
			PRINTFORML  ……一度は断った筈の%ANAME(TARGET)%の告白を、
			PRINTFORMW  とうとう%ANAME(MASTER)%は覚悟を決めて受ける事にした
			PRINTFORML 
			PRINTFORML  いつもと変わらぬ、諭すような口調で決意を語る%ANAME(TARGET)%の言葉を
			PRINTFORMW  聞き入る%ANAME(TARGET)%は、溢れる涙に零れる笑みを隠せないでいた...

		ELSEIF TALENT:恋慕 && !CFLAG:振られた回数
			PRINTFORML  意を決した%ANAME(MASTER)%の告白は、%ANAME(TARGET)%は静かに聞き入ると、
			PRINTFORMW  一時考え込んだ%ANAME(TARGET)%が、返事をゆっくり紡ぎ始めた。
			PRINTFORML 
			PRINTFORML 「――……実は私も以前から……あなたと同じ感情を抱いていたことに、今更になって気づいてしまいました。
			PRINTFORMW   ですから私も、あなたにもっと近づきたいと思うのも、間違いじゃないと思うんです……ですから……その……喜んでお受けします……」
			PRINTFORML 
			PRINTFORML  そして、最後まで言い終えた%PRONOUN(TARGET)%は%ANAME(MASTER)%に寄り添うと、
			PRINTFORMW  自らの頭を%ANAME(MASTER)%の肩へと落としていたのだった...

		ELSE
			;PRINTFORMW 
		ENDIF
	ENDIF
	PRINTFORML 
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTFORML 
	IF MASTER == NAME_TO_CHARA("命蓮")
		PRINTFORML 「――――%ANAME(MASTER)%、心を落ち着けてよく聞いて下さい。
		PRINTFORMW   それほどまでに慕って頂けることが、他の誰よりも私にとっては嬉しいことです」
		PRINTFORML 
		PRINTFORML 「――……ですが私達は血の繋がった姉弟なのです。
		PRINTFORMW   それだけはきっと……幾ら仏様でもお許しにはならないわ……」
	ELSE
		PRINTFORML 「……それほど思って頂けた事が、私にとっては幸いです……
		PRINTFORMW   ですが気を落とさず聞いてください。私は今……誰ともお付き合いしたい方はいなのです」
	ENDIF
	PRINTFORMW 
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTFORML 
	PRINTFORML 「……？　あの、もしかして私……押し倒されちゃってたり、しますか……？」
	PRINTFORMW 
	PRINTFORMW  別れ際に人目の無い場所へと連れ込まれた%ANAME(TARGET)%は、%ANAME(MASTER)%に押し倒された...！

	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTFORML 
	PRINTFORML 「……いい、ですよ……優しくしてくださいね……？」
	PRINTFORMW 
	SIF MASTER == 命蓮
		PRINTFORMW 「……でも%ANAME(MASTER)%？　……するのは前戯まで、ですよ……？」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTFORML 
	PRINTFORML 「…………こらっ、おいたはメッ！　ですよ？
	PRINTFORMW   流れや勢いに任せて女性に乱暴を行おうとすれば、手痛いしっぺ返しは当然の事なんですよ？　ですから――」
	PRINTFORML 
	PRINTFORMW  ……意図も容易く腕を捻りあげられてしまった%ANAME(MASTER)%は、%ANAME(TARGET)%の長い長い説教が始まってしまった...

	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	IF TALENT:恋慕
		IF MASTER == NAME_TO_CHARA("命蓮")
			PRINTFORMW 「ふふっ……それじゃあ、私を抱きしめてもらえますか？」
			SIF TALENT:処女
				PRINTFORMW 「あ、だからって分かっていますよね？　絶対にダメなんですからね？　それだけは……しちゃいけないんですからね……？」
		ELSE
			;PRINTFORMW 
		ENDIF
	ELSEIF TALENT:服従
		IF MASTER == NAME_TO_CHARA("命蓮")
			;PRINTFORMW 
		ELSE
			;PRINTFORMW 
		ENDIF
	ELSE
		IF MASTER == NAME_TO_CHARA("命蓮")
			;PRINTFORMW 
		ELSE
			;PRINTFORMW 
		ENDIF
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;気力限界(通常)
;-------------------------------------------------
IF ARG == 12
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;怒りの限界で追い返される
;-------------------------------------------------
IF ARG == 13
	;PRINTFORMW 
	RETURN 0
ENDIF
```
