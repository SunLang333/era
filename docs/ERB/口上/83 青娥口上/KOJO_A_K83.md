# 口上/83 青娥口上/KOJO_A_K83.ERB — 自动生成文档

源文件: `ERB/口上/83 青娥口上/KOJO_A_K83.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K83, KOJO_TRAIN_END_A1_K83, KOJO_TRAIN_START_A2_K83, KOJO_TRAIN_END_A2_K83, KOJO_COM_BEFORE_TARGET_A_K83, KOJO_COM_BEFORE_PLAYER_A_K83, KOJO_COM_A_K83, KOJO_COM_TARGET_A_K83, KOJO_COM_PLAYER_A_K83, KOJO_COM_AFTER_A_K83, SEX_VOICE83_00, SEX_VOICE83_01, SEX_VOICE83_02, SEX_VOICE83_03, SEX_VOICE83_04, SEX_VOICE83_05; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K83
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

IF CFLAG:251 == 0
	CFLAG:251 = 1
	PRINTFORML 
	CALL COLOR_PRINTW(@"唐突ですが、%ANAME(TARGET)%の下の毛の設定を変更しますか？", カラー_注意) 
	PRINTFORML 
	PRINTL [0] しない（剛毛）
	PRINTL [1] する（柔毛）
	PRINTL [2] むしろ無くていい（パイパン）
	$INPUT_LOOP
	INPUT
	IF RESULT == 0
		CALL COLOR_PRINTW("陰毛はそのままで開始します", カラー_注意) 
	ELSEIF RESULT == 1
		CALL COLOR_PRINTW("陰毛を柔毛に変更します", カラー_注意) 
		TALENT:陰毛現在値 = 陰毛_柔毛
		TALENT:陰毛目標値 = 陰毛_柔毛
	ELSEIF RESULT == 2
		CALL COLOR_PRINTW("陰毛をパイパンに変更します", カラー_注意) 
		TALENT:陰毛現在値 = 陰毛_パイパン
		TALENT:陰毛目標値 = 陰毛_パイパン
	ELSE
		GOTO INPUT_LOOP
	ENDIF
ENDIF
PRINTL

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	PRINTL
	;初対面の場合
	IF !CFLAG:17
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORMW 「……あら、ごきげんよう」
			PRINTFORMW %ANAME(MASTER)%が捕虜にあてがわれた部屋を訪れると、青い髪にノミのようなかんざしを止めた美女が優雅に寛いでいた
			PRINTFORML 「初めまして。私、　%NAME_FORMAL(TARGET)%　と申します」
			SETCOLOR 0x01A9DB
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　無理非道な仙人　『青娥 娘々』　―――――
				DATAFORM ―――――　壁抜けの邪仙　『青娥 娘々』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML そう言って、彼女は%ANAME(MASTER)%に名刺を手渡してきた。今時は仙人も名刺を持つ時代なのか……
			PRINTFORMW 「それで、今日はどのようなご用件で？」
			PRINTFORML 「牢に閉じ込めずにわざわざこの扱い……。何かしらの目的がお有りではないのですか？」
			PRINTFORMW 彼女は概ね察しているようだ。%ANAME(MASTER)%は素直に、この乱世を鎮めるため我が軍に力を貸して欲しい、と伝えた
			PRINTFORML 「いきなりそんなことを言われても、戸惑ってしまいますわ」
			PRINTFORMW 「……でも%ANAME(MASTER)%から、大いなる力の片鱗が見受けられます。それはとても興味深い事です」
			PRINTFORML %ANAME(TARGET)%は妖艶に目を細めて%ANAME(MASTER)%を見つめ、そしてニッコリと笑って向き合った
			PRINTFORMW 「もしよろしければ、しばらくの間お付き合いくださいませ。貴方の力がどんな物か、この目で見てみたい物ですので…♪」
		;それ以外
		ELSE
			PRINTFORMW 「ハァイ！　そこなお兄さん」
			PRINTFORML 突然呼び止められた%ANAME(MASTER)%は振り返る
			PRINTL
			PRINTFORMW そこには、ショートボブのふんわりした青い髪にノミのようなかんざしで髪を止めた美女がいた
			PRINTFORML 「突然お声がけして、申し訳ありません。私、仙人をやっております　%NAME_FORMAL(TARGET)%　と申すものでございますわ」
			SETCOLOR 0x01A9DB
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　無理非道な仙人　『青娥 娘々』　―――――
				DATAFORM ―――――　壁抜けの邪仙　『青娥 娘々』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORML そう言って、彼女は%ANAME(MASTER)%に名刺を手渡してきた。そこに書かれている名は、正に自分が使える国の主だった
				PRINTFORMW 「うふふ♥　驚かせてすみません。私は色々と力ある者に眼がない性質でして。そういったモノを見抜く目を持っているつもりです」
				PRINTL
				PRINTFORML 「その私の勘が囁くのです。『貴方は稀有な力の持ち主である』と…」
				PRINTFORMW 確かにこの乱世となった幻想郷で生きる以上、それなりの自信はあるが…
				PRINTFORML 仙人様の目に止まるような大それた力が、果たして自分にあるものだろうか？
				PRINTL
				PRINTFORMW 「いきなりこんなことを言われても、戸惑うのが当たり前ですよね」
				PRINTFORML %ANAME(TARGET)%は苦笑するも、その目には確信めいた自信が宿っていた
				PRINTFORMW 「でも貴方には、やはり大いなる可能性が眠っているのを感じますわ」
				PRINTFORMW 「もしよろしければ、今後とも力をお貸しくださいませ。貴方がどんな道を行くか、この目で見てみたいですわ♪
			;それ以外
			ELSE
				PRINTFORML そう言って、彼女は%ANAME(MASTER)%に名刺を手渡してきた。今時は仙人も名刺を持つ時代なのか……
				PRINTFORMW 「私は色々と力ある者に眼がない性質でして。そういったモノを見抜く目を持っているつもりです」
				PRINTL
				PRINTFORML 「その私の勘が囁くのです。『貴方は稀有な力の持ち主である』と…」
				PRINTFORMW 確かにこの乱世となった幻想郷で生きる以上、それなりの自信はあるが…
				PRINTFORML 仙人様の目に止まるような大それた力が、果たして自分にあるものだろうか？
				PRINTL
				PRINTFORMW 「いきなりこんなことを言われても、戸惑うのが当たり前ですよね」
				PRINTFORML %ANAME(TARGET)%は苦笑するも、その目には確信めいた自信が宿っていた
				PRINTFORMW 「でも貴方には、やはり大いなる可能性が眠っているのを感じますわ」
				PRINTFORMW 「もしよろしければ、今後ともお付き合いくださいませ。貴方がどんな道を行くか、この目で見てみたいですわ♪
			ENDIF
		ENDIF
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORMW 「……あら%ANAME(MASTER)%、ごきげんよう」
			PRINTFORMW %ANAME(MASTER)%が捕虜にあてがわれた部屋を訪れると、青い髪にノミのようなかんざしを止めた美女が優雅に寛いでいた
			PRINTFORML 「こういう形でまた会うとはね。どうせなら、もっと風情のあるところで会いたかったけど……」
			SETCOLOR 0x01A9DB
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　無理非道な仙人　『青娥 娘々』　―――――
				DATAFORM ―――――　壁抜けの邪仙　『青娥 娘々』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			PRINTFORMW 「それで、今日はどのようなご用件で？」
			PRINTFORML 「牢に閉じ込めずにわざわざこの扱い……。私に何か用があったんじゃないかしら？」
			PRINTFORMW 彼女は概ね察しているようだ。%ANAME(MASTER)%は素直に、この乱世を鎮めるため我が軍に力を貸して欲しい、と伝えた
			PRINTFORML 「うーん、いきなりそんなことを言われても、戸惑ってしまいますわ」
			PRINTFORMW 「……でも%ANAME(MASTER)%から、大いなる力の片鱗が見受けられます。それはとても興味深い事です」
			PRINTFORML %ANAME(TARGET)%は妖艶に目を細めて%ANAME(MASTER)%を見つめ、そしてニッコリと笑って向き合った
			PRINTFORMW 「しばらくの間お付き合いいたします。貴方の力がどんな物か、この目で見てみたい物ですので…♪」
		;それ以外
		ELSE
			PRINTFORMW 「ハァイ！　%ANAME(MASTER)%」
			PRINTFORML 突然呼び止められた%ANAME(MASTER)%は振り返る
			PRINTFORMW そこには、ショートボブのふんわりした青い髪にノミのようなかんざしで髪を止めた美女がいた。
			PRINTFORMW 確か見たことがある……。が、名は……なんだったっけ
			PRINTFORML 「あぁん、忘れられていたの？　寂しいわぁ」
			PRINTFORMW そう言って、美女は%ANAME(MASTER)%に名刺を手渡してきた。
			PRINTFORML 「私は　%NAME_FORMAL(TARGET)%　と申すものでございますわ。今はしがない仙人をやっております」
			SETCOLOR 0x01A9DB
			PRINTFORML 
			PRINTDATAL
				DATAFORM ―――――　無理非道な仙人　『青娥 娘々』　―――――
				DATAFORM ―――――　壁抜けの邪仙　『青娥 娘々』　―――――
			ENDDATA
			PRINTFORMW 
			RESETCOLOR
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORML …ああ、そうだ。彼女は我が陣営の君主だ。前はあまりの美貌に目を奪われて、名前の方がまったく頭に入っていなかった
				PRINTFORMW 「くすっ♪　今後は名前も覚えていただくように頑張りますわ。それで、前もお話しました？　私は力あるモノに目がないと…」
				PRINTL
				PRINTFORML 「その私の勘が囁くのです。『貴方は稀有な力の持ち主である』と…」
				PRINTFORMW 確かにこの乱世となった幻想郷で生きる以上、それなりの自信はあるが…
				PRINTFORML 仙人様の目に止まるような大それた力が、果たして自分にあるものだろうか？
				PRINTL
				PRINTFORMW 「いきなりこんなことを言われても、戸惑うのが当たり前ですよね」
				PRINTFORML %ANAME(TARGET)%は苦笑するも、その目には確信めいた自信が宿っていた
				PRINTFORMW 「でも貴方には、やはり大いなる可能性が眠っているのを感じますわ」
				PRINTFORMW 「もしよろしければ、今後とも力をお貸しくださいませ。貴方がどんな道を行くか、この目で見てみたいですわ♪
			;それ以外
			ELSE
				PRINTFORML ……ああ、そうだった。前は美貌に目を奪われて、名前がまったく頭に入っていなかった
				PRINTFORMW 「実は私、色々な力ある者に眼がない性質でして。そういったモノを見抜く目を持っているつもりです」
				PRINTL
				PRINTFORML 「その私の勘が囁くのです。『貴方は稀有な力の持ち主である』と…」
				PRINTFORMW 確かにこの乱世となった幻想郷で生きる以上、それなりの自信はあるが…
				PRINTFORML 彼女の目に止まるような大それた力が、果たして自分にあるものだろうか？
				PRINTL
				PRINTFORMW 「いきなりこんなことを言われても、戸惑うのが当たり前ですよね」
				PRINTFORML %ANAME(TARGET)%は苦笑するも、その目には確信めいた自信が宿っていた
				PRINTFORMW 「でも貴方には、やはり大いなる可能性が眠っているのを感じますわ」
				PRINTFORMW 「もしよろしければ、今後ともお付き合いくださいませ。貴方がどんな道を行くか、この目で見てみたいですわ♪」
			ENDIF
		ENDIF
		PRINTL
	ENDIF


;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻か妾
ELSEIF CFLAG:200 < 8 && (TALENT:正妻 || TALENT:妾)
	CFLAG:200 = 8
	PRINTFORML 
	IF TALENT:正妻 
		PRINTFORML ……
		PRINTFORML 朝。%ANAME(TARGET)%と共にベッドで眠っていた%ANAME(MASTER)%は、髪を撫でられる感触で目を覚ました
		PRINTFORMW 「あら、起こしてしまいましたか。ごめんなさいね」
		PRINTFORMW %ANAME(TARGET)%は半身を起こし、%ANAME(MASTER)%の頭を愛おしそうに撫で付けている
		PRINTFORML 窓から差し込む朝日に照らされ、%ANAME(TARGET)%の輝く青髪と白い肌が神秘的な美しさを放つ
		PRINTFORMW まさに天女そのものというべき美しさに、%ANAME(MASTER)%はしばし見蕩れてしまう
		PRINTFORML 「ふふ♥　そんなに熱心に見つめられると、少し照れちゃいますけど……」
		PRINTFORMW 「でも、それだけ私のことを綺麗だ…、って思ってくれたんですよね？」
		PRINTFORML 「うふふ♥　じゃあこれからも、%ANAME(MASTER)%に綺麗な奥さんだって思われるよう努力しますわ♥」
		PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%と目覚めのキスを交わして、今日の活動を開始した
```
