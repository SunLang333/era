# SKILLS/0_汎用/SKILL_2_治療.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/SKILL_2_治療.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_PASSIVE_2_EXIST, SKILL_0_PASSIVE_2_NAME, SKILL_0_PASSIVE_2_LEVEL, SKILL_0_PASSIVE_2_EXPLANATION; assigns RESULTS

前 200 行源码片段:

```text
﻿;-----------------------------------
;パッシブの効果はハードコーディングする
;モジュール化できていないので、基本作らないこと
;-----------------------------------
@SKILL_0_PASSIVE_2_EXIST
RETURN 1

@SKILL_0_PASSIVE_2_NAME
RESULTS = 治療

;レベルは1-5まで
@SKILL_0_PASSIVE_2_LEVEL
RETURN 3

@SKILL_0_PASSIVE_2_EXPLANATION
RESULTS = 部隊敗北時、自身か仲間の受けるクールタイムを軽減する。
```
