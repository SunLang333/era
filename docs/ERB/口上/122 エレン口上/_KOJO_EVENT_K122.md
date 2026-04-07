# 口上/122 エレン口上/_KOJO_EVENT_K122.ERB — 自动生成文档

源文件: `ERB/口上/122 エレン口上/_KOJO_EVENT_K122.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K122; UI/print

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
@KOJO_EVENT_K122(ARG)
#DIM 子供一人目
#DIM 子供二人目
#DIM 抽選回数
;呼び出す度に抽選回数はリセットしておく
抽選回数 = 0
;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕
	IF TALENT:恋慕
		IF IS_INITIATIVE(TARGET)
			IF IS_MALE(MASTER)
				PRINTFORMW 「あははは//」
			ELSE
				PRINTFORMW 「ねえ、嫌じゃなかった？」
				PRINTFORMW 「……本当？　よかった%UNICODE(0x2665)%//」
			ENDIF
		ELSE
			PRINTFORMW （好きな人からされるキスってこんなにもすてきなものだったのね//）
		ENDIF
	;好感度1000以上
	ELSEIF CFLAG:好感度 >= 1000
		IF IS_INITIATIVE(TARGET)
			
		ELSE
			IF IS_MALE(MASTER)
				PRINTFORMW 「えっ？えっ！？えええっ！？」
				PRINTFORMW （まさか%ANAME(MASTER)%がききききすしてくるなんて//）
				PRINTFORMW （%ANAME(MASTER)%からキスしてくるってことはももももしかしてわたしのことが好きなの！？//）
				PRINTFORMW （べべべべつに%ANAME(MASTER)%のことは好きだけれどそれは友達としての好きだし//）
				PRINTFORMW （%ANAME(MASTER)%もそう思ってると思ってたけどけどけど）
				PRINTFORMW （あーうー//）
				TALENT:恥薄い = 0
				TALENT:恥じらい = 1
				SETCOLOR カラー_注意
				PRINTFORML エレンは<恥薄い>を失い、新たに<恥じらい>を得た
				RESETCOLOR
			ELSE
				
			ENDIF
		ENDIF
	;その他
	ELSE
		IF IS_INITIATIVE(TARGET)
			
		ELSE
			IF IS_MALE(MASTER)
				PRINTFORMW 「……何勝手に人のファーストキッスを奪ってるのよ！！」
				PRINTFORMDW 本気で怒らせてしまったようだ…
				CFLAG:好感度 -= 300
				PALAM:怒主 += 100000
			ELSE
				PRINTFORMW 「あの、わたし初めてだったんだけど」
				PRINTFORMW 「……まあ、同性だしノーカウントよね！」
			ENDIF
		ENDIF
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		IF CFLAG:44
			PRINTFORMW 「……ようやく振り向いてくれたわね」
			PRINTFORM 「うれしい
		ELSE
			PRINTFORMW 「ええっ！？//　%ANAME(MASTER)%もわたしのことが好きだったの！？//」
			PRINTFORM 「…うん、わたしも%ANAME(MASTER)%のことが好きよ//　うれしい
		ENDIF
		PRINTFORMW %UNICODE(0x2665)%//　…えいっ%UNICODE(0x2665)%」
		PRINTFORMDW 遂に恋心が実ったエレンは、嬉しさを押さえられないのか満面の笑みを浮かべて%ANAME(MASTER)%に抱きついてきた
		PRINTFORMDW 抱きついてきたエレンを%ANAME(MASTER)%は優しく抱擁した…
		PRINTFORMW 「えへへ%UNICODE(0x2665)%　これからよろしくね%UNICODE(0x2665)% %ANAME(MASTER)%%UNICODE(0x2665)%%UNICODE(0x2665)%」
	;それ以外
	ELSE
		PRINTFORMW 「ええっ！？//　%ANAME(MASTER)%ってわたしのことが好きだったの！？//」
		PRINTFORMW 「…べつに%ANAME(MASTER)%だったらまあ、いいかな//」
		PRINTFORMW 「だから…、これからよろしくね%UNICODE(0x2665)%//」
	ENDIF
	IF TALENT:恥薄い
		TALENT:恥薄い = 0
		SETCOLOR カラー_注意
		PRINTFORML エレンは<恥薄い>を失った…
		RESETCOLOR
	ELSEIF TALENT:恥じらい
		TALENT:恥じらい = 0
		SETCOLOR カラー_注意
		PRINTFORML エレンは<恥じらい>を失った…
		RESETCOLOR
	ENDIF
	SIF TALENT:キス未経験
	PRINTFORMDW ……恋人となった%ANAME(MASTER)%とエレンは、長く、熱い口づけを交わした
	PRINTFORMDW …
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
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕かつ恋人
	IF TALENT:恋慕 && TALENT:恋人
		PRINTFORMW 「わたし達、とうとうえっちするんだよね//」
		PRINTFORMW 「初めてだからちょっと不安だけど…　それ以上に嬉しい気持ちでいっぱいだわ%UNICODE(0x2665)%」
		PRINTFORMW 「どういう風に嬉しいかって？　それは……色々よ//」
		PRINTFORMW 「もう//　…ねえ%ANAME(MASTER)%、出来るだけでいいから優しくしてね%UNICODE(0x2665)%//」
	;恋慕 or 恋人
	ELSEIF TALENT:恋慕 || TALENT:恋人
		PRINTFORMW 「わたし達、えっち…するんだよね//」
		PRINTFORMW 「初めてだからちょっと不安だけど…　大好きな%ANAME(MASTER)%のために頑張るわ%UNICODE(0x2665)%//」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	IF TALENT:恋慕 || TALENT:恋人 || TALENT:服従
		PRINTFORMW 「%ANAME(MASTER)%のことは好きだけど…//　こうムードとか…その…」
		PRINTFORMW 「とにかくだめ！//」
	ELSEIF TALENT:親友
		PRINTFORMW 「%ANAME(MASTER)%のことは好きだけど…、こういうのは恋人同士でやるものでしょ！」
		PRINTFORMW 「そもそもわたし達女の子同士じゃないの！」
	ELSE
		PRINTFORMW 「だめに決まってるでしょうが！　まったく」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	IF TALENT:妊娠
		PRINTFORMW 「子供に悪いからしたくないけど…、%ANAME(MASTER)%はしたいんだよね//」
		PRINTFORMW 「……わかったわ、してもいいけど…　やさしくしてね//」
	;嫁さんかわいい！
	ELSEIF TALENT:正妻
		IF TCVAR:650
			PRINTFORMW 「もう夜だもんね//　うん、いいわよ%UNICODE(0x2665)%//」
		ELSE
			SELECTCASE RAND:2
			CASE 1
				PRINTFORMW 「きて%UNICODE(0x2665)% %ANAME(MASTER)%//」
			CASEELSE
				PRINTFORMW 「エレンのこと、いっぱい愛してね%UNICODE(0x2665)%//」
			ENDSELECT
		ENDIF
	;恋慕かつ恋人
	ELSEIF TALENT:恋慕 && TALENT:恋人
		PRINTFORMW 「それじゃあしよっか。　%ANAME(MASTER)%//」
	;恋慕 or 恋人 or 服従
	ELSEIF TALENT:恋慕 || TALENT:恋人 || TALENT:服従
		PRINTFORMW 「その…、えっち、したいんだよね//」
		PRINTFORMW 「してもいいけど…、あの…//　優しくして//」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;真名を許すイベント
;-------------------------------------------------
IF ARG == 10
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
```
