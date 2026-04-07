# 口上/134 ドレミー口上/KOJO_A_K134.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/KOJO_A_K134.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K134, KOJO_TRAIN_END_A1_K134, KOJO_TRAIN_START_A2_K134, KOJO_TRAIN_END_A2_K134, KOJO_COM_BEFORE_TARGET_A_K134, KOJO_COM_BEFORE_PLAYER_A_K134, KOJO_COM_A_K134, KOJO_COM_TARGET_A_K134, KOJO_COM_PLAYER_A_K134, KOJO_COM_AFTER_A_K134; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K134

#DIM ドレミ
ドレミ = NAME_TO_CHARA("ドレミー")

;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ || CFLAG:400 == 1
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		PRINTFORML %ANAME(TARGET)%の元を訪れると、サンタ帽を被った青髪でショートヘアーの女性が居た
		PRINTFORML 部屋の主が%ANAME(MASTER)%に気付くと声を掛けてくる
		PRINTFORML 「誰かと思いきや噂の%ANAME(MASTER)%じゃないの」
		PRINTFORML 「現し世で会うのは初めてかしら？」
		PRINTFORML 黒いポンチョと白黒の玉房状の飾り（ポンポン）が沢山ついているエプロンつきの服を着た女性が近づいてくる
		PRINTFORML 「私は獏（バク）夢の世界の住人です」
		PRINTFORMW 「今は現し世だから生身ですけどもね」
		PRINTFORML 
		PRINTFORML 自己紹介をする%ANAME(MASTER)%に%ANAME(TARGET)%が続けてしゃべり続ける
		PRINTFORML 「ところで最近は随分と寝不足のようですね」
		PRINTFORMW 「寝る寝ないの自由に口を出すつもりはありませんが寝不足は体に毒ですよ」
		PRINTFORML 
		PRINTFORMW 「ははぁん…もしや私に見られたくない夢でも？」
		PRINTFORML 
		PRINTFORML 「んー？違ったの？…まあどうでも良いわね」
		PRINTFORML 「これからは現し世で行動を共にする身。宜しく」
		PRINTFORMW そう言うと、%ANAME(TARGET)%は手を差し伸べてきた
		PRINTFORML 
		PRINTFORML 夢の世界を含め混乱を極めた現状、彼女は混乱しつつある全ての夢を再度監視する為に貴方と手を組む
		PRINTFORML 確かにこれから乱世を統治するうえで夢の世界も例外ではない、彼女とは利害が一致するようだ
		PRINTFORML %ANAME(MASTER)%は差し出された手を握り返した
		PRINTFORMW 「それとお一つお耳に入れたいことが…」
		PRINTFORML 
		PRINTFORML そこで突如ぐいと手を引っ張られ、お互いの顔に息が掛かりそうな程に顔を引き寄せられる
		PRINTFORML 「ただし…、下手な事をすれば貴方の夢におけるプライバシーは保障しませんよ」
		PRINTFORML %ANAME(TARGET)%はこちら側をニタァと見るジト目のような目、逆三角形の口からなるどや顔の様なしたり顔の様な何とも言えない表情で若干の脅しをかけてきた
		PRINTFORMW 
	;既に会ったことがある場合
	ELSE
		;捕虜調教の末仕官
		IF TALENT:烙印
			IF TALENT:服従
				PRINTFORML 「…！」
				PRINTFORML %ANAME(MASTER)%の姿を認めた瞬間、調教の記憶が脳裏に過ったのか%ANAME(TARGET)%の表情が大きく引き攣った
				PRINTFORML 「…一体どういう風の吹き回し？」
				PRINTFORML %ANAME(TARGET)%の態度は頑な態度を崩そうとしない
				PRINTFORML しかしよく見ると、%ANAME(TARGET)%の指は無意識のうちに烙印をなぞっている
				PRINTFORML どうやら先の調教の成果はしっかりと%ANAME(TARGET)%に刻み込まれているようだ
				PRINTFORMW %ANAME(MASTER)%はより深く彼女の心を絡め取るべく暫く行動を共にすることにした……
			ELSE
				PRINTFORML 「…！」
				PRINTFORML %ANAME(MASTER)%の姿を認めた瞬間、調教の記憶が脳裏に過ったのか%ANAME(TARGET)%の表情が大きく引き攣った
				PRINTFORML 「どうやら今度は私が悪夢を見せられているようね」
				PRINTFORML 「たしかにあの時、私はその悪夢に屈した」
				PRINTFORML 「でも、貴方の吉夢はいつか終わり悪夢へと変わる」
				PRINTFORMW そう苦々しげに吐き捨てると、%ANAME(TARGET)%はそっぽを向いた
				PRINTFORML 
				PRINTFORML %ANAME(TARGET)%の態度は頑なだ
				PRINTFORMW ここから良好な関係を築くにはなかなか手間が掛かりそうだ……
			ENDIF
		;夜這いなどで服従のみ
		ELSEIF TALENT:服従
			PRINTFORML 「…！」
			PRINTFORML %ANAME(MASTER)%の姿を認めた瞬間、調教の記憶が脳裏に過ったのか%ANAME(TARGET)%の表情が大きく引き攣った
			PRINTFORML 「…一体どういう風の吹き回し？」
			PRINTFORML %ANAME(TARGET)%の態度は頑な態度を崩そうとしない
			PRINTFORML しかしよく見ると、%ANAME(TARGET)%の目は泳ぎ、こちらの一挙一動の度微かに肩を震わせている
			PRINTFORML どうやら先の調教の成果はしっかりと%ANAME(TARGET)%に刻み込まれているようだ
			PRINTFORMW %ANAME(MASTER)%はより深く彼女の心を絡め取るべく暫く行動を共にすることにした……
		ELSE
			PRINTFORML 「……誰かと思えば貴方ですか」
			PRINTFORML 「私の力が目的？　それとも体が目的かしら？」
			PRINTFORML 「まぁ良いわ。　これからよろしく……%ANAME(MASTER)%さん」
			PRINTFORML そう言って、%ANAME(TARGET)%は手を差し伸べてきた
			PRINTFORMW
			;かなり嫌われている
			IF CFLAG:3 <= -1000
				PRINTFORMW しかし、言葉とは裏腹に%ANAME(TARGET)%の目は底冷えのする光をたたえている……
			;嫌われている
			ELSEIF CFLAG:3 < 0
				PRINTFORMW しかし、%ANAME(TARGET)%の目は全く笑っていない……
			;好かれている
			ELSEIF CFLAG:3 >= 1000
				PRINTFORMW %ANAME(MASTER)%は差し出された手をにこやかに握り返した……
			;普通
			ELSE
				PRINTFORMW %ANAME(MASTER)%は差し出された手をがっしりと握り返した……
			ENDIF
		ENDIF
	ENDIF
;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;初めて泥酔行きずりセックス
ELSEIF CFLAG:350 == 1
	PRINTFORML 「おやおや…」
	PRINTFORML %ANAME(TARGET)%の元を訪れた%ANAME(MASTER)%は、なにやら神妙な顔で出迎えられた
	PRINTFORML %ANAME(TARGET)%はDとだけ書かれた表紙の本を読んでいる
	PRINTFORML 「前回会った日のこと…、貴方は覚えているかしら？」
	PRINTFORMW %ANAME(TARGET)%が真一文字に結んだ口を開いた
	PRINTFORML 
	PRINTFORML  前回…、それはやはり酔い潰れた%ANAME(TARGET)%と一夜を過ごした日のことだろうか…
	PRINTFORMW  こちらの表情から何かを読み取ったのか、%ANAME(TARGET)%の表情が変わった
	PRINTFORML 
	PRINTFORML 「人を酔わせて情事に持ち込むなんてね」
	PRINTFORML 「ところで貴方は私の事をどうお考えでいるのかしら？」
	PRINTFORMW %ANAME(TARGET)%は本を置いてゆっくりと%ANAME(MASTER)%に近付いてくる
	PRINTFORML 
	PRINTFORML じりじりと近づいてくる%ANAME(TARGET)%に%ANAME(MASTER)%は咄嗟に話題をすり替える
	PRINTFORML 何とか%ANAME(TARGET)%の質問をはぐらかす事に成功した
	PRINTFORML しかし、結果として相当に時間を食うことになってしまった
	PRINTFORMW 今日使える時間はもうあまり残っていないだろう……
	PRINTFORML 
	PRINTFORML ………………
	PRINTFORML ……
	PRINTFORMW 
	PRINTFORML 「そうやって白々しい対応をされると少し寂しいものね」
	PRINTFORML 「だから今はこの距離を楽しむ事にしましょう…でもいずれは」
	PRINTFORMW 
	PRINTFORML ………………
	PRINTFORML ……
	PRINTFORMW 
	CFLAG:350 = 2
	TFLAG:55 += 5;時間経過

;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意 && (!TALENT:服従 || !TALENT:烙印)
	CFLAG:200 = 5
	PRINTFORML 「おやおや…？」
	PRINTFORML 「どうなされたのかしら、随分と機嫌がよろしいようね」
	PRINTFORMW 「ははぁん…まさか前の事を勘違いされてるご様子で」
	PRINTFORML
	PRINTFORML 「"一度抱いた女だからチョロイ"だなんて…ねぇ」
	PRINTFORML 「ふーむ図星のようですね」
	PRINTFORML 「残念ながら私は夢の世界の住人、心も夢のように移ろい易いものでしてね」
	PRINTFORML 「さてこれ以上は野暮ったいので言いませんが」
	PRINTFORMW 「…これ以上は貴方には期待していますね」
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人  && (!TALENT:服従 || !TALENT:烙印)
	CFLAG:200 = 4
	PRINTFORML 「さて、晴れて恋人同士ではあるのですが…」
	PRINTFORML 「別にいつもと変わりありませんね」
	PRINTFORMW 「ま、お互い気楽に行きましょう」
;既成事実Lv1(初めてキスをした次の回)
;ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
;	CFLAG:200 = 3
	PRINTFORML 「おやおや、随分とギラついたご様子で」
	PRINTFORML 「まさかキスの一つでここまで舞い上がってしまうとは」
	PRINTFORMW 「これ以上は少々焦らしたくなりますね」
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:恋慕 && (!TALENT:恋人 && !TALENT:合意 && CFLAG:250 < 1)
	CFLAG:200 = 2
	PRINTFORML 「ふーむ、思っていた以上に思い通りにならないものですね」
	PRINTFORMW 「いえ、何もありませんよ」

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;正妻
ELSEIF TALENT:正妻
	IF RAND:3 == 0
		PRINTFORML 「あら、おはよう」
		PRINTFORMW %ANAME(MASTER)%の姿を認めた%ANAME(TARGET)%の表情がパッと輝いた……
	ELSEIF RAND:2 == 0
		PRINTFORML 「アナタ、どうかした？」
		PRINTFORMW %ANAME(TARGET)%は読んでいた本を閉じて%ANAME(MASTER)%に微笑みかけた……
	ELSE
		PRINTFORML 「あら、どうかした？」
		PRINTFORMW %ANAME(TARGET)%は本を読んでいるが尻尾が上下に凄いスピードで跳ねてる
	ENDIF
;服従
ELSEIF TALENT:服従
	PRINTFORML 「貴方ですか、今お茶を入れるで少しお待ちを」
	PRINTFORMW %ANAME(TARGET)%は、読んでいた本を慌てて閉じ接客の準備を始めた……
;烙印
ELSEIF TALENT:烙印
	PRINTFORML 「貴方ですか…。今日は何の用で？」
	PRINTFORMW %ANAME(TARGET)%は、本を閉じて%ANAME(MASTER)%の言葉を待っている……
;既成事実Lv2以上かつ恋慕
ELSEIF TALENT:恋人 || TALENT:合意 && TALENT:恋慕
	IF RAND:3 == 0
		PRINTFORML 「おや、貴方ですか。どうかなされましたか？」
		PRINTFORMW %ANAME(TARGET)%の言葉には親しみが籠められている……
	ELSEIF RAND:2 == 0
		PRINTFORML 「貴方ですか。今日は何のご用で？」
		PRINTFORMW %ANAME(TARGET)%はおどけた様に%ANAME(MASTER)%に微笑みかけた……
```
