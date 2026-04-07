# 口上/30 輝夜口上/DAILY/_KOJO_DAILY_K30_貴族の誘い.ERB — 自动生成文档

源文件: `ERB/口上/30 輝夜口上/DAILY/_KOJO_DAILY_K30_貴族の誘い.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K30_INVITATION_FROM_KAGUYA_RATE, KOJO_DAILY_K30_INVITATION_FROM_KAGUYA_DECISION, KOJO_DAILY_K30_INVITATION_FROM_KAGUYA_GENRE, KOJO_DAILY_K30_INVITATION_FROM_KAGUYA; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K30_INVITATION_FROM_KAGUYA_RATE(対象)
#DIM 対象
RETURN 25


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K30_INVITATION_FROM_KAGUYA_DECISION(対象)
#DIM 対象
#DIM 永琳
#DIM てゐ
#DIM 鈴仙
永琳 = NAME_TO_CHARA("永琳")
鈴仙 = NAME_TO_CHARA("鈴仙")
てゐ = NAME_TO_CHARA("てゐ")

SIF !ALLSAMES(CFLAG:対象:所属, CFLAG:永琳:所属, CFLAG:てゐ:所属, CFLAG:鈴仙:所属) || !IS_COUNTRY(CFLAG:対象:所属)
	RETURN 0

SIF MASTER == NAME_TO_CHARA("妹紅")
	RETURN 0

SIF !HAS_PENIS(MASTER)
	RETURN 0

SIF ABL:MASTER:武闘 + ABL:MASTER:知略 + ABL:MASTER:政治 + ABL:MASTER:防衛 < 250
	RETURN 0

SIF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == MASTER
	RETURN 0

SIF KDVAR:対象:輝夜_貴族の誘い
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 0, 0, 0) && CHECK_KOJO_DAILY_HAPPEN(永琳, -1, 0) && CHECK_KOJO_DAILY_HAPPEN(てゐ, -1, 0) && CHECK_KOJO_DAILY_HAPPEN(鈴仙, -1, 0)
;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K30_INVITATION_FROM_KAGUYA_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_その他


;------------------------------------
;デイリーイベント本体
;創意工夫
;発生判定に失敗した場合（イベントが発生しない場合）はマイナス１を返すこと
;-----------------------------------
@KOJO_DAILY_K30_INVITATION_FROM_KAGUYA(対象)
#DIM 対象
#DIM 永琳
#DIM てゐ
#DIM 鈴仙
#DIM ボス
永琳 = NAME_TO_CHARA("永琳")
鈴仙 = NAME_TO_CHARA("鈴仙")
てゐ = NAME_TO_CHARA("てゐ")
ボス = GET_COUNTRY_BOSS(CFLAG:MASTER:所属)

CALL COLORPRINT(NAME_FORMAL(対象), カラー_注意)
PRINTFORMW の拠点にて行われる宴の、招待状が送られてきた
PRINTFORMW %ANAME(対象)%といえば、月の都に関係する人物で、永遠亭の姫である人物だ
PRINTFORML ……そんな有力者が、自分のようなただの士官を招いてどうするつもりだろう……
PRINTFORML 疑問でしかないが、有力者に顔を売っておくのも悪くはないだろう……
PRINTFORML
CALL ASK_YN("出席する", "やめておく")

IF RESULT == 1
	PRINTFORML ……えらいがたの遊びに付き合うこともあるまい
	PRINTFORMW そう考えた%ANAME(MASTER)%は、欠席にマルをつけて返事を出した……
	KDVAR:対象:輝夜_貴族の誘い = 1
	RETURN 1
ENDIF

PRINTFORMW せっかくの機会だ。行ってみるとしよう……
PRINTFORML ・
PRINTFORML ・
PRINTFORML ・
PRINTFORML 永遠亭とやらは竹林の奥深く、話に聞くよりも辺鄙なところにあった
PRINTFORMW ……そして、宴の準備など何一つされていなかった
PRINTFORMW 「はじめまして、貴方が%ANAME(MASTER)%ね。……私が誰かは、知っているでしょう？」
PRINTFORM 初めて見る相手だが、その図抜けた美しさでわかる。彼女こそ
CALL COLORPRINT(NAME_FORMAL(対象), カラー_注意)
PRINTFORMW だろう……
PRINTFORMW 「まずは来てくれてありがとう。だけどもちろん、一介の士官を宴になんて招いたりしないわ、わざわざ」
PRINTFORMW 「貴方もそれは理解してたでしょう？　……まさか、本当に宴会に混ざろうとしてたわけじゃないわよね？」
PRINTFORMW なるほど、招待状自体が方便だったということか
PRINTFORMW %PRONOUN(対象)%に害意があるかないかで、ここからどう動くかが変わるが……
PRINTFORMW 「心配しないで、今日は貴方に、とっても素敵な話を用意したの。……%ANAME(永琳)%」
PRINTFORMW 「はい」
PRINTFORMW 呼ばれ、%PRONOUN(対象)%の後ろに控えていた銀髪の女性が進み出る
PRINTFORMW 「%ANAME(MASTER)%様。貴方は優秀な武将だと、聞き及んでいます」
PRINTFORMW 「姫は聡い方です。そういった人材の必要性を理解しており、また手元におくために、手段を選ばない」
PRINTFORMW 密談の場などもうける以上、平和な話ではないと思っていたが……
PRINTFORMW つまり%ANAME(対象)%は、今の主人を裏切り、自分につけと言っているのだ
PRINTFORMW 提案のようだが、状況から考えると、選択肢は少ないように思える……
PRINTFORMW 「%ANAME(永琳)%。そういうのはなしだと言っておいたはずだけど？」
PRINTFORMW 「ごめんなさいね、別に、脅すつもりはないのよ？　これから働いてもらう人を、無下には扱わないわ」
PRINTFORMW 「今いるところより、ずっといい待遇で迎えてあげる。金、それから……そうね、色なんてどうかしら？」
PRINTFORM 「
CALL COLORPRINT(NAME_FORMAL(てゐ), カラー_注意)
PRINTFORM 、
CALL COLORPRINT(NAME_FORMAL(鈴仙), カラー_注意)
PRINTFORM 、
CALL COLORPRINT(NAME_FORMAL(永琳), カラー_注意)
PRINTFORMW 。好きなのを選んでいいわよ。あげるわ」
PRINTFORMW %ANAME(対象)%はさらりと、とんでもないことを言ってのけた
PRINTFORMW %PRONOUN(対象)%の後ろに並ぶ、三人の女性。そのうち一人を情婦にしてやろうというのだ……
IF IS_FEMALE(MASTER)
	PRINTFORMW %ANAME(対象)%はどこから嗅ぎ付けたのか、%ANAME(MASTER)%の身体についても調べが付いているようだ
ENDIF
PRINTFORMW ……それにしても、何かあると思っていたが、まさか引き抜きをかけられるとは
PRINTFORMW 驚くほどのことではない。幻想郷は混迷の時代にある。そういう手段にでる勢力がいてもおかしくはない
PRINTFORMW こちらとしても、生き延びるためには、少しでも強力な勢力についておくのが得策だ
PRINTFORMW 一方で、この話を受ければ、今の主君の方面との関係は、間違いなくこじれるだろう
PRINTFORMW さて、どうするか……
CALL SINGLE_DRAWLINE
PRINTFORML %ANAME(対象)%の領地数:{GET_OWN_CITY(CFLAG:対象:所属)} %ANAME(ボス)%の領地数:{GET_OWN_CITY(CFLAG:MASTER:所属)}
PRINTFORML 
CALL ASK_YN("話にのる", "やめておく")

IF RESULT == 1
	PRINTFORMW 「あら……そう」
	PRINTFORMW 「大した度胸ね、敵陣まっただ中で、この話を断るなんて」
	PRINTFORMW 「ま、別に害意はないんだけどね。そういうことなら諦めるわ」
	PRINTFORMW 刃傷沙汰は覚悟の上だったが、%ANAME(対象)%は案外あっさりと諦めてみせた
	PRINTFORMW 「ここで殺したら、手に入らないもの。頷かないなら、%ANAME(ボス)%をねじ伏せて奪えばいいだけ。違う？」
	PRINTFORMW 「まぁそういうわけだから、次に会うときは容赦しないわよ……くくっ」
	PRINTFORMW その後、%ANAME(MASTER)%は無事に拠点まで帰り着いた……
	KDVAR:対象:輝夜_貴族の誘い = 2
	RETURN 1
ENDIF

PRINTFORMW 「そう言ってくれると思ってたわ」
PRINTFORMW 「ふふ、よろしくお願いするわね？」
PRINTFORMW %ANAME(MASTER)%は頷き返した……
LOCAL:0 = MIN((ABL:MASTER:武闘 + ABL:MASTER:知略 + ABL:MASTER:政治 + ABL:MASTER:防衛) * 200, 50000)
MONEY += LOCAL:0
CALL CHANGE_RELATION_O_TO_O(ボス, 対象, -500, 500)
CALL CHANGE_RELATION_O_TO_O(ボス, MASTER, -500, 500)
CALL CHANGE_COUNTRY(MASTER, CFLAG:対象:所属, 1)
CALL COLOR_PRINTW(@"支度金として金{LOCAL:0}を受け取りました", カラー_注意)
CALL COLOR_PRINTW(@"%ANAME(ボス)%との外交関係が、非常にこじれました", カラー_警告)
PRINTFORMW 「……それで、約束の『色』のほうだけれど」
PRINTFORMW 「誰にするの？　どうぞご自由に」
PRINTFORML
CALL ASK_MULTI(ANAME(てゐ), ANAME(鈴仙), ANAME(永琳), ANAME(対象))
LOCAL:0 = RESULT
SELECTCASE LOCAL
	CASE 0
		LOCAL = てゐ
	CASE 1
		LOCAL = 鈴仙
	CASE 2
		LOCAL = 永琳
	CASE 3
		LOCAL = 対象
ENDSELECT

SELECTCASE LOCAL
	CASE てゐ, 鈴仙, 永琳
		PRINTFORMW 「ふぅん……%ANAME(LOCAL)%がお好み？」
		PRINTFORMW 「ま、貴方の趣味に興味はないけど。わかったわ、今日から%ANAME(LOCAL)%は貴方のものよ」
		PRINTFORMW 「煮るなり焼くなり、好きにしなさいな。貴方が女をどう扱うかに興味はないから」
		PRINTFORMW それきり退屈げな表情を浮かべた%ANAME(対象)%の代わりに、%ANAME(LOCAL)%が一歩前に進み出る……
		SELECTCASE LOCAL
			CASE てゐ
				PRINTFORMW 「まぁよろしく。それにしても私を選ぶとはねー。あんたひょっとしてロリコンってやつ？」
				PRINTFORMW 「別にいーけど。我らが姫様の命令だ、あんたのモノになってあげるよ、しばらくは」
			CASE 鈴仙
				PRINTFORMW 「私……ですか、師匠でもてゐでもなく……はぁ」
				PRINTFORMW 「えーっと、……その、精一杯努めさせていただきます。よろしくお願いします」
			CASE 永琳
				PRINTFORMW 「姫もお戯れが過ぎるわ……そうね、終わらない一生の、ほんの一瞬の些細な間違いだとでも思っておくことにするわ」
				PRINTFORMW 「生きている間は貴方のものになってあげるから、せめて退屈はさせないでちょうだいね」
		ENDSELECT
		CALL COLOR_PRINTW(@"%ANAME(LOCAL)%の合意を得ました", カラー_ピンク)
		TALENT:LOCAL:合意 = 1
		TALENT:LOCAL:チョロイン = 1
	CASE 対象
		PRINTFORMW 「……へぇ、私？」
		PRINTFORMW %ANAME(対象)%は薄っすらとした笑みを浮かべ、じっとこちらを見つめてきた
		IF IS_LOVER(対象)
			PRINTFORMW 「別にこんな機会でなくても、貴方だったら別にいいのだけど」
			PRINTFORMW 「まあ、それがお望みなら、いいわよ」
			PRINTFORMW 「でも、優しくしてね？」
			CALL COLOR_PRINTW(@"%ANAME(対象)%の合意を得ました", カラー_ピンク)
			CFLAG:対象:好感度 += 500
			TALENT:LOCAL:合意 = 1
			TALENT:LOCAL:チョロイン = 1
		ELSEIF IS_SLAVE(対象)
			PRINTFORMW 「別にこんな機会でなくても、貴方だったらいつでもいいのに」
			PRINTFORMW 「それとも、それだけ私を欲してくださってるということかしら？」
```
