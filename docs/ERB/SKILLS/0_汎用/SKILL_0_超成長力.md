# SKILLS/0_汎用/SKILL_0_超成長力.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/SKILL_0_超成長力.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_PASSIVE_0_EXIST, SKILL_0_PASSIVE_0_NAME, SKILL_0_PASSIVE_0_LEVEL, SKILL_0_PASSIVE_0_EXPLANATION; assigns RESULTS

前 200 行源码片段:

```text
﻿;-----------------------------------
;パッシブの効果はハードコーディングする
;モジュール化できていないので、基本作らないこと
;-----------------------------------
@SKILL_0_PASSIVE_0_EXIST
RETURN 1

@SKILL_0_PASSIVE_0_NAME
RESULTS = 超成長力

;レベルは1-5まで
@SKILL_0_PASSIVE_0_LEVEL
RETURN 5

@SKILL_0_PASSIVE_0_EXPLANATION
RESULTS = ターンエンド時経験値を獲得。能力の成長が早くなる。
```
