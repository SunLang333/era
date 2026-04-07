# SYSTEM/EVENT_DAILY/各イベント群/YOU_WANDERING_放浪中の災難.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/YOU_WANDERING_放浪中の災難.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_YOU_WANDERING_RATE, EVENT_DAILY_YOU_WANDERING_DECISION, EVENT_DAILY_YOU_WANDERING_GENRE, EVENT_DAILY_YOU_WANDERING, EVENT_DAILY_YOU_WANDERING_ALLOW_WHEN_WANDERING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_YOU_WANDERING_RATE()
RETURN 100

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_YOU_WANDERING_DECISION()
SIF CFLAG:MASTER:所属 != 0 || CFLAG:MASTER:捕虜先 != 0
	RETURN 0

SIF !IS_FEMALE(MASTER)
	RETURN 0

SIF MAX(ABL:MASTER:武闘, ABL:MASTER:知略, ABL:MASTER:政治, ABL:MASTER:防衛) >= 70 || ABL:MASTER:武闘 + ABL:MASTER:知略 + ABL:MASTER:政治 + ABL:MASTER:防衛 >= 240
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_YOU_WANDERING_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_YOU_WANDERING()
#DIM 野盗

野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))

SELECTCASE RAND:30
	;獣に食べ物をねだる & MONEY < 100
	CASE 0
		PRINTFORML 旅の途中、空腹でどうしようもなくなり路地裏の片隅に倒れ込んでしまった
		PRINTFORML すると野良犬がどこかから盗んできたパンを貪っているのに遭遇した
		PRINTFORMW 今の%ANAME(MASTER)%にとってはそれすらもご馳走に見えて、思わずお腹が鳴ってしまう
		PRINTFORML するとその音を聞いた野良犬がこちらを振り返った
		PRINTFORML 筋骨隆々とした見るからに凶暴そうな雄犬だ
		PRINTFORMW どうしよう？
		CALL ASK_YN("媚びて食べ物をねだる", "力づくで食べ物を奪う")
		IF RESULT == 1
			PRINTFORMW %ANAME(MASTER)%は力づくで奪おうとした
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW ・
			PRINTFORML しかし敵わなかった
			PRINTFORML ボロボロにされて転がる%ANAME(MASTER)%に対し、雄犬は鼻息を荒げて匂いを嗅いできた
			PRINTFORMW 恐怖で震えて本能的に服従のポーズをとっていると、彼はワオン！と鳴いて覆いかぶさってきた
		ELSE
			PRINTFORML あまりの空腹に%ANAME(MASTER)%はプライドを捨てて四つん這いになった
			PRINTFORML 彼は警戒するような目つきでこちらを睨みつけてくる
			PRINTFORMW %ANAME(MASTER)%は媚びるように喉を鳴らすと、ごろんと転がり服従のポーズをとった
			PRINTFORML くぅんくぅんと鳴いていると彼は鼻息を荒げながらゆっくりと近づき、匂いを嗅いできた
			PRINTFORMW 恐怖で震えながら服従のポーズを続けていると、彼はワオン！と鳴いて覆いかぶさってきた
		ENDIF
		PRINTFORML %ANAME(MASTER)%は野良犬覆いかぶさられて激しく犯されながら、アヘアヘと喘いでいる
		PRINTFORML 彼は%ANAME(MASTER)%の身体を気に入った様で、一心不乱に腰を振ってペニスを打ち付けてくる
		PRINTFORML 畜生に犯される屈辱を感じながらも、その雄々しい腰遣いは否応なく%ANAME(MASTER)%を雌として目覚めさせる
		PRINTFORML 不意にゴツン！と亀頭で思いきり子宮を小突かれ、思わず身体を跳ねさせて嬌声を上げてしまった
		PRINTFORMW ぎゅうと締まる膣肉に野良犬が大きく吠えると、大量の精液が%ANAME(MASTER)%の胎内に解き放たれた
		CALL FUCK(MASTER, "欲望, 性技, 性交, Ｃ, Ｖ, 獣姦, Ｖ性交", "処女喪失, 膣内射精", GET_SPERM_ID("犬"), @"野良犬のペニス", @"野良犬", "", "強姦")
		PRINTFORML 
		PRINTFORML その後、満足した野犬がいなくなると
		PRINTFORMW %ANAME(MASTER)%はフラフラと起き上がり、泣きながら犬の食べかけのパンを頬張った
	;餓鬼に襲われる
	CASE 1
		PRINTFORMW 放浪中、疲れた%ANAME(MASTER)%が人気のない空き家で休んでいると餓鬼に遭遇した
		PRINTFORML 彼は%ANAME(MASTER)%を見ると甲高い声を上げて襲い掛かってきた！
		CALL ASK_MULTI("応戦する" ,"逃走する" ,"説得する")
		IF RESULT == 2
			PRINTFORMW 説得を試みた！
		ELSEIF RESULT == 1
			PRINTFORMW 逃走を試みた！
		ELSE
			PRINTFORMW 応戦した！
		ENDIF
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		PRINTFORML しかし失敗してしまった…
		PRINTFORMW 餓鬼は捕らえた%ANAME(MASTER)%を乱暴に押し倒すと、服をはいできた
		PRINTFORML 
		PRINTFORML 空き家の中にぱぁんぱぁんと肉の打ち合う音と%ANAME(MASTER)%のくぐもった呻き声が響く
		PRINTFORML 彼は%ANAME(MASTER)%の身体に夢中になってむしゃぶりつきながら大きく腰をグラインドさせて攻め立ててくる
		PRINTFORML なんとか引きはがそうとしても、彼は%ANAME(MASTER)%の身体にきつくしがみついて離そうとしない
		PRINTFORML そのねちっこい愛撫と激しいピストンに、次第に我慢できなくなり身体をくねらせヨガりだしてしまう
		PRINTFORMW やがて彼が一際深くペニスをねじ込み精を放つと、%ANAME(MASTER)%はあられもなく絶頂させられてしまった
		CALL FUCK(MASTER, "欲望, 性技, 性交, 情愛, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, Ｖ性交, Ａ性交", "処女喪失, 膣内射精, Ａ処女喪失, 腸内射精, キス喪失", GET_SPERM_ID("野良妖怪"), @"餓鬼の\@RAND:2 ? ペニス # 唇\@", @"餓鬼", "", "強姦")
		PRINTFORML 
		PRINTFORML 餓鬼は散々%ANAME(MASTER)%を犯された後、満足して去っていった
		PRINTFORMW 後には全身を汚され呆然としたまま横たわる%ANAME(MASTER)%が残された…
	;理不尽な調査
	CASE 2
		PRINTFORML 放浪中のとある町で、兵士に呼び止められた
		PRINTFORML テロを警戒して不審人物ではないか調べるという
		PRINTFORML 彼らはニヤつきながら%ANAME(MASTER)%を嘗め回すように眺めてくる
		PRINTFORML 居心地の悪さを感じて萎縮していると兵の一人が不意に%ANAME(MASTER)%の腕をつかんできた
		PRINTFORMW %ANAME(MASTER)%が驚いていると彼らは、怪しいのでもっとよく調べると告げ、強引に詰所へと連行された
		PRINTFORML 
		PRINTFORML 詰め所の奥に連れ込まれた%ANAME(MASTER)%が、兵士たちに輪姦されている
		PRINTFORML 逃げようとしては押し倒され殴られ、罰として犯され泣き叫ぶ%ANAME(MASTER)%の中にザーメンが注がれる
		PRINTFORMW その繰り返しにすっかり大人しくなった%ANAME(MASTER)%は、いまや泣きながらも従順に彼らに奉仕している
		PRINTFORML 今もまた一人の兵士に跨り腰を振りながら、口や手を使い他のペニスを懸命にしごき続けている
		PRINTFORML 膣内射精されてもむろん逃げることは許されず、ひきつった笑顔で一滴残らず受け止めさせられた
		PRINTFORMW %ANAME(MASTER)%の肉体は好評で、彼らの取り調べは夜通し続けられ、精液でドロドロにされてしまった
		CALL FUCK(MASTER, "欲望, 性技, 性交, 奉仕, 情愛, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, 輪姦, 口淫, Ｖ性交, Ａ性交", "処女喪失, 膣内射精, Ａ処女喪失, 腸内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "輪姦")
		PRINTFORML 
		PRINTFORMW %ANAME(MASTER)%は夜通し調べられた後、ようやく無一文で放り出された
		MONEY = 0
	;野盗に襲われる
	CASE 3
		PRINTFORMW 山道を歩いていると、周囲から何者かの気配を感じた
		PRINTFORML どうしよう？
		CALL ASK_MULTI("様子をうかがう" ,"周囲に声をかける" ,"足早に立ち去る")
		IF RESULT == 2
			PRINTFORML 嫌な予感がした%ANAME(MASTER)%は一目散にその場を走り出した
			PRINTFORML すると周囲の茂みから人影が現れ、%ANAME(MASTER)%の行く手をふさいできた
			PRINTFORMW 慌てて踵を返そうとするも、さらに複数の人影に囲まれてしまった
		ELSEIF RESULT == 1
			PRINTFORML 誰かがいるのかもしれない、そう思った%ANAME(MASTER)%は周囲に声をかけた
			PRINTFORML すると周囲の茂みから複数の人影が現れる…野盗の集団だ！
			PRINTFORMW 慌てて逃げようとしたが時すでに遅く、%ANAME(MASTER)%は囲まれてしまった
		ELSE
			PRINTFORML 獣か何かがいるのだろうか
			PRINTFORML うかつに動かずに警戒していると、突然背後から口をふさがれた！
			PRINTFORML もがいて逃げようとするも、それもかまわずその場に抑え込まれてしまった
			PRINTFORMW すると周囲の茂みから男の仲間らしき集団が姿を現した…
		ENDIF
		PRINTFORMW 野盗たちはニヤニヤと笑いながら、抵抗する%ANAME(MASTER)%を手際よく縛り上げるとどこかへ連れ去った…
		PRINTFORML 
		PRINTFORML どこかの小屋でドロドロにされた%ANAME(MASTER)%が無残に横たわっている
		PRINTFORML 拉致された%ANAME(MASTER)%は彼らの性奴隷として散々輪姦されつくし、ボロボロになっている
		PRINTFORML あまりの仕打ちに%ANAME(MASTER)%は茫然となっており、秘所から溢れる精液を虚ろに眺めていた
		PRINTFORML 野盗たちは%ANAME(MASTER)%をこれからどう使おうか、誰の子を孕むだろうかと下卑た会話をしている
		PRINTFORMW やがて休憩を終えた彼らが再び%ANAME(MASTER)%に群がってくると、小屋からまた悲痛な喘ぎ声が響きだした
		CALL FUCK(MASTER, "欲望, 性技, 性交, 奉仕, 情愛, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, 輪姦, 口淫, Ｖ性交, Ａ性交", "処女喪失, 膣内射精, Ａ処女喪失, 腸内射精", GET_SPERM_ID("野盗"), @"野盗の\@RAND:2 ? ペニス # 唇\@", @"野盗", "", "輪姦")
		CALL FUCK(MASTER, "欲望, 性技, 性交, 奉仕, 情愛, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, 輪姦, 口淫, Ｖ性交, Ａ性交", "処女喪失, 膣内射精, Ａ処女喪失, 腸内射精", GET_SPERM_ID("野盗"), @"野盗の\@RAND:2 ? ペニス # 唇\@", @"野盗", "", "輪姦")
		PRINTFORML 
		PRINTFORMW 彼らの性奴隷として散々犯されていたが、隙をついて何とか逃げ出す事が出来た
		CALL SET_TATTOO_RANDOM(MASTER, STR_FOR_TATTOO(-1), 0)
		IF RESULT != -1
			CALL COLOR_PRINT(@"しかし凌辱の証として%GET_TATTOO_NAME(RESULT)%に、「%TATTOO:MASTER:RESULT%」とタトゥーを入れられた", カラー_注意)
			PRINTFORMW
		ENDIF
	;河童の縄張りに入り込む
	CASE 4
		PRINTFORML 旅の途中、川べりで休んでいると水面に気泡が浮かんできた
		PRINTFORML なんだろうと覗き込むと、いきなり川の中から腕が伸びてきて足首をつかんできた！
		PRINTFORMW 水中に引きずり込まれそうになり、抵抗しているとやがて川の中から河童が現れた
		PRINTFORML いきなりの事に抗議をしたら、ここは自分の庭だから勝手にくつろぐなと文句を言われた
		PRINTFORML そして離してほしければキュウリをよこせと言われた
		PRINTFORML どうしよう？
		CALL ASK_YN("倒す", "キュウリをあげる")
		IF RESULT == 0
			PRINTFORML 妖怪相手に慈悲はない
			PRINTFORMW %ANAME(MASTER)%は河童を倒すことにした！
		ELSE
			PRINTFORML しかし手持ちにキュウリはなかった
			PRINTFORMW 仕方ないので河童を倒すことにした！
		ENDIF
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		PRINTFORML しかしやられてしまった…
		PRINTFORMW 河童は抵抗できなくなった%ANAME(MASTER)%を水中へと引きずり込んでいった
		PRINTFORML 
		PRINTFORML 薄暗い河童の巣の中に男女のまぐわう激しい蜜音と喘ぎ声が響いている
		PRINTFORML 河童に被さられ種付けプレスの姿勢で容赦なくペニスを打ち込まれ、%ANAME(MASTER)%はヒィヒィ喘いでいる
		PRINTFORML その雄々しいピストンは、一突き毎に脳天まで貫かれる様な衝撃をもたらし、身も心も蹂躙されていく
		PRINTFORML 次第に%ANAME(MASTER)%は無意識の内に自ら彼にしがみつきだし、あられもない嬌声を上げていた
		PRINTFORMW 彼がスパートをかけだすと%ANAME(MASTER)%は犯されているのも関わらず子宮を疼かせ種付けを期待していた
		CALL FUCK(MASTER, "欲望, 性技, 性交, 情愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "処女喪失, 膣内射精, 口内射精, キス喪失", GET_SPERM_ID("野良妖怪"), @"河童の\@RAND:2 ? ペニス # 唇\@", @"河童", "", "強姦")
		PRINTFORML 
		PRINTFORML たっぷり犯し満足したのか、河童は解放してくれた
		PRINTFORMW だが%ANAME(MASTER)%の子宮には彼の熱の感触が残り、しばらく忘れられなかった…
	;天狗に見初められる
	CASE 5
		PRINTFORML 山道を歩いていると突然体が宙に浮いた！
		PRINTFORML 慌てて足をばたつかせる%ANAME(MASTER)%だが、何者かに抱えあげられていると気づく
		PRINTFORML 天狗だ！
		PRINTFORMW 突然のことに慌てる%ANAME(MASTER)%の抗議の言葉も聞かずに天狗は%ANAME(MASTER)%を何処かへと連れ去った
		PRINTFORML 
		PRINTFORML …連れていかれたのは彼の棲み処だった
		PRINTFORML 食べられるかと恐怖に震えていると丁重なもてなしを受けた
		PRINTFORMW 訳も分からずにいると、なんと求婚をされてしまった
		PRINTFORML 山道を歩いている%ANAME(MASTER)%の姿に一目ぼれをしたらしい
		PRINTFORML そんな勝手なことがあるかと思ったが断ってもどうしようもないかもしれない…
		$SEXHARA_TENGU_LOOP
		PRINTFORML どうしよう？
```
