# SYSTEM/EVENT_DAILY/各イベント群/GAIRAI/GAIRAI_EXPERIMENT_外来人の非道な実験.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/GAIRAI/GAIRAI_EXPERIMENT_外来人の非道な実験.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_GAIRAI_EXPERIMENT_RATE, EVENT_DAILY_GAIRAI_EXPERIMENT_DECISION, EVENT_DAILY_GAIRAI_EXPERIMENT_GENRE, EVENT_DAILY_GAIRAI_EXPERIMENT, GAIRAI_SPY_RAPE, SELECT_CHARA_LIST_SHOW_LOGIC_GAIRAI_EXPERIMENT, SELECT_CHARA_LIST_SELECT_LOGIC_GAIRAI_EXPERIMENT; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_GAIRAI_EXPERIMENT_RATE()
RETURN 40


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_GAIRAI_EXPERIMENT_DECISION()
#DIM 外来人

外来人 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_外来人))
SIF 外来人 == -1 || 外来人 == CFLAG:MASTER:所属
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_GAIRAI_EXPERIMENT_GENRE()
RETURN デイリー_ジャンル_特殊勢力

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_GAIRAI_EXPERIMENT()
#DIM 対象
#DIM 外来人
#DIM 勢力番号

外来人 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_外来人))

PRINTFORML 外来人の実験施設の一つを見つけた
PRINTFORML 近くの村人たちを攫っては非道な実験を行っているようだ
PRINTFORMW どうしよう？
CALL ASK_YN("潜入する", "やめておく")
IF RESULT == 1
	PRINTFORMW やめておいた
ELSE
	PRINTFORML 放ってはおけない
	PRINTFORML 潜入して施設を破壊することにした
	PRINTFORMW 誰を潜入させようか？
	CALL SINGLE_DRAWLINE
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("GAIRAI_EXPERIMENT", "GAIRAI_EXPERIMENT")
	対象 = RESULT
	IF 対象 == -1
		PRINTFORML ……いや、やはり危険だ
		PRINTFORMW やめておくことにした
		RETURN -1
	ELSE
		IF 対象 == MASTER
			PRINTFORMW %ANAME(対象)%自ら潜入することにした
		ELSE
			PRINTFORMW %ANAME(対象)%を潜入させることにした
		ENDIF
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		IF (ABL:対象:武闘 + ABL:対象:知略) / 10 > RAND:10 + 11
			PRINTFORML やった！
			PRINTFORMW 首尾よく潜入に成功した%ANAME(対象)%はその施設を破壊することに成功した
			FOR LOCAL, 1, MAX_COUNTRY
				SIF LOCAL != 外来人 && IS_COUNTRY(LOCAL)
					CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:1, 100, -100)
			NEXT
			CALL COLOR_PRINT("この成果に他勢力の評価が上がった", カラー_注意)
			PRINTFORMW 
			CALL CHANGE_RELATION_C_TO_C(外来人, CFLAG:MASTER:1, -500, 500)
			CALL COLOR_PRINT("しかし外来人たちの目の敵にされてしまった", カラー_警告)
			PRINTFORMW 
		ELSE
			PRINTFORML しまった！
			PRINTFORML 作戦に失敗した%ANAME(対象)%は捕らえられてしまった
			PRINTFORMW 外来人たちはこの侵入者を新しい発明品の実験台にすることにした
			IF IS_FEMALE(対象)
				CALL GAIRAI_SPY_RAPE(対象)
				PRINTFORML 
				PRINTFORMW 散々犯された後、%ANAME(対象)%は何とか逃げ出せた
			ELSE 
				PRINTFORML
				PRINTFORMW ぼろぼろにされた%ANAME(対象)%だったが、どうにか逃げ出した
			ENDIF
			FOR LOCAL, 0, CHARANUM
				IF CFLAG:(LOCAL):所属 == 外来人 && !IS_ANIMAL(LOCAL) && TALENT:LOCAL:特殊勢力素質 == 特殊勢力_外来人
					ABL:LOCAL:武闘 += (RAND:3 + 1)
					ABL:LOCAL:知略 += (RAND:3 + 1)
					ABL:LOCAL:政治 += (RAND:3 + 1)
				ENDIF
			NEXT
			CALL COLOR_PRINT("しかし実験のデータにより彼らの勢力が強化されてしまった", カラー_ピンク)
			PRINTFORMW 
		ENDIF
	ENDIF
ENDIF

RETURN 1

;-----------------------------------------------
;実験調教
;-----------------------------------------------
@GAIRAI_SPY_RAPE(ARG:0)
#DIM 外来人
#DIM 勢力番号

外来人 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_外来人))

PRINTFORML 
SELECTCASE RAND:28
	CASE 0
		PRINTFORML %ANAME(ARG:0)%は外来人たちに囲まれながら、だらしない顔を晒してオナニーを披露している
		PRINTFORML %ANAME(ARG:0)%がヨガリ狂いながら激しく蜜壺をかき回す度に、グチョグチョといやらしい音と共に愛液が飛び散る
		PRINTFORML 彼らはその様子を観察しながら%ANAME(ARG:0)%に投与した新開発の薬の効果について淡々と話し合っている
		PRINTFORML 頭が飛んでいる%ANAME(ARG:0)%は実験動物にされている事も構わず、肉欲のままに自慰を続けて何度も絶頂する
		PRINTFORMW やがて指では物足りなくなった%ANAME(ARG:0)%がちんぽを求めだすと、彼らはよってたかって彼女を犯しだした
		CALL FUCK_SP(ARG:0, "自慰, 自慰, 自慰, 性技, 性交, 奉仕, 欲望, 輪姦, 口淫, Ｃ, Ｃ, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
	CASE 1
		PRINTFORML %ANAME(ARG:0)%は巨大な体躯を持つ犬にのしかかられて激しく犯されながら喘ぎ声を上げている
		PRINTFORML 外来人は%ANAME(ARG:0)%に特殊な排卵薬を投与し、別種-つまり犬-との子供を妊娠するかの実験をしている
		PRINTFORML %ANAME(ARG:0)%は必死にもがくが、凶悪なペニスで子宮を小突かれる度に思わず身を震わせ嬌声を上げてしまう
		PRINTFORML 犬はこの雌を孕ませようと激しく腰を振り、その野性的な交尾に%ANAME(ARG:0)%の身体は否応なく躾けられていく
		PRINTFORMW 二匹の交尾は外来人が満足するまで続き、結果%ANAME(ARG:0)%は秘所からあふれるほどの子種を注がれてしまった
		CALL FUCK_SP(ARG:0, "性技, 性交, 精愛, 欲望, 獣姦, Ｖ, Ｖ, Ｖ, Ｍ, Ｖ性交", "処女喪失, キス喪失 膣内射精", 勢力番号, GET_SPERM_ID("犬"), @"犬の\@ RAND:2 ? 唇 # ペニス \@", "犬", "", "強姦")
	CASE 2
		PRINTFORML 裸に剥かれた%ANAME(ARG:0)%は台座の上に大の字で拘束されながら身をよじらせて喘いでいる
		PRINTFORML その両胸には搾乳機が取り付けられており、振動音と共に激しく乳房を刺激して母乳を搾り取っている
		PRINTFORML 乳牛の様に改造された%ANAME(ARG:0)%の胸からは大量の母乳が噴出し、タンクには既に何ℓものミルクが貯まっている
		PRINTFORML %ANAME(ARG:0)%は絶え間なく与えられる刺激に絶頂から降りられず、ヒィヒィと喘ぎながら無様に潮を吹いている
		PRINTFORMW 限界まで搾り取られ搾乳機から解放された後も、%ANAME(ARG:0)%はそのだらしない体を彼らによって散々弄ばれた
		CALL FUCK_SP(ARG:0, "噴乳, 噴乳, 噴乳, 性技, 性交, 欲望, 精愛, 輪姦, 口淫, Ｃ, Ｖ, Ｂ, Ｂ, Ｂ, Ｍ, Ａ, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
		CALL SET_BUSTSIZE(ARG:0, 2)
		TALENT:(ARG:0):母乳体質 = 1
		CALL COLOR_PRINT(@"%ANAME(ARG:0)%は爆乳になった", カラー_ピンク)
		PRINTFORML 
		CALL COLOR_PRINT(@"%ANAME(ARG:0)%は母乳体質になった", カラー_ピンク)
		PRINTFORMW 
	CASE 3
		PRINTFORML 実験室のライトの下で、巨大な機械に取り込まれた%ANAME(ARG:0)%が乱暴に犯されている
		PRINTFORML 手足を拘束されたまま極太の張子でドスドスと雌穴を貫かれ、一突き毎に%ANAME(ARG:0)%は涙と共に喘ぎ声を上げる
		PRINTFORML 健康な女性として新発明の雌調教機械の実験台に選ばれた%ANAME(ARG:0)%は、延々と強度実験に付き合わされている
		PRINTFORML 容赦なく膣を抉られ、潰され、圧迫され続けた%ANAME(ARG:0)%はもはや壊れた人形の様に痙攣するだけになっている
		PRINTFORMW 外来人は実験後も%ANAME(ARG:0)%の身体の調教具合を確かめる為に、性玩具として好き放題に犯しはじめた
		CALL FUCK_SP(ARG:0, "性技, 性交, 欲望, 精愛, 口淫, 輪姦, Ｃ, Ｖ, Ｖ, Ｖ, Ｂ, Ｍ, Ａ, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "機械", "", "強姦")
	CASE 4
		PRINTFORML 実験室のライトの下で、大の字で台座に固定された%ANAME(ARG:0)%の悲痛な嬌声が響いている
		PRINTFORML %ANAME(ARG:0)%の乳首と陰核にはブラシ状のアームが取り付けられており、激しい振動と共に容赦なくシゴいている
		PRINTFORML 薬を塗られてビンビンになった突起への容赦のない刺激に、%ANAME(ARG:0)%は頭が真っ白になってガクガク震える
		PRINTFORML やめて！ゆるして！と潮を吹きながら絶叫する%ANAME(ARG:0)%を無視して、外来人たちはその様子を記録している
		PRINTFORMW やがて絶頂の連続で気を失った%ANAME(ARG:0)%に彼らは興味を失い、下級兵士への慰み者として提供された
		CALL FUCK_SP(ARG:0, "性技, 性交, 欲望, 欲望, 精愛, 口淫, 輪姦, Ｃ, Ｃ, Ｖ, Ｂ, Ｂ, Ｍ, Ａ, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
		TALENT:(ARG:0):Ｃ敏感 = 1
		CALL COLOR_PRINT(@"%ANAME(ARG:0)%はＣ敏感になった", カラー_ピンク)
		PRINTFORMW 
	CASE 5
		PRINTFORML %ANAME(ARG:0)%は一人の男に犯されながらアヒィアヒィとあられもない声を上げて絶頂している
		PRINTFORML 全身の感覚を何百倍にも鋭敏にされた今の%ANAME(ARG:0)%は、肌をなぞられるだけで絶頂してしまう程になっている
		PRINTFORML ペニスが出入りする度に頭が爆発するような快楽が%ANAME(ARG:0)%を襲い、無様にビクンビクンと体を跳ねさせる
		PRINTFORML 必死で負けまいと堪えていた%ANAME(ARG:0)%だが、暴力的な快楽には耐えきれずにだらしないアヘ顔を晒しだした
		PRINTFORMW 正気を失い体を跳ねさせてヨガリ狂う%ANAME(ARG:0)%に対して、男は淡々と弱点を攻めたててその様子を観察した
		CALL FUCK_SP(ARG:0, "性技, 性交, 欲望, 欲望, 精愛, 奉仕, 口淫, Ｃ, Ｖ, Ｂ, Ｍ, Ｖ性交", "処女喪失, キス喪失, 膣内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
	CASE 6
		PRINTFORML %ANAME(ARG:0)%は臨月の様に膨れ上がったお腹を抱えて床に這いつくばり、呻き声を上げている
		PRINTFORML その両穴には管が差し込まれており、そこから大量の精液が%ANAME(ARG:0)%の中へと絶え間なく注ぎこまれている
		PRINTFORML お腹が破裂しそうな苦しさに%ANAME(ARG:0)%は脂汗を流しながら、外来人たちにもう限界だと許しを請う
		PRINTFORML しかし実験は容赦なく続行され、やがて%ANAME(ARG:0)%は口から精液を溢れさせながらビクビクと痙攣しだした
		PRINTFORMW ようやく管を引き抜かれると、勢いよく大量の精液が溢れ出て、その衝撃で%ANAME(ARG:0)%は何度も絶頂した
		CALL FUCK_SP(ARG:0, "欲望, 排泄, Ｖ拡張, Ａ拡張, Ｖ, Ａ, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, 膣内射精, 腸内射精", 勢力番号, GET_SPERM_ID("外来人"), "", "機械姦", "", "強姦")
	CASE 7
		PRINTFORML 捕まった%ANAME(ARG:0)%は人型の機械と一体化させられたまま彼らの奴隷として過ごしている
		PRINTFORML スーツを着る様に機械に取り込まれ雌穴にずっぽりと機械のペニスをねじ込まれており、逃れることはできない
		PRINTFORML %ANAME(ARG:0)%が反抗する度に機械が身体を締め付けながら強烈なピストンを与えて、従順になるまでお仕置きする
		PRINTFORML そうして数日過ごすうちに%ANAME(ARG:0)%はすっかり大人しくなり、機械のパーツの一つに成り下がってしまった
		PRINTFORMW 機械から解放された%ANAME(ARG:0)%は膣に何も入ってないことに違和感を覚え、外来人におねだりしていた
		CALL FUCK_SP(ARG:0, "性技, 性交, 欲望, 精愛, 奉仕, 輪姦, 口淫, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "機械", "", "強姦")
	CASE 8
		PRINTFORML %ANAME(ARG:0)%は奇妙な首輪をつけられたまま彼らの性奴隷として飼われることになった
		PRINTFORML 奉仕を拒否すると首輪から電流が流れて、%ANAME(ARG:0)%が反省して謝罪するまで強烈な苦痛を与えてきた
		PRINTFORML 半面、従順に奉仕していると媚薬を注射して、%ANAME(ARG:0)%が気づかぬうちにその心を徐々に溶かしていく
		PRINTFORML そうやって数日を過ごしている内に%ANAME(ARG:0)%はすっかり彼らに従うことに悦びを覚える様になっていった
		PRINTFORMW 首輪を外されても%ANAME(ARG:0)%は従順なままで、子宮の疼きのままに悦んで身体を開く有様になっていた
		CALL FUCK_SP(ARG:0, "性技, 性交, 欲望, 精愛, 奉仕, 奉仕, 奉仕, 口淫, Ｃ, Ｖ, Ｂ, Ｍ, Ｖ性交", "処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
	CASE 9
		PRINTFORML %ANAME(ARG:0)%は外来人に囲まれながら床の上であられもない恰好をして嬌声を上げている
		PRINTFORML その股間には立派な男根が生えており、%ANAME(ARG:0)%はだらしなく涎を垂らしながら夢中でソレをしごいている
		PRINTFORML 猿のようにオナニーを続けている%ANAME(ARG:0)%の様子を見て、外来人たちは実験の成功を確信し頷きあっている
		PRINTFORML 体を改造された怒りも屈辱も快楽に洗い流された%ANAME(ARG:0)%は、その後も無様に潮と精液をまき散らし続けた
		PRINTFORMW その淫らな様子に外来人たちも我慢出来なくなり、実験と称して %ANAME(ARG:0)%に群がりだした
		TALENT:(ARG:0):性別 = 2
		SETBIT TALENT:(ARG:0):淫乱系, 素質_淫乱_射精狂い
		CALL FUCK_SP(ARG:0, "自慰, 自慰, 性技, 性交, 射精, 射精, 欲望, 輪姦, 口淫, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
		CALL COLOR_PRINT(@"%ANAME(ARG:0)%はふたなりになった", カラー_ピンク)
		PRINTFORML 
```
