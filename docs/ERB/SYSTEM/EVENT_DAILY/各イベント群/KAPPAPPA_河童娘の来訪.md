# SYSTEM/EVENT_DAILY/各イベント群/KAPPAPPA_河童娘の来訪.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/KAPPAPPA_河童娘の来訪.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_KAPPAPPA_RATE, EVENT_DAILY_KAPPAPPA_DECISION, EVENT_DAILY_KAPPAPPA_GENRE, EVENT_DAILY_KAPPAPPA; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_KAPPAPPA_RATE()
RETURN (DVAR:河童_抱いた回数 > 0 ? (120 + (DVAR:河童_抱いた回数 * 30)) # 30)


;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_KAPPAPPA_DECISION()
RETURN 10 <= DAY

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_KAPPAPPA_GENRE()
RETURN デイリー_ジャンル_エロ



;---------------------
;本体
;---------------------
@EVENT_DAILY_KAPPAPPA
#DIM 金額
#DIM 対象

IF DVAR:河童_発生フラグ == 0
	PRINTFORML 仕事をしていると部下が来客を告げた
	PRINTFORML 何やら河童の集団の使いらしい
	PRINTFORMW 妖怪が何の用だろか？気になった%ANAME(MASTER)%は会うことにした
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
	PRINTFORML 「こんにちはー、会ってくれて嬉しいよー」
	PRINTFORML 「ここの前に他の国にも行ったんだけどさ、どこでも門前払いなんだもん、酷いと思わない？この前なんてさー…」
	PRINTFORMW 現れたのは人懐っこい笑顔を見せる、河童の娘だった
	PRINTFORMW おしゃべり好きらしく、ここに来るまでの苦労だのなんだの長話を遮って、本題を促した
	PRINTFORML 「そうそう、そうだったよ。えっとねー、私達って色々発明好きなんだけどさ」
	PRINTFORML 「やっぱりそういうのって自分たちで使うだけじゃなくていろんな人たちに使ってほしいじゃない？」
	PRINTFORML 「だから商いを始めようと思ってね！その許可をもらいに来たんだよー」
	PRINTFORML 「どんな発明品かって？んふー、気になっちゃう？でもなー、まだ発売前だしなー、でも気になるって言うなら教えない事も…」
	PRINTFORMW よほど話を聞いてもらえてうれしいのか楽しそうに言葉を続ける彼女の話を聞き流す
	PRINTFORML 要は領内で商いをしたいから許可が欲しいと言う事らしい
	PRINTFORMW 発明品の内容も危険はなさそうだ…妖怪の言う事だから話半分の方がいいかもしれないが
	DVAR:河童_発生フラグ = 1
ELSEIF DVAR:河童_発生フラグ == 1
	PRINTFORML 例の河童の娘が再び訪れてきた
	IF DVAR:河童_抱いた回数 == 0
		PRINTFORML 「あの後、他の国とも交渉したけど、やっぱり許可もらえなかったんだよー」
		PRINTFORML 「ここだけが頼りなのさ、ね？お願いするよ」
		PRINTFORMW 相変わらずの人懐っこい笑顔と早口だ
	ELSEIF DVAR:河童_抱いた回数 > 6
		PRINTFORML 「ん…こんにちは、えへへ、また来ちゃった…」
		PRINTFORML 「今回も、お願いしにきたの…商いと…他にも、ね？」
		PRINTFORMW 彼女はすっかり雌の表情をして、媚びる様な声色を出している
	ELSE
		PRINTFORML 「えっと…あの後、他の国とも交渉したけど、やっぱり許可もらえなかったんだ」
		PRINTFORML 「だからその…またお願いしたいなぁって…」
		PRINTFORMW 以前と違い口調はたどたどしく、心なしか顔が赤い
	ENDIF
ENDIF
PRINTFORML さて、どうしようか……
CALL SINGLE_DRAWLINE
CALL ASK_MULTI_JUDGE("快く許可を出す", 1, "金を要求する", 1, "体を要求する", HAS_PENIS(MASTER), "やめておく", 1)
;断るパターン
IF RESULT == 3
	IF DVAR:河童_抱いた回数 > 0
		PRINTFORML 「うぅ…そんなぁ」
		PRINTFORMW 娘はがっかりして帰っていった
	ELSE
		PRINTFORML 「えー、残念だなぁ…」
		PRINTFORMW 娘はがっかりして帰って行った
	ENDIF
	DVAR:河童_発生フラグ = 1
	RETURN
;援助するパターン
ELSEIF RESULT == 0
	IF DVAR:河童_抱いた回数 > 5
		PRINTFORML 「ありがとう♥でも、それだけ…？」
		PRINTFORML 快く許可を出してやると、彼女はもじもじと体を揺すりだした
		PRINTFORMW その瞳には何かを期待する様な視線が混ざっていた
		PRINTFORML %ANAME(MASTER)%は苦笑すると彼女に歩み寄り、腰に手を回した
		PRINTFORML 「あっ…」
		PRINTFORMW 微かに喉を震わせて喘ぎ声を漏らした彼女を、寝室へと連れ込んだ
		PRINTFORML ・・・
		PRINTFORML ・・
		PRINTFORMW ・
		PRINTFORMW すっかり%ANAME(MASTER)%好みになった彼女の身体をたっぷりと可愛がった
	ELSEIF DVAR:河童_抱いた回数 > 0
		PRINTFORML 「えっ、うん…いいの？」
		PRINTFORMW 快く許可を出してやったら彼女は拍子抜けた様な声を出した
		PRINTFORML 「えっと…あの、ありがとう」
		PRINTFORMW 娘は%ANAME(MASTER)%をチラチラ振り返りながら足早に去って行った
	ELSE
		PRINTFORML 「ほんとに！？やったー！ありがとう！」
		PRINTFORMW 娘は飛び上がって喜び、嬉しさのあまり%ANAME(MASTER)%に抱きついてきた
		PRINTFORML 「えへへー、これで皆にもよい報告できるよー！ほんとにありがとー！」
		PRINTFORMW 娘はぴょんぴょん跳ねながら、大きく手を振りつつ去って行った
	ENDIF
	DVAR:河童_発生フラグ = 1
	DVAR:河童_商売した回数 ++
;金を要求するパターン
ELSEIF RESULT == 1
	金額 = 4000 + DAY * 100
	SIF 金額 > MONEY / 4
		金額 = MONEY / 4
	IF DVAR:河童_抱いた回数 > 5
		PRINTFORML 「えっと、欲しいのはそれだけ…？」
		PRINTFORML お金を求めると彼女はもじもじと体を揺すりだした
		PRINTFORMW その瞳には何かを期待する様な視線が混ざっていた
		PRINTFORML %ANAME(MASTER)%は苦笑すると彼女に歩み寄り、腰に手を回した
		PRINTFORML 「あっ…」
		PRINTFORMW 微かに喉を震わせて喘ぎ声を漏らした彼女を、寝室へと連れ込んだ
		PRINTFORML ・・・
		PRINTFORML ・・
		PRINTFORMW ・
		PRINTFORMW すっかり%ANAME(MASTER)%好みになった彼女の身体をたっぷりと可愛がった
	ELSEIF DVAR:河童_抱いた回数 > 0
		PRINTFORML 「えっ…それだけでいいの？」
		PRINTFORMW お金を求めると彼女は何やら拍子抜けした様な表情を見せた
		PRINTFORML 「あ、いや！なんでもない！…うん、わかったよ」
		PRINTFORMW 彼女は慌てて前言を撤回すると、すんなりとお金を払った
	ELSE
		PRINTFORML 「うーん、お金かー」
		PRINTFORML 「研究にもお金かかるんだけど、うーんうーん…仕方ないねー」
		PRINTFORMW 娘はしばし悩んでいた様だが、背に腹は代えられないようだった
	ENDIF
	SETCOLOR カラー_オレンジ
	PRINTFORMW {金額}の資金を得た
	RESETCOLOR
	MONEY += 金額
	LOCAL = 1
;身体を要求するパターン
;1回目と2回目以降の2パターンだけ用意したけど募金娘みたいにもっといろんなパターン口上書いていいのよ！いいのよ！
ELSEIF RESULT == 2
	IF DVAR:河童_抱いた回数 == 0
		PRINTFORML 許可を出す代わりにお前を抱かせろ
		PRINTFORMW %ANAME(MASTER)%がそう告げると、彼女は一瞬何を言われたのかわからずに硬直した
		PRINTFORML 「あっ……えっ……そ、それ……」
		PRINTFORMW 言われたことを理解すると、彼女は顔を真っ赤にして口をパクパクしだす
		PRINTFORML 「じょ、冗談……だよね？」
		PRINTFORMW ようやく我に返った彼女は、恐る恐る%ANAME(MASTER)%に尋ねてきた
		PRINTFORML しかしもう一度同じことを告げる
		PRINTFORMW 抱かせろ
		PRINTFORML 「っ！！！」
		PRINTFORML 「そ、そんなこと、言って！はっ恥ずかしく、ないの！？」
		PRINTFORMW 彼女は飛び上がって怒りだす
		PRINTFORML しかし駄目ならこれで話は終わりだと%ANAME(MASTER)%が冷徹に告げると
		PRINTFORMW 彼女は言葉に詰まり、俯いた
		PRINTFORML 「………よ」
		PRINTFORMW しばらくの沈黙の後、彼女から絞り出すような声が漏れた
		PRINTFORML 「…わ、わかったよ……」
		PRINTFORML もじもじとしながらも了承の言葉を呟いた
		PRINTFORMW %ANAME(MASTER)%は早速彼女の手を引き、寝室へと連れ込む
		PRINTFORML 「あ……で、でも……この事は……その、皆には、秘密に……して……」
		PRINTFORMW 顔を真っ赤にしながら懇願する彼女に約束してやると、寝室のドアを閉めた
	ELSEIF DVAR:河童_抱いた回数 > 5
		PRINTFORML 「…えへへ、うん」
		PRINTFORMW 身体を要求すると、彼女は何処か嬉しそうに照れ笑いをした
		PRINTFORML 彼女を抱き寄せ、身体をまさぐりながらいやらしい子だと囁く
		PRINTFORMW 「あんっ、そんな意地悪言って…こんな体にしたのは%ANAME(MASTER)%なんだから…♥」
		PRINTFORML 彼女は抗議しながらも嬉しそうに体をくねらせた
		PRINTFORMW %ANAME(MASTER)%は彼女とイチャイチャしながら寝室へ向かった
	ELSE
		PRINTFORML 「………っ」
		PRINTFORMW 再び彼女の体を要求すると、やはり顔を染め俯いてしまう
		PRINTFORML しかし予め覚悟していたようで、頬を染めながらもすぐに了承した
		PRINTFORMW %ANAME(MASTER)%は彼女の手を引くと、寝室へと向かった
	ENDIF
		PRINTFORML ・・・
		PRINTFORML ・・
		PRINTFORMW ・
		SELECTCASE RAND:10
			CASE 0
				PRINTFORMW %ANAME(MASTER)%は彼女の腰を背後から掴みながら、激しく腰を打ち付けている
				PRINTFORMW 柔肉がぶつかり合う音が響き、それに合わせて彼女から呻き声混じりの喘ぎ声が漏れる
				PRINTFORMW 一突き毎に子宮を小突いてやると、彼女は足をガクガクと震わせてなんとか耐えている
				PRINTFORMW 具合の良さにたまらず精液を放つと、彼女も背中を大きく弓なりに反らして絶頂した
			CASE 1
				PRINTFORMW %ANAME(MASTER)%は彼女の両腕を背後から掴みながら、激しく犯している
				PRINTFORMW 腰を激しく振りペニスで膣肉を抉るたびに、彼女の体が跳ね色っぽい声が溢れる
				PRINTFORMW 一突き毎にその声は甘えを帯びていき、次第にペニスへの締め付けもきつくなっていく
				PRINTFORMW 絶頂と共に締め付けてくる膣の感触を楽しみながら、彼女の奥へと種を解き放った
			CASE 2
				PRINTFORMW 彼女を押し倒し、覆いかぶさる格好で深々とペニスを挿入する
				PRINTFORMW 腰を深く沈めた状態のまま、ペニスの先端でボルチオをグリグリと刺激してやると
				PRINTFORMW 彼女の喉から思わずあられもない喘ぎ声が漏れ、両足で%ANAME(MASTER)%の腰に抱きついてきた
				PRINTFORMW 密着したまま彼女の胎内へと子種を注ぎ込んでやると、彼女はぎゅうっと抱きしめてきた
			CASE 3
				PRINTFORMW %ANAME(MASTER)%は彼女を抱きしめた格好で、ゆっくりと彼女を躾ける
				PRINTFORMW わざとゆっくりとした腰遣いで彼女を焦らす様に攻めると、彼女の方から腰を振りだす
				PRINTFORMW 我慢できずに精液を子宮へと放つと、彼女は雌の本能のままに悦びの声を上げた
				PRINTFORMW 絶頂の余韻に浸る%ANAME(MASTER)%の首に手を回して、彼女は浅ましく次をねだってきた
			CASE 4
				PRINTFORMW あぐらをかいた%ANAME(MASTER)%の上に跨りながら彼女は甘い声を上げている
				PRINTFORMW 深々と突き刺さったペニスから与えられる快感に、彼女は夢中で腰を揺すっている
				PRINTFORMW 限界が近づいた%ANAME(MASTER)%は彼女を抱き寄せ、濃厚なキスをしながら奥深くで射精した
				PRINTFORMW 彼女は膣内をキュっと締め付け、足をピンと伸ばしながらビクンビクンと身体を震わせた
```
