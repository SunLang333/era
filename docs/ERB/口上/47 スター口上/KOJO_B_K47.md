# 口上/47 スター口上/KOJO_B_K47.ERB — 自动生成文档

源文件: `ERB/口上/47 スター口上/KOJO_B_K47.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_B_K47, KOJO_TRAIN_END_B_K47, KOJO_COM_BEFORE_TARGET_B_K47, KOJO_COM_BEFORE_PLAYER_B_K47, KOJO_COM_B_K47, KOJO_COM_TARGET_B_K47, KOJO_COM_PLAYER_B_K47, KOJO_COM_AFTER_B_K47; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜調教」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_B_K47
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
		;PRINTFORMW 
	;既に会ったことがある場合
	ELSE
		;PRINTFORMW 
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;恋慕または服従を獲得した
ELSEIF CFLAG:202 < 3 && (TALENT:恋慕 || TALENT:服従)
	CFLAG:202 = 3
	;PRINTFORMW 
;依存度が300以上になった
ELSEIF CFLAG:202 < 2 && CFLAG:3 >= 300
	CFLAG:202 = 2
	;PRINTFORMW 

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;恋慕 or 服従
ELSEIF TALENT:恋慕 || TALENT:服従
	;PRINTFORMW 
;依存度が300以上
ELSEIF CFLAG:3 >= 300
	;PRINTFORMW 
;それ以外
ELSE
	;PRINTFORMW 
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_B_K47
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
	;PRINTFORMW 
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;初めて依存度が300以上になった
IF CFLAG:203 < 2 && CFLAG:2 >= 300
	CFLAG:203 = 2
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF
;初回
ELSEIF CFLAG:203 < 1
	CFLAG:203 = 1
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
;行動不能なら非表示
ELSEIF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		;PRINTFORMW 
	;依存度が300以上
	ELSEIF CFLAG:3 >= 300
		;PRINTFORMW 
	;それ以外
	ELSE
		;PRINTFORMW 
	ENDIF
ENDIF

;=================================================
;●コマンド実行前(このキャラがターゲット側のとき)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;=================================================
@KOJO_COM_BEFORE_TARGET_B_K47
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

RETURN 0

;=================================================
;●コマンド実行前(このキャラがプレイヤー側のとき)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_PLAYERの代わりに使う
;=================================================
@KOJO_COM_BEFORE_PLAYER_B_K47
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

RETURN 0

;=================================================
;●コマンド実行時(このキャラがプレイヤーでもターゲットでも呼び出される)
;  プレイヤー・ターゲットの区別がないコマンドはここに口上を記述する
;=================================================
@KOJO_COM_B_K47
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

;-------------------------------------------------
;キス
;-------------------------------------------------
IF SELECTCOM == 20
	;ファーストキス
	IF TALENT:キス未経験
		;恋慕 or 服従
		IF TALENT:恋慕 || TALENT:服従
			PRINTFORMW 「実はファーストキスだったんですよ。えへへ…」

		;それ以外
		ELSE
			PRINTFORMW スター「やぁっ！やだやだやめて！変態！ロリ――んむぅっ」 
			PRINTFORMW %ANAME(MASTER)%は激しく抵抗するスターを押さえつけ無理矢理唇を奪った
			PRINTFORMW 「初めてだったのに……ひぐっ……もっと……素敵なのが良かったのに……」

		ENDIF
	;キス経験済み
	ELSE
		;恋慕 or 服従
		IF TALENT:恋慕 || TALENT:服従
			PRINTFORMW スター「ちゅっ………ん………」
		;依存度300以上
		ELSEIF CFLAG:3 >= 300
			SELECTCASE RAND:2
				CASE 0
					PRINTFORMW スター「ふむぅ………んぐ～」
					PRINTFORMW スター(臭い………気持ち悪い………)
				CASE 1
					PRINTFORMW スター「 んん………やっ………ぷ…っ………ゴクッ……… 」
			ENDSELECT

		;それ以外
		ELSE
			SELECTCASE RAND:3
				CASE 0
					PRINTFORMW スター「ん゛ー！ん゛ー！」
					PRINTFORMW スターは目の端に涙を溜めながらもがいている。
				CASE 1
					PRINTFORMW スター「んぶっ！んぐぐ…あむっ」
					PRINTFORMW スター「～～～～～～～～～～～！！」
					PRINTFORMW %ANAME(MASTER)%はスターに口移しで痰を飲ませた
					PRINTFORMW スター「オ…エ゛ッ…………」

				CASE 2
					PRINTFORMW スター「んぅ………」
					PRINTFORMW スターは露骨に嫌そうな顔をしている


			ENDSELECT

		ENDIF
	ENDIF
	RETURN 0
```
