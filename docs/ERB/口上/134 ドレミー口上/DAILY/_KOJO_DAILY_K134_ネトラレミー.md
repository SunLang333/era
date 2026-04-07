# 口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_ネトラレミー.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_ネトラレミー.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K134_NTR_RATE, KOJO_DAILY_K134_NTR_DECISION, KOJO_DAILY_K134_NTR_GENRE, KOJO_DAILY_K134_NTR; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K134_NTR_RATE(対象)
#DIM 対象

;最初は10%
IF KDVAR:対象:ドレミー_ネトラレミー == 0
	RETURN 100
;二回目以降は100%
ELSE
	RETURN 1000
ENDIF

RETURN 1000


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K134_NTR_DECISION(対象)
#DIM 対象

SIF KDVAR:対象:ドレミー_ネトラレミー == -1
	RETURN 0

SIF !TALENT:対象:恋人
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K134_NTR_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ



;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K134_NTR(対象)
#DIM 対象

SELECTCASE KDVAR:対象:ドレミー_ネトラレミー
	CASE 0
		PRINTFORMW とある昼下がり%ANAME(MASTER)%が廊下を歩いていると、部下の一人が%ANAME(対象)%に言い寄っているのを見かけた
		PRINTFORML 「……っ……」
		PRINTFORMW しつこく部下が言い寄ってくるが、事務的に接して凌ぎきった…
		PRINTFORML あの様子では放っておくとしつこくなりそうだがどうしたものか……
		CALL ASK_YN("まぁ何とかなるだろう", "異物は排除しないと……")
		IF RESULT == 0
			PRINTFORMW まぁ何とかなるだろう
			PRINTFORMW %ANAME(MASTER)%は放っておいて自分の仕事に戻った……
			KDVAR:対象:ドレミー_ネトラレミー = 1
		ELSE
			PRINTFORMW 異物は排除しないと……
			PRINTFORMW 数刻後、%ANAME(MASTER)%は部下を部屋に呼び出し内密に排除した……
			KDVAR:対象:ドレミー_ネトラレミー = -1
		ENDIF
	CASE 1
		PRINTFORMW %ANAME(対象)%に部下が言い寄っている……
		PRINTFORML 
		PRINTFORMW %ANAME(対象)%は遂に誘いを断り切れず、言葉巧みな部下に乗せられ部下の私室へ連れて行かれた……
		IF RAND:3
			PRINTFORMW 何度も愛の言葉を囁かれながら、身体を抱き寄せられて胸を揉まれている
		ELSEIF RAND:3 == 0
			PRINTFORMW 何度も愛の言葉を囁かれながら、太ももを撫でられている
		ELSE
			PRINTFORMW 何度も愛の言葉を囁かれながら、パンティ越しに秘裂に指を這わされている
		ENDIF
		IF RAND:2
			PRINTFORML 「……っ……」
		ELSE
			PRINTFORML 「…あ…っ……」
		ENDIF
		IF RAND:2 == 0
			PRINTFORMW 秘所を指で責め立てられ、%ANAME(対象)%は快感に耐えるのに精一杯で逃げるに逃げ出せない…
		ELSE
			PRINTFORMW 逃げようとする%ANAME(対象)%は部下は秘所に指を押し付けやらしく撫でて動きを封じた…
		ENDIF
		IF RAND:3 == 0
			SETCOLOR カラー_ピンク
			PRINTFORMW %ANAME(対象)%は男に手籠めにされつつある……
			RESETCOLOR
			KDVAR:対象:ドレミー_ネトラレミー = 2
		ELSE
		ENDIF
	CASE 2
		PRINTFORMW %ANAME(対象)%は部下の男が気になってしまい、夜に部下の私室へ訪れた…… 
		PRINTFORML 
		SELECTCASE RAND:5
			CASE 5
				PRINTFORML 男の上で腰を振る様に言われた%ANAME(対象)%は、
				PRINTFORML %ANAME(MASTER)%の命令ではないと理解しているのに男に跨り、種付けの為の挿入を受け入れた……
				PRINTFORML 男の上で腰を振りながら、男は身も心も調教されている……
				PRINTFORML 部屋の中にはベットの軋む音と%ANAME(対象)%の嬌声が響き続けた……
			CASE 4
				PRINTFORML ベッドに生まれたままの姿で入ると、%ANAME(対象)%は男に強く抱かれ、唇を貪られた……
				PRINTFORML 種付けをしようとする雄の愛撫にすっかり身体を準備された%ANAME(対象)%は、正常位で身体を開き雄の欲望を受け入れた……
				PRINTFORML 何度も子宮で精液を受け止めながら、%ANAME(対象)%は雌の本能のまま子宮を捧げ続けた……
			CASE 3
				PRINTFORML 男に服を脱ぐように言われた%ANAME(対象)%は、
				PRINTFORML %ANAME(MASTER)%の命令ではないと理解しているのに服を肌蹴け、素肌を晒してしまった……
				PRINTFORML そのまま%ANAME(対象)%の全身をくまなく愛撫されると、%ANAME(対象)%は種付けの為の挿入を受け入れた……
				PRINTFORML 部屋の中にはベットの軋む音と%ANAME(対象)%の嬌声が響き続けた……
			CASE 2
				PRINTFORML 危険日だから今日はダメだと心に決めていたはずの%ANAME(対象)%だったが、
				PRINTFORML 男に抱き締められ押し倒されると、そのままペニスの挿入を許してしまった……
				PRINTFORML 何度も子宮で精液を受け止めながら、%ANAME(対象)%は雌の本能のまま子宮を捧げ続けた……
			CASE 1
				PRINTFORML 男は%ANAME(対象)%が危険日だと知ると、普段よりも激しく%ANAME(対象)%を求めていった…
				PRINTFORML 
				PRINTFORML 何度も大量に注がれた精液が垂れるのをそのままにして、限界を迎えてぐったりベッドに横たわる%ANAME(対象)%に
				PRINTFORML 男は再びペニスを突き立て、体を揺すりだした……
				PRINTFORML %ANAME(対象)%の子宮を男の精液で満たし、しっかり種付けを完了させるまで
				PRINTFORML 男の雄の本能が行為を終わらせようとはしなかった……
			CASEELSE
				PRINTFORML %ANAME(対象)%は壁に手をついた格好で男に後ろから犯されている……
				PRINTFORML %ANAME(対象)%は尻肉を掴まれながら、ゆっくりと確実に男の子種を種付けされた……
		ENDSELECT
		PRINTDATAL
			DATAFORM 「…ぅ…ぁっ…あっ…あっ……はぁっ！」
			DATAFORM 「当たっ…て…っ…ああぁっ！…あんっ…はぁあぁっ！」
			DATAFORM 「あはっ……ふあっ……っはぁんっ…」
			DATAFORM 「……ひゃっ…んっあっ……はっ」
			DATAFORM 「…っ……あ…っ……くぁっ」
		ENDDATA
		PRINTDATAW
			DATAFORM 後ろから肉棒を突き入れられ、それでも抵抗する%ANAME(対象)%だったが、秘所からは悦びの証拠である愛液がぱたぱたと零れていた…
			DATALIST
				DATAFORM 快感を認めつつある%ANAME(対象)%を見て薄く笑った男は、ペニスを引き抜くと口元にズイッと突きつける
				DATAFORM 察した%ANAME(対象)%はしぶしぶ精液と愛液で汚れきった肉棒を頬張り、舌と唇を使って掃除を始めた…
			ENDLIST
			DATAFORM 交尾を終えた二人は離れることなく、%ANAME(対象)%は未だ元気な男のペニスをブラジャーを着けたままパイズリで奉仕した
			DATAFORM 豊満な胸を自分の物にするべく、男は精液でプルプルと卑猥に揺れる乳房にマーキングしていく…
			DATAFORM 乳首にぐりぐりと擦りつけながら、男は吐き出す精液で%ANAME(対象)%の胸をマーキングしていく…
			DATALIST
				DATAFORM 子宮に数度目の種付けを終えても男はペニスを抜かずにそのまま腰を振り続ける
				DATAFORM 打ち付ける度に、結合部からは入りきらない精液が溢れでてきた…
			ENDLIST
		ENDDATA
		CALL FUCK_MAKELOVE(対象, GET_SPERM_ID("不明"), @"部下の男の\@RAND:2 ? ペニス # 唇\@", @"部下の男")
		IF RAND:5 == 0
			SETCOLOR カラー_ピンク
			PRINTFORMW %ANAME(対象)%は完全に男に手籠めにされてしまった……
			RESETCOLOR
			KDVAR:対象:ドレミー_ネトラレミー = 3
		ELSE
		ENDIF
	CASE 3
		PRINTFORMW %ANAME(対象)%は顔を赤らめながら、夜に男の客室を訪れた……
		PRINTFORML 
		PRINTDATAL
			DATAFORM 「いっぱい…射精してっ…♥……妊娠…っ…しても…いいからっ♥」
			DATAFORM 「膣内っ……こすれっ…♥……あぁっ…あっあっあっはぁんっ♥」
			DATAFORM 「…好き…っ…♥……愛してる………っ……♥」
			DATAFORM 「あはっ♥…あんなのよりっ…こっちの方が…んっ……気持ちいいっ…♥」
			DATAFORM 「動物の…っ……交尾っ…ふぁっ……みたい…っ……♥」
			DATAFORM 「ぁっあっぁっああっ……んぁあっ！…♥」
			DATAFORM 「…ぅあっ…ぁっ…膣内で…コツンっ…てっ……♥」
			DATAFORM 「当たっ…て…っ♥…ああぁっ！…あんっ…はぁあぁっ！♥」
			DATAFORM 「んぁあっ……にっ……妊娠させてぇっ……赤ちゃん…産みたいのっ…♪」
			DATAFORM 「ふぁっ！……んっ…んっあっ……ぁ…あはっ♥」
			DATAFORM 「…ッ気持ち……ぁっ…よすぎ…♥……イっちゃっ…ひゃあぁあっ♥」
		ENDDATA
		SELECTCASE RAND:12
			CASE 12
				PRINTFORML 部屋の中にベットの軋む音が響く……
				PRINTFORML ベットで仰向けに寝そべる%ANAME(対象)%は男に身を任せ、押し寄せる快楽に喘いでいる……
				PRINTFORML 男が射精しそうだ、と%ANAME(対象)%に伝えると%ANAME(対象)%は笑顔で『中に出して』と囁いた……
				PRINTFORML 
				PRINTFORML その瞬間、膣内でペニスが跳ね、男の精液が排卵日の子宮内を埋め尽くしていく……
				PRINTFORML 二人は射精が終わった後も繋がったままでキスを交わしながら、思いを確かめ合っている……
			CASE 11
				PRINTFORML %ANAME(対象)%は部屋に着くなり男に抱き付き、耳元で危険日である事を告げた……
				PRINTFORML %ANAME(対象)%が求めているものを察した男は、たまらず%ANAME(対象)%の下着に手を掛けた……
				PRINTFORML 
				PRINTFORML 時間を忘れ没頭していた子作りの為のセックスを終えた%ANAME(対象)%は、
				PRINTFORML 注ぎ込まれた子種に満足し、優しく男に微笑んだ……
			CASE 10
				PRINTFORML 仰向けで男を受け入れている%ANAME(対象)%は、足を絡ませ潤んだ瞳で男を見つめている……
				PRINTFORML 裸の身体を密着させより深い挿入をねだる%ANAME(対象)%の身体は、子宮まで届く射精を待ち望んでいる……
				PRINTFORML そして、熱い射精を一番奥で感じると、%ANAME(対象)%は仰け反りながらも男にしがみつき、
				PRINTFORML なおもペニスを離すまいと身体を絡ませていく……
				PRINTFORML 
				PRINTFORML 激しく何度も交わりやっとペニスを解放した%ANAME(対象)%は、
				PRINTFORML 膣口から溢れる精液を男に見せながら今日が危険日だと知らせ、にっこり微笑んだ……
			CASE 9
				PRINTFORML 膣奥に突き立てた時の%ANAME(対象)%の反応に、普段とは違う熱気を感じ取った男は、
				PRINTFORML %ANAME(対象)%が危険日である事を悟り、対面座位で%ANAME(対象)%の腰をしっかりと抱き寄せ最奥への刺激に集中し始めた……
				PRINTFORML 密着した腰使いから男が本気で自分を孕ませるつもりなのだと知ると、
```
