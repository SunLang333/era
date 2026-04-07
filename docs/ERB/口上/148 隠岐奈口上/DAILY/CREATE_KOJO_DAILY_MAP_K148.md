# 口上/148 隠岐奈口上/DAILY/CREATE_KOJO_DAILY_MAP_K148.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/DAILY/CREATE_KOJO_DAILY_MAP_K148.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K148

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K148(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "LICK_IT", "秘唇マターラ")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "INTO_FUCKDOOR", "イントゥ・ファックドア")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "HELLO_AGAIN", "再会")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "BENTO", "愛妻弁当")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "NIGHTEVENT", "秘神の気まぐれ")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "NIGHTEVENTH", "秘神の気まぐれH")

```
