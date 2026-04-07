# 口上/1206 ランダムキャラ文官/KOJO_A_K1206.ERB — 自动生成文档

源文件: `ERB/口上/1206 ランダムキャラ文官/KOJO_A_K1206.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K1206, KOJO_TRAIN_END_A1_K1206, KOJO_TRAIN_START_A2_K1206, KOJO_TRAIN_END_A2_K1206, KOJO_COM_BEFORE_TARGET_A_K1206, KOJO_COM_BEFORE_PLAYER_A_K1206, KOJO_COM_A_K1206, KOJO_COM_TARGET_A_K1206, KOJO_COM_PLAYER_A_K1206, KOJO_COM_AFTER_A_K1206; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K1206
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ || CFLAG:400 == 1
	RETURN
ENDIF
;━━━━━━━━━━━━━━━━━━━━

;━━━━━━━━━━━━━━━━━━━━
IF CFLAG:400 == 0
	PRINTFORML 口上を選択してください
	PRINTL [0] 口上を使用しない
	PRINTL [1] 文官口上 

	$INPUT_LOOP
	INPUT

	IF RESULT == 0
		PRINTFORMW 口上を使用しません
		CFLAG:400 = 1
		RETURN
	ELSEIF RESULT == 1
		PRINTFORMW 文官口上を使用します
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
			TALENT:反抗的 = 0
			TALENT:プライド高い = 0
			TALENT:恥薄い = 0

			TALENT:処女 = 1
			TALENT:素直 = 1
			TALENT:恥じらい = 1
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
		PRINTFORMW 「おや、どちらさまです？」
		PRINTFORMW 「同じ陣営の？　へえ、これはどうも」
		PRINTFORMW そう言いながら儀礼的な礼をする姿は、典型的な文官である。
		PRINTFORMW だが、探るような目を隠せない辺りは、腹芸は出来ない口らしい。
		PRINTFORMW 「それで、何かご用ですか？」
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 「何か、ご用ですか？」
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORMW 「………顔を見ないでください」
	PRINTFORMW 「なんだか、恥ずかしいので」
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人 
	CFLAG:200 = 4
	PRINTFORMW 「不思議な気分です」
	PRINTFORMW 「特に何が変わったわけではないのですが」
	PRINTFORMW 「どうしてでしょう、ね」
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORMW 「…………」
	PRINTFORMW %ANAME(TARGET)%は落ち着かない様子で、 %ANAME(MASTER)%を見つめている。
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「今日もわたしに会いに来たんですか？」
	PRINTFORMW 「変わった人ですね、 %ANAME(MASTER)%は……」
	PRINTFORMW そう言いながら、%ANAME(TARGET)%は嬉しそうに %ANAME(MASTER)%を見つめている。

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:4
		CASE 0
			PRINTFORMW 「……いえ、なんだか、幸せだなーって思って」
			PRINTFORMW そう言って%ANAME(TARGET)%は恥ずかしげに微笑している。
		CASE 1
			PRINTFORMW 「……………」
			PRINTFORMW 「あ、ごめんなさい。今日は来ないのかなと思っていまして……」
			PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%が来たことに気が付くと、読みかけの本を閉じ、微笑んだ。
		CASE 2
			PRINTFORMW 「あの、ちょっとの間でいいので、抱きしめてもらえませんか？」
			PRINTFORMW %ANAME(MASTER)%は頷き、%ANAME(TARGET)%を優しく抱き寄せた。%ANAME(MASTER)%の身体に身を預け、%ANAME(TARGET)%は幸せそうにしている。
			PRINTFORMW しばらくして、%ANAME(MASTER)%は%ANAME(TARGET)%を解放した。%ANAME(TARGET)%は名残惜しげな顔をして、%ANAME(MASTER)%を見つめている。
		CASE 3
			PRINTFORMW 「今日は、いい日です」
			PRINTFORMW 「多忙な貴方がわたしに時間を割いてくれました。だから」
			PRINTFORMW 「今日は、いい日です。そうでしょう？」
			PRINTFORMW そう言い切ると、%ANAME(TARGET)%はふわっと笑った。
	ENDSELECT
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	PRINTFORMW 「今日はどこに連れて行ってくれますか？」
	PRINTFORMW %ANAME(TARGET)%は目を輝かせながら、 %ANAME(MASTER)%を見つめている。
	PRINTFORMW 「でも、あんまりスケベなことはしないでくださいよ」
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人 
	PRINTFORMW 「今日はどこに連れて行ってくれますか？」
	PRINTFORMW %ANAME(TARGET)%は目を輝かせながら、 %ANAME(MASTER)%を見つめている。
	PRINTFORMW すでに%ANAME(TARGET)%の予定は出かけることで埋められているようだ。
;既成事実Lv1(キス済み)
ELSEIF CFLAG:250 == 1
	PRINTFORMW 「おや、また来てくれましたか。今日はどうします？」
;既成事実Lv0で恋慕
ELSEIF !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	PRINTFORMW 「会いに来てくれるのは嬉しいのですが……」
	PRINTFORMW 「いや、会いに来ないで欲しいわけでもないです、はい」
	PRINTFORMW %ANAME(TARGET)%は少しだけ寂しそうな表情で、 %ANAME(MASTER)%に微笑んだ。
;既成事実Lv0
ELSEIF CFLAG:250 < 1
	PRINTFORMW 「おや、ごきげんよう。何かご用ですか？」
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K1206
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
		PRINTFORMW 「やっちゃった……」
		PRINTFORMW 気だるい疲労感。そして奇妙な幸福感、%ANAME(TARGET)%は小さくため息を吐いた。
	ENDIF
;既成事実Lv2(恋人になった)
ELSEIF CFLAG:201 < 4 && TALENT:恋人 
	CFLAG:201 = 4
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「今日は、手でも繋いで帰りますか？」
		PRINTFORMW %ANAME(TARGET)%ははにかみながら、 %ANAME(MASTER)%に手を差し出している。
		PRINTFORMW 差し出された手を %ANAME(MASTER)%が握ると、%ANAME(TARGET)%はこれ以上にないほど顔を赤らめた。
	ENDIF
;既成事実Lv1(初めてキスをした)
ELSEIF CFLAG:201 < 3 && CFLAG:250 == 1
	CFLAG:201 = 3
	;行動不能ならフラグだけ立てて表示はしない
```
