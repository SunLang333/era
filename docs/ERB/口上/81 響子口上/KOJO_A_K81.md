# 口上/81 響子口上/KOJO_A_K81.ERB — 自动生成文档

源文件: `ERB/口上/81 響子口上/KOJO_A_K81.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K81, KOJO_TRAIN_END_A1_K81, KOJO_TRAIN_START_A2_K81, KOJO_TRAIN_END_A2_K81, KOJO_COM_BEFORE_TARGET_A_K81, KOJO_COM_BEFORE_PLAYER_A_K81, KOJO_COM_A_K81, KOJO_COM_TARGET_A_K81, KOJO_COM_PLAYER_A_K81, KOJO_COM_AFTER_A_K81, SEX_VOICE_K81_00, SEX_VOICE_K81_01, SEX_VOICE_K81_02, SEX_VOICE_K81_03, SEX_VOICE_K81_04, SEX_VOICE_K81_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K81
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
			PRINTFORML 「あっ、お　は　よ　ー　ご　ざ　い　ま　す　っ　！」
			PRINTFORMW %ANAME(MASTER)%が捕虜の部屋を訪れると、一人の妖怪少女が、元気な挨拶の声を掛ける
			PRINTFORMW …これが耳を塞ぎたいほどの大声でなければ、微笑ましい光景なのだが…
			SETCOLOR 0x088A08
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　読経するヤマビコ　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　平凡陳腐な山彦　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 「え？　わたしに用なんですか？」
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、戦乱を治めるためにも我が軍に力を貸して欲しい、と伝えた
			PRINTFORML 「え、えーと、その……そう簡単に宗旨替えするわけには……」
			PRINTFORMW 彼女はバツが悪そうに応える。まあ、そう簡単には行かないか
			PRINTFORMW 「ご、ごめんなさい。……これで帰っていい、…ってわけはないよね。トホホ……」
		;それ以外
		ELSE
			PRINTFORML 「　お　は　よ　ー　ご　ざ　い　ま　ー　す　！」
			PRINTFORMW 一人の妖怪少女が、%ANAME(MASTER)%に元気な挨拶の声を掛ける
			PRINTFORMW …これが耳を塞ぎたいほどの大声でなければ、微笑ましい光景なのだが…
			SETCOLOR 0x088A08
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　読経するヤマビコ　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　平凡陳腐な山彦　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 「え？　わたしに用なんですか？」
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、戦乱を治めるために力を貸しに来た、と伝えた
				PRINTFORML 「手を貸してくれるの！？　わーい！　最近物騒になってきて、寺の皆も修行どころじゃないみたいだし助かるわっ！」
				PRINTFORMW 「応援するから頑張ってね！　わたしに出来ることがあれば手伝ってあげる！」
				PRINTFORMW %ANAME(TARGET)%は高らかにハツラツと告げた。…君主を手伝うのではなく君主が手伝う…？
				PRINTFORML 「…わたし、弱っちいから…、荒事は期待しないでね？」
			;それ以外
			ELSE
				PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、戦乱を治めるために力を貸して欲しい、と伝えた
				PRINTFORML 「うーん、確かに最近物騒になってきて、寺の皆も修行どころじゃないみたいだし…」
				PRINTFORMW 「うん、いいよ！　わたしに出来ることがあれば手伝ってあげる！」
				PRINTFORMW %ANAME(TARGET)%は高らかにハツラツと告げた
				PRINTFORML 「…でもわたし、弱っちいから…、荒事は期待しないでね？」
			ENDIF
			PRINTFORMW …今度は弱々しく告げた。まあ、見た目からして明らかにか弱そうだし仕方ない
			PRINTFORMW 「それじゃあこれからよろしくね！　大声出す仕事なら任せてちょうだい！」
		ENDIF
		PRINTFORML
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「あっ、%ANAME(MASTER)%。お　は　よ　ー　ご　ざ　い　ま　す　っ　！」
			PRINTFORMW %ANAME(MASTER)%が捕虜の部屋を訪れると、一人の妖怪少女が、元気な挨拶の声を掛ける
			PRINTFORMW …相変わらずの大声でなければ、微笑ましい光景なのだが…
			SETCOLOR 0x088A08
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　読経するヤマビコ　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　平凡陳腐な山彦　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 「え？　わたしに用があるの？」
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、戦乱を治めるためにも我が軍に力を貸して欲しい、と伝えた
			PRINTFORML 「え、えーと、その……そう簡単に宗旨替えするわけには……」
			PRINTFORMW 彼女はバツが悪そうに応える。まあ、そう簡単には行かないか
			PRINTFORMW 「ご、ごめんなさい。……これで帰っていい、…ってわけはないよね。トホホ……」
		;それ以外
		ELSE
			PRINTFORML 「あ、%ANAME(MASTER)%だ。　お　は　よ　ー　ご　ざ　い　ま　ー　す　！」
			PRINTFORMW 一人の妖怪少女が、%ANAME(MASTER)%に元気な挨拶の声を掛ける
			PRINTFORMW …相変わらずの大声でなければ、微笑ましい光景なのだが…
			SETCOLOR 0x088A08
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　読経するヤマビコ　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　平凡陳腐な山彦　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 「え？　今日はわたしに用があるの？」
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、戦乱を治めるために力を貸しに来た、と伝えた
				PRINTFORML 「手を貸してくれるの！？　わーい！　最近物騒になってきて、寺の皆も修行どころじゃないみたいだし助かるわっ！」
				PRINTFORMW 「応援するから頑張ってね！　わたしに出来ることがあれば手伝ってあげる！」
				PRINTFORMW %ANAME(TARGET)%は高らかにハツラツと告げた。…君主を手伝うのではなく君主が手伝う…？
				PRINTFORML 「…わたし、弱っちいから…、荒事は期待しないでね？」
			;それ以外
			ELSE
				PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、戦乱を治めるため、力になって欲しい。と伝えた
				PRINTFORML 「うーん、確かに最近物騒になってきて、寺の皆も修行どころじゃないみたいだし…」
				PRINTFORMW 「うん、いいよ！　わたしに出来ることがあれば手伝ってあげる！」
				PRINTFORMW %ANAME(TARGET)%は高らかにハツラツと告げた
				PRINTFORML 「あ、でもわたし、弱っちいから…、荒事は期待しないでね？」
			ENDIF
			PRINTFORMW …今度は弱々しく告げた。まあ、見た目からして明らかにか弱そうだし仕方ない
			PRINTFORMW 「それじゃあよろしくね！　大声出す仕事なら任せてちょうだい！」
		ENDIF
		PRINTFORML
	ENDIF


;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------

;正妻
ELSEIF CFLAG:200 < 7 && TALENT:正妻
	CFLAG:200 = 7;婚姻した次の回フラグ
	PRINTFORML
	PRINTFORML 「あ、%ANAME(MASTER)%っ♥　おはよう♥」
	PRINTFORMW %ANAME(TARGET)%は目を細め、愛情を込めた言葉を%ANAME(MASTER)%に掛ける
	PRINTFORMW 「えへへ…、あんまり奥さんらしいことって分からないけど、これからもよろしくね、%ANAME(MASTER)%♥」
	PRINTFORML

;親愛か隷属
ELSEIF CFLAG:200 < 6 && (TALENT:親愛 || TALENT:隷属)
	CFLAG:200 = 6;親愛か隷属になった次の回フラグ
	PRINTFORML
	PRINTFORML 「あ♥　%ANAME(MASTER)%！　おはよーございまーっす！！」
	PRINTFORMW %ANAME(TARGET)%は一際元気に挨拶しながら、見てる側が幸せな気分になるような笑顔で走りよって来た
	PRINTFORMW 「えへへー♥　今日も一緒によろしくね♪」
	PRINTFORML

;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORML
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「あ！　%ANAME(MASTER)%！　おはよーございまーす！」
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の姿を見ると、満面の笑みで挨拶しながら走りよって来た
		PRINTFORMW 「えへへー、今日はどんなことするの？」
	;それ以外
	ELSE
		PRINTFORML 「あ、%ANAME(MASTER)%……お、おはようございます……」
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%を直視できないようで、頬を染めながら挨拶してきた
	ENDIF
	PRINTFORML

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTFORML
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「あ、%ANAME(MASTER)%…。お、おはよーございます！」
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の姿を見ると、頬を染めながら挨拶してきた
		PRINTFORML 「…恋人との挨拶って、どういう風にすればいいのかな。%ANAME(MASTER)%は分かる？」
		PRINTFORMW %ANAME(MASTER)%は答えるように%ANAME(TARGET)%の額にキスをする。彼女は耳まで赤くしつつも嬉しそうにしている
		PRINTW 「こ、言葉はいらないんだね…///。深いなー」
	;それ以外
	ELSE
		PRINTFORML 「あ、%ANAME(MASTER)%…。お、おはよーございまーす！」
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の姿を見ると、頬を染めながら挨拶してきた
		PRINTFORMW （…恋人との挨拶って、どういう風にすればいいのかな？）
	ENDIF
	PRINTFORML

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORML
	PRINTFORML 「お、おはよーございます！」
	PRINTFORMW %ANAME(MASTER)%の姿を見ると%ANAME(TARGET)%は挨拶してきた。何やらギクシャクしているような…
	PRINTFORMW （うー、なんか意識しちゃうな…。キスした時の事、思い出しちゃう……）
	PRINTFORML

;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORML
	PRINTFORM 「あ、%ANAME(MASTER)%……
```
