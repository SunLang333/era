# SKILLS/137_純狐/SKILL_純狐_PERSONAL_1_純粋な弾幕地獄.ERB — 自动生成文档

源文件: `ERB/SKILLS/137_純狐/SKILL_純狐_PERSONAL_1_純粋な弾幕地獄.ERB`

类型: .ERB

自动摘要: functions: SKILL_137_PERSONAL_1_EXIST, SKILL_137_PERSONAL_1_NAME, SKILL_137_PERSONAL_1_LEVEL, SKILL_137_PERSONAL_1_SETTARGET, SKILL_137_PERSONAL_1_CAN_INVOKE, SKILL_137_PERSONAL_1_INVOKE, SKILL_137_PERSONAL_1_EXPLANATION, SKILL_137_PERSONAL_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_137_PERSONAL_1_EXIST
RETURN 1

@SKILL_137_PERSONAL_1_NAME
RESULTS = 純粋な弾幕地獄

;レベルは1-5まで
@SKILL_137_PERSONAL_1_LEVEL
RETURN 5

;対象選択
@SKILL_137_PERSONAL_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_137_PERSONAL_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_137_PERSONAL_1_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_137_PERSONAL_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 無慈悲な弾幕が敵を襲う！
CALL DECREASE_SOLDIER(対象勢力, 対象部隊, RAND(2500, 3500), 1)


@SKILL_137_PERSONAL_1_EXPLANATION
RESULTS = 敵部隊にダメージ。




@SKILL_137_PERSONAL_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
