# 口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_BOTTOM_SOURCE_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_BOTTOM_SOURCE_K9.ERB`

类型: .ERB

自动摘要: functions: MOAN_K9; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●閨_受け_実行前_ソース参照　CALL MOAN_K9(MASTER)
;─────────────────────────────────────── 
@MOAN_K9(咲夜_対象)
#DIM 咲夜
#DIM 咲夜_対象
#DIM 咲夜_今回部位値
#DIM 咲夜_最大部位値
#DIM 咲夜_表示フラグ
#DIMS 咲夜_今回部位
#DIMS 咲夜_最大部位
#DIMS 咲夜_今回部位称
#DIMS 咲夜_最大部位称

IF !咲夜_対象
	咲夜_対象 = MASTER
ENDIF

;初期化
咲夜 = NAME_TO_CHARA("咲夜")
咲夜_今回部位値 = 0
咲夜_最大部位値 = 0
咲夜_表示フラグ = 0
咲夜_今回部位 = ""
咲夜_最大部位 = ""
咲夜_今回部位称 = ""
咲夜_最大部位称 = ""

;─────────────────────────────────────── 
;○咲夜の快楽状態をチェック
;─────────────────────────────────────── 
;▼SOURCE
;　前文の場合SOURCE・後文ならCUP・値は最大部位値との比較用なのでPALAMで保存
;　最低1ないと刺激とみなさないPALAMには快Ｐがない
IF SOURCE:咲夜:快Ｖ >= 1 && SOURCE:咲夜:快Ｖ >= SOURCE:咲夜:快Ｐ && SOURCE:咲夜:快Ｖ >= SOURCE:咲夜:快Ｃ && SOURCE:咲夜:快Ｖ >= SOURCE:咲夜:快Ａ && SOURCE:咲夜:快Ｖ >= SOURCE:咲夜:快Ｂ
	咲夜_今回部位値 = PALAM:咲夜:快Ｖ
	咲夜_今回部位 '= "Ｖ"
	咲夜_今回部位称 '= CALL_DIRTY_K9("Ｖ")
ELSEIF SOURCE:咲夜:快Ａ >= 1 && SOURCE:咲夜:快Ａ >= SOURCE:咲夜:快Ｐ && SOURCE:咲夜:快Ａ >= SOURCE:咲夜:快Ｃ && SOURCE:咲夜:快Ａ >= SOURCE:咲夜:快Ｖ && SOURCE:咲夜:快Ａ >= SOURCE:咲夜:快Ｂ
	咲夜_今回部位値 = PALAM:咲夜:快Ａ
	咲夜_今回部位 '= "Ａ"
	咲夜_今回部位称 '= CALL_DIRTY_K9("Ａ")
ELSEIF SOURCE:咲夜:快Ｐ >= 1 && SOURCE:咲夜:快Ｐ >= SOURCE:咲夜:快Ｖ && SOURCE:咲夜:快Ｐ >= SOURCE:咲夜:快Ａ && SOURCE:咲夜:快Ｐ >= SOURCE:咲夜:快Ｃ && SOURCE:咲夜:快Ｐ >= SOURCE:咲夜:快Ｂ
	咲夜_今回部位値 = PALAM:咲夜:快Ｃ
	咲夜_今回部位 '= "Ｐ"
	咲夜_今回部位称 '= CALL_DIRTY_K9("Ｐ")
ELSEIF SOURCE:咲夜:快Ｃ >= 1 && SOURCE:咲夜:快Ｃ >= SOURCE:咲夜:快Ｐ && SOURCE:咲夜:快Ｃ >= SOURCE:咲夜:快Ｖ && SOURCE:咲夜:快Ｃ >= SOURCE:咲夜:快Ａ && SOURCE:咲夜:快Ｃ >= SOURCE:咲夜:快Ｂ
	IF HAS_PENIS(咲夜)
		咲夜_今回部位値 = PALAM:咲夜:快Ｃ
		咲夜_今回部位 '= "Ｐ"
		咲夜_今回部位称 '= CALL_DIRTY_K9("Ｐ")
	ELSE
		咲夜_今回部位値 = PALAM:咲夜:快Ｃ
		咲夜_今回部位 '= "Ｃ"
		咲夜_今回部位称 '= CALL_DIRTY_K9("Ｃ")
	ENDIF
ELSEIF SOURCE:咲夜:快Ｂ >= 1 && SOURCE:咲夜:快Ｂ >= SOURCE:咲夜:快Ｐ && SOURCE:咲夜:快Ｂ >= SOURCE:咲夜:快Ｃ && SOURCE:咲夜:快Ｂ >= SOURCE:咲夜:快Ｖ && SOURCE:咲夜:快Ｂ >= SOURCE:咲夜:快Ａ
	咲夜_今回部位値 = PALAM:咲夜:快Ｂ
	咲夜_今回部位 '= "Ｂ"
	咲夜_今回部位称 '= CALL_DIRTY_K9("Ｂ")
ELSE
	咲夜_今回部位値 = 0
	咲夜_今回部位 '= ""
	咲夜_今回部位称 '= ""
ENDIF

;▼PALAM
;　PALAMは絶頂までの蓄積＆絶頂により落ち着く（LIMIT9999）
;　最低10ないと刺激とみなさないPALAMには快Ｐがない
IF PALAM:咲夜:快Ｖ >= 10 && PALAM:咲夜:快Ｖ >= PALAM:咲夜:快Ｃ && PALAM:咲夜:快Ｖ >= PALAM:咲夜:快Ａ && PALAM:咲夜:快Ｖ >= PALAM:咲夜:快Ｂ
	咲夜_最大部位値 = PALAM:咲夜:快Ｖ
	咲夜_最大部位 '= "Ｖ"
	咲夜_最大部位称 '= CALL_DIRTY_K9("Ｖ")
ELSEIF PALAM:咲夜:快Ａ >= 10 && PALAM:咲夜:快Ａ >= PALAM:咲夜:快Ｃ && PALAM:咲夜:快Ａ >= PALAM:咲夜:快Ｖ && PALAM:咲夜:快Ａ >= PALAM:咲夜:快Ｂ
	咲夜_最大部位値 = PALAM:咲夜:快Ａ
	咲夜_最大部位 '= "Ａ"
	咲夜_最大部位称 '= CALL_DIRTY_K9("Ａ")
ELSEIF PALAM:咲夜:快Ｃ >= 10 && PALAM:咲夜:快Ｃ >= PALAM:咲夜:快Ｖ && PALAM:咲夜:快Ｃ >= PALAM:咲夜:快Ａ && PALAM:咲夜:快Ｃ >= PALAM:咲夜:快Ｂ
	IF HAS_PENIS(咲夜)
		咲夜_最大部位値 = PALAM:咲夜:快Ｃ
		咲夜_最大部位 '= "Ｐ"
		咲夜_最大部位称 '= CALL_DIRTY_K9("Ｐ")
	ELSE
		咲夜_最大部位値 = PALAM:咲夜:快Ｃ
		咲夜_最大部位 '= "Ｃ"
		咲夜_最大部位称 '= CALL_DIRTY_K9("Ｃ")
	ENDIF
ELSEIF PALAM:咲夜:快Ｂ >= 10 && PALAM:咲夜:快Ｂ >= PALAM:咲夜:快Ｃ && PALAM:咲夜:快Ｂ >= PALAM:咲夜:快Ｖ && PALAM:咲夜:快Ｂ >= PALAM:咲夜:快Ａ
	咲夜_最大部位値 = PALAM:咲夜:快Ｂ
	咲夜_最大部位 '= "Ｂ"
	咲夜_最大部位称 '= CALL_DIRTY_K9("Ｂ")
ELSE
	咲夜_最大部位値 = 0
	咲夜_最大部位 '= ""
	咲夜_最大部位称 '= ""
ENDIF

;─────────────────────────────────────── 
;○台詞１_咲夜の失神疲労
;─────────────────────────────────────── 
;主導権がない
IF !IS_INITIATIVE(咲夜)
	;▼体力
	IF BASE:咲夜:体力 <= (MAXBASE:咲夜:体力 / 3)
		PRINT 「
		PRINTDATA
			DATAFORM はぁ……はぁ
			DATAFORM んぅ……う
			DATAFORM はっ、あぁ
			DATAFORM ふ……ぁ、は
			DATAFORM も、はぁ……はぁ
			DATAFORM う、く……はぁ
			DATAFORM 体が……疲れてぇ
			DATAFORM もう……はぁ、はぁ
			DATAFORM も、疲れて、あ、あ
			DATAFORM もう、体が……つら……い、わ
			DATAFORM もうぅ……はぁ、はぁ
			DATAFORM 息がぁ、苦しい……わ
			DATAFORM 頭がぼうっと……する、わ
			DATAFORM からだがぁ……動かない、わ
			DATAFORM んく、けふっ
		ENDDATA
		PRINTFORM %BREAK_K9("中", 咲夜_対象)%
		PRINTDATA
			DATAFORM は、ふ
			DATAFORM はぁっ
			DATAFORM 休ませてぇ
			DATAFORM あたまがぁ……も
			DATAFORM はぁ、んぅ
			DATAFORM 少し、休み……た
			DATAFORM 限界、よぉ
			DATAFORM はぁ……あ、ひぃ
			DATAFORM ふ、あ。は
		ENDDATA
		PRINTFORML %BREAK_K9("末", 咲夜_対象)%」

	;▼気力
	ELSEIF BASE:咲夜:気力 <= (MAXBASE:咲夜:気力 / 3)
		PRINT 「
		PRINTDATA
			DATAFORM はぁ……はぁ
			DATAFORM んぅ、つら……いわ
			DATAFORM 気持ち……よくぇ
			DATAFORM ふ……ぁ、は
			DATAFORM も、あめ……はぁ
			DATAFORM う、く……はぁ
			DATAFORM いき……過ぎてぇ
			DATAFORM もう……はぁ、はぁ
			DATAFORM も、感じ疲れて、あ、あ
			DATAFORM もう、体が……つら……い、わ
			DATAFORM もうぅ……はぁ、はぁ
			DATAFORM 息がぁ、苦しい……わ
			DATAFORM ひぅ……あ、はぁ
			DATAFORM からだがぁ……動かない、わ
			DATAFORM んく、けふっ
		ENDDATA
		PRINTFORM %BREAK_K9("中", 咲夜_対象)%
		PRINTDATA
			DATAFORM は、ふ
			DATAFORM はぁっ
			DATAFORM 休ませてぇ
			DATAFORM あたまがぁ……もぉ
			DATAFORM はぁ、んぅ
			DATAFORM 少しぃ、休ま……せ、ん
			DATAFORM 限界、よぉ
			DATAFORM はぁ……あ、ひぃ
			DATAFORM ふあぁ……ん
		ENDDATA
		PRINTFORML %BREAK_K9("末", 咲夜_対象)%」
	ENDIF
ENDIF

;─────────────────────────────────────── 
;○台詞２_ソースに関して
;─────────────────────────────────────── 
咲夜_表示フラグ = 0
;フィスト・イラマ・タトゥー・首絞め・腹パン・鞭などの強苦痛
IF SOURCE:咲夜:苦痛 >= 100
	咲夜_表示フラグ += 1
	IF 咲夜_表示フラグ == 1
		PRINTFORM 「
	ELSEIF 咲夜_表示フラグ > 3
		PRINTFORML %BREAK_K9("末", 咲夜_対象)%」
		PRINTFORM 「
	ELSE
		PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	ENDIF
	PRINTDATA
		DATAFORM あぐうぅ
		DATAFORM うあぁぁぁ――ぁあ
		DATAFORM ひぁぁあぁ
		DATAFORM ひいぃ
		DATAFORM ひぐぅっ、うぅ
		DATAFORM うくう……っ！　あ、ぐ
		DATAFORM ああぁ――っ！　う、ぁ
	ENDDATA
;縄やスパンキングなどの苦痛
ELSEIF SOURCE:咲夜:苦痛 >= 10
	咲夜_表示フラグ += 1
	IF 咲夜_表示フラグ == 1
```
