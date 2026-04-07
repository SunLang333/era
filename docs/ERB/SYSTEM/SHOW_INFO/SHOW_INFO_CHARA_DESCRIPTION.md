# SYSTEM/SHOW_INFO/SHOW_INFO_CHARA_DESCRIPTION.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SHOW_INFO/SHOW_INFO_CHARA_DESCRIPTION.ERB`

类型: .ERB

自动摘要: functions: SHOW_INFO_ERO_DESCRIPTION, SHOW_INFO_ERO_DESCRIPTION_BODY, SHOW_INFO_ERO_DESCRIPTION_SENSE, SHOW_INFO_ERO_DESCRIPTION_FETISH, SHOW_INFO_ERO_DESCRIPTION_FALLEN, SHOW_INFO_ERO_DESCRIPTION_SP_FALLEN; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;エロステータス表示
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION(対象)
#DIM 対象
CALL SINGLE_DRAWLINE
PRINTFORML 肉体
CALL COLOR_LINE

CALL SHOW_INFO_ERO_DESCRIPTION_BODY(対象)

CALL SINGLE_DRAWLINE
PRINTFORML 感覚
CALL COLOR_LINE

CALL SHOW_INFO_ERO_DESCRIPTION_SENSE(対象)

CALL SINGLE_DRAWLINE
PRINTFORML 性的嗜好
CALL COLOR_LINE

CALL SHOW_INFO_ERO_DESCRIPTION_FETISH(対象)

CALL SINGLE_DRAWLINE
PRINTFORML 陥落
CALL COLOR_LINE

CALL SHOW_INFO_ERO_DESCRIPTION_FALLEN(対象)

CALL SINGLE_DRAWLINE
PRINTFORML 特殊な陥落
CALL COLOR_LINE

CALL SHOW_INFO_ERO_DESCRIPTION_SP_FALLEN(対象)

CALL SINGLE_DRAWLINE
PRINTFORML SLG説明
CALL COLOR_LINE
TRYCCALLFORM SHOW_CHARA_EXPLANATION_{NO:(対象)}
	CALL SINGLE_EMPTY_LINE()
CATCH
	PRINTFORML SLG説明なし　
	CALL SINGLE_EMPTY_LINE()
ENDCATCH

;-------------------------------------------------
;エロステータス表示　肉体
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_BODY(対象)
#DIM 対象
IF TALENT:対象:キス未経験
	PRINTFORML 口づけを交わしたことがない
ELSE
	CALL COLOR_PRINT(SEXUAL_EXPERIENCE:対象:初体験_キス == "不明" ? "誰か" # SEXUAL_EXPERIENCE:対象:初体験_キス, カラー_ピンク, "に", GETDEFCOLOR())
	SIF SEXUAL_EXPERIENCE_SITUATION:対象:初体験_キス != ""
		CALL COLOR_PRINT(SEXUAL_EXPERIENCE_SITUATION:対象:初体験_キス, カラー_ピンク, "で", GETDEFCOLOR())
	PRINTFORML 唇の初めてを捧げた
	IF SEXUAL_LAST_EXPERIENCE:対象:初体験_キス != ""
		CALL COLOR_PRINT("直近では", GETDEFCOLOR(), SEXUAL_LAST_EXPERIENCE:対象:初体験_キス == "不明" ? "誰か" # SEXUAL_LAST_EXPERIENCE:対象:初体験_キス, カラー_ピンク, "に", GETDEFCOLOR())
		SIF SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_キス != ""
			CALL COLOR_PRINT(SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_キス, カラー_ピンク, "で", GETDEFCOLOR())
		PRINTFORML 口づけている
	ENDIF
ENDIF

IF HAS_VAGINA(対象)
	IF TALENT:対象:処女
		PRINTFORML 膣穴は純潔を保っている
	ELSE
		CALL COLOR_PRINT(SEXUAL_EXPERIENCE:対象:初体験_処女 == "不明" ? "誰か" # SEXUAL_EXPERIENCE:対象:初体験_処女, カラー_ピンク, "に", GETDEFCOLOR())
		SIF SEXUAL_EXPERIENCE_SITUATION:対象:初体験_処女 != ""
			CALL COLOR_PRINT(SEXUAL_EXPERIENCE_SITUATION:対象:初体験_処女, カラー_ピンク, "で", GETDEFCOLOR())
		PRINTFORML 純潔を捧げた
		IF SEXUAL_LAST_EXPERIENCE:対象:初体験_処女 != ""
			CALL COLOR_PRINT("直近では", GETDEFCOLOR(), SEXUAL_LAST_EXPERIENCE:対象:初体験_処女 == "不明" ? "誰か" # SEXUAL_LAST_EXPERIENCE:対象:初体験_処女, カラー_ピンク, "と", GETDEFCOLOR())
			SIF SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_処女 != ""
				CALL COLOR_PRINT(SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_処女, カラー_ピンク, "で", GETDEFCOLOR())
			PRINTFORML 交わっている
		ENDIF
	ENDIF
ENDIF

IF TALENT:対象:アナル処女
	PRINTFORML 尻穴は純潔を保っている
ELSE
	CALL COLOR_PRINT(SEXUAL_EXPERIENCE:対象:初体験_アナル処女 == "不明" ? "誰か" # SEXUAL_EXPERIENCE:対象:初体験_アナル処女, カラー_ピンク, "に", GETDEFCOLOR())
	SIF SEXUAL_EXPERIENCE_SITUATION:対象:初体験_アナル処女 != ""
		CALL COLOR_PRINT(SEXUAL_EXPERIENCE_SITUATION:対象:初体験_アナル処女, カラー_ピンク, "で", GETDEFCOLOR())
	PRINTFORML 尻穴での初体験を捧げた
	IF SEXUAL_LAST_EXPERIENCE:対象:初体験_アナル処女 != ""
		CALL COLOR_PRINT("直近では", GETDEFCOLOR(), SEXUAL_LAST_EXPERIENCE:対象:初体験_アナル処女 == "不明" ? "誰か" # SEXUAL_LAST_EXPERIENCE:対象:初体験_アナル処女, カラー_ピンク, "と", GETDEFCOLOR())
		SIF SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_アナル処女 != ""
			CALL COLOR_PRINT(SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_アナル処女, カラー_ピンク, "で", GETDEFCOLOR())
		PRINTFORML 交わっている
	ENDIF
ENDIF

IF HAS_PENIS(対象)
	IF TALENT:対象:童貞
		PRINTFORML 未だ童貞だ
	ELSE
		CALL COLOR_PRINT(SEXUAL_EXPERIENCE:対象:初体験_童貞 == "不明" ? "誰か" # SEXUAL_EXPERIENCE:対象:初体験_童貞, カラー_ピンク, "に", GETDEFCOLOR())
		SIF SEXUAL_EXPERIENCE_SITUATION:対象:初体験_童貞 != ""
			CALL COLOR_PRINT(SEXUAL_EXPERIENCE_SITUATION:対象:初体験_童貞, カラー_ピンク, "で", GETDEFCOLOR())
		PRINTFORML 童貞を捧げた
		IF SEXUAL_LAST_EXPERIENCE:対象:初体験_童貞 != ""
			CALL COLOR_PRINT("直近では", GETDEFCOLOR(), SEXUAL_LAST_EXPERIENCE:対象:初体験_童貞 == "不明" ? "誰か" # SEXUAL_LAST_EXPERIENCE:対象:初体験_童貞, カラー_ピンク, "と", GETDEFCOLOR())
			SIF SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_童貞 != ""
				CALL COLOR_PRINT(SEXUAL_LAST_EXPERIENCE_SITUATION:対象:初体験_童貞, カラー_ピンク, "で", GETDEFCOLOR())
			PRINTFORML 交わっている
		ENDIF
	ENDIF
ENDIF

IF IS_FEMALE(対象)
	SELECTCASE GET_BUSTSIZE(対象)
		CASE -2
			PRINTFORML 胸にはふくらみがなく、まったくの平らだ
		CASE -1
			PRINTFORML 乳房は小ぶりながらも整った形をしている
		CASE 0
			PRINTFORML 乳房はちょうどいい大きさの魅力的な形をしている
		CASE 1
			PRINTFORML 豊かで柔らかそうな乳房が目をひく
		CASE 2
			PRINTFORML はちきれんほどたわわに実った乳房が視線をくぎ付けにする
	ENDSELECT
	SELECTCASE GET_HIPSIZE(対象)
		CASE -2
			PRINTFORML 尻の肉付きはかなり薄く、まったくの平らだ
		CASE -1
			PRINTFORML 尻は小ぶりながらも整った形をしている
		CASE 0
			PRINTFORML 尻はちょうどいい大きさの魅力的な形をしている
		CASE 1
			PRINTFORML 豊かで弾力のある尻が目をひく
		CASE 2
			PRINTFORML はちきれんほど肉の詰まった尻が視線をくぎ付けにする
	ENDSELECT
	SIF TALENT:対象:母乳体質
		CALL COLOR_PRINTL("乳房からは母乳が分泌されている", カラー_ピンク)
	SIF TALENT:対象:美脚
		PRINTFORML すらりとした美しい脚が異性を魅了する
	SIF TALENT:対象:美尻
		PRINTFORML 尻肉は美しく、きゅっと引き締まっている
ENDIF

IF TALENT:対象:妊娠
	CALL ICPRINT(@"<\@ GET_SPERM_NAME(CFLAG:対象:子の父親) == "不明" ? 父親不明 # %GET_SPERM_NAME(CFLAG:(対象):子の父親)% \@>の子を宿している", "L", カラー_ピンク)
	SIF CFLAG:対象:行動不能状態 == 行動不能_臨月
		CALL COLOR_PRINTL("臨月を迎えた腹は大きく膨れている", カラー_ピンク)
ENDIF 

FOR LOCAL, 0, 2
	IF LOCAL == 0
		SIF !HAS_VAGINA(対象)
			CONTINUE
		LOCAL:1 = TALENT:対象:Ｖ締まり
		LOCALS = 女穴
	ELSE
		LOCAL:1 = TALENT:対象:Ａ締まり
		LOCALS = 尻穴
	ENDIF
	SELECTCASE LOCAL:1
		CASE IS >= 締まり_ぎちぎち
			PRINTFORML %LOCALS%は小指すら拒むほど狭い
		CASE IS >= 締まり_きつきつ
			PRINTFORML %LOCALS%は小指でもきゅうと締め付ける狭さだ
		CASE IS >= 締まり_きゅっきゅっ
			PRINTFORML %LOCALS%は指をきゅうきゅうと締め付けてくる
		CASE IS >= 締まり_名器
			PRINTFORML %LOCALS%は咥えたものに快感を与える名器だ
		CASE IS >= 締まり_普通
			PRINTFORML %LOCALS%の締まりは普通といったところだ
		CASE IS >= 締まり_ゆるめ
			PRINTFORML %LOCALS%の締まりはゆるめだ
		CASE IS >= 締まり_ゆるゆる
			PRINTFORML %LOCALS%はずいぶん緩くなってしまっている
		CASE IS >= 締まり_ぽっかり
			PRINTFORML 使い込まれた%LOCALS%はぽっかりと開いて閉じなくなっている
		CASE IS >= 締まり_がばがば
			PRINTFORML 使い込まれすぎて、%LOCALS%は型崩れしてがばがばになっている
		CASE IS >= 締まり_崩壊
			PRINTFORML 使い込まれすぎて、%LOCALS%は元の形がわからないほど崩れてしまっている
		CASEELSE
			PRINTFORML 使い込まれすぎて、%LOCALS%は醜く黒ずみ、ぐずぐずになり、濃厚な牝臭を放っている
	ENDSELECT
NEXT

SELECTCASE TALENT:対象:陰毛現在値
	CASE 陰毛_パイパン
		PRINTFORML 陰毛は脱毛され、恥丘はつるつるとしている
	CASE 陰毛_つるつる
		PRINTFORML 陰毛の生えていない恥丘はつるつるとしている
	CASE 陰毛_うっすら
		PRINTFORML 恥丘にはうっすらと、陰毛が産毛のように生えている
	CASE 陰毛_柔毛
		PRINTFORML 陰毛は生えかけのようだ
	CASE 陰毛_ふんわり
		PRINTFORML 薄めの陰毛が恥丘で草むらを形作っている
```
