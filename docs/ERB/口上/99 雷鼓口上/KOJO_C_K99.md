# 口上/99 雷鼓口上/KOJO_C_K99.ERB — 自动生成文档

源文件: `ERB/口上/99 雷鼓口上/KOJO_C_K99.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_C_K99, KOJO_TRAIN_END_C_K99, KOJO_COM_BEFORE_TARGET_C_K99, KOJO_COM_BEFORE_PLAYER_C_K99, KOJO_COM_C_K99, KOJO_COM_TARGET_C_K99, KOJO_COM_PLAYER_C_K99, KOJO_COM_AFTER_C_K99; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜逆調教(通常)」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_C_K99
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:204 == 0
	CFLAG:204 = 1
	PRINTFORMW 「あらあら、随分面白いことになったわね」
	PRINTFORMW 「お姉さんがいいことシてあげる…%UNICODE(0x2665) *1%」

;-------------------------------------------------
;2回目以降
;-------------------------------------------------
ELSE
	IF RAND:3 == 0
		PRINTFORMW 「あら、%ANAME(MASTER)%、元気そうね%UNICODE(0x2665) *1%」
		PRINTFORMW 雷鼓は妖艶な笑みを浮かべて部屋に入ってくる。
	ELSEIF RAND:2 == 0
		PRINTFORMW 「%ANAME(MASTER)%、入るわよ」
		PRINTFORMW 「…今日は何してあげようかしら？」
	ELSE
		PRINTFORMW 「%ANAME(MASTER)%、逃げ出したりしてないわよね～？」
		PRINTFORMW 雷鼓はにこやかに部屋に入ってきた。
	ENDIF
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_C_K99
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	IF RAND:3 == 0
		PRINTFORMW 「うっぷ…飲み過ぎたわ…」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「んん…飲み過ぎで気分悪い…」
	ELSE
		PRINTFORMW 「…うぇ…吐きそう…」
	ENDIF
;快感のあまり気絶
ELSEIF TCVAR:52
	PRINTFORMW 「～～～%UNICODE(0x2665) *1%%UNICODE(0x2665) *1%%UNICODE(0x2665) *1%」
	PRINTFORMW 雷鼓は快感のあまりぐったりしている。
;疲労による行動不能
ELSEIF TCVAR:51
	IF RAND:3 == 0
		PRINTFORMW  「…疲れちゃった…」
	ELSEIF RAND:2 == 0
		PRINTFORMW  「はぁ…流石に疲れたわね…」
	ELSE
		PRINTFORMW  「う～ん…疲れた…」
	ENDIF
;主人公が酒酔いによる行動不能
ELSEIF TCVAR:MASTER:53 == 1
	IF RAND:3 == 0
		PRINTFORMW  「おーい…潰れちゃった？」
	ELSEIF RAND:2 == 0
		PRINTFORMW  「飲み過ぎじゃないの？」
	ELSE
		PRINTFORMW  「大丈夫～？お水飲む？」
	ENDIF
;主人公が快感のあまり気絶
ELSEIF TCVAR:MASTER:52
	IF RAND:3 == 0
		PRINTFORMW  「…そんなに気持ちよかったのかな…」
	ELSEIF RAND:2 == 0
		PRINTFORMW  「大丈夫？ちゃんと起きれる？」
	ELSE
		PRINTFORMW  「ふふっ…かわいいかも…%UNICODE(0x2665) *1%」
	ENDIF
;主人公が疲労による行動不能
ELSEIF TCVAR:MASTER:51
	IF RAND:3 == 0
		PRINTFORMW  「もしも～し？起きてる～？」
	ELSEIF RAND:2 == 0
		PRINTFORMW  「まったくもう、体力ないのねえ」
	ELSE
		PRINTFORMW  「みっちりしごきすぎたかしら？」
	ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
ELSEIF CFLAG:205 < 1
	PRINTFORMW 「はーい、じゃあこれまでね%UNICODE(0x2665) *1%」

;-------------------------------------------------
;2回目以降
;-------------------------------------------------
ELSE
	IF RAND:3 == 0
		PRINTFORMW 「今日はこれで終わりね%UNICODE(0x2665) *1%」
	ELSEIF RAND:2 == 0
		PRINTFORMW 「%ANAME(MASTER)%、今日はもう終わりにしてあげるわ」
	ELSE
		PRINTFORMW 「%ANAME(MASTER)%、逃げ出したらだめよ～？」
	ENDIF
ENDIF

;-------------------------------------------------
;初回なら進行度を増加
;-------------------------------------------------
IF CFLAG:205 < 1
	CFLAG:205 = 1
ENDIF

;=================================================
;●コマンド実行前(このキャラがターゲット側のとき)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;=================================================
@KOJO_COM_BEFORE_TARGET_C_K99
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
@KOJO_COM_BEFORE_PLAYER_C_K99
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

RETURN 0

;=================================================
;●コマンド実行時(このキャラがプレイヤーでもターゲットでも呼び出される)
;  プレイヤー・ターゲットの区別がないコマンドはここに口上を記述する
;=================================================
@KOJO_COM_C_K99
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
		PRINTFORMW 「んちゅ…ん…」
		PRINTFORMW 「はぁ…ん…」
		PRINTFORMW 雷鼓は情熱的にキスをする。
		PRINTFORMW 首に手を回し、唇を押し付け舌を入れようとしてくる。
		PRINTFORMW 「ぷはぁ…キス…ご馳走様♪」
		PRINTFORMW そういうと雷鼓は首に回した手をゆっくりと解いていった。
	;キス経験済み
	ELSE
		PRINTFORMW 「ん～！」
		PRINTFORMW 「ぷはっ…ん…%UNICODE(0x2665) *1%」
		PRINTFORMW 雷鼓は唇が離れると名残惜しそうに唇に指を添えた。
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;貝合わせ
;-------------------------------------------------
IF SELECTCOM == 21
	;PRINTFORMW 
	RETURN 0
ENDIF

;-------------------------------------------------
;双頭バイブ
;-------------------------------------------------
IF SELECTCOM == 22
	;このキャラと主人公が共に処女
	IF EXP:TARGET:Ｖ性交経験 == 1 && EXP:MASTER:Ｖ性交経験 == 1
		;PRINTFORMW 
	;このキャラのみ処女
	ELSEIF EXP:TARGET:Ｖ性交経験 == 1
		;PRINTFORMW 
```
