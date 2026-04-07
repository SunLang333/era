# SKILLS/81_響子/SKILL_響子_TROOP_0_パワーレゾナンス.ERB — 自动生成文档

源文件: `ERB/SKILLS/81_響子/SKILL_響子_TROOP_0_パワーレゾナンス.ERB`

类型: .ERB

自动摘要: functions: SKILL_81_TROOP_0_EXIST, SKILL_81_TROOP_0_NAME, SKILL_81_TROOP_0_LEVEL, SKILL_81_TROOP_0_SETTARGET, SKILL_81_TROOP_0_CAN_INVOKE, SKILL_81_TROOP_0_INVOKE, SKILL_81_TROOP_0_EXPLANATION, SKILL_81_TROOP_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_81_TROOP_0_EXIST
RETURN 1

@SKILL_81_TROOP_0_NAME
RESULTS = パワーレゾナンス

;レベルは1-5まで
@SKILL_81_TROOP_0_LEVEL
RETURN 3

;対象選択
@SKILL_81_TROOP_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_81_TROOP_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_81_TROOP_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
BATTLE_RATE_ATC:発動側 += 7
PRINTFORML 自部隊の与える被害が増加する！

@SKILL_81_TROOP_0_EXPLANATION
RESULTS = 自部隊の与える被害を増加させる。




@SKILL_81_TROOP_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
