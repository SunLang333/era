# TRAIN/COMF/COMF333_日常クリ愛撫.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF333_日常クリ愛撫.ERB`

类型: .ERB

自动摘要: functions: COM_NAME333, COM_ABLE333, COM333, COM_IS_EQUIP333, COM_EQUIP333, EQUIP_MESSAGE333, COM_TEXT_BEFORE_EQUIP333, COM_TEXT_RELEASE_EQUIP333, COM_ORDER_PLAYER333, COM_ORDER_TARGET333, COM_TEXT_BEFORE333, COM_TEXT_LAST333, COM_AVAILABLE_WHEN333; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;セクハラのある日常。パンツ履いてる前提になってる

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME333
SELECTCASE PREVCOM
	CASE 327
		LOCALS:0 = 膝枕クリ愛撫
	CASEELSE
		LOCALS:0 = クリ愛撫
ENDSELECT

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%してもらう
RESULTS:3 = %LOCALS:0%される


;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE333
;共通部分
CALL COM_ABLE_COMMON(333)
SIF RESULT == 0
	RETURN 0
;行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;ターゲットに膣が必要
SIF !HAS_VAGINA(MTAR:0)
	RETURN 0
	;フェラ中は不可
SIF IS_EQUIP(MPLY:0, 330)
	RETURN 0
;主人公以外が実行する場合、実行可能でなければ表示されない
IF MPLY:0 != MASTER
	TCVAR:(MPLY:0):24 = 0
	SKIPDISP 1
	CALL COM_ORDER_PLAYER333(MPLY:0)
	SKIPDISP 0
	SIF TCVAR:(MPLY:0):24 < TCVAR:(MPLY:0):25 
		RETURN 0
ENDIF
;主導権を握っている側に指挿入れの知識が必要
LOCAL:0 = 0
IF FLAG:主導権所有者 == -1
	CALL CHECK_COM_KNOWLEDGE(MPLY:0, 3)
	LOCAL:0 += RESULT
	CALL CHECK_COM_KNOWLEDGE(MTAR:0, 3)
	LOCAL:0 += RESULT
ELSE
	CALL CHECK_COM_KNOWLEDGE(FLAG:主導権所有者, 3)
	LOCAL:0 += RESULT
ENDIF
IF !RESULT
	RETURN 0
ENDIF
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM333
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;プレイヤーのフェラを解除
CALL RELEASE_EQUIP(SEARCH_EQUIP(330, MPLY:0, -1), 1, 0)

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 100

EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 200)
SOURCE:(MPLY:0):接触 = 50
SOURCE:(MPLY:0):性行動 = 100

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 100, 40)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲット側の処理
LOCAL:4 = SENSE_HOUSHI(MPLY:0, MTAR:0, 1200)
IF TALENT:(MPLY:0):恋人
	TIMES LOCAL:4, 1.05
ENDIF
SOURCE:(MTAR:0):快Ｃ += LOCAL:4

;●ソースの計算
DOWNBASE:(MTAR:0):体力 += 60
SOURCE:(MTAR:0):接触 = 50
SOURCE:(MTAR:0):性行動 = 180
;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 100, 0)

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 3

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP333
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP333(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

;●プレイヤーの処理
DOWNBASE:(LOCAL:2):体力 += 20
EXP:(MPLY:0):性技経験値 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 100)
SOURCE:(LOCAL:2):接触 += 30
SOURCE:(LOCAL:2):性行動 += 50

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;●ターゲット側の処理
DOWNBASE:(LOCAL:3):体力 += 10
SOURCE:(LOCAL:3):接触 += 30
SOURCE:(LOCAL:3):性行動 += 90
SOURCE:(LOCAL:3):快Ｃ = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 300 / 3)
;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)
CALL SUM_SOURCE(LOCAL:3)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE333(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%のクリ愛撫中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP333(ARG:0)

PRINTFORML  %EQUIP_PLAYER_ANAME(ARG:0)%は%EQUIP_TARGET_ANAME(ARG:0)%のクリトリスを愛撫している…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP333(ARG:0)

;-------------------------------------------------
;固有の実行判定(プレイヤー側)
;-------------------------------------------------
@COM_ORDER_PLAYER333(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 70

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 2, 20))

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
ENDIF

IF TALENT:(ARG:0):貞操観念
	CALL COM_ORDER_ELEMENT(ARG:0, "貞操観念", -6)
ENDIF
```
