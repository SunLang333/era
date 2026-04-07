# 口上/99 雷鼓口上/KOJO_B_K99.ERB — 自动生成文档

源文件: `ERB/口上/99 雷鼓口上/KOJO_B_K99.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_B_K99, KOJO_TRAIN_END_B_K99, KOJO_COM_BEFORE_TARGET_B_K99, KOJO_COM_BEFORE_PLAYER_B_K99, KOJO_COM_B_K99, KOJO_COM_TARGET_B_K99, KOJO_COM_PLAYER_B_K99, KOJO_COM_AFTER_B_K99; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜調教」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_B_K99
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:202 == 0
	CFLAG:202 = 1
	;初対面の場合
	IF !CFLAG:17
		PRINTFORMW 「…無様にも捕まったのね、私」
		PRINTFORMW 「？」
		PRINTFORMW 「抵抗しないのかって？」
		PRINTFORMW 「力入らないですしこのままではあなたに勝てない」
		PRINTFORMW 「性処理の道具にしたいのでしたらすればいいでしょう」
		PRINTFORMW 「ただ覚えておいて」
		PRINTFORMW 「道具を粗末に扱えばどうなるか…その身に呪いが返るときまでね」
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「あら、よりによって貴方なのね…最悪かもしれないわ」
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;恋慕または服従を獲得した
ELSEIF CFLAG:202 < 3 && (TALENT:恋慕 || TALENT:服従)
	CFLAG:202 = 3
	PRINTFORMW 「ねぇ%ANAME(MASTER)%」
	PRINTFORMW 「前々から言おうと思っていたんだけどさ」
	PRINTFORMW 「私のこと…どう思ってる？」
	PRINTFORMW 「私ね、ただ与えられるだけじゃダメになっちゃったの」
	PRINTFORMW 「本当の自由ってのは与えられるだけでも与えるだけでもダメ」
	PRINTFORMW 「私の愛をあなたにあげたい」
	PRINTFORMW 「…」
	PRINTFORMW 「あなたのことを好きになっちゃったの」
	PRINTFORMW 「もし…良ければだけど」
	PRINTFORMW 「これからも私に鼓動を聞かせてもらえないかしら」
	PRINTFORMW 「あなたの魔力を私に頂けるのなら」
	PRINTFORMW 「これからもあなたと一緒に…」
;依存度が300以上になった
ELSEIF CFLAG:202 < 2 && CFLAG:3 >= 300
	CFLAG:202 = 2
	PRINTFORMW 「もう…抗えないわ…」

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;恋慕 or 服従
ELSEIF TALENT:恋慕 || TALENT:服従
	IF RAND:5 == 0
		PRINTFORMW 「あら、来てくれたの？」
		PRINTFORMW 「…待っていたわ、さぁ、愛しあいましょう」
	ELSEIF RAND:4 == 0
		PRINTFORMW 「ん？」
		PRINTFORMW 「立っているだけじゃわからないわよ？」
		PRINTFORMW 「ほら、こっちに来なさいよ」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「ふふ、今日もいっぱいエッチするの？」
		PRINTFORMW 「人間って浅ましいわね、そんなに女の体がいいの？」
		PRINTFORMW 「いいわよ、いっぱい愛してあげる…」
	ELSE
		PRINTFORMW 「人間の体って不便よね」
		PRINTFORMW 「何にもしなくたってあなたのことを想うと火照ってきちゃう」
		PRINTFORMW 「今日は何してくれるの？御主人様？」
	ENDIF
;依存度が300以上
ELSEIF CFLAG:3 >= 300
	IF RAND:2 == 0
		PRINTFORMW 「もう…なんだってすればいいじゃない…」
		PRINTFORMW すっかり屈服した様子でうなだれている
		PRINTFORMW 「せめて…他の子たちの身代わりになれるのなら…」
	ELSE
		PRINTFORMW 「おはよう、今日も元気ね」
		PRINTFORMW 「私？」
		PRINTFORMW 「そうね…諦めたほうが楽になれるもの」
	ENDIF
;それ以外
ELSE
	IF RAND:2 == 0
		PRINTFORMW 「また、するの…？」
		PRINTFORMW 「ほんと、人間って身勝手ね…」
	ELSE
		PRINTFORMW 「今日はなにするの？」
	ENDIF
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_B_K99
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	IF RAND:3 == 0
		PRINTFORMW 「うっぷ…飲み過ぎたわ…」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「んん…飲み過ぎで気分悪い…」
	ELSE
		PRINTFORMW 「…うぇ…吐きそう…」
	ENDIF
;快感のあまり気絶
ELSEIF TCVAR:52
	PRINTFORMW 「～～～%UNICODE(0x2665) *1%%UNICODE(0x2665) *1%%UNICODE(0x2665) *1%」
	PRINTFORMW 雷鼓は快感のあまりぐったりしている。
;疲労による行動不能
ELSEIF TCVAR:51
	IF RAND:3 == 0
		PRINTFORMW  「…疲れちゃった…」
	ELSEIF RAND:2 == 0
		PRINTFORMW  「はぁ…流石に疲れたわね…」
	ELSE
		PRINTFORMW  「う～ん…疲れた…」
	ENDIF
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;初めて依存度が300以上になった
IF CFLAG:203 < 2 && CFLAG:2 >= 300
	CFLAG:203 = 2
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「…相変わらず…激しいのね…♪」
	ENDIF
;初回
ELSEIF CFLAG:203 < 1
	CFLAG:203 = 1
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「コレで終わり…？」
		PRINTFORMW 「何考えてるのよ…不気味ね…」
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
;行動不能なら非表示
ELSEIF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		IF RAND:3 == 0
			PRINTFORMW 「終わり？」
			PRINTFORMW 「………まぁいいけど」
			PRINTFORMW 「ねえ…また…」
			PRINTFORMW 「…また会えるわよね？」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「今日はコレで終わり？」
			PRINTFORMW 「そう…もう少し私に構ってくれると思っていたのだけれど」
			PRINTFORMW 「あまり浮気してると怒っちゃうぞ？」
		ELSE
			PRINTFORMW 「こうしてあなたと過ごしている時間が楽しくて楽しくて」
			PRINTFORMW 「ふふ、抱き合ったまま一日過ごすってのもいいかもしれないわね」
		ENDIF
	;依存度が300以上
	ELSEIF CFLAG:3 >= 300
		IF RAND:2 == 0
			PRINTFORMW 「八橋や弁々はどうしているのかしら」
			PRINTFORMW 「もう会えないのだろうけど…」
		ELSE
			PRINTFORMW 「どうせするのなら優しくしてくれればいいのに」
			PRINTFORMW 「激しいだけの演奏はダメよ」
			PRINTFORMW 「と言っても分かってくれないんだろうなぁ」
		ENDIF
	;それ以外
	ELSE
		IF RAND:2 == 0
			PRINTFORMW 「もう…ダメ…」
			PRINTFORMW 「どうにかしてここから…」
		ELSE
			PRINTFORMW 「せっかく肉体を持っているっていうのにコレじゃ道具だわ…」
		ENDIF
	ENDIF
ENDIF

;=================================================
;●コマンド実行前(このキャラがターゲット側のとき)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;=================================================
@KOJO_COM_BEFORE_TARGET_B_K99
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
```
