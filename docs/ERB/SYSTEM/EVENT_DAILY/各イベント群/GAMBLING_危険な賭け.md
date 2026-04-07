# SYSTEM/EVENT_DAILY/各イベント群/GAMBLING_危険な賭け.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/GAMBLING_危険な賭け.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_GAMBLING_RATE, EVENT_DAILY_GAMBLING_DECISION, EVENT_DAILY_GAMBLING_GENRE, EVENT_DAILY_GAMBLING_SETTARGET, EVENT_DAILY_GAMBLING, GAMBLING_PENALTY, SELECT_CHARA_LIST_SHOW_LOGIC_GAMBLING, EVENT_DAILY_GAMBLING_AGAIN_RATE, EVENT_DAILY_GAMBLING_AGAIN_DECISION, EVENT_DAILY_GAMBLING_AGAIN_GENRE, EVENT_DAILY_GAMBLING_AGAIN_SETTARGET, EVENT_DAILY_GAMBLING_AGAIN, GAMBLING_AGAIN_DEMUKAE, SELECT_CHARA_LIST_SHOW_LOGIC_GAMBLING_RETURN; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_GAMBLING_RATE()
RETURN 35


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_GAMBLING_DECISION()
RETURN DAY >= 15

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_GAMBLING_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_GAMBLING_SETTARGET()

;賭けの対象にできるキャラがいるかだけ見ておく
FOR LOCAL, 0, CHARANUM
	SIF CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && IS_FEMALE(LOCAL)
		GOTO FOUND
NEXT
RETURN 0

$FOUND

;賭けに負けて持っていかれたキャラがいたらダメ
FOR LOCAL, 0, CHARANUM
	IF GETBIT(TALENT:LOCAL:デイリー系, 素質_デイリー_カジノの従業員)
		RETURN 0
	ENDIF
NEXT
RETURN 1


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_GAMBLING()
#DIM 対象
#DIM 配当金

配当金 = LIMIT(MONEY / 2, 100000, 500000)

IF DVAR:賭け_初回実行済み
	PRINTFORMW また例の裏カジノからの招待状が届いた
	PRINTFORML 行ってみようか……
	PRINTL
	CALL ASK_YN()
ELSE
	PRINTFORMW %ANAME(MASTER)%のもとに、裏カジノからの招待が届いた
	PRINTFORMW 非合法ではあるが、その分非常に配当は高く、一攫千金も夢ではないという
	PRINTFORML 行ってみようか……
	PRINTL
	CALL ASK_YN()
ENDIF

IF RESULT == 1
	PRINTFORMW ……いや、そんなものに手をつけることはないだろう
	PRINTFORMW やめておくことにした
	RETURN 1
ENDIF

PRINTFORML せっかくなので訊ねることにした……
PRINTFORML 
PRINTFORML 
PRINTFORML 
PRINTFORMW 「ようこそ、お待ちしておりました」
PRINTFORMW 裏カジノというからには怪しげな建物を想像していたのだが、案外まともな建物のようだ
PRINTFORMW ……これだけ堂々と営業できているということは、地元の権力と癒着しているのだろう
PRINTFORMW 進められるまま、%ANAME(MASTER)%は席に着く
CALL ICPRINT(@"「当カジノの配当金は一律<{配当金}>となっております」", "W", カラー_注意)
PRINTFORMW 支配人の男がそう説明する。賭け金によって変動しないのか？　と尋ねると、支配人はニコニコと笑いながら平然と言う
PRINTFORMW 「当カジノでは金は賭けません。その代わりに、女の身柄を賭けていただくことになっております」
PRINTFORMW 「勝てば一攫千金、負ければ……まあ、その女性には、我々の従業員として働いていただくことになりますね」
PRINTFORMW ……とんでもないことを言い始めた
PRINTFORMW 従業員などと言っているが、ここは裏カジノだ。負ければ賭けた女は性奴隷にされるだろう
PRINTFORML だが、その破格の配当金は魅力だ……
PRINTL

CALL ASK_YN("賭けをする", "帰る")

IF RESULT == 1
	$CANCEL
	PRINTFORMW 配当金どうこうの問題ではない。こんなことは受け入れられない
	PRINTFORMW 帰ることにした……
	RETURN 0
ENDIF

PRINTFORML 「では、どなたを賭けてくださいますかな？」
CALL SINGLE_DRAWLINE
CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("GAMBLING", "NONE")
対象 = RESULT
SIF 対象 == -1
	GOTO CANCEL
IF 対象 == MASTER
	PRINTFORMW 「ご自分を？　……それは興味深い」
	PRINTFORMW 「仲間思いなのか、それともリスクがあってこそ燃えるタイプか、それとも……」
	PRINTFORMW 「……犯されたがりのド淫乱か」
	PRINTFORMW 「まあ、こちらとしてはいずれであっても構いませんがね」
ELSE
	PRINTFORMW こちらからは%ANAME(対象)%を賭ける……
	PRINTFORMW そのように伝えた
ENDIF
PRINTFORMW 「では、賭けの時間と参りましょうか……」

SELECTCASE RAND:3
	CASE 0
		CALL GAMBLING_SLOT
	CASE 1
		CALL GAMBLING_SORT
	CASE 2
		CALL GAMBLING_BINGO
ENDSELECT

SELECTCASE RESULT
	CASE 1
		PRINTFORMW 「素晴らしい！　%ANAME(MASTER)%様の勝利です」
		PRINTFORMW 「さあ、こちらが配当金です、お納めください」
		CALL COLOR_PRINTW(@"{配当金}を手に入れた", カラー_注意)
		PRINTFORMW 支配人に見送られ、カジノを後にした……
		MONEY += 配当金
	CASE 0
		PRINTFORMW 「おやおや、残念ですが我々の勝利のようですね」
		IF 対象 == MASTER
			PRINTFORMW 「では、約束通り、我々のために働いていただきますよ」
			PRINTFORMW 「せいぜいその肉体で、我々の客を悦ばせることですな」
			PRINTFORMW 支配人は舐めるような目線で、%ANAME(対象)%を見た……
		ELSE
			PRINTFORMW 「では、%ANAME(対象)%はいただいていきますよ。なに、待遇は悪くありませんからご心配なく」
			CALL COLOR_PRINTW(@"%ANAME(対象)%が連れていかれてしまった……", カラー_警告)
			PRINTFORMW 支配人に見送られ、カジノを後にした……
			CALL CHANGE_COUNTRY(対象, 0)
			CFLAG:対象:特殊状態 = 0
		ENDIF
		SETBIT TALENT:対象:デイリー系, 素質_デイリー_カジノの従業員
		CALL SET_PIERCE_RANDOM(対象, 0)
		SIF RESULT != -1
			CALL COLOR_PRINTW(@"%ANAME(対象)%の%GET_PIERCE_NAME(RESULT)%に、従業員である証のピアスが取り付けられた……", カラー_ピンク)
	CASE 2
		PRINTFORMW 「くく、やってしまいましたね、では我々の勝利です」
		PRINTFORMW 「%ANAME(対象)%のことは従業員として雇用いたしますが……その前に、ペナルティですね」
		PRINTFORMW 「少々お待ちください……くくっ」
		IF 対象 == MASTER
			PRINTFORMW %ANAME(対象)%はガードマンに店の奥へと連れていかれた……
		ELSE
			PRINTFORMW %ANAME(対象)%はガードマンに店の奥へと連れられて行った……
		ENDIF
		PRINTFORML
		PRINTFORML
		PRINTFORML
		CALL GAMBLING_PENALTY(対象)
		PRINTFORML
		PRINTFORML
		PRINTFORML
		PRINTFORMW 「いいショーでしたよ、くくっ、今後も%ANAME(対象)%には活躍してもらいませんとね」
		IF 対象 == MASTER
			PRINTFORMW 「では、約束通り、我々のために働いていただきますよ」
			PRINTFORMW 「せいぜいその肉体で、我々の客を悦ばせることですな」
			PRINTFORMW 支配人は舐めるような目線で、%ANAME(対象)%を見た……
		ELSE
			CALL COLOR_PRINTW(@"%ANAME(対象)%が連れていかれてしまった……", カラー_警告)
			PRINTFORMW 支配人に見送られ、カジノを後にした……
		ENDIF
		SETBIT TALENT:対象:デイリー系, 素質_デイリー_カジノの従業員
		CALL SET_PIERCE_RANDOM(対象, 0)
		SIF RESULT != -1
			CALL COLOR_PRINTW(@"%ANAME(対象)%の%GET_PIERCE_NAME(RESULT)%に、従業員である証のピアスが取り付けられた……", カラー_ピンク)
ENDSELECT



DVAR:賭け_初回実行済み = 1

;---------------------
;カジノで犯ひいたとき用のペナル茶
;---------------------
@GAMBLING_PENALTY(対象)
#DIM 対象
SELECTCASE RAND:5
	CASE 0
		PRINTFORML %ANAME(対象)%は公開輪姦ショーに出演させられた
		PRINTFORML 何人もの男がステージ上で%ANAME(対象)%を取り押さえ、両脚を無理やりに開かせる
		PRINTFORML 濡れてもいない膣にペニスを無理やり挿入すると、激しく前後し始める
		PRINTFORML やがて男が精を解き放つと、%ANAME(対象)%の喉から悲痛な叫び声が上がった……
```
