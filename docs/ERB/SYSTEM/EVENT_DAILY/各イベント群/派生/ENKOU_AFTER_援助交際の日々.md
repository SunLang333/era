# SYSTEM/EVENT_DAILY/各イベント群/派生/ENKOU_AFTER_援助交際の日々.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/ENKOU_AFTER_援助交際の日々.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_ENKOU_AFTER_DISABLE, EVENT_DAILY_DERIVATION_ENKOU_AFTER_DECISION, EVENT_DAILY_DERIVATION_ENKOU_AFTER_SETTARGET, EVENT_DAILY_DERIVATION_ENKOU_AFTER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_ENKOU_AFTER_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("NAMPA")



;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_ENKOU_AFTER_DECISION()
RETURN 1

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_DERIVATION_ENKOU_AFTER_SETTARGET()
FOR LOCAL, 0, CHARANUM
	SIF !GETBIT(TALENT:LOCAL:デイリー系, 素質_デイリー_援交少女)
		CONTINUE
	SIF !IS_FEMALE(LOCAL)
		CONTINUE
	SIF CFLAG:LOCAL:特殊状態 != 0
		CONTINUE
	SIF CFLAG:LOCAL:捕虜先 != 0
		CONTINUE
	SIF RAND:3
		CONTINUE
	DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
	DAILY_TARGET_NUM ++
NEXT

SIF DAILY_TARGET_NUM < 1
	RETURN 0

RETURN 1

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_ENKOU_AFTER(対象)
#DIM 対象
#DIM 金額
#DIM LCOUNT

FOR LOCAL, 0, DAILY_TARGET_NUM
	対象 = DAILY_TARGET:LOCAL

	PRINTFORML %ANAME(対象)%は"パパ"から連絡を受けた
	SELECTCASE RAND:5
		CASE 0
			PRINTFORML 今夜会わないかと尋ねられた%ANAME(対象)%は予定を確認して返事をした
			PRINTFORMW そしてテキパキと仕事を終わらせると無意識の内に早足で彼の元に向かった…
		CASE 1
			PRINTFORML 「今晩、どうかな？」
			PRINTFORML 簡潔なメールの内容とは裏腹にどんなプレイにつき合わされるのか
			PRINTFORMW そう考えるだけで、%ANAME(対象)%は思わず胸が熱くなった……
		CASE 2
			PRINTFORML 情熱的なデートの誘いに%ANAME(対象)%は二つ返事で了承する
			PRINTFORMW そして仕事の残りを部下に任せると胸を高鳴らせながら彼の元に向かった…
		CASE 3
			PRINTFORML 彼の声を聴くだけで前回の逢瀬を思い出して子宮が疼く
			PRINTFORMW %ANAME(対象)%は努めて平静さを取り繕いながら彼の誘いを了承した……
		CASE 4
			PRINTFORML 彼は妻子が出かけたのでたっぷりと楽しめると告げてきた
			PRINTFORMW 一晩中彼に可愛がられる事を想像した%ANAME(対象)%は思わず生唾を飲んだ…
	ENDSELECT
	PRINTFORML 
	SELECTCASE RAND:4
		CASE 0
			PRINTFORMW 彼と合流した%ANAME(対象)%は腕を組みながらホテル街へと向かった
			PRINTFORML 
			SELECTCASE RAND:15
				CASE 0
					PRINTFORML 部屋に入るなり早速押し倒された
					PRINTFORML 興奮した彼は宥める%ANAME(対象)%の言葉を無視しむしゃぶりつきながら、肉棒をねじ込んできた
					PRINTFORMW その雄々しいセックスに否応なく感じさせられ、あられもなくヨガってしまった
				CASE 1
					PRINTFORML ベッドに腰かけベロチューをしながら体を弄られる
					PRINTFORML 中年親父のねっとりとした愛撫に嫌悪感とそれ以上の快楽を感じゾクゾクしてしまう
					PRINTFORMW 我慢できなくなった%ANAME(対象)%がおねだりをすると勢い良く押し倒された
				CASE 2
					PRINTFORML 一回戦を終えた%ANAME(対象)%達は身体を重ねて横になっている
					PRINTFORML 彼のねっとりとした腰遣いにメロメロとなった%ANAME(対象)%は甘える様にその腕に抱かれている
					PRINTFORMW しばしのピロートークの後、彼に次を要求された%ANAME(対象)%は悦んで身体を開いた
				CASE 3
					PRINTFORML ピンク色の部屋に%ANAME(対象)%のあられもない嬌声が響き渡る
					PRINTFORML ベッドに四つん這いになった%ANAME(対象)%は激しいガン突きを食らって身悶えている
					PRINTFORML 彼の底なしのスタミナで何度もイかされまくっているその表情はまさにビッチそのものだ
					PRINTFORMW 何度も壊れるかと思う程夜通しハメ倒される羽目になった
				CASE 4
					PRINTFORML 彼の要望で対面座位で繋がっている
					PRINTFORML ベロチューを交わし胸を揉まれながら野太いペニスで子宮を小突かれ思わず呻く
					PRINTFORML その濃厚なセックスに%ANAME(対象)%は身も心も蕩け切り、彼にしがみついて快楽を求めていた
					PRINTFORMW 彼が満足するまでひたすらつながり続け、何度もその精を受け止める事になった
				CASE 5
					PRINTFORML %ANAME(対象)%は激しく責め立てられてひたすら喘いでいる
					PRINTFORML 逞しいペニスで一突きされる度に身体が悦びキュッ♥キュッ♥と膣を締めあげ射精を促す
					PRINTFORMW そして彼が射精すると子宮に注ぎ込まれる灼熱を感じながら、大きく仰け反った
				CASE 6
					PRINTFORML 部屋に入るとどちらからともなくキスをしながらベッドに向かった
					PRINTFORML 既にバキバキに勃起しているペニスに、%ANAME(対象)%は赤面しながらも両手を開いて彼を迎えた
					PRINTFORMW 相変わらず身体の相性は抜群に良く、互いに何度も絶頂を繰り返した
				CASE 7
					PRINTFORML 彼の要望で着衣のまま楽しむことになった
					PRINTFORML 彼に跨り、スカートをたくし上げて結合部を見せながらずっちゅずちゅと激しく腰を振る
					PRINTFORMW ビッチの様な自らの行為に興奮した%ANAME(対象)%はいつも以上に彼にサービスした
				CASE 8
					PRINTFORML 雌の顔をした%ANAME(対象)%が彼のペニスをぺろぺろと舐めている
					PRINTFORML 時折ひくついている%ANAME(対象)%の股間からはドロリと大量のザーメンが溢れ出ている
					PRINTFORML 丹念な奉仕で一物は直ぐに硬さを取り戻し、それを見て%ANAME(対象)%はゴクリと生唾を飲んだ
					PRINTFORMW %ANAME(対象)%が次を求めると彼は舌なめずりをしながら覆い被さって来た
				CASE 9
					PRINTFORML %ANAME(対象)%は四つん這いの格好で犯されながら呻いている
					PRINTFORML 彼は%ANAME(対象)%の腰を掴み激しく腰を打ち付けながらバチンバチンと尻を叩いてくる
					PRINTFORML その度に痛みとそれ以上の快楽が走り、%ANAME(対象)%は溜まらず犬の様に卑しく啼いてしまう
					PRINTFORMW %ANAME(対象)%はお尻が真っ赤になるまで虐められへたりこみながらも悦びの表情をしていた
				CASE 10
					PRINTFORML 彼の要望でコスプレエッチをする事になった
					PRINTFORML ヒラヒラの衣装を身につけたまま全身を弄ばれた後、彼に跨り淫らに腰をくねらせる
					PRINTFORMW 最初は硬かった%ANAME(対象)%も次第に熱が入り出し、気付けば情熱的に腰を振っていた
				CASE 11
					PRINTFORML 今日はじっくりとしたスローセックスを楽しんでいる
					PRINTFORML ペニスで貫かれたままキスを交わし互いの肌をなぞっていると幸福感でいっぱいとなる
					PRINTFORMW やがて彼の熱が子宮に染み込むのを感じながら深い絶頂を味わった
				CASE 12
					PRINTFORML 部屋につくと早速ベッドに向かいセックスに没頭した
					PRINTFORML %ANAME(対象)%の弱点を知り尽くした彼の攻めに抗う術はなく、何度もあっけなくイかされる
					PRINTFORML グリグリとＧスポットを亀頭でねちっこく抉られるとビクビクと痙攣させられてしまった
					PRINTFORMW たっぷりと楽しんだ後は、一緒にシャワーを浴びながらイチャついた
				CASE 13
					PRINTFORML 今日は彼の持参した女子高生の制服を着せられて抱かれている
					PRINTFORML 彼は何時もにもましていやらしい笑みを浮かべ激しく腰を打ち付けて来る
					PRINTFORML キモさを感じながらも、%ANAME(対象)%もまた学生になり切って抱かれる行為に興奮していた
					PRINTFORMW %ANAME(対象)%を孕ませようとする濃いザーメンを子宮一杯になるまで注がれた
				CASE 14
					PRINTFORML いつも通り激しいセックスに没頭していると彼の携帯が鳴った
					PRINTFORML 彼の妻からだったが、彼は構わず腰を振り続けながら何食わぬ声で応答する
					PRINTFORML しかし%ANAME(対象)%がキュッと膣を締めてやると情けない声を出しながら慌てて電話を切った
					PRINTFORMW 悪戯した%ANAME(対象)%はたっぷりとお仕置きをされてしまった
			ENDSELECT
		CASE 1
			PRINTFORMW 彼と合流した%ANAME(対象)%は腰を抱かれながら路地裏へ連れ込まれた
			PRINTFORML 
			SELECTCASE RAND:15
				CASE 0
					PRINTFORML 壁際に立たされパンツを降ろされると思いきりペニスをねじ込まれた
					PRINTFORML 野外でのセックスに彼は興奮した様子でいつも以上に激しく突き上げて来る
					PRINTFORMW %ANAME(対象)%もまたその野性的なピストンに感じてしまい、みっともなく喘ぎ声を上げた
				CASE 1
					PRINTFORML 路地に入るなりスカートを捲り上げられそのまま激しく犯された
					PRINTFORML 数ｍ先を通行人が行きかっており%ANAME(対象)%は身悶えながらも必死で声を抑える
					PRINTFORMW しかし彼は容赦せずに突き上げてきて、%ANAME(対象)%は快楽と理性の間で狂いそうになった
				CASE 2
					PRINTFORML 路地裏で%ANAME(対象)%は彼に跪いてペニスにしゃぶりついている
					PRINTFORML 我慢できずにバッキバキのペニス頬張り頭を動かすと口内に雄の匂いが充満する
					PRINTFORMW そして濃いザーメンを放たれると下品な音を立てながら一滴残らず飲み干した
				CASE 3
					PRINTFORML 人気のない路地裏で全身を弄られていると浮浪者と遭遇した
					PRINTFORML 焦って場所を移そうと提案したが、彼はニヤリと笑うとそのまま行為を続行した
					PRINTFORMW 浮浪者に見せつけるように激しく抱かれて、何度もイかされてしまった
				CASE 4
					PRINTFORML ホテルまで我慢できない彼に背後から抱きしめられ激しく突き上げられる
					PRINTFORML 鼻息を荒げる醜い中年親父に犯されているという事実に%ANAME(対象)%は興奮して喘いでしまう
					PRINTFORML %ANAME(対象)%達は場所を忘れてまぐわい続け、
					PRINTFORMW %ANAME(対象)%達は場所を忘れて子宮がザーメンでタプタプになるまでまぐわい続けた
				CASE 5
					PRINTFORML 散々犯されボロボロになった%ANAME(対象)%が地べたにはいつくばっている
					PRINTFORML 痙攣してパクつくまんこからは大量の精液がゴポッと溢れ出てまぐわった回数を物語る
					PRINTFORMW 彼はその無様な姿をしっかりと写メに納めると再び腰を掴みペニスを打ち込んできた
				CASE 6
					PRINTFORML 薄暗い路地裏から%ANAME(対象)%の呻き声が漏れ聞こえてくる
					PRINTFORML 強引に素っ裸に剥かれた%ANAME(対象)%はだらしないアヘ顔でガン突きされている
					PRINTFORML まるで露出狂の様な行為に官能を刺激された%ANAME(対象)%はいつも以上に興奮して子宮が疼かせた
					PRINTFORMW そしてまた何度目かの膣内射精を受けながら%ANAME(対象)%は大きく絶頂した
				CASE 7
					PRINTFORML 路地に入るなり彼は%ANAME(対象)%に抱きつき濃厚に舌を絡ませてきた
					PRINTFORML %ANAME(対象)%は強引に全身を弄られながら誘う様な笑みを浮かべて、されるがままに受け入れた
					PRINTFORMW 我慢できなくなった%ANAME(対象)%達はホテル行きを中止しその場で何度も交わった
				CASE 8
					PRINTFORML %ANAME(対象)%達は浮浪者たちの前で公開セックスをする事になった
					PRINTFORML 結合部を丸見えの状態で激しく突き上げられ、%ANAME(対象)%は羞恥でゾクゾクしながら身悶える
					PRINTFORML 彼もまたいつも以上に興奮した様子で深く激しく腰を振り%ANAME(対象)%を攻め立ててきた
					PRINTFORMW そして浮浪者たちの視線に晒されながらあられもないイキ顔を晒してしまった
				CASE 9
					PRINTFORML 路地の奥で%ANAME(対象)%は壁にもたれながら彼に抱かれている
					PRINTFORML いつ人が来るかわからない場所での営みに興奮した%ANAME(対象)%は無意識に身をくねらせ喘ぐ
					PRINTFORMW わざと時間をかけたねっとりセックスに%ANAME(対象)%は気を失いそうになる程イかされた
				CASE 10
					PRINTFORML 路地で激しく交わっていると、ひょっこりと子供が現れた
					PRINTFORML 慌てる%ANAME(対象)%に対し、彼はなんと少年に呼び掛け%ANAME(対象)%との行為を見せつけ出した
					PRINTFORMW %ANAME(対象)%はなすすべなく、子供の無垢な視線を浴びながらイかされてしまった
				CASE 11
					PRINTFORML 彼は路地でも容赦なく%ANAME(対象)%を犯しまくった
					PRINTFORML 激しいセックスで足腰が立たなくなった%ANAME(対象)%が下半身もろ出しで地べたに横たわる
```
