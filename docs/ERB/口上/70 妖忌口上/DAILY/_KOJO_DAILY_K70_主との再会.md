# 口上/70 妖忌口上/DAILY/_KOJO_DAILY_K70_主との再会.ERB — 自动生成文档

源文件: `ERB/口上/70 妖忌口上/DAILY/_KOJO_DAILY_K70_主との再会.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K70_NTR_HIS_MASTER_RATE, KOJO_DAILY_K70_NTR_HIS_MASTER_DECISION, KOJO_DAILY_K70_NTR_HIS_MASTER_GENRE, KOJO_DAILY_K70_NTR_HIS_MASTER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K70_NTR_HIS_MASTER_RATE(対象)
#DIM 対象
RETURN 1000


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K70_NTR_HIS_MASTER_DECISION(対象)
#DIM 対象
#DIM 幽々子
#DIM 避妊
幽々子 = NAME_TO_CHARA("幽々子")

SIF IS_FALLEN(対象)
	RETURN 0

SIF !IS_SLAVE(幽々子)
	RETURN 0

SIF TALENT:幽々子:処女 || TALENT:幽々子:キス未経験
	RETURN 0

SIF ABL:幽々子:欲望 < ランク閾値:ランク_その他:ランク_C
	RETURN 0

SIF !HAS_PENIS(対象) || !HAS_PENIS(MASTER)
	RETURN 0

SIF KDVAR:対象:妖忌_主との再会
	RETURN 0

SIF CFLAG:対象:捕虜先 != CFLAG:MASTER:所属
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, -1, 1) && CHECK_KOJO_DAILY_HAPPEN(幽々子, 1, 0)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K70_NTR_HIS_MASTER_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K70_NTR_HIS_MASTER(対象)
#DIM 対象
#DIM 幽々子
#DIM 避妊
幽々子 = NAME_TO_CHARA("幽々子")


KDVAR:対象:妖忌_主との再会 = 1
KDVAR:対象:妖忌_孫娘との再会 = 1

PRINTFORMW %ANAME(MASTER)%は獄中の%ANAME(対象)%を訪ねた……
PRINTFORMW 「儂を笑いに来たか？」
PRINTFORMW 「ふん、上等。後で吠え面かくがいいわ、若造が」
PRINTFORMW 「言っておくが、儂が貴様ごときに尻尾を振ると思う……な」
PRINTFORML 強気で語る%ANAME(対象)%だが、その言葉は途中で詰まった
PRINTFORMW %ANAME(MASTER)%が連れてきた女性……%ANAME(幽々子)%に気づいたからだろう
PRINTFORMW 「%ANAME(幽々子)%様！？　一体……！？」
PRINTFORMW 「%ANAME(対象)%ったら、意地を張るところを間違えないほうがいいわよ？」
PRINTFORMW 「でないと、私みたいになっちゃうから……」
PRINTFORMW 「？　一体、何を……？」
PRINTFORMW どうもこの老人は、事態を理解できていないらしい
PRINTFORMW %ANAME(MASTER)%が合図するように顎をしゃくると、%ANAME(幽々子)%は自ら衣服を脱ぎ捨てる
PRINTFORMW 剥き出しになった秘部は、とろとろに濡れそぼっている……
PRINTFORMW 「わかるかしら？　この方に逆らうと、どうなるか」
PRINTFORMW 「こう、なっちゃうから……ぁッ♥　駄目、なのぉッ♥」
PRINTFORML 語る%ANAME(幽々子)%の秘部に指を這わせ、クニクニと弄ってやる
PRINTFORMW それだけで%PRONOUN(幽々子)%は膝をカクカクと震わせ、秘裂から牝汁を溢れさせている
PRINTFORMW 「%ANAME(幽々子)%様ッ……貴様ッ……何をしたァ！」
PRINTFORML 何もへったくれもない。少しばかり躾けてやっただけのこと
PRINTFORMW 元がお嬢様だろうとなんだろうと、快楽を刷り込んでやればただの牝になる……
PRINTFORMW 「貴様、この……こっちに来い！　その息の根を止めてくれるッ！」
PRINTFORMW 檻を掴み、こちらに手を伸ばしてくる。歳だろうに元気なことだ
PRINTFORML それにしても、歳なだけあって頭が固い。少しばかり、こいつに教えてやる必要があるか……
PRINTFORML
CALL ASK_MULTI(@"%ANAME(幽々子)%を%ANAME(対象)%にけしかける", @"%ANAME(幽々子)%を犯す", "何もせず帰る")

SELECTCASE RESULT
	CASE 2
		PRINTFORMW まあ、今日は%ANAME(幽々子)%を見せに来ただけだ
		PRINTFORMW そのまま帰ることにした……
	CASE 0
		PRINTFORMW せっかくの再会なのだから、「楽しませて」やろうじゃないか
		PRINTFORMW %ANAME(MASTER)%は牢の扉を開けると、%ANAME(幽々子)%を中に入れる
		PRINTFORMW 「ああ……%ANAME(対象)%……ッ♥」
		PRINTFORMW 「貴方が私のところにいたときから、ずっとこうしたかったの、知ってた……？」
		PRINTFORMW 「%ANAME(幽々子)%様……それは、違う……違う！　おやめくだされ！」
		PRINTFORML %ANAME(幽々子)%は牢に入るなり、衣服を脱ぎ捨て、その豊満な肉体を晒した
		PRINTFORMW さらに%ANAME(対象)%の衣服を剥ぎ取ると、露出させた逸物を口に含み、悦ばせていく
		PRINTFORMW %ANAME(MASTER)%がたっぷりと仕込んでやったとおりの仕草だ
		PRINTFORML %ANAME(対象)%は身を捩り逃れようとするが、両手を枷で戒められた状態で%ANAME(幽々子)%から逃げられるはずもない
		PRINTFORMW ただされるがままになり、%ANAME(MASTER)%仕込みの%ANAME(幽々子)%の技術によりモノを勃たせている……
		CALL ASK_YN("生でやらせる", "ゴムを投げ入れる")
		避妊 = RESULT
		IF 避妊 == 0
			PRINTFORML せっかくだ、%ANAME(対象)%にプレゼントをくれてやろう
			PRINTFORMW 尊敬する主が己の子を産んでくれる。最高の贈り物だろう
			PRINTFORMW 「あはっ♥　そんなこと言って、%ANAME(対象)%も硬くなってるじゃない？」
			PRINTFORMW 「その玉の中の、全部搾り取ってあげるから、私を孕ませて……♥」
		ELSE
			PRINTFORML ……ただ、やつの子を孕ませてやるつもりはない
			PRINTFORMW %ANAME(幽々子)%の子宮には他の使い道があるのだから
			PRINTFORMW 檻の外から一声かけ、%ANAME(幽々子)%にゴムを投げ渡す
			PRINTFORMW %ANAME(幽々子)%はすぐ意図を理解したようで、%ANAME(対象)%のペニスにソレを被せた
			PRINTFORMW 「ごめんなさいね%ANAME(対象)%、私はお腹の中まで全部、あの方のものだから……」
			PRINTFORMW 「でも、ちゃんとセックスはできるから、安心して、楽しみましょ？」
		ENDIF
		PRINTFORMW 「%ANAME(幽々子)%様、そんな……おやめ、ください……」
		PRINTFORMW 「どうして？　こんなに気持ちいいのに……ほらっ……あはぁッ♥　ねっ♥　きもちいッ♥」
		PRINTFORML すっかり弱気になった%ANAME(対象)%に跨り、%ANAME(幽々子)%は腰を落とした
		PRINTFORML ぶちゅん！　と音を立て、%PRONOUN(対象)%のモノはかつて主だった牝の膣に呑み込まれた
		PRINTFORMW %ANAME(幽々子)%はたまらないというような甘い声をあげ、すぐさま激しく腰を振りたてはじめる……
		PRINTFORMW 「あはぁッ♥　硬ッ、すごっ、%ANAME(対象)%のおちんちん、おじいちゃんなのに硬くて、いいぃッ♥」
		PRINTFORMW 「あぐッ……！　うぁ、あッ、あああッ……！」
		PRINTFORML %ANAME(幽々子)%は%ANAME(MASTER)%仕込みの腰使いで、%ANAME(対象)%に快楽を与えていく
		PRINTFORML ご無沙汰だろう老人が、そんな技巧に耐えられるはずもない
		PRINTFORML ただただうめき声を零しながら、首を振って現状を否定するばかりだ
		PRINTFORMW もちろん、発情した牝となった%ANAME(幽々子)%が、そんな懇願でやめるはずもない……
		PRINTFORMW 「アハッ、あッ、あんッ♥　……あれ」
		PRINTFORML ふと、%ANAME(幽々子)%の動きが止まった。怪訝な表情を浮かべている
		PRINTFORMW 対照的に、%ANAME(対象)%の身体はびくびくと痙攣していた。会陰のあたりが収縮している。射精したのだ
		PRINTFORMW 「%ANAME(対象)%ったら、もう射精しちゃった？　早いのね」
		PRINTFORMW 「%ANAME(幽々子)%様……うう……申し訳、ありません……ッ」
		PRINTFORML %ANAME(対象)%は力なく、謝罪の言葉を繰り返す
		PRINTFORMW ただ、倫理観を失った今の%ANAME(幽々子)%に、その言葉を正しく理解することはできない……
		IF 避妊
			PRINTFORMW 「もう、膣内射精くらい気にしなくていいのに。ちゃんとゴムもつけたんだし」
		ELSE
			PRINTFORMW 「別に気にしなくていいのに。いつかはどうせ射精るものなんだし」
		ENDIF
		PRINTFORMW 「そんなことより、続き、しましょ♥」
		PRINTFORMW 「続きって……うぁ、あああッ！？　%ANAME(幽々子)%様ッ、もうッ……」
		PRINTFORMW 「大丈夫♥　まだまだ射精せるでしょ、歳っていったって鍛えてるんだから♥」
		PRINTFORML 爪先から頭頂まで淫乱女と化した%ANAME(幽々子)%が、一度や二度の射精で満足するはずもない
		PRINTFORML %ANAME(幽々子)%は%PRONOUN(対象)%の上から退こうともせず、そのまま腰をくねらせはじめる
		PRINTFORML 対する%ANAME(対象)%は、がくがくと全身を跳ねさせ、快楽に翻弄されている
		PRINTFORMW ……悪くない見世物だ
		PRINTFORMW %ANAME(MASTER)%はしばし、熱烈な交尾を眺めていた……
		PRINTFORML
		PRINTFORML
		FOR LOCAL, 0, 5
			CALL FUCK(対象, "Ｃ, 射精, 性交, 苦痛快楽, Ｖ挿入, キス", "童貞喪失, キス喪失", 0, @"%ANAME(幽々子)%の唇", "", @"%ANAME(幽々子)%の膣", "調教")
			CALL FUCK(幽々子, "Ｃ, Ｂ, Ｖ, 性交, 奉仕, 性技, 精愛, Ｖ性交, キス, 口淫", @"\@ 避妊 == 0 ? 膣内射精, # \@ キス喪失, 処女喪失", 避妊 == 0 ? GET_ID(対象) # 0, @"%ANAME(対象)%のペニス", ANAME(対象), "", "調教")
		NEXT
		PRINTFORML
		PRINTFORML 
		PRINTFORMW しばらくして、ようやく%ANAME(対象)%は解放された
		PRINTFORMW 体力の限界まで搾り取られ、枯れ果てたようになっている……
		PRINTFORMW 「……忠誠を、誓う。誓いますから……%ANAME(幽々子)%様だけは……どうか……」
		PRINTFORMW 力なくつぶやいたのを見、%ANAME(対象)%を牢から出してやった
		PRINTFORMW もっとも、%ANAME(幽々子)%は好きに使わせてもらうが……
		CALL COLOR_PRINTW(@"%ANAME(対象)%が忠誠を誓いました", カラー_注意)
		CALL CHANGE_COUNTRY(対象, CFLAG:MASTER:所属, 1)
		TALENT:対象:服従 = 1
		TALENT:対象:チョロイン = 1
		TALENT:対象:臆病 = 1
		TALENT:対象:気丈 = 0
		CFLAG:対象:従属度 += 1500
		CFLAG:対象:依存度 += 300
	CASE 1
		PRINTFORMW 感動の再会なのだ。かつての主が今どのような仕事をしているか、見せてやるのも悪くあるまい
		PRINTFORMW そう考えた%ANAME(MASTER)%は、%ANAME(幽々子)%に短く声をかける
		PRINTFORMW 「はい……♥」
		PRINTFORMW %ANAME(幽々子)%は意図を察したようで、すぐさま%ANAME(MASTER)%に寄り添う
		PRINTFORMW たわわな乳房を下から掬うように軽く愛撫してやると、それだけで%ANAME(幽々子)%は甘い吐息をこぼす……
		PRINTFORMW 「貴様！　何をしている！　このッ……！」
		PRINTFORML 喚く%ANAME(対象)%を無視し、%ANAME(幽々子)%に目で合図をくれてやる
		PRINTFORMW 「では、失礼します……んふッ、んむ、ちゅる、ちゅう……♥」
		PRINTFORML %ANAME(幽々子)%はこちらに口づけ、濃厚な接吻をしつつ、さらに%ANAME(MASTER)%の逸物を手慣れた手つきで露出させる
		PRINTFORMW 白い指を絡め、ゆっくりと扱き、勃起させていく……
		PRINTFORMW 「ああ……お願いです、%ANAME(MASTER)%様、お恵みを……♥」
		PRINTFORML そのうちに我慢できなくなったか、%ANAME(幽々子)%が懇願するので、許してやる
		PRINTFORMW %ANAME(幽々子)%は%ANAME(MASTER)%の慈悲に感謝しながら、%ANAME(MASTER)%のもとに跪き、ソレを舐め、しゃぶり始める
		PRINTFORMW 「んぢゅッ、ぢゅる、ンフッ、んぅ、んっ、ぢゅぷぅッ♥」
		PRINTFORMW %ANAME(MASTER)%によって仕込まれた、%ANAME(MASTER)%好みの技術だ
		PRINTFORMW 唾液をたっぷりと絡ませながらペニスにむしゃぶりつくさまは、かつてはお嬢様「だった」とは思えないほどのものだ……
		PRINTFORMW 「%ANAME(幽々子)%様……おやめくだされ！　気をしっかり……！」
		PRINTFORML %ANAME(対象)%は鉄格子を歪めんばかりに握りしめながら、必死に喚いている
		PRINTFORMW %ANAME(幽々子)%%PRONOUN(対象)%をつまらなそうな目で見ると、吐き捨てた
		PRINTFORMW 「何を勘違いしているの%ANAME(対象)%……気をしっかり？」
		PRINTFORMW 「今までが間違ってたの。……全てのオンナは%ANAME(MASTER)%のために尽くすべき。私はそれに従ってるだけよ？」
		PRINTFORML なかなかおもしろいことを言う
		PRINTFORML その答えは気に入ったが、自分からねだっておいて勝手に口奉仕を中断したのはいただけない
		PRINTFORMW 罰をくれてやらねばなるまいと、%ANAME(MASTER)%は%ANAME(幽々子)%を押し倒す……
```
