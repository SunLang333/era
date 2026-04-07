# SKILLS/137_純狐/SKILL_純狐_PERSONAL_2_人を殺める為の純粋な弾幕.ERB — 自动生成文档

源文件: `ERB/SKILLS/137_純狐/SKILL_純狐_PERSONAL_2_人を殺める為の純粋な弾幕.ERB`

类型: .ERB

自动摘要: functions: SKILL_137_PERSONAL_2_EXIST, SKILL_137_PERSONAL_2_NAME, SKILL_137_PERSONAL_2_LEVEL, SKILL_137_PERSONAL_2_SETTARGET, SKILL_137_PERSONAL_2_CAN_INVOKE, SKILL_137_PERSONAL_2_INVOKE, SKILL_137_PERSONAL_2_EXPLANATION, SKILL_137_PERSONAL_2_RATE, SKILL_137_PERSONAL_2_CANT_TELL, SKILL_137_PERSONAL_2_NO_LEARN_INIT; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_137_PERSONAL_2_EXIST
RETURN 1

@SKILL_137_PERSONAL_2_NAME
RESULTS = 人を殺めるための純粋な弾幕

;レベルは1-5まで
@SKILL_137_PERSONAL_2_LEVEL
RETURN 4

;対象選択
@SKILL_137_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_137_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_137_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(BATTLE_COMMANDER:対象側:COMBAT_SKILL_TARGET)%は弾幕に呑み込まれた！
PRINTFORML この戦闘に参加できない！
CALL BATTLE_KNOCKOUT(対象側, COMBAT_SKILL_TARGET)

RETURN 1

;
@SKILL_137_PERSONAL_2_EXPLANATION
RESULTS = 敵一人を戦闘不能にする。




@SKILL_137_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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


@SKILL_137_PERSONAL_2_CANT_TELL
@SKILL_137_PERSONAL_2_NO_LEARN_INIT
```
