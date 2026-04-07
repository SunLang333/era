# SYSTEM/EVENT_DAILY/各イベント群/BANDIT/BANDIT_CORRUPTION_野盗の士官篭絡.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/BANDIT/BANDIT_CORRUPTION_野盗の士官篭絡.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_BANDIT_CORRUPTION_RATE, EVENT_DAILY_BANDIT_CORRUPTION_DECISION, EVENT_DAILY_BANDIT_CORRUPTION_GENRE, EVENT_DAILY_BANDIT_CORRUPTION, SELECT_CHARA_LIST_SHOW_LOGIC_BANDIT_CORRUPTION_TARGET, SELECT_CHARA_LIST_SELECT_LOGIC_BANDIT_CORRUPTION_TARGET, SELECT_CHARA_LIST_SHOW_LOGIC_BANDIT_CORRUPTION_SPY, SELECT_CHARA_LIST_SELECT_LOGIC_BANDIT_CORRUPTION_SPY; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_BANDIT_CORRUPTION_RATE()
RETURN (DVAR:麻薬漬け_ターゲット > 0 ? 250 # 30)


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_BANDIT_CORRUPTION_DECISION()
#DIM 野盗
野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))

SIF CFLAG:MASTER:所属 != 野盗
	RETURN 0

SIF ITEM:麻薬 <= 0
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_BANDIT_CORRUPTION_GENRE()
RETURN デイリー_ジャンル_特殊勢力

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_BANDIT_CORRUPTION()
#DIM 対象
#DIM 実行者
#DIM 野盗
野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))

対象 = ID_TO_CHARA(DVAR:麻薬漬け_ターゲット)
実行者 = ID_TO_CHARA(DVAR:麻薬漬け_工作員ID)

IF DVAR:麻薬漬け_篭絡段階 > 0
	;工作員が死亡、捕虜、他の勢力に移っている場合は最初からになる
	IF 実行者 < 0 || CFLAG:実行者:所属 != CFLAG:MASTER:所属 || CFLAG:実行者:捕虜先 != 0
		PRINTFORML 例の士官籠絡計画は担当の工作員がいなくなってしまった為頓挫してしまった
		PRINTFORMW 作戦を最初からやり直す必要があるだろう
		DVAR:麻薬漬け_ターゲット = 0
		DVAR:麻薬漬け_工作員ID = 0
		DVAR:麻薬漬け_篭絡段階 = 0
	ENDIF

	;ターゲットが死亡、捕虜になっている場合は最初からになる
	IF 対象 < 0 || CFLAG:対象:捕虜先 != 0 || CFLAG:対象:特殊状態 == 特殊状態_死亡
		PRINTFORML 例の士官籠絡計画はターゲットが手の出せない状況になってしまい中断せざるを得なくなった
		PRINTFORMW 諦めて新しいターゲットを探す事にしよう
		DVAR:麻薬漬け_ターゲット = 0
		DVAR:麻薬漬け_工作員ID = 0
		DVAR:麻薬漬け_篭絡段階 = 0
	ENDIF
ENDIF
;初回、ターゲットと工作員決定
IF DVAR:麻薬漬け_篭絡段階 == 0
	PRINTFORML 敵国の女士官を籠絡する計画を立てた
	PRINTFORML 成功すれば大きな戦力に、何よりも良い性奴隷になるだろう
	PRINTFORMW 誰をターゲットにしようか？
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("BANDIT_CORRUPTION_TARGET", "BANDIT_CORRUPTION_TARGET")
	IF RESULT < 0
		PRINTFORMW やはりやめることにした
		RETURN 1
	ENDIF
	対象 = RESULT
	PRINTFORML %ANAME(対象)%をターゲットにする事にした
	PRINTFORMW 誰に任せようか？
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("BANDIT_CORRUPTION_SPY", "BANDIT_CORRUPTION_SPY")
	IF RESULT < 0
		PRINTFORMW やはりやめることにした
		RETURN 1
	ENDIF
	実行者 = RESULT
	IF 実行者 == MASTER
		PRINTFORML %ANAME(実行者)%自ら計画を実行する事にした
		PRINTFORMW %ANAME(実行者)%はニヤリと笑いながら計画を実行する準備を始めた
	ELSE
		PRINTFORML %ANAME(実行者)%に任せる事にした
		PRINTFORMW 彼はニヤニヤと笑いながら計画を実行する準備を始めた
	ENDIF
	DVAR:麻薬漬け_ターゲット = GET_ID(対象)
	DVAR:麻薬漬け_工作員ID = GET_ID(実行者)
;工作員とターゲットが健在の場合、籠絡作戦は続行される
ELSE
	対象 = ID_TO_CHARA(DVAR:麻薬漬け_ターゲット)
	実行者 = ID_TO_CHARA(DVAR:麻薬漬け_工作員ID)
	PRINTFORML 前回に引き続き%ANAME(対象)%を籠絡する作戦を実行する事にした
	PRINTFORMW %ANAME(実行者)%は特製の薬を手に彼女の元に向かった
ENDIF

PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
IF DVAR:麻薬漬け_篭絡段階 == 0
	PRINTFORML %ANAME(実行者)%は商人に化けて%ANAME(対象)%に謁見することに成功した
	PRINTFORML 怪しまれない様に礼儀正しく振る舞い、%ANAME(対象)%と挨拶を交わす
	PRINTFORML へりくだった態度の%ANAME(実行者)%に対し、少々偉そうな態度を取る%ANAME(対象)%に
	PRINTFORMW %ANAME(実行者)%は内心苛々しながらも、これからどのように調教してやろうかと考える
	PRINTFORML しばし他愛無い会話を交わした後、%ANAME(実行者)%は外来産の高級菓子を献上した
	PRINTFORML …もちろんただの菓子ではなく、中には特製の媚薬と麻薬がたっぷりと含まれている
	PRINTFORML %ANAME(対象)%は疑う事も無く喜んで受け取ると、一つ摘まんで美味しそうに口に含んだ
	PRINTFORMW それを見た%ANAME(実行者)%は心の中でほくそ笑みながら部屋を後にした
	PRINTFORML 
	PRINTFORML 深夜、%ANAME(対象)%はベッドの中で呻いていた
	PRINTFORML その顔は赤く染まっており、息を荒げながらもじもじと内股をこすり合わせている
	PRINTFORML %ANAME(対象)%は今日一日中、身体が火照って仕方がなかった
	PRINTFORML 眠れば何とかなるだろうと思っていたが、夜になりますます身体の疼きは強くなるばかりだった
	PRINTFORMW しかし%ANAME(対象)%にはその原因はわからず、ベッドの中でひたすら悶々としている
	PRINTFORML %ANAME(対象)%は遂に我慢できなくなり、ゆっくりと濡れそぼる秘所へと指を伸ばした
	PRINTFORML 軽くなぞるだけで痺れるような快楽が走り、彼女は身体をビクンと跳ねさせ甘い吐息を漏らした
	PRINTFORML 静かな寝室に響いたその声に、%ANAME(対象)%は誰かに聞かれたのではないかとビクッと震える
	PRINTFORML しかしそんなはずもなく、周囲はしんと静まりかえっており、ほっと安堵した彼女は再び己を慰めだした
	PRINTFORMW 息を潜めながらも次第に指の動きは激しくなっていき、やがて彼女の喘ぎ声が部屋の中に響き出した
	LOCAL:0 = RAND:3 + 3
	SETCOLOR カラー_オレンジ
	CALL FUCK(対象, "Ｃ, Ｂ, 自慰, 欲望")
	RESETCOLOR
	PRINTFORML 
	PRINTFORML 結局%ANAME(対象)%は夜が白むまでオナニーを続けてしまった
	PRINTFORMW しかし何度も達したものの彼女はどこか満ち足りない表情を見せていた
	CFLAG:対象:薬物依存 += RAND(20, 50)
	ITEM:麻薬 -= 1
	DVAR:麻薬漬け_篭絡段階 ++
ELSEIF DVAR:麻薬漬け_篭絡段階 == 1
	PRINTFORML %ANAME(実行者)%は再び%ANAME(対象)%に謁見している
	PRINTFORML 挨拶をしながら彼女の顔をチラと見やると、微かに頬を染めている様子がうかがえた
	PRINTFORMW 前回渡した“菓子”の効果が表れているようだ、%ANAME(実行者)%は彼女に見られない様にニヤリと笑う
	PRINTFORML %ANAME(実行者)%は今回も献上品として前回の菓子と共に香を渡した…リラックス出来る効果があると嘯いて
	PRINTFORML 彼の思惑に気付かない%ANAME(対象)%はそれを喜んで受け取った
	PRINTFORMW %ANAME(実行者)%は内心ほくそ笑むと早々に部屋を後にした
	PRINTFORML 
	PRINTFORML 深夜、香の焚かれた真っ暗な部屋の中で影が蠢き、喘ぎ声が響いていた
	PRINTFORML %ANAME(対象)%は寝間着姿で机の角に股間を擦り付けながらかくかくと腰を振っている
	PRINTFORML 特製の香によって昂ぶらされたその表情はだらしなく、まるで盛りのついた雌犬の様だった
	PRINTFORMW 最近の彼女は指だけでは物足りなくなってしまい、このように己を慰めるのが日課になっていた
	PRINTFORML 以前とは違い、もはや声を潜めることも無くあられもなくヨガリ狂い、自慰に没頭している
	PRINTFORML そのうち足をガクガクと震わせながら、%ANAME(対象)%は嬌声と共に大きく背を反らして絶頂に達した
	PRINTFORML その顔は恍惚としており、かつての恥じらいはすでに快楽によって押し流されつつあった
	PRINTFORMW しばし机に寄りかかり絶頂の余韻に浸った後、%ANAME(対象)%は再び腰を振り始めた
	LOCAL:0 = RAND:3 + 3
	SETCOLOR カラー_オレンジ
	CALL FUCK(対象, "Ｃ, Ｂ, 自慰, 欲望")
	RESETCOLOR
	PRINTFORML 
	PRINTFORML 結局、%ANAME(対象)%の淫らな行為は、明け方近くまで続いた
	PRINTFORMW くたくたになりベッドに倒れ込んだ彼女は、惚けたような表情で身体を震わせていた
	CFLAG:対象:薬物依存 += RAND(20, 50)
	ITEM:麻薬 -= 1
	DVAR:麻薬漬け_篭絡段階 ++
ELSEIF DVAR:麻薬漬け_篭絡段階 == 2
	PRINTFORML %ANAME(実行者)%は再び%ANAME(対象)%に謁見している
	PRINTFORML しかし彼女は%ANAME(実行者)%の挨拶にも上の空の様子で、身体をもじもじさせている
	PRINTFORML 体調がすぐれないようですね、と%ANAME(実行者)%はわざとらしく彼女を気遣うとお茶を差し出した
	PRINTFORML これを飲めばきっと落ち着きますよ、そう告げる彼の言葉に%ANAME(対象)%は疑う事も無くそれを口にした
	PRINTFORMW それを確かめた%ANAME(実行者)%はしばし彼女と他愛無い会話をして、待った
	PRINTFORML さほど間を置くことも無くその時は来た、%ANAME(対象)%の目がとろんとして呂律が回らなくなりだす
	PRINTFORML やがて体に力が入らなくなったようにソファに寄りかかり、辛そうに息を荒げだした
	PRINTFORML %ANAME(実行者)%は頃合いだと判断すると、彼女を介抱する振りをして近づき身体を支える
	PRINTFORML そしてさりげなく胸を揉むと、%ANAME(対象)%は甘い吐息を漏らして体を震わせた
	PRINTFORMW %ANAME(実行者)%はろくに抵抗も出来ない彼女を抱きかかえるようにして寝室へと連れ込んだ
	PRINTFORML 
	PRINTFORML %ANAME(実行者)%は%ANAME(対象)%をベッドに腰かけさせると、お茶の残りを飲ませる
	PRINTFORML するとますます彼女の息は荒げだし、押し寄せる快楽でビクビクと身体を震わせ出した
	PRINTFORML それでもかすかに残る理性で抵抗する彼女を無視し、%ANAME(実行者)%は彼女をベッドに押し倒し乱暴に服を脱がせる
	PRINTFORML %ANAME(対象)%はなんとか逃れようとしたが、性感帯を軽く弄られるだけで痺れるような快楽が走り身体が痙攣してしまう
	PRINTFORMW 彼が続けてトロトロになった割れ目をなぞる様に指を這わせると、彼女はビクンビクンと痙攣しながら嬌声を上げた
	PRINTFORML %ANAME(実行者)%は惚けた表情で力なく横たわる%ANAME(対象)%の両足を広げると、ペニスを取り出す
	PRINTFORML 彼女は小さく悲鳴を上げるも、その逞しい肉棒に思わず釘付けになり、ごくりと生唾を飲み込んだ
	PRINTFORML %ANAME(実行者)%は彼女に見せつける様に、愛液の溢れる蜜壺に、ゆっくりとペニスをねじ込んだ
	PRINTFORML 下腹部に潜りこんでくる灼熱の感覚に、%ANAME(対象)%は全身をのけぞらせながら声にならない声を上げて震えた
	IF TALENT:対象:処女 == 1
		PRINTFORMW その膣肉は処女のそれとは思えない程に蠢き、ペニスに絡みついてきた
	ELSE
		PRINTFORMW すっかり出来上がっていた膣肉はペニスに絡みつく様に蠢いてきた
	ENDIF
	PRINTFORML %ANAME(実行者)%は思わず射精しそうになるのをこらえ、膣の奥深くまで深々とペニスを沈めていく
	PRINTFORML %ANAME(対象)%は全身を痙攣させ涙を流しながら、壊れた人形の様に繰り返しピンク色の喘ぎ声を上げている
	PRINTFORML %ANAME(実行者)%は痙攣し脈打つ様に絡みついて来る極上の膣肉を堪能する様にペニスを出し入れする
	PRINTFORML 薬の効果ですっかり敏感になっている膣肉をペニスで抉られる度に、%ANAME(対象)%は頭が真っ白になりヨガり狂う
	PRINTFORMW しばしの間、部屋の中に%ANAME(対象)%の嬌声といやらしい蜜音が響き渡った
	PRINTFORML そして%ANAME(対象)%の頭がすっかり快楽で蕩けきった頃、突如彼女の膣奥にさらに強烈な熱がぶちまけられた
	PRINTFORML 不意に下腹部に与えられた衝撃に、彼女は一瞬気を失うほどの絶頂に達し、大きく背をのけぞらせて嬌声を上げた
	PRINTFORML %ANAME(対象)%の膣肉はきつくペニスを締め上げ、子宮に精液を吐き出される度に彼女は連続でアクメに達した
	PRINTFORMW その後も%ANAME(実行者)%に犯され続け、%ANAME(対象)%が自ら腰を振り出すのに時間はかからなかった
	CALL FUCK_RAPE(対象, GET_ID(実行者), @"%ANAME(実行者)%の\@RAND:2 ? ペニス # 唇\@", @"%ANAME(実行者)%")
	CALL FUCK_RAPE(対象, GET_ID(実行者), @"%ANAME(実行者)%の\@RAND:2 ? ペニス # 唇\@", @"%ANAME(実行者)%")
	PRINTFORML 
	PRINTFORML たっぷりと可愛がられた%ANAME(対象)%は夢見心地のままベッドの上で横たわっている
	PRINTFORMW %ANAME(実行者)%が彼女の耳元でまた来ると告げると、%ANAME(対象)%はぶるっと身震いした
```
