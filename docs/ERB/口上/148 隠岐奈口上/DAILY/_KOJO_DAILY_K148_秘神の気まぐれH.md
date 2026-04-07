# 口上/148 隠岐奈口上/DAILY/_KOJO_DAILY_K148_秘神の気まぐれH.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/DAILY/_KOJO_DAILY_K148_秘神の気まぐれH.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K148_NIGHTEVENTH_RATE, KOJO_DAILY_K148_NIGHTEVENTH_DECISION, KOJO_DAILY_K148_NIGHTEVENTH_GENRE, KOJO_DAILY_K148_NIGHTEVENTH; UI/print

前 200 行源码片段:

```text
﻿

;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K148_NIGHTEVENTH_RATE(対象)
#DIM 対象
RETURN 50


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K148_NIGHTEVENTH_DECISION(対象)
#DIM 対象

;隠岐奈と面識があり、所属がおなじ、合意あり
SIF !TALENT:対象:合意

RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K148_NIGHTEVENTH_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K148_NIGHTEVENTH(対象)
#DIM 対象

IF HAS_PENIS(対象) && HAS_PENIS(MASTER)
  COUNT = RAND:2

 ELSEIF HAS_PENIS(MASTER)
  COUNT = 0
  
 ELSEIF HAS_PENIS(対象)
  COUNT = 1
  
 ELSE
  COUNT = 2 
  
ENDIF 

IF COUNT == 0
	;主人公がこのキャラのＶに挿入
	IF RAND:2 == 0
		;恋慕 or 服従
		IF TALENT:対象:恋慕 || TALENT:対象:服従
			PRINTFORML %ANAME(MASTER)%が寝る準備をしていると、突然背後から誰かに抱き着かれた。
			PRINTFORMW ……隠岐奈だ。
			PRINTFORML 「ふふっ♪ %ANAME(MASTER)%、今晩は一緒にどうかな？」
			PRINTFORML もうすでに呼吸を乱している隠岐奈は自身の火照った肢体を摺り寄せてくる…。
			PRINTFORMW よく見ると、彼女はネグリジェの下に何も身につけていなかった。
			PRINTFORML 
		;――――――――――――――――――――――――――――――――――――――――
			IF !RAND:2 
				PRINTFORML 妖しげな笑みを浮かべた隠岐奈は、%ANAME(MASTER)%の下着を脱がせ、しこしことペニスを愛撫し始めた。
				PRINTFORMW 彼女の細い指で優しく刺激されて、%ANAME(MASTER)%の肉棒はあっという間に勃起してしまう。
				PRINTFORML 「ふふっ♥ もしかしてお前も結構溜まっていたのか？」
				PRINTFORMW 「こんなに大きく、硬くして……楽しみがいがありそうだ♥」
				PRINTFORML 
			ELSE
				PRINTFORML 隠岐奈は%ANAME(MASTER)%の股座に顔を埋めると、まだ柔らかなペニスを口で愛撫し始めた。
				PRINTFORML 「んっ…ちゅ…っ♥ あむ、れろ、じゅるる…っ♥」
				PRINTFORMW 温かな口内と舌のざらざらとした感触で、%ANAME(MASTER)%の肉棒はあっという間に勃起してしまった。
				PRINTFORML 
				PRINTFORMW 「ぷはぁっ♥ ん、これならもう、大丈夫そうだな…」
			ENDIF
		;――――――――――――――――――――――――――――――――――――――――
			IF RAND:4 == 0
				PRINTFORML 隠岐奈は微笑むと、前戯もそこそこに%ANAME(MASTER)%の血管を浮かせる怒張に跨ってきた…。
				PRINTFORML 「はぁぁぁ…～～っっ♥」
				PRINTFORMW 挿入の悦びに大きく息を吐くと、彼女は自身の体を見せつけるようにして上下に動き始めた。
				PRINTFORML 
				PRINTFORML 「あぁっ…あっ、はあっ、あぁんっ♥」
				PRINTFORML 「はあぁっ♥ やっぱりひとりでするよりっ、気持ちいいぃ…っ♥」
				PRINTFORML ぎしぎしとベッドを軋ませながら、隠岐奈は恍惚とした表情で%ANAME(MASTER)%のペニスを扱き上げる。
				PRINTFORML %ANAME(MASTER)%も腰を振り始めると、隠岐奈は快楽に染まった目を細めて笑った。
				PRINTFORMW 「あはッ♥ 上手じゃないか、%ANAME(MASTER)%っ♥」
				PRINTFORML 
				PRINTFORML 「はあっ、はあっ♥ このまま私の中に出させてやるっ♥」
				PRINTFORML 隠岐奈はパンッパンッと音を立てながら、大きく腰を振るって%ANAME(MASTER)%の精子を搾り取りにかかる。
				PRINTFORMW 「ほらっ、イけっ♥ 射精してしまえッ♥♥」
				PRINTFORML そんな風に激しく責められては、もう我慢などできない。
				PRINTFORML %ANAME(MASTER)%は呆気なく果て、隠岐奈の子宮に濃厚な精液をぶちまけた。
				PRINTFORML 「あああっ♥ きたっ、中でびくびくしてっ♥ ～～～っっ♥♥」
				PRINTFORMW 隠岐奈は膣奥に吐き出された精液の感触に、背中を弓なりに反らせて絶頂した。
			ELSEIF RAND:3 == 0
				PRINTFORMW そう言うと、隠岐奈はそそり立つ%ANAME(MASTER)%のペニスに腰を下ろしていった…。
				PRINTFORML 「はぁぁ……っ♥ ああ、%ANAME(MASTER)%、抱きしめてくれないか？」
				PRINTFORMW 「そうしてくれると安心するから……♥」
				PRINTFORML %ANAME(MASTER)%は彼女の望み通りに抱擁し、できる限り密着した状態で腰を動かす。
				PRINTFORMW 「ああっ、そう、いい……♥ んっ、ううぅ…っ♥」
				PRINTFORML
				PRINTFORML さらに深く繋がりたくなったのか、隠岐奈は%ANAME(MASTER)%の唇を奪い、自身も腰を振り始めた…。
				PRINTFORML 「んんんっ♥ んむっ、ちゅ、ぅぅ…っ♥♥」
				PRINTFORML 「くぅ、ん、むうぅっ♥ ふっ、ぅん、ちゅっ…♥ ぷはぁっ♥」
				PRINTFORML 隠岐奈の膣壁はきゅんきゅんと%ANAME(MASTER)%のペニスを締め付け、ひたすら卑猥に舐めしゃぶる。
				PRINTFORMW その快楽に堪らなくなった%ANAME(MASTER)%は、射精に向けていよいよ激しく腰を振り始めた。
				PRINTFORML 
				PRINTFORML 「ああっ、%ANAME(MASTER)%っ♥♥ %ANAME(MASTER)%っ、きもちいいよぉっ♥♥」
				PRINTFORML 「だめぇっ♥♥ すきっ♥ あなたのこと、好きすぎておかしくなっちゃうぅ…っ♥♥」
				PRINTFORMW %ANAME(MASTER)%は隠岐奈に激しく求められる幸福感を覚えながら、ついに彼女の膣内に射精した。
				PRINTFORML 「ああ…っ♥ はあ、ぁ……%ANAME(MASTER)%の精液…きてるぅ……♥」
				PRINTFORMW 隠岐奈は恍惚とした表情で、膣内に吐き出された%ANAME(MASTER)%の子種を受け入れている。
			ELSEIF RAND:2 == 0
				PRINTFORML 「%ANAME(MASTER)%、入れてくれ……♥」
				PRINTFORML %ANAME(対象)%は脚を開いて自身の濡れそぼった秘所を晒し、正面から%ANAME(MASTER)%を誘う。
				PRINTFORMW %ANAME(MASTER)%はそんな彼女に覆い被さって、ゆっくりと腰を沈めていった…。
				PRINTFORML 「あ、あぁぁぁ……っ！♥♥」
				PRINTFORML 挿入しただけでも%ANAME(対象)%は背を反らして、大げさなほどにびくびくと震える。
				PRINTFORMW 締め付けてくる膣壁をかき分けながら、%ANAME(MASTER)%は奥深くまでペニスをねじ込んだ。
				PRINTFORML
				PRINTFORML 「はあぁ…奥にきてるぅ……あんっ♥♥ %ANAME(MASTER)%…っ♥」
				PRINTFORMW ぬちゃぬちゃと音を立てながら腰を動かすと、%ANAME(対象)%は体をくねらせてよがる。
				PRINTFORML 「あっ♥ あっ♥ いいよぉっ、%ANAME(MASTER)%っっ♥♥」
				PRINTFORML 「やめないでぇっ♥ そのまま達してっ、%ANAME(MASTER)%～～っ♥♥」
				PRINTFORML 隠岐奈は最奥での種付けを求め、%ANAME(MASTER)%の腰に自身の脚を絡みつける。
				PRINTFORMW %ANAME(MASTER)%も前に思い切り体重をかけ、隠岐奈にのしかかるような形で腰を振り続けた…。
				PRINTFORML 
				PRINTFORML 「あああッ♥♥ だめぇっ、いくっ、いぐうぅっ♥♥ ひっ、あああぁ～～～ッッ♥♥♥」
				PRINTFORML 隠岐奈の絶頂の瞬間、%ANAME(MASTER)%も一気に肉棒を突き入れ、彼女の奥底で射精した。
				PRINTFORML 「ああっ、あぁ……あなたの…きてるぅ……♥」
				PRINTFORMW 子宮にたっぷりと精液を注がれ、%ANAME(対象)%は女としての幸せを感じているようだ。
				PRINTFORMW %ANAME(MASTER)%はぎゅっと%ANAME(対象)%を抱きしめ、絶頂の余韻に浸った。
			ELSE
				PRINTFORML 「%ANAME(MASTER)%…今日は、後ろから……♥」
				PRINTFORML 隠岐奈は四つん這いになり、グチョグチョに濡れ切った秘所を晒す。
				PRINTFORMW 細い%ANAME(対象)%の腰を掴んで、%ANAME(MASTER)%はゆっくりとペニスを挿入していった。
				PRINTFORML
				PRINTFORML 「はぁぁぁ………っ♥♥」
				PRINTFORML 「あっ♥ ああっ♥ きもちいぃ…っっ♥♥」
				PRINTFORMW %ANAME(MASTER)%が腰を振り始めると、一突きするたびに厭らしい水音が響いた。
				PRINTFORML やがて隠岐奈は自身の秘所に手を伸ばし、%ANAME(MASTER)%に犯されながらクリトリスを弄り始めた。
				PRINTFORML 「んんんっ♥ ああっ、はあぁっ、あっ、%ANAME(MASTER)%っ♥♥」
				PRINTFORMW 「さっきまで、ひとりでしてたのっ♥♥ あっ、あなたのこと考えながらぁっ♥♥」
				PRINTFORMW それを聞いた%ANAME(MASTER)%は、いよいよ興奮して腰を強く打ち付けた。
				PRINTFORML 「きゃああっ！？♥ やっ、はげしっ…あああぁぁッ♥♥♥」」
				PRINTFORML 「すきっ、すきぃっ♥♥ %ANAME(MASTER)%っ、きもちいいよおぉっっ♥♥♥」
				PRINTFORMW 普段の様子からは想像もできないほどに乱れながら、隠岐奈はセックスの快楽に悶えている。
				PRINTFORML
				PRINTFORML 獣のような交尾の果てに、%ANAME(MASTER)%は彼女の最奥にどっぷりと精液を注ぎ込んだ。
				PRINTFORML 「ああっ♥ はぁっ、はぁぁっ……お腹の中…あついぃ……♥」
				PRINTFORMW 隠岐奈は体を震わせながら、子宮内に広がる精液の感触を味わっている…。
			ENDIF 
		;――――――――――――――――――――――――――――――――――――――――
				PRINTFORML
				PRINTFORML しばらくして%ANAME(MASTER)%がペニスを引き抜くと、%ANAME(対象)%の秘所からどろりと精液が漏れ出した。
				PRINTFORMW 「んっ……♥ あはは、すごく濃いじゃないか…」
				PRINTFORML 
				PRINTFORML 「%ANAME(MASTER)%の、べとべとになってしまっているな…綺麗にしないと」
				PRINTFORMW そう言うと、%ANAME(対象)%は%ANAME(MASTER)%の肉棒を頬張り、じっくりと汚れを舐めとり始めた。
				PRINTFORML 「ん、ぐ……じゅぷ、ぐぽっ…」
				PRINTFORML 萎えて柔らかくなったソレを、舌で優しく愛撫し、付いた精液と愛液を拭う。
				PRINTFORML 愛おしそうに目を細めて、%ANAME(対象)%はそっと亀頭に唇を寄せる。
				PRINTFORML 「ちゅ、じゅるるっ……んくっ、ちゅぅぅっ……♥」
				PRINTFORML 尿道に残った精液まで吸い取ると、%ANAME(対象)%は満足気に%ANAME(MASTER)%の股間から顔を離す。
				PRINTFORMW 「ぷはぁっ…！ ふふっ、こんなもので良いだろう」
				PRINTFORML
				PRINTFORML しかし、丹念に舐めしゃぶられた%ANAME(MASTER)%のペニスは、再び元気を取り戻してしまっていた。
				PRINTFORML 「%ANAME(MASTER)%、まだまだこれからって感じだな？」
				PRINTFORMW 「それでは、二回戦目といこうか…♥」
				PRINTFORML ……………
				PRINTFORMW …………………
		;――――――――――――――――――――――――――――――――――――――――
				PRINTFORML %ANAME(MASTER)%が目覚めると、外はもうすっかり朝になっていた。
				PRINTFORMW 昨夜の疲労感は未だ残っているが、どちらかと言えば寝起きの爽快感の方が強い。
			IF RAND:4 == 0
				PRINTFORML 「ふぁああぁ………んん…」
				PRINTFORMW まだ眠たげな隠岐奈を横目に見ながら、%ANAME(MASTER)%は身支度を始めた。
				PRINTFORML …………。
				PRINTFORMW …%ANAME(MASTER)%が支度を終えても、隠岐奈がベッドから出てくる様子はない。
				PRINTFORML 「朝は弱いんだ…お前は先に行ってていいから……」
				PRINTFORMW そうはいかない、と%ANAME(MASTER)%が隠岐奈を引っ張り出すと、彼女は不機嫌そうに唸った。
				PRINTFORMW ……が、その唇に軽くキスしてやると、隠岐奈はあっという間に機嫌を直して微笑んだ。
			ELSEIF RAND:3
				PRINTFORML 隣にいた隠岐奈を起こそうと揺すると、彼女は目を閉じたまま気だるげに口を開いた。
				PRINTFORML 「私はもう少し寝るから……」
				PRINTFORML そうはいかない、と%ANAME(MASTER)%が隠岐奈を引っ張り出すと、彼女は不機嫌そうに唸った。
				PRINTFORMW ……が、その唇に軽くキスしてやると、隠岐奈はびくりと体を跳ねさせた。
				PRINTFORML 「し、仕方ないな……」
				PRINTFORMW 隠岐奈は頬を染めて、朝の身支度に取り掛かり始めた。
			ELSEIF RAND:2
				PRINTFORML 「……おはよう、%ANAME(MASTER)%…」
				PRINTFORMW まだ眠たげな隠岐奈の傍らで、%ANAME(MASTER)%は身支度を始めた。
				PRINTFORML
				PRINTFORML 「…%ANAME(MASTER)%、ちょっといいか」
```
