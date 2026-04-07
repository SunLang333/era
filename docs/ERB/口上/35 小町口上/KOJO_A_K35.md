# 口上/35 小町口上/KOJO_A_K35.ERB — 自动生成文档

源文件: `ERB/口上/35 小町口上/KOJO_A_K35.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K35, KOJO_TRAIN_END_A1_K35, KOJO_TRAIN_START_A2_K35, KOJO_TRAIN_END_A2_K35, KOJO_COM_BEFORE_TARGET_A_K35, KOJO_COM_BEFORE_PLAYER_A_K35, KOJO_COM_A_K35, KOJO_COM_TARGET_A_K35, KOJO_COM_PLAYER_A_K35, KOJO_COM_AFTER_A_K35, SEX_VOICEK35_00, SEX_VOICEK35_01, SEX_VOICEK35_02, SEX_VOICEK35_03, SEX_VOICEK35_04, SEX_VOICEK35_05, SEX_VOICEK35_06, SEX_VOICEK35_07; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K35
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF
PRINTL

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
			PRINTFORML 「……おや、、お前さんが噂の%ANAME(MASTER)%かい」
			PRINTFORMW 捕虜用の部屋に居る豊満な体つきをした赤髪の女に、%ANAME(MASTER)%が声をかける
			SETCOLOR カラー_パ赤
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　江戸っ子気質な死神　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　三途の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　川霧の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　拓落失路の死神　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女こそ%ANAME(MASTER)%が会いにきた死神、%NAME_FORMAL(TARGET)%だ
			PRINTFORML 死神の力を借りれればどれだけ心強いだろう。%ANAME(MASTER)%は彼女に『我が軍に力を貸して欲しい』と協力を仰いだ
			PRINTFORMW 「ふむふむ、この乱世を鎮めるために、ねぇ」
			PRINTFORML 「名目は立派だけどそう簡単には手を貸せないよ。信用できるほどお前さんのこと知らないしね」
			PRINTFORMW 「…とはいえ、問答無用で牢屋に入れないだけ紳士的だし…、もうちょい%ANAME(MASTER)%のことを見極めさせてもらうよ」
		;それ以外
		ELSE
			PRINTFORML 「ほほう、お前さんが噂の%ANAME(MASTER)%かい」
			PRINTFORMW 歪な刃の鎌を携えた豊満な体つきの女が、%ANAME(MASTER)%に声をかける
			SETCOLOR カラー_パ赤
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　江戸っ子気質な死神　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　三途の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　川霧の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　拓落失路の死神　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女こそ%ANAME(MASTER)%が会いにきた死神、%NAME_FORMAL(TARGET)%だ
			PRINTFORMW 本来は三途の河の船頭だが、暇を見ては幻想郷にやってくるという
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORML そんな彼女に力を借すべく、%ANAME(MASTER)%は彼女の元に挨拶に伺ったのだった
				PRINTFORMW 「ふむふむ、この乱世を鎮めるために、あたいに協力してくれる、と」
				PRINTFORML 「丁度あたいももっと上の方から言われててね。『妙なことになってる幻想郷を調査、必要とあらば事態を収めよ』ってさ」
				PRINTFORMW 「つまり、お前さんの目的はあたいの目的と繋がってるってわけだ。そういうことで、これからよろしく」
				PRINTFORML %ANAME(MASTER)%は無事挨拶を終え、%ANAME(TARGET)%と握手を交わした
			;それ以外
			ELSE
				PRINTFORML そんな彼女の力を借りるべく、%ANAME(MASTER)%は彼女に協力を仰ぎに来たのだった
				PRINTFORMW 「ふむふむ、この乱世を鎮めるために、ねぇ」
				PRINTFORML 「丁度あたいも上から言われててね。『妙なことになってる幻想郷を調査、必要とあらば事態を収めよ』ってさ」
				PRINTFORMW 「つまり、お前さんとあたいの利害は一致してるわけだ。そういうことで、これからよろしく」
				PRINTFORML %ANAME(MASTER)%は無事協力を取り付け、%ANAME(TARGET)%と握手を交わした
			ENDIF
			PRINTFORMW 「……しかしまあ、自分から死神に会いに来るって、噂通りの変わり者だねお前さんは。普通は不吉がられるもんなのにさ」
			PRINTFORML ……言われてみればたしかに。でもこんなベッピンさんな死神なら、会いに行くのも悪くないかも
			PRINTFORMW 「あはは、お世辞はちゃんと言えるようだねぇ。なんにせよ、よろしく頼むよ%ANAME(MASTER)%」
		ENDIF

	;すでに隷属状態の場合
	ELSEIF TALENT:隷属
		PRINTFORML 「あは♥　%ANAME(MASTER)%様。私に何か用ですかい？」
		PRINTFORMW 歪な刃の鎌を携えた豊満な体つきの女が、媚びるような表情で%ANAME(MASTER)%に呼びかける
		SETCOLOR カラー_パ赤
		PRINTFORML 
		PRINTDATAL
			DATAFORM ―――――　江戸っ子気質な死神　『%NAME_FORMAL(TARGET)%』　―――――
			DATAFORM ―――――　三途の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
			DATAFORM ―――――　川霧の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
			DATAFORM ―――――　拓落失路の死神　『%NAME_FORMAL(TARGET)%』　―――――
		ENDDATA
		PRINTFORMW 
		RESETCOLOR
		PRINTFORML 彼女は%NAME_FORMAL(TARGET)%。死神だ
		PRINTFORMW 本来は三途の河の船頭だが、暇を見ては幻想郷に（サボるために）やってくるという
		PRINTFORML そんな彼女の力を借りるべく『色々』した結果、快く%ANAME(MASTER)%に付き従ってくれることになった
		IF HAS_PENIS(MASTER)
			PRINTFORMW 「んんっ♥　じゅぷっ…れろ…♥　%ANAME(MASTER)%様ぁ、キモチいいですか？　あむ…」
			PRINTFORML %ANAME(TARGET)%は挨拶が終わるとすぐに%ANAME(MASTER)%の前に跪き、一物を取り出して熱心にしゃぶり始める
			PRINTFORMW こちらが何も言わずとも彼女自ら奉仕を始めるほど、%ANAME(TARGET)%は%ANAME(MASTER)%に心酔しているようだ
			PRINTFORML その様に満足した%ANAME(MASTER)%は彼女の頭を掴み、彼女の喉奥まで一物を突き込んで射精した
			PRINTFORMW 「んぶぅっ！　…ぢゅうぅ…ぷはっ♥　%ANAME(MASTER)%様の子種…ありがとうございます♥」
			PRINTFORML 嫌がるどころか喜んで%ANAME(MASTER)%の精を飲み込む彼女の仕上がり具合に満足しつつ
			PRINTFORMW これからより一層の協力をしてもらうため、%ANAME(MASTER)%は%ANAME(TARGET)%との交流を開始した……
		ELSE
			PRINTFORMW 「んん…っ♥　ちゅぅっ…えろぉ…♥　、キモチいいですか？」
			PRINTFORML %ANAME(TARGET)%は挨拶が終わるとすぐに%ANAME(MASTER)%の前に跪き、主人の秘裂を熱心に舐め始める
			PRINTFORMW こちらが何も言わずとも彼女自ら奉仕を始めるほど、%ANAME(TARGET)%は%ANAME(MASTER)%に心酔しているようだ
			PRINTFORML その様に満足した%ANAME(MASTER)%は彼女の頭を掴み、彼女の口内に褒美の聖水を流し込んだ
			PRINTFORMW 「んぶぅっ！　んんっ…こく…こく……ぷはっ♥　%ANAME(MASTER)%様の…ありがとうございます♥」
			PRINTFORML 嫌がるどころか喜んで%ANAME(MASTER)%の聖水を飲み込む彼女の仕上がり具合に満足しつつ
			PRINTFORMW これからより一層の協力をしてもらうため、%ANAME(MASTER)%は%ANAME(TARGET)%との交流を開始した……
		ENDIF

	;既に会ったことがある場合
	ELSE
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「……よう、%ANAME(MASTER)%。あたいに何か用かい？」
			PRINTFORMW 捕虜用の部屋に居る豊満な体つきをした赤髪の女に、%ANAME(MASTER)%が声をかける
			SETCOLOR カラー_パ赤
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　江戸っ子気質な死神　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　三途の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　川霧の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　拓落失路の死神　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は%NAME_FORMAL(TARGET)%、死神だ。
			PRINTFORMW 本来は三途の河の船頭だが、暇を見ては幻想郷に（サボるために）やってくるという
			PRINTFORML 死神たる彼女の力を借りるべく、%ANAME(MASTER)%は彼女に会いに来たのだった
			PRINTFORMW 「ふむ、この乱世を鎮めるために手を貸して欲しい、と……」
			PRINTFORML 「確かに知った仲ではあるけど、そう簡単に手は貸せないよ。あたいにも事情があるんでね」
			PRINTFORMW 「…とはいえ、牢屋に入れないだけ紳士的だし…、もうちょい%ANAME(MASTER)%のことを見極めさせてもらうよ」
		;それ以外
		ELSE
			PRINTFORML 「やあ、%ANAME(MASTER)%。あたいに何か用かい？」
			PRINTFORMW 歪な刃の鎌を携えた豊満な体つきの女が、%ANAME(MASTER)%に声をかける
			SETCOLOR カラー_パ赤
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　江戸っ子気質な死神　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　三途の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　川霧の水先案内人　『%NAME_FORMAL(TARGET)%』　―――――
				DATAFORM ―――――　拓落失路の死神　『%NAME_FORMAL(TARGET)%』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は%NAME_FORMAL(TARGET)%。死神だ
			PRINTFORMW 本来は三途の河の船頭だが、暇を見ては幻想郷に（サボるために）やってくるという
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORML そんな彼女に力を借すべく、%ANAME(MASTER)%は彼女の元に馳せ参じたのだった
				PRINTFORMW 「ふむふむ、この乱世を鎮めるために、あたいに協力してくれる、と」
				PRINTFORML 「丁度あたいももっと上の方から言われててね。『妙なことになってる幻想郷を調査、必要とあらば事態を収めよ』ってさ」
				PRINTFORMW 「そういうことで人手が欲しいところだったんだよ。それじゃあ、これからよろしくな、%ANAME(MASTER)%」
				PRINTFORML %ANAME(MASTER)%は無事挨拶を終え、%ANAME(TARGET)%と握手を交わした
			;それ以外
			ELSE
				PRINTFORML 死神たる彼女の力を借りるべく、%ANAME(MASTER)%は彼女に会いに来たのだった
				PRINTFORMW 「ふむふむ、この乱世を鎮めるために、ねぇ」
				PRINTFORML 「丁度あたいも上から言われてるところさね。『妙なことになってる幻想郷を調査、必要とあらば事態を収めよ』ってさ」
				PRINTFORMW 「つまり、お前さんとあたいの利害は一致してるわけだ。そういうことで、これからよろしくね、%ANAME(MASTER)%」
				PRINTFORML %ANAME(MASTER)%は無事協力を取り付け、%ANAME(TARGET)%と握手を交わした
			ENDIF
			PRINTFORMW 「……しかしまあ、自分から死神に会いに来るって、やっぱり変わり者だねお前さんは。普通は不吉がられるもんなのにさ」
			PRINTFORML ……言われてみればたしかに。でもこんなベッピンさんな死神なら、会いに行くのも悪くないってものだ
			PRINTFORMW 「あはは、お世辞はちゃんと言えるようだねぇ。なんにせよ、よろしく頼むよ%ANAME(MASTER)%」
		ENDIF
	ENDIF
	PRINTFORML

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻
ELSEIF CFLAG:200 < 7 && TALENT:正妻
	;正妻になった次の回フラグ
	CFLAG:200 = 7
	PRINTFORML
	;恋慕ルートの台詞
	IF TALENT:親愛
		PRINTFORML 「……あたいが所帯を持つようになるなんてね。ちょっと前まで思いもしなかったよ」
		PRINTFORMW 共に目覚めた朝。%ANAME(TARGET)%は布団の上で寝転びながら頬杖をついて、隣の%ANAME(MASTER)%を見つめる
		PRINTFORML 「…まあ、%ANAME(MASTER)%とならいい夫婦になれるかもって、今は思ってるよ…♥」
		PRINTFORML 愛する人とのこれからを想い、%ANAME(TARGET)%は幸せそうに笑う。そんな彼女を、%ANAME(MASTER)%は優しく抱きしめる
		PRINTFORMW 「えへへ…頼むよ%ANAME(MASTER)%？　アンタの女房になったのは間違いじゃ無かったって、あたいに教えておくれよ♥」

	;服従ルートの台詞
	ELSEIF TALENT:隷属
		PRINTFORML 「…奴隷も同然の私が、%ANAME(MASTER)%様と結ばれて朝を迎えるなんて…何だか不思議な感じです」
		PRINTFORMW 共に目覚めた朝。%ANAME(TARGET)%は布団からちょこんと顔を出して、隣の%ANAME(MASTER)%を見つめる
		PRINTFORML 「…仮初にも夫婦になった以上は…もう少し%ANAME(MASTER)%様に甘えてもいいんでしょうか……」
		PRINTFORML 不安そうに問いかける%ANAME(TARGET)%に%ANAME(MASTER)%は優しく笑いかける。何とも思わぬ女とは、例え形だけでもこんな関係にはならない
		PRINTFORMW 「…えへへ♥　ありがとうございます、旦那様。貴方に仕えることができて、私は幸せです…♥」
	ENDIF
	PRINTFORML

;親愛か隷属
ELSEIF (CFLAG:200 < 6) && (TALENT:親愛 || TALENT:隷属)
```
