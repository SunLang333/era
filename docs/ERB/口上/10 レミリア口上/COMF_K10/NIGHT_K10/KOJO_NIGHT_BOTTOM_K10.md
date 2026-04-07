# 口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_BOTTOM_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_BOTTOM_K10.ERB`

类型: .ERB

自动摘要: functions: KOJO_K10_NIGHT_BEFORE_BOTTOM, KOJO_K10_NIGHT_AFTER_BOTTOM; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■閨_受け_実行前
;　汎用台詞「KOJO_K10_共_閨_受_汎用.ERB」を呼び出す前に
;　特殊なコマンドを個別に表示してRETURNする
;─────────────────────────────────────── 
@KOJO_K10_NIGHT_BEFORE_BOTTOM(レミリア_対象)
#DIM レミリア
#DIM レミリア_対象
#DIMS レミリア機嫌

IF !レミリア_対象
	レミリア_対象 = MASTER
ENDIF

レミリア = NAME_TO_CHARA("レミリア")
レミリア機嫌 '= TOSTR_EMOTION(レミリア)

;─────────────────────────────────────── 
;◆実行が受け（主導権によるものもある）
;─────────────────────────────────────── 
;おねだりする・させられる
IF SELECTCOM == 111
	;主導権がないと渋々だが陥落してると乗り気、慰安だと何も言わない
	IF !IS_INITIATIVE(レミリア) && FLAG:調教モード != 調教_慰安
		IF CHECK_K10("陥落", レミリア_対象)
			PRINTDATA
				DATAFORM 「それは私のすることかしら？　
				DATAFORM 「おねだりって、お願いとは違うの？　
				DATAFORM 「卑俗な言葉を使えと言うの？　
				DATAFORM 「私に下賎の真似をしろと言うの？　
			ENDDATA
			PRINTDATAL
				DATAFORM うーむ……%CALLNAME_K10(レミリア_対象)%がされてみたいなら、いいわ」
				DATAFORM いいわ。%CALLNAME_K10(レミリア_対象)%が好きなら。特別よ？」
				DATAFORM ……誤解しないでね、ごっこ遊びなんだから」
				DATAFORM %CALLNAME_K10(レミリア_対象)%はそういうのが好きなのね」
				DATAFORM ど～っしてもと言うなら、してあげるわ！」
			ENDDATA
		ELSE
			PRINTDATA
				DATAFORM 「は？　おねだり？　私が？　嫌よ。
				DATAFORM 「そんなことは%CALLNAME_K10(レミリア_対象)%がすればいいわ。
				DATAFORM 「私のすることじゃないわ。
				DATAFORM 「身の程をわきまえなさい。
				DATAFORM 「誇り高き吸血鬼に向かって、何を言っているの。
			ENDDATA
			PRINTDATAL
				DATAFORM ……しょうがないわね」
				DATAFORM ……仕方ないわね」
				DATAFORM ……しないと済まないの？」
				DATAFORM もう、面倒ね」
				DATAFORM ……どうしてもなの？」
			ENDDATA
		ENDIF
	ENDIF
	;対象が男性
	IF HAS_PENIS(レミリア_対象)
		IF RAND:2 == 0
			PRINTFORM 「%ANAME(レミリア)%の
			PRINTDATA
				DATAFORM いやらしい
				DATAFORM はしたない
				DATAFORM みだらな
				DATAFORM 欲しがりの
				DATAFORM 淫乱
				DATAFORM 感じっぱなしの
			ENDDATA
			IF RAND:2 == 0
				PRINTDATA
					DATAFORM %CALL_DIRTY_K10("Ｖ")%
					DATAFORM %CALL_DIRTY_K10("Ａ")%
				ENDDATA
				PRINTDATA
					DATAFORM を可愛がってください
					DATAFORM をいじめてください
					DATAFORM を気持ちよくしてください
					DATAFORM を弄ってください
					DATAFORM で遊んでください
					DATAFORM を%CALL_DIRTY_K10("Ｐ")%で犯してください
					DATAFORM に%CALL_DIRTY_K10("Ｐ")%を挿れてください
				ENDDATA
			ELSE
				PRINTDATA
					DATAFORM %CALL_DIRTY_K10("Ｂ")%
					DATAFORM %CALL_DIRTY_K10("Ｃ")%
				ENDDATA
				PRINTDATA
					DATAFORM を可愛がってください
					DATAFORM をいじめてください
					DATAFORM を気持ちよくしてください
					DATAFORM を弄ってください
					DATAFORM で遊んでください
				ENDDATA
			ENDIF
		ELSE
			PRINTDATA
				DATAFORM 「%ANAME(レミリア)%に%CALL_DIRTY_K10("Ｐ")%をください
				DATAFORM 「どうか、%ANAME(レミリア)%を好きにしてください
				DATAFORM 「%ANAME(レミリア)%を可愛がってください
				DATAFORM 「%ANAME(レミリア)%を気持ちよくしてください
				DATAFORM 「%ANAME(レミリア)%に%CALL_DIRTY_K10("Ｐ", "ぁ")%を挿れてください
				DATAFORM 「どうか、%ANAME(レミリア)%に赤ちゃんをください
			ENDDATA
		ENDIF
		PRINTFORM %BREAK_K10("末", レミリア_対象)%
		PRINTFORML 」
	;対象が女性
	ELSE
		IF RAND:2 == 0
			PRINTFORM 「%ANAME(レミリア)%の
			PRINTDATA
				DATAFORM いやらしい
				DATAFORM はしたない
				DATAFORM みだらな
				DATAFORM 欲しがりの
				DATAFORM 淫乱
				DATAFORM 感じっぱなしの
			ENDDATA
			PRINTDATA
				DATAFORM %CALL_DIRTY_K10("Ｖ")%
				DATAFORM %CALL_DIRTY_K10("Ａ")%
				DATAFORM %CALL_DIRTY_K10("Ｂ")%
				DATAFORM %CALL_DIRTY_K10("Ｃ")%
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
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%の奴隷にしてください
				DATAFORM 「私は%CALLNAME_K10(レミリア_対象)%の性奴隷です
				DATAFORM 「どうか、%ANAME(レミリア)%を好きにしてください
				DATAFORM 「%ANAME(レミリア)%を可愛がってください
				DATAFORM 「%ANAME(レミリア)%を気持ちよくしてください
			ENDDATA
		ENDIF
		PRINTFORM %BREAK_K10("末", レミリア_対象)%
		PRINTFORML 」
	ENDIF
	IF CHECK_K10("陥落", レミリア_対象)
		PRINTDATAL
			DATAFORM 「こ、こう？　……なんだか変な気分だわ。意地悪な顔、しないで」
			DATAFORM 「上手でしょう？　……%CALLNAME_K10(レミリア_対象)%だから頑張ったのよ」
			DATAFORM 「……うう。く、屈辱よ。なんか、ヘンだわ」
			DATAFORM 「こんな感じかしら……どきどきしたりするのかしら？　私はなんだか、その……」
			DATAFORM 「…………。ば、バカだと思ったでしょう？　無礼だわ！　%CALLNAME_K10(レミリア_対象)%だからなのに！」
			DATAFORM 「……うーっ。なんでぇ」
		ENDDATA
	ELSE
		PRINTDATAL
			DATAFORM 「……わ、笑ってないでしょうね？」
			DATAFORM 「……頑張ったのよ。馬鹿にしたら許さないからっ」
			DATAFORM 「……く、屈辱よ」
		ENDDATA
	ENDIF
	RETURN 0
ENDIF

;土下座する・させられる
IF SELECTCOM == 110
	;主導権がないと渋々だが陥落してると乗り気、慰安だと何も言わない
	IF !IS_INITIATIVE(レミリア) && FLAG:調教モード != 調教_慰安
		IF CHECK_K10("陥落", レミリア_対象)
			PRINTDATA
				DATAFORM 「何か嫌なことしたかしら？　
				DATAFORM 「土下座って……何か悪いことした？　
				DATAFORM 「私に平伏しろというの？　
				DATAFORM 「謝罪のことよね。それ、どうやるの？　
				DATAFORM 「私に下賎の真似をしろと言うの？　
			ENDDATA
			PRINTDATAL
				DATAFORM うーむ。%CALLNAME_K10(レミリア_対象)%がされてみたいだけなのね」
				DATAFORM ま、%CALLNAME_K10(レミリア_対象)%が好きならいいわ」
				DATAFORM ……誤解しないでね、ごっこ遊びなんだから」
				DATAFORM %CALLNAME_K10(レミリア_対象)%はそういうのが好きなのね」
				DATAFORM ……どうしても？」
			ENDDATA
		ELSE
			PRINTDATA
				DATAFORM 「は？　土下座？　私が？　嫌よ。
				DATAFORM 「そんなことは%CALLNAME_K10(レミリア_対象)%がすればいいわ。
				DATAFORM 「私のすることじゃないわ。
				DATAFORM 「身の程をわきまえなさい。
				DATAFORM 「誇り高き吸血鬼に向かって、何を言っているの。
			ENDDATA
			PRINTDATAL
				DATAFORM ……しょうがないわね」
				DATAFORM ……仕方ないわね」
				DATAFORM ……しないと済まないの？」
				DATAFORM もう、面倒ね」
				DATAFORM ……どうしてもなの？」
			ENDDATA
		ENDIF
	ENDIF
	PRINTDATA
```
