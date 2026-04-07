# SYSTEM/EVENT_DAILY/各イベント群/DANMAKU_弾幕ごっこ.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/DANMAKU_弾幕ごっこ.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DANMAKU_RATE, EVENT_DAILY_DANMAKU_DECISION, EVENT_DAILY_DANMAKU_GENRE, EVENT_DAILY_DANMAKU_SETTARGET, EVENT_DAILY_DANMAKU, EVENT_DAILY_DANMAKU_ALLOW_WHEN_WANDERING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_DANMAKU_RATE()
RETURN 30

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_DANMAKU_DECISION()
RETURN DAY >= 5

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_DANMAKU_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_DANMAKU_SETTARGET()

;あなたが女でありふたなりではない
SIF IS_FEMALE(MASTER) && !HAS_PENIS(MASTER)
	RETURN 1

;遭遇キャラの選出
FOR LOCAL, 0, CHARANUM
	;別の勢力に所属している、女性キャラ
	IF CFLAG:(LOCAL):所属 != CFLAG:MASTER:所属 && (IS_COUNTRY(CFLAG:LOCAL:1) || CFLAG:LOCAL:特殊状態 == 特殊状態_放浪) && !CFLAG:(LOCAL):捕虜先 && IS_FEMALE(LOCAL) && !IS_ANIMAL(LOCAL)
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
@EVENT_DAILY_DANMAKU()
#DIM 対象
#DIM 該当能力
#DIM 対象該当能力
#DIM 難易度
#DIM 金額

;弾幕ごっこの該当能力決定、武闘と知略の高いに決定、同値なら武闘で
IF ABL:MASTER:知略 > ABL:MASTER:武闘
	該当能力 = ABL:MASTER:知略
ELSE
	該当能力 = ABL:MASTER:武闘
ENDIF

;あなたが男の場合。もしくはふたなりの場合50%の確率で
IF IS_MALE(MASTER) || (HAS_PENIS(MASTER) && RAND:2)
	対象 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)
	IF ABL:対象:知略 > ABL:対象:武闘
		対象該当能力 =  ABL:対象:知略
	ELSE
		対象該当能力 = ABL:対象:武闘
	ENDIF
	
	PRINTFORML たまたま遭遇した%ANAME(対象)%から弾幕ごっこを挑まれた
	PRINTFORML 背を向けるわけにもいかない、受けて立つ事にした
	PRINTFORML 身構えると、彼女は距離を取りながら弾幕をばら撒いてきた
	PRINTFORMW どうしよう？
	CALL ASK_MULTI("集中する" , "服を狙う", "逃げる")
	IF RESULT == 2
		PRINTFORML 相手していられない
		PRINTFORML 逃げることにした
		RETURN 1
	ELSEIF RESULT == 1
		PRINTFORML 空を舞う彼女の肢体はとても美しく、見ているだけでムラムラしてきた
		PRINTFORML どうせならもっと扇情的にしてやろう
		PRINTFORMW %ANAME(MASTER)%は気合を入れて彼女の服が破けるように重点的に狙った
		難易度 = 1
	ELSE
		PRINTFORML 本気でかからないと危ない相手だ
		PRINTFORMW 弾幕を避けるのに集中した
		難易度 = 0
	ENDIF
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
	IF  該当能力 / 10 >= (対象該当能力 / 10) + RAND:3 + 難易度
		IF 難易度 == 1
			PRINTFORML 勝った！
			PRINTFORML 狙い通り彼女の服は%ANAME(MASTER)%の弾幕でボロボロになった
			PRINTFORML 彼女は地面に座り込み、顔を真っ赤にして両手で柔肌を隠そうとしている
			PRINTFORMW どうしよう？
			CALL ASK_MULTI("お金" , "お酒" , "フェラチオ" , "公開オナニー" , "何もしない")
			IF RESULT == 4
				PRINTFORML 良い勝負だったと彼女に手を差し伸べた
				PRINTFORML 彼女は拍子抜けした様子になりながらも、%ANAME(MASTER)%の手を取った
				PRINTFORMW しかし直ぐに我に返ると、露わになった肌を隠す様にそそくさと走り去った
				CFLAG:対象:好感度 += 300
				CALL COLOR_PRINT(@"%ANAME(対象)%の評価が上がった", カラー_注意)
				PRINTFORMW
			ELSEIF RESULT == 0
				PRINTFORML 褒賞として金品を要求した
				PRINTFORML 彼女は仕方ないと言った風に肩をすくめ、大人しくお金を差し出してきた
				PRINTFORMW 次は負けないわよとリベンジ宣言をすると、露わになった肌を隠す様にそそくさと走り去った
				金額 = 1000 + 500 * RAND:6 + 1
				MONEY += 金額
				CALL COLOR_PRINT(@"金{金額}を手に入れた", カラー_注意)
				PRINTFORML
				CFLAG:対象:好感度 += 200
				CALL COLOR_PRINT(@"%ANAME(対象)%の評価が上がった", カラー_注意)
				PRINTFORMW 
			ELSEIF RESULT == 1
				PRINTFORML 褒賞としてお酒を要求した
				LOCAL = RAND:3 + 1
				PRINTFORML 彼女は仕方ないと言った風に肩をすくめ、清酒を差し出してきた
				PRINTFORMW 次は負けないわよとリベンジ宣言をすると、露わになった肌を隠す様にそそくさと走り去った
				ITEM:清酒 += LOCAL
				CALL COLOR_PRINT(@"清酒を{LOCAL}個手に入れた", カラー_注意)
				PRINTFORML
				CFLAG:対象:好感度 += 200
				CALL COLOR_PRINT(@"%ANAME(対象)%の評価が上がった", カラー_注意)
				PRINTFORMW 
			ELSEIF RESULT == 2
				PRINTFORML ムラッと来た%ANAME(MASTER)%は彼女にフェラチオを要求した
				IF ABL:対象:性知識 == 0
					PRINTFORML しかし%ANAME(対象)%はきょとんとしており何のことかわかっていない
					PRINTFORML %ANAME(MASTER)%は彼女を物陰に連れ込むと、目の前にペニスを露出した
					PRINTFORML %ANAME(対象)%はぎょっとしていたが、初めて見るであろうそれに釘付けになっている
					PRINTFORMW %ANAME(MASTER)%がやり方を説明して催促すると、彼女はおずおずと手を伸ばした
					PRINTFORML 
					PRINTFORML 彼女の指と舌がゆっくりと%ANAME(MASTER)%のペニスをなぞる
					PRINTFORML その拙いながらも初々しい表情と仕草に興奮が高まり、ペニスがはちきれんばかりになる
					PRINTFORML 我慢出来なくなり%ANAME(対象)%に咥えこませると、喉奥めがけて思い切り精を放った
					PRINTFORMW 彼女は顔を震わせ逃れようとするが、ガッチリと顔を掴んで射精を続ける
					PRINTFORML 呻き声を上げながら溺れない様に精液を飲み込んでいく喉の動きが更に心地よくペニスを刺激した
					PRINTFORML 射精を終え解放してやると、%ANAME(対象)%はゲホゲホと餌付いて口内に残った精液を吐き出した
					PRINTFORML 乱暴にしてしまったことを謝ると、彼女は涙目で頬を膨らませながら睨みつけてきた
					PRINTFORMW お詫びに今度甘味を奢る事を約束すると、%ANAME(対象)%は何とか機嫌を直してくれた
					CALL PRINT_ADD_EXP(対象, "性知識経験値", 100)
				ELSE
					PRINTFORML %ANAME(MASTER)%の要求に対し%ANAME(対象)%は顔を引き攣らせた
					PRINTFORML %ANAME(MASTER)%は硬直する彼女を物陰へ連れ込み、ペニスを露出する
					PRINTFORMW しばし顔を真っ赤にしていた%ANAME(対象)%だが、やがて観念したのかおずおずと手を伸ばした
					PRINTFORML 
					PRINTFORML 彼女の指と舌がゆっくりと%ANAME(MASTER)%のペニスをなぞる
					IF ABL:対象:奉仕 >= 3
						PRINTFORML その巧みな奉仕により、ペニスはすぐに限界近くまではち切れてしまう
					ELSE
						PRINTFORML その熱心な奉仕により、思わずうめき声が漏れてペニスが跳ねてしまう
					ENDIF
					PRINTFORML 我慢出来なくなり%ANAME(対象)%に咥えこませると、喉奥めがけて思い切り精を放った
					PRINTFORMW 彼女は顔を震わせ逃れようとするが、ガッチリと顔を掴んで射精を続ける
					PRINTFORML 呻き声を上げながら溺れない様に精液を飲み込んでいく喉の動きが更にペニスを刺激した
					PRINTFORML 射精を終え解放してやると、%ANAME(対象)%はゲホゲホと餌付いて口内に残った精液を吐き出した
					PRINTFORML 乱暴にしてしまったことを謝ると、彼女は涙目で頬を膨らませながら睨みつけてきた
					PRINTFORMW お詫びに今度甘味を奢る事を約束すると、%ANAME(対象)%は何とか機嫌を直してくれた
				ENDIF
				SETCOLOR カラー_オレンジ
				CALL PRINT_ADD_EXP(対象, "奉仕経験値", 10)
				CALL PRINT_ADD_EXP(対象, "性技経験値", 10)
				RESETCOLOR
			ELSE
				PRINTFORML %ANAME(MASTER)%はニヤニヤ笑いながら彼女に公開オナニーを要求した
				IF ABL:対象:性知識 == 0
					PRINTFORML しかし%ANAME(対象)%は何のことかわからずきょとんとしている
					PRINTFORML %ANAME(MASTER)%は彼女を物陰に連れ込むと、オナニーについて説明した
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の話を聞きながら次第に顔を真っ赤に染めていった
					PRINTFORMW もじもじしている彼女に促すと、ゆっくりと股を開き、おずおずと秘所に指を伸ばした
					PRINTFORML 
					PRINTFORML 彼女はぎこちなく秘所に指を這わせている
					PRINTFORML %ANAME(MASTER)%に促されるままに指を動かしているが、まだ快楽よりくすぐったさの方が勝っているらしい
					PRINTFORML そんな彼女の気分を昂ぶらせるべく、%ANAME(MASTER)%は背後から耳元で自身のいやらしい姿を実況してやる
					PRINTFORMW すると彼女はゾクゾクと背を震わせだし指の動きを早め、次第に甘い吐息を漏らし始めた
					PRINTFORML 快楽を自覚したのか、%ANAME(MASTER)%が実況をやめても彼女は夢中でクリトリスや乳首に指を弄り続ける
					PRINTFORML やがて色っぽい喘ぎ声を上げ、身をくねらせながらぶるぶるっと身体を震わせて絶頂に達した
					PRINTFORML 初めてであろう絶頂に彼女は大きく嬌声を上げ、しばし痙攣しながらその余韻に浸っていた
					PRINTFORMW 良いものを見せてもらったと礼を言うと、%ANAME(対象)%は耳まで真っ赤にしてそそくさと走り去った
				ELSE
					PRINTFORML %ANAME(MASTER)%の要求に対し%ANAME(対象)%は顔を引き攣らせた
					PRINTFORML %ANAME(MASTER)%は硬直する彼女を物陰へ連れ込み、再度要求した
					PRINTFORMW しばし顔を真っ赤にしていた%ANAME(対象)%だが、やがて観念したのかおずおずと股を開いた
					PRINTFORML 
					PRINTFORML 彼女はぎこちなく秘所に指を這わせている
					PRINTFORML %ANAME(MASTER)%に見られているからか、中々快楽にのめり込めていないらしい
					PRINTFORML そんな彼女の気分を昂ぶらせるべく、%ANAME(MASTER)%は背後から耳元で自身のいやらしい姿を実況してやる
					PRINTFORMW すると彼女はゾクゾクと背を震わせだし指の動きを早め、次第に甘い吐息を漏らし始めた
					PRINTFORML 快楽に没頭し出した彼女は、%ANAME(MASTER)%が実況をやめても夢中でクリトリスや乳首に指を弄り続ける
					PRINTFORML やがて色っぽい喘ぎ声を上げ、身をくねらせながらぶるぶるっと身体を震わせて絶頂に達した
					PRINTFORML %ANAME(MASTER)%に見られているのも忘れたかのように彼女は絶頂の余韻でだらしない表情を晒している
					PRINTFORMW 良いものを見せてもらったと礼を言うと、%ANAME(対象)%は我に返り耳まで真っ赤にしてそそくさと走り去った
```
