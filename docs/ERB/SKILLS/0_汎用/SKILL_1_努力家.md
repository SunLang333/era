# SKILLS/0_汎用/SKILL_1_努力家.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/SKILL_1_努力家.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_PASSIVE_1_EXIST, SKILL_0_PASSIVE_1_NAME, SKILL_0_PASSIVE_1_LEVEL, SKILL_0_PASSIVE_1_EXPLANATION; assigns RESULTS

前 200 行源码片段:

```text
﻿;-----------------------------------
;パッシブの効果はハードコーディングする
;モジュール化できていないので、基本作らないこと
;-----------------------------------
@SKILL_0_PASSIVE_1_EXIST
RETURN 1

@SKILL_0_PASSIVE_1_NAME
RESULTS = 努力家

;レベルは1-5まで
@SKILL_0_PASSIVE_1_LEVEL
RETURN 5

@SKILL_0_PASSIVE_1_EXPLANATION
RESULTS = ターンエンド時経験値を獲得。戦闘勝利時の経験値獲得量が増加する。
```
