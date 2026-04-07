# SYSTEM/_FUNCTION_DESIGN.ERB — 自动生成文档

源文件: `ERB/SYSTEM/_FUNCTION_DESIGN.ERB`

类型: .ERB

自动摘要: functions: COLOR, COLOR_PRINT, COLOR_PRINTL, COLOR_PRINTW, PRINT_KANNRAKU_BAR, COLOR_LINE, SETFONT_MEYRYOKE, TITLE_LABEL_START, TITLE_CATEGORY_GENERAL, FILL_SPACE; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;■関数デザイン回り

;============================================================================== 
;◆RGBカラーを色名単語で指定する関数（使用頻度の高そうな色のみ）
;　使い方：　SETCOLOR COLOR("レッド")
;　tohoK参考にしました。感謝。
;============================================================================== 
@COLOR(ARGS:0)
	#FUNCTION

	;基本デザインカラー
	;　選択中メニューの着色等
	IF ARGS:0 == "メインカラー"
		RETURNF 0x47B0A0
	;　カテゴリータイトル色等
	ELSEIF ARGS:0 == "サブカラー"
		RETURNF 0x888E7E
	;　選択不可色等、使用不可であることを示す
	ELSEIF ARGS:0 == "ダークグレー"
		RETURNF 0x303030
	;　時間やムードのデフォルト色等、不可ではないがオフを示す
	ELSEIF ARGS:0 == "グレー"
		RETURNF 0x505050
	;　注釈等、注目して欲しい部分が他にあるときの引き算色
	ELSEIF ARGS:0 == "シルバー"
		RETURNF 0x808992
	;　基本的な強調色
	ELSEIF ARGS:0 == "オレンジ"
		RETURNF 0xCE7A19
	;　基本的な強調色と対立する色（現在のメインカラーに近いため注意）
	ELSEIF ARGS:0 == "シアン"
		RETURNF 0x47B3A5
	;　注意喚起・最も目立つ色
	ELSEIF ARGS:0 == "イエロー"
		RETURNF 0xCFBF30
	;　強調色が足りない時用
	ELSEIF ARGS:0 == "オリーブ"
		RETURNF 0x8B9E53
	;補佐色
	ELSEIF ARGS:0 == "ダークオレンジ"
		RETURNF 0xC66630
	ELSEIF ARGS:0 == "ダークイエロー"
		RETURNF 0x999939
	ELSEIF ARGS:0 == "ダークレッド"
		RETURNF 0x942C2C
	;深陥落カラー
	ELSEIF ARGS:0 == "レッド"
		RETURNF 0xD04040
	ELSEIF ARGS:0 == "グリーン"
		RETURNF 0x609040
	ELSEIF ARGS:0 == "パープル"
		RETURNF 0x8970DF
	;浅陥落カラー
	ELSEIF ARGS:0 == "ピンク"
		RETURNF 0xD97980
	ELSEIF ARGS:0 == "イエローグリーン"
		RETURNF 0x809940
	ELSEIF ARGS:0 == "ブルー"
		RETURNF 0x6070DC
	;既成事実Lv2誓約カラー
	ELSEIF ARGS:0 == "ライトピンク"
		RETURNF 0xF09CA3
	ELSEIF ARGS:0 == "ライトグリーン"
		RETURNF 0x90A060
	ELSEIF ARGS:0 == "ライトブルー"
		RETURNF 0x7090D0
	;既成事実Lv3情交カラー
	ELSEIF ARGS:0 == "パステルピンク"
		RETURNF 0xE5ABBE
	ELSEIF ARGS:0 == "パステルグリーン"
		RETURNF 0xA0A966
	ELSEIF ARGS:0 == "パステルブルー"
		RETURNF 0x87A8DB
	;暴君に服従（服従ルートはブルー～パープル、少しずらしてシアン系）
	ELSEIF ARGS:0 == "暴君カラー"
		RETURNF 0x50A0A0
	;好敵手に恋慕（恋慕ルートはピンク～レッド、少しずらしてオレンジ系）
	ELSEIF ARGS:0 == "好敵手カラー"
		RETURNF 0xCC9930
	;小町を愛玩（愛玩ルートはグリーン～イエローグリーン、少しずらしてミントグリーン系）
	ELSEIF ARGS:0 == "小町カラー"
		RETURNF 0x70BB90
	;シルバーのバリエーション
	ELSEIF ARGS:0 == "シルバーブルー"
		RETURNF 0x90A9BF
	;季節
	ELSEIF ARGS:0 == "春"
		RETURNF 0xE597B2
	ELSEIF ARGS:0 == "夏"
		RETURNF 0x72AE66
	ELSEIF ARGS:0 == "秋"
		RETURNF 0xC53D43
	ELSEIF ARGS:0 == "冬"
		RETURNF 0x99B3DB
	;天候
	ELSEIF ARGS:0 == "雪天"
		RETURNF 0x98AAAB
	ELSEIF ARGS:0 == "曇天"
		RETURNF 0x708E94
	ELSEIF ARGS:0 == "雨天"
		RETURNF 0x5383C3
	ELSEIF ARGS:0 == "晴天"
		RETURNF 0xD9D09F
	;マップ用
	ELSEIF ARGS:0 == "土"
		RETURNF 0x302010
	ELSEIF ARGS:0 == "樹"
		RETURNF 0x555555
	ELSEIF ARGS:0 == "畳床"
		RETURNF 0x363910
	ELSEIF ARGS:0 == "板壁"
		RETURNF 0x736950
	ELSEIF ARGS:0 == "板床"
		RETURNF 0x332C16
	ELSEIF ARGS:0 == "石壁"
		RETURNF 0x606066
	ELSEIF ARGS:0 == "石床"
		RETURNF 0x202029
	ELSEIF ARGS:0 == "水場"
		RETURNF 0x105060
	ELSEIF ARGS:0 == "春の樹"
		RETURNF 0xB38699
	ELSEIF ARGS:0 == "夏の樹"
		RETURNF 0x0e6953
	ELSEIF ARGS:0 == "秋の樹"
		RETURNF 0x652D30
	ELSEIF ARGS:0 == "冬の樹"
		RETURNF 0x39435B
	ELSEIF ARGS:0 == "春の土"
		RETURNF 0x283020
	ELSEIF ARGS:0 == "夏の土"
		RETURNF 0x0e3129
	ELSEIF ARGS:0 == "秋の土"
		RETURNF 0x403029
	ELSEIF ARGS:0 == "冬の土"
		RETURNF 0x262C39
	ELSEIF ARGS:0 == "春の夜の樹"
		RETURNF 0x3f212d
	ELSEIF ARGS:0 == "夏の夜の樹"
		RETURNF 0x031611
	ELSEIF ARGS:0 == "秋の夜の樹"
		RETURNF 0x2b0508
	ELSEIF ARGS:0 == "冬の夜の樹"
		RETURNF 0x1e2330
	ELSEIF ARGS:0 == "春の夜の土"
		RETURNF 0x101c0a
	ELSEIF ARGS:0 == "夏の夜の土"
		RETURNF 0x051c1a
	ELSEIF ARGS:0 == "秋の夜の土"
		RETURNF 0x0f0b09
	ELSEIF ARGS:0 == "冬の夜の土"
		RETURNF 0x0d0f14

	;デフォルトカラー
	ELSEIF ARGS:0 == "デフォルト"
		RETURNF GETDEFCOLOR()
	;エラー回避
	ELSE
		RETURNF GETDEFCOLOR()
	ENDIF

;============================================================================== 
;◆多色使いのテキストを一行で書く関数
;　デフォルトカラーは指定不要
;　CALL COLOR_PRINTFORML("オレンジで表示", COLOR("オレンジ"))
;　CALL COLOR_PRINTFORML("ここはいつも通り", , "ここはオレンジ色", COLOR("オレンジ"), "ここもいつも通り", , "ここはブルー", COLOR("ブルー"))
;============================================================================== 
@COLOR_PRINT(テキスト１, カラー１, テキスト２, カラー２, テキスト３, カラー３, テキスト４, カラー４, テキスト５, カラー５, テキスト６, カラー６, テキスト７, カラー７, テキスト８, カラー８, テキスト９, カラー９, テキスト１０, カラー１０)
	#DIMS テキスト１
	#DIM カラー１
	#DIMS テキスト２
	#DIM カラー２
	#DIMS テキスト３
	#DIM カラー３
	#DIMS テキスト４
	#DIM カラー４
	#DIMS テキスト５
	#DIM カラー５
	#DIMS テキスト６
	#DIM カラー６
	#DIMS テキスト７
	#DIM カラー７
	#DIMS テキスト８
	#DIM カラー８
	#DIMS テキスト９
	#DIM カラー９
	#DIMS テキスト１０
	#DIM カラー１０
	IF テキスト１ != ""
		IF カラー１
			SETCOLOR カラー１
		ELSE
			SETCOLOR GETDEFCOLOR()
		ENDIF
		PRINTFORM %テキスト１%
	ENDIF
	IF テキスト２ != ""
		IF カラー２
			SETCOLOR カラー２
		ELSE
```
