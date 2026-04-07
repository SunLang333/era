# 口上/23 萃香口上/KOJO_A_K23.ERB — 自动生成文档

源文件: `ERB/口上/23 萃香口上/KOJO_A_K23.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K23, KOJO_TRAIN_END_A1_K23, KOJO_TRAIN_START_A2_K23, KOJO_TRAIN_END_A2_K23, KOJO_COM_BEFORE_TARGET_A_K23, KOJO_COM_BEFORE_PLAYER_A_K23, KOJO_COM_A_K23, KOJO_COM_TARGET_A_K23, KOJO_COM_PLAYER_A_K23, KOJO_COM_AFTER_A_K23, SEX_VOICE23_00, SEX_VOICE23_01, SEX_VOICE23_02, SEX_VOICE23_03, SEX_VOICE23_04, SEX_VOICE23_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K23
#DIM 対象
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	PRINTFORML
	;初対面の場合
	IF !CFLAG:17
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「おやおや、私になんか用かい？　」
			PRINTFORMW %ANAME(MASTER)%が捕虜用にあてがわれた部屋を訪れると、赤ら顔の子鬼が我が物顔で寛いでいた……
			PRINTFORMW 彼女の名は『%NAME_FORMAL(TARGET)%』
			SETCOLOR カラー_オレンジ
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　萃まる夢、幻、そして百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　変装して屋台をやってた鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　瓢箪枕の酒呑童子　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　小さな百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　疎雨の百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の古豪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　太古の時代　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 見た目だけなら可愛らしい少女だ。しかしこう見えて彼女は、幻想郷縁起にも名を連ねる強大な鬼だ
			PRINTFORMW もし彼女が我が軍に協力してくれれば、きっとこの乱世を終わらせる助けになるだろう
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、挨拶に来たと伝えた
			PRINTFORML 「うん？　挨拶に？　ほうほう、それは関心♪」
			PRINTFORMW %ANAME(TARGET)%はニッコリ笑った
			PRINTFORML 「こんなとこにわざわざ足を運んで顔を出しに来るとは、なかなか分かってるじゃないかお前は♪」
			PRINTFORMW ……思ったより好印象だ。このまま協力してくれないだろうか
			PRINTFORML 「あー、それとはまた話は別な。まだまだアンタの事よく分かってないし」
			PRINTFORMW 「だからま、酒でも飲んで話そうじゃないか？」
			PRINTFORMW 「もちろんアンタも飲んでいくだろう？　酒は互いをよく知るための魔法の薬だぞ♪」
			PRINTFORML ……何だか酒を飲む口実に利用されたような……
			PRINTFORMW 何はともあれ、%ANAME(MASTER)%は%ANAME(TARGET)%との交流を開始した
		;それ以外
		ELSE
			PRINTFORML 「およ、見かけない顔だね」
			PRINTFORMW 瓢箪を携えた子鬼が、赤ら顔で%ANAME(MASTER)%に顔を向けた
			PRINTFORMW 彼女の名は『%NAME_FORMAL(TARGET)%』
			SETCOLOR カラー_オレンジ
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　萃まる夢、幻、そして百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　変装して屋台をやってた鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　瓢箪枕の酒呑童子　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　小さな百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　疎雨の百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の古豪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　太古の時代　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 見た目だけなら可愛らしい少女だ。しかしこう見えて彼女は、幻想郷縁起にも名を連ねる強大な鬼だ
			PRINTFORMW その力は、きっとこの乱世を終わらせる助けになるだろう
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、挨拶に来たと伝えた
			PRINTFORML 「ほう、挨拶に。それは関心、関心♪」
			PRINTFORMW %ANAME(TARGET)%はニッコリ笑った
			PRINTFORML 「わざわざ足を運んで顔を出しに来るとは、なかなか分かってるじゃないかお前は♪」
			PRINTFORMW 「たまに居るんだよねー、私に“挨拶”も無しの新参者とかがさー」
			PRINTFORML 「そういう奴らには、ちょいと痛い目に会ってもらってるよ」
			PRINTFORMW ……なんか怖いことを言っている。挨拶は大事。幻想郷縁起にも書いておくべき
			PRINTFORML 「まぁゆっくりしてきな。酒でも飲むかい？」
			PRINTFORML 「あー、それとな」
			PRINTFORMW %ANAME(TARGET)%は付け加えて言った
			PRINTFORML 
			PRINTFORML 
			CALL COLOR_PRINTL("「私は嘘が嫌いだ。吐くのも吐かれるのもな」", カラー_注意) 
			PRINTFORML 
			PRINTFORMW 
			PRINTFORMW 一瞬、%ANAME(TARGET)%の声色が変わった
			PRINTFORML 「%ANAME(MASTER)%は、正直者でいてくれよな♪」
			PRINTFORMW ……肝に銘じておこう
		ENDIF
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「あら、どっかで見た顔だ」
			PRINTFORMW %ANAME(MASTER)%が捕虜用にあてがわれた部屋を訪れると、赤ら顔の子鬼が我が物顔で寛いでいた……
			PRINTFORMW 彼女の名は『%NAME_FORMAL(TARGET)%』
			SETCOLOR カラー_オレンジ
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　萃まる夢、幻、そして百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　変装して屋台をやってた鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　瓢箪枕の酒呑童子　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　小さな百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　疎雨の百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の古豪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　太古の時代　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 見た目だけなら可愛らしい少女だ。しかしこう見えて彼女は、幻想郷縁起にも名を連ねる強大な鬼だ
			PRINTFORMW もし彼女が我が軍に協力してくれれば、きっとこの乱世を終わらせる助けになるだろう
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、挨拶に来たと伝えた
			PRINTFORML 「うん？　改めて挨拶に？　ほうほう、それは関心♪」
			PRINTFORMW %ANAME(TARGET)%はニッコリ笑った
			PRINTFORML 「こんなとこにわざわざ足を運んで顔を出しに来るとは、なかなか分かってるじゃないかお前さんは♪」
			PRINTFORMW ……思ったより好印象だ。このまま協力してくれないだろうか
			PRINTFORML 「あー、それとはまた話は別な。アンタの事まだまだ分かってないしさ」
			PRINTFORMW 「だからま、酒でも飲んで話そうじゃないか？」
			PRINTFORMW 「もちろんお前さんも飲んでいくだろう？　酒は互いをよく知るための魔法の薬だぞ♪」
			PRINTFORML ……何だか酒を飲む口実に利用されたような……
			PRINTFORMW 何はともあれ、%ANAME(MASTER)%は%ANAME(TARGET)%との交流を開始した
		;それ以外
		ELSE
			PRINTFORML 「あら、どっかで見た顔だ」
			PRINTFORMW 瓢箪を携えた子鬼が、赤ら顔で%ANAME(MASTER)%に顔を向けた
			PRINTFORMW 彼女の名は『%NAME_FORMAL(TARGET)%』
			SETCOLOR カラー_オレンジ
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　萃まる夢、幻、そして百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　変装して屋台をやってた鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　瓢箪枕の酒呑童子　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　小さな百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　疎雨の百鬼夜行　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の古豪　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　不羈奔放の鬼　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　太古の時代　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 見た目だけなら可愛らしい少女だ。しかしこう見えて彼女は、幻想郷縁起にも名を連ねる強大な鬼だ
			PRINTFORMW その力は、きっとこの乱世を終わらせる助けになるだろう
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%に、改めて挨拶に来たと伝えた
			PRINTFORML 「ほう、挨拶に。それは関心、関心♪」
			PRINTFORMW %ANAME(TARGET)%はニッコリ笑った
			PRINTFORML 「わざわざ足を運んで顔を出しに来るとは、なかなか分かってるじゃないかお前さんは♪」
			PRINTFORMW 「たまに居るんだよねー、私に“挨拶”も無しの新参者とかがさー」
			PRINTFORML 「そういう奴らには、ちょいと痛い目に会ってもらってるよ」
			PRINTFORMW ……なんか怖いことを言っている。挨拶は大事。幻想郷縁起にも書いておくべき
			PRINTFORML 「まぁゆっくりしてきな。酒でも飲むかい？」
			PRINTFORML 「あー、それとな」
			PRINTFORMW %ANAME(TARGET)%は付け加えて言った
			PRINTFORML 
			PRINTFORML 
			CALL COLOR_PRINTL("「私は嘘が嫌いだ。吐くのも吐かれるのもな」", カラー_注意) 
			PRINTFORML 
			PRINTFORMW 
			PRINTFORMW 一瞬、%ANAME(TARGET)%の声色が変わった
			PRINTFORML 「%ANAME(MASTER)%は、正直者でいてくれよな♪」
			PRINTFORMW ……肝に銘じておこう
		ENDIF
	ENDIF
	PRINTFORML

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻か妾
ELSEIF CFLAG:200 < 7 && (TALENT:正妻 || TALENT:妾)
	CFLAG:200 = 7;婚姻した次の回フラグ
	PRINTFORML 
	IF TALENT:正妻 
		PRINTFORML ……
		PRINTFORML 「ちゅっ、……ふふ♥」
		PRINTFORMW 朝。柔らかな唇が触れる心地いい感触で%ANAME(MASTER)%は目を覚ました
		PRINTFORML 「%ANAME(MASTER)%、おはよう…♥　昨日はよく眠れたかい？」
		PRINTFORMW 隣で一緒に寝ていた%ANAME(TARGET)%が優しいキスで%ANAME(MASTER)%を起こす
		PRINTFORML 「…んふふ♪　朝、目を覚ましたら隣に%ANAME(MASTER)%がいる…。こんな幸せったら無いね♥」
		PRINTFORMW 幸福に眩しさを感じているかのごとく愛しげに細められた目で、%ANAME(TARGET)%は%ANAME(MASTER)%をぽぅっと見つめる
		PRINTFORML ― 自分も同じ気持ちだよ ―　と告げると、%ANAME(TARGET)%は殊更嬉しそうに%ANAME(MASTER)%に抱きつく
		PRINTFORMW 「まったく、女ったらしと言うか鬼ったらしと言うか…。アンタにはかなわないねぇ…♥」
		PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%ともう一度キスを交わし、手を繋いで指を深く絡め、頬を染めながら%ANAME(MASTER)%を見つめる
		PRINTFORMW 「%ANAME(MASTER)%…♥　これからも私のこと、いっぱい愛しておくれ…♥」
	ELSEIF TALENT:妾
		PRINTFORML 普段よりかなり早めに目が覚めた。……%ANAME(TARGET)%に会いたい
		PRINTFORML 居ても立ってもいられず、会いに行こうと部屋を出た矢先、当の本人に出くわした
		PRINTFORML 「おう、%ANAME(MASTER)%、おはよう♪」
		PRINTFORMW 「それにしてもずいぶん早いお出かけですなぁ。もしかして私に会いたくなったとか？」
		PRINTFORML %ANAME(TARGET)%は心底幸せそうな笑顔で、%ANAME(MASTER)%を見つめてくる。「その通りだよ」と囁いて%ANAME(TARGET)%と抱き合った
		PRINTFORML 「んふ～♪　素直でよろしい♪」
		PRINTFORML 「まぁ、そう言う私も同じだけどさ♥　%ANAME(MASTER)%が起きててくれて良かったよ♪」
		PRINTFORMW %ANAME(MASTER)%と%ANAME(TARGET)%はキスを交わした後、指を深く絡めて手をつないだ
	ENDIF
	PRINTFORML 

```
