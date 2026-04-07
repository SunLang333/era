# SKILLS/58_ヤマメ/SKILL_ヤマメ_CAPTURE_0_キャプチャーウェブ.ERB — 自动生成文档

源文件: `ERB/SKILLS/58_ヤマメ/SKILL_ヤマメ_CAPTURE_0_キャプチャーウェブ.ERB`

类型: .ERB

自动摘要: functions: SKILL_58_CAPTURE_0_EXIST, SKILL_58_CAPTURE_0_NAME, SKILL_58_CAPTURE_0_LEVEL, SKILL_58_CAPTURE_0_SETTARGET, SKILL_58_CAPTURE_0_CAN_INVOKE, SKILL_58_CAPTURE_0_INVOKE, SKILL_58_CAPTURE_0_EXPLANATION, SKILL_58_CAPTURE_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_58_CAPTURE_0_EXIST
RETURN 1

@SKILL_58_CAPTURE_0_NAME
RESULTS = キャプチャーウェブ

;レベルは1-5まで
@SKILL_58_CAPTURE_0_LEVEL
RETURN 3

;対象選択
@SKILL_58_CAPTURE_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
SIF BATTLE_COMMANDER_NUM:対象側 == 0
	RETURN 0
COMBAT_SKILL_TARGET = RAND:(BATTLE_COMMANDER_NUM:対象側)
RETURN !BATTLE_SUMMONED_CHARA:対象側:COMBAT_SKILL_TARGET

;発動判定
@SKILL_58_CAPTURE_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_58_CAPTURE_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_58_CAPTURE_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 蜘蛛の糸が武将を捕らえる！
CAPTURE_RATE:COMBAT_SKILL_TARGET += 200

@SKILL_58_CAPTURE_0_EXPLANATION
RESULTS = 敵一人の捕縛率を増加させる。




@SKILL_58_CAPTURE_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
