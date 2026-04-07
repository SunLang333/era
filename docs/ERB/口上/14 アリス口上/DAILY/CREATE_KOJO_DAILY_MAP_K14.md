# 口上/14 アリス口上/DAILY/CREATE_KOJO_DAILY_MAP_K14.ERB — 自动生成文档

源文件: `ERB/口上/14 アリス口上/DAILY/CREATE_KOJO_DAILY_MAP_K14.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K14

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K14(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "FRAY", "ほつれ")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "VOODOO", "お守り")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "LOVEDOLL", "ラブドール")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "PUPPET_SHOW", "人形劇の前に")
```
