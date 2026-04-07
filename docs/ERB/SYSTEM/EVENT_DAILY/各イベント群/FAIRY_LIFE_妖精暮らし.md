# SYSTEM/EVENT_DAILY/各イベント群/FAIRY_LIFE_妖精暮らし.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/FAIRY_LIFE_妖精暮らし.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_FAIRY_LIFE_RATE, EVENT_DAILY_FAIRY_LIFE_DECISION, EVENT_DAILY_FAIRY_LIFE_GENRE, EVENT_DAILY_FAIRY_LIFE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_FAIRY_LIFE_RATE()
RETURN (DVAR:妖精暮らし_同棲フラグ > 0 ? 150 # 30)

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_FAIRY_LIFE_DECISION()
SIF DAY < 12
	RETURN 0
SIF !HAS_PENIS(MASTER)
	RETURN 0
SIF DVAR:妖精暮らし_同棲フラグ == -1
	RETURN 0
RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_FAIRY_LIFE_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;---------------------
@EVENT_DAILY_FAIRY_LIFE

;妖精との出会いイベント、同棲してる妖精がいる場合は発生しない
IF DVAR:妖精暮らし_同棲フラグ == 0
	SELECTCASE RAND:4
		;畑を荒らす妖精
		CASE 0
			PRINTFORMW 領民から畑を荒らす妖精がいて困っていると相談された
			PRINTFORML どうしよう？
			CALL ASK_MULTI("兵に巡回させる" ,"罠を仕掛ける" ,"何もしない")
			IF RESULT == 2
				PRINTFORML 妖精の悪戯程度に一々構っていられない
				PRINTFORMW 聞かなかったことにした
			ELSEIF RESULT == 0
				PRINTFORML 放置も出来ないので兵士に巡回させることにした
				PRINTFORML ・
				PRINTFORML ・
				PRINTFORMW ・
				PRINTFORML 数日後、兵士が妖精を捕まえた
				PRINTFORML 彼らはお仕置きと称して彼女を連れ帰り牢獄につないだ
				PRINTFORMW その後の事は想像できたが、彼らの日頃の不満を減らせるならと黙認した
				PRINTFORML …それからしばらくの間、牢獄の一角からは昼夜問わず
				PRINTFORMW 兵士たちの慰み者にされる妖精のうめき声が聞こえてきた
			ELSE
				PRINTFORML 罠を仕掛けることにした
				PRINTFORML 猟師に手伝ってもらい、畑の周囲に妖精用の罠を仕掛けしばらく様子を見た
				PRINTFORML ・
				PRINTFORML ・
				PRINTFORMW ・
				PRINTFORML 数日後、妖精を捕らえる事に成功した
				PRINTFORML 彼女は檻の中で恐怖に震えている
				PRINTFORMW 話をするとお腹が空いてつい出来心だったらしい
				PRINTFORML どうしよう？
				CALL ASK_MULTI("引き渡す" ,"匿う" ,"犯す")
				IF RESULT == 2
					PRINTFORML 妖精の身体を眺めると、幼いながらも立派に女を匂わせるラインをしている
					PRINTFORML ムラっときた%ANAME(MASTER)%は彼女を檻から出してやると近くの空き小屋に連れ込んだ
					PRINTFORMW そして彼女を押し倒し服をはぎ取ると、透き通る様な肌にむしゃぶりついた
					PRINTFORML すべすべした肌に指を這わせるとスポンジの様に沈み、彼女は悲痛な声を上げる
					PRINTFORML しかししばらく全身を愛撫してやると彼女は次第に甘い喘ぎ声を漏らしだした
					PRINTFORML もはや我慢できない%ANAME(MASTER)%は綺麗なピンク色の肉壺に思いきり一物をねじ込んだ
					PRINTFORMW 悲鳴を上げて身悶える彼女に合わせて痙攣する膣肉はきつく%ANAME(MASTER)%を締め付けてくる
					PRINTFORML みっちりとペニスを包み込まれる感覚に%ANAME(MASTER)%は夢中になって腰を打ち付ける
					PRINTFORML 痙攣しながらも涙を流して許しを請う彼女の表情もまた%ANAME(MASTER)%の興奮を煽った
					PRINTFORML 精子がこみ上げてくる感覚に%ANAME(MASTER)%が腰の動きを速めると彼女の嬌声も甲高く響きだす
					PRINTFORMW そして欲望のままに奥深くに射精すると、彼女は弓なりに身体を反らしながら気を失った
					PRINTFORMW 極上の肉オナホをたっぷりと味わった後、ボロボロの彼女を放置して小屋を立ち去った
					CALL FUCK(MASTER, "性技, 性交, Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", "妖精の膣", "強姦")
					DVAR:妖精暮らし_同棲フラグ = -1
				ELSEIF RESULT == 0
					PRINTFORML しかし被害を出したのは事実だ
					PRINTFORMW %ANAME(MASTER)%は被害にあった領民に妖精を引き渡した
					PRINTFORML 妖精はその後、領民たちの鬱憤を晴らす為に性奴隷にされたらしい
					PRINTFORMW 少しの罪悪感を抱きながらも、凌辱される彼女を想像して股間が熱くなった
					DVAR:妖精暮らし_同棲フラグ = -1
				ELSE
					PRINTFORML 悪い子ではなさそうだ
					PRINTFORML そう思った%ANAME(MASTER)%は自分が責任を持つと領民を説得して匿う事にした
					PRINTFORMW 彼女ははじめ警戒していたが、優しく諭してやると%ANAME(MASTER)%の家についてきた
					CALL COLOR_PRINTW(@"名もなき妖精が%ANAME(MASTER)%の家に住み着きました", カラー_注意)
					DVAR:妖精暮らし_同棲フラグ = 1
				ENDIF
			ENDIF
		;雨宿りする妖精
		CASE 1
			PRINTFORML 家で休んでいると突然の土砂降りがやって来た
			PRINTFORML あまりの雨の勢いに窓から外を見ていると、ふと軒下に小さな人影を見かけた
			PRINTFORMW 窓から身を乗り出すと妖精の少女と目が合った、どうやら雨宿りをしているらしい
			PRINTFORML どうしよう？
			CALL ASK_MULTI("家に招く" ,"追い払う" ,"犯す")
			IF RESULT == 2
				PRINTFORML 妖精の身体を眺めると、幼いながらも立派に女を匂わせるラインをしている
				PRINTFORML %ANAME(MASTER)%は心の中で舌なめずりしながら優しい言葉で彼女を家の中に招いた
				PRINTFORMW 疑うことなくついてくる彼女を寝室に連れ込むと、無理やりベッドに押し倒した
				PRINTFORML 当然彼女は激しく暴れたが二度三度とビンタしてやると、大人しくなった
				PRINTFORML 彼女の服をはぎ取ると透き通る様な白い肌と想像以上に大人びた肢体が露となる
				PRINTFORML もはや我慢できなくなった%ANAME(MASTER)%も裸になると彼女に覆い被さる様にむしゃぶりつく
				PRINTFORMW 泣きながら身をよじる彼女の表情もまた%ANAME(MASTER)%の興奮を煽り、夢中で全身を愛撫する
				PRINTFORML 次第に彼女も反応しだし、性感帯をなぞるとビクンと身を振るわせ甘い吐息を漏らした
				PRINTFORML %ANAME(MASTER)%は彼女を横たえると腰を掴み、いきりたった一物をそのピンクの秘所にねじ込んだ
				PRINTFORML 彼女は苦痛に悲鳴を上げたが、%ANAME(MASTER)%はかまわず腰を揺すりきつい膣肉をかき分けていく
				PRINTFORMW きつきつの蜜壺はペニスを全方向から締め付け、気を抜くと射精してしまいそうになる
				PRINTFORML 幼いながらも立派な雌穴に%ANAME(MASTER)%は夢中になって腰を打ち付け彼女の中を味わっていく
				PRINTFORML 彼女は涙を流しながら%ANAME(MASTER)%の腕にしがみつき、ビクンビクンと体を弓ぞりに痙攣する
				PRINTFORML 精子がこみ上げてくる感覚に%ANAME(MASTER)%が腰の動きを速めると彼女の嬌声も甲高く響きだす
				PRINTFORMW そして欲望のままに奥深くに射精すると、彼女は弓なりに身体を反らしながら気を失った
				PRINTFORMW 雨が上がるまで極上の肉オナホをたっぷりと味わった後、ボロボロの彼女を放り出した
				CALL FUCK(MASTER, "性技, 性交, Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", "妖精の膣", "強姦")
				DVAR:妖精暮らし_同棲フラグ = -1
			ELSEIF RESULT == 1
				PRINTFORML どんな悪戯をされるかわからない
				PRINTFORMW しっしっと追い払うと彼女は困った様な顔を見せながら土砂降りの雨の中に消えていった
				DVAR:妖精暮らし_同棲フラグ = -1
			ELSE
				PRINTFORML そこでは風邪をひいてしまうだろう、中に入りなさい
				PRINTFORML %ANAME(MASTER)%がそう呼びかけると彼女は吃驚した様で、飛び上がってこちらを見つめてきた
				PRINTFORMW 驚かせてしまったことを謝りもう一度中へ招く
				PRINTFORML 彼女はしばらく%ANAME(MASTER)%の顔と雨を見比べためらっていたが、恐る恐る家の中へ入って来た
				PRINTFORML タオルを渡し温かいお茶を入れてやると彼女は妖精にしては礼儀正しくお礼を述べた
				PRINTFORMW しばし雨音の中、彼女とたわいない会話をする
				PRINTFORML 最初は緊張していた彼女も慣れてきたのか、笑顔を見せて面白い話を聞かせてくれた
				PRINTFORML やがて雨が止んだが、既に外は真っ暗になっていた
				PRINTFORMW もう遅いから泊まっていくように告げると彼女はえへへと笑って頷いた
				PRINTFORMW …それから彼女はなんとなく%ANAME(MASTER)%の家に居着くことになった
				CALL COLOR_PRINTW(@"名もなき妖精が%ANAME(MASTER)%の家に住み着きました", カラー_注意)
				DVAR:妖精暮らし_同棲フラグ = 1
			ENDIF
		;摘み食いする妖精
		CASE 2
			PRINTFORML 道を歩いていると、お地蔵様のお供え物をつまみ食いする妖精に出会った
			PRINTFORMW 彼女は%ANAME(MASTER)%に見られて、饅頭を頬張りながらビクッと体をこわばらせ硬直した
			PRINTFORML どうしよう？
			CALL ASK_MULTI("食べ物を上げる" ,"捕まえる" ,"立ち去る")
			IF RESULT == 2
				PRINTFORML 別にそれぐらい問題ないだろう
				PRINTFORMW %ANAME(MASTER)%は何も見なかったことにしてその場を立ち去った
				DVAR:妖精暮らし_同棲フラグ = -1
			ELSEIF RESULT == 1
				PRINTFORML お供え物を食べるとは罰当たりめ
				PRINTFORML %ANAME(MASTER)%はサッと手を伸ばして彼女を捕まえた
				PRINTFORMW 彼女は身をよじらせ許してくださいと懇願している
				PRINTFORML どうしよう？
				CALL ASK_YN("売る", "逃がす")
				IF RESULT == 1
					PRINTFORML よく考えればこれぐらいで目くじらを立てる事も無い
					PRINTFORMW 彼女も反省している様なので逃がしてやった
					DVAR:妖精暮らし_同棲フラグ = -1
				ELSE
					PRINTFORML 折角捕まえたのだから逃がすなんてとんでもない
					PRINTFORML どうしようかと思っているとそういえば妖精趣味の男がいた事を思い出す
					PRINTFORMW %ANAME(MASTER)%は彼女を縛り上げると男の元に売りに行った
					PRINTFORML 彼は妖精をいたく気に入り、即金で買ってくれた
					PRINTFORML 恐らく彼女は彼のペットとして一生可愛がられるだろう
					PRINTFORMW 彼女の悲痛な声を背中で聞きながら、%ANAME(MASTER)%は金貨を数えつつ帰路についた
					MONEY += 5000
					CALL COLOR_PRINTW("金", GETDEFCOLOR(), "5000", カラー_注意, "を手に入れた", GETDEFCOLOR())
					DVAR:妖精暮らし_同棲フラグ = -1
				ENDIF
			ELSE
				PRINTFORML よほどお腹が空いているのだろう
				PRINTFORML %ANAME(MASTER)%は懐にあった残り物のお菓子を彼女に差し出した
				PRINTFORML 彼女は一瞬躊躇しながらも、おずおずとそれを受け取った
				PRINTFORMW %ANAME(MASTER)%は良い事をしたと満足し、彼女に別れを告げて帰路についた
				PRINTFORML …しかし彼女がついてくる
				PRINTFORMW その内何処かへ行くだろうと思っていたが、なんと家までついてきてしまった
				PRINTFORML どうしよう？
				CALL ASK_MULTI("家に招く" ,"追い払う" ,"犯す")
				IF RESULT == 1
					PRINTFORML 悪いが妖精の相手はごめんだ
					PRINTFORMW %ANAME(MASTER)%が追い払うと彼女は残念そうな表情を見せて去って行った
					DVAR:妖精暮らし_同棲フラグ = -1
				ELSEIF RESULT == 2
					PRINTFORML 振り返り見つめると、彼女は照れたように頬を染めつつ俯いた
					PRINTFORML その仕草にムラムラと来た%ANAME(MASTER)%は彼女の腕を掴むと家の中に引っ張り込んだ
					PRINTFORMW 驚き戸惑う彼女を寝室へ連れ込むと、ベッドに押し倒し覆いかぶさる
					PRINTFORML 彼女は何をされるのかわかっていない様でどきどきした様子で見つめてくる
					PRINTFORML 一抹の罪悪感を感じながら%ANAME(MASTER)%は彼女に優しくキスをすると服を脱がせる
					PRINTFORML やがて雪のように真っ白な肌が露になり、彼女は恥ずかしそうにもじもじした
					PRINTFORMW %ANAME(MASTER)%も服を脱ぎ棄て、彼女を抱きかかえながら優しく全身を愛撫してやる
					PRINTFORML 彼女はくすぐったそうに身をよじらせ吐息を漏らし、時折ピクッと身を震わせた
					PRINTFORML しばし愛撫を続けていると、次第に彼女も感じ始めたようで喘ぎ声を漏らしだす
					PRINTFORML ピンクの秘所もトロトロになったのを確認した%ANAME(MASTER)%は一物をそこにあてがった
					PRINTFORMW 不安そうに震える彼女のおでこにキスをしながらゆっくりと腰を沈めていく
					PRINTFORML 彼女は痛みに呻きながら%ANAME(MASTER)%にぎゅうっとしがみついてくる
					PRINTFORML そんな彼女を気遣いながらゆっくりと膣肉をほぐす様にしながら奥へと進んでいく
					PRINTFORML 雌穴はきつく%ANAME(MASTER)%を締め付け、気を抜くと射精してしまいそうになるのを我慢する
					PRINTFORMW やがて亀頭の先が小さな雌穴の奥までたどり着くと、彼女は深く息を吐いた
					PRINTFORML まだ涙を流している彼女が慣れるまではやる気を抑えてゆったりと腰を動かしてやる
					PRINTFORML 少しずつ彼女も慣れだし、女らしい喘ぎ声を漏らしながらぎゅうっと足を絡ませてきた
					PRINTFORML 精子がこみ上げてくる感覚に%ANAME(MASTER)%が腰の動きを速めると彼女の嬌声も甲高く響きだす
					PRINTFORMW そして欲望のままに奥深くに射精すると、彼女も弓なりに身体を反らしながら絶頂した
					PRINTFORMW 一晩中たっぷりと愛し合った後、彼女は再会を約束して去って行った
					CALL FUCK(MASTER, "性技, 性交, Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", "妖精の膣", "和姦")
```
