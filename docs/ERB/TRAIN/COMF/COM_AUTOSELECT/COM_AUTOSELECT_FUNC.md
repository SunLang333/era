# TRAIN/COMF/COM_AUTOSELECT/COM_AUTOSELECT_FUNC.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COM_AUTOSELECT/COM_AUTOSELECT_FUNC.ERB`

类型: .ERB

自动摘要: functions: CHECK_SP_SADIST_CHARA, BEING_IAN_GUEST_FEMALE, BEING_IAN_SERVE_FEMALE, IS_IAN_GUEST_MALE, GET_TRAINNUM, IS_AUTOSELECT, IS_AUTOSELECT_N, SET_COM_AUTO_COM_CATEGORY, GET_INITIATIVE_U_RANK, GET_INITIATIVE_N_RANK, GET_PERVERSION_RANK, AUTO_EQUIP_RELEASE, COM_AUTOSELECT_IS_WET_ENOUGH, AUTO_N_TYPE_活発, AUTO_N_TYPE_大人しい, AUTO_N_TYPE_クール, AUTO_N_TYPE_凛とした, AUTO_N_TYPE_遊び人, AUTO_N_TYPE_魅了, AUTO_N_TYPE_陥落; UI/print; definition/data

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;# 攻め役特殊キャラ
;	慰安モブは動物以外
;	特殊勢力は自警団・サキュバス以外
;-------------------------------------------------
@CHECK_SP_SADIST_CHARA(ARG_CHARA_NUM)
#FUNCTION
#DIM ARG_CHARA_NUM

SIF TALENT:ARG_CHARA_NUM:慰安モブ != 0 && !GROUPMATCH(TALENT:ARG_CHARA_NUM:慰安モブ, 慰安_キャラ_犬, 慰安_キャラ_豚, 慰安_キャラ_馬, 慰安_キャラ_猿)
	RETURNF 1
SIF CFLAG:ARG_CHARA_NUM:慰安参加者
	RETURNF 1
SIF TALENT:ARG_CHARA_NUM:特殊勢力素質 != 0 && !GROUPMATCH(TALENT:ARG_CHARA_NUM:特殊勢力素質, 特殊勢力_サキュバス, 特殊勢力_自警団)
	RETURNF 1

RETURNF 0

;-------------------------------------------------
;# 存在チェック慰安客に女はいるか
;-------------------------------------------------
@BEING_IAN_GUEST_FEMALE
#FUNCTION
#DIM L_COUNTER

FOR L_COUNTER, 0, CHARANUM
	SIF !CFLAG:L_COUNTER:調教参加フラグ
		CONTINUE
	SIF !IS_AUTOSELECT(L_COUNTER)
		CONTINUE
	SIF !TALENT:L_COUNTER:慰安モブ && !CFLAG:L_COUNTER:慰安参加者
		CONTINUE
	SIF !IS_FEMALE(L_COUNTER)
		CONTINUE
	RETURNF 1
NEXT

RETURNF 0

;-------------------------------------------------
;# 存在チェックサービス側に女はいるか
;-------------------------------------------------
@BEING_IAN_SERVE_FEMALE
#FUNCTION
#DIM L_COUNTER

FOR L_COUNTER, 0, CHARANUM
	SIF !CFLAG:L_COUNTER:調教参加フラグ
		CONTINUE
	SIF !IS_AUTOSELECT(L_COUNTER)
		CONTINUE
	SIF TALENT:L_COUNTER:慰安モブ || CFLAG:L_COUNTER:慰安参加者
		CONTINUE
	SIF !IS_FEMALE(L_COUNTER)
		CONTINUE
	RETURNF 1
NEXT

RETURNF 0

;-------------------------------------------------
;# このキャラは男の慰安客か
;-------------------------------------------------
@IS_IAN_GUEST_MALE(ARGCHARA)
#FUNCTION
#DIM ARGCHARA

SIF !CFLAG:ARGCHARA:調教参加フラグ
	RETURNF 0
SIF !IS_AUTOSELECT(ARGCHARA)
	RETURNF 0
SIF !TALENT:ARGCHARA:慰安モブ && !CFLAG:ARGCHARA:慰安参加者
	RETURNF 0
SIF !IS_MALE(ARGCHARA)
	RETURNF 0

RETURNF 1

;-------------------------------------------------
;# TRAINNAMEからTRAIN番号をとる
;-------------------------------------------------
@GET_TRAINNUM(ARG_TEXT)
#FUNCTION
#DIMS ARG_TEXT

GETNUM TRAINNAME, ARG_TEXT

RETURNF RESULT:0

;-------------------------------------------------
;# 閨で自動行動できるキャラかを判定
;	ARG:0 = キャラ
;-------------------------------------------------
@IS_AUTOSELECT(ARG:0)
#FUNCTION

SIF ARG:0 != MASTER && CFLAG:(ARG:0):調教参加フラグ && !TCVAR:(ARG:0):51 && !TCVAR:(ARG:0):52 && !TCVAR:(ARG:0):53
	RETURNF 1

RETURNF 0

;-------------------------------------------------
;# 日常で自動行動できるキャラかを判定
;-------------------------------------------------
@IS_AUTOSELECT_N(ARG:0)
#FUNCTION

SIF ARG:0 != MASTER && CFLAG:(ARG:0):調教参加フラグ && !TCVAR:(ARG:0):51 && !TCVAR:(ARG:0):52 && !TCVAR:(ARG:0):53
	RETURNF 1

RETURNF 0

;-------------------------------------------------
;# カテゴリ設定の重複チェック
;-------------------------------------------------
@SET_COM_AUTO_COM_CATEGORY(ARG_TRAIN_NUM, ARG_COM_CATEGORY_NUM)
#DIM ARG_TRAIN_NUM
#DIM ARG_COM_CATEGORY_NUM

[IF_DEBUG]
IF COM_AUTO_COM_CATEGORY:ARG_TRAIN_NUM
;DEBUGPRINTFORML 
;DEBUGPRINTFORM #### カテゴリ設定 重複 
	IF ARG_TRAIN_NUM >= ADD_NUM_第三者に実行
;DEBUGPRINTFORM {ARG_TRAIN_NUM}.%@"第三者に%TRAINNAME:(ARG_TRAIN_NUM - ADD_NUM_第三者に実行)%", 26, LEFT%
	ELSEIF ARG_TRAIN_NUM >= ADD_NUM_対象が実行 && ARG_TRAIN_NUM < ADD_NUM_第三者に実行
;DEBUGPRINTFORM {ARG_TRAIN_NUM}.%@"%TRAINNAME:(ARG_TRAIN_NUM - ADD_NUM_対象が実行)%させる", 26, LEFT%
	ELSE
;DEBUGPRINTFORM {ARG_TRAIN_NUM}.%@"%TRAINNAME:ARG_TRAIN_NUM%する", 26, LEFT%
	ENDIF
;DEBUGPRINTFORML  設定済
ENDIF
[ENDIF]
COM_AUTO_COM_CATEGORY:ARG_TRAIN_NUM = ARG_COM_CATEGORY_NUM

RETURN 0

;-------------------------------------------------
;# 主導度Ｕの補正値
;  ARG:0=キャラ番号
;-------------------------------------------------
@GET_INITIATIVE_U_RANK(ARG:0)
#FUNCTION

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド)
	RETURNF 6
ELSEIF ABL:(ARG:0):主導度Ｕ >= 500
	RETURNF 5
ELSEIF ABL:(ARG:0):主導度Ｕ >= 300
	RETURNF 3
ELSEIF ABL:(ARG:0):主導度Ｕ >= 100
	RETURNF 1
ELSEIF ABL:(ARG:0):主導度Ｕ > -100
	RETURNF 0
ELSEIF ABL:(ARG:0):主導度Ｕ > -300
	RETURNF -1
ELSEIF ABL:(ARG:0):主導度Ｕ > -500
	RETURNF -3
ELSE
	RETURNF -5
ENDIF

;-------------------------------------------------
;# 主導度Ｎの補正値
;	ARG:0=キャラ番号
;-------------------------------------------------
@GET_INITIATIVE_N_RANK(ARG:0)
#FUNCTION

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド)
	RETURNF 6
ELSEIF ABL:(ARG:0):主導度Ｎ >= 500
	RETURNF 5
ELSEIF ABL:(ARG:0):主導度Ｎ >= 300
	RETURNF 3
ELSEIF ABL:(ARG:0):主導度Ｎ >= 100
	RETURNF 1
ELSEIF ABL:(ARG:0):主導度Ｎ > -100
	RETURNF 0
ELSEIF ABL:(ARG:0):主導度Ｎ > -300
	RETURNF -1
ELSEIF ABL:(ARG:0):主導度Ｎ > -500
	RETURNF -3
ELSE
	RETURNF -5
ENDIF

;-------------------------------------------------
;# 倒錯度の補正値
;	ARG:0=キャラ番号
;-------------------------------------------------
@GET_PERVERSION_RANK(ARG:0)
#FUNCTION

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_サド) || GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_マゾ)
	RETURNF 7
ELSEIF ABL:(ARG:0):倒錯度 >= 800
	RETURNF 6
ELSEIF ABL:(ARG:0):倒錯度 >= 500
	RETURNF 4
```
