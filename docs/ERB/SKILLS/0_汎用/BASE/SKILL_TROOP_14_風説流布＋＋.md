# SKILLS/0_汎用/BASE/SKILL_TROOP_14_風説流布＋＋.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/BASE/SKILL_TROOP_14_風説流布＋＋.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_TROOP_14_EXIST, SKILL_0_TROOP_14_NAME, SKILL_0_TROOP_14_LEVEL, SKILL_0_TROOP_14_SETTARGET, SKILL_0_TROOP_14_CAN_INVOKE, SKILL_0_TROOP_14_INVOKE, SKILL_0_TROOP_14_EXPLANATION, SKILL_0_TROOP_14_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_0_TROOP_14_EXIST
RETURN 1

@SKILL_0_TROOP_14_NAME
RESULTS = 風説流布＋＋

;レベルは1-5まで
@SKILL_0_TROOP_14_LEVEL
RETURN 4

;対象選択
@SKILL_0_TROOP_14_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
;自部隊対象
RETURN 1

;発動判定
@SKILL_0_TROOP_14_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
対象側 = !発動側
RETURN 1

;効果をここに記述
@SKILL_0_TROOP_14_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
対象側 = !発動側
PRINTFORML 敵部隊の攻撃力と防御力が低下！
TIMES BATTLE_ATK:対象側, 0.97
TIMES BATTLE_DEF:対象側, 0.97

@SKILL_0_TROOP_14_EXPLANATION
RESULTS = 敵部隊の攻撃力・防御力を低下させる。

@SKILL_0_TROOP_14_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
#DIM 発動者
#DIM 発動番号
#DIM スキル
#DIMS ジャンル
#DIM 発動側
#DIM 発動勢力
#DIM 発動部隊
#DIM 対象側
#DIM 対象勢力
#DIM 対象部隊
RETURN 125
```
