# R_CHARA/RANDOM_CHARA.ERB — 自动生成文档

源文件: `ERB/R_CHARA/RANDOM_CHARA.ERB`

类型: .ERB

自动摘要: functions: CREATE_RANDOM_CHARA, RANDOM_CHARA_SETTING, RANDOM_CHARA_SKILL_SETTING, RANDOM_CHARA_TAG_SETTING, RANDOM_CHARA_BUSTSIZE, RANDOM_CHARA_PENISSIZE, RANDOM_CHARA_HIPSIZE, RANDOM_CHARA_SENSE, KILL_INCOMPATIBLE_SENSE, SET_SENSE_RANDOM, RCHARA_TALENT_SINGLE, RCHARA_TALENT_OPPOSE, RANDOM_CHARA_NAMING, SET_MIND_POWER, SET_CHARACTER, SET_HAIR, SET_INMOU_RANDOM, SET_ARMPIT_RANDOM, RECRUIT_AI, RECRUIT_RANDOM_CHARA; UI/print; definition/data

前 200 行源码片段:

```text
﻿;ランダムキャラの処理

;-------------------------
;汎用武将の作成
;ARG:0=ケモ率、ARG:1=能力傾向、ARG:2=性別
;生成したキャラの番号を返すが、人数の限界により生成に失敗した場合-1を返す
;-------------------------
@CREATE_RANDOM_CHARA(ARG:0 = 1, ARG:1 = -1, ARG:2 = -1, ARG:3 = 0)
IF !CAN_ADD_RANDOM_CHARA()
	RETURN -1
ENDIF

;ターゲットを退避
LOCAL:0 = TARGET

;キャラを追加
ADDVOIDCHARA

;作成したキャラをターゲットにする
TARGET = CHARANUM - 1

;NOの設定
NO = FLAG:汎用武将カウント + MIN_NO_RANDOM_CHARA
FLAG:汎用武将カウント ++

;素質と能力の決定
CALL RANDOM_CHARA_SETTING(ARG:0, ARG:1, ARG:2)

;名前の決定(※素質決定後に行う)
CALL RANDOM_CHARA_NAMING(ARG:3)

;初期設定(※素質決定後に行う)
CALL INIT_NEWCHARA(TARGET)

;スキルの習得
CALL RANDOM_CHARA_SKILL_SETTING()

;衣装の設定
CALL RANDOM_CHARA_CLOTH_SETTING()

;タグの設定
CALL RANDOM_CHARA_TAG_SETTING()

;ターゲットの再設定
TARGET = LOCAL:0

RETURN CHARANUM - 1

;-------------------------
;汎用武将の素質と能力を決定する
;ARG:0=ケモ率、ARG:1=能力傾向、ARG:2=性別
;-------------------------
@RANDOM_CHARA_SETTING(ARG:0, ARG:1, ARG:2)
IF ARG:2 > 5
	THROW @"RANDOM_CHARA_SETTING 関数に設定された性別が不正です(ARG:2 = {ARG:2})"
ENDIF

;性別を指定の通りに設定、指定がない場合は設定された男性率に応じて性別をランダムに決定
LOCAL:0 = ARG:2
IF LOCAL:0 <= -1
	IF RAND:100 < CONFIG:3
		IF RAND:30 == 0
			LOCAL:0 = 4
		ELSEIF RAND:30 == 0
			LOCAL:0 = 3
		ELSE
			LOCAL:0 = 0
		ENDIF
	ELSE
		IF RAND:20 == 0
			LOCAL:0 = 2
		ELSE
			LOCAL:0 = 1
		ENDIF
	ENDIF
ENDIF

SELECTCASE LOCAL:0
	CASE 0
		;男性
		TALENT:性別 = 0
		;童貞かどうかをランダムに設定
		TALENT:童貞 = (RAND:5 <= 2)
		TALENT:処女 = 1
		TALENT:アナル処女 = 1
		;キス経験をランダムに設定
		IF TALENT:童貞
			TALENT:キス未経験 = (RAND:4 != 0)
		ELSE
			TALENT:キス未経験 = (RAND:3 == 0)
		ENDIF
	CASE 1
		;女性
		TALENT:性別 = 1
		;処女・キス経験をランダムに設定
		TALENT:童貞 = 1
		TALENT:処女 = (RAND:4 != 0)
		TALENT:アナル処女 = (RAND:10 != 0)
		IF TALENT:処女
			TALENT:キス未経験 = (RAND:4 != 0)
		ELSE
			TALENT:キス未経験 = (RAND:3 == 0)
		ENDIF
	CASE 2
		;女ふた
		TALENT:性別 = 2
		;童貞・処女かどうかをランダムに設定
		TALENT:童貞 = (RAND:5 <= 2)
		TALENT:処女 = (RAND:4 != 0)
		TALENT:アナル処女 = (RAND:10 != 0)
		IF TALENT:処女
			TALENT:キス未経験 = (RAND:4 != 0)
		ELSE
			TALENT:キス未経験 = (RAND:3 == 0)
		ENDIF
	CASE 3
		;男ふた
		TALENT:性別 = 3
		;童貞・処女かどうかをランダムに設定
		TALENT:童貞 = (RAND:5 <= 2)
		TALENT:処女 = (RAND:4 != 0)
		TALENT:アナル処女 = (RAND:10 != 0)
		IF TALENT:処女
			TALENT:キス未経験 = (RAND:4 != 0)
		ELSE
			TALENT:キス未経験 = (RAND:3 == 0)
		ENDIF
	CASE 4
		;男の娘
		TALENT:性別 = 4
		;童貞かどうかをランダムに設定(男性より童貞率高め)
		TALENT:童貞 = (RAND:8 <= 6)
		TALENT:処女 = 1
		TALENT:アナル処女 = (RAND:10 != 0)
		;キス経験をランダムに設定
		IF TALENT:童貞
			TALENT:キス未経験 = (RAND:4 != 0)
		ELSE
			TALENT:キス未経験 = (RAND:3 == 0)
		ENDIF
	CASE 5
		;男の娘ふた
		TALENT:性別 = 5
		;童貞・処女かどうかをランダムに設定
		TALENT:童貞 = (RAND:8 <= 6)
		TALENT:処女 = (RAND:4 != 0)
		TALENT:アナル処女 = (RAND:10 != 0)
		IF TALENT:処女
			TALENT:キス未経験 = (RAND:4 != 0)
		ELSE
			TALENT:キス未経験 = (RAND:3 == 0)
		ENDIF
ENDSELECT

;■BASE値の決定
LOCAL:2 = RAND:6 + RAND:5 - 4
MAXBASE:体力 = 1600 + LOCAL:2 * 100

LOCAL:2 = RAND:8 + RAND:7 - 6
IF LOCAL:2 < 0
	MAXBASE:気力 = 1300 - ABS(LOCAL:2) / 2 * 100
ELSE
	MAXBASE:気力 = 1300 + LOCAL:2 * 100
ENDIF

BASE:体力 = MAXBASE:体力
BASE:気力 = MAXBASE:気力

;■戦闘系能力と成長型の設定
;多能
IF ARG:1 == 0
	TALENT:成長型 = RANDOM_ARRAY(1, 2, 3, 4) - 1
;武官
ELSEIF ARG:1 == 1
	TALENT:成長型 = RANDOM_ARRAY(1, 3, 4)
;軍師
ELSEIF ARG:1 == 2
	TALENT:成長型 = RANDOM_ARRAY(1, 2, 5)
;政務官
ELSEIF ARG:1 == 3
	TALENT:成長型 = RANDOM_ARRAY(2, 3, 6)
;アイドル
ELSEIF ARG:1 == 4
	TALENT:成長型 = RANDOM_ARRAY(1, 8) - 1
;料理人
ELSEIF ARG:1 == 5
	TALENT:成長型 = RANDOM_ARRAY(1, 9) - 1
;指定なし
ELSE
	IF RAND:100 == 0
		TALENT:成長型 = 9
	ELSE
		TALENT:成長型 = RANDOM_ARRAY(1, 2, 3, 4, 5, 6, 7, 9) - 1
	ENDIF
ENDIF

SELECTCASE TALENT:成長型
	CASE 0
		ABL:武闘 = RAND:46 + 25
		ABL:防衛 = RAND:46 + 25
```
