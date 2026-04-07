# TRAIN/COMF/COMF24_指フェラ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF24_指フェラ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME24, COM_ABLE24, COM24_RATE_M, COM24, COM_IS_EQUIP24, COM_EQUIP24, EQUIP_MESSAGE24, COM_TEXT_BEFORE_EQUIP24, COM_TEXT_RELEASE_EQUIP24, COM_ORDER_PLAYER24, COM_TEXT_BEFORE24, COM_TEXT_LAST24, COM_AVAILABLE_WHEN24, COM_PREFERENCE_PLAYER_24, COM_PREFERENCE_TARGET_24; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;フェラチオ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME24
;挿入中

LOCALS:0 = 指フェラ

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE24
;共通部分
CALL COM_ABLE_COMMON(24)
SIF RESULT == 0
	RETURN 0
;1-1限定
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0

FOR LOCAL:0, 0, MPLY_NUM
	;気絶してたらダメ
	SIF !IS_PLAYABLE(MPLY:(LOCAL:0))
		RETURN 0
	;ターゲットの口が塞がっているなら不可
	SIF IS_M_HOLD(MPLY:(LOCAL:0))
		RETURN 0
NEXT

;both bound
SIF IS_BIND(MPLY:0) && IS_BIND(MTAR:0)
	RETURN 0

RETURN 1

;-------------------------------------------------
;快Ｍソースの倍率を取得する関数 ARG:0=PLAYERのキャラ番号
;-------------------------------------------------
@COM24_RATE_M(ARG:0)
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
@COM24
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●全プレイヤーについて判定
DOWNBASE:(MPLY:0):体力 += 80

EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):口淫経験 += 1

SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 300)
SOURCE:(MPLY:0):接触 = 50
SOURCE:(MPLY:0):快Ｍ = 400 * COM24_RATE_M(MPLY:0) / 1000
SOURCE:(MPLY:0):性行動 = 200

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 100, 100)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●全ターゲットについて判定

;●ソースの計算
DOWNBASE:(MTAR:0):体力 += 20

SOURCE:(MTAR:0):接触 = 30
SOURCE:(MTAR:0):性行動 = 120

;主導権に応じた優越・受動のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 150, 70)

;主導度変化基準値
TFLAG:49 = 1

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 5

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP24
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP24(ARG:0)


;●全プレイヤーについて判定
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0

DOWNBASE:(LOCAL:2):体力 += 15

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):口淫経験 += 1

SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 150)
SOURCE:(LOCAL:2):接触 += 15
SOURCE:(LOCAL:2):快Ｍ += 200 * COM24_RATE_M(LOCAL:2) / 1000
SOURCE:(LOCAL:2):性行動 += 70

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

LOCAL:1 = MEQUIP_TARGET:(ARG:0):(LOCAL:0)

DOWNBASE:(LOCAL:1):体力 += 10

SOURCE:(LOCAL:1):接触 += 15
SOURCE:(LOCAL:1):性行動 += 30


;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE24(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%に指フェラ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP24(ARG:0)

PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の指を口で咥え込んで舐め回している…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP24(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER24(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 85

```
