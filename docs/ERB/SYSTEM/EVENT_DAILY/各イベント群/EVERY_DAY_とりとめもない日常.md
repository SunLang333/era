# SYSTEM/EVENT_DAILY/各イベント群/EVERY_DAY_とりとめもない日常.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/EVERY_DAY_とりとめもない日常.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_EVERY_DAY_RATE, EVENT_DAILY_EVERY_DAY_DECISION, EVENT_DAILY_EVERY_DAY_SETTARGET, EVENT_DAILY_EVERY_DAY_GENRE, EVENT_DAILY_EVERY_DAY; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_EVERY_DAY_RATE()
RETURN 25

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_EVERY_DAY_DECISION()
SIF DAY < 5
	RETURN 0
;MASTERにペニスがある
SIF !HAS_PENIS(MASTER)
	RETURN 0

RETURN 1

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_EVERY_DAY_SETTARGET()

FOR LOCAL, 0, CHARANUM
	;女キャラ、かつ自国所属かつ捕虜でない、かつ動物でない
	IF IS_FEMALE(LOCAL) && CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && !CFLAG:LOCAL:捕虜先 && !IS_ANIMAL(LOCAL) && CFLAG:LOCAL:面識
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
		DAILY_TARGET_NUM ++
	ENDIF
NEXT

SIF DAILY_TARGET_NUM < 11
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_EVERY_DAY_GENRE()
RETURN デイリー_ジャンル_その他

;---------------------
;本体
;---------------------
@EVENT_DAILY_EVERY_DAY
#DIM 対象

対象 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)

SIF CFLAG:対象:面識 == 0
	CFLAG:対象:面識 = 1

IF CFLAG:対象:好感度 < 0 
	PRINTFORML %ANAME(対象)%を見かけたが避けられてしまった
	PRINTFORMW 今までの%ANAME(MASTER)%の行いで、彼女に悪印象を持たれている様だ…
	RETURN
ENDIF

SELECTCASE RAND:20
	;髪型
	CASE 0
		PRINTFORMW 宮殿を歩いていると%ANAME(対象)%を見かけた
		PRINTFORML しかし何やらいつもと印象が違う…
		PRINTFORMW そうだ、いつもと髪型が変わっている
		PRINTFORML %ANAME(MASTER)%の視線に気づいたのか、彼女もこちらを振り向くと近寄って来た
		PRINTFORMW 二言三言挨拶を交わした後、『気分転換に髪型を変えてみたのだけどどうか』と尋ねられた
		PRINTFORML どうしよう？
		CALL ASK_MULTI("似合っていると誉める" ,"いつもの髪型のほうが良いという" ,"頭をなでる")
		IF RESULT == 0
			PRINTFORML 似合っていると褒めると彼女はにこっと笑った
			PRINTFORMW それからいくつかたわいない会話を交わし、彼女は仕事に戻って行った
			PRINTFORML 
			PRINTFORMW その後、時折その時の髪型に変えている彼女を見かけるようになった
			IF CFLAG:対象:好感度 >= CFLAG:対象:従属度
				CFLAG:対象:好感度 += 50
			ELSE
				CFLAG:対象:従属度 += 50
			ENDIF
		ELSEIF RESULT == 1
			PRINTFORML いつもの髪型のほうが似合っていると告げた
			PRINTFORMW 彼女は頭を撫でながら『そうかしら』と小さくつぶやいた
			PRINTFORMW それからいくつかたわいない会話を交わし、彼女は仕事に戻って行った
		ELSE
			PRINTFORML 似合っていると褒めながら彼女の頭に手を伸ばした
			LOCAL = RAND:300
			IF CFLAG:対象:好感度 + LOCAL >= 1000 || CFLAG:対象:従属度 + LOCAL >= 1000
				PRINTFORML 頭を撫でてやると彼女は小さく頬をほころばせた
				PRINTFORMW それからいくつかたわいない会話を交わし、彼女は仕事に戻って行った
				PRINTFORML 
				PRINTFORMW その後、時折その時の髪型に変えている彼女を見かけるようになった
				IF CFLAG:対象:好感度 >= CFLAG:対象:従属度
					CFLAG:対象:好感度 += 80
				ELSE
					CFLAG:対象:従属度 += 80
				ENDIF
			ELSE
				PRINTFORML しかしやんわりと手を払いのけられてしまった
				PRINTFORMW やはり少々馴れ馴れしすぎただろうか
				PRINTFORMW それからいくつかたわいない会話を交わし、彼女は仕事に戻って行った
			ENDIF
		ENDIF
	;うとうと
	CASE 1
		PRINTFORML 仕事中、%ANAME(対象)%がうとうとしているのを見かけた
		PRINTFORML どうしよう？
		CALL ASK_MULTI("驚かせる" ,"寝かせてあげる" ,"コーヒーを淹れる")
		IF RESULT == 0
			PRINTFORMW 悪戯を思いついた%ANAME(MASTER)%は静かに彼女の背後に回った
			PRINTFORML 
			PRINTFORML …わっ！
			PRINTFORMW 
			PRINTFORML 背後から大声で驚かせると彼女は素っ頓狂な叫びをあげて飛び上がった
			PRINTFORML そして笑っている%ANAME(MASTER)%を見ると彼女は頬を膨らませて怒り出した
			PRINTFORMW ごめんごめんと謝るとふくれっ面していた彼女もつられて笑い出した
			PRINTFORMW すっかり眠気も覚めたようでその後は二人で仕事に励んだ
		ELSEIF RESULT == 1
			PRINTFORML そのまま見ていると直ぐに彼女は机に突っ伏して寝息を立て始めた
			PRINTFORML 起こそうかとも思ったが、今は忙しくもないので寝かせてあげる事にした
			PRINTFORMW %ANAME(MASTER)%は手近にあった毛布をかけてやると仕事に戻った
			PRINTFORML 
			PRINTFORML 小一時間後、彼女は目を覚ました
			PRINTFORML おはようと言うときょとんとした後、仕事中だったことを思い出したのか頬を赤らめる
			PRINTFORMW 彼女は毛布に気づくと照れ臭そうに小さな声でお礼を告げた
			PRINTFORMW すっかり眠気も覚めたようでその後は二人で仕事に励んだ
		ELSE
			PRINTFORML 丁度良い時間なので休憩ついでにコーヒーを淹れてあげた
			PRINTFORMW 二人でコーヒーを飲みながらたわいない会話を楽しんだ
			PRINTFORML 
			PRINTFORMW すっかり眠気も覚めたようでその後は二人で仕事に励んだ
		ENDIF
		IF CFLAG:対象:好感度 >= CFLAG:対象:従属度
			CFLAG:対象:好感度 += 50
		ELSE
			CFLAG:対象:従属度 += 50
		ENDIF
	;チケット
	CASE 2
		PRINTFORML サーカスのチケットが当たった
		PRINTFORMW 二人分あるがどうしようかと思っていると%ANAME(対象)%を見かけた
		PRINTFORML どうしよう？
		CALL ASK_MULTI("彼女を誘う" ,"一人で楽しむ" ,"転売する")
		IF RESULT == 2
			PRINTFORML サーカスなんて興味はない
			PRINTFORMW %ANAME(MASTER)%はチケットを転売した
			PRINTFORMW チケットは金1000で売れた
			MONEY += 1000
		ELSEIF RESULT == 1
			PRINTFORML しかし一人で楽しむことにした
			PRINTFORMW サーカスはとても面白く、二度見に行ったが飽きなかった
		ELSE
			PRINTFORML 折角なので彼女を誘った
			PRINTFORMW %ANAME(MASTER)%の誘いに%ANAME(対象)%は喜んで応じてくれた
			PRINTFORML 
			PRINTFORML サーカスはとても面白く、二人で多いに楽しんだ
			PRINTFORMW 帰り道、彼女は誘ってくれてありがとうと満面の笑みを見せてくれた
			IF CFLAG:対象:好感度 >= CFLAG:対象:従属度
				CFLAG:対象:好感度 += 50
			ELSE
				CFLAG:対象:従属度 += 50
			ENDIF
		ENDIF
	;麻雀
	CASE 3
		PRINTFORML 休日、自室でくつろいでいたら%ANAME(対象)%に麻雀に誘われた
		PRINTFORMW 暇なので付き合う事にした
		CALL ASK_MULTI("あんた背中が煤けてるぜ" ,"死ねば助かるのに…" ,"これぞ玄人技の真骨頂【燕返し】")
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		IF RAND:2 == 0
			PRINTFORML 容赦せず巻き上げた
			PRINTFORMW 彼女は涙目になりながら、財布からお小遣いを差し出した
			PRINTFORMW 可愛そうだったのでご飯を奢ってあげた
			IF CFLAG:対象:好感度 >= CFLAG:対象:従属度
				CFLAG:対象:好感度 += 50
			ELSE
				CFLAG:対象:従属度 += 50
			ENDIF
			MONEY += 2000
		ELSE
			PRINTFORML 容赦なく巻き上げられた
			PRINTFORMW 許してといっても許されず、財布が空になるまでつき合わされた
			PRINTFORMW 彼女は上機嫌でご飯を奢ってくれた…
			IF CFLAG:対象:好感度 >= CFLAG:対象:従属度
				CFLAG:対象:好感度 += 50
			ELSE
				CFLAG:対象:従属度 += 50
			ENDIF
			LOCAL = 10000
			SIF MONEY < LOCAL
				LOCAL = MONEY
			MONEY -= LOCAL
		ENDIF
	;飲み会
	CASE 4
		PRINTFORML 夜遅く帰ったら宴会が開かれていた
		PRINTFORML 参加しようとしたら%ANAME(対象)%と目が合い、手招きされた
```
