# 口上/143 ネムノ口上/KOJO_A_K143.ERB — 自动生成文档

源文件: `ERB/口上/143 ネムノ口上/KOJO_A_K143.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K143, KOJO_TRAIN_END_A1_K143, KOJO_TRAIN_START_A2_K143, KOJO_TRAIN_END_A2_K143, KOJO_COM_BEFORE_TARGET_A_K143, KOJO_COM_BEFORE_PLAYER_A_K143, KOJO_COM_A_K143, KOJO_COM_TARGET_A_K143, KOJO_COM_PLAYER_A_K143, KOJO_COM_AFTER_A_K143, SEX_VOICE143_00, SEX_VOICE143_01, SEX_VOICE143_02, SEX_VOICE143_03, SEX_VOICE143_04; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K143
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF
PRINTL

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	PRINTFORML
	;初対面の場合
	IF !CFLAG:17
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「……うちに何の用だべ」
			PRINTFORMW 捕虜用の部屋を訪れた%ANAME(MASTER)%に、白髪の女性が静かに口を開く
			SETCOLOR カラー_シルバー
			PRINTFORML 
			PRINTFORML ―――――　浮世の関を超える山姥　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 噂では、めったに姿を見せない山姥だとか…
			PRINTFORML しかしその当人は、山姥という言葉からは程遠い若々しさと抜群のスタイルの持ち主だった
			PRINTFORMW 「…なんだべ、固まっちまって。用が無いなら帰ってくんろ」
			PRINTFORML 思わず見とれてしまった%ANAME(MASTER)%だったが、%ANAME(TARGET)%に会いに来た目的を伝えた
			PRINTFORMW ― この戦乱を治めるためにも我が軍に力を貸して欲しい ―　と…
			PRINTFORML
			PRINTFORML 「……正直うちは群れるのが嫌いだ。静かな生活を取り戻すために戦ってるだけだべ」
			PRINTFORMW 「それでも最低限の義理はある。そう簡単に下るつもりはねえ」
			PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%の誘いを断った。しかしその雰囲気は取り付く島も無い、といった物では無い
			PRINTFORMW 「…しかし、うちは強いやつは嫌いじゃない。これからあんたの事、見極めさせてもらうよ」
		;それ以外
		ELSE
			PRINTFORML 「あー？　うちに何の用だべ？」
			PRINTFORMW 声をかけられた白髪の女性が%ANAME(MASTER)%に顔を向けた
			SETCOLOR カラー_シルバー
			PRINTFORML 
			PRINTFORML ―――――　浮世の関を超える山姥　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 噂では、めったに姿を見せない山姥だとか…
			PRINTFORML しかしその当人は、山姥というには似つかわしくない若々しさと抜群のスタイルの持ち主だった
			PRINTFORMW 「なんだべ、固まっちまって。用が無いなら帰ってくんろ」
			PRINTFORML 思わず見とれてしまった%ANAME(MASTER)%だったが、%ANAME(TARGET)%に会いに来た目的を伝えた
			;相手が自国の君主の場合
			IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
				PRINTFORMW ― この戦乱を治めるため、微力ながら協力させてもらいます ―　と…
				PRINTFORML
				PRINTFORML 「いらん。帰れ」
				PRINTFORMW
				PRINTFORMW 「……と言いたいが、確かに近頃周りが騒がしすぎて一人じゃ手が回らんかったとこだべ」
				PRINTFORML 「…仕方ない。群れるのは嫌だが、また静かになるまでは置いといてやるだ」
			;それ以外
			ELSE
				PRINTFORMW ― この戦乱を治めるためにも自分に力を貸して欲しい ―　と…
				PRINTFORML
				PRINTFORML 「断る」
				PRINTFORMW
				PRINTFORMW 「……と言いたいが、確かに近頃周りが騒がしすぎて鬱陶しかったとこだべ」
				PRINTFORML 「…仕方ない。群れるのは嫌だが、また静かになるまでは手伝ってやるだ」
			ENDIF
			PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%と握手を交わそうとしたが、彼女はそれを拒否する
			PRINTFORML 「言ったろ？　群れたりするのは好きじゃねぇだ。馴れ合いはせん」
			PRINTFORMW 「…とは言え、強いやつは嫌いじゃない。これからあんたの事を見極めさせてもらうよ」
		ENDIF
		PRINTFORML
	;既に会ったことがあり、服従じゃない場合
	ELSEIF !TALENT:服従
		;軟禁中
		IF CFLAG:29 == 1
			PRINTFORML 「……見た顔だな。うちに何の用だべ」
			PRINTFORMW 捕虜用の部屋を訪れた%ANAME(MASTER)%に、白髪の女性が静かに口を開く
			SETCOLOR カラー_シルバー
			PRINTFORML 
			PRINTFORML ―――――　浮世の関を超える山姥　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は、めったに姿を見せない山姥だ
			PRINTFORML しかしその当人は相変わらずの、山姥という言葉からは程遠い若々しさと抜群のスタイルの持ち主だった
			;好感度500以上
			IF CFLAG:好感度 >= 500
				PRINTFORMW 「まーた、固まっちまって。%ANAME(MASTER)%は前もそうだったべ。何しに来ただ？」
				PRINTFORML 思わず見とれてしまった%ANAME(MASTER)%だったが、改めて%ANAME(TARGET)%に会いに来た目的を伝えた				
				PRINTFORML ― この戦乱を治めるためにも我が軍に力を貸して欲しい ―　と…
				PRINTFORMW 「ほーん……うちの力が必要、だと……」
				PRINTFORML 「……うちにも一応は義理がある。簡単に寝返るつもりはないが、お前とは知らん中でもないし…」
				PRINTFORML %ANAME(MASTER)%は%ANAME(TARGET)%を真剣な瞳で見据えてきた
				PRINTFORMW 「うちは強いやつは嫌いじゃない。%ANAME(MASTER)%にうちを従える力があるか、見極めさせてもらうべ」
			ELSE
				PRINTFORMW 「…あんたは前もそうやって固まってただな。何しに来たんだべ？」」
				PRINTFORML 思わず見とれてしまった%ANAME(MASTER)%だったが、%ANAME(TARGET)%に会いに来た目的を伝えた
				PRINTFORMW ― この戦乱を治めるためにも我が軍に力を貸して欲しい ―　と…
				PRINTFORML
				PRINTFORML 「……正直うちは群れるのが嫌いだ。静かな生活を取り戻すために戦ってるだけだべ」
				PRINTFORMW 「それでも最低限の義理はある。そう簡単に下るつもりはねえ」
				PRINTFORML %ANAME(TARGET)%は%ANAME(MASTER)%の誘いを断った。しかしその雰囲気は取り付く島も無い、といった物では無い
				PRINTFORMW 「…しかし、うちは強いやつは嫌いじゃない。これからあんたの事、見極めさせてもらうよ」
			ENDIF
		;それ以外
		ELSE
			PRINTFORML 「ん？　…どっかで見た顔だな。うちに何か用だべ？」
			PRINTFORMW 声をかけられた白髪の女性が%ANAME(MASTER)%に顔を向けた。
			SETCOLOR カラー_シルバー
			PRINTFORML 
			PRINTFORML ―――――　浮世の関を超える山姥　『%NAME_FORMAL(TARGET)%』　―――――
			PRINTFORMW 
			RESETCOLOR
			PRINTFORML 彼女は、めったに姿を見せない山姥だ
			PRINTFORML しかしその当人は相変わらずの、山姥というには似つかわしくない若々しさと抜群のスタイルの持ち主だった
			;好感度500以上
			IF CFLAG:好感度 >= 500
				PRINTFORMW 「まーた、固まっちまって。%ANAME(MASTER)%は前もそうだったべ。何しに来ただ？」
				PRINTFORML 思わず見とれてしまった%ANAME(MASTER)%だったが、改めて%ANAME(TARGET)%に会いに来た目的を伝えた
				;相手が自国の君主の場合
				IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
					PRINTFORML ― この戦乱を治めるためにも、微力ながら力を貸す ―　と…
					PRINTFORMW 「ほーん……うちを手伝ってくれる、ってか。まあ確かに手が足らんで困ってたとこだべ」
					PRINTFORML 「まあいい。群れるのは嫌だが%ANAME(MASTER)%に免じて、今回は手伝ってもらうべ」
				;それ以外
				ELSE
					PRINTFORML ― この戦乱を治めるためにも自分に力を貸して欲しい ―　と…
					PRINTFORMW 「ほーん……確かに、近頃騒がしすぎて困ってたとこだべ」
					PRINTFORML 「仕方ない。群れるのは嫌だが%ANAME(MASTER)%に免じて、今回は手伝ってやるだ」
				ENDIF
				PRINTFORML %ANAME(MASTER)%は%ANAME(TARGET)%と笑顔で握手を交わした
				PRINTFORMW 「うちも強いやつは嫌いじゃない。%ANAME(MASTER)%に戦乱を治める力があるか、見極めさせてもらううよ」
			ELSE
				PRINTFORMW 「…あんたは前もそうやって固まってただな。何しに来たんだべ？」
				PRINTFORML 思わず見とれてしまった%ANAME(MASTER)%だったが、改めて%ANAME(TARGET)%に会いに来た目的を伝えた
				;相手が自国の君主の場合
				IF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == TARGET
					PRINTFORMW ― この戦乱を治めるために、微力ながら協力させてもらいます ―と…
					PRINTFORML
					PRINTFORML 「いらん。帰れ」
					PRINTFORMW
					PRINTFORMW 「……と言いたいが、確かに近頃周りが騒がしすぎて一人じゃ手が回らんかったとこだべ」
					PRINTFORML 「…仕方ない。群れるのは嫌だが、また静かになるまでは置いといてやるだ」
				;それ以外
				ELSE
					PRINTFORMW ― この戦乱を治めるためにも自分に力を貸して欲しい ―と…
					PRINTFORML
					PRINTFORML 「断る」
					PRINTFORMW
					PRINTFORMW 「……と言いたいが、確かに近頃周りが騒がしすぎて鬱陶しいと思ってたとこだべ」
					PRINTFORML 「…仕方ない。群れるのは嫌だが、また静かになるまでは手伝ってやるだ」
				ENDIF
				PRINTFORMW %ANAME(MASTER)%は%ANAME(TARGET)%と握手を交わそうとしたが、彼女はそれを拒否する
				PRINTFORML 「言ったろ？　群れたりするのは好きじゃねぇだ。馴れ合いはせん」
				PRINTFORMW 「…とは言え、強いやつは嫌いじゃない。これからあんたの事を見極めさせてもらうよ」
			ENDIF
		ENDIF
		PRINTFORML
	ENDIF

;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;正妻
ELSEIF CFLAG:200 < 9 && TALENT:正妻
	CFLAG:200 = 9
	PRINTFORML
	PRINTFORML 「あ、%ANAME(MASTER)%♥　…はは、うちらが夫婦になったって、何だか不思議な感じだべ」
	PRINTFORMW %ANAME(TARGET)%は、はにかみながらも%ANAME(MASTER)%に寄り添っている
	PRINTFORML 「初めて会ったときは、お前さんがうちの旦那になるなんて思いもしなかったべ」
	PRINTFORML 「それが今はこうなって、……分からねぇもんだなあ」
	PRINTFORMW 頬を染めながら肩にもたれる%ANAME(TARGET)%を、%ANAME(MASTER)%はそっと抱き寄せた…
	PRINTFORMW 「%ANAME(MASTER)%……これからも、うちと一緒にいておくれ…♥」
	PRINTFORML

;親愛か隷属
ELSEIF CFLAG:200 < 8 && (TALENT:親愛 || TALENT:隷属)
	CFLAG:200 = 8
	PRINTFORML
	PRINTFORML 「あ！　%ANAME(MASTER)%♥　今日も来てくれただな、うれしいなあ♪」
	PRINTFORMW %ANAME(TARGET)%は笑顔で%ANAME(MASTER)%に抱きついてきた。豊満な胸が押し当てられる…
	PRINTFORML 「んー？　どうした？　うちの胸が気になるか？」
	PRINTFORMW 「ふふ…その気になったら、うちはいつでもいいからな…♥」
	PRINTFORMW %ANAME(TARGET)%は%ANAME(MASTER)%の耳元で熱っぽく囁いてくる……
	PRINTFORML

;既成事実Lv3(初めてセックスをした次の回)＆恋慕持ち
ELSEIF CFLAG:200 < 7 && TALENT:合意
	CFLAG:200 = 7
	PRINTFORML
	IF TALENT:恋慕
		PRINTFORML 「あ…%ANAME(MASTER)%……うちに会いに来てくれたんだな♥」
		PRINTFORML %ANAME(TARGET)%は頬を染めながら%ANAME(MASTER)%の手を握ってきた
		PRINTFORMW 「ふふ、まあゆっくりしていくべ。お茶でも飲むか？」
	ELSE
		PRINTFORMW 「どうしただ？　まぐわり合ったぐれぇでそんなアタフタする歳でもねぇべ」
```
