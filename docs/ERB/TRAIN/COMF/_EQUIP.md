# TRAIN/COMF/_EQUIP.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/_EQUIP.ERB`

类型: .ERB

自动摘要: functions: IS_EQUIP, IS_EQUIP_PLAYER, IS_EQUIP_TARGET, IS_EQUIP_OTHERS, SEARCH_EQUIP, SEARCH_EQUIP_M, SEARCH_EQUIP_IC, SEARCH_EQUIP_IC_M, SEARCH_EQUIP_EITHER, IS_MPLY_EQUIP, IS_MTAR_EQUIP, SET_EQUIP, RELEASE_EQUIP, RELEASE_EQUIP_EX, RELEASE_ALL_EQUIP, DOWN_RELEASE_EQUIP, INIT_EQUIP, EQUIP_PLAYER_ANAME, EQUIP_TARGET_ANAME, PUTOUT_SOURCE; UI/print; definition/data

前 200 行源码片段:

```text
﻿;継続状態や装着物に関する処理

;-------------------------------------------------
;キャラARG:0がコマンド番号ARG:1～ARG:10に対応する継続状態のプレイヤーまたはターゲットなら1を返す関数
;-------------------------------------------------
@IS_EQUIP(ARG:0, ARG:1, ARG:2 = -1, ARG:3 = -1, ARG:4 = -1, ARG:5 = -1, ARG:6 = -1, ARG:7 = -1, ARG:8 = -1, ARG:9 = -1, ARG:10 = -1, ARG:11 = -1, ARG:12 = -1, ARG:13 = -1)
#FUNCTION
FOR LOCAL:0, 0, MEQUIP_NUM
	IF GROUPMATCH(MEQUIP:(LOCAL:0), ARG:1, ARG:2, ARG:3, ARG:4, ARG:5, ARG:6, ARG:7, ARG:8, ARG:9, ARG:10, ARG:11, ARG:12, ARG:13)
		FOR LOCAL:1, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
			IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:1) == ARG:0
				RETURNF 1
			ENDIF
		NEXT
		FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
			IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:1) == ARG:0
				RETURNF 1
			ENDIF
		NEXT
	ENDIF
NEXT
RETURNF 0

;-------------------------------------------------
;キャラARG:0がコマンド番号ARG:1～ARG:8に対応する継続状態のプレイヤーならば1を返す関数
;-------------------------------------------------
@IS_EQUIP_PLAYER(ARG:0, ARG:1, ARG:2 = -1, ARG:3 = -1, ARG:4 = -1, ARG:5 = -1, ARG:6 = -1, ARG:7 = -1, ARG:8 = -1, ARG:9 = -1, ARG:10 = -1, ARG:11 = -1, ARG:12 = -1, ARG:13 = -1)
#FUNCTION
FOR LOCAL:0, 0, MEQUIP_NUM
	IF GROUPMATCH(MEQUIP:(LOCAL:0), ARG:1, ARG:2, ARG:3, ARG:4, ARG:5, ARG:6, ARG:7, ARG:8, ARG:9, ARG:10, ARG:11, ARG:12, ARG:13)
		FOR LOCAL:1, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
			IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:1) == ARG:0
				RETURNF 1
			ENDIF
		NEXT
	ENDIF
NEXT
RETURNF 0

;-------------------------------------------------
;キャラARG:0がコマンド番号ARG:1～ARG:8に対応する継続状態のターゲットならば1を返す関数
;-------------------------------------------------
@IS_EQUIP_TARGET(ARG:0, ARG:1, ARG:2 = -1, ARG:3 = -1, ARG:4 = -1, ARG:5 = -1, ARG:6 = -1, ARG:7 = -1, ARG:8 = -1, ARG:9 = -1, ARG:10 = -1, ARG:11 = -1, ARG:12 = -1, ARG:13 = -1)
#FUNCTION
FOR LOCAL:0, 0, MEQUIP_NUM
	IF GROUPMATCH(MEQUIP:(LOCAL:0), ARG:1, ARG:2, ARG:3, ARG:4, ARG:5, ARG:6, ARG:7, ARG:8, ARG:9, ARG:10, ARG:11, ARG:12, ARG:13)
		FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
			IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:1) == ARG:0
				RETURNF 1
			ENDIF
		NEXT
	ENDIF
NEXT
RETURNF 0

;-------------------------------------------------
;ARG:0の値に応じて
;  -1→MPLYをプレイヤー、MTAR「以外」をターゲットとする
;  -2→MPLY「以外」をプレイヤー、MTARをターゲットとする
;  -3→MTARをプレイヤー、MPLY「以外」をターゲットとする
;  -4→MTAR「以外」をプレイヤー、MPLYをターゲットとする
;コマンド番号ARG:1～ARG:10に対応する継続状態があれば1を返す関数
;-------------------------------------------------
@IS_EQUIP_OTHERS(ARG:0, ARG:1, ARG:2 = -1, ARG:3 = -1, ARG:4 = -1, ARG:5 = -1, ARG:6 = -1, ARG:7 = -1, ARG:8 = -1, ARG:9 = -1, ARG:10 = -1, ARG:11 = -1, ARG:12 = -1, ARG:13 = -1)
#FUNCTION
FOR LOCAL:6, 1, 14
	IF ARG:(LOCAL:6) < 0
		RETURNF 0
	ENDIF
	IF ARG:0 == -1
		FOR LOCAL:0, 0, MEQUIP_NUM
			IF MEQUIP:(LOCAL:0) == ARG:(LOCAL:6)
				FOR LOCAL:1, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
					FOR LOCAL:2, 0, MPLY_NUM
						IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:1) == MPLY:(LOCAL:2)
							FOR LOCAL:3, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
								FOR LOCAL:4, 0, MTAR_NUM
									;won't this just return 1 whenever MTAR_NUM >= 2?
                                    ;I think this is broken
                                    ;Right now the japs only use it for foam play, where >1 target is impossible
									IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:3) != MTAR:(LOCAL:4)
										RETURNF 1
									ENDIF
								NEXT
							NEXT
						ENDIF
					NEXT
				NEXT
			ENDIF
		NEXT
	ELSEIF ARG:0 == -2
		FOR LOCAL:0, 0, MEQUIP_NUM
			IF MEQUIP:(LOCAL:0) == ARG:(LOCAL:6)
				FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
					FOR LOCAL:2, 0, MTAR_NUM
						IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:1) == MTAR:(LOCAL:2)
							FOR LOCAL:3, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
								FOR LOCAL:4, 0, MPLY_NUM
									IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:3) != MPLY:(LOCAL:4)
										RETURNF 1
									ENDIF
								NEXT
							NEXT
						ENDIF
					NEXT
				NEXT
			ENDIF
		NEXT
	ELSEIF ARG:0 == -3
		FOR LOCAL:0, 0, MEQUIP_NUM
			IF MEQUIP:(LOCAL:0) == ARG:(LOCAL:6)
				FOR LOCAL:1, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
					FOR LOCAL:2, 0, MTAR_NUM
						IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:1) == MTAR:(LOCAL:2)
							FOR LOCAL:3, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
								FOR LOCAL:4, 0, MPLY_NUM
									IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:3) != MPLY:(LOCAL:4)
										RETURNF 1
									ENDIF
								NEXT
							NEXT
						ENDIF
					NEXT
				NEXT
			ENDIF
		NEXT
	ELSEIF ARG:0 == -4
		FOR LOCAL:0, 0, MEQUIP_NUM
			IF MEQUIP:(LOCAL:0) == ARG:(LOCAL:6)
				FOR LOCAL:1, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
					FOR LOCAL:2, 0, MPLY_NUM
						IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:1) == MPLY:(LOCAL:2)
							FOR LOCAL:3, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
								FOR LOCAL:4, 0, MTAR_NUM
									IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:3) != MTAR:(LOCAL:4)
										RETURNF 1
									ENDIF
								NEXT
							NEXT
						ENDIF
					NEXT
				NEXT
			ENDIF
		NEXT
	ELSE
		RETURNF 0
	ENDIF
NEXT
RETURNF 0

;-------------------------------------------------
;MEQUIPのコマンド番号がARG:0、プレイヤーがARG:1、ターゲットがARG:2の継続状態を検索し、存在すればMEQUIP番号を返す
;存在しない場合は-1を返す
;プレイヤー・ターゲットに-1を指定すると、そのプレイヤー・ターゲット指定を無視して探索
;-------------------------------------------------
@SEARCH_EQUIP(ARG:0, ARG:1, ARG:2)
#FUNCTION
FOR LOCAL:0, 0, MEQUIP_NUM
	IF MEQUIP:(LOCAL:0) == ARG:0
		FOR LOCAL:1, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
			IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:1) == ARG:1 || ARG:1 == -1
				FOR LOCAL:2, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
					IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:2) == ARG:2 || ARG:2 == -1
						RETURNF LOCAL:0
					ENDIF
				NEXT
				BREAK
			ENDIF
		NEXT
	ENDIF
NEXT
RETURNF -1


;-------------------------------------------------
;as above, with multiple optional arguments
;Arguments: Character 1, Character 2, action1, action2...
;-------------------------------------------------
@SEARCH_EQUIP_M(ARG:0, ARG:1, ARG:2, ARG:3 = -1, ARG:4 = -1, ARG:5 = -1, ARG:6 = -1, ARG:7 = -1, ARG:8 = -1, ARG:9 = -1, ARG:10 = -1, ARG:11 = -1, ARG:12 = -1, ARG:13 = -1)
#FUNCTION
FOR LOCAL:0, 0, MEQUIP_NUM
	IF GROUPMATCH(MEQUIP:(LOCAL:0), ARG:2, ARG:3, ARG:4, ARG:5, ARG:6, ARG:7, ARG:8, ARG:9, ARG:10, ARG:11, ARG:12, ARG:13)
		FOR LOCAL:1, 0, MEQUIP_PLAYER_NUM:(LOCAL:0)
			IF MEQUIP_PLAYER:(LOCAL:0):(LOCAL:1) == ARG:0 || ARG:0 == -1
				FOR LOCAL:2, 0, MEQUIP_TARGET_NUM:(LOCAL:0)
					IF MEQUIP_TARGET:(LOCAL:0):(LOCAL:2) == ARG:1 || ARG:1 == -1
						RETURNF LOCAL:0
					ENDIF
				NEXT
				BREAK
			ENDIF
		NEXT
	ENDIF
NEXT
RETURNF -1

;-------------------------------------------------
;MEQUIPのコマンド番号がARG:0、プレイヤー・ターゲットがARG:1・ARG:2の継続状態を検索し、存在すればMEQUIP番号を返す
;存在しない場合は-1を返す
;SEARCH_EQUIPと違い、ARG:1とARG:2が可換(いずれか片方がプレイヤー、片方がターゲットなら条件を満たす)
```
