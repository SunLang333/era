# SHOP/SHOP_LIFE/SHOP_LIFE11_会いに行く_育児.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE11_会いに行く_育児.ERB`

类型: .ERB

自动摘要: functions: 教育, EDUCATION; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;育児用(ARG=子供 ARG:1=教育者
;-------------------------------------------------
;CFLAG:(ARG:1):教育方針 = 10
@教育(ARG,ARG:1,ARG:2)
VARSET LOCALS
;SIF !ARG:2
;	ARG:2 = CFLAG:(ARG:1):教育方針
SELECTCASE ARG:2
	CASE 10
		LOCAL = GETNUM(ABL, "武闘")
		LOCALS = 武術
	CASE 11
		LOCAL = GETNUM(ABL, "防衛")
		LOCALS = 護身
	CASE 12
		LOCALS = 兵法
		LOCAL = GETNUM(ABL, "知略")
	CASE 13
		LOCALS = 学問
		LOCAL = GETNUM(ABL, "政治")
	CASE 14
		LOCALS = 歌舞
		LOCAL = GETNUM(ABL, "歌唱")
	CASE 15
		LOCALS = 料理
		LOCAL = GETNUM(ABL, "料理")
ENDSELECT
MPLY:0 = ARG:1
MTAR:0 = ARG

FOR LOCAL:1, 0, 5
	CALL COM_SLG_TRAIN_MAIN_PROCESS(LOCAL, 1)
NEXT

PRINTFORMW %ANAME(ARG:1)%は%ANAME(ARG)%に%LOCALS%を教えている…
CALL TRAIN_AUTO_ABLUP(ARG)


@EDUCATION(ARG)
#FUNCTIONS
SELECTCASE ARG
	CASE 10
		LOCALS = 武術
	CASE 11
		LOCALS = 護身
	CASE 12
		LOCALS = 兵法
	CASE 13
		LOCALS = 学問
	CASE 14
		LOCALS = 歌舞
	CASE 15
		LOCALS = 料理
	CASEELSE
		LOCALS = なし
ENDSELECT
RETURNF LOCALS

```
