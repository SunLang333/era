# 口上/134 ドレミー口上/KOJO_B_K134.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/KOJO_B_K134.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_B_K134, KOJO_TRAIN_END_B_K134, KOJO_COM_BEFORE_TARGET_B_K134, KOJO_COM_BEFORE_PLAYER_B_K134, KOJO_COM_B_K134, KOJO_COM_TARGET_B_K134, KOJO_COM_PLAYER_B_K134, KOJO_COM_AFTER_B_K134; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜調教」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_B_K134
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ || CFLAG:400 == 1
	RETURN
ENDIF
IF CFLAG:400 == 0
	PRINTFORML 口上を選択してください
	PRINTFORML 
	PRINTFORML ※この口上は「あなた（男）」を前提に書いています
	PRINTFORML それ以外のキャラだと齟齬が生じるかもしれません
	PRINTFORML 
	PRINTL [0] 口上を使用しない
	PRINTL [1] ドレミー口上 (※捕虜調教系の口上はほぼないです)

	$INPUT_LOOP
	INPUT

	IF RESULT == 0
		PRINTFORMW 口上を使用しません
		CFLAG:400 = 1
		RETURN
	ELSEIF RESULT == 1
		PRINTFORMW ドレミー口上を使用します
		PRINTFORMW 長い文が入る時もあるので鬱陶しくなったら右クリックですっ飛ばしてください
		PRINTFORMW (恋慕などが付くとセリフが変わります、とういうか恋慕などの場合とそうでない場合の気合の差がスゴイ事に…)
		CFLAG:400 = 2
		PRINTFORMW 
		PRINTFORML ところでドレミーさんを処女に戻して良いでしょうか？
				;割かしピュアなドレミーさんを作ってしまったので
		PRINTL [0] だめだめだめ
		PRINTL [1] わたしは一向にかまわんッッ 
		$INPUT_LOOP2
		INPUT
		IF RESULT == 0
			PRINTFORMW 素質はそのままで開始します
			RETURN
		ELSEIF RESULT == 1
			PRINTFORMW …素質を変更します
			TALENT:処女 = 1
		ELSE
			GOTO INPUT_LOOP2
		ENDIF
	ELSE
		GOTO INPUT_LOOP
	ENDIF
	PRINTL 
	PRINTW ……………………
	PRINTW …………
	PRINTW ……
	PRINTL 
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
@KOJO_TRAIN_END_B_K134
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
@KOJO_COM_BEFORE_TARGET_B_K134
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
@KOJO_COM_BEFORE_PLAYER_B_K134
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

RETURN 0

;=================================================
;●コマンド実行時(このキャラがプレイヤーでもターゲットでも呼び出される)
;  プレイヤー・ターゲットの区別がないコマンドはここに口上を記述する
;=================================================
@KOJO_COM_B_K134
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
```
