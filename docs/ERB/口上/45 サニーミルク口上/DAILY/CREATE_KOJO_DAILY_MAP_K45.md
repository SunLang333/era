# 口上/45 サニーミルク口上/DAILY/CREATE_KOJO_DAILY_MAP_K45.ERB — 自动生成文档

源文件: `ERB/口上/45 サニーミルク口上/DAILY/CREATE_KOJO_DAILY_MAP_K45.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K45

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K45(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "TRICK", "いたずらに命をかけて")
```
