# SKILLS/0_汎用/SKILL_3_明察.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/SKILL_3_明察.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_PASSIVE_3_EXIST, SKILL_0_PASSIVE_3_NAME, SKILL_0_PASSIVE_3_LEVEL, SKILL_0_PASSIVE_3_EXPLANATION; assigns RESULTS

前 200 行源码片段:

```text
﻿;-----------------------------------
;パッシブの効果はハードコーディングする
;モジュール化できていないので、基本作らないこと
;-----------------------------------
@SKILL_0_PASSIVE_3_EXIST
RETURN 1

@SKILL_0_PASSIVE_3_NAME
RESULTS = 明察

;レベルは1-5まで
@SKILL_0_PASSIVE_3_LEVEL
RETURN 4

@SKILL_0_PASSIVE_3_EXPLANATION
RESULTS = 計略を受けそうになったとき、無効化する。
```
