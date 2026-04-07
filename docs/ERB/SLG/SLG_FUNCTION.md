# SLG/SLG_FUNCTION.ERB — 自动生成文档

源文件: `ERB/SLG/SLG_FUNCTION.ERB`

类型: .ERB

自动摘要: functions: GET_COUNTRY_NUM, IS_COUNTRY, GET_COUNTRY_BOSS, GET_SUM_ARMY_DF, GET_SUM_SOLDIER, GET_RECRUIT_LIMIT, GET_SUM_ECONOMY, GET_SUM_GUARD, GET_OWN_CITY, GET_COMMANDER_NUM, GET_ANIMAL_NUM, GET_UNIT_NUM, GET_COMMANDER_ALL, GET_SOLDIER, MODIFY_SOLDIER, INCREASE_SOLDIER, DECREASE_SOLDIER, SET_SOLDIER, GET_CITY_COMMANDER, GET_CITY_COMMANDER_ALL; UI/print

前 200 行源码片段:

```text
﻿;SLG部分の各種関数まとめ
;-------------------------------------------------
;現存する勢力数を返す関数
;-------------------------------------------------
@GET_COUNTRY_NUM()
#FUNCTION
LOCAL:1 = 0
FOR LOCAL, 0, MAX_COUNTRY
	SIF IS_COUNTRY(LOCAL)
		LOCAL:1 ++
NEXT
RETURNF LOCAL:1

;-------------------------------------------------
;ARG:0番の勢力の存在判定
;-------------------------------------------------
@IS_COUNTRY(ARG:0)
#FUNCTION
SIF !INRANGE(ARG:0, 0, MAX_COUNTRY - 1)
	RETURNF 0
RETURNF COUNTRY_BOSS:(ARG:0) >= 1

;-------------------------------------------------
;ARG:0番の勢力について、頭首のキャラ番号を返す関数
;-------------------------------------------------
@GET_COUNTRY_BOSS(ARG:0)
#FUNCTION
RETURNF ID_TO_CHARA(COUNTRY_BOSS:(ARG:0))

;-------------------------------------------------
;ARG:0番の勢力について、防衛兵力の合計値を返す関数
;-------------------------------------------------
@GET_SUM_ARMY_DF(ARG:0)
#FUNCTION
LOCAL:1 = 0
FOR LOCAL:0, 0, MAX_CITY
	SIF CITY_OWNER:(LOCAL:0) == ARG:0
		LOCAL:1 += CITY_SOLDIER:(LOCAL:0)
NEXT
RETURNF LOCAL:1

;-------------------------------------------------
;ARG:0番の勢力について、所持兵数の合計値を返す関数
;-------------------------------------------------
@GET_SUM_SOLDIER(ARG:0)
#FUNCTION
LOCAL:1 = COUNTRY_SOLDIER:(ARG:0)
FOR LOCAL:0, 0, MAX_CITY
	SIF CITY_OWNER:(LOCAL:0) == ARG:0
		LOCAL:1 += CITY_SOLDIER:(LOCAL:0)
NEXT
FOR LOCAL:0, 0, 10
	LOCAL:1 += MAX(0, UNIT_SOLDIER:(ARG:0):(LOCAL:0))
NEXT
RETURNF LOCAL:1

;-------------------------------------------------
;ARG:0番の勢力について、徴兵限界を返す関数
;-------------------------------------------------
@GET_RECRUIT_LIMIT(勢力)
#FUNCTION
#DIM 勢力
#DIM 最大保持数
#DIM 兵舎数

最大保持数 = GET_SUM_ECONOMY(勢力) / 10

兵舎数 = GET_DEVELOPMENT_COUNT(建造物_兵舎, 勢力)

SIF TECHNOLOGY_STATUS:勢力:TECHNOLOGY_CONSCRIPTION >= 1
	TIMES 最大保持数, 1.10
SIF TECHNOLOGY_STATUS:勢力:TECHNOLOGY_CONSCRIPTION >= 3
	TIMES 最大保持数, 1.15
SIF TECHNOLOGY_STATUS:勢力:TECHNOLOGY_CONSCRIPTION >= 6
	TIMES 最大保持数, 1.20

SIF GET_DEVELOPMENT_COUNT(建造物_集積所, 勢力) > 0
	最大保持数 += 3000

最大保持数 += 兵舎数 * 500

;経済の生値 / 10(表示数値の10倍) ベースで兵舎数が補正
RETURNF 最大保持数


;-------------------------------------------------
;ARG:0番の勢力について、経済規模の合計値を返す関数
;-------------------------------------------------
@GET_SUM_ECONOMY(ARG:0)
#FUNCTION
LOCAL:1 = 0
FOR LOCAL:0, 0, MAX_CITY
	SIF CITY_OWNER:(LOCAL:0) == ARG:0
		LOCAL:1 += CITY_ECONOMY:(LOCAL:0)
NEXT
RETURNF LOCAL:1

;-------------------------------------------------
;ARG:0番の勢力について、都市防衛力の合計値を返す関数
;-------------------------------------------------
@GET_SUM_GUARD(ARG:0)
#FUNCTION
LOCAL:1 = 0
FOR LOCAL:0, 0, MAX_CITY
	SIF CITY_OWNER:(LOCAL:0) == ARG:0
		LOCAL:1 += CITY_GUARD:(LOCAL:0)
NEXT
RETURNF LOCAL:1


;-------------------------------------------------
;ARG:0番の勢力について、支配都市数を返す関数
;-------------------------------------------------
@GET_OWN_CITY(ARG:0)
#FUNCTION

RETURNF MATCH(CITY_OWNER, ARG:0, 1, CITY_NUM + 1)

;-------------------------------------------------
;ARG:0番の勢力について、士官数を返す関数
;-------------------------------------------------
@GET_COMMANDER_NUM(ARG:0)
#FUNCTION

RETURNF CMATCH(CFLAG:1, ARG:0)

;-------------------------------------------------
;ARG:0番の勢力について、動物の数を返す関数
;-------------------------------------------------
@GET_ANIMAL_NUM(ARG:0)
#FUNCTION
LOCAL:1 = 0
FOR LOCAL, 0, CHARANUM
	SIF IS_ANIMAL(LOCAL:0) && CFLAG:(LOCAL:0):所属 == ARG:0
		LOCAL:1 ++
NEXT
RETURNF LOCAL:1

;-------------------------------------------------
;ARG:0番の勢力について、現在の部隊の数を返す関数
;-------------------------------------------------
@GET_UNIT_NUM(ARG:0)
#FUNCTION
LOCAL:1 = 0
IF IS_COUNTRY(ARG:0)
	FOR LOCAL:0, 0, MAX_UNIT
		SIF UNIT_SOLDIER:(ARG:0):(LOCAL:0) > 0
			LOCAL:1 ++
	NEXT
ENDIF
RETURNF LOCAL:1


;-------------------------------------------------
;ARG:1の正負に応じてGET_UNIT_COMMANDER_ALLとGET_CITY_COMMANDER_ALLを呼び出す関数
;その辺透過的に扱えるようにするため作成
;-------------------------------------------------
@GET_COMMANDER_ALL(ARG:0, ARG:1)
IF ARG:1 < 0
	CALL GET_CITY_COMMANDER_ALL(ARG:0)
ELSE
	CALL GET_UNIT_COMMANDER_ALL(ARG:0, ARG:1)
ENDIF
RETURN RESULT:0, RESULT:1, RESULT:2

;-------------------------------------------------
;ARG:1の正負に応じてCITY_SOLDERとUNIT_SOLDIERを取得するための関数
;CITY_SOLDIERとUNIT_SOLDIERを透過的に扱うために作成。
;-------------------------------------------------
@GET_SOLDIER(ARG:0, ARG:1)
#FUNCTION
IF ARG:1 < 0
	RETURNF CITY_SOLDIER:(ARG:0)
ELSE
	RETURNF UNIT_SOLDIER:(ARG:0):(ARG:1)
ENDIF
RETURNF -1

;-------------------------------------------------
;ARG:1の正負に応じてCITY_SOLDERとUNIT_SOLDIERを操作するための関数
;CITY_SOLDIERとUNIT_SOLDIERを透過的に扱うために作成。
;-------------------------------------------------
@MODIFY_SOLDIER(ARG:0, ARG:1, ARG:2, ARG:3 = 0)
IF ARG:1 < 0
	LOCAL:1 = CITY_OWNER:(ARG:0)
	LOCAL:2 = MAX(CITY_SOLDIER:(ARG:0) + ARG:2, 0)
	SIF ARG:3
		PRINTFORML %@"\@ GET_COUNTRY_BOSS(LOCAL:1) >= 0 ? %SNAME(GET_COUNTRY_BOSS(LOCAL:1))% # 無所属 \@", MAX_CHARANAME_LENGTH / 2, LEFT%軍:{CITY_SOLDIER:(ARG:0), 6, RIGHT} → {LOCAL:2}
	CITY_SOLDIER:(ARG:0) = LOCAL:2	
ELSE
	LOCAL:1 = ARG:0
	LOCAL:2 = MAX(UNIT_SOLDIER:(ARG:0):(ARG:1) + ARG:2, 0)
	SIF ARG:3
		PRINTFORML %SNAME(GET_COUNTRY_BOSS(LOCAL:1)), MAX_CHARANAME_LENGTH / 2, LEFT%軍:{UNIT_SOLDIER:(ARG:0):(ARG:1), 6, RIGHT} → {LOCAL:2}
	UNIT_SOLDIER:(ARG:0):(ARG:1) = LOCAL:2
ENDIF

@INCREASE_SOLDIER(ARG:0, ARG:1, ARG:2, ARG:3 = 0)
CALL MODIFY_SOLDIER(ARG:0, ARG:1, ABS(ARG:2), ARG:3)

```
