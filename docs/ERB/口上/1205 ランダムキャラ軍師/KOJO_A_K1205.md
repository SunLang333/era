# 口上/1205 ランダムキャラ軍師/KOJO_A_K1205.ERB — 自动生成文档

源文件: `ERB/口上/1205 ランダムキャラ軍師/KOJO_A_K1205.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K1205, KOJO_TRAIN_END_A1_K1205, KOJO_TRAIN_START_A2_K1205, KOJO_TRAIN_END_A2_K1205, KOJO_COM_BEFORE_TARGET_A_K1205, KOJO_COM_BEFORE_PLAYER_A_K1205, KOJO_COM_A_K1205, KOJO_COM_TARGET_A_K1205, KOJO_COM_PLAYER_A_K1205, KOJO_COM_AFTER_A_K1205; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K1205
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ || CFLAG:400 == 1
	RETURN
ENDIF
IF CFLAG:400 == 0
	PRINTFORML 口上を選択してください
	PRINTL [0] 口上を使用しない
	PRINTL [1] 軍師口上 

	$INPUT_LOOP
	INPUT

	IF RESULT == 0
		PRINTFORMW 口上を使用しません
		CFLAG:400 = 1
		RETURN
	ELSEIF RESULT == 1
		PRINTFORMW 軍師口上を使用します
		CFLAG:400 = 2
		PRINTFORML 口上に合わせて素質を変更しますか？
		PRINTFORML (注意　素質がかなり変質します）
		PRINTL [0] 変更しない
		PRINTL [1] 変更する
		$INPUT_LOOP2
		INPUT
		IF RESULT == 0
			PRINTFORMW 素質はそのままで開始します。
			RETURN
		ELSEIF RESULT == 1
			PRINTFORMW 素質を変更します。
			TALENT:反抗的 = 0
			TALENT:プライド高い = 0
			TALENT:恥薄い = 0
			TALENT:解放 = 0

			TALENT:処女 = 1
			TALENT:プライド低い = 1
			TALENT:臆病 = 1
			TALENT:抑圧 = 1
		ELSE
			GOTO INPUT_LOOP2
		ENDIF
	ELSE
		GOTO INPUT_LOOP
	ENDIF
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		CALL SINGLE_DRAWLINE
		PRINTFORMW 
		PRINTFORMW 「こ、これは、どうも、ええ、はい、ええと」
		PRINTFORMW 「ど、どちらさまです？」
		PRINTFORMW %ANAME(TARGET)%は涙目で、絞り出すような声で言った。言葉の続かない人の典型である。
		PRINTFORMW %ANAME(MASTER)%は自身の名を名乗ると、ただ、雑談をしに来たと伝えた。
		PRINTFORMW 「ざ、雑談？　私と？」
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「ああ、これは、これ、ええっと……%ANAME(MASTER)%殿」
		PRINTFORMW 確実に名を思い出そうとした間があった。
		PRINTFORMW 意思疎通の苦手な者である。あえて追求しない情けが%ANAME(MASTER)%にも存在した。
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORMW 「あ、あんなことするなんて、へ、変態……」
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人 
	CFLAG:200 = 4
	PRINTFORMW 「ま、待ちましたか？　で、恋人とは、どういうことをす、するんですか？」
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORMW 「あ、あの、あの、ええと、その、なんというか……」
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「……い、いえ、いえ、ただ、貴方は輝いているような、き、気がして……」


;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:4
		CASE 0
			PRINTFORMW 「ふぁぁあああ……」
			PRINTFORMW %ANAME(TARGET)%は大きなあくびをしながらぼんやりとしている。
			PRINTFORMW 眠たげな目が%ANAME(MASTER)%を認識すると、%ANAME(TARGET)%は眠たげな表情のまま%ANAME(MASTER)%に近づき、身体を寄せた。
			PRINTFORMW 「ああ、貴方だぁ……」
		CASE 1
			PRINTFORMW 「あ、あの、私と一緒にいて、た、楽しいですか？」
			PRINTFORMW %ANAME(MASTER)%は、返答の代わりに%ANAME(TARGET)%の手を取り、頷いた。
			PRINTFORMW 「き、恐縮です」
		CASE 2
			PRINTFORMW 「ま、待ってました」
			PRINTFORMW %ANAME(TARGET)%はそう言って、%ANAME(MASTER)%に微笑んだ。
			PRINTFORMW 「きょ、今日はどうしましょうか？」
		CASE 3
			PRINTFORMW 「……不思議ですね。い、以前は一人の方が気楽だったのですが……」
			PRINTFORMW 「い、今は貴方と一緒にいたい、と思っています……」
			PRINTFORMW %ANAME(TARGET)%はそう言って、恥ずかしそうに頬を赤らめている。
	ENDSELECT
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	PRINTFORMW 「……貴方は、」
	PRINTFORMW %ANAME(TARGET)%は、何か言いたげな様子で、%ANAME(MASTER)%をじっと見ている。
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人 
	PRINTFORMW 「あ、きょ、今日は来る日、でしたか？」
	PRINTFORMW 「い、いえ、嫌なわけでは、ただ、心の準備が、少し……」
;既成事実Lv1(キス済み)
ELSEIF CFLAG:250 == 1
	PRINTFORMW 「む、無理に来なくていいんですよ、独りは、な、慣れているので」
;既成事実Lv0で恋慕
ELSEIF !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	PRINTFORMW 「…………」
	PRINTFORMW （この人は、何が目的で私の所にきているんだろう？）
	PRINTFORMW （ただの友達扱いだけ、では苦しい……）
;既成事実Lv0
ELSEIF CFLAG:250 < 1
	PRINTFORMW 「へ、あれ、ま、また来られたんですか」
	PRINTFORMW 「いえ、いえ、かんげ、歓迎します」
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K1205
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ || CFLAG:400 == 1
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
		PRINTFORMW 「……つもりはなかったんだけどなぁ……」
	ENDIF
;既成事実Lv2(恋人になった)
ELSEIF CFLAG:201 < 4 && TALENT:恋人 
	CFLAG:201 = 4
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「あ、あの、改めて、こ、これからも、よ、よろしくお願いします」
	ENDIF
;既成事実Lv1(初めてキスをした)
ELSEIF CFLAG:201 < 3 && CFLAG:250 == 1
	CFLAG:201 = 3
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「き、今日のことは、あの、じ、事故のようなもの、ですよね？」
		PRINTFORMW 「た、互いに犬にでも噛まれたとでも、お、思いましょう、ね？」
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
;行動不能なら非表示
ELSEIF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
	;既成事実Lv3かつ恋慕
	IF TALENT:合意 && TALENT:恋慕
		PRINTFORMW 「あ、あの、もう少しだけ一緒にいても、い、いいですか？」
```
