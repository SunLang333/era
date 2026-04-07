# 口上/92 わかさぎ姫口上/_KOJO_EVENT_K92.ERB — 自动生成文档

源文件: `ERB/口上/92 わかさぎ姫口上/_KOJO_EVENT_K92.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K92; UI/print

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
@KOJO_EVENT_K92(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1

	IF TALENT:恋慕
		IF CFLAG:300 == 0
			PRINTFORMW 「初めての相手が%ANAME(MASTER)%さんで…嬉しいです」
		ELSEIF CFLAG:300 == 1
			PRINTFORMW 「初めての相手が%ANAME(MASTER)%で…嬉しいです」
		ELSEIF CFLAG:300 == 2
			PRINTFORMW 「初めての相手が貴方で…嬉しいです」
		ENDIF
	ELSEIF TALENT:恋人 || TALENT:服従
		PRINTFORMW 「はじめてのキス…えへへ。悪くないですね」
	ELSE
	ENDIF
	
;	;恋慕かつ恋人
;	IF TALENT:恋慕 && TALENT:恋人
;		PRINTFORMW 「あっ…」
;		PRINTFORML キスを終えると%ANAME(TARGET)%は名残惜しそうに自分の口元に触れている
;		PRINTFORMW 「あの…もうちょっと、お願いしたいです」
;		
;	;恋慕または恋人または服従
;	ELSEIF TALENT:恋人 || TALENT:恋慕 || TALENT:服従
;		PRINTFORML 「なんだか…照れちゃいますね」
;		PRINTFORMW 「でも、嬉しいです」
;		
;	;合意あり
;	ELSEIF TALENT:合意
;		PRINTFORML 「むー」
;		PRINTFORMW 「嫌じゃないですけど、ムードは大事にしてほしかったです」
;		
;	;合意なし
;	ELSE
;		PRINTFORML 「うう…ひどい……」
;		PRINTFORMW %ANAME(TARGET)%は口元を拭っている…
;		
;	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕または合意
	IF TALENT:恋慕 || TALENT:合意 || TALENT:服従
		PRINTFORMW 「えっ…？私と…恋人になりたい？」
		PRINTFORML %ANAME(MASTER)%はこくこくと頷く。気の利いた台詞の一つも言えない自分が情けない。
		PRINTFORMW %ANAME(TARGET)%は顔を真っ赤にして何かぶつぶつつぶやいている…
		PRINTFORML 
		PRINTFORML 「いや待って私は妖怪でこの人のことは嫌いじゃないけどいきなり付き合うのは心の準備が」
		PRINTFORML 「ああ嫌ってのは断ってる訳じゃなくて私もどちらかと言うと好きだしこの人優しいし」
		PRINTFORMW 「頭がぐるぐるでもうなにがなんだか分からないけど返事しなくちゃ（ビターンビターン）」
		PRINTFORML 
		PRINTFORMW %ANAME(TARGET)%の混乱ぶりに%ANAME(MASTER)%は一旦帰ろうと踵を返した
		PRINTFORML 
		PRINTFORMW 「ま、待って！へ、へ、返事…するから、帰らないで！」
		PRINTFORMW 「い、今は心臓どきどきで、うまく言えないから…その、落ち着くまで」
		PRINTFORMW 「ぎゅって、抱きしめて、ください…」
		PRINTFORML 
		PRINTFORMW 
		PRINTFORMW …………………
		PRINTFORMW ………
		PRINTFORML 
		PRINTFORMW 
		IF CFLAG:300 == 0
			PRINTFORMW 「%ANAME(MASTER)%さん…暖かいです」
		ELSEIF CFLAG:300 == 1
			PRINTFORMW 「%ANAME(MASTER)%…暖かいです」
		ELSEIF CFLAG:300 == 2
			PRINTFORMW 「貴方…暖かいです」
		ENDIF
		PRINTFORML 
		PRINTFORMW 「もう大丈夫です。ありがとうございます」
		PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%の手を取り
		PRINTFORMW 「喜んでお受けします。ダーリン♪なんちゃって…えへへ」
		PRINTFORMW 照れ笑いを浮かべて答えた
		PRINTFORML 
	;それ以外
	ELSE
		PRINTFORML 「いや、お互いの事もよく知らないと思うんですけど！」
		PRINTFORMW 「いいのかなあ。簡単に決めちゃって」
		
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	IF TALENT:恋慕 || TALENT:合意 || TALENT:服従
		PRINTFORMW 「ちょ、ちょっとまだ心の準備が…」
		PRINTFORML 「や、やっぱりまだダメっ！（びたーん！）」
		PRINTFORMW 「ああっ！やっちゃった！ごめんなさーい！」
	ELSE
		PRINTFORML 「いいお友達でいましょうね」
		PRINTFORMW 「…近づかないでください。ひっぱたきますよ？」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTFORML 「ふえ？にゃにしてるんれすかあ。お風呂でしゅかあ？」
	PRINTFORML 泥酔している%ANAME(TARGET)%は抵抗せずに服を脱がされている…
	PRINTFORMW 「んもう、くすぐったいれすよお。きゃははは♪」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕かつ恋人
	IF TALENT:恋慕 && TALENT:恋人
		PRINTFORMW 「はい。えっちな事…しちゃうんですね。」
		PRINTFORMW 「恋人同士なのに全然求められなくて不安だったんですよ、もう」
		PRINTFORML 
		PRINTFORMW 「私だって…女の子なんですから」
		PRINTFORML %ANAME(TARGET)%は静かに帯を外してゆく…
		PRINTFORMW 　しゅるしゅる…すとん　すとん
		PRINTFORML 
		PRINTFORMW 「えへへ、たくさん愛してくださいね」
		
	;恋慕または恋人
	ELSEIF TALENT:恋慕 || TALENT:恋人 || TALENT:服従
		PRINTFORML 「はい…服を脱ぐんですね…」
		PRINTFORML 「ちょっと怖いですけど、大丈夫です。信じてますから」
		PRINTFORMW 「優しくしてくださいね」
		
	;それ以外
	ELSE
		PRINTFORML 「こういうのは好きな人同士が…！」
		PRINTFORMW 「脱ぎます、脱ぎますから！無理やりはやめてえ！」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;何度もやると嫌われるよ
;-------------------------------------------------
IF ARG == 6
	;初回
	IF CFLAG:302 == 0
		PRINTFORML 「きゃあ！何するんですか！（ばしーん！）」
		PRINTFORMW 「女の子を襲うなんてダメですよ！ぷんぷん！」
		CFLAG:302 = 1
	;２回目
	ELSEIF CFLAG:302 == 1
		PRINTFORMW 「だからあ、ダメですってば！（すぱーん！）」
		CFLAG:302 = 2
		
	;３回目以降
	ELSE
		SELECTCASE RAND:5
		CASE 1
			PRINTFORML 「いい加減にしないと怒っちゃいますよ…？」
			PRINTFORMW %ANAME(TARGET)%の目は笑っていない…
			CFLAG:好感度 -= 80
		CASE 2
			PRINTFORML 「いやらしい事ばかり考えてちゃダメ、です！」
			PRINTFORMW %ANAME(MASTER)%にびしっ！と指を突きつけた
			CFLAG:好感度 -= 70
		CASE 3
			PRINTFORML 「ふーっ！がおーっ！」
			PRINTFORMW %ANAME(MASTER)%から離れて威嚇している…
			CFLAG:好感度 -= 90
		CASE 4
			PRINTFORML 「い、嫌…！離してええっ！（ぶんっ！）」
			PRINTFORMW %ANAME(TARGET)%の尾が%ANAME(MASTER)%の鼻先を掠めていった…
			CFLAG:好感度 -= 100
		CASEELSE
			PRINTFORML %ANAME(TARGET)%は涙を浮かべて%ANAME(MASTER)%を睨みつけている…
			PRINTFORMW %ANAME(MASTER)%は耐えられずに目をそらした
			CFLAG:好感度 -= 200
		ENDSELECT
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
```
