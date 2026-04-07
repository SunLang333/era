# SYSTEM/EVENT_DAILY/各イベント群/派生/SAIMINSLAVE_PROGRESS_催眠調教中.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/SAIMINSLAVE_PROGRESS_催眠調教中.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_SAIMINSLAVE_PROGRESS_DISABLE, EVENT_DAILY_DERIVATION_SAIMINSLAVE_PROGRESS_DECISION, EVENT_DAILY_DERIVATION_SAIMINSLAVE_PROGRESS; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_SAIMINSLAVE_PROGRESS_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("SAIMINSLAVE")

;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_SAIMINSLAVE_PROGRESS_DECISION()

RETURN DVAR:催眠調教_発生フラグ < 0 && RAND:100 < 40

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_SAIMINSLAVE_PROGRESS
#DIM 対象

対象 = ID_TO_CHARA(DVAR:催眠調教_対象ID)

IF 対象 == -1
	DVAR:催眠調教_発生フラグ = 0
	DVAR:催眠調教_対象ID = 0
	DVAR:催眠調教_侵攻度 = 0
	RETURN 1
ENDIF

IF CFLAG:MASTER:所属 != CFLAG:対象:所属
	PRINTFORMW %ANAME(対象)%と%ANAME(MASTER)%が別陣営に分かれたため、その後の様子はわからなくなった……
	DVAR:催眠調教_発生フラグ = 0
	DVAR:催眠調教_対象ID = 0
	DVAR:催眠調教_侵攻度 = 0
	RETURN 1
ENDIF

;ターゲットが女じゃなくなっていたらやめる
IF !IS_FEMALE(対象)
	PRINTFORMW %ANAME(対象)%が女をやめたので、催眠調教師は興味を失ってしまったようだ……
	DVAR:催眠調教_発生フラグ = 0
	DVAR:催眠調教_対象ID = 0
	DVAR:催眠調教_侵攻度 = 0
	RETURN 1
ENDIF

;ターゲットが捕虜になったらやめる
IF CFLAG:対象:捕虜先
	PRINTFORMW %ANAME(対象)%が捕らえられたので、催眠調教師はこれ以上の調教を諦めたようだ……
	DVAR:催眠調教_発生フラグ = 0
	DVAR:催眠調教_対象ID = 0
	DVAR:催眠調教_侵攻度 = 0
	RETURN 1
ENDIF

IF CFLAG:対象:特殊状態 == 特殊状態_死亡
	PRINTFORMW %ANAME(対象)%が死亡したので、催眠調教師はこれ以上の調教を諦めたようだ……
	DVAR:催眠調教_発生フラグ = 0
	DVAR:催眠調教_対象ID = 0
	DVAR:催眠調教_侵攻度 = 0
	RETURN 1
ENDIF

IF DVAR:催眠調教_侵攻度 < 3
	PRINTFORML 例の詐欺まがいの男に呼び出しを受けた
	PRINTFORMW ちゃんと更生したかを確認しに向かった
ELSEIF 催眠調教_侵攻度 < 6
	PRINTFORML 催眠調教の呼び出しを受けた
	PRINTFORML 詐欺から足を洗い頑張っている様だ
	PRINTFORMW 私は雌豚調教を受ける為に彼の元に向かった
ELSE
	PRINTFORML "ご主人様"から呼び出しを受けた
	PRINTFORML もう少しで調教が完了すると言っていた
	PRINTFORMW 何のことか分からないが秘所をヒクつかせながら彼の元に向かった
ENDIF
PRINTFORML 
PRINTFORML 待ち合わせ場所では彼が下卑た笑みを浮かべていた
PRINTFORML 「へっへっへ、よく来たな」
PRINTFORMW 何時もの様にいやらしく腰に手を回される
PRINTFORML 「それじゃあ早速今日も調教を始めようか」
PRINTFORML 勿論、更生を確認する為に来たのだから
PRINTFORMW 彼は舌なめずりをすると私の耳元で何かを囁いた……
PRINTFORML
SELECTCASE RAND:20
	CASE 0
		PRINTFORML 「オラ！オラ！この糞女！これがいいんだろ！」
		PRINTFORML 彼のチンポが深々とねじ込まれ衝撃で身体が跳ねてしまう
		PRINTFORMW 一突き毎に逞しい肉棒が胎内を押し広げられる感覚に視界が真っ白になる
		PRINTFORML 「だらしなく喘ぎやがって！お前はなんだ！おら！答えろ！」
		PRINTFORML 答えようとするがより一層激しく腰を打ち付けられ喘ぎ声しか出せない
		PRINTFORMW いやしい雌犬です♥あなた様専用のちんぽ穴です♥
		PRINTFORMW 私が快楽に震える舌で必死に答えると彼は満足そうに笑い声を上げた
		PRINTFORML 「ひっひっひ！よく言えたな！オラ！ご褒美の種付けだ！」
		PRINTFORML 一際深い一撃で意識が飛ぶと同時に射精され、たまらずアクメッてしまった
		PRINTFORML 子宮壁に伝わる熱に視界がチカチカと瞬き絶頂しながら絶頂を繰り返す
		PRINTFORMW 「おっおっ！生意気に締め付けやがって！そんなに全部欲しいか！」
		PRINTFORML 私は我ながらだらしないアヘ顔を晒しながら全身で彼のチンポにしがみついていた
		PRINTFORML ザーメンを一滴残らず注がれ、彼のチンポが抜けるとまたイってしまい潮を吹いた
		PRINTFORMW その日の調教は激しく、その後も延々と抱かれ絶頂しっぱなしにされてしまった……
	CASE 1
		PRINTFORML 私は早速雌犬らしく全裸になり、差し出された首輪をつけた
		PRINTFORML ペットに相応しい恰好になった私が四つん這いになると彼が優しく撫でてくれた
		PRINTFORMW それだけで体が熱くなり子宮が疼いてどうしようもなく息を荒げてしまう
		PRINTFORML 散歩に行くぞと言われた私は「ワン♥」と鳴いて四つん這いで彼について行った
		PRINTFORML リードを引かれながらご主人様と夜道を歩くのはとても楽しく町中を回った
		PRINTFORMW 時折すれ違う人に奇異の目で見られたが、命ぜられるままに身体を見せつけた
		PRINTFORML 視線に晒され発情してしまった私は我慢できずにご主人様におねだりをした
		PRINTFORML ご主人様に呆れられたが路地裏に連れていかれると待望のご褒美をもらえた
		PRINTFORMW 大股を開きいやらしくおねだりすると逞しい雄チンポを容赦なくねじ込まれる
		PRINTFORML 火照り切った身体は一突きで絶頂に達してしまい情けない声を上げ身悶えてしまう
		PRINTFORML ドチュン♥ドチュン♥と乱暴に犯されるのがこの上なく嬉しく犬の様に吠えてヨガる
		PRINTFORMW そしてご主人様の精液を注がれながら何度もイキ狂い、種付けアクメの悦びを味わった
		PRINTFORML 「ふぅ、相変わらず良い穴だぜ」
		PRINTFORML 「オラ、いつまでも呆けてねぇでさっさと来い！まだ散歩は終わってねぇぞ」
		PRINTFORMW 余韻で痺れる私にも容赦なくご主人様はリードを引いて散歩を再開しました……
	CASE 2
		PRINTFORML 「オラ、さっさと脱げよ」
		PRINTFORML なんて男だろうか、家に連れ込むなり脱げ等と、従うわけがない
		PRINTFORMW 私はただ調教を受ける為に裸になるだけで誰がこの男の為に脱ぐものか
		PRINTFORMW 「へっへっへ、わかってねぇ面だな、このまま犯すのがたまんねぇんだ」
		PRINTFORML 男は勃起したペニスをそそり立たせながら私の身体をまさぐりだした
		PRINTFORML 乳首を乳房を、腹を腋をふとももを、そして秘所を好き放題に指と舌で愛撫される
		PRINTFORML 「相変わらず良い身体だぜ、いいのか？抵抗しないでよぉ」
		PRINTFORMW なぜ抵抗する必要があるのだろうか、ただ全身を弄ばれているだけなのに
		PRINTFORML 時間が惜しいから早く調教してほしいと言うと男は笑みを浮かべて押し倒してきた
		PRINTFORML 腰を掴まれギンギンに勃起したペニスを挿入されると一瞬意識が飛んでしまった
		PRINTFORMW 「あー、いいぜ、やっぱりこのまんこは最高だぁ！」
		PRINTFORML 男は情けない声を上げながら激しく腰を振り、私のまんこを使って扱いている
		PRINTFORML 私の方もすっかり蕩けた身体が敏感に反応して、恥ずかしい声を上げてしまう
		PRINTFORML 「おっおっおっ！締まったな！何だ、お前も感じてんのか！オラ！」
		PRINTFORMW グリグリと弱点を抉られると目の前に火花が散り、ビクンと跳ねてしまった
		PRINTFORML その反応に気を良くした彼は更に腰の動きを加速させていく
		PRINTFORML 「くぅ！出すぞ！おら！子宮を開けて受け止めろぉ！」
		PRINTFORML 彼に言われるまでもない、雄の子種を子宮で飲みこむのは雌の義務だ
		PRINTFORMW 私はキュッと膣を締め付けアヘ顔を晒しながら彼のザーメンを一滴残らず受け止めた……
	CASE 3
		PRINTFORML ふと気が付くと私は見知らぬ部屋にいた
		PRINTFORMW 私は部屋唯一の家具らしきベッドにドロドロに汚れたまま裸で寝転んでいた
		PRINTFORML 何があったのか何をされたのか一体ここはどこなのか、私は混乱し辺りを見回した
		PRINTFORML すると唯一の扉が開き一人の男が現れた
		PRINTFORML 「お、目覚めたか、意外と早かったな」
		PRINTFORMW そいつの顔を見て思い出した！私はこいつに騙され操られここに連れ込まれたのだ
		PRINTFORML そう、私はこいつの凶悪おチンポを調査してザーメンを採取する任務があったはずだ
		PRINTFORML しかしこいつは卑怯にも催眠術で私の意識を操り性玩具として弄んだ
		PRINTFORML 「へっへっへ、睨み付けてどうした、さっきまで随分楽しんでたくせに」
		PRINTFORMW なんという卑劣な男か、催眠術を使われなければ私が思う通りにされるわけがない
		PRINTFORML しかしもう同じ手は通じない、私は彼を睨み付けるとお股を開いて挑発した
		PRINTFORML このドスケベまんこを使ってお前のチンポを屈服させ生精液を子宮に注がせてやる
		PRINTFORML 「がっはっはっはっは！」
		PRINTFORMW 私の言葉に男は大声で笑った、おそらく恐怖を誤魔化す為のハッタリだろう
		PRINTFORML 「いいぜ、じゃあ早速勝負しようじゃねぇか」
		PRINTFORML 彼はこの上なく逞しく理想的な雄チンポ様をギンギンに勃起させて近づいてきた
		PRINTFORML 見るだけで孕んでしまいそうなその凶器に私の身体は悦び震え、熱く疼いた
		PRINTFORMW 結局私はおまんこを蹂躙され、なさけないアヘ顔を晒してしまったが、任務を達成できた
	CASE 4
		PRINTFORML 彼の家に招かれた私は早速用意された水着に着替えた
		PRINTFORML 水着と言っても殆ど紐のようなものでチンポを誘うにはちょうど良い衣装だった
		PRINTFORMW 「くっくっく、そんな娼婦みたいな恰好をして恥ずかしくねぇのか？」
		PRINTFORML 彼が一体何を言っているのか、なぜ笑っているのかわからなかった
		PRINTFORML これからチンポ誘惑エロダンスをするのだからその為の準備をするのは当然だろう
		PRINTFORML 常識のない彼に内心呆れつつも、それでもおチンポに犯してもらう為笑顔で対応した
		PRINTFORMW 頭に手を当て股を開き、腰をねっとりと振り、セックスアピールを見せつける
		PRINTFORML 私はだらしない雌豚です♥おまんこうずうずして仕方ないんです♥
		PRINTFORML 逞しいおチンポ様でガッツリ生ハメ交尾して妊娠汁ビュービューしてください♥
		PRINTFORML 女として相応しい台詞を可能な限りいやらしく述べながら腰をカクカク揺する
		PRINTFORMW 男はその姿にニヤニヤしていたが、ズボンの上からでも判る程に勃起していた
		PRINTFORML いくら取り繕っても所詮は男だなと思いながら、アヘ顔で腰を突き出しまんこを揺らす
		PRINTFORML 私の求愛ダンスに彼も遂に我慢できなくなった様で強引にベッドに押し倒された
		PRINTFORMW そして私の要求通り、火照ったトロトロの肉体を好き放題に犯される事になった……
	CASE 5
		PRINTFORML 「オラ！オラ！馬鹿女が！カメラに向かって挨拶しやがれ！」
		PRINTFORML 逞しいチンポで激しく犯されながら罵倒される
		PRINTFORMW 今日は彼の趣向で私のだらしない種付けシーンを記録する事になっている
		PRINTFORML 自分は雌として孕まされる瞬間をビデオに撮られるなんてとても興奮した
		PRINTFORML しかし乱暴に弱点を抉られ、私の視界は真っ白となり喘ぎ声しか上げられない
		PRINTFORML あひぃ♥あひぃ♥雌豚の私はご主人様に種付け交尾されながら悦んでいますぅ♥
		PRINTFORMW 震える喉から何とか声を振り絞り、カメラに向けてピースを決める
		PRINTFORML 「へっへっへ、まさに雌豚って顔だな！バッチリ撮られてるの解ってんのか！」
		PRINTFORML ずぱぁん！と一際深い一突きで再びアクメってしまい白目をむかされる
		PRINTFORMW だらしないアクメ顔を永遠に記録される事を考えるとそれだけで更に連鎖絶頂してしまう
		PRINTFORML 「おぅ、いつもより良く締まってるじゃねーか、このマゾ豚が」
		PRINTFORML 「罰としてこのビデオを里に流してやるよ！もちろん無修正でな！オラ！」
		PRINTFORML 交尾の様子を多くの男性に見られるなんて、想像するだけで悦びに震えちゃう♥
		PRINTFORMW その後もビデオテープがなくなるまで様々なプレイで公開レイプしてもらった……
	CASE 6
		PRINTFORML なんという事だろう、この男は詐欺から足を洗ったと思っていたのに嘘だった
		PRINTFORML 未だに催眠術などという粗末な嘘で女性を狙っているとわかったのだ
		PRINTFORMW 「あー、まじでこの穴最高だわ、オラもっと締め付けろ」
		PRINTFORML 彼は反省の色もなく今もこうして私を雌穴として乱暴に犯している
		PRINTFORML すでに何度も絶頂させられ溢れる程に膣出しされて私の身体は陥落寸前ね
		PRINTFORMW 「お前ここが好きなんだろ、オラ！また無様にイっちまえよ！」
		PRINTFORML んひぃ♥まんこ穿りながらいきなり乳首を抓むなんて、女の扱いが巧みな奴♥
		PRINTFORML 確かにこのテクがあれば女性を好き放題できるかもしれないが私には効かないわ
		PRINTFORML 潮吹きアクメしながらアヘ顔晒してしまうぐらいが精々よ、覚悟しなさい
		PRINTFORMW レイプは好きなだけすればいいけど詐欺はやめさせないといけないわ
		PRINTFORML んほぉ♥また来たぁ♥遠慮ないザーメンで深イキしちゃうぅ♥
		PRINTFORMW 「おーおー、生意気な事言いながら無様にイキ狂いやがって、この淫売が」
		PRINTFORML 淫売なんて女性になんてひどい言葉を吐くのだろうか
		PRINTFORML 私はただおチンポであられもなくヨガリ狂う、雌として当然の行為をしているだけなのに
```
