# SYSTEM/EVENT_DAILY/各イベント群/TUTOR_家庭教師.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/TUTOR_家庭教師.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_TUTOR_RATE, EVENT_DAILY_TUTOR_DECISION, EVENT_DAILY_TUTOR_GENRE, EVENT_DAILY_TUTOR, TUTOR_COURSE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_TUTOR_RATE()
RETURN (DVAR:家庭教師_お気に入りID > 0 ? 250 # 20)


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_TUTOR_DECISION()
#DIM 対象
SIF DVAR:家庭教師_発生フラグ == -1
	RETURN 0

IF DVAR:家庭教師_授業実施回数 > 0
	対象 = ID_TO_CHARA(DVAR:家庭教師_お気に入りID)
	IF 対象 == -1
		DVAR:家庭教師_逢瀬フラグ = 0
		DVAR:家庭教師_お気に入りID = 0
		RETURN 0
	ELSEIF CFLAG:対象:捕虜先 || CFLAG:対象:所属 != CFLAG:MASTER:所属
		RETURN 0
	ENDIF
ENDIF
RETURN 15 <= DAY

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_TUTOR_GENRE()
RETURN デイリー_ジャンル_エロ



;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_TUTOR()
#DIM 対象

IF DVAR:家庭教師_逢瀬フラグ == 1
	対象 = ID_TO_CHARA(DVAR:家庭教師_お気に入りID)
	PRINTFORMW 貴族の娘と逢引をした…
	PRINTFORML 
	SELECTCASE RAND:10
		CASE 0
			PRINTFORML 彼女が%ANAME(対象)%に跨り、髪を振り乱しながら激しく腰を振っている
			PRINTFORML 腰が上下する度にペニス全体を膣肉で扱かれ、心地よい快楽が与えられる
			PRINTFORML 次第に彼女の息が荒くなると膣壁が収縮しだし、絶頂が近づいているのが伝わってくる
			PRINTFORML やがて彼女が大きく背を反らし絶頂すると共に、膣肉が痙攣しながらぎゅうっと締まると
			PRINTFORMW %ANAME(対象)%も限界に達し、腰を突き上げて彼女の奥深くへとペニスをねじ込み射精した
		CASE 1
			PRINTFORML 彼女を四つん這いにさせてぱん！ぱん！と背後から腰を打ちつける
			PRINTFORML %ANAME(対象)%の一突き毎に彼女は身を震わせて可愛く鳴き、膣壁を締め付けてくる
			PRINTFORML 普段の彼女からは想像できないその色っぽい声に、夢中になって腰を振る
			PRINTFORML 快楽で力が入らなくなった彼女はくたっと倒れ込んでひたすら甘い声を出すだけになる
			PRINTFORMW 彼女に覆いかぶさりながら膣内射精すると、彼女は一際大きな嬌声と共に絶頂した
		CASE 2
			PRINTFORML 何度かの交わりの後、%ANAME(対象)%は彼女と繋がったままベッドに倒れ込む
			PRINTFORML 二人して息を荒げ、身を寄せ合いながらしばし心地よい絶頂の余韻に浸る
			PRINTFORML しばし寝ころびながら彼女と他愛無い会話を交わすだけの甘い時間が流れる
			IF IS_MALE(対象)
				PRINTFORML やがて彼女が無言で%ANAME(対象)%を見上げてつつっと指先で胸板をなぞってきた
			ELSE
				PRINTFORML やがて彼女が無言で%ANAME(対象)%を見上げて掌でふわりと頬に触れてきた
			ENDIF
			PRINTFORMW %ANAME(対象)%もそれに応えて優しくキスをしてやり、再びまぐわいを開始した
		CASE 3
			PRINTFORML 正常位の格好で彼女に覆いかぶさりながらゆったりと腰を振っている
			PRINTFORML 彼女はシーツを掴みながら艶めかしく体をくねらせて快楽に浸っている
			PRINTFORML その淫靡な表情に%ANAME(対象)%の剛直はますます固くなり、ぐりぐりと彼女の膣内を刺激してやる
			PRINTFORML すると彼女はたまらないと言った声で鳴き、ぶるぶると身体を震わせた
			PRINTFORMW 彼女の反応を楽しみながらゆっくりとしたセックスを楽しんだ
		CASE 4
			PRINTFORML 彼女が口で熱心に%ANAME(対象)%のペニスを咥えこみ奉仕している
			PRINTFORML 顔を前後させる度にじゅぷじゅぷと卑猥な音が漏れ、心地よさに思わずうめき声が漏れてしまう
			PRINTFORML それに気を良くした彼女はさらに指や舌も使い熱心にペニス全体を攻め出す
			PRINTFORML やがて我慢の限界に達して口内に射精すると、彼女はえづきながらもすべてを飲み干した
			PRINTFORMW 熱心な奉仕のご褒美に押し倒して犯してやると、彼女は恍惚と言った表情で身を震わせた
		CASE 5
			PRINTFORML 彼女をペニスの上に跨らせながら、背後から抱きしめ胸を揉みしだくと切なげな吐息が漏れる
			PRINTFORML 乳首をこねくり回しながらうなじに舌を這わせると彼女はゾクゾクと全身を震わせる
			PRINTFORML %ANAME(対象)%の愛撫に身をゆだねながら、彼女は腰をくねらせペニスに心地よい刺激を与えてくる
			PRINTFORML やがて彼女は惚けきった表情で甘える様な声であなたの名前を呼びながら膣をキュッと締め上げてきた
			PRINTFORMW %ANAME(対象)%もまた我慢できなくなり、彼女をぎゅっと抱きしめながら膣奥へと精液を解き放った
		CASE 6
			PRINTFORML 四つん這いの彼女に覆いかぶさる格好で激しく腰を打ちつけてやる
			PRINTFORML すると彼女はだらしなく舌を垂らしながらたまらないと言った声を上げて悦ぶ
			PRINTFORML ペニスを膣壁に擦り付ける度に強烈な快楽が押し寄せ、腰が止まらなくなってしまう
			PRINTFORML 身体を密着させ舌を絡ませながら獣の交尾の様に激しく交わっていると蕩ける様な感覚に陥る
			PRINTFORMW 結局お互いが疲れ果てるまで延々と腰を打ちつけ合い、何度も彼女の中に精を放った
		CASE 7
			PRINTFORML 対面座位の姿勢で彼女と向かい合い、ちゅっちゅと小さくキスをしている
			PRINTFORML 彼女は%ANAME(対象)%の首に手を回して幸せそうに笑いながらこちらを見つめ、時折腰を揺らしている
			PRINTFORML 彼女の表情と下半身に与えられる刺激に我慢できなくなり、舌を絡ませながら円を描くように腰を動かす
			PRINTFORML すると彼女は小さく喘ぎビクビクと身体を震わせ、%ANAME(対象)%に甘える様に体を預けてきた
			PRINTFORMW 彼女を強く抱きしめゆったりと腰を動かしながら濃厚で蕩ける様なセックスを存分に堪能した
		CASE 8
			PRINTFORML %ANAME(対象)%は既に何度も絶頂している彼女にのしかかり激しく腰を打ちつけている
			PRINTFORML 涙目で「死んでしまいます」と許しを請う彼女に対し、膣肉はきつく肉棒を締め付け離そうとしない
			PRINTFORML %ANAME(対象)%は圧倒的な快楽に理性も流され、彼女への気遣いも忘れ夢中で腰を振り続ける
			PRINTFORML やがて我慢の限界に達すると痙攣しっぱなしの彼女の深くへとペニスをねじ込み、思い切り欲望をぶちまけた
			PRINTFORMW 事後、彼女に謝ろうとすると彼女は恍惚の表情で「凄かったです」と呟き抱きついてきた
		CASE 9
			PRINTFORML 彼女が%ANAME(対象)%の上に跨り深々とペニスを咥えこんで腰を揺すっている
			PRINTFORML 腰が揺れる度に彼女の口からは甘い吐息が漏れ、きゅっと膣を締め上げペニスを刺激してくる
			PRINTFORML 彼女は%ANAME(対象)%の様子を窺いながら色んな角度で腰を動かし、より心地よい刺激を与えようとしている
			PRINTFORML 腰を小刻みにクイクイと捻られるとカリ首が膣肉で擦りあげられ、思わずうめき声を漏らしてしまう
			PRINTFORMW すると彼女は嬉しそうに笑い更に腰を動かし、結局何度も彼女の中へ射精させられてしまった
	ENDSELECT
	RETURN 1
ENDIF

;初回
IF DVAR:家庭教師_発生フラグ == 0
	DVAR:家庭教師_お気に入りID = 0
	PRINTFORML 仕事をしていると来客を告げられた
	PRINTFORML 名前を尋ねたところ、領内のとある貴族の使いらしい
	PRINTFORML 貴族と聞いて%ANAME(MASTER)%はため息をつく、どうせ面倒事だろう
	PRINTFORML しかしかなり影響力の大きい相手だ、無下に追い返すわけにもいかない
	PRINTFORMW %ANAME(MASTER)%は渋々と重い腰を上げ、使いと面会する事にした
	PRINTFORML 
	PRINTFORML 「初めまして、%ANAME(MASTER)%様。本日はお日柄もよく…。」
	PRINTFORML 使いの男は仰々しくお辞儀をして、口上を並べ立てる
	PRINTFORMW %ANAME(MASTER)%も同じように挨拶を返し、しばらく他愛無い雑談が続いた
	PRINTFORML 「…さて、本日私がお伺いしたのは、主から言伝を承ったからでして…。」
	PRINTFORMW 遂に来たか、%ANAME(MASTER)%は男の言葉に身構える
	PRINTFORML 「実は主のご息女の家庭教師を、お願いしたく参ったのです。」
	PRINTFORML 『家庭教師？』
	PRINTFORMW あまりに想定外の言葉に、%ANAME(MASTER)%は思わず間抜けな声を発してしまった
	PRINTFORML 「驚かれるのも無理はありません。が、これには色々と込み入った事情がございまして。」
	PRINTFORMW 男は若干渋い顔をしながら淡々と話を続けた
	PRINTFORML 主は一人娘を大変可愛がっており、まさに箱入り娘として育てていた
	PRINTFORML しかし最近、彼女に外の事がもっと知りたいとおねだりをされるようになった
	PRINTFORML なるべく彼女の願いは聞いてあげたいものの、下手に外に出して悪い虫がついてはかなわない
	PRINTFORMW どうしたものかと頭を悩ませた結果、信頼できそうな者ということで我々に頼むことにした、という事らしい
	PRINTFORML 「あなた様方の評判は聞いております、主もそれなら問題ないだろうと。」
	PRINTFORML 「どうか主とお嬢様の為になにとぞよろしくお願いします。」
	PRINTFORML 男は深々と頭を下げる
	PRINTFORML なるほど、話の流れはわかった
	PRINTFORMW 大方これを機に我々とのコネクションを強化したいという思惑もあるのだろう
	DVAR:家庭教師_発生フラグ = 1
;2回目以降、娘のお気に入りがいない場合
ELSEIF DVAR:家庭教師_お気に入りID == 0
	PRINTFORMW 例の貴族の使いが再び訪れた
	PRINTFORMW また家庭教師を頼みたいとのことだ
;2回目以降、娘のお気に入りがいる場合
ELSE
	対象 = ID_TO_CHARA(DVAR:家庭教師_お気に入りID)
	PRINTFORMW 例の貴族の使いが再び訪れた
	PRINTFORMW また家庭教師を頼みたいとのことだ
	PRINTFORMW 娘が%ANAME(対象)%を気に入っているとの事で指名された
	LOCALS = 彼
	SIF IS_FEMALE(対象)
		LOCALS = 彼女
	IF CFLAG:対象:捕虜先 && DVAR:家庭教師_授業実施回数 >= 4
		PRINTFORML しかし%LOCALS%は現在捕虜になっており、派遣できない
		PRINTFORML そう伝えると使いの男は大変慌て、お嬢様に%LOCALS%でなければ嫌だと言われたと告げる
		PRINTFORMW 今回はお嬢様を説得するから、なるべく早く%LOCALS%を連れ戻してほしいと言い立ち去った
		RETURN 1
	ELSEIF CFLAG:対象:捕虜先
		PRINTFORML しかし%LOCALS%は現在捕虜になっており、派遣できない
		PRINTFORML そう伝えると使いの男は慌てたが
		PRINTFORMW なんとかお嬢様には納得してもらうので他の者を頼むと頭を下げられた
		DVAR:家庭教師_お気に入りID = 0
	ENDIF
ENDIF

PRINTFORMW どうするか……
CALL ASK_YN("引き受ける", "断る")
IF RESULT == 1
	PRINTFORML やはり貴族の娘の我儘に付き合ってはいられない
	PRINTFORMW 丁重に断り引き取ってもらった
	DVAR:家庭教師_お気に入りID = 0
	SIF DVAR:家庭教師_授業実施回数 >= 4
		DVAR:家庭教師_発生フラグ = -1
	RETURN 1
ELSE
	IF DVAR:家庭教師_お気に入りID == 0
		PRINTFORML この程度なら大した手間ではないし、恩を売っておくのも良いだろう
		PRINTFORML なによりその箱入り娘とやらにも興味がある、引き受ける事にした
		PRINTFORML 「ありがとうございます。きっとそう言っていただけると思っていました。」
		PRINTFORML 使いの男は再び仰々しく頭を下げる
		PRINTFORMW さて、それでは誰を派遣しよう？
		CALL SINGLE_DRAWLINE
		CALL SELECT_CHARA_LIST_SLG()
		IF RESULT < 0
			PRINTFORML 引き受けたかったがあいにく今は全員忙しかった
			PRINTFORMW 使いの男に謝り、引き取ってもらった
			RETURN 1
		ENDIF
		対象 = RESULT
		IF 対象 == MASTER
```
