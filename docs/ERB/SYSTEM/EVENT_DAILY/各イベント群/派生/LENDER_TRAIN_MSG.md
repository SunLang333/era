# SYSTEM/EVENT_DAILY/各イベント群/派生/LENDER_TRAIN_MSG.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/LENDER_TRAIN_MSG.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_LENDER_TRAIN_DISABLE, EVENT_DAILY_DERIVATION_LENDER_TRAIN_DECISION, EVENT_DAILY_DERIVATION_LENDER_TRAIN, LENDER_TRAIN_MSG; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_LENDER_TRAIN_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("LENDER")


;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_LENDER_TRAIN_DECISION()
SIF DVAR:金貸し_返済期限 != -1
	RETURN 0
SIF DVAR:金貸し_残り融資額 <= 0
	RETURN 0
RETURN 1

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_LENDER_TRAIN()
#DIM 返済額
#DIM 対象


対象 = ID_TO_CHARA(DVAR:金貸し_カタID)

CALL LENDER_TRAIN_MSG(対象)

返済額 = ABL:(対象):Ｃ感 + ABL:(対象):Ｖ感 + ABL:(対象):Ａ感 + ABL:(対象):Ｂ感 + ABL:(対象):Ｍ感 + (ABL:(対象):欲望 * 3 / 2) + (ABL:(対象):性技 * 2) + ABL:(対象):性交 + ABL:(対象):奉仕
返済額 *= 1000
返済額 += RAND(0, DVAR:金貸し_融資総額 / 10)
返済額 = RAND(MIN(返済額, DVAR:金貸し_融資総額 / 10 - 1), DVAR:金貸し_融資総額 / 10)

DVAR:金貸し_残り融資額 = MAX(0, DVAR:金貸し_残り融資額 - 返済額)

PRINTFORML
PRINTFORM %ANAME(対象)%は、金
CALL COLOR_PRINT(@"{返済額}", カラー_注意)
PRINTFORML を返済したようだ
PRINTFORM 残り返済額は
CALL COLOR_PRINT(@"{DVAR:金貸し_残り融資額}", カラー_注意)
PRINTFORML だ……
PRINTFORMW

RETURN 1

@LENDER_TRAIN_MSG(対象)
#DIMS 竿役
#DIM 対象
竿役 = 金貸しの客
LOCAL = RAND:31
SELECTCASE LOCAL
	CASE 0
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客は太った中年男だ
		PRINTFORML 見た目は不快ながら、男のテクニックは大したもので、%ANAME(対象)%は何度もイカされてしまう
		PRINTFORML 男は%ANAME(対象)%に覆い被さると、体重の乗ったピストンで何度も何度も子宮を小突いた
		PRINTFORML 膣内に放たれる精液の熱さに、%ANAME(対象)%は恥も外聞もなくヨガり狂った……
	CASE 1
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客は見るからにそれと分かるチンピラだ
		PRINTFORML チンピラは横柄な態度で、彼女に奉仕をさせている
		PRINTFORML そして、自らへりくだった言葉を吐き、性交をねだるよう強要させた
		PRINTFORML %ANAME(対象)%は屈辱を感じながらも、男の性技の前に何度も絶頂してしまった……
	CASE 2
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客は一見なんということはない青年だ
		PRINTFORML 青年はベッドの上で腰を振りながら、%ANAME(対象)%に何度も愛をささやいた
		PRINTFORML 偽りの愛だとは分かっているが、女の本能が、それを信じそうになってしまう
		PRINTFORML 彼が膣内に種を吐き出すと、%ANAME(対象)%はその熱さに激しく絶頂した……
	CASE 3
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客はなんと、年端もいかぬ少年だ
		PRINTFORML %ANAME(対象)%は戸惑いながらも、少年をリードしてやる
		PRINTFORML 初めて触れる女体の美しさにどぎまぎとしながらも、彼も一生懸命それについていった
		PRINTFORML やがて彼が%ANAME(対象)%の膣内で果てると、彼女は何か満たされた思いになり、心の底から絶頂した……
	CASE 4
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客は、見るからにそれとわかる浮浪者だ
		PRINTFORML 部屋に入るなり、時間が勿体ないだろうと、彼は口での奉仕を強要してきた
		PRINTFORML 汚れたペニスを口で掃除させると、前戯もそこそこに%ANAME(対象)%の淫裂へ挿入した
		PRINTFORML 結局彼は時間いっぱいまで、何度も何度も%ANAME(対象)%に小汚い種を植え付けた……
	CASE 5
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客は、一見すると柔和な紳士だった
		PRINTFORML ところが彼は、部屋に入るなりサディスティックな笑みを浮かべ、%ANAME(対象)%を縛り上げた
		PRINTFORML そして鞭や蝋燭、口枷に目隠しに針、そして張型などを用い、%ANAME(対象)%を責めていった
		PRINTFORML 最後には容赦のないピストンを受け、%ANAME(対象)%は被虐の悦びを覚えながら乱れ悶えた……
	CASE 6
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客は、がっしりした身体をもつ精悍な青年だ。ペニスも立派なもので、男の理想型といったところだ
		PRINTFORML 見ているだけで身体が疼くのを感じ、%ANAME(対象)%は娼婦らしく、彼に淫らなサービスを行った
		PRINTFORML 彼もまた、%ANAME(対象)%の肉体に非常に満足し、何度も何度も熱く濃い精を放った
		PRINTFORML 彼のテクニックにすっかり魅了された%ANAME(対象)%は、個人的な連絡先を教え、立ち去る彼を見送った……
	CASE 7
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の客は、何の変哲もない普通の男性だ
		PRINTFORML それでも、部屋に焚きしめられた香や、あらかじめ飲まされた薬が、%ANAME(対象)%の気分を高める
		PRINTFORML 可も不可もない肉棒に、%ANAME(対象)%は熱心な奉仕を行っていく
		PRINTFORML 彼が%ANAME(対象)%の膣内で果てると、%ANAME(対象)%は感極まってあられもない声をあげた……
	CASE 8
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 今日の彼女は、店の表で通行人を呼び込む仕事を割り当てられた
		PRINTFORML %ANAME(対象)%の美しさに、道行く男達は簡単に話を聞いてくれる
		PRINTFORML 少し乳房や陰部を強調するようなポーズをとってやると、もうこちらの言いなりも同然だ
		PRINTFORML %ANAME(対象)%はそのままその男と店に戻り、客と娼婦としての熱い一夜を過ごした……
	CASE 9
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML なんと三人の客が、集団で彼女を買ったようだ
		PRINTFORML 彼らは%ANAME(対象)%の身体を好き放題に弄り、快楽を引き出していく
		PRINTFORML そして口と両穴に一物を突き立て、ずごずごとピストンを繰り返した 
		PRINTFORML 彼らが満足して部屋を後にする頃には、%ANAME(対象)%はあらゆる穴から白濁を零れさせていた……
	CASE 10
		PRINTFORML %ANAME(対象)%は金貸しの営む酒場で、給仕として働かされている
		PRINTFORML 制服はあきらかに普通のモノではない。乳房は剥き出しで、スカートも丈が短すぎる
		PRINTFORML 酒に酔った客達は、給仕をしている%ANAME(対象)%の身体に手を伸ばす
		PRINTFORML 逆らうことも許されず、%ANAME(対象)%はただされるがままにされてしまう
		PRINTFORML 最終的に%ANAME(対象)%は、興奮した客によって皆の見ている前で犯されてしまった……
	CASE 11
		PRINTFORML %ANAME(対象)%は金貸しの営む酒場で、給仕として働かされている
		PRINTFORML 酒に酔った一人の客が、%ANAME(対象)%の身体を弄び始める
		PRINTFORML 逆らうことも許されず、%ANAME(対象)%はそのテクニックに腰砕けになってしまう
		PRINTFORML 客はそのまま%ANAME(対象)%を手洗いに連れ込むと、濡れた穴でたっぷりと愉しんだ……
		PRINTFORML 解放されるころには、彼女の雌穴からは白濁がどろどろと溢れていた……
	CASE 12
		PRINTFORML %ANAME(対象)%は金貸しの営む酒場で、給仕として働かされている
		PRINTFORML 客の一人が%ANAME(対象)%を横に座らせ、酒を勧めてきた
		PRINTFORML %ANAME(対象)%は結局、潰れるまで客の相手をさせられた
		PRINTFORML その後、客は潰れた%ANAME(対象)%を部屋に運び込み、意識のない彼女の肉体で散々愉しんだ
		PRINTFORML 目覚めた彼女が最初に目にしたのは、あちこち白濁にまみれた自らの肉体だった……
	CASE 13
		PRINTFORML %ANAME(対象)%は金貸しの営む酒場で、踊り子として働かされている
		PRINTFORML 身につけているのは恥部を強調し肌を露出するような、派手で卑猥な衣装だ
		PRINTFORML 観客達は%ANAME(対象)%に好色な視線を向け、ニヤニヤと笑っている
		PRINTFORML 恥ずかしいことであるはずだというのに、%ANAME(対象)%は身体が熱くなるのを感じている
		PRINTFORML そのあと%ANAME(対象)%は、彼女を気に入った観客に買われ、娼婦として奉仕したようだ……
	CASE 14
		PRINTFORML %ANAME(対象)%は金貸しの営む酒場で、踊り子として働かされている
		PRINTFORML 今日の演目はいささか過激で、ステージの上でのオナニーショーだ
		PRINTFORML 恥ずかしがりながら身体を弄る%ANAME(対象)%に、観客は野卑な言葉を投げつける
		PRINTFORML 快楽の高まりに合わせて指の動きは激しくなり、%ANAME(対象)%は激しく絶頂した
		PRINTFORML その後%ANAME(対象)%は、彼女を気に入った観客に買われ、娼婦として奉仕したようだ……
	CASE 15
		PRINTFORML %ANAME(対象)%は金貸しの営む酒場で、給仕として働かされている
		PRINTFORML 酔っ払った客が陰茎を露出し、彼女に口での奉仕をもとめてきた
		PRINTFORML その肉棒のあまりのたくましさに、%ANAME(対象)%は断り切れなかった
		PRINTFORML %ANAME(対象)%はテーブルの下で彼に口奉仕をし、彼が精を吐き出すと、音を立てて全て呑み込んだ
		PRINTFORML 熱心な奉仕を気に入った客は、そのまま%ANAME(対象)%を買い、熱い夜を過ごしたようだ……
	CASE 16
		PRINTFORML %ANAME(対象)%は金貸しに個人的な奉仕を強要されている
		PRINTFORML %ANAME(対象)%は彼の一物をその口や乳房で悦ばしている
		PRINTFORML 彼が小さく呻くと、熱く粘っこい濁液が口腔にたっぷりと吐き出された
		PRINTFORML そのあまりに熱さにむせる%ANAME(対象)%を、金貸しはベッドに押し倒す
		PRINTFORML そしてその肉体で、たっぷりと愉しんだ……
		竿役 = 金貸し
	CASE 17
		PRINTFORML %ANAME(対象)%は金貸しに個人的な奉仕を強要されている
		PRINTFORML 金貸しは%ANAME(対象)%に媚薬を飲ませ、その身体で愉しんでいる
		PRINTFORML 薬による興奮と逞しい肉棒、そして巧みなピストンによって、%ANAME(対象)%はただ喘がされている
		PRINTFORML 金貸しが射精すると、%ANAME(対象)%はその鮮烈な快楽に、一際高い声をあげ絶頂した
		PRINTFORML コトが終わる頃には、%ANAME(対象)%の雌穴はどろどろと白いものを零していた……
		竿役 = 金貸し
	CASE 18
		PRINTFORML %ANAME(対象)%は金貸しの部下達に貸し与えられたようだ
		PRINTFORML たまの「上玉」を好きなだけ愉しもうと、部下達は%ANAME(対象)%と休みなく交わっている
		PRINTFORML 口も、両穴もふさがれ、%ANAME(対象)%は目を白黒させ快楽に悶えている
		PRINTFORML びゅるびゅると注がれる白濁が、彼女を激しく絶頂させる……
		PRINTFORML 解放される頃には、%ANAME(対象)%の穴からは止めどなく白いものがこぼれ落ちていた……
		竿役 = 金貸しの部下たち
	CASE 19
		PRINTFORML %ANAME(対象)%は金貸しの部下に貸し与えられたようだ
		PRINTFORML 部下とはいうが、ほとんどチンピラのようなものだ。彼は%ANAME(対象)%の服を乱暴に脱がせ、押し倒した
		PRINTFORML その愛撫はひどく乱暴なものだが、技術は的確なもので、%ANAME(対象)%は快感を押さえられない
		PRINTFORML %ANAME(対象)%が何度も絶頂を迎えた後、彼はその硬く太いペニスで、彼女のことを貫いた
		PRINTFORML ただ切なくヨガることしかできなくなった%ANAME(対象)%に、彼は何度も子種を吐き出した……
		竿役 = 金貸しの部下たち
	CASE 20
		PRINTFORML %ANAME(対象)%は金貸しから与えられた仕事でヘマをしてしまったようだ
		PRINTFORML 怒った金貸しによって、%ANAME(対象)%は「便器」の仕事をさせられている
		PRINTFORML ろくに金も持っていない浮浪者たちが彼女のいる「便所」を訪れては、彼女で「排泄」していく
		PRINTFORML 嫌だとは思っているのに、貫かれる快感に、%ANAME(対象)%は快楽を押さえられない
		PRINTFORML 解放されたころには、%ANAME(対象)%の全身は白濁まみれになっていた……
		竿役 = 浮浪者
	CASE 21
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で客をとらされている
		PRINTFORML 現れたのは、なんと見目麗しい女性だった
		PRINTFORML 何より驚くべきは、その股座に、雄々しいペニスが生えていたことだろう
		PRINTFORML 目を疑う%ANAME(対象)%だったが、逞しいペニスの前には、女の本能を押さえられなかった
		PRINTFORML %ANAME(対象)%は彼女に積極的に奉仕し、女の穴でその精を受け止めた……
	CASE 22
		PRINTFORML %ANAME(対象)%は金貸しに仕事の特訓を受けさせられている
		PRINTFORML 娼婦としての特訓、つまりは金貸しとの性行為だ
		PRINTFORML 金貸しは%ANAME(対象)%を乱暴にベッドに押し倒し、彼女を貫いた
		PRINTFORML そりたつ怒張が出入りするたび、%ANAME(対象)%は目を白黒して嬌声を上げる
		PRINTFORML 熱い精液が胎内に注がれると、%ANAME(対象)%は背を反らして激しく絶頂した……
	CASE 23
		PRINTFORML %ANAME(対象)%は金貸しの営む娼館で働かされている
```
