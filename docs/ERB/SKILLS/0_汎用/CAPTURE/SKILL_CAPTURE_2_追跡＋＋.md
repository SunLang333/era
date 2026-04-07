# SKILLS/0_汎用/CAPTURE/SKILL_CAPTURE_2_追跡＋＋.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/CAPTURE/SKILL_CAPTURE_2_追跡＋＋.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_CAPTURE_2_EXIST, SKILL_0_CAPTURE_2_NAME, SKILL_0_CAPTURE_2_LEVEL, SKILL_0_CAPTURE_2_SETTARGET, SKILL_0_CAPTURE_2_CAN_INVOKE, SKILL_0_CAPTURE_2_INVOKE, SKILL_0_CAPTURE_2_EXPLANATION, SKILL_0_CAPTURE_2_RATE; assigns RESULTS

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_0_CAPTURE_2_EXIST
RETURN 1

@SKILL_0_CAPTURE_2_NAME
RESULTS = 追跡＋＋

;レベルは1-5まで
@SKILL_0_CAPTURE_2_LEVEL
RETURN 3

;対象選択
@SKILL_0_CAPTURE_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN !BATTLE_SUMMONED_CHARA:対象側:COMBAT_SKILL_TARGET

;発動判定
@SKILL_0_CAPTURE_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_0_CAPTURE_2_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_0_CAPTURE_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
CAPTURE_RATE:COMBAT_SKILL_TARGET += 200

@SKILL_0_CAPTURE_2_EXPLANATION
RESULTS = 敵一人の捕縛率を増加させる。




@SKILL_0_CAPTURE_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 250
```
