# SYSTEM/EVENT_DAILY/各イベント群/FRIEND_H_DAY_ある日の出来事.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/FRIEND_H_DAY_ある日の出来事.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_FRIEND_H_DAY_RATE, EVENT_DAILY_FRIEND_H_DAY_DECISION, EVENT_DAILY_FRIEND_H_DAY_GENRE, EVENT_DAILY_FRIEND_H_DAY_SETTARGET, EVENT_DAILY_FRIEND_H_DAY; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_FRIEND_H_DAY_RATE()
RETURN 40

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_FRIEND_H_DAY_DECISION()
SIF !(IS_MALE(MASTER) && TALENT:MASTER:童貞 == 0)
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_FRIEND_H_DAY_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_FRIEND_H_DAY_SETTARGET()

;同じ国に所属している妊娠中でも捕虜でもない女キャラ、対象がいない場合はイベントキャンセル
FOR LOCAL, 0, CHARANUM
	IF CFLAG:(LOCAL):所属 == CFLAG:MASTER:所属 && TALENT:LOCAL:妊娠 == 0 && !CFLAG:(LOCAL):捕虜先 && IS_FEMALE(LOCAL) && !IS_ANIMAL(LOCAL)
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL 
		DAILY_TARGET_NUM ++
	ENDIF
NEXT

SIF DAILY_TARGET_NUM == 0
	RETURN 0

RETURN 1

;---------------------
;本体
;---------------------
@EVENT_DAILY_FRIEND_H_DAY
#DIM 対象
#DIM 兵数

LOCAL = 0

対象 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)

CFLAG:対象:面識 = 1
SELECTCASE RAND:8
	;軍事広報
	CASE 0
		PRINTFORML 軍事広報の為のポスターの写真を撮る仕事を任された
		PRINTFORML 自分がモデルになるわけにもいかず、どうしようかと悩んでいると%ANAME(対象)%と出会った
		PRINTFORMW 閃いた%ANAME(MASTER)%がモデルになってくれと頼んだら少し悩んだものの引き受けてくれた
		PRINTFORML 
		PRINTFORML 撮影は順調に進んだ
		PRINTFORMW 彼女は水着姿での撮影に最初は戸惑っていたが、徐々に慣れてくれた様だ
		PRINTFORML …いったん休憩をとる事にした
		PRINTFORML 彼女は緊張の為か微妙に頬を赤らめ全身にじんわりと汗をかいていた
		PRINTFORMW その色っぽい様子と煽情的な恰好に思わずムラッと来てしまった
		PRINTFORML どうしよう？
		CALL ASK_YN("押し倒す" ,"我慢する")
		IF RESULT == 1
			PRINTFORML いやいや何を考えているのか
			PRINTFORMW %ANAME(MASTER)%は我慢して撮影を続行した
			兵数 = MIN(1000 * (DAY / 10), 5000)
			SIF 兵数 == 0
				兵数 = 1000
			COUNTRY_SOLDIER:(CFLAG:MASTER:所属) += 兵数
			CALL COLOR_PRINTW(@"完成したポスターは好評で入隊希望者が{兵数}人増えた", カラー_注意)
		ELSEIF RESULT == 0
			PRINTFORML …構うものか
			PRINTFORMW %ANAME(MASTER)%は彼女を押し倒した
			IF CFLAG:対象:好感度 + RAND:400 >= 1700 
				PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の表情に一瞬悲鳴を上げたがそれ以上抵抗はしなかった
				PRINTFORMW その反応を確認した%ANAME(MASTER)%は彼女の唇を塞いだ
				PRINTFORMW 柔らかい唇に触れる直前、微かに甘い吐息が漏れた
				PRINTFORML 軽いキスを終わらせ改めて彼女を見つめると真っ赤になっていた
				PRINTFORMW %ANAME(MASTER)%が続きを求めると%ANAME(対象)%は小さく頷き、身体から力を抜いた
				PRINTFORML 
				PRINTFORMW %ANAME(MASTER)%は汗だくになりながら彼女と身体を重ねている
				PRINTFORML 彼女は艶めかしい喘ぎ声を上げながら%ANAME(MASTER)%にされるがままになって身をくねらせている
				PRINTFORMW 軽く肌に触れるだけで身を震わせ、腰を振る度に可愛い嬌声が響かせて%ANAME(MASTER)%の耳を溶かす
				IF TALENT:対象:処女 == 1
					PRINTFORMW 処女だった彼女は痛みに涙を流しながらも幸せそうな表情で%ANAME(MASTER)%に絡みついてくる
				ELSE
					PRINTFORMW 彼女は発情しきった様な表情で見つめてきながらしっかりと%ANAME(MASTER)%にしがみついてくる
				ENDIF
				PRINTFORML %ANAME(MASTER)%は愛おしい%ANAME(対象)%の全てを味わう様に優しく濃厚なセックスで彼女の官能を高めていく
				IF TALENT:対象:処女 == 1
					PRINTFORML こわばっていた彼女の身体も徐々にほぐれていき、その喘ぎ声にも色気が混ざってきだした
				ELSE
					PRINTFORML 彼女の身体はすっかり出来上がり、軽く小突いてやるだけでアクメに達してビクビクと震えだす
				ENDIF
				PRINTFORMW 舌を絡ませ互いの身体に腕を回して密着しながらただひたすら腰を打ち付けて快感を貪りあう
				PRINTFORML 絡みついてくる肉ひだ、脳を溶かす彼女の喘ぎに限界は直ぐに訪れ%ANAME(MASTER)%は彼女の中に一発目を放つ
				PRINTFORMW 彼女もまたそれと同時に絶頂に達し、一際甲高い嬌声を上げながら大きく身体を仰け反らせた
				PRINTFORML …強烈な絶頂を終えた%ANAME(MASTER)%達は重なる様に倒れ込み、しばらく息を整えていた
				PRINTFORML 鼻腔をくすぐる彼女の汗の匂いと柔らかい肌の感触が心地よく、二人でまどろむように余韻に浸る
				PRINTFORMW やがて再び元気になった%ANAME(MASTER)%が次を求めると彼女はキスで返答し、自ら股を開いた
				CALL FUCK(対象, "Ｃ, Ｂ, Ｖ, Ｍ, 欲望, 性交, 奉仕, 精愛, 口淫, キス, Ｖ性交", "処女喪失, キス喪失, 膣内射精", GET_ID(MASTER), @"%ANAME(MASTER)%の\@RAND:2 ? ペニス # 唇\@", ANAME(MASTER), "", "和姦")
				CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣", "和姦")
				CFLAG:対象:好感度 += 300
				PRINTFORML 
				PRINTFORML "休憩"を終えた%ANAME(MASTER)%達は撮影を再開した
				PRINTFORMW 残りの撮影では彼女は先程よりノリノリでモデルとなった
				兵数 = MIN(1000 * (DAY / 8), 10000)
				SIF 兵数 == 0
					兵数 = 1000
				COUNTRY_SOLDIER:(CFLAG:MASTER:所属) += 兵数
				CALL COLOR_PRINTW(@"完成したポスターは好評で入隊希望者が{兵数}人増えた", カラー_注意)
			ELSEIF (ABL:MASTER:武闘 / 10) * (RAND:10 + 1) > (ABL:対象:武闘 / 10) * (RAND:10 + 1)
				PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の表情に悲鳴を上げ抵抗してきた
				PRINTFORMW しかしそれを無理矢理押さえつけた%ANAME(MASTER)%は彼女の唇を塞ぐ
				PRINTFORML 呻き声を漏らし必死で逃れようとする彼女の唇を強く吸うとビクンと震えた
				PRINTFORML キスを終わらせ改めて%ANAME(対象)%を見つめると涙目で真っ赤になって睨み付けてくる
				PRINTFORMW %ANAME(MASTER)%は気にすることなく彼女を押さえつけたまま、水着を脱がした
				PRINTFORML 
				PRINTFORMW %ANAME(MASTER)%は水着姿の%ANAME(対象)%を乱暴に犯している
				PRINTFORML 彼女は悲痛なうめき声を上げながら%ANAME(MASTER)%に押さえつけられたまま犯され身悶えている
				PRINTFORMW ペニスをねじ込みながら肌に手を這わせると彼女は小さな悲鳴を上げながら身をくねらせる
				IF TALENT:対象:処女 == 1
					PRINTFORML 股からは処女だった証しが流れ、彼女は痛みに涙を流しガチガチと歯を震わせる
				ELSE
					PRINTFORML %ANAME(MASTER)%の仕打ちに彼女は涙を流してガチガチと歯を震わせながらも必死で抵抗する
				ENDIF
				PRINTFORML %ANAME(MASTER)%はそんな彼女を蹂躙する様により激しくより深く腰を打ち付けてその身体を味わい尽くす
				IF TALENT:対象:処女 == 1
					PRINTFORMW 一突き毎に%ANAME(対象)%は悲鳴を上げて身を跳ねさせ、裂かれた秘所は痙攣しながら血を流す
				ELSE
					PRINTFORMW %ANAME(対象)%の身体は彼女の思いとは裏腹に徐々にペニスに馴染みきゅうっと締め付けて来た
				ENDIF
				PRINTFORML 仲間を無理矢理犯す行為に%ANAME(MASTER)%の興奮は昂り、ギンギンに勃起したペニスでひたすら肉欲を貪る
				PRINTFORML 絡みついてくる肉ひだ、脳に響く彼女の呻きに限界は直ぐに訪れ%ANAME(MASTER)%は彼女の中に一発目を放つ
				PRINTFORMW 彼女は胎内の熱に悲鳴を上げて逃げようとするが%ANAME(MASTER)%はがっしりと押さえつけ全てを注ぎ込んだ
				PRINTFORML …%ANAME(MASTER)%は射精を終えると一つ溜息をつき、息を整える為にいったんペニスを引き抜いた
				PRINTFORML 力なく横たわる%ANAME(対象)%は、涙を流しながら犯された事実に放心したようにブツブツと何かを呟いていた
				PRINTFORMW 一度では%ANAME(MASTER)%の興奮は収まらず満足するまで繰り返し彼女を犯し続けた
				CALL FUCK(対象, "Ｃ, Ｂ, Ｖ, Ｍ, 欲望, 性交, 奉仕, 精愛, 口淫, キス, Ｖ性交", "処女喪失, キス喪失, 膣内射精", GET_ID(MASTER), @"%ANAME(MASTER)%の\@RAND:2 ? ペニス # 唇\@", ANAME(MASTER), "", "強姦")
				CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣", "強姦")
				PRINTFORML 
				PRINTFORMW 満足した%ANAME(MASTER)%は写真を手に彼女を放置してその場を後にした
				PRINTFORML …ポスターは好評だった
				PRINTFORMW 報復を警戒していたが犯された事が恥ずかしいのか彼女は何もしてこなかった
				CFLAG:対象:好感度 -= 500
			ELSE
				PRINTFORML しかし%ANAME(対象)%の抵抗は激しく、突き飛ばされてしまった
				PRINTFORMW 彼女は%ANAME(MASTER)%が怯んだ隙に逃げ去って行った…
				PRINTFORML 
				FOR LOCAL, 0, CHARANUM
					SIF CFLAG:(LOCAL):所属 == CFLAG:MASTER:所属 && !CFLAG:(LOCAL):捕虜先 && !IS_ANIMAL(LOCAL)
						CFLAG:(LOCAL):好感度 -= 300
				NEXT
				CALL COLOR_PRINTW("レイプ未遂の噂はすぐに広がり仲間からの評価は大幅に悪化した…", カラー_注意)
			ENDIF
		ENDIF
	;夢現の宿
	CASE 1
		PRINTFORMW …ここはどこだろう？
		PRINTFORML %ANAME(MASTER)%は何処か見知らぬ場所にいた
		PRINTFORML いつの間にこんなところに？頭にはもやがかかったようで思考が働かない
		PRINTFORMW まるで夢の中の様な感覚にとらわれる
		PRINTFORML 辺りを見回していると一見の宿が見えた
		PRINTFORML はて先程見た時にはこんな宿があったかな？あぁ、やっぱりこれは夢のようだ
		PRINTFORMW そう納得した%ANAME(MASTER)%は躊躇いつつも宿に入った
		PRINTFORML …宿の中に店員は誰もいなかったが客が一人いた、%ANAME(対象)%だ
		PRINTFORML 彼女も%ANAME(MASTER)%と同じ様にここに迷い込んできたらしい
		PRINTFORMW 二人で状況を分析してみたがらちが明かなかった
		PRINTFORML 仕方なく休むことにしたが空いている部屋は一つだけだった
		PRINTFORML %ANAME(MASTER)%達はダブルベッドが一つだけ部屋にいる
		PRINTFORMW なんだか妙な空気が流れ、先ほどからお互いに黙ってしまっている
		PRINTFORML どうしよう？
		CALL ASK_YN("ベッドに押し倒す" ,"大人しく休む")
		IF RESULT == 1
			PRINTFORMW 大人しく休むことにした
			PRINTFORML 
			PRINTFORML 気づくと%ANAME(MASTER)%は自室のベッドにいた
			PRINTFORML あれは夢だったのだろうか？
			PRINTFORMW しばらくもやもやしながら過ごした
		ELSEIF RESULT == 0
			PRINTFORML どうせ夢の中ならば、やってしまえ
			PRINTFORML そう思った%ANAME(MASTER)%は%ANAME(対象)%をベッドに押し倒した
			PRINTFORMW 彼女ははじめもじもじしていたが同じ様に夢の中だと思っているのか、さほど抵抗はしなかった
			PRINTFORML 
			PRINTFORMW %ANAME(MASTER)%は汗だくになってベッドに横たわっている…
			PRINTFORML その腕の中には同じく汗だくで息を荒げる%ANAME(対象)%が抱かれている
			PRINTFORML %ANAME(MASTER)%達は数時間もの間休む間もなくひたすら貪る様に身体を重ね何度も絶頂を繰り返した
			PRINTFORMW 夢の中だからなのか感覚は何時もより鋭く、%ANAME(MASTER)%も彼女も夢中になってお互いを求めた
			PRINTFORML 互いの身体に手を回し激しく舌を絡めて身体を密着させながらの濃厚なキスハメをし
			PRINTFORML 四つん這いにさせた彼女の腰を掴みながら、背後から子宮まで貫く勢いでガン突きし
			PRINTFORMW また%ANAME(MASTER)%に跨りだらしないアヘ顔を晒して腰を振る彼女を、下から強烈に突き上げた
			PRINTFORML 腰を打ち付ける度にシビレる様な快感が走り、%ANAME(MASTER)%はたまらず何度も彼女の中に精を放った
			PRINTFORMW …%ANAME(MASTER)%達は少し休んだらどちらからともなく再び交わりをはじめ、夜通し愛し合った…
			CALL FUCK(対象, "Ｃ, Ｂ, Ｖ, Ｍ, 欲望, 性交, 奉仕, 精愛, 口淫, キス, Ｖ性交", "処女喪失, キス喪失, 膣内射精", GET_ID(MASTER), @"%ANAME(MASTER)%の\@RAND:2 ? ペニス # 唇\@", ANAME(MASTER), "", "和姦")
			CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣", "和姦")
```
