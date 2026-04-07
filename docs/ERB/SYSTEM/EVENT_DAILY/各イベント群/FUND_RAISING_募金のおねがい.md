# SYSTEM/EVENT_DAILY/各イベント群/FUND_RAISING_募金のおねがい.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/FUND_RAISING_募金のおねがい.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_FUND_RAISING_RATE, EVENT_DAILY_FUND_RAISING_DECISION, EVENT_DAILY_FUND_RAISING_GENRE, EVENT_DAILY_FUND_RAISING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_FUND_RAISING_RATE()
RETURN (30 + INRANGE(DVAR:募金_抱いた回数, 0, 10) * 7)


;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_FUND_RAISING_DECISION()
SIF DAY < 10
	RETURN 0
;資金が50000以上の場合
SIF MONEY < 50000
	RETURN 0
RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_FUND_RAISING_GENRE()
RETURN デイリー_ジャンル_エロ

@EVENT_DAILY_FUND_RAISING()
#DIM 募金額


;募金額は現在資金の大体1割
;抱いた回数が増えると募金額が減る（最低5%）
;最低額を10000に設定、最大額をDAY*1000に設定
募金額 = MAX(MONEY * MIN(((10 + RAND:11 + RAND:11) - DVAR:募金_抱いた回数)/ 2, 5) / 100, 10000)
SIF 募金額 > 1000 * DAY
	募金額 = 1000 * DAY
SIF DVAR:募金_抱いた回数 > 0
	募金額 = 募金額 / DVAR:募金_抱いた回数
;初遭遇
IF DVAR:募金_発生フラグ == 0
	PRINTFORMW 仕事をしていると部下が来客を告げた
	PRINTFORMW 何やら市民団体の者らしいが
	PRINTFORMW 丁度仕事も一段落している、会うことにした
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW 「どうも、初めまして。%ANAME(MASTER)%様ですね、本日はお会いしていただきありがとうございます」
	PRINTFORMW 現れたのはどこかあか抜けない、しかし人に好かれそうな笑顔が印象的な娘だ
	PRINTFORMW 娘をソファに座らせ、要件を聞くことにした
	PRINTFORML 「えっと、私達は、恵まれない子供達の為に活動している団体の者です」
	PRINTFORMW 「最近の幻想郷の乱れにより、多くの子供達が酷い目にあっています」
	PRINTFORML 「それで、私達の団体も一生懸命活動しているのですが……」
	PRINTFORMW 「少々活動資金が心もとなくなってきているのです。元々、皆さんの善意により成り立っている活動ですので……」
	PRINTFORMW なるほど、つまり活動資金の援助を申し込みに来たようだ
;8回以上抱いている場合、1/2の確率でただ抱かれに来る
ELSEIF DVAR:募金_抱いた回数 >= 8 && RAND:2 == 0
	PRINTFORML 例の慈善団体の娘が会いに来た様だ
	PRINTFORMW しかしいつもと様子が違う
	PRINTFORML 「お久しぶりです、ご主人様ぁ」
	PRINTFORML 彼女はあなたの顔を見ると恍惚の表情を見せ媚びるような声を出した
	PRINTFORMW 火照りきって息を荒げるその様子は、まるで発情した雌犬の様だ
	PRINTFORML 「んっ、ごめんなさい…我慢できなくなって、また、ご慈悲が欲しくなっちゃって…」
	PRINTFORML 彼女はそう言いながら衣服をたくし上げる
	PRINTFORMW 下着は履いておらず、まる出しの秘所はすでに愛液を滴らせていた
	PRINTFORML 「お願いします…」
	PRINTFORMW いつもとは違う"お願い"に、あなたは苦笑しながらも彼女を抱き寄せた
	PRINTFORML 
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW すっかりあなた好みになった身体をたっぷりと味わった
		CASE 1
			PRINTFORMW あなたの一物にピッタリの蜜壺を飽きるまで楽しんだ
		CASE 2
			PRINTFORMW 可愛らしくあなたを求めてくる彼女を一晩中可愛がった
	ENDSELECT
	PRINTFORML 
	PRINTFORMW …翌朝、彼女は見送るあなたを名残惜しそうに見つめながら帰っていった
	RETURN -1
;2回目以降
ELSEIF DVAR:募金_発生フラグ == 1
	PRINTFORML 例の慈善団体の娘が、また募金を求めにきたようだ
	SELECTCASE DVAR:募金_抱いた回数
		CASE IS < 2
			PRINTFORMW 「あの、恵まれない子供たちのために…またお願いします」
		CASE 2 TO 4
			PRINTFORMW 「あの、恵まれない子供たちのために…今日もお願いします」
			PRINTFORMW 何かを期待しているのか、心なしか顔が赤い…
		CASE 5 TO 7
			PRINTFORMW 「あの…子供たちと…それを建前に抱かれに来た、はしたない私のために…またお願いします」
			PRINTFORMW 紅潮させた頬を隠すことなく、しかし恥ずかしそうな表情でおねだりをしてきた
		CASE IS > 7
			PRINTFORMW 「ここに来るだけで…体が疼いちゃうようになりました」
			PRINTFORMW 「お願いです、淫らな私のために……」
			PRINTFORMW 欲望を隠すことなくさらけ出す姿は娼婦のそれとは異なる淫靡なものだった
	ENDSELECT
	PRINTFORMW 
ENDIF
PRINTFORM 彼女が求めてきた金額は
CALL COLOR_PRINT(@"{募金額}", カラー_注意)
PRINTFORMW 程のようだ
PRINTFORML 言うまでもなく大金だ、見返りも期待できるほどの物はないだろう
PRINTFORMW さて、どうしようか……
CALL SINGLE_DRAWLINE
IF DVAR:募金_抱いた回数 <= 4
	CALL ASK_MULTI_JUDGE(@"金{募金額}を援助する", 1,"やめておく", 1,"代わりにお前を抱かせろ", HAS_PENIS(MASTER))
ELSE
	CALL ASK_MULTI_JUDGE(@"金{募金額}と引き換えに抱く", HAS_PENIS(MASTER),"やめておく", 1)
ENDIF
;断るパターン
IF RESULT == 1
	PRINTFORMW 「そうですか……。とても残念です……」
	IF !RAND:5 && 4 < DVAR:募金_抱いた回数
	;レアケース、面会料のお支払い
		PRINTFORML 「ですが、会っていただいたお礼はしないといけませんね」
		PRINTFORML そう言いながら%ANAME(MASTER)%の足元に四つん這いでにじりより、
		PRINTFORMW %ANAME(MASTER)%のズボンを下ろすと、股間にむしゃぶりついた……
		PRINTFORML 「会って…んっ、いただいあむ…お礼ですので……やんっ」
		PRINTFORML そう、これはただのお礼だからね
		PRINTFORML そう言いながら%ANAME(MASTER)%は己の股間に伸ばそうとしていた娘の手を掴んだ
		PRINTFORMW 「ぁん、ごめんなさ…お礼だけなのに気持ちよくなって…んぐ、いやらしい涎が止まらないのをぁは…許して下さい」
		PRINTFORML %ANAME(MASTER)%が満足いくまで娘の面会のお礼が、淫ら水音が止むことはなかった…
		PRINTFORML …
		PRINTFORMW ……
		PRINTFORMW 「今回は特別ですよ、ちゃんと援助もしてくださいね…んっ」
		PRINTFORMW すっきりした表情で娘は帰っていった
	ELSE
		PRINTFORMW 娘は肩を落として帰って行った
	ENDIF
;援助するパターン
ELSEIF RESULT == 0
	;お金が足りないパターン、無いと思うけど一応
	IF MONEY <= 募金額
		PRINTFORML 募金しようとしたが金が足りなかった
		PRINTFORMW 娘はガッカリしながらもお気持ちだけでもありがとうございますと告げ、去って行った
	ELSEIF DVAR:募金_抱いた回数 == 0
		PRINTFORML 子供を出されてしまってはどうしようもない
		PRINTFORMW 寄付してやることにしよう
		PRINTFORML 「ありがとうございます！%ANAME(MASTER)%様のおかげで多くの子供たちが救われます！」
		PRINTFORMW 娘はパッと笑顔になり、%ANAME(MASTER)%の手を強く握って感謝の気持ちを伝えてきた
		PRINTFORML 
		CALL COLOR_PRINT(@"{募金額}", カラー_注意)
		PRINTFORMW の金を募金した
		MONEY -= 募金額
		CALL COLOR_PRINT(@"%ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%の評判がわずかに上がりました", カラー_注意)
		PRINTFORMW
		FOR LOCAL, 0, MAX_COUNTRY
			SIF IS_COUNTRY(LOCAL)
				CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, 15, -15)
		NEXT
	ELSEIF DVAR:募金_抱いた回数 < 5
		PRINTFORML また抱いてもいいが、今はそんな気分ではない
		PRINTFORMW 素直に募金だけしてやることにした
		PRINTFORML 「あっ…いえ、はい…あ、ありがとうございます……」
		PRINTFORMW 彼女はどこか拍子抜けしたような、あるいはおあずけを食らったような表情をしていた
		PRINTFORML 
		CALL COLOR_PRINT(@"{募金額}", カラー_注意)
		PRINTFORMW の金を募金した
		MONEY -= 募金額
		CALL COLOR_PRINT(@"%ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%の評判がわずかに上がりました", カラー_注意)
		PRINTFORMW
		FOR LOCAL, 0, MAX_COUNTRY
			SIF IS_COUNTRY(LOCAL)
				CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, 15, -15)
		NEXT
	ELSEIF DVAR:募金_抱いた回数 >= 5
		IF RAND:20
			PRINTFORML 「はい…今日もたっぷりと礼を尽くさせていただきますね…♥」
			PRINTFORML 抱いてやると告げると彼女は恍惚の笑みを浮かべて息を荒げた
			PRINTFORMW 寝室へと案内すると、待ちきれないかのように%ANAME(MASTER)%に抱き着いてきた……
			PRINTFORML 
			SELECTCASE RAND:10
				CASE 0
					PRINTFORML 「あっ♥い、いぃ♥あぁ♥おちんぽぉ♥いいのぉ♥あぁん♥」
					PRINTFORML 彼女は%ANAME(MASTER)%に跨り髪を振り乱しながら激しく腰を振ってヨガっている
					PRINTFORML 以前の彼女では考えられないその淫靡な表情と誘う様な仕草が%ANAME(MASTER)%の興奮を煽る
					PRINTFORML 「もっと♥もっとぉ♥あぁ♥そこそこぉ♥ご主人様ぁ♥♥あ♥あぁ♥♥♥」
					PRINTFORMW 淫らに踊り狂う彼女に求められるまま、夜通したっぷりと可愛がってやった
				CASE 1
					PRINTFORML 「ん♥んん♥どうですか♥あっ…♥ご主人様ぁ♥♥あ♥あん♥」
					PRINTFORML 彼女は%ANAME(MASTER)%に抱きつき、腰の動きを合わせながら甘える様な声で囁いてくる
					PRINTFORML 返事代わりに激しく一突きしてやると、悦びの声を上げて大きく身を仰け反らせた
					PRINTFORML 「あひぃ♥♥♥あ…♥イッたぁ♥イッちゃいましたぁ…♥あ♥んん♥あはぁ♥♥」
					PRINTFORMW もっともっとと熱っぽい視線を送ってくる彼女と何度も何度もまぐわった
				CASE 2
					PRINTFORML 「ひぃぃ♥ひぃん♥そこぉ♥あ♥はげしっ♥あぁ♥いく♥いっちゃう♥♥ひぃぃ♥♥」
					PRINTFORML 腰をつかんで激しく突いてやると、彼女は痙攣しながら悲鳴のような喘ぎ声を上げる
					PRINTFORML 一突き毎に膣肉がペニスをきつく締め付けてきて、より深くへといざなわれる
					PRINTFORML 「あ♥あん♥やぁ、おちんぽ♥おっきくなってるぅ♥♥あん♥あ♥きてぇ♥♥」
					PRINTFORMW 膣の締め付けに思わず射精すると、彼女は身体を弓なりに反らしながら絶頂した
				CASE 3
					PRINTFORML 「じゅぷ♥じゅっぷ♥ん♥んん♥ぢゅるるぅ♥♥…ぷはぁ♥はぁ♥はぁ♥どうですかぁ？」
					PRINTFORML フェラを終えた彼女は%ANAME(MASTER)%のペニスに愛おしそうに頬ずりしながら見上げてくる
					PRINTFORML 上手だとほめてやると彼女は嬉しそうに笑い、ご褒美を求めてお尻を突き出してきた
					PRINTFORML 「見てください♥もうぐちょぐちょなんです♥♥我慢できないのぉ♥♥」
					PRINTFORMW 求められるままに一気にねじこんでやると、彼女は歓喜の声を上げて潮を吹いた
				CASE 4
					PRINTFORML 「あ♥あ♥だめぇ♥あっ♥イってる♥今イってます♥♥イってるから許してぇええ♥♥♥」
					PRINTFORML イキっぱなしになった彼女が痙攣しながらヨガリ狂い、許しを請うてくる
					PRINTFORML しかしその必死な表情がたまらなく可愛く、%ANAME(MASTER)%は腰の動きをさらに加速させる
					PRINTFORML 「あひ♥あっ♥♥♥あっ♥♥いひぃ♥いく♥いく♥またイっくぅぅう♥♥♥」
					PRINTFORMW その後も彼女はひたすら絶頂を繰り返し、気を失うまでたっぷりと虐めてやった
				CASE 5
```
