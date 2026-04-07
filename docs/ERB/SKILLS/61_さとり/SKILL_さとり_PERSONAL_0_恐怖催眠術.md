# SKILLS/61_さとり/SKILL_さとり_PERSONAL_0_恐怖催眠術.ERB — 自动生成文档

源文件: `ERB/SKILLS/61_さとり/SKILL_さとり_PERSONAL_0_恐怖催眠術.ERB`

类型: .ERB

自动摘要: functions: SKILL_61_PERSONAL_0_EXIST, SKILL_61_PERSONAL_0_NAME, SKILL_61_PERSONAL_0_LEVEL, SKILL_61_PERSONAL_0_SETTARGET, SKILL_61_PERSONAL_0_CAN_INVOKE, SKILL_61_PERSONAL_0_INVOKE, SKILL_61_PERSONAL_0_EXPLANATION, SKILL_61_PERSONAL_0_CANT_TELL, SKILL_61_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_61_PERSONAL_0_EXIST
RETURN 1

@SKILL_61_PERSONAL_0_NAME
RESULTS = 恐怖催眠術

;レベルは1-5まで
@SKILL_61_PERSONAL_0_LEVEL
RETURN 5

;対象選択
@SKILL_61_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 1

;発動判定
@SKILL_61_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	SIF HAS_TAG(BATTLE_COMMANDER:対象側:LOCAL, タグ_妖怪)
		RETURN 1
NEXT
RETURN 0

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_61_PERSONAL_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_61_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	IF HAS_TAG(BATTLE_COMMANDER:対象側:LOCAL, タグ_妖怪)
		TIMES BATTLE_武闘パワー:対象側:LOCAL, 0.85
		TIMES BATTLE_防衛パワー:対象側:LOCAL, 0.85
	ENDIF
NEXT
PRINTFORML 敵妖怪の武闘と防衛が低下！

@SKILL_61_PERSONAL_0_EXPLANATION
RESULTS = 敵部隊の妖怪全員の武闘と防衛を低下させる。

@SKILL_61_PERSONAL_0_CANT_TELL







@SKILL_61_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
