# 口上/83 青娥口上/DAILY/CREATE_KOJO_DAILY_MAP_K83.ERB — 自动生成文档

源文件: `ERB/口上/83 青娥口上/DAILY/CREATE_KOJO_DAILY_MAP_K83.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K83

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K83(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "NECRO", "死霊術")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "I_GIVE_YOU_EVERYTHING_I_HAVE", "全てをあなたに")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "RECOVERY", "邪仙流の回復術")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "PRISON_BREAK", "壁抜けの仙人")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "NIGHT_OF_THE_HERMIT", "邪仙と過ごす夜")
```
