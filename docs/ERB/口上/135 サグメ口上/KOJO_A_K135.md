# 口上/135 サグメ口上/KOJO_A_K135.ERB — 自动生成文档

源文件: `ERB/口上/135 サグメ口上/KOJO_A_K135.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K135, KOJO_TRAIN_END_A1_K135, KOJO_TRAIN_START_A2_K135, KOJO_TRAIN_END_A2_K135, KOJO_COM_BEFORE_TARGET_A_K135, KOJO_COM_BEFORE_PLAYER_A_K135, KOJO_COM_A_K135, KOJO_COM_TARGET_A_K135, KOJO_COM_PLAYER_A_K135, KOJO_COM_AFTER_A_K135, SAGUMEHANYOUAEGIANAL; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K135
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
		PRINTFORMW  サグメに会いに行くとぼうっと窓辺に座っていた。
		PRINTFORMW  銀髪赤眼の彼女は深い切れ込みの入った紫色のスカートに白銀の翼という出で立ちで何か用かと尋ねてくる。
		PRINTFORMW  「何？」
		PRINTFORMW  彼女はこちらに気づくと興味深げに見つめてきた。
		PRINTFORMW  「………」
		PRINTFORMW  「地上人、あまり私に関わらない方がいいわ」
		PRINTFORMW  「私は稀神サグメ、一応名乗っておくけど、忘れていい」
		PRINTFORMW  「私の能力は喋った事象を逆転させる」
		PRINTFORMW  「………」
		PRINTFORMW  「だから、あまり口に出したくない」
		PRINTFORMW  「………」
		PRINTFORMW  「どうしてもというのなら話ぐらいは聞いてあげる」
	;既に会ったことがある場合
	ELSE
		PRINTFORMW  サグメに会いに行くとぼうっと窓辺に座っていた。
		PRINTFORMW  銀髪赤眼の彼女は深い切れ込みの入った紫色のスカートに白銀の翼という出で立ちで何か用かと尋ねてくる。
		PRINTFORMW  「何？」
		PRINTFORMW  彼女はこちらに気づくと興味深げに見つめてきた。
		PRINTFORMW  「………」
		PRINTFORMW  「地上人、あまり私に関わらない方がいいわ」
		PRINTFORMW  「知ってるかもしれないけど私の能力は喋った事象を逆転させる」
		PRINTFORMW  「………」
		PRINTFORMW  「だから、あまり口に出したくない」
		PRINTFORMW  「………」
		PRINTFORMW  「どうしてもというのなら話ぐらいは聞いてあげる」
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------

;■正妻や親愛系で特に台詞が思いつかなければ、この行から…■
;正妻か妾
ELSEIF (CFLAG:200 < 7) && (TALENT:正妻 || TALENT:妾)
	;婚姻した次の回フラグ
	CFLAG:200 = 7
	PRINTFORMW 「！」
	PRINTFORMW 「元気そうね、%ANAME(MASTER)%」
	PRINTFORMW サグメはそう言って挨拶をしてきた。
	
;親愛か隷属
ELSEIF (CFLAG:200 < 6) && (TALENT:親愛 || TALENT:隷属)
	;親愛か隷属になった次の回フラグ
	CFLAG:200 = 6
	PRINTFORMW 「…！」
	PRINTFORMW サグメはこちらに気づくと近寄ってきた。
	PRINTFORMW 「こんにちは、%ANAME(MASTER)%」
;■この行まで消しても良い■

;既成事実Lv3(初めてセックスをした次の回)＆恋慕持ち
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORMW 「？」
		PRINTFORMW 「今日は、何するの？」
		PRINTFORMW サグメはそう言いながらゆっくりと寄ってくる。
		PRINTFORMW 「なんでも、いいよ」
	;それ以外
	ELSE
		PRINTFORMW 「？」
		PRINTFORMW 「今日は、何するの？」
		PRINTFORMW サグメはそう言いながらゆっくりと寄ってくる。
		PRINTFORMW 「なんでも、いいよ」
	ENDIF
	
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	;恋慕時の台詞。思いつかなければ「それ以外」と一緒でよい
	IF TALENT:恋慕
		PRINTFORMW 「…」
		PRINTFORMW サグメは無言でこちらを凝視している。
		PRINTFORMW 「何するの？」
		PRINTFORMW サグメは顔を赤らめながら首を傾げている。
	;それ以外
	ELSE
		PRINTFORMW 「…」
		PRINTFORMW サグメは無言でこちらを凝視している。
		PRINTFORMW 「何するの？」
		PRINTFORMW サグメは顔を赤らめながら首を傾げている。
	ENDIF
	
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && !TALENT:キス未経験 && CFLAG:250 > 1
	CFLAG:200 = 3
	PRINTFORMW 「…！」
	PRINTFORMW サグメは%ANAME(MASTER)%が入ってくると胸元の蝶ネクタイを直し始めた。
	PRINTFORMW 「で、何？」
	
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:キス未経験 && TALENT:恋慕 && CFLAG:250 < 1
	CFLAG:200 = 2
	PRINTFORMW 「…こんにちは」
	PRINTFORMW サグメは挨拶をしてきた。

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;正妻か妾　思いつかなければ親愛のコピペでよい
ELSEIF TALENT:正妻 || TALENT:妾
	;ランダムで口上が変化する（使わない場合はすべて同じにすればよい）
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW 「今日も来てくれたのね、嬉しいわ」
		CASE 1
			PRINTFORMW 「…愛してるわ、%ANAME(MASTER)%」
		CASE 2
			PRINTFORMW 「今日は…何をしてくれるのかしら？」
	ENDSELECT
	
;親愛か隷属　思いつかなければ恋慕のコピペでよい
ELSEIF TALENT:親愛 || TALENT:隷属
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW 「…会いに…来てくれたの…？」
		CASE 1
			PRINTFORMW 「会いたかったわ、%ANAME(MASTER)%…」
		CASE 2
			PRINTFORMW 「…会えて嬉しいわ」
	ENDSELECT
	
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW 「今日も来てくれたのね、嬉しいわ」
		CASE 1
			PRINTFORMW 「…愛してるわ、%ANAME(MASTER)%」
		CASE 2
			PRINTFORMW 「今日は…何をしてくれるのかしら？」
	ENDSELECT
	
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW 「…会いに…来てくれたの…？」
		CASE 1
			PRINTFORMW 「会いたかったわ、%ANAME(MASTER)%…」
		CASE 2
			PRINTFORMW 「…会えて嬉しいわ」
	ENDSELECT
	
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW 「今日は、何を？」
		CASE 1
			PRINTFORMW 「…%ANAME(MASTER)%、何か用？」
		CASE 2
			PRINTFORMW 「今日はどうしたの？」
	ENDSELECT
	
;既成事実Lv1(キス済み)
ELSEIF !TALENT:キス未経験 && CFLAG:250 > 1
	SELECTCASE RAND:2
		CASE 0
			PRINTFORMW 「……どうも」
		CASE 1
			PRINTFORMW 「……何か用かしら？」
	ENDSELECT
	
;既成事実Lv0で恋慕
ELSEIF !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	PRINTFORMW 「………」
	PRINTFORMW サグメは%ANAME(MASTER)%に気づくと羽をパタパタさせている。
	
;既成事実Lv0
ELSEIF TALENT:キス未経験 && CFLAG:250 < 1
	PRINTFORMW 「………」
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K135
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
```
