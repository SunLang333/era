# SKILLS/102_夢美/SKILL_夢美_TROOP_0_夢幻伝説.ERB — 自动生成文档

源文件: `ERB/SKILLS/102_夢美/SKILL_夢美_TROOP_0_夢幻伝説.ERB`

类型: .ERB

自动摘要: functions: SKILL_102_TROOP_0_EXIST, SKILL_102_TROOP_0_NAME, SKILL_102_TROOP_0_LEVEL, SKILL_102_TROOP_0_SETTARGET, SKILL_102_TROOP_0_CAN_INVOKE, SKILL_102_TROOP_0_INVOKE, SKILL_102_TROOP_0_EXPLANATION, SKILL_102_TROOP_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_102_TROOP_0_EXIST
RETURN 1

@SKILL_102_TROOP_0_NAME
RESULTS = 夢幻伝説

;レベルは1-5まで
@SKILL_102_TROOP_0_LEVEL
RETURN 4

;対象選択
@SKILL_102_TROOP_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_102_TROOP_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_102_TROOP_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 自部隊の攻撃力と防御力が増加！

TIMES BATTLE_ATK:発動側, 1.03
TIMES BATTLE_DEF:発動側, 1.03

@SKILL_102_TROOP_0_EXPLANATION
RESULTS = 自部隊の攻撃力と防御力を増加させる。

@SKILL_102_TROOP_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 200
```
