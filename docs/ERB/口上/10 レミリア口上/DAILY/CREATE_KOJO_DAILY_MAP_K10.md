# 口上/10 レミリア口上/DAILY/CREATE_KOJO_DAILY_MAP_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/DAILY/CREATE_KOJO_DAILY_MAP_K10.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K10

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K10(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "ASK_DIRTY_NAME", "ご褒美をあげる")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "ASK_MASTER_NAME", "愛称を教えて")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "BAD_WEATHER", "あいにくの天気")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "HOBGOBLIN_GANGBANG", "にくべん鬼ごっこ")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "HOBGOBLIN_SLAVE", "スレイヴ・オブ・ミッドナイト")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "INVITATION_FROM_REMILLIA", "レミリアからの勧誘")
```
