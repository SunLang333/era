# SKILLS/23_萃香/SKILL_萃香_PERSONAL_4_大江山悉皆殺し.ERB — 自动生成文档

源文件: `ERB/SKILLS/23_萃香/SKILL_萃香_PERSONAL_4_大江山悉皆殺し.ERB`

类型: .ERB

自动摘要: functions: SKILL_23_PERSONAL_4_EXIST, SKILL_23_PERSONAL_4_NAME, SKILL_23_PERSONAL_4_LEVEL, SKILL_23_PERSONAL_4_SETTARGET, SKILL_23_PERSONAL_4_CAN_INVOKE, SKILL_23_PERSONAL_4_INVOKE, SKILL_23_PERSONAL_4_EXPLANATION, SKILL_23_PERSONAL_4_NO_LEARN_INIT, SKILL_23_PERSONAL_4_CANT_LEARN_FROM_SHOP, SKILL_23_PERSONAL_4_CANT_TELL, SKILL_23_PERSONAL_4_IS_RATE_VARIABLE, SKILL_23_PERSONAL_4_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_23_PERSONAL_4_EXIST
RETURN 1

@SKILL_23_PERSONAL_4_NAME
RESULTS = 大江山悉皆殺し

;レベルは1-5まで
@SKILL_23_PERSONAL_4_LEVEL
RETURN 5

;対象選択
@SKILL_23_PERSONAL_4_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;自部隊対象
RETURN 1

;発動判定
@SKILL_23_PERSONAL_4_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_23_PERSONAL_4_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 鬼の金剛力が敵味方もろとも吹き飛ばす！
対象側 = !発動側
CALL DECREASE_SOLDIER(発動勢力, 発動部隊, LIMIT(GET_SOLDIER(発動勢力, 発動部隊) / 2, 2500, 5000), 1)
CALL DECREASE_SOLDIER(対象勢力, 対象部隊, LIMIT(GET_SOLDIER(対象勢力, 対象部隊) / 2, 3000, 6000), 1)


@SKILL_23_PERSONAL_4_EXPLANATION
RESULTS = 敵部隊と自部隊にダメージ。

;以下の三つ、スキル習得で購入させないための処理
@SKILL_23_PERSONAL_4_NO_LEARN_INIT
@SKILL_23_PERSONAL_4_CANT_LEARN_FROM_SHOP
@SKILL_23_PERSONAL_4_CANT_TELL

;発動率が変動する場合に必要な処理
@SKILL_23_PERSONAL_4_IS_RATE_VARIABLE
RETURN 1

@SKILL_23_PERSONAL_4_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN (35 + (ABL:発動者:武闘) * 2)
```
