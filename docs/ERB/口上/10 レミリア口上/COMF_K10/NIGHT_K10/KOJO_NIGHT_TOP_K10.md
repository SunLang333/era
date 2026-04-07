# 口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_TOP_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/COMF_K10/NIGHT_K10/KOJO_NIGHT_TOP_K10.ERB`

类型: .ERB

自动摘要: functions: KOJO_K10_NIGHT_BEFORE_TOP, KOJO_K10_NIGHT_AFTER_TOP; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■閨_攻め_実行前
;　汎用台詞「KOJO_K10_共_閨_攻_汎用.ERB」を呼び出す前に
;　特殊なコマンドを個別に表示してRETURNする
;─────────────────────────────────────── 
@KOJO_K10_NIGHT_BEFORE_TOP(レミリア_対象)
#DIM レミリア
#DIM レミリア_対象
#DIMS レミリア機嫌

IF !レミリア_対象
	レミリア_対象 = MASTER
ENDIF

レミリア = NAME_TO_CHARA("レミリア")
レミリア機嫌 '= TOSTR_EMOTION(レミリア)

;─────────────────────────────────────── 
;◆慰安中の攻めは煽らず曖昧に奉仕
;─────────────────────────────────────── 
IF FLAG:調教モード == 調教_慰安
	PRINTFORM 「
	IF RAND:5 == 0
		PRINTFORM %CALLNAME_K10(レミリア_対象)%
		PRINTFORM %SPLIT_R("……：、：。")%
		PRINTFORM %SPLIT_R("ここ、が：こんな、感じで：は、ふ")%
		PRINTFORM %SPLIT_R("……気持ちよくなるの？：……いいの？：……悦んでくれるの？")%
	ENDIF
	PRINTFORM %SPLIT_R("はふ、あ：うー：んぅ：んう")%
	PRINTFORM %BREAK_K10("中", レミリア_対象)%
	PRINTFORM %SPLIT_R("んっ……：んふ……：んく……：はぁ……：んぅ……：ん：はふ：ふぁ")%
	PRINTFORM %BREAK_K10("末", レミリア_対象)%
	PRINTFORML 」
	RETURN 0
ENDIF

;─────────────────────────────────────── 
;◆不機嫌時
;─────────────────────────────────────── 
SELECTCASE レミリア機嫌
	CASE "恨", "怒", "憤"
		IF PALAM:レミリア:怒主 <= PALAM:レミリア:怒外
			PRINTDATAL
				DATAFORM 「なんだかいらいらしていたの。ちょっとだけ八つ当たりしちゃってもいい？」
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%に怒ってるのとは違うんだけど、いじめたい気分だわ」
				DATAFORM 「悪いことしたい気分なの。いいでしょ？」
				DATAFORM 「いじめたりしちゃいたいわ。%CALLNAME_K10(レミリア_対象)%、付き合ってくれる？」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「家畜のくせに」
				DATAFORM 「後悔するといいわ」
				DATAFORM 「私の命令に従いなさい」
				DATAFORM 「気にいらないわ」
				DATAFORM 「お仕置きが欲しい？　そんなに」
				DATAFORM 「譲ってあげる気分じゃないの」
			ENDDATA
		ENDIF
		RETURN 0

	CASE "鬱", "悲", "憂"
		IF PALAM:レミリア:哀主 <= PALAM:レミリア:哀外
			PRINTDATAL
				DATAFORM 「なんだか悲しい気持ちだったの。%CALLNAME_K10(レミリア_対象)%をだっこさせて」
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%が嫌なわけじゃないけど、気が乗らないの」
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%がちゃんとぎゅうってさせてくれたら元気になるわ」
				DATAFORM 「いっぱい抱きついていい？　なんだか悲しかったの」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「もうっ。大人しくして」
				DATAFORM 「私の言うことが聞けないの？」
				DATAFORM 「私を何だと思っているの」
				DATAFORM 「そんなの、つまんないわ」
				DATAFORM 「何がそんなに気にいらないの？」
				DATAFORM 「…………」
			ENDDATA
		ENDIF
		RETURN 0

	CASE  "狂", "恐", "怯"
		IF PALAM:レミリア:怖主 <= PALAM:レミリア:怖外
			PRINTDATAL
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%、私こういうの知らないわ」
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%がちゃんと撫でてくれないと、怖いことになるんだから」
				DATAFORM 「あれって何が起きているの？　%CALLNAME_K10(レミリア_対象)%、ちゃんとくっついてなさい」
				DATAFORM 「どうしてあんなことをするのかしら？　%CALLNAME_K10(レミリア_対象)%はどう思う？」
			ENDDATA
		ELSE
		PRINTDATAL
			DATAFORM 「…………」
			DATAFORM 「いやよ」
			DATAFORM 「よくわからないわ」
			DATAFORM 「そんな気分じゃないわ」
			DATAFORM 「ヘンよ」
		ENDDATA
		ENDIF
		RETURN 0

	CASEELSE
ENDSELECT

;─────────────────────────────────────── 
;◆不機嫌だと喋らない
;─────────────────────────────────────── 
IF !GROUPMATCH(レミリア機嫌, "恨", "怒", "憤", "鬱", "悲", "憂", "狂", "恐", "怯")
	IF SELECTCOM == PREVCOM
		IF RAND:10 == 0 && IS_INITIATIVE(レミリア) && CHECK_K9("活力", レミリア_対象) && (( IS_MPLY(レミリア) && MPLY_NUM == 1 )||( IS_MTAR(レミリア) && MTAR_NUM == 1 ))
			PRINTDATA
				DATAFORM 「んんぅ……
				DATAFORM 「ほらぁ
				DATAFORM 「こうね
				DATAFORM 「もっとぉ
				DATAFORM 「このまま
				DATAFORM 「もうちょっと
				DATAFORM 「ずうっと
			ENDDATA
			;実行逆転のコマンド
			IF GROUPMATCH(SELECTCOM, 111, 101, 102, 100, 211, 130, 131, 132, 150, 151)
				PRINTDATAL
					DATAFORM %KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいの」
					DATAFORM %KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たいって甘えて？」
				ENDDATA
				LOCAL:0 = COM_EXP:(レミリア):(SELECTCOM+1000)
			;実行逆転のコマンド以外
			ELSE
				PRINTDATAL
					DATAFORM %KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%たいわ」
					DATAFORM %KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいって甘えて？」
				ENDDATA
				LOCAL:0 = COM_EXP:(レミリア):(SELECTCOM)
			ENDIF
			;性癖設定を参照して該当コマンドの経験回数をチェック
			;NTR系で経験を稼いでいる場合に違和感が出るからどうしたものか
			IF RAND:5 == 0
				IF LOCAL:0 > 100
					PRINTFORM 「もう何百回も
					PRINTDATAL
						DATAFORM 躾したんだから
						DATAFORM したんだから
						DATAFORM 可愛がってるんだから
						DATAFORM 繰り返しているんだから
					ENDDATA
					PRINTFORM %BREAK_K10("中", レミリア_対象)%
					PRINTDATAL
						DATAFORM %CALLNAME_K10(レミリア_対象)%もさすがに慣れたわよね？」
						DATAFORM %CALLNAME_K10(レミリア_対象)%だって好きよね？」
						DATAFORM しないとだめな体になってくれたわよね？」
						DATAFORM どう応えたらいいか、憶えてるわよね？」
						DATAFORM あと何万回できるか興味があるわよね？」
					ENDDATA
				ELSEIF LOCAL:0 > 35
					PRINTFORML 「何十回もしたんだから、もう慣れてるわよね」
				ELSE
					PRINTFORML 「まだ{LOCAL:0}回しかしてないから、もっとたくさん教えてあげなくちゃ」
				ENDIF
			ENDIF
		ENDIF
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●レミリア_対象が攻め（主導権によるものもある）
;─────────────────────────────────────── 
;おねだりされる・させる
IF SELECTCOM == 111
	IF IS_MALE(MASTER)
		LOCALS:0 '= "せーえき搾ってください"
		LOCALS:1 '= "白い"
	ELSE
		LOCALS:0 '= "あいえき掻き出してください"
		LOCALS:1 '= "透明"
	ENDIF
	PRINTDATAL
		DATAFORM 「%LOCALS:0%、でしょ」
		DATAFORM 「血を飲んで欲しいのよね？　%LOCALS:1%のを」
		DATAFORM 「私のものだと言いなさい」
		DATALIST
			DATAFORM 「%CALLNAME_K10(レミリア_対象)%の血は全部私の好きにしていい血よね」
			DATAFORM 「紅いのも、白いのも、透明なのも」
		ENDLIST
	ENDDATA
	RETURN 0
ENDIF

;顔面騎乗 Ａ顔面騎乗する・させる（ターゲットは喋れない）
IF SELECTCOM == 101 || SELECTCOM == 102
	IF IS_MPLY(レミリア)
		PRINTDATA
			DATAFORM 「ご褒美よ。私の血も分けてあげる」
			DATAFORM 「気持ちよくしなさい。上手にできないとお仕置きよ」
			DATALIST
				DATAFORM 「毛？　……ないけど。へん？　別に普通でしょ」
				DATAFORM 「妹だってこんなところ、そんなに生えてないわよ？」
			ENDLIST
			DATAFORM 「躾をしなくちゃ。息を止めてあげる」
		ENDDATA
		RETURN 0
	ENDIF
ENDIF
```
