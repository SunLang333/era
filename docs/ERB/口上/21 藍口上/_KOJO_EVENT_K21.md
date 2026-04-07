# 口上/21 藍口上/_KOJO_EVENT_K21.ERB — 自动生成文档

源文件: `ERB/口上/21 藍口上/_KOJO_EVENT_K21.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K21; UI/print

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
@KOJO_EVENT_K21(ARG)

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
	SETCOLOR カラー_黄
	;恋慕 or 服従
	IF (TALENT:恋慕 || TALENT:服従) && !(MASTER == NAME_TO_CHARA("紫"))
		PRINTFORMW 「っ！！　…………ほ、本気か？　%ANAME(MASTER)%……」
		PRINTFORML 
		PRINTFORMW こんな事、遊びでは口にしない。本気だと伝えると、%ANAME(TARGET)%は感極まった様子で%ANAME(MASTER)%を抱きしめた
		PRINTFORML 
		PRINTFORMW 「…嬉しいぞ、%ANAME(MASTER)%…お前からその言葉を聞けて…っ」
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%を強く抱きしめる%ANAME(TARGET)%の目には、うっすらと涙が浮かんでいた
		PRINTFORML 
		PRINTFORMW 「%ANAME(MASTER)%…、私もお前のことが、好きだ。…これからも私と一緒にいておくれ…♥」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は満面の笑みを見せ、%ANAME(MASTER)%の唇を激しく奪った…
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORMW 「…」
		PRINTFORML 
		PRINTFORMW 少しの静寂の後、%ANAME(TARGET)%は口を開く。その頬はやや赤くなっていた
		PRINTFORML 
		PRINTFORMW 「その気持ち、受け止めよう。…私もその…お前のことは、嫌いじゃ…ないぞ…」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%はそう言うと、%ANAME(MASTER)%を優しく抱きしめる
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%もまた%ANAME(TARGET)%の抱擁に応えて腕を背に回して抱き合い、やがて熱い口付けをかわした…
		PRINTFORML 
	ENDIF
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	SETCOLOR カラー_黄
	PRINTL
	PRINTFORML 「……すまない。気持ちは嬉しいが、今はまだそういう気持ちになれないんだ」
	PRINTFORMW %ANAME(TARGET)%はしばし悩んだ後、そう言った
	PRINTFORMW 「…もう少し%ANAME(MASTER)%のことを見極めさせてくれ。そうしたら、答えも変わってくるかもしれない…」
	PRINTFORML 
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL
	PRINTFORML 「あ、こ、こら…だめだってぇ……」
	PRINTFORMW %ANAME(TARGET)%は酔いが回って%ANAME(MASTER)%を拒みきれないようだ
	PRINTFORML
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「あっ……私を、抱きたいのか？」
		PRINTFORML 「…ふふっ、しょうがないやつだな%ANAME(MASTER)%は」
		PRINTFORMW %ANAME(TARGET)%は抵抗することなく、むしろ進んで%ANAME(MASTER)%に身体を委ねている
		PRINTFORML 「…本当はな、%ANAME(MASTER)%が抱いてくれるのを待っていたんだぞ…♥」
		PRINTFORMW %ANAME(TARGET)%は頬を染めて微笑みながら、%ANAME(MASTER)%の服にも手をかける
		PRINTFORMW 「さあ、私だけ裸なんて無い話だ。%ANAME(MASTER)%の裸も見せてくれ♥」
	;それ以外
	ELSE
		PRINTFORML 「あっ……ふう、そんなに私を抱きたのか？　まったく仕方ないな…」
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の目の前で服を脱いでゆく
		PRINTFORMW 「どうせするならちゃんと気持ちよくしてくれよ？」
	ENDIF
	PRINTFORML
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL
	PRINTFORML 「駄目だ」
	PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に腕をひねられ、投げ倒された
	PRINTFORMW 「……気持ちは察するが、もうちょっと自制しろ」
	PRINTFORML
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL
	;正妻
	IF TALENT:正妻
		SELECTCASE RAND:6
			CASE 0
				PRINTFORML 「あ…もう待ちきれないか？　ふふ、待たせてしまってごめんな」
				PRINTFORMW 「さあ、旦那様…私の身体でいっぱい気持ちよくしてあげるからな♥」
				PRINTFORMW 腰をくねらせながら、%ANAME(TARGET)%は妖艶に笑う
			CASE 1
				PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%に身体を摺り寄せながら服を脱いでいる、
				PRINTFORMW 「もう%ANAME(MASTER)%に触れていないと落ち着かない身体になってしまったよ…」
				PRINTFORMW 「ああ、愛しい旦那様…。今日も%ANAME(TARGET)%を、幸せにしてくださいな…♥」
			CASE 2
				PRINTFORML 「あっ♥……もう、そんなに私を抱きたいのか？　しょうがない旦那様だ♥」
				PRINTFORMW %ANAME(TARGET)%はそう言うと服を脱ぎ、蕩けた表情で%ANAME(MASTER)%に抱きついた
				PRINTFORML 「まぁ、そう言いつつ私も%ANAME(MASTER)%に抱かれたくてたまらないんだがな♥」
				PRINTFORMW 「さあ、%ANAME(MASTER)%…今夜は燃え上がろうか♥」
			CASE 3
				PRINTFORML 「あっ…もう我慢できないか？　ふふっ、私もだよ%ANAME(MASTER)%♥」
				PRINTFORMW %ANAME(TARGET)%は自ら服をはだけて、%ANAME(MASTER)%の身体に自慢の尻尾を絡めてきた
				PRINTFORMW 「愛しい旦那様…今日も%ANAME(TARGET)%が、いっぱい気持ちよくしてあげる♥」
			CASE 4
				PRINTFORML 「今回は私が脱がしてあげよう。さ、力を抜いてバンザイして…」
				PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の服を手を掛ける。脱がしに掛かる手つきが艶かしい
				PRINTFORML 「ふふ、もうビンビンだ……コレで今から私を愛してくれるんだな♥」
				PRINTFORML %ANAME(TARGET)%は蕩けた表情で%ANAME(MASTER)%の肉棒を手に取り撫でている…
				PRINTFORMW 「はぁ…愛しい旦那様のコレ…触ってるだけでも幸せだよ♥」
			CASE 5
				PRINTFORML 「あん♥…ふふ、そんなに焦らなくとも私は%ANAME(MASTER)%だけのものだよ…♥」
				PRINTFORMW %ANAME(TARGET)%が服を脱ぐたび、彼女の美しい肢体が露わになり%ANAME(MASTER)%の目を釘付けにする
				PRINTFORMW 「さぁ、旦那様…今夜も私を愛して♥」
		ENDSELECT 
	;親愛 or 隷属
	ELSEIF TALENT:親愛 || TALENT:隷属 || TALENT:所有者
		SELECTCASE RAND:6
			CASE 0
				PRINTFORML 「あ…もう待ちきれないか？」
				PRINTFORMW 「ふふ、待たせてしまってすまない。私の身体でいっぱい気持ちよくしてあげるからな♥」
				PRINTFORMW 腰をくねらせながら、%ANAME(TARGET)%は妖艶に笑う
			CASE 1
				PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%に身体を摺り寄せながら服を脱いでいる、
				PRINTFORMW 「もう%ANAME(MASTER)%に触れていないと落ち着かない身体になってしまったんだ」
				PRINTFORMW 「%ANAME(MASTER)%…。今日も私を、幸せにしておくれ…♥」
			CASE 2
				PRINTFORML %ANAME(TARGET)%は服を脱ぐと、蕩けた表情で%ANAME(MASTER)%に抱きついた
				PRINTFORMW 「%ANAME(MASTER)%に抱かれると、幸せを感じるんだ♥」
			CASE 3
				PRINTFORML 「あっ…もう我慢できないか？　ふふっ、私もなんだ♥」
				PRINTFORMW %ANAME(TARGET)%は自ら服をはだけて、%ANAME(MASTER)%の身体に自慢の尻尾を絡めてきた
				PRINTFORMW 「愛しい%ANAME(MASTER)%…今日もいっぱい、気持ちよくしてあげるからな♥」
			CASE 4
				PRINTFORML 「今回は私が脱がしてあげよう。さ、力を抜いてバンザイして…」
				PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の服を手を掛ける。脱がしに掛かる手つきが艶かしい
				PRINTFORML 「ふふ、もうビンビンだ……これで今から私を愛してくれるんだな♥」
				PRINTFORMW %ANAME(TARGET)%は蕩けた表情で%ANAME(MASTER)%の肉棒に頬ずりしている…
			CASE 5
				PRINTFORML 「あん…ふふ、そんなに焦らなくとも私は%ANAME(MASTER)%のモノだよ…♥」
				PRINTFORMW %ANAME(TARGET)%が服を脱ぐたび、彼女の美しい肢体が露わになり%ANAME(MASTER)%の目を釘付けにする
				PRINTFORMW 「さぁ、%ANAME(MASTER)%…私を愛して♥」
		ENDSELECT
	;恋慕 or 服従
	ELSEIF TALENT:恋慕 || TALENT:服従 || TALENT:親友 || TALENT:主人
		SELECTCASE RAND:6
			CASE 0
				PRINTFORML 「ん…もう待ちきれないか？」
				PRINTFORMW 「ふふ、いいぞ…私の身体、存分に味わってくれ♥」
				PRINTFORMW 腰をくねらせながら、%ANAME(TARGET)%は妖艶に笑う
			CASE 1
				PRINTFORML %ANAME(TARGET)%は服を脱ぐと、%ANAME(MASTER)%に抱きつく
				PRINTFORMW 「%ANAME(MASTER)%に抱かれると、安心できて好きなんだ…」
				PRINTFORMW 「今日も私を愛しておくれ…」
```
