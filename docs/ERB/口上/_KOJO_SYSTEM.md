# 口上/_KOJO_SYSTEM.ERB — 自动生成文档

源文件: `ERB/口上/_KOJO_SYSTEM.ERB`

类型: .ERB

自动摘要: functions: KOJO_NO, KOJO_STATE, IS_KOJO, EVENTTRAIN, EVENTEND, KOJO_COM_BEFORE, KOJO_COM, KOJO_COM_AFTER, KOJO_EVENT, KOJO_SINGLE_ENDING, KOJO_DEAD_ENDING, SET_COM_FIRST_FLAG, IS_COM_FIRST, KOJO_DATE_EVENT, CHECK_KOJO_DAILY_HAPPEN

前 200 行源码片段:

```text
﻿;口上に関する処理

;--------------------------------------------------
;キャラARG:0の口上ナンバーを返す
;東方キャラ……NOがそのまま返る
;汎用キャラ……口上パターン番号が返る
;--------------------------------------------------
@KOJO_NO(ARG:0)
#FUNCTION
IF IS_TOHO_CHARA(ARG:0) || IS_SP_CHARA(ARG:0)
	RETURNF NO:(ARG:0)
ENDIF
IF CFLAG:(ARG:0):汎用口上パターン >= 1000 && CFLAG:(ARG:0):汎用口上パターン <= 1999
	RETURNF CFLAG:(ARG:0):汎用口上パターン
ENDIF
RETURNF 999

;--------------------------------------------------
;状況に応じた付加文字列を返す
;ARG:0に1を設定すると、分岐が細かくなる
;--------------------------------------------------
@KOJO_STATE(ARG:0 = 0)
#FUNCTIONS
IF ARG:0
	;会いに行く
	IF FLAG:調教モード == 0
		RETURNF "A1"
	;閨に呼ぶ
	ELSEIF FLAG:調教モード == 1
		RETURNF "A2"
	;子育て
	ELSEIF FLAG:調教モード == 3
		RETURNF "A3"
	;捕虜会話
	ELSEIF FLAG:調教モード == 6
		RETURNF "A4"
	;捕虜の調教
	ELSEIF FLAG:調教モード == 2
		RETURNF "B"
	;捕虜逆調教(通常)
	ELSEIF FLAG:調教モード == 5
		RETURNF "C"
	;捕虜逆調教(外来)
	ELSEIF FLAG:調教モード == 4
		RETURNF "D"
	ENDIF
ELSE
	;会いに行く・閨に呼ぶ・子育て・捕虜会話
	IF GROUPMATCH(FLAG:調教モード, 0, 1, 3, 6)
		RETURNF "A"
	;捕虜の調教
	ELSEIF FLAG:調教モード == 2
		RETURNF "B"
	;捕虜逆調教(通常)
	ELSEIF FLAG:調教モード == 5
		RETURNF "C"
	;捕虜逆調教(外来)
	ELSEIF FLAG:調教モード == 4
		RETURNF "D"
	ENDIF
ENDIF

RETURNF "X"

;--------------------------------------------------
;口上の存在判定  口上が存在すれば1を、存在しなければ0を返す
;ARG:0にはキャラのNOを指定する
;--------------------------------------------------
@IS_KOJO(ARG:0)
;イベントキャラは口上を表示しない
IF ARG:0 >= 2000
	RETURN 0
ENDIF

;口上を表示しない設定なら常に0を返す
IF (ARG:0 <= 100 && CONFIG:40 == 1) || (ARG:0 >= 101 && CONFIG:41 == 1)
	RETURN 0
ENDIF

TRYCCALLFORM KOJO_EXIST_K{ARG:0}
	RETURN 1
CATCH
ENDCATCH
RETURN 0

;--------------------------------------------------
;調教開始時の口上
;--------------------------------------------------
@EVENTTRAIN
;現在のターゲットを記録
LOCAL:0 = TARGET

;相手が一人の場合のみ口上呼び出し 捕虜調教の場合は人数制限を無視してメインターゲットの口上を表示 逆調教,特殊勢力逆調教の場合は全てじょうじ
;IF TFLAG:44 == 1 || GROUPMATCH(FLAG:調教モード,2,4,5)
FOR LOCAL:0, 0, CHARANUM
		;調教参加フラグが立っていれば口上呼び出し(捕虜調教の場合はメインターゲットのみ)
	IF CFLAG:(LOCAL:0):調教参加フラグ && (FLAG:調教モード != 2 || FINDELEMENT(PRISONER_TARGET, LOCAL:0) != -1)
		TARGET = LOCAL:0
		LOCAL:5 = KOJO_NO(TARGET)

		CALL IS_KOJO(LOCAL:5)
		IF RESULT
			TRYCALLFORM KOJO_TRAIN_START_K{LOCAL:5}
			TRYCALLFORM KOJO_TRAIN_START_%KOJO_STATE(1)%_K{LOCAL:5}
		ENDIF
	ENDIF
NEXT
;ENDIF

;ターゲットを戻す
TARGET = LOCAL:0

;--------------------------------------------------
;調教終了時の口上
;--------------------------------------------------
@EVENTEND
;現在のターゲットを記録
LOCAL:0 = TARGET

;相手が一人の場合のみ口上呼び出し 捕虜調教の場合は人数制限を無視してメインターゲットの口上を表示 逆調教,特殊勢力逆調教の場合は全てじょうじ
IF TFLAG:44 == 1 || GROUPMATCH(FLAG:調教モード,2,4,5)
	FOR LOCAL:0, 0, CHARANUM
		;調教参加フラグが立っていれば口上呼び出し(捕虜調教の場合はメインターゲットのみ)
		IF CFLAG:(LOCAL:0):調教参加フラグ && (FLAG:調教モード != 2 || FINDELEMENT(PRISONER_TARGET, LOCAL:0) != -1)
			TARGET = LOCAL:0
			LOCAL:5 = KOJO_NO(TARGET)

			CALL IS_KOJO(LOCAL:5)
			IF RESULT
				TRYCALLFORM KOJO_TRAIN_END_K{LOCAL:5}
				TRYCALLFORM KOJO_TRAIN_END_%KOJO_STATE(1)%_K{LOCAL:5}
			ENDIF
		ENDIF
	NEXT
ENDIF

;ターゲットを戻す
TARGET = LOCAL:0

;--------------------------------------------------
;コマンド実行前の口上
;戻り値に1を設定すると地の文がカットされる
;--------------------------------------------------
@KOJO_COM_BEFORE
;現在のターゲットを記録
LOCAL:0 = TARGET

;戻り値のデフォルト値を0に設定
LOCAL:1 = 0

;主人公がプレイヤーの場合
IF IS_MPLY(MASTER)
	FOR LOCAL, 0, MTAR_NUM
		TARGET = MTAR:(LOCAL)
		SIF TARGET == -1
			CONTINUE
		;失神・睡眠・離脱状態なら口上を非表示
		IF !(TCVAR:52 || TCVAR:53)
			LOCAL:5 = KOJO_NO(TARGET)

			CALL IS_KOJO(LOCAL:5)
			IF RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_K{LOCAL:5}
				LOCAL:1 |= RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_TARGET_K{LOCAL:5}
				LOCAL:1 |= RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_%KOJO_STATE()%_K{LOCAL:5}
				LOCAL:1 |= RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_TARGET_%KOJO_STATE()%_K{LOCAL:5}
				LOCAL:1 |= RESULT
			ENDIF
		ENDIF
	NEXT
;主人公がターゲットの場合
ELSEIF IS_MTAR(MASTER)
	FOR LOCAL, 0, MPLY_NUM
		TARGET = MPLY:(LOCAL)
		SIF TARGET == -1
			CONTINUE
		;失神・睡眠・離脱状態なら口上を非表示
		IF !(TCVAR:52 || TCVAR:53)
			LOCAL:5 = KOJO_NO(TARGET)

			CALL IS_KOJO(LOCAL:5)
			IF RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_K{LOCAL:5}
				LOCAL:1 |= RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_PLAYER_K{LOCAL:5}
				LOCAL:1 |= RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_%KOJO_STATE()%_K{LOCAL:5}
				LOCAL:1 |= RESULT
				RESULT = 0
				TRYCALLFORM KOJO_COM_BEFORE_PLAYER_%KOJO_STATE()%_K{LOCAL:5}
```
