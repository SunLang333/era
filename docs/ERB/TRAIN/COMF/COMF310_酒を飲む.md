# TRAIN/COMF/COMF310_酒を飲む.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COMF310_酒を飲む.ERB`

类型: .ERB

自动摘要: functions: COM_NAME310, COM_ABLE310, COM310, COM_TEXT_BEFORE310, COM_TEXT_LAST310, COM_AVAILABLE_WHEN310; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;酒を飲む

;-------------------------------------------------
;コマンド名称
;-------------------------------------------------
@COM_NAME310
RESULTS:0 = 酒を飲ませる
RESULTS:1 = 酌をさせられる
RESULTS:2 = 酌をさせる
RESULTS:3 = 酒を飲まされる


;-------------------------------------------------
;選択可否判定
;-------------------------------------------------
@COM_ABLE310
;共通部分
CALL COM_ABLE_COMMON(310)
SIF RESULT == 0
	RETURN 0
;捕虜会話では不可
SIF FLAG:調教モード == 6
	RETURN 0
;酒類を持っている必要がある
SIF !(ITEM:濁り酒 || ITEM:清酒 || ITEM:葡萄酒 || ITEM:麦酒 || ITEM:醸造酒 || ITEM:果実酒 || ITEM:日本酒 || ITEM:蒸留酒)
	RETURN 0
;キス中は不可
SIF IS_EQUIP(MPLY:0, 342)
	RETURN 0
;飲まされる側が妊娠していたら不可
SIF TALENT:(MTAR:0):妊娠
	RETURN 0
RETURN 1

;-------------------------------------------------
;メイン処理
;-------------------------------------------------
@COM310
#DIM 酒配列 = GETNUM(ITEM, "濁り酒"), GETNUM(ITEM, "清酒"), GETNUM(ITEM, "葡萄酒"), GETNUM(ITEM, "麦酒"), GETNUM(ITEM, "醸造酒"), GETNUM(ITEM, "果実酒"), GETNUM(ITEM, "日本酒"), GETNUM(ITEM, "蒸留酒")
#DIM 飲む酒
;コマンドの成否をTFLAG:18にセット
CALL JUDGE_COM_RESULT(MTAR:0, 15, 5)

;主導権がMASTERにあれば酒を選択できる
IF TFLAG:45 == MASTER
	;酒の選択
	PRINTFORML どの酒を\@ MPLY:0 == MASTER ? 勧めますか？ # 飲みますか？ \@
	FOR LOCAL, 0, VARSIZE("酒配列")
		IF ITEM:(酒配列:LOCAL) > 0
			LOCALS = %"[" + ITEMNAME:(酒配列:LOCAL) + "]", 10, LEFT%
			PRINTBUTTON LOCALS, 酒配列:LOCAL
			PRINT    
			PRINTFORML {ITEM:(酒配列:LOCAL)}個
		ENDIF
	NEXT
	PRINTFORML [99] 戻る
	$INPUT_LOOP_DRINK
	INPUT
	IF RESULT == 99
		PRINTFORMW やめておくことにした
		RETURN 0
	ELSEIF FINDELEMENT(酒配列, RESULT) != -1 && ITEM:RESULT > 0
		飲む酒 = RESULT
	ELSE
		GOTO INPUT_LOOP_DRINK
	ENDIF
ELSE
	WHILE 1
		LOCAL = 酒配列:(RAND:(VARSIZE("酒配列")))
		IF ITEM:LOCAL > 0
			飲む酒 = LOCAL
			BREAK
		ENDIF
	WEND
ENDIF

SELECTCASE 飲む酒
	CASE GETNUM(ITEM, "濁り酒")
		ITEM:濁り酒 --
		SOURCE:(MTAR:0):酔い追加 = 300
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 220
		ELSEIF TALENT:(MTAR:0):幼児 || TALENT:(MTAR:0):幼稚
			LOCAL:0 = 120
			TFLAG:18 = -1
		ELSE
			LOCAL:0 = 190
		ENDIF
		FLAG:コマンド汎用 = 1
	CASE GETNUM(ITEM, "清酒")
		ITEM:清酒 --
		SOURCE:(MTAR:0):酔い追加 = 800
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 280
		ELSEIF TALENT:(MTAR:0):幼児 || TALENT:(MTAR:0):幼稚
			LOCAL:0 = 120
			TFLAG:18 = -1
		ELSE
			LOCAL:0 = 240
		ENDIF
		FLAG:コマンド汎用 = 2
	CASE GETNUM(ITEM, "葡萄酒")
		ITEM:葡萄酒 --
		SOURCE:(MTAR:0):酔い追加 = 600
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 320
		ELSEIF TALENT:(MTAR:0):幼児 || TALENT:(MTAR:0):幼稚
			LOCAL:0 = 260
		ELSE
			LOCAL:0 = 320
		ENDIF
		FLAG:コマンド汎用 = 3
	CASE GETNUM(ITEM, "麦酒")
		ITEM:麦酒 --
		SOURCE:(MTAR:0):酔い追加 = 800
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 320
		ELSEIF TALENT:(MTAR:0):幼児 || TALENT:(MTAR:0):幼稚
			LOCAL:0 = 120
			TFLAG:18 = -1
		ELSE
			LOCAL:0 = 270
		ENDIF
		FLAG:コマンド汎用 = 4
	CASE GETNUM(ITEM, "醸造酒")
		ITEM:醸造酒 --
		SOURCE:(MTAR:0):酔い追加 = 1800
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 360
		ELSEIF TALENT:(MTAR:0):幼児 || TALENT:(MTAR:0):幼稚
			LOCAL:0 = 100
			TFLAG:18 = -1
		ELSE
			LOCAL:0 = 300
		ENDIF
		FLAG:コマンド汎用 = 5
	CASE GETNUM(ITEM, "果実酒")
		ITEM:果実酒 --
		SOURCE:(MTAR:0):酔い追加 = 1200
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 360
		ELSEIF TALENT:(MTAR:0):幼児 || TALENT:(MTAR:0):幼稚
			LOCAL:0 = 260
		ELSE
			LOCAL:0 = 400
		ENDIF
		FLAG:コマンド汎用 = 6
	CASE GETNUM(ITEM, "日本酒")
		ITEM:日本酒 --
		SOURCE:(MTAR:0):酔い追加 = 3000
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 500
			TFLAG:18 = 1
		ELSEIF TALENT:(MTAR:0):幼児 || TALENT:(MTAR:0):幼稚
			LOCAL:0 = 100
			TFLAG:18 = -1
		ELSE
			LOCAL:0 = 360
		ENDIF
		FLAG:コマンド汎用 = 7
	CASE GETNUM(ITEM, "蒸留酒")
		ITEM:蒸留酒 --
		SOURCE:(MTAR:0):酔い追加 = 5000
		IF TALENT:(MTAR:0):酒豪
			LOCAL:0 = 500
			TFLAG:18 = 1
		ELSE
			LOCAL:0 = 50
			TFLAG:18 = -1
		ENDIF
		FLAG:コマンド汎用 = 8
	CASEELSE
		PRINTFORMW 存在しない酒が指定されたよ
		PRINTFORMW 飲む酒:{飲む酒}
		PRINTFORMW 上のメッセージと一緒にスレで報告してね
		RETURN 0
ENDSELECT

;●ターゲット側の処理
;固定で獲得するソース
SOURCE:(MTAR:0):歓楽 = LOCAL:0 / 3

;親密に応じた歓楽のソース追加
CALL ADD_SOURCE_KANRAKU(MTAR:0, LOCAL:0)

;主導権に応じたソースの追加
CALL ADD_SOURCE_INITIATIVE_N(MPLY:0, 50, 50)
CALL ADD_SOURCE_INITIATIVE_N(MTAR:0, 50, 50)

;失敗
IF TFLAG:18 == -1
	TIMES SOURCE:(MTAR:0):歓楽, 0.50
	SOURCE:(MTAR:0):不満 += 200
	TFLAG:37 -= 5
;成功
ELSEIF TFLAG:18 == 0
	TFLAG:37 += 2
;大成功
ELSE
	TIMES SOURCE:(MTAR:0):歓楽, 2.00
```
