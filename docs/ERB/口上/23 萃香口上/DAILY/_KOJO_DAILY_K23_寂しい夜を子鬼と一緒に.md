# 口上/23 萃香口上/DAILY/_KOJO_DAILY_K23_寂しい夜を子鬼と一緒に.ERB — 自动生成文档

源文件: `ERB/口上/23 萃香口上/DAILY/_KOJO_DAILY_K23_寂しい夜を子鬼と一緒に.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K23_LONELY_NIGHT_RATE, KOJO_DAILY_K23_LONELY_NIGHT_DECISION, KOJO_DAILY_K23_LONELY_NIGHT_GENRE, KOJO_DAILY_K23_LONELY_NIGHT; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K23_LONELY_NIGHT_RATE(対象)
#DIM 対象
RETURN 50


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K23_LONELY_NIGHT_DECISION(対象)
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
@KOJO_DAILY_K23_LONELY_NIGHT_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K23_LONELY_NIGHT(対象)
#DIM 対象

PRINTFORML ･･･
SELECTCASE RAND:3
	;添い寝ルート（角の事は忘れろ。そうすればお前はもっと強くなれる）
	CASE 0
		PRINTFORMW 深夜
		PRINTFORML 無性に肌寂しい夜だった
		PRINTFORMW 妙に寝付けなくてどうしようかと思っていた夜に、%ANAME(MASTER)%の部屋を訪れる影が一つ…
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「%ANAME(MASTER)%、まだ起きてるかい？」
				PRINTFORMW 「私も寝付けなくってさー。……添い寝とか、してあげようか？」
			CASE 1
				PRINTFORMW 「なんか今日、肌寒くない？　一緒に寝て暖めてあげるよ♪」
			CASE 2
				PRINTFORMW 「なんか寝苦しくてさ…。%ANAME(MASTER)%と一緒なら寝れるかなーって」
		ENDSELECT
		PRINTFORML タイミングよく現れた%ANAME(対象)%は、%ANAME(MASTER)%に、一緒に寝たいと言ってきた
		PRINTFORMW さて、どうしよう……
		PRINTFORML
		CALL ASK_YN("一緒に寝る", "断る")
		IF RESULT == 1
			PRINTFORML
			PRINTFORML 「ありゃー、残念。まあ、しょうがない。一人寂しく寝るとするよ……」
			PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%に手を振ってとぼとぼと帰っていった……
		ELSE
			PRINTFORML
			PRINTFORMW ちょうど人肌恋しい夜だ。断る理由も無いので部屋に招きいれた
			PRINTFORML 「ふへへー。それじゃあ、お邪魔しますよっと♪」
			PRINTFORMW 寝巻きに着替えて、冷えた布団の中に二人で潜り込む
			PRINTFORMW 「…んふふ♪　何だかドキドキしちゃうな。私の身体、温かいか？」
			PRINTFORML …ちっちゃいからか、とても温かい
			PRINTFORMW いわゆる子ども体温とでも言おうか。……口に出すと怒られそうなので、ぎゅっと抱きしめることで答える
			PRINTFORMW 「ふふ…私も温かいよ…。たまにはこういうのもいいもんだねぇ♪」
			PRINTFORML %ANAME(対象)%もぎゅっと抱きついてくる
			PRINTFORMW 彼女のすべすべぷにぷにの柔肌を押し付けられて、ちょっとイケない気持ちが鎌首をもたげ始める…
			CALL ASK_YN("襲っちゃう", "このまま一緒に眠る")
			IF RESULT == 1
				PRINTFORML
				PRINTFORML ……いや、この温かい雰囲気を壊したくない
				PRINTFORMW %ANAME(MASTER)%はこのまま、%ANAME(対象)%と抱き合って眠ることにした
				PRINTFORML 「ふふ…%ANAME(MASTER)%の匂いに包まれてると、なんか安心するよ……」
				PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の胸板に顔を埋めて、実に緩んだ顔で幸せそうにしている
				PRINTFORML %ANAME(MASTER)%もまた%ANAME(対象)%の頭を撫でながら目を閉じる
				PRINTFORMW ほんのり香る酒の匂いと%ANAME(対象)%の髪のいい匂いが混ざり、%ANAME(MASTER)%の心を落ち着かせていく…
				PRINTFORMW 「ふあ～……ふふ、私も眠くなってきたよ。%ANAME(MASTER)%……お休み、ちゅっ…」
				PRINTFORML 二人は、互いの頬にお休みのキスをして眠りについた
				PRINTFORMW お互いの体温と、仄かに聞こえる心音が子守唄となって二人とも幸せな気分で眠りについた……
				PRINTFORML
				CFLAG:対象:好感度 += 500
				CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が500上がった", カラー_シアン)
				RETURN
			ENDIF
			PRINTFORML
			PRINTFORMW ……人肌恋しい夜だから。%ANAME(MASTER)%は抱き合う%ANAME(対象)%の衣服の中にまで手を伸ばす
			PRINTFORML 「あっ…♥　もう、助平なんだからぁ♥」
			PRINTFORMW その声に抗議の色はなく、%ANAME(対象)%は抵抗もせず%ANAME(MASTER)%のまさぐりに身を任せている
			PRINTFORML 「寂しかったんなら…もっと触ってもいいよ…♥」
			PRINTFORMW %ANAME(対象)%の許しも出て、より大胆に彼女の温かくすべすべの肌を堪能する
			PRINTFORML そうしているうちに、下半身に張ったテントを%ANAME(対象)%に掴まれる
			PRINTFORMW 「それじゃあ私には…この熱いのをもらって温まろうかな…♥」
			PRINTFORML すでに勃起したペニスを取り出し、%ANAME(対象)%は物欲しそうな目を%ANAME(MASTER)%に向ける
			PRINTFORMW お望みどおりの方法で二人共々汗をかくほど温まることにした
			PRINTFORML
			PRINTFORMW ……
			SELECTCASE RAND:4
				CASE 0
					PRINTFORMW %ANAME(対象)%と布団の中で抱き締め合いながら、互いに温め合うようなゆっくりとしたペースで愛し合った
					PRINTFORML いつもより意識的に肌をすり合わせているせいか、お互いにいつもより敏感になっているように感じる
					PRINTFORMW ペニスで膣壁をぐりぐりと擦り上げると、%ANAME(対象)%はたまらない様子で%ANAME(MASTER)%の耳元に熱い吐息を漏らす
					PRINTFORMW 「ああっ、%ANAME(MASTER)%♥　いいよっ、キモチっ、いいよぉ♥」
					PRINTFORML 少しずつペースを早めていくと%ANAME(対象)%も断続的に甘い声を上げ、きゅんきゅんとペニスを締め付けてくる
					PRINTFORMW 高まる絶頂の気配に、%ANAME(対象)%はより強く%ANAME(MASTER)%を抱きしめ、放さないようにしている
					PRINTFORML %ANAME(MASTER)%もまた、がっしりと%ANAME(対象)%の腰を掴んで膣奥にペニスを固定する
					PRINTFORML 「あっ！　ああっ♥　%ANAME(MASTER)%っ♥　もうっ…イクぅッ♥♥」
					PRINTFORMW そしてついに大量に精を放つ。子宮を満たす命の熱を感じ、彼女は%ANAME(MASTER)%の名を上げて絶頂した……
				CASE 1
					PRINTFORMW %ANAME(対象)%は布団を羽織ながら%ANAME(MASTER)%に跨り、キスの雨を振らせながら自分から腰を振っている
					PRINTFORML ぱちゅっぱちゅっ、と接合部が触れ合う卑猥な音が二人の興奮を高めていく
					PRINTFORMW 「あっ♥　んんっ、どうだい、%ANAME(MASTER)%♥　私の中っ、キモチいいかい？　あっ♥」
					PRINTFORML %ANAME(対象)%は蜜壷を抉る快感に喘ぎながらも、%ANAME(MASTER)%に気持ち良くなってもらうため柔肉で献身的に奉仕している
					PRINTFORMW %ANAME(MASTER)%はそんな%ANAME(対象)%に愛おしさを感じながら、%ANAME(対象)%の桃尻の吸い付くような揉み心地を楽しんだ
					PRINTFORML 「あっ！　ああっ♥　%ANAME(MASTER)%っ♥　もうっ…イっちゃうよぉッ♥♥」
					PRINTFORMW 射精の瞬間、子宮口まで思い切り突き上げると、%ANAME(対象)%は%ANAME(MASTER)%の名を呼びながら背中を反らして絶頂した……
				CASE 2
					PRINTFORML 「はむ…んちゅ……もっとしておくれ♥」
					PRINTFORMW %ANAME(MASTER)%は対面座位の姿勢で%ANAME(対象)%と深く繋がりあっている
					PRINTFORML 蕩けた表情で甘えるように、ぎゅっと抱きつきながらキスをせがむ%ANAME(対象)%
					PRINTFORMW その姿が無性に愛しく思えて、つい耳元で、愛しているよ、と甘い言葉を囁いた
					PRINTFORMW すると、きゅうっ！　とペニスを包む膣肉が切なげに蠢き、子種を求めるように強く締めつけてきた
					PRINTFORML 「……もうっ。そういうの、ズルいぞ…♥」
					PRINTFORMW %ANAME(対象)%は耳まで赤くしながらもまんざらではない様子で、もっと言ってくれとねだる
					PRINTFORML %ANAME(MASTER)%はお望みどおり、腰を揺すりながら耳元で愛の言葉を囁き続け、可愛らしくうねる膣肉を堪能する
					PRINTFORMW 限界を迎え、腰に脚を絡めてきた%ANAME(対象)%に%ANAME(MASTER)%は熱いキスで応じ、子宮口を捉えたまま盛大に射精した……
				CASE 3
					PRINTFORMW 「あむっ…♥…んちゅっ…れろぉ…。ふふ、キモチよさそうにしちゃって♥」
					PRINTFORML %ANAME(対象)%は布団の中に潜り込みながら、%ANAME(MASTER)%のペニスを熱心にしゃぶっている
					PRINTFORMW 小さな少女が布団の中で己の肉棒をしゃぶっている。この背徳的な光景が%ANAME(MASTER)%の情欲を煽る
					PRINTFORML 「あ、ビクビクしてきた♥　ふふ、いつでも出していいからね♥」
					PRINTFORMW そう言うと%ANAME(対象)%は%ANAME(MASTER)%のペニスをよりいっそう深く咥え込む
					PRINTFORMW %ANAME(対象)%の小さな口での強烈なバキュームにより、たやすく限界を迎え、喉奥まで大量に精を放ってしまう
					PRINTFORML 「んぶぅっ！　…ん…♥…んん……こくっ…ごくんっ…ぷはぁっ♥　熱いの、いっぱい…♥」
					PRINTFORMW 「今度はこの熱いやつを…ここに入れて温めておくれ…♥」
					PRINTFORML 彼女は口元に涎と精液を垂らしたまま、%ANAME(MASTER)%の目の前で自らの蕩けきった媚肉を広げてみせる
					PRINTFORMW その淫靡な光景に、出したばかりの肉棒は即座に硬さを取り戻す
					PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%を押し倒し、望みどおりにその秘裂を貫いた……
			ENDSELECT 
			PRINTFORML
			PRINTFORMW ……
			PRINTFORMW 最後の一発を%ANAME(対象)%の膣奥に注ぎ込むと、二人は抱き合ったまま横になった
			PRINTFORML そして互いに息を荒げている%ANAME(対象)%とくすくすと笑い合い、ねっとりと濃厚なキスを交わした
			PRINTFORML 「ん……お休み、%ANAME(MASTER)%……♥」
			PRINTFORMW 心地良い疲労感と温もりに包まれながら、お互いを抱き枕にしてそのまま眠りについた……
			CALL FUCK_MAKELOVE(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の唇", ANAME(MASTER))
			CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣")
			CFLAG:対象:好感度 += 600
			CFLAG:対象:依存度 += 500
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が600上がった", カラー_シアン)
			CALL COLOR_PRINTL(@"%ANAME(対象)%の依存度が500上がった", カラー_シアン)
			PRINTFORML 
		ENDIF
	;晩酌ルート
	CASE 1
		PRINTFORMW 深夜
		PRINTFORML 眠りが浅く、中途半端な時間に目覚めてしまった
		PRINTFORMW 寝付けなくてどうしようかと思っていたところに、%ANAME(MASTER)%の部屋を訪れる影が一つ…
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「%ANAME(MASTER)%、まだ起きてるかい？」
				PRINTFORMW 「私も寝付けなくってさー…良かったら、ちょっと飲まない？」
			CASE 1
				PRINTFORMW 「寝る前に一杯どうだい？　気持ちよく寝付けるよ、きっと♪」
			CASE 2
				PRINTFORMW 「起きてるなら一緒に飲まないかい？　いい酒見つけたんだー♪」
		ENDSELECT
		PRINTFORMW %ANAME(対象)%は持ってきた酒瓶を%ANAME(MASTER)%に見せ、一緒に飲まないかと誘ってきた
		PRINTFORMW さて、どうしよう……
		PRINTFORML
		CALL ASK_YN("晩酌に付き合う", "断る")
		IF RESULT == 1
			PRINTFORML
			PRINTFORML 「えー、付き合ってくれないの？　はあ…、しょうがない。一人寂しく飲むとするよ……」
			PRINTFORMW %ANAME(対象)%はがっくりきた様子で寂しそうに帰っていった……
		ELSE
			PRINTFORML
			PRINTFORMW ちょうど眠れなかったところだ。断る理由も無いので部屋に招きいれた
			PRINTFORML 「やったねー♪　それじゃあ、お邪魔しますよっと♪」
			PRINTFORMW …
			PRINTFORMW %ANAME(対象)%との深夜の晩酌はとても盛り上がった
			PRINTFORML 彼女が持ってきた酒は実に美味かった。口当たりは軽く、するすると喉を通る爽やかさがあった
			PRINTFORMW お酒と肴を一通り楽しんだら、酔いも回って良い気分になってきた
			PRINTFORML これなら良く眠れそうだ
			PRINTFORMW 「ふう…飲み過ぎちゃったかい？　いっそこのまま一緒に寝ちゃう？　なんてね♪」
			PRINTFORML ふと%ANAME(対象)%を見やる
			PRINTFORMW 無造作にはだけられたブラウスから覗く胸元のきめ細かい肌が、ほんのり桜色づいてとても色っぽい……
			CALL ASK_YN("酔いに任せて襲っちゃう", "このまま一緒に眠る")
```
