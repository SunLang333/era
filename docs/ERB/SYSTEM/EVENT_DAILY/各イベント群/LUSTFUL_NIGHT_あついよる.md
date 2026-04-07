# SYSTEM/EVENT_DAILY/各イベント群/LUSTFUL_NIGHT_あついよる.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/LUSTFUL_NIGHT_あついよる.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_LUSTFUL_NIGHT_RATE, EVENT_DAILY_LUSTFUL_NIGHT_DECISION, EVENT_DAILY_LUSTFUL_NIGHT_GENRE, EVENT_DAILY_LUSTFUL_NIGHT, SELECT_CHARA_LIST_SHOW_LOGIC_LUSTFUL_NIGHT; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_LUSTFUL_NIGHT_RATE()
RETURN 50


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_LUSTFUL_NIGHT_DECISION()
SIF !HAS_PENIS(MASTER)
	RETURN 0
RETURN DAY >= 5

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_LUSTFUL_NIGHT_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_LUSTFUL_NIGHT()
#DIM 対象

PRINTFORML 一日の仕事を終えて寝床についた%ANAME(MASTER)%だったが、何故か妙に身体が火照って寝付けなかった
PRINTFORML 有り体に言って性欲を持て余している。今のままではとても眠れそうにない
PRINTFORMW いっそ誰か襲ってしまおうか…
CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("LUSTFUL_NIGHT", "NONE")
IF RESULT == -1
	PRINTFORML そんなことするべきではない
	PRINTFORMW あなたは水風呂に入って頭と身体を冷やした後、無理矢理眠りについた
	RETURN 1
ENDIF
対象 = RESULT

PRINTFORML %ANAME(MASTER)%が自室を出て歩いていると、%ANAME(対象)%を見つけた
PRINTFORML %ANAME(対象)%も%ANAME(MASTER)%の姿を認めると、挨拶をしてきた
SELECTCASE RAND:3
	CASE 0
		PRINTFORML どうやら同じように寝付けなかったようだ
	CASE 1
		PRINTFORML どうやら夜の巡回警備中だったようだ
	CASE 2
		PRINTFORML どうやらトイレに行ってきた帰りのようだ
ENDSELECT 
PRINTFORML 周囲に人の目はない…
PRINTFORMW %ANAME(MASTER)%はつかつかと歩み寄ると、ぐいと%ANAME(対象)%の手を引いて抱き寄せようとした

IF ABL:対象:性知識 == 0
	IF ID_TO_CHARA(CFLAG:対象:父親) == MASTER
		;娘ルート
		PRINTFORML %ANAME(対象)%は父親である%ANAME(MASTER)%に微塵も警戒心を抱いておらず、何か用があるのかと尋ねてきた
		PRINTFORML %ANAME(MASTER)%は曖昧に答えながら、%ANAME(対象)%の手を引いて自分の部屋へと向かった
		PRINTFORML %ANAME(MASTER)%の心には、自分が育てた娘の肢体を味わいたいというドス黒い情欲が渦を巻いていた
		PRINTFORMW そんなことを知らない%ANAME(対象)%は、ただ大人しく父である%ANAME(MASTER)%に従った……
		PRINTFORML 
		PRINTFORML 自室に備え付けられた個人用の風呂に、%ANAME(対象)%を誘って一緒に入った
		PRINTFORML %ANAME(MASTER)%はゆったりと浴槽に浸かりながら、身体の上に乗せた%ANAME(対象)%の全身を愛撫している
		PRINTFORML 言われるままに入浴したものの、さすがに父娘のスキンシップとしては度が過ぎていると感じたのか、
		PRINTFORMW %ANAME(対象)%は制止の声を上げるが、その声は弱々しく強く拒絶することはなかった……
		PRINTFORML 抵抗がないのをいいことに%ANAME(MASTER)%は%ANAME(対象)%の割れ目を掻き回しながら、強引に顔を引き寄せ唇を奪った
		PRINTFORMW 未知の快楽にガクガクと身悶えする娘の身体を抱き締め、絶頂へと導いてやった……
		PRINTFORML 息も絶え絶えといった様子の%ANAME(対象)%に、股の間から充血したペニスを突き出して見せつけた
		PRINTFORMW 幼い頃一緒に風呂に入ったときに見たモノとはあまりに違うソレから、%ANAME(対象)%は目を離せないでいる……
		PRINTFORML %ANAME(MASTER)%は浴槽内で立ち上がり、座り込んだ%ANAME(対象)%の眼前にびくびくと痙攣するペニスを突きつけた
		PRINTFORML %ANAME(対象)%は本能的に何をすれば良いのか理解したのか、口の端から涎を垂らしながらペニスにむしゃぶりついた
		PRINTFORML 舌と唇を淫靡に艶めかせ、無知とは思えないほど熱烈な口淫で、%ANAME(対象)%は父親のモノに奉仕した
		PRINTFORML ねっとりと絡みつく柔肉の感触に%ANAME(MASTER)%は呆気なく達し、愛する娘の喉奥に子種を注ぎ込んだ
		PRINTFORMW %ANAME(対象)%は自分の母親を孕ませたそれを嚥下し、食道を通る熱に言い知れない感情を覚えた……
		PRINTFORML 
		PRINTFORML 風呂から上がった%ANAME(MASTER)%は%ANAME(対象)%をベッドの上に仰向けに寝かせた
		PRINTFORML %ANAME(対象)%は最早何も言わず、雌として立派に成長した身体を、敬愛する%ANAME(MASTER)%の前に全て曝け出している……
		IF TALENT:対象:処女 == 1
			PRINTFORM 穢れを知らない
		ENDIF
		PRINTFORMW 陰唇は愛液でぬらぬらと光り、いやらしくひくついて雌の本能が満たされるのを待っている
		PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%に覆い被さると、すっかり準備の整っている割れ目にペニスを宛てがった
		PRINTFORML しかしすぐには挿入せず、焦らすように入り口を亀頭でぬちぬちと弄びながら娘の瞳を見つめた
		PRINTFORMW これからすることは父娘としての関係を一変させるものだと、%ANAME(対象)%に理解を促した
		PRINTFORML %ANAME(対象)%はしばらく無言だったが、やがてごくりと唾を飲み込んで、自ら%ANAME(MASTER)%の腰に脚を絡めてきた
		PRINTFORMW %ANAME(MASTER)%は娘が自ら最後の一線を踏み越えたのに満足すると、ぐっと腰を押し込んで一気に貫いた
		IF TALENT:対象:処女 == 1
			PRINTFORML 
			PRINTFORML 実の父親に純潔を奪われたにも関わらず、%ANAME(対象)%は自分を貫く雄の象徴を惚けたように見つめている
			PRINTFORMW 破瓜の痛みは接合部から押し寄せてくる正体不明の多幸感に塗り潰され、娘は女として喘いだ……
			PRINTFORML 
		ENDIF
		PRINTFORML %ANAME(対象)%の雌穴はまるで%ANAME(MASTER)%のために誂えたかのようにぴったりとペニスに絡みつき、
		PRINTFORML きゅんきゅんと切なげに哭きながら粘膜を蠕動させ、%ANAME(MASTER)%は腰が抜けそうな快楽に襲われた
		PRINTFORML それは%ANAME(対象)%も同じようで、呆けたように舌を突き出し、膣肉を抉る剛直の感触に酔い痴れている
		PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%と舌を絡め合うキスをし、すっかり『女』になった娘の身体を堪能することにした……
		
		PRINTFORML 
		PRINTFORML ……
		SELECTCASE RAND:5
			CASE 0
				PRINTFORML %ANAME(MASTER)%は四つん這いにさせた%ANAME(対象)%を後ろから犯している
				PRINTFORML ふと思い立って、%ANAME(対象)%の母親の弱点と同じ場所を、ペニスでぐりぐりと責め立ててみた
				PRINTFORML すると%ANAME(対象)%は激烈な反応を示し、獣じみた嬌声を上げながら潮を吹いてイき狂った……
				PRINTFORMW 血は争えないものだと思いながら、%ANAME(MASTER)%はより一層そこを責め立て、快楽を深く刻み込んだ
			CASE 1
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を自分の上に跨がらせ、腰を振らせた
				PRINTFORML 膣奥を抉る感覚がたまらないのか、%ANAME(対象)%は蕩けきった顔で夢中で腰を動かした
				PRINTFORML 生来の素質によるものなのか苦悶の色はなく、セックスが齎す快楽にただ耽溺している
				PRINTFORMW %ANAME(MASTER)%はよくできた娘へのご褒美して、腰を突き上げて子宮口を抉り精液を注ぎ込んでやった……
			CASE 2
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%と交わりながら、本屋で買った性教育の本を読み聞かせた……
				PRINTFORML 子供の作り方について教え、%ANAME(対象)%がそれを理解すると、不意に膣肉がきゅうっと締まった
				PRINTFORML 自分達が今していることを理解して真っ赤になった娘に、%ANAME(MASTER)%はこのまま続けるかと尋ねた
				PRINTFORMW 拒否の声はなかった……%ANAME(MASTER)%は娘の胎内にたっぷりと子種を注ぎ込み、実践で『子作り』を教え込んだ……
			CASE 3
				PRINTFORML 対面座位の姿勢で交わりながら、%ANAME(MASTER)%は%ANAME(対象)%の耳元で愛を囁いた
				PRINTFORML その愛は最早父娘同士のそれではなく、一人の男と一人の女としてのものだ
				PRINTFORML その意味を知ってか知らずか一言ごとに%ANAME(対象)%の膣は締まり、啼泣しながら%ANAME(MASTER)%へ愛の言葉を返した
				PRINTFORMW %ANAME(MASTER)%はそれに応え膣奥をぐりぐりと刺激し、緩まった子宮口に亀頭を食い込ませてたっぷりと精液を注いだ……
			CASE 4
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%に覆い被さり、長いストロークで深々と雌穴を掘削している
				PRINTFORML ぱん！ぱん！と奥を一突きするたびに、膣肉が%ANAME(MASTER)%のための穴として作り変えられていく
				PRINTFORML %ANAME(対象)%は背中を大きく仰け反らせながらびくびくと痙攣し、膣肉は本能的に子種を求めて蠢いている
				PRINTFORMW %ANAME(MASTER)%は欲望のままに娘の胎内に精液を吐き出し、またすぐに腰を振り始めた……
		ENDSELECT 
		
		PRINTFORML 
		PRINTFORML ……
		PRINTFORML 父と娘の一線を越えて、%ANAME(MASTER)%は獣のように%ANAME(対象)%の肢体をしゃぶり尽くした……
		PRINTFORML 肉欲を開花させられた%ANAME(対象)%は、今は赤子のように%ANAME(MASTER)%のペニスに吸い付いている
		PRINTFORMW 出された精液を飲み干した%ANAME(対象)%の頭を撫でてやると、%ANAME(対象)%は精液まみれの顔で無垢な子供のように微笑んだ
		PRINTFORML 育ててきた娘が自身の欲望に白く穢された様を見て、%ANAME(MASTER)%はさらに情欲の炎を燃やした
		PRINTFORML それを敏感に感じ取った%ANAME(対象)%は、自ら脚を大きく広げ、指で雌穴を開いて見せてきた
		PRINTFORML 瞳に♥を浮かべて犬のように涎を垂らすその姿からは無垢さは失われ、ただ一匹の雌として%ANAME(MASTER)%を誘っている
		PRINTFORMW その有様に暗い悦びを覚えた%ANAME(MASTER)%は、硬さを取り戻したペニスを娘の中心に突き立てた
		PRINTFORML 一夜にして%ANAME(MASTER)%専用として躾けられた穴は、肉親であろうとお構いなしに精液を求めて吸い付いてくる
		PRINTFORML 結局%ANAME(MASTER)%は空が白むまで%ANAME(対象)%の雌穴を犯し尽くしてペニスの形を教え込み、未熟な性感を開発し続けた
		PRINTFORMW 二人の父娘関係は、これまでとは決定的に違ったものになるだろう……

		ABL:対象:性知識 = 1
		CALL FUCK_MAKELOVE(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の唇", ANAME(MASTER))
		CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣")
		CFLAG:対象:好感度 += 800
		CFLAG:対象:従属度 += 300
		CFLAG:対象:依存度 += 300
		TALENT:対象:合意 = 1
		TALENT:対象:チョロイン = 1

	ELSE
		PRINTFORML %ANAME(対象)%はきょとんとした様子で%ANAME(MASTER)%を見ている……どうやら何をされるのか分かっていないようだ
		PRINTFORML %ANAME(MASTER)%はその無垢な瞳に罪悪感を覚えるも、それ以上に背徳的なドス黒い情欲がこみ上げてきた
		PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%の手を引いて、自分の部屋へと向かった
		PRINTFORMW %ANAME(対象)%は遊んでもらえると思っているのか、嬉しそうにしながら素直に%ANAME(MASTER)%についていった……
		PRINTFORML 
		PRINTFORML %ANAME(対象)%を膝の上に乗せて座り、お互いに身体を触りあった
		PRINTFORML 遊びだと思っているのか%ANAME(対象)%ははしゃぎながら%ANAME(MASTER)%に触れてくるが、%ANAME(MASTER)%の手がデリケートな部位に触れると、
		PRINTFORML ぴくりと身体を震わせた……頭に「？」を浮かべながらも、身体は女として敏感な反応を返している
		PRINTFORML 我慢できなくなった%ANAME(MASTER)%は%ANAME(対象)%を抱き締めると、強引に唇を重ねて舌をねじ込んだ
		PRINTFORMW %ANAME(対象)%は驚いて%ANAME(MASTER)%から離れようとするが、尻や胸を愛撫されるとふにゃふにゃと全身から力が抜けていった
		PRINTFORML 
		PRINTFORML しばらく愛撫し続けて唇を離すと、%ANAME(対象)%は瞳に♥を浮かべて%ANAME(MASTER)%を見つめてきた……
		PRINTFORML 頭では理解できていなくても、雌の本能に目覚めた身体はすっかり発情してしまったようだ……
		PRINTFORML お互い裸になって、%ANAME(MASTER)%は反り返ったペニスを%ANAME(対象)%の手に握らせつつ、%ANAME(対象)%の秘所を指でまさぐった
		PRINTFORML %ANAME(対象)%は押し寄せる未知の快感に肢体を震わせながらも、拒絶することなく%ANAME(MASTER)%という雄に身を任せていた
		PRINTFORMW 頃合いと見た%ANAME(MASTER)%は%ANAME(対象)%を優しく仰向けに寝かせると、先走りでぬらぬらと濡れたペニスを秘所に宛てがった
		IF TALENT:対象:処女 == 1
			PRINTFORML 
			PRINTFORMW %ANAME(対象)%は何が起きているのか理解し得ないまま、自分を貫こうとしている雄の象徴を目を見開いて見つめている……
		ENDIF
		
		PRINTFORML 
		PRINTFORML ……
		SELECTCASE RAND:5
			CASE 0
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%に覆い被さり、接合部を見せつけるようにしながら、ゆっくりとしたストロークでペニスを動かした
				PRINTFORML %ANAME(対象)%は顔を真っ赤にし、息を乱しながらも、自分を貫くモノから目が離せないでいる
				PRINTFORML 不意に%ANAME(MASTER)%がぴたりと動きを止めると、%ANAME(対象)%は不思議そうな目で%ANAME(MASTER)%を見上げてきた
				PRINTFORMW %ANAME(MASTER)%は微笑むと、突然暴力的なピストンで雌穴をほじくり返し、喘ぐ%ANAME(対象)%を情け容赦ない悦楽の波に沈めていった……
			CASE 1
				PRINTFORML %ANAME(MASTER)%は目の前に大きな姿見を置き、その前に座って、背面座位の姿勢で%ANAME(対象)%を犯した
				PRINTFORML 鏡面には脚を大きく広げられ接合部を露わにした、%ANAME(対象)%のあられもない姿が映っている
				PRINTFORML 恥ずかしさから目を背けようとする%ANAME(対象)%を諭しつつ、%ANAME(MASTER)%は男と女が気持ち良くなる場所を一つ一つ教えてあげた
				PRINTFORMW そして膣内射精を受けて蕩ける雌としての自分を見せつけ、どこに精液が流し込まれたのかをしっかりと認識させた……
			CASE 2
				PRINTFORML %ANAME(MASTER)%は仰向けに寝転がり、%ANAME(対象)%自身が気持ち良くなれるよう好きに動くように言った
				PRINTFORML 最初は戸惑っていたものの、なんとか膣穴にペニスを挿入すると、%ANAME(対象)%の喉の奥から熱い吐息が漏れた
				PRINTFORML やがて気持ち良くなる場所を見つけたのか、%ANAME(対象)%は涎を垂らしながら夢中で腰を振り始めた……
				PRINTFORMW そして%ANAME(MASTER)%の射精と同時に絶頂し、%ANAME(対象)%は胸の上に倒れ込んだ……%ANAME(MASTER)%が褒めてあげると、%ANAME(対象)%は嬉しそうに目を細めた
			CASE 3
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を四つん這いにさせて挿入し、がっちりと腰を掴んで長いストロークで犯し続けた
				PRINTFORML ゆっくりと%ANAME(対象)%の膣内全体をペニスでこねくり回しながら、%ANAME(対象)%にどこが一番気持ち良いかを答えさせた
				PRINTFORML 知識のない%ANAME(対象)%は正しく伝える言葉を持たなかったが、変化する喘ぎ声の高さで%ANAME(MASTER)%は弱点を見つけ出した
				PRINTFORMW 弱点を集中的に責められた%ANAME(対象)%は、一際高く嘶きながら快楽の波に飲まれ、強烈な絶頂を迎えた……
			CASE 4
				PRINTFORML 一戦交えた後、%ANAME(MASTER)%にペニスを突きつけられ舐めるように言われ、%ANAME(対象)%はおずおずと手を伸ばした
```
