# 口上/01 霊夢口上/KOJO_A_K1.ERB — 自动生成文档

源文件: `ERB/口上/01 霊夢口上/KOJO_A_K1.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K1, KOJO_TRAIN_END_A1_K1, KOJO_TRAIN_START_A2_K1, KOJO_TRAIN_END_A2_K1, KOJO_COM_BEFORE_TARGET_A_K1, KOJO_COM_BEFORE_PLAYER_A_K1, KOJO_COM_A_K1, KOJO_COM_TARGET_A_K1, KOJO_COM_PLAYER_A_K1, KOJO_COM_AFTER_A_K1; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K1
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		PRINTFORMW  「あら、見かけない顔ね」
		PRINTFORMW  　%ANAME(TARGET)%が不可思議そうに首を傾げてきたため、%ANAME(MASTER)%は簡単に自己紹介することとなった。
		PRINTFORMW  「ふぅん、なるほどね。なかなかに可愛らしい顔をしているじゃない」
		PRINTFORMW  　%ANAME(TARGET)%は改めて%ANAME(MASTER)%を覗き込むと、意味深げに微笑んでみせる。
		PRINTFORMW  　その妖艶な表情に、つい躰を強張らせてしまった。
		PRINTFORMW  「怖がらなくていいわよ。何処ぞの狐とは違って、誰彼構わずに襲う趣味はないからね」
		PRINTFORMW  「さあ、私に会いに来た要件を云ってみなさい。まさか顔を見に来ただけじゃないでしょう？」
		PRINTFORMW  　さて、本当は挨拶に来ただけなのだが、どうしたものか。
		PRINTFORMW  　%ANAME(MASTER)%は腕を組んで考えていると、「そうそう」と%ANAME(TARGET)%はお祓い棒で玄関の近くを示した。
		PRINTFORMW  「ちなみに出張版素敵な賽銭箱はあそこにあるわ」
		PRINTFORMW  「後で分社も用意しておかないといけないわね。政務やら軍備やらで、なかなか神社には戻れないのよ」
		PRINTFORMW  　そう云うと%ANAME(TARGET)%は、嘆息を零した。
		PRINTFORMW  　いまいち掴みどころのない彼女に%ANAME(MASTER)%は愛想笑いを返すしかなかった。

	;既に会ったことがある場合
	ELSE
		PRINTFORMW  「あら、何処かで見た顔ね」
		PRINTFORMW  　%ANAME(TARGET)%が不可思議そうに首を傾げてきたため、%ANAME(MASTER)%は簡単に自己紹介することとなった。
		PRINTFORMW  「ふぅん、なるほどね。なかなかに可愛らしい顔をしているじゃない」
		PRINTFORMW  　%ANAME(TARGET)%は改めて%ANAME(MASTER)%を覗き込むと、意味深げに微笑んでみせる。
		PRINTFORMW  　その妖艶な表情に、つい躰を強張らせてしまった。
		PRINTFORMW  「怖がらなくていいわよ。何処ぞの狐とは違って、誰彼構わずに襲う趣味はないからね」
		PRINTFORMW  「さあ、私に会いに来た要件を云ってみなさい。まさか顔を見に来ただけじゃないでしょう？」
		PRINTFORMW  　さて、本当は挨拶に来ただけなのだが、どうしたものか。
		PRINTFORMW  　%ANAME(MASTER)%は腕を組んで考えていると、「そうそう」と%ANAME(TARGET)%はお祓い棒で玄関の近くを示した。
		PRINTFORMW  「ちなみに出張版素敵な賽銭箱はあそこにあるわ」
		PRINTFORMW  「後で分社も用意しておかないといけないわね。政務やら軍備やらで、なかなか神社には戻れないのよ」
		PRINTFORMW  　そう云うと%ANAME(TARGET)%は、嘆息を零した。
		PRINTFORMW  　いまいち掴みどころのない彼女に%ANAME(MASTER)%は愛想笑いを返すしかなかった。
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意 && TALENT:恋慕
	CFLAG:200 = 5
	PRINTFORMW 　沈黙が重たい。
	PRINTFORMW 　%ANAME(TARGET)%が耳まで赤く染めた顔で、ちらちらとこちらの様子を伺ってくる。
	PRINTFORMW 　どう対処すれば良いのか判らず、%ANAME(MASTER)%は空を眺めた。
	PRINTFORMW 　いつしかは雲のような存在だと感じた%ANAME(TARGET)%の印象も随分と変わってしまったと想う。
	PRINTFORMW 　雲のように掴めなかった彼女は、今や両手で抱きしめることができる。
	PRINTFORMW 　雲のようにふわふわとしていた彼女は、互いを拠り所に今や身を寄せ合うほどになった。
	PRINTFORMW 　ふと触れた%ANAME(MASTER)%の指先は、互いに手を重ね合おうとして、結局は絡めあうことで終結した。
	PRINTFORMW 　肩が触れ合う、距離が縮まる。呼吸をするのが判る、胸の鼓動が伝わってくる。
	PRINTFORMW 　遠慮がちに%ANAME(TARGET)%が唇を耳元に寄せる。
	PRINTFORMW 「ねえ、今日もするの？」
	PRINTFORMW 　囁かれた言葉に%ANAME(MASTER)%は思わず生唾を飲み込んだ。

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人  && TALENT:恋慕
	CFLAG:200 = 4
	PRINTFORMW 「私達って付き合っているのよね？」
	PRINTFORMW 　縁側で上の空になっていた%ANAME(TARGET)%が独り言を零すように訊いてきた。
	PRINTFORMW 　首肯すると、「そう」と%ANAME(TARGET)%は小さく呟いた。
	PRINTFORMW 「いまいち夢と現の境界が判らないのよね、なんというか実感が湧かないのよ」
	PRINTFORMW 「たぶん幸せなのだと思う、とんでもないくらいに幸せなことなのだと思う」
	PRINTFORMW 「でも地に足が着かないというか……ふわふわ、としているというか……」
	PRINTFORMW 　幻想郷の空を飛ぶ巫女は苦心して、自らの心象を表現しようとする。
	PRINTFORMW 　どうすればいいのか問うと%ANAME(TARGET)%は急に顔を真っ赤にして俯いてしまった。
	PRINTFORMW 　暫しの間、
	PRINTFORMW 　%ANAME(TARGET)%は瞼を閉じたまま、そっと小さな唇を向けてきた。
	PRINTFORMW 　……
	PRINTFORMW 　…………
	PRINTFORMW 　………………
	PRINTFORMW 　唇を重ねる。
	PRINTFORMW 　身震いする%ANAME(TARGET)%に実感を植え付けるように長い時間を甘美な感触を共有した。
	PRINTFORML
	PRINTFORML 　　%ANAME(MASTER)%:キス経験+1
	PRINTFORML
	PRINTFORMW 　　%ANAME(TARGET)%:キス経験+1

	EXP:(MPLY:0):キス経験 += 1
	EXP:(MTAR:0):キス経験 += 1

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORMW　 いつもの縁側で%ANAME(TARGET)%が呆けた顔で座っている。
	PRINTFORMW 　先日の……ことを思い浮かべているのだろうか。
	PRINTFORMW 　ふと無意識に自らの唇に手が伸び、先日の柔らかい感触を思い浮かべる。
	PRINTFORMW 　躰が強張るのが判る、顔が火照っているのが判る。
	PRINTFORMW 　恐らくは、%ANAME(TARGET)%も同じに違いない。
	PRINTFORMW 　今日は何時も通りに接することができるのだろうか、あまり自信がない。
	PRINTFORMW 　驚かせないように慎重に挨拶を返すと、「ああ、%ANAME(MASTER)%ね」と%ANAME(TARGET)%は淡泊に返し、無言で自分の隣を叩いて座るように促してきた。
	PRINTFORMW 　おずおずと隣に座らせてもらい、無言で差し出された茶を啜る。
	PRINTFORMW 　今日は、うん、今日も風が心地よい。
	PRINTFORMW 　静かに二人だけの時が刻まれる。
	PRINTFORMW 　そしていつも通りだけど、いつもとは少し違う時間が過ぎる。

;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 　いつものように縁側に座っている%ANAME(TARGET)%を見つけたが、どうにも落ち着きがない。
	PRINTFORMW 　普段であれば敷地内に入っただけで誰かが来たことを察する勘の鋭い彼女であったが、どうにも今日ばかりは%ANAME(MASTER)%の存在に気付いていないようだ。
	PRINTFORMW 　少し悪戯心が芽生えた%ANAME(MASTER)%は、驚かせてやろうと音を忍ばせて%ANAME(TARGET)%の傍まで歩み寄る。
	PRINTFORMW 　もう数歩もすれば触れ合う距離なのに、%ANAME(TARGET)%はまだ気づく様子がない。
	PRINTFORMW 　間近に見る彼女の頬は心なしか朱に染まっているような気もする。
	PRINTFORMW 　わっ、と声を上げると「ひゃ、ひゃいっ！？」と%ANAME(TARGET)%は驚きの声を上げる。
	PRINTFORMW 「も、もう！　驚かさないでよ、本当にびっくりしたじゃない！」
	PRINTFORMW 　本気で怒鳴りつける%ANAME(TARGET)%に、%ANAME(MASTER)%は素直に謝ることにした。
	PRINTFORMW 「ま、まあ、来てくれるのは構わないけどね」
	PRINTFORMW 「今度からはちゃんと普通に挨拶すること、良いわね」
	PRINTFORMW 　そう云いつける%ANAME(TARGET)%の顔は耳まで赤く染まっており、まだ落ち着かない様子だった。
	PRINTFORMW 　雲のように掴みどころのない彼女の珍しいものが見れたと思う。
	PRINTFORMW 　なんだか、いつもより距離が縮まった感じがする。

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
;ELSEIF TALENT:合意 && TALENT:恋慕
	;PRINTFORMW 
;既成事実Lv3(セックス済み)
;ELSEIF TALENT:合意
	;PRINTFORMW 
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人 || TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:6
		CASE 0
			PRINTFORMW 「待っていたわよ、%ANAME(MASTER)%。早く座りなさい」
			PRINTFORMW 　縁側に座る%ANAME(TARGET)%に誘われて、彼女の隣に座る。
			PRINTFORMW 　湯呑は二つ、置いてある。他の誰かが来る予定があったのだろうか。
			PRINTFORMW 「今日はあったのよ、貴方が来る予定がね」
			PRINTFORMW 　%ANAME(TARGET)%が何食わぬ顔で告げる。
			PRINTFORMW 　今更、不思議に思うこともない。楽園の巫女はすこぶる勘が良かった。
			PRINTFORMW 　少しばかり薄い色をした茶を啜り、心を落ち着ける。
			PRINTFORMW 　なんとなく今日は良い日になる気がする。
			PRINTFORMW 「今日は何をしようかしらね」
			PRINTFORMW 　%ANAME(TARGET)%が何気なく身を寄せて問うてきた。
			PRINTFORMW 　たぶん彼女がいるから今日は良い日になるのだろう。
		CASE 1
			PRINTFORMW 「今日は%ANAME(MASTER)%も退屈しているようね」
			PRINTFORMW 　いつものように縁側に座る%ANAME(TARGET)%は笑みを浮かべて出迎えてくれる。
			PRINTFORMW 「……今日は甘い物が食べたいなあ、何か持って来てくれた？」
			PRINTFORMW 　恐らく%ANAME(TARGET)%は判っていて云っているのだろう。
			PRINTFORMW 　%ANAME(MASTER)%は通りすがりの茶店で購入した菓子を見せてやる。
			PRINTFORMW 「うん、うん、ここのお菓子は大好きなのよ。流石、判っているわね」
			PRINTFORMW 　笑顔で擦り寄って来る%ANAME(TARGET)%から菓子を遠ざけ、代わりにと茶を用意するように要求する。
			PRINTFORMW 「ん～、判っているわよ。別に一口くらい良いじゃない」
			PRINTFORMW 　文句を云いながらも%ANAME(TARGET)%は素直に腰を上げて、台所へと向かっていった。
			PRINTFORMW 　茶を淹れてくれるまでの間、%ANAME(MASTER)%は縁側に腰を下ろして空を眺める。
			PRINTFORMW 　今はこうして待っている時間すらも愛しく想える。
		CASE 2
			PRINTFORMW 　%ANAME(TARGET)%の家まで足を運ぶと、縁側には無防備に昼寝をする%ANAME(TARGET)%の姿があった。
			PRINTFORMW 　心地よい寝息を立てる%ANAME(TARGET)%の横に腰を下ろし、%ANAME(MASTER)%は静かに空を見上げる。
			PRINTFORMW 　あまりにも可愛らしい寝顔を晒す%ANAME(MASTER)%に、つい悪戯心が湧いてきてしまう。
			PRINTFORML　 キスをしますか？
			PRINTFORML [0] はい
			PRINTFORML [1] いいえ

			$INPUT_LOOP1
			INPUT
			IF RESULT != 0 && RESULT != 1
				GOTO INPUT_LOOP1
			ELSEIF RESULT == 0
				PRINTFORML
				SELECTCASE RAND:3
					CASE 0
						PRINTFORMW 　%ANAME(MASTER)%は安らかな表情で眠っている%ANAME(TARGET)%に唇を落とした。
						PRINTFORMW 　触れ合わせるだけのキス、じっくりと長い時間をかけて堪能する。
						PRINTFORMW 　躰の内側から込みあがって来る熱が心地よく、寝ている%ANAME(TARGET)%のキスを奪っているという背徳感が欲情を促す。
						PRINTFORMW 　もう少し深いキスをしても大丈夫だろうか。
						PRINTFORMW 「んん……っ」
						PRINTFORMW 　そう思った時、不意に%ANAME(TARGET)%が躰をよじり、慌てて%ANAME(MASTER)%は唇を離した。
						PRINTFORMW 　まだ残る柔らかな唇の感触、暫しの間、余韻を堪能しようとそのまま空を眺めた。
						PRINTFORMW 　暫くして、%ANAME(TARGET)%が目を醒ます。
						PRINTFORMW 「ふふ、なんだかとても良い夢を見た気がするわ」
						PRINTFORMW 　純粋な笑顔を向ける%ANAME(TARGET)%に、%ANAME(MASTER)%は背徳感を胸に潜めて、緩やかな笑みを返した。

						PRINTFORML
						PRINTFORML 　　%ANAME(MASTER)%:キス経験+1
						PRINTFORML
						PRINTFORMW 　　%ANAME(TARGET)%:キス経験+1

						EXP:(MPLY:0):キス経験 += 1
						EXP:(MTAR:0):キス経験 += 1
					CASE 1
						PRINTFORMW 　%ANAME(MASTER)%は安らかな表情で眠っている%ANAME(TARGET)%に唇を落とした。
						PRINTFORMW 　触れ合わせるだけのキス、じっくりと長い時間をかけて堪能する。
```
