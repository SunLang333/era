# SKILLS/90_小鈴/SKILL_小鈴_PERSONAL_0_あらゆる文字が読める程度の能力.ERB — 自动生成文档

源文件: `ERB/SKILLS/90_小鈴/SKILL_小鈴_PERSONAL_0_あらゆる文字が読める程度の能力.ERB`

类型: .ERB

自动摘要: functions: SKILL_90_PERSONAL_0_EXIST, SKILL_90_PERSONAL_0_NAME, SKILL_90_PERSONAL_0_LEVEL, SKILL_90_PERSONAL_0_SETTARGET, SKILL_90_PERSONAL_0_CAN_INVOKE, SKILL_90_PERSONAL_0_INVOKE, SKILL_90_PERSONAL_0_EXPLANATION, SKILL_90_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_90_PERSONAL_0_EXIST
RETURN 1

@SKILL_90_PERSONAL_0_NAME
RESULTS = あらゆる文字が読める程度の能力

;レベルは1-5まで
@SKILL_90_PERSONAL_0_LEVEL
RETURN 3

;対象選択
@SKILL_90_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_90_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_90_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
TIMES BATTLE_知略パワー:発動側:COMBAT_SKILL_TARGET, 1.20
RETURN 1

;
@SKILL_90_PERSONAL_0_EXPLANATION
RESULTS = 自身の知略を増加させる。




@SKILL_90_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 100
```
