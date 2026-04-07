# SKILLS/FUNCTIONS_SKILL.ERB — 自动生成文档

源文件: `ERB/SKILLS/FUNCTIONS_SKILL.ERB`

类型: .ERB

自动摘要: functions: PASSIVE_SKILL_NAME_TO_ID, FIND_PASSIVE_SKILL, FIND_GENERAL_SKILL, SKILL_COMBAT_INVOKE, SKILL_COMBAT_TRY_INVOKE, TECHNOLOGY_PERSONAL_SKILL_COMBAT_INVOKE, TECHNOLOGY_TROOP_SKILL_COMBAT_INVOKE, SKILL_PRINT_INVOKE, COMBAT_ASSASINATE, BATTLE_SUMMON, BATTLE_ADD_MOB, SKILL_INIT, SKILL_EXPLANATION, SKILL_LEARN_BY_NAME, SKILL_LEARN, SKILL_FORGET, SKILL_FORGET_BY_NAME, GET_EMPTY_SKILL_SLOT, LEARN_SKILL_GENERAL_BY_NAME, CHECK_SKILL_DUPLICATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;---------------------------------
;指定した名前のパッシブスキルを探す
;---------------------------------
@PASSIVE_SKILL_NAME_TO_ID(スキル名)
#FUNCTION
#DIM 発動者
#DIMS スキル名
SELECTCASE スキル名
	CASE "超成長力"
		RETURNF 0
	CASE "努力家"
		RETURNF 1
	CASE "治療"
		RETURNF 2
	CASE "明察"
		RETURNF 3
	CASE "工作員"
		RETURNF 4
ENDSELECT

RETURNF -1

;---------------------------------
;指定した名前のパッシブスキルがあるかを探す
;---------------------------------
@FIND_PASSIVE_SKILL(発動者, スキル名)
#FUNCTION
#DIM 発動者
#DIMS スキル名
#DIM スキルID
#DIM パッシブ

スキルID = PASSIVE_SKILL_NAME_TO_ID(スキル名)

SIF スキルID == -1
	THROW 該当する名前のスキルなし

パッシブ = FINDELEMENT(SKILL_GENRE_ENG, "PASSIVE")

FOR LOCAL, 0, MAX_SKILL_SLOT
	SIF SKILL_NO_SLOT:発動者:パッシブ:LOCAL == 0 && SKILL_ID_SLOT:発動者:パッシブ:LOCAL == スキルID
		RETURNF 1
NEXT
RETURNF 0

@FIND_GENERAL_SKILL(発動者, スキル名)
#DIM 発動者
#DIMS スキル名
#DIM ジャンル
#DIM スキルID
FOR LOCAL, 0, VARSIZE("SKILL_GENRE")
	FOR LOCAL:1, 0, MAX_SKILLS
		TRYCCALLFORM SKILL_0_%SKILL_GENRE_ENG:LOCAL%_{LOCAL:1}_NAME()
			IF RESULTS == スキル名
				ジャンル = LOCAL
				スキルID = LOCAL:1
				GOTO FOUND
			ENDIF
		CATCH
			CONTINUE
		ENDCATCH
	NEXT
NEXT

RETURN 0

$FOUND

FOR LOCAL, 0, MAX_SKILL_SLOT
	IF SKILL_NO_SLOT:発動者:ジャンル:LOCAL == 0 && SKILL_ID_SLOT:発動者:ジャンル:LOCAL == スキルID
		RETURN 1
	ENDIF
NEXT

RETURN 0

;---------------------------------
;SP, BASE, CAPTURE, ESCAPEスキル発動用
;---------------------------------
@SKILL_COMBAT_INVOKE(発動者, 発動番号, ジャンル, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象勢力
#DIM 対象部隊

SIF BATTLE_SKILL_SEALED:発動側:発動番号 || BATTLE_SUMMONED_CHARA:発動側:発動番号
	RETURN 0

FOR LOCAL, 0, MAX_SKILL_SLOT
	SIF SKILL_NO_SLOT:発動者:ジャンル:LOCAL < 0
		CONTINUE
	SIF SKILL_ID_SLOT:発動者:ジャンル:LOCAL < 0
		CONTINUE
	CALL SKILL_COMBAT_TRY_INVOKE(発動者, 発動番号, ジャンル, SKILL_NO_SLOT:発動者:ジャンル:LOCAL, SKILL_ID_SLOT:発動者:ジャンル:LOCAL, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
NEXT

;---------------------------------
;SP, BASE, CAPTURE, ESCAPEスキル発動用 CAPTUREでは発動側が捕縛側、ESCAPEでは発動側が逃走側
;---------------------------------
@SKILL_COMBAT_TRY_INVOKE(発動者, 発動番号, ジャンル, スキルNO, スキルID, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM ジャンル
#DIM スキルNO
#DIM スキルID
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象勢力
#DIM 対象部隊

SIF BATTLE_SKILL_SEALED:発動側:発動番号
	RETURN -1

;存在判定
TRYCCALLFORM SKILL_{スキルNO}_%SKILL_GENRE_ENG:ジャンル%_{スキルID}_EXIST
CATCH
	RETURN -1
ENDCATCH
;対象選択
TRYCCALLFORM SKILL_{スキルNO}_%SKILL_GENRE_ENG:ジャンル%_{スキルID}_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
	IF !RESULT
		RESETCOLOR
		RETURN 0
	ENDIF
CATCH
ENDCATCH
;発動率判定
CALLFORM SKILL_{スキルNO}_%SKILL_GENRE_ENG:ジャンル%_{スキルID}_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)

;技術研究の成果
SIF TECHNOLOGY_STATUS:(CFLAG:発動者:所属):TECHNOLOGY_BATTLE_SKILL >= 1
	RESULT += 50
SIF TECHNOLOGY_STATUS:(CFLAG:発動者:所属):TECHNOLOGY_BATTLE_SKILL >= 7
	RESULT += 100

IF RAND:1000 >= RESULT * BATTLE_SKILL_RATE:発動側:発動番号 / 100
	RESETCOLOR
	RETURN 0
ENDIF
;発動判定
CALLFORM SKILL_{スキルNO}_%SKILL_GENRE_ENG:ジャンル%_{スキルID}_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
IF !RESULT
	RESETCOLOR
	RETURN 0
ENDIF
;TRYCCALLFORM SKILL_{発動者}_%ジャンル%_{スキル}_INVOKE_TEXT(発動者)
;	CATCH
CALLFORM SKILL_PRINT_INVOKE(発動者, ジャンル, スキルNO, スキルID)
;ENDCATCH
CALLFORM SKILL_{スキルNO}_%SKILL_GENRE_ENG:ジャンル%_{スキルID}_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
RETURN RESULT

;---------------------------------
;国家方針・研究スキル
;---------------------------------
@TECHNOLOGY_PERSONAL_SKILL_COMBAT_INVOKE(発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象勢力
#DIM 対象部隊
#DIM 都市

SIF BATTLE_COMMANDER_NUM:発動側 == 0
	RETURN 0

SIF BATTLE_SKILL_SEALED:発動側:発動番号 || BATTLE_SUMMONED_CHARA:発動側:発動番号
	RETURN 0

発動者 = BATTLE_COMMANDER:(発動側):0
発動番号 = 0
;国人衆参戦
SIF TECHNOLOGY_STATUS:(CFLAG:発動者:所属):TECHNOLOGY_BATTLE_SKILL >= 2
	CALL SKILL_COMBAT_TRY_INVOKE(発動者, 発動番号, スキル_ジャンル_PERSONAL, 0, 40, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)


@TECHNOLOGY_TROOP_SKILL_COMBAT_INVOKE(発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象勢力
#DIM 対象部隊
#DIM 都市

SIF BATTLE_COMMANDER_NUM:発動側 == 0
	RETURN 0

SIF BATTLE_SKILL_SEALED:発動側:発動番号 || BATTLE_SUMMONED_CHARA:発動側:発動番号
	RETURN 0
```
