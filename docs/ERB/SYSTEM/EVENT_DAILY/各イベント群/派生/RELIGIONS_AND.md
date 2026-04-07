# SYSTEM/EVENT_DAILY/各イベント群/派生/RELIGIONS_AND.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/RELIGIONS_AND.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_RELIGIONS_PROGRESS_DISABLE, EVENT_DAILY_DERIVATION_RELIGIONS_PROGRESS_DECISION, EVENT_DAILY_DERIVATION_RELIGIONS_PROGRESS, EVENT_DAILY_DERIVATION_RELIGIONS_AFTER_DISABLE, EVENT_DAILY_DERIVATION_RELIGIONS_AFTER_DECISION, EVENT_DAILY_DERIVATION_RELIGIONS_AFTER_SETTARGET, EVENT_DAILY_DERIVATION_RELIGIONS_AFTER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_RELIGIONS_PROGRESS_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("RELIGIONS")

;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_RELIGIONS_PROGRESS_DECISION()

IF DVAR:新興宗教_潜入中キャラID > 0 && ID_TO_CHARA(DVAR:新興宗教_潜入中キャラID) == -1
	DVAR:新興宗教_潜入中キャラID = 0
	RETURN 0
ELSEIF DVAR:新興宗教_潜入中キャラID > 0
	RETURN 1
ENDIF

RETURN 0
;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_RELIGIONS_PROGRESS()
#DIM 対象
#DIM 満足度
対象 = ID_TO_CHARA(DVAR:新興宗教_潜入中キャラID)

IF CFLAG:対象:捕虜先 != 0
	PRINTFORMW %ANAME(対象)%は、牢獄の中で悶々と過ごしている……
	RETURN 1
ELSEIF CFLAG:対象:特殊状態 == 特殊状態_死亡
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_教祖様のしもべ
	DVAR:新興宗教_潜入中キャラID = 0
	DVAR:新興宗教_洗脳度 = 0
	RETURN 1
ELSEIF CFLAG:対象:特殊状態 == 特殊状態_放浪
	PRINTFORMW %ANAME(対象)%は放浪中、新興宗教への潜入捜査から離れ教祖の洗脳を逃れた様だ
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_教祖様のしもべ
	DVAR:新興宗教_潜入中キャラID = 0
	DVAR:新興宗教_洗脳度 = 0
	RETURN 1
ELSEIF CFLAG:対象:所属 != CFLAG:MASTER:所属
	PRINTFORMW 他国に移った%ANAME(対象)%は、新興宗教への潜入捜査から離れ教祖の洗脳を逃れた様だ
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_教祖様のしもべ
	DVAR:新興宗教_潜入中キャラID = 0
	DVAR:新興宗教_洗脳度 = 0
	RETURN 1
ELSEIF !IS_FEMALE(対象)
	PRINTFORMW %ANAME(対象)%が女ではなくなったので、教祖は手を引いたようだ
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_教祖様のしもべ
	DVAR:新興宗教_潜入中キャラID = 0
	DVAR:新興宗教_洗脳度 = 0
	RETURN 1
ENDIF
PRINTFORMW %ANAME(対象)%は今日も教団へ調査に向かった
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
IF !RAND:8
	PRINTFORML 今日も教祖の部屋に呼ばれた
	PRINTFORML しかし何だか嫌な予感がする…
	PRINTFORMW 前回も彼の部屋に入った後の記憶がなかった
	PRINTFORML 悩んでいると司祭の一人に話しかけられた
	PRINTFORML なんと彼は%ANAME(対象)%の正体を知っていた
	PRINTFORMW 身構える%ANAME(対象)%に対して彼は話をつづけた
	PRINTFORML 教祖の秘密を教えてあげるから二人でゆっくりで話がしたい、と
	PRINTFORMW 彼は囁きながら%ANAME(対象)%の腰に手を回してきた
	PRINTFORML …どうしよう？
	CALL ASK_YN("取引する" ,"断る")
	IF RESULT == 1
		PRINTFORMW %ANAME(対象)%は怪しげな取引を断り、教祖の部屋へ向かった
	ELSE
		PRINTFORML 男のいやらしさに嫌悪感を覚えつつも今は有益な情報が欲しい
		PRINTFORML %ANAME(対象)%は取引をする事にした
		PRINTFORMW 彼は舌なめずりをすると%ANAME(対象)%の腰を抱いて自分の部屋へ招き入れた
		PRINTFORMW ………
		CALL FUCK_RAPE(対象, GET_SPERM_ID("信者"), @"信者の\@ RAND:2 ? ペニス # 唇\@", "信者")
		満足度 = ABL:対象:Ｃ感 + ABL:対象:Ｖ感 + ABL:対象:Ｂ感 + ABL:対象:Ａ感 + ABL:対象:Ｍ感
		満足度 += ABL:対象:欲望 + ABL:対象:精愛 + ABL:対象:奉仕 + ABL:対象:性技 + ABL:対象:性交
		IF 満足度 >= 30 + RAND:20
			PRINTFORMW %ANAME(対象)%は彼のテクを上回り、情報を引き出す事に成功した
			PRINTFORML 何と教祖は薬と洗脳術で若者達を食い物にしているらしい
			PRINTFORML そして既に%ANAME(対象)%もその術中にハメられていたというのだ
			PRINTFORMW %ANAME(対象)%はその情報を持ち帰ると早速軍を動かして教祖を逮捕した
			PRINTFORMW %ANAME(対象)%の行動により若者達は救われる事になった
			DVAR:新興宗教_発生フラグ = 2
			DVAR:新興宗教_潜入中キャラID = 0
			DVAR:新興宗教_洗脳度 = 0
		ELSE
			PRINTFORML 彼のテクは想像以上で、情報を引き出す前に気をやってしまった
			PRINTFORML 気が付いた時には、%ANAME(対象)%は教団施設の前に放り出されていた
			PRINTFORMW 騙された事への憤りとセックスの余韻でフラフラになりながら帰路についた
		ENDIF
		RETURN
	ENDIF
ENDIF

IF DVAR:新興宗教_洗脳度 > 10
	PRINTFORML %ANAME(対象)%はいつも通り教祖の部屋にお勤めに向かった
	PRINTFORML 部屋に入り彼を目にした途端、キィン…と頭の中に何かが響いた
	PRINTFORMW その瞬間、%ANAME(対象)%は今までされてきた事を全て思い出し絶句する
	PRINTFORML 同時にすっかり調教された肉体も疼きだし、ガクガクと震え汗ばみだした
	PRINTFORML ベッドに座る教祖は%ANAME(対象)%の様子をニヤニヤと眺めているだけだ
	PRINTFORMW 彼の洗脳術と薬の効果で弄ばれたことを思い出した%ANAME(対象)%はキッ！と彼を睨み付けた
	PRINTFORML 
	PRINTFORML いや、睨み付けたつもりだった
	PRINTFORMW 
	PRINTFORML しかしその目には♥が浮かび、口は半開きで息を荒げ、もじもじと股を擦り合せていた
	PRINTFORML そうか、こうやって若者達も思い通りにされてきたのだと、自覚した時にはもう遅かった
	PRINTFORMW 彼は%ANAME(対象)%ほどの極上に肉体と精神を持つものは稀だと侮蔑混じりの声色で賞賛する
	PRINTFORML しかしその言葉も%ANAME(対象)%の頭には入ってこず、抗えない精への衝動で埋め尽くされている
	PRINTFORML 彼は服を脱ぎその一物、今まで%ANAME(対象)%を散々悦ばせてくれた愛おしいペニスを露出した
	PRINTFORMW ソレを目にした途端%ANAME(対象)%は気づけば自発的に服を脱ぎ彼に跪き…ソレにキスをしていた
	PRINTFORML 思い出したのは恥辱でも屈辱でもなく、圧倒的な雌の悦びとセックスの快楽だけだった
	PRINTFORML すっかり彼の虜になっていた%ANAME(対象)%は洗脳されていないにも拘らず自ら身体を差し出していた
	PRINTFORMW 任務も誇りも理性も、この雄々しいペニス様の前には、全てが陳腐だった……
	CALL FUCK_RAPE(対象, GET_SPERM_ID("教祖様"), @"教祖様の\@ RAND:2 ? ペニス # 唇\@", "教祖様")
	CALL FUCK_RAPE(対象, GET_SPERM_ID("教祖様"), @"教祖様の\@ RAND:2 ? ペニス # 唇\@", "教祖様")
	PRINTFORML 
	CALL COLOR_PRINTW(@"%ANAME(対象)%はその日、教祖に身も心も人生も全て捧げ、肉奴隷になる事を宣言した", カラー_ピンク)
	SETBIT TALENT:対象:デイリー系, 素質_デイリー_教祖様のしもべ
	IF 対象 != MASTER
		PRINTFORML 
		PRINTFORML 後日、%ANAME(対象)%は%ANAME(MASTER)%に潜入調査の報告をした
		PRINTFORML 無論内容は改ざんしており、特に問題は無いとされている
		PRINTFORML 教団は素晴らしく消えている若者については別の理由がある、と…
		PRINTFORMW %ANAME(MASTER)%は少し変に思いつつもその報告を受け入れ調査をひとまず終わらせた
		PRINTFORMW …%ANAME(対象)%が虚ろに口端を上げるのにも気づかずに
	ENDIF
	DVAR:新興宗教_潜入中キャラID = 0
	DVAR:新興宗教_洗脳度 = 0
	RETURN 1
ELSEIF DVAR:新興宗教_洗脳度 <= 5
	PRINTFORML 教祖に呼び出された%ANAME(対象)%は再び彼の部屋に向かった
	PRINTFORML …しかしいざ彼と面と向かい話をするうちに再び%ANAME(対象)%の意識は薄れた
	PRINTFORMW ニヤリと笑う教祖が一言『脱げ』と告げると、%ANAME(対象)%は従順にそれに従った
ELSE
	PRINTFORML %ANAME(対象)%は何も言われず無意識に教祖の部屋に向かった
	PRINTFORML 部屋に入る前は意識がはっきりしていたが部屋に入るなり再び意識が薄れた
	PRINTFORMW そして教祖の姿を目にした%ANAME(対象)%は今日も『お勤め』の為に自ら服を脱いだ
ENDIF
PRINTFORML 
SELECTCASE RAND:20
	CASE 0
		PRINTFORML %ANAME(対象)%は教祖に跨り髪を振り乱して激しく腰を振っている
		PRINTFORML 野太いチンポで突き上げられる度に無様な声を上げてビクビクと痙攣する
		PRINTFORMW 「おぉ、おぉ、可愛い奴め！望み通りにくれてやるぞっ！」
		PRINTFORML 愛おしい教祖の孕ませ汁を求め、%ANAME(対象)%は腰をくねらせおねだりする
		PRINTFORMW …そして子宮口に密着されながら射精されながら待望の種付けアクメに達した
	CASE 1
		PRINTFORML %ANAME(対象)%は教祖の射精したてのちんぽをお掃除フェラしている
		PRINTFORML 先程まで自分を悦ばせてくれた雄々しいおちんぽを夢中になって奉仕する
		PRINTFORMW むせ返る雄の匂いに頭がクラクラとして下腹部がキュンキュンと疼いた
		PRINTFORML 「上手になったではないか、これはまたご褒美をくれてやらんといかんな」
		PRINTFORMW …奉仕のご褒美に再び犯されると、%ANAME(対象)%は何度も雌の悦びに達しまくった
	CASE 2
		PRINTFORML %ANAME(対象)%はドギーバックの態勢で教祖に犯されヨガっている
		PRINTFORML 首輪とアナル尻尾をつけられてワンワンと鳴くその姿はまさに雌犬だ
		PRINTFORMW 「おら！おら！このいやしい犬め！おぉ！お！可愛がってやるぞぉ！」
		PRINTFORML ご主人様残しの動きが加速すると、ゾクゾクと震えながら涎を垂らした
		PRINTFORMW …%ANAME(対象)%は彼の可愛い雌ペットとして一晩中可愛がられご褒美を貰った
	CASE 3
		PRINTFORML %ANAME(対象)%は教祖に圧し掛かられ種付けプレスを喰らっている
		PRINTFORML ドチュン♥ドチュン♥と激しいピストンを喰らう度に結合部から愛液が溢れる
		PRINTFORMW 「ふっ、ふっ、ふぅ！どうじゃ！わしのちんぽはどうじゃ！ふぅ！」
		PRINTFORML 何度も射精して衰えない彼の攻めに%ANAME(対象)%はイキっぱなしでヨガり狂う
		PRINTFORMW …そして再び灼熱のザーメンを放たれると、彼に抱きつきながら嬌声を響かせた
	CASE 4
		PRINTFORML %ANAME(対象)%は淫らな踊子衣装を着せられて教祖に抱かれている
		PRINTFORML 彼の巧みなテクで全身を弄ばれ、%ANAME(対象)%は喘ぎながら身をくねらせ踊る
		PRINTFORMW 普段と違う衣装での行為にお互い興奮しきり、汗だくになってまぐわう
		PRINTFORML 「ほっほっ！お前は本当に男を悦ばせる才能があるのぉ…」
		PRINTFORMW …教祖の愛を何度も子宮で受け止めながら%ANAME(対象)%は一晩中踊り続けた
	CASE 5
		PRINTFORML 虚ろな瞳の%ANAME(対象)%が大勢の信者の前で教祖に犯されている
		PRINTFORML 激しく突き上げられる度に%ANAME(対象)%は体を跳ねさせ、無様な姿を彼らに晒す
		PRINTFORMW 「ほれ！ほれ！どうじゃ！皆に見られておるぞ！ふほっ！」
		PRINTFORML %ANAME(対象)%は呆けながらも、信者達の興奮した視線を感じて息を荒げ潮を吹いた
		PRINTFORMW …教祖から種付けされる様子を大勢に観られながら何度もアクメに達した
	CASE 6
		PRINTFORML %ANAME(対象)%は教祖と対面座位の態勢で激しく愛し合っている
		PRINTFORML 身体を密着させ舌を絡ませ下半身をぶつけ合ってひたすら肉欲に溺れる
		PRINTFORMW 何も変わったことはないただのセックスだが、その濃厚さに夢中になる
		PRINTFORML 愛し合えば愛し合う程子宮の疼きは増し、%ANAME(対象)%はもっともっととねだる
		PRINTFORMW …%ANAME(対象)%は乳首を甘噛みされながら射精されて大きく身を仰け反らせた
	CASE 7
		PRINTFORML リードで引かれた%ANAME(対象)%が教祖に連れられ教会内を歩く
		PRINTFORML 震える股間からは大量のザーメンと愛液が溢れ、道しるべになっている
		PRINTFORMW 「ほれ、もっと早く歩け！今日は色々予定があるのだからな！」
		PRINTFORML 彼は気まぐれに%ANAME(対象)%をオナホの様に使っては遠慮なく膣出ししていく
		PRINTFORMW …そんな都合よく使われるだけの仕打ちにも、%ANAME(対象)%は悦びに惚けていた
	CASE 8
		PRINTFORML 目隠しされた%ANAME(対象)%がベッドで艶めかしく身をくねらせる
		PRINTFORML 「どうじゃあ、いつもより感じるじゃろぉ、ほれぇ、ここじゃあ」
		PRINTFORMW 何も見えない%ANAME(対象)%は教祖の激しい攻めにされるがままに嬌声を上げる
		PRINTFORML 体内で暴れるチンポの感触をいつも以上に感じてしまい、ヨガリ狂う
		PRINTFORMW …ザーメンが子宮壁に注がれるのをダイレクトに感じながらアクメに達した
	CASE 9
```
