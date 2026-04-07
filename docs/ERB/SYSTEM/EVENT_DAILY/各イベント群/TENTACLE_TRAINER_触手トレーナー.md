# SYSTEM/EVENT_DAILY/各イベント群/TENTACLE_TRAINER_触手トレーナー.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/TENTACLE_TRAINER_触手トレーナー.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_TENTACLE_TRAINER_RATE, EVENT_DAILY_TENTACLE_TRAINER_DECISION, EVENT_DAILY_TENTACLE_TRAINER_GENRE, EVENT_DAILY_TENTACLE_TRAINER, SELECT_CHARA_LIST_SHOW_LOGIC_TENTACLE_TRAINER, SELECT_CHARA_LIST_SELECT_LOGIC_TENTACLE_TRAINER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_TENTACLE_TRAINER_RATE()
RETURN 25


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_TENTACLE_TRAINER_DECISION()
SIF DVAR:触手トレーナー_発生フラグ == -1
	RETURN 0
SIF !ITEM:触手部屋
	RETURN 0

RETURN DAY >= 15

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_TENTACLE_TRAINER_GENRE()
RETURN デイリー_ジャンル_トレーナー

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_TENTACLE_TRAINER()
#DIM 対象

;5回以上利用すると苗床を付けられるようになる
IF DVAR:触手トレーナー_発生フラグ == 5
	PRINTFORMW あの妖術師が再び訪れた
	PRINTFORML 「お久しぶりです…また“実験素材”と“資金”の提供をお願いしに来ました…」
	PRINTFORML 「そして、日頃からご利用していただいているお礼として…更に新しい“トレーニング”をご用意しました…」
	PRINTFORMW 新しいトレーニングとは、相手を触手づけにして【苗床】にしてしまうものらしい
	PRINTFORML 価格は70000、少々値は張るが今までの実績からも効果は信用できそうだ
	PRINTFORML 無論、ある程度触手に慣れている者にしか無理だろうが
	PRINTFORMW そして引き続き、今まで通りのトレーニングもしてくれるようだ
	PRINTFORMW さて、どうしようか……
;1回目
ELSEIF DVAR:触手トレーナー_発生フラグ == 0
	PRINTFORML 仕事中、来客を知らされた
	PRINTFORML いかにも妖しげな雰囲気の者らしい
	PRINTFORMW どれ程妖しげなのか、会ってみることにした
	PRINTFORML 
	PRINTFORMW 「%ANAME(MASTER)%様ですね、初めまして。お目にかかれて光栄です」
	PRINTFORML 目深にフードをかぶり顔を隠した男が恭しく頭を下げる
	PRINTFORMW 成程、確かにいかにも怪しげな雰囲気だ
	PRINTFORML 「私は、妖術家業をしておりまして…%ANAME(MASTER)%様ならばどういう事かお分かりになるでしょう？」
	PRINTFORMW 相手の言葉を聞いてその雰囲気にも合点が言った
	PRINTFORML 「妖術を極める為に様々な研究をしているのですが…いかんせん“実験素材”と“資金”の調達が難しく…」
	PRINTFORML 「そこで同じ妖術使いの%ANAME(MASTER)%様ならば、私のスポンサーになってくださるのではないかと…お伺いした次第でございます」
	PRINTFORMW 「無論、タダで、とは言いません。私は妖術知識を他者に伝え、またその能力を伸ばすことを得意としております」
	PRINTFORML 男の言葉を纏めると、金を払えば仲間に妖術知識を授けてくれるようだ
	PRINTFORMW 無論その為にどの様な行為が必要なのかも%ANAME(MASTER)%にはわかる、実験素材とはそういう事だろう
	PRINTFORML 費用は一回50000、高いと言えば高いが安いと言えば安いか？
	PRINTFORMW 妖しげではあるが、男が出鱈目を言っているのではない事はその知識を聞けば分かった
	PRINTFORMW さて、どうしようか……
;2回目以降
ELSE
	PRINTFORMW あの妖術師が再び訪れた
	PRINTFORMW 「お久しぶりです…また“実験素材”と“資金”の提供をお願いしに来ました…」
	PRINTFORMW さて、どうしようか……
ENDIF

CALL SINGLE_DRAWLINE
IF DVAR:触手トレーナー_発生フラグ >= 5
	PRINTFORML 現在の資金:{MONEY} 妖術知識費用:50000 苗床費用:70000
ELSE
	PRINTFORML 現在の資金:{MONEY} 妖術知識費用:50000
ENDIF
CALL ASK_MULTI_JUDGE("素材と資金を提供する", MONEY >= 50000, "やめておく", 1, "斬り捨てる", 1)
IF RESULT == 2
	PRINTFORMW 悪の触手使いめ！覚悟！
	PRINTFORMW 「ぎゃー！」
	PRINTFORMW 悪は去った！
	DVAR:触手トレーナー_発生フラグ = -1
	RETURN 1
ELSEIF RESULT == 1
	PRINTFORML 悪いが今はそれは必要としていない
	PRINTFORML 「そうですか…それではまたお伺いしましょう」
	PRINTFORMW 妖術師は音も立てずに去って行った
	DVAR:触手トレーナー_発生フラグ += 1
	RETURN 1
ELSE
	PRINTFORMW 「わかりました…では、どなたを提供していただけるのか、選んでください…」
	CALL SINGLE_DRAWLINE
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("TENTACLE_TRAINER", "TENTACLE_TRAINER")
	対象 = RESULT
	IF 対象 == -1
		PRINTFORML やはりやめておこう
		PRINTFORML 「そうですか…それではまたお伺いしましょう」
		PRINTFORMW 妖術師は音も立てずに去って行った
		RETURN 1
	ELSE
		IF 対象 == MASTER
			PRINTFORML 「あなた自身が？…わかりました…」
		ELSE
			PRINTFORML 「%ANAME(対象)%さんですね、わかりました…」
		ENDIF
		IF DVAR:触手トレーナー_発生フラグ >= 5 && ABL:対象:触手 >= 4 && GETBIT(TALENT:対象:淫乱系, 素質_淫乱_苗床) == 0 && MONEY >= 70000
			PRINTFORMW 「通常のトレーニングと苗床トレーニング…どちらにしましょうか？」
			CALL ASK_YN("通常のトレーニング", "苗床にしてもらう")
			IF RESULT == 1
				PRINTFORMW 「では、こちらへどうぞ…」
				IF ABL:対象:触手 <= 4 && 対象 != PLAYER
					PRINTFORMW 妖術師は嫌がる%ANAME(対象)%をローブの下から伸ばした無数の触手で束縛して連れて行った
				ELSE
					PRINTFORMW %ANAME(対象)%はもじもじしながらも大人しく妖術師に連れて行かれた
				ENDIF
				PRINTFORML ・
				PRINTFORML ・
				PRINTFORML ・
				SELECTCASE RAND:5
					CASE 0
						PRINTFORMW %ANAME(対象)%のお腹は臨月の妊婦のように膨れ上がっており、時折中で何かが動いているかの様に表面が蠢く
						PRINTFORMW %ANAME(対象)%の中に種付けされた触手が、%ANAME(対象)%の魔力を吸い上げ、急激に成長し出産の時を待っているのだ
						PRINTFORMW ほどなくして%ANAME(対象)%は下腹部に強烈な疼きを感じ、ドクンドクンと子宮が脈動し出すのを感じる
						PRINTFORMW いよいよ出産の時がやってきた、%ANAME(対象)%は自ら秘貝を広げいきみ、触手の出産を手助けする
						PRINTFORMW 途中、触手が産道をうねうねと這いずる感触で、%ANAME(対象)%は何度も絶頂してしまう
						PRINTFORMW やがて触手が勢いよく%ANAME(対象)%の雌穴から飛び出ると、%ANAME(対象)%はアヘ顔を晒しながら至福の絶頂を味わった
					CASE 1
						PRINTFORMW 無数の触手たちに埋もれながら、子宮を小突かれて%ANAME(対象)%は喜悦の声を上げている
						PRINTFORMW %ANAME(対象)%の下腹部には、ハート形の紋章が浮かび上がっており、%ANAME(対象)%の子宮を疼かせている
						PRINTFORMW その紋章は%ANAME(対象)%が絶頂する度に怪しく光り、%ANAME(対象)%の頭の中を快感で塗りつぶしていく
						PRINTFORMW %ANAME(対象)%はもはや触手に奉仕して種をもらう事しか考えられなくなっており、積極的に触手をしごいて種をねだる
						PRINTFORMW 触手の苗床になるとはなんて幸せな事なのだろう、もっと早くに知ればよかった
						PRINTFORMW おぼろげにそんな事を考えながら、全身に触手の種を受けて幸せそうに%ANAME(対象)%は絶頂した
					CASE 2
						PRINTFORMW 薄暗い部屋の中に、巨大な球根状の触手が鎮座している
						PRINTFORMW %ANAME(対象)%はその巨大な触手に呑みこまれ、全身の穴を触手で埋め尽くされながら犯されている
						PRINTFORMW 身動きすらできずに、ひたすら与えられる快感に、%ANAME(対象)%はもはや絶頂から降りられなくなっている
						PRINTFORMW びゅるると特濃の種を口内と子宮に注がれ、再び絶頂しながら%ANAME(対象)%は美味しそうにそれを飲みこんでいく
						PRINTFORMW もはや%ANAME(対象)%の頭の中に触手に対する嫌悪感は無く、快感を与えてくれる愛しい相手と認識している
						PRINTFORMW 夜通し触手たちに可愛がられた%ANAME(対象)%は、種を植え付けられることを自ら望むようになっていた
					CASE 3
						PRINTFORMW %ANAME(対象)%は触手の壁に埋め込まれながら、スポンジ状の触手によって目隠しされている
						PRINTFORMW その触手はチカチカと催眠光を発し、彼女の意識を塗り替えていく
						PRINTFORMW しばらくすると%ANAME(対象)%はだらしなく涎と舌を垂らし、まるで発情したか犬の様に息を荒げだした
						PRINTFORMW そんな%ANAME(対象)%の股間に一本の触手が擦り寄り、二度三度と愛液を垂れ流している割れ目を擦りあげる
						PRINTFORMW %ANAME(対象)%は恥も外聞も無く、必死で腰を振りながら触手を受け入れようと種をおねだりする
						PRINTFORMW その態度に満足したように触手は%ANAME(対象)%を犯し始め、%ANAME(対象)%は極上のご褒美を与えられた
					CASE 4
						PRINTFORMW %ANAME(対象)%は触手を咥えこみながら、あへあへとだらしなく舌を垂らして自ら腰を振っている
						PRINTFORMW 先ほどから注射器のような触手によって、%ANAME(対象)%の中に得体のしれない液体が注入されている
						PRINTFORMW その液体が自らの血肉と混ざり合い、少しずつ内側から自分の身体が作り変えられているのを感じる
						PRINTFORMW しかし%ANAME(対象)%の意識はすでに触手によって塗り替えられており、嫌悪の色はない
						PRINTFORMW むしろ%ANAME(対象)%は作りかえられる副作用による麻薬の様な快感に没頭し、更に腰の動きを早めていく
						PRINTFORMW 絶頂しながらもなお種をねだる%ANAME(対象)%に対し、触手たちは精液と媚薬を注ぎ込み続けてやった
				ENDSELECT
				PRINTFORML ・
				PRINTFORML ・
				PRINTFORML ・
				CALL COLOR_PRINT(@"%ANAME(対象)%は【苗床】になった", カラー_注意)
				PRINTFORMW 
				CALL FUCK(対象, "欲望, Ｃ, Ｖ, Ａ, Ｂ, Ｍ, 奉仕, 精愛, 口淫, 性交, 触手, Ｖ性交, Ａ性交", "キス喪失, 処女喪失, Ａ処女喪失, 膣内射精, 腸内射精, 口内射精, CFLAG減少", GET_SPERM_ID("触手"), "触手", "触手", "", "調教")
				EXP:対象:触手出産経験 += 6 + RAND:10
				SETBIT TALENT:対象:淫乱系, 素質_淫乱_苗床
				MONEY -= 70000
				DVAR:触手トレーナー_発生フラグ += 1
				PRINTFORML 「ご協力ありがとうございました…それでは私はこれで…」
				PRINTFORMW 妖術師は音も立てずに去って行った
				RETURN 1
			ELSE
				PRINTFORMW 「では、こちらへどうぞ…」
			ENDIF
		ELSE
			PRINTFORMW 「では、こちらへどうぞ…」
		ENDIF
		IF TALENT:対象:妖術知識 == 0
			IF ABL:対象:触手 <= 4 && 対象 != PLAYER
				PRINTFORMW 妖術師は嫌がる%ANAME(対象)%をローブの下から伸ばした無数の触手で束縛して連れて行った
			ELSEIF GETBIT(TALENT:対象:淫乱系, 素質_淫乱_苗床) == 1
				PRINTFORMW すっかり触手の魅力に溺れた%ANAME(対象)%は期待に頬を赤らめながら妖術師について行った
			ELSE
				PRINTFORMW %ANAME(対象)%はもじもじしながらも大人しく妖術師に連れて行かれた
			ENDIF
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW 薄暗い部屋の中で、%ANAME(対象)%は無数の触手に犯されている
			PRINTFORML 手足を触手に拘束された状態で無数の触手によって、代わる代わるに穴という穴を蹂躙され続ける
			PRINTFORMW 体中に触手の体液を塗りたくられ、もはや全身が触手たちのおもちゃになっていた
			PRINTFORML 絶え間なく与えられる異形の快楽に、%ANAME(対象)%は背徳感を感じながらもひたすらよがり狂う事しかできない
			PRINTFORMW そして膣内への幾度目かの射精を受け、%ANAME(対象)%はアヘ顔を晒しながら絶頂した
			PRINTFORML 触手が引き抜かれると%ANAME(対象)%は力なく床に倒れ込むが、そんな彼女にお構いなしに次の触手が群がっていく
			PRINTFORMW 饗宴は夜通し続き、%ANAME(対象)%は全身に触手の魔力と快感を染み込ませた
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORML ・
			TALENT:対象:妖術知識 = 1
			ABL:対象:妖術 += 10
			CALL COLOR_PRINT(@"%ANAME(対象)%は妖術知識を身につけた", カラー_注意)
```
