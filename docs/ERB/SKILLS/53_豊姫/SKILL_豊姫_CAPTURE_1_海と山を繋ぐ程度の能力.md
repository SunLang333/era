# SKILLS/53_豊姫/SKILL_豊姫_CAPTURE_1_海と山を繋ぐ程度の能力.ERB — 自动生成文档

源文件: `ERB/SKILLS/53_豊姫/SKILL_豊姫_CAPTURE_1_海と山を繋ぐ程度の能力.ERB`

类型: .ERB

自动摘要: functions: SKILL_53_CAPTURE_1_EXIST, SKILL_53_CAPTURE_1_NAME, SKILL_53_CAPTURE_1_LEVEL, SKILL_53_CAPTURE_1_SETTARGET, SKILL_53_CAPTURE_1_CAN_INVOKE, SKILL_53_CAPTURE_1_INVOKE, SKILL_53_CAPTURE_1_EXPLANATION, SKILL_53_CAPTURE_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_53_CAPTURE_1_EXIST
RETURN 1

@SKILL_53_CAPTURE_1_NAME
RESULTS = 海と山を繋ぐ程度の能力

;レベルは1-5まで
@SKILL_53_CAPTURE_1_LEVEL
RETURN 4

;対象選択
@SKILL_53_CAPTURE_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 1

;発動判定
@SKILL_53_CAPTURE_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_53_CAPTURE_1_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_53_CAPTURE_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 敵全員を追いつめる！
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	CAPTURE_RATE:LOCAL += 200
NEXT

@SKILL_53_CAPTURE_1_EXPLANATION
RESULTS = 敵全員の捕縛率を増加させる。




@SKILL_53_CAPTURE_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
