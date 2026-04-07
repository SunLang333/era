# 口上/83 青娥口上/DAILY/_KOJO_DAILY_K83_邪仙と過ごす夜.ERB — 自动生成文档

源文件: `ERB/口上/83 青娥口上/DAILY/_KOJO_DAILY_K83_邪仙と過ごす夜.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT_RATE, KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT_DECISION, KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT_GENRE, KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT_RATE(対象)
#DIM 対象
RETURN 50


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT_DECISION(対象)
#DIM 対象

;合意がないとだめ
SIF !TALENT:対象:合意
	RETURN 0
	
;対象が女でないとだめ
SIF !IS_FEMALE(対象)
	RETURN 0
	
;主人公と同一勢力で捕虜でなく、主人公がペニス持ちで、好感度1500以上
RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0) && HAS_PENIS(MASTER) && CFLAG:対象:好感度 >= 1500

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K83_NIGHT_OF_THE_HERMIT(対象)
#DIM 対象

PRINTFORML ･･･
SELECTCASE RAND:3
	;添い寝ルート
	CASE 0
		PRINTFORMW とある日の夜
		PRINTFORML そろそろ眠ろうかと思っていたところに、%ANAME(対象)%が枕持参で%ANAME(MASTER)%の部屋を訪ねてきた
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「%ANAME(MASTER)%、まだ起きてますか？」
				PRINTFORML 「あ、あの…子供っぽいこと言うようで何なんですけど……」
				PRINTFORMW 「今夜は妙に人肌が恋しくて……添い寝とか…してくれませんか？」
			CASE 1
				PRINTFORML 「一人寝は寂しくないですか？」
				PRINTFORMW 「…良かったら、私を抱き枕にしてみては如何でしょう♪」
			CASE 2
				PRINTFORML 「何だか人肌恋しくなりまして……良かったら抱き枕になってくれませんか？」
				PRINTFORMW 「その代わり、そちらは私のお胸を枕にしても構いませんから…♥」
		ENDSELECT
		PRINTFORMW どうやら人恋しくなった%ANAME(対象)%は、%ANAME(MASTER)%と一緒に寝たいようだ
		PRINTFORMW さて、どうしよう……
		PRINTFORML
		CALL ASK_YN("一緒に寝る", "断る")
		IF RESULT == 1
			PRINTFORML
			PRINTFORMW …逆に悶々として眠れなくなりそうだから断った
			PRINTFORML 「そ、そんな殺生な……ヨヨヨ、あんまりですわー……」
			PRINTFORMW %ANAME(対象)%は芝居がかった様子でハンカチを噛みながら帰っていった……
			PRINTFORML それではそろそろ眠るとしよう…
			PRINTFORML ･･･
			PRINTFORMW ･･････
			PRINTFORML 深夜、ふとした違和感で目が覚めた。何やら布団の中に温かくて柔らかい感触が…
			PRINTFORMW 何かと思って横を見ると、いつの間にか%ANAME(対象)%が%ANAME(MASTER)%に抱きつきながら眠っていた
			PRINTFORMW ……そういえば%ANAME(対象)%は壁抜けの術が使えるのだ。その気になれば部屋の施錠など無意味だった
			PRINTFORML しかし、%ANAME(MASTER)%に抱きついて幸せそうな顔で眠る彼女からは、邪な考えはまるで無いように感じた
			PRINTFORMW 本当に、ただ一緒に眠りたかっただけなのだろう
			PRINTFORML %ANAME(MASTER)%もまた、彼女を抱き枕にして再び眠ることにした
			PRINTFORMW 「ん…んん………%ANAME(MASTER)%………♥」
			PRINTFORML 甘えた声で寝言を漏らしながら、%ANAME(対象)%もぎゅっと抱きついてくる
			PRINTFORMW 結局二人とも、互いを抱き枕にして仲良く眠りについた……
			CFLAG:対象:好感度 += 300
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が300上がった", 0x00FFFF)
		ELSE
			PRINTFORML
			PRINTFORMW …彼女のような美人が添い寝してくれる機会を棒に振る、というのも損だろう
			PRINTFORML 「ふふ、ありがとうございます。それじゃあ、お邪魔しますね♪」
			PRINTFORML 寝巻きに着替えて、冷えた布団の中に二人で潜り込む
			PRINTFORMW 「あぁ…%ANAME(MASTER)%の身体、とても温かいです…♥　私の身体はどうですか？」
			PRINTFORML 上等な布質の寝巻きから、彼女の体温といい香り、そして柔らかさが伝わる
			PRINTFORMW その柔らかさをもっと味わいたくて、%ANAME(MASTER)%はおのずと%ANAME(対象)%を抱きしめる
			PRINTFORMW 「あん…、いいですよ。今日は二人とも、お互いのための抱き枕になっちゃいましょう…♥」
			PRINTFORML %ANAME(対象)%はそう言いながら、%ANAME(MASTER)%の顔を自らの胸で抱き包む
			PRINTFORMW 「私のお胸枕、どうですか？　男女を問わず喜ばれている枕なんですが」
			PRINTFORML %ANAME(MASTER)%の頭を撫でながら%ANAME(対象)%が囁く
			PRINTFORMW 柔らかさも、香りも、温もりも、たしかに極上の枕だった。思わず下半身も元気になるほどの…
			PRINTFORML 「あらあら、熱い物が太ももに当たっていますね♥　どうしましょうか」
			PRINTFORMW 「このまま眠っちゃいますか？　それとも……もっと先のことまで、シてあげましょうか…？」
			PRINTFORML 勃起した肉棒に太ももを擦り付けながら誘惑する
			PRINTFORMW …この誘惑を撥ね退けられる者はそう多くないだろう。そして%ANAME(MASTER)%もまた、この先を求めた
			PRINTFORML 「うふふ…そんな可愛いお顔で言われたら…、とっても、サービスしてあげたくなります」
			PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%のガチガチになったペニスを取り出し、淫蕩な表情で%ANAME(MASTER)%に絡み付いてきた
			PRINTFORMW 「ぐっすり眠れるように、たくさん搾ってあげますわ♥」
			PRINTFORML
			PRINTFORMW ……
			SELECTCASE RAND:4
				CASE 0
					PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%に覆いかぶさるように、正常位で繋がり合っている
					PRINTFORML 一見%ANAME(MASTER)%が押し倒しているはずの体勢だが、その実、主導権は%ANAME(対象)%が握っていた
					PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の腰に艶かしく脚を絡め、巧みに腰を揺すって膣内のペニスを弄ぶ
					PRINTFORMW 「ふふっ、キモチいいですか？　仙人の房中術、堪能してくださいね♥」
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の顔を、自らの豊満で柔らかな乳房で顔を抱き包む
					PRINTFORMW 上を乳肉、下を膣肉で包まれ、甘い快楽が%ANAME(MASTER)%を支配していく…
					PRINTFORML 「ああ、私に蕩けて、とてもいいお顔ですわ♥　いつでも中に出してかまいませんからね♪」
					PRINTFORML %ANAME(対象)%の甘い囁きが%ANAME(MASTER)%の耳を犯し、彼女に食べられているペニスを震わせる
					PRINTFORMW そしてついに彼女の中に精を漏らす。膣内に走る命の熱を感じ、彼女は幸せそうに%ANAME(MASTER)%の頭を撫でた……
				CASE 1
					PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の上に跨り、ねっとりとしたキスで%ANAME(MASTER)%の口を塞ぎながら腰を振っている
					PRINTFORML ぱちゅっぱちゅっ、と肉がぶつかり合う性交特有の音が二人の情欲を煽っていく
					PRINTFORMW 「あっ、んっ、どうですか？　%ANAME(MASTER)%♥　私の中っ、キモチいいですか？　あんっ♥」
					PRINTFORML %ANAME(対象)%は腰を巧みにくねらせ、%ANAME(MASTER)%に極上の快感を与えて肉棒を責め立てる
					PRINTFORMW 「ああ、注いでくださいっ私の中にっ♥　%ANAME(MASTER)%の愛を注いでくださいましっ♥」
					PRINTFORMW %ANAME(MASTER)%は彼女の腰使いに屈服して、%ANAME(対象)%の名を叫びながら子宮口まで思い切り突き上げて射精した……
				CASE 2
					PRINTFORMW %ANAME(MASTER)%は対面座位の姿勢で%ANAME(対象)%と深く繋がりあっている
					PRINTFORMW 彼女の魔性の腰使いに夢中になり、ぎゅっと柔らかな肢体に抱きつきながら快楽を貪る%ANAME(MASTER)%
					PRINTFORML その柔らかさと肉壷に恍惚としていると、ふいに%ANAME(対象)%が耳元で
					CALL COLOR_PRINTL("「　キ　モ　チ　い　い　で　す　か　？　」", カラー_ピンク)
					PRINTFORMW と甘い吐息交じりで囁いてきた
					PRINTFORMW 頭の中に響くような艶声が、%ANAME(MASTER)%の全身にゾクゾクと甘い痺れを走らせ、ペニスがびくびくと跳ねる
					PRINTFORML 「ふふ…♥　耳元で囁かれるの、お好きなんですか？　…じゃあ、もっとシテあげます…♥」
					PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の耳に唇が触れそうな距離で、甘い言葉を囁きながら腰をくねらせる
					PRINTFORMW %ANAME(対象)%が与える甘い快楽に支配された%ANAME(MASTER)%は、恍惚としたまま盛大に射精した……
				CASE 3
					PRINTFORMW 「んちゅ…はむ…っ♥…れろぉ…。うふふ、キモチよさそうですね♥」
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の股間に潜り込み、愛しい肉棒を丹念にしゃぶっている
					PRINTFORMW カリ首や鈴口を舌先で舐めなぞり、裏筋、玉袋まで入念に責める
					PRINTFORML その卓越した性技は%ANAME(MASTER)%を腰砕けにするには十分だった。あまりの快感に腰を引こうとするも
					PRINTFORML 「あぁん、だめですよ♥　んちゅっ……私のお口、まだまだ堪能してくださいまし♥」
					PRINTFORMW そう言うと%ANAME(対象)%は%ANAME(MASTER)%の腰をがっしりと抱え、ペニスをよりいっそう深く強くしゃぶり咥える
					PRINTFORMW %ANAME(対象)%のテクニックにより、%ANAME(MASTER)%の肉棒はたやすく根を上げ、彼女の口内に大量射精した
					PRINTFORML 「んんぅっ！　……ん…ちゅぅ…♥……見てください、%ANAME(MASTER)%のがこんなにいっぱい…あ～ん♥」
					PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の目の前で、口内に出された精液を見せ付ける
					PRINTFORML そして唾液と合わせてくちゅくちゅと味わい、扇情的な表情でごくん、と喉を鳴らして飲み込んだ
					PRINTFORMW そのあまりに淫靡な光景に、射精したばかりの肉棒は即座に硬さを取り戻す
					PRINTFORMW 「うふふ…今度は私のココに、%ANAME(MASTER)%の子種をくださいませ♥」
			ENDSELECT 
			PRINTFORML
			PRINTFORMW ……
			PRINTFORMW 最後の一滴まで%ANAME(対象)%に搾り取られてようやくセックスが終わると、二人は裸で抱き合ったまま横になった
			PRINTFORML %ANAME(対象)%の性技に恍惚とした%ANAME(MASTER)%は、そのまま甘えるように彼女に抱きついて目を閉じる
			PRINTFORMW 「ん……お休みなさい、%ANAME(MASTER)%……♥」
			PRINTFORMW %ANAME(MASTER)%の顔を自慢のバストで抱き包みながら、%ANAME(対象)%もまた眠りについた……
			CALL FUCK_MAKELOVE(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の唇", ANAME(MASTER))
			CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣")
			CFLAG:対象:好感度 += 700
			CFLAG:対象:支配度 += 300
			ABL:対象:主導度Ｕ += 500
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が500上がった", 0x00FFFF)
			CALL COLOR_PRINTL(@"%ANAME(対象)%の支配度が300上がった", 0x00FFFF)
			PRINTFORML 
		ENDIF
	;晩酌ルート
	CASE 1
		PRINTFORMW とある日の夜
		PRINTFORML そろそろ眠ろうかと思っていたところに、%ANAME(対象)%がお酒持参で%ANAME(MASTER)%の部屋を訪ねてきた
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「%ANAME(MASTER)%、まだ起きてます？」
				PRINTFORMW 「今日は妙に寝付けなくて……。良ければ、少し晩酌に付き合ってくれませんか？」
			CASE 1
				PRINTFORMW 「良いものを見つけまして、宜しければご一緒にどうですか？」
			CASE 2
				PRINTFORMW 「ちょっと一緒に飲みませんこと？　いいお酒を見つけましたの♪」
		ENDSELECT
		PRINTFORMW %ANAME(対象)%は持ってきた酒を%ANAME(MASTER)%に見せ、晩酌に付き合ってくれないかと提案してきた
		PRINTFORMW さて、どうしよう……
		PRINTFORML
		CALL ASK_YN("晩酌に付き合う", "断る")
		IF RESULT == 1
			PRINTFORML
			PRINTFORML 「えー、付き合ってくれないんですの？　はあ、寂しいわ～、ヨヨヨ……」
			PRINTFORMW  %ANAME(対象)%は芝居がかった様子で目元を押さえながら帰っていった……
		ELSE
			PRINTFORML
			PRINTFORMW 寝る前に駆けつけ一杯というのもいいだろう。%ANAME(MASTER)%は%ANAME(対象)%を部屋に招きいれた
			PRINTFORML 「うふふ、それじゃあお邪魔しますわ♪」
			PRINTFORMW …
			PRINTFORMW %ANAME(対象)%が持参した酒は本当に美味しく、話し上手な彼女との晩酌は大いに盛り上がった
			PRINTFORMW おしゃべりしながらチビチビ飲んでいると、酔いも回って良い気分になってきた
			PRINTFORMW これはとても良く眠れそうだ
			PRINTFORMW 「ふう……%ANAME(MASTER)%と一緒だと、ちょっと飲み過ぎてしまいます♪　少し火照ってきましたわ」
			PRINTFORML %ANAME(対象)%はぱたぱたと手で扇ぎ、少し汗が滲む胸元に風を送る
			PRINTFORMW 酒の火照りが、彼女の玉のように白い肌をほんのりと朱に染め、とても艶っぽく見せる……
			CALL ASK_YN("襲っちゃう", "このまま眠る")
			IF RESULT == 1
				PRINTFORML
```
