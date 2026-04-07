# SKILLS/20_幽々子/SKILL_幽々子_TROOP_0_无寿国への約束手形.ERB — 自动生成文档

源文件: `ERB/SKILLS/20_幽々子/SKILL_幽々子_TROOP_0_无寿国への約束手形.ERB`

类型: .ERB

自动摘要: functions: SKILL_20_TROOP_0_EXIST, SKILL_20_TROOP_0_NAME, SKILL_20_TROOP_0_LEVEL, SKILL_20_TROOP_0_SETTARGET, SKILL_20_TROOP_0_CAN_INVOKE, SKILL_20_TROOP_0_INVOKE, SKILL_20_TROOP_0_EXPLANATION, SKILL_20_TROOP_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_20_TROOP_0_EXIST
RETURN 1

@SKILL_20_TROOP_0_NAME
RESULTS = 无寿国への約束手形

;レベルは1-5まで
@SKILL_20_TROOP_0_LEVEL
RETURN 2

;対象選択
@SKILL_20_TROOP_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_20_TROOP_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_20_TROOP_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル


;効果をここに記述
@SKILL_20_TROOP_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 敵部隊の防御力が低下した！
TIMES BATTLE_DEF:対象側, 0.95

@SKILL_20_TROOP_0_EXPLANATION
RESULTS = 敵部隊の防御力を低下させる。




@SKILL_20_TROOP_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 100
```
