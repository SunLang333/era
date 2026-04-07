# 口上/36 四季映姫口上/DAILY/CREATE_KOJO_DAILY_MAP_K36.ERB — 自动生成文档

源文件: `ERB/口上/36 四季映姫口上/DAILY/CREATE_KOJO_DAILY_MAP_K36.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K36

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K36(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "YOUR_IDEAL", "理想の形")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "DRUG_ADDICTION", "ハメねば生き損")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "LEWD_ENMA", "楽園の淫乱閻魔")
```
