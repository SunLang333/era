# SKILLS/42_早苗/SKILL_早苗_PERSONAL_1_坤神招来.ERB — 自动生成文档

源文件: `ERB/SKILLS/42_早苗/SKILL_早苗_PERSONAL_1_坤神招来.ERB`

类型: .ERB

自动摘要: functions: SKILL_42_PERSONAL_1_EXIST, SKILL_42_PERSONAL_1_NAME, SKILL_42_PERSONAL_1_LEVEL, SKILL_42_PERSONAL_1_SETTARGET, SKILL_42_PERSONAL_1_CAN_INVOKE, SKILL_42_PERSONAL_1_INVOKE, SKILL_42_PERSONAL_1_EXPLANATION, SKILL_42_PERSONAL_1_CANT_TELL, SKILL_42_PERSONAL_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_42_PERSONAL_1_EXIST
RETURN 1

@SKILL_42_PERSONAL_1_NAME
RESULTS = 坤神招来

;レベルは1-5まで
@SKILL_42_PERSONAL_1_LEVEL
RETURN 3

;対象選択
@SKILL_42_PERSONAL_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
COMBAT_SKILL_TARGET = 発動番号
RETURN 1

;発動判定
@SKILL_42_PERSONAL_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN (発動部隊 < 0 ? BATTLE_COMMANDER_NUM:発動側 <= 1 # BATTLE_COMMANDER_NUM:発動側 <= 2) 

;効果をここに記述
@SKILL_42_PERSONAL_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 諏訪子がこの戦闘に参加する！
LOCAL:1 = NAME_TO_CHARA("諏訪子")
CALL BATTLE_SUMMON(発動側, LOCAL:1, 発動部隊 >= 0)

@SKILL_42_PERSONAL_1_EXPLANATION
RESULTS = 自部隊に空きがあるとき発動。所属にかかわらず諏訪子を参戦させる。

@SKILL_42_PERSONAL_1_CANT_TELL

@SKILL_42_PERSONAL_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 300
```
