# 口上/07 小悪魔口上/_KOJO_EVENT_K7.ERB — 自动生成文档

源文件: `ERB/口上/07 小悪魔口上/_KOJO_EVENT_K7.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K7; UI/print

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
@KOJO_EVENT_K7(ARG)

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
	SETCOLOR 0xB40404
	;淫魔スイッチＯＮ時淫乱
	IF CFLAG:240 == 3
		PRINTFORMW 「私のことが好きなんですかぁ？　ふふ♥　私も%ANAME(MASTER)%のこと大好きですよぉ♥」
		PRINTFORML
		PRINTFORMW ……意を決して%ANAME(TARGET)%に告白した%ANAME(MASTER)%だが、いたく簡単に受け入れられた
		PRINTFORML 
		PRINTFORMW もしかして『ＬＯＶＥ』ではなく『ＬＩＫＥ』の意味で受け取られたのだろうか？
		PRINTFORML 
		PRINTFORMW 確認しようとした%ANAME(MASTER)%を遮るように、%ANAME(TARGET)%は熱い口付けで唇を塞いできた
		PRINTFORML 
		PRINTFORMW 「んちゅぅぅっ、ぅんれろぉぉ……っ、ふふ♥　どうですかぁ？　恋人になった淫魔のキスは…♥」
		PRINTFORML 
		PRINTFORMW 口内を蹂躙するかのような舌使いによって体の力が抜けた%ANAME(MASTER)%を、%ANAME(TARGET)%が腰に手を回して支える
		PRINTFORML 
		PRINTFORMW 「私は、私を好きでいてくれる人が皆好きです」
		PRINTFORML 
		PRINTFORMW 「だって私は淫魔ですから……♥　特に、良質な精気をくれる%ANAME(MASTER)%のことは、本当に大好きです。愛していますよぉ♥」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は己の柔らかな肉体を押し当てながら、%ANAME(MASTER)%の耳元に熱い吐息を送るように囁く
		PRINTFORML 
		PRINTFORMW 「こういうの、不純だと思いますか？　ふふ♥　でも肉欲から始まる愛だって、面白いじゃないですかぁ♥」
		PRINTFORML 
		PRINTFORMW 「そういうわけで、これから恋人としてよろしくお願いしますねぇ、%ANAME(MASTER)%♥」
		PRINTFORML 
		PRINTFORMW 「特に私は性欲強いので、……夜の方も、期待していますよぉ♥♥」
		PRINTFORML
		PRINTFORMW ……何はともあれ、二人は晴れて恋人となった
		PRINTFORML 

	ELSEIF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「わ、私とっ、こっ、恋人に！？」
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%が%ANAME(TARGET)%に己の思いを伝えると、彼女は大層狼狽えた様子を晒した
		PRINTFORML 
		PRINTFORMW 「い、いやっこれは決してイヤとかそういうんじゃないですよ！？　そーじゃなくてえっと、えーっと…っ！」
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%は彼女の両肩に手を置き、とりあえず深呼吸で落ち着くように言った
		PRINTFORML 
		PRINTFORMW 「ヒッ、ヒッ、フーッ、ヒッ、ヒッ、フーッ、………ふう、だいぶ落ち着きました」
		PRINTFORML 
		PRINTFORMW それは深呼吸じゃないだろと言うツッコミを押し殺し、%ANAME(MASTER)%は%ANAME(TARGET)%の目を見据えて再度告白した
		PRINTFORML 
		PRINTFORMW 「や、やっぱり聞き間違いとかじゃなかったんですね。……嬉しいです♥」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は想いを寄せていた%ANAME(MASTER)%と結ばれた嬉しさに、一筋の涙を浮かべた笑顔で答えた
		PRINTFORML 
		PRINTFORMW 「私も、%ANAME(MASTER)%のことが大好きですっ。これからもどうか私のことを可愛がってください♥」
		PRINTFORML
		PRINTFORMW 互いの愛を確かめ合うように、二人はしばしの間、お互いを強く抱きしめていた……
		PRINTFORML
		PRINTFORMW 二人は晴れて恋人となった
		PRINTFORML 
		
	;それ以外
	ELSE
		PRINTFORML 
		PRINTFORMW 「…え？　私と？　恋人に？」
		PRINTFORML 
		PRINTFORML 「…………」
		PRINTFORML 
		PRINTFORMW 「いやー、やっぱりこんなに可愛い小悪魔ちゃん、放っておかれないかー！　そうですよねー♪」
		PRINTFORML 
		PRINTFORMW 突然の告白に目を丸くした%ANAME(TARGET)%だったが、すぐにいつものペースを取り戻した
		PRINTFORML 
		PRINTFORMW 「いいですよー。その告白、お受けします♪　%ANAME(MASTER)%のことも嫌いじゃあないですしね♥」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%はそう言うと、%ANAME(MASTER)%の手をぎゅっと握る
		PRINTFORML 
		PRINTFORMW 「今日から私たちは恋人ですね♥　ちゃんと可愛がってくださいよー？」
		PRINTFORML 
		PRINTFORMW 二人は笑顔で手を繋ぎ、晴れて恋人となった
		PRINTFORML 

	ENDIF
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	SETCOLOR 0xB40404
	PRINTFORML 
	PRINTFORML 「……すみません。気持ちは嬉しいんですが、今はそういう気持ちになれないんです」
	PRINTFORMW %ANAME(TARGET)%はしばし悩んだ後、そう言った
	PRINTFORMW 「…もう少し、お友達でいましょう？」
	PRINTFORML 
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL 
	PRINTFORML 「はれぇぇ…なんですかぁぁ……。なんだか分からないけど、いいキモチですぅ…♥」
	PRINTFORMW %ANAME(TARGET)%は酔いが深いのか、トロンとした表情で%ANAME(MASTER)%にもたれかかって来た
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL 
	;淫魔スイッチＯＮ時淫乱
	IF CFLAG:240 == 3
		PRINTFORML 「あぁん♥　やっと押し倒してくれましたねぇ♥」
		PRINTFORML 押し倒された%ANAME(TARGET)%は一切抵抗せず、むしろ進んで%ANAME(MASTER)%に艶かしい肢体を絡みつかせてくる
		PRINTFORMW 「今夜は放しませんよ……♥　さあ、心も身体も蕩けるほど交じり合いましょう♥」
	;恋慕
	ELSEIF TALENT:恋慕
		PRINTFORML 「きゃっ、……ふふ♪　やっとその気になってくれたんですねぇ♥」
		PRINTFORML 押し倒された%ANAME(TARGET)%は抵抗せず、むしろ進んで%ANAME(MASTER)%を受け入れている
		PRINTFORMW 「さあ、どうぞ…。出来たら優しくしてくださいね……♥」
	;それ以外
	ELSE
		PRINTFORML 「きゃっ！　……もう。しょうがないですねぇ」
		PRINTFORMW %ANAME(TARGET)%は諦めた様子で、%ANAME(MASTER)%のことを受け入れた
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL 
	PRINTFORMW 「こ、心の準備がありますのでっ！」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL 
	;淫魔スイッチＯＮ時淫乱
	IF CFLAG:240 == 3
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「あはん♥　もう我慢できないんですねぇ♥」
				PRINTFORMW 「ふふ、私も一緒ですよぉ♥　だから今夜は、いっぱいいっぱいシましょうね♥♥」
			CASE 1
				PRINTFORML 「あぁん♥　やっとこの時間が来ましたねぇ♥」
				PRINTFORML 押し倒された%ANAME(TARGET)%は一切抵抗せず、むしろ進んで%ANAME(MASTER)%に艶かしい肢体を絡みつかせてくる
				PRINTFORMW 「もう放しませんよ……♥　さあ、心も身体も蕩けるほど交じり合いましょう♥」
			CASE 2
				PRINTFORML 「あん♥　情熱的ですねぇ♥」
				PRINTFORML %ANAME(TARGET)%は押し倒してきた%ANAME(MASTER)%の顔を、自慢の巨乳で抱き包む
				PRINTFORMW 「今日もいっぱい、私に溺れてくださいねぇ♥♥」
		ENDSELECT
	;恋慕
	ELSEIF TALENT:恋慕
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「きゃあっ、……もう、我慢できないんですかぁ？」
				PRINTFORMW 「ふふ、しょうがないですねぇ♥　じゃあ今夜は、私とイイことしましょうね♥」
			CASE 1
				PRINTFORML 「きゃっ、……ふふ♪　その気になってくれたんですねぇ♥」
				PRINTFORML 押し倒された%ANAME(TARGET)%は抵抗せず、むしろ進んで%ANAME(MASTER)%を受け入れている
				PRINTFORMW 「さあ、どうぞ…。今日も優しくしてくださいね……♥」
			CASE 2
				PRINTFORML 「わわっ、……もう、乱暴ですねぇ。そんなにしなくたって、私はいつでも大丈夫ですよ♥」
```
