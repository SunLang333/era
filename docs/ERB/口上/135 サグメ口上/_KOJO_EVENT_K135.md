# 口上/135 サグメ口上/_KOJO_EVENT_K135.ERB — 自动生成文档

源文件: `ERB/口上/135 サグメ口上/_KOJO_EVENT_K135.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K135; UI/print

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
@KOJO_EVENT_K135(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	PRINTFORMW 「…」
	PRINTFORMW サグメは後ろ手を組みながら%ANAME(MASTER)%を見つめている。
	PRINTFORMW 「………」
	PRINTFORMW 意を決したように彼女はこう言った。
	PRINTFORMW 「眼瞑って」
	PRINTFORMW %ANAME(MASTER)%は言われるまま目を瞑ると
	PRINTFORMW 
	PRINTFORMW 「んっ…」
	PRINTFORMW 
	PRINTFORMW 柔らかい唇の感触と共にサグメは口付けをしてきた。
	PRINTFORMW 「…」
	PRINTFORMW 「……」
	PRINTFORMW 「………」
	PRINTFORMW 「…さようなら…」
	PRINTFORMW サグメは顔を真赤に上気させながら羽ばたいて行ってしまった。
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORMW 「………」
		PRINTFORMW 「私と、恋人に」
		PRINTFORML 「……そうね」
		PRINTFORMW 「私も、好きよ、%ANAME(MASTER)%のこと」
		PRINTFORMW 「女として…%ANAME(MASTER)%のこと、愛しているわ」
		PRINTFORML 「でもね、私の能力は人を不幸にするの」
		PRINTFORML 「それでもいい、そんな私を大切に想ってくれていたのなら」
		PRINTFORMW 「私の何もかもを貴方に捧げます」
		PRINTFORML 「そしてこれからも%ANAME(MASTER)%と―――」
		PRINTFORMW サグメはそう告白しながら抱きついてきた。
		PRINTFORMW 暫くの間%ANAME(MASTER)%はサグメと抱擁を交わしながらその温もりを感じ取ることにした。
	;それ以外
	ELSE
		PRINTFORMW 「私と付き合いたい…の？」
		PRINTFORMW 「…いいけど、どうなっても知らないわよ」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTFORML 「………？」
	PRINTFORML %ANAME(MASTER)%の挙動不審な態度にサグメは少し困惑している。
	PRINTFORMW （何か…あったのかしら？）
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	IF RAND:3 == 0
		PRINTFORMW 「…」
		PRINTFORMW 「別に、構わない」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「好きにすればいい」
	ELSE
		PRINTFORMW 「…」
		PRINTFORMW サグメは表情を強張らせながらもなすがままに押し倒されている。
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		IF RAND:3 == 0
			PRINTFORMW 「…いいわよ」
			PRINTFORMW そういうと押し倒されたサグメは足を絡めてきた。
			PRINTFORMW 「私を…滅茶苦茶に穢して…%UNICODE(0x2665) *1%」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「ん…分かった」
			PRINTFORMW 「気持よく、してね…%UNICODE(0x2665) *1%」
		ELSE
			PRINTFORMW 「…いいけど」
			PRINTFORMW 「責任取ってね…」
		ENDIF
	;それ以外
	ELSE
		IF RAND:3 == 0
			PRINTFORMW 「分かった…優しく、してね」
		ELSEIF RAND:2 == 0
			PRINTFORMW 「こういうのは、あまり慣れてないから…」
			PRINTFORMW 「リード、してね…」
		ELSE
			PRINTFORMW 「…好きにして」
		ENDIF
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	IF RAND:4 == 0
		PRINTFORMW 「…！」
		PRINTFORMW サグメは指でバッテンを作りながらもまんざらでもなさそうに顔を赤らめている。
	ELSEIF RAND:3 == 0
		PRINTFORMW 「やだ…そういうこと、したくない」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「…ダメ」
	ELSE
		PRINTFORMW 「…」
		PRINTFORMW サグメは無言で拒否の姿勢を貫いている。
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	IF RAND:6 == 0
		PRINTFORMW 「滅茶苦茶に…穢して…%UNICODE(0x2665) *1%」
	ELSEIF RAND:5 == 0
		PRINTFORMW 「%ANAME(MASTER)%の精で…満たして…%UNICODE(0x2665) *1%」
	ELSEIF RAND:4 == 0
		PRINTFORMW 「%ANAME(MASTER)%…私を…満たして…%UNICODE(0x2665) *1%」
	ELSEIF RAND:3 == 0
		PRINTFORMW 「…好きよ…%ANAME(MASTER)%…」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「来、て…%UNICODE(0x2665) *1%」
	ELSE
		PRINTFORMW 「気持よく、して…ね…%UNICODE(0x2665) *1%」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	PRINTFORMW 「ん…流石に…疲れた…」
	RETURN 0
ENDIF

;-------------------------------------------------
;気力限界(通常)
;-------------------------------------------------
IF ARG == 12
	PRINTFORMW 「あっ…ん…」
	PRINTFORMW 「%ANAME(MASTER)%…今日は終わり…？」	RETURN 0
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
```
