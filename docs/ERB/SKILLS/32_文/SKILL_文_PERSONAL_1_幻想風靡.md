# SKILLS/32_文/SKILL_文_PERSONAL_1_幻想風靡.ERB — 自动生成文档

源文件: `ERB/SKILLS/32_文/SKILL_文_PERSONAL_1_幻想風靡.ERB`

类型: .ERB

自动摘要: functions: SKILL_32_PERSONAL_1_EXIST, SKILL_32_PERSONAL_1_NAME, SKILL_32_PERSONAL_1_LEVEL, SKILL_32_PERSONAL_1_SETTARGET, SKILL_32_PERSONAL_1_CAN_INVOKE, SKILL_32_PERSONAL_1_INVOKE, SKILL_32_PERSONAL_1_EXPLANATION, SKILL_32_PERSONAL_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_32_PERSONAL_1_EXIST
RETURN 1

@SKILL_32_PERSONAL_1_NAME
RESULTS = 幻想風靡

;レベルは1-5まで
@SKILL_32_PERSONAL_1_LEVEL
RETURN 4

;対象選択
@SKILL_32_PERSONAL_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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

;発動判定
@SKILL_32_PERSONAL_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN GET_SOLDIER(発動勢力, 発動部隊) > 0 && GET_SOLDIER(対象勢力, 対象部隊) > 0

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_32_PERSONAL_1_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_32_PERSONAL_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 目にもとまらぬ先制攻撃！

IF 発動側 == 0
	CALL BATTLE_PREPARE_VARS(発動勢力, 発動部隊, 対象勢力, 対象部隊)
ELSE
	CALL BATTLE_PREPARE_VARS(対象勢力, 対象部隊, 発動勢力, 発動部隊)
ENDIF

BATTLE_INT:発動側 = 1
BATTLE_INT:対象側 = 1

IF 発動側 == 0
	CALL BATTLE_CALC_CORE(発動勢力, 発動部隊, 対象勢力, 対象部隊)
ELSE
	CALL BATTLE_CALC_CORE(対象勢力, 対象部隊, 発動勢力, 発動部隊)
ENDIF

VARSET BATTLE_RATE_DMG

CALL DECREASE_SOLDIER(対象勢力, 対象部隊, MAX(BATTLE_DMG:対象側 / 3, 100), 1)

@SKILL_32_PERSONAL_1_EXPLANATION
RESULTS = 戦闘に先んじて、自部隊が先制攻撃する。




@SKILL_32_PERSONAL_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
