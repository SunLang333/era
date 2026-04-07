# 口上/134 ドレミー口上/_KOJO_EVENT_K134.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/_KOJO_EVENT_K134.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K134; UI/print

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
@KOJO_EVENT_K134(ARG)
#DIM ドレミ
;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「んっ…」
		PRINTFORMW ほんのりと熱を帯びた吐息がかかった
		PRINTFORMW %ANAME(TARGET)%は更に求めるような口づけをしてきた
		PRINTFORMW 「ふぅ…ふぅ…。　キスって、良いわね…」
		PRINTFORMW 紅潮した%ANAME(TARGET)%の舌や唇、歯までも味わった…
	;恋人
	ELSEIF TALENT:恋人
		PRINTFORMW 「はぁはぁ…」
		PRINTFORMW ほんのりと熱を帯びた吐息がかかった
		PRINTFORMW %ANAME(TARGET)%は更に求めるような口づけをしてきた
		PRINTFORMW 「ふぅ…ふぅ…。　もっと…もっと…」
		PRINTFORMW 妖怪らしく長い舌を出し、激しく深い口づけをしてきた
		PRINTFORMW 歯の裏…舌の下…口天井…喉元まで深い舌の愛撫を受けた…
	;それ以外
	ELSE
		PRINTFORMW 「んっ…」
		PRINTFORMW ほんのりと熱を帯びた吐息がかかった
		PRINTFORMW %ANAME(TARGET)%は更に求めるような口づけをしてきた
		PRINTFORMW 「ふぅ…ふぅ…」
		PRINTFORMW ほんのり濡れた唇が更なるキスを求めている…
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「（…随分と長く待たされたわねぇ）」
		PRINTFORMW 「ん？あ、いや何でも？」
		PRINTFORML
		PRINTFORMW 「……」
		PRINTFORMW 「…そうですねぇ、どうしましょうかねぇ…」
		PRINTFORML
		PRINTFORMW 「私が欲しいですかぁ？」
		PRINTFORMW 「シンプルな告白も良いですけど…もっと思いの丈を叫んで欲しいですねぇ」
		PRINTFORML
		PRINTFORMW 「！？！？！？」
		PRINTFORMW 「そんな大声で叫ばなくても！？」
		PRINTFORMW 「あぁもう！分かったから！分かったから～っ！」
		PRINTFORML
		PRINTFORMW 二人の関係は瞬く間に周知されていった
	;それ以外
	ELSE
		PRINTFORMW 「恋人ですか…ええ、いいですよ」
		PRINTFORMW 「私も別にあなたの事は嫌いじゃないですからねぇ」
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
		PRINTFORMW 「！？」
		PRINTFORMW 「(ど、どうしよう…心の準備が…)」
		PRINTFORMW 「ちょ…ちょっと待って貰える？」
	;それ以外
	ELSE
		PRINTFORMW 「んー、私達はそういう関係ではないでしょう？」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意は得られない);実質酔った時専用？
;-------------------------------------------------
IF ARG == 4
	PRINTFORML 「ん……？な、なに…？」
	PRINTFORMW %ANAME(TARGET)%は普段は決して見せないようなあられもない姿で仰臥している
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕
	IF TALENT:恋慕
		PRINTFORMW 「……おやおや」
		PRINTFORMW 「…少し鼻息が荒いようですねぇ」
		PRINTFORMW 「いえそれくらい情熱的である方が嬉しいです」
		PRINTFORML
		PRINTFORMW 「…優しくしてくださいね？」
		PRINTFORML 
	;服従 or 烙印
	ELSEIF TALENT:服従 || TALENT:烙印
		PRINTFORMW 「…いつかは来ると分かっていましたよ」
		PRINTFORMW 「もう私はあなたのもの」
		PRINTFORMW 「でも今日は…優しくして欲しいなって…」
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORMW 「ははぁん、随分と急ですねぇ」
		PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%に両腕を押さえつけられ完全に身動きが取れない
		PRINTFORMW 余裕のある言葉を並べている%ANAME(TARGET)%だがその声色は震えている
		PRINTFORMW 「それで私をどうするおつもりで？」
		PRINTFORML 
		PRINTFORMW 「どうせ前々から私をこうするつもりだったのでしょう…」
		PRINTFORML 
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTFORML 抱き寄せようとした途端%ANAME(TARGET)%がするりとあなたから離れた
	PRINTFORMW どうやら察されていたようだ
	PRINTFORML 
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	;妊娠
	IF TALENT:妊娠
		PRINTFORMW 「えっ……今！？」
		PRINTFORMW 「その…良いんだけど」
		PRINTFORMW %ANAME(TARGET)%は心配そうにお腹を撫でた……
	;正妻
	ELSEIF TALENT:正妻
		IF RAND:3 == 0
			PRINTFORMW 「呆れるほど…元気ですねぇ」
			PRINTFORMW 「…んもぅ」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「それで今日はどういうプレイをするの？」
			PRINTFORMW 「あまりハードなのは止めて欲しいのだけれど…」
			PRINTFORMW 「されても付き合っちゃうんだろうけど…」
		ELSE
			PRINTFORMW 「…子供…作らない？」
			PRINTFORMW %ANAME(TARGET)%は催促するように甘い声を出した……
		ENDIF
	;恋慕
	ELSEIF TALENT:恋慕
		IF RAND:3 == 0
			PRINTFORMW 「呆れるほど…元気ですねぇ」
			PRINTFORMW 「…んもぅ」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「それで今日はどういうプレイをするの？」
			PRINTFORMW 「あまりハードなのは止めて欲しいのだけれど…」
			PRINTFORMW 「されても付き合っちゃうんだろうけど…」
		ELSE
			PRINTFORMW 「んっ…、今日はちょっと強く…抱いて」
		ENDIF
	;服従 or 烙印
	ELSEIF TALENT:服従 || TALENT:烙印
		IF RAND:3 == 0
			PRINTFORMW 「今日は何をするつもり…？」
			PRINTFORMW 「せめて…優しくして…お願い」
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
			PRINTFORMW 「随分と急ですねぇ、良いですよ」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「呆れるほど元気ですねぇ…」
			PRINTFORMW 「しょうがないので相手してあげましょう」
		ELSE
			PRINTFORMW 「全部あなたに委ねているわけじゃないので」
			PRINTFORMW 「勘違いしないでくださいね？」
		ENDIF
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;真名を許すイベント
;-------------------------------------------------
```
