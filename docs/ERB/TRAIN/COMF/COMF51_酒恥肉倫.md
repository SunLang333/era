# TRAIN/COMF/COMF51_酒恥肉倫.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF51_酒恥肉倫.ERB`

类型: .ERB

自动摘要: functions: COM_NAME51, COM_ABLE51, COM51, COM_ORDER_PLAYER51, COM_AVAILABLE_WHEN51, COM51_ORGY, COM51_ADD_SOURCE, COM_PREFERENCE_PLAYER_51, COM_PREFERENCE_TARGET_51; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;酒池肉林

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME51
LOCALS:0 = 酒恥肉倫
RESULTS:0 = %LOCALS:0%
RESULTS:1 = %LOCALS:0%
RESULTS:2 = %LOCALS:0%
RESULTS:3 = %LOCALS:0%
RESULTS:4 = %LOCALS:0%
RESULTS:5 = %LOCALS:0%

;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE51
;共通部分
CALL COM_ABLE_COMMON(51)
SIF RESULT == 0
	RETURN 0
;プレイヤーは1人, MASTER
SIF MPLY:0 != MASTER || MPLY_NUM != 1
	RETURN 0

;プレイヤーが行動不能なら不可
SIF !IS_PLAYABLE(MPLY:0)
	RETURN 0

;露出プレイ中でないと駄目
SIF TFLAG:54 !=  8
	RETURN 0

;モブがある程度いないと駄目
SIF TFLAG:104 < 2
	RETURN 0

;全てのプレイヤーについて判定
FOR LOCAL:0, 0, MPLY_NUM
	;口が塞がってたらだめ
	SIF IS_M_HOLD(MPLY:(LOCAL:0))
		RETURN 0
	;拘束されているなら不可
	SIF IS_BIND(MPLY:(LOCAL:0))
		RETURN 0
NEXT

LOCAL:1 = 0
;まんことちんぽ両方ないと駄目
FOR LOCAL:0, 0, CHARANUM
	SIF IS_PARTICIPATE_TRAIN(LOCAL) && HAS_VAGINA(LOCAL)
		SETBIT LOCAL:1, 1
	SIF IS_PARTICIPATE_TRAIN(LOCAL) && HAS_PENIS(LOCAL)
		SETBIT LOCAL:1, 2
NEXT

RETURN GETBIT(LOCAL:1, 1) && GETBIT(LOCAL:1, 2)

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM51
;実行判定
CALL COM_ORDER_COMMON
SIF RESULT == 0
	RETURN 0

PRINTFORML %ANAME(MPLY:0)%は、露出プレイに参加してきた連中を交えて乱交を行うことにした……
PRINTFORMW 誰も彼もが好き放題に交わっては相手を変え、乱痴気騒ぎが始まった……
PRINTFORMW ・
PRINTFORMW ・
PRINTFORMW ・

LOCAL:2 = 0
FOR LOCAL, 0, CHARANUM
	SIF IS_PARTICIPATE_TRAIN(LOCAL) && IS_FEMALE(LOCAL)
		LOCAL:2 ++
NEXT

;総当たりでFUCKする
FOR LOCAL:0, 0, CHARANUM
	SIF !IS_PARTICIPATE_TRAIN(LOCAL)
		CONTINUE
	SIF !IS_FEMALE(LOCAL)
		CONTINUE
	SIF GROUPMATCH(TCVAR:LOCAL:53, 5, 6)
		CONTINUE
	FOR LOCAL:1, 0, CHARANUM
		SIF !IS_PARTICIPATE_TRAIN(LOCAL:1)
			CONTINUE
		SIF LOCAL == LOCAL:1
			CONTINUE
		SIF GROUPMATCH(TCVAR:(LOCAL:1):53, 5, 6)
			CONTINUE
		;文章表示は確率
		SIF RAND:MAX(LOCAL:2 / 2, 1) == 0
			CALL COM51_ORGY(LOCAL, LOCAL:1)
		;表示されなかった場合も、膣内射精とかはされたことにする
		IF HAS_PENIS(LOCAL:1) && HAS_VAGINA(LOCAL)
			FOR LOCAL:2, 0, 5
				;modded code to be simpler
				CALL RECORD_CREAMPIE(LOCAL, GET_ID(LOCAL:1), CUM_AMOUNT_CORRECTION(GET_ID(LOCAL:1), LOCAL, 射精部位_膣内, RAND(3, 7)), 射精部位_膣内)
				CALL RECORD_CREAMPIE(LOCAL, GET_ID(LOCAL:1), CUM_AMOUNT_CORRECTION(GET_ID(LOCAL:1), LOCAL, 射精部位_膣内, RAND(3, 7)), 射精部位_アナル)
				CALL RECORD_CREAMPIE(LOCAL, GET_ID(LOCAL:1), CUM_AMOUNT_CORRECTION(GET_ID(LOCAL:1), LOCAL, 射精部位_膣内, RAND(3, 7)), 射精部位_口)
				FOR LOCAL:3, 0, 10
					IF GROUPMATCH(LOCAL:3, 射精部位_膣内, 射精部位_アナル, 射精部位_手, 射精部位_口, 射精部位_胸, 射精部位_足, 射精部位_髪, 射精部位_尻)
						CUM_GET_COUNT:LOCAL:(LOCAL:3) ++
						CUM_GET_AMOUNT:LOCAL:(LOCAL:3) += RAND(3, 7)
						CUM_CUR_AMOUNT:LOCAL:(LOCAL:3) += RAND(3, 7)
						CUM_TO_AMOUNT:(LOCAL:1):(LOCAL:3) += RAND(3, 7)
						CUM_TO_COUNT:(LOCAL:1):(LOCAL:3) ++
					ENDIF
				NEXT
			NEXT
		ENDIF
		CALL COM51_ADD_SOURCE(LOCAL)
		CALL COM51_ADD_SOURCE(LOCAL:1)
	NEXT
NEXT

PRINTFORMW ・
PRINTFORMW ・
PRINTFORMW ・
PRINTFORMW 乱痴気騒ぎはようやく終わったようだ

;主導度変化基準値
TFLAG:49 = 5

;倒錯度変化基準値
TFLAG:50 = 10

TFLAG:55 = TFLAG:56

;後のコマンドの実行を阻止する
CALL INIT_EQUIP

RETURN 1


;-------------------------------------------------
;固有の実行判定
;-------------------------------------------------
@COM_ORDER_PLAYER51(ARG:0)
;実行値の設定
TCVAR:(ARG:0):25 = 120

;共通部分
CALL COM_ORDER(ARG:0)

CALL COM_ORDER_ELEMENT(ARG:0, @"欲望Lv{ABL:(ARG:0):欲望}", ABL:(ARG:0):欲望 * 1)
CALL COM_ORDER_ELEMENT(ARG:0, @"奉仕Lv{ABL:(ARG:0):奉仕}", ABL:(ARG:0):奉仕 * 4)

LOCAL:0 = GET_PALAMLV(PALAM:(ARG:0):欲情)
CALL COM_ORDER_ELEMENT(ARG:0, @"欲情Lv{LOCAL:0}", MIN(LOCAL:0 * 1, 10))

IF TALENT:(ARG:0):恥じらい
	CALL COM_ORDER_ELEMENT(ARG:0, "恥じらい", -2)
ENDIF
IF TALENT:(ARG:0):恥薄い
	CALL COM_ORDER_ELEMENT(ARG:0, "恥薄い", 5)
ENDIF

RETURN 1

;-------------------------------------------------
;コマンド区分
;-------------------------------------------------

@COM_AVAILABLE_WHEN51
RETURN コマンド_ウフフ

;-------------------------------------------------
;乱交パート　よい表現が思いつかず受け攻めってしてるけど受け側のキャラが攻める分岐もあり
;男は受け側に入らない前提
;-------------------------------------------------
@COM51_ORGY(受け, 攻め)
#DIM 受け
#DIM 攻め

;男→女/ふた、またはふた→女/ふた
IF IS_MALE(攻め) || (HAS_PENIS(攻め) && RAND:100 < 20)
	SELECTCASE RAND:5
		CASE 0
			PRINTFORML %ANAME(受け)%の%STR_BODY("膣：欲情", 受け)%を、%ANAME(攻め)%が猛然と貫いている
			PRINTFORML %ANAME(受け)%はたまらないという声をあげながらよがっている……
		CASE 1
			PRINTFORML 既に何発も種を受け止めた%ANAME(受け)%は、恍惚の表情を浮かべ%ANAME(攻め)%の肉棒を咥え込んでいる
			PRINTFORML じゅるじゅると亀頭を舐め回され、%ANAME(攻め)%は思わず精を解き放った……
		CASE 2
			PRINTFORML %ANAME(受け)%の両穴を%ANAME(攻め)%が執拗に突いている
			PRINTFORML 肉棒をねじ込まれるたび、%ANAME(受け)%はたまらないという声をあげてよがる……
		CASE 3
			PRINTFORML %ANAME(攻め)%は寝転び、%ANAME(受け)%に騎乗位で腰を振らせている
			PRINTFORML %STR_BODY("膣：感度", 受け)%でペニスを咥え込んだ%ANAME(受け)%は、腰を振るたび艶やかな声をあげている……
		CASE 4
			PRINTFORML %ANAME(攻め)%は%ANAME(受け)%を組み敷いて、乱暴に突きまくっている
			PRINTFORML 両穴を抉られ、%ANAME(受け)%は獣じみた声をあげてよがっている……
	ENDSELECT
	CALL FUCK(攻め, "欲望, 性交, 性技, 射精, Ｃ, Ｍ, Ｖ挿入, Ａ挿入, キス", "童貞喪失, キス喪失", -1, @"%ANAME(受け)%の唇", "", @"%ANAME(攻め)%の膣", "乱交")
```
