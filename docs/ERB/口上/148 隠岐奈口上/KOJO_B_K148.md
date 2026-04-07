# 口上/148 隠岐奈口上/KOJO_B_K148.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/KOJO_B_K148.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_B_K148, KOJO_TRAIN_END_B_K148, KOJO_COM_BEFORE_TARGET_B_K148, KOJO_COM_BEFORE_PLAYER_B_K148, KOJO_COM_B_K148, KOJO_COM_TARGET_B_K148, KOJO_COM_PLAYER_B_K148, KOJO_COM_AFTER_B_K148; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜調教」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_B_K148
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;処女フラグ（処女だったらCFLAG:260を1にセット）
SIF TALENT:処女
	CFLAG:260 = 1

;処女フラグ（プレイヤー用）（処女だったらCFLAG:261を1にセット）
SIF TALENT:MASTER:処女
	CFLAG:261 = 1

;ファーストキスフラグ（キス未経験だったらCFLAG:264を1にセット）
SIF TALENT:キス未経験
	CFLAG:264 = 1
;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:202 == 0
	CFLAG:202 = 1
	;初対面の場合
	IF !CFLAG:17
		PRINTFORMW 鉄格子越しに薄暗い牢屋を覗いてみると、部屋の隅でうずくまっていた少女…隠岐奈がビクリと顔を上げた。
		PRINTFORML 「…………何の用だ」
		PRINTFORML 容姿に見合わぬ凄まじい敵意と殺気を放ちながら、彼女は%ANAME(MASTER)%を睨みつける。
		PRINTFORML %ANAME(MASTER)%が牢獄に足を踏み入れると、より明確にその威圧感を感じられた。
		PRINTFORMW しかし、臆することはない。もはやこの牢の中では、神だろうが何だろうが非力な存在でしかないのだ。
		PRINTFORML 
		PRINTFORML 「私に近寄るな、下種めが」
		PRINTFORML %ANAME(MASTER)%から一切目を逸らさずに嫌悪の視線を放つ隠岐奈。
		PRINTFORML だが、よく見てみればその体は微かに震えていた。
		PRINTFORMW それに気づいた%ANAME(MASTER)%は、思わず笑みを浮かべてしまう。
		PRINTFORML 
		PRINTFORML 逃げ場のないこの空間で、彼女の誇りも在り方も、何もかもを奪い、壊したら……
		PRINTFORMW 果たして、どのような表情を見せてくれるのだろう？
		PRINTFORML 
		PRINTFORMW ついに隠岐奈を追い詰めた%ANAME(MASTER)%は、加虐心を露わに彼女への凌辱を開始した…。
	;既に会ったことがある場合
	ELSE
		IF TALENT:恋慕 || TALENT:服従
			PRINTFORMW 鉄格子越しに薄暗い牢屋を覗いてみると、部屋の隅でうずくまっていた少女…隠岐奈がビクリと顔を上げた。
			PRINTFORML 「%ANAME(MASTER)%……？」
			PRINTFORML 「あ、あぁ……そうか、来たのか…お前が……」
			PRINTFORMW %ANAME(MASTER)%の顔を見て、隠岐奈はどこか安心したような、しかし悲しげな笑みを浮かべる。
			PRINTFORML 「………私を助けてくれるわけではないのだろう？」
			PRINTFORMW その通りだと%ANAME(MASTER)%が頷くと、彼女は項垂れて黙り込む。
			PRINTFORML 
			PRINTFORMW %ANAME(MASTER)%が牢獄に足を踏み入れても、隠岐奈はぴくんと肩を揺らしはすれど、顔を上げることはない。
			PRINTFORML そっと体に触れる……。
			PRINTFORMW 「さ、触るなッ！」
			PRINTFORML 「私は、こんな……っ」
			PRINTFORML 「こんなことは、望んではいないッ！」
			PRINTFORMW 隠岐奈は%ANAME(MASTER)%を振り払おうと暴れ、彼女を縛る鎖がじゃらじゃらと音を立てる。
			PRINTFORMW だが腕力で押さえこんでしまえば、彼女はあっという間に身動きが取れなくなり、悲痛に顔を歪ませるだけになった。
			PRINTFORML 
			PRINTFORML 「……%ANAME(MASTER)%」
			PRINTFORMW 最後に小さくそう呟くと、隠岐奈は諦めたように身体の力を抜いた。
		;好かれている
		ELSEIF CFLAG:3 >= 1000
			PRINTFORMW 鉄格子越しに薄暗い牢屋を覗いてみると、部屋の隅でうずくまっていた少女…隠岐奈がビクリと顔を上げた。
			PRINTFORML 「……%ANAME(MASTER)%か」
			PRINTFORML 「まさか、お前が来るとはな」
			PRINTFORMW 隠岐奈は嘲りの笑みを浮かべながら、%ANAME(MASTER)%をじっと見据えている。
			PRINTFORML 「………私を犯しに来たのだろう？」
			PRINTFORMW その通りだと頷けば、彼女はさらに色濃く%ANAME(MASTER)%への侮蔑を露わにする。
			PRINTFORML 「まさか、お前がそんな下種だとは思ってもいなかったよ」
			PRINTFORMW 「やれやれ……どうやら私の見込み違いだったようだ」
			PRINTFORML 
			PRINTFORML %ANAME(MASTER)%が牢獄に足を踏み入れると、彼女から凄まじい殺意と敵意が放たれる。
			PRINTFORMW しかし、臆することはない。もはやこの牢の中では、神だろうが何だろうが非力な存在でしかないのだ。
			PRINTFORML 「今ならまだ間に合う。引き返せ。でないと……」
			PRINTFORML 「お前はいつか、死よりも恐ろしい目に遭うことになるよ」
			PRINTFORMW 黄金色の目を光らせながら、隠岐奈は冷たく言い放つ。
			PRINTFORMW だが、そんな脅しなど効くものか。
			PRINTFORMW ついに隠岐奈を追い詰めた%ANAME(MASTER)%は、加虐心を露わに彼女への凌辱を開始した…。
		;それ以外
		ELSE
			PRINTFORMW 鉄格子越しに薄暗い牢屋を覗いてみると、部屋の隅でうずくまっていた少女…隠岐奈がビクリと顔を上げた。
			PRINTFORML 「……%ANAME(MASTER)%か」
			PRINTFORML 「まさか、お前が来るとはな」
			PRINTFORMW 隠岐奈は嘲りの笑みを浮かべながら、%ANAME(MASTER)%をじっと見据えている。
			PRINTFORML 「………私を犯しに来たのだろう？」
			PRINTFORML その通りだと頷けば、彼女はさらに色濃く%ANAME(MASTER)%への侮蔑を露わにする。
			PRINTFORMW 「だろうな。一目見た時から、お前はそういう下種だと分かっていたさ」
			PRINTFORML 
			PRINTFORML %ANAME(MASTER)%が牢獄に足を踏み入れると、彼女から凄まじい殺意と敵意が放たれる。
			PRINTFORMW しかし、臆することはない。もはやこの牢の中では、神だろうが何だろうが非力な存在でしかないのだ。
			PRINTFORML 「今ならまだ間に合う。引き返せ。でないと……」
			PRINTFORML 「お前はいつか、死よりも恐ろしい目に遭うことになるよ」
			PRINTFORMW 黄金色の目を光らせながら、隠岐奈は冷たく言い放つ。
			PRINTFORMW だが、そんな脅しなど効くものか。
			PRINTFORMW ついに隠岐奈を追い詰めた%ANAME(MASTER)%は、加虐心を露わに彼女への凌辱を開始した…。
		ENDIF
	ENDIF
;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;恋慕または服従を獲得した
ELSEIF CFLAG:202 < 3 && (TALENT:恋慕 || TALENT:服従)
	CFLAG:202 = 3
	PRINTFORMW %ANAME(MASTER)%が牢屋を訪れると、膝を抱え込み座っていた隠岐奈がハッと顔を上げた。
	PRINTFORML 「%ANAME(MASTER)%……」
	PRINTFORML 「今日もまた、するのか」
	PRINTFORMW そうして彼女は小さく微笑む。
	PRINTFORMW いつもの嫌悪感と拒絶に満ちたものとは違い、今見せた彼女の笑みは何かを諦めたような、どこか切なげなものだった。
	PRINTFORML 「勝手にするが良い。もう抗うことなどしないから」
	PRINTFORMW 「……さあ、私を抱け」
	PRINTFORML どういう心境の変化だろう。%ANAME(MASTER)%は訝しみつつも、隠岐奈の肌に触れる。
	PRINTFORMW 小さく身じろぎしたその身体はすでに火照り、投げかけられた視線には得も言われぬ熱が籠っていた…。
;依存度が300以上になった
ELSEIF CFLAG:202 < 2 && CFLAG:3 >= 300
	CFLAG:202 = 2
	PRINTFORML %ANAME(MASTER)%が牢獄に入ると、隠岐奈は自身の身体を庇うように身を縮こませながら、敵意の視線を向けてくる。
	PRINTFORML 「お前も飽きないな。私を辱めることがそんなに良いのか？」
	PRINTFORMW 「……まあいい。外道の魂胆など知りたくもない」
	PRINTFORML %ANAME(MASTER)%が目の前に立つと、彼女は小さく息を吐いて身体の力を抜く。
	PRINTFORML そっと肌に触れても抵抗する様子はない。
	PRINTFORMW しかしその目だけは未だ嫌悪感に満ち、軽蔑の色を湛えていた。

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;恋慕 or 服従
ELSEIF TALENT:恋慕 || TALENT:服従
	SELECTCASE RAND:2
		CASE 0
			PRINTFORML 「%ANAME(MASTER)%、来たのか…」
			PRINTFORML 牢屋内でぼうっとしていた隠岐奈だが、%ANAME(MASTER)%の顔を見るとその表情が緩んだ。
			PRINTFORMW その表情はどこか嬉しそうでもあり、一定の憂いも帯びているようにも見えた。
		CASE 1
			PRINTFORML 「%ANAME(MASTER)%か」
			PRINTFORML 隠岐奈は%ANAME(MASTER)%を見ると、ほっとしたような表情を浮かべた。
			PRINTFORML 「名も知らぬ馬の骨よりも、お前に抱かれた方がずっと良い」
			PRINTFORMW 「さあ、来てくれ……」
	ENDSELECT
;依存度が300以上
ELSEIF CFLAG:3 >= 300
	SELECTCASE RAND:2
		CASE 0
			PRINTFORML 「私を辱めるよりも、もっと別のことに時間を使ったらどうだ？」
			PRINTFORMW 隠岐奈は嫌悪感を露わにしつつ、呆れた様子で%ANAME(MASTER)%を見つめている。
		CASE 1
			PRINTFORML 「……もうお前の顔は見たくないと思っていたのだがな」
			PRINTFORMW 隠岐奈は苦虫を嚙み潰したよう表情を浮かべている。
	ENDSELECT
;それ以外
ELSE
	SELECTCASE RAND:2
		CASE 0
			PRINTFORML 「………ッ！」
			PRINTFORML 隠岐奈は寄らば斬ると言わんばかりの殺意を%ANAME(MASTER)%に向けている。
			PRINTFORML しかし問題はない。彼女の力は封じられ、身体は鎖に繋がれているのだ。
			PRINTFORMW %ANAME(MASTER)%は隠岐奈への調教を開始した。
		CASE 1
			PRINTFORML 「また来たのか。下劣な屑め」
			PRINTFORML 「言っておくが、いくら私を嬲ろうとも無意味だ」
			PRINTFORML 「私がお前に屈するなど絶対にあり得ないのだからな」
			PRINTFORMW 隠岐奈の言葉を無視して、%ANAME(MASTER)%は調教を開始した。
	ENDSELECT
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_B_K148
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	;PRINTFORMW 
;快感のあまり気絶
ELSEIF TCVAR:52
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「あぁ～～ッ♥ っ、はぁ……ぁ…」
		PRINTFORMW 隠岐奈は快楽のあまり腰を砕けさせ、その場に突っ伏した。
	;それ以外
	ELSE
		PRINTFORML 「ひッ、～～～ッ！！」
		PRINTFORMW 隠岐奈は一度大きく身体を跳ねさせると、その場にぐったりと突っ伏した。
	ENDIF
;疲労による行動不能
ELSEIF TCVAR:51
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
```
