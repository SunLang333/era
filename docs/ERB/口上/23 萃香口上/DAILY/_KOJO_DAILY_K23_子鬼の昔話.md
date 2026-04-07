# 口上/23 萃香口上/DAILY/_KOJO_DAILY_K23_子鬼の昔話.ERB — 自动生成文档

源文件: `ERB/口上/23 萃香口上/DAILY/_KOJO_DAILY_K23_子鬼の昔話.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K23_OLDTALE_RATE, KOJO_DAILY_K23_OLDTALE_DECISION, KOJO_DAILY_K23_OLDTALE_GENRE, KOJO_DAILY_K23_OLDTALE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K23_OLDTALE_RATE(対象)
#DIM 対象
RETURN 100 + (KDVAR:対象:萃香_昔話 > 0) * 50


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K23_OLDTALE_DECISION(対象)
#DIM 対象

;プレイヤーキャラが紫か勇儀か華扇なら発生しない
SIF GROUPMATCH(MASTER, NAME_TO_CHARA("紫"), NAME_TO_CHARA("勇儀"), NAME_TO_CHARA("華扇"))
	RETURN 0

;終わってたら発生しない
SIF KDVAR:対象:萃香_昔話 == -1
	RETURN 0

;恋慕系で、合意がなければだめ
SIF !(IS_LOVER(対象) && TALENT:対象:合意)
	RETURN 0

;ARG:0が口上デイリーイベントを実施できるかの簡易チェック関数
;ARG:1 0 MASTERと別勢力である 1 MASTERと同一勢力である　-1 どちらでもよい
;ARG:2 0 捕虜でない 1 捕虜である -1 どちらでもよい
;ARG:3 0 面識がない 1 面識がある -1 どちらでもよい
RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K23_OLDTALE_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_その他


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K23_OLDTALE(対象)
#DIM 対象


SELECTCASE KDVAR:対象:萃香_昔話
	CASE 0
		PRINTFORMW 「やあ、%ANAME(MASTER)%」
		PRINTFORML 夜、外をぶらぶらしていると%ANAME(対象)%が月見酒をしていた
		PRINTFORMW 「月を見てたらさ、なんかちょっと昔を思い出してね」
		PRINTFORMW 「思い出を肴に飲んでたところさ。月の明かりは今も昔も変わらないからね」
		PRINTFORML %ANAME(対象)%は見た目と違って長くを生きてきた大妖怪だ
		PRINTFORMW 当然、過去にも色々な事があったのだろう。…ちょっと興味があるな
		PRINTFORML 「…良かったらだけど、私の昔話、聞いてみる？　一杯おごるよ」
		PRINTFORMW どうしようか……
		PRINTFORML 
		CALL ASK_YN("どんな話か、興味がある", "今日のところはいいかな")
		IF RESULT == 1
			PRINTFORML 「そう？　そりゃ残念。ま、気が向いたらまた今度ね」
			PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%に手を振って別れた
		ELSE
			PRINTFORMW 「ふふ、それじゃあ、酔っ払いの話にちょっと付き合っておくれよ」
			PRINTFORML 
			PRINTFORMW %ANAME(対象)%は自分の過去を色々と語ってくれた
			PRINTFORML 昔の人間たちとの交流、受けた恩と仇の話を区別無く…
			PRINTFORMW 語り口の端々から、人間への好意が滲み出ていた
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW 「ふう…、今日はここまでにしようか。付き合ってくれてありがとうな」
			PRINTFORML いろいろ聞き入る内容だった。続きもいつか聞きたいな
			PRINTFORMW 「そ、そう？　へへ、なんか照れるなぁ」
			PRINTFORML 「でもなー、酔いが浅いと興が乗らないし…そうだなぁ」
			PRINTFORML
			CALL ICPRINT("「次は<清酒みっつ>用意してくれたら話してあげるよ」", "W", カラー_注意)
			PRINTFORML
			PRINTFORML 次の話はこっちで酒を用意すれば聞かせてくれるようだ
			PRINTFORMW 「私はここで飲んでるからさ、気が向いたらまたおいで」
			PRINTFORML
			CALL ICPRINT(@"<%ANAME(対象)%は昔話でかつての経験を思い出したようだ>", "W", カラー_注意)
			CALL PRINT_ADD_EXP(対象, "武闘経験値", 10, 1)
			CALL PRINT_ADD_EXP(対象, "防衛経験値", 10, 1)
			CALL PRINT_ADD_EXP(対象, "知略経験値", 5, 1)
			CALL PRINT_ADD_EXP(対象, "肝臓経験値", RAND(50, 100), 1)
			CALL PRINT_ADD_EXP(MASTER, "肝臓経験値", RAND(50, 100), 1)
			CALL TRAIN_AUTO_ABLUP(対象)
			CALL TRAIN_AUTO_ABLUP(MASTER)
			PRINTFORML
			CFLAG:対象:好感度 += 200
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が200上がった", カラー_シアン)
			KDVAR:対象:萃香_昔話 = 1
		ENDIF
	;KDVAR:対象:萃香_昔話 = が1でイベント発生
	CASE 1
		PRINTFORML 「よう、%ANAME(MASTER)%」
		PRINTFORMW 夜、外を歩いていると%ANAME(対象)%が月見酒をしていた
		PRINTFORML 「また私の話、聞きたくなったかい？」
		CALL ICPRINT("「<清酒みっつ>くれるんなら聞かせてあげるよ」", "W", カラー_注意)
		PRINTFORMW どうしようか……
		PRINTFORML 
		CALL ASK_MULTI_JUDGE("聞きたい",  ITEM:清酒 >= 3, "今日はやめておく", 1)
		IF RESULT == 1
			PRINTFORML 「そう？　そりゃ残念。ま、気が向いたらまた今度ね」
			PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%に手を振って別れた
		ELSE
			PRINTFORMW 「ふふ、バッチリだよ%ANAME(MASTER)%。それじゃあ、今日も酔っ払いの話に付き合っておくれ」
			PRINTFORML 
			PRINTFORMW %ANAME(対象)%は自分の過去を色々と語ってくれた
			PRINTFORML 数多の鬼や人間と出会い、戦い、そして親交を深めて行ったこと…
			PRINTFORMW 語り口の端々から、鬼としての誇りが滲み出ていた
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW 「ふう…、今日はここまでにしようか。付き合ってくれてありがとうね」
			PRINTFORMW 「しかし聞き手がいると、何だか喋りすぎちゃうな。退屈じゃなかった？」
			PRINTFORML いろいろ聞き入る内容だった。また続きを聞きたいな
			PRINTFORMW 「そ、そう？　へへ、なんか照れるなぁ」
			PRINTFORML 「でもなー、酔いが浅いと興が乗らないし…そうだなぁ」
			PRINTFORML
			CALL ICPRINT("「次は<麦酒みっつ>用意してくれたら話してあげるよ」", "W", カラー_注意)
			PRINTFORML
			PRINTFORML 次の話はこっちで酒を用意すれば聞かせてくれるようだ
			PRINTFORMW 「私はここで飲んでるからさ、気が向いたらまたおいで」
			PRINTFORML
			CALL ICPRINT(@"<%ANAME(対象)%は昔話でかつての経験を思い出したようだ>", "W", カラー_注意)
			CALL PRINT_ADD_EXP(対象, "武闘経験値", 15, 1)
			CALL PRINT_ADD_EXP(対象, "防衛経験値", 15, 1)
			CALL PRINT_ADD_EXP(対象, "知略経験値", 5, 1)
			CALL PRINT_ADD_EXP(対象, "肝臓経験値", RAND(20, 50), 1)
			CALL PRINT_ADD_EXP(MASTER, "肝臓経験値", RAND(20, 50), 1)
			CALL TRAIN_AUTO_ABLUP(対象)
			CALL TRAIN_AUTO_ABLUP(MASTER)
			ITEM:清酒 -= 3
			CALL COLOR_PRINTW("清酒を3つ飲み干した", カラー_注意)
			CFLAG:対象:好感度 += 200
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が200上がった", カラー_シアン)
			KDVAR:対象:萃香_昔話 = 2
		ENDIF
	;KDVAR:対象:萃香_昔話 = が2でイベント発生
	CASE 2
		PRINTFORML 「おう、%ANAME(MASTER)%」
		PRINTFORMW 夜、外を歩いていると%ANAME(対象)%が月見酒をしていた。隣に一人分のスペースを空けて…
		PRINTFORML 「また私の話、聞きたくなったかい？」
		CALL ICPRINT("「<麦酒みっつ>くれるんなら聞かせてあげるよ」", "W", カラー_注意)
		PRINTFORMW どうしようか……
		PRINTFORML 
		CALL ASK_MULTI_JUDGE("聞きたい",  ITEM:麦酒 >= 3, "今日はやめておく", 1)
		IF RESULT == 1
			PRINTFORML 「そう？　そりゃ残念。ま、気が向いたらまた今度ね」
			PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%に手を振って別れた
		ELSE
			PRINTFORMW 「おお！　バッチリだよ%ANAME(MASTER)%。それじゃあ、今日も酔っ払いの話に付き合っておくれ」
			PRINTFORML 
			PRINTFORMW %ANAME(対象)%は自分の過去を色々と語ってくれた
			PRINTFORML 人間たちとの関係の変化によって起きた事、人間と鬼との絆の終焉…
			PRINTFORMW 語り口の端々から、悔しさと、そして寂しさが滲み出ていた
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW 「ふう…、今日はここまでにしようか。何だか余計なことまで話しちゃった気がするよ」
			PRINTFORML いろいろ聞き入る内容だった。続きもいつか聞きたいな
			PRINTFORMW 「そ、そう？　へへ、なんか照れるなぁ」
			PRINTFORML 「でもなー、酔いが浅いと興が乗らないし…そうだなぁ」
			PRINTFORML
			CALL ICPRINT("「次は<日本酒みっつ>用意してくれたら話してあげるよ」", "W", カラー_注意)
			PRINTFORML
			PRINTFORML 次の話はこっちで酒を用意すれば聞かせてくれるようだ
			PRINTFORMW 「私はここで飲んでるからさ、気が向いたらまたおいで」
			PRINTFORML
			CALL ICPRINT(@"<%ANAME(対象)%は昔話でかつての経験を思い出したようだ>", "W", カラー_注意)
			CALL SKILL_LEARN_BY_NAME(対象, スキル_ジャンル_PERSONAL, NO:対象, "天手力男投げ")
			SIF RESULT
				CALL COLOR_PRINTW(@"%ANAME(対象)%がスキル＜天手力男投げ＞を習得しました", カラー_注意)
			CALL PRINT_ADD_EXP(対象, "武闘経験値", 15, 1)
			CALL PRINT_ADD_EXP(対象, "防衛経験値", 15, 1)
			CALL PRINT_ADD_EXP(対象, "知略経験値", 5, 1)
			CALL PRINT_ADD_EXP(対象, "肝臓経験値", RAND(20, 50), 1)
			CALL PRINT_ADD_EXP(MASTER, "肝臓経験値", RAND(20, 50), 1)
			CALL TRAIN_AUTO_ABLUP(対象)
			CALL TRAIN_AUTO_ABLUP(MASTER)
			ITEM:麦酒 -= 3
			CALL COLOR_PRINTW("麦酒を3つ飲み干した", カラー_注意)
			CFLAG:対象:好感度 += 200
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が200上がった", カラー_シアン)
			KDVAR:対象:萃香_昔話 = 3
		ENDIF
	;KDVAR:対象:萃香_昔話 = が3でイベント発生
	CASE 3
		PRINTFORML 「ああ、%ANAME(MASTER)%」
		PRINTFORMW 夜、外を歩いていると%ANAME(対象)%が月見酒をしていた。隣に一人分のスペースを空けて…
		PRINTFORML 「また私の話、聞きたくなったかい？」
		CALL ICPRINT("「<日本酒みっつ>くれるんなら聞かせてあげるよ」", "W", カラー_注意)
		PRINTFORMW どうしようか……
		PRINTFORML 
		CALL ASK_MULTI_JUDGE("聞きたい",  ITEM:日本酒 >= 3, "今日はやめておく", 1)
```
