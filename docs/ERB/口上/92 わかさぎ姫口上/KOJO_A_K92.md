# 口上/92 わかさぎ姫口上/KOJO_A_K92.ERB — 自动生成文档

源文件: `ERB/口上/92 わかさぎ姫口上/KOJO_A_K92.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K92, KOJO_TRAIN_END_A1_K92, KOJO_TRAIN_START_A2_K92, KOJO_TRAIN_END_A2_K92, KOJO_COM_BEFORE_TARGET_A_K92, KOJO_COM_BEFORE_PLAYER_A_K92, KOJO_COM_A_K92, KOJO_COM_TARGET_A_K92, KOJO_COM_PLAYER_A_K92, KOJO_COM_AFTER_A_K92; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K92
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

IF TALENT:処女
	CFLAG:304 = 1
ENDIF
;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合　好感度にちょっぴりボーナス
	IF !CFLAG:17
		PRINTFORML 
		PRINTFORML 「あ…初めまして、ですね」
		PRINTFORMW %ANAME(TARGET)%の部屋を訪ね、自己紹介を済ませる
		PRINTFORML 
		CFLAG:好感度 += 30

	;既に会ったことがある場合
	ELSE
		PRINTFORML 
		PRINTFORML 「確か…%ANAME(MASTER)%さん、でしたよね」
		PRINTFORML 
	ENDIF
	PRINTFORML 「私の名前は%ANAME(TARGET)%。戦うのは苦手です。ごめんなさい」
	PRINTFORML 「でも、お料理と歌なら少しはお役に立てると思います」
	PRINTFORMW 「足を引っ張らないように気を付けますので…」
	PRINTFORML 
	PRINTFORML %ANAME(TARGET)%は不安げに視線を逸らした。緊張しているようだ
	PRINTFORMW %ANAME(MASTER)%はこれからよろしく、と告げ%ANAME(TARGET)%に手を差し出す
	PRINTFORML 
	PRINTFORML 驚いたような表情の%ANAME(TARGET)%だったが、やがて%ANAME(MASTER)%の手を取り
	PRINTFORML 「はい。こちらこそよろしくお願いします」
	PRINTFORMW 先程よりも少し柔らかい声で答えた
	PRINTFORML 
	PRINTFORMW 
	PRINTFORML %ANAME(TARGET)%からの呼び方を変更できます
	PRINTFORML 
	PRINTFORML [0]名前+さん　（%ANAME(MASTER)%さん）
	PRINTFORML [1]呼び捨て　（%ANAME(MASTER)%）
	PRINTFORML [2]貴方
	$INPUT_LOOP_WAKASAGI_2
	INPUT
	IF RESULT != 0 && RESULT != 1 && RESULT != 2
		GOTO INPUT_LOOP_WAKASAGI_2
	ELSEIF RESULT == 0
		PRINTFORMW %ANAME(MASTER)%さん　に設定しました
	ELSEIF RESULT == 1
		PRINTFORMW %ANAME(MASTER)%　に設定しました
		CFLAG:300 = 1
	ELSEIF RESULT == 2
		PRINTFORMW 貴方　に設定しました
		CFLAG:300 = 2
	ENDIF
	PRINTFORML 
	PRINTFORML %ANAME(TARGET)%の素質を口上に合わせて変更しますか？
	PRINTFORML 
	PRINTFORML [0]いいよ　　（自制心が消えて好奇心がつきます）
	PRINTFORML [1]だめ　　　
	$INPUT_LOOP_WAKASAGI_6
	INPUT
	IF RESULT != 0 && RESULT != 1
		GOTO INPUT_LOOP_WAKASAGI_6
	ELSEIF RESULT == 0
		PRINTFORMW 素質を変更しました
		TALENT:自制心 = 0
		TALENT:好奇心 = 1
	ELSEIF RESULT == 1
		PRINTFORMW 変更せずに始めます
	ENDIF


;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	IF TALENT:恋慕 && TALENT:恋人
		PRINTFORML 「えへへ。捕まえました」
		PRINTFORML %ANAME(MASTER)%の姿を見た%ANAME(TARGET)%はぎゅっと抱きついてきた
		PRINTFORML 「えへへへ。何だかとっても嬉しいんです」
		PRINTFORMW %ANAME(MASTER)%に顔を擦りつけながら%ANAME(TARGET)%は幸せそうに目を細めた

	ELSEIF TALENT:恋慕 || TALENT:恋人 || TALENT:服従 || TALENT:合意
		PRINTFORML 「あ…その、あうう……」
		PRINTFORMW %ANAME(TARGET)%は真っ赤になってうつむいている…

	ELSE
		PRINTFORMW %ANAME(TARGET)%は恨めしそうに%ANAME(MASTER)%を睨んでいる…
	ENDIF
	PRINTFORML 
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人 
	CFLAG:200 = 4
	IF TALENT:恋慕
		PRINTFORML 「だ～れだっ♪」
		PRINTFORML 声とともに%ANAME(MASTER)%の目がふさがれた
		PRINTFORML 「さあ、私は誰でしょう？分かりますかあ」
		PRINTFORMW 
		PRINTFORML %ANAME(TARGET)%だ。と%ANAME(MASTER)%が答えると
		PRINTFORML %ANAME(MASTER)%を解放してその頬にキスしてきた
		PRINTFORML 「正解のごほうびですよ。えへへ…」
		PRINTFORML 
		PRINTFORMW （ふふっ、嬉しいなあ…）

	ELSE
		PRINTFORML 「恋人どうし…なんですよね。手をつなぎます？」
		PRINTFORML お互いの手を握ると、どちらからともなく笑みがこぼれる
		PRINTFORMW 「何だかいいですね。こういうの」

	ENDIF
	PRINTFORML 
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	IF TALENT:恋慕
		PRINTFORML 「ちゅー…しちゃいましたね…」
		PRINTFORMW 「今日も、します…か……？」

	ELSEIF CFLAG:好感度 >= 500
		PRINTFORMW %ANAME(TARGET)%は顔を赤くしてちらちらとこちらを見ている…

	ELSE
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%と目を合わそうとしない…

	ENDIF
	PRINTFORML 
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	;CFLAG:200 = 2
	;PRINTFORML 「」
	;PRINTFORMW 

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;恋慕かつ恋人
ELSEIF TALENT:恋慕 && TALENT:恋人
	SELECTCASE RAND:6
		CASE 1
			PRINTFORMW 「できれば毎日でも会いたいですけど…わがままですね」
		CASE 2
			PRINTFORML 「おかえりなさい。お風呂？ご飯？それとも…わ・た・し・なんちゃって、きゃー！（バシーンバシーン）」
			PRINTFORMW %ANAME(TARGET)%は一人で身もだえている…
		CASE 3
			PRINTFORMW 「おかえりなさーい。んー。…何ってただいまのちゅーですよお！ほら、んー」
		CASE 4
			PRINTFORML 「あ、ちょうどいいところに！ほら、新しいお料理に挑戦してみたんですよ」
			PRINTFORMW 「どうですか。…おいしい？やったあ♪」
		CASE 5
			PRINTFORMW 「えいっ。抱きついちゃいます。あらら、赤くなっちゃって…可愛いです♪」
		CASEELSE
			GOTO RENBO_WAKASAGI_3
	ENDSELECT

;恋慕または恋人
ELSEIF TALENT:恋慕 || TALENT:恋人 || TALENT:服従
	$RENBO_WAKASAGI_3
	SELECTCASE RAND:5
		CASE 1
			PRINTFORMW 「私にご用ですか？お任せください」
		CASE 2
			PRINTFORMW 「今、お昼ご飯作ってるのでよかったらどうぞ。座って待っててくださいね」
		CASE 3
			PRINTFORMW 「えへへへ。いっぱいお話しましょうね」
		CASE 4
			PRINTFORMW 「たまには二人でおでかけ、なんてどうですか？きっと楽しいですよお！」
		CASEELSE
			PRINTFORMW 「頑張ったらいっぱい褒めてください。なでなでがいいです」
	ENDSELECT

;好感度200未満
ELSEIF CFLAG:好感度 <= 199
	SELECTCASE RAND:3
		CASE 1
			PRINTFORMW 「あ…こんにちは」
		CASE 2
			PRINTFORMW 「えっと、お話ですか？」
		CASEELSE
			PRINTFORMW 「まだちょっと…怖いです」
	ENDSELECT

;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	SELECTCASE RAND:4
		CASE 1
			PRINTFORMW 「うう…じろじろ見ないでください…」
		CASE 2
```
