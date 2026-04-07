# 口上/07 小悪魔口上/KOJO_A_K7.ERB — 自动生成文档

源文件: `ERB/口上/07 小悪魔口上/KOJO_A_K7.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K7, KOJO_TRAIN_END_A1_K7, KOJO_TRAIN_START_A2_K7, KOJO_TRAIN_END_A2_K7, KOJO_COM_BEFORE_TARGET_A_K7, KOJO_COM_BEFORE_PLAYER_A_K7, KOJO_COM_A_K7, KOJO_COM_TARGET_A_K7, KOJO_COM_PLAYER_A_K7, KOJO_COM_AFTER_A_K7, SEX_VOICE_K7_00, SEX_VOICE_K7_01, SEX_VOICE_K7_02, SEX_VOICE_K7_03, SEX_VOICE_K7_04, SEX_VOICE_K7_05, SEX_VOICE_K7_06; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K7
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;初めて会った際の淫魔フラグ決定処理
IF CFLAG:240 == 0
	CFLAG:240 = 1
	PRINTFORML 
	CALL COLOR_PRINTW(@"突然ですが%ANAME(TARGET)%は淫魔だと思いますか？", カラー_ピンク) 
		;自分は淫魔派です
	PRINTL [0] 淫魔だから当然ドスケベだよ！（淫乱を取得すると台詞パターン変化、Ｈ中、体力気力が常にＭＡＸに）
	PRINTL [1] ちょっとえっちなだけで普通の小悪魔美少女だよ！（淫乱を取得しても特に変化無し）
	$INPUT_LOOP
	INPUT
	IF RESULT == 0
		;淫魔スイッチON
		CALL COLOR_PRINTW("淫乱をこれから取得した場合、もしくは既に取得している場合、淫魔の血が開放されます", カラー_ピンク) 
		CFLAG:240 = 2
		;すでに淫乱の場合
		SIF GETBIT(TALENT:TARGET:淫乱系, 素質_淫乱_淫乱) 
			CFLAG:240 = 3
	ELSEIF RESULT == 1
		PRINTFORMW 淫乱を取得しても、特に変化はありません
	ELSE
		GOTO INPUT_LOOP
	ENDIF
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
		PRINTFORML 「え？　私に用があるんですか？」
		PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%を訪ねた
		PRINTFORML 彼女はこう見えても悪魔の端くれらしい。仲良くなっておいて損はないだろう
		PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、これからよろしく　と手を差し出した
		PRINTFORML 「はぁ、まあよろしくです」
		PRINTFORML 「でも私はもうパチュリー様と契約してるんで、本当にちょっとした事くらいしか手伝えませんよ？」
		PRINTFORMW ……悪魔と契約して力を得る、という当ては外れたが、ともあれ彼女と交流を開始した

	;既に会ったことがある場合
	ELSEIF !TALENT:服従
		PRINTFORML 「あー、%ANAME(MASTER)%さん。私に何かご用ですか？」
		PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%を訪ねた
		PRINTFORML 彼女はこう見えて悪魔の端くれ。仲良くなっておいて損はないだろう
		PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、これからもよろしく　と手を差し出した
		PRINTFORML 「あーはい、よろしくです」
		PRINTFORML 「雑用はもう飽き飽きなので、なるべく楽しいことをお願いしますね♪」
		PRINTFORMW ……%ANAME(MASTER)%は一癖ありそうな%ANAME(TARGET)%と交流を開始した
	ENDIF
	PRINTL 

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------

;淫魔スイッチＯＮで淫乱取得時
ELSEIF (CFLAG:200 < 6) && (CFLAG:240 == 3)
	;淫乱になった次の回フラグ
	CFLAG:200 = 6
	PRINTL 
	PRINTFORML 「うふふ♥　いらっしゃい、%ANAME(MASTER)%…♥」
	PRINTFORMW %ANAME(MASTER)%を待っていた%ANAME(TARGET)%は、今までとはまるで違う妖艶な雰囲気を纏っていた
	PRINTFORML あまりの変わり様に戸惑っている様子の%ANAME(MASTER)%に、彼女は誘惑するように身体を密着させてきた
	PRINTFORMW 「クスクス♪　どうしたんです？　『何だか今までと違う』？　ああ、そういうことですか…」
	PRINTFORML 「エッチな事大好きな自分に嘘をつくのをやめて、ちょっと素直になっただけですよぉ…♥　自分の本能に、ね♥」
	PRINTFORMW %ANAME(MASTER)%は彼女の強い淫気に、理性を飛ばされないよう気を強く保って交流を再開した…
	PRINTL 

;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTL 
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「あ、いらっしゃい、%ANAME(MASTER)%♥」
		PRINTFORMW %ANAME(TARGET)%を訪ねると、彼女は%ANAME(MASTER)%の腕に抱きついてきた
		PRINTFORML 「えへへ♪　今日はどんなことするんですか？　出来たら…キモチいい事だといいなぁ…♥」
		PRINTFORMW 普段通りの明るさの中に垣間見える妖艶な雰囲気が%ANAME(MASTER)%をドキリとさせた
	;それ以外
	ELSE
		PRINTFORML 「あ、いらっしゃい、%ANAME(MASTER)%」
		PRINTFORMW 「えへへ♪　今日はどんなことするんですか？　出来たら、キモチいい事だといいんですけど♥」
	ENDIF
	PRINTL 

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTL 
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORML 「あ、%ANAME(MASTER)%。おはようございまーす♪　今日は何をするんですか？」
		PRINTFORMW 「どうせならデート行きましょうよ。こんなに可愛い彼女を見せびらかさない手は無いですよ♥　なんちゃって♪」
		PRINTFORMW %ANAME(TARGET)%はとても上機嫌な様子で%ANAME(MASTER)%を迎えた
	;それ以外
	ELSE
		PRINTFORMW 「あ、%ANAME(MASTER)%。おはようございまーす♪　今日は何をするんですか？」
	ENDIF
	PRINTL 

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTL 
	PRINTFORML 「あ、%ANAME(MASTER)%。おはようございます」
	PRINTFORMW 先日キスを交わしたはずだったが、%ANAME(TARGET)%は今までとあまり変わらない様子だ
	PRINTFORMW 「別にキスくらいでそんなに騒いだりしませんって。ちょっと親密な挨拶みたいなものですよぉ♪」
	PRINTL 

;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTL 
	PRINTFORML （…心の準備は出来てます。%ANAME(MASTER)%、私はいつでもウェルカムですよ！）
	PRINTFORMW %ANAME(TARGET)%はなにやら熱っぽい視線を%ANAME(MASTER)%に送っている
	PRINTL 

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;親愛か隷属
ELSEIF TALENT:親愛 || TALENT:隷属
	IF CFLAG:240 == 3
		SELECTCASE RAND:5
			CASE 0
				PRINTFORML 「もうっ、待ってましたよぉ、%ANAME(MASTER)%。待ちきれなくて、襲いに行っちゃうところでしたよぉ♥」
				PRINTFORMW %ANAME(TARGET)%は色っぽい雰囲気を纏ったまま、笑顔を浮かべて%ANAME(MASTER)%を出迎えた
			CASE 1
				PRINTFORML 「あは♥　今日も来てくれたんですねぇ%ANAME(MASTER)%。もしかして、私の身体が恋しくなったんじゃないですかぁ？　うふ♥」
				PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%に乳房をぐいぐい押し当てるように密着してきた
			CASE 2
				PRINTFORML 「あぁん、待ちくたびれましたよぉ♥　これじゃあ今日は、たっぷり可愛がってくれないとイヤですよぉ…♥」
				PRINTFORMW %ANAME(MASTER)%にぎゅっと抱きつく%ANAME(TARGET)%から発せられる魔性の香りが、%ANAME(MASTER)%の理性を蕩かしていく…
			CASE 3
				PRINTFORML 「うふふ…来てくれましたね、%ANAME(MASTER)%♥　それじゃあ二人で、夜までたっぷり楽しみましょう…♥」
				PRINTFORMW %ANAME(TARGET)%から発せられる、理性を蕩けさせる魔性の香りが%ANAME(MASTER)%の鼻腔をくすぐる…
			CASE 4
				PRINTFORML 「あはっ♥　待ってましたよぉ%ANAME(MASTER)%♪　ぁん、んん…ちゅぅ…♥」
				PRINTFORML フェロモンを纏いながら抱きついてきた%ANAME(TARGET)%は、%ANAME(MASTER)%の唇に熱烈なキスを見舞ってくれた
				PRINTFORMW 「うふふ♥　ごめんなさいねぇ、我慢できませんでしたぁ♥　どうせならこのまま…シちゃいますか？　うふふっ♥」
		ENDSELECT
	ELSE
		SELECTCASE RAND:5
			CASE 0
				PRINTFORML 「あはっ♪　待ってましたよー%ANAME(MASTER)%♪　さあさあ、今日も一緒に行きましょう♥」
				PRINTFORMW %ANAME(TARGET)%は実に嬉しそうな笑顔で%ANAME(MASTER)%を出迎えた
			CASE 1
				PRINTFORML 「あっ♪　おはようございます、%ANAME(MASTER)%。今日も素敵な一日にしてくださいね♥」
				PRINTFORMW %ANAME(TARGET)%は幸せそうに目を細め、%ANAME(MASTER)%の腕を取ってきた
			CASE 2
				PRINTFORML 「あは、来てくれたんですねぇ♪　今日もたっぷり、私を可愛がってください♥」
				PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の腕を抱き取り、甘えるように頬を寄せてきた
			CASE 3
				PRINTFORML %ANAME(TARGET)%が%ANAME(MASTER)%の姿を見つけると、彼女は笑顔で走り寄ってきた
				PRINTFORMW 「えへへ…、私、%ANAME(MASTER)%と逢えるのが今一番の楽しみなんです…♥」
			CASE 4
				PRINTFORML 「あっ！　待ってましたよー%ANAME(MASTER)%ー♪　んー、ちゅっ♥」
				PRINTFORML 駆け寄ってきた%ANAME(TARGET)%は、%ANAME(MASTER)%のほっぺに熱いキスを見舞ってくれた
				PRINTFORMW 「えへへー、すみません、我慢できませんでした♥　誰か見てたらどうしましょうね？　うふふっ♥」
		ENDSELECT
	ENDIF

;既成事実Lv3かつ恋慕or服従
ELSEIF TALENT:合意 && (TALENT:恋慕 || TALENT:服従)
	IF CFLAG:240 == 3
		SELECTCASE RAND:4
			CASE 0
				PRINTFORML 「あはっ♥　待ってましたよぉ%ANAME(MASTER)%。待ちきれなくて、自分で慰めちゃうところでしたよぉ♥」
				PRINTFORMW %ANAME(TARGET)%は上気した色っぽい表情で%ANAME(MASTER)%を出迎えた
			CASE 1
				PRINTFORML 「あは、来てくれたんですねぇ%ANAME(MASTER)%♥　さあ、今日も二人で楽しみましょう…♥」
				PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%に乳房を押し当てるように密着してきた
			CASE 2
				PRINTFORML 「あぁん、待ちくたびれましたよぉ♥　今日もたっぷり、可愛がってくださいねぇ…♥」
				PRINTFORMW %ANAME(MASTER)%に抱きついた%ANAME(TARGET)%から発せられる魔性の香りが、%ANAME(MASTER)%の理性を蕩かしていく…
			CASE 3
				PRINTFORML 「あぁん、待ってましたよぉ%ANAME(MASTER)%♪　ぁん、ちゅ…♥」
				PRINTFORML いやらしく抱きついてきた%ANAME(TARGET)%は、%ANAME(MASTER)%の唇に艶かしくキスを見舞ってくれた
				PRINTFORMW 「うふふ♪　ごめんなさいねぇ、つまみ食いしちゃいましたぁ♥」
		ENDSELECT
	ELSE
		SELECTCASE RAND:5
			CASE 0
				PRINTFORMW 「あ、待ってましたよ%ANAME(MASTER)%ー♪　さあさあ今日も行きましょう♪」
			CASE 1
```
