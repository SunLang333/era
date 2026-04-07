# SKILLS/9_咲夜/SKILL_咲夜_PERSONAL_0_咲夜の世界.ERB — 自动生成文档

源文件: `ERB/SKILLS/9_咲夜/SKILL_咲夜_PERSONAL_0_咲夜の世界.ERB`

类型: .ERB

自动摘要: functions: SKILL_9_PERSONAL_0_EXIST, SKILL_9_PERSONAL_0_NAME, SKILL_9_PERSONAL_0_LEVEL, SKILL_9_PERSONAL_0_SETTARGET, SKILL_9_PERSONAL_0_CAN_INVOKE, SKILL_9_PERSONAL_0_INVOKE, SKILL_9_PERSONAL_0_EXPLANATION, SKILL_9_PERSONAL_0_CANT_TELL, SKILL_9_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_9_PERSONAL_0_EXIST
RETURN 1

@SKILL_9_PERSONAL_0_NAME
RESULTS = 咲夜の世界

;レベルは1-5まで
@SKILL_9_PERSONAL_0_LEVEL
RETURN 5

;対象選択
@SKILL_9_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_9_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_9_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 何もかもが止まる……！
PRINTFORML %ANAME(発動者)%以外はこの戦闘に参加できない！
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:発動側
	IF LOCAL != 発動番号
		CALL BATTLE_KNOCKOUT(発動側, LOCAL)
	ENDIF
NEXT
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	CALL BATTLE_KNOCKOUT(対象側, LOCAL)
NEXT

RETURN 1

;
@SKILL_9_PERSONAL_0_EXPLANATION
RESULTS = 自身以外を戦闘不能にする。

@SKILL_9_PERSONAL_0_CANT_TELL




@SKILL_9_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 50
```
