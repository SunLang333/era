# 口上/149 女苑口上/_KOJO_EVENT_K149.ERB — 自动生成文档

源文件: `ERB/口上/149 女苑口上/_KOJO_EVENT_K149.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K149; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;イベント口上
;-------------------------------------------------

;=================================================
;●各種イベント
;※ARGにイベント番号が入る。詳しくは資料フォルダの「era恋姫 イベント表」を参照
;※RETURNの値を0→1に変えると、デフォルトのメッセージが表示されなくなる
;=================================================
@KOJO_EVENT_K149(ARG)
#DIM 紫苑
紫苑 = NAME_TO_CHARA("紫苑")

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
;IF ARG == 1
;	;恋慕 or 服従
;	IF TALENT:恋慕 || TALENT:服従
;		PRINTFORML 
;	;恋人
;	ELSEIF TALENT:恋人
;		PRINTFORML 
;	;それ以外
;	ELSE
;		PRINTFORML 
;	ENDIF
;	RETURN 0
;ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	SETCOLOR 0xffaf60
	PRINTFORML 
	PRINTFORMW 「……ごめん、ちょっと聞こえなかったわ。もう一回言ってくれる？」
	PRINTFORML 
	PRINTFORMW %ANAME(MASTER)%に愛の告白をされた%ANAME(TARGET)%は、信じられないといった様子で聞き返してきた
	PRINTFORML 
	PRINTFORMW おかげで%ANAME(MASTER)%はもう一度告白をする羽目になった
	PRINTFORML 
	PRINTFORMW 「き、聞き間違いじゃなかったのね。熱は、……平熱かー」
	PRINTFORML 
	PRINTFORMW %ANAME(MASTER)%の額に小さな手をぴと、と当てて熱を測る。どうにも信じてもらえないようだ
	PRINTFORML 
	PRINTFORMW 「いや当たり前でしょっ！？　私は疫病神よ！？　誰が好き好んで付き合おうだの言う奴が………っ」
	PRINTFORML 
	PRINTFORMW ここに居てしまった
	PRINTFORML 
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「…………ほ、ホントに本気なの？　後から文句言われても困るんだけど…」
		PRINTFORML 
		PRINTFORMW やたら念を押される。そんなに嫌なのだろうか
		PRINTFORML 
		PRINTFORMW 「イ、イヤじゃないわよ、別に。…て言うか、むしろ……」
		PRINTFORML 
		PRINTFORMW そう言うと%ANAME(TARGET)%は、頬を朱色に染めながら%ANAME(MASTER)%の胸元にそっと抱きつく
		PRINTFORML 
		PRINTFORMW 「アンタとじゃないと…イヤ、かな…………。もうっ！　こんな恥ずかしいこと言わせないでよねっ」
		PRINTFORML 
		PRINTFORMW 甘い雰囲気の中、二人はしばらく抱き合ってその想いを確かめ合った……
		PRINTFORML 
		PRINTFORMW 「……私、独占欲強いから。ちゃんと構ってくれないとヤだからね？」
	;それ以外
	ELSE
		PRINTFORMW 「……居たかー。まあ、アンタだしなー…」
		PRINTFORML 
		PRINTFORMW ポリポリと頭を掻いた後、しばし考えた%ANAME(TARGET)%は%ANAME(MASTER)%に顔を向けた
		PRINTFORML 
		PRINTFORMW 「ま、私可愛いし、そういうこともあるかっ！」
		PRINTFORML 
		PRINTFORMW そしてニカッと笑い、%ANAME(MASTER)%と手を繋いだ
		PRINTFORML 
		PRINTFORMW 「私もアンタのこと、別に嫌いじゃないしね。アンタが嫌になるまでは付き合ってあげるわー♪」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%はずいぶんな上機嫌だ
		PRINTFORML 
		PRINTFORMW 何だかんだ、普段嫌われている自分を好いてくれる%ANAME(MASTER)%のことを好ましく想っているようだ
	ENDIF
	RESETCOLOR
	PRINTFORML 
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTL 
	PRINTFORMW 「……聞かなかったことにしてあげる。もう馬鹿なことは考えないようにしなさい」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL 
	PRINTFORML 「ああ…もう、だめだってぇ……」
	PRINTFORMW %ANAME(TARGET)%は酔いが回って%ANAME(MASTER)%を拒みきれないようだ
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL 
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「きゃぁっ！　………ほ、本気…、なの？」
		PRINTFORMW %ANAME(MASTER)%に押し倒された%ANAME(TARGET)%は、ついにこの時が来たのか、といった風情で%ANAME(MASTER)%を見つめている
		PRINTFORML その細腕からは抵抗を感じられず、%ANAME(MASTER)%に身を委ねているように見える
		IF TALENT:処女
			PRINTFORMW 「わ、…私、その……初めてだから」
			PRINTFORMW 「……優しく、して…♥」
			PRINTFORML 普段の小生意気な雰囲気は鳴りを潜め、顔を赤らめながら上目遣いで%ANAME(MASTER)%をぽぉっと見つめる%ANAME(TARGET)%は
			PRINTFORMW とても儚く、いつになく可愛らしい存在に見え、%ANAME(MASTER)%の雄の本能を大いに刺激した
		ELSE
			PRINTFORML 「…私が疫病神だって、分かって抱こうとしてるんだよね？」
			PRINTFORMW %ANAME(MASTER)%が縦に首を振ると、%ANAME(TARGET)%は呆れたような嬉しそうな、そんな表情で%ANAME(MASTER)%を受け入れた
			PRINTFORMW 「まったく、アンタには負けたわ。…ちゃんとキモチよくしてくれないとヤよ？」
		ENDIF
	;それ以外
	ELSE
		PRINTFORML 「…女だったら見境無いの？　まったく……」
		PRINTFORMW %ANAME(TARGET)%は諦めた様子で、%ANAME(MASTER)%のことを受け入れている
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL 
	PRINTFORMW 「ちょ、ちょっとっ…止めてったら！！」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL 
	;親愛
	IF TALENT:親愛 && CFLAG:240 == 1
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「あっ、…今日も抱いてくれるの？」
				PRINTFORML %ANAME(TARGET)%は嬉しそうに服を脱ぎ、%ANAME(MASTER)%に抱きつく
				PRINTFORMW 「今日も私のこと…いっぱい愛してね♥」
			CASE 1
				PRINTFORML 「きゃっ！　…ふふ♥　もう我慢できない？」
				PRINTFORML %ANAME(TARGET)%は全身から力を抜き、%ANAME(MASTER)%のことを心から受け入れている
				PRINTFORMW 「私ももう我慢できないの…。いっぱいいっぱいキモチよくして？」
			CASE 2
				PRINTFORML 「ひゃっ、…もう、そんなにがっつかなくても大丈夫よ。私は逃げたりしないから…♥」
				PRINTFORML 押し倒された%ANAME(TARGET)%は%ANAME(MASTER)%にキスをする。その表情は既に蕩けている
				PRINTFORMW 「私も%ANAME(MASTER)%に抱かれるの、大好きだから…♥　今日もいっぱいシてね♥」
		ENDSELECT
	;恋慕か服従
	ELSEIF TALENT:恋慕 || TALENT:服従
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「わわっとっ！　…もう、我慢できないの？」
				PRINTFORMW 「まったく変わり者なんだから…♥　……ちゃんとキモチよくしてよ？」
			CASE 1
				PRINTFORML 「きゃっ！　…き、今日もするの？」
				PRINTFORML %ANAME(TARGET)%はそう言いつつも身体から力を抜き、%ANAME(MASTER)%のことを受け入れている
				PRINTFORMW 「べ、別に嫌なんじゃないわよっ？　私を抱きたがるのなんてアンタくらいだし…♥」
			CASE 2
				PRINTFORML 「ひゃんっ！　…もう、脅かさないでよねー」
				PRINTFORML 押し倒された%ANAME(TARGET)%は%ANAME(MASTER)%の頬をぺちぺちすると、機嫌を直して笑顔を向ける
				PRINTFORMW 「ヤルならちゃんと、キモチよくしてちょうだいよね♥」
		ENDSELECT
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	PRINTFORMW 「ち、ちょっと待って……」
	RETURN 0
ENDIF

;-------------------------------------------------
;気力限界(通常)
;-------------------------------------------------
IF ARG == 12
	PRINTFORMW 「もうやめてぇ……」
	RETURN 0
ENDIF

;-------------------------------------------------
;怒りの限界で追い返される
```
