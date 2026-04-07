# TRAIN/COMF/COMF332_日常手コキ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF332_日常手コキ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME332, COM_ABLE332, COM332, COM_IS_EQUIP332, COM_EQUIP332, EQUIP_MESSAGE332, COM_TEXT_BEFORE_EQUIP332, COM_TEXT_RELEASE_EQUIP332, COM_ORDER_PLAYER332, COM_ORDER_TARGET332, COM_TEXT_BEFORE332, COM_TEXT_LAST332, COM_AVAILABLE_WHEN332, COM_STACK_SPERM_MTAR_TO_MPLY_332; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;セクハラのある日常

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME332
SELECTCASE PREVCOM
	CASE 327
		LOCALS:0 = 膝枕手コキ
	CASEELSE
		LOCALS:0 = 手コキ
ENDSELECT

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%してもらう
RESULTS:3 = %LOCALS:0%される


;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE332
;共通部分
CALL COM_ABLE_COMMON(332)
SIF RESULT == 0
	RETURN 0
;行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;ターゲットに竿が必要
SIF !HAS_PENIS(MTAR:0)
	RETURN 0
;主人公以外が実行する場合、実行可能でなければ表示されない
IF MPLY:0 != MASTER
	TCVAR:(MPLY:0):24 = 0
	SKIPDISP 1
	CALL COM_ORDER_PLAYER332(MPLY:0)
	SKIPDISP 0
	SIF TCVAR:(MPLY:0):24 < TCVAR:(MPLY:0):25 
		RETURN 0
ENDIF
;主導権を握っている側に手コキの知識が必要
LOCAL:0 = 0
IF FLAG:主導権所有者 == -1
	CALL CHECK_COM_KNOWLEDGE(MPLY:0, 10)
	LOCAL:0 += RESULT
	CALL CHECK_COM_KNOWLEDGE(MTAR:0, 10)
	LOCAL:0 += RESULT
ELSE
	CALL CHECK_COM_KNOWLEDGE(FLAG:主導権所有者, 10)
	LOCAL:0 += RESULT
ENDIF
IF !RESULT
	RETURN 0
ENDIF
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM332
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 100

EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 300)
SOURCE:(MPLY:0):接触 = 100
SOURCE:(MPLY:0):性行動 = 210

SELECTCASE ABL:(MPLY:0):奉仕
	CASE 0
		TIMES SOURCE:(MPLY:0):不潔, 4.00
	CASE 1
		TIMES SOURCE:(MPLY:0):不潔, 2.50
	CASE 2
		TIMES SOURCE:(MPLY:0):不潔, 1.50
	CASE 3
		TIMES SOURCE:(MPLY:0):不潔, 1.00
	CASE 4
		TIMES SOURCE:(MPLY:0):不潔, 0.50
	CASEELSE
		TIMES SOURCE:(MPLY:0):不潔, 0.10
ENDSELECT

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 80)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲット側の処理
LOCAL:4 = SENSE_HOUSHI_P(MPLY:0, MTAR:0, 1200)
IF TALENT:(MPLY:0):恋人
	TIMES LOCAL:4, 1.05
ENDIF
SOURCE:(MTAR:0):快Ｐ += LOCAL:4

;●ソースの計算
DOWNBASE:(MTAR:0):体力 += 60
SOURCE:(MTAR:0):接触 = 50
SOURCE:(MTAR:0):性行動 = 180
;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 120, 50)

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

;胸愛撫の知識がなければ、獲得する
CALL SET_COM_KNOWLEDGE(MPLY:0, 10)
CALL SET_COM_KNOWLEDGE(MTAR:0, 10)
RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP332
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP332(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

;●プレイヤーの処理
DOWNBASE:(LOCAL:2):体力 += 20
EXP:(MPLY:0):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
SOURCE:(LOCAL:2):接触 += 50
SOURCE:(LOCAL:2):性行動 += 70

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;●ターゲット側の処理
DOWNBASE:(LOCAL:3):体力 += 10
SOURCE:(LOCAL:3):接触 += 25
SOURCE:(LOCAL:3):性行動 += 60
SOURCE:(LOCAL:3):快Ｐ = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 800) * 30 / 100


;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)
CALL SUM_SOURCE(LOCAL:3)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE332(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に手コキ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP332(ARG:0)

PRINTFORML  %EQUIP_PLAYER_ANAME(ARG:0)%は%EQUIP_TARGET_ANAME(ARG:0)%のペニスを手で握りシゴき上げている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP332(ARG:0)

;-------------------------------------------------
;固有の実行判定(プレイヤー側)
;-------------------------------------------------
@COM_ORDER_PLAYER332(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 70

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)
CALL COM_ORDER_ELEMENT(ARG:0, @"精愛Lv{ABL:(ARG:0):精愛}", ABL:(ARG:0):精愛 * 1)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 2, 20))

;ムード
```
