# TRAIN/COMF/COMF172_尿道挿入.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF172_尿道挿入.ERB`

类型: .ERB

自动摘要: functions: COM_NAME172, COM_ABLE172, COM172, COM_IS_EQUIP172, COM_EQUIP172, EQUIP_MESSAGE172, COM_TEXT_BEFORE_EQUIP172, COM_TEXT_RELEASE_EQUIP172, COM_ORDER_PLAYER172, COM_TEXT_BEFORE172, COM_TEXT_LAST172, COM_AVAILABLE_WHEN172, COM_PREFERENCE_PLAYER_172, COM_PREFERENCE_TARGET_172, COM_STACK_SPERM_MPLY_TO_MTAR_172; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;正常位

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME172

LOCALS:0 = 尿道挿入
RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE172
CALL COM_ABLE_COMMON(172)
SIF RESULT == 0
	RETURN 0
SIF MPLY_NUM <= 0 || MPLY_NUM > 1
	RETURN 0
SIF MTAR_NUM <= 0 || MTAR_NUM > 1
	RETURN 0
SIF !HAS_VAGINA(MTAR:0)
	RETURN 0
SIF IS_U_HOLD(MTAR:0)
	RETURN 0
SIF EXP:(MTAR:0):Ｕ開発経験 < 50
	RETURN 0

;Target is getting assfucked, unless it's sitting backwards or reverse cowgirl
SIF IS_INSERT_SINGLE(MTAR:0, "Ａ") && !GROUPMATCH(GET_SEX_POSITION_SINGLE(MTAR:0, "Ａ"), 4, 6)
	RETURN 0
SIF !CAN_FUCK(MPLY:0, MTAR:0, 172)
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM172
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;挿入関係を一時リセット
CALL CLEAR_INSERT_FLAG(MPLY:0, "Ｐ")

;●プレイヤー側の処理
DOWNBASE:(MPLY:0):体力 += 160

EXP:(MPLY:0):性技経験値 += 1
EXP:(MPLY:0):性交経験値 += 2

SOURCE:(MPLY:0):快Ｐ = SENSE_SEX_PLAYER_P(MTAR:0, MPLY:0, 1500)
SOURCE:(MPLY:0):露出 = 100
SOURCE:(MPLY:0):性行動 = 450

;性交系の共通処理
CALL COM_COMMON_USEX_P(MPLY:0, MTAR:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MPLY:0, 150, 80)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MPLY:0):4 = 1

;●ターゲット側の処理
DOWNBASE:(MTAR:0):体力 += 120

EXP:(MTAR:0):性技経験値 += 1
EXP:(MTAR:0):性交経験値 += 2
SOURCE:(MTAR:0):快Ｕ = SENSE_SEX_TARGET(MPLY:0, MTAR:0, 1500)
SOURCE:(MTAR:0):露出 = 200
SOURCE:(MTAR:0):性行動 = 450

;性交系の共通処理
CALL COM_COMMON_USEX_U(MTAR:0, MPLY:0)

;主導権に応じた優越・屈従のソース追加
CALL ADD_SOURCE_INITIATIVE_U(MTAR:0, 150, 100)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(MTAR:0):4 = 1

;体位フラグのセット
TCVAR:(MPLY:0):31 = 1
TCVAR:(MTAR:0):33 = 1

;主導度変化基準値
TFLAG:49 = 2

;倒錯度変化基準値
TFLAG:50 = -1

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続コマンドかどうかを設定
;-------------------------------------------------
@COM_IS_EQUIP172
RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP172(ARG:0)
LOCAL:2 = MEQUIP_PLAYER:(ARG:0):0
LOCAL:3 = MEQUIP_TARGET:(ARG:0):0

;ソースを退避
CALL PUTOUT_SOURCE(LOCAL:2)
CALL PUTOUT_SOURCE(LOCAL:3)

DOWNBASE:(LOCAL:2):体力 += 20

EXP:(LOCAL:2):性技経験値 += 1
EXP:(LOCAL:2):性交経験値 += 1

SOURCE:(LOCAL:2):快Ｐ += SENSE_SEX_PLAYER_P(LOCAL:3, LOCAL:2, 750)
SOURCE:(LOCAL:2):露出 += 50
SOURCE:(LOCAL:2):性行動 += 150

;性交系の共通処理
CALL COM_COMMON_SEX_P(LOCAL:2, LOCAL:3)

;奉仕経験値を得られるコマンドのフラグ
TCVAR:(LOCAL:2):4 = 1

;倒錯度変化基準値
TCVAR:(LOCAL:2):50 -= 1

DOWNBASE:(LOCAL:3):体力 += 20

EXP:(LOCAL:3):性技経験値 += 1
EXP:(LOCAL:3):性交経験値 += 1

SOURCE:(LOCAL:3):快Ｕ += SENSE_SEX_TARGET(LOCAL:2, LOCAL:3, 750)
SOURCE:(LOCAL:3):露出 += 100
SOURCE:(LOCAL:3):性行動 += 150

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
@EQUIP_MESSAGE172(ARG:0)
RESULTS = %EQUIP_PLAYER_ANAME(ARG:0)%が%EQUIP_TARGET_ANAME(ARG:0)%の尿道に挿入中

;-------------------------------------------------
;継続中の地の文(前文)
;-------------------------------------------------
@COM_TEXT_BEFORE_EQUIP172(ARG:0)
SELECTCASE RAND:2
	CASE 0
		PRINTFORML %EQUIP_TARGET_ANAME(ARG:0)%の尿道が%EQUIP_PLAYER_ANAME(ARG:0)%の%BAR_NAME(MEQUIP_PLAYER:(ARG:0):0)%を咥え込んでいる…
	CASE 1
		LOCAL:0 = MEQUIP_TARGET:(ARG:0):0
			;ターゲットが行動不能
		IF !IS_PLAYABLE(LOCAL:0)
			PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%はぐったりとしている%EQUIP_TARGET_ANAME(ARG:0)%の尿道に挿入したまま、さらに激しく腰を動かしている…
		ELSE
			SELECTCASE GET_COM_INITIATIVE()
					;プレイヤーに主導権
				CASE 0
					PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%は%EQUIP_TARGET_ANAME(ARG:0)%の尿道に挿入したまま、さらに激しく腰を動かしている…
					;ターゲットに主導権
				CASE 1
					PRINTFORML %EQUIP_TARGET_ANAME(ARG:0)%は%EQUIP_PLAYER_ANAME(ARG:0)%の腰に足を絡めながら、さらに激しく腰を動かすように要求し
					PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%は%EQUIP_TARGET_ANAME(ARG:0)%に求められるまま、何度も尿道を穿っている…
					;第三者に主導権
				CASEELSE
					PRINTFORML %ANAME(TFLAG:45)%は%EQUIP_TARGET_ANAME(ARG:0)%の尿道に挿入している%EQUIP_PLAYER_ANAME(ARG:0)%に対し、もっと激しく腰を動かすように命令し
					PRINTFORML %EQUIP_PLAYER_ANAME(ARG:0)%は言われるがまま、激しく何度も%EQUIP_TARGET_ANAME(ARG:0)%の尿道を穿っている…
			ENDSELECT
		ENDIF
ENDSELECT

;-------------------------------------------------
;継続を解除したときの地の文
;-------------------------------------------------
@COM_TEXT_RELEASE_EQUIP172(ARG:0)
```
