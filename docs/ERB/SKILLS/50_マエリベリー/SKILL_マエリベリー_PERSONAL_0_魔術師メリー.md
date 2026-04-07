# SKILLS/50_マエリベリー/SKILL_マエリベリー_PERSONAL_0_魔術師メリー.ERB — 自动生成文档

源文件: `ERB/SKILLS/50_マエリベリー/SKILL_マエリベリー_PERSONAL_0_魔術師メリー.ERB`

类型: .ERB

自动摘要: functions: SKILL_50_PERSONAL_0_EXIST, SKILL_50_PERSONAL_0_NAME, SKILL_50_PERSONAL_0_LEVEL, SKILL_50_PERSONAL_0_SETTARGET, SKILL_50_PERSONAL_0_CAN_INVOKE, SKILL_50_PERSONAL_0_INVOKE, SKILL_50_PERSONAL_0_EXPLANATION, SKILL_50_PERSONAL_0_CANT_TELL, SKILL_50_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_50_PERSONAL_0_EXIST
RETURN 1

@SKILL_50_PERSONAL_0_NAME
RESULTS = 魔術師メリー

;レベルは1-5まで
@SKILL_50_PERSONAL_0_LEVEL
RETURN 5

;対象選択
@SKILL_50_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
COMBAT_SKILL_TARGET = 発動番号
RETURN 1

;発動判定
@SKILL_50_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN BATTLE_妖術:発動側:発動番号 == 0 

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_50_PERSONAL_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_50_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 触れてはならない領域を垣間見た%ANAME(発動者)%は一時的に妖術を得る！
BATTLE_妖術:発動側:COMBAT_SKILL_TARGET = 20
BATTLE_妖術パワー:発動側:COMBAT_SKILL_TARGET = ABL_POWER(BATTLE_妖術:発動側:COMBAT_SKILL_TARGET, 発動者)

@SKILL_50_PERSONAL_0_EXPLANATION
RESULTS = 自身の妖術が0のとき発動。一時的に妖術を得る。


@SKILL_50_PERSONAL_0_CANT_TELL

@SKILL_50_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
