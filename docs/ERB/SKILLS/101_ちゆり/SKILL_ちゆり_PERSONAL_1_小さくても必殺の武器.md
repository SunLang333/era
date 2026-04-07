# SKILLS/101_ちゆり/SKILL_ちゆり_PERSONAL_1_小さくても必殺の武器.ERB — 自动生成文档

源文件: `ERB/SKILLS/101_ちゆり/SKILL_ちゆり_PERSONAL_1_小さくても必殺の武器.ERB`

类型: .ERB

自动摘要: functions: SKILL_101_PERSONAL_1_EXIST, SKILL_101_PERSONAL_1_NAME, SKILL_101_PERSONAL_1_LEVEL, SKILL_101_PERSONAL_1_SETTARGET, SKILL_101_PERSONAL_1_CAN_INVOKE, SKILL_101_PERSONAL_1_INVOKE, SKILL_101_PERSONAL_1_EXPLANATION, SKILL_101_PERSONAL_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_101_PERSONAL_1_EXIST
RETURN 1

@SKILL_101_PERSONAL_1_NAME
RESULTS = 小さくても必殺の武器

;レベルは1-5まで
@SKILL_101_PERSONAL_1_LEVEL
RETURN 4

;対象選択
@SKILL_101_PERSONAL_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
SIF BATTLE_COMMANDER_NUM:対象側 == 0
	RETURN 0
COMBAT_SKILL_TARGET = RAND:(BATTLE_COMMANDER_NUM:対象側)
RETURN 1

;発動判定
@SKILL_101_PERSONAL_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_101_PERSONAL_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(BATTLE_COMMANDER:対象側:COMBAT_SKILL_TARGET)%に命中！
PRINTFORML この戦闘に参加できない！
CALL BATTLE_KNOCKOUT(対象側, COMBAT_SKILL_TARGET)

RETURN 1

;
@SKILL_101_PERSONAL_1_EXPLANATION
RESULTS = 敵一人を戦闘不能にする。銃で撃たれれば痛い。




@SKILL_101_PERSONAL_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 80
```
