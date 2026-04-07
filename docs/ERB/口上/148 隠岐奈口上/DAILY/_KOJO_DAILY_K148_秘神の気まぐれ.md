# 口上/148 隠岐奈口上/DAILY/_KOJO_DAILY_K148_秘神の気まぐれ.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/DAILY/_KOJO_DAILY_K148_秘神の気まぐれ.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K148_NIGHTEVENT_RATE, KOJO_DAILY_K148_NIGHTEVENT_DECISION, KOJO_DAILY_K148_NIGHTEVENT_GENRE, KOJO_DAILY_K148_NIGHTEVENT; UI/print

前 200 行源码片段:

```text
﻿

;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K148_NIGHTEVENT_RATE(対象)
#DIM 対象
RETURN 80


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K148_NIGHTEVENT_DECISION(対象)
#DIM 対象

;対象との所属が同じ、好感度500以上、8%
SIF !CFLAG:対象:好感度 >= 500
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

RETURN 1


;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K148_NIGHTEVENT_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_その他



;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K148_NIGHTEVENT(対象)
#DIM 対象
#DIM 経験値

PRINTFORML 
PRINTFORML ある晩のこと。
SELECTCASE RAND:3
;添い寝   
	CASE 0
	;正妻
		IF TALENT:対象:正妻
			SELECTCASE RAND:3
				CASE 0
					PRINTFORMW %ANAME(MASTER)%が寝る準備をしていると、隠岐奈がそろそろと近寄ってきた。
					PRINTFORML 
					PRINTFORML 「%ANAME(MASTER)%、今日はもうお休みか？ なら、私も一緒に寝てしまおうかな」
					PRINTFORML そう言うと隠岐奈は服を脱ぎ、寝巻に着替え始める…。
					PRINTFORMW 目の前にいる相手が伴侶であるゆえに、彼女は自身の素肌を晒すことにも躊躇する様子はない。
					PRINTFORML 白く滑らかな肌、柔らかな肢体。
					PRINTFORMW その感触をよく知っているからこそ、%ANAME(MASTER)%は彼女の姿に釘付けになってしまう。
					PRINTFORML 
					PRINTFORML 「……何をそんなに見ている」
					PRINTFORMW 「悪いが、今日はそういう気分じゃないんだ……明日まで、我慢できるな？」
					PRINTFORML にや、と意地悪な笑みを浮かべ、隠岐奈は寝台に寝転がる。
					PRINTFORML 誘っているようにも見えなくないが、"おあずけ"を食らった以上は添い寝に留めるほかはない。
					PRINTFORMW %ANAME(MASTER)%も彼女の隣に横たわり、傍らのぬくもりを感じつつ、目を瞑った。
				CASE 1
					PRINTFORML 「%ANAME(MASTER)%……もう遅いし、寝よう…？」
					PRINTFORMW 隠岐奈は眠たげな様子で、くいくいと%ANAME(MASTER)%の袖を引っ張る。
					PRINTFORML 確かに今日は夜更かししすぎた。そろそろ寝ないと明日に響くだろう。
					PRINTFORMW %ANAME(MASTER)%は隠岐奈の腰を抱き、共にベッドへと向かった…。
					PRINTFORML 
					PRINTFORML 「ふあぁ……おやすみ………」
					PRINTFORML どうやら眠気が限界に達していたようで、隠岐奈は横になるとすぐに寝入ってしまった。
					PRINTFORMW 少し物足りなさを感じつつも、%ANAME(MASTER)%は彼女の寝顔を存分に眺めてから眠りに落ちた…。
				CASE 2
					PRINTFORML 「……たまには、こうしてくっついているだけなのも悪くないな」
					PRINTFORMW %ANAME(MASTER)%の胸に顔を埋め、隠岐奈はふっと微笑んだ。
					PRINTFORML "今日は疲れているから"と夜の誘いを断ったものの、隠岐奈が人肌恋しそうだったので妥協した結果が今のこの状態だ。
					PRINTFORMW 最初は不満げだった彼女も、しばらく抱き着いているうちに満足したようで、今は幸せそうに目を細めている。
					PRINTFORML 
					PRINTFORML 「%ANAME(MASTER)%、好きだ……」
					PRINTFORML 隠岐奈は小さくそう呟くと、より一層ぎゅっと%ANAME(MASTER)%に密着して目を瞑った。
					PRINTFORMW %ANAME(MASTER)%も優しく抱き返してやり、満たされた気持ちで眠りについた。
			ENDSELECT 
	;恋慕 or 服従
		ELSEIF TALENT:対象:恋慕 || TALENT:対象:服従
			SELECTCASE RAND:4
				CASE 0
					PRINTFORML %ANAME(MASTER)%が寝る準備をしていると、背後から隠岐奈が現われて抱き着いてきた。
					PRINTFORML 「私も丁度寝るところでな。なんだったら同衾してやってもいいぞ？」
					PRINTFORMW どう頑張っても放してくれそうになかったので、%ANAME(MASTER)%は隠岐奈と一緒に寝ることにした。
				CASE 1
					PRINTFORML %ANAME(MASTER)%がベッドに向かうと、すでに隠岐奈が寝ころんでいた。
					PRINTFORML 「このベッド、寝心地が良いな。しばらくこうさせてもらおうか」
					PRINTFORML 「……%ANAME(MASTER)%も、寝たかったらいいんだぞ？」
					PRINTFORMW そう言いながら、隠岐奈は頬を染めてぽんぽんと隣のスペースを叩いた。
				CASE 2
					PRINTFORML %ANAME(MASTER)%がベッドに向かうと、すでに隠岐奈が寝ころんでいた。
					PRINTFORML 「やっと来たのか、遅いぞ！」
					PRINTFORML 「私の抱き枕にしてやるから、さっさと横になりなさい」
					PRINTFORMW %ANAME(MASTER)%が仕方なく従うと、隠岐奈は嬉しそうに抱き着いてきた。
				CASE 3
					PRINTFORML %ANAME(MASTER)%が寝る準備をしていると、背後から隠岐奈が現われて抱き着いてきた。
					PRINTFORML 「%ANAME(MASTER)%、寝るのだろう？私が添い寝してやる」
					PRINTFORMW 「なんなら子守唄でも歌ってやろうか、ふふふっ」
			ENDSELECT
			PRINTFORML
			PRINTFORML %ANAME(MASTER)%は隠岐奈と楽しい時間を過ごした！
			PRINTFORMW ………が、特にエッチなイベントは起こらずに終わった。
	;その他
		ELSE
			PRINTFORML %ANAME(MASTER)%がベッドに向かうと、何故かすでに隠岐奈が寝ころんでいた。
			PRINTFORML 「このベッド、寝心地が良いな。しばらくこうさせてもらうぞ」
			PRINTFORMW 「お前も寝たいなら、勝手にしなさい」
			PRINTFORML
			PRINTFORML %ANAME(MASTER)%は隠岐奈とそこそこ楽しい時間を過ごした！
			PRINTFORMW ………が、特にエッチなイベントは起こらずに終わった。
		ENDIF
		CFLAG:対象:好感度 += 100
		CFLAG:対象:従属度 += 100
		RETURN 1

;晩酌
	CASE 1
		PRINTFORML 仕事を終えて自室でのんびりしていると、突然うなじにヒンヤリとしたものが押し当てられた。
		PRINTFORML %ANAME(MASTER)%が驚いて振り返ると、隠岐奈がニヤニヤしながら酒瓶を見せつけてきた。
		SELECTCASE RAND:4
			CASE 0
				PRINTFORMW 「良い酒が手に入ってな。付き合ってもらうぞ？」
			CASE 1
				PRINTFORMW 「%ANAME(MASTER)%、晩酌でもどうだ？どうせ暇だろう？」
			CASE 2
				PRINTFORMW 「良い酒を持ってきたぞ。肴もあるし、一緒に楽しもうじゃないか」
			CASE 3
				PRINTFORMW 「静かな良い夜だからな。晩酌でもどうだ？」
		ENDSELECT 
		;妊娠中の飲酒は禁物！
		IF TALENT:MASTER:妊娠
			PRINTFORML 
			PRINTFORML 「……とは言ったが、お前は妊娠中だったな」
			PRINTFORMW 「お茶とジュース、どっちが良い？ あ、ジンジャーエールもあるよ？」
			PRINTFORMW こうして、様々な飲み物やおつまみを勧められながら、%ANAME(MASTER)%は隠岐奈の酒盛りに付き合ってあげた。
			PRINTFORML 
			PRINTFORML ……少しお酒が余ったので、隠岐奈に「取っておけ」と押し付けられた…。
			CALL COLOR_PRINTW("日本酒を1つ手に入れた！", カラー_注意)
			経験値 = GET_EXP(GETNUM(ABL, "肝臓"))
			CALL PRINT_ADD_EXP(対象, EXPNAME:経験値, RAND:5 + 1, 1)
			CALL TRAIN_AUTO_ABLUP(対象)
			ITEM:日本酒 += 1
		ELSEIF TALENT:対象:妊娠
			PRINTFORML 
			PRINTFORMW 「……とは言ったが、私は妊娠中だからね。その酒はお前が全部飲んでよろしい！」
			PRINTFORML どうだ、嬉しいだろう？とばかりに隠岐奈はドヤ顔をしている…。
			PRINTFORMW %ANAME(MASTER)%はありがたくお酒を受け取り、彼女に酌をしてもらいながら楽しんだ。
			PRINTFORML 
			PRINTFORML 結局、酒は少し余ってしまったが、後で有効活用できるだろう…。
			CALL COLOR_PRINTW("日本酒を1つ手に入れた！", カラー_注意)
			ITEM:日本酒 += 1
			経験値 = GET_EXP(GETNUM(ABL, "肝臓"))
			CALL PRINT_ADD_EXP(MASTER, EXPNAME:経験値, RAND:5 + 1, 1)
			CALL TRAIN_AUTO_ABLUP(対象)
		ELSE
			PRINTFORML %ANAME(MASTER)%が頷くと、隠岐奈は嬉しそうに御酌をしてくれた。
			PRINTFORMW 「そら、味わって飲め！ つまみも美味いぞ、もっと食え～♪」
			経験値 = GET_EXP(GETNUM(ABL, "肝臓"))
			CALL PRINT_ADD_EXP(対象, EXPNAME:経験値, RAND:5 + 1, 1)
			CALL TRAIN_AUTO_ABLUP(対象)
			CALL PRINT_ADD_EXP(MASTER, EXPNAME:経験値, RAND:5 + 1, 1)
			CALL TRAIN_AUTO_ABLUP(MASTER)
		ENDIF
		PRINTFORML
		PRINTFORML こうして、%ANAME(MASTER)%は隠岐奈と楽しい時間を過ごした！
		PRINTFORMW ………が、特にエッチなイベントは起こらずに終わった。
		CFLAG:対象:好感度 += 100
		CFLAG:対象:従属度 += 100
		RETURN 1
;そのほかいろいろ
	CASE 2
	;正妻
		IF TALENT:対象:正妻
			PRINTFORML 仕事を終えて自室に戻ると、隠岐奈が笑顔で出迎えてくれた。
			PRINTFORML 「おかえり、%ANAME(MASTER)%。今日も遅くまで大変だったな」
			SELECTCASE RAND:6
				CASE 0
					PRINTFORML 「早速だが、横になれ。私がマッサージしてやろう」
					PRINTFORMW 隠岐奈に促され、%ANAME(MASTER)%はベッドにうつ伏せになった…。
					PRINTFORML 
					PRINTFORML 「おお、よく凝っているなぁ…これは揉み甲斐がありそうだ！」
					PRINTFORML 程よい力加減で体をもみもみされ、%ANAME(MASTER)%は心地よさに声を漏らす。
					PRINTFORML 「ふふふ……ここはどうだ？気持ち良いか？」
					PRINTFORMW %ANAME(MASTER)%の様子を見て隠岐奈も気を良くしたのか、さらにマッサージに熱が入っていった…。
					PRINTFORML 
					PRINTFORMW こうして、%ANAME(MASTER)%は充分にリラックスすることができた…！
				CASE 1
					PRINTFORML 「何か温かいものでも飲むか？リラックスできるぞ」
					PRINTFORMW %ANAME(MASTER)%が頷くと、隠岐奈はふっと微笑んで飲み物を取りに行った。
```
