# TRAIN/COMF/COMF23_兜合わせ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF23_兜合わせ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME23, COM_ABLE23, COM23, COM_IS_EQUIP23, COM_EQUIP23, EQUIP_MESSAGE23, COM_TEXT_BEFORE_EQUIP23, COM_TEXT_RELEASE_EQUIP23, COM_ORDER_PLAYER23, COM_ORDER_TARGET23, COM_ORDER_COMMON23, COM_TEXT_BEFORE23, COM_AVAILABLE_WHEN23, COM_PREFERENCE_PLAYER_23, COM_PREFERENCE_TARGET_23, COM_STACK_SPERM_MPLY_TO_MTAR_23, COM_STACK_SPERM_MTAR_TO_MPLY_23; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;貝合わせ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME23
LOCALS:0 = 兜合わせ

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE23
;共通部分
CALL COM_ABLE_COMMON(23)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
SIF !HAS_PENIS(MPLY:0) || !HAS_PENIS(MTAR:0)
	RETURN 0
SIF IS_RIDE(MPLY:0) || IS_RIDE(MTAR:0)
	RETURN 0
;grovelling
SIF IS_EQUIP_PLAYER(MPLY:0, 110) || IS_EQUIP_PLAYER(MTAR:0, 110)
	RETURN 0
;プレイヤーとターゲットが共に拘束中なら不可
SIF IS_BIND(MPLY:0) && IS_BIND(MTAR:0)
	RETURN 0
SIF !P_STACKABLE(MPLY, MTAR, 23) || !P_STACKABLE(MTAR, MPLY, 23)
	RETURN 0
;fucking or being fucked by anyone
SIF IS_INSERT_SINGLE(MPLY:0, "全") || IS_INSERT_SINGLE(MTAR:0, "全")
	RETURN 0
SIF LICKING_GROIN(MPLY, MTAR) || LICKING_GROIN(MTAR, MPLY)
	RETURN 0
;giving or receiving foot licking from target
SIF SEARCH_EQUIP_IC(104, MPLY:0, MTAR:0) >= 0
	RETURN 0

RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM23
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;逆方向からのMEQUIPを解除
;FOR LOCAL:0, 0, MPLY_NUM
;	FOR LOCAL:1, 0, MTAR_NUM
;		CALL RELEASE_EQUIP_EX(23, MTAR:(LOCAL:1), MPLY:(LOCAL:0))
;	NEXT
;NEXT

;●射精による各種倍率の計算

;●プレイヤーについて処理
DOWNBASE:(MPLY:0):体力 += 120

EXP:(MPLY:0):性技経験値 += 1

SOURCE:(MPLY:0):快Ｐ = SENSE_HOUSHI(MTAR:0, MPLY:0, 1600) * 30 / 100
SOURCE:(MPLY:0):奉仕 = SERVE_HOUSHI(MPLY:0, 100)
SOURCE:(MPLY:0):接触 = 120
SOURCE:(MPLY:0):性行動 = 300

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 40, 40)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲットについて処理
DOWNBASE:(MTAR:0):体力 += 120

EXP:(MTAR:0):性技経験値 += 1

SOURCE:(MTAR:0):快Ｐ = SENSE_HOUSHI(MPLY:0, MTAR:0, 1600) * 30 / 100
SOURCE:(MTAR:0):奉仕 = SERVE_HOUSHI(MTAR:0, 100)
SOURCE:(MTAR:0):接触 = 120
SOURCE:(MTAR:0):性行動 = 300

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 40, 40)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 7

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP23
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP23(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;●プレイヤーについて処理
DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1

SOURCE:(LOCAL:2):快Ｐ += SENSE_HOUSHI(LOCAL:3, LOCAL:2, 800) * 30 / 100
SOURCE:(LOCAL:2):奉仕 += SERVE_HOUSHI(LOCAL:2, 50)
SOURCE:(LOCAL:2):接触 += 60
SOURCE:(LOCAL:2):性行動 += 100

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;●ターゲットについて処理
DOWNBASE:(LOCAL:3):体力 += 20

EXP:(LOCAL:3):性技経験値 += 1

SOURCE:(LOCAL:3):快Ｐ = SENSE_HOUSHI(LOCAL:2, LOCAL:3, 800) * 30 / 100
SOURCE:(LOCAL:3):奉仕 = SERVE_HOUSHI(LOCAL:3, 50)
SOURCE:(LOCAL:3):接触 = 60
SOURCE:(LOCAL:3):性行動 += 100

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:3):4 = 1
;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE23(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%と%EQUIP_TARGET_ANAME(ARG:0)%が兜合わせ中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP23(ARG:0)
PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%と%EQUIP_TARGET_ANAME(ARG:0)%は%BAR_NAME(MEQUIP_PLAYER:(ARG:0):0)%を擦り合わせている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP23(ARG:0)

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER23(ARG:0)
CALL COM_ORDER_COMMON23(ARG:0)
RETURN 1

@COM_ORDER_TARGET23(ARG:0)
CALL COM_ORDER_COMMON23(ARG:0)
RETURN 1

@COM_ORDER_COMMON23(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 90

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 3)
CALL COM_ORDER_ELEMENT(ARG:0, @"Ｃ感Lv{ABL:(ARG:0):Ｃ感}", ABL:(ARG:0):Ｃ感 * 2)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"射精Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):射精 * 3)


LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 3, 30))

IF TCVAR:(ARG:0):60
	CALL COM_ORDER_ELEMENT(ARG:0, "媚薬", 6)
ENDIF
```
