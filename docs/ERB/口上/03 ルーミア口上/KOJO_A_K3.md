# 口上/03 ルーミア口上/KOJO_A_K3.ERB — 自动生成文档

源文件: `ERB/口上/03 ルーミア口上/KOJO_A_K3.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K3, KOJO_TRAIN_END_A1_K3, KOJO_TRAIN_START_A2_K3, KOJO_TRAIN_END_A2_K3, KOJO_COM_BEFORE_TARGET_A_K3, KOJO_COM_BEFORE_PLAYER_A_K3, KOJO_COM_A_K3, KOJO_COM_TARGET_A_K3, KOJO_COM_PLAYER_A_K3, KOJO_COM_AFTER_A_K3, SEX_VOICE03_00, SEX_VOICE03_01, SEX_VOICE03_02, SEX_VOICE03_03, SEX_VOICE03_04; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K3

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
	PRINTFORML
	;初対面の場合
	IF !CFLAG:17
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML %ANAME(MASTER)%が捕虜の部屋を訪れると、その部屋の隅に黒い玉が浮かんでいた
			PRINTFORML 「んー？　誰か入ってきたのー？」
			PRINTFORMW 声を上げた黒い球体は霧散した。そしてその中から、一人の少女が姿を現した
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　暗闇に潜む妖怪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　宵闇の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女が、妖怪%ANAME(TARGET)%。噂では闇を操る力を持つと聞く
			PRINTFORMW 『闇を操る力』、何とも男心をくすぐられる言葉だ。一体どんな妖怪なのかと訪ねてみたが…
			PRINTFORML 「……？　どちらさん？」
			PRINTFORMW 初対面の%ANAME(MASTER)%を訝しみながら%ANAME(TARGET)%は尋ねる
			PRINTFORML …幻想郷の妖怪は大体少女の姿をしているから、外見で力を判断するのは早計だが……正直弱そうというかオーラがないな…
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW ちょっと失礼なことを考えつつ、%ANAME(MASTER)%は『乱世を治めるため、我が軍に協力して欲しい』と%ANAME(TARGET)%に伝えた
				PRINTFORML 「うーん、いきなりそんなこと言われてもなー」
				PRINTFORMW 「そもそも、私って弱っちいからあんまり力になれないと思うよ？」
			;それ以外
			ELSE
				PRINTFORMW ちょっと失礼なことを考えつつ、%ANAME(MASTER)%は『乱世を治めるため、我が軍に協力して欲しい』と%ANAME(TARGET)%に伝えた
				PRINTFORML 「うーん、いきなりそんなこと言われてもなー」
				PRINTFORMW 「そもそも、私って弱っちいからあんまり力になれないと思うよ？」
			ENDIF
			PRINTFORML …やっぱりか。しかしせっかく出来た縁は大切にするべきだろう
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%と交流を始めた
		;それ以外
		ELSE
			PRINTFORML %ANAME(MASTER)%がとある妖怪を訪ねたところ、空に奇妙な黒い玉のような物が浮いているのを見つけた
			PRINTFORMW …何だろうとしばらく眺めていると、ふわふわと浮いているソレはやがて木にぶつかった
			PRINTFORML 「あいたっ！　え？　なに？」
			PRINTFORMW 黒い球体は痛みの声を上げて霧散した。そしてその中から、一人の少女が姿を現した
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　暗闇に潜む妖怪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　宵闇の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女が目的の妖怪、%ANAME(TARGET)%。噂では闇を操る力を持つと聞く
			PRINTFORMW 『闇を操る力』、何とも男心をくすぐられる言葉だ。一体どんな妖怪なのかと訪ねてみたが…
			PRINTFORML 「んん？　どちらさん？」
			PRINTFORMW ぶつけた頭をさすりながら%ANAME(TARGET)%は尋ねる
			PRINTFORML …幻想郷の妖怪は大体少女の姿をしているから、外見で力を判断するのは早計だが……正直弱そうというかオーラがないな…
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW ちょっと失礼なことを考えつつ、%ANAME(MASTER)%は『乱世を治めるため、協力しに来た』と%ANAME(TARGET)%に伝えた
				PRINTFORML 「おー、やったー。それじゃあこれからよろしくねー」
				PRINTFORMW 「あーそれと、私って弱っちいから頑張ってくれないとすぐ滅んじゃうと思うよ？」
				PRINTFORML ……我が君主はだいぶ弱気と言うか見栄を張らない性格のようだ
			;それ以外
			ELSE
				PRINTFORMW ちょっと失礼なことを考えつつ、%ANAME(MASTER)%は『乱世を治めるため、我が軍に協力して欲しい』と%ANAME(TARGET)%に伝えた
				PRINTFORML 「うーん、いきなりそんなこと言われてもなー」
				PRINTFORMW 「そもそも、私って弱っちいからあんまり力になれないと思うよ？」
				PRINTFORML …やっぱりか。しかしせっかく出来た縁は大切にするべきだろう
			ENDIF
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%と交流を始めた
		ENDIF
		PRINTFORML
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML %ANAME(MASTER)%が捕虜の部屋を訪れると、その部屋の隅に黒い玉が浮かんでいた
			PRINTFORML 「んー？　誰か入ってきたのー？」
			PRINTFORMW 声を上げた黒い球体は霧散した。そしてその中から、一人の少女が姿を現した
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　暗闇に潜む妖怪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　宵闇の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女が妖怪、%ANAME(TARGET)%。たしか、闇を操る力を持つと聞いている
			PRINTFORMW 『闇を操る力』。何とも男心をくすぐられる言葉だ。実物を見るまでは大妖怪を想像していたものだ…
			PRINTFORML 「あー、なんか見覚えあるような…たしか、%ANAME(MASTER)%だっけ？」
			PRINTFORMW うろ覚えな様子で首をかしげながら%ANAME(TARGET)%が尋ねる
			PRINTFORML …前に見かけたときも思ったけど、相変わらず弱そうというか…、少なくとも強そうではないな…
			PRINTFORMW ちょっと失礼なことを考えつつ、%ANAME(MASTER)%は『乱世を治めるため、我が軍に協力してくれないか』と%ANAME(TARGET)%に伝えた
			PRINTFORML 「うーん、いきなりそんなこと言われてもなー」
			PRINTFORMW 「そもそも、私って弱っちいからあんまり力になれないと思うよ？」
			PRINTFORML …やっぱりか。しかしせっかく出来た縁は大切にするべきだろう
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%と交流を始めた
		;それ以外
		ELSE
			PRINTFORML %ANAME(MASTER)%がとある妖怪を訪ねたところ、空に奇妙な黒い玉のような物が浮いているのを見つけた
			PRINTFORMW …何だろうとしばらく眺めていると、ふわふわと浮いているソレはやがて木にぶつかった
			PRINTFORML 「あいたっ！　え？　なに？」
			PRINTFORMW 黒い球体は痛みの声を上げて霧散した。そして一人の少女が姿を現した
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　暗闇に潜む妖怪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　宵闇の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女が目的の妖怪、%ANAME(TARGET)%。たしか、闇を操る力を持つと聞いている
			PRINTFORMW 『闇を操る力』、何とも男心をくすぐられる言葉だ。実物を見るまでは大妖怪を想像していたものだ…
			PRINTFORML 「んー？　貴方、どっかで見たことあるような…」
			PRINTFORMW ぶつけた頭をさすりながら%ANAME(TARGET)%は尋ねる
			PRINTFORML …前に見かけたときも思ったけど、相変わらず弱そうというか…、少なくとも強そうではないな…
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW ちょっと失礼なことを考えつつ、%ANAME(MASTER)%は「これから使える君主に挨拶に…」と%ANAME(TARGET)%に伝えた
				PRINTFORML 「あー、それはどうもご丁寧に。これからよろしくねー」
				PRINTFORMW 「ちなみに言っとくけど、私って弱っちいからホントに頑張ってくれないとすぐ滅んじゃうからね？　多分」
				PRINTFORML ……我が君主はだいぶ弱気と言うか見栄を張らない性格のようだ
			;それ以外
			ELSE
				PRINTFORMW ちょっと失礼なことを考えつつ、%ANAME(MASTER)%は「これからよろしく」と%ANAME(TARGET)%に改めて挨拶した
				PRINTFORML 「へー、そうなのかー」
				PRINTFORMW 「でもぶっちゃけ、私って弱いからあんまり力になれないと思うよー？」
				PRINTFORML …やっぱりか。しかしせっかく出来た縁は大切にするべきだろう
			ENDIF
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%と交流を始めた
		ENDIF
		PRINTFORML
	ENDIF


;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻か妾
ELSEIF CFLAG:200 < 7 && (TALENT:正妻 || TALENT:妾)
	CFLAG:200 = 7;婚姻した次の回フラグ
	PRINTFORML
	PRINTFORML ……朝というにはまだ薄暗い中、%ANAME(MASTER)%は妙な温かさを感じて目を覚ました
	PRINTFORMW 布団をめくってみると、%ANAME(TARGET)%が%ANAME(MASTER)%の体に抱きつきながら眠っていた
	PRINTFORML 隣で眠っていたはずなのにいつの間にこうなっていたのだろうか…
	PRINTFORML 「むにゃ……%ANAME(MASTER)%……すぅ…」
	PRINTFORMW 起こそうかとも思ったが、こんな幸せそうな寝顔で眠る彼女を起こしてしまうのも可哀想だ…
	PRINTFORML %ANAME(MASTER)%は%ANAME(TARGET)%の頭を優しく撫でながら二度寝することにした
	PRINTFORMW 「すぅ……んん……%ANAME(MASTER)%…大好きぃ♥……むにゃ……」
	PRINTFORML %ANAME(TARGET)%の可愛い寝言を聞きながら、%ANAME(MASTER)%は再び眠りにつく…
	PRINTFORMW ……結局昼過ぎまで、二人揃ってたっぷり寝過ごしてしまった……
	PRINTFORML
	TFLAG:55 += 2;時間経過

;親愛か隷属
ELSEIF CFLAG:200 < 6 && (TALENT:親愛 || TALENT:隷属)
	CFLAG:200 = 6;親愛か隷属になった次の回フラグ
	PRINTFORML
	PRINTFORML ……カリ…カリカリ……
	PRINTFORML 朝早く、%ANAME(MASTER)%は自分の部屋から聞こえる、扉を引っかくような音で目が覚めた
	PRINTFORMW 何の音かと見てみれば、扉の外には寂しそうな顔をした%ANAME(TARGET)%がいた
	PRINTFORM 「あ、%ANAME(MASTER)%！　おはよう！　
	PRINTL ……てへへー///」
	PRINTFORMW どうやら%ANAME(MASTER)%に会いたくて来たはいいものの、鍵が掛かっていたので部屋まで入れなかったようだ
	PRINTFORML 猫じゃあるまいし…とは思ったが、これからも同じように寂しい思いをさせるといけないので
	PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に合鍵を渡した。これで締め出されるようなことは無いだろう
	PRINTFORML 「やったー♪　えへへ、早起きした甲斐があったなー♪」
	PRINTFORMW 上機嫌になった%ANAME(TARGET)%は、%ANAME(MASTER)%に甘えるように抱きついてきた
	PRINTFORML

;既成事実Lv3(初めてセックスをした次の回)＆恋慕持ち
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORML
	IF TALENT:恋慕
		PRINTFORML 今日も%ANAME(TARGET)%の所へ向かうと、珍しく闇を纏わずそのままの姿で%ANAME(TARGET)%が待っていた
		PRINTFORML 「あ、%ANAME(MASTER)%！　……せ、先日はその…ごちそうさまでした…」
		PRINTFORMW %ANAME(TARGET)%は先日の行為のためか顔を赤くしていたが、穏やかな表情で%ANAME(MASTER)%を見つめている
		PRINTFORML ……そういえば今日はいつもと違って闇を纏っていない。何故だろうか
		PRINTFORML 「え？　なんでこのまんまで待ってたかって？」
		PRINTFORMW 「えーと、その…、今日は何か…、ちょっとでも早く%ANAME(MASTER)%に会いたいなって思って…♥」
		PRINTFORML %ANAME(TARGET)%は肌荒れがどうのとかで日差しに当たるのを嫌っている
		PRINTFORMW そんな彼女が、それを厭わず%ANAME(MASTER)%に会えるのを待っていたという
```
