# 口上/99 雷鼓口上/_KOJO_EVENT_K99.ERB — 自动生成文档

源文件: `ERB/口上/99 雷鼓口上/_KOJO_EVENT_K99.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K99; UI/print

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
@KOJO_EVENT_K99(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	PRINTFORMW 「う～ん！」
	PRINTFORMW 雷鼓は背中を伸ばしてリラックスしながら身を屈め上目遣いにこちらを向いた。
	PRINTFORMW 「今日はありがと、楽しかったわ…だからね…」
	PRINTFORMW 雷鼓は少し顔を赤らめながら顔を近づけ―――
	PRINTFORMW 
	PRINTFORMW 　　　　一瞬で唇を奪われた。
	PRINTFORMW 
	PRINTFORMW あまりにも静かに、いつもの雷鼓らしくないような陰を見せながら言葉を紡ぐ。
	PRINTFORMW 「…お礼…嫌だったかしら…？」
	PRINTFORMW 稲妻のごとき速さで音も無くキスされ、%ANAME(MASTER)%は反応できなかった。
	PRINTFORMW しばらく気まずい雰囲気が流れた後、そんなことない、と言うと雷鼓ははにかんだ笑顔で言う。
	PRINTFORMW 「それじゃ…今日はこれでお開きね、お疲れ様！」
	PRINTFORMW 顔を真っ赤にしながら飛び去っていく。
	PRINTFORMW (何やってんだろ…私…)
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 雷鼓、
		PRINTFORMW 「？」
		PRINTFORMW 「何、どうしたの？」
		PRINTFORMW 雷鼓は嬉しそうに振り返りながら笑みを浮かべている。
		PRINTFORMW 数瞬の間を置いて、%ANAME(MASTER)%は意を決して口を開く。
		PRINTFORMW 雷鼓…さん…
		PRINTFORMW 「どうしたの？言いたいことがあるのなら…」
		PRINTFORMW 
		PRINTFORMW ―――付き合ってください。
		PRINTFORMW 
		PRINTFORMW 少し間が空いて彼女の口が開き、そこから出た言葉は
		PRINTFORMW 「いいわよ？私でよければ」
		PRINTFORMW あっさりとした同意だった。
		PRINTFORMW 「ん？どうかしたの？」
		PRINTFORMW 緊張の糸が途切れへたり込んでいると雷鼓は手を差し伸べてくれた。
		PRINTFORMW 「…もう、私と付き合いたいってならしゃんとしなさい！」
		PRINTFORMW こういう時に腰が抜けるのはダメな男だということか…
		PRINTFORMW 「あら、私の目に狂いがなければ結構いい男よ、貴方」
		PRINTFORMW …情けなくなってきた…
		PRINTFORMW 「まあとりあえず、」
		PRINTFORMW 「これからもよろしくね、%ANAME(MASTER)%」
		PRINTFORMW 立ち上がらせた%ANAME(MASTER)%に抱きつくと、そう言いながらにっこりと彼女は微笑んだ。
	;それ以外
	ELSE
		PRINTFORMW 「へぇ？私と付き合いたい？」
		PRINTFORMW 「いいわ、付き合ったげる%UNICODE(0x2665) *1%」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTFORMW 雷鼓―――
	PRINTFORMW そう呼びかけようとして喉から出たのは空を切るひゅうひゅうという音だった。
	PRINTFORMW 「大丈夫！？ちょっと喘息とかじゃ―――」
	PRINTFORMW 雷鼓はあわてた様子で心配してくれている。
	PRINTFORMW そんなんじゃないんだ、言いたいことがあったんだ…
	PRINTFORMW 想いは出鼻とともに挫かれ次の機会を待つこととなる。
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTFORMW 「んーえっちー…変態～」
	PRINTFORMW 「…今変なことされたら…抵抗できないわ…%UNICODE(0x2665) *1%」
	PRINTFORMW そう言いながら雷鼓は%ANAME(MASTER)%を誘っている。
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		IF RAND:4 == 0
			PRINTFORMW 「ん…いい、わよ」
			PRINTFORMW 「じゃあ、よろしくお願いします…」
			PRINTFORMW 「…痛くしないでね…？」
		ELSEIF RAND:3 == 0
			PRINTFORMW 「あ…それじゃあ…」
			PRINTFORMW 「…よろしくお願いします…」
			PRINTFORMW 「痛くするのは…嫌よ？」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「えっと…」
			PRINTFORMW 「優しく…してね…」
		ELSE
			PRINTFORMW 「ん…」
			PRINTFORMW 「気持よくしてね…」
		ENDIF
	;それ以外
	ELSE
		IF RAND:3 == 0
			PRINTFORMW 「…ん！？」
			PRINTFORMW 「いいわよ…好きになさい…」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「…気持よくしてね」
		ELSE
			PRINTFORMW 「責任は取ってもらうわよ？」
		ENDIF
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	IF RAND:4 == 0
		PRINTFORMW 「ん？」
		PRINTFORMW 「駄目よ」
		PRINTFORMW 「まだ…そういう気分じゃないの」
	ELSEIF RAND:3 == 0
		PRINTFORMW 「え？」
		PRINTFORMW 「…そうねぇ…」
		PRINTFORMW 「もうちょっと雰囲気整えてくれたら…いいわよ？」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「えっと…」
		PRINTFORMW 「そういう気分じゃあないなぁって…」
	ELSE
		PRINTFORMW 「今はあんまりそういう気分じゃないの」
		PRINTFORMW 「だから…ごめんね」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	IF RAND:15 == 0
		PRINTFORMW 「ん…そんなに溜まってたの…？」
	ELSEIF RAND:14 == 0
		PRINTFORMW 「%ANAME(MASTER)%、エッチな匂いしてる…」
	ELSEIF RAND:13 == 0
		PRINTFORMW 「もう…私まで興奮してきちゃったじゃない…」
	ELSEIF RAND:12 == 0
		PRINTFORMW 「じゃあ…よろしくね…」
	ELSEIF RAND:11 == 0
		PRINTFORMW 「貴方となら…何してもいいわよ…」
	ELSEIF RAND:10 == 0
		PRINTFORMW 「優しく…ね？激しいのもいいけど」
	ELSEIF RAND:9 == 0
		PRINTFORMW 「今日は…激しくして…ね」
	ELSEIF RAND:8 == 0
		PRINTFORMW 「ん…気持よくして…」
	ELSEIF RAND:7 == 0
		PRINTFORMW 「こういうのも…好きよ…」
	ELSEIF RAND:6 == 0
		PRINTFORMW 「優しくしてよ…」
	ELSEIF RAND:5 == 0
		PRINTFORMW 「何？押し倒しちゃってきて」
	ELSEIF RAND:4 == 0
		PRINTFORMW 「…何して欲しい？」
	ELSEIF RAND:3 == 0
		PRINTFORMW 「…ん！？」
		PRINTFORMW 「いいわよ…好きになさい…」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「…気持よくしてね」
	ELSE
		PRINTFORMW 「責任は取ってもらうわよ？」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	PRINTFORMW 「ん…今日は…ここまで…で」
	PRINTFORMW 「お願い…疲れちゃったから…」
	RETURN 0
ENDIF

;-------------------------------------------------
;気力限界(通常)
;-------------------------------------------------
IF ARG == 12
```
