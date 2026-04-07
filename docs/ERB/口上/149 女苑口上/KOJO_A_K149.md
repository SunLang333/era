# 口上/149 女苑口上/KOJO_A_K149.ERB — 自动生成文档

源文件: `ERB/口上/149 女苑口上/KOJO_A_K149.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K149, KOJO_TRAIN_END_A1_K149, KOJO_TRAIN_START_A2_K149, KOJO_TRAIN_END_A2_K149, KOJO_COM_BEFORE_TARGET_A_K149, KOJO_COM_BEFORE_PLAYER_A_K149, KOJO_COM_A_K149, KOJO_COM_TARGET_A_K149, KOJO_COM_PLAYER_A_K149, KOJO_COM_AFTER_A_K149, SEX_VOICEK149_00, SEX_VOICEK149_01, SEX_VOICEK149_02, SEX_VOICEK149_03, SEX_VOICEK149_04, SEX_VOICEK149_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K149
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
			PRINTFORML %ANAME(MASTER)%が捕虜の部屋を訪れると、やたら派手な衣装に身を包んだ小柄な少女を見つけた
			PRINTFORML 「あら、お兄さんっ。ずいぶんイケてる感じじゃなーい♪」
			PRINTFORML 「ねえ、私こんな地味な部屋ヤダなー。もっといい所で話さない？　逃げられっこないって、こんな華奢な女の子なんだしー」
			PRINTFORMW ― 君が疫病神の%NAME_FORMAL(TARGET)%かい？ ―　と%ANAME(MASTER)%が問う
			PRINTFORMW 「…なーんだ、アンタも私のこと知ってるクチ？」
			SETCOLOR 0xffaf60
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　最凶最悪の双子の妹　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は正真正銘の疫病神だ。かつてこの幻想郷にて大いなる混乱を招いた最強最悪の姉妹の片割れだ
			PRINTFORML 知らずに付き合っていたら、次第に財の殆どを貢ぎ、巻き上げられたことだったろう…
			PRINTL
			PRINTFORMW 「まったく、知ってて疫病神を捕らえとくとか正気を疑うわー。で？　アンタは何しに来たの？」
			PRINTFORML 正体を知っている%ANAME(MASTER)%に対し、さっきまでのきゃぴきゃぴした感じは鳴りを潜めた
			PRINTFORMW その現金な様に苦笑しつつも、%ANAME(MASTER)%は彼女に我が軍への協力を仰いだ
			PRINTL
			PRINTFORML 「……はあ？　それ疫病神の私に頼むこと？　頭パープリンなの？」
			PRINTFORMW …冷静に考えれば至極もっともな言葉だが、かつて幻想郷で異変を起こした首謀者の手腕は捨てがたいものがあった
			PRINTFORML 「ふーん…。ま、まあそこまで私が必要だって言うなら、…考えてあげなくも無いわ」
			PRINTFORML 軟禁中だというのに不遜な態度は変わらない。腐っても神様ということか
			PRINTL
			PRINTFORML しかし言葉尻こそキツめなものの、彼女の小さな体躯と愛嬌ある身振り手振りを交えた話し方のせいか、あまり不快な印象は無かった
			PRINTFORMW 「それじゃあ、私が下るだけの価値がある相手かどうか、ちゃんと見極めてさせてもらうわね」
		;それ以外
		ELSE
			PRINTFORML 「はいはーい、そこのお兄さんっ。ずいぶんイケてる感じじゃなーい♪」
			PRINTFORMW 「良かったら私と遊んでいかない？　一緒にパァーッとやっちゃおうよー♪」
			PRINTFORML 町を歩いていると、やたら派手な身なりの少女に声を掛けられた。彼女こそ目的の少女で間違いないだろう
			PRINTL
			PRINTFORML ― 君が疫病神の%NAME_FORMAL(TARGET)%かい？ ―　と%ANAME(MASTER)%が問う
			PRINTFORMW 「…なーんだ、アンタも私のこと知ってるクチ？」
			SETCOLOR 0xffaf60
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　最凶最悪の双子の妹　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は正真正銘の疫病神だ。かつてこの幻想郷にて大いなる混乱を招いた最強最悪の姉妹の片割れだ
			PRINTFORML 知らずに付き合っていたら、次第に財の殆どを貢ぎ、巻き上げられたことだったろう…
			PRINTL
			PRINTFORMW 「アレ以来、妙に顔が知られてやり難くなったわー。で？　アンタは私に何の用？」
			PRINTFORML %ANAME(MASTER)%がカモでないと分かり、さっきまでのきゃぴきゃぴした感じは鳴りを潜めた
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW その現金な様に苦笑しつつも、%ANAME(MASTER)%は君主である彼女に挨拶に来ました　と伝えた
				PRINTL
				PRINTFORML 「…はあ？　わざわざ挨拶のために疫病神の私に会いに来たって？　アンタずいぶん度胸あるわね。それとも私のこと舐めてる？」
				PRINTFORMW …冷静に考えれば至極もっともな言葉だが、一応は君主であり神様でもある彼女に挨拶もなしというはちと罰当たりなことだろう
				PRINTFORML 「ふーん…。（…まあ疫病神だって知っててそれでも来てくれるってのも悪い気はしないわね）……よし」
				PRINTFORMW 「まあいいわ。アンタのことちゃんと使ってあげる。精々死なない程度には頑張りなさいよ？」
			;それ以外
			ELSE
				PRINTFORMW その現金な様に苦笑しつつも、%ANAME(MASTER)%は彼女に幻想郷を治めるための協力を仰いだ
				PRINTL
				PRINTFORML 「……はあ？　それ疫病神の私に頼むこと？　頭パープリンなの？」
				PRINTFORMW …冷静に考えれば至極もっともな言葉だが、かつて幻想郷で異変を起こした首謀者の手腕は捨てがたいものがあった
				PRINTFORML 「ふーん…。（ま、まあ疫病神だって知っててそれでも頼ってくれるってのも悪い気しないわね）……よし」
				PRINTFORMW 「それじゃあ、私が手を貸すだけの価値がある相手かどうか、ちゃんと見極めてさせてもらうわね」
			ENDIF
		ENDIF
		PRINTFORML
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML %ANAME(MASTER)%が捕虜の部屋を訪れると、やたら派手な衣装に身を包んだ小柄な少女を見つけた
			PRINTFORMW 「…なんだ、アンタか。何の用？　差し入れ？」
			SETCOLOR 0xffaf60
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　最凶最悪の双子の妹　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は正真正銘の疫病神だ。かつてこの幻想郷にて大いなる混乱を招いた最強最悪の姉妹の片割れだ
			PRINTFORML 知らずに付き合っていたら、次第に財の殆どを貢ぎ、巻き上げられたことだったろう…
			PRINTL
			PRINTFORMW 「疫病神を捕らえとくとか正気を疑うわー。で？　アンタは何しに来たの？」
			PRINTFORML 正体を知っている%ANAME(MASTER)%に対し、さっきまでのきゃぴきゃぴした感じは鳴りを潜めた
			PRINTFORMW その現金な様に苦笑しつつも、%ANAME(MASTER)%は彼女に我が軍への協力を仰いだ
			PRINTL
			PRINTFORML 「……はあ？　それ疫病神の私に頼むこと？　頭パープリンなの？」
			PRINTFORMW …冷静に考えれば至極もっともな言葉だが、かつて幻想郷で異変を起こした首謀者の手腕は捨てがたいものがあった
			PRINTFORML 「ふーん…。ま、まあそこまで私が必要だって言うなら、…考えてあげなくも無いわ」
			PRINTFORML 軟禁中だというのに不遜な態度は変わらない。腐っても神様ということか
			PRINTL
			PRINTFORML しかし言葉尻こそキツめなものの、彼女の小さな体躯と愛嬌ある身振り手振りを交えた話し方のせいか、あまり不快な印象は無かった
			PRINTFORMW 「それじゃあ、私が鞍替えするだけの価値がある相手かどうか、ちゃんと見極めてさせてもらうわね」
		;それ以外
		ELSE
			PRINTFORML 「はいはーい、そこのお兄さんっ。ずいぶんイケてる感じじゃなーい♪」
			PRINTFORMW 「良かったら私と遊んで…、ってなんだ、アンタか」
			PRINTFORML 町を歩いていると、やたら派手な身なりの少女に声を掛けられた。彼女こそ目的の少女だ
			SETCOLOR 0xffaf60
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　最凶最悪の双子の妹　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は正真正銘の疫病神だ。かつてこの幻想郷にて大いなる混乱を招いた最強最悪の姉妹の片割れだ
			PRINTFORML 知らずに付き合っていたら、次第に財の殆どを貢ぎ、巻き上げられたことだったろう…
			PRINTL
			PRINTFORMW 「アレ以来、妙に顔が知られてやり難くなったわー。で？　アンタは私に何か用があって来たの？」
			PRINTFORML 正体を知っている%ANAME(MASTER)%に対し、さっきまでのきゃぴきゃぴした感じは鳴りを潜めた
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW その現金な様に苦笑しつつも、%ANAME(MASTER)%は君主である彼女に挨拶に来た　と伝えた
				PRINTL
				PRINTFORML 「…はあ？　わざわざ挨拶のために疫病神の私に会いに来たって？　アンタずいぶん度胸あるわね。それとも私のこと舐めてない？」
				PRINTFORMW …冷静に考えれば至極もっともな言葉だが、一応は君主であり神様でもある彼女に挨拶もなしというはちと罰当たりなことだろう
				PRINTFORML 「ふーん…。（…まあ私のこと知っておきながらそれでも来てくれるってのも悪い気はしないわね）……よし」
				PRINTFORMW 「まあいいわ。アンタのこともちゃんと使ってあげる。精々死なない程度には頑張りなさいよ？」
			;それ以外
			ELSE
				PRINTFORMW その現金な様に苦笑しつつも、%ANAME(MASTER)%は彼女に幻想郷を治めるための協力を仰いだ
				PRINTL
				PRINTFORML 「……はあ？　それ疫病神の私に頼むこと？　頭パープリンなの？」
				PRINTFORMW …冷静に考えれば至極もっともな言葉だが、かつて幻想郷で異変を起こした首謀者の手腕は捨てがたいものがあった
				PRINTFORML 「ふーん…。（ま、まあ私のこと知っておきながらそれでも頼ってくるってのも悪い気しないわね）……よし」
				PRINTFORMW 「それじゃあ、私が手を貸すだけの価値がある相手かどうか、この目で見極めてあげるわ！」
			ENDIF
		ENDIF
		PRINTFORML
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------

;■正妻や親愛系で台詞が思いつかなければこの行から■
;正妻か妾
;ELSEIF (CFLAG:200 < 7) && (TALENT:正妻 || TALENT:妾)
;	;婚姻した次の回フラグ
;	CFLAG:200 = 7
;	;PRINTFORMW 

;親愛か隷属
ELSEIF (CFLAG:200 < 6) && (TALENT:親愛 || TALENT:隷属)
	PRINTFORML 
	IF CFLAG:240 == 1
		PRINTFORML 「あ、%ANAME(MASTER)%っ♪　…えへへ、おはよう…♥」
		PRINTFORMW %ANAME(TARGET)%ははにかみつつも%ANAME(MASTER)%に抱きついて甘えてきた。以前の彼女からは信じられない甘えぶりだ
		PRINTFORML 「これからは、ちょっとずつでも自分の気持ちに素直になろうって思うの。…だから言うね？」
		PRINTL
		PRINTFORMW 「私みたいな疫病神を愛してくれて、ありがとう、%ANAME(MASTER)%。…大好きよ♥」
		PRINTFORMW %ANAME(TARGET)%は眩いばかりのとびきりな笑顔で%ANAME(MASTER)%に愛の言葉を贈った
		;親愛か隷属になった次の回フラグ
		CFLAG:200 = 6
	ELSE
		PRINTFORML 「あ、%ANAME(MASTER)%…、お、おはよう………」
		PRINTFORMW %ANAME(TARGET)%は何やら元気のない様子だ…
	ENDIF
	PRINTFORML 
;■この行まで消しても良い■

;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORML 
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「あ、%ANAME(MASTER)%、おはよーさーんっ♪」
		PRINTFORML %ANAME(MASTER)%を見つけた%ANAME(TARGET)%は、頬を染めながら%ANAME(MASTER)%の腕を取って抱きついてきた
		PRINTFORMW 「私にあんなことシといてただで済むと思っちゃ駄目よ？　これからもちゃーんと付き合ってもらうからね♪」
	;それ以外
	ELSE
		PRINTFORML 「あ、%ANAME(MASTER)%、おはよう。…な、何よ、私の顔に何かついてる？」
		PRINTFORMW 身体を許したことを意識しているのか、%ANAME(TARGET)%の頬は赤く染まっている
	ENDIF
	PRINTFORML 

```
