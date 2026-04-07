# SKILLS/86_神子/SKILL_神子_PERSONAL_0_＊特別に両方選ばせてやろう！＊.ERB — 自动生成文档

源文件: `ERB/SKILLS/86_神子/SKILL_神子_PERSONAL_0_＊特別に両方選ばせてやろう！＊.ERB`

类型: .ERB

自动摘要: functions: SKILL_86_PERSONAL_0_EXIST, SKILL_86_PERSONAL_0_NAME, SKILL_86_PERSONAL_0_LEVEL, SKILL_86_PERSONAL_0_SETTARGET, SKILL_86_PERSONAL_0_CAN_INVOKE, SKILL_86_PERSONAL_0_INVOKE, SKILL_86_PERSONAL_0_EXPLANATION, SKILL_86_PERSONAL_0_CANT_TELL, SKILL_86_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_86_PERSONAL_0_EXIST
RETURN 1

@SKILL_86_PERSONAL_0_NAME
RESULTS = ＊特別に両方選ばせてやろう！＊

;レベルは1-5まで
@SKILL_86_PERSONAL_0_LEVEL
RETURN 1

;対象選択
@SKILL_86_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 1

;発動判定
@SKILL_86_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_86_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 両方選べるなんてお得だ！
PRINTFORML テンションのあがった敵部隊全員の武闘と知略が増加した！
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	TIMES BATTLE_武闘パワー:対象側:LOCAL, 1.2
	TIMES BATTLE_知略パワー:対象側:LOCAL, 1.2
NEXT
RETURN 1

;
@SKILL_86_PERSONAL_0_EXPLANATION
RESULTS = 敵全員の武闘と知略を増加させる。

@SKILL_86_PERSONAL_0_CANT_TELL




@SKILL_86_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
