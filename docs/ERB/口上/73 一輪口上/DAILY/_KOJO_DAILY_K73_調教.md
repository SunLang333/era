# 口上/73 一輪口上/DAILY/_KOJO_DAILY_K73_調教.ERB — 自动生成文档

源文件: `ERB/口上/73 一輪口上/DAILY/_KOJO_DAILY_K73_調教.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K73_TRAIN_RATE, KOJO_DAILY_K73_TRAIN_DECISION, KOJO_DAILY_K73_TRAIN_GENRE, KOJO_DAILY_K73_TRAIN; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K73_TRAIN_RATE(対象)
#DIM 対象
RETURN 1000


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K73_TRAIN_DECISION(対象)
#DIM 対象

SIF !IS_SLAVE(対象)
	RETURN 0

SIF CFLAG:対象:従属度 >= 5000
	RETURN 0

SIF !ITEM:アナルバイブ && !ITEM:バイブ　&& !ITEM:縄
	RETURN 0

SIF ABL:MASTER:性技 < 3
	RETURN 0

SIF KDVAR:対象:一輪_調教
	RETURN 0

SIF !HAS_PENIS(MASTER)
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K73_TRAIN_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ



;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K73_TRAIN(対象)
#DIM 対象
#DIM 選択肢

KDVAR:対象:一輪_調教 = 1

PRINTFORMW 「あっ……」
PRINTFORML 拠点で見回りをしている最中、%ANAME(対象)%とすれ違った
PRINTFORMW だが、%PRONOUN(対象)%は目を伏せてそのまま通り過ぎようとした
PRINTFORMW %ANAME(対象)%には忠誠を誓わせたはずだが、%PRONOUN(対象)%は最近どうもそのことを忘れかけているらしい
PRINTFORML ここらで一つ、自らの立場を教え直してやるべきだろうか……？
PRINTFORML

CALL ASK_YN("調教する", "今度でいいか")

IF RESULT == 1
	PRINTFORMW なにも今でなくとも良いだろう。忙しいのだ
	PRINTFORMW 放っておくことにした……
	RETURN 1
ENDIF

PRINTFORMW 「ッ、ち、ちょっと」
PRINTFORML すれ違いざまに、%PRONOUN(対象)%の尻を揉んでやる
PRINTFORMW 抗議するような表情を浮かべこちらを向いた%ANAME(対象)%の手を引っつかみ、自室へと連れ込んだ
PRINTFORMW 「な、何よ……私が何か悪いことしたっていうの？」
PRINTFORML 生意気な口をきく%ANAME(対象)%だが、その目も口調も震えている
PRINTFORMW %ANAME(MASTER)%に逆らってはならないということは、その身体がしっかり覚えているのだろう
PRINTFORML さて、まずは……
PRINTL
CALL ASK_MULTI("愛撫する", "下着をよこせ", "奉仕しろ")

SELECTCASE RESULT
	CASE 0
		PRINTFORMW 「あっ、ちょ、やめッ……」
		PRINTFORMW 逃げられないよう壁に追いやると、僧衣をまくり上げ、下着の内へと手を差し込む
		PRINTFORMW 「あ、やだ、だめ、アッ、あぁぁッ……」
		PRINTFORML %ANAME(MASTER)%に躾けられた肉体は、裂け目を撫でてやるだけで簡単に濡れそぼつ
		PRINTFORMW 軽く解れたところで内側に指を差し込み、弱いところを責めてやると、%ANAME(対象)%はもう腰砕けになっている
		PRINTFORMW 「ッ、くぅ、ッ……く……ゥ～ッ♥」
		PRINTFORML 声をあげまいと、%PRONOUN(対象)%は服の裾を噛んでいるが、無駄な努力というものだった
		PRINTFORMW 尼僧でありながらオンナとして出来上がったこの肉体の弱点がどこにあるかなど、お見通しなのだから
		PRINTFORMW 「アッ、はぁッ、あ、そこッ、そこだめ、私そこぉっ♥　あ、ひぁ、ッあぁッ……♥」
		PRINTFORML 入り口近くの浅いところをクリトリスと同時に苛めてやると、%ANAME(対象)%はたまらないというように膝も腰もかくつかせ、牝の表情を浮かべ始める
		PRINTFORMW いくらか従順さを見せたご褒美に、イかせてやるとしよう……
		PRINTFORMW 「ッあぁッ、～～～ッ♥」
		PRINTFORML ぐりっと、今までの優しい愛撫とは違い強く刺激してやると、不意の快楽に%PRONOUN(対象)%は声もなく絶頂した
		PRINTFORMW 弓なりに反った背と、秘部から噴き出した淫らな潮が、%ANAME(対象)%の覚えた快楽を物語っている
		PRINTFORMW 絶頂の余韻で脱力し、その場にくずおれかけた%ANAME(対象)%の腰を抱き留めた……
		CALL FUCK(対象, "Ｃ, Ｖ, 欲望")
	CASE 1
		PRINTFORMW 「は……？　何馬鹿なこと言って……」
		PRINTFORMW 下着を、よこせ
		PRINTFORMW 「ふ、ふざけないで、誰がそんな……」
		PRINTFORMW 下着を、よこせ
		PRINTFORMW 「……ッ」
		PRINTFORML 口答えは許さない。どちらが上の立場なのか、思い知らせてやる必要がある
		PRINTFORMW 強い口調で繰り返すと、%ANAME(対象)%は小さく呟く
		PRINTFORMW 「分かったわよ……渡せばいいんでしょう」
		PRINTFORMW ずいぶんと小生意気な返事だが、この段階ではこんなものだろう
		PRINTFORML 法衣の内に手を差し込む%PRONOUN(対象)%の姿を、たっぷりと視姦してやる
		PRINTFORMW 「ほら……これでいいんでしょう？」
		PRINTFORMW 「次は何をさせるつもりよ……」
		PRINTFORMW 彼女が身に着けていたのは、尼僧には不釣り合いな、いわゆる「オトナ」らしい下着だった
		PRINTFORMW まだ暖かいのは、彼女の体温が残っているのだ
		PRINTFORMW 次はなにをするのかと問う%PRONOUN(対象)%の表情には、倒錯の色が浮かんでいる……
		CALL FUCK(対象, "露出, 欲望")
	CASE 2
		PRINTFORMW 「ちょ……、本気なの、こんな昼間っから……」
		PRINTFORML 一物を露出させ、しゃぶれと命じると、%ANAME(対象)%は慌てたような声をあげた
		PRINTFORML だが、昼間であることと%ANAME(対象)%を調教することに、一体何の関わりがあるというのだろう
		PRINTFORMW それとも、自分に逆らうつもりか？
		PRINTFORMW 問うと、%ANAME(対象)%は畏れるように顔を伏せた
		PRINTFORMW 「分かった、分かったわよ……」
		PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の元に跪く
		PRINTFORMW 硬く膨らみ天を指すモノを眺める目には、微かながらオンナとしての本性がうかがえる
		PRINTFORMW 「ッくぷ……んふ……んぅ」
		PRINTFORML 彼女の口内は熱く、唾液でぬめっている
		PRINTFORML 舌はねっとりと肉棒に絡みつき、精液をねだっているようだ
		PRINTFORMW 狙っているのでないとしたら、牝の本能がそうさせているのだろう……
		PRINTFORMW 「ぢゅるッ……ぐぷ、んく、ん」
		PRINTFORMW 「ぐぷっ……ぢゅぶ、ぐぶ、ッんむ」
		PRINTFORML 特に命じずとも、%ANAME(対象)%は深々と%ANAME(MASTER)%のモノを咥え込んでいる
		PRINTFORMW いくら生意気な態度をとっていようが、躾の成果というのは現れるものだ……
		PRINTFORMW 「ぐぷッ……ぷはッ、あっ、あぁ……」
		PRINTFORML 献身的な態度には褒美が必要だろう
		PRINTFORML %ANAME(対象)%の唇からモノを引き抜き、その顔に白いプレゼントをぶちまけてやる
		PRINTFORMW 彼女は待ち受けるように顔を差し出し、瞳を閉じ口を開けてそれを受け止めていった
		PRINTFORML ……もちろん、こんな精液まみれの顔では外を歩けないだろう
		PRINTFORMW せめてバレにくいようにしてやろうと、ベトベトと付着する精液を、たっぷりと顔に塗り込んでやる
		PRINTFORMW その間、%PRONOUN(対象)%は大人しくされるがままになっており、ゾクゾクとカラダを震わせるばかりだった……
		CALL FUCK(対象, "Ｍ, 欲望, 奉仕, 性技, 精愛, 口淫", "キス喪失", GET_SPERM_ID("不明"), @"%ANAME(MASTER)%のペニス", "", "", "調教")
ENDSELECT
PRINTL
PRINTFORMW %ANAME(対象)%は幾分従順な表情を浮かべてはいるが、躾というものは徹底して行われなくてはならない
PRINTFORML さて、次はどうしてやろうか……？
PRINTL

CALL ASK_MULTI_JUDGE("縄で縛って過ごさせる", ITEM:縄, "バイブを入れて過ごさせる", ITEM:バイブ, "アナルバイブを入れて過ごさせる", ITEM:アナルバイブ)

選択肢 = RESULT
SELECTCASE 選択肢
	CASE 0
		PRINTFORMW 「はい……わかり、ました」
		PRINTFORMW 縄で縛ってやることとしよう……
		PRINTFORMW 服を脱げ、そう命じると、%ANAME(対象)%は躊躇いつつも頷いた
		PRINTFORMW 「ッ、く、あ……キツっ……」
		PRINTFORMW 快楽のためでなく、躾のためだ。強めに縛っておく
		PRINTFORMW %ANAME(対象)%は顔を歪めるが、それ以上に肌や秘部への食い込みによる快楽が、その表情を蕩かせている
		PRINTFORMW ――そのまま法衣を着て、今日は一日そのままで過ごせ
	CASE 1
		PRINTFORMW 「はい……わかり、ました」
		PRINTFORML 素敵なおもちゃをくれてやるから、今日は一日それを着けて過ごせ……
		PRINTFORMW 命じると、%ANAME(対象)%は躊躇いながらも頷いた
		PRINTFORMW 「ッ……」
		PRINTFORMW 壁に手をつかせ、尻をむけさせる
		PRINTFORMW 法衣をまくって現れた秘部は、期待にひくひくと収縮し、涎を垂れ流している
		PRINTFORML ――とても尼僧とは思えない下半身だな？
		PRINTFORML からかうように言ってやると、%ANAME(対象)%はいやいやをするように首を振る
		PRINTFORMW だが、その腰は期待するようにくねっている……
		PRINTFORMW 「ァ……はっ、あ、あぁッ、入って、あぁぁッ……」
		PRINTFORMW そのままずぶずぶと、バイブをねじ込んでやる
		PRINTFORMW 蕩けた声をあげ、膝を軽くカクつかせながら、%ANAME(対象)%はされるがままになっている
		PRINTFORMW ――せっかくくれてやったんだから、絶対に落とすんじゃないぞ
	CASE 2
		PRINTFORMW 「はい……わかり、ました」
		PRINTFORML 素敵なおもちゃをくれてやるから、今日は一日それを着けて過ごせ……
		PRINTFORMW 命じると、%ANAME(対象)%は躊躇いながらも頷いた
		PRINTFORMW 「ッ……」
		PRINTFORMW 壁に手をつかせ、尻をむけさせる
		PRINTFORMW 法衣をまくって現れた尻穴は、まるで性器のように期待にひくひくと収縮している
		PRINTFORML ――こんなところがいいだなんて、大した変態だな？
		PRINTFORML からかうように言ってやると、%ANAME(対象)%はいやいやをするように首を振る
		PRINTFORMW だが、その腰は期待するようにくねっている……
		PRINTFORMW 「ァ……はっ、あ、あぁッ、入って、あぁぁッ……」
		PRINTFORMW そのままずぶずぶと、背徳の穴にバイブをねじ込んでやる
		PRINTFORMW 蕩けた声をあげ、膝を軽くカクつかせながら、%ANAME(対象)%はされるがままになっている
		PRINTFORMW ――せっかくくれてやったんだから、絶対に落とすんじゃないぞ
ENDSELECT

PRINTFORMW 「はい……わかりました……♥」
PRINTFORMW 強く命じると、%ANAME(対象)%は熱に浮かされたような声で返事をした
PRINTFORMW そもそも、日々修行を積んでいる身だ。こういう苦行のような要素のある調教を本質的に好むのだろう
PRINTFORMW %ANAME(対象)%はそのまま、ふらふらとした足取りで部屋を後にした……

TALENT:対象:一線越えない = 0

FOR LOCAL, 0, 3
	PRINTL ・
```
