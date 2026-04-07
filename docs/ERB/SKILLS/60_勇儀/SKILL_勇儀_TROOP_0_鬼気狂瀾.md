# SKILLS/60_勇儀/SKILL_勇儀_TROOP_0_鬼気狂瀾.ERB — 自动生成文档

源文件: `ERB/SKILLS/60_勇儀/SKILL_勇儀_TROOP_0_鬼気狂瀾.ERB`

类型: .ERB

自动摘要: functions: SKILL_60_TROOP_0_EXIST, SKILL_60_TROOP_0_NAME, SKILL_60_TROOP_0_LEVEL, SKILL_60_TROOP_0_SETTARGET, SKILL_60_TROOP_0_CAN_INVOKE, SKILL_60_TROOP_0_INVOKE, SKILL_60_TROOP_0_EXPLANATION, SKILL_60_TROOP_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_60_TROOP_0_EXIST
RETURN 1

@SKILL_60_TROOP_0_NAME
RESULTS = 鬼気狂瀾

;レベルは1-5まで
@SKILL_60_TROOP_0_LEVEL
RETURN 2

;対象選択
@SKILL_60_TROOP_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_60_TROOP_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_60_TROOP_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル


;効果をここに記述
@SKILL_60_TROOP_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML %ANAME(発動者)%はひたすら殴り合う構えだ！
PRINTFORML 被害軽減リセット！　さらに互いに与える被害が激増する！
BATTLE_RATE_ATC:発動側 += 20
BATTLE_RATE_ATC:対象側 += 20
VARSET BATTLE_RATE_GRD

@SKILL_60_TROOP_0_EXPLANATION
RESULTS = 両部隊の与える被害を増加させ、被害軽減を無効化する。




@SKILL_60_TROOP_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
