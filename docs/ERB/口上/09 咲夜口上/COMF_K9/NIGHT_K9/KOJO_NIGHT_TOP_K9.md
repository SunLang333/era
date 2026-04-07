# 口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_TOP_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/NIGHT_K9/KOJO_NIGHT_TOP_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_K9_NIGHT_BEFORE_TOP, KOJO_K9_NIGHT_AFTER_TOP; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■閨_攻め_実行前
;　汎用台詞「KOJO_K9_共_閨_攻_汎用.ERB」を呼び出す前に
;　特殊なコマンドを個別に表示してRETURNする
;─────────────────────────────────────── 
@KOJO_K9_NIGHT_BEFORE_TOP(咲夜_対象)
#DIM 咲夜
#DIM 咲夜_対象
#DIMS 咲夜機嫌

IF !咲夜_対象
	咲夜_対象 = MASTER
ENDIF

咲夜 = NAME_TO_CHARA("咲夜")
咲夜機嫌 '= TOSTR_EMOTION(咲夜)

;このくらいは専用口上が欲しいけど事前に何で判断するべきか
;これらの未経験チェック＋喪失コマンド番号総ざらいのグループマッチチェック？
;ファーストキス喪失
;処女喪失
;Ａ処女喪失

;─────────────────────────────────────── 
;◆慰安中の攻めは煽らず曖昧に奉仕
;─────────────────────────────────────── 
IF FLAG:調教モード == 調教_慰安
	PRINTFORM 「
	PRINTFORM %SPLIT_R("んっ……：んふ……：んく……：はぁ……：んぅ……：ん：はふ：ふぁ")%
	PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	PRINTFORM %SPLIT_R("ぁは：う：ん：はぁ、はぁ")%
	PRINTFORM %BREAK_K9("中", 咲夜_対象)%
	IF RAND:5 == 0
		PRINTFORM %CALLNAME_K9(咲夜_対象)%
		PRINTFORM %SPLIT_R("……：、：。")%
		PRINTFORM %SPLIT_R("これで：こう、したら：はぁ、はぁ")%
		PRINTFORM %SPLIT_R("お悦び頂けますか：感じて頂けますか：よろしいでしょうか")%
		PRINTFORM %SPLIT_R("……：？　")%
	ENDIF
	PRINTFORM %SPLIT_R("んっ……：んふ……：んく……：はぁ……：んぅ……：ん：はふ：ふぁ")%
	PRINTFORML %BREAK_K9("末", 咲夜_対象)%」
	;汎用攻めを喋らない
	RETURN 0
ENDIF

;─────────────────────────────────────── 
;◆不機嫌時
;─────────────────────────────────────── 
SELECTCASE 咲夜機嫌
	CASE "恨", "怒", "憤"
		IF PALAM:咲夜:怒主 <= PALAM:咲夜:怒外
			PRINTDATAL
				DATAFORM 「意地悪させてくれるかしら？」
				DATAFORM 「%CALLNAME_K9(咲夜_対象)%に怒っている訳ではないの……ごめんなさい。八つ当たりよね」
				DATAFORM 「いじめさせてくれるかしら？」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「もう！　いい加減にしてくれ%POLITE_K9("ないかしら", "ませんか", 咲夜_対象)%」
				DATAFORM 「大人しくして%POLITE_K9("ちょうだい", "くれませんか", 咲夜_対象)%」
				DATAFORM 「何がそんなに気にいらない%POLITE_K9("のかしら", "のでしょう", 咲夜_対象)%」
				DATAFORM 「あまりイライラさせないで%POLITE_K9("ちょうだい", "くださいませんか", 咲夜_対象)%」
				DATAFORM 「そんなにお仕置きが欲しいの%POLITE_K9("かしらね", "でしょう", 咲夜_対象)%」
				DATAFORM 「まぁいい%POLITE_K9("わ", "でしょう", 咲夜_対象)%。これから%POLITE_K9("だもの", "ですから", 咲夜_対象)%」
			ENDDATA
		ENDIF
		RETURN 0

	CASE "鬱", "悲", "憂"
		IF PALAM:咲夜:哀主 <= PALAM:咲夜:哀外
			PRINTDATAL
				DATAFORM 「ごめんなさい、こんな時に。気分を変えるわね」
				DATAFORM 「少し落ち込むことがあったの……甘えさせてくれるかしら？」
				DATAFORM 「そうね……ちょっと憂鬱だったの。今はもう平気よ」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「手間を掛けさせないで%POLITE_K9("ね", "くださいませんか", 咲夜_対象)%」
				DATAFORM 「そんなに私のことが%POLITE_K9("嫌いかしら", "お嫌いですか", 咲夜_対象)%」
				DATAFORM 「ふう……」
				DATAFORM 「付き合いきれ%POLITE_K9("ないわ", "ません", 咲夜_対象)%」
				DATAFORM 「…………」
				DATAFORM 「まぁいい%POLITE_K9("わ", "でしょう", 咲夜_対象)%。これから%POLITE_K9("だもの", "ですから", 咲夜_対象)%」
			ENDDATA
		ENDIF
		RETURN 0

	CASE  "狂", "恐", "怯"
		IF PALAM:咲夜:怖主 <= PALAM:咲夜:怖外
			PRINTDATAL
				DATAFORM 「何なのかしら……いえ、%CALLNAME_K9(咲夜_対象)%のことではないわ」
				DATAFORM 「ちょっと怖かったのよね……」
				DATAFORM 「ごめんなさい、こんな時に。気分を変えるわね」
			ENDDATA
		ELSE
		PRINTDATAL
			DATAFORM 「…………」
			DATAFORM 「どう考えてもおかしい%POLITE_K9("わね", "でしょう", 咲夜_対象)%」
			DATAFORM 「どうしてこんなことになっているの%POLITE_K9("かしらね", "でしょう", 咲夜_対象)%」
			DATAFORM 「……恐ろしくなって%POLITE_K9("くるわね", "きたわ", 咲夜_対象)%」
			DATAFORM 「順に片付け%POLITE_K9("るしかないわね", "るしかなさそうですね", 咲夜_対象)%」
			DATAFORM 「まぁいい%POLITE_K9("わ", "でしょう", 咲夜_対象)%。これから%POLITE_K9("だもの", "ですから", 咲夜_対象)%」
		ENDDATA
		ENDIF
		RETURN 0

	CASEELSE
ENDSELECT

;─────────────────────────────────────── 
;◆不機嫌だと喋らない
;─────────────────────────────────────── 
;前回と同一コマンド
IF !GROUPMATCH(咲夜機嫌, "恨", "怒", "憤", "鬱", "悲", "憂", "狂", "恐", "怯")
	IF SELECTCOM == PREVCOM
		IF RAND:10 == 0 && IS_INITIATIVE(咲夜) && CHECK_K9("活力", 咲夜_対象) && (( IS_MPLY(咲夜) && MPLY_NUM == 1 )||( IS_MTAR(咲夜) && MTAR_NUM == 1 ))
			PRINTDATA
				DATAFORM 「もっと
				DATAFORM 「このまま
				DATAFORM 「もう少し
				DATAFORM 「こうしてずっと
				DATAFORM 「まだ
				DATAFORM 「いつまでも
				DATAFORM 「ずっと
			ENDDATA
			;実行逆転のコマンド
			IF GROUPMATCH(SELECTCOM, 111, 101, 102, 100, 211, 130, 131, 132, 150, 151)
				PRINTDATAL
					DATAFORM %KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%たい%POLITE_K9("わ", "です", 咲夜_対象)%」
					DATAFORM %KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%た%POLITE_K9("いでしょう", "くはありませんか？", 咲夜_対象)%」
				ENDDATA
				LOCAL:0 = COM_EXP:(咲夜):(SELECTCOM+1000)
			;実行逆転のコマンド以外
			ELSE
				PRINTDATAL
					DATAFORM %KOJO_COM_NAME_PLAYER_K9(SELECTCOM, 咲夜_対象)%たい%POLITE_K9("わ", "です", 咲夜_対象)%」
					DATAFORM %KOJO_COM_NAME_TARGET_K9(SELECTCOM, 咲夜_対象)%た%POLITE_K9("いでしょう", "くはありませんか？", 咲夜_対象)%」
				ENDDATA
				LOCAL:0 = COM_EXP:(咲夜):(SELECTCOM)
			ENDIF
			;性癖設定を参照して該当コマンドの経験回数をチェック
			;NTR系で経験を稼いでいる場合に違和感が出るからどうしたものか
			IF RAND:5 == 0
				IF LOCAL:0 > 100
					PRINTFORM 「もう何百回と
					PRINTDATAL
						DATAFORM 躾した
						DATAFORM 刷り込んだ
						DATAFORM 可愛がった
						DATAFORM 繰り返している
					ENDDATA
					PRINTFORM こと%POLITE_K9("だ", "です", 咲夜_対象)%
					PRINTDATAL
						DATAFORM もの。しないと体が疼きます」
						DATAFORM もの。されないと体が疼くでしょう？」
						DATAFORM もの。中毒になって%POLITE_K9("くれたんじゃないかしら", "しまわれたのではありませんか", 咲夜_対象)%」
						DATAFORM もの。ないとダメ%POLITE_K9("よね", "ですよね", 咲夜_対象)%？」
						DATAFORM けど、まだ足りないでしょう？」
						DATAFORM けど、もっと%POLITE_K9("されたいわよね", "欲しいですよね", 咲夜_対象)%？」
					ENDDATA
				ELSEIF LOCAL:0 > 35
					PRINTFORML 「もう何十回もしたことだもの。好きになったわよね？」
				ELSE
					PRINTFORML 「まだ{LOCAL:0}回しかして%POLITE_K9("いない", "いません", 咲夜_対象)%し、これから好きになって%POLITE_K9("貰わなくちゃね", "頂かなくてはいけません", 咲夜_対象)%」
				ENDIF
			ENDIF
		ENDIF
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●咲夜_対象が攻め（主導権によるものもある）
;─────────────────────────────────────── 
;おねだりされる・させる
IF SELECTCOM == 111
	PRINTDATAL
		DATAFORM 「自分でお尻を掴んで開いて%POLITE_K9("くれなくちゃ", "くださらないと", 咲夜_対象)%よく見えない%POLITE_K9("わよ", "ですよ", 咲夜_対象)%？　ふふっ」
		DATAFORM 「私、物覚えが悪いですから。何をどうして欲しいのかちゃんと話して%POLITE_K9("くれるかしら", "くださいね", 咲夜_対象)%」
		DATAFORM 「無様%POLITE_K9("ね", "ですね", 咲夜_対象)%。あさましい恰好%POLITE_K9("だわ", "です", 咲夜_対象)%」
		DATAFORM 「太いのが欲しい%POLITE_K9("の", "んです", 咲夜_対象)%？　それとも痛めつけて欲しい%POLITE_K9("のかしら", "のでしょうか", 咲夜_対象)%」
	ENDDATA
	RETURN 0
ENDIF

;顔面騎乗 Ａ顔面騎乗する・させる（ターゲットは喋れない）
IF SELECTCOM == 101 || SELECTCOM == 102
		PRINTFORM 「
	IF IS_MPLY(咲夜)
		PRINTDATA
			DATAFORM ふふ、苦しい%POLITE_K9("かしら", "でしょうか", 咲夜_対象)%
			DATAFORM 顔の上に跨るなんて、失礼%POLITE_K9("するわね", "しますね", 咲夜_対象)%
			DATAFORM 息苦しくして%POLITE_K9("あげるわ", "差し上げます", 咲夜_対象)%
			DATAFORM さあ、気持ちよくしてして%POLITE_K9("くれるでしょう", "くださるでしょう", 咲夜_対象)%？　%ANAME(咲夜)%を%POLITE_K9("食べて", "食べてください", 咲夜_対象)%
			DATAFORM 気持ちよくしてして%POLITE_K9("くれるかしら", "くださるでしょう", 咲夜_対象)%？　%ANAME(咲夜)%を%POLITE_K9("食べて欲しいの", "食べてください", 咲夜_対象)%
		ENDDATA
		PRINTFORML %BREAK_K9("末", 咲夜_対象)%」
	ENDIF
	RETURN 0
ENDIF

```
