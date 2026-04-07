# TRAIN/COMF/COMF57_代わる代わる挿入.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF57_代わる代わる挿入.ERB`

类型: .ERB

自动摘要: functions: COM_NAME57, COM_ABLE57, COM57, COM_EQUIP57, COM_IS_EQUIP57, EQUIP_MESSAGE57, COM_TEXT_BEFORE_EQUIP57, COM_TEXT_RELEASE_EQUIP57, COM_ORDER_PLAYER57, COM_TEXT_BEFORE57, COM_AVAILABLE_WHEN57, COM_PREFERENCE_PLAYER_57, COM_PREFERENCE_TARGET_57, COM_STACK_SPERM_MPLY_TO_MTAR_57; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;代わる代わる挿入する

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME57
LOCALS:0 = 代わる代わる挿入

RESULTS:0 = %LOCALS:0%する
RESULTS:1 = %LOCALS:0%させられる
RESULTS:2 = %LOCALS:0%させる
RESULTS:3 = %LOCALS:0%される
RESULTS:4 = %LOCALS:0%させる
RESULTS:5 = %LOCALS:0%見せつけ

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE57
;共通部分
CALL COM_ABLE_COMMON(57)
SIF RESULT == 0
	RETURN 0
;プレイヤーは2人以上
SIF MPLY_NUM < 2
	RETURN 0
;ターゲットは1人以上
SIF MTAR_NUM < 1
	RETURN 0

FOR LOCAL:0, 0, MTAR_NUM
	SIF !HAS_VAGINA(MTAR:(LOCAL:0))
		RETURN 0
	SIF IS_V_HOLD(MTAR:(LOCAL:0))
		RETURN 0
NEXT

FOR LOCAL:0, 0, MPLY_NUM
	FOR LOCAL:1, 0, MTAR_NUM
		;could be slow for a large number selected
		SIF !CAN_FUCK(MPLY:(LOCAL:0), MTAR:(LOCAL:1), 57)
			RETURN 0
	NEXT
NEXT
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM57
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

;挿入関係を一時リセット

FOR LOCAL:0, 0, MPLY_NUM
	CALL CLEAR_INSERT_FLAG(MPLY:(LOCAL:0), "Ｐ")

	;プレイヤーが行動不能または拘束中なら騎乗位挿入にする
	LOCAL:6 = !IS_PLAYABLE(MPLY:(LOCAL:0)) || IS_BIND(MPLY:(LOCAL:0))

	;●プレイヤー側の処理
	EXP:(MPLY:(LOCAL:0)):性技経験値 += 2
	EXP:(MPLY:(LOCAL:0)):性交経験値 += 3

	LOCAL:5 = 0
	FOR LOCAL:1, 0, MTAR_NUM
		IF LOCAL:6
			SOURCE:(MPLY:(LOCAL:0)):快Ｐ = SENSE_SEX_TARGET_P(MTAR:(LOCAL:1), MPLY:(LOCAL:0), 1500)
		ELSE
			SOURCE:(MPLY:(LOCAL:0)):快Ｐ = SENSE_SEX_PLAYER_P(MTAR:(LOCAL:1), MPLY:(LOCAL:0), 1500)
		ENDIF

		CALL DOUTEI_COMMON(MPLY:(LOCAL:0), @"%ANAME(MTAR:(LOCAL:1))%たちの膣", "乱交")

		;性交系の共通処理
		CALL COM_COMMON_SEX_P(MPLY:(LOCAL:0), MTAR:(LOCAL:1))

		LOCAL:5 += SOURCE:(MPLY:(LOCAL:0)):快Ｐ
		SOURCE:(MPLY:(LOCAL:0)):快Ｐ = 0
	NEXT
	SOURCE:(MPLY:(LOCAL:0)):快Ｐ = LOCAL:5 / MPLY_NUM
	SOURCE:(MPLY:(LOCAL:0)):露出 = 100
	SOURCE:(MPLY:(LOCAL:0)):性行動 = 450

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(MPLY:(LOCAL:0), 200, 100)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(MPLY:(LOCAL:0)):4 = 1

NEXT
;体位フラグのセット
;TCVAR:(MPLY:0):31 = 1
;TCVAR:(MTAR:0):33 = 1

;●ターゲット側の処理
FOR LOCAL:1, 0, MTAR_NUM
	LOCAL:2 = MTAR:(LOCAL:1)
	LOCAL:3 = MPLY:(RAND:MPLY_NUM)

	EXP:(LOCAL:2):性技経験値 += 2
	EXP:(LOCAL:2):性交経験値 += 3
	EXP:(LOCAL:2):輪姦経験 += MPLY_NUM / 2

	IF LOCAL:6
		SOURCE:(LOCAL:2):快Ｖ = SENSE_SEX_PLAYER(LOCAL:2, LOCAL:3, MAX(1200 - MTAR_NUM * 75, 600))
	ELSE
		SOURCE:(LOCAL:2):快Ｖ = SENSE_SEX_TARGET(LOCAL:2, LOCAL:3, MAX(1200 - MTAR_NUM * 75, 600))
	ENDIF
	SOURCE:(LOCAL:2):露出 = 400
	SOURCE:(LOCAL:2):性行動 = 450

	CALL VIRGIN_COMMON(LOCAL:2, @"%ANAME(MPLY:0)%たち", (GET_SITUATION_BY_TRAIN_MODE() == "和姦" ? "乱交" # "輪姦"))

	;性交系の共通処理
	CALL COM_COMMON_SEX_V(LOCAL:2, LOCAL:3)
	CALL TIGHTNESS_DECREASE_V(LOCAL:2, RAND:MAX(MPLY_NUM / 2, 1))
	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:2, 150, 100)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:2):4 = 1
NEXT

;主導度変化基準値
TFLAG:49 = 3

;倒錯度変化基準値
TFLAG:50 = 0

;レズ・ＢＬ経験基準値
TFLAG:51 = 4

RETURN 1

;-------------------------------------------------
;継続状態の処理
;-------------------------------------------------
@COM_EQUIP57(ARG:0)


;挿入関係を一時リセット

FOR LOCAL:0, 0, MEQUIP_PLAYER_NUM:(ARG:0)
	LOCAL:1 = MEQUIP_PLAYER:(ARG:0):(LOCAL:0)
	DOWNBASE:(LOCAL:1):体力 += 50

	;プレイヤーが行動不能または拘束中なら騎乗位挿入にする
	LOCAL:6 = !IS_PLAYABLE(LOCAL:1) || IS_BIND(LOCAL:1)

	;●プレイヤー側の処理
	EXP:(LOCAL:1):性技経験値 += 2
	EXP:(LOCAL:1):性交経験値 += 2

	LOCAL:5 = 0
	FOR LOCAL:2, 0, MEQUIP_TARGET_NUM:(ARG:0)
		LOCAL:3 = MEQUIP_TARGET:(ARG:0):(LOCAL:2)
		IF LOCAL:6
			SOURCE:(LOCAL:1):快Ｐ = SENSE_SEX_TARGET_P(LOCAL:3, LOCAL:1, 750)
		ELSE
			SOURCE:(LOCAL:1):快Ｐ = SENSE_SEX_PLAYER_P(LOCAL:3, LOCAL:1, 750)
		ENDIF
		;性交系の共通処理
		CALL COM_COMMON_SEX_P(LOCAL:1, LOCAL:3)

		LOCAL:5 += SOURCE:(LOCAL:1):快Ｐ
		SOURCE:(LOCAL:1):快Ｐ = 0
	NEXT
	SOURCE:(LOCAL:1):快Ｐ = LOCAL:5 / MEQUIP_PLAYER_NUM:(ARG:0)
	SOURCE:(LOCAL:1):露出 += 100
	SOURCE:(LOCAL:1):性行動 += 450

	;主導権に応じた優越・屈従のソース追加
	CALL ADD_SOURCE_INITIATIVE_U(LOCAL:1, 200, 100)

	;奉仕経験値を得られるコマンドのフラグ
	TCVAR:(LOCAL:1):4 = 1

NEXT
;体位フラグのセット
;TCVAR:(MPLY:0):31 = 1
;TCVAR:(MTAR:0):33 = 1

;●ターゲット側の処理
FOR LOCAL:1, 0,  MEQUIP_TARGET_NUM:(ARG:0)
	LOCAL:2 =  MEQUIP_TARGET:(ARG:0):(LOCAL:1)
	LOCAL:3 = MEQUIP_PLAYER:(ARG:0):(RAND:(MEQUIP_PLAYER_NUM:(ARG:0)))

	EXP:(LOCAL:2):性技経験値 += 2
	EXP:(LOCAL:2):性交経験値 += 2
	EXP:(LOCAL:2):輪姦経験 += MEQUIP_PLAYER_NUM:(ARG:0) / 2

	IF LOCAL:6
		SOURCE:(LOCAL:2):快Ｖ += SENSE_SEX_PLAYER(LOCAL:2, LOCAL:3, MAX(1200 - MTAR_NUM * 75, 600))
	ELSE
		SOURCE:(LOCAL:2):快Ｖ += SENSE_SEX_TARGET(LOCAL:2, LOCAL:3, MAX(1200 - MTAR_NUM * 75, 600))
	ENDIF
```
