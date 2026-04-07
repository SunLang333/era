# SKILLS/148_隠岐奈/SKILL_隠岐奈_PERSONAL_0_背面の暗黒猿楽.ERB — 自动生成文档

源文件: `ERB/SKILLS/148_隠岐奈/SKILL_隠岐奈_PERSONAL_0_背面の暗黒猿楽.ERB`

类型: .ERB

自动摘要: functions: SKILL_148_PERSONAL_0_EXIST, SKILL_148_PERSONAL_0_NAME, SKILL_148_PERSONAL_0_LEVEL, SKILL_148_PERSONAL_0_SETTARGET, SKILL_148_PERSONAL_0_CAN_INVOKE, SKILL_148_PERSONAL_0_INVOKE, SKILL_148_PERSONAL_0_EXPLANATION, SKILL_148_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_148_PERSONAL_0_EXIST
RETURN 1

@SKILL_148_PERSONAL_0_NAME
RESULTS = 背面の暗黒猿楽

;レベルは1-5まで
@SKILL_148_PERSONAL_0_LEVEL
RETURN 4

;対象選択
@SKILL_148_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
対象側 = !発動側
SIF BATTLE_COMMANDER_NUM:対象側 == 0
	RETURN 0
COMBAT_SKILL_TARGET = RAND:(BATTLE_COMMANDER_NUM:対象側)
RETURN 1

;発動判定
@SKILL_148_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
対象側 = !発動側
RETURN 1

;効果をここに記述
@SKILL_148_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
対象側 = !発動側
PRINTFORML %ANAME(BATTLE_COMMANDER:対象側:COMBAT_SKILL_TARGET)%は背面から不意を討たれた！
PRINTFORML この戦闘に参加できない！
CALL BATTLE_KNOCKOUT(対象側, COMBAT_SKILL_TARGET)

RETURN 1

@SKILL_148_PERSONAL_0_EXPLANATION
RESULTS = 敵一人を戦闘不能にする。




@SKILL_148_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
RETURN 150
```
