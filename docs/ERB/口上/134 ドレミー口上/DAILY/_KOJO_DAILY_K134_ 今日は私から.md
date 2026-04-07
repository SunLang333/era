# 口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_ 今日は私から.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_ 今日は私から.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K134_SEISAI_ONLY_RATE, KOJO_DAILY_K134_SEISAI_ONLY_DECISION, KOJO_DAILY_K134_SEISAI_ONLY_GENRE, KOJO_DAILY_K134_SEISAI_ONLY; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K134_SEISAI_ONLY_RATE(対象)
#DIM 対象
RETURN 70


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K134_SEISAI_ONLY_DECISION(対象)
#DIM 対象

;ドレミーと面識があり、所属がおなじ、正妻であること、7%
SIF !TALENT:対象:正妻
	RETURN 0

;ネトラレミー中は起きない
SIF KDVAR:対象:ドレミー_ネトラレミー > 0
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K134_SEISAI_ONLY_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K134_SEISAI_ONLY(対象)
#DIM 対象
#DIM 経験値

PRINTFORML 
PRINTFORMW ようやく今日の分の仕事が終わった
PRINTFORML さて体力が少し余っているな…少し身体を動かすか？
PRINTFORML それとも今日はベッドで休もうか？
CALL ASK_YN("身体を動かす", "ベッドで休む")
IF RESULT == 0
	SELECTCASE RAND:100
		CASE IS < 40
			経験値 = GET_EXP(GETNUM(ABL, "武闘"))
		CASE IS < 70
			経験値 = GET_EXP(GETNUM(ABL, "防衛"))
		CASE IS < 90
			経験値 = GET_EXP(GETNUM(ABL, "知略"))
		CASEELSE
			経験値 = GET_EXP(GETNUM(ABL, "政治"))
	ENDSELECT
	PRINTFORML 一人で自分の戦い方を見直しながら武器を振った……
	CALL PRINT_ADD_EXP(MASTER, EXPNAME:経験値, RAND:5 + 1, 1)
	CALL TRAIN_AUTO_ABLUP(MASTER)
	PRINTFORMW %ANAME(MASTER)%はそのまま朝まで続けた
ELSE
	IF KDVAR:対象:ドレミー_今日は私から == 0
		PRINTFORML 
		PRINTFORML 皆が寝静まり始めた深夜、%ANAME(MASTER)%も寝ようとベッドに横になった
		PRINTFORML %ANAME(対象)%を妻に迎えてからは必ず毎日同じベッドで寝ている
		PRINTFORML だが隣には妻は居ない、普段なら先に床に就いている筈だが……
		PRINTFORMW きっと夢の世界に行っているのだろうと考え、%ANAME(MASTER)%は蝋燭の灯を消して一人で寝ることにした
		PRINTFORMW ・
		PRINTFORMW ・
		PRINTFORMW ・
		SETCOLOR カラー_ピンク
		PRINTFORML ぼんやりと蝋燭の火が部屋を照らしている……おかしい、蝋燭の火は確かに消したはずだが
		PRINTFORML 「ふふっ%ANAME(MASTER)%ったら、これで起きちゃうなんて眠りが浅いですねぇ良い夢見れませんよ？」
		PRINTFORML 目を覚まし声のする方へ向くと、そこには挑発的に微笑んでスカートをたくし上げた%ANAME(対象)%がベッドの傍に立っていた
		PRINTFORML 「…セックス好きの女って……嫌い？」
		PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の頬に手を当てて耳元でそう囁いた
		PRINTFORML 
		PRINTFORML 
		PRINTFORML %ANAME(MASTER)%は頬に当てられた手に自らの手を重ね、自身の思いを伝えた
		PRINTFORML 「……じゃあ…いいよね」
		PRINTFORML 表情を変える事無く%ANAME(対象)%は手を離し、寝そべる%ANAME(MASTER)%の上に立つ
		PRINTFORML そのまま%ANAME(対象)%はスルスルと衣服を脱ぎ落とし、艶っぽい紫に綺麗な刺繍レースをあしらったベビードール姿になる
		PRINTFORML ピンっと張った乳首が透けて見え、下着の上からでも欲情しきっているのがわかるほどの愛液で蜜壺が濡れている……
		PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の手を握り、濡れた蜜壺をなぞらせてきた
		PRINTFORML ネットリとした愛液が%ANAME(MASTER)%の指と指の間でヌチャヌチャと音を立てて糸を引いている……
		PRINTFORML 「もう……こんなになっちゃったの♥　んちゅっ……♥」
		PRINTFORML %ANAME(MASTER)%が勃起したのを見てとると、%ANAME(対象)%は互いの舌を交わらせる程の濃厚なキスをしてきた
		PRINTFORML 「%ANAME(MASTER)%は動かなくていいわ♥」
		PRINTFORMW 
	ELSE
		SETCOLOR カラー_ピンク
		PRINTFORML 皆が寝静まり始めた深夜、%ANAME(MASTER)%も寝ようとベッドに横になると隣に%ANAME(対象)%が横たわっていた
		PRINTFORML 「ふふっ、今日も……ね♥」
		PRINTFORML %ANAME(対象)%はすでに艶っぽい%SPLIT_RAND("紫/黒/赤/緑/青/白", 1)%に綺麗な刺繍レースをあしらった%SPLIT_RAND("ベビードール/オープンブラ/ビスチェ/スリップ", 1)%姿だ
		PRINTFORMW ピンっと張った%SPLIT_RAND("乳首/クリトリス", 1)%が透けて見え、下着の上からでも欲情しきっているのがわかるほどの愛液で蜜壺が濡れている……
		PRINTFORM
			;―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
		IF RAND:5 == 0
			PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の手を握り、濡れた蜜壺をなぞらせてきた
			PRINTFORML ネットリとした愛液が%ANAME(MASTER)%の指と指の間でヌチャヌチャと音を立てて糸を引いている……
			PRINTFORML 「もう……こんなになっちゃったの♥　んちゅっ……♥」
			PRINTFORML  %ANAME(MASTER)%が勃起したのを見てとると、%ANAME(対象)%は互いの舌を交わらせる程の濃厚なキスをしてきた
		ELSEIF RAND:4 == 0
			PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の背に手をまわし、身体を押し付けるように抱き着いてきた
			PRINTFORML 「すぅーっ♥　はぁぁ♥　すぅーっ♥　はぁぁ♥」
			PRINTFORML %ANAME(MASTER)%の耳の裏に鼻をあてて深呼吸をする%ANAME(対象)%、呼吸の度に身体をビクッと震わせている
			PRINTFORML 身体が震える度に%ANAME(MASTER)%のペニスはヌチャヌチャと音を立てて%ANAME(対象)%の濡れた蜜壺を摩っていく……
			PRINTFORML 「だめ……我慢デキない♥　んちゅっ……♥」
			PRINTFORML  %ANAME(MASTER)%が勃起したのを見てとると、%ANAME(対象)%は互いの舌を交わらせる程の濃厚なキスをしてきた
		ELSEIF RAND:3 == 0
			PRINTFORML 「舌出して♥　ほら♥　んむっ♥　ちゅ、れろっ……♥」
			PRINTFORML 言われるまま舌を出すと、%ANAME(対象)%はその舌先に自らの舌先を絡ませ舌裏や天井まで舐める
			PRINTFORML 「あむっ……ぢゅるるるっ…んっ♥」
			PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の舌を咥え、フェラチオをするように音を立てて吸い始める
			PRINTFORML そのまま更に%ANAME(MASTER)%に抱きつきながら%ANAME(対象)%は淫らに首を動かす
			PRINTFORML しばらくしてようやく%ANAME(対象)%は%ANAME(MASTER)%の舌から舌先を離した
			PRINTFORML 互いの舌先は透明で粘っこい糸をつぅーと垂らし繋がっている……
		ELSEIF RAND:2 == 0
			PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の背に手をまわし、身体を押し付けるように抱き着いてきた
			PRINTFORML 「はぁぁ♥　ねぇ……%ANAME(MASTER)%♥」
			PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%のペニスを手で優しく愛撫しながら耳元で囁く
			PRINTFORMW 「おちんちん♥　勃てて♥♥♥　いっぱいエッチしよ♥♥　気持ちよくなっちゃお♥♥♥」
			PRINTFORMW 「好き♥　%ANAME(MASTER)%大好き♥♥　愛してる♥」
			PRINTFORMW 「ほら触って♥♥　オマンコ♥　グッチョグチョなの♥　%ANAME(MASTER)%のおちんちん欲しいの♥♥♥」
			PRINTFORMW 「気持ちよくなっちゃお♥　いっぱいエッチしちゃお♥」
			PRINTFORMW 「孕ませて♥♥　いっぱい♥♥♥　気持ちよくして♥♥♥　ほら♥　おちんちん勃てて♥♥」
			PRINTFORMW 「エッチ♥♥　気持ち良～い♥♥　エッチしよ♥　ねっ♥♥♥」
			PRINTFORMW 「%ANAME(MASTER)%のおちんちんで♥♥　いっぱい突いて♥♥　いっぱい出して♥♥♥」
			PRINTFORMW 「好き♥♥　好き♥♥　好き♥♥♥　エッチしたいの♥♥　%ANAME(MASTER)%♥♥♥　大好きっ♥♥♥」
			PRINTFORML  %ANAME(対象)%の囁きに%ANAME(MASTER)%が勃起すると、%ANAME(対象)%は互いの舌を交わらせる程の濃厚なキスをしてきた
		ELSE
			PRINTFORML %ANAME(対象)%は下着から乳首を露出させ%ANAME(MASTER)%の口元へ近付けた
			PRINTFORML 「ねぇ……吸って♥」
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%の淡いピンク色の乳輪に舌を這わせる…
			PRINTFORML 「もぅ……♥　……ふふっ♥」
			PRINTFORML そのまま乳輪だけをねちっこく攻め続ける%ANAME(MASTER)%
			PRINTFORMW
			PRINTFORML 「んっ♥　……ふっー♥」
			PRINTFORML 既に%ANAME(対象)%の乳首はピンっと張り詰め、%ANAME(MASTER)%の舌先による愛撫への期待に満ちている…
			PRINTFORML 「%ANAME(MASTER)%……」
			PRINTFORML 切なげな声で呟いている%ANAME(対象)%
			PRINTFORML その姿を見て%ANAME(MASTER)%は乳輪ばかりを責めていた舌先を乳頭に移した
			PRINTFORML 「あっ♥♥♥　そんな急に♥♥♥♥」
			PRINTFORMW 
			PRINTFORML %ANAME(MASTER)%は乳頭を舌先で舐め絞ったり、舌先でちょっぴり触れさせた
			PRINTFORML 「あはっ♥……はっ…んっ……くあっ…♥」
			PRINTFORML そのたび%ANAME(対象)%は腰を浮かせ感じている…
			PRINTFORML そこへ%ANAME(MASTER)%は固くなった乳首を甘噛みしつつチュパチュパと音をたてて吸った
			PRINTFORML 「あぁん♥♥　そんな赤ちゃんみたいに♥♥」
			PRINTFORML 「ふふっ♥　良いですよ♥　おっぱい好きなのよね♥」
			PRINTFORML %ANAME(MASTER)%が口を離すと、%ANAME(対象)%が互いの舌を交わらせる程の濃厚なキスをしてきた
		ENDIF
			;―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
		IF RAND:6 == 0
			PRINTFORML 「%ANAME(MASTER)%は動かなくていいわ♥」
		ELSEIF RAND:5 == 0
			PRINTFORML 「私に任せて♥　いっぱい気持ち良くしてあげる♥♥」
		ELSEIF RAND:4 == 0
			PRINTFORML 「バキバキに勃起した孕ませおちんちん♥　私のねっ…とりオマンコでドピュ♥ドピュ♥させてあげる」
		ELSEIF RAND:3 == 0
			PRINTFORML 「好き♥　いっぱい愛し合いましょ♥　と～っても濃厚な種付け孕ませセックスしましょ♥」
		ELSEIF RAND:2 == 0
			PRINTFORML 「えっちしましょ♥　気持ちいいえっち♥」
		ELSE
			PRINTFORML 「ふふっ♥　危険日子宮でおちんちんジュポジュポさせてあげる♥♥♥」
		ENDIF
			;――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
		PRINTFORMW 
	ENDIF
;――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
		;手コキ・フェラ・パイズリ・素股のどれかが選択される
	SELECTCASE RAND:4
			;手コキ＋手に射精
		CASE 0
			PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%のペニスを手に取りしごき始めた
			IF RAND:3 == 0
				PRINTFORML
				PRINTFORML 「ふふっ、手の中でびくんびくんしてる♥」
				PRINTFORML 丹念にペニスをしごいていく%ANAME(対象)%
				PRINTFORML 右手でペニスをしごきながら左手で袋を優しい手つきで触っている
				PRINTFORML 強すぎず弱すぎず、程よい%ANAME(対象)%の奉仕に%ANAME(MASTER)%は徐々に射精へと向かっていく
				PRINTFORML 「射精したくなったら……♥　いつでもしていいわ♥　受け止めてあげる♥」
				PRINTFORMW
			ELSEIF RAND:2 == 0
				PRINTFORML
				PRINTFORML 「ふふっ♥　ビクビクしちゃって可愛いわね……えいっ♥」
				PRINTFORML ぴんっと指で軽くペニスを弾く
				PRINTFORML 痺れる様な快感に思わず%ANAME(MASTER)%は仰け反る
				PRINTFORML 「あらっ♥　ちょっと痛かったかしら♥　んっー……そうでもないようね♥」
				PRINTFORML そう言って%ANAME(対象)%は手の動きを再開させた
				PRINTFORMW
			ELSE
				PRINTFORML
				PRINTFORML 「ふふっ♥　随分と大きな子供になっちゃったわねぇ……♥」
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%の太ももに顔を乗せ、彼女の胸を弄っている
				PRINTFORML 一方で慈愛の表情を浮かべながら丹念に竿をしごいていく%ANAME(対象)%
```
