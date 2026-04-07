# SKILLS/70_妖忌/SKILL_妖忌_PERSONAL_2_悟入幻想.ERB — 自动生成文档

源文件: `ERB/SKILLS/70_妖忌/SKILL_妖忌_PERSONAL_2_悟入幻想.ERB`

类型: .ERB

自动摘要: functions: SKILL_70_PERSONAL_2_EXIST, SKILL_70_PERSONAL_2_NAME, SKILL_70_PERSONAL_2_LEVEL, SKILL_70_PERSONAL_2_SETTARGET, SKILL_70_PERSONAL_2_CAN_INVOKE, SKILL_70_PERSONAL_2_INVOKE, SKILL_70_PERSONAL_2_EXPLANATION, SKILL_70_PERSONAL_2_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_70_PERSONAL_2_EXIST
RETURN 1

@SKILL_70_PERSONAL_2_NAME
RESULTS = 悟入幻想

;レベルは1-5まで
@SKILL_70_PERSONAL_2_LEVEL
RETURN 3

;対象選択
@SKILL_70_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_70_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_70_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(発動者)%の知略が増加した！
TIMES BATTLE_知略パワー:発動側:COMBAT_SKILL_TARGET, 1.1
RETURN 1

;
@SKILL_70_PERSONAL_2_EXPLANATION
RESULTS = 自身の知略を増加させる。




@SKILL_70_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 500
```
