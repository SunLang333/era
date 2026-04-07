# 口上/03 ルーミア口上/_KOJO_EVENT_K3.ERB — 自动生成文档

源文件: `ERB/口上/03 ルーミア口上/_KOJO_EVENT_K3.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K3; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;イベント口上
;-------------------------------------------------

;=================================================
;●各種イベント
;※ARGにイベント番号が入る。詳しくは資料フォルダの「era恋姫 イベント表」を参照
;※RETURNの値を0→1に変えると、デフォルトのメッセージが表示されなくなる
;=================================================
@KOJO_EVENT_K3(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「ん……私の"はじめて"、上げちゃった♥」
		PRINTFORMW 自分の唇を指でなぞる%ANAME(TARGET)%の姿は、妙に色気があるように見えた
	;恋人
	ELSEIF TALENT:恋人
		PRINTFORML 「ん……私の"はじめて"、どうだった？」
		PRINTFORMW %ANAME(TARGET)%は頬を染めて、ファーストキスの感想を聞いてきた
	;それ以外
	ELSE
		PRINTFORML 「……"はじめて"だったんだけど、特にどうという事はないわね…」
		PRINTFORMW %ANAME(TARGET)%は淡々と、ファーストキスの感想を話した
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	PRINTL
	;恋慕 or 服従
	SETCOLOR カラー_黄
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「…ほ、ほんとうに…？」
		PRINTFORML 
		PRINTFORMW 「ウソじゃない？　罰ゲームでー、とか、そんなだったら怒るよ！？」
		PRINTFORML 
		PRINTFORMW この気持ちはウソじゃない。%ANAME(MASTER)%は%ANAME(TARGET)%に本心を伝えた
		PRINTFORML 
		PRINTFORMW 「……はは、夢みたい。私がこんな…………っ！」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%に抱きついて胸元に頭を埋める。その顔には満面の笑みが浮かんでいた
		PRINTFORML 
		PRINTFORMW 「私だけの片思いじゃなかったんだね…、うれしいなぁ♥」
		PRINTFORML 
		PRINTFORMW 「……これからもずっと一緒にいてね。カノジョに寂しい思い、させないでよね♪」
		PRINTFORML 
		PRINTFORMW 甘い雰囲気の中、二人はしばらくの間ずっと抱き合っていた……
		PRINTFORML 
		PRINTFORMW 二人は晴れて恋人となった
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORMW 「…ほんとうに？」
		PRINTFORML 
		PRINTFORMW 「ウソじゃないでしょうね？　冗談とかだったら怒るよ？」
		PRINTFORML 
		PRINTFORMW このキモチはウソじゃない。%ANAME(MASTER)%は本心を伝えた
		PRINTFORML 
		PRINTFORMW 「……ほうほう…。本気なんだ…、そうなんだ」
		PRINTFORML 
		PRINTFORMW しばし考えた後、%ANAME(TARGET)%はにっこりと笑い%ANAME(MASTER)%に顔を向けた
		PRINTFORML 
		PRINTFORMW 「いいよー♥　私も%ANAME(MASTER)%のこと、嫌いじゃないしね♪」
		PRINTFORML 
		PRINTFORMW 「そのかわり、ちゃんと恋人らしく構ってよ？　カノジョに寂しい思い、させないでよねー♪」
		PRINTFORML 
		PRINTFORMW 二人は笑顔で手を繋ぎ、晴れて恋人となった
		PRINTFORML 
	ENDIF
	RESETCOLOR
	RETURN 1
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTL
	PRINTFORML 「ふにゅぁ…あ、ああ…だめだってぇ……」
	PRINTFORMW %ANAME(TARGET)%は酔いが回って%ANAME(MASTER)%を拒みきれないようだ
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	PRINTL
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「あっ…♥　ついに、す、するんだね…いいよ♥」
		PRINTFORML %ANAME(TARGET)%はやや緊張しつつも、%ANAME(MASTER)%のことを受け入れている
		PRINTFORMW 「でも、ちゃんと優しくしてね、%ANAME(MASTER)%♥」
	;それ以外
	ELSE
		PRINTFORML 「あ……もう。しょうがないなぁ」
		PRINTFORMW %ANAME(TARGET)%は力を抜いて、%ANAME(MASTER)%のことを受け入れている
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	PRINTL
	PRINTFORMW 「もう！　だめーっ！」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	PRINTL
	SELECTCASE RAND:3
		CASE 0
			PRINTFORML 「あん…♥　もう我慢できないの？」
			PRINTFORMW 「ふふ、いいよー♪　そのかわり、いっぱいキモチよくしてー♥」
		CASE 1
			PRINTFORML 「あ♥　…ふふ、いいよ♥」
			PRINTFORML %ANAME(TARGET)%は力を抜いて、%ANAME(MASTER)%のことを受け入れている
			PRINTFORMW 「ちゃんと優しくしてね、%ANAME(MASTER)%♥」
		CASE 2
			PRINTFORML 「あはっ♪　待ってたよー」
			PRINTFORML %ANAME(TARGET)%は服を脱ぐと、笑顔で%ANAME(MASTER)%に抱きついた
			PRINTFORMW 「今日もちゃんと、キモチよくしてね♥」
	ENDSELECT
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	PRINTFORMW 「もっ、もうむりぃ……」
	RETURN 0
ENDIF

;-------------------------------------------------
;気力限界(通常)
;-------------------------------------------------
IF ARG == 12
	PRINTFORMW 「もっ、もうだめぇ……」
	RETURN 0
ENDIF

;-------------------------------------------------
;怒りの限界で追い返される
;-------------------------------------------------
IF ARG == 13
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;哀しみの限界で追い返される
;-------------------------------------------------
IF ARG == 14
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;怒りの限界で勝手に帰る
;-------------------------------------------------
IF ARG == 15
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;哀しみの限界で勝手に帰る
;-------------------------------------------------
IF ARG == 16
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;体力限界(捕虜調教)
;-------------------------------------------------
IF ARG == 17
	PRINTFORMW 「もっ、もうむりぃ……」
	RETURN 0
```
