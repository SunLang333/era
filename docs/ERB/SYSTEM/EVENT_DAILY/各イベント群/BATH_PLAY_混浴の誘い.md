# SYSTEM/EVENT_DAILY/各イベント群/BATH_PLAY_混浴の誘い.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/BATH_PLAY_混浴の誘い.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_BATH_PLAY_RATE, EVENT_DAILY_BATH_PLAY_DECISION, EVENT_DAILY_BATH_PLAY_GENRE, EVENT_DAILY_BATH_PLAY_SETTARGET, SELECT_CHARA_RANDOM_LOGIC_DAILY_BATH_PLAY, EVENT_DAILY_BATH_PLAY; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_BATH_PLAY_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_BATH_PLAY_DECISION()
RETURN DAY >= 10

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_BATH_PLAY_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_BATH_PLAY_SETTARGET()

CALL SELECT_CHARA_RANDOM("DAILY_BATH_PLAY")

SIF RESULT == -1
	RETURN 0

DAILY_TARGET:0 = RESULT

RETURN 1

@SELECT_CHARA_RANDOM_LOGIC_DAILY_BATH_PLAY(対象)
#DIM 対象
;あなたが男
SIF 対象 == MASTER
	RETURN 0
IF IS_MALE(MASTER)
	;女キャラ、かつ自国所属かつ捕虜でない、かつ「服従」or「恋慕＆貞操無頓着or解放or合意」or「恋人」or「性知識0」持ち、かつ動物でない
	{
		RETURN IS_FEMALE(対象) && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !CFLAG:対象:捕虜先 
			&& (IS_SLAVE(対象) || (IS_LOVER(対象) && (TALENT:対象:貞操無頓着 || TALENT:対象:解放 || TALENT:対象:合意)) || TALENT:対象:恋人 == 1 || ABL:対象:性知識 == 0)
			&& !IS_ANIMAL(対象) && CFLAG:対象:面識 && CFLAG:対象:行動不能状態 != 行動不能_子供
	}
;あなたが女ふたなり
ELSEIF HAS_PENIS(MASTER)
		;女キャラ、かつ自国所属かつ捕虜でない、かつ「服従」or「恋慕＆貞操無頓着or解放or合意」or「恋人」or「性知識0」持ち、かつ動物でない
	IF IS_FEMALE(対象) && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !CFLAG:対象:捕虜先 && (IS_SLAVE(対象) || (IS_LOVER(対象) && (TALENT:対象:貞操無頓着 || TALENT:対象:解放 || TALENT:対象:合意)) || TALENT:対象:恋人 == 1 || ABL:対象:性知識 == 0) && !IS_ANIMAL(対象) && CFLAG:対象:面識 && CFLAG:対象:行動不能状態 != 行動不能_子供
		RETURN 1
	;男キャラ、かつ自国所属かつ捕虜でない、かつ性知識有り、かつ面識があり、かつ動物でない
	ELSEIF IS_MALE(対象) && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !CFLAG:対象:捕虜先 && ABL:対象:性知識 > 0 && CFLAG:対象:面識 == 1 && !IS_ANIMAL(対象) && CFLAG:対象:面識 && CFLAG:対象:行動不能状態 != 行動不能_子供
		RETURN 1
	ENDIF
ELSE
	IF IS_MALE(対象) && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !CFLAG:対象:捕虜先 && ABL:対象:性知識 > 0 && CFLAG:対象:面識 == 1 && !IS_ANIMAL(対象) && CFLAG:対象:面識 && CFLAG:対象:行動不能状態 != 行動不能_子供
		RETURN 1
	ENDIF
ENDIF

RETURN 0




;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_BATH_PLAY()
#DIM 対象


対象 = DAILY_TARGET:0

IF IS_FEMALE(対象)
	PRINTFORML 深夜、自室で仕事をしているとドアをノックする音がした
	PRINTFORML こんな時分に誰だろうかと思いながら出てみると、洗面用具を脇に抱えた%ANAME(対象)%が立っていた
	IF ABL:対象:性知識 > 0
		PRINTFORML 心なしか頬を染めながら、もじもじとやや恥ずかしそうにしている
		PRINTFORMW 何の用かと訪ねると、やや口ごもりながら一緒にお風呂に入らないかと誘ってきた
	ELSE
		PRINTFORML %ANAME(MASTER)%を見た彼女は笑顔を見せて手を振ってきた
		PRINTFORMW 何の用かと訊ねると、一緒にお風呂に入らないかと無邪気に誘ってきた
	ENDIF
	PRINTFORML どうしよう？
	CALL ASK_YN("ご一緒する", "遠慮する")
	IF RESULT == 1
		PRINTFORML 申し訳ないが、まだ仕事がある
		PRINTFORMW 断ると%ANAME(対象)%は残念そうに去っていった
		RETURN 1
	ELSE
		PRINTFORML せっかくのお誘いだ、ご一緒させてもらうことにしよう
		PRINTFORMW %ANAME(MASTER)%が了承すると、%ANAME(対象)%は嬉しそうに笑った
		PRINTFORML 
	ENDIF
	PRINTFORML 深夜なこともあって大浴場には誰もおらず、貸し切り状態だった
	PRINTFORML 普段よりも広く感じる浴場に%ANAME(MASTER)%と%ANAME(対象)%はなんとなくテンションが上がる
	PRINTFORMW 彼女とお互いの背中を洗いっこした後、一緒に浴槽につかった
	PRINTFORML 普段の疲れを流す様にゆっくりと湯につかりながら%ANAME(対象)%と会話をする
	PRINTFORML 入浴中だからかお互いに普段より開放的になり、いつもはできない話もできて話は弾んだ
	PRINTFORMW ふと会話中に彼女のタオル越しにもわかる女らしい体のラインが目にとまり、ムラッとしてしまう
	PRINTFORML どうしよう？
	CALL ASK_YN("悪戯する", "我慢する")
	IF RESULT == 1
		PRINTFORML この雰囲気を壊したくない
		PRINTFORML %ANAME(MASTER)%は膨れそうになる息子をなんとか抑え込んだ
		PRINTFORMW …%ANAME(対象)%とのんびりお風呂を楽しんだ
		CFLAG:対象:好感度 += 200
		CALL PRINT_ADD_EXP(対象, "露出経験値", RAND:10 + 1, 1)
		CALL TRAIN_AUTO_ABLUP(対象)
	ELSE
		PRINTFORML 我慢できず悪戯することにした
		PRINTFORML %ANAME(MASTER)%はさりげなく体を寄せると、そっと%ANAME(対象)%の太ももを撫でた
		IF ABL:対象:性知識 == 0
			PRINTFORML 彼女はきょとんとした表情で%ANAME(MASTER)%を見上げてくる
			PRINTFORML %ANAME(MASTER)%はその無垢な瞳に一瞬罪悪感を抱いたが、我慢できずに彼女の身体を抱き寄せた
			PRINTFORMW %ANAME(対象)%は戸惑いを見せながらも抵抗せずに%ANAME(MASTER)%に身を委ねた
			PRINTFORML 柔らかい肌に手を這わせると、彼女はくすぐったそうに身をよじって小さく笑い声を上げた
			PRINTFORML しばらく指と舌で愛撫していると、次第に彼女の頬が染まり始めて喘ぎ声を漏らしだした
			PRINTFORML %ANAME(MASTER)%は熱と愛撫でとろんとした表情の彼女の身体を抱き上げ、割れ目をペニスにあてがう
			PRINTFORMW 性知識のない%ANAME(対象)%は不安そうに%ANAME(MASTER)%に抱き着いてきて、心臓が早鐘の様に打つのが伝わってきた
			PRINTFORML %ANAME(MASTER)%は彼女を安心させるために優しくキスをして、頭を撫でてやる
			PRINTFORML 唇を離すと彼女は先ほどよりさらに熱っぽい表情で瞳に小さな♥を浮かべながら%ANAME(MASTER)%を見つめてきた
			PRINTFORML そんな%ANAME(対象)%をしっかりと抱きしめながら、綺麗なピンクの割れ目にペニスを挿入した
			PRINTFORMW その衝撃と痛みに彼女は風呂場中に響くような悲鳴を上げながらぎゅうっと%ANAME(MASTER)%にしがみついてきた
			PRINTFORML %ANAME(MASTER)%は彼女を気遣い、体をほぐす様に全身を愛撫しながらゆっくりと奥へとペニスをねじ込んでいく
			PRINTFORML きつきつの膣の奥へと侵入していく度に彼女は体を震わせ、より強く%ANAME(MASTER)%にしがみついてくる
			PRINTFORML やがてペニスを根元までねじ込むと、%ANAME(対象)%は大きく息を吐いてぶるっと身震いした
			PRINTFORMW %ANAME(MASTER)%はしばらく腰の動きを止め、涙を流しながら震える彼女を抱きしめて頭を撫でてやる
			PRINTFORML やがて膣肉が馴染んできたのを感じた%ANAME(MASTER)%は、彼女の腰を掴みながら軽く腰を突き上げた
			PRINTFORML すると彼女はビクンと体を跳ねあげて、喉から可愛い喘ぎ声を漏らした
			PRINTFORML %ANAME(対象)%は蕩けたような表情で未知の快感に頭をボーっとさせながら%ANAME(MASTER)%を見つめてくる
			PRINTFORMW そんな彼女に快楽を教え込む様に%ANAME(MASTER)%は優しく腰を振りはじめた
			PRINTFORMW 間をおかず、風呂場から水の跳ねる音と%ANAME(対象)%の嬌声が響きだした
			ABL:対象:性知識 = 1
		ELSE
			PRINTFORML 彼女は悪戯っぽく笑い、かすかに身をよじらせたが抵抗はしなかった
			PRINTFORML その反応を見た%ANAME(MASTER)%は彼女の肩を抱いてグイッと抱き寄せた
			PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の胸板に寄り添いながら熱っぽい視線で見上げてくる
			PRINTFORML 彼女と見つめ合いながらゆっくりと顔を近づけ、柔らかそうな唇をそっと塞いだ
			PRINTFORML %ANAME(対象)%の身体を優しく愛撫しながら音を立てて唇に吸いつくと、彼女は小さく身震いする
			PRINTFORML 口内に舌を差し込むと彼女は一瞬硬直したが、すぐに受け入れて舌を絡ませてきた
			PRINTFORMW しばし二人で抱き合い絡み合うようにしながら互いの唇を夢中で貪りあった
			PRINTFORML 一息つくために唇を離すと、%ANAME(対象)%は熱と快楽でとろんとした表情で息を荒げていた
			PRINTFORML 頬を優しくなでてやると彼女は目を細めて喉から小さく甘える様な喘ぎ声を漏らす
			PRINTFORMW その色っぽさに我慢できなくなった%ANAME(MASTER)%は彼女に浴槽縁に手をつかせて四つん這いの姿勢をさせた
			PRINTFORML お尻を突き出す様な格好に、%ANAME(対象)%は恥ずかしそうに頬を染めて吐息を漏らしながら%ANAME(MASTER)%を振り返る
			PRINTFORML ツツッと割れ目をなぞると愛撫と熱とですっかりとろとろになっており、身震いと共に「あんっ！」と嬌声が響いた
			PRINTFORMW だらしなく震える%ANAME(対象)%の身体を支える様に腰を掴み、ペニスを割れ目に押し当てゆっくりとねじ込んでいった
			IF TALENT:対象:処女 == 1
				PRINTFORML その痛みに%ANAME(対象)%は呻き声を上げ、ガクガクと腕を震わせながらなんとか堪えている
				PRINTFORML %ANAME(MASTER)%は彼女を気遣い、体をほぐす様に全身を愛撫しながらゆっくりと腰を沈めていく
				PRINTFORMW きつきつの膣内に侵入していくたびに彼女は体を震わせ、喉から絞り出すように呻き声を漏らす
				PRINTFORML ぎゅうっと%ANAME(MASTER)%のペニスを締め付けてくる膣肉に、思い切り腰を動かしたい衝動をぐっとこらえる
				PRINTFORML そして膣奥までたどり着き、子宮を小突くと%ANAME(対象)%は大きく息を吐いてぶるっと身震いした
				PRINTFORML %ANAME(MASTER)%はしばらく腰を止め、涙を流しながら震える%ANAME(対象)%の頭を撫でてキスをしてやる
				PRINTFORMW やがて彼女の膣肉がとろけ出したのを確認した%ANAME(MASTER)%は、ゆっくりと腰を動かし始めた
			ELSE
				PRINTFORML するとすっかり出来上がっていた%ANAME(対象)%はそれだけで達した様に大きく身を仰け反らせた
				PRINTFORML 彼女の絶頂に合わせて膣肉が締めあがり、ペニスを刺激されて思わず射精しそうになるのを堪える
				PRINTFORML ずぷずぷとゆっくりとペニスをねじ込んでいくと、彼女は喉を震わせてあられもない嬌声を漏らす
				PRINTFORMW やがて膣奥までたどり着き、子宮を小突くと%ANAME(対象)%は一際大きな嬌声と共に体を痙攣させた
			ENDIF
			PRINTFORML とろとろのまん肉を味わう様に腰を前後させると、思わず腰が砕けそうな快楽が伝わってくる
			PRINTFORML 天井をこする様にペニスを押し付けると、彼女はゾクゾクと背筋を震わせてそれに合わせて膣肉が痙攣した
			PRINTFORML 精液を搾り取ろうと絡みついてくる膣肉の脈動に我慢できず、徐々に腰の動きを速めていく
			PRINTFORMW しばし夢中で腰を打ち付け、浴場に肉の打ち合う音と水の跳ねる音、そして%ANAME(対象)%の嬌声だけが響き続けた
			PRINTFORMW やがて限界を迎えた%ANAME(MASTER)%は、一際深く腰を打ち込み、彼女の子宮口に亀頭を密着させながら思い切り射精した
			PRINTFORML %ANAME(対象)%は大きく背中をのけぞらせながら浴場の外まで響くような大きな嬌声を上げてガクガクと体を震わせる
			PRINTFORML 一滴残らず搾り取る様な膣の動きに%ANAME(MASTER)%は呻き声を上げながら射精を続け、それに合わせて彼女もヨガった
			PRINTFORMW 射精を終えた%ANAME(MASTER)%が大きく息をついてペニスを引き抜くと、彼女の秘所からどろりと大量の白濁液が溢れ出た
			PRINTFORML %ANAME(対象)%はくたっと浴槽の縁に倒れ込んでぜーぜーと荒く息を吐きながら恍惚の表情を見せていた
			PRINTFORML その表情にまたムラムラしてきた%ANAME(MASTER)%は、彼女の腕をつかむと今度は自らの上に跨らせるように抱きあげる
			PRINTFORML 対面座位の姿勢で%ANAME(対象)%の腰を掴むと、彼女は%ANAME(MASTER)%の首に手を回して熱っぽい視線で見つめてきた
			PRINTFORMW %ANAME(対象)%と見つめ合いながらキスをして、再びゆっくりとペニスを彼女の中へと沈めていった
		ENDIF
		CALL FUCK_MAKELOVE(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の唇", ANAME(MASTER))
		CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣")
		PRINTFORMW  
		PRINTFORML %ANAME(対象)%の可愛らしい反応に夢中になってしまい、のぼせるまでセックスを続けてしまった
		PRINTFORML %ANAME(MASTER)%はくてっと力なく倒れ込んだ彼女を抱きかかえてふらつきながらも部屋に運んだ
		PRINTFORML 着替えさせてベッドに横たえると、%ANAME(対象)%はかすかに目を開き、嬉しそうに頬を緩ませて見つめてきた
;		PRINTFORML 「えへ…また一緒にお風呂、入ろうね…？」
		PRINTFORMW %ANAME(MASTER)%は返事の代わりにキスをしてから毛布をかけて、部屋を後にした
		CFLAG:対象:好感度 += 200
		CALL PRINT_ADD_EXP(対象, "露出経験値", RAND:10 + 1, 1)
		CALL TRAIN_AUTO_ABLUP(対象)
	ENDIF
ELSE
	PRINTFORML 深夜、自室で仕事をしているとドアをノックする音がした
	PRINTFORML こんな時分に誰だろうかと思いながら出てみると、洗面用具を脇に抱えた%ANAME(対象)%が立っていた
	PRINTFORMW %ANAME(MASTER)%を見た彼は笑顔を見せて一緒に風呂に入らないかと誘ってきた
```
