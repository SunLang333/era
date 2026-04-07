# TRAIN/SYSTEM_TRAIN.ERB — 自动生成文档

源文件: `ERB/TRAIN/SYSTEM_TRAIN.ERB`

类型: .ERB

自动摘要: functions: EVENTTRAIN, SET_TMP_MPLY, SET_TMP_MTAR, EVENTCOM, EVENTCOMEND, TRAIN_EXIT, JUDGE_PUSHDOWN, JUDGE_PUSHDOWN2, PUSH_OVER, CHECK_EXIT_ACTION; assigns RESULTS; UI/print; definition/data

前 200 行源码片段:

```text
﻿;調教関連のシステム関数を管理

;-------------------------------------------------
;調教開始時の処理
;-------------------------------------------------
@EVENTTRAIN
#PRI

FLAG:継続コマンド表示絞り込み = 0
FLAG:継続コマンド表示絞り込み選択中キャラ = MASTER
FLAG:逆調教コマンド強制 = -1

LINES_TRAIN = LINECOUNT
;調教に参加している人数を数える
TFLAG:44 = 0
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):調教参加フラグ
		TFLAG:44 ++
	ENDIF
NEXT

;機嫌パラメータに退避しておいた値を代入
FOR LOCAL:0, 0, CHARANUM
	FOR LOCAL:1, 0, 10
		PALAM:(LOCAL:0):(LOCAL:1 + 10) = CFLAG:(LOCAL:0):(LOCAL:1 + 190)
	NEXT
NEXT

;強制友好化フラグが立っているなら、負の感情をリセットする
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):強制友好化
		FOR LOCAL:1, 0, 10
			SIF PALAM:(LOCAL:0):(LOCAL:1 + 10) > 0
				PALAM:(LOCAL:0):(LOCAL:1 + 10) = 0
		NEXT
	ENDIF
NEXT

;「会いに行く」モード
IF FLAG:調教モード == 0
	FOR LOCAL:0, 0, CHARANUM
		;ツンデレ＆恋慕＆非恋人の場合
		IF TALENT:(LOCAL:0):ツンデレ && TALENT:(LOCAL:0):恋慕 && !TALENT:(LOCAL:0):恋人
			;最初から怒・哀の感情が高めの状態に
			PALAM:(LOCAL:0):怒主 = MAX(PALAM:(LOCAL:0):怒主, 300 + RAND:100)
			PALAM:(LOCAL:0):哀主 = MAX(PALAM:(LOCAL:0):哀主, 300 + RAND:100)
		ENDIF
	NEXT
ENDIF

;IF FLAG:調教モード == 2 && CFLAG:(FLAG:19):外交調教カウンタ && TFLAG:44 == 1
;	IF ABL:(FLAG:19):欲望 >= 3 && ABL:(FLAG:19):性知識 >= 3 && (ABL:(FLAG:19):主導度Ｕ >= 300 || TALENT:(FLAG:19):サド)
;		PRINTFORMW ………………
;		PRINTFORMW これはどういうことだろうか？
;		PRINTFORMW 気付けば、%ANAME(FLAG:19)%に完全に主導権を奪われ、縄で縛り上げられてしまっている
;		PRINTFORMW ひょっとすると、調教する相手を間違えたかもしれない…
;		FLAG:調教モード = 5
;		FLAG:19 = -1
;	ENDIF
;ENDIF

;時間の設定
IF FLAG:調教モード == 調教_会う
	;臨月
	IF CFLAG:(MTAR:0):行動不能状態 == 行動不能_臨月
		TFLAG:56 = 5
	;育児中
	ELSEIF CFLAG:(MTAR:0):行動不能状態 == 行動不能_育児
		TFLAG:56 = 5
	;怪我
	ELSEIF CFLAG:(MTAR:0):行動不能状態 == 3
		TFLAG:56 = 3
	ELSE
		TFLAG:56 = 10
	ENDIF
ELSEIF FLAG:調教モード == 調教_子育て
	TFLAG:56 = 5
ELSEIF FLAG:調教モード == 調教_捕虜会話
	TFLAG:56 = 10
ELSEIF FLAG:ウフフフラグ
	TFLAG:56 = 20
ENDIF

;情報表示モードのリセット
FLAG:能力表示モード = 0

;捕虜調教・子育てなら常に主人公が主導権を握る
IF GROUPMATCH(FLAG:調教モード, 2, 3)
	FLAG:主導権所有者 = MASTER
;それ以外なら通常は「成り行き」で開始
ELSE
	FLAG:主導権所有者 = -1
ENDIF

;EQUIPの初期化
CALL INIT_EQUIP()

;捕虜逆調教なら縛られた状態からスタート
IF GROUPMATCH(FLAG:調教モード, 4, 5) && !GROUPMATCH(1, FLAG:閨逆調教)
	CALL CLEAR_MPLY
	CALL CLEAR_MTAR
	FOR LOCAL:0, 0, CHARANUM
		IF CFLAG:(LOCAL:0):調教参加フラグ && LOCAL:0 != MASTER
			CALL ADD_MPLY(LOCAL:0)
		ENDIF
	NEXT
	CALL ADD_MTAR(MASTER)
	;縄は捕虜であるか1/3
	SIF CFLAG:(MASTER):捕虜先 || !RAND:3
		CALL SET_EQUIP(85, 1)
	SIF !RAND:3
		CALL SET_EQUIP(84, 1)
	SIF !RAND:3
		CALL SET_EQUIP(86, 1)
	CALL CLEAR_MPLY
	CALL CLEAR_MTAR
	FOR LOCAL, 0, CHARANUM
		IF CFLAG:(LOCAL:0):調教参加フラグ && TALENT:LOCAL:特殊勢力素質 == 特殊勢力_触手
			CALL ADD_MPLY(LOCAL:0)
		ENDIF
	NEXT
	IF MPLY_NUM > 0
		CALL SET_EQUIP(200, 1)
	ENDIF
ENDIF

IF CONFIG:10 && GROUPMATCH(FLAG:調教モード, 調教_閨, 調教_捕虜調教)
	CALL CLEAR_MPLY
	CALL CLEAR_MTAR
	FOR LOCAL, 0, CHARANUM
		IF IS_PARTICIPATE_TRAIN(LOCAL) && HAS_PENIS(LOCAL)
			;ゴムがなければ補給
			IF ITEM:コンドーム <= 0
				IF ITEMPRICE:コンドーム > MONEY
					PRINTFORML コンドーム購入のための資金が不足しています
					BREAK
				ELSE
					PRINTFORML コンドームを補充します
					ITEM:コンドーム ++
					MONEY -= ITEMPRICE:コンドーム
				ENDIF
			ENDIF
			IF (LOCAL == MASTER && CONFIG:10 == 2) || LOCAL != MASTER
				CALL ADD_MPLY(LOCAL)
				ITEM:コンドーム --
			ENDIF
		ENDIF
	NEXT
	SIF MPLY_NUM > 0
		CALL SET_EQUIP(GETNUM(TRAINNAME, "コンドーム"), 1)
ENDIF


;特殊勢力による調教は、出来上がった状態からスタート
IF FLAG:調教モード == 調教_逆調教特殊
	FOR LOCAL:0, 0, CHARANUM
		IF CFLAG:(LOCAL:0):調教参加フラグ
			PALAM:(LOCAL:0):潤滑 = 30000
			PALAM:(LOCAL:0):欲情 = 30000
		ENDIF
	NEXT
ENDIF

;下戸でなく妊娠していなかったら、たまに酔っ払った状態でスタート
;種族名が鬼の場合高確率、酒豪でもそこそこの確率
;ただし鬼じゃない場合、捕虜調教時は含めない
IF FLAG:調教モード == 調教_会う
	FOR LOCAL, 0, CHARANUM
		IF CFLAG:(LOCAL:0):調教参加フラグ && !TALENT:(LOCAL:0):下戸 && !TALENT:(LOCAL:0):妊娠 && CFLAG:(LOCAL:0):行動不能状態 != 行動不能_子供
			IF HAS_TAG(LOCAL:0, タグ_鬼) && !RAND:3
				PRINTFORMW %ANAME(LOCAL:0)%は酔っ払っているようだ……
				PALAM:(LOCAL:0):酔い = RAND(3000, 6000)
			ELSEIF TALENT:(LOCAL:0):酒豪 && FLAG:調教モード != 2 && !RAND:5
				PRINTFORMW %ANAME(LOCAL:0)%は酔っ払っているようだ……
				PALAM:(LOCAL:0):酔い = RAND(1500, 3000)
			ELSEIF FLAG:調教モード != 2 && !RAND:10
				PRINTFORMW %ANAME(LOCAL:0)%は酔っ払っているようだ……
				PALAM:(LOCAL:0):酔い = RAND(500, 1500)
			ENDIF
		ENDIF
	NEXT
ENDIF

;プレイヤーとターゲットをクリア
CALL CLEAR_MPLY
CALL CLEAR_MTAR

;初期プレイヤー、ターゲット設定
;指定しとかないと何かと不具合起こしがちなので
CALL SET_TMP_MPLY
CALL SET_TMP_MTAR

;尿残量と屁残量をリセット
CVARSET TCVAR, 54, 1000
CVARSET TCVAR, 55, 1000

PLAYER = -1
TARGET = -1
TFLAG:31 = -1

```
