# 口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_TOP_SOURCE_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_TOP_SOURCE_K10.ERB`

类型: .ERB

自动摘要: functions: TEASE_K10; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●閨_攻め_実行前_ソース参照　CALL TEASE_K10(レミリア_対象)
;─────────────────────────────────────── 
@TEASE_K10(レミリア_対象)
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
;○レミリア_対象の快楽状態をチェック
;─────────────────────────────────────── 
;▼SOURCE
;　前文の場合SOURCE・後文ならCUP・値は最大部位値との比較用なのでPALAMで保存
;　最低1ないと刺激とみなさないPALAMには快Ｐがない
IF SOURCE:レミリア_対象:快Ｖ >= 1 && SOURCE:レミリア_対象:快Ｖ >= SOURCE:レミリア_対象:快Ｐ && SOURCE:レミリア_対象:快Ｖ >= SOURCE:レミリア_対象:快Ｃ && SOURCE:レミリア_対象:快Ｖ >= SOURCE:レミリア_対象:快Ａ && SOURCE:レミリア_対象:快Ｖ >= SOURCE:レミリア_対象:快Ｂ
	レミリア_今回部位値 = PALAM:レミリア_対象:快Ｖ
	レミリア_今回部位 '= "Ｖ"
	レミリア_今回部位称 '= CALL_DIRTY_K10("Ｖ")
ELSEIF SOURCE:レミリア_対象:快Ａ >= 1 && SOURCE:レミリア_対象:快Ａ >= SOURCE:レミリア_対象:快Ｐ && SOURCE:レミリア_対象:快Ａ >= SOURCE:レミリア_対象:快Ｃ && SOURCE:レミリア_対象:快Ａ >= SOURCE:レミリア_対象:快Ｖ && SOURCE:レミリア_対象:快Ａ >= SOURCE:レミリア_対象:快Ｂ
	レミリア_今回部位値 = PALAM:レミリア_対象:快Ａ
	レミリア_今回部位 '= "Ａ"
	レミリア_今回部位称 '= CALL_DIRTY_K10("Ａ")
ELSEIF SOURCE:レミリア_対象:快Ｐ >= 1 && SOURCE:レミリア_対象:快Ｐ >= SOURCE:レミリア_対象:快Ｖ && SOURCE:レミリア_対象:快Ｐ >= SOURCE:レミリア_対象:快Ａ && SOURCE:レミリア_対象:快Ｐ >= SOURCE:レミリア_対象:快Ｃ && SOURCE:レミリア_対象:快Ｐ >= SOURCE:レミリア_対象:快Ｂ
	レミリア_今回部位値 = PALAM:レミリア_対象:快Ｃ
	レミリア_今回部位 '= "Ｐ"
	レミリア_今回部位称 '= CALL_DIRTY_K10("Ｐ")
ELSEIF SOURCE:レミリア_対象:快Ｃ >= 1 && SOURCE:レミリア_対象:快Ｃ >= SOURCE:レミリア_対象:快Ｐ && SOURCE:レミリア_対象:快Ｃ >= SOURCE:レミリア_対象:快Ｖ && SOURCE:レミリア_対象:快Ｃ >= SOURCE:レミリア_対象:快Ａ && SOURCE:レミリア_対象:快Ｃ >= SOURCE:レミリア_対象:快Ｂ
	IF HAS_PENIS(レミリア_対象)
		レミリア_今回部位値 = PALAM:レミリア_対象:快Ｃ
		レミリア_今回部位 '= "Ｐ"
		レミリア_今回部位称 '= CALL_DIRTY_K10("Ｐ")
	ELSE
		レミリア_今回部位値 = PALAM:レミリア_対象:快Ｃ
		レミリア_今回部位 '= "Ｃ"
		レミリア_今回部位称 '= CALL_DIRTY_K10("Ｃ")
	ENDIF
ELSEIF SOURCE:レミリア_対象:快Ｂ >= 1 && SOURCE:レミリア_対象:快Ｂ >= SOURCE:レミリア_対象:快Ｐ && SOURCE:レミリア_対象:快Ｂ >= SOURCE:レミリア_対象:快Ｃ && SOURCE:レミリア_対象:快Ｂ >= SOURCE:レミリア_対象:快Ｖ && SOURCE:レミリア_対象:快Ｂ >= SOURCE:レミリア_対象:快Ａ
	レミリア_今回部位値 = PALAM:レミリア_対象:快Ｂ
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
IF PALAM:レミリア_対象:快Ｖ >= 10 && PALAM:レミリア_対象:快Ｖ >= PALAM:レミリア_対象:快Ｃ && PALAM:レミリア_対象:快Ｖ >= PALAM:レミリア_対象:快Ａ && PALAM:レミリア_対象:快Ｖ >= PALAM:レミリア_対象:快Ｂ
	レミリア_最大部位値 = PALAM:レミリア_対象:快Ｖ
	レミリア_最大部位 '= "Ｖ"
	レミリア_最大部位称 '= CALL_DIRTY_K10("Ｖ")
ELSEIF PALAM:レミリア_対象:快Ａ >= 10 && PALAM:レミリア_対象:快Ａ >= PALAM:レミリア_対象:快Ｃ && PALAM:レミリア_対象:快Ａ >= PALAM:レミリア_対象:快Ｖ && PALAM:レミリア_対象:快Ａ >= PALAM:レミリア_対象:快Ｂ
	レミリア_最大部位値 = PALAM:レミリア_対象:快Ａ
	レミリア_最大部位 '= "Ａ"
	レミリア_最大部位称 '= CALL_DIRTY_K10("Ａ")
ELSEIF PALAM:レミリア_対象:快Ｃ >= 10 && PALAM:レミリア_対象:快Ｃ >= PALAM:レミリア_対象:快Ｖ && PALAM:レミリア_対象:快Ｃ >= PALAM:レミリア_対象:快Ａ && PALAM:レミリア_対象:快Ｃ >= PALAM:レミリア_対象:快Ｂ
	IF HAS_PENIS(レミリア)
		レミリア_最大部位値 = PALAM:レミリア_対象:快Ｃ
		レミリア_最大部位 '= "Ｐ"
		レミリア_最大部位称 '= CALL_DIRTY_K10("Ｐ")
	ELSE
		レミリア_最大部位値 = PALAM:レミリア_対象:快Ｃ
		レミリア_最大部位 '= "Ｃ"
		レミリア_最大部位称 '= CALL_DIRTY_K10("Ｃ")
	ENDIF
ELSEIF PALAM:レミリア_対象:快Ｂ >= 10 && PALAM:レミリア_対象:快Ｂ >= PALAM:レミリア_対象:快Ｃ && PALAM:レミリア_対象:快Ｂ >= PALAM:レミリア_対象:快Ｖ && PALAM:レミリア_対象:快Ｂ >= PALAM:レミリア_対象:快Ａ
	レミリア_最大部位値 = PALAM:レミリア_対象:快Ｂ
	レミリア_最大部位 '= "Ｂ"
	レミリア_最大部位称 '= CALL_DIRTY_K10("Ｂ")
ELSE
	レミリア_最大部位値 = 0
	レミリア_最大部位 '= ""
	レミリア_最大部位称 '= ""
ENDIF

;─────────────────────────────────────── 
;○台詞１_失神・疲労
;─────────────────────────────────────── 
;▼失神
IF TCVAR:レミリア_対象:52
	PRINTFORM 「
	PRINTDATA
		DATAFORM %CALLNAME_K10(レミリア_対象)%、起きて
		DATAFORM イキ過ぎて眠っちゃったの？　ねぇ
		DATAFORM %CALLNAME_K10(レミリア_対象)%、まだよ
	ENDDATA
	PRINTFORML %BREAK_K10("末", レミリア_対象)%」

;気力が1/3以下
ELSEIF BASE:レミリア_対象:気力 <= (MAXBASE:レミリア_対象:気力 / 3)
	PRINTFORM 「
	PRINTFORM %SPLIT_R("たくさん：とっても：いっぱい：すごい")%
	PRINTFORM %SPLIT_R("気持ちよくなっちゃった：イッちゃった：よろこんでくれた：感じちゃった")%
	PRINTFORM %SPLIT_R("わね：のね：みたいね")%
	PRINTFORM %BREAK_K10("中", レミリア_対象)%
	IF IS_MALE(レミリア_対象)
		PRINTDATA
			DATAFORM 苦しそうにぜいぜいして
			DATAFORM お肉が締まって
			DATAFORM 体の筋が浮いて
			DATAFORM くったりしちゃって
			DATAFORM ぶるぶるしちゃって
			DATAFORM かすれた声して
			DATAFORM 汗だくで
			DATAFORM 肌が血の色に染まって
		ENDDATA
	ELSE
		PRINTDATA
			DATAFORM 苦しそうにはぁはぁして
			DATAFORM 胸を揺らして
			DATAFORM 体の筋が浮いて
			DATAFORM くったりしちゃって
			DATAFORM ぷるぷるしちゃって
			DATAFORM 甘い声して
			DATAFORM 汗ぐっしょりで
			DATAFORM 肌がピンク色に染まって
		ENDDATA
	ENDIF
	PRINTDATA
		DATAFORM 美味しそう
		DATAFORM 喉が鳴っちゃう
		DATAFORM 食べちゃいたいわ
		DATAFORM いくら食べてもおなかが減っちゃう
		DATAFORM いい匂い
		DATAFORM 美味しそうな匂い
	ENDDATA
	PRINTFORM %BREAK_K10("末", レミリア_対象)%
	PRINTFORML 」
ENDIF

;▼疲労
IF TCVAR:レミリア_対象:51 || BASE:レミリア_対象:体力 <= (MAXBASE:レミリア_対象:体力 / 3)
	PRINTFORM 「
	PRINTDATA
		DATAFORM 苦し？　もう少し頑張りなさい
		DATAFORM もう疲れちゃったの？　いいわ。勝手に食べてあげる
		DATAFORM 動けないなら、それはそれでいいわ。食べやすいし
		DATAFORM もうだめなの？　まだ食べたいわ
	ENDDATA
	PRINTFORM %BREAK_K10("末", レミリア_対象)%
	PRINTFORML 」
ENDIF

;─────────────────────────────────────── 
;○台詞２_ソースに関して
;　覚書：解消は会話のみ・感応は猥談本屋のみ
;─────────────────────────────────────── 
レミリア_表示フラグ = 0
IF SOURCE:レミリア_対象:苦痛 >= 10
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
		DATAFORM 痛いの？　なるべく傷は残さないから、私に身を委ねなさい
		DATAFORM ケガはしないように気を付けてあげるから、安心して痛がってていいわ
		DATAFORM 痛いと怖いでしょ？　私を畏れるといいわ。血が美味しくなるもの
		DATAFORM ちゃんと気持ち良くなろうとしないと、痛いわ
	ENDDATA
ENDIF

;とりあえずレミリア_対象が主人公で陥落時のみ
;NTRで心も奪われたい派に向けにはどう分岐させたらいいものか
IF CHECK_K10("陥落", レミリア_対象)
	IF SOURCE:レミリア_対象:愛情 >= 10 || SOURCE:レミリア_対象:歓喜 >= 10
		レミリア_表示フラグ += 1
		IF レミリア_表示フラグ == 1
			PRINTFORM 「
		ELSEIF レミリア_表示フラグ > 3
			PRINTFORML %BREAK_K10("末", レミリア_対象)%」
			PRINTFORM 「
		ELSE
			PRINTFORM %BREAK_K10("中", レミリア_対象)%
```
