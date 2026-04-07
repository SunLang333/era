# 口上/152 潤美口上/KOJO_A_K152.ERB — 自动生成文档

源文件: `ERB/口上/152 潤美口上/KOJO_A_K152.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K152, KOJO_TRAIN_END_A1_K152, KOJO_TRAIN_START_A2_K152, KOJO_TRAIN_END_A2_K152, KOJO_COM_BEFORE_TARGET_A_K152, KOJO_COM_BEFORE_PLAYER_A_K152, KOJO_COM_A_K152, KOJO_COM_TARGET_A_K152, KOJO_COM_PLAYER_A_K152, KOJO_COM_AFTER_A_K152, SEX_VOICEK152_00, SEX_VOICEK152_01, SEX_VOICEK152_02, SEX_VOICEK152_03, SEX_VOICEK152_04, SEX_VOICEK152_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K152
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
			PRINTFORML 捕虜を軟禁している部屋へ%ANAME(MASTER)%が赴くと、そこに彼女はいた
			PRINTFORMW 水着のような服装に白黒二色に分かれた髪色、そして立派な角と豊満な肉体…
			PRINTFORML 「…さっきから何処を見ている？　私に何か用か？」
			SETCOLOR 0x4d3d3d
			PRINTL 
			PRINTFORML ―――――　古代魚の子連れ番人　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR 
			PRINTFORML ついつい邪な視線を向けてしまっていたようだ。%ANAME(MASTER)%は咳払いをして、改めて挨拶をした
			PRINTFORMW 「ふむ、%ANAME(MASTER)%というのか。私は牛鬼の%NAME_FORMAL(TARGET)%だ。鬼じゃなくて牛鬼だぞ？」
			PRINTL
			;勢力に所属している
			IF  CFLAG:所属 != 0
				PRINTFORML 「普段は三途の河で漁をしている者なんだが、最近は乱世の影響か死神の往来が増えて漁がやり難くなってね…」
				PRINTFORMW 「おかげで本業をしばらく止めなきゃならなくなって…、こんな戦争の真似事ついでにこうなったってわけさ」
			;勢力に未所属
			ELSE
				PRINTFORML 「本業は漁師でね。普段は三途の河で漁をしているんだが、最近死神の往来が増えて仕事に支障が出るようになってな…」
				PRINTFORMW 「どうしたもんかねぇ…と思っていたところさ。幻想郷の川は河童とかが口うるさくてね」
			ENDIF
			PRINTL
			PRINTFORML %ANAME(TARGET)%はシニカルな様子で肩をすくめる
			PRINTFORMW 牛鬼と言えばかなりの大妖怪なはずだが、彼女からはそういった大妖怪特有の威圧感は無く、落ち着いた雰囲気を纏っている
			PRINTL 
			PRINTFORML 「まあ、一応は感謝してるんだよ。牢屋に繋がれてたっておかしくなかったわけだしね」
			PRINTFORMW 「…それで、どういう話をしに来たんだい？　言っとくけど、私には大したことは出来ないよ」
		;それ以外
		ELSE
			PRINTFORML %ANAME(MASTER)%が出歩いていると、普段見かけない妖怪を見かけた
			PRINTFORMW 水着のような服と豊満な肉体に目を奪われるも、すぐ異質な部分に気付く。立派な角に足元の鎖……まさか鬼！？
			PRINTFORML 「…さっきから何を見ている？　私に何か用か？」
			SETCOLOR 0x4d3d3d
			PRINTL 
			PRINTFORML ―――――　古代魚の子連れ番人　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR 
			PRINTFORML 「ああ、見慣れない奴がいて気になったのか？」
			PRINTFORMW 「私は牛鬼の%NAME_FORMAL(TARGET)%だ。鬼じゃなくて牛鬼だぞ？」
			PRINTL
			;勢力に所属している
			IF  CFLAG:所属 != 0
				PRINTFORML 「普段は三途の河で漁をしているんだが、最近は乱世の影響か死神の往来が増えて漁がやり難くなってね…」
				PRINTFORMW 「おかげで本業をしばらく止めなきゃならなくなって、こんな戦争の真似事してるってわけさ」
			;勢力に未所属
			ELSE
				PRINTFORML 「本業は漁師でね。普段は三途の河で漁をしてたんだが、最近死神の往来が増えて仕事に支障が出るようになってな…」
				PRINTFORMW 「どうしたもんかねぇ…と思っていたところさ。幻想郷の川は河童とかが口うるさくてね」
			ENDIF
			PRINTL
			PRINTFORML %ANAME(TARGET)%はシニカルな様子で肩をすくめる
			PRINTFORMW 牛鬼と言えばかなりの大妖怪なはずだが、彼女からはそういった大妖怪特有の威圧感は無く、落ち着いた雰囲気を纏っている
			PRINTL 
			PRINTFORML 「まあ、分別はあるつもりだよ。誰彼構わず襲ったりとかは控えてるさ」
			PRINTFORMW 「…で？　私の方ばかりじゃなくて、そろそろお前さんの名前とかも聞かせてくれて良いんじゃないかね？」
		ENDIF
		PRINTFORML
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 捕虜を軟禁している部屋へ%ANAME(MASTER)%が赴くと、そこに彼女はいた
			PRINTFORMW 水着のような服装に白黒二色に分かれたの髪色、そして立派な角と豊満な肉体。彼女は確か…
			PRINTFORML 「…ん？　あんた…確か、%ANAME(MASTER)%だったか。私に何か用か？」
			SETCOLOR 0x4d3d3d
			PRINTL 
			PRINTFORML ―――――　古代魚の子連れ番人　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR 
			PRINTFORML 彼女が%ANAME(MASTER)%に話しかける。やはり間違いない。牛鬼の%ANAME(TARGET)%だ
			PRINTFORML 「…こんなトコで知り合いに会うとはね。その様子だと、説得でもしに来たのかい？」
			PRINTL
			;勢力に所属している
			IF  CFLAG:所属 != 0
				PRINTFORML ― 分かっているなら話は早い。是非とも我が軍に力を貸して欲しい。そうすれば丁重な扱いを保障する ―　そう伝えた
				PRINTFORMW 「うーん…言い分は分かるけどね…。私にも立場ってもんがあるからねぇ……」
			;勢力に未所属
			ELSE
				PRINTFORML ― 分かっているなら話は早い。その実力を活かさないのはもったいない。是非とも力を貸して欲しい ―　そう伝えた
				PRINTFORMW 「うーん…力を買ってくれてるのは嬉しいけどね…。そもそも本業は漁師だしなぁ……」
			ENDIF
			PRINTFORML 「一応、感謝はしてるんだよ？　牢屋に繋がれてたっておかしくないわけだしね。でもそれとこれとは話がな…」
			PRINTL
			PRINTFORML %ANAME(TARGET)%は腕を組んで天井を見上げる。随分悩んでいるようだ
			PRINTFORMW まあ、すぐに答えが出るとはこちらも思っていない。%ANAME(MASTER)%は気長に彼女と交流し、説得することにした…
		;それ以外
		ELSE
			PRINTFORML %ANAME(MASTER)%が出歩いていると、一人の女性が目に止まった
			PRINTFORMW 水着のような服装に白黒二色に分かれた髪色、そして立派な角と豊満な肉体。あれは確か…
			PRINTFORML 「…ん？　あんた…確か、%ANAME(MASTER)%だったか。私に何か用か？」
			SETCOLOR 0x4d3d3d
			PRINTL 
			PRINTFORML ―――――　古代魚の子連れ番人　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR 
			PRINTFORML 彼女が%ANAME(MASTER)%に話しかける。やはり間違いない。牛鬼の%ANAME(TARGET)%だ
			PRINTFORML 「また会うとはね。元気してたかい？」
			PRINTL
			PRINTFORMW 「こっちは本業の漁がやり辛くなってきてね。乱世の影響か、死神が大忙しでやたら三途の河の往来が激しくなってな…」
			;勢力に所属している
			IF  CFLAG:所属 != 0
				PRINTFORMW 「おかげさまで暇だから、こんな戦争ごっこまがいなことしてるってわけさ。そっちはどうだい？」
			;勢力に未所属
			ELSE
				PRINTFORMW 「幻想郷の川は河童とかが口うるさくて面倒だからね。いっそどこかで雇ってもらおうか…と悩んでるところさ」
			ENDIF
			PRINTL
			PRINTFORML %ANAME(TARGET)%はシニカルな様子で肩をすくめる
			PRINTFORMW 牛鬼と言えばかなりの大妖怪なはずだが、彼女からはそういった大妖怪特有の威圧感は無く、落ち着いた雰囲気を纏っている
			PRINTL 
			PRINTFORML 「まあ、ここで会ったのも何かの縁だ。ちょうど暇してたし世間話でもしようじゃないか」
			PRINTFORMW 「なに。牛鬼だからって、別に獲って喰ったりはしないから安心おし」
		ENDIF
		PRINTL
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------

;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTL
	;恋慕時
	IF TALENT:恋慕
		PRINTFORML 「あ、%ANAME(MASTER)%っ。はは、来てくれたんだねぇ。今か今かと待ってたところだよ」
		PRINTFORML 手を振って%ANAME(MASTER)%を出迎える%ANAME(TARGET)%。その表情は明るい
		PRINTFORMW 「ん？　何だか機嫌良さそうだって？　そりゃあ、イイ人が来てくれたんだ。嬉しくもなるってものさ♥」
		PRINTFORML %ANAME(TARGET)%は笑いながら%ANAME(MASTER)%に抱きつき、服越しに豊満な胸をぐいぐい押し当てる
		PRINTFORMW 「だからこういうことだってしちゃうのさ♪　ほらほらどんな気分だい？　教えておくれよ…ふふっ♥」
	;それ以外
	ELSE
		PRINTFORML 「あ、ああ、おはよう%ANAME(MASTER)%……。ま、前の夜のことはその…言いふらさないでおくれよ…？」
		PRINTFORMW %ANAME(TARGET)%は頬を赤らめ、困った様子で%ANAME(MASTER)%に念を押した
	ENDIF
	PRINTL

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTL
	PRINTFORML 「やあ%ANAME(MASTER)%。おはよう」
	PRINTFORMW 「…はは、恋人らしい挨拶って中々思いつかないもんだねぇ」
	;恋慕時
	IF TALENT:恋慕
		PRINTFORML %ANAME(TARGET)%は朗らかに笑いながら%ANAME(MASTER)%と腕を絡ませる。その際に、彼女の大きな乳房の柔らかさが伝わる…
		PRINTFORMW 「くすっ…、言葉よりこういうやり方のほうが嬉しいんじゃないか？　お前さんには…♥」
	ENDIF
	PRINTL

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTL
	PRINTFORML 「おお、%ANAME(MASTER)%。おはようさん」
	PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%に唇を許したことをさして気にしていないようだ…
	PRINTL

;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTL
	PRINTFORML 「…はぁ、またこんな気持ちになるなんてね。まったくいつ以来だろうかね…」
	PRINTFORML %ANAME(TARGET)%は溜め息をつきながら%ANAME(MASTER)%のことを見つめている。心なしか頬が赤いような…
	PRINTFORMW 「……ん？　い、いや、何でもないよ、コッチの話さ。さあ、今日は何するんだい？」
	PRINTL

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;親愛か隷属
ELSEIF TALENT:親愛 || TALENT:隷属
	SELECTCASE RAND:5
		CASE 0
			PRINTFORML 「おお、%ANAME(MASTER)%。おはようさん♥　今日も良い天気だねぇ…」
			PRINTFORMW %ANAME(TARGET)%は朗らかな表情で%ANAME(MASTER)%を出迎えてくれた
```
