# 口上/28 鈴仙口上/KOJO_A_K28.ERB — 自动生成文档

源文件: `ERB/口上/28 鈴仙口上/KOJO_A_K28.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K28, KOJO_TRAIN_END_A1_K28, KOJO_TRAIN_START_A2_K28, KOJO_TRAIN_END_A2_K28, KOJO_COM_BEFORE_TARGET_A_K28, KOJO_COM_BEFORE_PLAYER_A_K28, KOJO_COM_A_K28, KOJO_COM_TARGET_A_K28, KOJO_COM_PLAYER_A_K28, KOJO_COM_AFTER_A_K28, SEX_VOICEK28_00, SEX_VOICEK28_01, SEX_VOICEK28_02, SEX_VOICEK28_03, SEX_VOICEK28_04; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K28
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
		;PRINTFORMW 
	;既に会ったことがある場合
	ELSE
		;PRINTFORML
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻か妾
ELSEIF CFLAG:200 < 7 && TALENT:正妻 || CFLAG:200 < 7 && TALENT:妾
	CFLAG:200 = 7;婚姻した次の回フラグ
	;PRINTFORMW 
;親愛か隷属
ELSEIF CFLAG:200 < 6 && TALENT:親愛 || CFLAG:200 < 6 && TALENT:隷属
	CFLAG:200 = 6;親愛か隷属になった次の回フラグ
	;PRINTFORMW 
;既成事実Lv3(初めてセックスをした次の回)＆恋慕持ち
ELSEIF CFLAG:200 < 5 && TALENT:合意
	CFLAG:200 = 5
	IF TALENT:恋慕
			;PRINTFORMW 
	ELSE
			;PRINTFORMW 
	ENDIF
;既成事実Lv2(恋人になった次の回)
ELSEIF CFLAG:200 < 4 && TALENT:恋人
	CFLAG:200 = 4
	;PRINTFORMW 
;既成事実Lv1(初めてキスをした次の回)
ELSEIF CFLAG:200 < 3 && !TALENT:キス未経験 && CFLAG:250 > 1
	CFLAG:200 = 3
	;PRINTFORMW 
;既成事実Lv0で恋慕
ELSEIF CFLAG:200 < 2 && TALENT:キス未経験 && TALENT:恋慕 && CFLAG:250 < 1
	CFLAG:200 = 2
	;PRINTFORMW 

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;正妻か妾　思いつかなければ親愛のコピペでよい
ELSEIF TALENT:正妻 || TALENT:妾
	;ランダムで口上が変化する（使わない場合はすべて同じにすればよい）
	SELECTCASE RAND:3
		CASE 0
			;PRINTFORMW 
		CASE 1
			;PRINTFORMW 
		CASE 2
			;PRINTFORMW 
	ENDSELECT
;親愛か隷属　思いつかなければ恋慕のコピペでよい
ELSEIF TALENT:親愛 || TALENT:隷属
	SELECTCASE RAND:3
		CASE 0
			;PRINTFORMW 
		CASE 1
			;PRINTFORMW 
		CASE 2
			;PRINTFORMW 
	ENDSELECT
;既成事実Lv3かつ恋慕
ELSEIF TALENT:合意 && TALENT:恋慕
	SELECTCASE RAND:3
		CASE 0
			;PRINTFORMW 
		CASE 1
			;PRINTFORMW 
		CASE 2
			;PRINTFORMW 
	ENDSELECT
;既成事実Lv3(セックス済み)
ELSEIF TALENT:合意
	SELECTCASE RAND:2
		CASE 0
			;PRINTFORMW 
		CASE 1
			;PRINTFORMW 
	ENDSELECT
;既成事実Lv2(恋人)
ELSEIF TALENT:恋人
	SELECTCASE RAND:2
		CASE 0
			;PRINTFORMW 
		CASE 1
			;PRINTFORMW 
	ENDSELECT
;既成事実Lv1(キス済み)
ELSEIF !TALENT:キス未経験 && CFLAG:250 < 1
	SELECTCASE RAND:2
		CASE 0
			;PRINTFORMW 
		CASE 1
			;PRINTFORMW 
	ENDSELECT
;既成事実Lv0で恋慕
ELSEIF !TALENT:恋人 && TALENT:恋慕 && !TALENT:合意 && CFLAG:250 < 1
	;PRINTFORMW 
;既成事実Lv0
ELSEIF TALENT:キス未経験 && CFLAG:250 < 1
	;PRINTFORMW 
ENDIF

;=================================================
;●「会いに行く」の終了時のセリフ
;=================================================
@KOJO_TRAIN_END_A1_K28
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能　現状死に分岐
IF TCVAR:53 == 1
	;PRINTFORMW 
;快感のあまり気絶　現状死に分岐
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
		;初めてセックスをしたときに恋慕かどうか
		IF TALENT:恋慕
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
		;恋人になったときに恋慕かどうか
		IF TALENT:恋慕
			;PRINTFORMW 
		ELSE
			;PRINTFORMW 
		ENDIF
	ENDIF
;既成事実Lv1(初めてキスをした)
ELSEIF CFLAG:201 < 3 && CFLAG:250 > 1 && !TALENT:キス未経験 
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
	;正妻か妾　思いつかなければ親愛のコピペでよい
	IF TALENT:正妻 || TALENT:妾
		SELECTCASE RAND:3
			CASE 0
				;PRINTFORMW 
			CASE 1
				;PRINTFORMW 
			CASE 2
				;PRINTFORMW 
		ENDSELECT
	;親愛か隷属　思いつかなければ恋慕のコピペでよい
	ELSEIF TALENT:親愛 || TALENT:隷属
		SELECTCASE RAND:3
```
