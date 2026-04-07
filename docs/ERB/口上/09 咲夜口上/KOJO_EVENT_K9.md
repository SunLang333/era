# 口上/09 咲夜口上/KOJO_EVENT_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/KOJO_EVENT_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K9; UI/print

前 200 行源码片段:

```text
﻿;イベント口上
@KOJO_EVENT_K9(ARG)
#DIM 咲夜_対象
#DIM 咲夜
#DIMS 咲夜機嫌

咲夜_対象 = MASTER
咲夜 = NAME_TO_CHARA("咲夜")
咲夜機嫌 '= TOSTR_EMOTION(咲夜)

SIF CFLAG:咲夜:400 == 1
	RETURN 0

SETCOLOR 咲夜_口上カラー

;─────────────────────────────────────── 
;●2_告白成功
;─────────────────────────────────────── 
IF ARG == 2
	咲夜_告白成功期 = DAY
	咲夜_告白成功場所 = TFLAG:54
	咲夜_告白成功したキャラ = 咲夜_対象
	;陥落済み
	IF CHECK_K9("陥落", 咲夜_対象)
		PRINTFORML 「あぁ……」
		PRINTFORMDW %ANAME(咲夜)%は胸を押さえて頬を染め、恍惚と微笑んでいる
		PRINTL 
		PRINTFORML 「…………」
		PRINTFORML 「あ。あぁ。ごめんなさい」
		PRINTFORML 「いや、待って%POLITE_K9("ちょうだい", "ください")%」
		PRINTFORML 「断るという意味では%POLITE_K9("ないわ", "ありません")%……」
		PRINTFORMW 「ぼうっとしてしまったから謝った%POLITE_K9("のよ", "んです")%」
		PRINTL 
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%が言って%POLITE_K9("くれな", "くださらな")%かったら、私から%POLITE_K9("言うところだったわ", "お願いしてしまうところでした")%」
		PRINTFORML 「ここしばらくは、何も怖いことなんてなかったのに。ずっと怖くて……」
		PRINTFORMW 「あぁ」
		PRINTL 
		PRINTFORML 「こんな気持ちがあるなんてね」
		PRINTFORML 「胸が、どきどきし過ぎて、痛い……%CALLNAME_K9(咲夜_対象)%……」
		PRINTFORML 「大好き%POLITE_K9("よ", "です")%。%POLITE_K9("すごく嬉しいわ", "とても嬉しいです")%。%POLITE_K9("返事はもちろん、イエスよ", "私からもどうか、お願いします")%」
	;陥落百合
	ELSEIF TALENT:咲夜:親友
		PRINTFORML 「……%POLITE_K9("付き合うって、いうのは。その", "付き合う、というのは……その")%」
		PRINTFORML 「%POLITE_K9("一緒にどこかへ遊びに行くとか、そういうことじゃなく", "どこかへ出かけるから伴をするようにとか、そういうことではなく")%？」
		PRINTFORML 「恋愛の……？」
		PRINTFORMDW %ANAME(咲夜)%は目を丸くしてポカンと口を開いたまま動きを止めた
		PRINTL 
		PRINTFORML 「あぁ……そう、そうだったのね」
		PRINTFORMDW ややあって、%ANAME(咲夜)%は自らの胸を抱きしめて頬を染め、恍惚と微笑んだ
		PRINTL 
		PRINTFORML 「あっ。ごめんなさい、ひとりで納得してしまって。私、その」
		PRINTFORML 「親友だと思っていたもの%POLITE_K9("だから", "ですから")%、%POLITE_K9("気づいていなかったのだけれど", "気づいていなかったのですけれど")%」
		PRINTFORML 「その言葉を聞いたら急に……凄く胸がどきどきして、幸せな気持ちになって」
		PRINTFORMW 「私も本当はそうだったのかもしれないと思っていた%POLITE_K9("の", "んです")%」
		PRINTL 
		PRINTFORML 「嬉しいわ……%CALLNAME_K9(咲夜_対象)%……」
		PRINTFORML 「%POLITE_K9("すごく嬉しいわ", "とても嬉しいです")%。大好き%POLITE_K9("よ", "です")%。%POLITE_K9("返事はもちろん、イエスよ", "私からもどうか、お願いします")%」
	;未陥落
	ELSE
		PRINTFORML 「……私と%POLITE_K9("？　付き合うって、恋愛の", "ですか。恋人に")%？」
		PRINTFORML 「よくよく珍しい人%POLITE_K9("ね", "ですね")%。%CALLNAME_K9(咲夜_対象)%は」
		PRINTFORMW 「%POLITE_K9("いいわよ。付き合ってあげるわ", "私でよろしければ、喜んでお付き合い致します")%」
		PRINTL 
		PRINTFORML 「あら。適当に答えた訳%POLITE_K9("じゃないわ。", "ではありませんよ？　")%嫌いではないから%POLITE_K9("よ", "です")%」
		PRINTFORML 「ちゃんと……他の誰よりも、恋愛対象として見られそうだから頷%POLITE_K9("いたわ", "きました")%」
		PRINTFORML 「まだどういうものかは%POLITE_K9("わかってないのだけど", "わからないのですが")%、かまわない%POLITE_K9("かしら", "でしょうか")%？」
	ENDIF
	WAIT
ENDIF

;─────────────────────────────────────── 
;●3_告白失敗
;─────────────────────────────────────── 
IF ARG == 3
	IF IS_SLAVE(咲夜)
		PRINTFORML 「あら……私は%CALLNAME_K9(咲夜_対象)%の奴隷かと思っていました」
		PRINTFORML 「そうなると気持ちも変わりそうです。少し考えさせてください」
	ELSEIF IS_LOVER(咲夜)
		PRINTFORML 「あら。言う相手を間違えて%POLITE_K9("いるんじゃないかしら", "いらっしゃいませんか")%」
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%には他にたくさん恋人がいる%POLITE_K9("かと思ったけれど？", "かと思っておりました")%」
		PRINTFORML 「……本気で%POLITE_K9("言ってるなら、少し考えさせてくれないかしら", "仰っているなら、少し考えさせてください")%」
	ELSEIF TALENT:咲夜:親友
		PRINTFORML 「ふふ、そう%POLITE_K9("ね", "ですね")%。私たちは恋人みたいに仲が良い%POLITE_K9("って妖精メイドに言われたわ", "と、妖精メイドにからかわれました")%」
		PRINTFORML 「異性%POLITE_K9("だったら", "でしたら")%、間違いなく%CALLNAME_K9(咲夜_対象)%に告白していたと思%POLITE_K9("うわ", "います")%」
		PRINTFORMDL %ANAME(咲夜)%は冗談か比喩表現だと誤解したようだ
	ELSE
		PRINTFORML 「……私%POLITE_K9("と", "とですか")%？　冗談が過ぎ%POLITE_K9("るわよ", "ますよ")%」
		PRINTFORML 「そんなにからかいやすく見え%POLITE_K9("るのかしら", "ますか？")%」
	ENDIF
	WAIT
ENDIF

;─────────────────────────────────────── 
;●4_押し倒し成功(酒酔いの影響・合意は得られない)
;─────────────────────────────────────── 
IF ARG == 4
	PRINTFORML 「ん……っ？　ちょっと、何%POLITE_K9("よ", "ですか")%。いやらしいことをするつもり%POLITE_K9("", "ですか")%？」
	PRINTFORML 「……そう%POLITE_K9("ね", "ですね")%。お酒もまわって少し人肌恋しいし……%POLITE_K9("かまわないけれど", "かまいませんが")%」
ENDIF

;─────────────────────────────────────── 
;●5_押し倒し成功(合意を取得)
;─────────────────────────────────────── 
IF ARG == 5
	IF IS_SLAVE(咲夜)
		PRINTFORML 「あっ……❤　%CALLNAME_K9(咲夜_対象)%……嬉しい、です❤」
	ELSEIF IS_LOVER(咲夜)
		IF CHECK_K9("敬語")
			PRINTFORML 「あの……あっ❤　%CALLNAME_K9(咲夜_対象)%から求めて頂けるなんて……嬉しいです❤」
		ELSE
			PRINTFORML 「ちょ、ちょっと。あっ❤」
			PRINTFORML 「気づいてくれたのね。ふふっ……待ってたのよ？」
		ENDIF
	ELSE
		PRINTFORML 「何？　もうっ。遊び相手にするつもり%POLITE_K9("かしら", "ですか")%？」
		PRINTFORML 「……%CALLNAME_K9(咲夜_対象)%に遊んで貰えるなら、それもいいかもしれ%POLITE_K9("ないわ", "ません")%」
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●6_押し倒し失敗
;─────────────────────────────────────── 
IF ARG == 6
	IF IS_SLAVE(咲夜)
		PRINTFORML 「あっ……だ、駄目です。今は……」
	ELSEIF IS_LOVER(咲夜)
		PRINTFORML 「ちょ、ちょっと。あっ❤　駄目よ、今は」
	ELSE
		PRINTFORML 「何？　もうっ……遊び相手にするつもり%POLITE_K9("かしら", "ですか")%？」
		PRINTFORML 「そういうのは他の人に頼んで%POLITE_K9("ちょうだい", "ください")%」
	ENDIF
	WAIT
ENDIF

;─────────────────────────────────────── 
;●7_押し倒し成功(既に合意あり)
;─────────────────────────────────────── 
IF ARG == 7
	IF IS_SLAVE(咲夜)
		PRINTFORML 「あ、あの。あっ❤　……おねだりしなくて良かったです」
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%から求めて頂けると、嬉しくなります❤」
	ELSEIF IS_LOVER(咲夜)
		IF CHECK_K9("敬語")
			PRINTFORML 「あ、あの。あっ❤　……おねだりしなくて良かったです」
			PRINTFORML 「%CALLNAME_K9(咲夜_対象)%から求めて頂けると、嬉しくなります❤」
		ELSE
			PRINTFORML 「ちょ、ちょっと。あっ❤　……おねだりしなくて良かったわ」
			PRINTFORML 「%CALLNAME_K9(咲夜_対象)%から求めてもらえるのって、最高ね❤」
		ENDIF
	ELSE
		PRINTFORML 「あっ❤　もう、また……」
	ENDIF
	WAIT
ENDIF

;─────────────────────────────────────── 
;●11_体力切れによる行動不能（捕虜調教ではないか実行者）
;─────────────────────────────────────── 
IF ARG == 11
	IF (FLAG:調教モード == 調教_会う || FLAG:調教モード == 調教_閨) && GROUPMATCH(咲夜機嫌,"幸","悦","良")
		PRINTFORML 「はぁっ……❤　あぁ……もう駄目よ、いくらしたくても体がもたないわ❤」
	ELSE
		PRINTFORML 「あはぁっ……もう駄目、体がぁ……」
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●12_気力切れ（快楽）による失神（捕虜調教ではないか実行者）
;─────────────────────────────────────── 
IF ARG == 12
	IF (FLAG:調教モード == 調教_会う || FLAG:調教モード == 調教_閨) && GROUPMATCH(咲夜機嫌,"幸","悦")
		PRINTFORML 「ひぁっ……狂っちゃう❤　最高ぉ……に、幸せ、よ❤」
	ELSE
		PRINTFORML 「ひぁっ……くるっ、ちゃ、うぅ……っ」
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●13_怒り限界による離脱（閨に呼ぶモードやデート先でない）
;─────────────────────────────────────── 
IF ARG == 13
	IF IS_SLAVE(咲夜)
		PRINTFORML 「申し訳ありませんが、そろそろお見送りさせてください」
		PRINTFORML 「今日は訓練をすると手元が狂ってしまいそうです」
		PRINTFORML 「どうしても心が手に入らない方を手に入れる方法は、%CALLNAME_K9(咲夜_対象)%ならご存知でしょう？」
	ELSEIF IS_LOVER(咲夜)
		IF CHECK_K9("敬語")
			PRINTFORML 「申し訳ありませんが、そろそろお見送りさせてください」
			PRINTFORML 「今日は訓練をすると手元が狂いそうです」
			PRINTFORML 「血の色を見てみたいくらい好きなものですから」
		ELSE
			PRINTFORML 「悪いけれど、そろそろお掃除がしたいから帰って貰えるかしら」
			PRINTFORML 「訓練に付き合ってくれるなら助かるけれど、今日は手元が狂いそうよ」
			PRINTFORML 「%CALLNAME_K9(咲夜_対象)%のことは血の色を見てみたいくらい好きなんですもの」
		ENDIF
	ELSE
		IF CHECK_K9("敬語")
			PRINTFORML 「申し訳ありませんが、そろそろお掃除をしたいのでお見送りさせてください」
			PRINTFORML 「訓練をしても良いのですが……今日は手元が狂いそうです」
		ELSE
```
