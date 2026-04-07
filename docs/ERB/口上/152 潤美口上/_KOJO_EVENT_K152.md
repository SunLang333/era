# 口上/152 潤美口上/_KOJO_EVENT_K152.ERB — 自动生成文档

源文件: `ERB/口上/152 潤美口上/_KOJO_EVENT_K152.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K152; UI/print

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
@KOJO_EVENT_K152(ARG)


;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	SETCOLOR 0x4d3d3d
	PRINTL 
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「……ほ、本気なのかい？　%ANAME(MASTER)%。その言葉……」
		PRINTFORML 
		PRINTFORMW 愛の告白をした%ANAME(MASTER)%を、%ANAME(TARGET)%は困惑四割、嬉しさ六割といった表情で受け止めた
		PRINTFORML 
		PRINTFORMW 「…嬉しい。嬉しいよ、%ANAME(MASTER)%。お前さんから、そう言ってくれるなんて…」
		PRINTFORML 
		PRINTFORMW そして%ANAME(MASTER)%を優しく抱きしめる。%ANAME(MASTER)%もまた、彼女を抱きしめ返す。その顔からは、もう困惑の色は無かった
		PRINTFORML 
		PRINTFORMW 「…正直、怖かったんだ…。もし私から付き合ってくれ、なんて言って拒絶されたらどうしよう、って……」
		PRINTFORML 
		PRINTFORMW 「それが取り越し苦労でよかった…。%ANAME(MASTER)%、私も…お前が大好きだよ…♥」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は慈しみの笑みを浮かべ、%ANAME(MASTER)%の唇を優しく塞いだ…
	;それ以外
	ELSE
		PRINTFORML 
		PRINTFORMW 「……本気なのかい？　その言葉……」
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%の告白を受け、しばしの逡巡の後、%ANAME(TARGET)%は答えた
		PRINTFORML 
		PRINTFORMW 「その気持ちが本物かどうか、これからの行動で見極めてやるとしよう。…まあその、…ＯＫってことだ…」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%はそう言うと、%ANAME(MASTER)%を優しく抱きしめる。その顔は仄かに朱を帯びていた
		PRINTFORML 
		PRINTFORMW 「…私もこういうこと、そんなに経験無いから……%ANAME(MASTER)%もよろしく頼むぞ？」
	ENDIF
	PRINTL 
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTL
	PRINTFORMW 「…ごめんな。今はそういう気分になれないんだ。……気持ちは嬉しいけどね」
	PRINTL
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL
	PRINTFORML 「んふふふふ…♪　……さあ%ANAME(MASTER)%、この後どうするんだい？　ふふ…♥」
	PRINTFORMW 酔っ払っている%ANAME(TARGET)%に抵抗する様子は無く、むしろ挑発するような瞳で%ANAME(MASTER)%を見つめている
	PRINTL
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「おわっと、………さあ%ANAME(MASTER)%、この後どうするんだい？　ふふ…♥」
		PRINTFORMW 押し倒された%ANAME(TARGET)%に抵抗する様子は無く、むしろその先を期待するような瞳で%ANAME(MASTER)%を見つめている
		PRINTL
		PRINTFORML 「………いいよ、ほら、おいで…♥」
		PRINTFORMW そして%ANAME(TARGET)%は嬉しそうに微笑み、%ANAME(MASTER)%を受け入れるように抱き寄せた
	;それ以外
	ELSE
		PRINTFORML 「おわっ！　……お前さん、本気なのかい？　…はあ、まったく助平なんだから……」
		PRINTFORMW %ANAME(TARGET)%は牛鬼である自分すら抱こうとする%ANAME(MASTER)%を、半ば呆れた様子で受け入れた…
	ENDIF
	PRINTL
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL
	PRINTFORMW 「おっと、そういう関係にはまだ早い。出直して来な」
	PRINTL
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL
	;親愛か隷属
	IF TALENT:親愛 || TALENT:隷属
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「あんっ、もう我慢できないのかい？　ふふ、いいよ♥　私も丁度そういう気分だったところさ♥」
				PRINTFORML %ANAME(TARGET)%は押し倒してきた%ANAME(MASTER)%を抱き寄せ、その豊満な肉体にむにゅむにゅと押し付ける
				PRINTFORMW 「一日の締めくくりだからね。たっぷりと愛してもらうよ、ア・ナ・タ♥」
			CASE 1
				PRINTFORML 「あんっ、もう、乱暴にしてくれちゃって…、まあ、そういうのも嫌いじゃないけどさ♥」
				PRINTFORMW 押し倒された%ANAME(TARGET)%はその豊かな乳房をゆさゆさ揺らしながら服を脱ぎ、%ANAME(MASTER)%の目を喜ばせる
				PRINTFORMW 「さあ、%ANAME(MASTER)%♥　今日もたっぷり、激しく愛しておくれ♥」
			CASE 2
				PRINTFORML 「おわっと、…くすっ♪　そんなに焦らなくても私は逃げないよ、%ANAME(MASTER)%…♥」
				PRINTFORML 押し倒された%ANAME(TARGET)%は%ANAME(MASTER)%を受け入れるように抱きしめ、肉の柔らかさを伝えてくる…
				PRINTFORMW 「ふふ、その硬くなったモノで、いっぱい私を鳴かせておくれ♥」
		ENDSELECT
	;恋慕か服従
	ELSEIF TALENT:恋慕 || TALENT:服従
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「おっと、……ふふ、どうやら私と一緒の夜を過ごしたいようだな♥」
				PRINTFORMW 「くすっ、いいぞ。お前さんとならな…さあ、おいで♥」
			CASE 1
				PRINTFORML 「あっと、…もう我慢できないか？　ふふっ、実は私もだ♥」
				PRINTFORMW %ANAME(TARGET)%は自ら服をはだけて、押し倒してきた%ANAME(MASTER)%の身体を受け入れる
				PRINTFORMW 「今日もいっぱい、キモチいいことしような…♥」
			CASE 2
				PRINTFORML 「おわっと、…これはどういうつもりだい？　%ANAME(MASTER)%よ。ふふふ…♥」
				PRINTFORML 押し倒された%ANAME(TARGET)%は%ANAME(MASTER)%を挑発するように笑みを浮かべている
				PRINTFORMW 「ほらほら、察しの悪い私にちゃんと教えておくれ、…くすっ♥」
		ENDSELECT
	;それ以外
	ELSE
		SELECTCASE RAND:2
			CASE 0
				PRINTFORMW 「おっと、…何だ？　そんなに私が欲しいのか？」
			CASE 1
				PRINTFORMW 「おわっ、わ、私を抱くのか？　まったく怖いもの知らずだなお前は…」
		ENDSELECT
	ENDIF
	PRINTL
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	PRINTFORMW 「きゅぅ………」
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

;-------------------------------------------------
;哀しみの限界で追い返される
;-------------------------------------------------
IF ARG == 14
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;怒りの限界で勝手に帰る
;-------------------------------------------------
IF ARG == 15
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;哀しみの限界で勝手に帰る
;-------------------------------------------------
IF ARG == 16
	;PRINTFORMW 
	RETURN 0
ENDIF

```
