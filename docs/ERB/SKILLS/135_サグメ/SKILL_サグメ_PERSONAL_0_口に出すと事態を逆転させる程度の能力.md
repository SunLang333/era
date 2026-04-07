# SKILLS/135_サグメ/SKILL_サグメ_PERSONAL_0_口に出すと事態を逆転させる程度の能力.ERB — 自动生成文档

源文件: `ERB/SKILLS/135_サグメ/SKILL_サグメ_PERSONAL_0_口に出すと事態を逆転させる程度の能力.ERB`

类型: .ERB

自动摘要: functions: SKILL_135_PERSONAL_0_EXIST, SKILL_135_PERSONAL_0_NAME, SKILL_135_PERSONAL_0_LEVEL, SKILL_135_PERSONAL_0_SETTARGET, SKILL_135_PERSONAL_0_CAN_INVOKE, SKILL_135_PERSONAL_0_INVOKE, SKILL_135_PERSONAL_0_EXPLANATION, SKILL_135_PERSONAL_0_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_135_PERSONAL_0_EXIST
RETURN 1

@SKILL_135_PERSONAL_0_NAME
RESULTS = 口に出すと事態を逆転させる程度の能力

;レベルは1-5まで
@SKILL_135_PERSONAL_0_LEVEL
RETURN 1

;対象選択
@SKILL_135_PERSONAL_0_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_135_PERSONAL_0_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_135_PERSONAL_0_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_135_PERSONAL_0_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
PRINTFORML 全員の武闘と知略が入れ替わる！
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:発動側
	SIF BATTLE_COMMANDER:発動側:LOCAL != 発動者
		SWAP BATTLE_武闘パワー:発動側:LOCAL, BATTLE_知略パワー:発動側:LOCAL
NEXT
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	SWAP BATTLE_武闘パワー:対象側:LOCAL, BATTLE_知略パワー:対象側:LOCAL
NEXT

@SKILL_135_PERSONAL_0_EXPLANATION
RESULTS = 自身以外の武闘・知略を入れ替える。




@SKILL_135_PERSONAL_0_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
RETURN 200
```
