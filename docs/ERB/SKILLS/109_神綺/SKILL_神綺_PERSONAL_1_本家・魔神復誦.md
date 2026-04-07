# SKILLS/109_神綺/SKILL_神綺_PERSONAL_1_本家・魔神復誦.ERB — 自动生成文档

源文件: `ERB/SKILLS/109_神綺/SKILL_神綺_PERSONAL_1_本家・魔神復誦.ERB`

类型: .ERB

自动摘要: functions: SKILL_109_PERSONAL_1_EXIST, SKILL_109_PERSONAL_1_NAME, SKILL_109_PERSONAL_1_LEVEL, SKILL_109_PERSONAL_1_SETTARGET, SKILL_109_PERSONAL_1_CAN_INVOKE, SKILL_109_PERSONAL_1_INVOKE, SKILL_109_PERSONAL_1_EXPLANATION, SKILL_109_PERSONAL_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_109_PERSONAL_1_EXIST
RETURN 1

@SKILL_109_PERSONAL_1_NAME
RESULTS = 本家・魔神復誦

;レベルは1-5まで
@SKILL_109_PERSONAL_1_LEVEL
RETURN 4

;対象選択
@SKILL_109_PERSONAL_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
#DIM 能力, 3
VARSET 能力

COMBAT_SKILL_TARGET = 発動番号
RETURN 1

;発動判定
@SKILL_109_PERSONAL_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_109_PERSONAL_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(発動者)%の防衛が増加した！
TIMES BATTLE_防衛パワー:発動側:COMBAT_SKILL_TARGET, 1.25
RETURN 1

;
@SKILL_109_PERSONAL_1_EXPLANATION
RESULTS = 自身の防衛を増加させる。




@SKILL_109_PERSONAL_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 400
```
