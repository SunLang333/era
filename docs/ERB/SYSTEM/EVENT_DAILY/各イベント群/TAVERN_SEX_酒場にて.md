# SYSTEM/EVENT_DAILY/各イベント群/TAVERN_SEX_酒場にて.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/TAVERN_SEX_酒場にて.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_TAVERN_SEX_RATE, EVENT_DAILY_TAVERN_SEX_DECISION, EVENT_DAILY_TAVERN_SEX_GENRE, EVENT_DAILY_TAVERN_SEX; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_TAVERN_SEX_RATE()
RETURN 20


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_TAVERN_SEX_DECISION()
RETURN DAY >= 10

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_TAVERN_SEX_GENRE()
RETURN デイリー_ジャンル_エロ



;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_TAVERN_SEX()
#DIM 対象
#DIM 請求額

PRINTFORMW 領民の声を直接聞くためにお忍びで酒場に行ってみよう
PRINTFORMW 誰に行かせようか？

CALL SINGLE_DRAWLINE
CALL SELECT_CHARA_LIST_SLG()
IF RESULT == -1
	PRINTFORMW やはりやめておこう
	RETURN 1
ENDIF

対象 = RESULT
IF 対象 == MASTER
	PRINTFORMW 自分で行くことにした
ELSE
	PRINTFORMW %ANAME(対象)%に任せる事にした
ENDIF

PRINTFORML 
PRINTFORML 

;酒場に行ったのが男性もしくは
IF IS_MALE(対象)
	PRINTFORML %ANAME(対象)%は酒場で客と意気投合した
	PRINTFORMW 中々有意義なお忍びだった
	;ちょっとお酒に強くなる（肝臓経験値1～5）
	EXP:対象:肝臓経験値 += RAND:3 + RAND:3 + 1
	CALL TRAIN_AUTO_ABLUP(対象, 0)
	;時々請求書が回ってくる、仕方ないね
	IF !RAND:5
		PRINTFORML ……
		PRINTFORML …
		IF 対象 == MASTER
			PRINTFORMW なお、経費で落ちなかった模様
		ELSE
			PRINTFORMW どうしてこっちに請求書が回ってきているのかな？
		ENDIF
		;所持金の3～7%なんて良心的な飲み代です
		請求額 = MONEY * RAND(3, 7) / 100
		PRINTFORMW 仕方ないので、{請求額, 6}を支払った。
		MONEY -= 請求額
	ENDIF
	RETURN 1
ENDIF

PRINTFORMW %ANAME(対象)%は酒場で一人の客と意気投合した
PRINTFORMW すっかり良い気分になり店を出ようとしたところ、男に誘われた
IF TALENT:対象:貞操観念 == 1 || TALENT:対象:恋人 == 1 || TALENT:対象:恋慕 == 1 || HAS_PENIS(対象)
	PRINTFORMW 確かに%ANAME(対象)%は彼に魅力を感じているものの、これ以上はいけないとも思う
	PRINTFORMW 彼女はしばし悩んでいたが…
	CALL ASK_YN("誘いに乗った", "誘いを断った")
	IF RESULT == 1
		PRINTFORMW やがてきっぱりと男の誘いを断った
		PRINTFORMW 男は残念そうにしながらもそれ以上迫ってくることもなく去って行った
		RETURN 1
	ELSE
		PRINTFORMW やがて恥ずかしそうに頬を染めながら、小さく頷いた
		PRINTFORMW 男は嬉しそうに彼女の腰を抱き、二人で寄り添って宿屋へと入って行った
	ENDIF
ELSE
	PRINTFORMW %ANAME(対象)%は照れながらも抵抗せず、恋人の様に抱かれながら宿屋へ入って行った
ENDIF
PRINTFORML 
PRINTFORML 

SELECTCASE RAND:45
	CASE 0
		PRINTFORML %ANAME(対象)%はベッドに寝転がった彼に跨り腰を振っている
		PRINTFORML 腰を上下する度にペニスが%ANAME(対象)%の奥深くを抉り、彼女は嬌声を上げて痙攣する
		PRINTFORML セックスに夢中になっている%ANAME(対象)%は更なる快楽を得ようとみだらな表情で男を誘う
		PRINTFORMW 男もそれに応えて激しく%ANAME(対象)%を突き上げ、二人で夜通し濃厚なセックスを味わった
	CASE 1
		PRINTFORML 彼の胸に手を当て、だらしなく舌を垂らしながら%ANAME(対象)%は腰を振っている
		PRINTFORML 逞しいペニスで膣肉を抉られる度に、%ANAME(対象)%は頭の中が真っ白になるような快楽を受ける
		PRINTFORML ペニスを咥えこんだ雌穴からは愛液がとめどなく溢れ、膣肉は収縮を繰り返し男の子種を待ちわびている
		PRINTFORMW やがて待望の膣内射精を受けながら、%ANAME(対象)%は大きく背中を反らし悦びの声を上げて絶頂した
	CASE 2
		PRINTFORML %ANAME(対象)%は彼に跨りそのペニスを深々と咥えこみながらキスをしている
		PRINTFORML 舌を絡ませながら胸をもみしだかれている%ANAME(対象)%は、快楽でとろけた表情になっている
		PRINTFORML もはやたまらなくなり腰をくいくいと揺すると、ペニスが膣肉に擦れ%ANAME(対象)%はピクピクと震える
		PRINTFORMW 二人は密着したままお互いの汗でどろどろになりながら濃厚なセックスを楽しんだ
	CASE 3
		PRINTFORML 男の上に乗った%ANAME(対象)%は淫らに体をくねらせている
		PRINTFORML 咥えこんだペニスに子宮を突き上げられる度に、%ANAME(対象)%は甘い嬌声を上げ恍惚の表情を見せた
		PRINTFORML ぎゅうっとペニスを締め上げる膣肉の感触に男も我慢できなくなり、子宮内へと子種を解き放つ
		PRINTFORMW 下腹部に広がる熱に%ANAME(対象)%は子宮がきゅんと疼くのを感じながら、雌の悦びと共に絶頂した
	CASE 4
		PRINTFORML 男に抱きしめられながら何度目かの射精を受けて%ANAME(対象)%は嬌声を上げる
		PRINTFORML 疲れ果てた男が倒れ込むが、物足りない%ANAME(対象)%はペニスを咥えこんだまま腰を揺すり次を催促する
		PRINTFORML 男に目で楽しませてくれと言われた%ANAME(対象)%は、淫靡な笑みを浮かべ踊り子の様に体をくねらせる
		PRINTFORMW 自らの中で肉棒が再び熱を持ち出したのを感じた%ANAME(対象)%は、彼の上で更に情熱的に踊った
	CASE 5
		PRINTFORML %ANAME(対象)%は四つん這いの姿勢で男に犯されている
		PRINTFORML 男の一突き毎に、柔肉の打ち合う音と%ANAME(対象)%の嬌声がリズミカルに響く
		PRINTFORML 脳天に響くような圧倒的なセックスに%ANAME(対象)%はまるで男に征服されるかのような錯覚に陥る
		PRINTFORMW しかし%ANAME(対象)%はむしろそれに悦びを覚え、一匹の雌として男の精を受け入れた
	CASE 6
		PRINTFORML %ANAME(対象)%は犬のような恰好で背後から突かれている
		PRINTFORML 逞しいペニスが出入りする度に天井をこすられ、%ANAME(対象)%はあられもない声を出してビクビクと痙攣する
		PRINTFORML 彼が激しく子宮まで届くような一突きを見舞うと、%ANAME(対象)%は大きく背を反らしながら一瞬気を飛ばす
		PRINTFORMW その時の膣の締まりを気に入った男によって激しく突かれ続け、%ANAME(対象)%は何度も絶頂させられた
	CASE 7
		PRINTFORML %ANAME(対象)%は男に覆いかぶされて四つん這いで犯されている
		PRINTFORML 身体を密着させて乱暴に腰を打ちつけ合う野性的なセックスに、%ANAME(対象)%はひぃひぃ喘がされている
		PRINTFORML 胸を揉まれながらぐりぐりと膣肉を刺激され、%ANAME(対象)%は大きく身を震わせて絶頂してしまう
		PRINTFORMW 二人の熱は一向に収まることを知らず、まるで獣のような交尾をひたすら繰り返した
	CASE 8
		PRINTFORML 男が背後から%ANAME(対象)%の腰を掴んで激しく犯している
		PRINTFORML %ANAME(対象)%はゴリゴリと膣肉を抉られだらしなく喘ぎながらも、崩れ落ちそうになるのを必死で堪えている
		PRINTFORML しかし男の巧みなテクニックによってすぐに腕に力が入らなくなり、絶頂と共にベッドに倒れ込んでしまう
		PRINTFORMW そんな%ANAME(対象)%に対し男はさらに激しく攻めたて、彼女は夜通し躾けられてしまった
	CASE 9
		PRINTFORML %ANAME(対象)%は男に背後から抱きしめられながらペニスを咥えこんでいる
		PRINTFORML 胸を揉みしだかれ乳首をこねくり回されながらうなじを舌でなぞられ、%ANAME(対象)%はゾクゾクと震える
		PRINTFORML 濃厚な愛撫に切なくなった%ANAME(対象)%が腰を揺すると男も彼女の腰に手を回し優しく突き上げてきた
		PRINTFORMW 決して激しくはないが身体を絡ませ合う濃厚なセックスに%ANAME(対象)%は夢中になり何度も絶頂した
	CASE 10
		PRINTFORML %ANAME(対象)%は男に背後から両腕を掴まれ立ちバックの姿勢で子宮を小突かれている
		PRINTFORML 乱暴なセックスにしかし%ANAME(対象)%は興奮し、一突き毎に喘ぎながら膣を締め上げペニスを刺激した
		PRINTFORML %ANAME(対象)%の反応に気を良くした男は、更に激しく子宮内に響くようなストロークを繰り出し彼女を攻める
		PRINTFORMW やがて膣の締め付けに我慢できなくなった男が射精すると、%ANAME(対象)%は体を跳ね上げながら絶頂した
	CASE 11
		PRINTFORML %ANAME(対象)%は部屋に入るなり男に押し倒されペニスをねじ込まれた
		PRINTFORML しかしその秘所はすでにとろとろになっており、%ANAME(対象)%も抵抗もせずにそれを受け入れる
		PRINTFORML 男は%ANAME(対象)%のマン肉の感触に夢中になって腰を振り、彼女もまた一突きされる度に嬌声を上げる
		PRINTFORMW 震える男の腰を両足でがっしりと掴みながら射精を受け、%ANAME(対象)%は身体が燃える様な快楽を味わった
	CASE 12
		PRINTFORML %ANAME(対象)%は正常位の格好で激しく犯されている
		PRINTFORML 男が腰を振りペニスで膣内を刺激される度に、%ANAME(対象)%はたまらないといった表情で体をくねらせる
		PRINTFORML その淫らな表情と仕草に男の興奮も一層昂ぶり、更に激しく腰を打ちつけ快楽を貪りあう
		PRINTFORMW やがて男が低く唸り射精すると同時に、%ANAME(対象)%もまただらしなく涎を垂らしながら絶頂した
	CASE 13
		PRINTFORML %ANAME(対象)%は男のペニスを咥えこみながら舌を絡ませている
		PRINTFORML 男が体重を乗せて腰を打ち付ける度に%ANAME(対象)%は痺れるような快楽で体を痙攣させ軽く達する
		PRINTFORML 唇を離しても%ANAME(対象)%は男の首に手を回したまま、もっともっととおねだりして膣を締めつける
		PRINTFORMW %ANAME(対象)%の誘いに男もより激しく腰を振って応え、二人はお互いを貪る様なセックスを繰り返した
	CASE 14
		PRINTFORML %ANAME(対象)%は男に犯されながら艶めかしく体をくねらせている
		PRINTFORML 彼のねっとりとした腰遣いで攻められ続け、その虜になった%ANAME(対象)%はすっかり惚けてしまっている
		PRINTFORML 普段の%ANAME(対象)%からは想像も出来ないような淫靡な表情で淫らな言葉を紡ぎ彼を求めている
		PRINTFORMW %ANAME(対象)%は男に与えられる快楽に陶酔しながら、犯されるままに犯され何度も絶頂した
	CASE 15
		PRINTFORML %ANAME(対象)%はうつ伏せの格好で男にのしかかられながら犯されている
		PRINTFORML 男がその逞しいペニスを%ANAME(対象)%の中に出し入れする度に、彼女はそれに合わせ嬌声を上げる
		PRINTFORML %ANAME(対象)%は与えられる快楽に夢中になって、一突き毎により強く枕を抱きしめ表情を蕩けさせる
		PRINTFORMW 待望の男の子種を子宮内に注ぎ込まれると、%ANAME(対象)%は全身を痙攣させながら絶頂した
	CASE 16
		PRINTFORML %ANAME(対象)%は男に尻を持ち上げられる格好で犯されている
		PRINTFORML あまりの快楽に%ANAME(対象)%は枕に顔をうずめながら身体を振るわせつつ、必死で耐えている
		PRINTFORML しかしペニスに子宮口を撫でられると、耐えきれず甘える様な声を上げて絶頂してしまった
		PRINTFORMW %ANAME(対象)%の可愛い反応に男は興奮し、膣内を蹂躙しながら何度も彼女を絶頂させた
	CASE 17
		PRINTFORML %ANAME(対象)%は男に犯されながら腰をくねらせ甘えた声を上げる
		PRINTFORML ペニスでボルチオをグリグリと攻められると、%ANAME(対象)%はたまらず嬌声を上げて体を跳ねる
		PRINTFORML %ANAME(対象)%は絶頂しながら目をハートにしながら男を見つめて、大きく手を広げて彼を誘う
		PRINTFORMW 男にぎゅぅっと抱きしめられながら子種を注がれ、%ANAME(対象)%は足をピンと伸ばしながら再び絶頂した
	CASE 18
		PRINTFORML %ANAME(対象)%は男の巧みな指使いで攻められ、すぐに虜になってしまった
		PRINTFORML 我慢できなくなった%ANAME(対象)%は服従のポーズになり、とろとろになったまんこを割れ開きおねだりする
		PRINTFORML 男が逞しいペニスを取り出すと、%ANAME(対象)%は釘付けになり秘所からさらに愛液を溢れださせる
		PRINTFORMW そして待望のペニスをねじ込まれるとともに%ANAME(対象)%は子宮を震わせながら絶頂した
	CASE 19
		PRINTFORML %ANAME(対象)%は壁に寄りかかりながら犯されている
		PRINTFORML 男に片足を持ち上げられ、爪先立ちの格好でペニスを激しく出し入れされながらヨガっている
		PRINTFORML 男のペニスで子宮を抉る様に小突かれ続けて、%ANAME(対象)%はあまりの快楽にガクガクと震える
		PRINTFORMW 濃厚な精液を膣奥に放たれると、%ANAME(対象)%はたまらずアヘ顔を晒しながら絶頂した
	CASE 20
```
