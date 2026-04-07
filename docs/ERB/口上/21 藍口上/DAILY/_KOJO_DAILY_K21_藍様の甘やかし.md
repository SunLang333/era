# 口上/21 藍口上/DAILY/_KOJO_DAILY_K21_藍様の甘やかし.ERB — 自动生成文档

源文件: `ERB/口上/21 藍口上/DAILY/_KOJO_DAILY_K21_藍様の甘やかし.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K21_AMAYAKASI_RATE, KOJO_DAILY_K21_AMAYAKASI_DECISION, KOJO_DAILY_K21_AMAYAKASI_GENRE, KOJO_DAILY_K21_AMAYAKASI; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K21_AMAYAKASI_RATE(対象)
#DIM 対象
RETURN (KDVAR:対象:藍_甘やかし > 0 ? 200 # 70)

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K21_AMAYAKASI_DECISION(対象)
#DIM 対象

;プレイヤーキャラが紫か幽々子だと発生しない
SIF (MASTER == NAME_TO_CHARA("紫") || MASTER == NAME_TO_CHARA("幽々子"))
	RETURN 0

;恋慕系か主人系で、合意がなければだめ
SIF !((IS_LOVER(対象) || IS_SLAVED_BY(対象)) && TALENT:対象:合意)
	RETURN 0

;ペニスがないと駄目
SIF !HAS_PENIS(MASTER)
	RETURN 0
	
;対象が女でないとだめ
SIF !IS_FEMALE(対象)
	RETURN 0
	
;終わってたら発生しない
SIF KDVAR:対象:藍_甘やかし == -1
	RETURN 0
	
;ARG:0が口上デイリーイベントを実施できるかの簡易チェック関数。
;ARG:1 0 MASTERと別勢力である 1 MASTERと同一勢力である　-1 どちらでもよい
;ARG:2 0 捕虜でない 1 捕虜である -1 どちらでもよい
;ARG:3 0 面識がない 1 面識がある -1 どちらでもよい
RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1) 

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K21_AMAYAKASI_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K21_AMAYAKASI(対象)
#DIM 対象
#DIM 対象都市
#DIM 対象都市2
#DIM 橙

橙 = NAME_TO_CHARA("橙")

;自国都市ランダム
CALL DAILY_EVENT_RAND_CITYSELECT(0)
対象都市 = RESULT
SIF 対象都市 < 0
	RETURN 0

CALL DAILY_EVENT_RAND_CITYSELECT(0)
対象都市2 = RESULT
SIF 対象都市 < 0
	RETURN 0
	
SELECTCASE KDVAR:対象:藍_甘やかし
	CASE 0
		PRINTFORMW 深夜。%ANAME(MASTER)%の部屋にはまだ明かりが灯っている
		PRINTFORML %ANAME(MASTER)%はここ最近、書類仕事が山のように増え、連日夜遅くまで仕事に追われていた…
		PRINTFORML 領内の経済に関わる事だけにサボるわけにも行かず、青白い顔で書類と向き合っていると
		PRINTFORMW 「…大丈夫か？　%ANAME(MASTER)%。ずいぶん疲れた顔をしているぞ」
		PRINTFORML 連日の激務を心配してくれたのか、%ANAME(対象)%が様子を見に来たようだ
		PRINTFORMW 「ふむ…この量は中々厳しいだろう。顔色も悪いし、少し休んだらどうだ？　後は私がやっておくから」
		PRINTFORML 大変ありがたい申し出だが、%ANAME(対象)%はその優秀さから既に自分より多くの仕事を受け持っている
		PRINTFORMW これ以上彼女に負担をかけるような事をしていいものか…どうしよう？
		PRINTFORML
		CALL ASK_YN("それじゃあ、お言葉に甘えて…", "大丈夫、何とかするよ…何とかするさ…")
		IF RESULT == 1
			PRINTFORML 「本当に大丈夫なのか？　……それじゃあ、私は行くからな…」
			PRINTFORML %ANAME(対象)%は心配そうな顔で立ち去っていった……
			PRINTFORMW これは自分の担当の仕事だ。%ANAME(対象)%に余計な負担をかけるわけには行かない
			PRINTFORML 再び書類の山に向かうもしばらくすると目が霞みはじめる
			PRINTFORMW 連日の疲れがたたったのか、だんだん意識が朦朧としてきた……
			PRINTFORML
			PRINTFORMW
			CALL COLOR_PRINTL(@"%ANAME(MASTER)%は過労で倒れてしまった！", カラー_注意)
			PRINTFORML
			PRINTFORMW
			PRINTFORML ・
			PRINTFORML ・・
			PRINTFORMW ・・・
			PRINTFORML 「……ん？　気がついたか%ANAME(MASTER)%。ああ、まだ寝ているといい。大丈夫、書類は私が片付けてるから」
			PRINTFORML %ANAME(MASTER)%が意識を取り戻すと、%ANAME(対象)%が声を掛ける。どうやら倒れた%ANAME(MASTER)%を見つけて看病してくれていたようだ
			PRINTFORMW 「念のためにもう一度見に来てよかったよ。どうやら軽い貧血のようだが、後でちゃんと医者に見てもらうといい」
			PRINTFORML ― 一体どれぐらい気を失っていたのだろうか？　期日が近い書類も多い。早く取り掛からねば…っ ―
			PRINTFORMW 「駄目だ。まだ寝ていろといったろう？　お前は無理をして倒れたんだぞ。仕事のことは心配するな」
			PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の頭を撫でながら、その尻尾の毛先に無数のペンを持たせ、凄まじい速さで書類を処理している
			PRINTFORMW 「私の体は仮にも九尾だぞ？　これくらい何てことはない。一先ず、期日が近い分から先にやっつけておいたからな」
			PRINTFORML 結局%ANAME(対象)%は大量にあった書類の束をあっという間に片付けてしまった。これでしばらくは大丈夫だろう
			PRINTFORMW 「まったく。頑張るのは立派だが、倒れる前にまず頼って欲しいものだ。それとも、私じゃ頼りないのか？」
			PRINTFORMW %ANAME(MASTER)%は、「自分の仕事で%ANAME(対象)%に余分な負担を掛けたくなかった」、と%ANAME(対象)%に伝えた
			PRINTFORML 「…そういう優しいところは美点だが、それで自分が倒れては元も子もないぞ。……本当に、心配したんだからな…」
			PRINTFORMW %ANAME(対象)%はそう言うと%ANAME(MASTER)%を抱きしめ、尻尾で全身を優しく包み込んでくる
			PRINTFORMW 「添い寝してあげるから今日はもうこのまま眠るといい。…これからは遠慮せず、私に甘えてくれていいからな…」
			ABL:対象:主導度Ｎ += 150
			CFLAG:対象:好感度 += 100
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が100上がった", 0x00FFFF)
			CALL PRINT_ADD_EXP(MASTER, "政治経験値", RAND(5, 10), 1)
			CALL TRAIN_AUTO_ABLUP(MASTER)
			KDVAR:対象:藍_甘やかし = 1
			PRINTFORMW
		ELSE
			PRINTFORMW 「ふふ、任せておくれ。お前はここで少し休んでいるといい」
			PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%を膝枕で寝かしつけながら、その尻尾の毛先に無数のペンを持たせ、凄まじい速さで書類を処理している
			PRINTFORML 「私の体は仮にも九尾だ。これくらい何てことはない。一先ず、期日が近い分から先にやっつけておいたからな」
			PRINTFORMW 結局%ANAME(対象)%は大量にあった書類の束をあっという間に片付けてしまった。これでしばらくは大丈夫だろう
			PRINTFORML 「どうだ？　私に掛かればこんな物だ。これくらい、いつでも頼ってくれていいからな」
			PRINTFORML %ANAME(対象)%は上機嫌で%ANAME(MASTER)%の頭を撫でている。素直に頼ってもらえたのがよほど嬉しかったようだ
			PRINTFORMW 「さて、作業は終わったが、…まだ顔色が悪いように見えるな。何か胃に優しい飲み物を持ってくるよ」
			PRINTFORML 仕事が終わって一息ついた後、%ANAME(対象)%は%ANAME(MASTER)%を抱きしめ、尻尾で全身を優しく包み込んでくる
			PRINTFORML 「私が添い寝してあげるから今日はもうこのまま眠ろうか。…これからも遠慮せず、いつでも私に甘えてくれていいからな…」
			PRINTFORMW ……翌日、%ANAME(対象)%に癒された効果か、特に体調不良もなくスッキリ目覚めることが出来た
			ABL:対象:主導度Ｎ += 100
			CFLAG:対象:好感度 += 150
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が150上がった", 0x00FFFF)
			KDVAR:対象:藍_甘やかし = 1
			;クールタイムがあったら-1
			SIF COOLTIME:MASTER:0 < 0
				CALL ADD_COOLTIME(MASTER, -1)
			PRINTFORMW
		ENDIF
	CASE 1
		PRINTFORML 深夜。%ANAME(MASTER)%の部屋にはまだ明かりが灯っている
		PRINTFORML %ANAME(MASTER)%はまたもや多くの書類仕事に追われていた…
		PRINTFORMW 「大丈夫か？　%ANAME(MASTER)%。よかったらまた手伝おうか？」
		PRINTFORML 深夜まで終わらない仕事を心配してくれたのか、また%ANAME(対象)%が様子を見に来てくれたようだ
		PRINTFORMW さて、どうしよう？
		PRINTFORML
		CALL ASK_YN("それじゃあ、お言葉に甘えて", "いや、もう大丈夫")
		IF RESULT == 1
			PRINTFORML 「……どうやら、やせ我慢で言ってるわけではないようだな。顔色も悪くない」
			PRINTFORML そう何度も手を借りるようでは示しがつかないというものだ。%ANAME(MASTER)%は%ANAME(対象)%に「今回は大丈夫」と伝えた
			PRINTFORMW （まあ確かに…私が出しゃばりすぎたら%ANAME(MASTER)%の立つ瀬がないものな…。ちょっと寂しいけど仕方ない）
			PRINTFORML 「分かったよ。でも夜食くらいは用意させておくれ。それくらいはいいだろう？」
			PRINTFORMW ちょうど小腹が空いてきたところだ。%ANAME(MASTER)%は%ANAME(対象)%が作ってくれた夜食を食べて仕事に取り掛かった
			PRINTDATAW
			DATA ちなみにメニューはきつねうどんだった
			DATA ちなみにメニューは稲荷寿司だった
			DATA ちなみにメニューは油揚げの味噌汁だった
			DATA ちなみにメニューは油揚げのサラダだった
			DATA ちなみにメニューは焼き油揚げだった
			DATA ちなみにメニューは信玄袋だった
			ENDDATA
			PRINTFORML
			PRINTFORML
			PRINTFORMW …何とか夜が明ける前に終えることが出来た。%ANAME(MASTER)%は心地よい達成感のようなものに包まれながら眠りについた…
			CFLAG:対象:好感度 += 100
			CALL PRINT_ADD_EXP(MASTER, "政治経験値", RAND(10, 25), 1)
			CALL TRAIN_AUTO_ABLUP(MASTER)
			KDVAR:対象:藍_甘やかし = -1
			PRINTFORMW
		ELSE
			PRINTFORMW 申し出に甘えると、%ANAME(対象)%はにっこりと笑いながら%ANAME(MASTER)%の頭を優しく撫でる
			PRINTFORML 「ふふ。嬉しいぞ、素直に頼ってくれて。よし、すぐに片付けてやるからな」
			PRINTFORMW %ANAME(対象)%はそう言うと、%ANAME(MASTER)%の目の前で多くの式神を作り出した
			PRINTFORML 「こいつらは複雑な動作こそ出来ないが、コレくらいの雑務なら問題なく処理できるぞ」
			PRINTFORMW 手のひらサイズの式神たちは各々ペンをとって仕事に取り掛かる
			PRINTFORML 念のため、出来上がった書類を確認しても特に問題はなかった。便利な能力だ……
			PRINTFORMW 「さて、後のことは式に任せて大丈夫…あとは、そうだな…」
			PRINTFORML 「%ANAME(MASTER)%、夜遅くまで仕事で疲れているだろう。私がマッサージしてあげよう」
			PRINTFORMW そう言いながら%ANAME(対象)%は%ANAME(MASTER)%の肩を揉み始める
			PRINTFORML 力加減は弱くもなく、痛くもなくの絶妙な按配での揉み解しに、思わず声が漏れる
			PRINTFORMW 「ふふ…気に入ってくれたか？　ほら、布団に横になって…。背中も腰もやってあげるからな」
			PRINTFORML %ANAME(対象)%はしなやかで巧みな指使いで的確に筋肉のコリをほぐし、%ANAME(MASTER)%を夢心地にさせる
			PRINTFORMW 「中々なものだろう？　ふふ、紫様にもたまに行うけど…、けっこう評判なんだぞ」
			PRINTFORML 愛情が込められた按摩と彼女の甘い香り、そして耳元で囁かれる優しい声色が%ANAME(MASTER)%を眠りに誘う…
			PRINTFORMW 「いつでも寝ちゃってもいいからな…後は私に任せておけ…。これからも、遠慮なんていらないからな……♥」
			PRINTFORML ・
			PRINTFORML ・・
			PRINTFORMW …すっかり熟睡してしまっていた…。翌朝、机に上にはちゃんと出来上がった書類が残されていた
			ABL:対象:主導度Ｎ += 150
			CFLAG:対象:好感度 += 150
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が150上がった", 0x00FFFF)
			;クールタイムがあったら-1
			SIF COOLTIME:MASTER:0 < 0
				CALL ADD_COOLTIME(MASTER, -1)
			KDVAR:対象:藍_甘やかし ++
			PRINTFORMW
		ENDIF
	CASE 2
```
