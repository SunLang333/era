# SYSTEM/SHOW_INFO/SHOW_INFO_DESCRIPTION_EACH.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SHOW_INFO/SHOW_INFO_DESCRIPTION_EACH.ERB`

类型: .ERB

自动摘要: functions: SHOW_INFO_DESCRIPTION_SENSE, SHOW_INFO_ERO_DESCRIPTION_0, SHOW_INFO_ERO_DESCRIPTION_1, SHOW_INFO_ERO_DESCRIPTION_2, SHOW_INFO_ERO_DESCRIPTION_3, SHOW_INFO_ERO_DESCRIPTION_4, SHOW_INFO_ERO_DESCRIPTION_5, SHOW_INFO_ERO_DESCRIPTION_12, SHOW_INFO_ERO_DESCRIPTION_13, SHOW_INFO_ERO_DESCRIPTION_14, SHOW_INFO_ERO_DESCRIPTION_20, SHOW_INFO_ERO_DESCRIPTION_21, SHOW_INFO_ERO_DESCRIPTION_22, SHOW_INFO_ERO_DESCRIPTION_23, SHOW_INFO_ERO_DESCRIPTION_24, SHOW_INFO_ERO_DESCRIPTION_25, SHOW_INFO_ERO_DESCRIPTION_26, SHOW_INFO_ERO_DESCRIPTION_27, SHOW_INFO_ERO_DESCRIPTION_28, SHOW_INFO_ERO_DESCRIPTION_29; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;感覚用汎用
;-------------------------------------------------
@SHOW_INFO_DESCRIPTION_SENSE(文字列, 数値)
#DIMS 文字列
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_B
		PRINTFORML 開発された%文字列%はかなり敏感になっており、明らかな弱点になっている
	CASE IS >= ランク閾値:ランク_その他:ランク_C
		PRINTFORML %文字列%はかなり開発され、ずいぶん敏感になっている
	CASE IS >= ランク閾値:ランク_その他:ランク_D
		PRINTFORML %文字列%で明確に感じるようになったようだ
	CASE IS >= ランク閾値:ランク_その他:ランク_E
		PRINTFORML %文字列%で人並みに感じるようだ
	CASE IS >= ランク閾値:ランク_その他:ランク_F
		PRINTFORML %文字列%で感じ始めたようだ
	CASE IS >= ランク閾値:ランク_その他:ランク_G
		PRINTFORML %文字列%ではあまり感じないようだ
	CASEELSE
ENDSELECT

;-------------------------------------------------
;Ｃ感覚
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_0(対象, 数値)
#DIM 対象
#DIM 数値
LOCALS = \@ IS_MALE(対象) ? ペニス # 秘核 \@
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML %LOCALS%は風が吹いただけで絶頂してしまうほど敏感になっている
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 開発されきった%LOCALS%は、指で軽く触れただけで達するほど敏感だ
	CASEELSE
		CALL SHOW_INFO_DESCRIPTION_SENSE(LOCALS, 数値)
ENDSELECT

;-------------------------------------------------
;Ｖ感覚
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_1(対象, 数値)
#DIM 対象
#DIM 数値
SIF !HAS_VAGINA(対象)
	RETURN 0
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML 女穴は常に快感を求めて疼き、涎を垂れ流している
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 開発されきった女穴は、指で軽く触れただけで達するほど敏感だ
	CASEELSE
		CALL SHOW_INFO_DESCRIPTION_SENSE("女穴", 数値)
ENDSELECT

;-------------------------------------------------
;Ａ感覚
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_2(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML 菊穴は常に快感を求めて疼く、貪欲な性器に作り替えられている
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 開発されきった菊穴は、指で軽くほじくっただけで達するほど敏感だ
	CASEELSE
		CALL SHOW_INFO_DESCRIPTION_SENSE("菊穴", 数値)
ENDSELECT

;-------------------------------------------------
;Ｂ感覚
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_3(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML 乳房は風が吹いただけで絶頂してしまうほど敏感になっている
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 開発されきった乳房の先端は、いつでも快楽を期待し尖っている
	CASEELSE
		CALL SHOW_INFO_DESCRIPTION_SENSE("乳房", 数値)
ENDSELECT

;-------------------------------------------------
;Ｍ感覚
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_4(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML 口は性器として生まれ変わり、その感度は食事が困難なほどだ
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 開発されきった唇は、バードキスですら絶頂するほど敏感だ
	CASEELSE
		CALL SHOW_INFO_DESCRIPTION_SENSE("唇", 数値)
ENDSELECT

;-------------------------------------------------
;Ｕ感覚
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_5(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML  尿道は性感帯として生まれ変わり、排尿の刺激ですら絶頂するほどだ
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML  開発されきった尿道は、完全に快楽を生み出す器官に変化した
	CASEELSE
		CALL SHOW_INFO_DESCRIPTION_SENSE("尿道", 数値)
ENDSELECT

;-------------------------------------------------
;欲望
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_12(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML 淫らな欲望が頭を支配し、いつでも快楽を求めている
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 淫乱というに足るほど欲深く、快楽を望んでいる
	CASE IS >= ランク閾値:ランク_その他:ランク_B
		PRINTFORML 淫らな行為にすっかり抵抗がなくなっている
	CASE IS >= ランク閾値:ランク_その他:ランク_C
		PRINTFORML 淫らな行為にもだいぶ慣れたようだ
ENDSELECT

;-------------------------------------------------
;性技
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_13(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML その技巧は神と呼んでもよいほどのものだ
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 巧みな技術は、誰が相手でも骨抜きにしてしまうほどだ
	CASE IS >= ランク閾値:ランク_その他:ランク_B
		PRINTFORML そこらの娼婦にも劣らない技術を身につけている
	CASE IS >= ランク閾値:ランク_その他:ランク_C
		PRINTFORML 性技がだいぶ身についてきたようだ
ENDSELECT

;-------------------------------------------------
;性知識
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_14(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_性知識:ランク_S
		PRINTFORML 性の世界の知識を極めている
	CASE IS >= ランク閾値:ランク_性知識:ランク_A
		PRINTFORML 性のことについて、ニッチな技まで知っている
	CASE IS >= ランク閾値:ランク_性知識:ランク_B
		PRINTFORML 性のことについて詳しい
	CASE IS >= ランク閾値:ランク_性知識:ランク_C
		PRINTFORML 人並みの性知識を身につけている
	CASE IS >= ランク閾値:ランク_性知識:ランク_D
		PRINTFORML 性知識はやや薄い
	CASEELSE
		PRINTFORML 性のことなどなにもわかっていない
ENDSELECT

;-------------------------------------------------
;奉仕
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_20(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML 己は他者に奉仕するためにあると考えているほどだ
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 他人への奉仕を何にも代えがたい悦びと考えている
	CASE IS >= ランク閾値:ランク_その他:ランク_B
		PRINTFORML 他人への奉仕が気に入っている
	CASE IS >= ランク閾値:ランク_その他:ランク_C
		PRINTFORML 他人への奉仕に快感を覚えている
ENDSELECT

;-------------------------------------------------
;性交
;-------------------------------------------------
@SHOW_INFO_ERO_DESCRIPTION_21(対象, 数値)
#DIM 対象
#DIM 数値
SELECTCASE 数値
	CASE IS >= ランク閾値:ランク_その他:ランク_S
		PRINTFORML 性交なしでは生きていられない
	CASE IS >= ランク閾値:ランク_その他:ランク_A
		PRINTFORML 四六時中、性交のことを考えている
	CASE IS >= ランク閾値:ランク_その他:ランク_B
		PRINTFORML 性交の快楽に溺れつつある
```
