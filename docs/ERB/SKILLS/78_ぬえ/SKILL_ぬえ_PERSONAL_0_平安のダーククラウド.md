# SKILLS/78_ぬえ/SKILL_ぬえ_PERSONAL_0_平安のダーククラウド.ERB — 自动生成文档

源文件: `ERB/SKILLS/78_ぬえ/SKILL_ぬえ_PERSONAL_0_平安のダーククラウド.ERB`

类型: .ERB

自动摘要: functions: SKILL_78_PERSONAL_0_EXIST, SKILL_78_PERSONAL_0_NAME, SKILL_78_PERSONAL_0_LEVEL, SKILL_78_PERSONAL_0_SETTARGET, SKILL_78_PERSONAL_0_CAN_INVOKE, SKILL_78_PERSONAL_0_INVOKE, SKILL_78_PERSONAL_0_EXPLANATION, SKILL_78_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_78_PERSONAL_0_EXIST
RETURN 1

@SKILL_78_PERSONAL_0_NAME
RESULTS = 平安のダーククラウド

;レベルは1-5まで
@SKILL_78_PERSONAL_0_LEVEL
RETURN 2

;対象選択
@SKILL_78_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_78_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_78_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
TIMES BATTLE_防衛パワー:発動側:COMBAT_SKILL_TARGET, 1.1
RETURN 1

;
@SKILL_78_PERSONAL_0_EXPLANATION
RESULTS = 自身の防衛を増加させる。




@SKILL_78_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 125
```
