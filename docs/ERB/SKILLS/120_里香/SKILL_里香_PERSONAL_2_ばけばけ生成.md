# SKILLS/120_里香/SKILL_里香_PERSONAL_2_ばけばけ生成.ERB — 自动生成文档

源文件: `ERB/SKILLS/120_里香/SKILL_里香_PERSONAL_2_ばけばけ生成.ERB`

类型: .ERB

自动摘要: functions: SKILL_120_PERSONAL_2_EXIST, SKILL_120_PERSONAL_2_NAME, SKILL_120_PERSONAL_2_LEVEL, SKILL_120_PERSONAL_2_SETTARGET, SKILL_120_PERSONAL_2_CAN_INVOKE, SKILL_120_PERSONAL_2_INVOKE, SKILL_120_PERSONAL_2_EXPLANATION, SKILL_120_PERSONAL_2_CANT_TELL, SKILL_120_PERSONAL_2_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_120_PERSONAL_2_EXIST
RETURN 1

@SKILL_120_PERSONAL_2_NAME
RESULTS = ばけばけ生成

;レベルは1-5まで
@SKILL_120_PERSONAL_2_LEVEL
RETURN 1

;対象選択
@SKILL_120_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_120_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_120_PERSONAL_2_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_120_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML ばけばけを作り出した！
PRINTFORML 自部隊の兵が増加する！
CALL INCREASE_SOLDIER(発動勢力, 発動部隊, RAND(300, 500), 1)



@SKILL_120_PERSONAL_2_EXPLANATION
RESULTS = 自部隊の兵数を増加させる。

@SKILL_120_PERSONAL_2_CANT_TELL






@SKILL_120_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 1000
```
