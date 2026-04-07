# SHOP/SHOP_SLG/SHOP_SLG41_外交1_関係_見返り_性行為.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_SLG/SHOP_SLG41_外交1_関係_見返り_性行為.ERB`

类型: .ERB

自动摘要: functions: DIPLOMACY_REQUESTED_SEX; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;性的行為の要求の処理
;ARG:0は相手の勢力番号、ARG:1は要求の重さ。要求を飲むと1、断ると0を返す
;-------------------------------------------------
@DIPLOMACY_REQUESTED_SEX(ARG:0, ARG:1)
;自国・相手勢力の君主のキャラ番号をそれぞれ取得
LOCAL:4 = GET_COUNTRY_BOSS(CFLAG:MASTER:所属)
LOCAL:5 = GET_COUNTRY_BOSS(ARG:0)

;常に主人公が対象
IF CONFIG:307 == 1
	LOCAL:6 = MASTER
;常に君主が対象
ELSEIF CONFIG:307 == 2
	LOCAL:6 = LOCAL:4
;対象が状況によって変化
ELSE
	;対象キャラ判定値。正なら君主、負なら主人公が要求の対象になる
	LOCAL:10 = 0

	;●対象キャラの決定(君主 or 主人公)
	;君主に対するイメージが悪いほど君主を辱める方向に傾く
	IF REL_LIKE:(LOCAL:5):(LOCAL:4) >= 800
		LOCAL:10 -= 20
	ELSEIF REL_LIKE:(LOCAL:5):(LOCAL:4) >= 300
		LOCAL:10 -= 10
	ENDIF
	IF REL_HATE:(LOCAL:5):(LOCAL:4) >= 800
		LOCAL:10 += 30
	ELSEIF REL_HATE:(LOCAL:5):(LOCAL:4) >= 300
		LOCAL:10 += 15
	ENDIF

	;主人公との関係の深さに応じて主人公の奉仕を求める方に傾く
	IF TALENT:(LOCAL:5):親愛
		LOCAL:10 -= 40
	ELSEIF TALENT:(LOCAL:5):恋慕
		LOCAL:10 -= 20
	ELSEIF TALENT:(LOCAL:5):恋人
		LOCAL:10 -= 10
	ELSEIF TALENT:(LOCAL:5):親友
		LOCAL:10 += 20
	ELSEIF CFLAG:(LOCAL:5):2 >= 500
		LOCAL:10 -= 5
	ENDIF

	;性別による判定
	IF IS_MALE(LOCAL:5)
		SIF IS_FEMALE(MASTER)
			LOCAL:10 -= 10
		SIF IS_FEMALE(LOCAL:4)
			LOCAL:10 += 10
	ENDIF
	
	IF IS_FEMALE(LOCAL:5)
		SIF IS_MALE(MASTER)
			LOCAL:10 -= 10
		SIF IS_MALE(LOCAL:4)
			LOCAL:10 += 10
	ENDIF

	IF LOCAL:10 >= 0
		LOCAL:6 = LOCAL:4
	ELSE
		LOCAL:6 = MASTER
	ENDIF
ENDIF

;●内容の決定(キス、足舐め、フェラ・パイズリ・クンニ)
LOCAL:11 = 0
LOCAL:12 = 0

SIF TALENT:(LOCAL:5):素直
	LOCAL:12 += 10
SIF TALENT:(LOCAL:5):臆病
	LOCAL:12 += 10
SIF TALENT:(LOCAL:5):貞操観念
	LOCAL:12 += 10
SIF TALENT:(LOCAL:5):貞操無頓着
	LOCAL:12 -= 10
SIF TALENT:(LOCAL:5):生意気
	LOCAL:11 += 10
SIF TALENT:(LOCAL:5):プライド高い
	LOCAL:11 += 10

IF GETBIT(TALENT:(LOCAL:5):淫乱系, 素質_淫乱_サド)
	LOCAL:11 += 20
ELSEIF GETBIT(TALENT:(LOCAL:5):淫乱系, 素質_淫乱_マゾ)
	LOCAL:11 -= 20
ELSEIF ABL:(LOCAL:5):主導度Ｕ >= 500
	LOCAL:11 += 15
ELSEIF ABL:(LOCAL:5):主導度Ｕ >= 300
	LOCAL:11 += 10
ELSEIF ABL:(LOCAL:5):主導度Ｕ >= 100
	LOCAL:11 += 5
ELSEIF ABL:(LOCAL:5):主導度Ｕ > -100
	LOCAL:11 += 0
ELSEIF ABL:(LOCAL:5):主導度Ｕ > -300
	LOCAL:11 -= 5
ELSEIF ABL:(LOCAL:5):主導度Ｕ > -500
	LOCAL:11 -= 10
ELSE
	LOCAL:11 -= 15
ENDIF

IF ABL:(LOCAL:5):倒錯度 >= 800
	LOCAL:12 -= 15
ELSEIF ABL:(LOCAL:5):倒錯度 >= 500
	LOCAL:12 -= 10
ELSEIF ABL:(LOCAL:5):倒錯度 >= 300
	LOCAL:12 -= 5
ENDIF

IF ARG:1 == 1
	LOCAL:12 -= 10
ELSEIF ARG:1 == 2
	LOCAL:12 -= 20
ENDIF

IF LOCAL:12 >= 5 && LOCAL:6 == MASTER
	LOCAL:15 = 0
ELSEIF LOCAL:11 >= 15 && RAND:2
	LOCAL:15 = 1
ELSEIF LOCAL:12 <= -15 && RAND:2
	LOCAL:15 = 2
ELSEIF !RAND:3
	IF RAND:2 && (HAS_PENIS(LOCAL:6) && HAS_VAGINA(LOCAL:5)) || (HAS_VAGINA(LOCAL:6) && HAS_PENIS(LOCAL:5))
		LOCAL:15 = 30
	ELSE
		LOCAL:15 = 50
	ENDIF
ELSEIF HAS_PENIS(LOCAL:5)
	LOCAL:15 = 10
	IF RAND:3 >= 1
		LOCAL:15 = 11
	ENDIF
ELSE
	LOCAL:15 = 20
ENDIF

SELECTCASE LOCAL:15
	CASE 0
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりにこの場でキスをしろと要求してきた
	CASE 1
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりにこの場で足を舐めろと要求してきた
	CASE 2
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりにこの場でオナニーしろと要求してきた
	CASE 10
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりにフェラで奉仕しろと要求してきた
	CASE 11
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりにパイズリで奉仕しろと要求してきた
	CASE 20
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりにクンニで奉仕しろと要求してきた
	CASE 30
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりに一晩%ANAME(LOCAL:5)%の慰み者になるように要求してきた
	CASE 50
		PRINTFORML %ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%に対して、こちらの提案を飲む代わりに兵達の相手をしろと要求してきた
ENDSELECT

CALL ASK_YN("受け入れる", "断る")
IF RESULT == 1
	RETURN 0
ENDIF

IF LOCAL:6 != MASTER
	PRINTFORMW %ANAME(MASTER)%は%ANAME(LOCAL:6)%に対して、要求を飲むように説得した…
	PRINTL 
ENDIF

SELECTCASE LOCAL:15
	CASE 0
		IF LOCAL:11 >= 20
			PRINTFORML %ANAME(LOCAL:6)%が要求通り%ANAME(LOCAL:5)%に口付けると、%ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%の頭の後ろに手を回し、
			PRINTFORMW 舌を入れて貪るように%ANAME(LOCAL:6)%の口内を舐め回してきた
			PRINTFORMW %ANAME(LOCAL:6)%は息苦しさに口を離そうとしたが、%ANAME(LOCAL:5)%に頭をしっかりと抱え込まれて逃げることが出来ない
			PRINTFORMW やがて%ANAME(LOCAL:5)%が満足するまで、%ANAME(LOCAL:6)%は延々と%ANAME(LOCAL:5)%に抱き締められてキスをされ続けた
		ELSE
			PRINTFORML %ANAME(LOCAL:6)%が要求通り%ANAME(LOCAL:5)%に口付けると、%ANAME(LOCAL:5)%は%ANAME(LOCAL:6)%の口内に舌を挿し入れ、
			PRINTFORMW 誘うように%ANAME(LOCAL:6)%の舌を絡め取った
			PRINTFORMW %ANAME(LOCAL:6)%は%ANAME(LOCAL:5)%に促されるまま、自らも舌を絡めて深い口付けを交わした
			PRINTFORMW しばらくして%ANAME(LOCAL:6)%が口を離すと、%ANAME(LOCAL:5)%は物足りないといった表情でさらなるキスをねだってきた
			PRINTFORMW やがて%ANAME(LOCAL:5)%が満足するまで、%ANAME(LOCAL:6)%は延々と%ANAME(LOCAL:5)%にキスを強要され続けた
		ENDIF
		IF LOCAL:6 == MASTER && (TALENT:(LOCAL:4):恋慕 || TALENT:(LOCAL:4):恋人)
			PRINTL 
			PRINTFORMW ふと背筋に寒気を感じて振り向くと、%ANAME(LOCAL:4)%が%ANAME(LOCAL:6)%のことを恨めしげに睨みつけていた
			PRINTFORMW 冷や汗を流す%ANAME(LOCAL:6)%をよそに、%ANAME(LOCAL:5)%はクスクスと楽しそうに微笑んでいた
			PALAM:(LOCAL:4):怒主 += 5000
		ENDIF
		PRINTL 

		PRINTFORML <%ANAME(LOCAL:6)%>
		CALL PRINT_ADD_EXP(LOCAL:6, "キス経験", 3)
		CALL TRAIN_AUTO_ABLUP(LOCAL:6)
		PRINTL 

		PRINTFORML <%ANAME(LOCAL:5)%>
		CALL PRINT_ADD_EXP(LOCAL:5, "キス経験", 3)
		CALL TRAIN_AUTO_ABLUP(LOCAL:5)
		PRINTL 
```
