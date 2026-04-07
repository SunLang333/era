# SYSTEM/EVENT_DAILY/各イベント群/HYPNOTISM_SLAVE_AFTER_催眠奴隷のその後.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/HYPNOTISM_SLAVE_AFTER_催眠奴隷のその後.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_RATE, EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_DECISION, EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_GENRE, EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_SETTARGET, EVENT_DAILY_HYPNOTISM_SLAVE_AFTER, SELECT_CHARA_LIST_SHOW_LOGIC_HYPNOTISM_SLAVE_AFTER, SELECT_CHARA_LIST_SELECT_LOGIC_HYPNOTISM_SLAVE_AFTER, EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_ALLOW_WHEN_WANDERING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_RATE()
RETURN 1000


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_DECISION()
RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_HYPNOTISM_SLAVE_AFTER_SETTARGET()
FOR LOCAL, 0, CHARANUM
	;捕虜でなく、死んでおらず、催眠奴隷所持者の女で、1/3の確率
	IF !CFLAG:LOCAL:捕虜先 && CFLAG:LOCAL:特殊状態 != 特殊状態_死亡 && GETBIT(TALENT:LOCAL:デイリー系, 素質_デイリー_催眠奴隷) && IS_FEMALE(LOCAL) && !RAND:3
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
		DAILY_TARGET_NUM ++
	ENDIF
NEXT
SIF DAILY_TARGET_NUM < 1
	RETURN 0
RETURN 1

;---------------------
;本体
;---------------------
@EVENT_DAILY_HYPNOTISM_SLAVE_AFTER
#DIM 対象
#DIM 対象2

FOR LOCAL, 0, DAILY_TARGET_NUM

	対象 = DAILY_TARGET:LOCAL

	PRINTFORMW 催眠奴隷に成り下がった%ANAME(対象)%は今日も仕事場に通っている
	SELECTCASE RAND:100
		CASE 0 TO 39
			PRINTFORMW 今日の仕事は肉便器だと告げられた%ANAME(対象)%は胸を高鳴らせた……
			PRINTFORML 
			SELECTCASE RAND:5
				CASE 0
					PRINTFORMW %ANAME(対象)%はご主人様に抱かれている
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORML 寝室に入るなりベッドに押し倒され乱暴に剥かれるといきなりペニスをねじ込まれた
							PRINTFORMW レイプに近い激しいセックスに%ANAME(対象)%は呻きながらもぎゅうっと彼にしがみつき全身を震わせて喘いだ
						CASE 1
							PRINTFORML ベッドに寝かされるとキスをされながらねっとりと指で全身を愛撫されてたまらず身悶える
							PRINTFORMW いつもと違う優しいセックスに%ANAME(対象)%はメロメロになり子宮を疼かせながらされるがままにヨガり狂う
						CASE 2
							PRINTFORML 犬の様な恰好をさせられバックから激しく弱点を小突かれて悦びに満ちた嬌声が響かせる
							PRINTFORMW %ANAME(対象)%は逞しいペニスで子宮まで支配されるような感覚に酔いしれながら獣の様にあさましく腰を振った
						CASE 3
							PRINTFORML 肉体の感覚が普段の数倍も鋭敏になる催眠をかけられてヒィヒィとヨガリ狂わされる
							PRINTFORMW ちんぽが出入りする度に気が狂いそうな快感に%ANAME(対象)%は必死でご主人様にしがみつきながらイキまくる
						CASE 4
							PRINTFORML いつも以上に強力な催眠をかけられた%ANAME(対象)%がご主人様に跨り狂ったように腰を振る
							PRINTFORMW 焦点の合わない視線で涎を垂らしながらチンポを求める%ANAME(対象)%の姿を彼は口端を歪めながら眺めていた
					ENDSELECT
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORML 「オラ！イけ！孕みながらイキ狂え！この雌豚が！」
							PRINTFORMW ご主人様に罵られながら大量の精液が勢いよく胎内に注がれ%ANAME(対象)%は何度も何度も絶頂した
						CASE 1
							PRINTFORML 「ふぅ…相変わらず穴だけは極上だな、このちんぽ狂いが」
							PRINTFORMW お腹がたぷたぷになるまで膣出しされた%ANAME(対象)%は幸せそうな表情でベッドに横たわっていた
						CASE 2
							PRINTFORML 「うぅ、おっ！いくぞ！く…っ！子宮開けろ！出すぞ！」
							PRINTFORMW 膣内射精を予告された%ANAME(対象)%は彼の腰に足を絡ませながらあられなく種付けをおねだりした
						CASE 3
							PRINTFORML 「おっ、イイぞ、すっかり舌の扱いも上手くなったな」
							PRINTFORMW 一回戦が終わりお掃除フェラをする%ANAME(対象)%は波打つペニスに次を期待して胸を昂らせた
						CASE 4
							PRINTFORML 「あー、出した出した…こんだけ好き放題できる穴は便利でいいな」
							PRINTFORMW 事後、強烈な絶頂の余韻で%ANAME(対象)%は腰砕けになり精液を溢れさせながら無様に横たわっていた
					ENDSELECT
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORMW %ANAME(対象)%はご主人様と一緒にシャワーを浴びて帰った
						CASE 1
							PRINTFORMW %ANAME(対象)%は下着を没収されてノーパンのまま帰宅させられた
						CASE 2
							PRINTFORMW たっぷり愛された%ANAME(対象)%は夢見心地のまま帰路についた
						CASE 3
							PRINTFORMW その日のご主人様は激しく、結局家には帰れなかった
						CASE 4
							PRINTFORMW %ANAME(対象)%はご主人様と濃厚なキスを交わして別れた
					ENDSELECT
					CALL FUCK(対象, "欲望, 欲望, 奉仕, 奉仕, 精愛, 性技, 性交, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, キス, 口淫, Ｖ性交, Ａ性交", "処女喪失, 膣内射精, 口内射精, Ａ処女喪失, 腸内射精, CFLAG減少", GET_SPERM_ID("催眠術師"), @"催眠術師の\@RAND:2 ? ペニス # 唇\@", @"", "催眠術師", "催眠中の強姦")
				CASE 1
					PRINTFORMW %ANAME(対象)%はご主人様の命令で繁華街にて男を漁っている
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORML 適当な男を探していると、見るからに下心丸出しのチンピラに話しかけられた
							PRINTFORML 頭が緩い女と思われたらしく気安く腰に手を回してくる彼の誘いに%ANAME(対象)%はあえて乗る事にした
							PRINTFORMW %ANAME(対象)%は彼の腕に絡みつき胸を押し付けながら一緒にホテルに向かった
						CASE 1
							PRINTFORML 男を探してよそ見をしているとヤクザ風の男にぶつかってしまった
							PRINTFORML 怒鳴りつけてきた彼に謝罪する%ANAME(対象)%に対し彼はニヤリと口端を上げると弁償を求めてきた
							PRINTFORMW その意図を察して頷くと彼は下卑た笑みを浮かべて%ANAME(対象)%をホテルに連れ込んだ
						CASE 2
							PRINTFORML 人混みの中でいきなりお尻を揉みしだかれ%ANAME(対象)%は小さく悲鳴を上げた
							PRINTFORML 構わずお尻を撫でつけて来る痴漢に対し%ANAME(対象)%は舌なめずりをしてその手を恥部へと導いた
							PRINTFORMW その反応に痴漢は驚きつつも愛撫を続行し、どちらともなくホテルへと向かった
						CASE 3
							PRINTFORML 好みの男が見つからずに暇をしていると老紳士に話しかけられた
							PRINTFORML 刺激的な関係を求めていた%ANAME(対象)%には不満だったが仕方ないので適当に付き合う事にした
							PRINTFORMW しかし彼の巧みな話術にすっかりほだされた%ANAME(対象)%はホテルに誘われると嬉しそうに頷いた
						CASE 4
							PRINTFORML 街中では珍しい事に妖怪を見かけた%ANAME(対象)%は試しに話しかけてみた
							PRINTFORML 話をしていると彼の視線が胸や女性器に集中しているの察した%ANAME(対象)%はホテルに誘ってみた
							PRINTFORMW 彼は肉欲丸出しの返事をすると%ANAME(対象)%の腕を強引に引いてホテルへ向かった
					ENDSELECT
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORML 部屋に入るなり男に押し倒されペニスをねじ込まれて激しく犯された
							PRINTFORMW その雄々しいピストンで問答無用に雌に目覚めさせられた%ANAME(対象)%はあられもなく身悶えた
						CASE 1
							PRINTFORML 彼の男根は想像以上に逞しく、挿入されるだけで軽くイってしまった
							PRINTFORMW 数回のピストンですっかり雌穴はペニスに屈服させられ、%ANAME(対象)%はヒィヒィとヨガリ狂った
						CASE 2
							PRINTFORML %ANAME(対象)%達の身体の相性は抜群に良く、互いに夢中になって交わっている
							PRINTFORMW 舌を絡ませながら腰を打ち付けられる度に視界で火花が散り%ANAME(対象)%は雌の悦びに嬌声を上げた
						CASE 3
							PRINTFORML 時間を忘れて楽しんだ%ANAME(対象)%達は汗だくの身体をシャワーで流している
							PRINTFORML 洗いっこをしていると彼の一物が再び元気になるのを見た%ANAME(対象)%は頬を染めて壁に手を突いた
							PRINTFORMW すぐに浴場からシャワーの音に交じって%ANAME(対象)%のあられもない嬌声が響いてきた
						CASE 4
							PRINTFORML %ANAME(対象)%はだらしない表情を晒しながら男に跨り激しく腰を振っている
							PRINTFORML 彼のテクですっかり理性を溶かされた%ANAME(対象)%は狂ったようにチンポを求めて身をくねらせる
							PRINTFORMW 何度もザーメンを放たれながらその度に強烈な快楽で気が飛びそうな絶頂を味わった
					ENDSELECT
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORMW 男はベッドで横たわる%ANAME(対象)%を置いてさっさと帰っていった
						CASE 1
							PRINTFORMW たっぷりと楽しんだ後、%ANAME(対象)%達は連絡先を交換して別れた
						CASE 2
							PRINTFORMW 別れ際、男に下腹部を撫でられた%ANAME(対象)%は甘い吐息を漏らした
						CASE 3
							PRINTFORMW 男は勝手に%ANAME(対象)%のあられもない姿をハメ撮りしていった
						CASE 4
							PRINTFORMW %ANAME(対象)%達は身体を洗う為にお風呂でイチャイチャしてから別れた
					ENDSELECT
					CALL FUCK(対象, "欲望, 欲望, 奉仕, 奉仕, 精愛, 性技, 性交, Ｃ, Ｖ, Ｂ, Ｍ, Ａ, キス, 口淫, Ｖ性交, Ａ性交", "処女喪失, 膣内射精, 口内射精, Ａ処女喪失, 腸内射精, CFLAG減少", GET_SPERM_ID("行きずりの男"), @"行きずりの男の\@RAND:2 ? ペニス # 唇\@", @"", "行きずりの男", "強姦")
				CASE 2
					PRINTFORMW %ANAME(対象)%は無警戒に妖怪の縄張りをうろついている
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORML 武器も持たない%ANAME(対象)%を野良妖怪が見逃すはずもなくすぐに捕まってしまった
							PRINTFORMW %ANAME(対象)%は抵抗のポーズを見せつつも何をされるのか期待しつつねぐらへと連れて行かれた
						CASE 1
							PRINTFORML 歩き疲れた%ANAME(対象)%が洞窟で一休みしているとそこの主である牛鬼に見つかった
							PRINTFORMW 逃げるにはすでに遅すぎ、侵入者である%ANAME(対象)%は容赦なく押し倒され乱暴に服を剥かれた
						CASE 2
							PRINTFORML すると巨躯の鬼が立ちふさがり、%ANAME(対象)%に殺されるか従うか選べと脅してきた
							PRINTFORMW %ANAME(対象)%は従えばどうなってしまうのかと想像しキュンと下腹部を疼かせながら小さく頷いた
						CASE 3
							PRINTFORML 当然すぐに妖怪に見つかった%ANAME(対象)%は抵抗も空しく捕まって犯されてしまった
							PRINTFORMW 彼は%ANAME(対象)%のハメ心地を気に入った様で、ヒョイと担ぎ上げるとねぐらへと拉致していった
						CASE 4
							PRINTFORML 山道を歩いていると突然突風が吹き%ANAME(対象)%の身体がふわりと宙に浮いた
							PRINTFORML 無重力状態に慌てて辺りを見回すとなんと天狗に拉致されていた
							PRINTFORMW %ANAME(対象)%は一体この後どうなるのかと恐怖と期待で昂りながら彼のねぐらへと運ばれた
					ENDSELECT
					PRINTFORML 
					SELECTCASE RAND:5
						CASE 0
							PRINTFORML 妖怪のねぐらに連れ込まれた%ANAME(対象)%は昼夜を問わず休む事無く犯され続けた
							PRINTFORMW そのあまりにも暴力的なセックスに耐えきれるはずもなく、狂ったようにイかされまくった
						CASE 1
							PRINTFORML 妖怪に気に入られ花嫁認定された%ANAME(対象)%はそれから連日連夜犯されまくっている
							PRINTFORML 圧倒的なスタミナで毎回足腰立たなくなるまで犯される為逃げる事も出来ずされるがままだ
							PRINTFORMW しかしその表情に苦痛や恐怖はなく至上の幸福を受け入れる雌のモノになっていた
						CASE 2
							PRINTFORML %ANAME(対象)%は殺されない為にねぐらの主の従順な雌奴隷となって奉仕している
							PRINTFORML 巨大なペニスにも慣れ、雌穴をみっちり広げて根元まで咥え込み命ぜられるままに腰を振る
```
