# TRAIN/COMF/COMF330_日常フェラ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF330_日常フェラ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME330, COM_ABLE330, COM330_RATE_M, COM330, COM_IS_EQUIP330, COM_ORDER_PLAYER330, COM_ORDER_TARGET330, COM_TEXT_BEFORE330, COM_TEXT_LAST330, COM_AVAILABLE_WHEN330, COM_STACK_SPERM_MTAR_TO_MPLY_330; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;フェラチオのある日常

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME330
SELECTCASE PREVCOM
	CASE 303, 304, 351
		LOCALS:0 = 机下フェラ
	CASEELSE
		LOCALS:0 = フェラ
ENDSELECT

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%してもらう
RESULTS:3 = %LOCALS:0%される


;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE330
;共通部分
CALL COM_ABLE_COMMON(330)
SIF RESULT == 0
	RETURN 0
;ターゲットに竿が必要
SIF !HAS_PENIS(MTAR:0)
	RETURN 0
;行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;キス中は不可
SIF IS_EQUIP(MPLY:0, 342)
	RETURN 0
;主人公以外が実行する場合、実行可能でなければ表示されない
IF MPLY:0 != MASTER
	TCVAR:(MPLY:0):24 = 0
	SKIPDISP 1
	CALL COM_ORDER_PLAYER330(MPLY:0)
	SKIPDISP 0
	SIF TCVAR:(MPLY:0):24 < TCVAR:(MPLY:0):25 
		RETURN 0
ENDIF
;主導権を握っている側にフェラの知識が必要
LOCAL:0 = 0
IF FLAG:主導権所有者 == -1
	CALL CHECK_COM_KNOWLEDGE(MPLY:0, 11)
	LOCAL:0 += RESULT
	CALL CHECK_COM_KNOWLEDGE(MTAR:0, 11)
	LOCAL:0 += RESULT
ELSE
	CALL CHECK_COM_KNOWLEDGE(FLAG:主導権所有者, 11)
	LOCAL:0 += RESULT
ENDIF
IF !RESULT
	RETURN 0
ENDIF
RETURN 1

;-------------------------------------------------
;快Ｍソースの倍率を取得する関数 ARG:0=PLAYERのキャラ番号
;-------------------------------------------------
@COM330_RATE_M(ARG:0)
#FUNCTION
LOCAL:5 = 1000
SELECTCASE ABL:(ARG:0):奉仕
	CASE 0
		TIMES LOCAL:5, 0.00
		;TIMES SOURCE:(LOCAL:2):不潔, 4.00
	CASE 1
		TIMES LOCAL:5, 0.10
		;TIMES SOURCE:(LOCAL:2):不潔, 2.50
	CASE 2
		TIMES LOCAL:5, 0.30
		;TIMES SOURCE:(LOCAL:2):不潔, 1.50
	CASE 3
		TIMES LOCAL:5, 0.80
		;TIMES SOURCE:(LOCAL:2):不潔, 1.00
	CASE 4
		TIMES LOCAL:5, 1.00
		;TIMES SOURCE:(LOCAL:2):不潔, 0.50
	CASEELSE
		LOCAL:5 = LOCAL:5 * (100 + (ABL:(ARG:0):奉仕 - 5) * 3) / 100
		;TIMES SOURCE:(LOCAL:2):不潔, 0.10
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
		LOCAL:5 = LOCAL:5 * ((ABL:(ARG:0):性技 - 5) * 2 + 150) / 100
ENDSELECT

RETURNF LOCAL:5

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM330
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 120

EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):口淫経験 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 400)
SOURCE:(MPLY:0):接触 = 50
SOURCE:(MPLY:0):快Ｍ = 300 * COM330_RATE_M(MPLY:0) / 1000
;SOURCE:(MPLY:0):快Ｍ = 300 * COM11_RATE_M(MPLY:0) / 1000
SOURCE:(MPLY:0):性行動 = 300

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 120)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

IF HAS_PENIS(MTAR:0)
	;ペニスへのキス
	CALL KISS_COMMON(MPLY:0, @"%ANAME(MTAR:0)%のペニス", GET_SITUATION_BY_TRAIN_MODE())
ENDIF

;●ターゲット側の処理
LOCAL:4 = SENSE_HOUSHI_P(MPLY:0, MTAR:0, 1500)
IF TALENT:(MPLY:0):舌使い
	TIMES LOCAL:4, 1.50
ENDIF
SOURCE:(MTAR:0):快Ｐ += LOCAL:4


;●ソースの計算
DOWNBASE:(MTAR:0):体力 += 60
SOURCE:(MTAR:0):接触 = 50
SOURCE:(MTAR:0):性行動 = 180
;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 150, 70)

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 2

;レズ・ＢＬ経験基準値
TFLAG:51 = 7

;フェラの知識がなければ、獲得する
CALL SET_COM_KNOWLEDGE(MPLY:0, 11)
CALL SET_COM_KNOWLEDGE(MTAR:0, 11)
RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP330
RETURN 0

;-------------------------------------------------
;固有の実行判定(プレイヤー側)
;-------------------------------------------------
@COM_ORDER_PLAYER330(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 90

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)
CALL COM_ORDER_ELEMENT(ARG:0, @"精愛Lv{ABL:(ARG:0):精愛}", ABL:(ARG:0):精愛 * 3)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

;ムード
IF TFLAG:37 < 10
	LOCAL:0 = -10
ELSEIF TFLAG:37 < 30
	LOCAL:0 = -5
ELSEIF TFLAG:37 < 50
	LOCAL:0 = 0
ELSEIF TFLAG:37 < 100
	LOCAL:0 = (TFLAG:37 - 50) / 10
ELSE
	LOCAL:0 = MIN(10, (TFLAG:37 - 100) / 50 + 5)
```
