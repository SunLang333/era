# 口上/09 咲夜口上/STARTEND_K9/KOJO_D_TOP_ETC_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/STARTEND_K9/KOJO_D_TOP_ETC_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_D_K9, KOJO_TRAIN_END_D_K9; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●「捕虜逆調教(外来勢力に捕まった場合)」開始時
;─────────────────────────────────────── 
@KOJO_TRAIN_START_D_K9
#DIM 咲夜_対象
#DIM 咲夜

咲夜_対象 = MASTER
咲夜 = NAME_TO_CHARA("咲夜")

;咲夜口上の使用可否設定と初期化
SIF CFLAG:咲夜:400 == 0
	CALL KOJO_ASK_RESET_K9

;口上を使用しない設定なら戻る
SIF CFLAG:咲夜:400 == 1
	RETURN 0

SETCOLOR 咲夜_口上カラー

;─────────────────────────────────────── 
;○初回
;─────────────────────────────────────── 
IF CFLAG:咲夜:206 == 0

	;捕虜逆調教(外来)口上初回呼び出しフラグオン
	CFLAG:咲夜:206 = 1

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:咲夜:虚ろ
		IF IS_MALE(咲夜_対象)
			PRINTFORML 「……う……んぁ……❤　おちんぽぉ……❤　ちんぽ……」
		ELSE
			PRINTFORML 「う、んぁ……❤　おんなの、こ……くちゅくちゅ、ってぇ……あ、あ❤」
		ENDIF
		PRINTFORMDL %ANAME(咲夜)%は虚ろな瞳で近付いてきた……
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常
	;───────────────────────────────────── 
	PRINTFORML 「あら。%CALLNAME_K9(咲夜_対象)%じゃない……ふふっ。ふっ、くふ、アハハっ」
	PRINTFORML 「会えて嬉しいわ。ねぇ？　助けに来てくれたのでしょう」
	PRINTFORMW 「私？　もちろん助けに来たわ……あなただとは知らなかったけれど、ね？」
	PRINTL 
	IF IS_MALE(咲夜_対象)
		PRINTFORML 「あいつらに散々玩具にされたんでしょう？　%CALLNAME_K9(咲夜_対象)%」
		PRINTFORML 「大事なおちんぽが腫れっぱなしで苦しいわよね」
	ELSE
		PRINTFORML 「あいつらに散々玩具にされたんでしょう？　%CALLNAME_K9(咲夜_対象)%」
		PRINTFORML 「大事な女の子もお尻の穴も、腫れっぱなしで苦しいわよね」
	ENDIF
	PRINTFORMDL %ANAME(咲夜_対象)%の知る%ANAME(咲夜)%に声も姿も良く似ていたが
	PRINTFORMDW 息を乱して薄ら笑いを浮かべるその表情に瀟洒な面影は欠片も見当たらない
	PRINTL 
	PRINTFORML 「今助けてあげるわ……❤」
	PRINTFORMDL %ANAME(咲夜_対象)%の股座にぽたぽたと涎を垂らしながら尻を振る彼女は
	PRINTFORMDL 交尾をねだる一匹の牝犬へと変貌していた……

;─────────────────────────────────────── 
;○二回目以降
;─────────────────────────────────────── 
ELSE

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:咲夜:虚ろ
		IF IS_MALE(咲夜_対象)
			PRINTFORML 「……う……んぁ……❤　おちんぽぉ……❤　ちんぽ……」
		ELSE
			PRINTFORML 「う、んぁ……❤　おんなの、こ……くちゅくちゅ、ってぇ……あ、あ❤」
		ENDIF
		PRINTFORMDL %ANAME(咲夜)%は虚ろな瞳で近付いてきた……
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常
	;───────────────────────────────────── 
	PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、私を待っていてくれたかしら」
	PRINTFORML 「私は待っていたわ。とても素敵だったもの。また素敵になれるでしょう？」
	PRINTFORML 「ふふっ……❤　さあ、早くセックスしましょう？」
ENDIF

;終了
WAIT
RESETCOLOR
RETURN 0

;─────────────────────────────────────── 
;●「捕虜逆調教(外来)」終了
;─────────────────────────────────────── 
@KOJO_TRAIN_END_D_K9
#DIM 咲夜_対象
#DIM 咲夜

咲夜_対象 = MASTER
咲夜 = NAME_TO_CHARA("咲夜")

;口上を使用しない設定なら戻る
SIF CFLAG:咲夜:400 == 1
	RETURN 0

SETCOLOR 咲夜_口上カラー

PRINTL 

;─────────────────────────────────────── 
;行動不能
;─────────────────────────────────────── 
;離脱済み
IF TCVAR:咲夜:53 > 1
	RESETCOLOR
	RETURN 0
ENDIF

IF TALENT:咲夜:虚ろ
	PRINTFORML 「う……んん……」
	PRINTFORMDL %ANAME(咲夜)%は%ANAME(咲夜_対象)%が立ち去ろうとしていることに気付いていないようだ……
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

;酒酔いによる行動不能
IF TCVAR:咲夜:53 == 1
	PRINTFORML 「んはぁ……もうらめ……気持ちいいわぁ❤」
	PRINTFORMDL %ANAME(咲夜)%はぐでんぐでんになって赤ら顔をにやつかせながら寝ている
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

;快感のあまり気絶
IF TCVAR:咲夜:52 || BASE:咲夜:気力 <= 300
	PRINTFORML 「んう……ぁふ❤　ふあぁ……」
	PRINTFORMDL %ANAME(咲夜)%はくったりした手足を時々ぴくつかせて、恍惚と笑んでいる……
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

;疲労による行動不能
IF TCVAR:咲夜:51
	PRINTFORML 「う……んん……」
	PRINTFORMDL %ANAME(咲夜)%は疲れ果てた顔で眠っている……
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

;─────────────────────────────────────── 
;主人公の行動不能
;─────────────────────────────────────── 
IF TALENT:咲夜_対象:虚ろ
	PRINTFORML 「いいわ、そのままぼんやりしていて❤」
	PRINTFORML 「私の……あっ❤　こんなあさましい姿も、はぁっ、あ❤　忘れてっ」
	IF IS_MALE(咲夜_対象)
		PRINTFORML 「そのほうが、私もっ……ちんぽっ❤　あっ、はあぁぁあんっ❤　ちんぽぉっ❤」
	ELSE
		PRINTFORML 「そのほうが、私もっ……あはぁあっ❤　気持ちいいっ❤　おあぁっ❤」
	ENDIF
	PRINTFORMDL %ANAME(咲夜)%は虚ろな瞳の%ANAME(咲夜_対象)%にいつまでも体を絡ませ続けている
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

;酒酔いによる行動不能
IF TCVAR:咲夜_対象:53
	PRINTFORML 「いいわ、全部お酒のせいよ。あっ、はっ❤」
	PRINTFORML 「私の……あっ❤　こんなあさましい姿も、はぁっ、あ❤　忘れてっ」
	IF IS_MALE(咲夜_対象)
		PRINTFORML 「そのほうが、私もっ……ちんぽっ❤　あっ、はあぁぁあんっ❤　ちんぽぉっ❤」
	ELSE
		PRINTFORML 「そのほうが、私もっ……あはぁあっ❤　気持ちいいっ❤　おあぁっ❤」
	ENDIF
	PRINTFORMDL %ANAME(咲夜)%は酔い潰れた%ANAME(咲夜_対象)%にいつまでも体を絡ませ続けている
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

;快感のあまり気絶
IF TCVAR:咲夜_対象:52 || BASE:咲夜_対象:気力 <= 300
	PRINTFORML 「いいわ、そのままバカになるまでイきっぱなしになって❤」
	PRINTFORML 「私の……あっ❤　こんなあさましい姿も、はぁっ、あ❤　忘れてっ」
	IF IS_MALE(咲夜_対象)
		PRINTFORML 「そのほうが、私もっ……ちんぽっ❤　あっ、はあぁぁあんっ❤　ちんぽぉっ❤」
	ELSE
		PRINTFORML 「そのほうが、私もっ……あはぁあっ❤　気持ちいいっ❤　おあぁっ❤」
	ENDIF
```
