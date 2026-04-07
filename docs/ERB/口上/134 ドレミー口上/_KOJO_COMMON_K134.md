# 口上/134 ドレミー口上/_KOJO_COMMON_K134.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/_KOJO_COMMON_K134.ERB`

类型: .ERB

自动摘要: functions: KOJO_EXIST_K134, KOJO_TRAIN_START_K134, KOJO_TRAIN_END_K134, KOJO_COM_TARGET_K134, KOJO_COM_PLAYER_K134, KOJO_COM_AFTER_K134, KOJO_SINGLE_ENDING_K134, KOJO_DEAD_ENDING_K134; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;共通部分
;-------------------------------------------------

;=================================================
;●口上の存在判定
;=================================================
@KOJO_EXIST_K134

;=================================================
;●開始時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_START_K134

;=================================================
;●終了時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_END_K134


;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_TARGET_K134

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_PLAYER_K134

;=================================================
;●コマンド実行後(パラメータの変動処理が終わってから呼び出される)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_AFTER_K134
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

;淫乱かつこちらに主導権が有るとたまにおねだりするお試し記述。条件を満たすと確率が上がる。
;現状おねだりを聞いても特に意味は無い。育成のお楽しみ要素、達成感、マンネリ回避…的な？

;会いに行く or 閨に呼ぶ
IF GETBIT(TALENT:淫乱系, 素質_淫乱_淫乱) && TFLAG:45 == 0 && (FLAG:調教モード == 0 || FLAG:調教モード == 1)
	;Vおねだり
	IF RAND:5 == 0 && !TALENT:妊娠 && TequIP:1 == 1
		PRINTFORML 
		IF RAND:4 == 0 && ABL:Ｖ感 >= 5
			PRINTFORMW ［膣交おねだり］
				IF RAND:2 == 0
					PRINTFORML 「子供…欲しくない？」
				ELSE
					PRINTFORML 「子作り…しませんか？」
				ENDIF
				IF RAND:2 == 0 
					PRINTFORMW %ANAME(TARGET)%は、秘部を拡げて淫靡に微笑んでいる……
				ELSE
					PRINTFORMW %ANAME(TARGET)%は寝そべったまま%ANAME(MASTER)%を招き入れるように腕を伸ばしている……
				ENDIF
		ELSEIF RAND:3 == 0 && GETBIT(TALENT:淫乱系, 素質_淫乱_淫壷)
			PRINTFORMW ［膣交おねだり］
				IF RAND:2 == 0 
					PRINTFORML 「私の体をこんなにしたのはあなたなのですよ…？満足させてくれるまで離さないのだから…」
				ELSE
					PRINTFORML 「あなたの手にかかると私もただの女なのね…」
				ENDIF
				IF RAND:2 == 0 
					PRINTFORMW %ANAME(TARGET)%は、秘部を大きく拡げて%ANAME(MASTER)%を誘っている……
				ELSE
					PRINTFORMW %ANAME(TARGET)%が%ANAME(MASTER)%を招き入れるように股を開くと、愛液が地面に滴り落ちた……
				ENDIF
		ELSEIF RAND:2 == 0 && (TequIP:1 == 2 || TequIP:1 == 10 )
			PRINTFORMW ［膣交おねだり］
			PRINTFORML 「こんな玩具じゃ…ダメ、あなたのが欲しいの…」
				IF RAND:2 == 0 
					PRINTFORMW %ANAME(TARGET)%は切なげに%ANAME(MASTER)%を見つめている……
				ELSE
					PRINTFORMW %ANAME(TARGET)%は淫靡に腰を揺らした……
				ENDIF
		ELSE
			PRINTFORML 
		ENDIF
	;Aおねだり
	ELSEIF RAND:4 == 0 && TequIP:2 == 1
		PRINTFORML 
		IF RAND:4 == 0 && ABL:Ａ感 >= 5
			PRINTFORMW ［肛交おねだり］
				IF RAND:2 == 0 
					PRINTFORML 「そろそろ…、こちらもシない？…」
				ELSE
					PRINTFORML 「私も…、すっかり変態の仲間入りね…」
				ENDIF
				IF RAND:2 == 0 
					PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%に尻を突き出すとアナルセックスを懇願した……
				ELSE
					PRINTFORMW %ANAME(TARGET)%は二本の指で尻穴を大きく拡げ、%ANAME(MASTER)%を誘っている……
				ENDIF
		ELSEIF RAND:3 == 0 && GETBIT(TALENT:淫乱系, 素質_淫乱_尻穴狂い)
			PRINTFORMW ［肛交おねだり］
				IF RAND:2 == 0 
					PRINTFORML 「はしたないのだけど…、お尻も可愛がってくれない…？」
				ELSE
					PRINTFORML 「尻穴が疼くの…、鎮めて…くれない？」
				ENDIF
				IF RAND:2 == 0 
					PRINTFORMW %ANAME(TARGET)%は二本の指で尻穴を大きく拡げ、%ANAME(MASTER)%を誘っている……
				ELSE
					PRINTFORMW すっかり弛緩し縦に割れた%ANAME(TARGET)%の尻穴は、%ANAME(MASTER)%を待ち侘びたようにヒクついている……
				ENDIF
		ELSEIF RAND:2 == 0 && TequIP:2 == 10
			PRINTFORMW ［肛交おねだり］
			PRINTFORML 「こんな玩具じゃダメ…、あなたのモノが欲しいの…」
				IF RAND:2 == 0 
					PRINTFORMW %ANAME(TARGET)%は切なげに%ANAME(MASTER)%を見つめている……
				ELSE
					PRINTFORMW %ANAME(TARGET)%は淫靡に腰を揺らした……
				ENDIF
		ELSE
			PRINTFORML 
		ENDIF
	;Cおねだり
	ELSEIF RAND:3 == 0
		PRINTFORML 
		IF RAND:4 == 0 && ABL:Ｃ感 >= 5
			PRINTFORMW ［陰核おねだり］
			PRINTFORML 「ここがジンジン疼いて…弄って？」
			PRINTFORMW %ANAME(TARGET)%はクリトリスに指先を這わせている……
		ELSEIF RAND:3 == 0 && GETBIT(TALENT:淫乱系, 素質_淫乱_淫核)
			PRINTFORMW ［陰核おねだり］
			PRINTFORML 「ジンジン疼いて堪らないの…」
			PRINTFORMW %ANAME(TARGET)%はクリトリスを見せつけてきた……
		ELSEIF RAND:2 == 0 && TequIP:0 == 10
			PRINTFORMW ［陰核おねだり］
			PRINTFORML 「本当はおぬしの手で弄って欲しいんじゃが…」
			PRINTFORMW %ANAME(TARGET)%はクリトリスに取り付けられた淫具を恨めしげに見つめている……
		ELSE
			PRINTFORML 
		ENDIF
	;Bおねだり
	ELSEIF RAND:2 == 0
		PRINTFORML 
		IF RAND:4 == 0 && ABL:Ｂ感 >= 5
			PRINTFORMW ［乳房おねだり］
			PRINTFORML 「ここは触らないの……？」
			PRINTFORMW %ANAME(TARGET)%は両腕で胸の谷間を作って誘惑している……
		ELSEIF RAND:3 == 0 && GETBIT(TALENT:淫乱系, 素質_淫乱_淫乳)
			PRINTFORMW ［乳房おねだり］
			PRINTFORML 「ふぅ…、胸が張って苦しいわね……誰か弄ってくれないかしら？」
			PRINTFORMW %ANAME(TARGET)%はチラチラと%ANAME(MASTER)%に視線を寄越している……
		ELSEIF RAND:2 == 0 && TequIP:3 == 10
			PRINTFORMW 「本当はあなたの手で弄って欲しいのよね…」
			PRINTFORMW %ANAME(TARGET)%は乳首に取り付けられた淫具を恨めしげに見つめている……
		ELSE
			PRINTFORML 
		ENDIF
	;Mおねだり
	ELSE
		PRINTFORML 
		IF RAND:3 == 0 && ABL:Ｍ感 >= 5
			PRINTFORMW ［キスおねだり］
			PRINTFORMW 「ん……」
			PRINTFORMW %ANAME(TARGET)%は唇をトントンと指で叩いてキスをせがんでいる……
		ELSEIF RAND:2 == 0 && GETBIT(TALENT:淫乱系, 素質_淫乱_蕩唇)
			PRINTFORMW ［口交おねだり］
			PRINTFORML 「キスだけじゃ物足りないわね…」
			PRINTFORMW %ANAME(TARGET)%は口の前で指の輪を作り、舌を突き出すジェスチャーをしている……
		ELSE
			PRINTFORML 
		ENDIF
	ENDIF
ENDIF

;-------------------------------------------------
;初絶頂は使い回せそうなのでここに作成　多重絶頂もそのうち
;-------------------------------------------------
;-------------------------------------------------
;初めてＣ絶頂
;-------------------------------------------------
IF NOWEX:Ｃ絶頂 > 0
	PRINTFORML 
	IF CFLAG:220 == 0
		CFLAG:220 = 1
		;PRINTFORMW 「」
	ENDIF
ENDIF

;-------------------------------------------------
;初めてＶ絶頂
;-------------------------------------------------
IF NOWEX:Ｖ絶頂 > 0
	PRINTFORML 
	;初回
	IF CFLAG:221 == 0
		CFLAG:221 = 1
		PRINTFORML 「んっ…！くぅぅ～…っ！！」
```
