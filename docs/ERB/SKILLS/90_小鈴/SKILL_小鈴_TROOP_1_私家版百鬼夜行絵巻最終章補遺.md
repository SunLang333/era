# SKILLS/90_小鈴/SKILL_小鈴_TROOP_1_私家版百鬼夜行絵巻最終章補遺.ERB — 自动生成文档

源文件: `ERB/SKILLS/90_小鈴/SKILL_小鈴_TROOP_1_私家版百鬼夜行絵巻最終章補遺.ERB`

类型: .ERB

自动摘要: functions: SKILL_90_TROOP_1_EXIST, SKILL_90_TROOP_1_NAME, SKILL_90_TROOP_1_LEVEL, SKILL_90_TROOP_1_SETTARGET, SKILL_90_TROOP_1_CAN_INVOKE, SKILL_90_TROOP_1_INVOKE, SKILL_90_TROOP_1_EXPLANATION, SKILL_90_TROOP_1_CANT_TELL, SKILL_90_TROOP_1_RATE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-----------------------------------
;基本値計算に先んじて処理するもの
;-----------------------------------
@SKILL_90_TROOP_1_EXIST
RETURN 1

@SKILL_90_TROOP_1_NAME
RESULTS = 私家版百鬼夜行絵巻最終章補遺

;レベルは1-5まで
@SKILL_90_TROOP_1_LEVEL
RETURN 5

;対象選択
@SKILL_90_TROOP_1_SETTARGET(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
@SKILL_90_TROOP_1_CAN_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
;@SKILL_90_TROOP_1_INVOKE_TEXT(発動者, スキル, ジャンル)
;#DIM 発動者
;#DIM スキル
;#DIMS ジャンル


;効果をここに記述
@SKILL_90_TROOP_1_INVOKE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
LOCAL:1 = 0
FOR LOCAL, 0, BATTLE_COMMANDER_NUM:対象側
	SIF HAS_TAG(BATTLE_COMMANDER:対象側:LOCAL, タグ_妖怪)
		LOCAL:1 += 5
NEXT
PRINTFORML 自部隊の受ける被害が減少した！
BATTLE_RATE_GRD:発動側 += LOCAL:1

@SKILL_90_TROOP_1_EXPLANATION
RESULTS = 敵部隊の妖怪の数に応じ、自部隊の被害を軽減させる。

@SKILL_90_TROOP_1_CANT_TELL



@SKILL_90_TROOP_1_RATE(発動者, 発動番号, 発動側, 発動勢力, 発動部隊, 対象勢力, 対象部隊)
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
