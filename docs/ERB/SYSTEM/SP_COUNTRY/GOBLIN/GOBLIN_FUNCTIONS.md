# SYSTEM/SP_COUNTRY/GOBLIN/GOBLIN_FUNCTIONS.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/GOBLIN/GOBLIN_FUNCTIONS.ERB`

类型: .ERB

自动摘要: functions: TURNEND_GOBLIN, GOBLIN_DESTROY_MSG, GOBLIN_INIT, START_TRAIN_COMMON_GOBLIN, SELECT_CHARA_RANDOM_LOGIC_GOBLIN_SPECIAL_REQRUITMENT, GOBLIN_SPECIAL_REQRUITMENT, MASTER_CAPTURED_GOBLIN, GOBLIN_ENDING; UI/print

前 200 行源码片段:

```text
﻿;--------------------------------------
;ターンエンド時のホフゴブリンの処理
;--------------------------------------
@TURNEND_GOBLIN
#DIM ホフゴブリン
ホフゴブリン = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_ホフゴブリン)

;兵力の増える処理
IF DAY % 3 == 0
	CALL SINGLE_DRAWLINE
	LOCAL:0 = MAX(RAND:3000, 1000)
	LOCAL:0 += RAND:500 * SP_COUNTRY_RANK:(特殊勢力_ホフゴブリン)
	PRINTFORML ホフゴブリンにつけばおこぼれにあずかれると聞いた野良妖怪たちが、次々と寝返っているようです……
	PRINTFORML ホフゴブリンの兵力が{LOCAL:0}増加した
	COUNTRY_SOLDIER:ホフゴブリン += LOCAL:0
ENDIF
;4ターンに1回、特別な徴兵
CALL GOBLIN_SPECIAL_REQRUITMENT(DAY % 4 == 0)

;--------------------------------------
;滅亡時の処理
;--------------------------------------
@GOBLIN_DESTROY_MSG
CALL SINGLE_DRAWLINE
SETCOLOR カラー_注意
PRINTFORML
PRINTFORML
PRINTFORML
PRINTFORMW 壊滅的な被害を受けたホフゴブリンは、ちりぢりに四散していきました
PRINTFORMW 八雲紫が「めっ☆（滅っ）」したようなので、しばらくは大人しくしていることでしょう……
PRINTFORML
PRINTFORML
PRINTFORML
RESETCOLOR

;--------------------------------------
;ホフゴブリンの初期化処理
;--------------------------------------
@GOBLIN_INIT(ARG:0)
#DIM LCOUNT
VARSET LOCAL

SIF GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_ホフゴブリン) != -1
	RETURN 0

SIF SP_COUNTRY_RANK:特殊勢力_ホフゴブリン == 0
	RETURN 0

SIF GET_NEW_COUNTRY() == -1
	RETURN 0

CALL CREATE_SP_COUNTRY(特殊勢力_ホフゴブリン)
LOCAL = RESULT
CALL INIT_SP_COUNTRY(LOCAL)

RETURN LOCAL

;-------------------------------------------------
;DESC  :ホフゴブリン所属時に閨・捕虜調教前にアイテムを追加する処理
;-------------------------------------------------
@START_TRAIN_COMMON_GOBLIN()
ITEM:A_バイブ = 1
ITEM:A_アナルバイブ = 1
ITEM:A_縄 = 1
ITEM:A_目隠し = 1
ITEM:A_口枷 = 1
ITEM:A_鼻フック = 1
ITEM:A_媚薬 = 99
ITEM:A_排卵誘発剤 = 99
ITEM:A_絶倫丸 = 99


@SELECT_CHARA_RANDOM_LOGIC_GOBLIN_SPECIAL_REQRUITMENT(対象)
#DIM 対象
#DIM ゴブリン

ゴブリン = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_ホフゴブリン))

;ゴブリン所属で、捕虜でなく、陥落済み
RETURN CFLAG:対象:所属 == ゴブリン && !CFLAG:対象:捕虜先 && IS_FEMALE(対象) && GETBIT(TALENT:対象:特殊勢力陥落系, 特殊勢力_ホフゴブリン)

;--------------------------------------
;ホフゴブリンの定期イベント。
;陥落済みキャラを使って兵数を増やす
;--------------------------------------
@GOBLIN_SPECIAL_REQRUITMENT(条件 = 1)
#DIM ゴブリン
#DIM 条件
#DIM 対象
#DIM メッセージ

ゴブリン = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_ホフゴブリン))

;ゴブリン勢力があり、条件を満たしている
SIF ゴブリン == -1 || !条件
	RETURN -1

CALL SELECT_CHARA_RANDOM("GOBLIN_SPECIAL_REQRUITMENT")

対象 = RESULT

SIF 対象 == -1
	RETURN 0


CALL SINGLE_DRAWLINE
SETCOLOR カラー_ピンク
PRINTFORML ホフゴブリンは%ANAME(対象)%を、兵士の募集活動に駆り出したようだ……
PRINTFORML 
メッセージ = RAND:4
SELECTCASE メッセージ
	CASE 0
		PRINTFORMW 彼らは近くの人里に繰り出した
		PRINTFORML %ANAME(対象)%は彼らの一歩後ろを歩き、付き従っている
		PRINTFORML ぱっと見は普段の彼女であり、いたって普通だった
		PRINTFORMW ……その足取りは、%ANAME(対象)%にしては珍しいほどふらついていたが
		PRINTFORML 彼らは里の中心、広場まで来ると、そこで里の男達をかき集めた
		PRINTFORML 何事かと思った野次馬が人妖問わず集まり、広場はあっという間に埋まる
		PRINTFORMW そこでホフゴブリンは、全員によく聞こえるよう、大声でスピーチを始めた
		PRINTFORMW 俺たちに参加すればものすごくいいことがある。それを今日は見せてやる……
		PRINTFORML ホフゴブリンが%ANAME(対象)%に目配せすると、彼女はおもむろに服を脱ぎ捨てた
		PRINTFORML 突如として露わになる美しい肢体に、皆の目は釘付けになる
		PRINTFORMW \@ TATTOO:(対象):タトゥー_秘部 != "" ? その下腹には「%TATTOO:対象:タトゥー_秘部%」のタトゥーが刻まれ、 # \@両穴には太いバイブがねじ込まれていた
		PRINTFORML この女は俺たちの奴隷だ。今日はコイツを連れてきたが、他にも女はいくらでもいる……
		PRINTFORML %ANAME(対象)%に己の肉棒をしゃぶらせながら、ホフゴブリンたちは勧誘の言葉を並べたてる
		PRINTFORMW やがてホフゴブリンは射精し、%ANAME(対象)%の顔にぶちまけると、%ANAME(対象)%を抱え、群衆の中に放り投げる
		PRINTFORMW この女はサービスだ。好きにしていいぞ
		PRINTFORMW ホフゴブリンがそう言うと、男達は目の色を変え、%ANAME(対象)%に群がった……
	CASE 1
		CALL SET_PIERCE_RANDOM(対象, 0)
		SIF RESULT == -1
			RESULT = ピアス_乳首
		PRINTFORMW 彼らは近くの人里に繰り出した
		PRINTFORML %ANAME(対象)%はリードつきの首輪を嵌められ、里の目抜き通りを歩かされている
		PRINTFORML 口にはギャグボールを嵌められ、羽織っているのは肝心なところをまるで隠さない奴隷用ボンデージ
		PRINTFORML 全身にはあちこちに卑猥な落書きが施されている。さらに、%GET_PIERCE_NAME(RESULT)%に痛々しいピアスが取り付けられている
		PRINTFORMW 拠点を出る前に何度も「使われて」おり、全身べっとりと白いものにまみれている。特にその両穴は、でろでろと白濁を垂れ流す
		PRINTFORML 腕には頑丈な枷が嵌められており、抵抗などできるはずもなかった
		PRINTFORMW もっとも、ホフゴブリン"様"たちの忠実なしもべである%ANAME(対象)%に、そんな大それた考えはあるまいが……
		PRINTFORML 里の男達は、練り歩く彼らをじっと眺めている
		PRINTFORMW 正しくは、%ANAME(対象)%の淫らな姿を
		PRINTFORMW ホフゴブリンはニヤニヤと笑いながら言う
		PRINTFORML 俺たちの奴隷がそんなに気になるか、俺たちに参加すればコイツ以外にもヤり放題だ
		PRINTFORMW 特別に今回は、お前らにコイツを好きにさせてやるよ……
		PRINTFORMW ホフゴブリンがそう言うと、男達は目の色を変え、%ANAME(対象)%に群がった……
	CASE 2
		PRINTFORMW 彼らは%ANAME(対象)%を、他の奴隷と一緒に肉便器として提供した
		PRINTFORMW 彼女らは屋外に設けられた「特設便所」にて、壁尻の状態で備え付けられた
		PRINTFORML 人妖問わず、さまざまな男達が訪れては、%ANAME(対象)%の両穴を使っていく
		PRINTFORML 自らモノを扱いてちり紙に射精するときの気軽さで、簡単に膣内射精していく
		PRINTFORMW 使い捨てられる被虐と快楽に、%ANAME(対象)%は何度も激しく絶頂する……
		PRINTFORMW やがてコトが終わるころには、%ANAME(対象)%の%STR_BODY("尻", 対象)%には両手に余る正の字が書き込まれていた
		PRINTFORML 彼女の穴は大変評判がよかったらしい
		PRINTFORMW %ANAME(対象)%はその「褒美」として、ホフゴブリン"様"たちのモノをたっぷりとしゃぶらせてもらった……
	CASE 3
		PRINTFORMW 彼らは%ANAME(対象)%を、他の奴隷と一緒に肉便器として提供した
		PRINTFORML 彼女らは屋外に設けられた「特設便所」にて、グローリーホールをしたようだ
		PRINTFORMW 人妖問わず、さまざまな男達が訪れては、壁越しにペニスを突き出してくる
		PRINTFORML 太いもの、細いもの、逞しいものから恥垢を溜めたもの
		PRINTFORML それら全てを、%ANAME(対象)%は顔を蕩かし、股を濡らしながら舐めしゃぶっていく
		PRINTFORMW 官能の炎は%ANAME(対象)%の中で激しく燃え上がり、彼女は仕事中に何度も自慰をし、絶頂した
		PRINTFORMW やがてコトが終わるころには、何度も白濁を受けた上半身に、白く汚れていないところはないほどになっていた
		PRINTFORML 彼女の口技は大変評判がよかったらしい
		PRINTFORMW %ANAME(対象)%はその「褒美」として、疼く身体をホフゴブリン"様"たちにたっぷりと使っていただいた……
ENDSELECT

PRINTFORML
SETCOLOR カラー_注意
LOCAL:0 = MAX(RAND:3000, 1000)
PRINTFORML キャンペーンは好評だったようだ……
PRINTFORMW ホフゴブリンの兵力が{LOCAL:0}増加した
RESETCOLOR
COUNTRY_SOLDIER:(ゴブリン) += LOCAL:0

;-----------------------------
;ホフゴブリンに捕らえられたときのイベント
;-----------------------------
@MASTER_CAPTURED_GOBLIN(ARG:0)
PRINTFORMW 捕らえられた%ANAME(MASTER)%はホフゴブリンの前に引きずり出された…
IF IS_MALE(MASTER)
	PRINTFORMW ホフゴブリンは%ANAME(MASTER)%を見ると、男なんて要らねぇのになと呟いた
	PRINTFORMW 俺達の側につくなら、イイ思いをさせてやるぜ？　と言った
	PRINTFORMW 奴隷という扱いにはなるようだが、拒否するより待遇はマシになるようだ……
	PRINTFORMW 受け入れますか？
	CALL ASK_YN("受け入れる", "拒否する")
	IF RESULT == 0
		PRINTFORMW 投獄されるよりはマシだろう。%ANAME(MASTER)%が頷くと、ホフゴブリンはゲタゲタと笑う
		PRINTFORMW 何を笑っているのかといぶかる%ANAME(MASTER)%に、奴隷としての証をつけてやるよと彼らは言い出した
		PRINTFORMW 用意された焼きごては、あろうことか、%ANAME(MASTER)%のペニスに押し当てられた……
		SETCOLOR カラー_注意
		PRINTFORMW %ANAME(MASTER)%はホフゴブリンの性奴隷となりました
		RESETCOLOR
	ELSE
		PRINTFORMW お前達になど手を貸すか。%ANAME(MASTER)%は毅然として言い放つ	
		PRINTFORMW そうかよと、彼らはそのまま興味なさげに、%ANAME(MASTER)%を投獄した……
	ENDIF
ELSEIF GETBIT(TALENT:MASTER:特殊勢力陥落系, 特殊勢力_ホフゴブリン)
	PRINTFORMW 懲りずに俺達の前に来たのかよと、彼らは%ANAME(MASTER)%の身体に手を這わせながらささやく
	PRINTFORMW それだけで%ANAME(MASTER)%の身体は、彼らに刻み込まれた快楽を思い出して濡れてしまう
	PRINTFORMW %ANAME(MASTER)%の声が甘く蕩け始めた頃、また俺達のところに来るか？　と彼らは尋ねる
```
