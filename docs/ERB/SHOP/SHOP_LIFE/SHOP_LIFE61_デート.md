# SHOP/SHOP_LIFE/SHOP_LIFE61_デート.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE61_デート.ERB`

类型: .ERB

自动摘要: functions: SHOP_LIFE_NAME61, SHOP_LIFE_CHECK61, SHOP_LIFE_CHECKCHARA61, SHOP_LIFE_EVENTBUY61, SHOP_LIFE_EVENTBUY_SHOW61, SHOP_LIFE_USERSHOP61; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「デート」の名称
;-------------------------------------------------
@SHOP_LIFE_NAME61
RESULTS:0 '= "デート"

;-------------------------------------------------
;「デート」の選択可否判定
;-------------------------------------------------
@SHOP_LIFE_CHECK61
;デート代不足
SIF MONEY < 3000
	RETURN 0
SIF CFLAG:MASTER:捕虜先
	RETURN 0
SIF !CFLAG:MASTER:所属
	RETURN 0
RETURN 1

;-------------------------------------------------
;「デート」の選択可能キャラ存在判定（誘えるキャラ）
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA61(ARG:0)
;非主人公、同一勢力、捕虜でない、動物でない、通常状態または育児中
RETURN ARG:0 != MASTER && CFLAG:(ARG:0):所属 == CFLAG:MASTER:所属 && CFLAG:(ARG:0):捕虜先 == 0 && !IS_ANIMAL(ARG:0) && GROUPMATCH(CFLAG:(ARG:0):行動不能状態, 0, 2)

;-------------------------------------------------
;「デート」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY61
FLAG:拠点フェイズページ = 1
FLAG:夜這い = 0
RETURN 0

;-------------------------------------------------
;「デート」の右カラム表示処理
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SHOW61
;タイトル
CALL COLUMN_RIGHT_TITLE("対象者選択", "0", "1", "1～全", "3,000～", "自勢力のみ可")
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL
;右カラムの標準的なキャラリストとページ移動呼び出し
CALL COLUMN_RIGHT_CHARALIST
RETURN

;-------------------------------------------------
;「デート」のリスト１入力処理
;-------------------------------------------------
@SHOP_LIFE_USERSHOP61(対象)
#DIM 対象, 1
#DIM 結果, 1
#DIM 全消費, 1
#DIM 内容, 1
#DIM 能力, 1
#DIM イベント発生, 1
;対象者とデートする
;お金消費,1回10000
;好感度+ 200+RAND:100
;行先は湖、森、人里etc

FLAG:能力表示モード = 0

イベント発生 = 0
LOCAL:5 = 0
CALL SINGLE_DRAWLINE
PRINTFORML 行動回数とお金を消費し、%ANAME(対象)%とデートします。
PRINTFORML 1回デートする毎に金3,000を消費します。
PRINTFORML どこに誘いますか？
PRINTFORML 
PRINTFORML 残行動:{CALC_SHOP_TIME() - SHOP_TIME}
PRINTFORML 所持金:%NUM_FORMAT(MONEY)%
CALL SINGLE_DRAWLINE
PRINTBUTTON @"%"[湖]", 12, LEFT%", 1
PRINTBUTTON "[行動全消費]", 11
PRINTL   湖に誘います。武闘値が高いほど相手に好印象を与えられます。
PRINTBUTTON @"%"[山]", 12, LEFT%", 2
PRINTBUTTON "[行動全消費]", 12
PRINTL   山に誘います。防衛値が高いほど相手に好印象を与えられます。
PRINTBUTTON @"%"[森]", 12, LEFT%", 3
PRINTBUTTON "[行動全消費]", 13
PRINTL   森に誘います。知略値が高いほど相手に好印象を与えられます。
PRINTBUTTON @"%"[人里]", 12, LEFT%", 4
PRINTBUTTON "[行動全消費]", 14
PRINTL   人里に誘います。政治値が高いほど相手に好印象を与えられます。
PRINTBUTTON @"%"[花畑]", 12, LEFT%", 5
PRINTBUTTON "[行動全消費]", 15
PRINTL   花畑に誘います。歌唱値が高いほど相手に好印象を与えられます。
PRINTBUTTON @"%"[自宅]", 12, LEFT%", 6
PRINTBUTTON "[行動全消費]", 16
PRINTL   自宅に誘います。料理値が高いほど相手に好印象を与えられます。
CALL SINGLE_DRAWLINE
PRINTBUTTON "[0] - 戻る", 0
$INPUT_LOOP
INPUT 0

内容 = RESULT
;0だったら戻す
IF 内容 == 0
	RETURN 0
ENDIF

IF GROUPMATCH(内容, 11, 12, 13, 14, 15, 16)
	IF MONEY < 3000 * (CALC_SHOP_TIME() - SHOP_TIME)
		PRINTFORMW お金が足りません。
		GOTO INPUT_LOOP
	ELSE
		全消費 = 1
		内容 -= 10
		LOCAL:5 = 1
	ENDIF
ELSEIF GROUPMATCH(内容, 1, 2, 3, 4 ,5, 6)
	IF MONEY < 3000
		PRINTFORMW お金が足りません。
		GOTO INPUT_LOOP
	ELSE
		全消費 = 0
	ENDIF
ELSE
	GOTO INPUT_LOOP
ENDIF

;全消費の場合ここに戻ってくる
$DATE_LOOP

SHOP_TIME += 1
SHOP_WORK_COUNT += 1


;結果の計算
SELECTCASE RAND:100
	CASE 0 TO 19
		結果 = 0
	CASE 20 TO 79
		結果 = 1
	CASEELSE
		結果 = 2
ENDSELECT
;------------------------------------
;イベント発生タイミングを前に変更
IF !イベント発生
	CALL KOJO_DATE_EVENT(対象, 内容)
	SIF RESULT
		イベント発生 = 1
ENDIF
;------------------------------------
SELECTCASE 内容
	CASE 1
		IF LOCAL:5 == 0
			PRINTFORML %ANAME(対象)%を湖に誘った。
		ELSE
			PRINTFORML 引き続き湖で%ANAME(対象)%と楽しんだ。
		ENDIF
		能力 = ABL:MASTER:武闘
	CASE 2
		IF LOCAL:5 == 0
			PRINTFORML %ANAME(対象)%を山に誘った。
		ELSE
			PRINTFORML 引き続き山で%ANAME(対象)%と楽しんだ。
		ENDIF
		能力 = ABL:MASTER:防衛
	CASE 3
		IF LOCAL:5 == 0
			PRINTFORML %ANAME(対象)%を森に誘った。
		ELSE
			PRINTFORML 引き続き森で%ANAME(対象)%と楽しんだ。
		ENDIF
		能力 = ABL:MASTER:知略
	CASE 4
		IF LOCAL:5 == 0
			PRINTFORML %ANAME(対象)%を人里に誘った。
		ELSE
			PRINTFORML 引き続き人里で%ANAME(対象)%と楽しんだ。
		ENDIF
		能力 = ABL:MASTER:政治
	CASE 5
		IF LOCAL:5 == 0
			PRINTFORML %ANAME(対象)%を花畑に誘った。
		ELSE
			PRINTFORML 引き続き花畑で%ANAME(対象)%と楽しんだ。
		ENDIF
		能力 = ABL:MASTER:歌唱
	CASE 6
		IF LOCAL:5 == 0
			PRINTFORML %ANAME(対象)%を自宅に誘った。
		ELSE
			PRINTFORML 引き続き自宅で%ANAME(対象)%と楽しんだ。
		ENDIF
		能力 = ABL:MASTER:料理
	CASEELSE
		GOTO INPUT_LOOP
ENDSELECT

;口上でキャラ毎に別のセリフを言わせられるようにしたい
SELECTCASE RAND:5
	CASE 0
		PRINTFORMW %PRONOUN(対象)%は楽しんでくれている様だ。
	CASE 1
		PRINTFORMW 二人で楽しい時間を過ごした。
```
