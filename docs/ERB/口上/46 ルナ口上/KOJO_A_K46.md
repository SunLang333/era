# 口上/46 ルナ口上/KOJO_A_K46.ERB — 自动生成文档

源文件: `ERB/口上/46 ルナ口上/KOJO_A_K46.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K46, KOJO_TRAIN_END_A1_K46, KOJO_TRAIN_START_A2_K46, KOJO_TRAIN_END_A2_K46, KOJO_COM_BEFORE_TARGET_A_K46, KOJO_COM_BEFORE_PLAYER_A_K46, KOJO_COM_A_K46, KOJO_COM_TARGET_A_K46, KOJO_COM_PLAYER_A_K46, KOJO_COM_AFTER_A_K46; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K46
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
		PRINTFORML 「何か用ですかぁ？」
	;既に会ったことがある場合
	ELSE
		IF TALENT:烙印
			PRINTFORML 「ひっ」
			PRINTFORML 「き、今日は、なな何のご用でしょうか」
			PRINTFORMW ルナチャイルドは%ANAME(MASTER)%に怯えているようだ……
		ELSE
			PRINTFORML 「何か用ですかぁ？」
		ENDIF
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした次の回)
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	PRINTFORML 「……あ、いらっしゃい」
	PRINTFORML %ANAME(MASTER)%が部屋に入ると、ルナチャイルドは前回のことについて話し出した
	PRINTFORML 「正直、妖精の私が%ANAME(MASTER)%とあんなことをするなんて思わなかったわ」
	PRINTFORMW 「でも、不思議とイヤな気分じゃないかも……」
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	PRINTFORML 「あら、いらっしゃい」
	PRINTFORML 「……恋人って何かもっと特別な対応した方がいいのかしら？」
	PRINTFORMW %ANAME(MASTER)%はルナチャイルドに無理はするなと言った
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && CFLAG:250 == 1
	CFLAG:200 = 3
	PRINTFORML 「あ……いらっしゃい」
	PRINTFORML 前回キスをしたせいか、ルナチャイルドの態度は少しぎこちない
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:恋慕 && (!TALENT:恋人 && !TALENT:合意 && CFLAG:250 < 1)
	CFLAG:200 = 2
	;PRINTFORMW 

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	PRINTFORML 「あっ、来てくれたのね」
	PRINTFORML 「どこに座る？椅子？それともベッドがいいかな。あっ、お茶淹れなきゃ」
	PRINTFORMW ルナチャイルドも、随分と気安くなったものだ。とても微笑ましい
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	PRINTFORML 「あ……いらっしゃい」
	PRINTFORML （今日も、その……する、のかなぁ。いや、用があるだけかも……）
	PRINTFORMW ルナチャイルドはモジモジしている……
;既成事実Lv2(恋人)
;キス経験は上がらない
ELSEIF TALENT:恋人 
	PRINTFORML 「あっ、来てくれたのね」
	PRINTFORML %ANAME(MASTER)%が来訪すると、ルナチャイルドはキスで出迎えてくれた
	PRINTFORMW 「んっ……どう？恋人っぽかったかしら」
;既成事実Lv1(キス済み)
ELSEIF CFLAG:250 == 1
	PRINTFORML 「ああ、いらっしゃい」
	PRINTFORML 最初と比べると、ルナチャイルドの態度が気安くなった気がする
;既成事実Lv0で恋慕
ELSEIF TALENT:恋慕 && (!TALENT:恋人 && !TALENT:合意 && CFLAG:250 < 1)
	PRINTFORML 「あ……お茶淹れますね」
	PRINTFORML %ANAME(MASTER)%が来訪すると、ルナチャイルドは苦いコーヒーを淹れてくれた。彼女の好みらしい
;既成事実Lv0
ELSEIF CFLAG:250 < 1
	PRINTFORML 「今日は何の用ですかぁ？」
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K46
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	PRINTFORML 「すー……すー……」
	PRINTFORML ルナチャイルドは酔いつぶれて眠っている……
;快感のあまり気絶
ELSEIF TCVAR:52
	PRINTFORML 「――……――……」
	PRINTFORML ルナチャイルドは白目を剥き、ぱくぱくと呼吸だけをしている……
;疲労による行動不能
ELSEIF TCVAR:51
	PRINTFORML 「た、立てない……このまま置いていかないでー……」
	PRINTFORML %ANAME(MASTER)%は疲れ切ったルナチャイルドを、ベッドに寝かせてやった
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;既成事実Lv3(初めてセックスをした)
IF CFLAG:201 < 5 && TALENT:合意
	CFLAG:201 = 5
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		IF TALENT:処女
			;PRINTFORMW 
		ELSE
			;PRINTFORMW 
		ENDIF
	ENDIF
;既成事実Lv2(恋人になった)
ELSEIF CFLAG:201 < 4 && TALENT:恋人 
	CFLAG:201 = 4
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORML 「また来てくれるよね……？」
	ENDIF
;既成事実Lv1(初めてキスをした)
ELSEIF CFLAG:201 < 3 && CFLAG:250 == 1
	CFLAG:201 = 3
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
;行動不能なら非表示
ELSEIF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
	;既成事実Lv3かつ恋慕
	IF TALENT:合意 && TALENT:恋慕
		;PRINTFORMW 
	;既成事実Lv3(セックス済み)
	ELSEIF TALENT:合意
		;PRINTFORMW 
	;既成事実Lv2(恋人)
	ELSEIF TALENT:恋人 
		PRINTFORML 「また来てくれるよね……？」
	;既成事実Lv1(キス済み)
	ELSEIF CFLAG:250 == 1 
		;PRINTFORMW 
	;既成事実Lv0で恋慕
	ELSEIF TALENT:恋慕 && (!TALENT:恋人 && !TALENT:合意 && CFLAG:250 < 1)
		;PRINTFORMW 
	;既成事実Lv0
	ELSEIF CFLAG:250 < 1
		PRINTFORML 「じゃあ、さようなら」
	ENDIF
ENDIF

;=================================================
;●「閨に呼ぶ」の開始時のセリフ ※単独で呼ばれた場合のみ呼ばれる
;=================================================
@KOJO_TRAIN_START_A2_K46
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;=================================================
;●「閨に呼ぶ」の終了時のセリフ ※単独で呼ばれた場合のみ呼ばれる
;=================================================
@KOJO_TRAIN_END_A2_K46
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;酒酔いによる行動不能
IF TCVAR:53 == 1
	;PRINTFORMW 
;快感のあまり気絶 or 気力300以下
ELSEIF TCVAR:52 || BASE:気力 <= 300
	PRINTFORML 「――……――……」
	PRINTFORML ルナチャイルドは白目を剥き、ぱくぱくと呼吸だけをしている……
;疲労による行動不能
ELSEIF TCVAR:51
	PRINTFORML 「た、立てない……このまま置いていかないでー……」
	PRINTFORML %ANAME(MASTER)%は疲れ切ったルナチャイルドを、ベッドに寝かせてやった
```
