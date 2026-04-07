# 口上/86 神子口上/DAILY/CREATE_KOJO_DAILY_MAP_K86.ERB — 自动生成文档

源文件: `ERB/口上/86 神子口上/DAILY/CREATE_KOJO_DAILY_MAP_K86.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K86

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K86(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "GOODJOB", "気にいった")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "GOUZOKU_LOVES_FUCKING", "豪族の愉しみ")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "HIGH_GLEE", "上機嫌")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "NATURAL_BORN_ADMINISTRATOR", "天職の為政者")
```
