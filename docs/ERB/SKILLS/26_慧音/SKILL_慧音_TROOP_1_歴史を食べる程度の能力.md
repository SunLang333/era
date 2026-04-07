# SKILLS/26_慧音/SKILL_慧音_TROOP_1_歴史を食べる程度の能力.ERB — 自动生成文档

源文件: `ERB/SKILLS/26_慧音/SKILL_慧音_TROOP_1_歴史を食べる程度の能力.ERB`

类型: .ERB

自动摘要: functions: SKILL_26_TROOP_1_EXIST, SKILL_26_TROOP_1_NAME, SKILL_26_TROOP_1_LEVEL, SKILL_26_TROOP_1_SETTARGET, SKILL_26_TROOP_1_CAN_INVOKE, SKILL_26_TROOP_1_INVOKE, SKILL_26_TROOP_1_EXPLANATION, SKILL_26_TROOP_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_26_TROOP_1_EXIST
RETURN 1

@SKILL_26_TROOP_1_NAME
RESULTS = 歴史を食べる程度の能力

;レベルは1-5まで
@SKILL_26_TROOP_1_LEVEL
RETURN 2

;対象選択
@SKILL_26_TROOP_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_26_TROOP_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_26_TROOP_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
BATTLE_RATE_GRD:発動側 += 5
PRINTFORML 自部隊の被害を軽減する！

@SKILL_26_TROOP_1_EXPLANATION
RESULTS = 自部隊の被害を軽減する。




@SKILL_26_TROOP_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
