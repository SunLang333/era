# 口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_TOP_SOURCE_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_TOP_SOURCE_K9.ERB`

类型: .ERB

自动摘要: functions: TEASE_K9; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●閨_攻め_実行前_ソース参照　CALL TEASE_K9(MASTER)
;─────────────────────────────────────── 
@TEASE_K9(咲夜_対象)
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
;○咲夜_対象の快楽状態をチェック
;─────────────────────────────────────── 
;▼SOURCE
;　前文の場合SOURCE・後文ならCUP・値は最大部位値との比較用なのでPALAMで保存
;　最低1ないと刺激とみなさないPALAMには快Ｐがない
IF SOURCE:咲夜_対象:快Ｖ >= 1 && SOURCE:咲夜_対象:快Ｖ >= SOURCE:咲夜_対象:快Ｐ && SOURCE:咲夜_対象:快Ｖ >= SOURCE:咲夜_対象:快Ｃ && SOURCE:咲夜_対象:快Ｖ >= SOURCE:咲夜_対象:快Ａ && SOURCE:咲夜_対象:快Ｖ >= SOURCE:咲夜_対象:快Ｂ
	咲夜_今回部位値 = PALAM:咲夜_対象:快Ｖ
	咲夜_今回部位 '= "Ｖ"
	咲夜_今回部位称 '= CALL_DIRTY_K9("Ｖ")
ELSEIF SOURCE:咲夜_対象:快Ａ >= 1 && SOURCE:咲夜_対象:快Ａ >= SOURCE:咲夜_対象:快Ｐ && SOURCE:咲夜_対象:快Ａ >= SOURCE:咲夜_対象:快Ｃ && SOURCE:咲夜_対象:快Ａ >= SOURCE:咲夜_対象:快Ｖ && SOURCE:咲夜_対象:快Ａ >= SOURCE:咲夜_対象:快Ｂ
	咲夜_今回部位値 = PALAM:咲夜_対象:快Ａ
	咲夜_今回部位 '= "Ａ"
	咲夜_今回部位称 '= CALL_DIRTY_K9("Ａ")
ELSEIF SOURCE:咲夜_対象:快Ｐ >= 1 && SOURCE:咲夜_対象:快Ｐ >= SOURCE:咲夜_対象:快Ｖ && SOURCE:咲夜_対象:快Ｐ >= SOURCE:咲夜_対象:快Ａ && SOURCE:咲夜_対象:快Ｐ >= SOURCE:咲夜_対象:快Ｃ && SOURCE:咲夜_対象:快Ｐ >= SOURCE:咲夜_対象:快Ｂ
	咲夜_今回部位値 = PALAM:咲夜_対象:快Ｃ
	咲夜_今回部位 '= "Ｐ"
	咲夜_今回部位称 '= CALL_DIRTY_K9("Ｐ")
ELSEIF SOURCE:咲夜_対象:快Ｃ >= 1 && SOURCE:咲夜_対象:快Ｃ >= SOURCE:咲夜_対象:快Ｐ && SOURCE:咲夜_対象:快Ｃ >= SOURCE:咲夜_対象:快Ｖ && SOURCE:咲夜_対象:快Ｃ >= SOURCE:咲夜_対象:快Ａ && SOURCE:咲夜_対象:快Ｃ >= SOURCE:咲夜_対象:快Ｂ
	IF HAS_PENIS(咲夜_対象)
		咲夜_今回部位値 = PALAM:咲夜_対象:快Ｃ
		咲夜_今回部位 '= "Ｐ"
		咲夜_今回部位称 '= CALL_DIRTY_K9("Ｐ")
	ELSE
		咲夜_今回部位値 = PALAM:咲夜_対象:快Ｃ
		咲夜_今回部位 '= "Ｃ"
		咲夜_今回部位称 '= CALL_DIRTY_K9("Ｃ")
	ENDIF
ELSEIF SOURCE:咲夜_対象:快Ｂ >= 1 && SOURCE:咲夜_対象:快Ｂ >= SOURCE:咲夜_対象:快Ｐ && SOURCE:咲夜_対象:快Ｂ >= SOURCE:咲夜_対象:快Ｃ && SOURCE:咲夜_対象:快Ｂ >= SOURCE:咲夜_対象:快Ｖ && SOURCE:咲夜_対象:快Ｂ >= SOURCE:咲夜_対象:快Ａ
	咲夜_今回部位値 = PALAM:咲夜_対象:快Ｂ
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
IF PALAM:咲夜_対象:快Ｖ >= 10 && PALAM:咲夜_対象:快Ｖ >= PALAM:咲夜_対象:快Ｃ && PALAM:咲夜_対象:快Ｖ >= PALAM:咲夜_対象:快Ａ && PALAM:咲夜_対象:快Ｖ >= PALAM:咲夜_対象:快Ｂ
	咲夜_最大部位値 = PALAM:咲夜_対象:快Ｖ
	咲夜_最大部位 '= "Ｖ"
	咲夜_最大部位称 '= CALL_DIRTY_K9("Ｖ")
ELSEIF PALAM:咲夜_対象:快Ａ >= 10 && PALAM:咲夜_対象:快Ａ >= PALAM:咲夜_対象:快Ｃ && PALAM:咲夜_対象:快Ａ >= PALAM:咲夜_対象:快Ｖ && PALAM:咲夜_対象:快Ａ >= PALAM:咲夜_対象:快Ｂ
	咲夜_最大部位値 = PALAM:咲夜_対象:快Ａ
	咲夜_最大部位 '= "Ａ"
	咲夜_最大部位称 '= CALL_DIRTY_K9("Ａ")
ELSEIF PALAM:咲夜_対象:快Ｃ >= 10 && PALAM:咲夜_対象:快Ｃ >= PALAM:咲夜_対象:快Ｖ && PALAM:咲夜_対象:快Ｃ >= PALAM:咲夜_対象:快Ａ && PALAM:咲夜_対象:快Ｃ >= PALAM:咲夜_対象:快Ｂ
	IF HAS_PENIS(咲夜)
		咲夜_最大部位値 = PALAM:咲夜_対象:快Ｃ
		咲夜_最大部位 '= "Ｐ"
		咲夜_最大部位称 '= CALL_DIRTY_K9("Ｐ")
	ELSE
		咲夜_最大部位値 = PALAM:咲夜_対象:快Ｃ
		咲夜_最大部位 '= "Ｃ"
		咲夜_最大部位称 '= CALL_DIRTY_K9("Ｃ")
	ENDIF
ELSEIF PALAM:咲夜_対象:快Ｂ >= 10 && PALAM:咲夜_対象:快Ｂ >= PALAM:咲夜_対象:快Ｃ && PALAM:咲夜_対象:快Ｂ >= PALAM:咲夜_対象:快Ｖ && PALAM:咲夜_対象:快Ｂ >= PALAM:咲夜_対象:快Ａ
	咲夜_最大部位値 = PALAM:咲夜_対象:快Ｂ
	咲夜_最大部位 '= "Ｂ"
	咲夜_最大部位称 '= CALL_DIRTY_K9("Ｂ")
ELSE
	咲夜_最大部位値 = 0
	咲夜_最大部位 '= ""
	咲夜_最大部位称 '= ""
ENDIF

;─────────────────────────────────────── 
;○台詞１_失神・疲労
;─────────────────────────────────────── 
;▼失神
IF TCVAR:咲夜_対象:52
	PRINTFORM 「
	PRINTDATA
		DATAFORM %CALLNAME_K9(咲夜_対象)%、%POLITE_K9("起きて", "起きてください")%
		DATAFORM %POLITE_K9("イキ過ぎて眠っちゃったかしら", "イキ過ぎて眠ってしまわれましたか")%？　ふふ
		DATAFORM %CALLNAME_K9(咲夜_対象)%、%POLITE_K9("まだ終わっていないのよ", "まだ終わっていませんよ")%
	ENDDATA
	PRINTFORML %BREAK_K9("末", 咲夜_対象)%」

;気力が1/3以下
ELSEIF BASE:咲夜_対象:気力 <= (MAXBASE:咲夜_対象:気力 / 3)
	PRINTFORM 「
	PRINTDATA
		DATAFORM たくさん
		DATAFORM とっても
		DATAFORM すごく
		DATAFORM いっぱい
	ENDDATA
	PRINTDATA
		DATAFORM %POLITE_K9("悦んでくれた", "悦んでくださった")%
		DATAFORM %POLITE_K9("イッちゃった", "イッてくださった")%
		DATAFORM %POLITE_K9("よくなってくれた", "感じてくださった")%
		DATAFORM %POLITE_K9("深イキし過ぎちゃった", "深く絶頂された")%
	ENDDATA
	PRINTDATA
		DATAFORM %POLITE_K9("のね", "のですね")%
		DATAFORM %POLITE_K9("わね", "んですね")%
	ENDDATA
	PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	IF IS_MALE(咲夜_対象)
		PRINTDATA
			DATAFORM 息苦しそうで
			DATAFORM おなかがぎゅ、ぎゅって動いて
			DATAFORM 足の付け根の筋が浮いて
			DATAFORM くったりしちゃって
			DATAFORM 指先まで震えて
			DATAFORM 声が苦しそうで
			DATAFORM 肌が汗ばんでいて
			DATAFORM 雄っぽい匂いがして
			DATAFORM お肌が真っ赤になっていて
		ENDDATA
		PRINTDATA
			DATAFORM %POLITE_K9("えっちよ", "えっちです")%
			DATAFORM %POLITE_K9("色っぽいわ", "色っぽいです")%
			DATAFORM %POLITE_K9("セクシーよ", "セクシーです")%
			DATAFORM %POLITE_K9("見てると濡れちゃいそう", "見ていると濡らしてしまいそう")%
			DATAFORM %POLITE_K9("嬉しいわ", "嬉しいです")%
			DATAFORM %POLITE_K9("素敵よ", "素敵です")%
			DATAFORM %POLITE_K9("悩ましいわ", "悩ましいです")%
			DATAFORM %POLITE_K9("そそられちゃうわ", "ますますしたくなってしまいます")%
		ENDDATA
	ELSE
		PRINTDATA
			DATAFORM 息苦しそうで
			DATAFORM はぁはぁって胸を揺らして
			DATAFORM 指先までひくひくして
			DATAFORM 全身くったりして
			DATAFORM 声が甘ったるく絡んで
			DATAFORM 肌が汗ばんでいて
			DATAFORM 雌っぽい匂いがして
			DATAFORM とろとろで
			DATAFORM お肌がピンク色になって
		ENDDATA
		PRINTDATA
			DATAFORM %POLITE_K9("えっちよ", "えっちです")%
			DATAFORM %POLITE_K9("色っぽいわ", "色っぽいです")%
			DATAFORM %POLITE_K9("セクシーよ", "セクシーです")%
			DATAFORM %POLITE_K9("見てると濡れちゃいそう", "見ていると濡らしてしまいそう")%
			DATAFORM %POLITE_K9("嬉しいわ", "嬉しいです")%
			DATAFORM %POLITE_K9("可愛いわ", "お可愛らしいです")%
			DATAFORM %POLITE_K9("悩ましいわ", "悩ましいです")%
			DATAFORM %POLITE_K9("そそられちゃうわ", "ますますしたくなってしまいます")%
		ENDDATA
	ENDIF
	PRINTFORML %BREAK_K9("末", 咲夜_対象)%」
ENDIF

;▼疲労
IF TCVAR:咲夜_対象:51 || BASE:咲夜_対象:体力 <= (MAXBASE:咲夜_対象:体力 / 3)
	PRINTFORM 「
	PRINTDATA
		DATAFORM 息%POLITE_K9("、苦しい", "が苦しいですか")%？　もう少しだけ%POLITE_K9("、ね", "お付き合いください")%
		DATAFORM ふふ、疲れ%POLITE_K9("ちゃったのね", "てしまったんですね")%
		DATAFORM お疲れ%POLITE_K9("なのね。いいわ、私に任せて", "なんですね。お任せくださいませ")%
		DATAFORM %POLITE_K9("いいのよ。休んでいて。私がするわ", "休んでいてください。私が致しますから")%
		DATAFORM %POLITE_K9("疲れちゃったのかしら", "お疲れですか")%
		DATAFORM %POLITE_K9("まだ時間は大丈夫よね？", "お時間はまだ平気でしょう？")%　ふふ
		DATAFORM %POLITE_K9("もっとしたいわ", "まだこうしていたいです")%
	ENDDATA
	PRINTFORML %BREAK_K9("末", 咲夜_対象)%」
ENDIF

;─────────────────────────────────────── 
;○台詞２_ソースに関して
;─────────────────────────────────────── 
咲夜_表示フラグ = 0
IF SOURCE:咲夜_対象:苦痛 >= 10
	咲夜_表示フラグ += 1
	IF 咲夜_表示フラグ == 1
```
