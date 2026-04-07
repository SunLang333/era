# 口上/09 咲夜口上/STARTEND_K9/KOJO_C_TOP_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/STARTEND_K9/KOJO_C_TOP_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_C_K9, KOJO_TRAIN_END_C_K9; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●「捕虜逆調教」開始時
;─────────────────────────────────────── 
@KOJO_TRAIN_START_C_K9
#DIM 咲夜_対象
#DIM 咲夜

咲夜_対象 = MASTER
咲夜 = NAME_TO_CHARA("咲夜")

;咲夜口上の使用可否設定と初期化
SIF CFLAG:咲夜:400 == 0
	CALL KOJO_ASK_RESET_K9

;口上を使用しない設定なら戻る
SIF CFLAG:咲夜:400 == 1
	RETURN 0

SETCOLOR 咲夜_口上カラー

;─────────────────────────────────────── 
;○初回
;─────────────────────────────────────── 
IF CFLAG:咲夜:204 == 0

	;逆調教口上初回呼び出しフラグオン
	CFLAG:咲夜:204 = 1

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:咲夜:虚ろ
		PRINTFORML 「……う……ぅう……ん……」
		PRINTFORMDL %ANAME(咲夜)%は虚ろな瞳で近付いてきた……
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常
	;───────────────────────────────────── 
	IF IS_SLAVE(咲夜)
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%、お許しください……いえ、やっぱり無理かしらね」
		PRINTFORML 「お叱りは後で、%CALLNAME_K9(咲夜_対象)%のお気の済むまでお受けいたします」

	ELSEIF CHECK_K9("敬語") && IS_LOVER(咲夜)
		PRINTFORML 「縛ってあれば、怒られて逃がす心配もないし、焦らしそびれる心配もないのよね」
		PRINTFORML 「することは今更でしょう？　素敵なことです。縛られるのがお好みなら引き伸ばしてください」
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%なら私は飽きそうにありませんから」

	ELSEIF CHECK_K9("敬語")
		PRINTFORML 「縛ってあれば、怒られて逃がす心配もないし、焦らしそびれる心配もないのよね」
		PRINTFORML 「することは今更でしょう？　%CALLNAME_K9(咲夜_対象)%」
		PRINTFORML 「縛られるのがお好きなら、折れずに引き伸ばしてください」

	ELSEIF IS_LOVER(咲夜)
		PRINTFORML 「縛ってあれば、怒られて逃がす心配もないし、焦らしそびれる心配もないのよね」
		PRINTFORML 「することなんて今更ね。縛られるのが好きなら引き伸ばしてもいいのよ」
		PRINTFORML 「%CALLNAME_K9(咲夜_対象)%なら私もたのしめそうね」

	ELSEIF TALENT:咲夜:合意
		PRINTFORML 「何でも命あっての物種だとは思わないかしら？」
		PRINTFORML 「まあいいわ。%CALLNAME_K9(咲夜_対象)%なら私もたのしめそうだし」
		PRINTFORML 「することなんて今更ね。いつまでも縛られていたければ引き伸ばしてもいいのよ」

	ELSE
		PRINTFORML 「何でも命あっての物種だとは思わないかしら？　……ってか、死にたいの？」
		PRINTFORML 「こんなこと、好きでするはずないじゃないの！　%CALLNAME_K9(咲夜_対象)%には死んで欲しくないだけよ」
		PRINTFORML 「無意味な抵抗はやめて、さっさと忠誠を誓えばいいのよ」

	ENDIF

;─────────────────────────────────────── 
;○二回目以降
;─────────────────────────────────────── 
ELSE

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:咲夜:虚ろ
		PRINTFORML 「……う……ぅう……ん……」
		PRINTFORMDL %ANAME(咲夜)%は虚ろな瞳で近付いてきた……
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常
	;───────────────────────────────────── 
	IF IS_SLAVE(咲夜)
		PRINTDATAL
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、お許しください……いえ、やっぱり無理かしらね」
			DATAFORM 「お叱りは後で、%CALLNAME_K9(咲夜_対象)%のお気の済むまでお受け致します」
			DATAFORM 「%CALLNAME_K9(咲夜_対象)%、ごめんなさい」
		ENDDATA

	ELSEIF CHECK_K9("敬語") && IS_LOVER(咲夜)
		PRINTDATA
			DATAFORM 「調教の時間です。
			DATAFORM 「お仕置きさせて頂きますわ。
			DATAFORM 「おたのしみの時間です。
			DATAFORM 「牝犬の時間です。
		ENDDATA
		PRINTDATAL
			DATAFORM %CALLNAME_K9(咲夜_対象)%も何をされるのかはご存知でしょう？」
			DATAFORM %CALLNAME_K9(咲夜_対象)%のあさましいお姿を暴くのは私の悦びですから」
			DATAFORM あら、お待たせしちゃってました？」
			DATAFORM で？　%CALLNAME_K9(咲夜_対象)%。おねだりはどうしたんですか」
			DATAFORM 愛犬ですから可愛がりますよ。グルーミングは大切でしょう？」
		ENDDATA

	ELSEIF CHECK_K9("敬語")
		PRINTDATA
			DATAFORM 「調教の時間です。
			DATAFORM 「お仕置きさせて頂きますわ。
			DATAFORM 「おたのしみの時間です。
			DATAFORM 「牝犬の時間です。
		ENDDATA
		PRINTDATAL
			DATAFORM ご安心ください。これもご奉仕ですから」
			DATAFORM 日頃はかしずく私だからこそ、%CALLNAME_K9(咲夜_対象)%を貶められるでしょうね」
			DATAFORM おかしいわ。%CALLNAME_K9(咲夜_対象)%は犬だったでしょうか？」
			DATAFORM で？　%CALLNAME_K9(咲夜_対象)%。おねだりはどうしたんですか」
		ENDDATA

	ELSEIF CFLAG:咲夜:好感度 >= 800
		PRINTDATA
			DATAFORM 「調教の時間よ。
			DATAFORM 「お仕置きの時間よ。
			DATAFORM 「おたのしみの時間よ。
			DATAFORM 「牝犬の時間よ。
		ENDDATA
		PRINTDATAL
			DATAFORM ふふっ。始めましょうか」
			DATAFORM おかしいわ。%CALLNAME_K9(咲夜_対象)%は犬だったかしらね？」
			DATAFORM で？　%CALLNAME_K9(咲夜_対象)%。おねだりはどうしたのかしら」
		ENDDATA

	ELSE
		PRINTDATAL
			DATAFORM 「じゃ、今日こそよろしくね？」
			DATAFORM 「うんと言ってくれたらすぐ終わるのよ？」
		ENDDATA

	ENDIF

ENDIF

;終了
WAIT
RESETCOLOR
RETURN 0

;─────────────────────────────────────── 
;●「捕虜逆調教(通常)」終了
;─────────────────────────────────────── 
@KOJO_TRAIN_END_C_K9
#DIM 咲夜_対象
#DIM 咲夜

咲夜_対象 = MASTER
咲夜 = NAME_TO_CHARA("咲夜")

;口上を使用しない設定なら戻る
SIF CFLAG:咲夜:400 == 1
	RETURN 0

SETCOLOR 咲夜_口上カラー

PRINTL 

;─────────────────────────────────────── 
;行動不能
;─────────────────────────────────────── 
;離脱済み
IF TCVAR:咲夜:53 > 1
	RESETCOLOR
	RETURN 0
ENDIF

IF TALENT:咲夜:虚ろ
	PRINTFORML 「う……んん……」
	PRINTFORMDL %ANAME(咲夜)%は%ANAME(咲夜_対象)%が立ち去ろうとしていることに気付いていないようだ
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

;酒酔いによる行動不能
IF TCVAR:咲夜:53 == 1
	PRINTFORML 「んはぁ……もうらめ……気持ちいいわぁ❤」
	PRINTFORMDL %ANAME(咲夜)%はぐでんぐでんになって赤ら顔をにやつかせながら寝ている
	WAIT
	RESETCOLOR
	RETURN 0
ENDIF

```
