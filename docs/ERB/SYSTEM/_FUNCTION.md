# SYSTEM/_FUNCTION.ERB — 自动生成文档

源文件: `ERB/SYSTEM/_FUNCTION.ERB`

类型: .ERB

自动摘要: functions: INIT_NEWCHARA, DELETE_CHARA, SWAP_CHARA, SORT_CHARA_NO, INIT_CHARA, ANAME, SNAME, NAME_FORMAL, PRONOUN, NOUN_SEX, GET_ID, NO_TO_CHARA, ID_TO_CHARA, NAME_TO_CHARA, IS_MTAR, ADD_MTAR, DEL_MTAR, CLEAR_MTAR, IS_MPLY, ADD_MPLY; assigns RESULTS; UI/print; references CSV; definition/data

前 200 行源码片段:

```text
﻿;基本的な関数をまとめる

;-------------------------------------------------
;キャラ加入時の共通設定
;-------------------------------------------------
@INIT_NEWCHARA(ARG:0)
;キャラIDを設定(1から始まる)
FLAG:998 ++
CFLAG:(ARG:0):キャラＩＤ = FLAG:998

;主導度・倒錯度の初期設定
CALL INIT_TENDENCY(ARG:0)

FOR LOCAL, 0, VARSIZE("SEXUAL_EXPERIENCE_SITUATION")
	SEXUAL_EXPERIENCE_SITUATION:(ARG:0):LOCAL =
	SEXUAL_LAST_EXPERIENCE_SITUATION:(ARG:0):LOCAL =
NEXT

;キス未経験でないならキス経験を不明として記録
IF !TALENT:(ARG:0):キス未経験
	SEXUAL_EXPERIENCE:(ARG:0):初体験_キス = 不明
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_キス = 不明
ELSE
	SEXUAL_EXPERIENCE:(ARG:0):初体験_キス = ----
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_キス = ----
ENDIF

IF HAS_VAGINA(ARG:0) && !TALENT:(ARG:0):処女
	SEXUAL_EXPERIENCE:(ARG:0):初体験_処女 = 不明
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_処女 = 不明
ELSE
	TALENT:(ARG:0):処女 = 1
	SEXUAL_EXPERIENCE:(ARG:0):初体験_処女 = ----
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_処女 = ----
ENDIF

IF HAS_PENIS(ARG:0) && !TALENT:(ARG:0):童貞
	SEXUAL_EXPERIENCE:(ARG:0):初体験_童貞 = 不明
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_童貞 = 不明
ELSE
	TALENT:(ARG:0):童貞 = 1
	SEXUAL_EXPERIENCE:(ARG:0):初体験_童貞 = ----
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_童貞 = ----
ENDIF

IF !TALENT:(ARG:0):アナル処女
	SEXUAL_EXPERIENCE:(ARG:0):初体験_アナル処女 = 不明
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_アナル処女 = 不明
ELSE
	TALENT:(ARG:0):アナル処女 = 1
	SEXUAL_EXPERIENCE:(ARG:0):初体験_アナル処女 = ----
	SEXUAL_LAST_EXPERIENCE:(ARG:0):初体験_アナル処女 = ----
ENDIF

TALENT:(ARG:0):危険日 = RAND:5

CALL SET_BODYSIZE(ARG:0)

CALL TAG_INIT(ARG:0, NO:(ARG:0))

CALL SKILL_INIT(ARG:0)

CALL CLOTH_INIT(ARG:0)

;汎用キャラなら口上パターンを設定
IF IS_CHILD(ARG:0) || IS_RANDOM_CHARA(ARG:0)
	CALL SET_KOJO_PATTERN(ARG:0)
ENDIF

;-------------------------------------------------
;キャラARG:0を削除する関数
;-------------------------------------------------
@DELETE_CHARA(ARG:0)
;東方キャラの場合
IF IS_TOHO_CHARA(ARG:0)
	;削除は禁止。エラーメッセージを出力
	THROW 東方キャラを削除することはできません(キャラ番号={ARG:0})

;ランダムキャラ(汎用)の場合
ELSEIF IS_RANDOM_CHARA(ARG:0)
	;キャラARG:0より後ろのNOを持つキャラのNOを詰める
	FOR LOCAL:0, 0, CHARANUM
		IF NO:(LOCAL:0) > NO:(ARG:0) && IS_RANDOM_CHARA(LOCAL:0)
			NO:(LOCAL:0) --
		ENDIF
	NEXT
	;ランダムキャラのNO割り振り用変数を一つ戻す
	FLAG:汎用武将カウント --

;ランダムキャラ(子供)の場合
ELSEIF IS_CHILD(ARG:0)
	;キャラARG:0より後ろのNOを持つキャラのNOを詰める
	FOR LOCAL:0, 0, CHARANUM
		IF NO:(LOCAL:0) > NO:(ARG:0) && IS_CHILD(LOCAL:0)
			NO:(LOCAL:0) --
		ENDIF
	NEXT
	;子供のNO割り振り用変数を一つ戻す
	FLAG:子供カウント --

;イベントキャラの場合
ELSE
	;固有の処理は不要
ENDIF

;削除されるキャラが育児されている子供であった場合、その親の育児状態を削除する
IF CFLAG:(ARG:0):行動不能状態 == 行動不能_子供
	FOR LOCAL:0, 0, CHARANUM
		SIF ID_TO_CHARA(CFLAG:(LOCAL:0):育児対象) == ARG:0
			CALL RESET_MOTHER_STATE(LOCAL:0, 0)
	NEXT
ENDIF

;削除されるキャラを初体験とする

;キャラの削除
DELCHARA ARG:0

;REL_LIKE、REL_HATEの修正
FOR LOCAL:0, 0, CHARANUM
	FOR LOCAL:1, ARG:0, CHARANUM
		REL_LIKE:(LOCAL:0):(LOCAL:1) = REL_LIKE:(LOCAL:0):(LOCAL:1 + 1)
		REL_HATE:(LOCAL:0):(LOCAL:1) = REL_HATE:(LOCAL:0):(LOCAL:1 + 1)
	NEXT
	REL_LIKE:(LOCAL:0):CHARANUM = 0
	REL_HATE:(LOCAL:0):CHARANUM = 0
NEXT


;-------------------------------------------------
;キャラARG:0とARG:1のキャラ番号を入れ替える関数(必要な変数も追随させる)
;-------------------------------------------------
@SWAP_CHARA(ARG:0, ARG:1)
SWAPCHARA ARG:0, ARG:1

;REL_LIKE、REL_HATEの修正
FOR LOCAL:0, 0, CHARANUM
	SWAP REL_LIKE:(LOCAL:0):(ARG:0), REL_LIKE:(LOCAL:0):(ARG:1)
	SWAP REL_HATE:(LOCAL:0):(ARG:0), REL_HATE:(LOCAL:0):(ARG:1)
NEXT

;-------------------------------------------------
;キャラをNO順に並べ替える関数(必要な変数も追随させる)
;-------------------------------------------------
@SORT_CHARA_NO
FOR LOCAL:0, 1, CHARANUM
	FOR LOCAL:1, LOCAL:0, 0, -1
		IF NO:(LOCAL:1 - 1) > NO:(LOCAL:1)
			CALL SWAP_CHARA(LOCAL:1 - 1, LOCAL:1)
		ELSE
			BREAK
		ENDIF
	NEXT
NEXT

;-------------------------------------------------
;キャラARG:0を初期状態に戻す関数(初期値が記録されていない場合、再生成を試みる)
;東方キャラに使用した場合、後でADDITIONAL_CHARA_SETTING関数を呼び出すこと
;-------------------------------------------------
@INIT_CHARA(ARG:0)

;クールタイムは消去しておく
COOLTIME:(ARG:0):0 = 0

;CSVが存在しない場合
IF !EXISTCSV(NO:(ARG:0))
	;初期化しない(できない)
	RETURN
ENDIF


;初期化しないCFLAGを退避
LOCAL:9 = 0
IF CFLAG:(ARG:0):行動不能状態 == 行動不能_子供
	LOCAL:9 = 1
ENDIF
LOCAL:11 = CFLAG:(ARG:0):母親
LOCAL:12 = CFLAG:(ARG:0):父親
LOCAL:13 = CFLAG:(ARG:0):子の成長度
LOCAL:14 = CFLAG:(ARG:0):キャラＩＤ
LOCAL:15 = CFLAG:(ARG:0):汎用口上パターン
LOCAL:16 = CFLAG:(ARG:0):51
LOCAL:17 = CFLAG:(ARG:0):52
LOCAL:18 = CFLAG:(ARG:0):53
LOCAL:19 = CFLAG:(ARG:0):54
LOCAL:20 = CFLAG:(ARG:0):陥落済み
LOCAL:21 = CFLAG:(ARG:0):陥落するな
;CFLAG, MARK, PALAMを全て0に
FOR LOCAL:0, 0, VARSIZE("CFLAG")
	CFLAG:(ARG:0):(LOCAL:0) = 0
NEXT
FOR LOCAL:0, 0, VARSIZE("MARK")
	MARK:(ARG:0):(LOCAL:0) = 0
NEXT
FOR LOCAL:0, 0, VARSIZE("PALAM")
	PALAM:(ARG:0):(LOCAL:0) = 0
NEXT

;REL_LIKE、REL_HATEを初期化
FOR LOCAL:0, 0, CHARANUM
```
