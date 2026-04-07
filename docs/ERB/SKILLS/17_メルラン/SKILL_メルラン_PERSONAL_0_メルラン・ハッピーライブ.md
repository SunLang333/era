# SKILLS/17_メルラン/SKILL_メルラン_PERSONAL_0_メルラン・ハッピーライブ.ERB — 自动生成文档

源文件: `ERB/SKILLS/17_メルラン/SKILL_メルラン_PERSONAL_0_メルラン・ハッピーライブ.ERB`

类型: .ERB

自动摘要: functions: SKILL_17_PERSONAL_0_EXIST, SKILL_17_PERSONAL_0_NAME, SKILL_17_PERSONAL_0_LEVEL, SKILL_17_PERSONAL_0_SETTARGET, SKILL_17_PERSONAL_0_CAN_INVOKE, SKILL_17_PERSONAL_0_INVOKE, SKILL_17_PERSONAL_0_EXPLANATION, SKILL_17_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_17_PERSONAL_0_EXIST
RETURN 1

@SKILL_17_PERSONAL_0_NAME
RESULTS = メルラン・ハッピーライブ

;レベルは1-5まで
@SKILL_17_PERSONAL_0_LEVEL
RETURN 4

;対象選択
@SKILL_17_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
#DIM 能力, 3
VARSET 能力

RETURN 1

;発動判定
@SKILL_17_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_17_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 躁の音を聞いた自分以外の味方の武闘が増加した！

FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	SIF LOCAL == 発動番号
		CONTINUE
	TIMES BATTLE_武闘パワー:発動側:LOCAL, 1.1
NEXT

RETURN 1

;
@SKILL_17_PERSONAL_0_EXPLANATION
RESULTS = 自身以外の味方全員の武闘を増加させる。




@SKILL_17_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
