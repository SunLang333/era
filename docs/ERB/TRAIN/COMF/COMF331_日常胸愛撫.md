# TRAIN/COMF/COMF331_日常胸愛撫.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF331_日常胸愛撫.ERB`

类型: .ERB

自动摘要: functions: COM_NAME331, COM_ABLE331, COM331_RATE_B, COM331, COM_IS_EQUIP331, COM_EQUIP331, EQUIP_MESSAGE331, COM_TEXT_BEFORE_EQUIP331, COM_TEXT_RELEASE_EQUIP331, COM_ORDER_PLAYER331, COM_ORDER_TARGET331, COM_TEXT_BEFORE331, COM_TEXT_LAST331, COM_AVAILABLE_WHEN331; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;セクハラのある日常

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME331
SELECTCASE PREVCOM
	CASE 327
		LOCALS:0 = 膝枕胸愛撫
	CASEELSE
		LOCALS:0 = 胸愛撫
ENDSELECT

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%してもらう
RESULTS:3 = %LOCALS:0%される


;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE331
;共通部分
CALL COM_ABLE_COMMON(331)
SIF RESULT == 0
	RETURN 0
;行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;日常フェラ中は不可
SIF IS_EQUIP(MPLY:0, 330)
	RETURN 0
;主人公以外が実行する場合、実行可能でなければ表示されない
IF MPLY:0 != MASTER
	TCVAR:(MPLY:0):24 = 0
	SKIPDISP 1
	CALL COM_ORDER_PLAYER331(MPLY:0)
	SKIPDISP 0
	SIF TCVAR:(MPLY:0):24 < TCVAR:(MPLY:0):25 
		RETURN 0
ENDIF
;主導権を握っている側に胸愛撫の知識が必要
LOCAL:0 = 0
IF FLAG:主導権所有者 == -1
	CALL CHECK_COM_KNOWLEDGE(MPLY:0, 1)
	LOCAL:0 += RESULT
	CALL CHECK_COM_KNOWLEDGE(MTAR:0, 1)
	LOCAL:0 += RESULT
ELSE
	CALL CHECK_COM_KNOWLEDGE(FLAG:主導権所有者, 1)
	LOCAL:0 += RESULT
ENDIF
IF !RESULT
	RETURN 0
ENDIF
RETURN 1

;-------------------------------------------------
;快Ｂソースの倍率を取得する関数 ARG:0=PLAYERのキャラ番号
;-------------------------------------------------
@COM331_RATE_B(ARG:0)
#FUNCTION
LOCAL:5 = 1000
SELECTCASE ABL:(ARG:0):奉仕
	CASE 0
		TIMES LOCAL:5, 0.50
	CASE 1
		TIMES LOCAL:5, 0.80
	CASE 2
		TIMES LOCAL:5, 1.00
	CASE 3
		TIMES LOCAL:5, 1.20
	CASE 4
		TIMES LOCAL:5, 1.40
	CASEELSE
		LOCAL:5 = LOCAL:5 * (150 + (ABL:(LOCAL:2):奉仕 - 5) * 2) / 100
ENDSELECT

SELECTCASE ABL:(ARG:0):性技
	CASE 0
		TIMES LOCAL:5, 1.00
	CASE 1
		TIMES LOCAL:5, 1.10
	CASE 2
		TIMES LOCAL:5, 1.20
	CASE 3
		TIMES LOCAL:5, 1.30
	CASE 4
		TIMES LOCAL:5, 1.40
	CASEELSE
		LOCAL:5 = LOCAL:5 * ((ABL:(LOCAL:2):性技 - 5) * 2 + 150) / 100
ENDSELECT

RETURNF LOCAL:5

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM331
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 100

EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 200)
SOURCE:(MPLY:0):接触 = 60
SOURCE:(MPLY:0):性行動 = 90

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 100, 40)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲット側の処理
LOCAL:4 = SENSE_HOUSHI(MPLY:0, MTAR:0, 1200)
IF TALENT:(MPLY:0):恋人
	TIMES LOCAL:4, 1.05
ENDIF
SOURCE:(MTAR:0):快Ｂ += LOCAL:4

;●ソースの計算
DOWNBASE:(MTAR:0):体力 += 60
SOURCE:(MTAR:0):接触 = 60
SOURCE:(MTAR:0):性行動 = 180
;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 80, 0)

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = -1

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

;胸愛撫の知識がなければ、獲得する
CALL SET_COM_KNOWLEDGE(MPLY:0, 1)
CALL SET_COM_KNOWLEDGE(MTAR:0, 1)
RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP331
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP331(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

;●プレイヤーの処理
DOWNBASE:(LOCAL:2):体力 += 20
EXP:(MPLY:0):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 60)
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 30

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;●ターゲット側の処理
DOWNBASE:(LOCAL:3):体力 += 10
SOURCE:(LOCAL:3):接触 += 30
SOURCE:(LOCAL:3):性行動 += 60
SOURCE:(LOCAL:3):快Ｂ = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 300 / 3)

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 -= 1

;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)
CALL SUM_SOURCE(LOCAL:3)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE331(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に胸愛撫中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP331(ARG:0)

```
