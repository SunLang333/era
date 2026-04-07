# SKILLS/4_大妖精/SKILL_大妖精_PERSONAL_0_応援.ERB — 自动生成文档

源文件: `ERB/SKILLS/4_大妖精/SKILL_大妖精_PERSONAL_0_応援.ERB`

类型: .ERB

自动摘要: functions: SKILL_4_PERSONAL_0_EXIST, SKILL_4_PERSONAL_0_NAME, SKILL_4_PERSONAL_0_LEVEL, SKILL_4_PERSONAL_0_SETTARGET, SKILL_4_PERSONAL_0_CAN_INVOKE, SKILL_4_PERSONAL_0_INVOKE, SKILL_4_PERSONAL_0_EXPLANATION, SKILL_4_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_4_PERSONAL_0_EXIST
RETURN 1

@SKILL_4_PERSONAL_0_NAME
RESULTS = 応援

;レベルは1-5まで
@SKILL_4_PERSONAL_0_LEVEL
RETURN 2

;対象選択
@SKILL_4_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
SIF BATTLE_COMMANDER_NUM:発動側 == 0
	RETURN 0
COMBAT_SKILL_TARGET = RAND:(BATTLE_COMMANDER_NUM:発動側)
RETURN 1

;発動判定
@SKILL_4_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_4_PERSONAL_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル


;効果をここに記述
@SKILL_4_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(BATTLE_COMMANDER:発動側:COMBAT_SKILL_TARGET)%はやる気が出た！
BATTLE_SKILL_RATE:発動側:COMBAT_SKILL_TARGET += 20

@SKILL_4_PERSONAL_0_EXPLANATION
RESULTS = 味方一人のスキルを発動しやすくする。




@SKILL_4_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
