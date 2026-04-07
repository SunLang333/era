# 口上/21 藍口上/KOJO_A_K21.ERB — 自动生成文档

源文件: `ERB/口上/21 藍口上/KOJO_A_K21.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K21, KOJO_TRAIN_END_A1_K21, KOJO_TRAIN_START_A2_K21, KOJO_TRAIN_END_A2_K21, KOJO_COM_BEFORE_TARGET_A_K21, KOJO_COM_BEFORE_PLAYER_A_K21, KOJO_COM_A_K21, KOJO_COM_TARGET_A_K21, KOJO_COM_PLAYER_A_K21, KOJO_COM_AFTER_A_K21, SEX_VOICE21_00, SEX_VOICE21_01, SEX_VOICE21_02, SEX_VOICE21_03, SEX_VOICE21_04, SEX_VOICE21_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K21

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
			PRINTFORML 「……私に何か？」
			PRINTFORMW 捕虜用にあてがわれた部屋にて、九本の大きな尻尾を持った美女が%ANAME(MASTER)%の呼びかけに応える
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　すきま妖怪の式　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　珍しい動物　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　策士の九尾　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML %ANAME(MASTER)%はその美貌にしばし見とれる
			PRINTFORMW 肌の露出がまるで無いにも拘らず色気を放つ肉体と、艶々な毛並みの尻尾が視線を釘付けにする…
			PRINTFORMW 「…まぁ、そういう目線には慣れております。それで、私に何か用ですか？」
			PRINTFORML 視線がどこに向かったか、お見通しのようだ
			PRINTFORMW 誤魔化しの咳払いの後%ANAME(MASTER)%は、この乱世を鎮めるため我が軍に力を貸して欲しい、と伝えた
			PRINTFORML 「……私を牢に繋がず、この扱いをするのはそういうことでしたか」
			PRINTFORMW 「ですが、そう易々と宗旨替えするわけにはいきません。私にも誇りはありますので……」
			PRINTFORML ……やはりそう簡単には行かないようだ
			PRINTFORMW しかし彼女を諦めるというのもあまりに惜しい。根気強く交流を続けて心変わりを願おう
			PRINTFORML 「…諦めるつもりは無いようですね……、はあ……」
			PRINTFORMW 「…どれくらいの付き合いになるか分かりませんが、とりあえずはよろしく、%ANAME(MASTER)%殿」
		;それ以外
		ELSE
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORML 「ん？　私に用か？」
			;それ以外
			ELSE
				PRINTFORML 「ん？　私ですか？」
			ENDIF
			PRINTFORMW 九本の大きな尻尾を持った美女が%ANAME(MASTER)%の呼びかけに応えて振り向く
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　すきま妖怪の式　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　珍しい動物　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　策士の九尾　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML %ANAME(MASTER)%はその美貌にしばし見とれる
			PRINTFORMW 肌の露出がまるで無いにも拘らず色気を放つ肉体と、艶々な毛並みの尻尾が視線を釘付けにする…
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW 「えーと、君は確か…%ANAME(MASTER)%だったかな？」
				PRINTFORML 直接の面識は無くとも、部下である%ANAME(MASTER)%の顔と名前は覚えられているようだ
				PRINTFORMW 問いに肯定を返した%ANAME(MASTER)%は、君主である%ANAME(TARGET)%に挨拶に伺わせていただきました、と伝えた
				PRINTFORML 「わざわざ挨拶に？　ふむ、それは感心だ」
				PRINTFORMW 「…この幻想郷は色々と自由奔放な人物が多いからな。ちゃんと礼節をもって挨拶に来てくれるのは嬉しいよ」
				PRINTFORML そう言うと%ANAME(TARGET)%は柔和な眼差しで微笑んだ
				PRINTFORML 男を虜にするような美女の笑みを向けられ、%ANAME(MASTER)%はその美貌に心臓を打たれたような錯覚を抱いた
				PRINTFORMW 「それでは、これからよろしく頼むぞ。どうか私のために尽力してくれ。……ああ、それと」
				PRINTFORML %ANAME(TARGET)%は思い出したかのように一言付け加える
				PRINTFORMW 「今度挨拶に来る時は油揚げを持ってきてくれると、その、何だ…とても嬉しいぞ？」
			;相手が同盟国の士官の場合
			ELSEIF CFLAG:TARGET:所属 != CFLAG:MASTER:所属
				PRINTFORMW 「…まぁ、そういう目線には慣れております。それで、私に何か御用ですか？」
				PRINTFORML 視線がどこに向かったか、お見通しのようだ
				PRINTFORMW 誤魔化しの咳払いの後%ANAME(MASTER)%は、同盟国の方々に挨拶に参った、と伝えた
				PRINTFORML 「ほう、挨拶に。わざわざご丁寧にどうも」
				PRINTFORMW 「私は%NAME_FORMAL(TARGET)%と申します。以後お見知りおきを」
				PRINTFORMW 「この先何があるか分かりませんが、少なくとも今は同士。共に力を合わせていきましょう」
			;それ以外
			ELSE
				PRINTFORMW 「…まぁ、そういう目線には慣れております。それで、私に何か御用ですか？」
				PRINTFORML 視線がどこに向かったか、お見通しのようだ
				PRINTFORMW 誤魔化しの咳払いの後%ANAME(MASTER)%は、この乱世を鎮めるために力を貸して欲しい、と伝えた
				PRINTFORML 「……ふむ、そういうことですか」
				PRINTFORMW 「私も幻想郷のために尽力する身、一先ずはよろしくお願いします」
				PRINTFORML これは心強い！　名高い九尾の狐の力を借りれるとなると鬼に金棒だ
				PRINTFORMW 「あ、いや…私は厳密に言えば九尾の狐ではなくて、それを依代にしている式神なのだが…、まぁいいか」
				PRINTFORMW 「それでは、不肖この%NAME_FORMAL(TARGET)%、微力ながらお手伝いしましょう」
			ENDIF
		ENDIF
		PRINTFORML
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		PRINTFORML
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「…やあ、%ANAME(MASTER)%」
			PRINTFORMW 捕虜用にあてがわれた部屋にて、九本の大きな尻尾を持った美女が%ANAME(MASTER)%の呼びかけに応えた
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　すきま妖怪の式　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　珍しい動物　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　策士の九尾　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML %ANAME(MASTER)%は相変わらずの美貌にしばし見とれる
			PRINTFORMW 肌の露出がまるで無いにも拘らず色気を放つ肉体と、艶々な毛並みの尻尾が視線を釘付けにする…
			IF CFLAG:好感度 >= 500
				PRINTFORMW 「ふう、相変わらずだな%ANAME(MASTER)%は。それで、私に何の用かな？」
				PRINTFORML 視線がどこに向かったか、お見通しのようだ
				PRINTFORMW 誤魔化しの照れ笑いの後%ANAME(MASTER)%は、この乱世を鎮めるため我が軍に力を貸して欲しい、と伝えた
				PRINTFORML 「……ふむ。私を牢に繋がずにいた理由はそれか」
				IF CFLAG:好感度 >= 1000
					PRINTFORMW 「うーん、どうしようかな。お前のためならそれもやぶさかではないが……」
				ELSE
					PRINTFORMW 「まあ、お前のことは嫌いではないが……。それとこれは話が違うしなぁ…」
				ENDIF
				PRINTFORML 「…やはり、そう簡単に答えを出すわけにもいかない。すまないがもう少し時間をくれないだろうか」
				PRINTFORMW ……流石に易々とは行かないようだ
				PRINTFORML だが感触は悪くない。このまま根気強く交流を続けて心変わりを願おう
				PRINTFORMW 「それじゃあしばらく厄介になる。よろしく頼むよ、%ANAME(MASTER)%」
			ELSE
				PRINTFORMW 「…まぁ、そういう目線には慣れているよ。それで、私に何か用ですか？」
				PRINTFORML 視線がどこに向かったか、お見通しのようだ
				PRINTFORMW 誤魔化しの咳払いの後%ANAME(MASTER)%は、この乱世を鎮めるため我が軍に力を貸して欲しい、と伝えた
				PRINTFORML 「……私を牢に繋がず、この扱いをするのはそういうことでしたか」
				PRINTFORMW 「ですが、そう易々と宗旨替えするわけにはいきません。私にも誇りはありますので……」
				PRINTFORML ……やはりそう簡単には行かないようだ
				PRINTFORMW しかし彼女を諦めるというのもあまりに惜しい。根気強く交流を続けて心変わりを願おう
				PRINTFORML 「…諦めるつもりは無いようですね……、はあ……」
				PRINTFORMW 「…どれくらいの付き合いになるか分かりませんが、とりあえずはよろしく、%ANAME(MASTER)%殿」
			ENDIF
		;それ以外
		ELSE
			PRINTFORML 「ああ、%ANAME(MASTER)%。久しぶりだな」
			PRINTFORMW 九本の大きな尻尾を持った美女が%ANAME(MASTER)%の呼びかけに応えて振り向いた
			SETCOLOR カラー_黄
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　すきま妖怪の式　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　珍しい動物　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　策士の九尾　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML %ANAME(MASTER)%は相変わらずの美貌にしばし見とれる
			PRINTFORMW 肌の露出がまるで無いにも拘らず色気を放つ肉体と、艶々な毛並みの尻尾が視線を釘付けにする…
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				IF CFLAG:好感度 >= 500
					PRINTFORMW 「ふふ、相変わらずだな%ANAME(MASTER)%は。それで、私に何か用かい？」
					PRINTFORML 視線がどこに向かったか、お見通しのようだ
					PRINTFORMW 誤魔化しの照れ笑いの後%ANAME(MASTER)%は、改めて%ANAME(TARGET)%様に挨拶に伺いました、と伝えた
					PRINTFORML 「ふむ、感心だぞ%ANAME(MASTER)%。やはり挨拶はちゃんとしないとな」
					PRINTFORMW そう言うと%ANAME(TARGET)%は笑顔を浮かべ、%ANAME(MASTER)%の頭をよしよしと撫でた
					PRINTFORML 突然の、しかし優しい手つきに逆らえず%ANAME(MASTER)%はなすがままになってしまった
					PRINTFORML 「あっ…す、すまない。ついいつものクセで…。気分を害したりしていないか？　何だが顔が赤いようだが…」
					PRINTFORMW 紅潮した顔を何でもありませんと誤魔化すと、お互いの間に妙な空気が流れた…
					PRINTFORMW 「こほんっ、あー、それでは改めて。これからもよろしく頼むぞ、%ANAME(MASTER)%」
				ELSE
					PRINTFORMW 「…まぁ慣れてはいるが、目上の者にそういう視線を送るのは感心しないな。それで、私に何か用か？」
					PRINTFORML 視線がどこに向かったか、お見通しのようだ
					PRINTFORMW 誤魔化しの咳払いの後%ANAME(MASTER)%は、この乱世を鎮めるため尽力します、と伝えた
					PRINTFORML 「ふむ、私も期待しているよ」
					PRINTFORMW 「それでは%ANAME(MASTER)%。改めて、よろしく頼む」
				ENDIF
			;相手が同盟国の士官の場合
			ELSEIF CFLAG:TARGET:所属 != CFLAG:MASTER:所属
				IF CFLAG:好感度 >= 500
					PRINTFORMW 「ふふ、相変わらずだな%ANAME(MASTER)%は。それで、私に何か用かい？」
					PRINTFORML 視線がどこに向かったか、お見通しのようだ
					PRINTFORMW 誤魔化しの照れ笑いの後%ANAME(MASTER)%は、せっかく同盟を組んだのだから手土産を持って会いに来た、と伝えた
					PRINTFORML 「ほほう、わざわざ顔を出してくれるとは嬉しいよ」
					PRINTFORMW 「…それにその包み。油揚げだな？　匂いで分かるぞ。私のために用意してくれたのか？」
					PRINTFORML %ANAME(TARGET)%は油揚げが好物と聞き持参した物だが、当人は大いに喜んでくれたようだ
					PRINTFORMW 「ふふ♪　%ANAME(MASTER)%は気が利くな。とても嬉しいよ」
					PRINTFORMW 「私の方もお茶を出そう。どうかゆっくりしていってくれ」
				ELSE
					PRINTFORMW 「…まぁ、そういう目線には慣れております。それで、私に何か御用ですか？」
					PRINTFORML 視線がどこに向かったか、お見通しのようだ
					PRINTFORMW 誤魔化しの咳払いの後%ANAME(MASTER)%は、せっかく同盟を組んだのだから挨拶に来た、と伝えた
					PRINTFORML 「ほう、わざわざ挨拶に。それはご丁寧にどうも」
					PRINTFORMW 「何があるわけでもありませんが、どうぞゆっくりしていってください」
				ENDIF
			;それ以外
			ELSE
				IF CFLAG:好感度 >= 500
					PRINTFORMW 「ふふ、相変わらずだな%ANAME(MASTER)%は。それで、私に何か用かい？」
```
