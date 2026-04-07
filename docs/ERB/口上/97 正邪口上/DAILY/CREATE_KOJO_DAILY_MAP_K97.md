# 口上/97 正邪口上/DAILY/CREATE_KOJO_DAILY_MAP_K97.ERB — 自动生成文档

源文件: `ERB/口上/97 正邪口上/DAILY/CREATE_KOJO_DAILY_MAP_K97.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K97

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K97(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "MERCY_PLEASE", "正直な懇願")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常派生, "BETRAYAL", "正直者が馬鹿を見る")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "COUNTER_ROCKET", "反逆の狼煙")
```
