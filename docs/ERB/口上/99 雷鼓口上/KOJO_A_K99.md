# 口上/99 雷鼓口上/KOJO_A_K99.ERB — 自动生成文档

源文件: `ERB/口上/99 雷鼓口上/KOJO_A_K99.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K99, KOJO_TRAIN_END_A1_K99, KOJO_TRAIN_START_A2_K99, KOJO_TRAIN_END_A2_K99, KOJO_COM_BEFORE_TARGET_A_K99, KOJO_COM_BEFORE_PLAYER_A_K99, KOJO_COM_A_K99, KOJO_COM_TARGET_A_K99, KOJO_COM_PLAYER_A_K99, KOJO_COM_AFTER_A_K99; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K99
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
		PRINTFORMW 「あら、えーっと名前が出てこないわね…どなたかしら？」
		PRINTFORMW 「そう、%ANAME(MASTER)%っていうの、素敵な名前ね」
		PRINTFORMW 「私は太鼓の付喪神の堀川雷鼓、まあ手広くやっているわ」
		PRINTFORMW 「それで…なんの用かしら？」
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「あら、%ANAME(MASTER)%だっけ…わざわざ会いに来てくれたの？」
		PRINTFORMW 
		PRINTFORMW 「綺麗だったから？ふふ、照れるわね」
		PRINTFORMW 「何しているのかって…見て分からない？ドラムの演奏よ」
		PRINTFORMW 「乗っかっちゃダメだろって？まぁ自分の体の一部みたいなものだし大丈夫でしょ」
		PRINTFORMW 「ん～じゃあ私はもう２、３曲演奏していくけど聞いていく？」
		PRINTFORMW 「あ、お金とか取らないわよ、まだ練習の途中だし」
		PRINTFORMW 「それじゃあ新曲行ってみよ～！」
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORMW 「あっれー？」
	PRINTFORMW 「どうしたの？%ANAME(MASTER)%」
	PRINTFORMW 雷鼓はリラックスした様子でネクタイとシャツを緩め胸元を露にしながら近寄ってくる。
	PRINTFORMW 「今日は何しよっか？」
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人 
	CFLAG:200 = 4
	PRINTFORMW 「あれ？」
	PRINTFORMW 雷鼓は部屋に入ってきた侵入者に気づくとネクタイとシャツを緩めながら話しかけてくる。
	PRINTFORMW 「今日はどうして？」
	PRINTFORMW なんでもない風に装っているが少し顔を赤らめている。
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORMW 「ん？どうしたの？」
	PRINTFORMW 雷鼓は侵入者に気づくと自分の体の埃を払うようにポンポンと叩いている。
	PRINTFORMW 「うん…変な所は無いわね…で、何かしら？」
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:恋慕 && (!TALENT:恋人 && !TALENT:合意 && CFLAG:250 < 1)
	CFLAG:200 = 2
	PRINTFORMW 「おー%ANAME(MASTER)%じゃない」
	PRINTFORMW 「今日はどうしたの？」

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	IF RAND:4 == 0
		PRINTFORMW 「%ANAME(MASTER)%、いる？」
		PRINTFORMW 雷鼓は中に%ANAME(MASTER)%がいることを確認するとにこやかに入ってきた。
	ELSEIF RAND:3 == 0
		PRINTFORMW 「あら、%ANAME(MASTER)%、元気そうね」
		PRINTFORMW 雷鼓はこちらに気づくと一瞬ビクッと体を震わせながら部屋に入ってくる。
	ELSEIF RAND:2 == 0
		PRINTFORMW 「%ANAME(MASTER)%、入ってもいいかしら？」
		PRINTFORMW 頷くと雷鼓はいそいそと入ってくる。
		PRINTFORMW 「…何か変かしら？」
		PRINTFORMW 綺麗だから見とれていた、と言うと顔を赤くして俯いてしまった。
	ELSE
		PRINTFORMW 「お邪魔しまーす」
		PRINTFORMW 雷鼓はにこやかに部屋に入ってきた。
	ENDIF
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	IF RAND:3 == 0
		PRINTFORMW 「ん…今日も元気そうね…」
		PRINTFORMW 「こうして見るといい男よね、貴方」
		PRINTFORMW 「だから貴方を受け入れたんだけど、さぁ貴方の鼓動聞かせて頂戴」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「今日こそは貴方との子供、作るわよ」
		PRINTFORMW 「ふふ、まぁ多くても困るわけじゃないしね…」
	ELSE
		PRINTFORMW 「お帰りなさい、ご飯にします？」
		PRINTFORMW 「それともお風呂に入りながらシちゃう？」
		PRINTFORMW 「…人の営みってのがよくわかんないのよ、教えてくれない？」
	ENDIF
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人 
	IF RAND:4 == 0
		PRINTFORMW 「あら、来てくれたの？」
		PRINTFORMW 「…待っていたわ、さぁ、愛しあいましょう」
	ELSEIF RAND:3 == 0
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
;既成事実Lv1(キス済み)
ELSEIF CFLAG:250 == 1
	IF RAND:3 == 0
		PRINTFORMW 「ふふっどうしたの？」
		PRINTFORMW 「嬉しいわ、会いに来てくれて」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「…続きをしに来たの？」
	ELSE
		PRINTFORMW 「わざわざ会いに来てくれたのね、嬉しいわ」
	ENDIF
;既成事実Lv0で恋慕
ELSEIF TALENT:恋慕 && (!TALENT:恋人 && !TALENT:合意 && CFLAG:250 < 1)
	IF RAND:3 == 0
		PRINTFORMW 「ふふ、待ってたわ」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「今日は…どうしたの？」
	ELSE
		PRINTFORMW 「あら？会いに来てくれたの？」
	ENDIF
;既成事実Lv0
ELSEIF CFLAG:250 < 1
	IF RAND:3 == 0
		PRINTFORMW 「何やってんの？」
		PRINTFORMW 「こっちに来なよ」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「ふーん、今日はどうしたの？」
	ELSE
		PRINTFORMW 「何？私に用？」
	ENDIF
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K99
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
		PRINTFORMW  「…ごめんなさい…疲れちゃった…」
	ELSEIF RAND:2 == 0
		PRINTFORMW  「はぁ…流石に疲れたわね…」
	ELSE
		PRINTFORMW  「う～ん…疲れた…」
	ENDIF
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした)
IF CFLAG:201 < 5 && TALENT:合意
	CFLAG:201 = 5
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「ん…あっ…%UNICODE(0x2665) *1%」
		PRINTFORMW 雷鼓は力尽きたようにぐったりとしながら呼吸していた。
	ENDIF
;既成事実Lv2(恋人になった)
ELSEIF CFLAG:201 < 4 && TALENT:恋人 
	CFLAG:201 = 4
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
```
