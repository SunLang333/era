# 口上/87 マミゾウ口上/_KOJO_EVENT_K87.ERB — 自动生成文档

源文件: `ERB/口上/87 マミゾウ口上/_KOJO_EVENT_K87.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K87; UI/print

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
@KOJO_EVENT_K87(ARG)
SIF CFLAG:400 == 1
	RETURN

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		;PRINTFORMW 
	;恋人
	ELSEIF TALENT:恋人
		;PRINTFORMW 
	;それ以外
	ELSE
		;PRINTFORMW 
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「（…遅いわ！）」
		PRINTFORMW 「ん？あ、いや何でもないぞ？」
		PRINTFORML
		PRINTFORMW 「……」
		PRINTFORMW 「…おほん、ぅおっほん！」
		PRINTFORML
		PRINTFORMW 「よいか？『恋人になる』『ならない』などという口約束だけでは何の意味も無いのじゃ」
		PRINTFORMW 「ここからどう転ぶかは…おぬしの行動次第じゃぞお？」
		PRINTFORMW %ANAME(TARGET)%は顔がニヤけるを堪えながら%ANAME(MASTER)%の次の反応を伺っている……
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORMW 「『恋人になる』『ならない』などという口約束だけでは何の意味も無いのじゃ」
		PRINTFORMW 「ここからどう転ぶかはおぬしの行動次第じゃぞお？」
		PRINTFORMW %ANAME(TARGET)%は少し上機嫌な様子で%ANAME(MASTER)%の次の反応を伺っている……
		PRINTFORML 
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「あ、慌てるでない！」
		PRINTFORMW 「…そういうのはもっとお互いに深く知り合ってからじゃ」
	;それ以外
	ELSE
		PRINTFORMW 「尻の軽い女と見くびってもらっては困るのう」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意は得られない);実質酔った時専用？
;-------------------------------------------------
IF ARG == 4
	PRINTFORML 「ぅ…む……？なんじゃぁ～…？」
	PRINTFORMW %ANAME(TARGET)%は普段は決して見せないようなあられもない姿で仰臥している
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕
	IF TALENT:恋慕
		PRINTFORMW 「ふぅ…、まったく……」
		PRINTFORML
		PRINTFORMW 「遅いんじゃよ！お前さんは！」
		PRINTFORMW 「あんまり手を出してこんから儂はてっきりその気が無いのかと…」
		PRINTFORML
		PRINTFORMW 「待ちくたびれて婆さんになるかとおもったぞい！」
		PRINTFORML 
	;服従 or 烙印
	ELSEIF TALENT:服従 || TALENT:烙印
		PRINTFORMW 「姿を見せた時点でいずれそう来るじゃろうと覚悟しておったよ…」
		PRINTFORMW 「儂はもうおぬしの味方じゃ…」
		PRINTFORMW 「今度は…、優しくしておくれよ？」
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORMW 「む…ぅ、ぬかったわ」
		PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%に両腕を押さえつけられ完全に身動きが取れないはずだが、
		PRINTFORMW いつでも逃げ出せると言いたいのかその表情からは余裕が消えていない。
		PRINTFORMW 「まあよい、この儂の不覚を付いた事に敬意を表して”ご褒美”という奴をやろうぞ」
		PRINTFORML 
		PRINTFORMW 「もともと、お前さんもそういうつもりだったんじゃろう？」
		PRINTFORML 
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTFORML 
	PRINTFORML ドロンと音がして腕に抱いたはずの%ANAME(TARGET)%の姿が消えた
	PRINTFORMW …どうやら化かされたようだ
	PRINTFORML 
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	;妊娠
	IF TALENT:妊娠
		PRINTFORMW 「儂もやぶさかではない、が……」
		PRINTFORMW 「お手柔らかに頼むぞ？」
		PRINTFORMW %ANAME(TARGET)%は心配そうにお腹を撫でた……
	;正妻
	ELSEIF TALENT:正妻
		IF RAND:3 == 0
			PRINTFORMW 「待て待て！そうがっつくでない！」
			PRINTFORMW 「…んもぅ」
		ELSEIF RAND:2 == 0
			PRINTFORML 「ほっほっほ」
			PRINTFORMW 「相変わらず元気が有り余っとるようじゃのぅ」
			PRINTFORMW 「…期待させてもらうぞ？」
		ELSE
			PRINTFORMW 「今度は…子供、欲しいのぅ…」
			PRINTFORMW %ANAME(TARGET)%は催促するように甘い声を出した……
		ENDIF
	;恋慕
	ELSEIF TALENT:恋慕
		IF RAND:3 == 0
			PRINTFORMW 「待て待て！そうがっつくでない！」
			PRINTFORMW 「…もぅ！」
		ELSEIF RAND:2 == 0
			PRINTFORML 「ほっほっほ」
			PRINTFORMW 「元気が有り余っとるようじゃな？」
			PRINTFORMW 「期待させてもらうとしようかのう」
		ELSE
			PRINTFORMW 「んっ…、優しく頼むぞ？」
		ENDIF
	;服従 or 烙印
	ELSEIF TALENT:服従 || TALENT:烙印
		IF RAND:3 == 0
			PRINTFORMW 「姿を見せた時点でそう来るじゃろうと覚悟しておったよ…」
			PRINTFORMW 「酷いことは…せんでくだされよ？」
		ELSEIF RAND:2 == 0
			PRINTFORML 「っ…！」
			PRINTFORMW %ANAME(TARGET)%は身を震わせているが決して拒絶はしない
			PRINTFORMW どうやら先の調教の効果はまだしっかり残っているようだ……
		ELSE
			PRINTFORML 「………ふぅ」
			PRINTFORMW %ANAME(TARGET)%は一つため息をつくと、全身を弛緩させて%ANAME(MASTER)%を受け入れた……
		ENDIF
	ELSE
		IF RAND:3 == 0
			PRINTFORMW 「待て待て！そうがっつくでない！」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「元気が有り余っとるようじゃな…」
			PRINTFORMW 「しょうがないのう。相手してやろうぞ」
		ELSE
			PRINTFORMW 「何もかも許したわけではないからな？」
			PRINTFORMW 「そこは勘違いしてもらっては困るぞ」
		ENDIF
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;真名を許すイベント
;-------------------------------------------------
IF ARG == 10
	PRINTFORMW 「うむ、儂の本当の名は秘湯混浴刑事エバラという……」
	PRINTFORMW ※このメッセージは本来表示され得ないメッセージです
	RETURN 0
ENDIF

;-------------------------------------------------
;デート中に向こうからキス
;-------------------------------------------------
IF ARG == 20
	PRINTFORML 「なんじゃ？化かされたような顔をしおって」
	PRINTFORML %ANAME(TARGET)%はからかうように喉の奥をくっくと鳴らすと、
	PRINTFORMW くるりと後ろを振り返り何事も無かったように歩き去っていく
```
