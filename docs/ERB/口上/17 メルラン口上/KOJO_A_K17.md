# 口上/17 メルラン口上/KOJO_A_K17.ERB — 自动生成文档

源文件: `ERB/口上/17 メルラン口上/KOJO_A_K17.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K17, KOJO_TRAIN_END_A1_K17, KOJO_TRAIN_START_A2_K17, KOJO_TRAIN_END_A2_K17, KOJO_COM_BEFORE_TARGET_A_K17, KOJO_COM_BEFORE_PLAYER_A_K17, KOJO_COM_A_K17, KOJO_COM_TARGET_A_K17, KOJO_COM_PLAYER_A_K17, KOJO_COM_AFTER_A_K17, SEX_VOICE17_00, SEX_VOICE17_01, SEX_VOICE17_02, SEX_VOICE17_03, SEX_VOICE17_04; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K17
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
	PRINTFORML 
	PRINTFORMW 部屋から賑やかなトランペットの演奏が聞こえる。思わず気持ちが浮き立つような、だがやや落ち着きの無いような……
	PRINTFORMW 「んん？誰かいるのかなー？いいよー入ってきてー」
	IF !CFLAG:17
		PRINTFORML 
		PRINTFORMW 「ふふふ、いらっしゃい。キミだね？音楽の力で幻想郷を支配しようというのは！」
		PRINTFORMW 「そんなの考えたこともなかったよー、でもいいね！みんなでハッピーになっちゃおう、みたいな？」
		PRINTFORMW 自己紹介もしないうちに喋り続けるメルランの勢いに圧倒される%ANAME(MASTER)%。しかも何か誤解も混ざっているような……
		PRINTFORML 
		PRINTFORMW 「んー……それじゃあキミは新しいマネージャーみたいなものなのかな？」
		PRINTFORMW 「なるほどよろしくね！私はメルラン・プリズムリバー。次のコンサートの日取りが決まったら教えてね？」
		PRINTFORMW 「それじゃあ私はもうちょっと練習したいからまた後でね。ほらほら、私の音を聴き過ぎてヘンになっても知らないよ～♪」
		PRINTFORML 
		PRINTFORMW 言うなり、メルランは%ANAME(MASTER)%に背を向けて演奏の続きを始める。テンションが上がったのか先よりもさらに激し……うるさい。
		PRINTFORMW ペースに呑まれて目的を忘れそうになるところだったが、%ANAME(MASTER)%は響き渡る躁の音に負けじと気合いを入れ、再びメルランに呼び掛けた……
	;既に会ったことがある場合
	ELSE
		PRINTFORML 
		PRINTFORMW 「あれっ？、キミは……前にどこかで会ったことあったかなぁ？あははっ♪」
		PRINTFORMW 「でもそんなことはどうでもいいよね、だってほら、わざわざ私に会いに来たってことはぁ、私とシたいことがあるんでしょう～？」
		PRINTFORML 
		PRINTFORMW 上目遣いでわざとらしくこちらを覗きこんで来るメルラン。
		PRINTFORMW 頭の中を心地良く通り抜けるその声と、子供っぽささえある楽団服とのミスマッチが実に激しい豊かな体つき。
		PRINTFORMW 思わず心臓の鼓動が高まるのを感じる%ANAME(MASTER)%だったが、なんとか落ち着いてメルランと自己紹介を交わし、改めて自分に協力してほしい旨を伝えたのだった。
		PRINTFORML 
		PRINTFORMW 「ふふふ、真面目な人なんだね♪もう少し肩の力を抜いた方がハッピーになれるんじゃないかな？」
		PRINTFORMW 「さ、私の演奏でハッピーになりたい人がいるんでしょ？これからどんどん連れて行ってちょうだいね～」
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻か妾
ELSEIF CFLAG:200 < 7 && TALENT:正妻 || CFLAG:200 < 7 && TALENT:妾
	CFLAG:200 = 7;婚姻した次の回フラグ
	PRINTFORML 「おはようございまーす♪さあ！今日はこれからどうしよう……って」
	PRINTFORMW 「うーん……ちょっとそこ動かないでもらえる？」
	PRINTFORML メルランと元気よく朝の挨拶を交わそうとした%ANAME(MASTER)%だったが、怪訝な顔をされてしまう。
	PRINTFORMW そしてこちらの顔……いや、首元を見つめたメルランがあなたに近づき、襟元に手を回し……
	PRINTFORML 
	PRINTFORMW 「ん…しょ、よし…っと」
	PRINTFORMW 「あのね、ちょっと襟がぴしっとしてなかったから、気になっちゃってね？」
	PRINTFORMW 「なんかこういうのってお嫁さんっぽくなーい？ふふっ♪いや別に、ただ気になっただけなんだけどね～」
	PRINTFORMW クスクスと笑うメルラン。首に手を回されたときには朝からいきなり……かと思ったがそんなことはなく。
	PRINTFORMW あなたは整えられた襟元をいじりつつ、首筋に触れたメルランの指の感触に少し、胸が高鳴るのだった。
	PRINTFORML 
	PRINTFORMW 「……ん、キミったらハッピーな顔してる。ふふふ♪」
	PRINTFORMW 「でもでも、格好がだらしないのはダメだからね？今はサービス期間なので特別でーす」
	PRINTFORML 
	PRINTFORMW 「まあでも……キミはずっと特別……かな❤」
;親愛か隷属
ELSEIF CFLAG:200 < 6 && TALENT:親愛 || CFLAG:200 < 6 && TALENT:隷属
	CFLAG:200 = 6;親愛か隷属になった次の回フラグ
	IF TALENT:親愛
		PRINTFORML 「あっ……今、その、ええ……おはよう！ふふ、びっくりしちゃった」
		PRINTFORMW 「どうしてかって？だってね、今ちょうど私もキミに会いに行っちゃおっかな～って…思ってたから…❤」
		PRINTFORML にっこりとメルランが微笑む。この笑顔を見ただけできょう一日が素晴らしいものになると決まったような、
		PRINTFORMW そう確信させてくれるような一番の表情だ…思わずこちらも笑顔にさせられてしまう。
		PRINTFORML 「ふふふ～そうそう❤キミも笑顔が一番似合ってるよ❤」
		PRINTFORML 「笑う門にはいい音がやってくるなんてね、ふふふ、こういう変なことお姉ちゃんに言うと呆れられるんだけど…」
		PRINTFORMW 「あ～あんまり真面目に聞かなくてもいいよ？ごめんね～だって…あ、なんか楽しくて…アガってきちゃったかも…はは、あはっ❤」
		PRINTFORML 
		PRINTFORML ……こうなってしまってはメルランはなかなか止まらない。腹を決め、あなたは一緒にハイになることにした。
		PRINTFORMW 「え、何で！？ちょっと…何それ、意味わかんない…❤」
		PRINTFORMW 「付き合ってくれなくてもいいのにっ…❤ふふ、ふふっ、ほんとにもう…大好き❤」
	ELSE
	ENDIF
;既成事実Lv3(初めてセックスをした次の回)＆恋慕持ち
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	IF TALENT:恋慕
		PRINTFORML 
		PRINTFORMW 「おっはよー♪ふふ、どうかした？何か変わったことでもあった？」
		PRINTFORMW 「それともー、ついにえっちしちゃったから？あはは♪もうやめてよー、私もほら、意識しちゃうから……うん……」
		PRINTFORMW 急にもじもじとし出すメルラン。お互いにぎこちない空気が流れる……
		PRINTFORMW 「……うふふ、変な感じ……でもねっ、こういうのも全然イヤじゃないよ？」
		PRINTFORMW 「何も考えないでわーっとするだけがハッピーじゃないもんね……ふふ♪それじゃあ今日もがんばろ―！」
	ELSE
		PRINTFORML
		PRINTFORMW 「あ、%ANAME(MASTER)%だ。ふふ、いらっしゃーい❤」
		PRINTFORMW するすると距離を詰めてくるメルラン。急な接近に%ANAME(MASTER)%がたじろいでいると……
		PRINTFORMW 「ちょっと強引だったって反省してるのかな？ふふ、いいのいいの♪」
		PRINTFORMW 「抱かれたときにね、私とするのが嬉しいって、ハッピーだってすっごく伝わってきたから……」
		PRINTFORMW 「でも、どうせなら優しくしてくれた方が好き。ふふ♪あんまり夢中になって、相手を思う余裕を無くしちゃダメだよ？ね❤」
	ENDIF
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTFORML 
	PRINTFORMW 「%ANAME(MASTER)%！来てくれんたんだねー♪」
	PRINTFORMW 勢い良く%ANAME(MASTER)%に抱きつく、むしろ飛びついてくるメルラン。しかしその幸せそうな表情を見ればなんの不満も湧いてこない。
	PRINTFORMW 「ふふふっ❤あははあっ❤無限にハッピーが湧いてきそうだよぉ…嬉しい…♪」
	PRINTFORMW 「……あ、もうちょっとおとなしくした方いい？別に大丈夫？ほんとに…？」
	PRINTFORMW 「ちょっともうその、嬉しくてどうにかもう…あはは♪あはっ、はあっ、いつも通りいつも通り……ふぅ、ふぅ…ね♪」
	PRINTFORMW テンションが上がり過ぎて肩で息をしているメルランをなだめつつ、%ANAME(MASTER)%はその温かさを腕の中で感じていた…

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && !TALENT:キス未経験 && CFLAG:250 > 1
	CFLAG:200 = 3
	PRINTFORML 
	PRINTFORMW 「おはよう%ANAME(MASTER)%！今日は何するの？お仕事？コンサート？」
	PRINTFORMW 「それとも弾幕ごっこかなぁ？派手にやっちゃおーう！」
	PRINTFORMW ……メルランとの初めての口付けは%ANAME(MASTER)%にとっては印象深いものだったが、彼女にとってはどうもそうではないらしい……
	PRINTFORML
	PRINTFORMW （ぎこちないなー%ANAME(MASTER)%ったら♪でもこうやって互いにくっついていくのっていいよねー♪恋って感じで…あれ？）
	PRINTFORMW （……私こういう恋愛っぽいことしたことあったかなぁ…いっつもその、勢いでやっちゃうからなぁ……）
	PRINTFORML 

;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:恋慕 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORML 
	PRINTFORMW 「ふふ、こんにちは%ANAME(MASTER)%！」
	PRINTFORMW 「んー？やけに嬉しそう？そうかなぁ～私はいつでもハッピーだよぉ～？うふふ、ふふっ♪」
	PRINTFORMW 「…んふふっ、だめ、ごめん、ふふ、あははっ♪…なんだか嬉しくて…笑いが止まんないの…♪」

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;妊娠
ELSEIF TALENT:妊娠
	;正妻
	IF TALENT:正妻 || TALENT:妾
		;妊娠６期以降(ぼてっ)
		IF CFLAG:18 >= 6
			SELECTCASE RAND:3
				CASE 0
					PRINTFORML 「おはよう%ANAME(MASTER)%♪……っしょ、ふう」
					PRINTFORML 「こーんなに大きくなって……もういよいよだね❤」
					PRINTFORMW 大きく膨らんだお腹を優しく撫でるメルラン。後は共に予定日を待つだけだ。
				CASE 1
					PRINTFORML 「心配で見に来てくれたんでしょ？キミったらほんと心配性～♪」
					PRINTFORMW 「……でも、頼りになるお父さんだと思ってるよ？ふふ、ありがとね」
				CASE 2
					PRINTFORML 「あ、いらっしゃ……あ、おっ、おぉ……動いたぁ」
					PRINTFORMW 「お父さん来たって分かったのかな？えらいえら～い❤」
			ENDSELECT
		;妊娠４期以降(ぽっこり)
		ELSEIF CFLAG:18 >= 4
			SELECTCASE RAND:3
				CASE 0
					PRINTFORML 「おはよう%ANAME(MASTER)%♪ふふ、どんどん大きくなってきたよね～」
					PRINTFORMW すくすくと育つ我が子の成長を実感する……%ANAME(MASTER)%はメルランと無言で微笑みを交わし合った。
				CASE 1
					PRINTFORML 「今日も朝早いね～♪そんな見ても昨日と大きさ変わってないって～」
					PRINTFORMW 「心配しなくてもちゃんと育ってるよ？ふふ、お母さんにはわかるのです」
				CASE 2
					PRINTFORML 「～～♪……あ、来てたんだ！」
					PRINTFORMW 「今日は調子がいいみたいで……キミの顔を見たらもっと良くなっちゃった！ふふっ❤」
			ENDSELECT
		;妊娠３期以前
		ELSE
			SELECTCASE RAND:3
				CASE 0
					PRINTFORML 「おはよう%ANAME(MASTER)%♪さあさあ、この子にも挨拶してね」
					PRINTFORMW 言われた通りメルランと、そのお腹の中の命に挨拶をする……何とも言えない喜びが湧き上がってくる。
				CASE 1
					PRINTFORML 「こんな朝早くからもう来たの？あ、いやその、キミも嬉しいんだねーって……ふふ♪」
					PRINTFORMW 「必要なものがあったら伝えるからほら、嬉しいのは分かるけどお父さんもちょっと落ち着こうね～」
				CASE 2
					PRINTFORML 「今日はどうしよう？どこか出かける？」
					PRINTFORMW 「じっとしてるのも飽きちゃうし……少し体も動かしたい気分！」
			ENDSELECT
		ENDIF
	;恋慕
	ELSEIF TALENT:恋慕
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「ああ！来てくれたんだ～……♪」
				PRINTFORMW 「良かった……ちょっとその、心細かったから……ふふ、嬉しい♪」
			CASE 1
				PRINTFORML 「あ、お父さんが来たよ～♪ふふ、声とか聞こえてるかな」
				PRINTFORMW 愛おしそうにお腹を撫でるメルランの姿を見ると思わず%ANAME(MASTER)%も顔が緩んでしまう。
			CASE 2
				PRINTFORML 「おっはよー♪なんかお手伝いする？あ、いらない？」
				PRINTFORMW 「今日は調子がいいからついつい……ふふ、無理しちゃだめだよね～」
		ENDSELECT
	;それ以外
	ELSE
		PRINTFORML 「あらお父さんいらっしゃ～い♪ふふ、来てくれるなんてちょっと予想外」
		PRINTFORMW 「……でも、嬉しいのはホントだよ？」
```
