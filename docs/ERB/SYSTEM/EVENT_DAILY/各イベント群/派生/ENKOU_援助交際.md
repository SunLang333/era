# SYSTEM/EVENT_DAILY/各イベント群/派生/ENKOU_援助交際.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/ENKOU_援助交際.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_ENKOU_DISABLE, EVENT_DAILY_DERIVATION_ENKOU_DECISION, EVENT_DAILY_DERIVATION_ENKOU; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_ENKOU_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("NAMPA")

;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_ENKOU_DECISION()
RETURN DVAR:援助交際_発生フラグ > 0 && RAND:2 == 0

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_ENKOU()
#DIM 対象
#DIM 金額

対象 = ID_TO_CHARA(DVAR:援助交際_対象ID)

IF 対象 == -1
	PRINTFORMW 相手がいなくなったので、援交親父はこれ以上の付き合いを諦めたようだ……
	DVAR:援助交際_対象ID = 0
	DVAR:援助交際_発生フラグ = 0
	DVAR:援助交際_生ハメ許可 = 0
	RETURN 1
ENDIF
;ターゲットが女じゃなくなっていたらやめる
IF !IS_FEMALE(対象)
	PRINTFORMW %ANAME(対象)%が女をやめたので、援交親父は興味を失ってしまったようだ……
	DVAR:援助交際_対象ID = 0
	DVAR:援助交際_発生フラグ = 0
	DVAR:援助交際_生ハメ許可 = 0
	RETURN 1
ENDIF

;ターゲットが捕虜になったらやめる
IF CFLAG:対象:捕虜先
	PRINTFORMW %ANAME(対象)%が捕らえられたので、援交親父はこれ以上の付き合いを諦めたようだ……
	DVAR:援助交際_対象ID = 0
	DVAR:援助交際_発生フラグ = 0
	DVAR:援助交際_生ハメ許可 = 0
	RETURN 1
ENDIF

IF CFLAG:対象:特殊状態 == 特殊状態_死亡
	PRINTFORMW %ANAME(対象)%が死亡したので、援交親父はこれ以上の付き合いを諦めたようだ……
	DVAR:援助交際_対象ID = 0
	DVAR:援助交際_発生フラグ = 0
	DVAR:援助交際_生ハメ許可 = 0
	RETURN 1
ENDIF

PRINTFORML "パパ"からデートの誘いが来た
PRINTFORML 丁度今夜は何も予定がない
PRINTFORMW %ANAME(対象)%はOKと返事すると、待ち合わせ場所へ向かった……
PRINTFORML 
SELECTCASE RAND:4
	CASE 0
		PRINTFORMW 彼と合流した%ANAME(対象)%は腕を組みながらホテル街へと向かった
		PRINTFORML 
		SELECTCASE RAND:10
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
				IF DVAR:援助交際_生ハメ許可 == 1
					PRINTFORMW 彼が満足するまでひたすらつながり続け、何度もその精を受け止める事になった
				ELSE
					PRINTFORMW 彼が満足するまでひたすらつながり続け、使い終わったゴムがそこら中に転がった
				ENDIF
			CASE 5
				PRINTFORML %ANAME(対象)%は激しく責め立てられてひたすら喘いでいる
				PRINTFORML 逞しいペニスで一突きされる度に身体が悦びキュッ♥キュッ♥と膣を締めあげ射精を促す
				IF DVAR:援助交際_生ハメ許可 == 1
					PRINTFORMW そして彼が射精すると子宮に注ぎ込まれる灼熱を感じながら、大きく仰け反った
				ELSE
					PRINTFORMW そして彼が射精するとゴム越しでも伝わるその灼熱を感じながら、大きく仰け反った
				ENDIF
			CASE 6
				PRINTFORML 部屋に入るとどちらからともなくキスをしながらベッドに向かった
				PRINTFORML 既にバキバキに勃起しているペニスに、%ANAME(対象)%は赤面しながらも両手を開いて彼を迎えた
				PRINTFORMW 相変わらず身体の相性は抜群に良く、互いに何度も絶頂を繰り返した
			CASE 7
				PRINTFORML 男の要望で着衣のまま楽しむことになった
				PRINTFORML 彼に跨り、スカートをたくし上げて結合部を見せながらずっちゅずちゅと激しく腰を振る
				PRINTFORMW ビッチの様な自らの行為に興奮した%ANAME(対象)%はいつも以上に彼にサービスした
			CASE 8
				PRINTFORML 雌の顔をした%ANAME(対象)%が彼のペニスをぺろぺろと舐めている
				IF DVAR:援助交際_生ハメ許可 == 1
					PRINTFORML 時折ひくついている%ANAME(対象)%の股間からはドロリと大量のザーメンが溢れ出ている
				ELSE
					PRINTFORML 周囲には大量の使用済みコンドームが転がり、%ANAME(対象)%が抱かれた回数を物語る
				ENDIF
				PRINTFORML 丹念な奉仕で一物は直ぐに硬さを取り戻し、それを見て%ANAME(対象)%はゴクリと生唾を飲んだ
				PRINTFORMW %ANAME(対象)%が次を求めると彼は舌なめずりをしながら覆い被さって来た
			CASE 9
				PRINTFORML %ANAME(対象)%は四つん這いの格好で犯されながら呻いている
				PRINTFORML 彼は%ANAME(対象)%の腰を掴み激しく腰を打ち付けながらバチンバチンと尻を叩いてくる
				PRINTFORML その度に痛みとそれ以上の快楽が走り、%ANAME(対象)%は溜まらず犬の様に卑しく啼いてしまう
				PRINTFORMW %ANAME(対象)%はお尻が真っ赤になるまで虐められへたりこみながらも悦びの表情をしていた
		ENDSELECT
	CASE 1
		PRINTFORMW 彼と合流した%ANAME(対象)%は腰を抱かれながら路地裏へ連れ込まれた
		PRINTFORML 
		SELECTCASE RAND:10
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
				IF DVAR:援助交際_生ハメ許可 == 1
					PRINTFORMW %ANAME(対象)%達は場所を忘れて子宮がザーメンでタプタプになるまでまぐわい続けた
				ELSE
					PRINTFORMW %ANAME(対象)%達は場所を忘れて持参のコンドームを使いきるまでまぐわい続けた
				ENDIF
			CASE 5
				PRINTFORML 散々犯されボロボロになった%ANAME(対象)%が地べたにはいつくばっている
				IF DVAR:援助交際_生ハメ許可 == 1
					PRINTFORML 痙攣してパクつくまんこからは大量の精液がゴポッと溢れ出てまぐわった回数を物語る
				ELSE
					PRINTFORML %ANAME(対象)%の周囲には大量の使用済みコンドームが転がっておりまぐわった回数を物語る
				ENDIF
				PRINTFORMW 男はその無様な姿をしっかりと写メに納めると再び腰を掴みペニスを打ち込んできた
			CASE 6
				PRINTFORML 薄暗い路地裏から%ANAME(対象)%の呻き声が漏れ聞こえてくる
				PRINTFORML 強引に素っ裸に剥かれた%ANAME(対象)%はだらしないアヘ顔でガン突きされている
				PRINTFORML まるで露出狂の様な行為に官能を刺激された%ANAME(対象)%はいつも以上に興奮して子宮が疼かせた
				IF DVAR:援助交際_生ハメ許可 == 1
					PRINTFORMW そしてまた何度目かの膣内射精を受けながら%ANAME(対象)%は大きく絶頂した
				ELSE
					PRINTFORMW そしてまたゴム越しの灼熱を感じながら%ANAME(対象)%は大きく絶頂した
				ENDIF
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
		ENDSELECT
	CASE 2
		PRINTFORMW 彼と合流した%ANAME(対象)%は軽いデートの後、自宅に招待された
		PRINTFORML 
		SELECTCASE RAND:10
			CASE 0
				PRINTFORML 自宅に着くなり寝室に連れ込まれ押し倒された
				PRINTFORML 日頃彼が妻と寝ているであろうベッドでの行為に背徳感が刺激されはしたなく喘いでしまう
				PRINTFORMW 気付かぬ内にいつも以上に彼にきつくしがみ付き、自ら腰を振って求めていた
			CASE 1
				PRINTFORML 彼と家族の家で、その家族のいない家で激しく交わっている
				PRINTFORML もしも今彼の妻子が帰ってきたら…そう考えるだけでゾクゾクして子宮が熱くなっていく
				PRINTFORMW 燃え上がった%ANAME(対象)%達は時間ぎりぎりまで不倫セックスを楽しんだ
			CASE 2
				PRINTFORML 激しいセックスの後、%ANAME(対象)%達はベッドでピロートークを交わしている
				PRINTFORML まるで本物の夫婦の様な甘い時間を二人でゆっくりと楽しみ、存分にイチャつく
				IF DVAR:援助交際_生ハメ許可 == 1
					PRINTFORML 彼に子宮を上から撫でられると先程注がれた精液の熱を感じたまらず喘いでしまった
				ELSE
```
