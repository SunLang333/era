# 口上/94 影狼口上/KOJO_A_K94.ERB — 自动生成文档

源文件: `ERB/口上/94 影狼口上/KOJO_A_K94.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K94, KOJO_TRAIN_END_A1_K94, KOJO_TRAIN_START_A2_K94, KOJO_TRAIN_END_A2_K94, KOJO_COM_BEFORE_TARGET_A_K94, KOJO_COM_BEFORE_PLAYER_A_K94, KOJO_COM_A_K94, KOJO_COM_TARGET_A_K94, KOJO_COM_PLAYER_A_K94, KOJO_COM_AFTER_A_K94; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K94
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;従属度が100以上(調教で恐怖や苦痛で堕とした後を想定、もっといい分岐あるかしら)
	IF CFLAG:4 >= 100
		PRINTFORMW 影狼の元を訪ねた
		PRINTFORMW 彼女の姿を確認し声をかけると、ビクッと怯えたような反応をされた
		PRINTFORMW 「あっ…こ、こんにちは…」
		PRINTFORMW 先の調教で警戒されているらしく、たどたどしく挨拶された
		PRINTFORMW 緊張を解くためにここでの暮らしについてあれこれ話をする
		PRINTFORMW 彼女はその間も始終こちらの顔色を覗っていた
		PRINTFORMW 一通りの会話も済み、何か要望や質問はあるかと尋ねるとゆっくりと口を開く
		PRINTFORMW 「え、えっと…それで今日は何の用かしら……？」
		PRINTFORMW 成程、また何かされるかと思い怯えていたようだ
		PRINTFORMW さて、可愛がってやってもいいし、もう少し調教してやってもいいか
		PRINTFORMW そんなことを考えながら影狼の腕を取り、住まいへと入っていった
	;好感度＆依存度が100以上(調教で快楽で堕とした後を想定、もっといい分岐あるかしら)
	ELSEIF CFLAG:2 >= 100 && CFLAG:3 >= 100
		PRINTFORMW 影狼の元を訪ねた
		PRINTFORMW 彼女の姿を確認し声をかけると、パッと笑顔になって駆け寄ってきた
		PRINTFORMW 「こんにちは、%ANAME(MASTER)%、ふふっ」
		PRINTFORMW すっかりこの国になれたらしい影狼とあれこれ世間話をする
		PRINTFORMW 彼女はその間も始終笑顔でこちらの話を聞いていた
		PRINTFORMW 一通りの会話も済み、何か要望や質問はあるかと尋ねるとゆっくりと口を開く
		PRINTFORMW 「うぅん、今のところは平気…それより、今日はもう帰っちゃうの？」
		PRINTFORMW まるで小犬の様にあなたを見上げ、不安と期待が混じったような瞳を向けてきた
		PRINTFORMW 今日は休みだから、まだ帰る必要はないと告げると
		PRINTFORMW それならもう少し一緒に居られるわねと、あなたの腕を取り住まいへと入っていった
	;初対面の場合
	ELSEIF !CFLAG:17
		PRINTFORMW 影狼の元を訪ねた
		PRINTFORMW 将の住まいにしては町から離れた静かで簡素な所だ
		PRINTFORMW 周囲に人影は見当たらない、留守なのだろうか
		PRINTFORMW 出直すかと思案していると背後から声を掛けられた
		PRINTFORMW 「あら、お客さん？」
		PRINTFORMW 声のする方を向くと一人の少女がこちらへと歩いてきた
		PRINTFORMW 長くつややかな髪とそこからピョンと飛び出た犬耳
		PRINTFORMW そしてふんわりとした大きな尻尾が目に付いた
		PRINTFORMW 「何か用かしら、来客の予定はなかったと思うけど」
		PRINTFORMW 警戒するようにあなたと少し離れた位置で立ち止まりこちらを見つめてくる
		PRINTFORMW 自分は同じ国に仕える%ANAME(MASTER)%だ
		PRINTFORMW 今日は同じ国に仕える者として交流を深めに来たと自己紹介をする
		PRINTFORMW 「ふーん、あなたが%ANAME(MASTER)%…名前は聞いてたわ」
		PRINTFORMW しげしげと%ANAME(MASTER)%を眺めている、やはりその視線からは警戒の色がうかがえる
		PRINTFORMW 「まぁ、仲間なら追い返すわけにもいかないし…あがっていって」
		PRINTFORMW 彼女の尻尾を追いかける様に後に続き屋敷に入る
		PRINTFORMW しかしなんだかそっけない、わざわざこんなところに住んでいるのを見ても
		PRINTFORMW どうやら彼女は人嫌いかあるいは偏屈な性分なのか
		PRINTFORMW そんなことを考えていると彼女がくるっとこちらに向き直った
		PRINTFORMW 「そうそう、一つだけ忠告しておくけど」
		PRINTFORMW 真剣な視線と口調にまさか声に出ていたかとドキッと身構えた
		PRINTFORMW 「尻尾には触らないで」
		PRINTFORMW ジトッとした視線で強い口調で釘を刺された
		PRINTFORMW …どうやらふんわりとした尻尾に目移りしていたことがばれていたようだ
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 影狼の元を訪ねた
		PRINTFORMW 将の住まいにしては町から離れた静かで簡素な所だ
		PRINTFORMW 周囲に人影は見当たらない、留守なのだろうか
		PRINTFORMW 出直すかと思案していると背後から声を掛けられた
		PRINTFORMW 「あら、お客さん？」
		PRINTFORMW 声のする方を向くと一人の少女がこちらへと歩いてきた
		PRINTFORMW 長くつややかな髪とそこからピョンと飛び出た犬耳
		PRINTFORMW そしてふんわりとした大きな尻尾が目に付いた
		PRINTFORMW 「あなた、どこかで会ったことあったかしら？」
		PRINTFORMW 警戒するようにあなたと少し離れた位置で立ち止まりこちらを見つめてくる
		PRINTFORMW 自分は同じ国に仕える%ANAME(MASTER)%だ
		PRINTFORMW 今日は同じ国に仕える者として交流を深めに来たと自己紹介をする
		PRINTFORMW 「あぁ、あなたが%ANAME(MASTER)%なのね…ふーん、以前とは印象が違うわね」
		PRINTFORMW しげしげと%ANAME(MASTER)%を眺めている、やはりその視線からは警戒の色がうかがえる
		PRINTFORMW 「まぁ、仲間なら追い返すわけにもいかないし…あがっていって」
		PRINTFORMW 彼女の尻尾を追いかける様に後に続き屋敷に入る
		PRINTFORMW しかしなんだかそっけない、わざわざこんなところに住んでいるのを見ても
		PRINTFORMW どうやら彼女は人嫌いかあるいは偏屈な性分なのか
		PRINTFORMW そんなことを考えていると彼女がくるっとこちらに向き直った
		PRINTFORMW 「そうそう、一つだけ忠告しておくけど」
		PRINTFORMW 真剣な視線と口調にまさか声に出ていたかとドキッと身構えた
		PRINTFORMW 「尻尾には触らないで」
		PRINTFORMW ジトッとした視線で強い口調で釘を刺された
		PRINTFORMW …どうやらふんわりとした尻尾に目移りしていたことがばれていたようだ
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
		;恋慕
	IF TALENT:恋慕
		PRINTFORMW 影狼の元を訪ねると、空を見上げている彼女を見上げた
		PRINTFORMW 「あっ…」
		PRINTFORMW あなたと目が合うと小さく声を漏らし、ふいと顔を反らしてしまった
		PRINTFORMW 何か怒らせることをしただろうか、それとも前回の事を根に持っているのだろうか
		PRINTFORMW チラッと様子を見るとこちらから顔を反らしたままで顔色もうかがえない
		PRINTFORMW 悩んだままでは仕方ない、怒っているならば理由を聞かなくては
		PRINTFORMW そう思って影狼に声をかけようとしたとき、彼女がくるっとこちらを向き直った
		PRINTFORMW 「えっと…い、いらっしゃい、%ANAME(MASTER)%」
		PRINTFORMW いつもと変わらないその言葉に面食らってしまい、しどろもどろに返事を返す
		PRINTFORMW どうやら怒ってはいない様だがいつもよりも顔が赤いように感じた
		PRINTFORMW その後表面上はいつも通りに振る舞おうとする彼女を意識してしまい
		PRINTFORMW お互いにいつもよりもぎこちなく過ごしてしまった
		;服従
	ELSEIF TALENT:服従
		PRINTFORMW 影狼の元を訪ねると、空を見上げている彼女を見上げた
		PRINTFORMW 「あっ…」
		PRINTFORMW あなたと目が合うと小さく声を漏らし、ふいと顔を反らしてしまった
		PRINTFORMW 何か怒らせることをしただろうか、それとも前回の事を根に持っているのだろうか
		PRINTFORMW チラッと様子を見るとこちらから顔を反らしたままで顔色もうかがえない
		PRINTFORMW 悩んだままでは仕方ない、怒っているならば理由を聞かなくては
		PRINTFORMW そう思って影狼に声をかけようとしたとき、彼女がくるっとこちらを向き直った
		PRINTFORMW 「えっと…い、いらっしゃいませ、ご主人様」
		PRINTFORMW いつもと変わらないその言葉に面食らってしまい、しどろもどろに返事を返す
		PRINTFORMW どうやら怒ってはいない様だがいつもよりも顔が赤いように感じた
		PRINTFORMW その後表面上はいつも通りに振る舞おうとする彼女を意識してしまい
		PRINTFORMW お互いにいつもよりもぎこちなく過ごしてしまった
		;それ以外
	ELSE
		PRINTFORMW 影狼の元を訪ねると、空を見上げている彼女を見上げた
		PRINTFORMW 「あっ…」
		PRINTFORMW あなたと目が合うと小さく声を漏らし、ふいと顔を反らしてしまった
		PRINTFORMW 何か怒らせることをしただろうか、それとも前回の事を根に持っているのだろうか
		PRINTFORMW チラッと様子を見るとこちらから顔を反らしたままで顔色もうかがえない
		PRINTFORMW 悩んだままでは仕方ない、怒っているならば理由を聞かなくては
		PRINTFORMW そう思って影狼に声をかけようとしたとき、彼女がくるっとこちらを向き直った
		PRINTFORMW 「えっと…い、いらっしゃい、%ANAME(MASTER)%」
		PRINTFORMW いつもと変わらないその言葉に面食らってしまい、しどろもどろに返事を返す
		PRINTFORMW どうやら怒ってはいない様だがいつもよりも顔が赤いように感じた
		PRINTFORMW その後表面上はいつも通りに振る舞おうとする彼女を意識してしまい
		PRINTFORMW お互いにいつもよりもぎこちなく過ごしてしまった
	ENDIF
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人 
	CFLAG:200 = 4
		;恋慕
	IF TALENT:恋慕
		PRINTFORMW 「恋人って何すればいいのかしら…」
		PRINTFORMW あなたの隣でポツリと影狼が呟いた
		PRINTFORMW 「こういう付き合いって初めてだから、分からないのよ」
		PRINTFORMW 頬を染め耳を垂らしながらもじもじしながらあなたを見上げてきた
		PRINTFORMW 思わず押し倒したくなる衝動をこらえ、彼女の頭を撫でた
		PRINTFORMW 影狼は目を細めてあなたへ寄りかかってきた
		PRINTFORMW 暫く二人で寄り添いながらゆったりとした時間を過ごした
		;服従
	ELSEIF TALENT:服従
		PRINTFORMW 「恋人って何すればいいのかしら…」
		PRINTFORMW あなたの隣でポツリと影狼が呟いた
		PRINTFORMW 「ご主人様とこんな関係になるなんて思わなかったから…わからないの…」
		PRINTFORMW 頬を染め耳を垂らしながらもじもじしながらあなたを見上げてきた
		PRINTFORMW 思わず押し倒したくなる衝動をこらえ、彼女の頭を撫でた
		PRINTFORMW 影狼は目を細めてあなたへ寄りかかってきた
		PRINTFORMW 暫く二人で寄り添いながらゆったりとした時間を過ごした
		;それ以外
	ELSE
		PRINTFORMW 「恋人って何すればいいのかしら…」
		PRINTFORMW あなたの隣でポツリと影狼が呟いた
		PRINTFORMW 「こういう付き合いって初めてだから、分からないのよ」
		PRINTFORMW 頬を染め耳を垂らしながらもじもじしながらあなたを見上げてきた
		PRINTFORMW 思わず押し倒したくなる衝動をこらえ、彼女の頭を撫でた
		PRINTFORMW 影狼は目を細めてあなたへ寄りかかってきた
		PRINTFORMW 暫く二人で寄り添いながらゆったりとした時間を過ごした
	ENDIF
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
		;恋慕
	IF TALENT:恋慕
		PRINTFORMW 「………」
		PRINTFORMW 影狼の屋敷を訪ねると、何やら上の空の影狼を見つけた
		PRINTFORMW 「あっ、%ANAME(MASTER)%！」
		PRINTFORMW こちらを見つけるとはねる様にパッと立ち上がった
		PRINTFORMW 「そ、そろそろ来るころかと思ってたわ、えーっと、今日は何をするんだっけ？」
		PRINTFORMW 「そうそう、仕事の話だっけ？いや、それはこの前終わったわね、えーっと…」
		PRINTFORMW 何やら焦った様子で、あたふたとしながらまくし立ててきた
		PRINTFORMW 彼女の手を取り、そんなに慌ててどうかしたのかと尋ねた
		PRINTFORMW 「ど、どうかしたかって…うぅ…前に…し、したじゃない…」
		PRINTFORMW 顔を覗き込むと顔を真っ赤にしながらゴニョゴニョと俯いてしまった
		;服従
	ELSEIF TALENT:服従
		PRINTFORMW 「………」
		PRINTFORMW 影狼の屋敷を訪ねると、何やら上の空の影狼を見つけた
		PRINTFORMW 「あっ、%ANAME(MASTER)%！」
		PRINTFORMW こちらを見つけるとはねる様にパッと立ち上がった
		PRINTFORMW 「そ、そろそろ来るころかと思ってたわ、えーっと、今日は何をするんだっけ？」
		PRINTFORMW 「そうそう、仕事の話だっけ？いや、それはこの前終わったわね、えーっと…」
```
