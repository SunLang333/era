# 口上/10 レミリア口上/STARTEND_K10/KOJO_A1_NOON_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/STARTEND_K10/KOJO_A1_NOON_K10.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K10, KOJO_DESCRIPTION_CHARA_K10, KOJO_TRAIN_END_A1_K10; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●「会いに行く」の開始時
;─────────────────────────────────────── 
@KOJO_TRAIN_START_A1_K10
#DIM レミリア_対象
#DIM レミリア
#DIMS レミリア機嫌

レミリア_対象 = MASTER
レミリア = NAME_TO_CHARA("レミリア")
レミリア機嫌 = %TOSTR_EMOTION(レミリア)%

;レミリア口上の使用可否設定と初期化
SIF CFLAG:レミリア:400 == 0
	CALL KOJO_ASK_RESET_K10

;口上を使用しない設定なら戻る
SIF CFLAG:レミリア:400 == 1
	RETURN 0

SETCOLOR レミリア_口上カラー

;─────────────────────────────────────── 
;○初回
;─────────────────────────────────────── 
IF CFLAG:レミリア:200 == 0

	;会いに行く口上初回呼び出しフラグオン
	CFLAG:レミリア:200 = 1

	;───────────────────────────────────── 
	;▼虚ろ
	;───────────────────────────────────── 
	IF TALENT:レミリア:虚ろ
		PRINTFORML 「あ……うー……」
		PRINTFORMDL %ANAME(レミリア)%は乱れた服装で人形のように手足を投げ出している
		WAIT
		RESETCOLOR
		RETURN 0
	ENDIF

	;───────────────────────────────────── 
	;▼通常初対面
	;　面識がなく紅魔館メンバーや知人キャラでない場合
	;───────────────────────────────────── 
	IF !CHECK_K10("面識")
		;同勢力
		IF CFLAG:レミリア:所属 == CFLAG:(レミリア_対象):所属
			;レミリア君主
			IF GET_COUNTRY_BOSS(CFLAG:レミリア:所属) == NAME_TO_CHARA("レミリア")
				PRINTFORMW 「入りなさい」
				PRINTL 
				PRINTFORM 「%CALLNAME_K10(レミリア_対象)%ね。私がこの城の主、
				CALL COLOR_PRINT(@"%NAME_FORMAL(レミリア)%", カラー_赤)
				PRINTFORML 。誇り高き吸血鬼」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿１")
				PRINTL 
				IF HAS_TAG(レミリア_対象, タグ_人間) || IS_TAG_EMPTY(レミリア_対象)
					PRINTFORML 「人間がどこまで使えるかわからないけれど、活躍に期待してあげるわ」
					PRINTFORML 「私を畏れるただの人間なら、餌にしてやろう」
				ELSEIF HAS_TAG(レミリア_対象, タグ_悪魔)
					PRINTFORML 「%CALLNAME_K10(レミリア_対象)%も悪魔なのでしょう？　活躍に期待してあげるわ」
				ELSE
					PRINTFORML 「%CSTR:レミリア_対象:8%がどこまで使えるかわからないけれど、活躍に期待してあげるわ」
				ENDIF
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿２")
				PRINTL 
				PRINTFORML 「ふわぁ～あ。んー……」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格１")
				PRINTL 
				PRINTFORML 「ところで、目の覚めるような面白い話はない？　宵は少し眠いのよ」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格２")
			;あなた君主
			ELSEIF GET_COUNTRY_BOSS(CFLAG:レミリア:所属) == レミリア_対象
				PRINTFORMW 「入っていいわよ」
				PRINTL 
				PRINTFORM 「%CALLNAME_K10(レミリア_対象)%。この城の主ね。――私は
				CALL COLOR_PRINT(@"%NAME_FORMAL(レミリア)%", カラー_赤)
				PRINTFORML 。誇り高き吸血鬼」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿１")
				PRINTL 
				PRINTFORML 「%CALLNAME_K10(レミリア_対象)%の活躍には期待してるから、協力してあげるわね」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿２")
				PRINTL 
				PRINTFORML 「ふわぁ～あ。んー……」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格１")
				PRINTL 
				PRINTFORML 「ところで、目の覚めるような面白い話はない？　宵は少し眠いのよ」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格２")
			;ともに士官
			ELSE
				PRINTFORMW 「入りなさい」
				PRINTL 
				PRINTFORML 「え。あんた誰？」
				PRINTFORM 「……ふーん。%CALLNAME_K10(レミリア_対象)%ね。――私は
				CALL COLOR_PRINT(@"%NAME_FORMAL(レミリア)%", カラー_赤)
				PRINTFORML 。誇り高き吸血鬼」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿１")
				PRINTL 
				IF HAS_TAG(レミリア_対象, タグ_人間) || IS_TAG_EMPTY(レミリア_対象)
					PRINTFORML 「人間がどこまで使えるかわからないけれど、活躍に期待してあげるわ」
					PRINTFORML 「私を畏れるただの人間なら、餌にしてやろう」
				ELSEIF HAS_TAG(レミリア_対象, タグ_悪魔)
					PRINTFORML 「%CALLNAME_K10(レミリア_対象)%も悪魔なのでしょう？　活躍に期待してあげるわ」
				ELSE
					PRINTFORML 「%CSTR:レミリア_対象:8%がどこまで使えるかわからないけれど、活躍に期待してあげるわ」
				ENDIF
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿２")
				PRINTL 
				PRINTFORML 「ふわぁ～あ。んー……」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格１")
				PRINTL 
				PRINTFORML 「ところで、目の覚めるような面白い話はない？　宵は少し眠いのよ」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格２")
			ENDIF
		;違勢力
		ELSE
			;レミリア君主
			IF GET_COUNTRY_BOSS(CFLAG:レミリア:所属) == NAME_TO_CHARA("レミリア")
				PRINTFORMW 「入りなさい」
				PRINTL 
				PRINTFORM 「%CALLNAME_K10(レミリア_対象)%ね。私がこの城の主、
				CALL COLOR_PRINT(@"%NAME_FORMAL(レミリア)%", カラー_赤)
				PRINTFORML 。誇り高き吸血鬼」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿１")
				PRINTL 
				IF HAS_TAG(レミリア_対象, タグ_人間) || IS_TAG_EMPTY(レミリア_対象)
					PRINTFORML 「人間がどこまで使えるかわからないけれど、協力に期待してあげるわ」
					PRINTFORML 「私を畏れるただの人間なら、餌にしてやろう」
				ELSEIF HAS_TAG(レミリア_対象, タグ_悪魔)
					PRINTFORML 「%CALLNAME_K10(レミリア_対象)%も悪魔なのでしょう？　協力に期待してあげるわ」
				ELSE
					PRINTFORML 「%CSTR:レミリア_対象:8%がどこまで使えるかわからないけれど、協力に期待してあげるわ」
				ENDIF
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿２")
				PRINTL 
				PRINTFORML 「ふわぁ～あ。んー……」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格１")
				PRINTL 
				PRINTFORML 「ところで、目の覚めるような面白い話はない？　宵は少し眠いのよ」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格２")

			;あなた君主
			ELSEIF GET_COUNTRY_BOSS(CFLAG:レミリア:所属) == レミリア_対象
				PRINTFORMW 「入っていいわよ」
				PRINTL 
				PRINTFORM 「%CALLNAME_K10(レミリア_対象)%。この城の主ね。――私は
				CALL COLOR_PRINT(@"%NAME_FORMAL(レミリア)%", カラー_赤)
				PRINTFORML 。誇り高き吸血鬼」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿１")
				PRINTL 
				PRINTFORML 「%CALLNAME_K10(レミリア_対象)%の活躍には期待してるから、協力してあげるわね」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿１")
				PRINTL 
				PRINTFORML 「ふわぁ～あ。んー……」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格１")
				PRINTL 
				PRINTFORML 「ところで、目の覚めるような面白い話はない？　宵は少し眠いのよ」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格２")
			;共に士官
			ELSE
				PRINTFORMW 「入りなさい」
				PRINTL 
				PRINTFORML 「え。あんた誰？」
				PRINTFORM 「……ふーん。%CALLNAME_K10(レミリア_対象)%ね。――私は
				CALL COLOR_PRINT(@"%NAME_FORMAL(レミリア)%", カラー_赤)
				PRINTFORML 。誇り高き吸血鬼」
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿１")
				PRINTL 
				IF HAS_TAG(レミリア_対象, タグ_人間) || IS_TAG_EMPTY(レミリア_対象)
					PRINTFORML 「人間がどこまで使えるかわからないけれど、協力に期待してあげるわ」
					PRINTFORML 「私を畏れるただの人間なら、餌にしてやろう」
				ELSEIF HAS_TAG(レミリア_対象, タグ_悪魔)
					PRINTFORML 「%CALLNAME_K10(レミリア_対象)%も悪魔なのでしょう？　協力に期待してあげるわ」
				ELSE
					PRINTFORML 「%CSTR:レミリア_対象:8%がどこまで使えるかわからないけれど、協力に期待してあげるわ」
				ENDIF
				CALL KOJO_DESCRIPTION_CHARA_K10("容姿２")
				PRINTL 
				PRINTFORML 「ふわぁ～あ。んー……」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格１")
				PRINTL 
				PRINTFORML 「ところで、目の覚めるような面白い話はない？　宵は少し眠いのよ」
				CALL KOJO_DESCRIPTION_CHARA_K10("性格２")
			ENDIF
		ENDIF
	;───────────────────────────────────── 
	;▼通常初対面ではない
	;　面識があるまたは紅魔館メンバーや知人キャラの場合
	;───────────────────────────────────── 
	ELSE
		;同勢力
		IF GET_COUNTRY_BOSS(CFLAG:レミリア:所属) == GET_COUNTRY_BOSS(CFLAG:(レミリア_対象):所属)
			;親しい知り合い
			IF CHECK_K10("紅魔館", レミリア_対象)
				PRINTFORMW 「入りなさい」
				PRINTL 
				PRINTFORML 「%CALLNAME_K10(レミリア_対象)%。優秀ね。ちょうど目が覚めたところよ」
				PRINTFORML 「着替えをとってくれるかしら」
				PRINTFORML 「陣地取りゲームが始まったけれど、当然この私が勝つわよ」
```
