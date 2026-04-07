# 口上/148 隠岐奈口上/KOJO_A_K148.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/KOJO_A_K148.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K148, KOJO_TRAIN_END_A1_K148, KOJO_TRAIN_START_A2_K148, KOJO_TRAIN_END_A2_K148, KOJO_COM_BEFORE_TARGET_A_K148, KOJO_COM_BEFORE_PLAYER_A_K148, KOJO_COM_A_K148, KOJO_COM_TARGET_A_K148, KOJO_COM_PLAYER_A_K148, KOJO_COM_AFTER_A_K148; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------
;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K148

;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;処女フラグ（処女だったらCFLAG:260を1にセット）
SIF TALENT:処女
	CFLAG:260 = 1

;処女フラグ（プレイヤー用）（処女だったらCFLAG:261を1にセット）
SIF TALENT:MASTER:処女
	CFLAG:261 = 1

;アナル処女フラグ（アナル処女だったらCFLAG:262を1にセット）
SIF TALENT:アナル処女
	CFLAG:262 = 1

;アナル処女フラグ（プレイヤー用）（アナル処女だったらCFLAG:263を1にセット）
SIF TALENT:MASTER:アナル処女
	CFLAG:263 = 1

;ファーストキスフラグ（キス未経験だったらCFLAG:264を1にセット）
SIF TALENT:キス未経験
	CFLAG:264 = 1


;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	PRINTFORML 
	;初対面の場合
	IF !CFLAG:17
		PRINTFORML 「いらっしゃい、よく来たね」
		PRINTFORML %ANAME(MASTER)%が扉を開けると、部屋の主であろう金髪の少女が悠然と椅子に腰かけていた。
		PRINTFORML 髪の色と同じ金色の目で、%ANAME(MASTER)%を見定めるかのように眺めている。
		PRINTFORMW 穏やかではあるが不穏な予感もさせる彼女を前に、%ANAME(MASTER)%は落ち着かない気持ちになった。
		PRINTFORML 
		PRINTFORML 「……ふっ、では早速だが、お互いに自己紹介でもしようか」
		PRINTFORMW そんな%ANAME(MASTER)%の胸中を察したのか、少女はうすら笑いを浮かべながら口を開いた。
		PRINTFORML 「私の名前は、摩多羅 隠岐奈」
		PRINTFORML 「究極の絶対秘神とは私のことだ」
		PRINTFORML 「そして私は、星の神であり、障碍の神であり、地母神であり…」
		PRINTFORMW 「能楽の神、被差別民の神、養蚕の神でもある」
		PRINTFORML …はたして、こんなにも多様な側面を持つ神がいるのだろうか？
		PRINTFORMW %ANAME(MASTER)%が訝しんでいると、隠岐奈は妖しげに目を細めた。
		PRINTFORML 「信じられない、というような顔をしているな？ このように多様な神格を持つ神がいるのか、と」
		PRINTFORML 「ふふふ…そう思ってくれて構わないよ。今はまだ、ね……」
		PRINTFORML 「さあ、次はお前の番だ」
		PRINTFORMW そうして隠岐奈は顎を刳り、%ANAME(MASTER)%に名乗るよう促した。
		PRINTFORML 
		PRINTFORML ……………
		PRINTFORMW %ANAME(MASTER)%が自己紹介を終えると、隠岐奈は大きく息を吐いた。
		PRINTFORML 「…なるほど、お前のことは大体分かった」
		PRINTFORMW 「それでは、共にこの厄介事を片付けていくとしようか。よろしく頼むぞ」
		PRINTFORML 言葉だけならば友好的に思えなくもない。
		PRINTFORML しかし、隠岐奈の目は%ANAME(MASTER)%を信用していないことを明確に示していた。
		PRINTFORMW この神様とうまくやっていくには、軽率な真似は避けた方が良いかもしれない…。
		PRINTFORML 
	;既に会ったことがある場合
	ELSE
		PRINTFORML 「ん？ 誰かと思えば…なんだ、%ANAME(MASTER)%か」
		PRINTFORML 「既知ではあるだろうが、隠岐奈だ」
		PRINTFORMW 「これからは共に戦うことになる。よろしく頼むぞ」
		;かなり嫌われている
		IF CFLAG:3 <= -1000
			PRINTFORML そう言う隠岐奈の声には一切の感情が籠められていない。
			PRINTFORML 顔は完全に無表情で、しかし目だけは氷のように冷たい光を放っていた。
			PRINTFORMW ……どうやら、彼女には相当嫌われているようだ。
		;嫌われている
		ELSEIF CFLAG:3 < 0
			PRINTFORML そうして%ANAME(MASTER)%に冷たい視線を投げかけながら、口の端を吊り上げる隠岐奈。
			PRINTFORMW 一切の好意もないその笑みに、思わず冷や汗が流れた。
		;好かれている
		ELSEIF CFLAG:3 >= 1000
			PRINTFORML 隠岐奈は自身の手を差しだして、%ANAME(MASTER)%に握手を求めてきた。
			PRINTFORMW %ANAME(MASTER)%もそれに応じると、彼女ははにかむように微笑んだ。
		;普通
		ELSE
			PRINTFORMW %ANAME(MASTER)%が握手を求めると、隠岐奈はとりあえずは応じてくれた。
		ENDIF
	ENDIF
;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
	PRINTFORML 
;初めて泥酔行きずりセックス
ELSEIF CFLAG:350 == 1
	PRINTFORML 「……はぁ、お前か」
	PRINTFORML %ANAME(MASTER)%を見た隠岐奈は、顔をしかめて眉間を抑えた。
	PRINTFORMW 「まあ、いい……そこに座りなさい。どうせ暇だからここに来たのだろう？」
	PRINTFORML …………。
	PRINTFORML …………………。
	PRINTFORMW 沈黙が場を包む。正直、かなり気まずい。
	PRINTFORML ………………。
	PRINTFORMW そして、ようやく隠岐奈が口を開いた。
	PRINTFORML 「………%ANAME(MASTER)%、この前のことだが…」
	PRINTFORML 「あの時は完全に酔っていたんだ……」
	PRINTFORML 隠岐奈は%ANAME(MASTER)%に目を合わせることなく呟いた。
	PRINTFORML 「だから……とりあえずあの時の事は忘れて、以降は話題にするのもなしってことで…」
	PRINTFORML 「約束だぞ？破ったら燃やすからな…」
	PRINTFORMW %ANAME(MASTER)%が神妙な顔で頷くと、隠岐奈はようやくほっとした表情を浮かべた。
	PRINTFORML
;正妻か妾
ELSEIF CFLAG:200 < 7 && TALENT:正妻 || CFLAG:200 < 7 && TALENT:妾
	CFLAG:200 = 7;婚姻した次の回フラグ
	IF TALENT:正妻
		PRINTFORML 「%ANAME(MASTER)%…！」
		PRINTFORML %ANAME(MASTER)%の姿を認めた隠岐奈は、ぱっと顔を輝かせてこちらに駆け寄ってきた。
		PRINTFORML 「"妻"の私に会いに来てくれたんだな？ ふふふっ♪」
		PRINTFORMW 言葉の一部分を強調しつつそう言うと、隠岐奈は%ANAME(MASTER)%の腰に手を回してぎゅっと抱きしめてきた。
		PRINTFORML 
		PRINTFORML 「今日は何をする？貴方と一緒なら、私は何でも付き従おう♥」
		PRINTFORMW すりすりと甘えてくる隠岐奈の頭を撫でながら、%ANAME(MASTER)%は今日の予定を考え始めた…。
	ELSE
		PRINTFORML 「%ANAME(MASTER)%…！」
		PRINTFORML %ANAME(MASTER)%の姿を認めた隠岐奈は、ぱっと顔を輝かせてこちらに駆け寄ってきた。
		PRINTFORML 「ふふふっ！ いいのか？ 正妻を置いて、私のところに来るなど…」
		PRINTFORMW からかうように笑いながら、それでも嬉しそうに隠岐奈は%ANAME(MASTER)%に抱き着く。
		PRINTFORML 
		PRINTFORML 「さて、今日は何をする？どんなことにでも付き合ってあげるよ」
		PRINTFORMW ぴったりとくっつく隠岐奈を抱き返してあげながら、%ANAME(MASTER)%は今日の予定を考え始めた…。
	ENDIF
;親愛か隷属
ELSEIF CFLAG:200 < 6 && TALENT:親愛 || CFLAG:200 < 6 && TALENT:隷属
	CFLAG:200 = 6;親愛か隷属になった次の回フラグ
	IF TALENT:親愛
		PRINTFORML 「おや、%ANAME(MASTER)%じゃないか」
		PRINTFORML 「まったく、ノックぐらいしろと言うに…」
		PRINTFORMW %ANAME(MASTER)%が部屋を訪れると、隠岐奈は苦笑しながらも歓迎してくれた。
		PRINTFORML 
		PRINTFORML 「さ、座りなさい。何か持ってくるとしよう」
		PRINTFORML %ANAME(MASTER)%がソファに座ると、隠岐奈はバックドアからお茶と菓子を取り出してテーブルに置いた。
		PRINTFORML 「%ANAME(MASTER)%が来てくれてよかったよ。さっきまで退屈で仕方がなかったんだ」
		PRINTFORMW ご機嫌な様子の隠岐奈は鼻歌交じりにお菓子をつまみ始めた…。
	ELSE
		PRINTFORMW %ANAME(MASTER)%はノックもなしに隠岐奈の部屋に入った。
		PRINTFORML 「わっ、%ANAME(MASTER)%！？」
		PRINTFORML 「びっくりしたぁ……すまない、迎えもせずに…」
		PRINTFORMW 軽く頭を下げ、隠岐奈は急ぎ足で%ANAME(MASTER)%に駆け寄る。
		PRINTFORML 
		PRINTFORML 「さ、座ってくれ。私はお茶と菓子を持ってくるよ」
		PRINTFORML %ANAME(MASTER)%がソファに座ると、隠岐奈はバックドアから緑茶と様々な和菓子の盛り合わせをテーブルに置いた。
		PRINTFORML 「貴方の口に合えば良いのだが……」
		PRINTFORMW 彼女は%ANAME(MASTER)%の顔を見つめ、そわそわと様子をうかがっている…。
	ENDIF
;既成事実Lv3(初めてセックスをした次の回)＆恋慕持ち
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	IF TALENT:恋慕
		PRINTFORML 「あ、%ANAME(MASTER)%…来てくれたのか…」
		PRINTFORML 「今日は、その………い、いや、何でもない…！」
		PRINTFORML そうして隠岐奈は赤くなった顔を隠すようにそっぽを向き、黙り込んでしまった。
		PRINTFORMW しかし彼女は何かを期待するように、時折ちらりとこちらを見やっている。
	ELSE
		PRINTFORML 「%ANAME(MASTER)%か………」
		PRINTFORML 「……何をそわそわとしている？さっさと入れ」
		PRINTFORMW 隠岐奈は不愛想な態度を貫いているが、纏う雰囲気はどこか穏やかだ。
	ENDIF
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTFORML 「%ANAME(MASTER)%……」
	PRINTFORML 「恋人として会うのは、これが初めてになるのかな」
	PRINTFORML 「まあ、その……だからどうというわけではないんだが…」
	PRINTFORMW 隠岐奈は照れているのか、ほんのりと頬を染めている。
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && !TALENT:キス未経験 && CFLAG:250 > 1
	CFLAG:200 = 3
	PRINTFORML 「ああ、%ANAME(MASTER)%か」
	PRINTFORML 「……ふふっ、どうした？私の顔に何かついてるのかな？」
	PRINTFORMW 隠岐奈はくすくす笑いながら、自身の唇を指でなぞった。
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:キス未経験 && TALENT:恋慕 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORML 「あ……ああ、来たのか、%ANAME(MASTER)%…」
	PRINTFORML 「ええっと、今日は何か予定はあるのか？」
	PRINTFORMW 隠岐奈は少し言い淀みながら、ちらちらと%ANAME(MASTER)%の様子をうかがっている。
;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
	PRINTFORML 
;正妻か妾
ELSEIF TALENT:正妻 || TALENT:妾
	SELECTCASE RAND:4
		CASE 0
			PRINTFORML 「ああ、そろそろ来てくれると思っていたぞ！」
			PRINTFORML 隠岐奈は椅子から立ち上がって%ANAME(MASTER)%に駆け寄り、ぎゅっと抱き着いた。
			PRINTFORML 「%ANAME(MASTER)%、今日はたっぷり甘えさせてもらうからな♥」
			PRINTFORMW 嬉しそうに笑いながら、隠岐奈は%ANAME(MASTER)%の胸元に顔をうずめた。
		CASE 1
```
