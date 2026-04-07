# 口上/09 咲夜口上/DAILY/_KOJO_DAILY_K9_えっちな呼び方.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/DAILY/_KOJO_DAILY_K9_えっちな呼び方.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K9_ASK_DIRTY_NAME_RATE, KOJO_DAILY_K9_ASK_DIRTY_NAME_DECISION, KOJO_DAILY_K9_ASK_DIRTY_NAME_GENRE, KOJO_DAILY_K9_ASK_DIRTY_NAME; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K9_ASK_DIRTY_NAME_RATE(対象)
#DIM 対象
RETURN 500


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K9_ASK_DIRTY_NAME_DECISION(対象)
#DIM 対象
;咲夜口上デイリー入力系使用の設定が「使用する」でなければ戻る
SIF 咲夜_口上デイリー入力系使用 != 2
	RETURN 0

;奴隷でも恋人でもない、または合意がなければ戻る
SIF ( !IS_SLAVE(対象) && !IS_LOVER(対象) ) || !TALENT:対象:合意
	RETURN 0

;一回きり
SIF KDVAR:対象:咲夜_えっちな呼びかた
	RETURN 0


RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K9_ASK_DIRTY_NAME_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K9_ASK_DIRTY_NAME(対象)
#DIM 対象
#DIM 咲夜_対象
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
咲夜_対象 = MASTER



SETCOLOR 咲夜_口上カラー

;ロードデータ用の初期化
咲夜_淫語頻度 = 0
咲夜_淫語Ｐ '= "あれ"
咲夜_淫語Ｖ '= "なか"
咲夜_淫語Ｃ '= "そこ"
咲夜_淫語Ａ '= "そこ"
咲夜_淫語Ｂ '= "そこ"

;リセット
BEFORE_DIRTY_P '= 咲夜_淫語Ｐ
BEFORE_DIRTY_V '= 咲夜_淫語Ｖ
BEFORE_DIRTY_A '= 咲夜_淫語Ａ
BEFORE_DIRTY_C '= 咲夜_淫語Ｃ
BEFORE_DIRTY_B '= 咲夜_淫語Ｂ
NOW_DIRTY_P '= 咲夜_淫語Ｐ
NOW_DIRTY_V '= 咲夜_淫語Ｖ
NOW_DIRTY_A '= 咲夜_淫語Ａ
NOW_DIRTY_C '= 咲夜_淫語Ｃ
NOW_DIRTY_B '= 咲夜_淫語Ｂ

IF CHECK_K9("敬語")
	PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、少しお時間を頂けませんか？」
	PRINTFORMDW 拠点の見回りをしていると、%ANAME(対象)%が早足で近寄ってきた
	PRINTL 
	PRINTFORML 「お会いできて安心しました。あの、お伺いしたいことがあって」
	PRINTFORMDW %ANAME(対象)%は頬を緊張させている
	PRINTL 
	PRINTFORML 「教えて頂きたいのですが……夜のお相手を務めるに当たって、その」
	PRINTFORML 「体のことを、どう呼べばいいのかわからなくて悩んでいたんです」
	PRINTFORMDW やや口籠ったが、政務に励む姿と同じくらい真剣な瞳だ
	PRINTL 
	PRINTFORML 「%CALLNAME_K9(咲夜_対象)%には、最大限愉しんで頂きたいと思っております」
	PRINTFORML 「悦んでいることすら伝えられないようでは、申し訳なくて……」
	PRINTFORMW 「ただ、あまり積極的に乱れても冷めてしまわれるかもしれませんし」
	PRINTL 
	PRINTFORMW 「それで、よろしければ……%CALLNAME_K9(咲夜_対象)%のお気に召す呼び方を教えて頂きたいんです」
ELSE
	PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、今はいいかしら」
	PRINTFORMDW 拠点の見回りをしていると、%ANAME(対象)%が早足で近寄ってきた
	PRINTL 
	PRINTFORML 「ちょっと変なこと訊きたいのだけれど」
	PRINTFORMDW %ANAME(対象)%は頬を赤らめて視線を逸らしている
	PRINTL 
	PRINTFORML 「真面目な話だから、笑わないでね」
	PRINTFORML 「ほら、一緒に寝ると色んなことをするものでしょう？」
	PRINTFORMW 「意思疎通も大切だと思うのだけど、体のことをどう呼べばいいのかわからなくて」
	PRINTL 
	PRINTFORML 「黙ったまま察して欲しいなんて、フェアじゃないもの……%CALLNAME_K9(咲夜_対象)%を困らせちゃうわよね」
	PRINTFORML 「でも、あまり品のないことを言うと嫌われてしまうのかしら」
	PRINTFORMDW %ANAME(対象)%の声はどんどん小さくなっていった
	PRINTL 
	PRINTFORML 「もう！　変なことで悩んでるのはわかってるのよ」
	PRINTFORMW 「だから、その、%CALLNAME_K9(咲夜_対象)%の好きな呼び方を教えて欲しいの。お願いよ」
ENDIF

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
	咲夜_淫語Ｐ '= NOW_DIRTY_P
	咲夜_淫語Ｖ '= NOW_DIRTY_V
	咲夜_淫語Ａ '= NOW_DIRTY_A
	咲夜_淫語Ｃ '= NOW_DIRTY_C
	咲夜_淫語Ｂ '= NOW_DIRTY_B
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
```
