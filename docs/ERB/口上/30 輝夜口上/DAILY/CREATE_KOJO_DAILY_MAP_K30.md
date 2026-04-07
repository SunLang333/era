# 口上/30 輝夜口上/DAILY/CREATE_KOJO_DAILY_MAP_K30.ERB — 自动生成文档

源文件: `ERB/口上/30 輝夜口上/DAILY/CREATE_KOJO_DAILY_MAP_K30.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K30

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K30(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "DESCENDANT", "貴族の末裔と勝負")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "DESCENDANT_SLAVE", "輝夜_貴族の末裔の奴隷嫁")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "INVITATION_FROM_KAGUYA", "貴族の誘い")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "KAWAYA_HIME", "かわや姫")
```
