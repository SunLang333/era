# 口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_枕の訪問販売.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_枕の訪問販売.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K134_DOOR_SALE_RATE, KOJO_DAILY_K134_DOOR_SALE_DECISION, KOJO_DAILY_K134_DOOR_SALE_GENRE, KOJO_DAILY_K134_DOOR_SALE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K134_DOOR_SALE_RATE(対象)
#DIM 対象
RETURN 300

;ごちゃごちゃし過ぎた

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K134_DOOR_SALE_DECISION(対象)
#DIM 対象
;ドレミーと所属が別、ドレミーが捕虜でなく、面識は問わない、プレイヤーのクールタイムが2以上蓄積している、30%

;マスターにペニスがないと出ない
SIF !HAS_PENIS(MASTER)
	RETURN 0

;一回きり
SIF KDVAR:対象:ドレミー_枕の訪問販売
	RETURN 0

;放浪してないとだめ
SIF CFLAG:対象:特殊状態 != 特殊状態_放浪
	RETURN 0

SIF IS_SP_COUNTRY(CFLAG:MASTER:所属)
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 0, 0, -1) && COOLTIME:MASTER:0 >= 2
;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K134_DOOR_SALE_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K134_DOOR_SALE(対象)
#DIM 対象
#DIM 枕代
#DIM 膝枕代
#DIM 判定値

;先にイベントで必要な金額を決める
枕代 = RAND(DAY *100, DAY * 300)
膝枕代 = 枕代 * 5

PRINTFORML %ANAME(MASTER)%が仕事をしていると、部下が来客を告げた……
PRINTFORMW なんでも「枕の訪問販売」だそうだ
PRINTFORMW 気分転換に%ANAME(MASTER)%は、会うことにしてみた
PRINTFORML ・
PRINTFORML ・
PRINTFORML ・
PRINTFORMW 「どうもこんにちは、\@ CFLAG:対象:面識 ? %ANAME(対象)%です # 私は%NAME_FORMAL(対象)%と申します \@」
PRINTFORMW 「最近よく眠れてますか？　気持ち良く起きれてますか？」
PRINTFORML 「きっと%ANAME(MASTER)%様ほどの方になられると、何かと忙しいでしょう」
PRINTFORMW 「生涯の3分の1は睡眠に充てられる以上、睡眠にも質を求めたいものですね」
PRINTFORML そう言って%ANAME(対象)%は、どこからともなく枕を出してきた
PRINTFORMW とくに見た目が変わった様子もなく、至って普通の枕だが……
PRINTFORML
PRINTFORML
PRINTFORML 「フフッ、これはスイート安眠枕。　私が監修して作らせた極上の枕です」
PRINTFORMW 「この肌触り、感触に大きさどれをとっても万人受けする究極の枕」
PRINTFORML %ANAME(対象)%は自ら枕に顔を埋もれさせ、ふぉぉぉと変な声をあげている……
PRINTFORML 「おっといけないいけない……このスイート安眠枕！　これで夜はグッスリ！　朝はパッチリ！」
PRINTFORMW 「貴方に素敵な安眠と、快適な目覚めを約束するこのスイート安眠枕……」
PRINTFORMW 「なんと今なら{枕代}でのご提供！　どうです？　欲しいでしょう？　欲しくなっちゃいましたよね？」
PRINTFORML 意気揚々とセールストークを続ける%ANAME(対象)%だが、少々胡散臭い
PRINTFORMW しかしここ最近激務気味だ、睡眠の質を向上させるのは魅力的な話だ……
PRINTFORML
PRINTFORML 現在の資金:{MONEY}　スイート安眠枕:{枕代}
PRINTFORMW ……意外と安くない、どうしたものか
PRINTFORML 
CALL ASK_MULTI_JUDGE("その枕……買った！", MONEY >= 枕代, "そんな胡散臭いものは要らない", 1,"そんな枕より君の膝枕が良い", 1)
IF RESULT == 0
	PRINTFORMW 睡眠に質を求めるならば多少の投資も必要だ、%ANAME(MASTER)%は枕を購入した
	PRINTFORMW 「まいどあり！　それでは貴方に吉夢が訪れんことを……」
	PRINTFORMW そう言って微笑み、%ANAME(対象)%は立ち去った……
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORML ・
	CALL COLOR_PRINTW(@"ぐっすり眠れた！　%ANAME(MASTER)%はクールタイムから回復した！", カラー_注意)
	COOLTIME:MASTER:0 = 0
	CFLAG:対象:好感度 += 100
	KDVAR:対象:ドレミー_枕の訪問販売 = 1
	MONEY -= 枕代
ELSEIF RESULT == 1
	PRINTFORMW 胡散臭い枕を買うつもりはない、%ANAME(MASTER)%は購入を断った
	PRINTFORMW 「そうですか、それは残念です。良い枕なんですけどねぇ。　まぁ今の貴方には不要なのかもしれませんね」
	PRINTFORMW 「それでは失礼します。　ではまた何処かで……」
	PRINTFORMW そう言って微笑み、%ANAME(対象)%は立ち去った……
	CFLAG:対象:好感度 += 10
	KDVAR:対象:ドレミー_枕の訪問販売 = 1
ELSEIF RESULT == 2
	PRINTFORMW 疲れを取るなら無機質な枕より人肌が良い
	PRINTFORMW 「ははぁん、また面白い冗談を言う方ですねぇ」
	PRINTFORMW 「そうですねぇ……{膝枕代}ほど頂けたら考えてもイイですよ」
	PRINTFORML 
	PRINTFORML 
	PRINTFORML 現在の資金:{MONEY}　膝枕代:{膝枕代}
	PRINTFORMW ……かなり吹っ掛けられているがどうしたものか
	PRINTFORML 
	CALL ASK_MULTI_JUDGE("膝枕してもらう", MONEY >= 膝枕代, "やっぱりやめておく", 1,"いっそ犯す", 1)
	IF RESULT == 0
		PRINTFORMW あの膝枕で寝ればさぞ疲れが取れるだろう
		PRINTFORMW %ANAME(MASTER)%は自室に、%ANAME(対象)%を誘い込んだ
		PRINTFORMW 「(ふふふ、一回の膝枕でこれだけ貰えるなら、いっそ膝枕屋を開業した方が良いかもしれませんね)」
		PRINTFORML さっそく%ANAME(対象)%の膝に頭を乗せ寝てみる
		PRINTFORML おぉこれは良いフィット具合、そして柔らかな人肌と体温……素晴らしい
		PRINTFORML %ANAME(MASTER)%はそのままグッスリと眠った……
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW 「おやおやもう寝てしまわれたのですか、早いですねぇ」
		PRINTFORMW 「……あっどうしよう、私この方が起きるまで動けないじゃない……」
		CALL COLOR_PRINTW(@"%ANAME(MASTER)%はクールタイムから回復した！", カラー_注意)
		COOLTIME:MASTER:0 = 0
		CFLAG:対象:好感度 += 300
		KDVAR:対象:ドレミー_枕の訪問販売 = 1
		MONEY -= 膝枕代
	ELSEIF RESULT == 1
		PRINTFORMW 流石にそんな大金は払えない……やめておこう
		PRINTFORMW 「ふふふ、そうですか残念ですね」
		PRINTFORMW 「それでは失礼します。　ではまた何処かで……」
		PRINTFORMW そう言って微笑み、%ANAME(対象)%は立ち去った……
		CFLAG:対象:好感度 += 50
		KDVAR:対象:ドレミー_枕の訪問販売 = 1
	ELSEIF RESULT == 2
		;ドレミーからあなた武闘を引いた数×5%
		判定値 = (ABL:MASTER:武闘 - ABL:対象:武闘) * 5
		IF RAND:100 > 判定値
			PRINTFORMW 胡散臭い上に吹っ掛けて来るとは良い度胸だ
			PRINTFORMW 「えっ、なに……きゃ！？」
			PRINTFORMW %ANAME(MASTER)%は無理やり、%ANAME(対象)%を自室に引き込もうとする
			PRINTFORMW 「は、離して……ッ！」
			PRINTFORMW だが、激しく抵抗する%ANAME(対象)%に、%ANAME(MASTER)%は力負けしてしまった
			PRINTFORMW そのまま%ANAME(対象)%は逃げ帰ってしまった……
			PRINTFORML
			PRINTFORMW それから数日間、%ANAME(MASTER)%は悪夢に悩まされ、さらに疲れてしまった
			CALL ADD_COOLTIME(MASTER, 2)
			CFLAG:対象:好感度 -= 500
			KDVAR:対象:ドレミー_枕の訪問販売 = 1
		ELSE
			PRINTFORMW 胡散臭い上に吹っ掛けて来るとは良い度胸だ
			PRINTFORMW 「えっ、なに……きゃ！？」
			PRINTFORMW %ANAME(MASTER)%は無理やり、%ANAME(対象)%を自室に引き込んだ
			PRINTFORMW 「こっ、こんなことをして……！　タダで済むと思わない方が！」
			PRINTFORMW 抵抗する%ANAME(対象)%をベッドに突き飛ばす%ANAME(MASTER)%、%ANAME(対象)%は少しずつ恐怖で顔を歪めている……
			PRINTFORMW 「い、今なら枕なんてタダであげるから！　許して！　お願い助けて！」
			PRINTFORML 叫び逃げようとする%ANAME(対象)%だが、ここは完全に%ANAME(MASTER)%のスペースだ、助けは来ない
			PRINTFORMW %ANAME(MASTER)%は自らの行いに興奮し始めたのか、股間に大きなテントを張っている
			PRINTFORML
			PRINTFORML
			PRINTFORMW 「い……嫌っ！　来ないで！　来ないでったら！！」
			PRINTFORML ベッドの上で後ずさりしつつ、ベッドに置いてある枕を%ANAME(MASTER)%に投げつける%ANAME(対象)%
			PRINTFORMW %ANAME(MASTER)%は動じる事無く%ANAME(対象)%を組み敷いて強引にスカートを脱がせ始める
			PRINTFORML 「いやぁあああああ！　いやぁああああああああ！！！！」
			PRINTFORML 泣き叫び暴れる%ANAME(対象)%だが、%ANAME(MASTER)%の腕力から逃れられない
			PRINTFORMW スカートがベッドの外に捨てられ、晒された下半身がより強張っていく……
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%のパンツに手を掛け、無理やり引き剝がす
			PRINTFORMW 暴れる足をホールドされたまま開かれ女性器を晒す%ANAME(対象)%
			PRINTFORMW 「うぅううう……」
			PRINTFORML 腕で顔を隠して泣く%ANAME(対象)%に、%ANAME(MASTER)%はズボンを脱ぎ捨てる
			PRINTFORMW 一切の潤滑が無い%ANAME(対象)%のヴァギナに、%ANAME(MASTER)%はペニスの先端をあてがう
			PRINTFORMW 「……せめて」
			PRINTFORMW 「せめて優しく……優しくして……お願い……」
			PRINTFORMW 何度も何度も、うわ言のように静かに泣きながら懇願する%ANAME(対象)%
			PRINTFORML
			PRINTFORML
			;優しくしないパターンも需要あるんだろうけど、なんか書けない
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%の身体を愛撫し始めた……
			PRINTFORMW しかしどれだけ愛撫しようが、%ANAME(対象)%の強張りは無くならない
			PRINTFORMW 「うぅ……ひっくっ……」
			PRINTFORML %ANAME(MASTER)%は、顔を隠す%ANAME(対象)%の腕を払い除け無理矢理口づけする
			PRINTFORMW 唇に無理やり唇を押し付ける、%ANAME(対象)%は抵抗こそしないが受け入れさえもしないようだ
			PRINTFORML 互いの荒い鼻息が当たるなか、%ANAME(MASTER)%の舌は%ANAME(対象)%の唇の隙間に潜り込もうとする
			PRINTFORMW 一方で払い除けられていた%ANAME(対象)%の腕は、力を失ったように落ちてベッドに両手着いている
			PRINTFORMW 「んっ……ふーっ、ふーっ」
			PRINTFORML やがて%ANAME(対象)%の唇は、%ANAME(MASTER)%の舌の侵入を許してしまう
			PRINTFORMW %ANAME(MASTER)%の舌は、そのまま%ANAME(対象)%の歯や唇の裏側をねちっこく舐めまわす……
			PRINTFORML 
			PRINTFORML 
			PRINTFORMW キスをしながらしばらく愛撫を続けていると、僅かに%ANAME(対象)%の太腿から湿り気が伝わってくる
			PRINTFORML 太腿を優しく撫で、豊満なバストを服越しに優しく揉みしだく
			PRINTFORMW 腰から服に手を入れ、胸に手を伸ばす……ブラの固い触り心地が手に当たる
			PRINTFORML ブラを下にズラし、軽く勃起した乳首を服の下に露出させる
			PRINTFORMW 上下にピンと弾いたり、乳輪を指でなぞったりして%ANAME(対象)%の胸を愛撫する
			PRINTFORMW 「……んんっ」
			PRINTFORML 少しピンっと背を伸ばす%ANAME(対象)%、どうやら少しずつ感じ始めているようだ
```
