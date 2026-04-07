# SKILLS/12_レティ/SKILL_レティ_PERSONAL_0_テーブルターニング.ERB — 自动生成文档

源文件: `ERB/SKILLS/12_レティ/SKILL_レティ_PERSONAL_0_テーブルターニング.ERB`

类型: .ERB

自动摘要: functions: SKILL_12_PERSONAL_0_EXIST, SKILL_12_PERSONAL_0_NAME, SKILL_12_PERSONAL_0_LEVEL, SKILL_12_PERSONAL_0_SETTARGET, SKILL_12_PERSONAL_0_CAN_INVOKE, SKILL_12_PERSONAL_0_INVOKE, SKILL_12_PERSONAL_0_EXPLANATION, SKILL_12_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_12_PERSONAL_0_EXIST
RETURN 1

@SKILL_12_PERSONAL_0_NAME
RESULTS = テーブルターニング

;レベルは1-5まで
@SKILL_12_PERSONAL_0_LEVEL
RETURN 2

;対象選択
@SKILL_12_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_12_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_12_PERSONAL_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル


;効果をここに記述
@SKILL_12_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(BATTLE_COMMANDER:対象側:COMBAT_SKILL_TARGET)%は寒さに凍えて武闘が低下！
TIMES BATTLE_武闘パワー:対象側:COMBAT_SKILL_TARGET, 0.90

@SKILL_12_PERSONAL_0_EXPLANATION
RESULTS = 敵一人の武闘を低下させる。




@SKILL_12_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
