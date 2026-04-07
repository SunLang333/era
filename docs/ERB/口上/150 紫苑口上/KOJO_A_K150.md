# 口上/150 紫苑口上/KOJO_A_K150.ERB — 自动生成文档

源文件: `ERB/口上/150 紫苑口上/KOJO_A_K150.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K150, KOJO_TRAIN_END_A1_K150, KOJO_TRAIN_START_A2_K150, KOJO_TRAIN_END_A2_K150, KOJO_COM_BEFORE_TARGET_A_K150, KOJO_COM_BEFORE_PLAYER_A_K150, KOJO_COM_A_K150, KOJO_COM_TARGET_A_K150, KOJO_COM_PLAYER_A_K150, KOJO_COM_AFTER_A_K150, SEX_VOICE150_00, SEX_VOICE150_01, SEX_VOICE150_02, SEX_VOICE150_03; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K150
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		PRINTFORMW 「初めまして。何か恵んでください。」
		PRINTFORMW 宮殿を歩いていると突然話しかけられ、欠けた茶碗を差し出された
		PRINTFORMW 「あぁ、自己紹介がまだだったわね。私は貧乏神の紫苑。」
		PRINTFORMW 困惑しているあなたに対し、青髪の彼女はそう告げた
		PRINTFORMW 貧乏神…よく見ると全身に【差し押さえ】の札が張られている
		PRINTFORMW 「…そんなに露骨に引かれると、傷つくわー。」
		PRINTFORMW しかし言葉とは裏腹に彼女はグイグイ迫ってきた
		PRINTFORMW 「これからは仲間なんだから、仲良くしましょ？そして私をリッチにしてね。」
		PRINTFORMW 貧乏神と仲良くしたくない、喉まで出かかった言葉をグッと飲み込んだ
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「あら、あなたは…。」
		PRINTFORMW 宮殿を歩いていると声をかけられ振り返る
		PRINTFORMW そこには長く青い髪の女性がふわふわと浮いていた
		PRINTFORMW 「なによー、そんなに露骨に嫌な顔しなくてもいいじゃない。」
		PRINTFORMW 目の前の貧乏神は不満そうに近づいてきた
		PRINTFORMW 「これからは仲間なんだから、仲良くしましょ？」
		PRINTFORMW 彼女はこちらに構わずグイグイ迫って来る
		PRINTFORMW 「それじゃあ再会を祝して、何か恵んで？」
		PRINTFORMW 彼女はそう言い欠けた茶碗を差し出してきた
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意 && (TALENT:恋慕 || TALENT:服従)
	CFLAG:200 = 5
	PRINTFORMW 「いらっしゃい、%ANAME(MASTER)%。」
	PRINTFORMW 紫苑の家を訪ねると彼女が腕に抱きついてきた
	PRINTFORMW 「いいじゃない、これぐらい。人肌寂しいのー。」
	PRINTFORMW 彼女はふふっと笑うとあなたを家の中へと引っ張る
	PRINTFORMW 「ここまで来ちゃったんだから、もう後悔しても遅いのよ？」
	PRINTFORMW 後悔なんてしてないさ、そう答えると彼女は嬉しそうに笑った
	PRINTFORMW 「本当にもの好きな人。でもそんなあなたが大好きよー。」
	PRINTFORMW 「ねぇ…それで…今日も、する？」
	PRINTFORMW 彼女はそう呟くと、微かに頬を染めながら身体ごと擦り寄って来た
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人  && (TALENT:恋慕 || TALENT:服従)
	CFLAG:200 = 4
	PRINTFORMW 「待ってたわ、%ANAME(MASTER)%。」
	PRINTFORMW 家を出ると紫苑がいた
	PRINTFORMW 驚くあなたに対して彼女は悪戯っぽく笑った
	PRINTFORMW 「うふふ、折角恋人になったんだし、待ち合わせしてみたわ。」
	PRINTFORMW これは待ち合わせではなく待ち伏せではないだろうか
	PRINTFORMW 「そこはほら、貧乏神らしく？押しかけてみたの。」
	PRINTFORMW 楽しそうに話す彼女にやれやれと思いつつも、家の中に招いた
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1 && (TALENT:恋慕 || TALENT:服従)
	CFLAG:200 = 3
	PRINTFORMW 「こんにちは、待ってたわ。」
	PRINTFORMW 紫苑はあなたを見るとふわふわと近寄って来た
	PRINTFORMW 「今日は何を恵んでくれるの？それとも楽しくおしゃべりでもする？」
	PRINTFORMW 「それとも…？」
	PRINTFORMW それだけ告げると彼女は何かを期待する様な視線を向けてきた
;既成事実Lv0で服従
ELSEIF CFLAG:200 < 2 && TALENT:服従 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「いらっしゃい、%ANAME(MASTER)%。」
	PRINTFORMW 紫苑に会いに行くといつも通り笑顔で出迎えられた
	PRINTFORMW …いや、いつもよりも心なしか距離が近く感じられた
	PRINTFORMW 「え、いつもと違う？」
	PRINTFORMW 「…そうかな。わからないわ。」
	PRINTFORMW 紫苑はあなたの問いかけに何やら考え込むように膝を抱える
	PRINTFORMW 「でも…あなたが来てくれて嬉しいわ。とても…。」
	PRINTFORMW 「乱暴でも何でも、私に構ってくれる人なんて、いなかったもの。」
	PRINTFORMW 彼女はいつもと違いたどたどしく、言葉を紡ぐ
	PRINTFORMW 「貧乏神に懐かれて、迷惑かしら？」
	PRINTFORMW それなら会いになんて来ない
	PRINTFORMW 「そう？ほんとに？」
	PRINTFORMW 「ありがとう、これからも構ってね？」
	PRINTFORMW あなたの返事に紫苑は安心した様にニコッと笑った
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「いらっしゃい、%ANAME(MASTER)%。」
	PRINTFORMW 紫苑に会いに行くといつも通り笑顔で出迎えられた
	PRINTFORMW …いや、いつもよりも心なしか距離が近く感じた
	PRINTFORMW 「え、いつもと違う？」
	PRINTFORMW 「…そうかな。わからないわ。」
	PRINTFORMW 紫苑はあなたの問いかけに何やら考え込むように膝を抱える
	PRINTFORMW 「でも…あなたが来てくれて嬉しいわ。とても…。」
	PRINTFORMW 「こんな風に私に構ってくれる人なんて、今までいなかったから。」
	PRINTFORMW 彼女はいつもと違いたどたどしく、言葉を紡ぐ
	PRINTFORMW 「貧乏神に懐かれて、迷惑かしら？」
	PRINTFORMW それなら会いになんて来ない
	PRINTFORMW 「そう？ほんとに？」
	PRINTFORMW 「ありがとう、これからもよろしくね？」
	PRINTFORMW あなたの返事に紫苑は安心した様にニコッと笑った

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕か服従
;ELSEIF TALENT:合意 && (TALENT:恋慕 || TALENT:服従)
	SELECTCASE RAND:10
		CASE 0
			PRINTFORMW 「いらっしゃい、会いたかったわ。あなたも？そっかー。」
		CASE 1
			PRINTFORMW 「待ってたわ。今日は何しようか楽しみにしてたの。」
		CASE 2
			PRINTFORMW 「寂しかったの。手、繋いで良い？えへへ、ありがとう。」
		CASE 3
			PRINTFORMW 「さぁデートしましょ。…それとも、エッチ、する？」
		CASE 4
			PRINTFORMW 「人肌恋しいよー、抱きしめて良い？ぎゅぅぅー。」
		CASE 5
			PRINTFORMW 「あんまり寂しくてキングビンボーになっちゃうところだったわ。」
		CASE 6
			PRINTFORMW 「女苑は出かけてるから、二人きりよ。うふふ、何する？」
		CASE 7
			PRINTFORMW 「こんにちは、%ANAME(MASTER)%。今日はどんな楽しい事を恵んでくれるの？」
		CASE 8
			PRINTFORMW 「私にこんなに会いに来てくれるなんて%ANAME(MASTER)%だけだわ。大好きよ。」
		CASE 9
			PRINTFORMW 「あなたがいないと身体も心もひもじいの。ちゃんと責任取ってね？」
	ENDSELECT
;既成事実Lv2かつ恋慕か服従
ELSEIF TALENT:恋人 || TALENT:合意 && (TALENT:恋慕 || TALENT:服従)
	SELECTCASE RAND:6
		CASE 0
			PRINTFORMW 「いらっしゃい。会いに来てくれて嬉しいわ。」
		CASE 1
			PRINTFORMW 「最近一人だとすごく寂しいの、もっと会いに来て？」
		CASE 2
			PRINTFORMW 「ひもじいよー。お金も愛ももっと恵んでね？」
		CASE 3
			PRINTFORMW 「貧乏神に憑りつかれて迷惑じゃない？…そう？ありがと。」
		CASE 4
			PRINTFORMW 「今日も楽しいお話しましょ。それとも、別のことする？」
		CASE 5
			PRINTFORMW 「相変わらず貧乏だけど以前よりも楽しいわ、あなたのおかげね。」
	ENDSELECT
;既成事実Lv0で恋慕か服従
ELSEIF (TALENT:恋慕 || TALENT:服従) && CFLAG:250 < 1
	SELECTCASE RAND:6
		CASE 0
			PRINTFORMW 「待ってたよ。今日はどんなお話聞かせてくれるの？」
		CASE 1
			PRINTFORMW 「いらっしゃい、楽しみにしてたわ。」
		CASE 2
			PRINTFORMW 「やっと来てくれたね、寂しかったよー。」
		CASE 3
			PRINTFORMW 「こんなに近づいたら不運が移っちゃうわよ？」
		CASE 4
			PRINTFORMW 「皆にエンガチョされてない？大丈夫？」
		CASE 5
			PRINTFORMW 「良い日和ね、今日は何処かに連れて行ってくれる？」
	ENDSELECT
;既成事実Lv0で好感度マイナス
ELSEIF CFLAG:2 < 0 && CFLAG:250 < 1
	PRINTFORMW 「………。」
	PRINTFORMW 刺すような視線と負のオーラを感じた。
;既成事実Lv0で好感度300以下
ELSEIF CFLAG:2 < 300 && CFLAG:250 < 1
	SELECTCASE RAND:5
		CASE 0
			PRINTFORMW 「あら、こんにちは。」
		CASE 1
			PRINTFORMW 「なにか恵んでー？」
		CASE 2
			PRINTFORMW 「また来たの？暇人ね。」
		CASE 3
			PRINTFORMW 「お話したらお金くれる？」
		CASE 4
			PRINTFORMW 「お腹が空いたわー。」
	ENDSELECT
;既成事実Lv0で好感度1000以下
ELSEIF CFLAG:2 < 1000 && CFLAG:250 < 1
	SELECTCASE RAND:5
		CASE 0
			PRINTFORMW 「あなたももの好きね。」
		CASE 1
			PRINTFORMW 「女苑に置いて行かれたの。」
		CASE 2
			PRINTFORMW 「どうせなら楽しい話を聞かせて。」
		CASE 3
			PRINTFORMW 「いらっしゃい。ここ座る？」
		CASE 4
			PRINTFORMW 「あんまり会わない方がいいと思うけど。」
```
