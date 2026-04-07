# SKILLS/5_チルノ/SKILL_チルノ_PERSONAL_1_超⑨武神覇斬.ERB — 自动生成文档

源文件: `ERB/SKILLS/5_チルノ/SKILL_チルノ_PERSONAL_1_超⑨武神覇斬.ERB`

类型: .ERB

自动摘要: functions: SKILL_5_PERSONAL_1_EXIST, SKILL_5_PERSONAL_1_NAME, SKILL_5_PERSONAL_1_LEVEL, SKILL_5_PERSONAL_1_SETTARGET, SKILL_5_PERSONAL_1_CAN_INVOKE, SKILL_5_PERSONAL_1_INVOKE, SKILL_5_PERSONAL_1_EXPLANATION, SKILL_5_PERSONAL_1_CANT_TELL, SKILL_5_PERSONAL_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_5_PERSONAL_1_EXIST
RETURN 1

@SKILL_5_PERSONAL_1_NAME
RESULTS = 超⑨武神覇斬

;レベルは1-5まで
@SKILL_5_PERSONAL_1_LEVEL
RETURN 3

;対象選択
@SKILL_5_PERSONAL_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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

;発動判定
@SKILL_5_PERSONAL_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN ランク閾値:ランク_ＳＬＧ:ランク_C <= ABL:(発動者):武闘 

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_5_PERSONAL_1_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_5_PERSONAL_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 敵部隊を切り刻んだ！
CALL DECREASE_SOLDIER(対象勢力, 対象部隊, 999, 1)

@SKILL_5_PERSONAL_1_EXPLANATION
RESULTS = 敵部隊にダメージ。一定の武闘が必要。

@SKILL_5_PERSONAL_1_CANT_TELL




@SKILL_5_PERSONAL_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 500
```
