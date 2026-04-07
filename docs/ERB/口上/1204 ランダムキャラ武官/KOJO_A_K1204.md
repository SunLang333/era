# 口上/1204 ランダムキャラ武官/KOJO_A_K1204.ERB — 自动生成文档

源文件: `ERB/口上/1204 ランダムキャラ武官/KOJO_A_K1204.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K1204, KOJO_TRAIN_END_A1_K1204, KOJO_TRAIN_START_A2_K1204, KOJO_TRAIN_END_A2_K1204, KOJO_COM_BEFORE_TARGET_A_K1204, KOJO_COM_BEFORE_PLAYER_A_K1204, KOJO_COM_A_K1204, KOJO_COM_TARGET_A_K1204, KOJO_COM_PLAYER_A_K1204, KOJO_COM_AFTER_A_K1204; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K1204
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ || CFLAG:400 == 1
	RETURN
ENDIF
;━━━━━━━━━━━━━━━━━━━━

;━━━━━━━━━━━━━━━━━━━━
IF CFLAG:400 == 0
	PRINTFORML 口上を選択してください
	PRINTL [0] 口上を使用しない
	PRINTL [1] 武官口上

	$INPUT_LOOP
	INPUT

	IF RESULT == 0
		PRINTFORMW 口上を使用しません
		CFLAG:400 = 1
		RETURN
	ELSEIF RESULT == 1
		PRINTFORMW 武官口上を使用します
		CFLAG:400 = 2
		PRINTFORML 口上に合わせて素質を変更しますか？
		PRINTFORML （注意　かなり素質が変質します）
		PRINTL [0] 変更しない
		PRINTL [1] 変更する
		$INPUT_LOOP2
		INPUT
		IF RESULT == 0
			PRINTFORMW 素質はそのままで開始します。
			RETURN
		ELSEIF RESULT == 1
			PRINTFORMW 素質を変更します。
			TALENT:痛みに弱い = 0
			TALENT:プライド低い = 0
			TALENT:臆病 = 0
			TALENT:抑圧 = 0

			TALENT:解放 = 1
			TALENT:痛みに強い = 1
			TALENT:プライド高い = 1
		ELSE
			GOTO INPUT_LOOP2
		ENDIF
	ELSE
		GOTO INPUT_LOOP
	ENDIF
ENDIF

;
;
;
;━━━━━━━━━━━━━━━━━━━━
;━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		CALL SINGLE_DRAWLINE
		PRINTFORMW 
		PRINTFORMW 「俺に何かようか？」
		PRINTFORMW 第一声からしてぶっきらぼうである。
		PRINTFORMW 武官としてはいいのだろうが、女としては残念な部類である。
		PRINTFORMW 「交流か、ふむ、まあ同輩と仲を深めるのも一興か」
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「お前か、何の用だ？」
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORMW 「まさか、お前としてしまうとはな……」
	PRINTFORMW 「いいか！　何かあったら、責任だけは取れよ」
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人 
	CFLAG:200 = 4
	PRINTFORMW 「よく来たな、で、恋人同士とはどんなことをするんだ？」
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORMW 「な、なんだ、なんの用だ。動揺？　しとらん！」
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「あー……俺の言葉遣いは、その、嫌いか？」
	PRINTFORMW そのままでいい、と%ANAME(MASTER)%が返答すると、%ANAME(TARGET)%はそうか、とほっとした様子を見せた。

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:4
		CASE 0
			PRINTFORMW 「よお、来てくれたのか」
			PRINTFORMW 「今日は……なんでもいいか。お前がいればいい」
			PRINTFORMW そう言って%ANAME(TARGET)%は楽しそうに笑った。
		CASE 1
			PRINTFORMW 「……どうにもいかんな」
			PRINTFORMW 「うん、どうにもお前が来ると、こう、気が緩むな」
			PRINTFORMW 「いや、来るなと言ってるんじゃない、勘違いしないでくれ」
		CASE 2
			PRINTFORMW 「おっ、来たか、悪いが少し待ってくれ」
			PRINTFORMW 彼女は手際よく剣の手入れをしている。邪魔をすれば首が飛びかねない
			PRINTFORMW 「よし、こんなものか」
			PRINTFORMW 「っと、待たせた。では、今日はどうする」
		CASE 3
			PRINTFORMW 「おっ、今日は他の奴らの所にはいかないのか」
			PRINTFORMW 「そうか、そうか、そいつはいい」
			PRINTFORMW 言いながら、彼女はあなたの手を取り、走り出す。
			PRINTFORMW 「よし、行くぞ%ANAME(MASTER)%！」
	ENDSELECT
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	PRINTFORMW 「今日はどうする？　お前のやりたいことに付き合うぞ」
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人 
	PRINTFORMW 「飯に行くか？　それとも訓練か？」
	PRINTFORMW %ANAME(TARGET)%の選択肢には内政関係は全て捨てられているようだ。
;既成事実Lv1(キス済み)
ELSEIF CFLAG:250 == 1
	PRINTFORMW 「今日は、どうするんだ？」
;既成事実Lv0で恋慕
ELSEIF !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	PRINTFORMW 「お前は、意外と鈍感な奴なのかもしれんな……」
	PRINTFORMW 「いや、なんでもない、こちらの話だ」
;既成事実Lv0
ELSEIF CFLAG:250 < 1
	PRINTFORMW 「また交流か？」
	PRINTFORMW 「それよりも身体を動かさないか？　話してばかりは性に合わん」
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K1204
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ || CFLAG:400 == 1
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	PRINTFORMW 「酔いに負けるとは～」
;快感のあまり気絶 or 気力300以下
ELSEIF TCVAR:52 || BASE:気力 <= 300
	;PRINTFORMW 
;疲労による行動不能
ELSEIF TCVAR:51
	;PRINTFORMW 
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした)
IF CFLAG:201 < 5 && TALENT:合意
	CFLAG:201 = 5
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「こんなに疲れるものとはな」
		PRINTFORMW %ANAME(TARGET)%は奇妙な疲労感に身を任せ、%ANAME(MASTER)%に寄りかかった。
		PRINTFORMW その汗ばんだ体は普段の姿からは想像できないほど女らしい。
	ENDIF
;既成事実Lv2(恋人になった)
ELSEIF CFLAG:201 < 4 && TALENT:恋人 
	CFLAG:201 = 4
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「俺に恋人ができるとはな……」
		PRINTFORMW 「だが、恋人同士はいったい何をする関係なんだ？」
		PRINTFORMW 「まあいい、何をするかはお前と一緒に悩んでいこう」
	ENDIF
;既成事実Lv1(初めてキスをした)
ELSEIF CFLAG:201 < 3 && CFLAG:250 == 1
	CFLAG:201 = 3
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「唇ぐらい、別に、別になんてことは……」
		PRINTFORMW 「ないわけないだろう！　馬鹿！　色魔！」
		PRINTFORMW %ANAME(TARGET)%は普段とは違い、ひどく子供っぽい罵倒をした。よほどキスが衝撃だったらしい。
```
