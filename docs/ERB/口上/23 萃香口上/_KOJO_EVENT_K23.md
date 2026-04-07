# 口上/23 萃香口上/_KOJO_EVENT_K23.ERB — 自动生成文档

源文件: `ERB/口上/23 萃香口上/_KOJO_EVENT_K23.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K23; UI/print

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
@KOJO_EVENT_K23(ARG)
#DIM 霊夢
霊夢 = NAME_TO_CHARA("霊夢")

;-------------------------------------------------
;ファーストキス実行;現状死に口上
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「ん……、ふあ……んふふ♪　私の“初めて”はどうだい？」
		PRINTFORMW 唇を離すと、%ANAME(TARGET)%はにこやかな表情で尋ねてきた
		PRINTFORML 「よかった？　じゃあ、もっと…しておくれ？」
		PRINTFORMW 上目遣いの可愛らしい懇願に応えて、再び唇を重ねた
		PRINTFORML 「ぁん……♥」
		PRINTFORMW 欲張りな小鬼が満足するまで、何度も口づけを繰り返した 
	;恋人
	ELSEIF TALENT:恋人
		PRINTFORML 「ん……、ふあ……」
		PRINTFORMW 唇を離すと、%ANAME(TARGET)%は少し物足りなさそうな表情を浮かべた
		PRINTFORML 「ねぇ、もう一回…い、いやっ！　やっぱり何でもないよ！」
		PRINTFORMW %ANAME(TARGET)%は顔を赤くして慌てている
		
	;それ以外
	ELSE
		PRINTFORML 「…この%ANAME(TARGET)%様の唇を奪うとはねぇ」
		PRINTFORMW 唇を離すと、%ANAME(TARGET)%は唇に指を当て、少し照れくさそうにしている
		PRINTFORMW 「私の“初めて”を上げたんだ。ちゃんと責任とれよ？」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	PRINTL
	SETCOLOR カラー_オレンジ
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「…本気かい？」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の告白に驚いている
		PRINTFORML 
		PRINTFORMW 「…私は一応、おっそろしい鬼なんだぞ……お馬鹿…」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%に近づき、腰に手を回して抱きついてきた
		PRINTFORML 
		PRINTFORMW 「でもアンタのそういう、怖いもの知らずなところ、嫌いじゃない…ていうか…」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%を見上げて言った
		PRINTFORML 
		PRINTFORMW 「……私も…好きだよ。…%ANAME(MASTER)%のこと…」
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%を見上げる%ANAME(TARGET)%の頬は、赤く染まっていた
		PRINTFORML 
		PRINTFORMW 「ははっ♪　私ら、お互いとっくに好き合ってたってことかい」
		PRINTFORML 
		PRINTFORMW 頬を赤くしたまま、%ANAME(TARGET)%は満面の笑みを浮かべた
		PRINTFORML 
		PRINTFORMW 「じゃあ、今から私たちは恋人同士って訳だ。改めて、これからもよろしくな！」
		PRINTFORML 
		PRINTFORML 
		PRINTFORMW 
		PRINTFORMW 「あ、ちなみに私は浮気がどうとか気にしないからな。男は甲斐性が大事だぞ？」
		PRINTFORML 
		SIF !(MASTER == NAME_TO_CHARA("霊夢")) 
			PRINTFORMW 「だからどんどんコマシちゃいな。あ、霊夢とかどうだ？　アイツはいい女になるぞー♪」
	;それ以外
	ELSE
		PRINTFORMW 「私のことが好きだって？　ふふん、中々見る目があるね、%ANAME(MASTER)%は」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は瓢箪に入った酒を煽った。そしてしばしの沈黙の後…
		PRINTFORML 
		PRINTFORMW 「……いいよ、その話乗った。私もアンタのこと、嫌いじゃないしね」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は片目を閉じ、%ANAME(MASTER)%にウインクしてみせた
		PRINTFORML 
		PRINTFORMW 「それじゃあ、今から私たちは恋人同士って訳だ。改めて、これからもよろしくな♪」 
	ENDIF
	PRINTFORML 
	RESETCOLOR
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTL
	SETCOLOR カラー_オレンジ
	PRINTFORML 「…うーん、悪い。気持ちは分かったけど、今はそういう気持ちになれないよ」
	PRINTFORMW %ANAME(TARGET)%はしばし悩んだ後、そう言った
	PRINTFORML 「まぁでも、%ANAME(MASTER)%の事は嫌いなわけじゃないよ。本当さ」
	PRINTFORMW 「もう少し%ANAME(MASTER)%の事を見極めさせてもらうよ。そしたら、私も気が変わるかもしれないからさ」
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL
	PRINTFORMW 「ちょ、ちょっと待ってよ。まだ心の準備って奴がさぁっ」
	PRINTFORML …
	PRINTFORML ……
	PRINTFORMW ………
	PRINTFORML （うむむ、拝み倒されてしまった…）
	PRINTFORMW （我ながら押しに弱いなぁ…。酔いすぎたかな）
	PRINTFORMW %ANAME(TARGET)%はしぶしぶながら、身体を任せている
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「おわっ！　……私を抱くのかい？　…ふふ、なら自分だけじゃなくて、私も気持ちよくしておくれよ♪」
		PRINTFORMW 押し倒されても%ANAME(TARGET)%は抵抗せずに、%ANAME(MASTER)%に身体を委ねている
		PRINTFORML 「とはいえ、ちょっと恥ずかしいな…。私の裸なんて、見て楽しいものじゃないだろう？」
		PRINTFORML そんなことは無い。女性らしい豊満な肉付きは無くとも、
		PRINTFORMW すらりと伸びたスレンダーな手足と形の良い胸と尻のバランス、何よりほんのりと朱を帯びる肌の美しさがとても艶めかしい…
		PRINTFORML 「わ、わかったわかったって。…ったく、この身体のことそんな風に見てたとはね……物好きなんだから…♥」
		PRINTFORML %ANAME(TARGET)%は頬を染めながら、%ANAME(MASTER)%の服に手をかける
		PRINTFORMW 「さあさ、%ANAME(MASTER)%も脱いでよね。私にもお前さんの身体を見せてもらうよ♪」
	;それ以外
	ELSE
		PRINTFORML 「わ、私みたいな身体でいいのかい？　自分で言うのもなんだけど、ちんちくりんだぞ？」
		PRINTFORMW そういうのも嫌いじゃない。むしろフェイバリット！
		PRINTFORML 「そ、そうか……。はぁ、しょうがないなあ。でも私の方も気持ちよくしてよ？」
		PRINTFORMW 謎の凄みに押された%ANAME(TARGET)%は、諦めたように服を脱ぎ始めた
	ENDIF
	PRINTFORML 
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL
	PRINTFORML 「おおっ！？　ち、ちょっと待っ……どりゃーっ！」
	PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に投げ飛ばされた
	PRINTFORML 「い、いきなり何するんだよまったく！」
	PRINTFORMW %ANAME(TARGET)%は顔を真っ赤にして怒っている
	PRINTFORML 「物事には順序ってもんがあるだろ！　私だって一応女なんだぞ！」
	PRINTFORMW 痛みに呻きながらも、%ANAME(MASTER)%は必死に頭を下げて謝った
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL
	;親愛 or 隷属
	IF TALENT:親愛 || TALENT:隷属
		SELECTCASE RAND:9
			CASE 0
				PRINTFORML 「ははっ♪　その言葉、待ってたよー、んー……ちゅっ♥」
				PRINTFORMW 「こっちの準備は万全だからねー♪」
				PRINTFORML 「さあ、%ANAME(MASTER)%のための身体、たっぷり味わってみな♥」
				PRINTFORMW 腰をくねらせながら、%ANAME(TARGET)%は淫靡に笑う
			CASE 1
				PRINTFORML %ANAME(TARGET)%は服を脱ぐと、貴方に強く抱きつく
				PRINTFORMW 「つくづく思うよ。鬼ほど愛情深くて激しいものはないってさ」
				PRINTFORML 「……お前さんへの私の愛、味わっていってよ♥」
				PRINTFORMW 情欲と愛情に塗れ光る瞳で%ANAME(TARGET)%は熱っぽく囁いた
			CASE 2
				PRINTFORML %ANAME(TARGET)%は服を脱ぐと、%ANAME(MASTER)%に抱きついた
				PRINTFORMW 「今夜も愛してくれるんでしょ？　本当に嬉しいよぉ♥」
				PRINTFORMW 可愛らしい乳首を%ANAME(MASTER)%に押し当てながら、%ANAME(TARGET)%は色っぽく笑った
			CASE 3
				PRINTFORML 「するのかい？　……この助平め♥」
				PRINTFORMW %ANAME(TARGET)%は自ら服をはだけて、%ANAME(MASTER)%の手を自分の胸に押し当てた
				PRINTFORML 「こんな小さな身体でもお前さんはちゃんと愛してくれる…、本当に嬉しいんだよ」
				PRINTFORMW 「だからさ。私もいっぱい愛してあげる。いっぱい気持ちよくしてあげるからな♥」
			CASE 4
				PRINTFORML 「今回は私が脱がしてあげる。ほーら、力を抜いてー」
				PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の服を脱がしにかかった
				PRINTFORML 「ははっ、もう下の方はビンビンだねぇ♪　私に脱がされて興奮しちゃったんだぁ♥」
				PRINTFORMW %ANAME(TARGET)%は期待に満ちた眼で%ANAME(MASTER)%を見ている
			CASE 5
				PRINTFORML 「……ふふ♥　なんだい？　脱ぐところ見たいのかい♪」
				PRINTFORMW %ANAME(TARGET)%は頬を染めながら、%ANAME(MASTER)%の方を向いて服を脱ぎ始めた
				PRINTFORMW 「まじまじ見られるの、まだちょっと恥ずかしいけど…。%ANAME(MASTER)%に見てもらうの、好き…♥」
			CASE 6
```
