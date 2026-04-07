# 口上/31 妹紅口上/DAILY/CREATE_KOJO_DAILY_MAP_K31.ERB — 自动生成文档

源文件: `ERB/口上/31 妹紅口上/DAILY/CREATE_KOJO_DAILY_MAP_K31.ERB`

类型: .ERB

自动摘要: functions: CREATE_KOJO_DAILY_MAP_K31

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :口上デイリーを登録する。REGISGER_KOJO_DAILYを呼び出す
;param :対象:対象のキャラ番号
;-------------------------------------------------
@CREATE_KOJO_DAILY_MAP_K31(対象)
#DIM 対象
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "DIE_KAGUYA", "刺客")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "ONAHOLE", "蓬莱の穴の形")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "PLEASE_GET_BACK_MY_HOME", "おうちかえして")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "VIGILANTE_GANGBANG", "蓬莱の牝犬")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常, "FUCKMEAT", "永遠の便女と蓬莱の便女")
CALL REGISTER_KOJO_DAILY(対象, デイリー_通常派生, "PLEASE_GET_BACK_MY_HOME", "かえってきたおうち")

```
