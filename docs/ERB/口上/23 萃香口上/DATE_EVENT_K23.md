# 口上/23 萃香口上/DATE_EVENT_K23.ERB — 自动生成文档

源文件: `ERB/口上/23 萃香口上/DATE_EVENT_K23.ERB`

类型: .ERB

自动摘要: functions: DATE_EVENT_K23, DATE_EVENT_K23_mizuumi, DATE_EVENT_K23_yama, DATE_EVENT_K23_mori, DATE_EVENT_K23_hitozato, DATE_EVENT_K23_hanabatake, DATE_EVENT_K23_zitaku; UI/print

前 200 行源码片段:

```text
﻿;--------------------------------------------------------
;そのキャラのデートイベント本体を呼び出すハブとなる関数
;--------------------------------------------------------
@DATE_EVENT_K23(場所)
#DIM 場所
#DIM 湖
#DIM 山
#DIM 森
#DIM 人里
#DIM 花畑
#DIM 自宅
#DIM 萃香
#DIM 勇儀
萃香 = NAME_TO_CHARA("萃香")
勇儀 = NAME_TO_CHARA("勇儀")

;面識がないとデートイベントは発生しない
SIF CFLAG:萃香:面識 == 0
	RETURN 0
;服従ルートだと発生しない
SIF TALENT:萃香:服従
	RETURN 0
;好感度が500以上で無いと発生しない
SIF CFLAG:萃香:好感度 <= 500
	RETURN 0

;--------------------------
;デートに誘ったときの反応	
;--------------------------

;好感度10000以上
IF CFLAG:萃香:好感度 >= 10000
	;自軍に勇儀がいたら1/3の確率で表示される
	IF CFLAG:勇儀:所属 == CFLAG:MASTER:所属 &&  !(MASTER == NAME_TO_CHARA("勇儀")) && !RAND:3
		PRINTFORML 
		CALL SINGLE_DRAWLINE
		PRINTFORML 
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「おーい、%ANAME(萃香)%。今から飲みに…って、ありゃ、もう先約がいるみたいだね」
				PRINTFORMW デートの待ち合わせ場所に向かう途中、%ANAME(勇儀)%が%ANAME(萃香)%に声を掛ける
				PRINTFORML 「ああ、%ANAME(勇儀)%。ふふーん、悪いね。今日は%ANAME(MASTER)%と逢引さ♪」
				PRINTFORMW %ANAME(MASTER)%とのデートが楽しみなのか、%ANAME(萃香)%はとても上機嫌だ
				PRINTFORML 「ちぇっ、そんな浮かれた顔しちゃってさ。あーあ、%ANAME(萃香)%が遠くに行っちゃったなー」
				PRINTFORMW 「な、何だよソレ…。分かったよ、今度付き合うからさ」
				PRINTFORML 「あははは、たまには拗ねてみるもんだね。それじゃあ今度飲む時に土産話を頼むよ」
				PRINTFORMW %ANAME(勇儀)%は%ANAME(萃香)%との呑み約束と取り付けて去っていった……
			CASE 1
				PRINTFORML 「あ、%ANAME(萃香)%。今から%ANAME(MASTER)%と逢引かい？」
				PRINTFORMW デートの待ち合わせ場所に向かう途中、%ANAME(萃香)%は%ANAME(勇儀)%に声を掛けられた
				PRINTFORML 「おお、%ANAME(勇儀)%。…そういうの、傍から見て分かるもんなの？」
				PRINTFORML 「そりゃまあ、付き合い長いからね。見りゃ分かるくらい浮かれてるよ、あんた」
				PRINTFORMW %ANAME(萃香)%はデートが楽しみすぎて、頬が緩みっぱなしだったことにまったく自覚が無かったようだ
				PRINTFORML 「あっはは！　%ANAME(萃香)%もそういう顔するんだねぇ。何だか妬けちゃうよ」
				PRINTFORMW 「な、何言ってんだいまったく…」
				PRINTFORML 「さて、これ以上引き止めちゃあ野暮だね。それじゃ、楽しんできなよ」
				PRINTFORMW %ANAME(勇儀)%は何やら嬉しそうな様子で%ANAME(萃香)%を見送った……
			CASE 2
				PRINTFORML 「おー、%ANAME(萃香)%じゃん。暇なら一緒に飲みに行かないかい？」
				PRINTFORMW デートで待ち合わせている途中、%ANAME(萃香)%は%ANAME(勇儀)%に声を掛けられた
				PRINTFORML 「あー、悪いね%ANAME(勇儀)%。今日は%ANAME(MASTER)%との大事な約束があってねー♪」
				PRINTFORMW %ANAME(MASTER)%とのデートが楽しみなのか、%ANAME(萃香)%はとても上機嫌だ
				PRINTFORML 「ありゃ残念。…しかし山の四天王ともあろう%ANAME(萃香)%がそういう顔するとは、よっぽど良い人見つけたんだねぇ」
				PRINTFORML 「…え、私そんな顔してる？」
				PRINTFORMW 「あははは、そりゃもう幸せそうな顔してるよ。それじゃ、馬に蹴られないうちに私は退散しようかね」
				PRINTFORML 「事の次第は今度一緒に飲む時に聞かせてよね。それじゃ、楽しんできなよ」
				PRINTFORMW そして%ANAME(萃香)%と呑みの約束を取り付けて、%ANAME(勇儀)%は去っていった……
		ENDSELECT
		PRINTFORML 
		CALL SINGLE_DRAWLINE
		PRINTFORMW 
	ENDIF
	SELECTCASE RAND:4
		CASE 0
			PRINTFORML 「おーい、遅いぞーっ！　まったく。あんまり待たせないで欲しいねぇ」
			PRINTFORMW 待ち合わせ時間より30分は早く来たつもりだったが、%ANAME(萃香)%はいつから待っていたのだろうか…
			PRINTFORML 「え、いつからってそりゃあ、……朝から…？」
			PRINTFORML そんなにデートが待ち遠しかったのか……
			PRINTFORMW %ANAME(MASTER)%が、ごめん　と%ANAME(萃香)%の頭を一撫ですると、彼女はたちまち笑顔になって許してくれた
		CASE 1
			PRINTFORML 「おーっ！　来たねぇ来たねぇ♪　待ってたよーっ♥」
			PRINTFORMW 「……何かテンションが高いって？　そりゃあアンタとのデートだもん。楽しみに決まってるじゃん♪」
			PRINTFORMW %ANAME(萃香)%は%ANAME(MASTER)%とのデートを心待ちにしていたようだ
		CASE 2
			PRINTFORML 「あ、来てくれたね、待ってたよ、ア・ナ・タ♥」
			PRINTFORML %ANAME(萃香)%は%ANAME(MASTER)%と出会うや否や、腕に組み付いてニンマリ笑顔になった
			PRINTFORMW 「んふふー♪　今日はどんな所へ連れてってくれるのかなぁ。楽しみだなー♥」
		CASE 3
			PRINTFORML 「んあぁ…。おはよう%ANAME(MASTER)%…ふわぁ…っ」
			PRINTFORMW 待ち合わせ場所に現れた%ANAME(萃香)%は何やら眠そうだ
			PRINTFORML 「いやぁ、今日のデートが楽しみで…ワクワクしすぎて寝付けなかったんだよ……」
			PRINTFORMW …そんなに眠いなら、デートはまたの機会にしようか？
			PRINTFORML 「いやいやいやっ！　そりゃないよ%ANAME(MASTER)%ーっ！　私がどれだけこの日を楽しみにしていたことかっ！」
			PRINTFORMW %ANAME(萃香)%の眠気は、%ANAME(MASTER)%の一言で吹き飛んでくれたようだ
	ENDSELECT

;好感度1500以上
ELSEIF CFLAG:萃香:好感度 >= 1500
	;自軍に勇儀がいたら1/3の確率で表示される
	IF CFLAG:勇儀:所属 == CFLAG:MASTER:所属 &&  !(MASTER == NAME_TO_CHARA("勇儀")) && !RAND:3
		PRINTFORML 
		CALL SINGLE_DRAWLINE
		PRINTFORML 
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「おーい、%ANAME(萃香)%。丁度良かった、今から飲みに行かないかい？」
				PRINTFORMW デートの待ち合わせ場所に向かう途中、%ANAME(勇儀)%が%ANAME(萃香)%に声を掛ける
				PRINTFORML 「ああ、%ANAME(勇儀)%か。うーん、残念だけど今日はちょっと用事があってね…」
				PRINTFORMW 「あー？　私との飲みを断るなんて一体どういう用事が……、ああ、なるほどね…」
				PRINTFORML %ANAME(MASTER)%とのデート用に、少しおめかししていた%ANAME(萃香)%の姿を見て、%ANAME(勇儀)%は概ね察した
				PRINTFORMW 「な、何だよぉ……」
				PRINTFORML 「あっははは、何でもないさ。さーて、じゃあ私は他を誘ってみるか。今度飲む時に土産話を頼むよ」
				PRINTFORMW %ANAME(勇儀)%は何やら嬉しそうな様子で%ANAME(萃香)%を見送った……
			CASE 1
				PRINTFORML 「…お、%ANAME(萃香)%じゃん。そんなめかしこんで何処へ行くんだ？」
				PRINTFORMW デートの待ち合わせ場所に向かう途中、%ANAME(萃香)%は%ANAME(勇儀)%に声を掛けられた
				PRINTFORML 「おお、%ANAME(勇儀)%か。…べ、別にいつもと変わらないだろ」
				PRINTFORMW 「なーに言ってんだい。お前さんが色気づいてるって分からない程度の付き合いだと思ってたのかい？」
				PRINTFORML 「い、いや、そういうわけじゃ…」
				PRINTFORMW 「……あっはは！　冗談さ、冗談。%ANAME(MASTER)%との逢引だろ？　最近お熱らしいじゃないか」
				PRINTFORML 「…ほーお、分かっててからかうとは良い度胸だねぇ。流石は%ANAME(勇儀)%だよ」
				PRINTFORMW 「おっと怖い怖い。それじゃあ、お邪魔にならないうちに鬼は退散といこうかね」
				PRINTFORML %ANAME(勇儀)%はおどけた様子で肩をすくめ、%ANAME(萃香)%を開放した
				PRINTFORMW 「……楽しんできなよ、%ANAME(萃香)%」
				PRINTFORMW そして%ANAME(萃香)%を見送りながら、%ANAME(勇儀)%は優しげに呟いた……
			CASE 2
				PRINTFORML 「おー、%ANAME(萃香)%じゃん。暇なら一緒に飲みに行かないかい？」
				PRINTFORMW デートで待ち合わせている途中、%ANAME(萃香)%は%ANAME(勇儀)%に声を掛けられた
				PRINTFORML 「あー、悪いね%ANAME(勇儀)%。今日は%ANAME(MASTER)%との先約があるんだよ」
				PRINTFORMW 「ありゃ残念。それじゃ他を誘ってみるか。…しかし%ANAME(萃香)%が%ANAME(MASTER)%と逢引とは、興味が湧くねぇ」
				PRINTFORML 「一応釘を刺しとくけど…、出歯亀したら、『酷い』ぞ？」
				PRINTFORML 相手が%ANAME(勇儀)%でなければ背筋が凍りつくような声色で%ANAME(萃香)%が念を押す
				PRINTFORMW 「ははは、気にはなるが流石にそこまでする趣味は無いね」
				PRINTFORML 「事の次第は今度一緒に飲む時に聞かせてもらうとしようか。それじゃ、楽しんできなよ」
				PRINTFORMW そして%ANAME(萃香)%と呑みの約束を取り付けて、%ANAME(勇儀)%は去っていった……
		ENDSELECT
		PRINTFORML 
		CALL SINGLE_DRAWLINE
		PRINTFORMW 
	ENDIF
	SELECTCASE RAND:4
		CASE 0
			PRINTFORML 「遅いぞーっ、あんまり待たせないで欲しいねぇ」
			PRINTFORMW 待ち合わせ時間より20分は早く来たつもりだったが、%ANAME(萃香)%はいつから待っていたのだろうか…
		CASE 1
			PRINTFORML 「おーっ！　来たね来たねぇ♪　待ってたんだよ？」
			PRINTFORML 「……何かテンションが高いって？　そ、そりゃお前さんアレだよ…アレ」
			PRINTFORMW %ANAME(萃香)%は普段より顔を赤くして何やらアタフタしている
		CASE 2
			PRINTFORML 「お待たせーっ♪　今日は何処に行くんだい？　まあ一緒にいるだけでも充分だけどさ」
			PRINTFORMW %ANAME(萃香)%はそう言うと、%ANAME(MASTER)%の腕に抱きついた
		CASE 3
			PRINTFORML 「今日の%ANAME(MASTER)%とのデート、楽しみにしてたよ♪」
			PRINTFORMW 「さあさあ、今日も楽しい一日にしておくれよ？」
	ENDSELECT

;好感度500以上
ELSE
	PRINTDATAL
		DATAFORM 「鬼と遊びたいなんて度胸あるねぇ、アンタ♪」
		DATAFORM 「こんなちんちくりんとデートなんて変わってるねぇ。…もしかしてそっちの気がお有り？」
		DATAFORM 「いいねぇ、何処に飲みに行くんだい？」
	ENDDATA
	PRINTFORMW %ANAME(MASTER)%に遊びに誘われ、%ANAME(萃香)%は満更でもない様子だ
ENDIF
PRINTFORML …
PRINTFORML ……
PRINTFORML ………
PRINTFORML

;--------------------------
;デートイベント本体へ
;--------------------------
SELECTCASE 場所
	CASE 1
		;湖に行く
		CALL DATE_EVENT_K23_mizuumi(湖)
	CASE 2
		;山に行く
		CALL DATE_EVENT_K23_yama(山)
	CASE 3
		;森に行く
		CALL DATE_EVENT_K23_mori(森)
	CASE 4
		;人里に行く
		CALL DATE_EVENT_K23_hitozato(人里)
	CASE 5
		;花畑に行く
		CALL DATE_EVENT_K23_hanabatake(花畑)
	CASE 6
		;自宅に誘う
		CALL DATE_EVENT_K23_zitaku(自宅)
ENDSELECT

;--------------------------
;デート終了時の反応	
;--------------------------
PRINTFORML
PRINTFORML …
PRINTFORML ……
```
