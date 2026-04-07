# SKILLS/25_ミスティア/SKILL_ミスティア_PERSONAL_2_ヒューマンケージ.ERB — 自动生成文档

源文件: `ERB/SKILLS/25_ミスティア/SKILL_ミスティア_PERSONAL_2_ヒューマンケージ.ERB`

类型: .ERB

自动摘要: functions: SKILL_25_PERSONAL_2_EXIST, SKILL_25_PERSONAL_2_NAME, SKILL_25_PERSONAL_2_LEVEL, SKILL_25_PERSONAL_2_SETTARGET, SKILL_25_PERSONAL_2_CAN_INVOKE, SKILL_25_PERSONAL_2_INVOKE, SKILL_25_PERSONAL_2_EXPLANATION, SKILL_25_PERSONAL_2_NO_LEARN_INIT, SKILL_25_PERSONAL_2_CANT_TELL, SKILL_25_PERSONAL_2_CANT_LEARN_FROM_SHOP, SKILL_25_PERSONAL_2_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_25_PERSONAL_2_EXIST
RETURN 1

@SKILL_25_PERSONAL_2_NAME
RESULTS = ヒューマンケージ

;レベルは1-5まで
@SKILL_25_PERSONAL_2_LEVEL
RETURN 2

;対象選択
@SKILL_25_PERSONAL_2_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_25_PERSONAL_2_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
	SIF HAS_TAG(BATTLE_COMMANDER:対象側:LOCAL, タグ_人間)
		RETURN 1
NEXT
RETURN 0

;発動テキストをオーバライドしたいときに。
;「誰それのスキル発動！　○○した！」の「○○した！」の部分を実装したい場合は、
;これじゃなくてINVOKEで書けばいいです。
;@SKILL_25_PERSONAL_2_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル

;効果をここに記述
@SKILL_25_PERSONAL_2_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
LOCAL:1 = 100
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	SIF HAS_TAG(BATTLE_COMMANDER:対象側:LOCAL, タグ_人間)
		LOCAL:1 += 7
NEXT
PRINTFORML この歌は人間を虜にする！
PRINTFORML %ANAME(発動者)%の武闘が上昇！
BATTLE_武闘パワー:発動側:発動番号 = BATTLE_武闘パワー:発動側:発動番号 * LOCAL:1 / 100

@SKILL_25_PERSONAL_2_EXPLANATION
RESULTS = 敵部隊の人間の数に応じ、自身の武闘を上昇させる。

@SKILL_25_PERSONAL_2_NO_LEARN_INIT
@SKILL_25_PERSONAL_2_CANT_TELL
@SKILL_25_PERSONAL_2_CANT_LEARN_FROM_SHOP






@SKILL_25_PERSONAL_2_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
