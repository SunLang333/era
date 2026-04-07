# SKILLS/9_咲夜/SKILL_咲夜_PERSONAL_2_パーフェクトスクウェア.ERB — 自动生成文档

源文件: `ERB/SKILLS/9_咲夜/SKILL_咲夜_PERSONAL_2_パーフェクトスクウェア.ERB`

类型: .ERB

自动摘要: functions: SKILL_9_PERSONAL_2_EXIST, SKILL_9_PERSONAL_2_NAME, SKILL_9_PERSONAL_2_LEVEL, SKILL_9_PERSONAL_2_SETTARGET, SKILL_9_PERSONAL_2_CAN_INVOKE, SKILL_9_PERSONAL_2_INVOKE, SKILL_9_PERSONAL_2_EXPLANATION, SKILL_9_PERSONAL_2_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_9_PERSONAL_2_EXIST
RETURN 1

@SKILL_9_PERSONAL_2_NAME
RESULTS = パーフェクトスクウェア

;レベルは1-5まで
@SKILL_9_PERSONAL_2_LEVEL
RETURN 3

;対象選択
@SKILL_9_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_9_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_9_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(BATTLE_COMMANDER:対象側:COMBAT_SKILL_TARGET)%の武闘と防衛が低下した！
TIMES BATTLE_武闘:対象側:COMBAT_SKILL_TARGET, 0.85
TIMES BATTLE_防衛:対象側:COMBAT_SKILL_TARGET, 0.85

RETURN 1

;
@SKILL_9_PERSONAL_2_EXPLANATION
RESULTS = 敵一人の武闘・防衛を低下させる。




@SKILL_9_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
