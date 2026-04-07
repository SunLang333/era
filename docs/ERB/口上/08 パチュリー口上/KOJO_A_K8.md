# 口上/08 パチュリー口上/KOJO_A_K8.ERB — 自动生成文档

源文件: `ERB/口上/08 パチュリー口上/KOJO_A_K8.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A2_K8, KOJO_TRAIN_END_A2_K8, KOJO_COM_AFTER_A_K8; UI/print

前 200 行源码片段:

```text
﻿;=================================================
;●「閨に呼ぶ」の開始時のセリフ ※単独で呼ばれた場合のみ呼ばれる
;=================================================
@KOJO_TRAIN_START_A2_K8
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF



;=================================================
;●「閨に呼ぶ」の終了時のセリフ ※単独で呼ばれた場合のみ呼ばれる
;=================================================
@KOJO_TRAIN_END_A2_K8
#DIM 報酬
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF


;=================================================
;●コマンド実行後(パラメータの変動処理が終わってから呼び出される)
;=================================================
@KOJO_COM_AFTER_A_K8
;[虚ろ]状態の場合は口上を表示しない
IF TALENT:虚ろ
	RETURN 0
ENDIF
IF KDVAR:パチュリー_精液採取_調教中
	BASE:体力 = MAXBASE:体力
	BASE:気力 = MAXBASE:気力
ENDIF
;-------------------------------------------------
;主人公を射精させた
;-------------------------------------------------
IF NOWEX:MASTER:射精 > 0
	SELECTCASE GET_STACK_SPERM_TO(MASTER, TARGET)
		;膣に射精
		CASE 1
			IF KDVAR:パチュリー_精液採取_調教中
				SELECTCASE RAND:12
					CASE 0
						PRINTFORML 「っあ、なかっ、あっ、ああ……！」
					CASE 1
						PRINTFORML 「……あ、なか、あつっ……！」
					CASE 2
						PRINTFORML 「っ、くぅんっ……！」
					CASE 3
						PRINTFORML 「あ、でてっ……あぁっ……！」
					CASE 4
						PRINTFORML 「っあ、あぁッ……！」
						PRINTFORML 「……あ、は、採取、しなくちゃ……」
					CASE 5
						PRINTFORML 「はぁ、お腹の中っ、射精て……っ！」
						PRINTFORML 「……採取、しにくいじゃないの……」
					CASE 6
						PRINTFORML 「んんんんっ……！」
					CASE 7
						PRINTFORML 「っは、あはっ……」
				ENDSELECT
			;恋慕 or 服従
			ELSEIF TALENT:恋慕 || TALENT:服従
				;PRINTFORMW 
			;それ以外
			ELSE
				;PRINTFORMW 
			ENDIF
		;アナルに射精
		CASE 2
			IF KDVAR:パチュリー_精液採取_調教中
				SELECTCASE RAND:12
					CASE 0
						PRINTFORML 「っあ、おしり、あっ、ああ……！」
					CASE 1
						PRINTFORML 「……あ、やっ、あつっ……！」
					CASE 2
						PRINTFORML 「っ、ぅあ、お尻っ、ぃいっ……！」
					CASE 3
						PRINTFORML 「あっ、お腹の中ッ、でてっ……！」
					CASE 4
						PRINTFORML 「はぁあっ、アッ……！」
						PRINTFORML 「……あ、は、採取、しなくちゃ……」
					CASE 5
						PRINTFORML 「うぁ、お腹の中、でて……っ！」
						PRINTFORML 「……そっちに射精されると、不純物が混じるのだけど……」
					CASE 6
						PRINTFORML 「んんんんっ……！」
					CASE 7
						PRINTFORML 「っは、あはっ……」
				ENDSELECT
			;恋慕 or 服従
			ELSEIF TALENT:恋慕 || TALENT:服従
				;PRINTFORMW 
			;それ以外
			ELSE
				;PRINTFORMW 
			ENDIF
		;手に射精
		CASE 3
			IF KDVAR:パチュリー_精液採取_調教中
				SELECTCASE RAND:12
					CASE 0
						PRINTFORML 「ん……、出した？」
					CASE 1
						PRINTFORML 「……精液って、意外と熱いのね」
					CASE 2
						PRINTFORML 「ちょっと待ってね……採取するから」
					CASE 3
						PRINTFORML 「沢山出るわね……まあ、私にとっても好都合だわ」
					CASE 4
						PRINTFORML 「気持ちよさそうな顔ね……」
						PRINTFORML 「……私の手、そんなによかった？」
					CASE 5
						PRINTFORML 「ん、……」
						PRINTFORML 「……手で射精させるのが、不純物も混じらなくて一番効率的ね」
					CASE 6
						PRINTFORML 「ん……射精したの？」
						PRINTFORML 「悪いけど、もう少しつきあってちょうだい……あといくらかサンプルがほしいの」
				ENDSELECT
			;恋慕 or 服従
			ELSEIF TALENT:恋慕 || TALENT:服従
				;PRINTFORMW 
			;それ以外
			ELSE
				;PRINTFORMW 
			ENDIF
		;口に射精
		CASE 4
			IF KDVAR:パチュリー_精液採取_調教中
				SELECTCASE RAND:12
					CASE 0
						PRINTFORML 「ん……、んむ……」
					CASE 1
						PRINTFORML 「んくっ……んぅ」
						PRINTFORML 「……苦いとか、臭いとか、本には書いてあったけど」
						PRINTFORML 「無味無臭なのね、意外と」
					CASE 2
						PRINTFORML 「んくっ……！？」
						PRINTFORML 「んっ、こほっ、けほっ……」
					CASE 3
						PRINTFORML 「んぐっ……」
						PRINTFORML 「……ねぇ、この方法、喉によくないと思うのだけど」
					CASE 4
						PRINTFORML 「んんぐ……」
						PRINTFORML 「……舌に味が残ってる。ものが食べれないじゃない……」
					CASE 5
						PRINTFORML 「ん、……くちゅ」
						PRINTFORML 「……んっ……くむ……んふ……」
					CASE 6
						PRINTFORML 「ん……ぇお」
						PRINTFORML 「……唾液が混ざるのが難点ね。あと顎も疲れるし」
				ENDSELECT
			;恋慕 or 服従
			ELSEIF TALENT:恋慕 || TALENT:服従
				;PRINTFORMW 
			;それ以外
			ELSE
				;PRINTFORMW 
			ENDIF
		;胸に射精
		CASE 5
			IF KDVAR:パチュリー_精液採取_調教中
				SELECTCASE RAND:12
					CASE 0
						PRINTFORML 「……男って、本当に胸が好きなのね」
					CASE 1
						PRINTFORML 「ん……」
						PRINTFORML 「精液って、意外と熱いのね」
					CASE 2
						PRINTFORML 「ちょっと待ってね……採取するから」
					CASE 3
						PRINTFORML 「沢山出るわね……まあ、私にとっても好都合だわ」
					CASE 4
						PRINTFORML 「気持ちよさそうな顔ね……」
						PRINTFORML 「……私の胸、そんなによかった？」
					CASE 5
						PRINTFORML 「ん、……」
						PRINTFORML 「……胸で射精させるの、不純物も混じらなくて効率的ね」
						PRINTFORML 「行為自体は間抜けだけどね……」
					CASE 6
						PRINTFORML 「ん……射精したの？」
						PRINTFORML 「悪いけど、もう少しつきあってちょうだい……もうちょっとサンプルがほしいの」
				ENDSELECT
			;恋慕 or 服従
			ELSEIF TALENT:恋慕 || TALENT:服従
				;PRINTFORMW 
			;それ以外
			ELSE
				;PRINTFORMW 
			ENDIF
		;足に射精
		CASE 6
			IF KDVAR:パチュリー_精液採取_調教中
				SELECTCASE RAND:4
					CASE 0
						PRINTFORML 「ん……」
						PRINTFORML 「……ねえ、こんなところに射精して楽しい？」
					CASE 1
```
