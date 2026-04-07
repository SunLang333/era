# 口上/91 こころ口上/DAILY/CREATE_KOJO_DAILY_MAP_K91.ERB — 自动生成文档

源文件: `ERB/口上/91 こころ口上/DAILY/CREATE_KOJO_DAILY_MAP_K91.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K91

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K91(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "EMOTION_I_DONT_KNOW", "まだ知らぬ感情")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "STREET_FIGHTER", "私より強い奴に会いに行く")
```
