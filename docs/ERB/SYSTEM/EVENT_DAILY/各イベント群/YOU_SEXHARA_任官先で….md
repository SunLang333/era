# SYSTEM/EVENT_DAILY/各イベント群/YOU_SEXHARA_任官先で….ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/YOU_SEXHARA_任官先で….ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_YOU_SEXHARA_RATE, EVENT_DAILY_YOU_SEXHARA_DECISION, EVENT_DAILY_YOU_SEXHARA_GENRE, EVENT_DAILY_YOU_SEXHARA; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_YOU_SEXHARA_RATE()
RETURN 60

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_YOU_SEXHARA_DECISION()
SIF !IS_FEMALE(MASTER)
	RETURN 0
SIF MAX(ABL:MASTER:武闘, ABL:MASTER:知略, ABL:MASTER:政治, ABL:MASTER:防衛) >= 70 || ABL:MASTER:武闘 + ABL:MASTER:知略 + ABL:MASTER:政治 + ABL:MASTER:防衛 >= 240
	RETURN 0
SIF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == MASTER || CFLAG:MASTER:捕虜先 != 0
	RETURN 0
RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_YOU_SEXHARA_GENRE()
RETURN デイリー_ジャンル_エロ


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_YOU_SEXHARA()

SELECTCASE RAND:100
	;45%でセクハライベント
	CASE IS < 45
		PRINTFORMW 非力な%ANAME(MASTER)%は日常的にセクハラの的にされている…
		PRINTFORML 
		SELECTCASE RAND:25
			;ご褒美フェラ
			CASE 0
				PRINTFORML %ANAME(MASTER)%の部屋にじゅっぽじゅっぽと卑猥な蜜音と苦しそうな呻き声が響く
				PRINTFORML 仕事の褒美として部下にフェラチオをせがまれた%ANAME(MASTER)%は、断り切れずに奉仕する事になった
				PRINTFORMW しかしぎこちない動きに業を煮やした彼は、%ANAME(MASTER)%の頭をつかみオナホの様に乱暴に扱いている
				PRINTFORML やがて彼が呻きながら勢いよく射精すると、口いっぱいに雄の匂いが広がり頭がクラクラした
				PRINTFORML 押さえつけられ逃げられない%ANAME(MASTER)%は、涙目になりながらも一滴残らず飲み干すしかなかった
				PRINTFORMW そうして何とかフェラを終えたものの解放されず、ベッドに引きずり込まれて本番も強要されてしまった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"部下の\@RAND:2 ? ペニス # 唇\@", @"部下", "", "強姦")
				PRINTFORMW 
			;資料室で
			CASE 1
				PRINTFORML 人気のない資料室に、ぱんぱんぱんと肉と肉の打ち合う音が響いている
				PRINTFORML %ANAME(MASTER)%は壁に押し付けられた格好で一人の兵士に背後から乱暴に犯されている
				PRINTFORMW 仕事中、兵士に言い寄られた%ANAME(MASTER)%は断り切れず、なしくずしにセックスに持ち込まれてしまった
				PRINTFORML %ANAME(MASTER)%は激しく犯され身を震わせながらも、誰かに聞かれないように必死で声を堪えている
				PRINTFORML しかし彼の方は%ANAME(MASTER)%のそんな様子をまるで楽しむかのようにを容赦なく攻めたててくる
				PRINTFORMW やがてその時が来ると、%ANAME(MASTER)%の懇願もむなしく膣出しされ、その熱に思わず嬌声を上げてしまった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "強姦")
				PRINTFORMW 
			;見回り中に
			CASE 2
				PRINTFORML 巡回任務中、%ANAME(MASTER)%は休憩しないかと付き添いの兵士に近くの宿に誘われた
				PRINTFORML 遠慮していたが腰を抱かれる格好で強引に連れ込まれてしまい、部屋に入るなり押し倒されてしまった
				PRINTFORMW 服を脱がされながらもやはり止めようと説得しようとしたが乱暴に唇をふさがれてしまう
				PRINTFORML 恐怖と緊張で身もだえて震える%ANAME(MASTER)%に対し、彼は手慣れた手つきで全身をまさぐってくる
				PRINTFORML 思わず喘ぎ声を漏らしてしまった%ANAME(MASTER)%を見て、彼は不敵に笑うと、その男らしい一物を取り出した
				PRINTFORMW 彼が満足するまでひたすら抱かれ続けることになり、帰路につく頃にはすっかり日が暮れていた
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "強姦")
				PRINTFORMW 
			;任務の帰りに
			CASE 3
				PRINTFORML 「おら！おら！普段からお高くとまりやがって！役立たずの女のくせに！」
				PRINTFORML %ANAME(MASTER)%は人里離れた古小屋の中で部下に罵倒されながら激しく犯されて呻いている
				PRINTFORMW 任務の帰り道、休憩の為に入った小屋で彼にいきなり押し倒されてそのままレイプされてしまった
				PRINTFORML 「へへ！いつも狙ってたんだよ！あんたを犯せる機会をよ！お、締まったな、ここか！ここが好きか！」
				PRINTFORML 溜まりに溜まった猛りをぶつける荒々しい腰遣いに、%ANAME(MASTER)%の疲れた体は否応なく反応して喘いでしまう
				PRINTFORML 懇願もむなしく中出しされてしまい、子宮に染み込む熱で%ANAME(MASTER)%は思わず絶頂させられてしまった
				PRINTFORMW その後も何度も犯されてしまったが、きつく脅されて誰にも訴えることはできなかった…
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"部下の\@RAND:2 ? ペニス # 唇\@", @"部下", "", "強姦")
				PRINTFORMW 
			;接待の命令
			CASE 4
				PRINTFORML %ANAME(MASTER)%は大臣の命令でパーティーに出席し、ある貴族の接待をさせられている
				PRINTFORML 彼はドレスで着飾った%ANAME(MASTER)%の肩を馴れ馴れしく抱きながらいやらしい目つきで眺めてくる
				PRINTFORMW その視線に嫌悪感を感じながらもなんとか任務を済ませようと必死で笑顔を浮かべて会話に付き合う
				PRINTFORML やがて%ANAME(MASTER)%の事を気に入った貴族は屋敷に連れ帰りたいと要求をしてきた
				PRINTFORML なんとか穏便に拒否しようとしたが大臣が勝手に了承してしまい、結局お持ち帰りされてしまった
				PRINTFORML 屋敷に持ち帰られると当たり前の様に押し倒され、底なしのスタミナで一晩中調教されることになった
				PRINTFORMW 後日、例の大臣に接待は好評だったのでまた頼むよと言われて思い出し、熱い吐息を漏らしてしまった…
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("貴族"), @"富豪の\@RAND:2 ? ペニス # 唇\@", @"富豪", "", "強姦")
				PRINTFORMW 
			;大臣のパワハラ
			CASE 5
				PRINTFORML とある豪奢な部屋の中で%ANAME(MASTER)%はゼーゼーと息を荒げながらベッドに転がっている
				PRINTFORML その脇で一人の男が上機嫌でワインを飲んでいる、%ANAME(MASTER)%の勤めている国の大臣だ
				PRINTFORMW 彼に食事に誘われた%ANAME(MASTER)%はそのままベッドに誘われてしまい、強引に犯されてしまった
				PRINTFORML 散々イかされてしまった%ANAME(MASTER)%は余韻で呆然としながら、秘所から溢れてくる精液を眺めている
				PRINTFORML 休憩を終えた彼が再び覆い被さってくると、%ANAME(MASTER)%は瞳を潤ませながらも震える身体を自ら開いた
				PRINTFORMW 翌日、仕事中に出会った彼にまた頼むよとねっとり囁かれた%ANAME(MASTER)%は、思わず身震いをしてしまった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("貴族"), @"大臣の\@RAND:2 ? ペニス # 唇\@", @"大臣", "", "強姦")
				PRINTFORMW 
			;兵士慰安
			CASE 6
				PRINTFORML 深夜の自室で、%ANAME(MASTER)%は汗だくになりながら若い新兵と激しく絡み合っている
				PRINTFORML %ANAME(MASTER)%はホームシックに悩む彼の相談を聞いてるうちに母性本能を刺激され親身に話を聞いていた
				PRINTFORMW そんな彼に一晩を懇願されては断れず、自室に連れ込んでからもう数時間も恋人の様に愛し合っている
				PRINTFORML 彼は息を荒げて夢中で%ANAME(MASTER)%の身体にむしゃぶりつきながら、一心不乱に腰を打ち付けてくる
				PRINTFORML 彼は激しく腰を振りながら愛の言葉を囁いてきて、%ANAME(MASTER)%は思わず子宮がきゅんと疼いてしまう
				PRINTFORMW 結局求められるままに一晩中交わり続け、朝の陽ざしの中で彼の腕に抱かれて眠りについた
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "和姦")
				PRINTFORMW 
			;酔わされて
			CASE 7
				PRINTFORML %ANAME(MASTER)%は親睦を深めるためと兵士たちに誘われて、彼らと共に酒場で酒を飲んでいる
				PRINTFORML 程々にしようとしていたが、次々に注がれるお酒を断り切れず、結局泥酔するまで酔わされてしまった
				PRINTFORMW すると兵の一人が%ANAME(MASTER)%をお立ち台に立たせて、皆の目の前でおもむろに服をはぎ取り全身をまさぐり始めた
				PRINTFORML 抵抗できない%ANAME(MASTER)%は愛撫の快楽に合わせて身をよじらせ色っぽい喘ぎ声をあげ、兵士たちの興奮を煽る
				PRINTFORML いよいよペニスをぶちこまれると、すっかり火照っていた%ANAME(MASTER)%は兵の目の前で潮吹き絶頂してしまった
				PRINTFORMW その後%ANAME(MASTER)%は代わる代わる兵士たちの相手をさせられ、なん十発モノ精液を注ぎ込まれてしまった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, 輪姦, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "輪姦")
				PRINTFORMW 
			;媚薬を飲まされる
			CASE 8
				PRINTFORML 執務室の中で机に寄りかかる姿勢で兵士に犯されながら、%ANAME(MASTER)%はアヘアヘと喘いでいる
				PRINTFORML 無理矢理犯されている様子にもかかわらず、その表情は惚けきっており目に♥を浮かべて悦びに満ちている
				PRINTFORMW 差し入れの菓子に盛られた媚薬で、今の%ANAME(MASTER)%は犯されることしか頭にないメスに成り下がっているのだ
				PRINTFORML 彼は日頃から目をつけていた%ANAME(MASTER)%を犯せることに興奮し、ガツンガツンと激しくペニスを打ち付けてくる
				PRINTFORML その容赦ないガン突きに%ANAME(MASTER)%は目の前が真っ白になるような快楽に襲われ、恥も外聞もなくヨガリ狂わされる
				PRINTFORMW 薬が切れるまでひたすら膣内射精され、%ANAME(MASTER)%は彼のペニスとザーメンの熱を覚え込まされてしまった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "強姦")
				PRINTFORMW 
			;お風呂でばったり
			CASE 9
				PRINTFORML 深夜、目が覚めた%ANAME(MASTER)%がこっそりとシャワーを浴びていると一人の兵士とばったり遭遇した
				PRINTFORML 慌てる%ANAME(MASTER)%に対し、彼は下卑た笑みを浮かべながら前も隠さずにツカツカと近づいてくる
				PRINTFORMW そして震える%ANAME(MASTER)%を壁に追い詰めると腕をつかんで、騒ぐと人に見られるぞと脅してきた
				PRINTFORML 逃げようとしたが彼に抱きつかれ、そのまま無遠慮に全身を愛撫されだし、思わず小さく喘いでしまった
				PRINTFORML 耳を甘噛みされながら陰核と乳首を巧みにいじられ、%ANAME(MASTER)%は小刻みに震えつつも必死で喘ぎ声を我慢する
				PRINTFORML しかし彼のテクニックにはかなわず、すぐにシャワー室から水音に交じり%ANAME(MASTER)%の甘い嬌声が響きだした
				PRINTFORMW 結局のぼせるまでたっぷりと可愛がられてしまい、体の奥深くまで彼の熱を覚え込まされることになった…
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "強姦")
				PRINTFORMW 
			;仕事中に尻揉み
			CASE 10
				PRINTFORML 仕事をしているとこっそり背後から近づいてきた部下にいきなりお尻を触れられた
				PRINTFORML %ANAME(MASTER)%は驚き悲鳴を上げつつも部下に抗議するが、彼はニヤつきながら手を止めようとしない
				PRINTFORMW 尻肉を大きく揉みしだかれ思わず喘ぎ声を漏らしてしまうと、ますます彼の手の動きは激しさを増していった
				PRINTFORML なんとか逃れようと身をよじるが彼は%ANAME(MASTER)%に身体を寄せてお尻だけではなく胸まで弄りだしてきた
				PRINTFORML すっかり彼のペースにはまってしまい、耳元でなじられながら愛撫され続け、何度か軽くイかされてしまう
				PRINTFORMW その後、惚けた%ANAME(MASTER)%は強引に寝室に連れ込まれて、彼のペニスの相手をさせられることになった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "強姦")
				PRINTFORMW 
			;仕事のミスの代償
			CASE 11
				PRINTFORML 仕事で重大なミスをしてしまった%ANAME(MASTER)%は、それを役人に見つかり咎められてしまった
				PRINTFORML ねちねちと説教され意気消沈していると、帳消しにしてほしければその体を使って楽しませろと迫られた
				PRINTFORMW すっかり弱気になった%ANAME(MASTER)%はその申し出に一瞬ためらいはしたが拒否はできず、頷くしかなかった
				PRINTFORML 部屋に連れ込まれ、ベッドに寝転ぶ彼に奉仕を命ぜられた%ANAME(MASTER)%はその逞しいペニスを自ら咥え込み腰を振る
				PRINTFORML 彼のペニスは長大で、腰を下ろす度に子宮を蹴られる様な衝撃に貫かれ、たまらず喉から甘い喘ぎが漏れてしまう
				PRINTFORML 彼に罵倒されながら腰を振っていると、不意に激しく突き上げられ、思わず大きく身を仰け反らせてしまった
				PRINTFORMW 一晩中犯された後、ようやく解放された%ANAME(MASTER)%は身も心もボロボロになって泣きながら部屋に戻った
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"役人の\@RAND:2 ? ペニス # 唇\@", @"役人", "", "強姦")
				PRINTFORMW 
			;写真をネタに
			CASE 12
				PRINTFORML ある日、衛士の一人に相談があると呼び出された%ANAME(MASTER)%は、そこで一枚の写真を見せられた
				PRINTFORML その写真には自室で自慰にふけるあられもない自分の姿が写されており、%ANAME(MASTER)%は驚愕した
				PRINTFORMW 固まる%ANAME(MASTER)%に彼はゆっくりと近づいてきて「溜まっているならばぜひ相手をしてほしい」と囁いてきた
				PRINTFORML この状況で断れるはずもなく、%ANAME(MASTER)%は怒りや悔しさ、恥ずかしさで身体を震わせながらも小さく頷いた
				PRINTFORML 彼はにんまりと笑うとこちらの腰に手をまわして乱暴に唇をふさぐと、自分の家へと%ANAME(MASTER)%を案内した
				PRINTFORMW %ANAME(MASTER)%は新婚プレイやソーププレイなど様々なプレイを要求され、一晩中彼の肉欲に付き合わされた…
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "強姦")
				PRINTFORMW 
			;馬小屋の管理人に
			CASE 13
				PRINTFORML ある日、%ANAME(MASTER)%は馬の世話をしようと思い立ち馬小屋に向かい、そこの管理人と出会った
				PRINTFORML しばし世間話をしていると馬のペニスや下の世話の話になり、%ANAME(MASTER)%はしどろもどろになってしまった
				PRINTFORMW 彼は%ANAME(MASTER)%の反応を見るとねっとりと笑い、でも俺のペニスもでかくて世話が大変でしてねと迫ってきた
				PRINTFORML 何とか逃れようとした%ANAME(MASTER)%だったが、「日頃の労いをしてくれても良いじゃないか」と腕を掴まれた
				PRINTFORML そして強引に彼の管理小屋に連れ込まれ乱暴に布団に押し倒され悲鳴を上げる間もなく覆いかぶさられてしまった
				PRINTFORMW 言葉通りの馬並みのペニスと底なしのスタミナによって、すっかり立派な雌として調教されてしまった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"馬小屋の管理人の\@RAND:2 ? ペニス # 唇\@", @"馬小屋の管理人", "", "強姦")
				PRINTFORMW 
			;兵の夜這い
			CASE 14
				PRINTFORML ある日の深夜、%ANAME(MASTER)%が眠っていると一人の兵士が夜這いを仕掛けてきた
				PRINTFORML %ANAME(MASTER)%はとっさに逃げようとしたが、思いきり殴りつけられ、乱暴にペニスをねじ込まれてしまった
				PRINTFORML 彼は%ANAME(MASTER)%の腕を掴みながらこれでもかと激しく腰を振り、子宮まで響くようなストロークを見舞ってくる
				PRINTFORMW 内臓が潰される様な激しい衝撃で、%ANAME(MASTER)%は嗚咽を上げながらも一突き毎に思わず身体をはねさせてしまう
				PRINTFORML やがて彼が膣内射精を予告すると%ANAME(MASTER)%は外に出してと懇願するが、容赦なく胎内へと注がれてしまった
				PRINTFORML ショックで呆然とする%ANAME(MASTER)%に構わず、彼はその後もレイプを続け、何度も種付けされてしまった…
				PRINTFORMW 翌朝になり気を取り戻した%ANAME(MASTER)%だったが、恥ずかしさで誰にも相談出来ず泣き寝入りするしかなかった
				CALL FUCK(MASTER, "欲望, 奉仕, 性技, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ｍ, キス, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精", GET_SPERM_ID("兵士"), @"兵士の\@RAND:2 ? ペニス # 唇\@", @"兵士", "", "強姦")
				PRINTFORMW 
			;怪我のお詫び
			CASE 15
				PRINTFORML 訓練中、部下との手合わせ中に誤って怪我をさせてしまった
```
