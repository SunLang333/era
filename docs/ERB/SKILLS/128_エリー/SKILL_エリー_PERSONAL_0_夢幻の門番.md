# SKILLS/128_エリー/SKILL_エリー_PERSONAL_0_夢幻の門番.ERB — 自动生成文档

源文件: `ERB/SKILLS/128_エリー/SKILL_エリー_PERSONAL_0_夢幻の門番.ERB`

类型: .ERB

自动摘要: functions: SKILL_128_PERSONAL_0_EXIST, SKILL_128_PERSONAL_0_NAME, SKILL_128_PERSONAL_0_LEVEL, SKILL_128_PERSONAL_0_SETTARGET, SKILL_128_PERSONAL_0_CAN_INVOKE, SKILL_128_PERSONAL_0_INVOKE, SKILL_128_PERSONAL_0_EXPLANATION, SKILL_128_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_128_PERSONAL_0_EXIST
RETURN 1

@SKILL_128_PERSONAL_0_NAME
RESULTS = 夢幻の門番

;レベルは1-5まで
@SKILL_128_PERSONAL_0_LEVEL
RETURN 4

;対象選択
@SKILL_128_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_128_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_128_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(発動者)%の防衛が増加した！
TIMES BATTLE_防衛パワー:発動側:COMBAT_SKILL_TARGET, 1.15
RETURN 1

;
@SKILL_128_PERSONAL_0_EXPLANATION
RESULTS = 自勢力での戦闘時に発動。自身の防衛が増加する。




@SKILL_128_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
