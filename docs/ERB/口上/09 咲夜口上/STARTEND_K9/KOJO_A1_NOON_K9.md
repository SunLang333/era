# 口上/09 咲夜口上/STARTEND_K9/KOJO_A1_NOON_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/STARTEND_K9/KOJO_A1_NOON_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K9, KOJO_DESCRIPTION_CHARA_K9, KOJO_TRAIN_END_A1_K9; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●「会いに行く」の開始時
;─────────────────────────────────────── 
@KOJO_TRAIN_START_A1_K9
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
IF CFLAG:咲夜:200 == 0

	;会いに行く口上初回呼び出しフラグオン
	CFLAG:咲夜:200 = 1

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:咲夜:虚ろ
		PRINTFORML 「あ……うー……」
		PRINTFORMDL %ANAME(咲夜)%は乱れた服装で人形のように手足を投げ出している
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常初対面
	;　面識がなく紅魔館メンバーや知人キャラでない場合
	;───────────────────────────────────── 
	IF !CHECK_K9("面識")
		;同勢力
		IF CFLAG:咲夜:所属 == CFLAG:(咲夜_対象):所属
			;主人公が咲夜の君主
			IF 咲夜_対象 == GET_COUNTRY_BOSS(CFLAG:咲夜:所属)
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%。ご足労くださってありがとうございます」
				PRINTFORML 「私は紅魔館で使用人を務めておりました、%NAME_FORMAL(咲夜)%と申します」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「今後は%CALLNAME_K9(咲夜_対象)%のお世話になります」
				PRINTFORML 「身の回りのお世話はどうぞお任せください」
				PRINTFORML 「お茶の濃さもお菓子の甘さも%CALLNAME_K9(咲夜_対象)%のお好み通りに致します」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;咲夜が主人公の君主
			ELSEIF 咲夜 == GET_COUNTRY_BOSS(CFLAG:咲夜_対象:所属)
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%ね。私に士官してくれたのでしょう？」
				PRINTFORML 「話は聞いているわ。私はレミリアお嬢様に仕える紅魔館のメイド長……」
				PRINTFORML 「だったのだけど。事情が変わって、今はここのあるじを務めているの」
				PRINTFORML 「%NAME_FORMAL(咲夜)%よ。よろしく頼むわね」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「掛けてちょうだい。今日はおもてなしするわ。これからたくさん働いてもらうもの」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;共に士官で君主はレミリア
			ELSEIF GET_COUNTRY_BOSS(CFLAG:咲夜:所属) == NAME_TO_CHARA("レミリア") 
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%ね。待っていたのよ」
				PRINTFORML 「お嬢様に雇われたのでしょう？　話は聞いているわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「私は紅魔館のメイド長を務めている、%NAME_FORMAL(咲夜)%。よろしくね」
				PRINTFORML 「掛けてちょうだい。これからたくさん働いてもらうんだもの。おもてなしするわよ」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;共に士官
			ELSE
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%ね。話は聞いているわ」
				PRINTFORML 「私は%NAME_FORMAL(咲夜)%。よろしくお願いするわね」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「掛けて。ちょうど休憩時間だし良かったらお話しましょう」
				PRINTFORML 「同じあるじに勤める仲間だもの。歓迎するわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")
			ENDIF

		;違勢力
		ELSE
			;主人公が君主かつ咲夜が君主
			IF GET_COUNTRY_BOSS(CFLAG:咲夜_対象:所属) ==  咲夜_対象 && GET_COUNTRY_BOSS(CFLAG:咲夜:所属) == 咲夜
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「あら。%CALLNAME_K9(咲夜_対象)%。お世話になるわね」
				PRINTFORML 「改めて挨拶したほうがいいかしら。私は紅魔館のメイド長を務めていた%NAME_FORMAL(咲夜)%よ」
				PRINTFORML 「今は雇う側だけれど、%CALLNAME_K9(咲夜_対象)%もそうなのでしょう？」
				PRINTFORML 「よろしくお願いするわね、先輩。相談できると嬉しいわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「掛けてちょうだい。そのお礼って訳じゃないけど、おもてなしするわよ」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;主人公が君主かつ咲夜の君主はレミリア
			ELSEIF GET_COUNTRY_BOSS(CFLAG:咲夜_対象:所属) == 咲夜_対象 && GET_COUNTRY_BOSS(CFLAG:咲夜:所属) == NAME_TO_CHARA("レミリア")
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「あら。%CALLNAME_K9(咲夜_対象)%」
				PRINTFORML 「申し遅れました。私は紅魔館の使用人、%NAME_FORMAL(咲夜)%と申します」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「お嬢様がお世話になる方は、私がお世話になる方です」
				PRINTFORML 「なにとぞよろしくお願いします」
				PRINTFORML 「お掛けください。お待たせは致しませんわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;咲夜が君主
			ELSEIF GET_COUNTRY_BOSS(CFLAG:咲夜:所属) == 咲夜
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「あなたは……どなただったかしら？」
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%？　そう。わざわざ挨拶に来てくれたのね」
				PRINTFORML 「申し遅れたけど、私はレミリアお嬢様に仕える紅魔館のメイド長……だったのだけど」
				PRINTFORML 「事情が変わって今はここのあるじを務めている、%NAME_FORMAL(咲夜)%よ」
				PRINTFORML 「よろしくお願いするわね」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「掛けてちょうだい。せっかく来てくれたのだから、おもてなしするわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;咲夜の君主はレミリア
			ELSEIF GET_COUNTRY_BOSS(CFLAG:咲夜:所属) == NAME_TO_CHARA("レミリア")
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「あなたは……どなただったかしら？」
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%？　そう。お嬢様がお世話になっているのね」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「申し遅れたけど、私は紅魔館のメイド長を務めている%NAME_FORMAL(咲夜)%」
				PRINTFORML 「よろしくね。どうぞ、せっかく来てくれたんだもの。おもてなしするわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;それ以外
			ELSE
				PRINTFORML 「どうぞ。開いてるわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("容姿")
				PRINTL 
				PRINTFORML 「あなたは……どなただったかしら？」
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%？　そう。よろしくね」
				PRINTFORML 「申し遅れたけど、私は%NAME_FORMAL(咲夜)%。レミリアお嬢様に仕える紅魔館のメイド長……」
				PRINTFORML 「だったのだけど。事情が変わって、今はここで雇ってもらっている身よ」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「掛けてちょうだい。せっかく来てくれたのだし、おもてなしするわ」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			ENDIF
		ENDIF

	;───────────────────────────────────── 
	;▼通常初対面ではない
	;　面識があるまたは紅魔館メンバーや知人キャラの場合
	;───────────────────────────────────── 
	ELSE
		;同勢力
		IF CFLAG:咲夜:所属 == CFLAG:(咲夜_対象):所属
			;デイリーによる出会い
			IF KDVAR:咲夜:咲夜_主の主は
				PRINTFORMW 「どうぞ。開いてるわ」
				PRINTL 
				PRINTFORML 「%CALLNAME_K9(咲夜_対象)%。お待ちしておりました」
				PRINTFORML 「早速、何かご命令でしょうか？　ご期待は裏切りません」
				CALL KOJO_DESCRIPTION_CHARA_K9("能力")
				PRINTL 
				PRINTFORML 「……雑談ですか？　いえ、意外で。ええ、わかりました」
				PRINTFORML 「お掛けください。すぐにお茶を用意致します」
				PRINTFORML 「改めてご挨拶を。私は紅魔館のメイド長、%NAME_FORMAL(咲夜)%と申します」
				CALL KOJO_DESCRIPTION_CHARA_K9("職業")

			;デイリーによる出会い
			ELSEIF KDVAR:咲夜:咲夜_主の客は
				PRINTFORMW 「どうぞ。開いてるわ」
				PRINTL 
```
