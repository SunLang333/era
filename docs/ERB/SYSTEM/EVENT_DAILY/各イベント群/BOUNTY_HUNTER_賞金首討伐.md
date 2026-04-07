# SYSTEM/EVENT_DAILY/各イベント群/BOUNTY_HUNTER_賞金首討伐.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/BOUNTY_HUNTER_賞金首討伐.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_BOUNTY_HUNTER_RATE, EVENT_DAILY_BOUNTY_HUNTER_DECISION, EVENT_DAILY_BOUNTY_HUNTER_GENRE, EVENT_DAILY_BOUNTY_HUNTER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_BOUNTY_HUNTER_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_BOUNTY_HUNTER_DECISION()
RETURN 15 <= DAY

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_BOUNTY_HUNTER_GENRE()
RETURN デイリー_ジャンル_エロ



;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;---------------------
@EVENT_DAILY_BOUNTY_HUNTER()
#DIM 対象
#DIMS 賞金首, 6
#DIM 賞金額, 6
#DIM COOL_TIME

賞金首:0 = 巨大スライム
賞金額:0 = 20000

賞金首:1 = 小鬼の軍団
賞金額:1 = 22500

賞金首:2 = 蝦蟇蛙
賞金額:2 = 25000

賞金首:3 = 山犬
賞金額:3 = 27500

賞金首:4 = 死霊術師
賞金額:4 = 30000

賞金首:5 = 暴れ鬼
賞金額:5 = 40000


IF DVAR:賞金稼ぎ_発生フラグ == 0
	PRINTFORML 仕事中、息抜きになんとなく辺りを見回すと賞金首の手配書が目に留まった
	PRINTFORML 部下に尋ねると、この辺りで暴れている妖怪や魔物の類らしい
	PRINTFORML 賞金額20000,25000,30000…結構な金額だ
	PRINTFORMW こいつらを討伐できれば国庫も潤うし、民に良い印象も与えられるかもしれない
	DVAR:賞金稼ぎ_発生フラグ = 1
ELSE
	PRINTFORML 例の賞金首たちの手配書が再び目に留まった
	PRINTFORMW 賞金額は以前と同じだ、どうやらまだ討伐されていないらしい
ENDIF
PRINTFORMW どうしよう
CALL ASK_YN("討伐に行く", "やめておく")
IF RESULT == 1
	$CANCEL
	PRINTFORML いや危険だ、やめておこう
	PRINTFORMW %ANAME(MASTER)%は手配書の束を脇に放った
	RETURN 1
ELSE
	PRINTFORML %ANAME(MASTER)%は討伐を行うことにした
ENDIF

PRINTFORML 討伐するとしたら単純に戦闘力の高さの方が重要だろうか
PRINTFORMW 誰を討伐に向かわせようか？
CALL SINGLE_DRAWLINE
CALL SELECT_CHARA_LIST_SLG
SIF RESULT == -1
	GOTO CANCEL
対象 = RESULT

IF 対象 == MASTER
	PRINTFORML 自ら討伐に向かうことにした
ELSE
	PRINTFORML %ANAME(対象)%に任せる事にした
ENDIF

PRINTFORML さて、ターゲットはいくつかいる
PRINTFORML 賞金額が高いものほど手強そうだ
PRINTFORMW どいつを討伐しようか？
CALL SINGLE_DRAWLINE
;討伐対象を決める
FOR LOCAL, 0, VARSIZE("賞金首")
	IF DVAR:(賞金稼ぎ_討伐フラグ:LOCAL) == 0
		PRINTFORML [{LOCAL, 2, RIGHT}] %(賞金首:LOCAL), 14, LEFT% 賞金額:{賞金額:LOCAL}
	ELSE
		SETCOLOR カラー_選択不可
		PRINTPLAINFORM [{LOCAL, 2, RIGHT}] %賞金首:LOCAL, 14, LEFT% 賞金額:{賞金額:LOCAL}
		RESETCOLOR
		PRINTL
	ENDIF
NEXT
PRINTFORML [99] やはりやめておく
$INPUT_LOOP
INPUT
IF RESULT == 99
	GOTO CANCEL
ELSEIF  RESULT < 0
	GOTO INPUT_LOOP
ELSE
	LOCAL:1 = 賞金額:RESULT
	LOCAL:2 = RESULT
	PRINTFORML %賞金首:RESULT%に決めた
	PRINTFORMW %ANAME(対象)%は早速討伐に向かった
	PRINTFORML ・・・
	PRINTFORML ・・
	PRINTFORMW ・
	;判定処理、
	;武闘の基準値、10%単位で最大4倍。
	LOCAL:3 = ABL:対象:武闘 * (RAND:31 + 10) / 10
	;知略の基準値、10%単位で最大3倍。
	LOCAL:4 = ABL:対象:知略 * (RAND:21 + 10) / 10
	IF LOCAL:3 + LOCAL:4 > LOCAL:1 / 100
		PRINTFORMW %ANAME(対象)%は見事%賞金首:RESULT%を討伐した！
		PRINTFORMW 賞金を手に入れた！
		PRINTFORMW 更に自勢力の評判が上がった！
		MONEY += LOCAL:1
		DVAR:(賞金稼ぎ_討伐フラグ:RESULT) = 1
		FOR LOCAL, 1, MAX_COUNTRY
			SIF IS_COUNTRY(LOCAL)
				CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, (LOCAL:1 / 200))
		NEXT
		RETURN 1
	ELSE
		PRINTFORMW %ANAME(対象)%は返り討ちにされてしまった
		IF IS_FEMALE(対象)
			PRINTFORMW %賞金首:RESULT%はぐったりと横たわる%ANAME(対象)%を巣穴へと引きずって行った
			PRINTFORML 
			PRINTFORML 
			SELECTCASE LOCAL:2
				;スライム・未完成
				CASE 0
					SELECTCASE RAND:5
						CASE 0
							PRINTFORML かび臭いスライムの巣穴で%ANAME(対象)%はお腹を押さえて冷や汗を流しながら呻いている
							PRINTFORML %ANAME(対象)%のお腹はまるで臨月のように膨れ上がっており、時折ボコボコと蠢いている
							PRINTFORML スライムの一部が%ANAME(対象)%の子宮へと潜りこんで暴れているのだ
							PRINTFORMW 必死で耐える%ANAME(対象)%だが、スライムにより子宮を直接刺激され続け、何度か絶頂させられている
							PRINTFORML そしてお腹が一気に膨れ上がったかと思うと、大量のスライムが産道から溢れ出てきた
							PRINTFORML あまりの衝撃に%ANAME(対象)%はぐるんと目を裏返し、嬌声を響かせながら絶頂を迎えてしまった
							PRINTFORML やがて全てのスライムを産み落とすと、%ANAME(対象)%はその場に崩れ落ち身体を痙攣させる
							PRINTFORMW その雌穴はぱくぱくと開き切ってしまっており、子宮口まで丸見えになっていた
						CASE 1
							PRINTFORML %ANAME(対象)%は巨大なスライムに首だけ出した体勢で飲みこまれている
							PRINTFORML なんとか逃れようとするが、スライムに全身を圧迫されておりろくに動く事も出来ない
							PRINTFORML %ANAME(対象)%は次第に異変に気付く、スライムの体液により服を溶かされているのだ
							PRINTFORML このまま消化されるのかと恐怖したが、どうやら彼女の身体には影響はないようだ
							PRINTFORMW 全裸にされ顔を真っ赤にしながらも逃れようと考える%ANAME(対象)%の下腹部に、突如衝撃が襲った
							PRINTFORML 呻き声を上げながら下腹部を見ると、雌穴がぱっくりと開かれスライムが侵入しているではないか
							PRINTFORML スライムは膣肉を押し広げながら奥へと奥へと潜りこみ、%ANAME(対象)%もそれに合わせてビクビクと震える
							PRINTFORML 少しずつ膣内を満たしながらやがて最奥までたどり着くと、子宮口をこじ開けて胎内に潜りこんだ
							PRINTFORMW その衝撃で%ANAME(対象)%のお腹はボコッと膨れ上がり、彼女は絶叫の様な嬌声を上げて絶頂した
						CASE 2
							PRINTFORML %ANAME(対象)%は巣の奥で粘着性のスライムに囚われてしまった
							PRINTFORML スライムは器用に%ANAME(対象)%の服を破り捨てると、露わになった乳房や秘所、お尻などに張り付く
							PRINTFORML 敏感な部分に張り付かれ羞恥する%ANAME(対象)%だが、更にスライムはぐにぐにと蠢き彼女を刺激し出した
							PRINTFORMW 思わず小さく嬌声をあげる%ANAME(対象)%に気を良くしたように、スライムは更に刺激を強めていく
							PRINTFORML もがいて抵抗する%ANAME(対象)%だったがスライムは巧みに彼女の性感帯を愛撫し、次第に甘い声が漏れ出す
							PRINTFORML 陰核を締められ遂に%ANAME(対象)%が絶頂すると、スライムは噴き出た愛液をずりゅずりゅと吸いだした
							PRINTFORML 息を荒げながらこれが目当てかと気付く%ANAME(対象)%だが、尻穴にねじ込まれて再び絶頂してしまう
							PRINTFORMW 堪えようとする%ANAME(対象)%を弄ぶように、スライムは何度も彼女を絶頂させ体液を吸い取り続けた
						CASE 3
							PRINTFORML %ANAME(対象)%はスライムの巣穴で地面に這いつくばってヨガり狂っている
							PRINTFORML 彼女の服の中にスライムが潜りこみ、全身を愛撫しているのだ
							PRINTFORML 初めはスライムを追い出そうとしていた%ANAME(対象)%だが、粘液状のスライム相手ではそれも空しく
							PRINTFORMW まるで女体について知り尽くしているかのようなスライムの巧みな愛撫に、何度もイカされてしまった
							PRINTFORML 次第に%ANAME(対象)%の抵抗が弱まるのを確認したスライムは、遂に彼女の中へと潜りこみだす
							PRINTFORML スライムは粘液の一部を棒状に硬めると、一突きで彼女の雌穴と尻穴の奥までねじり込んできた
							PRINTFORML まるで肉棒を挿入されたかの様な圧迫感と痺れるような刺激に、%ANAME(対象)%は大きく体を反らして絶頂する
							PRINTFORML どちゅ！どちゅ！と両穴を激しく犯され、更に全身をスライムに拘束されている%ANAME(対象)%は
							PRINTFORMW 逃げ場のない快楽に襲われながら体をビクビクと跳ねさせヨガり狂う事しか出来なかった
						CASE 4
							PRINTFORML %ANAME(対象)%は巨大なスライムに首を残して飲みこまれ、全身を愛撫されている
							PRINTFORML スライムの愛撫は巧みであり、慣れないうちは一、二度絶頂させられてしまった%ANAME(対象)%が
							PRINTFORML それでも逃げるチャンスを窺おうと必死で堪えていると、次第に体が火照ってきた
							PRINTFORML 実はこのスライムの体液には媚薬成分が含まれており、それが彼女の中へと染み込んでいるのだ
							PRINTFORMW しかしそんな事を知らない%ANAME(対象)%は何かの間違いだと必死で自分に言い聞かせて我慢する
							PRINTFORML だが強烈な媚薬成分を全身に染み込まされ、もはや%ANAME(対象)%は撫でられるだけで喘ぎ声を漏らしてしまう
							PRINTFORML 更にスライムの一部が変形してペニスのような形になり、膣へとねじ込まれるとそれだけで絶頂してしまった
							PRINTFORML 全身を束縛されたまま何度も子宮を小突かれ、その度に絶頂させられ続け、その内子宮口も開いてしまい
							PRINTFORMW 狙い澄ましたように胎内へと種を放たれると、彼女はあまりの熱さに理性も吹き飛びあられもなく嬌声を上げた
					ENDSELECT
					CALL FUCK_RAPE(対象, GET_SPERM_ID("スライム"), @"スライムの\@RAND:2 ? ペニス # 唇\@", @"スライム")
					CALL FUCK_RAPE(対象, GET_SPERM_ID("スライム"), @"スライムの\@RAND:2 ? ペニス # 唇\@", @"スライム")
				;小鬼の軍団
				CASE 1
					SELECTCASE RAND:5
						CASE 0
```
