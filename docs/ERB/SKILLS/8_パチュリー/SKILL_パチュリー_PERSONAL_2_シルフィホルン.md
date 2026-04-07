# SKILLS/8_パチュリー/SKILL_パチュリー_PERSONAL_2_シルフィホルン.ERB — 自动生成文档

源文件: `ERB/SKILLS/8_パチュリー/SKILL_パチュリー_PERSONAL_2_シルフィホルン.ERB`

类型: .ERB

自动摘要: functions: SKILL_8_PERSONAL_2_EXIST, SKILL_8_PERSONAL_2_NAME, SKILL_8_PERSONAL_2_LEVEL, SKILL_8_PERSONAL_2_SETTARGET, SKILL_8_PERSONAL_2_CAN_INVOKE, SKILL_8_PERSONAL_2_INVOKE, SKILL_8_PERSONAL_2_EXPLANATION, SKILL_8_PERSONAL_2_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_8_PERSONAL_2_EXIST
RETURN 1

@SKILL_8_PERSONAL_2_NAME
RESULTS = シルフィホルン

;レベルは1-5まで
@SKILL_8_PERSONAL_2_LEVEL
RETURN 2

;対象選択
@SKILL_8_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_8_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_8_PERSONAL_2_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_8_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 風が敵を切り刻む！
CALL DECREASE_SOLDIER(対象勢力, 対象部隊, RAND(300, 700), 1)

@SKILL_8_PERSONAL_2_EXPLANATION
RESULTS = 敵部隊にダメージ。




@SKILL_8_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
