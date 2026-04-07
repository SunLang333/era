# TRAIN/COMF/_COM_TEXT.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/_COM_TEXT.ERB`

类型: .ERB

自动摘要: functions: COM_TEXT_BEFORE, COM_TEXT_AFTER, COM_TEXT_LAST; UI/print

前 200 行源码片段:

```text
﻿;地の文に関する処理

;---------------------------------------------------------
;コマンド実行前に表示される地の文の呼び出し
;主に行動内容や状況等を記述する
;---------------------------------------------------------
@COM_TEXT_BEFORE
;地の文が非表示なら戻る
;SIF FLAG:0 == 0
;	RETURN

;口上表示
CALL KOJO_COM_BEFORE

;口上側の戻り値が1なら地の文はカットされる
IF !RESULT
	TRYCALLFORM COM_TEXT_BEFORE{SELECTCOM}
ENDIF

;---------------------------------------------------------
;コマンド実行直後に表示される地の文の呼び出し
;主に行動の結果を記述する
;射精や絶頂に関連したメッセージもここで表示
;何かメッセージを表示したら1を返す
;---------------------------------------------------------
@COM_TEXT_AFTER
;地の文が非表示なら戻る
;SIF FLAG:0 == 0
;	RETURN

RESULT = 0
TRYCALLFORM COM_TEXT_AFTER{SELECTCOM}
IF RESULT
	;コマンド専用の地の文が定義されていれば戻る
	RETURN 0
ENDIF

LOCAL:10 = 0

;今ターンに絶頂したキャラの人数を数え、名前と最低強度を記録
LOCAL:5 = 0
LOCAL:6 = 0
LOCAL:7 = 999
LOCALS:1 = 
LOCALS:2 = 
FOR LOCAL:0, 0, CHARANUM
	IF IS_PARTICIPATE_TRAIN(LOCAL:0) && !IS_ANIMAL(LOCAL:0)
		;今回のＣＶＡＢＭの絶頂回数(NOWEX)の合計を取得
		LOCAL:2 = SUM_NOWEX(LOCAL:0, 0, 0)

		IF LOCAL:2 > 0
			IF LOCAL:2 < LOCAL:7
				LOCAL:7 = LOCAL:2
			ENDIF

			IF LOCAL:0 == MASTER
				LOCAL:6 = 1
			ELSE
				IF LOCAL:5 == 1
					LOCALS:2 = と%ANAME(LOCAL:0)%
				ELSE
					LOCALS:1 = %ANAME(LOCAL:0)%
				ENDIF
				LOCAL:5 ++
			ENDIF
		ENDIF
	ENDIF
NEXT

;一人以上絶頂した場合
IF LOCAL:5 >= 1
	IF LOCAL:5 >= 3
		LOCALS:1 = %LOCALS:1%たち
	ELSE
		LOCALS:1 = %LOCALS:1%%LOCALS:2%
	ENDIF
	;主人公が同時に絶頂した場合
	IF LOCAL:6
		LOCALS:0 = %ANAME(MASTER)%と
		LOCALS:3 = 同時に
	ELSE
		LOCALS:0 = 
		LOCALS:3 = 
	ENDIF

	IF LOCAL:7 >= 8
		LOCAL:10 = 1
		PRINTFORML %LOCALS:0%%LOCALS:1%は強烈な絶頂感に何度も背を反らせ、打ち上げられた魚のように体を跳ねさせた…
	ELSEIF LOCAL:7 >= 3
		LOCAL:10 = 1
		PRINTFORML %LOCALS:0%%LOCALS:1%は%LOCALS:3%激しく絶頂し、口から涎を垂らしてガクガクと痙攣した…
	ELSEIF LOCAL:7 >= 1
		LOCAL:10 = 1
		PRINTFORML %LOCALS:0%%LOCALS:1%は%LOCALS:3%絶頂に達しビクビクと体を震わせた…
	ENDIF

;主人公だけが絶頂した場合
ELSEIF LOCAL:6
	;今回のＣＶＡＢＭの絶頂回数(NOWEX)の合計を取得
	LOCAL:2 = SUM_NOWEX(MASTER, 0, 0)

	IF LOCAL:2 >= 8
		LOCAL:10 = 1
		PRINTFORML %ANAME(MASTER)%は強烈な絶頂感に何度も背を反らせ、打ち上げられた魚のように体を跳ねさせた…
	ELSEIF LOCAL:2 >= 3
		LOCAL:10 = 1
		PRINTFORML %ANAME(MASTER)%は激しく絶頂し、口から涎を垂らしてガクガクと痙攣した…
	ELSEIF LOCAL:2 >= 1
		LOCAL:10 = 1
		PRINTFORML %ANAME(MASTER)%は絶頂に達しビクビクと体を震わせた…
	ENDIF
ENDIF

FOR LOCAL:0, 0, CHARANUM
	;番号LOCAL:0のキャラが射精した場合
	IF IS_PARTICIPATE_TRAIN(LOCAL:0) && NOWEX:(LOCAL:0):射精 > 0

		LOCAL:10 = 1

		;コンドーム装着中
		IF IS_EQUIP_PLAYER(LOCAL:0, 75)
			SIF SOURCE:(LOCAL:0):快Ｐ == 0 && NOWEX:(LOCAL:0):Ｖ絶頂 + NOWEX:(LOCAL:0):Ａ絶頂 > 0
				PRINTFORM ペニスに触れられてもいないのに射精した
			PRINTFORML %ANAME(LOCAL:0)%の精液が、コンドームへと放たれていった……
			GOTO CUM_SKIP
		ENDIF

		IF STACK_SPERM_CHARA_NUM:(LOCAL:0):0 <= 0
			SIF SOURCE:(LOCAL:0):快Ｐ == 0 && NOWEX:(LOCAL:0):Ｖ絶頂 + NOWEX:(LOCAL:0):Ａ絶頂 > 0
				PRINTFORM ペニスに触れられてもいないのに射精した
			;捕虜調教 or 捕虜逆調教
			IF GROUPMATCH(FLAG:調教モード, 2, 4, 6, 7)
				PRINTFORML %ANAME(LOCAL:0)%の精液が床を汚していった…
			ELSE
				PRINTFORML %ANAME(LOCAL:0)%の精液が%GET_GROUND_NAME(TFLAG:54)%を汚していった…
			ENDIF
			GOTO CUM_SKIP
		ENDIF

		FOR LOCAL:5, 0, CUM_SLOT_NUM
			;射精対象の人数を数え、必要な文字列を作成
			LOCAL:2 = 0
			LOCAL:3 = 2
			LOCAL:4 = -1
			;shitty animal logic. have to run through and count animals first to get apostrophe right.
			FOR LOCAL:1, 0, STACK_SPERM_CHARA_NUM:(LOCAL:0):0
				SIF STACK_SPERM_TO_MAP:(LOCAL:0):(LOCAL:1) != LOCAL:5
					CONTINUE
				LOCAL:4 = STACK_SPERM_CHARA_MAP:(LOCAL:0):(LOCAL:1)
				SIF LOCAL:4 >= 0
					LOCAL:2 ++
				;対象の精愛Lvを判定(主人公が含まれているor逆調教なら-1に固定)
				;★was: IF TCVAR:(LOCAL:0):(LOCAL:1) == MASTER || FLAG:調教モード == 4
				;enabling master's reaction to cum (LOCAL:3 text) depending on config
				IF (!CONFIG:441 ? LOCAL:4 == MASTER # MASTER) || FLAG:調教モード == 4 || IS_ANIMAL(LOCAL:4)
					LOCAL:3 = -1
				ELSEIF LOCAL:3 >= 1 && ABL:(LOCAL:4):精愛 < 2
					LOCAL:3 = 0
				ELSEIF LOCAL:3 >= 2 && ABL:(LOCAL:4):精愛 < 5
					LOCAL:3 = 1
				ENDIF
			NEXT
			;射精対象が未設定
			IF LOCAL:2 <= 0
				CONTINUE
			ELSE
				SIF SOURCE:(LOCAL:0):快Ｐ == 0 && NOWEX:(LOCAL:0):Ｖ絶頂 + NOWEX:(LOCAL:0):Ａ絶頂 > 0
					PRINTFORM ペニスに触れられてもいないのに射精した
				;射精対象が４人以上
				IF LOCAL:2 >= 2
					LOCALS:1 = %ANAME(STACK_SPERM_CHARA_MAP:(LOCAL:0):0)%達
				;射精対象が３人以下
				ELSE
					LOCALS:1 = %ANAME(STACK_SPERM_CHARA_MAP:(LOCAL:0):0)%
				ENDIF
				PRINTFORM %ANAME(LOCAL:0)%の精液が%LOCALS:1%

				SELECTCASE LOCAL:5
					CASE 1
						PRINTL の膣内へと注ぎ込まれた…
					;射精したキャラが獣変化中
						IF (TALENT:(LOCAL):動物耳 || TALENT:(LOCAL):しっぽ) && !IS_ANIMAL(LOCAL)
							IF LOCAL:0 == MASTER
								PRINTFORML 獣の本能がもたらす膣内射精の悦びが、%ANAME(LOCAL:0)%の脳天を甘く痺れさせた…
						;好感度または従属度が1500以上
							ELSEIF CFLAG:(LOCAL:0):好感度 >= 1500 || CFLAG:(LOCAL:0):従属度 >= 1500 || CFLAG:(LOCAL:4):支配度 >= 1500
								PRINTFORML %ANAME(LOCAL:0)%は獣の本能に流されるまま、膣内射精の悦びに顔を緩ませている…
							ELSE
								PRINTFORML %ANAME(LOCAL:0)%は獣の本能に逆らえず、膣内射精の悦びに打ち震えている…
							ENDIF
						ENDIF
					;射精されたキャラが獣変化中
						IF LOCAL:4 >= 0 && (TALENT:(LOCAL:4):動物耳 || TALENT:(LOCAL:4):しっぽ)
							IF LOCAL:4 == MASTER
								PRINTFORML 獣の本能がもたらす膣内射精の悦びが、%ANAME(LOCAL:4)%の脳天を甘く痺れさせた…
						;好感度または従属度が1500以上
							ELSEIF CFLAG:(LOCAL:4):好感度 >= 1500 || CFLAG:(LOCAL:4):従属度 >= 1500 || CFLAG:(LOCAL:4):支配度 >= 1500
								PRINTFORML %ANAME(LOCAL:4)%は獣の本能に流されるまま、膣内射精の悦びに顔を緩ませている…
							ELSE
								PRINTFORML %ANAME(LOCAL:4)%は獣の本能に逆らえず、膣内射精の悦びに打ち震えている…
```
