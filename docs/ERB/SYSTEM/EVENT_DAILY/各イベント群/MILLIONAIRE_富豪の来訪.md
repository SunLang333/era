# SYSTEM/EVENT_DAILY/各イベント群/MILLIONAIRE_富豪の来訪.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/MILLIONAIRE_富豪の来訪.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_MILLIONAIRE_RATE, EVENT_DAILY_MILLIONAIRE_DECISION, EVENT_DAILY_MILLIONAIRE_SETTARGET, SELECT_CHARA_RANDOM_LOGIC_DAILY_MILLIONAIRE, SELECT_CHARA_RANDOM_BIAS_DAILY_MILLIONAIRE, EVENT_DAILY_MILLIONAIRE_GENRE, EVENT_DAILY_MILLIONAIRE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_MILLIONAIRE_RATE()
RETURN (DVAR:富豪_お気に入りID > 0 ? 250 # 30)

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_MILLIONAIRE_DECISION()
SIF DVAR:富豪_発生フラグ == -1
	RETURN 0
;SIF DAY < 20
;	RETURN 0

RETURN 1


;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_MILLIONAIRE_SETTARGET()


CALL SELECT_CHARA_RANDOM("DAILY_MILLIONAIRE", "DAILY_MILLIONAIRE")
SIF RESULT == -1
	RETURN 0

DAILY_TARGET:0 = RESULT
RETURN 1

@SELECT_CHARA_RANDOM_LOGIC_DAILY_MILLIONAIRE(対象)
#DIM 対象
RETURN 対象 != MASTER && IS_FEMALE(対象) && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !CFLAG:対象:捕虜先 && GET_COUNTRY_BOSS(CFLAG:対象:1) != 対象 && CFLAG:対象:行動不能状態 != 行動不能_子供

@SELECT_CHARA_RANDOM_BIAS_DAILY_MILLIONAIRE(対象)
#DIM 対象
;すでにお気に入りになっている娘がいたら確実に指名する
SIF 対象 == ID_TO_CHARA(DVAR:富豪_お気に入りID) && RAND:5
	RETURN __INT_MAX__

;でなければ好感度ベース
RETURN CFLAG:対象:好感度 + IS_LOVER(対象) * 1000

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_MILLIONAIRE_GENRE()
RETURN デイリー_ジャンル_エロ

@EVENT_DAILY_MILLIONAIRE()
#DIM 対象
#DIM 満足度
#DIM 報酬

対象 = DAILY_TARGET:0

IF DVAR:富豪_発生フラグ == 0
	PRINTFORML %ANAME(MASTER)%が政務をこなしていると、部下が来客を告げた
	PRINTFORMW 幻想郷中に名をとどろかす富豪が訪ねてきたのだという
	PRINTFORML 傲慢で有名であり、会いたくない相手だが、彼が一度の遊興で使う金はちょっとした勢力の予算ほどもある
	PRINTFORMW むげにするわけにいかない客だと判断した%ANAME(MASTER)%は、さっそく会うことにした……
	PRINTFORML 
	PRINTFORML 
	PRINTFORML 
	PRINTFORML 「やあ。君が%ANAME(MASTER)%かね？　噂と違って実物はしょぼいな」
	PRINTFORML 「まぁいい。ここに来たのは暇つぶしのためだ。でなきゃ誰がこんなド田舎に来る？」
	PRINTFORMW 「さて……、田舎の猿山の大将殿が、どうやって私を楽しませてくれるのか、見物だがね」
	PRINTFORML 部屋にいたのは、見るからに成金趣味の、"非常に恰幅の良い"男だった
	PRINTFORMW 首は贅肉に埋もれ、まるで見えない。葉巻を吸う指の全てに、大きな宝石つきの指輪が嵌まっていた
	PRINTFORML 「おっと。暇つぶしだとは言ったが、どのように楽しませるか考える必要はないぞ」
	PRINTFORML 「実際、君のような貧民が無い脳味噌を必死に絞って思いつくことなど、私には何にもならん」
	PRINTFORML 「何を思いついたのか、聞かせてみてくれるかね？　ゴミあさりか、それとも下らん井戸端会議か？」
	PRINTFORMW 「女だ。こんなド田舎でも、いるだろう、一人くらいは、私の眼鏡にかなう娘が」
	PRINTFORMW 女。それならとびきりの娼婦でも呼んでこようかと考えた%ANAME(MASTER)%だが、男は埋もれた首を横に振る
	PRINTFORML
	CALL ICPRINT(@"「<%ANAME(対象)%>とかいう、なかなかの上玉がいるそうじゃないか？　それを貸したまえ」", "W", カラー_注意)
	PRINTFORMW 「そいつの"働き"に応じて、金を払ってやろうじゃないか」
	PRINTFORML 「別に構わんだろう？　君たちだって金は必要だろうしな」
	PRINTFORMW 「所属する組織に奉じることができるのだから、%ANAME(対象)%も満足だろうさ」
	SIF IS_LOVER(対象)
		PRINTFORMW 「……そう考えたら、思い人が一人や二人いたところで、どうということもあるまい？」
	PRINTFORMW 「もちろん避妊はしよう。そのあたりは心配するな」
	PRINTFORML なんとふざけた発言だろう。%ANAME(MASTER)%は唇を噛みしめる
	PRINTFORML ……だが、この男の羽振りの良さは人の口にのぼるほどだ。差し出せば、かなりの支払いは期待できるだろう……
ELSEIF 対象 == ID_TO_CHARA(DVAR:富豪_お気に入りID)
	PRINTFORMW 例の富豪の男が訪ねてきた
	PRINTFORML 「やあ、また来てやったぞ」
	CALL ICPRINT(@"「用件は一つ。あの<%ANAME(対象)%>とかいうのをまた貸したまえ」", "W", カラー_注意)
	IF DVAR:富豪_お気に入り調教回数 >= 3
		PRINTFORMW 「避妊？　ああ、してやるしてやる。わかったわかった」
	ELSE
		PRINTFORMW 「もちろん避妊はしよう。そのあたりは心配するな」
	ENDIF
	PRINTFORMW 「働きに応じて、たんまりと報酬をくれてやる」
	PRINTFORML さて、どうしようか……
ELSE
	PRINTFORMW 例の富豪の男が訪ねてきた
	PRINTFORML 「やあ、また来てやったぞ」
	CALL ICPRINT(@"「そうだな、今回は<%ANAME(対象)%>とかいうのを貸したまえ」", "W", カラー_注意)
	PRINTFORMW 「もちろん避妊はしよう。そのあたりは心配するな」
	PRINTFORMW 「働きに応じて、たんまりと報酬をくれてやる」
	PRINTFORML さて、どうしようか……
ENDIF
CALL SINGLE_DRAWLINE
CALL ASK_MULTI("貸し出す", "そんなことはできない", "捕縛し、身代金を要求", "斬る")
IF RESULT == 1
	PRINTFORMW 「……ふむ？　そうかね」
	PRINTFORMW 「馬鹿な奴め、せっかく大金を手にする機会が目の前にあったというのに」
	PRINTFORMW 「まぁ、いい。それならそれで、こんな辛気くさいところに用はない。それじゃあな」
	PRINTFORMW 男は早々に立ち去っていった……
	DVAR:富豪_お気に入りID = 0
	DVAR:富豪_お気に入り調教回数 = 0
	DVAR:富豪_発生フラグ = 1
	RETURN 1
ELSEIF RESULT == 2
	PRINTFORMW 「き、貴様……！」
	PRINTFORMW 兵士に命じ、彼を捕らえた
	PRINTFORMW その後、国元に身代金を要求した
	PRINTFORMW 男は激怒していたが、最終的には受け入れるほかになかった……
	DVAR:富豪_発生フラグ = -1
	DVAR:富豪_誘拐カウンタ = 5
	DVAR:富豪_誘拐対象 = GET_ID(対象)
	CALL ICPRINT("金<100000>を手に入れた", "W", カラー_注意)
	MONEY += 100000
	CALL COLOR_PRINTW("……富豪の恨みを買った", カラー_警告)
	RETURN 1
ELSEIF RESULT == 3
	PRINTFORML なんとまあ無礼なやつだ
	PRINTFORMW %ANAME(MASTER)%は男を斬り捨てた……
	DVAR:富豪_発生フラグ = -1
	RETURN 1
ENDIF

;お気に入りと違うキャラをご指名ならここで回数リセット
SIF 対象 != ID_TO_CHARA(DVAR:富豪_お気に入りID)
	DVAR:富豪_お気に入り調教回数 = 0

PRINTFORML 「そうだろう？　君たち貧民は、金のこととなれば目の色を変えるものなぁ」
PRINTFORML 「安心したまえ、借り物を壊すような趣味は私にはない。丁寧に弄んでやろうじゃないか」
SELECTCASE DVAR:富豪_お気に入り調教回数
	CASE 0
		PRINTFORMW 「……もっとも、私の技術の前に堕ちることは、あるかもしれないがなぁ？」
		PRINTFORML 男はいやらしい視線を、%ANAME(対象)%の身体に這わせている
		PRINTFORMW %ANAME(対象)%の硬い表情は、嫌悪しつつもそれを表に出せない彼女の立場を如実に表している……
		DVAR:富豪_発生フラグ = 1
	CASE 1
		PRINTFORMW 「ククッ、前回私のモノを受け入れて、その肉穴が緩くなってしまったかもしれんがな」
		PRINTFORML 男はねっとりとした視線を、%ANAME(対象)%の身体に這わせている
		PRINTFORMW 以前されたことを思い出したのか、%ANAME(対象)%は目をそらした……
	CASE 2
		PRINTFORML 「丁寧に仕込まれた"おもちゃ"のようだからな……壊すのは勿体ない」
		PRINTFORMW 「まったく、いいものを貸してくれているよ、君は。ハッ」
		PRINTFORML 男は我が物顔で、%ANAME(対象)%の尻を衣服の上から撫で回している
		PRINTFORMW %ANAME(対象)%は頬を上気させ、\@ IS_LOVER(対象) ? 思い慕っているはずの# \@%ANAME(MASTER)%の目の前で、されるがままにされている……
	CASE 3
		PRINTFORMW 「私への奉仕の仕方も、随分覚えてきてねぇ……おい」
		PRINTFORML 男が目配せすると、%ANAME(対象)%は彼の元に跪く
		PRINTFORMW その一物を露出させると、\@ IS_LOVER(対象) ? 思い慕っているはずの# \@%ANAME(MASTER)%の目の前で、彼の肉棒をしゃぶり始めた……
		PRINTFORML 「おぉ、この吸い付きときたら、本当の好き者のそれだ。金のため股を開いているだけの売春婦には真似できん」
		PRINTFORMW 「君には感謝しているよ？　こんないいものを仕込んでくれたのだからね、私のために」
		PRINTFORMW 男が止めるまで、%ANAME(対象)%は音を立てて、彼の肉棒を熱心にしゃぶり続けていた……
	CASE 4
		PRINTFORMW 「この頃は私から離れようとしなくなってきてなぁ、困ったものだよ」
		PRINTFORML 男はまるで自分のものであるかのように%ANAME(対象)%の衣服のうちに手を入れ、乳房や秘部を弄くり回している
		PRINTFORMW %ANAME(対象)%も%ANAME(対象)%で、たまらないというような切ない声を上げている……
		PRINTFORMW 「ふむ、我慢ならんな、この場で軽くハメてやるか」
		PRINTFORML 男は呟くと、手早く己のモノを露出させ、%ANAME(対象)%の下着を下ろすと、濡れそぼつ雌穴にペニスをねじ込んだ
		PRINTFORMW もはやゴムを使うつもりすらないらしい……
		PRINTFORMW 「あぁ～これだ、この穴だよまったく、大した雌だなコイツは」
		PRINTFORML \@ IS_LOVER(対象) ? 思い慕っているはずの# \@%ANAME(MASTER)%の目の前だというのに、%ANAME(対象)%は淫らな声をあげよがり、自ら腰を振る
		PRINTFORMW 男が膣内に生の種を放つと、%ANAME(対象)%は最高だと言わんばかりの嬌声とともに背を弓なりに反らし、絶頂した……
ENDSELECT
PRINTFORMW 「さて、楽しんでくるとするか。部屋には誰も入れてくれるなよ」
PRINTFORML 男は%ANAME(対象)%の腰を抱きながら、特別に用意された部屋へ連れ立って入っていった……
IF DVAR:富豪_お気に入り調教回数 >= 2 && IS_LOVER(対象)
	PRINTFORML 「……あぁ、そうだ、君は部屋の前に立っていたまえ」
	PRINTFORMW 不意に、男が振り返り、言う
	PRINTFORMW 「どうやら%ANAME(対象)%にとって君は"特別な存在"らしいな？　違うかね？」
	PRINTFORMW 「コトの最中に君のことに言及すると、随分締まりがよくなるんだよ。ククッ」
	PRINTFORMW 「扉一つ隔てて、君が自分の声を聞いているとなったら……随分楽しいだろうなぁ」
	PRINTFORMW 「そういうわけだから、一つ頼むよ。では」
	PRINTFORMW 言うだけ言って、男は扉を閉めた……
ENDIF

PRINTFORML
PRINTFORML
PRINTFORML
PRINTFORMW 二人の入った部屋の中から、男女の激しく交わる声が聞こえてくる……
IF DVAR:富豪_お気に入り調教回数 >= 3 && IS_LOVER(対象)
	CALL COLOR_PRINTL(@"時折、大好き、愛してるなどという、%ANAME(対象)%のとろけた声が混じっている……", カラー_警告)
	CFLAG:対象:好感度 /= 3
	CFLAG:対象:従属度 /= 3
	CFLAG:対象:依存度 /= 3
	CFLAG:対象:支配度 /= 3
	CALL FUCK_RAPE(対象, GET_SPERM_ID("富豪"), @"富豪の\@ RAND:2 ? ペニス # 唇\@", "富豪")
ENDIF
CALL FUCK_RAPE_HININ(対象, @"富豪の\@ RAND:2 ? ペニス # 唇\@", "富豪")
```
