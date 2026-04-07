# SYSTEM/EVENT_DAILY/各イベント群/BANDIT/BANDIT_REQUIRE_RANSOM_野盗からの身代金要求.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/BANDIT/BANDIT_REQUIRE_RANSOM_野盗からの身代金要求.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_BANDIT_REQUIRE_RANSOM_RATE, EVENT_DAILY_BANDIT_REQUIRE_RANSOM_DECISION, EVENT_DAILY_BANDIT_REQUIRE_RANSOM_GENRE, EVENT_DAILY_BANDIT_REQUIRE_RANSOM_SETTARGET, EVENT_DAILY_BANDIT_REQUIRE_RANSOM; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_BANDIT_REQUIRE_RANSOM_RATE()
RETURN 1000


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_BANDIT_REQUIRE_RANSOM_DECISION()
#DIM 野盗
野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))

SIF 野盗 == -1
	RETURN 0

SIF IS_SP_COUNTRY(CFLAG:MASTER:所属)
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_BANDIT_REQUIRE_RANSOM_GENRE()
RETURN デイリー_ジャンル_特殊勢力

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_BANDIT_REQUIRE_RANSOM_SETTARGET()
#DIM 野盗
野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))

FOR LOCAL, 1, CHARANUM
	IF CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && CFLAG:LOCAL:捕虜先 == 野盗 && IS_FEMALE(LOCAL) && RAND:100 < SP_TRAIN_COUNT:LOCAL:特殊勢力_野盗 * 5
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
		DAILY_TARGET_NUM ++
	ENDIF
NEXT

SIF DAILY_TARGET_NUM < 1
	RETURN 0

RETURN 1

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_BANDIT_REQUIRE_RANSOM()
#DIM 対象
#DIM 身代金
#DIM 野盗
VARSET 対象, -1
VARSET 身代金

対象 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)
野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_野盗)

;身代金は各種能力合計の500倍かプレイヤーの給料5ターンぶんのうち高い方を採用
身代金 = ABL:対象:Ｃ感 + ABL:対象:Ｂ感 + ABL:対象:Ａ感 + ABL:対象:Ｖ感 + ABL:対象:Ｍ感 + ABL:対象:欲望 + ABL:対象:性技 + ABL:対象:奉仕 + ABL:対象:性交 + ABL:対象:露出 + ABL:対象:精愛
身代金 *= 500
身代金 = MAX(GET_SUM_ECONOMY(CFLAG:MASTER:所属) * (ABL:MASTER:武闘 + ABL:MASTER:防衛 + ABL:MASTER:知略 + ABL:MASTER:政治 + 100) / 40000 * 5, 身代金)

PRINTFORML %ANAME(MASTER)%が仕事をしていると、侍従が来客を告げた
PRINTFORML 使いだと名乗る男が来たのだそうだが、どこから来たのか言わないのだという
PRINTFORMW 怪訝に思った%ANAME(MASTER)%は、とりあえず会ってみることにした……
PRINTFORML
PRINTFORML
PRINTFORML
;初対面
IF DVAR:野盗身代金要求_発生フラグ == 0
	PRINTFORML 「へへへ、あんたが%ANAME(MASTER)%か」
	PRINTFORMW 使いだと自称するのは、ごろつきじみた、明らかに真っ当ではない男だった
;前回払った
ELSEIF DVAR:野盗身代金要求_発生フラグ == 1
	PRINTFORML 「よう、また金ェ払ってもらいに来たぜ」
	PRINTFORMW 部屋で待っていたのは、例の野盗の使いの男だった。にやにやと、下卑た笑みを浮かべている
	PRINTFORML 「おっと、荒っぽい真似はナシだぜ。こっちには%ANAME(対象)%がいる。そうだろ？」
	PRINTFORMW 非常に癪だが、その通りだ。%ANAME(MASTER)%は武器を収めざるを得なかった
;前回調教
ELSEIF DVAR:野盗身代金要求_発生フラグ == 2
	PRINTFORML 「よう、また来てやったぜ？　今度こそ金ェ払ったらどうだよ？」
	PRINTFORMW 部屋で待っていたのは、例の野盗の使いの男だった。にやにやと、下卑た笑みを浮かべている
	PRINTFORML 「おっと、荒っぽい真似はナシだぜ。こっちには%ANAME(対象)%がいる。そうだろ？」
	PRINTFORMW 非常に癪だが、その通りだ。%ANAME(MASTER)%は武器を収めざるを得なかった
;前回身代わり
ELSEIF DVAR:野盗身代金要求_発生フラグ == 3
	PRINTFORML 「よう、まあた来てやったぜ」
	PRINTFORMW 部屋で待っていたのは、例の野盗の使いの男だった。にやにやと、下卑た笑みを浮かべている
	PRINTFORML 「へへへ、お前、中々『使い心地』も悪くなかったなぁ」
	PRINTFORMW 「どうだ？　また俺らのとこに来ねぇか、可愛がってやるぜぇ？」
	PRINTFORMW 野卑な視線が身体に這わされる。それだけで%ANAME(MASTER)%の身体はかつての陵辱を思い出し、熱を孕んでしまう……
ENDIF
SELECTCASE RAND:5
	CASE 0
		PRINTFORMW 何の用だ、こっちは暇ではない。冷淡に対応すると、男は気色の悪い猫撫で声をあげる
		PRINTFORML 「おいおい、そんなこと言うなよなぁ。今日はお前に、いいもんを持ってきてやったんだ」
		PRINTFORML 男が差し出したのは、一枚の写真だった
		PRINTFORMW 怪訝に思いながら覗き込んだ%ANAME(MASTER)%は、目を疑った
		PRINTFORML 行方不明になっていた%ANAME(対象)%が、虚ろな瞳で男のモノをしゃぶり、犯されている
		PRINTFORMW %ANAME(対象)%がどのような扱いを受けてきたかは、想像にかたくなかった
	CASE 1
		PRINTFORMW 「それよりだ。この女ァ、見覚えねぇかよ？」
		PRINTFORML 脚を開き椅子に座り込んだ男の下に、誰かが跪いている
		PRINTFORML 響くねっとりとした水音からいって、男のモノをしゃぶらされているのだろう
		PRINTFORMW 確かにその姿には見覚えがあった――%ANAME(対象)%だ！
		PRINTFORML 「へへへ、最初は泣くわ喚くわブチ切れるわで大事だったがな、今じゃすっかり雌犬だ」
		PRINTFORML 「おまけに具合もだいぶイイときてる……くっ、オラ射精すぞっ」
		PRINTFORML 男が軽く腰を浮かすと、%ANAME(対象)%は喉を鳴らし、放たれる白濁を飲み干していく
		PRINTFORMW 最後の最後まで一物に吸い付いてからモノを解放し、ご馳走様でしたと呟いた
	CASE 2
		PRINTFORML 「今日はよぉ、お前に見せたいものがあるんだよ」
		PRINTFORML 男が手を鳴らすと、部屋の外から誰かが入ってくる
		PRINTFORMW なんとそれは、野盗との戦いの最中に行方不明になった、%ANAME(対象)%ではないか！
		PRINTFORML その姿は、見るも無惨なものになっていた
		PRINTFORML 卑猥な落書きを施された全身は白濁にまみれ、首輪以外には何も身に着けさせてもらえていない
		PRINTFORML 瞳は虚ろで、端から子種を垂れ流す唇から、ぶつぶつと、男根をねだる言葉を呟いている
		PRINTFORML 無意識に快楽をもとめているのか、その手は白濁を垂れ流す両穴をぐちゅぐちゅと掻き回している
		PRINTFORMW 彼女がどのようなことをされてきたか、想像にかたくなかった
	CASE 3
		PRINTFORML 「今日はよぉ、お前に見せたいものがあるんだよ」
		PRINTFORML 男が手を鳴らすと、部屋の外から誰かが入ってくる
		PRINTFORML なんとそれは、野盗との戦いの最中に行方不明になった、%ANAME(対象)%ではないか！
		PRINTFORMW 身に纏った衣装は、ボディラインを強調するような、なんとも卑猥なものだった
		PRINTFORML 「おう雌豚、さっさと準備しろ」
		PRINTFORML 男が命じると、%ANAME(対象)%は文句一つ言うことなく、壁に手を突き%STR_BODY("尻", 対象)%を突き出す
		PRINTFORMW たくし上げられたスカートの中に下着などなく、期待に濡れた秘部が剥き出しになっている
		PRINTFORML 「へへへ、まったくたまんねぇなオラっ！」
		PRINTFORML ろくな準備もなしに男がそこへ一物をねじ込むと、%ANAME(対象)%はたまらないという声を上げる
		PRINTFORML そのまま抽送にあわせて自ら腰を振り、だらしのないアヘ顔を晒し続けた
		PRINTFORMW 結局、行為が終わったのは、彼が三回も膣内射精した後のことだった
	CASE 4
		PRINTFORML 「今日はよぉ、お前に見せたいものがあるんだよ」
		PRINTFORML 男が手を鳴らすと、部屋の外から誰かが入ってくる
		PRINTFORML なんとそれは、野盗との戦いの最中に行方不明になった、%ANAME(対象)%ではないか！
		PRINTFORMW 一糸まとわぬ裸身の乳房と秘部には、痛々しい金色のピアスがぶら下がっている
		PRINTFORML 「ほれ、挨拶しろ」
		PRINTFORML 男がそう呟くと、%ANAME(対象)%は床に頭をつけ、土下座してみせた
		PRINTFORML そして、己がどのようなことをされてきたか、つぶさに報告し始めた
		FOR LOCAL:0, 0, 4
			PRINTDATA
				DATAFORM 浮浪者相手に身を売って歩いたこと、
				DATAFORM 娼館で客をとり、金を稼いだこと、
				DATAFORM 男のモノを何本も受け入れ、悦ばせたこと、
				DATAFORM 自分がペニス狂いの雌豚になり果てたこと、
				DATAFORM ときには野良犬と交わりもしたこと、
				DATAFORM もう何人に種付けされたか分からないこと、
				DATAFORM もうセックスなしには生きていけないこと、
				DATAFORM 彼らの家畜として飼育されたこと、
				DATAFORM ストリップダンサーとして働いたこと、
				DATAFORM 他の囚人の慰みものにされたこと、
				DATAFORM 肉便器として何度も使ってもらったこと、
				DATAFORM 彼ら専用のマゾ豚として生まれ変わったこと、
				DATAFORM 今こうしている間もオナニーしたくて仕方ないこと、
				DATAFORM アジトの近くを露出して歩いて回ったこと、
				DATAFORM 行きずりの男に声をかけ、抱いてもらったこと、
				DATAFORM 彼らの一物がどれだけ素晴らしいか、
				DATAFORM 彼らのセックスがどれほど最高か、
				DATAFORM 自分にとってどれだけ精液便女が適任であったか、
				DATAFORM セックスなしの生活にはもう戻れないこと、
				DATAFORM 一夜を競売にかけられ、知らぬ男に抱かれたこと、
				DATAFORM さまざまな道具や薬物の実験体にされたこと、
				DATAFORM もはや「愛あるセックス」などでは満足できないこと、
				DATAFORM 家畜として飼育されたこと、
				DATAFORM 行きずりの男の一物をしゃぶって回らされたこと、
				DATAFORM レイプされていないと子宮が疼いてしかたないこと、
				DATAFORM 腕のように太いペニスが今も恋しくてしかたないこと、
				DATAFORM 輪姦以外ではイけなくなってしまったこと、
				DATAFORM 奴隷としての自分の分際について、
				DATAFORM 奴隷である自分を犯してくれる彼らがどれだけ素晴らしいか、
				DATAFORM すぐ股を濡らしてしまう己の浅ましさ、
				DATAFORM ときには彼らに厠として使ってもらったこと、
				DATAFORM 二穴を抉られることがどれだけ気持ちいいか、
				DATAFORM 自分は天性の性奴隷なのだということ、
				DATAFORM 日頃受けている調教はどのようなものか、
				DATAFORM ペニスをしゃぶらせていただくときにどれほど幸せか、
				DATAFORM 犯されることこそ女としての生きがいであるということ、
				DATAFORM 今日もこの後この人に犯してもらうのだということ、
				DATAFORM ここに来る前にも何発も膣内射精してもらったということ、
				DATAFORM 今まで知らなかった菊穴での快楽について、
				DATAFORM アナルをペニスでほじくられることがどれだけ気持ちよいか、
				DATAFORM 自分の乳房は授乳でなくパイズリのためにあるということ、
				DATAFORM 自分の口はチンポをしゃぶるためにあるということ、
				DATAFORM 自分の髪はチンポを扱くためにあるのだということ、
				DATAFORM 自分の膣は犯され、膣内射精されるためにあるのだということ、
				DATAFORM 自分はいやらしい、淫らな雌犬にすぎないのだということ、
			ENDDATA
		NEXT
		PRINTFORML などなど……
		PRINTFORMW 聞くに堪えない話の連続に、%ANAME(MASTER)%は唇を噛みしめて堪えていた
```
