# 口上/77 白蓮口上/DAILY/CREATE_KOJO_DAILY_MAP_K77.ERB — 自动生成文档

源文件: `ERB/口上/77 白蓮口上/DAILY/CREATE_KOJO_DAILY_MAP_K77.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K77

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K77(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "INVITATION_FROM_BYAKUREN", "白蓮からの勧誘")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "CULTIST_GANGBANG", "ファックを滅さぬ尼公")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "LEWD_PRIEST", "ガンガンイく僧侶")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "DEPRAVED_MONK", "破戒僧")
```
