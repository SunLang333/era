# SKILLS/65_半霊/SKILL_半霊_TROOP_1_桜花閃々.ERB — 自动生成文档

源文件: `ERB/SKILLS/65_半霊/SKILL_半霊_TROOP_1_桜花閃々.ERB`

类型: .ERB

自动摘要: functions: SKILL_65_TROOP_1_EXIST, SKILL_65_TROOP_1_NAME, SKILL_65_TROOP_1_LEVEL, SKILL_65_TROOP_1_SETTARGET, SKILL_65_TROOP_1_CAN_INVOKE, SKILL_65_TROOP_1_INVOKE, SKILL_65_TROOP_1_EXPLANATION, SKILL_65_TROOP_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_65_TROOP_1_EXIST
RETURN 1

@SKILL_65_TROOP_1_NAME
RESULTS = 桜花閃々

;レベルは1-5まで
@SKILL_65_TROOP_1_LEVEL
RETURN 3

;対象選択
@SKILL_65_TROOP_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_65_TROOP_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_65_TROOP_1_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_65_TROOP_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 人の世に
PRINTFORML 生まれし頃より
PRINTFORML 戦道
TIMES BATTLE_ATK:発動側, 1.05

@SKILL_65_TROOP_1_EXPLANATION
RESULTS = 自部隊の攻撃力を上昇させる。



@SKILL_65_TROOP_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
