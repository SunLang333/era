# SKILLS/85_布都/SKILL_布都_PERSONAL_0_大火の改新.ERB — 自动生成文档

源文件: `ERB/SKILLS/85_布都/SKILL_布都_PERSONAL_0_大火の改新.ERB`

类型: .ERB

自动摘要: functions: SKILL_85_PERSONAL_0_EXIST, SKILL_85_PERSONAL_0_NAME, SKILL_85_PERSONAL_0_LEVEL, SKILL_85_PERSONAL_0_SETTARGET, SKILL_85_PERSONAL_0_CAN_INVOKE, SKILL_85_PERSONAL_0_INVOKE, SKILL_85_PERSONAL_0_EXPLANATION, SKILL_85_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_85_PERSONAL_0_EXIST
RETURN 1

@SKILL_85_PERSONAL_0_NAME
RESULTS = 大火の改新

;レベルは1-5まで
@SKILL_85_PERSONAL_0_LEVEL
RETURN 3

;対象選択
@SKILL_85_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;両軍対象
RETURN 1

;発動判定
@SKILL_85_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_85_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 灼熱が敵味方もろとも焼き尽くす……！
対象側 = !発動側
CALL DECREASE_SOLDIER(発動勢力, 発動部隊, LIMIT(GET_SOLDIER(発動勢力, 発動部隊) / 5, 1000, 3000), 1)
CALL DECREASE_SOLDIER(対象勢力, 対象部隊, LIMIT(GET_SOLDIER(対象勢力, 対象部隊) / 5, 1000, 3000), 1)



@SKILL_85_PERSONAL_0_EXPLANATION
RESULTS = 敵部隊と自部隊にダメージ。




@SKILL_85_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
