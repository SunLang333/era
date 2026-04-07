# TRAIN/USERCOM.ERB — 自动生成文档

源文件: `ERB/TRAIN/USERCOM.ERB`

类型: .ERB

自动摘要: functions: CREATE_COMABLE_LIST, CHECK_COMABLE, SHOW_COMMAND, SHOW_PARTICIPANT_SELECTOR, SHOW_PARTICIPANT_INFO, PRINT_SHORT_PALAM1, PRINT_SHORT_PALAM2, PRINT_SHORT_EMOTION, PRINT_SHORT_DRUNK, PRINT_SHORT_MIND, PRINT_SHORT_BASE1, PRINT_SHORT_BASE2, PRE_COMORDER, SHOW_USERCOM, USERCOM, RELEASE_CONFLICT_COM, TRAIN_SHOP, FORCE_COM; assigns RESULTS; UI/print; definition/data

前 200 行源码片段:

```text
﻿;調教コマンドの基幹部分とそれに関連する処理

;-------------------------------------------------
;実行可能なコマンドの記録
;-------------------------------------------------
@CREATE_COMABLE_LIST

;リストのクリア
VARSET COM_ABLE_FLAG
VARSET COM_CONFLICT_FLAG

;モード別のコマンドを走査
FOR LOCAL:0, 0, VARSIZE("TRAINNAME")
	SIF TRAINNAME:(LOCAL:0) == ""
		CONTINUE
	;実行可能かどうかを判定
	CALL CHECK_COMABLE(LOCAL:0)
	;COM_ABLE_FLAGに実行可能かどうか保存
	;1の場合は普通に実行可能、2は干渉、3の場合は干渉コマンド外したら可能な継続実行
	SIF GROUPMATCH(RESULT, 1, 3)
		COM_ABLE_FLAG:LOCAL = 1
	IF GROUPMATCH(RESULT, 2, 3)
		COM_CONFLICT_FLAG:(LOCAL) = 1
		COM_ABLE_FLAG:LOCAL = 1
	ENDIF
	;リストの記録位置を一つ進める
NEXT

;-------------------------------------------------
;コマンドARG:0が実行可能ならCOM_LISTに記録する
;-------------------------------------------------
@CHECK_COMABLE(ARG:0)
;TRAINNAMEが定義されていないなら無視
IF TRAINNAME:(ARG:0) != ""
	;コマンドフィルタ
	IF !COM_FILTER:(ARG:0)
		; ;Only check the currently selected category. Saves some processing time.
		; TRYCALLFORM COM_CATEGORY{ARG:0}
		; IF (RESULT != TFLAG:7) && (ARG:0 != 291)
		; 	RETURN 0
		; ENDIF

		;If a continuable action is already equipped with the same players and targets, make it selectable
        ;Note: Doing this here instead of in each COM_ABLE means it works for the user, but not autoselect)
		TRYCALLFORM COM_IS_EQUIP{ARG:0}
		IF RESULT && COM_ALREADY_HAPPENING(ARG:0)
                ;Non-repeatable continuable actions: Strap-on, strapon gag, condom, blindfold, rope, gag, nose hook, exposure play draw on body, shoot video, enema&plug, summon tentacles
			IF GROUPMATCH(ARG:0, 50, 68, 75, 78, 84, 85, 86, 93, 112, 114, 115, 142, 200)
				RETURN 0
			ELSE
				RETURN 1
			ENDIF
		ENDIF

		COM_ENABLE = 1
		TRYCALLFORM COM_ABLE{ARG:0}
		COM_ENABLE = 0
		LOCAL:1 = RESULT
		LOCAL:2 = RESULT

            ;clear out mequip, except for actions like "Summon Tentacles" that strictly enable other actions, which we move to the top
            ;This way, we're only checking conditions like HAS_PENIS or IS_PLAYABLE instead of action-related conditions
		LOCAL:4 = 0
		FOR LOCAL, 0, MEQUIP_NUM
			IF GROUPMATCH(MEQUIP:LOCAL, 50, 200)
				CALL SWAP_MEQUIP(LOCAL, LOCAL:4)
				LOCAL:4++
			ENDIF
		NEXT
		LOCAL:5 = MEQUIP_NUM
		MEQUIP_NUM = LOCAL:4
		COM_ENABLE = 1
		TRYCALLFORM COM_ABLE{ARG:0}
		COM_ENABLE = 0
		LOCAL:2 = RESULT

        ;Print the disabled actions - using this for debugging
        ;SIF !RESULT && (ARG:0 < 250)
        ;    PRINTFORM %ENTRAINNAME(ARG:0)%

		MEQUIP_NUM = LOCAL:5

		;初回実行時はだめだが2回目が通るケース
		;つまり既存コマンドと干渉するケース
		IF LOCAL:1 == 0 && LOCAL:2 == 1
			RESULT = 0
			TRYCALLFORM COM_IS_EQUIP{ARG:0}
			SELECTCASE RESULT
				CASE 0
					RETURN 2
				CASE 1
					RETURN 2
				CASE 2
					RETURN 3
			ENDSELECT
		ELSEIF LOCAL:1 == LOCAL:2
			RETURN LOCAL:1
		ELSE
			;DEBUGPRINTFORML %TRAINNAME:ARG%
			RETURN 2
		ENDIF
	ENDIF
ENDIF
RETURN 0

;-------------------------------------------------
;調教コマンドの表示＆実行可能コマンドの記録
;-------------------------------------------------
@SHOW_COMMAND
#DIM L_COUNTER
#DIM AUTO_MAIN_CHARA
#DIM SET_MPLY
#DIM SET_MTAR

;実行可能なコマンドの記録
CALL CREATE_COMABLE_LIST

CALL TITLE_CATEGORY_GENERAL("コマンド")
PRINTL 

;逆調教または主人公が行動不能
IF GROUPMATCH(FLAG:調教モード, 調教_逆調教特殊, 調教_逆調教通常, 調教_慰安) || !IS_PLAYABLE(MASTER)
	PRINTPLAINFORM %TOSTR_SPACE(14)%
	PRINTBUTTON @"[なすがまま]", 0
	PRINTL 

	RETURN
ENDIF

;非ウフフ中で最終ターンならコマンド種別のタブを「特殊」で固定
IF !FLAG:ウフフフラグ && TFLAG:55 == TFLAG:56
	TFLAG:7 = 6
ENDIF

;プレイヤー・ターゲットの一覧を文字列として記録
LOCALS:0 = 
LOCALS:1 = 
LOCALS:2 = 
FOR LOCAL:0, 0, MPLY_NUM
	IF LOCAL:0 >= 1
		LOCALS:0 += @"・%ANAME(MPLY:(LOCAL:0))%"
	ELSE
		LOCALS:0 += @"%ANAME(MPLY:(LOCAL:0))%"
	ENDIF
NEXT
IF LOCALS:0 == ""
	LOCALS:0 = ----
ENDIF
FOR LOCAL:0, 0, MTAR_NUM
	IF LOCAL:0 >= 1
		LOCALS:1 += @"・%ANAME(MTAR:(LOCAL:0))%"
	ELSE
		LOCALS:1 += @"%ANAME(MTAR:(LOCAL:0))%"
	ENDIF
NEXT
IF LOCALS:1 == ""
	LOCALS:1 = ----
ENDIF

IF FLAG:ウフフフラグ && (TFLAG:7 != 5 || IS_EQUIP_PLAYER(MPLY:0, 200)) && TFLAG:7 != 6
	PRINT     
	IF IS_MPLY(MASTER)
		IF FLAG:主導権所有者 < 0 || IS_MPLY(FLAG:主導権所有者)
			PRINTFORML 「%LOCALS:0%」が「%LOCALS:1%」に――
		ELSEIF IS_MTAR(FLAG:主導権所有者)
			PRINTFORML 「%LOCALS:0%」が「%LOCALS:1%」の命令で――
		ELSE
			PRINTFORML 「%ANAME(FLAG:主導権所有者)%」の命令で「%LOCALS:0%」が「%LOCALS:1%」に――
		ENDIF
	ELSEIF IS_MTAR(MASTER)
		IF FLAG:主導権所有者 < 0 || IS_MTAR(FLAG:主導権所有者)
			PRINTFORML 「%LOCALS:1%」が「%LOCALS:0%」に命令して――
		ELSEIF IS_MPLY(FLAG:主導権所有者)
			PRINTFORML 「%LOCALS:1%」が「%LOCALS:0%」に――
		ELSE
			PRINTFORML 「%ANAME(FLAG:主導権所有者)%」の命令で「%LOCALS:0%」が「%LOCALS:1%」に――
		ENDIF
	ELSE
		IF FLAG:主導権所有者 < 0 || IS_MPLY(FLAG:主導権所有者)
			PRINTFORML 「%LOCALS:0%」が「%LOCALS:1%」に――
		ELSEIF IS_MTAR(FLAG:主導権所有者)
			PRINTFORML 「%LOCALS:0%」が「%LOCALS:1%」の命令で――
		ELSE
			PRINTFORML 「%ANAME(FLAG:主導権所有者)%」の命令で「%LOCALS:0%」が「%LOCALS:1%」に――
		ENDIF
	ENDIF
ENDIF

LOCAL:2 = 0
CALL SET_TMP_MPLY()
SET_MPLY = RESULT
CALL SET_TMP_MTAR()
SET_MTAR = RESULT

FOR LOCAL:0, 0, 1000

	;COM_FILTERが立ってる場合、対応するCOM_ABLE_FLAGは折れてるので、
	;INPUT側でチェックする必要はなし
	SIF TRAINNAME:LOCAL == "" || COM_FILTER:LOCAL
		CONTINUE
```
