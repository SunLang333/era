# SKILLS/23_萃香/SKILL_萃香_PERSONAL_2_ミッシングパープルパワー.ERB — 自动生成文档

源文件: `ERB/SKILLS/23_萃香/SKILL_萃香_PERSONAL_2_ミッシングパープルパワー.ERB`

类型: .ERB

自动摘要: functions: SKILL_23_PERSONAL_2_EXIST, SKILL_23_PERSONAL_2_NAME, SKILL_23_PERSONAL_2_LEVEL, SKILL_23_PERSONAL_2_SETTARGET, SKILL_23_PERSONAL_2_CAN_INVOKE, SKILL_23_PERSONAL_2_INVOKE, SKILL_23_PERSONAL_2_EXPLANATION, SKILL_23_PERSONAL_2_NO_LEARN_INIT, SKILL_23_PERSONAL_2_CANT_LEARN_FROM_SHOP, SKILL_23_PERSONAL_2_CANT_TELL, SKILL_23_PERSONAL_2_IS_RATE_VARIABLE, SKILL_23_PERSONAL_2_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_23_PERSONAL_2_EXIST
RETURN 1

@SKILL_23_PERSONAL_2_NAME
RESULTS = ミッシングパープルパワー

;レベルは1-5まで
@SKILL_23_PERSONAL_2_LEVEL
RETURN 5

;対象選択
@SKILL_23_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_23_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_23_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 巨大化した%ANAME(発動者)%の武闘と防衛が大増加した！
TIMES BATTLE_武闘パワー:発動側:COMBAT_SKILL_TARGET, 1.5
TIMES BATTLE_防衛パワー:発動側:COMBAT_SKILL_TARGET, 1.5
RETURN 1


@SKILL_23_PERSONAL_2_EXPLANATION
RESULTS = 自身の武闘・防衛を増加させる。


;以下の三つ、スキル習得で購入させないための処理
@SKILL_23_PERSONAL_2_NO_LEARN_INIT
@SKILL_23_PERSONAL_2_CANT_LEARN_FROM_SHOP
@SKILL_23_PERSONAL_2_CANT_TELL

;発動率が変動する場合に必要な処理
@SKILL_23_PERSONAL_2_IS_RATE_VARIABLE
RETURN 1

@SKILL_23_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN (40 + (ABL:発動者:武闘) * 2)
```
