# 口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_BOTTOM_SOURCE_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_BOTTOM_SOURCE_K10.ERB`

类型: .ERB

自动摘要: functions: MOAN_K10; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●閨_受け_実行前_ソース参照　CALL MOAN_K10(レミリア_対象)
;─────────────────────────────────────── 
@MOAN_K10(レミリア_対象)
#DIM レミリア
#DIM レミリア_対象
#DIM レミリア_今回部位値
#DIM レミリア_最大部位値
#DIM レミリア_表示フラグ
#DIMS レミリア_今回部位
#DIMS レミリア_最大部位
#DIMS レミリア_今回部位称
#DIMS レミリア_最大部位称

IF !レミリア_対象
	レミリア_対象 = MASTER
ENDIF

;初期化
レミリア = NAME_TO_CHARA("レミリア")
レミリア_今回部位値 = 0
レミリア_最大部位値 = 0
レミリア_表示フラグ = 0
レミリア_今回部位 = ""
レミリア_最大部位 = ""
レミリア_今回部位称 = ""
レミリア_最大部位称 = ""

;─────────────────────────────────────── 
;○レミリアの快楽状態をチェック
;─────────────────────────────────────── 
;▼SOURCE
;　前文の場合SOURCE・後文ならCUP・値は最大部位値との比較用なのでPALAMで保存
;　最低1ないと刺激とみなさないPALAMには快Ｐがない
IF SOURCE:レミリア:快Ｖ >= 1 && SOURCE:レミリア:快Ｖ >= SOURCE:レミリア:快Ｐ && SOURCE:レミリア:快Ｖ >= SOURCE:レミリア:快Ｃ && SOURCE:レミリア:快Ｖ >= SOURCE:レミリア:快Ａ && SOURCE:レミリア:快Ｖ >= SOURCE:レミリア:快Ｂ
	レミリア_今回部位値 = PALAM:レミリア:快Ｖ
	レミリア_今回部位 '= "Ｖ"
	レミリア_今回部位称 '= CALL_DIRTY_K10("Ｖ")
ELSEIF SOURCE:レミリア:快Ａ >= 1 && SOURCE:レミリア:快Ａ >= SOURCE:レミリア:快Ｐ && SOURCE:レミリア:快Ａ >= SOURCE:レミリア:快Ｃ && SOURCE:レミリア:快Ａ >= SOURCE:レミリア:快Ｖ && SOURCE:レミリア:快Ａ >= SOURCE:レミリア:快Ｂ
	レミリア_今回部位値 = PALAM:レミリア:快Ａ
	レミリア_今回部位 '= "Ａ"
	レミリア_今回部位称 '= CALL_DIRTY_K10("Ａ")
ELSEIF SOURCE:レミリア:快Ｐ >= 1 && SOURCE:レミリア:快Ｐ >= SOURCE:レミリア:快Ｖ && SOURCE:レミリア:快Ｐ >= SOURCE:レミリア:快Ａ && SOURCE:レミリア:快Ｐ >= SOURCE:レミリア:快Ｃ && SOURCE:レミリア:快Ｐ >= SOURCE:レミリア:快Ｂ
	レミリア_今回部位値 = PALAM:レミリア:快Ｃ
	レミリア_今回部位 '= "Ｐ"
	レミリア_今回部位称 '= CALL_DIRTY_K10("Ｐ")
ELSEIF SOURCE:レミリア:快Ｃ >= 1 && SOURCE:レミリア:快Ｃ >= SOURCE:レミリア:快Ｐ && SOURCE:レミリア:快Ｃ >= SOURCE:レミリア:快Ｖ && SOURCE:レミリア:快Ｃ >= SOURCE:レミリア:快Ａ && SOURCE:レミリア:快Ｃ >= SOURCE:レミリア:快Ｂ
	IF HAS_PENIS(レミリア)
		レミリア_今回部位値 = PALAM:レミリア:快Ｃ
		レミリア_今回部位 '= "Ｐ"
		レミリア_今回部位称 '= CALL_DIRTY_K10("Ｐ")
	ELSE
		レミリア_今回部位値 = PALAM:レミリア:快Ｃ
		レミリア_今回部位 '= "Ｃ"
		レミリア_今回部位称 '= CALL_DIRTY_K10("Ｃ")
	ENDIF
ELSEIF SOURCE:レミリア:快Ｂ >= 1 && SOURCE:レミリア:快Ｂ >= SOURCE:レミリア:快Ｐ && SOURCE:レミリア:快Ｂ >= SOURCE:レミリア:快Ｃ && SOURCE:レミリア:快Ｂ >= SOURCE:レミリア:快Ｖ && SOURCE:レミリア:快Ｂ >= SOURCE:レミリア:快Ａ
	レミリア_今回部位値 = PALAM:レミリア:快Ｂ
	レミリア_今回部位 '= "Ｂ"
	レミリア_今回部位称 '= CALL_DIRTY_K10("Ｂ")
ELSE
	レミリア_今回部位値 = 0
	レミリア_今回部位 '= ""
	レミリア_今回部位称 '= ""
ENDIF

;▼PALAM
;　PALAMは絶頂までの蓄積＆絶頂により落ち着く（LIMIT9999）
;　最低10ないと刺激とみなさないPALAMには快Ｐがない
IF PALAM:レミリア:快Ｖ >= 10 && PALAM:レミリア:快Ｖ >= PALAM:レミリア:快Ｃ && PALAM:レミリア:快Ｖ >= PALAM:レミリア:快Ａ && PALAM:レミリア:快Ｖ >= PALAM:レミリア:快Ｂ
	レミリア_最大部位値 = PALAM:レミリア:快Ｖ
	レミリア_最大部位 '= "Ｖ"
	レミリア_最大部位称 '= CALL_DIRTY_K10("Ｖ")
ELSEIF PALAM:レミリア:快Ａ >= 10 && PALAM:レミリア:快Ａ >= PALAM:レミリア:快Ｃ && PALAM:レミリア:快Ａ >= PALAM:レミリア:快Ｖ && PALAM:レミリア:快Ａ >= PALAM:レミリア:快Ｂ
	レミリア_最大部位値 = PALAM:レミリア:快Ａ
	レミリア_最大部位 '= "Ａ"
	レミリア_最大部位称 '= CALL_DIRTY_K10("Ａ")
ELSEIF PALAM:レミリア:快Ｃ >= 10 && PALAM:レミリア:快Ｃ >= PALAM:レミリア:快Ｖ && PALAM:レミリア:快Ｃ >= PALAM:レミリア:快Ａ && PALAM:レミリア:快Ｃ >= PALAM:レミリア:快Ｂ
	IF HAS_PENIS(レミリア)
		レミリア_最大部位値 = PALAM:レミリア:快Ｃ
		レミリア_最大部位 '= "Ｐ"
		レミリア_最大部位称 '= CALL_DIRTY_K10("Ｐ")
	ELSE
		レミリア_最大部位値 = PALAM:レミリア:快Ｃ
		レミリア_最大部位 '= "Ｃ"
		レミリア_最大部位称 '= CALL_DIRTY_K10("Ｃ")
	ENDIF
ELSEIF PALAM:レミリア:快Ｂ >= 10 && PALAM:レミリア:快Ｂ >= PALAM:レミリア:快Ｃ && PALAM:レミリア:快Ｂ >= PALAM:レミリア:快Ｖ && PALAM:レミリア:快Ｂ >= PALAM:レミリア:快Ａ
	レミリア_最大部位値 = PALAM:レミリア:快Ｂ
	レミリア_最大部位 '= "Ｂ"
	レミリア_最大部位称 '= CALL_DIRTY_K10("Ｂ")
ELSE
	レミリア_最大部位値 = 0
	レミリア_最大部位 '= ""
	レミリア_最大部位称 '= ""
ENDIF

;─────────────────────────────────────── 
;○台詞１_レミリアの失神疲労
;─────────────────────────────────────── 
;主導権がない
IF !IS_INITIATIVE(レミリア)
	;体力
	IF BASE:レミリア:体力 <= (MAXBASE:レミリア:体力 / 3)
		PRINT 「
		PRINTDATA
			DATAFORM はふっ……んんぅ
			DATAFORM 疲れちゃったの
			DATAFORM はあ、ふ
			DATAFORM ねえ、力が入らないわ
			DATAFORM 私のほうが先に体力がなくなっちゃったの？　驚いたわ
			DATAFORM うー……はふ、う
			DATAFORM んぅ……疲れたわ
			DATAFORM はあはあ……ちょっと疲れたみたい
		ENDDATA
		PRINTFORM %BREAK_K10("中", レミリア_対象)%
		PRINTDATA
			DATAFORM 少し休むわね
			DATAFORM 休みたいわ
			DATAFORM はあはあ
			DATAFORM はあ、んぅ
			DATAFORM 休憩しましょ
			DATAFORM はふ
			DATAFORM ねぇ、休みましょ
			DATAFORM ん。はあ、ふ
		ENDDATA
		PRINTFORML %BREAK_K10("末", レミリア_対象)%」

	;気力
	ELSEIF BASE:レミリア:気力 <= (MAXBASE:レミリア:気力 / 3)
		PRINT 「
		PRINTDATA
			DATAFORM ちょっと叫び過ぎたかしら……けふ
			DATAFORM ふわふわ、するわ
			DATAFORM これなあに……指先までじいんって
			DATAFORM ふあぁあぁ……んぅ
			DATAFORM いきすぎたみたいぃ……戻ってこれないわ
			DATAFORM 深い……のぉ、気持ちいいのが引かないわ
		ENDDATA
		PRINTFORM %BREAK_K10("中", レミリア_対象)%
		PRINTDATA
			DATAFORM はあ、ふぁ
			DATAFORM 休むぅ
			DATAFORM だんだん、よくわから――な、くぅ
			DATAFORM ひゃう……あ❤　は
			DATAFORM ふあぁん
		ENDDATA
		PRINTFORML %BREAK_K10("末", レミリア_対象)%」
	ENDIF
ENDIF

;─────────────────────────────────────── 
;○台詞２_ソースに関して
;　覚書：解消は会話のみ・感応は猥談本屋のみ
;─────────────────────────────────────── 
レミリア_表示フラグ = 0
;フィスト・イラマ・タトゥー・首絞め・腹パン・鞭などの強苦痛（痛みに強い）
IF SOURCE:レミリア:苦痛 >= 100
	レミリア_表示フラグ += 1
	IF レミリア_表示フラグ == 1
		PRINTFORM 「
	ELSEIF レミリア_表示フラグ > 3
		PRINTFORML %BREAK_K10("末", レミリア_対象)%」
		PRINTFORM 「
	ELSE
		PRINTFORM %BREAK_K10("中", レミリア_対象)%
	ENDIF
	PRINTDATA
		DATAFORM くうう……ぅ
		DATAFORM あ！　あ――ぁ、あ
		DATAFORM ひぁ！　くっ……つ
		DATAFORM うくうっ……ん
		DATAFORM いっ……うあ！　あ、あ
	ENDDATA
;縄やスパンキングなどの苦痛
ELSEIF SOURCE:レミリア:苦痛 >= 10
	レミリア_表示フラグ += 1
	IF レミリア_表示フラグ == 1
		PRINTFORM 「
	ELSEIF レミリア_表示フラグ > 3
		PRINTFORML %BREAK_K10("末", レミリア_対象)%」
		PRINTFORM 「
	ELSE
		PRINTFORM %BREAK_K10("中", レミリア_対象)%
	ENDIF
	PRINTDATA
		DATAFORM い、いた。なに、もう……ん
		DATAFORM 痛っ、痛いのよ
		DATAFORM いくら私が丈夫でも、んっ。痛いものは、痛……う
		DATAFORM 痛いわ
		DATAFORM つっ、う
	ENDDATA
ENDIF

IF SOURCE:レミリア:恐怖 >= 10 || SOURCE:レミリア:不安 >= 10
	レミリア_表示フラグ += 1
	IF レミリア_表示フラグ == 1
		PRINTFORM 「
	ELSEIF レミリア_表示フラグ > 3
		PRINTFORML %BREAK_K10("末", レミリア_対象)%」
```
