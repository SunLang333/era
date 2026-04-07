# SLG/SLG_ESCAPE.ERB — 自动生成文档

源文件: `ERB/SLG/SLG_ESCAPE.ERB`

类型: .ERB

自动摘要: functions: LOSERS_ACTION, JUDGE_ESCAPE, TREAT_PRISONER, SELECT_PRISONER_TREATMENT, AUTO_PRISONER_TREATMENT, MASTER_CAPTURED, MASTER_CAPTURED_DOES_EXECUTE, JUDGE_ASSIGN, JUDGE_ASSIGN_REQUIRE_MONEY; UI/print

前 200 行源码片段:

```text
﻿;勢力が滅亡した場合や捕縛された場合の処理

;-------------------------------------------------
;ARG:1勢力がARG:0勢力を滅亡させた時の敗将の処理
;-------------------------------------------------
@LOSERS_ACTION(滅亡勢力, 滅ぼした勢力)
#DIM 滅亡勢力
#DIM 滅ぼした勢力
#DIM 滅亡君主
#DIM 滅ぼした君主

滅亡君主 = GET_COUNTRY_BOSS(滅亡勢力)
滅ぼした君主 = GET_COUNTRY_BOSS(滅ぼした勢力)

;プレイヤー勢力が特殊勢力に滅ぼされた場合は特殊イベント
IF 滅亡勢力 == CFLAG:MASTER:所属 && IS_SP_COUNTRY(滅ぼした勢力)
	TRYCCALLFORM MASTER\CAPTURED_%SP_COUNTRY_NAME_ENG:SP_COUNTRY_TO_CONST(滅ぼした勢力)%(滅ぼした勢力)
		;プレイヤー勢力の所属キャラ、ないしプレイヤー勢力の捕虜は全て無所属となり、特殊勢力に囚われる
		FOR LOCAL, 0, CHARANUM
			IF CFLAG:LOCAL:所属 == 滅亡勢力 || CFLAG:LOCAL:捕虜先 == 滅亡勢力
				CALL CHANGE_COUNTRY(LOCAL, 0, 1)
				CALL CAPTURE(LOCAL, 滅ぼした勢力)
			ENDIF
		NEXT
		RETURN 1
	CATCH
	ENDCATCH
ENDIF

;主人公勢力の手で滅亡させた場合
IF 滅ぼした勢力 == CFLAG:MASTER:所属
	WAIT
	PRINTL 
	PRINTW ………………
	PRINTW ……
	PRINTL 
ENDIF

FOR LOCAL, 0, CHARANUM
	SIF LOCAL == MASTER
		CONTINUE
	SIF CFLAG:LOCAL:所属 != 滅亡勢力
		CONTINUE
	SIF !CFLAG:LOCAL:捕虜先
		CONTINUE
	SIF CFLAG:LOCAL:捕虜先 == CFLAG:MASTER:所属
		CONTINUE
	;特殊勢力の捕虜にはなにもしない(調教堕ち)
	SIF IS_SP_COUNTRY(CFLAG:LOCAL:捕虜先)
		CONTINUE
	;滅亡した勢力自身の捕虜は、TREAT_PRISONERで判断(捕まったキャラとして考える)
	;現状ではプレイヤー自ら投獄していた場合
	IF CFLAG:LOCAL:捕虜先 == 滅亡勢力
		CALL TREAT_PRISONER(LOCAL, 滅亡勢力, 滅ぼした勢力)
	;他のCPU勢力の捕虜になっていたら登用判定を行う。失敗したら解放・放浪
	ELSEIF JUDGE_ASSIGN(LOCAL, CFLAG:(LOCAL:0):所属, CFLAG:(LOCAL:0):捕虜先) == 1
		CALL COLOR_PRINTL(@"囚われていた%ANAME(LOCAL)%は、%ANAME(GET_COUNTRY_BOSS(CFLAG:(LOCAL:0):捕虜先))%に登用された", カラー_注意)
		CALL CHANGE_COUNTRY(LOCAL, CFLAG:LOCAL:捕虜先, 1)
	ELSE
		CALL COLOR_PRINTL(@"%ANAME(GET_COUNTRY_BOSS(CFLAG:(LOCAL:0):捕虜先))%に囚われていた%ANAME(LOCAL)%は解放され、放浪した", カラー_注意)
		CALL CHANGE_COUNTRY(LOCAL:0, 0, 1)
	ENDIF
NEXT

;●まず君主について処理する(主人公を含む)
;逃走判定
PRINTFORML ----------君主の逃亡----------
CALL JUDGE_ESCAPE(滅亡君主, 滅亡勢力, 滅ぼした勢力)

;逃走失敗
IF RESULT == 1
	CALL TREAT_PRISONER(滅亡君主, 滅亡勢力, 滅ぼした勢力)
ENDIF


PRINTFORML ----------士官の逃亡----------
;その他士官(主人公は最後)
FOR LOCAL:0, 0, CHARANUM
	SIF CFLAG:LOCAL:所属 != 滅亡勢力 || CFLAG:LOCAL:捕虜先 || LOCAL == 滅亡君主 || LOCAL == MASTER
		CONTINUE
	CALL JUDGE_ESCAPE(LOCAL, 滅亡勢力, 滅ぼした勢力)
	SIF RESULT == 1
		CALL TREAT_PRISONER(LOCAL, 滅亡勢力, 滅ぼした勢力)
NEXT

;滅亡した勢力の捕虜の処理
;滅ぼした側の士官が先
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):捕虜先 == 滅亡勢力 && CFLAG:LOCAL:所属 == 滅ぼした勢力
		CALL CAPTURE(LOCAL:0, 0)
		CALL COLOR_PRINTL(@"%ANAME(滅亡君主)%勢力に囚えられていた%ANAME(LOCAL:0)%は、元の勢力に復帰した", カラー_注意)
	ENDIF
NEXT
;第三勢力の士官なら、滅ぼした側が扱いを決定
FOR LOCAL:0, 0, CHARANUM
	SIF CFLAG:(LOCAL:0):捕虜先 == 滅亡勢力
		CALL TREAT_PRISONER(LOCAL, 滅亡勢力, 滅ぼした勢力)
NEXT

;主人公が士官の場合はラストになる
IF CFLAG:MASTER:所属 == 滅亡勢力 && MASTER != 滅亡君主
	IF CFLAG:MASTER:捕虜先
		CALL CHANGE_COUNTRY(MASTER, 0)
	ELSE
		CALL JUDGE_ESCAPE(MASTER, 滅亡勢力, 滅ぼした勢力)
		SIF RESULT == 1
			CALL TREAT_PRISONER(MASTER, 滅亡勢力, 滅ぼした勢力)
	ENDIF
ENDIF

;これでもなお所属が滅亡勢力のままなら、一気に無所属にする
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):所属 == 滅亡勢力
		CFLAG:(LOCAL:0):所属 = 0
	ENDIF
NEXT

;-------------------------------------------------
;ARG:2番のキャラの、勢力滅亡時の逃走判定(ARG:0=滅亡した勢力、ARG:1=滅亡させた勢力)
;ARG:3……0=戦闘中、1=滅亡時
;-------------------------------------------------
@JUDGE_ESCAPE(対象, 滅亡勢力, 滅ぼした勢力)
#DIM 対象
#DIM 滅亡勢力
#DIM 滅ぼした勢力
#DIM 滅亡君主
#DIM 滅ぼした君主
#DIM 捕縛率


滅亡君主 = GET_COUNTRY_BOSS(滅亡勢力)
滅ぼした君主 = GET_COUNTRY_BOSS(滅ぼした勢力)

;主人公は逃げられない
SIF 対象 == MASTER
	RETURN 1

;主人公勢力が滅ぼし、対象が陥落済み
IF 滅ぼした勢力 == CFLAG:MASTER:所属 && (IS_LOVER(対象) || IS_SLAVE(対象))
	CALL KOJO_EVENT(対象, 331)
	PRINTFORML %ANAME(対象)%は自ら捕縛されにきました
	RETURN 1
;むしろ滅ぼした側の方が好き
ELSEIF REL_LIKE:対象:滅ぼした君主 - REL_LIKE:対象:滅亡君主 > 300 && REL_HATE:対象:滅ぼした君主 - REL_HATE:対象:滅亡君主 < 300
	IF 滅ぼした勢力 == CFLAG:MASTER:所属
		CALL KOJO_EVENT(対象, 331)
		PRINTFORML %ANAME(対象)%は大人しく捕縛されました
	ELSE
		PRINTFORML %ANAME(対象)%は捕らえられたようです…
	ENDIF
	RETURN 1
ENDIF

SELECTCASE CONFIG:306
	CASE 1
		IF 対象 == 滅亡君主
			捕縛率 = 0
		ELSE
			捕縛率 = 2000
		ENDIF
	CASEELSE
		IF 対象 == 滅亡君主
			捕縛率 = 1000
		ELSE
			捕縛率 = 3000
		ENDIF
ENDSELECT

;四能力が高いほど捕縛率への補正が小さくなる（逃げられやすくなる）
捕縛率 += (6000 - (ABL:対象:武闘 * 2 + ABL:対象:防衛 * 2 + ABL:対象:知略 + ABL:対象:政治) * 10)

;部隊にいないと逃げやすい
SIF IS_FREE(対象)
	捕縛率 -= 1000

;イベントキャラは捕まらない
IF IS_SP_CHARA(対象)
	捕縛率 = 0
ELSE
	SELECTCASE CONFIG:306
		CASE 1
			捕縛率 = LIMIT(捕縛率, 0, 6000)
		CASEELSE
			捕縛率 = LIMIT(捕縛率, 2000, 9000)
	ENDSELECT
	SIF IS_SP_COUNTRY(滅ぼした勢力) && 滅ぼした勢力 != CFLAG:MASTER:所属
		捕縛率 = SP_COUNTRY_RANK:SP_COUNTRY_TO_CONST(滅ぼした勢力) * 2000
ENDIF

IF RAND:10000 < 捕縛率
	IF 滅ぼした勢力 == CFLAG:MASTER:所属
		CALL KOJO_EVENT(対象, 331)
		PRINTFORML %ANAME(対象)%を捕縛しました
	ELSE
		PRINTFORML %ANAME(対象)%は捕らえられたようです…
	ENDIF
	RETURN 1
ENDIF

PRINTFORML %ANAME(対象)%は逃走したようです…
```
