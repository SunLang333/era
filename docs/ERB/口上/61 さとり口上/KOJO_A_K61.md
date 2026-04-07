# 口上/61 さとり口上/KOJO_A_K61.ERB — 自动生成文档

源文件: `ERB/口上/61 さとり口上/KOJO_A_K61.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K61, KOJO_TRAIN_END_A1_K61, KOJO_TRAIN_START_A2_K61, KOJO_TRAIN_END_A2_K61, KOJO_COM_BEFORE_TARGET_A_K61, KOJO_COM_BEFORE_PLAYER_A_K61, KOJO_COM_A_K61, KOJO_COM_TARGET_A_K61, KOJO_COM_PLAYER_A_K61, KOJO_COM_AFTER_A_K61, SEX_VOICEK61_00, SEX_VOICEK61_01, SEX_VOICEK61_02, SEX_VOICEK61_03, SEX_VOICEK61_04, SEX_VOICEK61_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K61
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
	;初対面で主人公がお燐、お空、こいしでない場合
	IF !CFLAG:17 && !GROUPMATCH(MASTER, NAME_TO_CHARA("お燐"), NAME_TO_CHARA("お空"), NAME_TO_CHARA("こいし"))
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「あら、私に来客なんて珍しいですね」
			PRINTFORMW 捕虜用にあてがわれた部屋を訪れると、一人の少女が%ANAME(MASTER)%に振り向く
			PRINTFORMW 「……ふむ。%ANAME(MASTER)%、という名前なのですね。それでどんな用で？　……そう、挨拶に」
			PRINTFORML %ANAME(MASTER)%が一言も喋らぬうちから、少女は知りえるはずの無い情報を口走る
			PRINTFORML 「ああ、申し遅れました。私の名は%NAME_FORMAL(TARGET)%です。以後お見知りおきを」
			SETCOLOR 0xFF00FF
			PRINTL 
			PRINTDATAL
				DATAFORM ―――――　地の底の安楽椅子探偵　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　怨霊も恐れ怯む少女　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　みんなの心の病み　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　孤影悄然の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は相手の心を読むことが出来る覚り妖怪だ。対面する以上、考えていることは彼女に筒抜けになってしまうだろう
			PRINTFORML 「……ええ、その通りです。まあ、別に気にすることは無いですよ」
			PRINTFORMW 「せいぜい貴方が考えていることをたまに言葉に出す程度なので」
			PRINTFORML ……だいぶいい性格をしているようだ。読心能力を持つ彼女に腹芸は通じないだろう
			PRINTFORMW 「ええ、そのつもりでよろしく。……でも少し安心しました」
			PRINTFORML 「少なくとも貴方が、いきなり襲い掛かってこない程度には平和的な心を持っているようで…」
			PRINTFORMW ……過去にいきなり襲い掛かられた事でもあったのだろうか

		ELSE
			PRINTFORML 「あら、私に来客なんて珍しいですね」
			PRINTFORMW 「……ふむ。%ANAME(MASTER)%、という名前なのですね。それでどんな用で？　……そう、挨拶に」
			PRINTFORML %ANAME(MASTER)%が一言も喋らぬうちから、少女は知りえるはずの無い情報を口走る
			;さとりが君主
			IF GET_COUNTRY_BOSS(CFLAG:TARGET:所属) == NAME_TO_CHARA("さとり")
				PRINTFORML 「ああ、申し遅れました。私の名は%NAME_FORMAL(TARGET)%。ここの主ですよ」
			ELSE
				PRINTFORML 「ああ、申し遅れましたね。私の名は%NAME_FORMAL(TARGET)%です。以後お見知りおきを」
			ENDIF
			SETCOLOR 0xFF00FF
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　地の底の安楽椅子探偵　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　怨霊も恐れ怯む少女　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　みんなの心の病み　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　孤影悄然の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は相手の心を読むことが出来る覚り妖怪だ。対面する以上、考えていることは彼女に筒抜けになってしまうだろう
			PRINTFORML 「……ええ、その通りです。まあ、別に気にすることは無いですよ」
			PRINTFORMW 「せいぜい貴方が考えていることをたまに言葉に出す程度なので」
			PRINTFORML ……だいぶいい性格をしているようだ。読心能力を持つ彼女に腹芸は通じないだろう
			PRINTFORMW %ANAME(MASTER)%は改めて、%ANAME(TARGET)%によろしく　と挨拶をした
			PRINTFORMW 「ええ、よろしく。……でも少し安心したわ」
			PRINTFORML 「少なくとも貴方が、いきなり襲い掛かってこない程度には平和的な心を持っているようで…」
			PRINTFORMW ……過去にいきなり襲い掛かられた事でもあったのだろうか
		ENDIF
		PRINTL 
	;既に会ったことがあり、服従でなく、主人公がお燐、お空、こいしでない場合
	ELSEIF !GROUPMATCH(MASTER, NAME_TO_CHARA("お燐"), NAME_TO_CHARA("お空"), NAME_TO_CHARA("こいし")) && !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「あら、私に来客なんて珍しい、…って%ANAME(MASTER)%でしたか」
			PRINTFORMW 捕虜用にあてがわれた部屋を訪れると、一人の少女が%ANAME(MASTER)%に振り向く
			PRINTFORMW 「きょうはどんな用で？　……そう、挨拶に」
			PRINTFORML こちらが一言も喋らぬうちから、少女は%ANAME(MASTER)%の心の声を口に出す
			SETCOLOR 0xFF00FF
			PRINTL 
			PRINTDATAL
				DATAFORM ―――――　地の底の安楽椅子探偵　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　怨霊も恐れ怯む少女　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　みんなの心の病み　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　孤影悄然の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は相手の心を読むことが出来る覚り妖怪だ。対面する以上、考えていることは彼女に筒抜けになってしまうだろう
			PRINTFORML 「……ええ、その通りです。まあ、別に気にすることは無いですよ」
			PRINTFORMW 「せいぜい貴方が考えていることをたまに言葉に出す程度なので」
			PRINTFORML 性格も相変わらずのようだ。読心能力を持つ彼女に隠し事は通じないだろう
			PRINTFORMW 「ええ、そのつもりでよろしく。……でも少し安心しました」
			PRINTFORML 「少なくとも貴方が、いきなり襲い掛かってこない程度には平和的な心を持っているようで…」
			PRINTFORMW ……過去にいきなり襲い掛かられた事でもあったのだろうか

		ELSE
			PRINTFORML 「あら、私に来客なんて珍しい、…って%ANAME(MASTER)%でしたか」
			PRINTFORMW 「きょうはどんな用で？　……そう、挨拶に来たのね」
			PRINTFORML こちらが一言も喋らぬうちから、少女は%ANAME(MASTER)%の心の声を口に出す
			SETCOLOR 0xFF00FF
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　地の底の安楽椅子探偵　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　怨霊も恐れ怯む少女　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　みんなの心の病み　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　孤影悄然の妖怪　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は相手の心を読むことが出来る覚り妖怪だ。対面する以上、考えていることは彼女に筒抜けになってしまうだろう
			PRINTFORML 「……ええ、その通りです。まあ、別に気にすることは無いですよ」
			PRINTFORMW 「せいぜい貴方が考えていることをたまに言葉に出す程度なので」
			PRINTFORML 性格も相変わらずのようだ。読心能力を持つ彼女に隠し事は通じないだろう
			PRINTFORMW %ANAME(MASTER)%は改めて、%ANAME(TARGET)%によろしく　と挨拶をした
			PRINTFORML 「はい。こちらこそよろしく」
			;さとりが主人
			IF TALENT:主人
				PRINTFORML 「…ふふっ、ちゃんと自分から挨拶に来るなんて偉いわね」
				PRINTFORMW 「ほら、こっちいらっしゃい。ヨシヨシしてあげる……♪」
			;さとりが君主
			ELSEIF GET_COUNTRY_BOSS(CFLAG:TARGET:所属) == NAME_TO_CHARA("さとり")
				PRINTFORMW 「私は荒事が得意じゃないから、手を貸してくれると助かるのだけれど…」
			ELSE
				PRINTFORMW 「私としては元の静かな暮らしがいいので、早いとこ乱世を治めてくださいね」
			ENDIF
		ENDIF
		PRINTL 
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻か妾
ELSEIF CFLAG:200 < 7 && TALENT:正妻
	CFLAG:200 = 7;婚姻した次の回フラグ
	PRINTFORML
	;さとりが主人
	IF TALENT:主人
		PRINTFORML 「あ、%ANAME(MASTER)%…。おはよう…♥」
		PRINTFORMW 朝。同じベッドで目覚めた%ANAME(TARGET)%は愛おしさに目を細め、愛情を込めた言葉を%ANAME(MASTER)%に送る
		PRINTFORML 「…今日から私たちの、本当の家族としての生活が始まるのね」
		PRINTFORML 彼女は優しく微笑みながら、%ANAME(MASTER)%の額に軽いキスをした
		PRINTFORMW 「これからも私のこと、よろしくお願いね、%ANAME(MASTER)%…♥」
	;それ以外
	ELSE
		PRINTFORML 「あ、%ANAME(MASTER)%…。おはようございます♥」
		PRINTFORMW 朝。同じベッドで目覚めた%ANAME(TARGET)%は愛おしさに目を細め、愛情を込めた言葉を%ANAME(MASTER)%に送る
		PRINTFORML 「…今日から私たちの、家族としての生活が始まるんですね」
		PRINTFORML 彼女は頬を染めながら、%ANAME(MASTER)%の額に優しくキスをする
		PRINTFORMW 「これからも私のこと、どうぞよろしくね、%ANAME(MASTER)%…♥」
	ENDIF
	PRINTFORML

;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTL
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「あらいらっしゃい、%ANAME(MASTER)%。よく来てくれましたね」
		PRINTFORMW %ANAME(MASTER)%の姿を見ると%ANAME(TARGET)%は嬉しそうに挨拶してきた
		PRINTFORML 「……『機嫌が良さそう』？　そうですね。なにせ大好きな%ANAME(MASTER)%が来てくれたんですから…♥」
		PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%と腕を絡ませて寄り添ってきた
		PRINTFORMW 「これからも私の事、よろしくお願いしますね…。それじゃあ行きましょう」
	;それ以外
	ELSE
		PRINTFORML 「いらっしゃい。……前回のことなんて考えなくてもいいですよ」
		PRINTFORMW 思わず前の情事のことを思い出してしまった%ANAME(MASTER)%は、%ANAME(TARGET)%に注意された……
	ENDIF
	PRINTL

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTL
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「あ、いらっしゃい%ANAME(MASTER)%。…恋人らしいことってあまり分かりませんけど、よろしくお願いしますね」
		PRINTFORMW %ANAME(TARGET)%は頬を染めつつも、何やらワクワクした様子で挨拶してきた
	;それ以外
	ELSE
		PRINTFORMW 「ああ、%ANAME(MASTER)%、こんにちは。…恋人なんて今までいなかったもので、どうするものなのかしら？」
	ENDIF
	PRINTL

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTL
	PRINTFORML 「…お、おはようございます」
	PRINTFORMW %ANAME(MASTER)%の姿を見ると%ANAME(TARGET)%は挨拶してきた。少し顔が赤いような……
	PRINTFORML 「な、何でもありませんよ。……ちょっと。私の唇の感触なんて今思い出さなくてもいいでしょう？」
```
