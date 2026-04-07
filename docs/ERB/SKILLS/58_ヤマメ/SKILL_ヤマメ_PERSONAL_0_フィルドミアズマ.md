# SKILLS/58_ヤマメ/SKILL_ヤマメ_PERSONAL_0_フィルドミアズマ.ERB — 自动生成文档

源文件: `ERB/SKILLS/58_ヤマメ/SKILL_ヤマメ_PERSONAL_0_フィルドミアズマ.ERB`

类型: .ERB

自动摘要: functions: SKILL_58_PERSONAL_0_EXIST, SKILL_58_PERSONAL_0_NAME, SKILL_58_PERSONAL_0_LEVEL, SKILL_58_PERSONAL_0_SETTARGET, SKILL_58_PERSONAL_0_CAN_INVOKE, SKILL_58_PERSONAL_0_INVOKE, SKILL_58_PERSONAL_0_EXPLANATION, SKILL_58_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_58_PERSONAL_0_EXIST
RETURN 1

@SKILL_58_PERSONAL_0_NAME
RESULTS = フィルドミアズマ

;レベルは1-5まで
@SKILL_58_PERSONAL_0_LEVEL
RETURN 4

;対象選択
@SKILL_58_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
#DIM 能力, 3
VARSET 能力
対象側 = !発動側
SIF BATTLE_COMMANDER_NUM:対象側 == 0
	RETURN 0
RETURN 1

;発動判定
@SKILL_58_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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

;効果をここに記述
@SKILL_58_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 敵全員の武闘と防衛が低下！
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	TIMES BATTLE_武闘パワー:対象側:LOCAL, 0.9
	TIMES BATTLE_防衛パワー:対象側:LOCAL, 0.9
NEXT
RETURN 1

;
@SKILL_58_PERSONAL_0_EXPLANATION
RESULTS = 敵全員の武闘・防衛を低下させる。




@SKILL_58_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
