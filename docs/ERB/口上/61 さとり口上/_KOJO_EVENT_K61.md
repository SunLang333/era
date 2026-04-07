# 口上/61 さとり口上/_KOJO_EVENT_K61.ERB — 自动生成文档

源文件: `ERB/口上/61 さとり口上/_KOJO_EVENT_K61.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K61; UI/print

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
@KOJO_EVENT_K61(ARG)

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
	PRINTL 
	SETCOLOR 0xFF00FF
	;恋慕
	IF TALENT:恋慕
		PRINTFORMW 「……うふふ♥　どうしたんですか？　%ANAME(MASTER)%。何か言いたいことがあるんじゃないですか？　くすっ♪」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は嬉しそうに目を細め、%ANAME(MASTER)%の顔をニマニマと見つめている
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%が何を言おうとしているか。%ANAME(TARGET)%はその心を読んですでに分かっているようだ
		PRINTFORML 
		PRINTFORMW それでも自ら言葉にせずに%ANAME(MASTER)%の告白を待つのは、彼女なりの配慮だろう
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%は、%ANAME(TARGET)%らしいな、と思いつつ彼女に「好きだ。付き合って欲しい」と告白した
		PRINTFORML 
		PRINTFORMW 「……ふふっ、うふふ、生まれて初めて告白されちゃいました」
		PRINTFORML 
		PRINTFORMW 「小説とかでこういう場面を読んだことはありますけど、実際に体験するとやっぱり違いますね♪」
		PRINTFORML 
		PRINTFORMW そう言うと%ANAME(TARGET)%は浮かれた様子で%ANAME(MASTER)%に抱きつく
		PRINTFORML 
		PRINTFORMW 「…私も、%ANAME(MASTER)%が好きです。これからも、私とお付き合いしてください……♥」
		PRINTFORML 
		PRINTFORMW 甘い雰囲気の中二人は優しく抱き合い、お互いの心臓の鼓動を感じあっていた……
		
	;主人
	ELSEIF TALENT:主人
		PRINTFORMW 「……うふふ♥　どうしたの？　%ANAME(MASTER)%。何か言いたいことがあるんじゃない？　くすくすっ…♪」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は嬉しそうに目を細め、%ANAME(MASTER)%の顔をニマニマと見つめている
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%が何を言おうとしているか。%ANAME(TARGET)%はその心を読んですでに分かっているようだ
		PRINTFORML 
		PRINTFORMW それでも自ら言葉にせずに%ANAME(MASTER)%の告白を待つのは、彼女なりの配慮だろう
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%は、ご主人様らしい、と思いつつ彼女に「好きです。恋人にしてください」と告白した
		PRINTFORML 
		PRINTFORMW 「……ふふっ、うふふ♥　ペットから好きって言われることはあったけど…」
		PRINTFORML 
		PRINTFORMW 「%ANAME(MASTER)%みたいに、恋人にしてって言われたのは初めてだわ。こういう愛され方もあるのね…♪」
		PRINTFORML 
		PRINTFORMW そう言うと%ANAME(TARGET)%は%ANAME(MASTER)%を優しく抱きしめる
		PRINTFORML 
		PRINTFORMW 「…私も、%ANAME(MASTER)%が大好きよ。これからも、私と一緒にいてね……♥」
		PRINTFORML 
		PRINTFORMW 甘い雰囲気の中二人は優しく抱き合い、お互いの心臓の鼓動を感じあっていた……
		
	;それ以外
	ELSE
		PRINTFORMW 「あら？　どうしました？　……『付き合って欲しい』、ですか？　私と？　ふーん……」
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%が告白する前に、%ANAME(TARGET)%から心を読まれ言葉に出されてしまった……
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は目をにんまりと細め、その様子をニヤニヤ見つめている
		PRINTFORML 
		PRINTFORMW 「……配慮が足らなかったですか？　すみませんね。こう見えて結構浮かれているんです」
		PRINTFORML 
		PRINTFORMW 「なにせ、私に初めて恋人が出来たんですから……♪」
		PRINTFORML 
		PRINTFORMW …ということは
		PRINTFORML 
		PRINTFORMW 「はい。これからは恋人として、よろしくお願いしますね」
		PRINTFORML 
		PRINTFORMW 二人は笑顔で手を繋ぎ、晴れて恋人となった
	ENDIF
	PRINTFORML 
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTL 
	SETCOLOR 0xFF00FF
	PRINTFORML 「……あー、すみません。今の所はそういうつもりは無いんです」
	PRINTFORMW %ANAME(TARGET)%に心を読まれた%ANAME(MASTER)%は、告白するより先にフラれてしまった…
	RESETCOLOR
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL 
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「きゃっ！　……ふふ。やっとその気になったんですね」
		PRINTFORMW 押し倒されたというのに、%ANAME(TARGET)%は抵抗することなく、%ANAME(MASTER)%に熱い視線を送っている
		PRINTFORML 「……くすっ♪　そんなに私としたいですか？　ここまで大胆にされたら断れませんね…」
		PRINTFORMW 合意を得た%ANAME(MASTER)%は、%ANAME(TARGET)%の服に優しく手をかける
		IF TALENT:処女
			PRINTFORML 「…私、初めてなので、…優しくしてくださいね…♥」
		ELSE 
			PRINTFORML 「あまりこういうことに馴れてないので、…優しくしてくださいね…♥」
		ENDIF
		PRINTFORMW %ANAME(TARGET)%も、頬を染めながら%ANAME(MASTER)%の服に手をかけていった…
	;それ以外
	ELSE
		PRINTFORML 「……そんなに私としたいんですか？　%ANAME(MASTER)%も変わり者ですね」
	ENDIF
	PRINTFORML
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL 
	PRINTFORML 「……そういうわけには行きません」
	PRINTFORML %ANAME(MASTER)%は%ANAME(TARGET)%のサードアイから伸びる触手に縛り上げられてしまった
	PRINTFORMW 「無理やりされるのは好きじゃないので…。反省してくださいね」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL 
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		SELECTCASE RAND:4
			CASE 0
				PRINTFORMW 「……くすっ♪　そんなに私としたいですか？　仕方ありませんね…♥」
			CASE 1
				PRINTFORML 「……ふふっ♥　いいですよ。さあ、こちらへ…」
				PRINTFORMW %ANAME(TARGET)%は全てを察している様子で%ANAME(MASTER)%を受け入れている
			CASE 2
				PRINTFORML 「……あらあら、そんなに興奮しちゃって…。しょうがないですね…♥」
				PRINTFORMW %ANAME(TARGET)%は押し倒してきた%ANAME(MASTER)%をキスで受け入れた
			CASE 3
				PRINTFORML 「きゃっ、……もう。そんなに乱暴にしなくても、%ANAME(MASTER)%だったら拒みませんよ…♥」
				PRINTFORMW %ANAME(TARGET)%は乱暴に押し倒してきた%ANAME(MASTER)%を、額へのキスで諌めた
		ENDSELECT
	;主人
	ELSEIF TALENT:主人
		SELECTCASE RAND:4
			CASE 0
				PRINTFORMW 「……くすっ♪　そんなに私としたいの？　仕方ない子ね…♥」
			CASE 1
				PRINTFORML 「……ふふっ♥　いいわよ。さあ、こっらへ…」
				PRINTFORMW %ANAME(TARGET)%は全てを察している様子で%ANAME(MASTER)%を受け入れている
			CASE 2
				PRINTFORML 「……あらあら、そんなに興奮しちゃって…。まったくしょうがない子ね…♥」
				PRINTFORMW %ANAME(TARGET)%は押し倒してきた%ANAME(MASTER)%をキスで受け入れた
			CASE 3
				PRINTFORML 「きゃっ、……もう。そんなに乱暴にしなくても%ANAME(MASTER)%だったら拒まないわよ…♥」
				PRINTFORMW %ANAME(TARGET)%は乱暴に押し倒してきた%ANAME(MASTER)%を、額へのキスで諌めた
		ENDSELECT
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
```
