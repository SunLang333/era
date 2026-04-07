# 口上/83 青娥口上/_KOJO_EVENT_K83.ERB — 自动生成文档

源文件: `ERB/口上/83 青娥口上/_KOJO_EVENT_K83.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K83; UI/print

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
@KOJO_EVENT_K83(ARG)

;-------------------------------------------------
;ファーストキス実行;現状死に口上
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「ん……、ふぅ……」
		PRINTFORMW 唇を離すと、%ANAME(TARGET)%は少し物足りなさそうな表情を浮かべた
		PRINTFORMW 「一度では足りませんわ…もっとしてくださいまし♥」
	;恋人
	ELSEIF TALENT:恋人
		PRINTFORML 「ん……、うふふ♪　私の“初めて”はどうでした？」
		PRINTFORMW 唇を離すと、%ANAME(TARGET)%はにこやかな表情で尋ねてきた
		PRINTFORML 「良かったですか？　じゃあ、もっと…しますか？」
		PRINTFORMW 妖艶な問いかけに応えて、再び唇を重ねた
		PRINTFORML 「ん……♥」
		PRINTFORMW 欲張りな仙人が満足するまで、何度も口づけを繰り返した 
		
	;それ以外
	ELSE
		PRINTFORML 「…仙人の“初めて”の味はどうでしたか？」
		PRINTFORMW 唇を離すと、%ANAME(TARGET)%は唇に指を当て、少し照れくさそうにしている
	ENDIF
	RETURN 1
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	PRINTL 
	SETCOLOR 0x01A9DB
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「え……、ほ、本気ですか？」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の告白に驚いている
		PRINTFORML 
		PRINTFORMW 「えと、その…、私、器量は好いつもりですから、そういうこと言われるの、何度かありましたけど…」
		PRINTFORML 
		PRINTFORMW 「…%ANAME(MASTER)%は、今までの付き合いで私がどんな女か、ある程度分かっているのではないですか？」
		PRINTFORML 
		PRINTFORMW 「私は邪仙と呼ばれている女ですよ…？　いや、自分ではそういうつもりは全然無いんですけど」
		PRINTFORML 
		PRINTFORMW 「……そんな女で…良いんですか…？」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%を見据えて言った。心なしか瞳が潤んでいる気がした
		PRINTFORML 
		PRINTFORMW ― それでも良い。そういう%ANAME(TARGET)%だからこそ好きになったんだ ―
		PRINTFORML 
		PRINTFORMW 「……嬉しいです♥」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%と%ANAME(MASTER)%は熱い抱擁を交わした。%ANAME(TARGET)%の眼から一筋の涙がこぼれた
		PRINTFORML 
		PRINTFORMW 「え、あっ、なんで…もう、小娘じゃあるまいし…♪」
		PRINTFORML 
		PRINTFORMW 照れながらも涙をぬぐう%ANAME(TARGET)%。そして%ANAME(MASTER)%の胸元に顔を埋めて囁いた
		PRINTFORML 
		PRINTFORMW 「……私、欲深い女です。だからちゃんと、愛してくださいね♪」
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORMW 「私のことが、好き…ですか」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%はしばしの沈黙の後
		PRINTFORML 
		PRINTFORMW 「正直、言われ慣れている言葉ですが、……%ANAME(MASTER)%に好かれるというのも素敵ですね♪」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%に顔を寄せて囁いてきた
		PRINTFORML 
		PRINTFORMW 「それじゃあ、今から私たちは恋人同士ですね。これからもよろしくお願いしますわ♪」 
		PRINTFORML 
	ENDIF
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTL 
	SETCOLOR 0x01A9DB
	PRINTFORML 「…%ANAME(MASTER)%のこと、嫌いではないですよ」
	PRINTFORMW 「でもすみません。今はそういう気持ちになれないんです」
	PRINTFORMW %ANAME(TARGET)%はしばし悩んだ後、そう告げた
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL 
	PRINTFORML 「あ、ちょっと、そんな無理やり……あん♥」
	PRINTFORMW %ANAME(TARGET)%は酔いが回って力が入らない様子だ
	PRINTFORML
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL 
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「あん……私を抱きたいのですか？　…ふふっ、しょうがないですね」
		PRINTFORMW %ANAME(TARGET)%は抵抗することなく、%ANAME(MASTER)%に身体を委ねている
		PRINTFORML 「……実はちょっと…こうされることを望んでいました…♥」
		PRINTFORMW %ANAME(TARGET)%は頬を染めて、%ANAME(MASTER)%の服に手をかけた
		PRINTFORMW 「さあ、私だけ裸なんて不公平ですわ。%ANAME(MASTER)%も脱いでください♥」
	;それ以外
	ELSE
		PRINTFORML 「ふふ、そんなに私を抱きたいですか？　仕方ないですね」
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の目の前で服を脱いでゆく
		PRINTFORMW 「どうせなら、私も気持ちよくしてね」
	ENDIF
	PRINTFORML
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL 
	PRINTFORML 「あら、おいたはいけませんわ 」
	PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に腕をひねられ、ひっくり返された
	PRINTFORMW 「…こういうことはもっと親しくなってから、ですよ」
	PRINTFORML
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL 
	;親愛 or 隷属
	IF TALENT:親愛 || TALENT:隷属 || TALENT:所有者
		SELECTCASE RAND:7
			CASE 0
				PRINTFORML 「あん…もう待ちきれないですか？　ふふ、私もです♥」
				PRINTFORMW 「さぁ、私の身体、心ゆくまで堪能していって♥」
				PRINTFORMW 腕を%ANAME(MASTER)%の首元に絡めて、%ANAME(TARGET)%は淫靡に笑う
			CASE 1
				PRINTFORML %ANAME(TARGET)%は服を脱ぐと、貴方に抱きつく。その表情は既に蕩けていた
				PRINTFORMW 「%ANAME(MASTER)%に抱かれるの、大好きなの…。今日もいっぱい、愛してください♥」
				PRINTFORMW 情欲と愛情に塗れ光る瞳で%ANAME(TARGET)%は熱っぽく囁いた
			CASE 2
				PRINTFORML %ANAME(TARGET)%は服を脱ぐと、%ANAME(MASTER)%に抱きついた
				PRINTFORMW 「今日もたっぷり、私に愛を注いでくださいまし♥」
			CASE 3
				PRINTFORML 「あん♥　もう我慢できませんか？」
				PRINTFORMW %ANAME(TARGET)%は服をはだけて、%ANAME(MASTER)%の手を自分の胸に強く押し当てた
				PRINTFORMW 「今日もいっぱい愛して…私をメチャクチャにしてぇ♥」
			CASE 4
				PRINTFORML 「ふふ、今回は私が脱がしてあげる。ほら、力を抜いて…♥」
				PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の服を手を掛ける。脱がしに掛かる手つきが艶かしい
				PRINTFORML 「あん♥　もう下の方はビンビン♪ 私に脱がされて興奮したんですね♥」
				PRINTFORMW %ANAME(TARGET)%は期待に満ちた眼で%ANAME(MASTER)%を見ている
			CASE 5
				PRINTFORML 「やーん♥　犯されちゃいますわー♥　それはもうめちゃくちゃにー♥」
				PRINTFORMW %ANAME(TARGET)%はノリノリで体をくねらせ、%ANAME(MASTER)%誘ってきている
			CASE 6
				PRINTFORML 「あん…ふふ、そんなに焦らなくとも大丈夫♥　私は逃げませんから…」
				PRINTFORMW %ANAME(TARGET)%が服を脱ぐたび、彼女の芳しい香りが鼻腔をくすぐり劣情を煽る
				PRINTFORMW 「さぁ…今日もたくさん愛して♥」
		ENDSELECT
	;恋慕 or 服従
	ELSEIF TALENT:恋慕 || TALENT:服従 || TALENT:親友 || TALENT:主人
		SELECTCASE RAND:7
			CASE 0
				PRINTFORML 「あん…もう待ちきれないですか？」
				PRINTFORMW 「ふふ、いいですよ…仙人の房中術、堪能していってくださいな♥」
				PRINTFORMW 腰をくねらせながら、%ANAME(TARGET)%は淫靡に笑う
			CASE 1
				PRINTFORML %ANAME(TARGET)%は艶かしく服を脱ぐと、そっと%ANAME(MASTER)%に抱きつく
				PRINTFORMW 「%ANAME(MASTER)%に抱かれるの、私好きなんです…いっぱい可愛がってください♥」
				PRINTFORMW 情欲と恋慕に塗れ光る瞳で%ANAME(TARGET)%は熱っぽく囁いた
			CASE 2
				PRINTFORML %ANAME(TARGET)%は服を脱ぐと、%ANAME(MASTER)%に抱きついた
				PRINTFORMW 「今日もたっぷり、愛を注いでくださいまし♥」
			CASE 3
				PRINTFORML 「あん♥　もう我慢できませんか？」
				PRINTFORMW %ANAME(TARGET)%は服をはだけて、%ANAME(MASTER)%の手を自分の胸に押し当てた
				PRINTFORMW 「いっぱい愛してくださいね♥」
```
