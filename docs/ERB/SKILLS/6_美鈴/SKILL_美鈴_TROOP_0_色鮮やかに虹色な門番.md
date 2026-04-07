# SKILLS/6_美鈴/SKILL_美鈴_TROOP_0_色鮮やかに虹色な門番.ERB — 自动生成文档

源文件: `ERB/SKILLS/6_美鈴/SKILL_美鈴_TROOP_0_色鮮やかに虹色な門番.ERB`

类型: .ERB

自动摘要: functions: SKILL_6_TROOP_0_EXIST, SKILL_6_TROOP_0_NAME, SKILL_6_TROOP_0_LEVEL, SKILL_6_TROOP_0_SETTARGET, SKILL_6_TROOP_0_CAN_INVOKE, SKILL_6_TROOP_0_INVOKE, SKILL_6_TROOP_0_EXPLANATION, SKILL_6_TROOP_0_CANT_TELL, SKILL_6_TROOP_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_6_TROOP_0_EXIST
RETURN 1

@SKILL_6_TROOP_0_NAME
RESULTS = 色鮮やかに虹色な門番

;レベルは1-5まで
@SKILL_6_TROOP_0_LEVEL
RETURN 5

;対象選択
@SKILL_6_TROOP_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
COMBAT_SKILL_TARGET = 発動番号
RETURN 1

;発動判定
@SKILL_6_TROOP_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
IF 発動部隊 < 0
	RETURN CITY_OWNER:発動勢力 == CFLAG:(発動者):所属
ELSE
	RETURN CITY_OWNER:(UNIT_POSITION:発動勢力:発動部隊) == CFLAG:(発動者):所属
ENDIF
RETURN 0

;効果をここに記述
@SKILL_6_TROOP_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML ここは守り抜く！　自部隊の防衛が増加した！
TIMES BATTLE_DEF:発動側, 1.1
RETURN 1

;
@SKILL_6_TROOP_0_EXPLANATION
RESULTS = 自勢力での戦闘時に発動。自部隊の防衛が増加する。

@SKILL_6_TROOP_0_CANT_TELL

@SKILL_6_TROOP_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 1000
```
