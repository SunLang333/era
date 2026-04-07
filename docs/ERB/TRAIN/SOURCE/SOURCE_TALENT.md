# TRAIN/SOURCE/SOURCE_TALENT.ERB — 自动生成文档

源文件: `ERB/TRAIN/SOURCE/SOURCE_TALENT.ERB`

类型: .ERB

自动摘要: functions: UP_TALENT_CHECK1, UP_TALENT_CHECK2, UP_TALENT_CHECK3, YOKUATSU_RATE, KOKOU_RATE, SET_RATE_EMOTION

前 200 行源码片段:

```text
﻿;SOURCE_CHECKで使用する関数(TALENT系)

;-------------------------------------------------
;素質などによるパラメータ上昇の補正(快楽系)
;-------------------------------------------------
@UP_TALENT_CHECK1(ARG:0)
IF TALENT:(ARG:0):自制心 && !GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_淫乱)
	IF !IS_FALLEN(ARG:0)
		TIMES CUP:(ARG:0):快Ｃ, 0.75
		TIMES CUP:(ARG:0):快Ｖ, 0.70
		TIMES CUP:(ARG:0):快Ａ, 0.80
		TIMES CUP:(ARG:0):快Ｂ, 0.60
		TIMES CUP:(ARG:0):快Ｍ, 0.80
		TIMES CUP:(ARG:0):快Ｕ, 0.80
	ENDIF
ENDIF

;機嫌の影響
SELECTCASE TOSTR_EMOTION(ARG:0)
	CASE "幸"
		TIMES CUP:(ARG:0):快Ｃ, 1.30
		TIMES CUP:(ARG:0):快Ｖ, 1.30
		TIMES CUP:(ARG:0):快Ａ, 1.30
		TIMES CUP:(ARG:0):快Ｂ, 1.30
		TIMES CUP:(ARG:0):快Ｍ, 1.30
		TIMES CUP:(ARG:0):快Ｕ, 1.30
	CASE "悦"
		TIMES CUP:(ARG:0):快Ｃ, 1.20
		TIMES CUP:(ARG:0):快Ｖ, 1.20
		TIMES CUP:(ARG:0):快Ａ, 1.20
		TIMES CUP:(ARG:0):快Ｂ, 1.20
		TIMES CUP:(ARG:0):快Ｍ, 1.20
		TIMES CUP:(ARG:0):快Ｕ, 1.20
	CASE "良"
		TIMES CUP:(ARG:0):快Ｃ, 1.10
		TIMES CUP:(ARG:0):快Ｖ, 1.10
		TIMES CUP:(ARG:0):快Ａ, 1.10
		TIMES CUP:(ARG:0):快Ｂ, 1.10
		TIMES CUP:(ARG:0):快Ｍ, 1.10
		TIMES CUP:(ARG:0):快Ｕ, 1.10
	CASE "恨"
	CASE "怒"
	CASE "憤"
	CASE "鬱"
		TIMES CUP:(ARG:0):快Ｃ, 0.60
		TIMES CUP:(ARG:0):快Ｖ, 0.60
		TIMES CUP:(ARG:0):快Ａ, 0.60
		TIMES CUP:(ARG:0):快Ｂ, 0.60
		TIMES CUP:(ARG:0):快Ｍ, 0.60
		TIMES CUP:(ARG:0):快Ｕ, 0.60
	CASE "悲"
		TIMES CUP:(ARG:0):快Ｃ, 0.75
		TIMES CUP:(ARG:0):快Ｖ, 0.75
		TIMES CUP:(ARG:0):快Ａ, 0.75
		TIMES CUP:(ARG:0):快Ｂ, 0.75
		TIMES CUP:(ARG:0):快Ｍ, 0.75
		TIMES CUP:(ARG:0):快Ｕ, 0.75
	CASE "憂"
		TIMES CUP:(ARG:0):快Ｃ, 0.80
		TIMES CUP:(ARG:0):快Ｖ, 0.80
		TIMES CUP:(ARG:0):快Ａ, 0.80
		TIMES CUP:(ARG:0):快Ｂ, 0.80
		TIMES CUP:(ARG:0):快Ｍ, 0.80
		TIMES CUP:(ARG:0):快Ｕ, 0.80
	CASE "狂"
	CASE "恐"
	CASE "怯"
	CASE "壊"
		TIMES CUP:(ARG:0):快Ｃ, 0.50
		TIMES CUP:(ARG:0):快Ｖ, 0.50
		TIMES CUP:(ARG:0):快Ａ, 0.50
		TIMES CUP:(ARG:0):快Ｂ, 0.50
		TIMES CUP:(ARG:0):快Ｍ, 0.50
		TIMES CUP:(ARG:0):快Ｕ, 0.50
	CASE "虚"
		TIMES CUP:(ARG:0):快Ｃ, 0.85
		TIMES CUP:(ARG:0):快Ｖ, 0.85
		TIMES CUP:(ARG:0):快Ａ, 0.85
		TIMES CUP:(ARG:0):快Ｂ, 0.85
		TIMES CUP:(ARG:0):快Ｍ, 0.85
		TIMES CUP:(ARG:0):快Ｕ, 0.85
ENDSELECT

;男性・男の娘
IF !HAS_VAGINA(ARG:0)
	TIMES CUP:(ARG:0):快Ａ, 1.20
ENDIF

;目隠し
IF IS_EQUIP_TARGET(ARG:0, 84)
	TIMES CUP:(ARG:0):快Ｃ, 1.10
	TIMES CUP:(ARG:0):快Ｖ, 1.10
	TIMES CUP:(ARG:0):快Ａ, 1.10
	TIMES CUP:(ARG:0):快Ｂ, 1.10
	TIMES CUP:(ARG:0):快Ｍ, 1.10
	TIMES CUP:(ARG:0):快Ｕ, 1.10
ENDIF

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_浮気癖)
	IF ((IS_MPLY(MASTER) && IS_MTAR(ARG:0)) || (IS_MPLY(ARG:0) && IS_MTAR(MASTER)))
		TIMES CUP:(ARG:0):快Ｃ, 0.7
		TIMES CUP:(ARG:0):快Ｖ, 0.7
		TIMES CUP:(ARG:0):快Ａ, 0.7
		TIMES CUP:(ARG:0):快Ｂ, 0.7
		TIMES CUP:(ARG:0):快Ｍ, 0.7
		TIMES CUP:(ARG:0):快Ｕ, 0.7
	ELSE
		TIMES CUP:(ARG:0):快Ｃ, 1.15
		TIMES CUP:(ARG:0):快Ｖ, 1.15
		TIMES CUP:(ARG:0):快Ａ, 1.15
		TIMES CUP:(ARG:0):快Ｂ, 1.15
		TIMES CUP:(ARG:0):快Ｍ, 1.15
		TIMES CUP:(ARG:0):快Ｕ, 1.15
	ENDIF
ENDIF

;-------------------------------------------------
;素質などによるパラメータ上昇の補正(快楽系以外)
;-------------------------------------------------
@UP_TALENT_CHECK2(ARG:0)
;TRAINの外で欲情がリセットされないままこの関数が呼び出されたことでオーバーフローの可能性があった
;機嫌系を別関数に切り出してこっちから呼び出す

IF TALENT:(ARG:0):反抗的
	TIMES CUP:(ARG:0):欲情, 0.70
ENDIF

IF TALENT:(ARG:0):気丈
	TIMES CUP:(ARG:0):欲情, 0.8
ENDIF

IF TALENT:(ARG:0):大人しい
	TIMES CUP:(ARG:0):欲情, 0.8
ENDIF

IF TALENT:(ARG:0):無関心
	TIMES CUP:(ARG:0):欲情, 0.7
ENDIF

IF TALENT:(ARG:0):感情乏しい
	TIMES CUP:(ARG:0):欲情, 0.7
ENDIF

IF TALENT:(ARG:0):抑圧
	CUP:(ARG:0):欲情 = CUP:(ARG:0):欲情 * (125 - YOKUATSU_RATE(ARG:0)) / 125
ENDIF

IF TALENT:(ARG:0):解放
	TIMES CUP:(ARG:0):欲情, 1.5
ENDIF

IF TALENT:(ARG:0):孤高
	TIMES CUP:(ARG:0):欲情, 0.80
ENDIF

SIF TALENT:(ARG:0):快感に素直
	TIMES CUP:(ARG:0):欲情, 1.8
SIF TALENT:(ARG:0):快感の否定
	TIMES CUP:(ARG:0):欲情, 0.7

IF GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_浮気癖)
	IF ((IS_MPLY(MASTER) && IS_MTAR(ARG:0)) || (IS_MPLY(ARG:0) && IS_MTAR(MASTER)))
		TIMES CUP:(ARG:0):欲情, 0.8
	ELSE
		TIMES CUP:(ARG:0):欲情, 1.5
	ENDIF
ENDIF


;機嫌の影響
SELECTCASE TOSTR_EMOTION(ARG:0)
	CASE "幸"
		TIMES CUP:(ARG:0):欲情, 1.15
	CASE "悦"
		TIMES CUP:(ARG:0):欲情, 1.10
	CASE "良"
		TIMES CUP:(ARG:0):欲情, 1.05
	CASE "恨"
	CASE "怒"
	CASE "憤"
	CASE "鬱"
		TIMES CUP:(ARG:0):欲情, 0.30
	CASE "悲"
		TIMES CUP:(ARG:0):欲情, 0.60
	CASE "憂"
		TIMES CUP:(ARG:0):欲情, 0.80
	CASE "狂"
	CASE "恐"
	CASE "怯"
	CASE "壊"
		TIMES CUP:(ARG:0):欲情, 0.20
	CASE "虚"
		TIMES CUP:(ARG:0):欲情, 0.60
ENDSELECT

;機嫌系を後から呼び出す
CALL UP_TALENT_CHECK3(ARG:0)


;素質などによるパラメータ上昇の補正(機嫌系)
```
