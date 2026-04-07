# 口上/10 レミリア口上/DAILY/_KOJO_DAILY_K10_ご褒美をあげる.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/DAILY/_KOJO_DAILY_K10_ご褒美をあげる.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K10_ASK_DIRTY_NAME_RATE, KOJO_DAILY_K10_ASK_DIRTY_NAME_DECISION, KOJO_DAILY_K10_ASK_DIRTY_NAME_GENRE, KOJO_DAILY_K10_ASK_DIRTY_NAME; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K10_ASK_DIRTY_NAME_RATE(対象)
#DIM 対象
RETURN 500


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K10_ASK_DIRTY_NAME_DECISION(対象)
#DIM 対象

;対象口上デイリー入力系使用の設定が「使用する」でなければ戻る
SIF レミリア_口上デイリー入力系使用 != 2
	RETURN 0

;奴隷でも恋人でもない、または合意がなければ戻る
SIF ( !IS_SLAVE(対象) && !IS_LOVER(対象) ) || !TALENT:対象:合意
	RETURN 0

;一回きり
SIF KDVAR:対象:レミリア_ご褒美をあげる
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K10_ASK_DIRTY_NAME_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K10_ASK_DIRTY_NAME(対象)
#DIM 対象
#DIM レミリア_対象
#DIMS BEFORE_DIRTY_P
#DIMS BEFORE_DIRTY_V
#DIMS BEFORE_DIRTY_A
#DIMS BEFORE_DIRTY_C
#DIMS BEFORE_DIRTY_B
#DIMS NOW_DIRTY_P
#DIMS NOW_DIRTY_V
#DIMS NOW_DIRTY_A
#DIMS NOW_DIRTY_C
#DIMS NOW_DIRTY_B

;リセット
レミリア_対象 = MASTER



SETCOLOR レミリア_口上カラー

;ロードデータ用の初期化
レミリア_淫語頻度 = 0
レミリア_淫語Ｐ '= "あれ"
レミリア_淫語Ｖ '= "なか"
レミリア_淫語Ｃ '= "そこ"
レミリア_淫語Ａ '= "そこ"
レミリア_淫語Ｂ '= "そこ"

;リセット
BEFORE_DIRTY_P '= レミリア_淫語Ｐ
BEFORE_DIRTY_V '= レミリア_淫語Ｖ
BEFORE_DIRTY_A '= レミリア_淫語Ａ
BEFORE_DIRTY_C '= レミリア_淫語Ｃ
BEFORE_DIRTY_B '= レミリア_淫語Ｂ
NOW_DIRTY_P '= レミリア_淫語Ｐ
NOW_DIRTY_V '= レミリア_淫語Ｖ
NOW_DIRTY_A '= レミリア_淫語Ａ
NOW_DIRTY_C '= レミリア_淫語Ｃ
NOW_DIRTY_B '= レミリア_淫語Ｂ

PRINTFORMDL 目を覚ますと、ドアの隙間から手紙が差し込まれていた
PRINTFORMDL 封蝋に%ANAME(対象)%の指輪印章が捺されている
PRINTFORMDW 部屋への招待状――どうやら呼び出しの手紙のようだ
PRINTL 
PRINTFORML 「来たわね、%CALLNAME_K10(レミリア_対象)%。喜びなさい」
PRINTFORMDL %ANAME(レミリア_対象)%が部屋に入ると、%ANAME(対象)%は目を輝かせて微笑んだ
PRINTFORMDW いつもより豪華な菓子がテーブルに飾られている
PRINTL 
PRINTFORML 「あなたにご褒美をあげる――今日からこの、%ANAME(対象)%が」
PRINTFORML 「%CALLNAME_K10(レミリア_対象)%の大好きな、卑しい言葉を使ってあげるわ！」
PRINTFORMDW %ANAME(対象)%は得意満面で声高らかに言い放った
PRINTL 
PRINTFORML 「……？　喜ばないの？　反応が薄いわね」
PRINTFORML 「たまに私に言ってもらおうとしてなかった？」
PRINTFORML 「何か特別な意味があるかと思っていたのだけど……違ったの？」
PRINTFORMDW %ANAME(対象)%はきょとんとして首を傾げている
PRINTL 
PRINTFORML 「あまり卑しい言葉は使いたくないのだけど」
PRINTFORML 「%CALLNAME_K10(レミリア_対象)%が気持ちよくなるなら、私も愉しいし」
PRINTFORMW 「好きな呼び方を言ってみていいのよ？　言いなさい」

LOCAL:0 = LINECOUNT
$SHOW_LOOP
RESETCOLOR
CALL SINGLE_DRAWLINE
CALL ICPRINT("<教えたい名称を><全角仮名><で入力・または決定する（平仮名・片仮名はどちらでも可能）>", "L", カラー_選択不可, カラー_オレンジ, カラー_選択不可)
PRINTL 
PRINTFORM   Ｐ呼称 : 
RESETCOLOR
PRINTFORM %NOW_DIRTY_P, 20, LEFT%
PRINTBUTTON "  [入力]", "入力Ｐ"
PRINTL 
PRINTFORM   Ｖ呼称 : 
RESETCOLOR
PRINTFORM %NOW_DIRTY_V, 20, LEFT%
PRINTBUTTON "  [入力]", "入力Ｖ"
PRINTL 
PRINTFORM   Ｃ呼称 : 
RESETCOLOR
PRINTFORM %NOW_DIRTY_C, 20, LEFT%
PRINTBUTTON "  [入力]", "入力Ｃ"
PRINTL 
PRINTFORM   Ａ呼称 : 
RESETCOLOR
PRINTFORM %NOW_DIRTY_A, 20, LEFT%
PRINTBUTTON "  [入力]", "入力Ａ"
PRINTL 
PRINTFORM   Ｂ呼称 : 
RESETCOLOR
PRINTFORM %NOW_DIRTY_B, 20, LEFT%
PRINTBUTTON "  [入力]", "入力Ｂ"

PRINTBUTTON "  [決定]", "決定"
PRINTL 
CALL SINGLE_DRAWLINE

;初期値指定入力
INPUTS 決定

IF RESULTS == "決定"
	レミリア_淫語Ｐ '= NOW_DIRTY_P
	レミリア_淫語Ｖ '= NOW_DIRTY_V
	レミリア_淫語Ａ '= NOW_DIRTY_A
	レミリア_淫語Ｃ '= NOW_DIRTY_C
	レミリア_淫語Ｂ '= NOW_DIRTY_B
	CLEARLINE LINECOUNT - LOCAL:0
	PRINTL 

ELSEIF RESULTS == "入力Ｐ"
	CLEARLINE 1
	SETCOLOR カラー_選択不可
	PRINTL Ｐ呼称入力中
	RESETCOLOR
	IF RESULTS != NOW_DIRTY_P
		INPUTS %NOW_DIRTY_P%
		LOCALS:0 = %RESULTS%
		;半角を1字と数えてLOCALS:0の0字目から20字目までを切り出す
		SUBSTRING LOCALS:0, 0, 20
		NOW_DIRTY_P '= LOCALS:0
	ENDIF
	CLEARLINE LINECOUNT - LOCAL:0
	GOTO SHOW_LOOP

ELSEIF RESULTS == "入力Ｖ"
	CLEARLINE 1
	SETCOLOR カラー_選択不可
	PRINTL Ｖ呼称入力中
	RESETCOLOR
	IF RESULTS != NOW_DIRTY_V
		INPUTS %NOW_DIRTY_V%
		LOCALS:0 = %RESULTS%
		SUBSTRING LOCALS:0, 0, 20
		NOW_DIRTY_V '= LOCALS:0
	ENDIF
	CLEARLINE LINECOUNT - LOCAL:0
	GOTO SHOW_LOOP

ELSEIF RESULTS == "入力Ａ"
	CLEARLINE 1
	SETCOLOR カラー_選択不可
	PRINTL Ａ呼称入力中
	RESETCOLOR
	IF RESULTS != NOW_DIRTY_A
		INPUTS %NOW_DIRTY_A%
		LOCALS:0 = %RESULTS%
		SUBSTRING LOCALS:0, 0, 20
		NOW_DIRTY_A '= LOCALS:0
	ENDIF
	CLEARLINE LINECOUNT - LOCAL:0
	GOTO SHOW_LOOP

ELSEIF RESULTS == "入力Ｃ"
	CLEARLINE 1
	SETCOLOR カラー_選択不可
```
