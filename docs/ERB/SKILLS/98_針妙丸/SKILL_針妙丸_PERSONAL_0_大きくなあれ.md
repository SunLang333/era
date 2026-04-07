# SKILLS/98_針妙丸/SKILL_針妙丸_PERSONAL_0_大きくなあれ.ERB — 自动生成文档

源文件: `ERB/SKILLS/98_針妙丸/SKILL_針妙丸_PERSONAL_0_大きくなあれ.ERB`

类型: .ERB

自动摘要: functions: SKILL_98_PERSONAL_0_EXIST, SKILL_98_PERSONAL_0_NAME, SKILL_98_PERSONAL_0_LEVEL, SKILL_98_PERSONAL_0_SETTARGET, SKILL_98_PERSONAL_0_CAN_INVOKE, SKILL_98_PERSONAL_0_INVOKE, SKILL_98_PERSONAL_0_EXPLANATION, SKILL_98_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_98_PERSONAL_0_EXIST
RETURN 1

@SKILL_98_PERSONAL_0_NAME
RESULTS = 大きくなあれ

;レベルは1-5まで
@SKILL_98_PERSONAL_0_LEVEL
RETURN 2

;対象選択
@SKILL_98_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
#DIM 能力, 3
VARSET 能力
対象側 = !発動側
SIF BATTLE_COMMANDER_NUM:発動側 == 0
	RETURN 0

FOR LOCAL, 0, BATTLE_COMMANDER_NUM:発動側
	能力:LOCAL = BATTLE_武闘:発動側:LOCAL + BATTLE_知略:発動側:LOCAL
NEXT

COMBAT_SKILL_TARGET = FINDELEMENT(能力, MAXARRAY(能力))
RETURN 1

;発動判定
@SKILL_98_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_98_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 大きくなった%ANAME(BATTLE_COMMANDER:発動側:COMBAT_SKILL_TARGET)%の武闘が増加！
TIMES BATTLE_武闘パワー:発動側:COMBAT_SKILL_TARGET, 1.2
RETURN 1

;
@SKILL_98_PERSONAL_0_EXPLANATION
RESULTS = 味方一人の武闘を増加させる。




@SKILL_98_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
