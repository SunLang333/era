# SKILLS/0_汎用/BASE/SKILL_TROOP_35_霊界トランス.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/BASE/SKILL_TROOP_35_霊界トランス.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_TROOP_35_EXIST, SKILL_0_TROOP_35_NAME, SKILL_0_TROOP_35_LEVEL, SKILL_0_TROOP_35_SETTARGET, SKILL_0_TROOP_35_CAN_INVOKE, SKILL_0_TROOP_35_INVOKE, SKILL_0_TROOP_35_EXPLANATION, SKILL_0_TROOP_35_NO_LEARN_INIT, SKILL_0_TROOP_35_CANT_LEARN_FROM_SHOP, SKILL_0_TROOP_35_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_0_TROOP_35_EXIST
RETURN 1

@SKILL_0_TROOP_35_NAME
RESULTS = 霊界トランス

;レベルは1-5まで
@SKILL_0_TROOP_35_LEVEL
RETURN 5

;対象選択
@SKILL_0_TROOP_35_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_0_TROOP_35_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_0_TROOP_35_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル


;効果をここに記述
@SKILL_0_TROOP_35_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 自部隊の防御力が上昇！
TIMES BATTLE_DEF:発動側, 1.05

@SKILL_0_TROOP_35_EXPLANATION
RESULTS = 自部隊の防御力を増加させる。

@SKILL_0_TROOP_35_NO_LEARN_INIT
@SKILL_0_TROOP_35_CANT_LEARN_FROM_SHOP

@SKILL_0_TROOP_35_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
