# 口上/32 文口上/DAILY/CREATE_KOJO_DAILY_MAP_K32.ERB — 自动生成文档

源文件: `ERB/口上/32 文口上/DAILY/CREATE_KOJO_DAILY_MAP_K32.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K32

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K32(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "INVITATION_FROM_AYA", "新聞勧誘")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "MIZUASOBI", "水遊び")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "FUCKMEAT", "ダブルズボズボ淫乱")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "FUCKMEAT_2", "ダブルヌポヌポ淫乱")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常派生, "MIZUASOBI", "お見舞い")

```
