# 口上/158 影華扇口上/KOJO_A_K158.ERB — 自动生成文档

源文件: `ERB/口上/158 影華扇口上/KOJO_A_K158.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K158, KOJO_TRAIN_END_A1_K158, KOJO_TRAIN_START_A2_K158, KOJO_TRAIN_END_A2_K158, KOJO_COM_BEFORE_TARGET_A_K158, KOJO_COM_BEFORE_PLAYER_A_K158, KOJO_COM_A_K158, KOJO_COM_TARGET_A_K158, KOJO_COM_PLAYER_A_K158, KOJO_COM_AFTER_A_K158, SEX_VOICEK158_00, SEX_VOICEK158_01, SEX_VOICEK158_02, SEX_VOICEK158_03, SEX_VOICEK158_04, SEX_VOICEK158_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K158
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF
PRINTL

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	PRINTL
	;初対面の場合
	IF !CFLAG:17
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORMW 「……私に何の用だ」
			PRINTFORML 捕虜用の部屋を訪れた%ANAME(MASTER)%を、眼光鋭い美女が睨みつける
			PRINTL
			PRINTFORML 寒色系を基調とした服装に際立つ桃色の髪と大きな胸、そして
			PRINTFORMW すらりと延びた脚を包むタイツのシルエットが、全身メリハリの利いた肉付きであることを証明している
			PRINTFORMW しかしそんな美女そのものな印象を塗り潰す、頭部の大きな角と足の鎖。そして隠す気も無い危険なオーラ…
			PRINTFORML 
			SETCOLOR 0xF7819F
			PRINTFORML 
			PRINTFORML ―――――　断善修悪の怪腕　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR 
			PRINTFORML 「お前がここの責任者か？　ならば話は早い…」
			PRINTFORMW そう言うが早いか、彼女は一瞬で%ANAME(MASTER)%との間合いを詰め、その首を捻り上げる
			PRINTFORMW あまりにも躊躇ない行動に、%ANAME(MASTER)%は完全に気勢を制されてしまった
			PRINTL
			PRINTFORML 「雑魚兵士は食い飽きたところだ。ちょっとはマシな奴が釣れて大人しくした甲斐があった。それでは一思いに……ん？」
			PRINTFORMW 彼女は残虐な笑みを湛えて、%ANAME(MASTER)%の首を掴む手に力を入れようと……したところでその手を止めた
			PRINTL
			PRINTFORML 「お前、いやに変わった『匂い』がするな」
			PRINTFORML さっきまで残虐な笑みを湛えていた顔は、とたんに年若い少女の如く眉根を寄せ、困惑したような表情に変わった
			PRINTFORMW （何だこれは…。美味そうな、それでいて臭いような、でも癖になりそうな……こんな「匂い」を持つ奴は初めてだな…）
			PRINTL
			PRINTFORML 「……ふっ、興味深いな」
			PRINTFORMW %ANAME(TARGET)%がさっきまで纏っていた殺気を消し、%ANAME(MASTER)%の首を掴んでいた手を離す
			PRINTFORML 「まあいい。今は腹も減ってないし、己の肉体を得ることが出来て上機嫌だ。ここで喰い殺すのは止めてやろう」
			PRINTFORMW 痛みと苦しみから解放され、%ANAME(MASTER)%はゴホゴホと咳き込む。どうやら彼女が気変わりしたことで助かったようだ
			PRINTL
			PRINTFORMW 「それよりも私はお前のことに興味が湧いた。しばらくここでお前を観察させてもらうぞ」
			PRINTFORML 「なに、安心しろ。その間は殺さないさ。私をガッカリさせなければ、な。くっくっくっ…」
			PRINTFORMW 嗜虐に満ちた目が嬉しそうに細まる。どうやら大変な存在に目を付けられたようだ……
			PRINTFORMW 「私のことは……そうだな、「%ANAME(TARGET)%」とでも呼ぶがいい。ではお前のことを色々教えてもらうぞ」
		;それ以外
		ELSE
			PRINTFORMW 「おい。そこのお前」
			PRINTFORML 誰かに呼び止められ、%ANAME(MASTER)%は声の方向へ振り向いた
			PRINTFORMW そこにいたのは、……一言で言えば、「危険な雰囲気の美女」だった
			PRINTL
			PRINTFORML 寒色系を基調とした服装に際立つ桃色の髪と大きな胸、そして
			PRINTFORMW すらりと延びた脚を包むタイツのシルエットが、全身メリハリの利いた肉付きであることを証明している
			PRINTFORML しかしそんな美女そのものな印象を塗り潰す、頭部の大きな角と足の鎖。それらを従えるが如く眼光鋭い切れ長の目…
			PRINTFORMW 「…やはりお前にも、私の右腕以外の姿が見えているようだな」
			PRINTFORML 
			SETCOLOR 0xF7819F
			PRINTFORML 
			PRINTFORML ―――――　断善修悪の怪腕　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR 
			PRINTFORML 右腕以外？　一体何の話だろうか？　だが確かに……
			PRINTFORMW 言われてみれば、強い邪気や妖力の迸りを感じる右腕に対し、それ以外の部位は不思議とオーラが弱いように感じる…
			PRINTL
			PRINTFORMW 「…やはりそうか。仮初とはいえ、私はれっきとした五体を持ったようだな。一体どういうことか…。まあそれは後でいい」
			PRINTFORML 「肉体を持てていることが確認できたならば、もうお前は用済みだな。それでは一思いに……んん？」
			PRINTFORMW 殺意を隠そうともせず彼女は%ANAME(MASTER)%に近寄る。が、%ANAME(MASTER)%の眼前に迫った時、不意にその豪腕が止まった
			PRINTL
			PRINTFORML 「お前、いやに変わった『匂い』がするな」
			PRINTFORML さっきまで冷たいまでの美しさに整っていた表情は、とたんに年若い少女の如く眉根を寄せ、困惑したような表情に変わった
			PRINTFORMW （何だこれは…。美味そうな、それでいて臭いような、でも癖になりそうな……こんな「匂い」を持つ奴は初めてだな…）
			PRINTL
			PRINTFORMW 「……ふっ、興味深いな」
			PRINTFORML %ANAME(TARGET)%がさっきまで纏っていた殺気を消し、赤いアイシャドウが利いた目で%ANAME(MASTER)%を見据える
			PRINTFORMW 「まあいい。今は腹も減ってないし、己の肉体を得ることが出来て上機嫌だ。ここで喰い殺すのは止めてやろう」
			PRINTL
			PRINTFORMW 「それよりもお前のことに興味が湧いた。しばらくお前を観察させてもらうぞ。その間は殺しはせんさ」
			PRINTFORML 「…もっとも、私の期待に添えなかったらその限りではないがな。くっくっくっ…」
			PRINTFORMW 嗜虐に満ちた目が嬉しそうに細まる。どうやら大変な存在に目を付けられたようだ……
			PRINTFORMW 「私のことは……そうだな、「%ANAME(TARGET)%」とでも呼ぶがいい。ではお前のことを色々教えてもらうぞ」
		ENDIF

	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		IF CFLAG:好感度 >= 500
			PRINTFORML 「おお。息災か%ANAME(MASTER)%」
		ELSE
			PRINTFORML 「おい。そこのお前」
		ENDIF
		PRINTFORMW 聞き覚えのあるに呼び止められ、%ANAME(MASTER)%は声の方向へ振り向いた
		PRINTL
		PRINTFORML 寒色系を基調とした服装に際立つ桃色の髪と豊満な肉体、
		PRINTFORMW そして、そんな美女そのものな印象を塗り潰す、頭部の大きな角と足の鎖。それらを従えるが如く眼光鋭い切れ長の目…
		PRINTFORMW 間違いなく、彼女だ
		PRINTFORML 
		SETCOLOR 0xF7819F
		PRINTFORML 
		PRINTFORML ―――――　断善修悪の怪腕　『%NAME_FORMAL(TARGET)%』　―――――
		PRINTFORMW 
		RESETCOLOR 
		IF CFLAG:好感度 >= 500
			PRINTFORML 初めて会った時、その邪気と危険なオーラに恐怖を抱いた
			PRINTFORMW しかしある程度付き合いが進むと、割りと素直な言動や纏う邪気とは裏腹の無邪気さなど、割りと話せる相手だと感じていた
			PRINTL
			PRINTFORML 「こんな所で会うとは奇遇だな。それとも、もしや私に会いに来たのか？　ふふふ」
			PRINTFORMW 彼女から放たれる威圧感は相変わらずだったが、それでも慣れた分いくらかマシに感じられた
			PRINTFORML （…相変わらず変わったな匂いの奴だ。美味そうな、それでいて臭いような、でも癖になりそうな……興味深い）
			PRINTL
			PRINTFORMW 「ふふふ、私にわざわざ会いに来るような物好きはお前くらいだろうからな。精々歓迎してやるとしよう」
			PRINTFORMW %ANAME(TARGET)%は屈託無く笑った。その表情は邪悪な妖怪というより、むしろ人懐っこい少女のように見えた…
		ELSE
			PRINTFORML 初めて会った時、その邪気と危険なオーラに恐怖を抱いたことを思い出した
			PRINTFORML 「確か…%ANAME(MASTER)%とか言ったか。こんな所で会うとはな」
			PRINTFORMW %ANAME(MASTER)%は近寄ってくる彼女の圧に押され、背中から汗がじわりと噴出す…
			PRINTL
			PRINTFORMW 「…ふっ、そう怖がるな。今のところは、お前に手を出すつもりは無い。今のところは、…な。くくく」
			PRINTFORML %ANAME(TARGET)%は害意は無いことを示すように肩をすくめる。かといってその威圧感が消えることは無かったが…
			PRINTFORMW （…相変わらず妙な匂いを持った奴だ。美味そうな、それでいて臭いような、でも癖になりそうな……こんな「匂い」を持つ奴は他にいないな）
			PRINTL
			PRINTFORMW 「私はお前に興味がある。だからしばらくお前を観察させてもらうぞ。なに、その間は殺しはせんさ」
			PRINTFORML 「…もっとも、私の期待に添えなかったらその限りではないがな。くっくっくっ…」
			PRINTFORMW 嗜虐に満ちた目が嬉しそうに細まる。どうやら大変な存在に目を付けられたようだ……
			PRINTFORMW 「前に名乗っていたか？　私のことは「%ANAME(TARGET)%」とでも呼ぶがいい。ではお前のことを色々教えてもらうぞ」
		ENDIF
		PRINTL
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------

;親愛か隷属か所有者
ELSEIF (CFLAG:200 < 6) && (TALENT:親愛 || TALENT:隷属 || TALENT:所有者)
	;親愛か隷属になった次の回フラグ
	CFLAG:200 = 6
	PRINTL
	PRINTFORMW ………まずい。かなり寝坊してしまった
	PRINTFORML 待ち合わせ相手はあの%ANAME(TARGET)%だ。怒らせてしまうとどんな目に会うか分かったものではない
	PRINTFORMW %ANAME(MASTER)%は様々な言い訳を考えつつ、大急ぎで彼女のところへ向かった……
	PRINTL
	PRINTFORMW 「………………………………%ANAME(MASTER)%？　……っっ」
	PRINTFORML かなり遅れて待ち合わせ場所へ駆けつけた%ANAME(MASTER)%を見つけた%ANAME(TARGET)%は、烈火の如く怒るかと思いきや…
	PRINTFORMW 「良かった……。何かあったわけじゃないんだなっ！？　私が嫌になったわけじゃないんだなっ！？」
	PRINTFORMW 声を震わせ、目に大粒の涙を滲ませて%ANAME(MASTER)%に駆け寄り、その体をぎゅっと抱きしめた
	PRINTL
	PRINTFORMW 「良かった…ちゃんと来てくれて…。何かあったんじゃないかと思って……心配していたんだぞ…っ！」
	PRINTFORML %ANAME(MASTER)%の服に涙の跡を付けて顔を上げる%ANAME(TARGET)%。その顔から、姿を現さない%ANAME(MASTER)%のことを真剣に心配していたことがわかった
	PRINTFORMW %ANAME(MASTER)%は　ごめん　と謝り、彼女の背中をぽんぽんと優しく叩いた
	PRINTFORML 「……今回だけは、許す。…でも、もうこんなことは止めておくれ。私に黙って……私を裏切って…消えたりしないでおくれ。%ANAME(MASTER)%…」
	PRINTFORMW %ANAME(TARGET)%はしばらくそのまま、%ANAME(MASTER)%の温もりと存在を確かめるように抱きしめていた…
	PRINTL
	;時間経過
	TFLAG:55 += 1

;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTL
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「おお、来たな%ANAME(MASTER)%っ。今日は何をする？　何なら…前と『同じこと』でも構わんぞ…♥」
		PRINTFORMW %ANAME(TARGET)%は前回の情事が忘れられないのか、その柔らかな身体を%ANAME(MASTER)%に押し付けるように誘惑してる
	;それ以外
	ELSE
		PRINTFORMW 「よく来た、%ANAME(MASTER)%。今日は何をする？　何ならまた交尾でも構わんぞ？　くくく…」
	ENDIF
	PRINTL

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTL
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「…ふ、よく来たな%ANAME(MASTER)%。それでは恋人らしいことをよろしく頼むぞっ♪」
		PRINTFORMW %ANAME(TARGET)%は何やら楽しそうな雰囲気で%ANAME(MASTER)%にエスコートを望んでいる
	;それ以外
	ELSE
		PRINTFORMW 「…ふむ、よく来たな。ところで%ANAME(MASTER)%よ。恋人らしいこと、とは何をするんだ？」
	ENDIF
	PRINTL

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTL
	PRINTFORML 「よく来たな%ANAME(MASTER)%。さっそくだが、私たちの間柄は何と呼ぶのだ？」
	PRINTFORMW %ANAME(TARGET)%は、前回口付けを許した%ANAME(MASTER)%との関係をどう呼ぶべきか考えているようだ
	PRINTL
```
