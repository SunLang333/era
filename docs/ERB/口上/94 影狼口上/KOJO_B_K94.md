# 口上/94 影狼口上/KOJO_B_K94.ERB — 自动生成文档

源文件: `ERB/口上/94 影狼口上/KOJO_B_K94.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_B_K94, KOJO_TRAIN_END_B_K94, KOJO_COM_BEFORE_TARGET_B_K94, KOJO_COM_BEFORE_PLAYER_B_K94, KOJO_COM_B_K94, KOJO_COM_TARGET_B_K94, KOJO_COM_PLAYER_B_K94, KOJO_COM_AFTER_B_K94; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜調教」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_B_K94
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
		PRINTFORMW 影狼の繋がれている牢へ入った
		PRINTFORMW あなたが入ってくるのを見ると、警戒するように耳を立てながら唸った
		PRINTFORMW そして強い口調でここから出せと怒りの声を上げる
		PRINTFORMW 抗議を無視し暴れる彼女を押さえつけ、調教に邪魔なボロ服を引き裂き裸にひん剥いた
		PRINTFORMW 裸になった彼女は両手で体を多い微かに震えながら、何が目的だと問う
		PRINTFORMW 調教と答えると、一瞬ひるんだ様だがすぐにキッと睨み付けてきた
		PRINTFORMW これは調教のし甲斐がありそうだ
		PRINTFORMW さて、どうしようか
	;既に会ったことがある場合
	ELSE
		PRINTFORMW 影狼の繋がれている牢へ入った
		PRINTFORMW あなたが入ってくるのを見ると、警戒するように耳を立てながら唸った
		PRINTFORMW そして強い口調でここから出せと怒りの声を上げる
		PRINTFORMW 抗議を無視し暴れる彼女を押さえつけ、調教に邪魔な服を引き裂き裸にひん剥いた
		PRINTFORMW 裸になった彼女は両手で体を多い微かに震えながら、何が目的だと問う
		PRINTFORMW 調教と答えると、一瞬ひるんだ様だがすぐにキッと睨み付けてきた
		PRINTFORMW これは調教のし甲斐がありそうだ
		PRINTFORMW さて、どうしようか
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;恋慕を獲得した
ELSEIF CFLAG:202 < 3 && TALENT:恋慕
	CFLAG:202 = 3
	PRINTFORMW 影狼の繋がれている牢へ入った
	PRINTFORMW あなたが入ってくるのを見ると、嬉しそうに近づいてきた
	PRINTFORMW 調教の開始だと告げると大人しく服を脱いだ
	PRINTFORMW もはや裸体を隠そうともしない
	PRINTFORMW あなたが影狼の身体に手をかけると、その手を握って見つめてきた
	PRINTFORMW 「あなたの言うとおりにするから…優しくして、お願い」
	PRINTFORMW どうやら完全にあなたに心を奪われたようだ
	PRINTFORMW 可愛らしい彼女を抱き寄せてやると、戸惑いつつも嬉しそうに尻尾を振っていた
;服従を獲得した
ELSEIF CFLAG:202 < 3 && TALENT:服従
	CFLAG:202 = 3
	PRINTFORMW 影狼の繋がれている牢へ入った
	PRINTFORMW あなたが入ってくるのを見ると、おずおずと近づいてきた
	PRINTFORMW 調教の開始だと告げると大人しく服を脱いだ
	PRINTFORMW もはや裸体を隠そうともしない
	PRINTFORMW あなたが影狼の身体に手をかけると、その手を握って見つめてきた
	PRINTFORMW 「ご主人様のい、言うとおりにするから…優しくしてください…」
	PRINTFORMW どうやら完全にあなたに服従したようだ
	PRINTFORMW 可愛らしい彼女を抱き寄せてやると、戸惑いつつも嬉しそうに尻尾を振っていた
;依存度が300以上になった
ELSEIF CFLAG:202 < 2 && CFLAG:3 >= 300
	CFLAG:202 = 2
	PRINTFORMW 
	PRINTFORMW 影狼の繋がれている牢へ入った
	PRINTFORMW あなたが入ってくるのを見ると、一瞬笑顔になったがすぐに顔を背けた
	PRINTFORMW 調教の開始だと告げるとゆっくりと服を脱いだ
	PRINTFORMW 身体を震わせながらももはや抵抗はせず、尻尾を垂らして調教の開始を受け入れている
	PRINTFORMW 「はい…でも、痛くしないで…」
	PRINTFORMW 少しは調教の成果が出てきたようだ

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;恋慕
ELSEIF TALENT:恋慕
	SELECTCASE RAND:4
		CASE 0
			PRINTFORMW 「あっ、%ANAME(MASTER)%！」
			PRINTFORMW あなたを見ると嬉しそうに尻尾を振りながら駆け寄ってきた
		CASE 1
			PRINTFORMW 「今日は何をするの？気持ちいい事なら、良いな」
			PRINTFORMW もじもじと股をこすり合わせながら、尻尾をかすかに振っている
		CASE 2
			PRINTFORMW 「私は%ANAME(MASTER)%のペットよ…だから、放っておかないで」
			PRINTFORMW あなたにピタッと寄り添い縋り付く様に懇願してきた
		CASE 3
			PRINTFORMW 「えへへ…待ってた」
			PRINTFORMW 牢屋に入ると既に全裸の影狼が期待を込めた瞳で見つめてきた
	ENDSELECT
;服従
ELSEIF TALENT:服従
	SELECTCASE RAND:4
		CASE 0
			PRINTFORMW 「あっ…ご主人様ぁ…」
			PRINTFORMW あなたを見るとどこか虚ろな笑みを向け、歩み寄ってきた
		CASE 1
			PRINTFORMW 「今日は、何をするの…？あんまり痛くないと、良いな…」
			PRINTFORMW もじもじと股をこすり合わせながら、不安そうにこちらを窺っている
		CASE 2
			PRINTFORMW 「わ、私は、ご主人様の…ペットだから…放っておかないで…」
			PRINTFORMW あなたにピタッと寄り添い縋り付く様に懇願してきた
		CASE 3
			PRINTFORMW 「待ってました、ご主人様…」
			PRINTFORMW 牢屋に入ると既に全裸の影狼が期待を込めた瞳で見つめてきた
	ENDSELECT
;依存度が300以上
ELSEIF CFLAG:3 >= 300
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW 「はい、わかりました…」
			PRINTFORMW 調教開始を告げるともぞもぞと服を脱いだ
		CASE 1
			PRINTFORMW 「あの…いえ、なんでも…」
			PRINTFORMW 何かを言いかけたが、口ごもった
		CASE 2
			PRINTFORMW 「痛いのは、嫌なの…」
			PRINTFORMW 影狼の身体に触れるとビクビクと震えた
	ENDSELECT
;それ以外
ELSE
	PRINTFORMW あなたの姿を確認すると牙をむき出しにして威嚇してきた
	PRINTFORMW 無理矢理組み伏せてボロ服を引き裂き、調教を開始した
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_B_K94
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
		PRINTFORMW 「うぅ…」
		PRINTFORMW 牢屋を出ようとすると背後から影狼のうめき声が聞こえた
		PRINTFORMW 振り返ると、彼女と目が合う
		PRINTFORMW 影狼は困った子供のような表情であなたを見つめると、力なく俯いてしまった
		PRINTFORMW その瞳からは以前のような反抗心が消えかかっているのを確かに感じた
	ENDIF
;初回
ELSEIF CFLAG:203 < 1
	CFLAG:203 = 1
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		PRINTFORMW 「ふぅー…ふぅー…」
		PRINTFORMW 調教を終え、疲れ果てたのか力なく床に転がっている
		PRINTFORMW 顔を覗き込むとフイッとそっぽを向いた
		PRINTFORMW まだまだ折れるには遠いようだ
		PRINTFORMW 幸い人間と違い体も心も強い、次はどう調教しようかと考えながら牢屋を出た
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
;行動不能なら非表示
ELSEIF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
	;恋慕 or　服従
	IF TALENT:恋慕 || TALENT:服従
		SELECTCASE RAND:4
			CASE 0
				PRINTFORMW 「もう行っちゃうの…？そう…また来てくれる…？」
				PRINTFORMW 去っていくあなたの背中をいつまでも切なそうに見送っていた
			CASE 1
				PRINTFORMW 「はぁ…はぁ…相変わらず…激しすぎよぉ…」
				PRINTFORMW 力なく床に転がりながら、どこか嬉しそうにあなたに文句を告げた
			CASE 2
				PRINTFORMW 「えへへ…気持ちよかった…」
				PRINTFORMW 調教後、蕩けたような表情でこちらを見上げポツリとつぶやいた
			CASE 3
				PRINTFORMW 「も、もう少しだけ、お話でもしない？」
				PRINTFORMW 潤んだ瞳で縋り付いてくる影狼に負け、しばらく話に付き合ってやった
		ENDSELECT
```
