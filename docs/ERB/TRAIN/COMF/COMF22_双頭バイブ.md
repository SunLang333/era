# TRAIN/COMF/COMF22_双頭バイブ.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF22_双頭バイブ.ERB`

类型: .ERB

自动摘要: functions: COM_NAME22, COM_ABLE22, COM22, COM_IS_EQUIP22, COM_EQUIP22, EQUIP_MESSAGE22, COM_TEXT_BEFORE_EQUIP22, COM_TEXT_RELEASE_EQUIP22, COM_ORDER_PLAYER22, COM_ORDER_TARGET22, COM_ORDER_COMMON22, COM_TEXT_BEFORE22, COM_AVAILABLE_WHEN22, COM_PREFERENCE_PLAYER_22, COM_PREFERENCE_TARGET_22; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;双頭バイブ

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME22
LOCALS:0 = 双頭バイブ

RESULTS:0 = %LOCALS:0%を使う
RESULTS:1 = %LOCALS:0%を使わされる
RESULTS:2 = %LOCALS:0%を使わせる
RESULTS:3 = %LOCALS:0%を使われる
RESULTS:4 = %LOCALS:0%を使わせる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE22
;共通部分
CALL COM_ABLE_COMMON(22)
SIF RESULT == 0
	RETURN 0
;プレイヤーは最大で1人まで
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
;ターゲットは最大で1人まで
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
;プレイヤーとターゲットが共に行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0
;双頭バイブが必要
SIF !ITEM:双頭バイブ && !ITEM:A_双頭バイブ
	RETURN 0
SIF !HAS_VAGINA(MPLY:0) || !HAS_VAGINA(MTAR:0)
	RETURN 0
SIF IS_RIDE(MPLY:0) || IS_RIDE(MTAR:0)
	RETURN 0
;prostrate
SIF IS_EQUIP_PLAYER(MPLY:0, 110) || IS_EQUIP_PLAYER(MTAR:0, 110)
	RETURN 0
;プレイヤーとターゲットが共に拘束中なら不可
SIF IS_BIND(MPLY:0) && IS_BIND(MTAR:0)
	RETURN 0
SIF IS_V_HOLD(MPLY:0) || IS_V_HOLD(MTAR:0)
	RETURN 0
;either is fucking or fucked by anyone
SIF IS_INSERT_SINGLE(MPLY:0, "全") || IS_INSERT_SINGLE(MTAR:0, "全")
	RETURN 0
SIF REACHING_BODY(MPLY, MTAR) || REACHING_BODY(MTAR, MPLY)
	RETURN 0
SIF LICKING_GROIN(MPLY, MTAR) || LICKING_GROIN(MTAR, MPLY)
	RETURN 0
SIF LICKING_BODY(MPLY, MTAR) || LICKING_BODY(MTAR, MPLY)
	RETURN 0
;giving/receiving assjob, trampling, footjob
SIF SEARCH_EQUIP_IC_M(MPLY:0, MTAR:0, 14, 15, 103) >= 0
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM22
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0


;●プレイヤーについて処理
DOWNBASE:(MPLY:0):体力 += 140

EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):性交経験値 += 2

SOURCE:(MPLY:0):快Ｖ = SENSE_SEX_TARGET(MTAR:0, MPLY:0, 1400)
SOURCE:(MPLY:0):接触 = 100
SOURCE:(MPLY:0):性行動 = 360

;性交系の共通処理
CALL COM_COMMON_SEX_V(MPLY:0, MTAR:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 50, 50)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1


;●ターゲットについて処理
DOWNBASE:(MTAR:0):体力 += 140

EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):性交経験値 += 2

SOURCE:(MTAR:0):快Ｖ = SENSE_SEX_TARGET(MPLY:0, MTAR:0, 1400)
SOURCE:(MTAR:0):接触 = 80
SOURCE:(MTAR:0):性行動 = 360

;性交系の共通処理
CALL COM_COMMON_SEX_V(MTAR:0, MPLY:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 50, 50)

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
@COM_IS_EQUIP22
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP22(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):性交経験値 += 1

SOURCE:(LOCAL:2):快Ｖ += SENSE_SEX_TARGET(LOCAL:3, LOCAL:2, 700)
SOURCE:(LOCAL:2):露出 += 100
SOURCE:(LOCAL:2):性行動 += 120

;性交系の共通処理
CALL COM_COMMON_SEX_V(LOCAL:2, LOCAL:3)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 -= 1

DOWNBASE:(LOCAL:3):体力 += 20

EXP:(LOCAL:3):性技経験値 += 1
EXP:(LOCAL:3):性交経験値 += 1

SOURCE:(LOCAL:3):快Ｖ += SENSE_SEX_TARGET(LOCAL:2, LOCAL:3, 700)
SOURCE:(LOCAL:3):露出 += 100
SOURCE:(LOCAL:3):性行動 += 120

;性交系の共通処理
CALL COM_COMMON_SEX_V(LOCAL:3, LOCAL:2)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:3):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:3):50 -= 1

;退避したソースを加算
CALL SUM_SOURCE(LOCAL:2)
CALL SUM_SOURCE(LOCAL:3)

;-------------------------------------------------
;継続中の表示
;-------------------------------------------------
@EQUIP_MESSAGE22(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%と%EQUIP_TARGET_ANAME(ARG:0)%が双頭バイブで結合中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP22(ARG:0)
PRINTFORML %EQUIP_TARGET_ANAME(ARG:0)%と%EQUIP_PLAYER_ANAME(ARG:0)%は双頭バイブで繋がったまま腰を動かしている…

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP22(ARG:0)
PRINTFORMW %EQUIP_PLAYER_ANAME(ARG:0)%と%EQUIP_TARGET_ANAME(ARG:0)%は双頭バイブを引き抜いた…

;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER22(ARG:0)
```
