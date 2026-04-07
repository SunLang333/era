# 口上/94 影狼口上/DAILY/CREATE_KOJO_DAILY_MAP_K94.ERB — 自动生成文档

源文件: `ERB/口上/94 影狼口上/DAILY/CREATE_KOJO_DAILY_MAP_K94.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K94

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K94(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAGEROU_FUROAGARI", "ホカホカ狼")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAGEROU_GROOMING", "毛繕い")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAGEROU_HANAUTA", "鼻歌交じり")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAGEROU_OHIRUNE", "お昼寝狼")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAGEROU_RAINYDAY", "雨宿り狼")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAGEROU_SANPO", "月夜の散歩")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAGEROU_YAKINIKU", "焼肉デート")
```
