# SKILLS/82_芳香/SKILL_芳香_PERSONAL_1_死なない殺人鬼.ERB — 自动生成文档

源文件: `ERB/SKILLS/82_芳香/SKILL_芳香_PERSONAL_1_死なない殺人鬼.ERB`

类型: .ERB

自动摘要: functions: SKILL_82_PERSONAL_1_EXIST, SKILL_82_PERSONAL_1_NAME, SKILL_82_PERSONAL_1_LEVEL, SKILL_82_PERSONAL_1_SETTARGET, SKILL_82_PERSONAL_1_CAN_INVOKE, SKILL_82_PERSONAL_1_INVOKE, SKILL_82_PERSONAL_1_EXPLANATION, SKILL_82_PERSONAL_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_82_PERSONAL_1_EXIST
RETURN 1

@SKILL_82_PERSONAL_1_NAME
RESULTS = 死なない殺人鬼

;レベルは1-5まで
@SKILL_82_PERSONAL_1_LEVEL
RETURN 5

;対象選択
@SKILL_82_PERSONAL_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;部隊対象
RETURN 1

;発動判定
@SKILL_82_PERSONAL_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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

RETURN BATTLE_防衛:発動側:発動番号 < ABL:発動者:防衛 || BATTLE_防衛パワー:発動側:発動番号 < ABL_POWER(ABL:発動者:防衛, 発動者)



;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_82_PERSONAL_1_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_82_PERSONAL_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(BATTLE_COMMANDER:対象側:COMBAT_SKILL_TARGET)%は毒爪を受けた！
PRINTFORML この戦闘に参加できない！
CALL BATTLE_KNOCKOUT(対象側, COMBAT_SKILL_TARGET)


@SKILL_82_PERSONAL_1_EXPLANATION
RESULTS = 現在の自身の防衛が本来の防衛を下回る場合に発動。敵一人を戦闘不能にする。

@SKILL_82_PERSONAL_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 500
```
