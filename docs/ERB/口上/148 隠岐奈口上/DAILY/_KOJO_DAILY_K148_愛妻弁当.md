# 口上/148 隠岐奈口上/DAILY/_KOJO_DAILY_K148_愛妻弁当.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/DAILY/_KOJO_DAILY_K148_愛妻弁当.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K148_BENTO_RATE, KOJO_DAILY_K148_BENTO_DECISION, KOJO_DAILY_K148_BENTO_GENRE, KOJO_DAILY_K148_BENTO; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K148_BENTO_RATE(対象)
#DIM 対象
RETURN 20

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K148_BENTO_DECISION(対象)
#DIM 対象
;隠岐奈と面識があり、所属がおなじ、正妻であること、2%
SIF !TALENT:対象:正妻
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K148_BENTO_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_その他

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K148_BENTO(対象)
#DIM 対象
#DIM 経験値

PRINTFORML 
PRINTFORML 今日は朝から晩まで軍事演習がある。
PRINTFORMW %ANAME(MASTER)%は監督役として、現地に行かなくてはならない。
PRINTFORML 
PRINTFORML 身支度を整え出かけようとした矢先に、%ANAME(対象)%に声をかけられた。
PRINTFORML 「%ANAME(MASTER)%、今日はずっと外で仕事なんだろう？」
PRINTFORML 「これを昼に食べると良い。ほら、受け取れ」
PRINTFORML どこか誇らしげな様子の%ANAME(対象)%は、風呂敷に包まれた弁当を押し付けてきた。
PRINTFORMW 手に持ってみると、思ったよりも重量感がある。
PRINTFORML 
	;料理Lv50以上　まともだとむしろ書けないという事故
IF ABL:対象:料理 >= 50
	PRINTFORML ああ見えて、%ANAME(対象)%は料理が上手い。
	PRINTFORML この弁当箱の中には、きっと色とりどりの美味しいおかずが詰まっているのだろう。
	PRINTFORML %ANAME(MASTER)%が顔を輝かせてお礼を言うと、%ANAME(対象)%は照れ臭そうに笑った。
	PRINTFORMW 「ふふっ！そんな風に喜んでもらえると、私としても作った甲斐があるよ」
	PRINTFORML 
	PRINTFORML 「……そうだ、%ANAME(MASTER)%、ちょっと屈んでくれ」
	PRINTFORML %ANAME(MASTER)%が応じると、%ANAME(対象)%は駆け寄って軽く唇を重ねてきた。
	PRINTFORML 「ちゅっ……ふふっ、いってらっしゃいのキスだ♥」
	PRINTFORMW くすっと悪戯っぽく肩をすくめる%ANAME(対象)%は、ほんのりと頬を染めていた。
	PRINTFORML 
	PRINTFORMW %ANAME(対象)%に見送られながら、%ANAME(MASTER)%は愛妻弁当を片手に演習予定地へと向かっていった。
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
	PRINTFORML ようやく昼休みの時間がやってきた。
	PRINTFORML まだ半日しか経っていないとはいえ、すっかりお腹はぺこぺこだ。
	PRINTFORMW 弁当を取り出し包みを解いていくと、上品な漆塗りの弁当箱が顔を覗かせた。
	SELECTCASE RAND:3
		CASE 0
			PRINTFORML 蓋を開ければ、艶のある白飯と彩り豊かなおかずが目に飛び込んできた。
			PRINTFORMW がっつきたくなる気持ちを抑えて、まずは両の掌を合わせて「いただきます」をする。
			PRINTFORML 
			PRINTFORMW 最初は白米に箸をつけることにした。
			PRINTFORML やはりコメは炊き立て、と言いたいところだが、弁当のご飯も別の美味さがあるように思う。
			PRINTFORML その持論は、今ここにある白米が証明してくれている。
			PRINTFORML 程よい硬さとどこか温かみのある甘さが、堪らなく心を安らげてくれるのだ。
			PRINTFORMW ほっくりと焼きあがった鮭の切り身、赤紫蘇の塩漬けを合わせれば、もう文句の言いようがない。
			PRINTFORML 
			PRINTFORMW %ANAME(MASTER)%は満足気に頷き、次はおかずの方に箸を伸ばした。
			PRINTFORML 
			PRINTFORML 鶏団子はふわふわしつつも、軟骨のコリコリとした感触と生姜の味が良いアクセントとなっていてとても美味しい。
			PRINTFORML 夢中になって食べていたら、3つ入っていた団子はあっという間になくなってしまった。
			PRINTFORML 実に名残惜しい…。今度おねだりすれば、いっぱい作ってもらえるだろうか？
			PRINTFORMW 彼女のことだ、間違いなく喜んで応じてくれるだろう。
			PRINTFORML 
			PRINTFORMW %ANAME(MASTER)%は高揚した気分のまま、次のおかず…筑前煮に手をつける。
			PRINTFORML 蓮根のさっくりとした食感や、コリコリとした筍、弾力あるぷりぷりの椎茸。
			PRINTFORML 人参の橙とさやいんげんの緑が彩りを豊かに保っている。
			PRINTFORML 一切煮崩れしておらず、つるんとした里芋は程よくねっとりしていて癖になる美味しさだ。
			PRINTFORMW 出汁もきちんと染みていて、見た目も味も申し分ない。
			PRINTFORML 
			PRINTFORML 口にするものがどれもこれも美味しいというのは、なんという贅沢だろうか。
			PRINTFORMW しかもそれら全て、愛妻が作った料理である。
			PRINTFORML 
			PRINTFORML %ANAME(MASTER)%は幸せを噛み締めながら、最後のデザートに箸を伸ばす。
			PRINTFORML ばらんで仕切られているそれは、栗茶巾だ。
			PRINTFORML 柔らかな印象を受ける淡い黄色からは、ほんのりと良い香りが漂ってくる。
			PRINTFORML 箸でひと掬いして口に入れれば、あっという間にふわりと解けて消えてしまった。
			PRINTFORMW 上品な和三盆の甘い余韻が、まるで独り静かな庭園を散歩している時のような心の安らぎをもたらした。
			PRINTFORML 
			PRINTFORML ……本当に、美味しい。
			PRINTFORMW %ANAME(MASTER)%は目を瞑り、穏やかな表情でしみじみとそう思うのだった…。
		CASE 1
			PRINTFORML 今日のお弁当は白米と洋風なおかずで綺麗に彩られている。
			PRINTFORML 星型のニンジンを乗せたミニハンバーグに、ナポリタンスパゲティ。
			PRINTFORML ほうれん草のバターソテー、うずら卵の目玉焼き、プチトマトにブロッコリー。
			PRINTFORMW 大人よりも子供ウケするようなラインナップだが、それがむしろ家庭的な印象をより強調させた。
			PRINTFORML 
			PRINTFORML 「わあ、素敵なお弁当ですね！奥様のお手製ですか？」
			PRINTFORML さて食べようと思っていたところに、傍に控えていた部下が話しかけてきた。
			PRINTFORML 「っと、お邪魔してすみません……あまりに美味しそうだったのでつい」
			PRINTFORML 愛妻手製の弁当を褒められると、こちらとしても嬉しい気持ちになる。
			PRINTFORMW %ANAME(MASTER)%は誇らしげな笑みを浮かべた。
			PRINTFORML 
			PRINTFORML 「それにしても…%ANAME(対象)%様がこんな可愛らしいお弁当を作られるなんて」
			PRINTFORML 「失礼を承知で申しますが、ちょっと意外です」
			PRINTFORML まあ、確かに…%ANAME(対象)%は普段、どこか圧倒されるような雰囲気を纏っている。
			PRINTFORMW 隙を見せず、常に尊大で……伴侶のためにお弁当を作るという愛らしさとは無縁に思われても仕方がない。
			PRINTFORML 
			PRINTFORMW しかし見よ、このお星さまニンジンを。そして%ANAME(対象)%がこれを作っている姿を想像せよ。
			PRINTFORMW す ご く か わ い い 。
			PRINTFORML 
			PRINTFORML しかし可愛いだけではない。これには別の意味も込められている。
			PRINTFORML つまり、"私は星の神なのだぞ！"という顕示だ。
			PRINTFORML %ANAME(対象)%は目立ちたがり屋さんなのである。やっぱり可愛い。
			PRINTFORMW 「なるほど……すごいですね、星の神だなんて」
			PRINTFORML 
			PRINTFORML ちなみに%ANAME(対象)%は能楽の神であり、後戸の神であり、障碍の神であり、養蚕の神であり、
			PRINTFORML 被差別民の神であり、地母神であり、宿神であり、幻想郷の賢者でもある。
			PRINTFORMW 「すごいですね…」
			PRINTFORML 
			PRINTFORML だが、多くある神格の……その本質は何だと思う？
			PRINTFORMW 「それは…申し訳ありません、分かりません」
			PRINTFORML 究極の絶対秘神だ。
			PRINTFORMW 「きゅうきょく…それはすごいですね……」
			PRINTFORML 
			PRINTFORML 「あ……あの、そろそろお弁当をお食べになっては？」
			PRINTFORML たしかにその通りだと思い、 %ANAME(MASTER)%は弁当を食べ、飲み込んでは愛妻自慢を続ける。
			PRINTFORMW 引きつった笑顔を浮かべつつも、真面目な部下である彼は%ANAME(MASTER)%の話を聞かされ続けた…。
		CASE 2
			PRINTFORML 今日のお弁当は炊き込みご飯を筆頭に、和風の彩りだ。
			PRINTFORML おかずはだし巻き卵、鶏のから揚げ、ひじきの煮物、ししとうがらしの甘辛煮。
			PRINTFORMW %SPLIT_RAND("筍/山菜/とうもろこし/鯛/松茸/栗/銀杏/むかご/牡蠣/", 1)%と一緒に炊きこまれたご飯は、見るだけでも食欲をそそる。
			PRINTFORML 
			PRINTFORML ちなみに、ひじきなどの幻想郷で手に入らない食材は、わざわざ%ANAME(対象)%が外の世界に出向いて仕入れているらしい。
			PRINTFORML 色々なものが食べられて嬉しいものの、浮世離れした彼女のことだから、危険なことをしたりされたりしていないか心配だ。
			PRINTFORMW …今度、彼女の買い物について行ってみるとしよう。
			PRINTFORML 
			PRINTFORMW ……ともかく、彼女の料理に外れはない。今日も美味しく頂こう。
			PRINTFORML 
			PRINTFORMW %ANAME(MASTER)%はさっそく炊き込みご飯に箸をつける。
			PRINTFORML このように出汁で炊いたご飯は炊き立てよりも、むしろ冷めている方が味が分かりやすくなる。
			PRINTFORMW つまり、お弁当に最適ということだ。
			PRINTFORML 口に入れた途端、上品に漂う鰹とほっくり炊き上がった具材の香りがいっぱいに広がった。
			PRINTFORMW 慎ましやかにご飯を彩っていた三つ葉が、その独特の風味豊かさで全体の味を引き上げている。
			PRINTFORML 
			PRINTFORML 美味しい……。
			PRINTFORMW 料理上手な妻がいて、本当に幸せ極まりない。
			PRINTFORML 
			PRINTFORML %ANAME(MASTER)%が心穏やかに愛妻弁当を堪能していると、軽い声かけと共に部下の一人がやってきた。
			PRINTFORMW 彼女はたしか…小隊の指揮官だっただろうか。
			PRINTFORML 「お休み中すみません、演習所付近に潜入していた敵陣営の諜報員を捕らえたのですが…」
			PRINTFORML ごはんのあとにしてほしい、と%ANAME(MASTER)%が眉をひそめると、彼女は小さく溜息を吐いた。
			PRINTFORMW 「ええ、そう仰ると思いましたよ」
			PRINTFORML 
			PRINTFORML 「……とりあえず、今は監視付きで拘束、後で捕虜として連れ帰ればいいですかね？」
			PRINTFORML 「女だったんですけれども。昼休みと演習割いて、尋問したりマワしたりってのは時間が勿体ないですし」
			PRINTFORMW 食事中にそういう話するなと顔をしかめつつ、他に仲間がいないかの尋問、捜索を%ANAME(MASTER)%は命じた。
			PRINTFORML 
			PRINTFORML 「捜索はもうさせてます。尋問も一応。ただ、簡単に口を割るとは思えないし、休み時間が勿体ないので"軽く"ですが」
			PRINTFORML 態度は良いとは言えないが、なかなかデキる部下だ。
			PRINTFORMW %ANAME(MASTER)%が満足気に頷くと、彼女もこくりと頷き返した。
			PRINTFORML 
			PRINTFORML 「ところで……お弁当、美味しそうですね。お手製ですか？」
			PRINTFORMW %ANAME(MASTER)%は待ってましたとばかりに、妻の手作りだと答え胸を張る。
			PRINTFORML 「なるほど、羨ましい限りです」
			PRINTFORML 「私の伴侶は容姿も愛想も良いのですが、料理だけは苦手みたいで…」
			PRINTFORML 「…って、こんなこと貴方にとってはどうでもいいですよね。それでは失礼します」
			PRINTFORMW そう言って一礼し、少々早足で彼女は去っていった。
			PRINTFORML 
			PRINTFORML ところで、あの口ぶりからして…彼女の伴侶は女性だろうか……。
			PRINTFORML %ANAME(MASTER)%は百合の園に思いを馳せつつ、再び愛妻弁当を頬張り始めた。
			PRINTFORML ……よそ様のことを考えつつ食べていたなんてバレたら、%ANAME(対象)%に拳骨を食らいそうだ。
			PRINTFORMW 思わず背後を振り返りながらも、%ANAME(MASTER)%は弁当を平らげた。
	ENDSELECT
	IF MAXBASE:MASTER:体力 < 5000
		MAXBASE:MASTER:体力 += 100
		PRINTFORML 
		CALL COLOR_PRINT("弁当のおかげだろう、生命力が漲るのを感じる…", カラー_注意)
		CALL COLOR_PRINT(@"%ANAME(MASTER)%の体力が100上がった！", カラー_注意)
	ENDIF
	PRINTFORML 
	PRINTFORML ・
	PRINTFORMW ・
	PRINTFORML 「おかえり、%ANAME(MASTER)%」
	PRINTFORML 夜遅くに私室に戻った%ANAME(MASTER)%は、笑顔の%ANAME(対象)%に迎えられた。
	PRINTFORMW 「今日はお疲れ様。晩酌でもするか？良いお酒があるけれど…」
	PRINTFORMW %ANAME(MASTER)%は首を振り、%ANAME(対象)%の腰を抱いてソファにかける。
	PRINTFORMW 一緒に座った%ANAME(対象)%は頬を染めて%ANAME(MASTER)%にすり寄ってくる。
	PRINTFORML 
```
