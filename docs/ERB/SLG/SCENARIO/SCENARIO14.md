# SLG/SCENARIO/SCENARIO14.ERB — 自动生成文档

源文件: `ERB/SLG/SCENARIO/SCENARIO14.ERB`

类型: .ERB

自动摘要: functions: SCENARIO_NAME_14, SCENARIO_MAPSELECT_14, SCENARIO_INTRO_14, SCENARIO_PLACEMENT_14; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;シナリオ14
;
;-------------------------------------------------
@SCENARIO_NAME_14
RESULTS = ゆかりんの野望～The Guns of August～
RETURN

@SCENARIO_MAPSELECT_14

MAPID '= "GREATWAR"



@SCENARIO_INTRO_14
PRINTFORML
SETCOLOR カラー_シアン
PRINTFORML A long time ago in a Europa
PRINTFORMW far, far away…
RESETCOLOR
PRINTFORML
PRINTFORMW どこかで見たようなヨーロッパっぽい世界線で複雑怪奇な情勢を打破するのは誰か。
PRINTFORMW 1914年当時（第一次世界大戦当時）の国境線と同時期に独立していた国家全てを再現しています。
PRINTFORMW 帝国主義に走るも良し、民族主義に走るも良し世界の命運は貴方の手にあるのだ。
PRINTFORMW
	SELECTCASE RAND:36
	CASE 0
		SETCOLOR 0Xec6d71
		PRINTFORMW 「こんなに月も紅いのに。永い夜になりそうね」
		RESETCOLOR
	CASE 1
		SETCOLOR 0xc1ab05
		PRINTFORMW 「目どころか、色々当てられない状態にしてやるよ」
		RESETCOLOR
	CASE 2
		SETCOLOR 0xB40404
		PRINTFORMW 「こんなに月も紅いから本気で殺すわよ」
		RESETCOLOR
	CASE 3
		SETCOLOR 0x65318e
		PRINTFORMW 「夜摩天より力があれば、どうとでもなる。ここは、いや、ここもそういう世界なの」
		RESETCOLOR
	CASE 4
		SETCOLOR 0Xeddc44
		PRINTFORMW 「こんな殺伐とした夜がいいのかしら？」
		RESETCOLOR
	CASE 5
		SETCOLOR 0X2a83a2
		PRINTFORMW 「今まで、何人もの人間が敗れ去っていった五つの難題。貴方達に幾つ解けるかしら？」
		RESETCOLOR
	CASE 6
		SETCOLOR 0Xfcc801
		PRINTFORMW 「虐めただけよ。それは日課だもの」
		RESETCOLOR
	CASE 7
		SETCOLOR 0X00552e
		PRINTFORMW 「どう転んでも白黒つくのは貴方だけですよ！」
		RESETCOLOR
	CASE 8
		SETCOLOR 0x1e50a2
		PRINTFORMW 「燕雀いずくんぞ鴻鵠の志を知らんや」
		RESETCOLOR
	CASE 9
		SETCOLOR 0Xe6b422
		PRINTFORMW 「いかに策を練ろうとも、相手はそれを乗り越えて来る。しかし、その愚策は失敗に終わったようね」
		RESETCOLOR
	CASE 10
		SETCOLOR 0Xaacf53
		PRINTFORMW 「貴方は一度─神の荒ぶる御魂を味わうと良い！」
		RESETCOLOR
	CASE 11
		SETCOLOR 0Xf8b500
		PRINTFORMW 「暴れる奴には暴れて迎えるのが礼儀ってね！」
		RESETCOLOR
	CASE 12
		SETCOLOR 0Xdf7163
		PRINTFORMW 「まさか、普通の人間はそんなに生きられませんよ」
		RESETCOLOR
	CASE 13
		SETCOLOR 0X7058a3
		PRINTFORMW 「人間界、最期の夜を。遺伝子の奥底にまで刻み込め！」
		RESETCOLOR
	CASE 14
		SETCOLOR 0x2ca9e1
		PRINTFORMW 「人形を群と為すのならば、その戦略戦術は水の姿に学べ。臨機応変が勝利の鍵なのよ」
		RESETCOLOR
	CASE 15
		SETCOLOR 0xFFFF00
		PRINTFORMW 「雑音は、始末するまで」
		RESETCOLOR
	CASE 16
		SETCOLOR 0X736d71
		PRINTFORMW 「私自らがあなたを裁くわ。覚悟することね」
		RESETCOLOR
	CASE 17
		SETCOLOR 0Xabced8
		PRINTFORMW 「そろそろ私達が活躍する番よ！」
		RESETCOLOR
	CASE 18
		SETCOLOR 0X43676b
		PRINTFORMW 「さあ私と一緒に弱き者が笑って過ごせる世界を創りましょ！」
		RESETCOLOR
	CASE 19
		SETCOLOR 0Xe49e61
		PRINTFORMW 「神様たる物、身に纏う香りも気をつけないと」
		RESETCOLOR
	CASE 20
		SETCOLOR 0xa1d8e2
		PRINTFORMW 「無謀は勇気だ、って事を見せてやる！」
		RESETCOLOR
	CASE 21
		SETCOLOR 0Xffedab
		PRINTFORMW 「あなたに力があろうとも、私達三人には敵わないでしょう？」
		RESETCOLOR
	CASE 22
		SETCOLOR 0xbf783a
		PRINTFORMW 「再び私を封印すると言うのなら─私は精一杯抵抗します」
		RESETCOLOR
	CASE 23
		SETCOLOR 0x895b8a
		PRINTFORMW 「さあ私を倒してみせよ。そして私は生ける伝説となる！」
		RESETCOLOR
	CASE 24
		SETCOLOR 0x9f563a
		PRINTFORMW 「人間に必要なのは豊富な知識でも柔軟な発想でも無い。学ぶ欲と謙虚さじゃ」
		RESETCOLOR
	CASE 25
		SETCOLOR 0Xfff1cf
		PRINTFORMW 「そこにある者が、一番面白い」
		RESETCOLOR
	CASE 26
		SETCOLOR 0XE95464
		PRINTFORMW 「久しぶりの娑婆だ、少し生きる気力が湧いてきたな」
		RESETCOLOR
	CASE 27
		SETCOLOR 0xC51E1F
		PRINTFORMW 「つまり…あなたを倒せば丸く収まるわ」
		RESETCOLOR
	CASE 28
		SETCOLOR 0xBEF781
		PRINTFORMW 「勝負に勝つことぐらい、奇跡でも何でも無いです！」
		RESETCOLOR
	CASE 29
		SETCOLOR 0x0B610B
		PRINTFORMW 「なんなら、貴方の厄災も全て引き受けましょうか？」
		RESETCOLOR
	CASE 30
		SETCOLOR 0xFFFF00
		PRINTFORMW 「『聖者は十字架に磔られました』っていってるように見える？」
		RESETCOLOR
	CASE 31
		SETCOLOR 0xF781F3
		PRINTFORMW 「私が鳥目にしてあげる！」
		RESETCOLOR
	CASE 32
		SETCOLOR 0xFF00FF
		PRINTFORMW 「さあ、これからが本番よ！眠りを覚ます恐怖の記憶（トラウマ）で眠るがいい！」
		RESETCOLOR
	CASE 33
		SETCOLOR 0Xa688bd
		PRINTFORMW 「今日は、喘息も調子良いから、とっておきの魔法。見せてあげるわ！」
		RESETCOLOR
	CASE 34
		SETCOLOR 0x007042
		PRINTFORMW 「私の目的は全人類に復讐することなの」
		RESETCOLOR
	CASE 35
		SETCOLOR 0x848350
		PRINTFORMW 「見よ！聞け！語れ！秘神の真なる魔力がお前の障碍となろう！」
		RESETCOLOR
	ENDSELECT

;ランダムキャラは選択に委ねる
FLAG:OPランダムキャラ使用 = 0


@SCENARIO_PLACEMENT_14

;勢力設定
COUNTRY_BOSS:0 = 0
COUNTRY_COLOR:0 = GETDEFCOLOR()

;;--------ドイツ;--------

COUNTRY_BOSS:1 = GET_ID(NAME_TO_CHARA("幽々子"))
COUNTRY_COLOR:1 = 0xF5A9F2
COUNTRY_AI_TYPE:1 = AI_好戦

CITY_OWNER:GET_CITYNUMBER("キール") = 1
CITY_OWNER:GET_CITYNUMBER("ロストック") = 1
CITY_OWNER:GET_CITYNUMBER("ケーニヒスベルク") = 1
CITY_OWNER:GET_CITYNUMBER("フライブルグ") = 1
CITY_OWNER:GET_CITYNUMBER("マグデブルグ") = 1
CITY_OWNER:GET_CITYNUMBER("ベルリン") = 1
CITY_OWNER:GET_CITYNUMBER("ケルン") = 1
CITY_OWNER:GET_CITYNUMBER("フランクフルト") = 1
CITY_OWNER:GET_CITYNUMBER("コットブス") = 1
CITY_OWNER:GET_CITYNUMBER("ドレスデン") = 1
CITY_OWNER:GET_CITYNUMBER("ニュルンベルグ") = 1
CITY_OWNER:GET_CITYNUMBER("ミュンヘン") = 1
```
