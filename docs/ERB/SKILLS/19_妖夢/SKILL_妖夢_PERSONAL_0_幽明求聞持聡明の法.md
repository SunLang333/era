# SKILLS/19_妖夢/SKILL_妖夢_PERSONAL_0_幽明求聞持聡明の法.ERB — 自动生成文档

源文件: `ERB/SKILLS/19_妖夢/SKILL_妖夢_PERSONAL_0_幽明求聞持聡明の法.ERB`

类型: .ERB

自动摘要: functions: SKILL_19_PERSONAL_0_EXIST, SKILL_19_PERSONAL_0_NAME, SKILL_19_PERSONAL_0_LEVEL, SKILL_19_PERSONAL_0_SETTARGET, SKILL_19_PERSONAL_0_CAN_INVOKE, SKILL_19_PERSONAL_0_INVOKE, SKILL_19_PERSONAL_0_EXPLANATION, SKILL_19_PERSONAL_0_CANT_TELL, SKILL_19_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_19_PERSONAL_0_EXIST
RETURN 1

@SKILL_19_PERSONAL_0_NAME
RESULTS = 幽明求聞持聡明の法

;レベルは1-5まで
@SKILL_19_PERSONAL_0_LEVEL
RETURN 5

;対象選択
@SKILL_19_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 1

;発動判定
@SKILL_19_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN BATTLE_COMMANDER_NUM:発動側 == 1

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_19_PERSONAL_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_19_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(発動者)%は三人に分身した！
CALL BATTLE_SUMMON(発動側, 発動者, 発動部隊 >= 0)
CALL BATTLE_SUMMON(発動側, 発動者, 発動部隊 >= 0)

@SKILL_19_PERSONAL_0_EXPLANATION
RESULTS = 自部隊が自分のみであるとき発動。三人に分身する。

@SKILL_19_PERSONAL_0_CANT_TELL




@SKILL_19_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
