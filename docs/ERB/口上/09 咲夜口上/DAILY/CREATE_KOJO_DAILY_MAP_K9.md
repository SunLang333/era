# 口上/09 咲夜口上/DAILY/CREATE_KOJO_DAILY_MAP_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/DAILY/CREATE_KOJO_DAILY_MAP_K9.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K9

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K9(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "AFTER_REMILLIAS_INVITATION", "主の客は")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "ASK_DIRTY_NAME", "えっちな呼びかた")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "ASK_MASTER_NAME", "親しい呼びかた")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "DO_NOT_HURT_YOURSELF", "ケガをしないで")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "HOBGOBLIN_GANGBANG", "ご奉仕メイド")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "LOYALTY_FROM_SAKUYA", "主の主は")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "MEMORIES", "おもいで語り")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "TRAINING", "トレーニング")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "DOGGY_MAID", "牝犬メイド")
```
