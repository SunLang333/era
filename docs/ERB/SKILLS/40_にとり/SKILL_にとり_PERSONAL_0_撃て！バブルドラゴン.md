# SKILLS/40_にとり/SKILL_にとり_PERSONAL_0_撃て！バブルドラゴン.ERB — 自动生成文档

源文件: `ERB/SKILLS/40_にとり/SKILL_にとり_PERSONAL_0_撃て！バブルドラゴン.ERB`

类型: .ERB

自动摘要: functions: SKILL_40_PERSONAL_0_EXIST, SKILL_40_PERSONAL_0_NAME, SKILL_40_PERSONAL_0_LEVEL, SKILL_40_PERSONAL_0_SETTARGET, SKILL_40_PERSONAL_0_CAN_INVOKE, SKILL_40_PERSONAL_0_INVOKE, SKILL_40_PERSONAL_0_EXPLANATION, SKILL_40_PERSONAL_0_CANT_TELL, SKILL_40_PERSONAL_0_CANT_LEARN_FROM_SHOP, SKILL_40_PERSONAL_0_NO_LEARN_INIT, SKILL_40_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_40_PERSONAL_0_EXIST
RETURN 1

@SKILL_40_PERSONAL_0_NAME
RESULTS = 撃て！バブルドラゴン

;レベルは1-5まで
@SKILL_40_PERSONAL_0_LEVEL
RETURN 4

;対象選択
@SKILL_40_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;部隊対象
RETURN 1

;発動判定
@SKILL_40_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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

SIF 発動者 != NAME_TO_CHARA("にとり")
	RETURN 0

RETURN 1

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_40_PERSONAL_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_40_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 巨大な泡が敵をとらえる！

CALL DECREASE_SOLDIER(対象勢力, 対象部隊, RAND(1500, 2500), 1)

@SKILL_40_PERSONAL_0_EXPLANATION
RESULTS = 敵部隊にダメージ。

@SKILL_40_PERSONAL_0_CANT_TELL

@SKILL_40_PERSONAL_0_CANT_LEARN_FROM_SHOP

@SKILL_40_PERSONAL_0_NO_LEARN_INIT




@SKILL_40_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
