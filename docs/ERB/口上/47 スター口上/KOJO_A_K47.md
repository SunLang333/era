# 口上/47 スター口上/KOJO_A_K47.ERB — 自动生成文档

源文件: `ERB/口上/47 スター口上/KOJO_A_K47.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K47, KOJO_TRAIN_END_A1_K47, KOJO_TRAIN_START_A2_K47, KOJO_TRAIN_END_A2_K47, KOJO_COM_BEFORE_TARGET_A_K47, KOJO_COM_BEFORE_PLAYER_A_K47, KOJO_COM_A_K47, KOJO_COM_TARGET_A_K47, KOJO_COM_PLAYER_A_K47, KOJO_COM_AFTER_A_K47; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K47
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		PRINTFORMW スター「わ、わ、誰かしら？」
		PRINTFORMW スター「ふーん%ANAME(MASTER)%っていうんですか」
		PRINTFORMW スター「妖精相手にわざわざ自己紹介するなんて珍しい人ですね」　
	ELSE
		PRINTFORMW スター「えーと……誰だったかしら？」
		PRINTFORMW スター「ふーん%ANAME(MASTER)%っていうんですか」
		PRINTFORMW スター「妖精相手にわざわざ名前を教えてくれるなんて珍しい人ですね」　
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意 && TALENT:恋慕
	CFLAG:200 = 5
	PRINTFORMW 　スター「えーと、その･･･」
	PRINTFORMW 　スター(サニーとルナならこんな時なんて言うのかしら…)

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人  && TALENT:恋慕
	CFLAG:200 = 4
	PRINTFORMW スター「こ、こんにちは･･･」
	PRINTFORMW スター(恋人ってどんな感じのことをするのかな…)

;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人  && TALENT:恋慕
	CFLAG:200 = 4
	PRINTFORMW スター「恋人ごっこってどうやるんですか？」
	PRINTFORMW スター「恋人ってどんな感じのことをするのかな」

;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORMW スター「こ、こんにちは･･･」
	PRINTFORMW スター「昨日の…いや！なんでもないです…」

;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:恋慕 && (!TALENT:恋人 && !TALENT:合意 && CFLAG:250 < 1)
	CFLAG:200 = 2
	PRINTFORMW スター「こ、こんにちは･･･」
	PRINTFORMW スター(なんでこんなどきどきするの…平常心平常心…)

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;
;ELSEIF TALENT:合意 && TALENT:正妻
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW スター「お料理にする？お風呂にする？それとも私？」 
			PRINTFORMW スター「じょ、冗談よ冗談！あはは・・・」 
		CASE 1
			PRINTFORMW スター「貴方のためにお料理作っておいたわ」
		CASE 2
			PRINTFORMW スター「今日はずっと私だけを見てね%ANAME(MASTER)%」
	ENDSELECT  
;既成事実Lv3(セックス済み)
;ELSEIF TALENT:合意
	PRINTFORMW スター「…」 
	PRINTFORMW スター「なんだかなー」 
;恋慕　既成事実Lv2～3
ELSEIF TALENT:恋人 || TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW スター「貴方のためにお料理作っておいたわ」
		CASE 1
			PRINTFORMW スター「もう！待ってたのよー」 
			PRINTFORMW スター「貴方が居ないと寂しいからもっと会いに来て下さいよー」
	ENDSELECT 

;恋慕　既成事実Lv0～1
ELSEIF (CFLAG:250 < 1 || CFLAG:250 > 1) && TALENT:恋慕
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW スター「あ、%ANAME(MASTER)%さん！会いに来てくれたんだ！」 
		CASE 1
			PRINTFORMW スター「精力つくような食べ物って何か知ってます？」
			PRINTFORMW スター「いや深い意味は無いんですけど……」
	ENDSELECT 
;既成事実Lv0
ELSEIF CFLAG:250 < 1 && CFLAG:2 < -300
	PRINTFORMW %ANAME(TARGET)%が怯えた目でこちらを見てくる。
ELSEIF CFLAG:250 < 1 && CFLAG:2 < 0
	PRINTFORMW 三人で仲良く遊んでいるようだ。
ELSEIF CFLAG:250 < 1 && CFLAG:2 < 150
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW スター「一緒に遊びます？」
		CASE 1
			PRINTFORMW スター「ええと…誰でしたっけ？」
	ENDSELECT
ELSEIF CFLAG:250 < 1 && CFLAG:2 < 300
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW スター「あ、%ANAME(MASTER)%さんだー」
		CASE 1

			PRINTFORMW スター「よく会いに来てくれますよね、%ANAME(MASTER)%さん。」
			PRINTFORMW スター「もしかして、人間のお友達いないんですか？」
	ENDSELECT
ELSEIF CFLAG:250 < 1 && CFLAG:2 < 500
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW スター「よく会いに来てくれますよね、%ANAME(MASTER)%さん。」
			PRINTFORMW スター「妖精の私にこんなに会いに来てくれるなんて、%ANAME(MASTER)%さんくらいですよ？」

			PRINTFORMW スター「いや嬉しいですけど」

		CASE 1
			PRINTFORMW スター「あ、%ANAME(MASTER)%さんだー」
	ENDSELECT
ELSEIF CFLAG:250 < 1 && CFLAG:2 < 1000
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW スター「来てくれたんですね。さあいつものように一緒に遊びましょう」
		CASE 1
			PRINTFORMW スター「来ると思ったからお料理作って待ってたわ」
		CASE 2
			PRINTFORMW スター「貴方が居ないと退屈なんだからもっと会いに来て下さいよー」
	ENDSELECT
ELSEIF CFLAG:250 < 1 && CFLAG:2 >= 1000
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW スター「来てくれたんですね。さあいつものように一緒に遊びましょう」
		CASE 1
			PRINTFORMW スター「来ると思ったからお料理作って待ってたわ！」
		CASE 2
			PRINTFORMW スター「貴方が居ないと退屈なんだからもっと会いに来て下さいよー」
	ENDSELECT

ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K47
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	;PRINTFORMW 
;快感のあまり気絶
ELSEIF TCVAR:52
	;PRINTFORMW 
;疲労による行動不能
ELSEIF TCVAR:51
	IF RAND:3 == 0
		PRINTFORML スター「も゛～動けない～…」
	ELSEIF RAND:2 == 0
		PRINTFORML スター「もっと優しくしてよ……」
	ELSE 
		PRINTFORML スター「これ以上は一回休みになっちゃう…」
	ENDIF
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした)
IF CFLAG:201 < 5 && TALENT:合意
	CFLAG:201 = 5
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF
;既成事実Lv2(恋人になった)
ELSEIF CFLAG:201 < 4 && TALENT:恋人 
	CFLAG:201 = 4
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW スター(キス、されちゃった…)
	ENDIF
;既成事実Lv1(初めてキスをした)
ELSEIF CFLAG:201 < 3 && CFLAG:250 == 1
```
