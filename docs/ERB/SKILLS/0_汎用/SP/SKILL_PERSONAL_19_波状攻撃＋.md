# SKILLS/0_汎用/SP/SKILL_PERSONAL_19_波状攻撃＋.ERB — 自动生成文档

源文件: `ERB/SKILLS/0_汎用/SP/SKILL_PERSONAL_19_波状攻撃＋.ERB`

类型: .ERB

自动摘要: functions: SKILL_0_PERSONAL_19_EXIST, SKILL_0_PERSONAL_19_NAME, SKILL_0_PERSONAL_19_LEVEL, SKILL_0_PERSONAL_19_SETTARGET, SKILL_0_PERSONAL_19_CAN_INVOKE, SKILL_0_PERSONAL_19_INVOKE, SKILL_0_PERSONAL_19_EXPLANATION, SKILL_0_PERSONAL_19_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_0_PERSONAL_19_EXIST
RETURN 1

@SKILL_0_PERSONAL_19_NAME
RESULTS = 波状攻撃＋

;レベルは1-5まで
@SKILL_0_PERSONAL_19_LEVEL
RETURN 2

;対象選択
@SKILL_0_PERSONAL_19_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_0_PERSONAL_19_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_0_PERSONAL_19_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_0_PERSONAL_19_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 敵部隊に連続ダメージ！
LOCAL:1 = RAND(1, 6)
FOR LOCAL, 0, LOCAL:1
	CALL DECREASE_SOLDIER(対象勢力, 対象部隊, 200, 1)
NEXT

@SKILL_0_PERSONAL_19_EXPLANATION
RESULTS = 敵部隊に複数回ダメージ。

@SKILL_0_PERSONAL_19_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 125
```
