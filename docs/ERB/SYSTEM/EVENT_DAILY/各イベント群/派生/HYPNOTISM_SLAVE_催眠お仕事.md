# SYSTEM/EVENT_DAILY/各イベント群/派生/HYPNOTISM_SLAVE_催眠お仕事.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/HYPNOTISM_SLAVE_催眠お仕事.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_HYPNOTISM_SLAVE_DISABLE, EVENT_DAILY_DERIVATION_HYPNOTISM_SLAVE_DECISION, EVENT_DAILY_DERIVATION_HYPNOTISM_SLAVE, EVENT_DAILY_DERIVATION_HYPNOTISM_SLAVE_ALLOW_WHEN_WANDERING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------_
@EVENT_DAILY_DERIVATION_HYPNOTISM_SLAVE_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("HYPNOTISM_WORKER")

;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_HYPNOTISM_SLAVE_DECISION()

RETURN DVAR:催眠お仕事_状態管理フラグ > 0 && RAND:100 < 40

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_HYPNOTISM_SLAVE
#DIM 対象
#DIM 仕事先

対象 = ID_TO_CHARA(DVAR:催眠お仕事_調教対象ID)

IF 対象 == -1
	DVAR:催眠お仕事_状態管理フラグ = 0
	DVAR:催眠お仕事_調教対象ID = 0
	DVAR:催眠お仕事_進行度 = 0
	RETURN 1
ENDIF

;ターゲットが女じゃなくなっていたらやめる
IF !IS_FEMALE(対象)
	PRINTFORMW %ANAME(対象)%が女をやめたので、催眠傀儡師は興味を失ってしまったようだ……
	DVAR:催眠お仕事_状態管理フラグ = 0
	DVAR:催眠お仕事_調教対象ID = 0
	DVAR:催眠お仕事_進行度 = 0
	RETURN 1
ENDIF

;ターゲットが捕虜になったらやめる
IF CFLAG:対象:捕虜先
	PRINTFORMW %ANAME(対象)%が捕らえられたので、催眠傀儡師はこれ以上の調教をあきらめたようだ……
	DVAR:催眠お仕事_状態管理フラグ = 0
	DVAR:催眠お仕事_調教対象ID = 0
	DVAR:催眠お仕事_進行度 = 0
	RETURN 1
ENDIF

IF CFLAG:対象:特殊状態 == 特殊状態_死亡
	PRINTFORMW %ANAME(対象)%が死亡したので、催眠傀儡師はこれ以上の調教を諦めたようだ……
	DVAR:催眠お仕事_状態管理フラグ = 0
	DVAR:催眠お仕事_調教対象ID = 0
	DVAR:催眠お仕事_進行度 = 0
	RETURN 1
ENDIF

PRINTFORMW %ANAME(対象)%は今日も"お仕事"に出かけた
PRINTFORML 
IF DVAR:催眠お仕事_進行度 > 15
	PRINTFORMW 今日の%ANAME(対象)%はご主人様の肉奴隷として奉仕している
	PRINTFORML 首輪をつけられた%ANAME(対象)%がベッドの上でご主事様に跨って激しく腰を振る
	PRINTFORML だらしなく舌を垂らし、アヘ顔を晒しながらヨガり狂う姿はまさに雌犬の様だ
	PRINTFORMW ちんぽで膣肉を抉られる度に脳天までシビレが走り、%ANAME(対象)%はあられない嬌声を上げる
	PRINTFORML 度重なる催眠と凌辱により、%ANAME(対象)%は心も体もすっかり快楽に染められてしまった
	PRINTFORML 軽い催眠でも以前とは考えらない程に乱れる%ANAME(対象)%に彼は満足そうにニヤリと笑う
	PRINTFORMW 不意に勢いよく精液が放たれると、%ANAME(対象)%は潮を吹きながら大きく身を仰け反らせた
	PRINTFORML びゅる！びゅるる！と胎内に注がれる灼熱に、激しく痙攣しながら連続で絶頂する
	PRINTFORML そしてようやく射精が終わると%ANAME(対象)%はくたぁっと力なくご主人様の上に倒れ込んだ
	PRINTFORMW 絶頂の余韻で恍惚の表情をしながら息を荒げる%ANAME(対象)%に対し彼がそっと何かを囁く
	PRINTFORML すると途端に%ANAME(対象)%は何時もの表情に戻り、キョロキョロと辺りを見回しだした
	PRINTFORML 彼はその様子をニヤニヤと眺めながら腰を掴むと再びいきり立ったペニスで突き上げた
	PRINTFORMW %ANAME(対象)%はビクンと身を震わせたもののそれだけで、相変わらず不思議そうにしている
	PRINTFORML 新たに認識阻害の催眠で上書きされた%ANAME(対象)%は彼に犯されているのに気付けないのだ
	PRINTFORML だが肉体の方はそのままで、膣穴はちんぽをきつく締め付け乳首は限界まで勃っていた
	PRINTFORMW 激しく突き上げられながら胸をこねくり回され%ANAME(対象)%は知らず知らずに甘い吐息を上げる
	PRINTFORML しかしやはり犯されている事に気づきもせず首をかしげながらされるがままに犯される
	PRINTFORML そしてまた、彼のザーメンを子宮に注がれながら%ANAME(対象)%は無意識絶頂で嬌声を響かせた
	PRINTFORMW %ANAME(対象)%は一晩中彼から様々な催眠を受け続け、もう戻れない所まで変わってしまった……
	PRINTFORML 
	CALL COLOR_PRINTW(@"この日から、%ANAME(対象)%は恒久的な催眠奴隷となった", カラー_ピンク)
	SETBIT TALENT:対象:デイリー系, 素質_デイリー_催眠奴隷
	CALL LOSE_RELATION_TALENT(対象)
	DVAR:催眠お仕事_状態管理フラグ = 0
	DVAR:催眠お仕事_調教対象ID = 0
	DVAR:催眠お仕事_進行度 = 0
ELSE
	IF 対象 == MASTER
		PRINTFORML 今日はどこで仕事をしようか？
		CALL ASK_MULTI("貴族の屋敷" ,"酒場" ,"寺小屋" ,"神社" ,"スラム")
		IF RESULT == 0
			仕事先 = 0
		ELSEIF RESULT == 1
			仕事先 = 1
		ELSEIF RESULT == 2
			仕事先 = 2
		ELSEIF RESULT == 3
			仕事先 = 3
		ELSEIF RESULT == 4
			仕事先 = 4
		ENDIF
	ELSE
		LOCAL = RAND:5
		IF LOCAL == 0
			仕事先 = 0
		ELSEIF LOCAL == 1
			仕事先 = 1
		ELSEIF LOCAL == 2
			仕事先 = 2
		ELSEIF LOCAL == 3
			仕事先 = 3
		ELSEIF LOCAL == 4
			仕事先 = 4
		ENDIF
	ENDIF
	IF 仕事先 == 0
		PRINTFORMW %ANAME(対象)%は貴族の屋敷へ向かった……
		PRINTFORML 
		PRINTFORMW %ANAME(対象)%は貴族のメイドとして働いている
		SELECTCASE RAND:10
			CASE 0
				PRINTFORML 掃除中、ご主人様にお尻を撫でられた%ANAME(対象)%は悦び交じりの嬌声を上げた
				PRINTFORML ニヤニヤと笑いながらお尻を撫でまわしてくる彼に%ANAME(対象)%は言葉だけの抵抗をしつつもお尻を振る
				PRINTFORML その表情はすっかり期待に満ちた雌犬のものであり、震える喉からは甘い吐息が漏れていた
				PRINTFORMW そのまま寝室に連れ込まれた%ANAME(対象)%はたっぷりとご主人様にご奉仕を行った
			CASE 1
				PRINTFORML %ANAME(対象)%は乳もパンツも丸見えのメイド服を着ながらせわしなく動き回っている
				PRINTFORML ご主人様にいやらしい目つきで見られても%ANAME(対象)%はにっこりと笑顔で返して熱心に仕事をする
				PRINTFORML 不意に背後から胸を揉まれた%ANAME(対象)%は小さく喘ぎを上げながらも抵抗せず笑顔で受け入れた
				PRINTFORMW そのまま押し倒された%ANAME(対象)%の午後はご主人様のおチンポ処理で終わった
			CASE 2
				PRINTFORML %ANAME(対象)%は仕事中のご主人様の机の下に潜り込んでペニスをしゃぶりついている
				PRINTFORML じゅっぽじゅっぽといやらしい音を出しながら恍惚の表情で熱心に顔を振って竿を扱く
				PRINTFORML 不意にびゅるる！と勢い良く精液を口いっぱいに放たれると、%ANAME(対象)%は軽くイきながら飲み干した
				PRINTFORMW 彼は%ANAME(対象)%を抱き上げると机に押し倒し、今度は下の口にペニスをねじ込んできた
			CASE 3
				PRINTFORML %ANAME(対象)%はご主人様に付き従って一緒にお風呂に入り身体を洗っている
				PRINTFORML ご主人様とイチャイチャしながら全身をスポンジ代わりに彼に密着してゴシゴシと体を洗う
				PRINTFORML ギンギンに勃起したペニスを差し出されると舌と指で根元から皮の隙間まで丹念にこすりあげた
				PRINTFORMW 洗い終わると今度はシャワーを浴びながらご主人様のザーメンで体内を隅々まで洗われた
			CASE 4
				PRINTFORML 洗濯中ご主人様のパンツを手にした%ANAME(対象)%は突然発情してしまい自慰を始めた
				PRINTFORML 下着の匂いを嗅ぎながら声を押し殺してくちゅくちゅといやらしい音を立てて何度もアクメする
				PRINTFORML 時間を忘れてオナニーをしているとご主人に見つかってしまい慌てて取り繕うとしたが遅かった
				PRINTFORMW %ANAME(対象)%はお仕置きとして寝室に連れ込まれ直接彼の匂いを全身に擦りつけられた
			CASE 5
				PRINTFORML ベッドメイキングをしていると突然ご主人様に背後から押し倒された
				PRINTFORML 「奥様が来るといけません」と抵抗するも優しく愛撫されるとたまらず甘い吐息を漏らしてしまう
				PRINTFORML 彼は%ANAME(対象)%を押し倒すと背徳感で躊躇う姿を楽しむかの様に笑いながらねっとりと全身を弄んできた
				PRINTFORMW 結局その日はご主人様の寝室でのご奉仕だけで一日が潰れてしまった
			CASE 6
				PRINTFORML 深夜のお屋敷から%ANAME(対象)%のあられもない嬌声が響いてくる
				PRINTFORML 仕事をしているご主人様に夜食を運んだ%ANAME(対象)%はそのまま彼に抱き寄せられ机に押し倒された
				PRINTFORML 不意を突かれた%ANAME(対象)%は最初戸惑ったがギンギンの一物を見ると微かにはにかみながら股を開いた
				PRINTFORMW %ANAME(対象)%は夜食代わりとしてご主人様が満足するまでたっぷりと食べられた
			CASE 7
				PRINTFORML %ANAME(対象)%はキッチンでご主人様から激しくバック突きをされてヨガっている
				PRINTFORML 料理中に現れた彼に抵抗するも無視され、無理やりスカートを捲し上げられ犯されてしまった
				PRINTFORML 崩れ落ちそうなのをシンクに手をついて何とか堪える%ANAME(対象)%に対し彼は容赦なく腰を打ち付けてきた
				PRINTFORMW ご主人様が満足して解放される頃にはすっかり料理が焦げてしまっていた
			CASE 8
				PRINTFORML 仕事で粗相をしてしまった%ANAME(対象)%はご主人様に折檻される事になった
				PRINTFORML 地下室に連行され鎖で繋がれて特注の様々な玩具で弄ばれ、%ANAME(対象)%は泡を飛ばしながらヨガリ狂う
				PRINTFORML 潮を吹いて痙攣する%ANAME(対象)%の様子に彼は嗜虐的な笑みを浮かべ、折檻は一層激しさを増していった
				PRINTFORMW その後の%ANAME(対象)%は粗相の頻度が上がり、その度に瞳に期待の色を込めるようになった
			CASE 9
				PRINTFORML %ANAME(対象)%はご主人様の寝室で彼に跨りながら必死で声を押し殺し腰を振っている
				PRINTFORML すぐ横のベッドでは奥様が眠っておりベッドが軋む音すらも巨大な音に聞こえ、心臓が高鳴る
				PRINTFORML 必死で堪える%ANAME(対象)%に対し彼は楽しむ様に激しく突き上げを繰り返し何度も絶頂させられてしまった
				PRINTFORMW 秘密のセックスに%ANAME(対象)%達はいつも以上に昂り一晩中激しくベッドを軋ませ続けた
		ENDSELECT
	ELSEIF 仕事先 == 1
		PRINTFORMW %ANAME(対象)%は酒場へ向かった……
		PRINTFORML 
		PRINTFORMW %ANAME(対象)%は繁盛する酒場で従業員として働いている
		SELECTCASE RAND:10
			CASE 0
				PRINTFORML ライトアップされた舞台の上で大勢の客に見られながらポールダンスを奢る
				PRINTFORML スケスケで殆ど裸の衣装に身を包みながら妖艶に踊る%ANAME(対象)%の姿に観客は喝采と下品な野次を飛ばす
				PRINTFORML %ANAME(対象)%は男達に欲情の視線を向けられる事に興奮し子宮を疼かせながらより艶めかしく踊り続けた
				PRINTFORMW ショーの後、%ANAME(対象)%は気に入った客に買われてベッドの上で踊る事となった
			CASE 1
				PRINTFORML 退廃的な衣装を身にまとった%ANAME(対象)%が舞台の上でストリップショーを行っている
				PRINTFORML 目の前でお尻や恥部を突きだし見せつける様に振ると客は生唾を飲んでチップを下着に挟んでくれる
				PRINTFORML ショーの締めに下着を全て脱ぎ去りあられもない裸体を曝け出すと大量のおひねりが舞台に投げられた
				PRINTFORMW 熱視線を浴びてすっかり火照った%ANAME(対象)%は一人の客を誘い、静めてもらった
			CASE 2
				PRINTFORML %ANAME(対象)%はバニーガール衣装で手品師の助手をしている
				PRINTFORML 妖艶な笑みと極上の女体で舞台を彩る%ANAME(対象)%に観客達は釘付けとなり、舞台は大いに盛り上がる
				PRINTFORML 最後の手品で%ANAME(対象)%が一瞬で素っ裸にされると舞台の熱は最高潮となり大量のおひねりが飛び交った
				PRINTFORMW 仕事の後、上手く助手をこなしたご褒美として手品師の巧みなテクで存分に可愛がってもらった
			CASE 3
				PRINTFORML 今日の%ANAME(対象)%の担当演目は舞台の上での本番まな板ショーだ
				PRINTFORML 大勢の客に見られている前で媚薬を打たれた%ANAME(対象)%は屈強な男に犯されながらあられもなくヨガリ狂う
				PRINTFORML 結合部が丸見えの格好で激しく突き上げられ、羞恥と快楽で思考が真っ白になりながら何度も絶頂した
				PRINTFORMW ショーの後は勃起した客一人一人のおチンポ様を丁寧にしゃぶって処理するサービスも行った
			CASE 4
				PRINTFORML 場末の娼婦の様な卑猥な衣装を身に着けた%ANAME(対象)%がポールダンスを踊っている
				PRINTFORML くるくると回りながらポールに胸やお尻をこすり付ける様に踊ると歓声が上がりおひねりが飛んでくる
				PRINTFORML 男に求められる快感に%ANAME(対象)%はすっかりドはまりし、彼らに求められるままに過激な踊りを繰り返した
```
