# 口上/11 フランドール口上/KOJO_A_K11.ERB — 自动生成文档

源文件: `ERB/口上/11 フランドール口上/KOJO_A_K11.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K11, KOJO_TRAIN_END_A1_K11, KOJO_TRAIN_START_A2_K11, KOJO_TRAIN_END_A2_K11, KOJO_COM_BEFORE_TARGET_A_K11, KOJO_COM_BEFORE_PLAYER_A_K11, KOJO_COM_A_K11, KOJO_COM_TARGET_A_K11, KOJO_COM_PLAYER_A_K11, KOJO_COM_AFTER_A_K11; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K11
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
		;レミリアと同じ勢力に所属している
		IF CFLAG:MASTER:所属 == CFLAG:NAME_TO_CHARA("レミリア"):所属
			PRINTFORMW 「待ちなさい」
			PRINTFORMW %ANAME(MASTER)%が拠点内を歩いていると、突然後ろから呼び止められる
			PRINTFORMW 振り向けばそこには、共に戦う同胞であるレミリアの姿があった
			PRINTFORMW 「あいつに──『悪魔の妹』に会いに行くんでしょう」
			PRINTFORMW 「悪いことは言わない。やめなさい」
			PRINTFORML はて、何故知っているのだろうか
			PRINTFORMW 今日の予定──%ANAME(TARGET)%に会うことを誰かに知らせた記憶は無いのだが
			PRINTFORMW 「……視えたのよ、そういう運命が」
			PRINTFORMW 「ともかく、後悔したくないなら踵を返すことね」
			PRINTFORML そうは言うが、今は%ANAME(TARGET)%も同じ勢力に属する仲間だ
			PRINTFORMW 親睦を深めに行くのは悪い結果にならないと思うのだが
			PRINTFORMW 「……%ANAME(MASTER)%、幻想郷縁起を読んでないのかしら」
			PRINTFORMW 「まあいいわ。行きたいというなら行けばいい」
			PRINTFORMW 「忠告はした。後はどうなろうが%ANAME(MASTER)%の責任よ」
			PRINTFORMW そう言い残して、レミリアは何処かへと飛び去るのであった
			IF TALENT:NAME_TO_CHARA("レミリア"):恋慕
				PRINTFORML 　
				PRINTFORML （……大馬鹿者）
				PRINTFORMW （%ANAME(MASTER)%をむざむざ失いたくはないのよ）
			ELSE
				PRINTFORML 　
				PRINTFORML （全く、物好きね）
				PRINTFORMW （好奇心は猫をも殺すわよ。無論、人もね）
			ENDIF
		ELSE
		ENDIF
		PRINTFORML 　
		PRINTFORML 　
		PRINTFORML 「……誰？」
		PRINTFORML %ANAME(TARGET)%の部屋の戸を叩くと、中から気怠げな返事がした
		PRINTFORMW 戸は開けずに自らの名を名乗る
		PRINTFORML 「……ああ、%ANAME(MASTER)%ね。噂は聞いてるよ」
		SIF MASTER == NAME_TO_CHARA("あなた")
			PRINTFORML 「特別な能力を持ってるでもないのに、この戦に与した奇特な人間だって」
		PRINTFORMW 「それで？何の用？」
		PRINTFORML 「……会いに来ただけ？」
		PRINTFORMW 「この気の触れた、凶暴凶悪な吸血鬼に？」
		PRINTFORML 「……面白いね。奇っ怪で、冒険的で……腹立たしいよ」
		PRINTFORMW 「ま、その好奇心か何だか分からない気概に免じて殺すのはやめといてあげる」
		PRINTFORML 「立ち話もなんだし入りなよ」
		PRINTFORMW 「何突っ立ってるのさ。『悪魔の妹』と交流してみたいんでしょ？」
		PRINTFORMW 　
	;既に会ったことがある場合
	ELSE
		;嫌われている
		IF CFLAG:3 <= -100
			PRINTFORMW 「……用が済んだらさっさと帰れ」
			PRINTFORMW 「不愉快極まりないの。分からない？」
			PRINTFORMW 「ま、分かるようなら最初からあんな不快なことしないよね。失敬」
		;知り合い程度
		ELSEIF CFLAG:3 < 800 && CFLAG:3 > -100
			PRINTFORML 「……えーと」
			PRINTFORML 「前に何処かで会ったかな」
			PRINTFORMW 「気を悪くしたならごめん。有象無象の顔まで一々覚えてないからさ」
			PRINTFORML 「改めて。『悪魔の妹』、フランドール・スカーレット」
			PRINTFORMW 「よろしくね」
		;それなりに好かれている
		ELSE
			PRINTFORMW 「……あ、%ANAME(MASTER)%」
			PRINTFORML 「奇遇だね。こんな所で会うなんて」
			PRINTFORML 「うん、会えて嬉しいよ」
			PRINTFORML 「改めて。これからよろしくね、%ANAME(MASTER)%」
			PRINTFORMW %ANAME(TARGET)%は僅かにはにかみながら手を差し出してきた
		ENDIF
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻か妾
ELSEIF CFLAG:200 < 7 && TALENT:正妻 || CFLAG:200 < 7 && TALENT:妾
	CFLAG:200 = 7;婚姻した次の回フラグ
	PRINTFORMW 「来てくれたんだね、『旦那様』」
	PRINTFORMW 「……うーん。あんまりしっくりこないかな」
	PRINTFORMW 「ずっと%ANAME(MASTER)%って呼んでたから、もう癖になっちゃってるね」
		;正妻か妾かで分岐
	IF TALENT:正妻
		PRINTFORML 「それとさ」
		PRINTFORML 「私を選んでくれて。悪魔を愛してくれて、本当にありがとう」
		PRINTFORML 「一生、%ANAME(MASTER)%を隣で支え続けるから」
		PRINTFORMW 「だから、%ANAME(MASTER)%も離さないでね」
	ELSE
		PRINTFORML 「嬉しかったよ。私を選んでくれたこと」
		PRINTFORML 「例え一番じゃないとしても、選ばれたことに私は意義を感じた」
		PRINTFORML 「愛してくれてるんだなって思えたんだ」
	ENDIF
;親愛か隷属
ELSEIF CFLAG:200 < 6 && TALENT:親愛 || CFLAG:200 < 6 && TALENT:隷属
	CFLAG:200 = 6;親愛か隷属になった次の回フラグ
	;PRINTFORMW 
;既成事実Lv3(初めてセックスをした次の回)＆恋慕持ち
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	IF TALENT:恋慕
		PRINTFORMW 「……ごめん。ちょっと、顔を合わせられない」
		PRINTFORMW 「あんなに身体を弄くられて、乱れて」
		PRINTFORMW 「自分の知らない淫靡な面をしこたま引き出されたって思うとさ」
		PRINTFORMW 「思い出すだけで恥ずかしくて。でも、少し腹が疼くんだ」 
	ELSE
		PRINTFORMW 「どうも」
		PRINTFORMW 「悪魔の身体はお気に召してくれたかな」
		PRINTFORMW 「その気なら、また交わったっていいんだよ」
		PRINTFORMW 「加減ができなくなっても知らないけど、ね」
	ENDIF
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTFORMW 「あ、来てくれた」
	PRINTFORMW 「正直、恋人になったって言ってもさ。やることは変わらないよね」
	PRINTFORMW 「%ANAME(MASTER)%と私が側にいる、そして月日と経験を積み重ねる」
	PRINTFORMW 「それでも私は、この恋人ってレッテルが愛おしくてたまらないんだ」
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && !TALENT:キス未経験 && CFLAG:250 > 1
	CFLAG:200 = 3
	PRINTFORMW 「改めて考えると、%ANAME(MASTER)%も恐れ知らずだよね」
	PRINTFORMW 「吸血鬼に口を、牙を近づけさせたんだよ。血を吸われるなんて考えなかったの？」
	PRINTL [0] 考えた
	PRINTL [1] 考えなかった
	$INPUT_LOOP
	INPUT
	IF RESULT == 0
		PRINTFORMW 「……考えてなお、口づけを許してくれたんだ」
		PRINTFORMW 「どうしよ。ちょっと、嬉しいな」
	ELSEIF RESULT== 1
		PRINTFORMW 「まあ、そうだよね」
		PRINTFORMW 「私も一緒だよ。%ANAME(MASTER)%の血を吸うなんて考え、微塵もなかった」
	ELSE
		GOTO INPUT_LOOP
	ENDIF
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:キス未経験 && TALENT:恋慕 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「……あ」
	PRINTFORMW 「ごめん。来てたんだ」
	PRINTFORMW 「ぼーっとしてた？うん、そうだね」
	PRINTFORMW 「未知の事柄について考えてた。それだけだよ」
;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;正妻か妾
ELSEIF TALENT:正妻 || TALENT:妾
	;ランダムで口上が変化する（使わない場合はすべて同じにすればよい）
	SELECTCASE RAND:3
		CASE 0
			PRINTFORML 「%ANAME(MASTER)%を吸血鬼にしないのかって？」
			PRINTFORML 「その気になればできるけどさ。少なくとも、今はする気は無い」
			PRINTFORML 「吸血鬼なんて不便なモノだよ」
			PRINTFORMW 「日光も流水もダメな一生。いくら%ANAME(MASTER)%でも、人間には耐え難いと思う」
		CASE 1
			PRINTFORML 「あ、来たんだ」
			PRINTFORMW 「羽根がぴこぴこ動いてるって？うーん、身体は誤魔化しきれないね」
		CASE 2
			PRINTFORML 「……ふふ」
			PRINTFORML 「うん、指輪はすごく気に入ってるよ」
			PRINTFORMW 「きっと、%ANAME(MASTER)%が思っている以上にね」
	ENDSELECT
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:3
		CASE 0
			PRINTFORML 「ちょうど%ANAME(MASTER)%のことを考えてたんだ」
			PRINTFORMW 「偶然以外にあり得ないけどさ。以心伝心とも言ってみたくなるよね」
		CASE 1
			PRINTFORML 「ねえ、ぎゅって抱きしめさせて」
			PRINTFORMW 「大丈夫。%ANAME(MASTER)%を壊さない力加減は心得てるつもりだよ」
		CASE 2
			PRINTFORML 「……すんすん」
			PRINTFORMW 「万人にいい匂いではないかもだけど。私にとってはいい匂いだよ」
	ENDSELECT
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW 「さ、どうしようか」 
		CASE 1
			PRINTFORML 「また来てくれたんだ」
			PRINTFORMW 「私になのか、私の身体になのかは知らないけどね。ふふ」
	ENDSELECT
```
