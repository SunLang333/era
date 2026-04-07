# 口上/145 成美口上/DAILY/CREATE_KOJO_DAILY_MAP_K145.ERB — 自动生成文档

源文件: `ERB/口上/145 成美口上/DAILY/CREATE_KOJO_DAILY_MAP_K145.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K145

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K145(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "TWO_MAGUS", "魔法を使う程度の能力×２")
```
