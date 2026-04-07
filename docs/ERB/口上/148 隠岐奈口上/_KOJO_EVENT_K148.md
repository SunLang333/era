# 口上/148 隠岐奈口上/_KOJO_EVENT_K148.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/_KOJO_EVENT_K148.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K148; UI/print

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
@KOJO_EVENT_K148(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「ちゅ……っ」
		PRINTFORML そっと%ANAME(MASTER)%が顔を離すと、耳まで真っ赤になりつつも微笑む隠岐奈が目に入った。
		PRINTFORML 「その…キスは初めてで……」
		PRINTFORMW 「%ANAME(MASTER)%とすることができて、少し嬉しいんだ…ははは」
	;恋人
	ELSEIF TALENT:恋人
		PRINTFORML 「ちゅ……っ」
		PRINTFORML そっと%ANAME(MASTER)%が顔を離すと、耳まで真っ赤になった隠岐奈が目に入った。
		PRINTFORML 「その…キスは初めてで……」
		PRINTFORMW 「ま、まあ…どこぞの馬の骨とするより、恋人とできたのは幸いだが…うぅ、恥ずかしい…」
	;それ以外
	ELSE
		PRINTFORML 「ちゅ……っ」
		PRINTFORML %ANAME(MASTER)%が顔を離すと、困ったような笑みを浮かべる隠岐奈が目に入った。
		PRINTFORML 「ははは……いや、実はこれが私のファーストキスだったんだ」
		PRINTFORMW 「全く、貞操などあっけないものだな、知ってはいたが」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 
		PRINTFORML 「…念のため、理由を聞いておこうか」
		PRINTFORML 「身の程知らずが、この摩多羅神に惚れたという…その理由を」
		PRINTFORMW 隠岐奈は試すように%ANAME(MASTER)%の顔を覗き込んで、じっと見つめている…。
		PRINTFORML 
		PRINTFORML しばしの沈黙の後、%ANAME(MASTER)%はおずおずと口を開く。
		PRINTFORMW すると隠岐奈は目を丸くして、その言葉を反芻した。
		PRINTFORMW 「……"秘神である以前にひとりの少女だ" だと？」
		PRINTFORMW 「……………」
		PRINTFORMW 「は、はははははッ！気に入ったぞ、%ANAME(MASTER)%！」
		PRINTFORML 「未だかつて、そしてこれからも、この私にそんな世迷い言を抜かす者はいなかろうよ！」
		PRINTFORMW 隠岐奈は金色の瞳を細めながら、心底愉快そうに笑った。
		PRINTFORML 「その厚顔無恥さ……実に面白い。よかろう、しばらくはお前に付き合ってやる」
		PRINTFORMW 「"ひとりの少女"として…な。ふっふっふ…」
		PRINTFORML 
		PRINTFORML ………………………
		PRINTFORMW ………………
		PRINTFORML 
		PRINTFORML （ようやく……ようやく、%ANAME(MASTER)%が私のものに……！！）
		PRINTFORMW （まさか向こうから告白してくるとは思ってなかったけど！）
		PRINTFORML （"しばらくは付き合ってやる"なんて言ったけど、一生離すものか！）
		PRINTFORMW （あいつが死ぬまで…いや、死んでも…ずっと一緒に私と……ふふっ、ふふふふふふっ♥）
		PRINTFORMW 隠岐奈は心の中でガッツポーズを決め、これからの訪れるであろう多くの楽しみに想いを馳せた……。
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORML 
		PRINTFORML 「…念のため、理由を聞いておこうか」
		PRINTFORML 「身の程知らずが、この摩多羅神に惚れたという…その理由を」
		PRINTFORMW 隠岐奈は試すように%ANAME(MASTER)%の顔を覗き込んで、じっと見つめている…。
		PRINTFORML 
		PRINTFORML しばしの沈黙の後、%ANAME(MASTER)%はおずおずと口を開く。
		PRINTFORMW すると隠岐奈は目を丸くして、その言葉を反芻した。
		PRINTFORMW 「……"秘神である以前にひとりの少女だ" だと？」
		PRINTFORMW 「……………」
		PRINTFORMW 「は、はははははッ！気に入ったぞ、%ANAME(MASTER)%！」
		PRINTFORML 「未だかつて、そしてこれからも、この私にそんな世迷い言を抜かす者はいなかろうよ！」
		PRINTFORMW 隠岐奈は金色の瞳を細めながら、心底愉快そうに笑った。
		PRINTFORML 「その厚顔無恥さ……実に面白い。よかろう、しばらくはお前に付き合ってやる」
		PRINTFORMW 「"ひとりの少女"として…な。ふっふっふ」
		PRINTFORML 
	ENDIF
	RETURN 1
ENDIF
;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「お前の気持ちは嬉しいが……」
		PRINTFORMW 「…………駄目だ、やっぱり」
		PRINTFORMW 「私は神様だから、お前ひとりだけを見るわけにはいかないんだよ……」
		PRINTFORMW 隠岐奈は切なげな表情を浮かべながら、%ANAME(MASTER)%の告白を断った。
	;それ以外
	ELSE
		PRINTFORMW 「ふぅぅ……聞かなかったことにしておいてやる」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTFORML 「んぁぁ…何だ……？」
	PRINTFORMW 隠岐奈はぽやんとした顔で%ANAME(MASTER)%を見つめている……。
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「%ANAME(MASTER)%…？」
		PRINTFORML 「も、もしかして、したいのか…？」
		PRINTFORML 隠岐奈は目を見開いて赤面し、珍しく動揺を隠さずにいる。
		PRINTFORMW %ANAME(MASTER)%が息を荒げながら頷くと、彼女は耳まで真っ赤になって顔を背けてしまった。
		PRINTFORML 
		PRINTFORML 「別に私は……%ANAME(MASTER)%が相手なら、嫌ではないが…」
		PRINTFORML 「む、むしろ……貴方に抱いて欲しかったというか……」
		PRINTFORML 「その…………」
		PRINTFORMW 「ああ、もう！私は何を言っているんだ！いいから抱け、%ANAME(MASTER)%！」
	;それ以外
	ELSE
		PRINTFORML 「ふふっ、そんなに息を荒げてどうした？」
		PRINTFORML 「私に欲情してしまったのか？ まったく、度し難い奴め」
		PRINTFORMW 「だが……良いだろう、お前の求めに応えてやる」
		PRINTFORML 
		PRINTFORML 「さあ、おいで…%ANAME(MASTER)%……」
		PRINTFORMW 隠岐奈は淫靡な笑みを浮かべて、%ANAME(MASTER)%を受け入れた……。
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTFORML 抱き寄せようとした途端、隠岐奈にぎろりと睨まれた……。
	PRINTFORMW %ANAME(MASTER)%が手を引っ込めると、それでいい、と隠岐奈は頷いた。
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	;妊娠
	IF TALENT:妊娠
		IF RAND:3 == 0
			PRINTFORML 「私のお腹を見ても、したいと思うのか…？」
			PRINTFORML 「負担をかけないようにしてくれるのなら構わないが……」
			PRINTFORMW 隠岐奈は不安そうにお腹を撫でた……
		ELSEIF RAND:2 == 0
			PRINTFORML 「妊娠中はあまり無理はしたくないんだが…」
			PRINTFORML 「優しく抱くから……って、そういう問題じゃ……」
			PRINTFORMW 「…ああもう、分かった分かった！絶対に乱暴なことはするんじゃないぞ？いいな！」
		ELSE
			PRINTFORML 「今はこれ以上抱いても子供はできんぞ？」
			PRINTFORML 「それに、お腹の子が驚いてしまうだろうし……」
			PRINTFORMW 「……そ、そんな顔をするんじゃない！ああもう、仕方ないな！ちょっとだけだぞ！」
		ENDIF
	;正妻 or 妾
	ELSEIF TALENT:正妻 || TALENT:妾
		IF RAND:4 == 0
			PRINTFORML 「ふふっ、するのか？」
			PRINTFORMW 「それでは、いっぱい愛してもらおうか…」
		ELSEIF RAND:3 == 0
			PRINTFORML 「したくなっちゃったのか？」
			PRINTFORMW 「ふふっ、それじゃあ……子作りしようか、%ANAME(MASTER)%♥」
		ELSEIF RAND:2 == 0
			PRINTFORML 「ああ……私を抱いてくれるのか？」
			PRINTFORML 「ありがとう、%ANAME(MASTER)%……愛してる…♥」
		ELSE
			PRINTFORML 「ふふふっ、おいで、%ANAME(MASTER)%……♥」
			PRINTFORMW 隠岐奈は嬉しそうに微笑んで、%ANAME(MASTER)%を受け入れた……
		ENDIF
	;隷属
	ELSEIF TALENT:隷属
		IF RAND:3 == 0
			PRINTFORML 「あ……%ANAME(MASTER)%…」
			PRINTFORMW 「愛してくれるのか？ そうか、嬉しいよ…♥」
		ELSEIF RAND:2 == 0
			PRINTFORML 「貴方の気が済むまで抱いて、滅茶苦茶にしてくれ……♥」
			PRINTFORMW 隠岐奈はもうすでに発情しきっているようだ。
		ELSE
			PRINTFORML 「ああ、%ANAME(MASTER)%…♥ 私を使ってくれるんだな？ ふふふふっ♥♥」
			PRINTFORMW 隠岐奈は心の底から幸せそうに微笑んでいる…。
		ENDIF
	;恋慕
	ELSEIF TALENT:恋慕
		IF RAND:3 == 0
			PRINTFORML 「ふふっ！元気だなぁ、お前は」
			PRINTFORMW 「仕方ないから、付き合ってあげよう。感謝するんだぞ？」
```
