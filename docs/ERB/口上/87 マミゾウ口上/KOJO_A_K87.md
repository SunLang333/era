# 口上/87 マミゾウ口上/KOJO_A_K87.ERB — 自动生成文档

源文件: `ERB/口上/87 マミゾウ口上/KOJO_A_K87.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K87, KOJO_TRAIN_END_A1_K87, KOJO_TRAIN_START_A2_K87, KOJO_TRAIN_END_A2_K87, KOJO_COM_BEFORE_TARGET_A_K87, KOJO_COM_BEFORE_PLAYER_A_K87, KOJO_COM_A_K87, KOJO_COM_TARGET_A_K87, KOJO_COM_PLAYER_A_K87, KOJO_COM_AFTER_A_K87; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K87
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
	PRINTL [1] マミゾウ口上 
	$INPUT_LOOP
	INPUT

	IF RESULT == 0
		PRINTFORMW 口上を使用しません
		CFLAG:400 = 1
		RETURN
	ELSEIF RESULT == 1
		PRINTFORMW マミゾウ口上を使用します
		CFLAG:400 = 2
		PRINTFORMW 
		PRINTFORML ところでマミゾウさんって薄着だと胸のラインが薄……
				;それどころか黄昏ゲー（特に深秘録）の立ち絵だともはや絶ペ……
		PRINTL [0] 思わない
		PRINTL [1] 思う
		$INPUT_LOOP2
		INPUT
		IF RESULT == 0
			PRINTFORMW 素質はそのままで開始します
			RETURN
		ELSEIF RESULT == 1
			PRINTFORMW …素質を変更します
			CALL SET_BUSTSIZE(TARGET, -1)
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
IF CFLAG:200 == 0
	CFLAG:200 = 1
	;初対面の場合
	IF !CFLAG:17
		PRINTFORMW %ANAME(TARGET)%の元を訪れると、見慣れない眼鏡をかけた女性が静かに紫煙を燻らせていた
		PRINTFORMW 部屋の主は留守かと思い踵を返した%ANAME(MASTER)%に声がかかる
		PRINTFORMW 「おやおや、珍しい客人じゃな」
		PRINTFORML 「…おっと失礼」
		PRINTFORMW 軽い破裂音がして眼前の女性の姿が煙に隠れたかと思うと、そこには目当ての相手が佇んでいた
		PRINTFORMW 「儂は佐渡の二ッ岩」
		PRINTFORMW 「皆はマミゾウって呼ぶよ」
		PRINTFORML 
		PRINTFORMW 驚きから我に返り、挨拶をしようと口を開きかけた%ANAME(MASTER)%を%ANAME(TARGET)%がやんわりと制止する
		PRINTFORMW 「おお、お前さんのことは狸たちの噂に聞いたことがあるぞい」
		PRINTFORMW 「確か」
		PRINTFORML 
		PRINTFORML 「”最低の女たらし”」
		PRINTFORMW 
		PRINTFORMW 「んー？違ったかの？…まあどうでも良いわ」
		PRINTFORML 「これでも同じ釜の飯を食う仲間じゃ。宜しく頼むぞい」
		PRINTFORMW そうからかうように言うと、%ANAME(TARGET)%は手を差し伸べてきた
		PRINTFORML 
		PRINTFORML …どこまで本気なのか彼女ののらりくらりとした態度からは窺い知ることは出来ないが、
		PRINTFORMW 確かにこれからは彼女は頼りにすべき味方だ
		PRINTFORMW %ANAME(MASTER)%は差し出された手を握り返した
		PRINTFORMW 「うむうむ、袖振り合うも多生の縁じゃからな」
		PRINTFORML 
		PRINTFORML そこで突如ぐいと手を引っ張られ、お互いの顔に息が掛かりそうな程に顔を引き寄せられる
		PRINTFORMW 「ただし…、もし本当に下心が有って儂に近づいたのなら…火傷せんうちに手を引いた方が良いぞお？」
		PRINTFORMW 眼鏡の奥で%ANAME(TARGET)%の目が値踏みするように光った……
		PRINTFORML 
	;既に会ったことがある場合
	ELSE
		;捕虜調教の末仕官
		IF TALENT:烙印
			IF TALENT:服従
				PRINTFORML 「おぬしは…！」
				PRINTFORMW %ANAME(MASTER)%の姿を認めた瞬間、調教の記憶が脳裏に過ったのか%ANAME(TARGET)%の表情が大きく引き攣った
				PRINTFORMW 「…どういう風の吹き回しじゃ？」
				PRINTFORMW %ANAME(TARGET)%の態度は頑な態度を崩そうとしない
				PRINTFORMW しかしよく見ると、%ANAME(TARGET)%の指は無意識のうちに烙印を押した場所をなぞっている
				PRINTFORMW どうやら先の調教の成果はしっかりと%ANAME(TARGET)%に刻み込まれているようだ
				PRINTFORMW %ANAME(MASTER)%はより深く彼女の心を絡め取るべく暫く行動を共にすることにした……
			ELSE
				PRINTFORML 「おぬしは…！」
				PRINTFORMW %ANAME(MASTER)%の姿を認めた瞬間、調教の記憶が脳裏に過ったのか%ANAME(TARGET)%の表情が大きく引き攣った
				PRINTFORMW 「儂を笑いにでも来たか？」
				PRINTFORMW 「確かに…、儂は責め苦には屈した」
				PRINTFORML 「だが、心まで捧げたつもりはないぞ」
				PRINTFORMW そう苦々しげに吐き捨てると、%ANAME(TARGET)%はそっぽを向いた
				PRINTFORML 
				PRINTFORML %ANAME(TARGET)%の態度は頑なだ
				PRINTFORMW ここから良好な関係を築くにはなかなか手間が掛かりそうだ……
			ENDIF
		;夜這いなどで服従のみ
		ELSEIF TALENT:服従
			PRINTFORML 「おぬしは…！」
			PRINTFORMW %ANAME(MASTER)%の姿を認めた瞬間、調教の記憶が脳裏に過ったのか%ANAME(TARGET)%の表情が大きく引き攣った
			PRINTFORMW 「…どういう風の吹き回しじゃ？」
			PRINTFORMW %ANAME(TARGET)%の態度は頑な態度を崩そうとしない
			PRINTFORMW しかしよく見ると、%ANAME(TARGET)%の目は泳ぎ、こちらの一挙一動の度微かに肩を震わせている
			PRINTFORMW どうやら先の調教の成果はしっかりと%ANAME(TARGET)%に刻み込まれているようだ
			PRINTFORMW %ANAME(MASTER)%はより深く彼女の心を絡め取るべく暫く行動を共にすることにした……
		ELSE
			PRINTFORMW 「誰かと思えばお前さんか」
			PRINTFORMW 「お互い”いろいろ”有ったが、これからは同じ釜の飯を食う仲間じゃ」
			PRINTFORML 「全て水に流そうではないか」
			PRINTFORMW そう言って、%ANAME(TARGET)%は手を差し伸べてきた
			PRINTFORML
			;かなり嫌われている
			IF CFLAG:3 <= -1000
				PRINTFORMW しかし、言葉とは裏腹に%ANAME(TARGET)%の目は底冷えのする光をたたえている……
			;嫌われている
			ELSEIF CFLAG:3 < 0
				PRINTFORMW しかし、%ANAME(TARGET)%の目は全く笑っていない……
			;好かれている
			ELSEIF CFLAG:3 >= 1000
				PRINTFORMW %ANAME(MASTER)%は差し出された手をにこやかに握り返した……
			;普通
			ELSE
				PRINTFORMW %ANAME(MASTER)%は差し出された手をがっしりと握り返した……
			ENDIF
		ENDIF
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;初めて泥酔行きずりセックス　Mamizou In Black
ELSEIF CFLAG:350 == 1
	PRINTFORML 「おぬしか…」
	PRINTFORMW %ANAME(TARGET)%の元を訪れた%ANAME(MASTER)%は、なにやら神妙な顔で出迎えられた
	PRINTFORMW %ANAME(TARGET)%は普段の格好ではなく、黒いタイトなスーツを身に纏っている
	PRINTFORML 「前回会った日のこと…、お前さんは覚えておるか？」
	PRINTFORMW %ANAME(TARGET)%が真一文字に結んだ口を重々しく開いた
	PRINTFORML 
	PRINTFORMW  前回…、それはやはり酔い潰れた%ANAME(TARGET)%と一夜を過ごした日のことだろうか…
	PRINTFORMW  こちらの表情から何かを読み取ったのか、%ANAME(TARGET)%の表情が変わった
	PRINTFORML 
	PRINTFORMW 「…いや！いい！皆まで言わんでいい！」
	PRINTFORMW 「あれは酔った上での過ちじゃ！忘れよう！綺麗さっぱり忘れるのじゃ！それがお互いのためなのじゃ！」
	PRINTFORMW 珍しくあたふたと取り乱した%ANAME(TARGET)%は、懐から黒眼鏡と銀色の懐中電灯(？)を取り出し目の前にかざした
	PRINTFORML 
	PRINTFORML 何かされそうな気配を感じた%ANAME(MASTER)%は、謎の装置を振り回す%ANAME(TARGET)%を宥めすかして説得し、
	PRINTFORMW 何とかお互いに落ち度が有ったと納得させることに成功した
	PRINTFORML しかし、結果として相当に時間を食うことになってしまった
	PRINTFORMW 今日使える時間はもうあまり残っていないだろう……
	PRINTFORML 
	PRINTFORMW ………………
	PRINTFORMW ……
	PRINTFORML 
	PRINTFORMW 「ところで、儂は…そのぅ…。褥で何か妙なことを口走ったりせんかったかの…？」
	PRINTFORMW 「い、いや…、それも聞かんでおいた方が良さそうじゃ………」
	PRINTFORML 
	PRINTFORMW ………………
	PRINTFORMW ……
	PRINTFORML 
	CFLAG:350 = 2
	TFLAG:55 += 5;時間経過

;初めて合意セックスをした次の回
ELSEIF CFLAG:200 < 5 && TALENT:合意 && (!TALENT:服従 || !TALENT:烙印)
	CFLAG:200 = 5
	PRINTFORMW  「おう、おぬしか」
	PRINTFORMW  「んー？なんじゃその顔は？ニヤニヤしおってからに」
	PRINTFORMW  「まさか、お前さん…一回抱いた程度で儂を自分の女にしたと思っておるのではあるまいな？」
	PRINTFORML
	PRINTFORMW  「ふぉっふぉっふぉ！」
	PRINTFORMW  「甘いのうお前さん。女心は秋の空。次に会った時にはもう心変わりしとるのかもしれんのじゃぞお？」
	PRINTFORMW  「『何度でもこやつに抱かれたい』と思わせてこそ甲斐性持ちというやつじゃな」
	PRINTFORML
	PRINTFORMW  「まっ！儂にそう思わせるくらいになれということじゃよ」
	PRINTFORMW  「…これでもお前さんには期待しておるんじゃぞ？」
;恋人になった次の回
ELSEIF CFLAG:200 < 4 && TALENT:恋人 && (!TALENT:服従 || !TALENT:烙印)
	CFLAG:200 = 4
	PRINTFORMW 「さて、晴れて恋人同士となったわけじゃが…」
	PRINTFORMW 「別にいつもと変わった感じではないのぅ」
	PRINTFORMW 「ま、お互い気楽に行こうではないか」
;恋慕になった次の回
```
