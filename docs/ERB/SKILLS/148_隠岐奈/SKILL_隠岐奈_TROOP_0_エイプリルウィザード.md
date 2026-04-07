# SKILLS/148_隠岐奈/SKILL_隠岐奈_TROOP_0_エイプリルウィザード.ERB — 自动生成文档

源文件: `ERB/SKILLS/148_隠岐奈/SKILL_隠岐奈_TROOP_0_エイプリルウィザード.ERB`

类型: .ERB

自动摘要: functions: SKILL_148_TROOP_0_EXIST, SKILL_148_TROOP_0_NAME, SKILL_148_TROOP_0_LEVEL, SKILL_148_TROOP_0_SETTARGET, SKILL_148_TROOP_0_CAN_INVOKE, SKILL_148_TROOP_0_INVOKE, SKILL_148_TROOP_0_EXPLANATION, SKILL_148_TROOP_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_148_TROOP_0_EXIST
RETURN 1

@SKILL_148_TROOP_0_NAME
RESULTS = エイプリルウィザード

;レベルは1-5まで
@SKILL_148_TROOP_0_LEVEL
RETURN 3

;対象選択
@SKILL_148_TROOP_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_148_TROOP_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_148_TROOP_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_148_TROOP_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 自部隊の攻撃力が上昇！
TIMES BATTLE_ATK:発動側, 1.07

@SKILL_148_TROOP_0_EXPLANATION
RESULTS = 自部隊の攻撃力を上昇させる。



@SKILL_148_TROOP_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
