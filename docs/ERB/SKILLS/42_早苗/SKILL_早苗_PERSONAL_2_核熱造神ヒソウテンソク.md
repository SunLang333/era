# SKILLS/42_早苗/SKILL_早苗_PERSONAL_2_核熱造神ヒソウテンソク.ERB — 自动生成文档

源文件: `ERB/SKILLS/42_早苗/SKILL_早苗_PERSONAL_2_核熱造神ヒソウテンソク.ERB`

类型: .ERB

自动摘要: functions: SKILL_42_PERSONAL_2_EXIST, SKILL_42_PERSONAL_2_NAME, SKILL_42_PERSONAL_2_LEVEL, SKILL_42_PERSONAL_2_SETTARGET, SKILL_42_PERSONAL_2_CAN_INVOKE, SKILL_42_PERSONAL_2_INVOKE, SKILL_42_PERSONAL_2_EXPLANATION, SKILL_42_PERSONAL_2_CANT_TELL, SKILL_42_PERSONAL_2_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_42_PERSONAL_2_EXIST
RETURN 1

@SKILL_42_PERSONAL_2_NAME
RESULTS = 核熱造神ヒソウテンソク

;レベルは1-5まで
@SKILL_42_PERSONAL_2_LEVEL
RETURN 5

;対象選択
@SKILL_42_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_42_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN (発動部隊 < 0 ? BATTLE_COMMANDER_NUM:発動側 <= 1 # BATTLE_COMMANDER_NUM:発動側 <= 2)

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_42_PERSONAL_2_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_42_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 燃える拳は正義のしるし！　卑劣な悪をうちくだく！
PRINTFORML 非想天則が参戦した！

CALL BATTLE_ADD_MOB(発動側, 発動部隊 >= 0, "非想天則", 100, 80, 50,  1, 0, 1, 1)

@SKILL_42_PERSONAL_2_EXPLANATION
RESULTS = 自部隊に空きがあるとき発動。非想天則を召喚する。

@SKILL_42_PERSONAL_2_CANT_TELL

@SKILL_42_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 300
```
