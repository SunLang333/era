# TRAIN/COMF/_COM_SOURCE.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/_COM_SOURCE.ERB`

类型: .ERB

自动摘要: functions: ADD_SOURCE_INITIATIVE_U, ADD_SOURCE_INITIATIVE_N, ADD_SOURCE_KANRAKU, ADD_SOURCE_AIZYOU, SENSE_HOUSHI, SENSE_HOUSHI_P, SENSE_SEX_PLAYER, SENSE_SEX_TARGET, SENSE_SEX_PLAYER_P, SENSE_SEX_TARGET_P, SERVE_HOUSHI, SERVE_SEX, COM_COMMON_SEX_P, COM_COMMON_SEX_V, COM_COMMON_ASEX_P, COM_COMMON_ASEX_A, COM_COMMON_USEX_P, COM_COMMON_USEX_U, ANIMAL_SOURCE_MULTIPLIER, ANIMAL_SOURCE_MULTIPLIER_REVERSED

前 200 行源码片段:

```text
﻿;コマンド関係の共通関数(特にソースに関わるもの)をまとめる

;-------------------------------------------------
;主導権に応じた優越・屈従のソースを加算する関数
;ARG:0=キャラ番号、ARG:1=優越の加算値、ARG:2=屈従の加算値
;-------------------------------------------------
@ADD_SOURCE_INITIATIVE_U(ARG:0, ARG:1, ARG:2)
;主導権をチェック
SELECTCASE GET_COM_INITIATIVE()
	;主導権がプレイヤー側
	CASE 0
		;ARG:0番のキャラがプレイヤー側
		IF IS_MPLY(ARG:0)
			LOCAL:3 = 0
		ELSE
			LOCAL:3 = 2
		ENDIF
	;主導権がターゲット側
	CASE 1
		;ARG:0番のキャラがプレイヤー側
		IF IS_MPLY(ARG:0)
			LOCAL:3 = 2
		ELSE
			LOCAL:3 = 0
		ENDIF
	;主導権が両方
	CASE 2
		LOCAL:3 = 1
	;主導権がどちらにもない
	CASE 3
		LOCAL:3 = 3
ENDSELECT

;主導権が両方・どちらにもない状況ではソース半減
IF LOCAL:3 == 1 || LOCAL:3 == 3
	LOCAL:0 = 2
ELSE
	LOCAL:0 = 1
ENDIF

;ARG:0番のキャラが主導権を持つ
IF LOCAL:3 == 0 || LOCAL:3 == 1
	SOURCE:(ARG:0):優越 += ARG:1 / LOCAL:0
ELSE
	SOURCE:(ARG:0):屈従 += ARG:2 / LOCAL:0
ENDIF

;-------------------------------------------------
;主導権に応じた主導・受動のソースを加算する関数
;ARG:0=キャラ番号、ARG:1=主導の加算値、ARG:2=受動の加算値
;-------------------------------------------------
@ADD_SOURCE_INITIATIVE_N(ARG:0, ARG:1, ARG:2)
;主導権をチェック
SELECTCASE GET_COM_INITIATIVE()
	;主導権がプレイヤー側
	CASE 0
		;ARG:0番のキャラがプレイヤー側
		IF IS_MPLY(ARG:0)
			LOCAL:3 = 0
		ELSE
			LOCAL:3 = 2
		ENDIF
	;主導権がターゲット側
	CASE 1
		;ARG:0番のキャラがプレイヤー側
		IF IS_MPLY(ARG:0)
			LOCAL:3 = 2
		ELSE
			LOCAL:3 = 0
		ENDIF
	;主導権が両方
	CASE 2
		LOCAL:3 = 1
	;主導権がどちらにもない
	CASE 3
		LOCAL:3 = 3
ENDSELECT

;主導権が両方・どちらにもない状況ではソース半減
IF LOCAL:3 == 1 || LOCAL:3 == 3
	LOCAL:0 = 2
ELSE
	LOCAL:0 = 1
ENDIF

;ARG:0番のキャラが主導権を持つ
IF LOCAL:3 == 0 || LOCAL:3 == 1
	SOURCE:(ARG:0):主導 += ARG:1 / LOCAL:0
ELSE
	SOURCE:(ARG:0):受動 += ARG:2 / LOCAL:0
ENDIF

;-------------------------------------------------
;好感度に応じた歓楽のソースを加算する関数
;ARG:0=キャラ番号、ARG:1=倍率
;-------------------------------------------------
@ADD_SOURCE_KANRAKU(ARG:0, ARG:1)
IF CFLAG:(ARG:0):2 < 100
	LOCAL:0 = MAX(CFLAG:(ARG:0):2 * 20 / 100, 0)
ELSEIF CFLAG:(ARG:0):2 < 300
	LOCAL:0 = 20 + (CFLAG:(ARG:0):2 - 100) * 10 / 200
ELSEIF CFLAG:(ARG:0):2 < 500
	LOCAL:0 = 30 + (CFLAG:(ARG:0):2 - 300) * 10 / 200
ELSEIF CFLAG:(ARG:0):2 < 800
	LOCAL:0 = 40 + (CFLAG:(ARG:0):2 - 500) * 10 / 300
ELSEIF CFLAG:(ARG:0):2 < 1500
	LOCAL:0 = 50 + (CFLAG:(ARG:0):2 - 800) * 10 / 700
ELSEIF CFLAG:(ARG:0):2 < 5000
	LOCAL:0 = 60 + (CFLAG:(ARG:0):2 - 1500) * 10 / 4500
ELSEIF CFLAG:(ARG:0):2 < 55000
	LOCAL:0 = 70 + (CFLAG:(ARG:0):2 - 5000) * 20 / 50000
ELSE
	LOCAL:0 = 90 + (CFLAG:(ARG:0):2 - 55000) / 20000
ENDIF

LOCAL:0 = MAX(LOCAL:0, 0)

;設定された倍率に応じた補正を掛け歓楽のソースを追加
SOURCE:(ARG:0):歓楽 += LOCAL:0 * ARG:1 / 100

;-------------------------------------------------
;好感度に応じた愛情のソースを加算する関数
;ARG:0=キャラ番号、ARG:1=倍率
;-------------------------------------------------
@ADD_SOURCE_AIZYOU(ARG:0, ARG:1)
LOCAL:1 = CFLAG:(ARG:0):2
IF LOCAL:1 < 100
	LOCAL:0 = MAX(LOCAL:1 / 50, 0)
ELSEIF LOCAL:1 < 300
	LOCAL:0 = 10 + (LOCAL:1 - 100) / 20
ELSEIF LOCAL:1 < 500
	LOCAL:0 = 30 + (LOCAL:1 - 300) / 20
ELSEIF LOCAL:1 < 800
	LOCAL:0 = 50 + (LOCAL:1 - 500) / 30
ELSEIF LOCAL:1 < 1500
	LOCAL:0 = 70 + (LOCAL:1 - 800) / 35
ELSEIF LOCAL:1 < 5000
	LOCAL:0 = 100 + (LOCAL:1 - 1500) / 100
ELSEIF LOCAL:1 < 55000
	LOCAL:0 = 135 + (LOCAL:1 - 5000) / 500
ELSE
	LOCAL:0 = 235 + (LOCAL:1 - 55000) / 20000
ENDIF

;設定された倍率に応じた補正を掛け愛情のソースを追加
SOURCE:(ARG:0):愛情 += LOCAL:0 * ARG:1 / 100

;-------------------------------------------------
;快感系ソースに必要な補正を掛けた値を返す関数(Ｐ以外への奉仕系)
;ARG:0=奉仕側のキャラ番号、ARG:1=相手のキャラ番号、ARG:2=快感ソースの基本値
;-------------------------------------------------
@SENSE_HOUSHI(ARG:0, ARG:1, ARG:2)
#FUNCTION
LOCAL:0 = ARG:2

SELECTCASE ABL:(ARG:0):性技
	CASE 0
		TIMES LOCAL:0, 0.5
	CASE 1
		TIMES LOCAL:0, 0.75
	CASE 2
		TIMES LOCAL:0, 1.00
	CASE 3
		TIMES LOCAL:0, 1.25
	CASE 4
		TIMES LOCAL:0, 1.50
	CASEELSE
		LOCAL:0 = LOCAL:0 * ((ABL:(ARG:0):性技 - 5) * 4 + 154) / 100
ENDSELECT

SELECTCASE ABL:(ARG:0):奉仕
	CASE 0
		TIMES LOCAL:0, 1.00
	CASE 1
		TIMES LOCAL:0, 1.04
	CASE 2
		TIMES LOCAL:0, 1.08
	CASE 3
		TIMES LOCAL:0, 1.12
	CASE 4
		TIMES LOCAL:0, 1.16
	CASEELSE
		LOCAL:0 = LOCAL:0 * ((ABL:(ARG:0):奉仕 - 5) * 1 + 120) / 100
ENDSELECT

;奉仕対象が主人公の場合
IF ARG:1 == MASTER
	;好感度と従属度と支配度のうち大きいほうが影響
	LOCAL:1 = MAX(CFLAG:(ARG:0):2, CFLAG:(ARG:0):4, CFLAG:(ARG:0):5)
	IF LOCAL:1 < 100
		TIMES LOCAL:0, 0.60
	ELSEIF LOCAL:1 < 300
		TIMES LOCAL:0, 0.70
	ELSEIF LOCAL:1 < 500
		TIMES LOCAL:0, 0.80
	ELSEIF LOCAL:1 < 800
		TIMES LOCAL:0, 0.85
	ELSEIF LOCAL:1 < 1500
		TIMES LOCAL:0, 0.95
	ELSEIF LOCAL:1 < 10000
```
