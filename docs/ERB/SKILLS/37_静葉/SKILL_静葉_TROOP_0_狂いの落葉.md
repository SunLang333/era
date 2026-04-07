# SKILLS/37_静葉/SKILL_静葉_TROOP_0_狂いの落葉.ERB — 自动生成文档

源文件: `ERB/SKILLS/37_静葉/SKILL_静葉_TROOP_0_狂いの落葉.ERB`

类型: .ERB

自动摘要: functions: SKILL_37_TROOP_0_EXIST, SKILL_37_TROOP_0_NAME, SKILL_37_TROOP_0_LEVEL, SKILL_37_TROOP_0_SETTARGET, SKILL_37_TROOP_0_CAN_INVOKE, SKILL_37_TROOP_0_INVOKE, SKILL_37_TROOP_0_EXPLANATION, SKILL_37_TROOP_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_37_TROOP_0_EXIST
RETURN 1

@SKILL_37_TROOP_0_NAME
RESULTS = 狂いの落葉

;レベルは1-5まで
@SKILL_37_TROOP_0_LEVEL
RETURN 2

;対象選択
@SKILL_37_TROOP_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_37_TROOP_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_37_TROOP_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 敵部隊の攻撃力が増加！　防御力が低下！

TIMES BATTLE_ATK:発動側, 1.05
TIMES BATTLE_DEF:発動側, 0.95

@SKILL_37_TROOP_0_EXPLANATION
RESULTS = 敵部隊の攻撃力を増加、防御力を低下させる。


@SKILL_37_TROOP_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 150
```
