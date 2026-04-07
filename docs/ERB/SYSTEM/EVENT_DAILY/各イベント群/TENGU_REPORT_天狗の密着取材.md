# SYSTEM/EVENT_DAILY/各イベント群/TENGU_REPORT_天狗の密着取材.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/TENGU_REPORT_天狗の密着取材.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_TENGU_REPORT_RATE, EVENT_DAILY_TENGU_REPORT_DECISION, EVENT_DAILY_TENGU_REPORT_GENRE, EVENT_DAILY_TENGU_REPORT; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_TENGU_REPORT_RATE()
RETURN (DVAR:天狗取材_発生フラグ > 0 ? 250 # 50)


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_TENGU_REPORT_DECISION()
SIF !HAS_PENIS(MASTER)
	RETURN 0
SIF DVAR:天狗取材_発生フラグ < 0
	RETURN 0
SIF (ABL:MASTER:武闘 + ABL:MASTER:防衛 + ABL:MASTER:知略 + ABL:MASTER:政治) < 250
	RETURN 0
RETURN DAY >= 15

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_TENGU_REPORT_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_TENGU_REPORT()
#DIM 対象

;繰り返しイベント
IF DVAR:天狗取材_発生フラグ == 2
	PRINTFORML 「どうも！　今日も取材にやってきました！」
	PRINTFORMW 今日も天狗の少女が取材にやってきた……

	PRINTFORML 
	PRINTFORML ……
	SELECTCASE RAND:15
		CASE 0
			PRINTFORML 「あっ♥　あんっ♥　もっとぉ♥　もっと奥まで突いてぇ♥」
			PRINTFORML 取材もそこそこに、%ANAME(MASTER)%と少女は部屋の中で激しく求めあった
			PRINTFORML 「んあっ♥　いいからっ、今夜は一晩中、犯してくださいぃっ♥」
			PRINTFORML もちろん断る理由などあるはずもなく、%ANAME(MASTER)%は深々とペニスを突き立てて応えた
			PRINTFORMW きゅんきゅんと切なげに鳴く雌穴に、%ANAME(MASTER)%はたっぷりと種を付けた……
		CASE 1
			PRINTFORML 少女は%ANAME(MASTER)%の足元に跪いて、唇と舌で熱心にペニスに奉仕している
			PRINTFORML 「ん……はぁ♥　相変わらず硬くて熱いですね……♥　気持ちいいですかぁ♥」
			PRINTFORML 返事代わりに%ANAME(MASTER)%は少女の頭を鷲掴みにすると、喉をオナホ代わりにしてピストンした
			PRINTFORML 「んごっ♥　お゛っ♥　オ゛ッ♥　オ゛ッ♥　～～～～ッ♥♥♥」
			PRINTFORMW 喉奥にびゅるびゅると熱い精液を流し込まれて、少女はそれだけで達してしまった……
		CASE 2
			PRINTFORML 「あんっ♥　ごっ、御主人様っ♥　御主人様ぁんっ♥　ごめんなさぁい♥」
			PRINTFORML 今日はメイドの仕事を体験取材するはずだったが、何故かそういうプレイをすることになってしまった
			PRINTFORML 「はいっ♥　出してくださいっ♥　不出来な淫乱メイドにお仕置きしてくださいっ♥
			PRINTFORML 　御主人様の特濃ザーメンでっ♥　御主人様専用のメイドまんこを躾けてくださぃぃ♥♥♥」
			PRINTFORMW %ANAME(MASTER)%は可愛らしいメイド天狗の中にたっぷり射精し、その後も一晩中躾け続けた……
		CASE 3
			PRINTFORML 自勢力内にある温泉宿に、泊りがけで取材に行くことになった
			PRINTFORML 「もぉ♥　お食事が済んだらすぐセックスだなんて、少しは景色を楽しみましょうよぉ……♥」
			PRINTFORML 家族風呂に二人で浸かりながら、ゆっくりとまぐわいを楽しんだ
			PRINTFORML 「ところでこの温泉って子宝の湯って言われてるらしいですよ……♥
			PRINTFORMW 　あっ♥　ちょっと♥　急に、はげしっ♥　ほっ、本気で孕ませる気ですかっ、もぅっ♥♥♥」
		CASE 4
			PRINTFORML 河童から新しい発明品のレビューを頼まれたそうなので、協力することにした
			PRINTFORML 「ひい゛ぃーっ♥　ちょっ♥　これっ♥　勘弁してくださっ♥　やば、やばいですっ♥
			PRINTFORML 　お゛っ♥　おしりのあな、ばかになっちゃうっ♥　ばかになっちゃうよぅ♥」
			PRINTFORML 四つん這いになった少女のアナルで、河童印の極太バイブがぐいんぐいん蠢いている
			PRINTFORMW %ANAME(MASTER)%はその様子を観察してレポートしつつ、購入することを検討した……
		CASE 5
			PRINTFORML 「あ゛あ゛ァーーーっ♥♥♥　あ゛ッ♥　オ゛ッ♥　んんお゛お゛っお゛っお゛っ♥
			PRINTFORML 　いぎゅっ♥♥♥　いぎまひゅっ♥♥♥　いひっ♥　ひっひっひィィィーーーー♥♥♥」
			PRINTFORML 永遠亭から新しい媚薬のレビューを頼まれたのだが、どうやら効果が強すぎるようだ
			PRINTFORML かく言う%ANAME(MASTER)%も勃起が収まらず、何度出しても全く萎える気配を見せない
			PRINTFORMW 結局効果が切れる頃には、少女の腹は妊娠したかのように膨れ上がっていた……
		CASE 6
			PRINTFORML 「は……はいっ、チーズぅ♥」
			PRINTFORML %ANAME(MASTER)%に下から貫かれた姿勢のまま、少女はセルフタイマーで自分の姿を撮影させられた
			PRINTFORML 「うぅっ、仕事道具なのに……こんな写真誰にも見せられませんよぉ
			PRINTFORML 　え？　次は中出しされてイってるところを撮る？　それはちょっ、あっ♥　あっ♥　あ゛ーっ♥」
			PRINTFORMW その後、%ANAME(MASTER)%は少女の痴態を思う存分撮影してやった……
		CASE 7
			PRINTFORML 「も、もうっ！　本当に仕方のない人ですねぇ……♥」
			PRINTFORML 今日は食レポに出かけたが、途中でついムラっとした%ANAME(MASTER)%は、少女を路地裏に連れ込み口で奉仕させた
			PRINTFORML 「あむっ♥　ちゅっ♥　ちゅるっ、んぶっ、じゅるっ、じゅるるんっ♥
			PRINTFORML 　いいれふよぉ♥　らひてくらひゃい♥　おいしいせーえき、たっぷりのまへてぇ♥♥♥」
			PRINTFORMW その後も何件か回ったが、口内の精液の味が残っていたため、まともな取材にならなかったようだ……
		CASE 8
			PRINTFORML 「あぐっ♥　あぅぅん♥　あっ♥　あっ♥　あぅぅーっ♥　あぁんっ♥」
			PRINTFORML %ANAME(MASTER)%は少女に覆い被さりながら、深いところまで膣肉を味わっている。
			PRINTFORML 少女は嬉しさで咽び泣きながらガクガクと身体を震わせ、%ANAME(MASTER)%に愛される幸せに酔い痴れている
			PRINTFORML 「好きぃっ、好きですっ♥　こうやってっ、奥までっ♥　%ANAME(MASTER)%に、してもらうのぉ♥♥♥」
			PRINTFORMW 必死にしがみつきながら可愛らしく呻く少女に、%ANAME(MASTER)%はキスしながら長々と精を注ぎ込んだ……
		CASE 9
			PRINTFORML 「あっ♥　ひゃんっ♥　お、奥まで来てますよぉっ♥　ぐりぐりってぇ♥」
			PRINTFORML 少女は%ANAME(MASTER)%に跨り、自分から腰を振って子宮口を抉る悦びに溺れている
			PRINTFORML すっかり%ANAME(MASTER)%に躾けられた膣肉は、別の生き物のようにうねり、ペニスに吸い付いてくる
			PRINTFORML 「あはっ♥　気持ちいいですかぁ♥　いい、ですよ♥　一緒に、もっと、気持ちよく♥　よくぅ♥」
			PRINTFORMW ますます熱烈に腰をくねらせる少女に、%ANAME(MASTER)%が堪らず射精すると、少女もまた嬌声を上げて絶頂した……
		CASE 10
			PRINTFORML 「ちょっ♥　ひぃっ、こんなの誰かにばれたらっ、どうするんですかぁ♥」
			PRINTFORML 自勢力内の見回りに出た%ANAME(MASTER)%だったが、つい途中でムラッと来てしまい、物見櫓の上で少女に襲いかかった……
			PRINTFORML 「ひィィッ♥　お、お願いっ♥　誰も気づかないでぇ♥　見られたらっ、恥ずかしくて死んじゃうぅ♥
			PRINTFORML 　バレたらっ♥　あぁんっ♥　バレたらぁ、私が新聞に載っちゃいますぅぅぅー……♥♥♥」
			PRINTFORMW 異常な状況に興奮してきゅんきゅんと締め付けてくる肉穴に、%ANAME(MASTER)%は満足いくまで精液を注ぎ込んだ……
		CASE 11
			PRINTFORML 今日は勢力内で開かれているお祭りに、少女を伴って行ってみた。
			PRINTFORML 少女の浴衣姿にドキドキしつつも取材を終えて少し休んでいたが、そこら中の茂みから男女の喘ぎ声が聞こえる……
			PRINTFORML 「い、いやぁ皆さんお盛んなことで……♥　で、その、そう、取材の一環として、ですね……、私達も、しますか？」
			PRINTFORML ちらりと浴衣の裾を捲って恥ずかしげに誘う少女に、%ANAME(MASTER)%は一も二もなく襲いかかった
			PRINTFORMW そして嬉しげにきゃー♥と悲鳴を上げる少女を押し倒し、周囲のカップルに負けないほど哭かせてやった……
		CASE 12
			PRINTFORML 取材中、突然の雨に降られてしまった%ANAME(MASTER)%と少女は、仕方なく近くにあった宿に飛び込んだ
			PRINTFORML 「でも、これってどう見ても……連れ込み宿ですよねぇ……♥」
			PRINTFORML その通りだ。そして折角入ったのなら楽しむべきだ。そう思った%ANAME(MASTER)%は少女を押し倒した
			PRINTFORML 「あーもうっ♥　分かってましたけどっ！　というかそもそも最初から分かってて連れ込んだんじゃ……♥
			PRINTFORMW 　あっ♥　ごめっ、口答えしませんからぁ♥　そこっ♥　だめっ♥　やっ、あっ♥　あっ♥　あ゛ーーーっ♥♥♥」
		CASE 13
			PRINTFORML ある宿で裏取引が行われているという情報を掴んだ%ANAME(MASTER)%と少女は、潜入捜査を行うことになった
			PRINTFORML しかしそこはカップル御用達の秘密の連れ込み宿……やむなく、%ANAME(MASTER)%達は恋人同士として宿に潜入した
			PRINTFORML 「そ、そうっ♥　これは捜査のために仕方のないことなんです♥　恋人同士の演技をっ♥　しないとっ♥
			PRINTFORML 　あっ♥　あっ♥　いいよぉ♥　もっと愛してくださいっ♥　%ANAME(MASTER)%の子種ぇ♥　たくさんくださいぃ♥」
			PRINTFORMW その後、恋人ごっこにハマりすぎてうっかり取引現場を逃しかけたが、なんとか犯人達を捕えることができた……
		CASE 14
			PRINTFORML ムラムラしていた%ANAME(MASTER)%は、今日は仕事も取材も放り投げて少女とセックスすることにした
			PRINTFORML 「あっ♥　そ、そんなんでいいんですかぁ♥　し、仕事は、真面目に、しないと♥　いけないんです、よぉ♥」
			PRINTFORML そんなことは関係ない、今はただお前の身体を味わい尽くしたいと、%ANAME(MASTER)%は告げた
			PRINTFORML 「……ッ♥♥♥　ず、ずるいですよぉ♥　そんなこと言われたらっ♥　私もっ♥　我慢っ♥　できなくなっちゃいますっ♥
			PRINTFORMW 　うんっ♥　うんっ♥　いっぱいシてくださいっ♥　%ANAME(MASTER)%の子種っ♥　好きなだけ私の中に出してください……っ♥♥♥」
	ENDSELECT 
	PRINTFORMW
	RETURN 1
ENDIF

;回数進行イベント
IF DVAR:天狗取材_発生フラグ == 0
	PRINTFORML ある日、%ANAME(MASTER)%の元を見知らぬ烏天狗の少女が訪ねてきた
	PRINTFORMW 幼さの残る顔立ちだが、活発な印象を与えてくる、綺麗というより可愛らしい少女だ
	PRINTFORML 「どうも、初めましてですよね？
	PRINTFORML 　今日は近頃名を挙げているという%ANAME(MASTER)%さんを、取材させてもらうためにやってきました！」
	PRINTFORML 聞けば、%ANAME(MASTER)%に同行してどんな風に活躍しているか見てみたいのだという
	PRINTFORMW また、今後もしばらくの間、継続的に取材させてほしいとのことだった
	PRINTFORML 「実は私、文さんやはたてさんの後輩なんですが、最近良い記事を書けていなくて……
	PRINTFORML 　でもここで一発、高名な%ANAME(MASTER)%さんの様子をまとめて新聞にすれば、きっと私も目立てると思うんです！
	PRINTFORML 　ですので是非！　取材をさせてください！」
	PRINTFORMW 非常にやる気の入った様子で少女はまくし立ててきた
	PRINTFORML その熱意は認めるが、%ANAME(MASTER)%も暇というわけではない……
ELSEIF DVAR:天狗取材_発生フラグ == 1
	PRINTFORMW また烏天狗の少女がやってきた
	PRINTFORML 「こんにちは、また取材させてもらいに来ました！
	PRINTFORML 　今日は大丈夫ですか？」
ENDIF
PRINTFORML どうしよう？

CALL SINGLE_DRAWLINE
CALL ASK_YN("受け入れる", "断る")

IF RESULT == 1
	IF DVAR:天狗取材_発生フラグ == 0
		PRINTFORML 「ええっ、そんなぁ……」
		PRINTFORML 目に見えてがっくりと天狗の少女は肩を落とすが、しかしすぐに気を取り直したようで、
		PRINTFORML 「いえ、こんなことで諦めはしません！　そのうちまたお伺いしますからねー！」
		PRINTFORMW そう言い残し、猛スピードで飛び去っていった……
		DVAR:天狗取材_発生フラグ = -1
	ELSEIF DVAR:天狗取材_発生フラグ == 1
		PRINTFORML 「あら、今日は都合が悪いですか……うーん、次は取材させてくださいね！」
		PRINTFORMW めげない様子で、天狗の少女は帰っていった……
	ENDIF
	RETURN 1
ENDIF

DVAR:天狗取材_発生フラグ = 1

PRINTFORML 「やった！　それじゃ今日一日、密着取材させてもらいますね！」
PRINTFORMW 喜色満面といった様子で、少女は%ANAME(MASTER)%に飛びついてきた
PRINTFORML 
PRINTFORML ……

SELECTCASE RAND:7
	CASE 0
		PRINTFORML %ANAME(MASTER)%は今日は前線で指揮を取ることになっている
		PRINTFORML 「うひゃー、激しい戦いですねぇ！　おっと、写真写真……」
		PRINTFORMW さすが天狗というべきか、%ANAME(MASTER)%に飛んでくる矢弾をすいすい避けながら、写真を撮りまくっていた
	CASE 1
		PRINTFORML %ANAME(MASTER)%は、自勢力下にある町の様子を見に行った
		PRINTFORML 「ほほぅ、活気があっていい町ですねぇ……あ、お団子屋さんに寄っていいですか？」
		PRINTFORMW 取材というよりはほとんど食べ歩きのような感じで、%ANAME(MASTER)%は娘に一日中振り回された……
	CASE 2
		PRINTFORML 今日の%ANAME(MASTER)%は、政策を話し合う会議に出ることになっている
		PRINTFORML 「会議の様子を取材したいんですけど私も入っていいですか？　あ、やっぱだめ？　ちぇー……」
		PRINTFORMW 娘は口を尖らせて不満を訴えるが、さすがに中に入れるわけにはいかない……
	CASE 3
		PRINTFORML %ANAME(MASTER)%は、今日はずっと自室に篭もって書類仕事を片付けることにした
		PRINTFORML 「うーん、これじゃあ取材にならないし暇なんですが……あ、お茶とか入れてきましょうか」
```
