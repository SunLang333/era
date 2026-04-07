# 口上/135 サグメ口上/KOJO_B_K135.ERB — 自动生成文档

源文件: `ERB/口上/135 サグメ口上/KOJO_B_K135.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_B_K135, KOJO_TRAIN_END_B_K135, KOJO_COM_BEFORE_TARGET_B_K135, KOJO_COM_BEFORE_PLAYER_B_K135, KOJO_COM_B_K135, KOJO_COM_TARGET_B_K135, KOJO_COM_PLAYER_B_K135, KOJO_COM_AFTER_B_K135; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜調教」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_B_K135
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:202 == 0
	CFLAG:202 = 1
	;初対面の場合
	IF !CFLAG:17
	PRINTFORMW 「…」
	PRINTFORMW 「……」
	PRINTFORMW 「………」
	PRINTFORMW 「…たとえ何があっても私が貴方に屈することなど無いわ」
	PRINTFORMW 「下賎な地上人の慰み者に成り下がるつもりはありません」
	PRINTFORMW 「精々粋がる事ですね」
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「…悪夢だわ」
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;恋慕または服従を獲得した
ELSEIF CFLAG:202 < 3 && (TALENT:恋慕 || TALENT:服従)
	CFLAG:202 = 3
	PRINTFORMW 「…」
	PRINTFORMW 「……」
	PRINTFORMW サグメはぼうっとこちらを見ながら何か考えている
	PRINTFORMW 「…」
	PRINTFORMW 「……」
	PRINTFORMW 「………」
	PRINTFORMW 何も言わずにサグメは抱きついてきた
	PRINTFORMW 「…」
	PRINTFORMW 「好きです…」
	PRINTFORMW 「…あ、貴方のことが…忘れられなくて…」
	PRINTFORMW 「%ANAME(MASTER)%…私を…見て…」
	PRINTFORMW 「貴方となら…どこまでも堕ちてもいい、貴方となら誰に弓を引くことになってもかまわない」
	PRINTFORMW 「%ANAME(MASTER)%…私は貴方のことが好きなの」
	PRINTFORMW 「だから…どうか私と―――」
	PRINTFORMW 「―――ずっと一緒に―――」
;依存度が300以上になった
ELSEIF CFLAG:202 < 2 && CFLAG:3 >= 300
	CFLAG:202 = 2
	PRINTFORMW 「ん…ああ…」
	PRINTFORMW 「もう…好きにすればいいじゃない…」
	PRINTFORMW 「…変態…」

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;恋慕 or 服従
ELSEIF TALENT:恋慕 || TALENT:服従
	IF RAND:4 == 0
		PRINTFORMW 「…では、よろしくお願いします」
		PRINTFORMW 「私はこういう事、慣れてないから…相も変わらず下手だと思うから…」
		PRINTFORMW 「だから…リードして、下さい…」
	ELSEIF RAND:3 == 0
		PRINTFORMW 「ごきげんよう今日も元気そうね」
		PRINTFORMW 「…こういうの、うまくいえないけど」
		PRINTFORMW 「………気持よく…してね…」
		PRINTFORMW 「………」
		PRINTFORMW 「………ダメ？」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「………」
		PRINTFORMW 「…このまま貴方と永遠に居られるのならどれほど嬉しいことか…」
	ELSE
		PRINTFORMW 「…」
		PRINTFORMW 「……」
		PRINTFORMW 「………」
		PRINTFORMW 「………優しくしてね？」
	ENDIF
;依存度が300以上
ELSEIF CFLAG:3 >= 300
	IF RAND:2 == 0
		PRINTFORMW 「ああ、貴方ですか…」
		PRINTFORMW 「さあ、狂宴を始めましょう…？」
	ELSE
		PRINTFORMW 「おはよう…」
		PRINTFORMW 「どうするの？さっさと始めないの？」
		PRINTFORMW 「まぁ…貴方の好きにすればいいわ」
	ENDIF
;それ以外
ELSE
	IF RAND:2 == 0
		PRINTFORMW 「………」
		PRINTFORMW 「…頼むから…優しく…」
	ELSE
		PRINTFORMW 「………」
	ENDIF
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_B_K135
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	IF RAND:3 == 0
		PRINTFORMW 「うう…飲みすぎ…」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「んん…気分悪い…」
	ELSE
		PRINTFORMW 「…うぇ…」
	ENDIF
;快感のあまり気絶
ELSEIF TCVAR:52
	PRINTFORMW 「ん～～～%UNICODE(0x2665) *1%%UNICODE(0x2665) *1%%UNICODE(0x2665) *1%」
	PRINTFORMW サグメは快感のあまりぐったりしている。
;疲労による行動不能
ELSEIF TCVAR:51
	IF RAND:3 == 0
		PRINTFORMW  「…疲れた…」
	ELSEIF RAND:2 == 0
		PRINTFORMW  「はぁ…いつもこんなことを…」
	ELSE
		PRINTFORMW  「…疲れたわね」
	ENDIF
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;初めて依存度が300以上になった
IF CFLAG:203 < 2 && CFLAG:2 >= 300
	CFLAG:203 = 2
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
			PRINTFORMW 「もう…終わり…？」
	ENDIF
;初回
ELSEIF CFLAG:203 < 1
	CFLAG:203 = 1
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
			PRINTFORMW 「…」
			PRINTFORMW サグメは未だ気丈にこちらを睨みつけている。
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
;行動不能なら非表示
ELSEIF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
			IF RAND:3 == 0
				PRINTFORMW 「終わり？」
				PRINTFORMW 「………」
				PRINTFORMW 「ねえ…もう少し…このままで…」
				PRINTFORMW （この人と…一緒なら…）
			ELSEIF RAND:2 == 0
				PRINTFORMW 「あ…」
				PRINTFORMW 「これで…終わり…？」
				PRINTFORMW （次は…もっとうまく…）
			ELSE
				PRINTFORMW 「あ…今日は終わり？」
				PRINTFORMW 「いや…なんでもない…」
			ENDIF
	;依存度が300以上
	ELSEIF CFLAG:3 >= 300
			IF RAND:2 == 0
				PRINTFORMW 「私がいなくても…問題なければ…いいのだけれど…」
			ELSE
				PRINTFORMW 「まぁこういう状況を受け入れて楽しむのも一つの策なのでしょうけど」
				PRINTFORMW 「どうにもこうにも忌避意識が…受け入れられませんね」
				PRINTFORMW 「いっそ楽には…してくれないんでしょうね…」
			ENDIF
	;それ以外
	ELSE
		IF RAND:2 == 0
			PRINTFORMW 「…何？」
			PRINTFORMW 「…大人しくしていれば…優しくしてくれるの？」
			PRINTFORMW サグメは虚ろな目でそう問いかけてきた
		ELSE
			PRINTFORMW 「…」
			PRINTFORMW （抵抗するだけ無駄なのだろうか…）
		ENDIF
	ENDIF
ENDIF

```
