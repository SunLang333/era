# 口上/11 フランドール口上/_KOJO_EVENT_K11.ERB — 自动生成文档

源文件: `ERB/口上/11 フランドール口上/_KOJO_EVENT_K11.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K11; UI/print

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
@KOJO_EVENT_K11(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「んっ……」
		PRINTFORML 「……その、これ」
		PRINTFORMW 「私の、ファーストキス……だから」
	;恋人
	ELSEIF TALENT:恋人
		PRINTFORML 「んっ……」
		PRINTFORML 「……ファーストキスだよ。私の、ね」
		PRINTFORMW 「……へへっ。ちゃんと好きな人にできて嬉しいな」
	;それ以外
	ELSE
		PRINTFORML 「んっ……」
		PRINTFORMW 「何さ。したくなったからしただけだよ」
		PRINTFORMW 「好意とか、そういうのじゃない。勘違いはしないで」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「………」
		PRINTFORMW %ANAME(MASTER)%の告白を受けた%ANAME(TARGET)%は、しばらく固まっていた
		PRINTFORMW 「……一つだけ聞かせて」
		PRINTFORML 「私は、どうしようもない狂気を孕んでる」
		PRINTFORMW 「殺すことを厭わない。そうしようと思えばすぐ実行に移す吸血鬼」
		PRINTFORML 「もし私が%ANAME(MASTER)%を受け入れたら、%ANAME(MASTER)%は一生をこの狂気と過ごすことになる」
		PRINTFORML 「悪魔の妹とそういう関係にあるという事実は、いつまでも%ANAME(MASTER)%について回る」
		PRINTFORMW 「そうだとしても、%ANAME(MASTER)%は……」
		PRINTFORMW %ANAME(TARGET)%が言い切るより先に、%ANAME(MASTER)%は「構わない」と答えた
		PRINTFORML 「……いい、ん、だね？」
		PRINTFORMW 「全てのリスクを理解して、私に気持ちを伝えてくれるんだね？」
		PRINTFORML 目尻に涙を浮かべて%ANAME(TARGET)%は問う
		PRINTFORMW %ANAME(MASTER)%は先と変わらぬ決意を持って頷いた
		PRINTFORML 「……っっ！！」
		PRINTFORMW 「やっと……やっと、言える、言って、いいんだ……！」
		PRINTFORML 「いつからは分からない……だけど、%ANAME(MASTER)%を私はずっと好きだった」
		PRINTFORMW 「でも、言えなかった。言えるわけ、なかった」
		PRINTFORML 「狂った吸血鬼に好かれてるって分かった%ANAME(MASTER)%が、どんな行動を取るのか……」
		PRINTFORMW 「それを想像すると、とても怖かったから……だから、言えなかった」
		PRINTFORML 「でも、もう秘密にするのはやめる。私は%ANAME(MASTER)%を受け入れる」
		PRINTFORMW 「好きです。私と付き合ってください、%ANAME(MASTER)%」
	;それ以外
	ELSE
		PRINTFORMW 「……覚悟は、できてるんだよね」
		PRINTFORMW 「その想いを遂げるなら、%ANAME(MASTER)%は一生私という狂気を背負うことになる」
		PRINTFORMW 「この十字架は重いよ。自分で言うのもなんだけど」
		PRINTFORMW 「一度だけチャンスをあげる。引き返すなら今だよ」
		PRINTFORMW 「……と思ったけど、引き下がりそうにないね」
		PRINTFORMW 「わかった。%ANAME(MASTER)%の想い、受け入れるよ」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「……ダメだよ」
		PRINTFORMW 「私は狂った悪魔。%ANAME(MASTER)%とは、釣り合わない」
		PRINTFORML 「……ごめん。でも、どうしても受け入れられない」
		PRINTFORMW 「受け入れるだけの資格が、ない」
	ELSE
		PRINTFORML 「寝言は寝て言ってよ」
		PRINTFORMW 「それとも、今ここで永遠に眠ってみる？」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTFORML 「……もしかして、これが狙いだった？」
	PRINTFORMW 「ま、酒のせいということにしておいてあげる」
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「あっ……」
		PRINTFORMW 意外にも、何の抵抗もなく%ANAME(TARGET)%は押し倒された
		PRINTFORML 「……いつかは、こうなるかなって思ってたから」
		PRINTFORML 「いいよ。%ANAME(MASTER)%になら、全部曝してあげる」
		PRINTFORMW 「だから……優しくね？」
	;それ以外
	ELSE
		PRINTFORML 「ふーん……シたいの？」
		PRINTFORML 「こんな貧相な身体に欲情するなんて。好奇者だね」
		PRINTFORMW 「いいよ。欲望の捌け口になってあげる」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML %ANAME(TARGET)%を押し倒そうとしたが、やんわりと止められた
		PRINTFORMW 「ごめん。そういうことをする気分じゃない」
	ELSE
		PRINTFORML %ANAME(TARGET)%を押し倒そうとすると、背中に激痛が走った
		PRINTFORMW どうやら壁まで投げ飛ばされたらしい
		PRINTFORML 「他の人の目があるから殺しはしない」
		PRINTFORMW 「だけど覚えておけ。私はいつでも、お前を殺せる」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「うん、いいよ」
		PRINTFORMW 「また気持ちよくさせて？」
	;それ以外
	ELSE
		PRINTFORML 「……はぁ」
		PRINTFORML 「こんな身体のどこがいいんだか」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;:体力限界(通常)
;-------------------------------------------------
IF ARG == 11
	;恋人 or 服従
	IF TALENT:恋人 || TALENT:服従
		PRINTFORML 「ちょっとはしゃぎすぎたかな」
		PRINTFORMW 「抱き枕になってくれてもいいんだよ？」
	;それ以外
	ELSE
		PRINTFORMW 「疲れた……もう寝る」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;気力限界(通常)
;-------------------------------------------------
IF ARG == 12
	PRINTFORMW 「も……だめ、疲れた……」
	RETURN 0
ENDIF

;-------------------------------------------------
;怒りの限界で追い返される
;-------------------------------------------------
IF ARG == 13
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		PRINTFORML 「ごめん、今日は帰って」
		PRINTFORML 「%ANAME(MASTER)%を壊しかねないからさ」
	;それ以外
	ELSE
		PRINTFORML 「……帰れ」
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;哀しみの限界で追い返される
;-------------------------------------------------
IF ARG == 14
	PRINTFORMW 「……今日は一人にさせて」
	RETURN 0
ENDIF

;-------------------------------------------------
;怒りの限界で勝手に帰る
;-------------------------------------------------
```
