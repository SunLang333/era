# SKILLS/68_朱鷺子/SKILL_朱鷺子_PERSONAL_0_非ノイマン型計算機の未来.ERB — 自动生成文档

源文件: `ERB/SKILLS/68_朱鷺子/SKILL_朱鷺子_PERSONAL_0_非ノイマン型計算機の未来.ERB`

类型: .ERB

自动摘要: functions: SKILL_68_PERSONAL_0_EXIST, SKILL_68_PERSONAL_0_NAME, SKILL_68_PERSONAL_0_LEVEL, SKILL_68_PERSONAL_0_SETTARGET, SKILL_68_PERSONAL_0_CAN_INVOKE, SKILL_68_PERSONAL_0_INVOKE, SKILL_68_PERSONAL_0_EXPLANATION, SKILL_68_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_68_PERSONAL_0_EXIST
RETURN 1

@SKILL_68_PERSONAL_0_NAME
RESULTS = 非ノイマン型計算機の未来

;レベルは1-5まで
@SKILL_68_PERSONAL_0_LEVEL
RETURN 2

;対象選択
@SKILL_68_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
COMBAT_SKILL_TARGET = 発動番号
RETURN 1

;発動判定
@SKILL_68_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_68_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML なんだか賢くなった気がする！
PRINTFORML %ANAME(発動者)%の知略が増加した！
BATTLE_知略パワー:発動側:COMBAT_SKILL_TARGET += 3000
RETURN 1

;
@SKILL_68_PERSONAL_0_EXPLANATION
RESULTS = 自身の知略を増加させる。




@SKILL_68_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 120
```
