# 口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_BOTTOM_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_BOTTOM_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_K9_NIGHT_BEFORE_BOTTOM, KOJO_K9_NIGHT_AFTER_BOTTOM; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■閨_受け_実行前
;　汎用台詞「KOJO_K9_共_閨_受_汎用.ERB」を呼び出す前に
;　特殊なコマンドを個別に表示してRETURNする
;─────────────────────────────────────── 
@KOJO_K9_NIGHT_BEFORE_BOTTOM(咲夜_対象)
#DIM 咲夜
#DIM 咲夜_対象
#DIMS 咲夜機嫌

IF !咲夜_対象
	咲夜_対象 = MASTER
ENDIF

咲夜 = NAME_TO_CHARA("咲夜")
咲夜機嫌 '= TOSTR_EMOTION(咲夜)

;このくらいは専用口上が欲しいけど事前に何で判断するべきか
;ファーストキス喪失
;処女喪失
;Ａ処女喪失

;─────────────────────────────────────── 
;◆実行が受け（主導権によるものもある）
;─────────────────────────────────────── 
;おねだりする・させられる
IF SELECTCOM == 111
	;主導権がないと渋々だが陥落してると乗り気、慰安だと何も言わない
	IF !IS_INITIATIVE(咲夜) && FLAG:調教モード != 調教_慰安
		IF CHECK_K9("陥落", 咲夜_対象)
			IF CHECK_K9("敬語", 咲夜_対象)
				PRINTDATAL
					DATAFORM 「%CALLNAME_K9(咲夜_対象)%にならいつでも抱かれたいと思っています%BREAK_K9("中", 咲夜_対象)%……もっと下品な言葉ですか？」
					DATAFORM 「わかっていて言っていらっしゃるんでしょう？　意地悪です%BREAK_K9("末", 咲夜_対象)%」
					DATAFORM 「おねだりをしないと、して頂けないのですね。……笑わないでくださいね%BREAK_K9("末", 咲夜_対象)%」
					DATAFORM 「かしこまりました……%CALLNAME_K9(咲夜_対象)%に気に入って頂けるように、みっともなく鳴きます%BREAK_K9("末", 咲夜_対象)%」
				ENDDATA
			ELSE
				PRINTDATAL
					DATAFORM 「甘い言葉が聞きたいわけではないのね。いやらしいこと？」
					DATAFORM 「%CALLNAME_K9(咲夜_対象)%にならして欲しいに決まっているのに……意地悪だわ%BREAK_K9("末", 咲夜_対象)%」
					DATAFORM 「いつもおねだりしている気がするのだけど……そういうことじゃないのね」
					DATAFORM 「いつものじゃなくて？　もっと淫らなことなのね。考えてみるわ。……えっと、そうね」
				ENDDATA
			ENDIF
		ELSE
			IF CHECK_K9("敬語", 咲夜_対象)
				PRINTDATAL
					DATAFORM 「ど、どうしてそんな？　しなくてはいけないのでしょうか」
					DATAFORM 「かしこまりました。教わった通りに致します」
					DATAFORM 「おねだり、ですか……かしこまりました」
					DATAFORM 「どうしてそんなことをしなくてはならないのでしょう……いえ、かしこまりました」
				ENDDATA
			ELSE
				PRINTDATAL
					DATAFORM 「な、なんでそんなことをしなくちゃいけないのよ……する、けど」
					DATAFORM 「おねだりだなんて。しなくてはならないのかしら……するわよ。憶えてるわよ」
					DATAFORM 「おねだり？　はぁ……まぁ、いいわ。なんだったかしらね」
					DATAFORM 「なんで私がそんなことを私がしなくちゃいけないのよ。……わ、わかったわ」
					DATAFORM 「従うのは慣れているけれど、ベッドでもなんて……おかしいわ%BREAK_K9("末", 咲夜_対象)%」
				ENDDATA
			ENDIF
		ENDIF
	ENDIF
	IF HAS_PENIS(咲夜_対象)
		IF RAND:2 == 0
			PRINTFORM 「%ANAME(咲夜)%の
			PRINTDATA
				DATAFORM いやらしい
				DATAFORM はしたない
				DATAFORM みだらな
				DATAFORM 欲しがりの
				DATAFORM 淫乱
				DATAFORM 感じっぱなしの
			ENDDATA
			PRINTDATA
				DATAFORM %CALL_DIRTY_K9("Ｖ")%
				DATAFORM %CALL_DIRTY_K9("Ａ")%
				DATAFORM %CALL_DIRTY_K9("Ｂ")%
				DATAFORM %CALL_DIRTY_K9("Ｃ")%
			ENDDATA
			PRINTDATA
				DATAFORM を可愛がってください
				DATAFORM をいじめてください
				DATAFORM を気持ちよくしてください
				DATAFORM を弄ってください
				DATAFORM をだめにしてください
				DATAFORM で遊んでください
				DATAFORM を%CALL_DIRTY_K9("Ｐ")%で犯してください
				DATAFORM に%CALL_DIRTY_K9("Ｐ")%をください
				DATAFORM を精液塗れにしてください
			ENDDATA
		ELSE
			PRINTDATA
				DATAFORM 「%CALL_DIRTY_K9("Ｐ")%をください
				DATAFORM 「種付けして下さい
				DATAFORM 「%CALLNAME_K9(咲夜_対象)%の奴隷にしてください
				DATAFORM 「%CALL_DIRTY_K9("Ｐ", "ぁ")%%BREAK_K9("中", 咲夜_対象)%%CALL_DIRTY_K9("Ｐ", "ぁ")%
				DATAFORM 「私は%CALLNAME_K9(咲夜_対象)%の性奴隷です
				DATAFORM 「いれてください%BREAK_K9("中", 咲夜_対象)%%CALL_DIRTY_K9("Ｐ", "ぁ")%
				DATAFORM 「セックスしてください
				DATAFORM 「%CALL_DIRTY_K9("Ｐ", "ぁ")%%BREAK_K9("中", 咲夜_対象)%……い、いや
				DATAFORM 「%CALL_DIRTY_K9("Ｐ", "ぁ")%を挿れてください
				DATAFORM 「どうか、赤ちゃんを種付けしてください
			ENDDATA
		ENDIF
		PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	ELSE
		IF RAND:2 == 0
			PRINTFORM 「%ANAME(咲夜)%の
			PRINTDATA
				DATAFORM いやらしい
				DATAFORM はしたない
				DATAFORM みだらな
				DATAFORM 欲しがりの
				DATAFORM 淫乱
				DATAFORM 感じっぱなしの
			ENDDATA
			PRINTDATA
				DATAFORM %CALL_DIRTY_K9("Ｖ")%
				DATAFORM %CALL_DIRTY_K9("Ａ")%
				DATAFORM %CALL_DIRTY_K9("Ｂ")%
				DATAFORM %CALL_DIRTY_K9("Ｃ")%
			ENDDATA
			PRINTDATA
				DATAFORM を可愛がってください
				DATAFORM をいじめてください
				DATAFORM を気持ちよくしてください
				DATAFORM を弄ってください
				DATAFORM をだめにしてください
				DATAFORM で遊んでください
			ENDDATA
		ELSE
			PRINTDATA
				DATAFORM 「%CALLNAME_K9(咲夜_対象)%の奴隷にしてください
				DATAFORM 「あぁ、苦しい、イきたいのぉ
				DATAFORM 「私は%CALLNAME_K9(咲夜_対象)%の性奴隷です
				DATAFORM 「イかせてください
				DATAFORM 「どうか、気持ちよくしてください
				DATAFORM 「私のいやらしい体を可愛がってください
				DATAFORM 「気持ちよくしてください
			ENDDATA
		ENDIF
		PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	ENDIF
	PRINTFORM %SPLIT_R("ああ：うぅ：く：ひぃ：いやぁ：だ、だめ：ひくっ：うぁ")%
	PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	IF CHECK_K9("陥落", 咲夜_対象)
		PRINTDATAL
			DATAFORM も、もうだめ%BREAK_K9("末", 咲夜_対象)%」
			DATAFORM %POLITE_K9("恥ずかしい、わ", "うぅ", 咲夜_対象)%%BREAK_K9("末", 咲夜_対象)%」
			DATAFORM ……もう%BREAK_K9("末", 咲夜_対象)%頭がおかしくなりそう」
		ENDDATA
	ELSE
		PRINTDATAL
			DATAFORM ど、どうしてこんな、私……っ」
			DATAFORM あ、ああ。私……っ」
			DATAFORM ……こんなことって……っ」
		ENDDATA
	ENDIF
	RETURN 0
ENDIF

;土下座する・させられる
IF SELECTCOM == 110
	IF !IS_INITIATIVE(咲夜) && FLAG:調教モード != 調教_慰安
		IF CHECK_K9("陥落", 咲夜_対象)
			PRINTDATAL
				DATAFORM 「%POLITE_K9("そういうの、昂奮するのかしら。……いいわ", "かしこまりました……", 咲夜_対象)%」
				DATAFORM 「%POLITE_K9("%CALLNAME_K9(咲夜_対象)%がそう言うなら、してみるわ", "%CALLNAME_K9(咲夜_対象)%がそう仰るのでしたら、何でも致します", 咲夜_対象)%」
				DATAFORM 「%POLITE_K9("何を謝ればいいの？　……おねだりしたらいいのかしら？", "立場を教えてくださるのですね。かしこまりました", 咲夜_対象)%」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「くっ……土下座だなんてぇ」
				DATAFORM 「どうして、こんな……あぁ……」
				DATAFORM 「どうして私が……ああっ」
				DATAFORM 「どうして……く、う。あっ」
			ENDDATA
		ENDIF
	ENDIF
	PRINTDATA
		DATAFORM 「申し訳ありません
		DATAFORM 「お願いします
		DATAFORM 「お許しください
		DATAFORM 「ど、どうか
	ENDDATA
	PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	PRINTDATA
		DATAFORM 身分をわきまえず生意気を申し上げた%ANAME(咲夜)%をお許しください
		DATAFORM 誠心誠意ご奉仕致しますので、%ANAME(咲夜)%をお使いください
		DATAFORM 愚かな%ANAME(咲夜)%をお躾ください
		DATAFORM %ANAME(咲夜)%を%CALLNAME_K9(咲夜_対象)%の性処理にお使いください
		DATAFORM %ANAME(咲夜)%を%CALLNAME_K9(咲夜_対象)%の玩具にしてください
		DATAFORM %CALLNAME_K9(咲夜_対象)%の面白いように、%ANAME(咲夜)%をお使いください
		DATAFORM これからは精一杯ご命令に従います。お見捨てにならずお躾けください
	ENDDATA
	IF CHECK_K9("陥落", 咲夜_対象)
		PRINTFORML %BREAK_K9("末", 咲夜_対象)%」
	ELSE
```
