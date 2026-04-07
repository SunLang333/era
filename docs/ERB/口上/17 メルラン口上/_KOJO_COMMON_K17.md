# 口上/17 メルラン口上/_KOJO_COMMON_K17.ERB — 自动生成文档

源文件: `ERB/口上/17 メルラン口上/_KOJO_COMMON_K17.ERB`

类型: .ERB

自动摘要: functions: KOJO_EXIST_K17, KOJO_TRAIN_START_K17, KOJO_TRAIN_END_K17, KOJO_COM_TARGET_K17, KOJO_COM_PLAYER_K17, KOJO_COM_BEFORE_K17, KOJO_COM_AFTER_K17, KOJO_SINGLE_ENDING_K17, KOJO_DEAD_ENDING_K17; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;共通部分
;-------------------------------------------------

;=================================================
;●口上の存在判定
;=================================================
@KOJO_EXIST_K17

;=================================================
;●開始時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_START_K17

;=================================================
;●終了時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_END_K17

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_TARGET_K17

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_PLAYER_K17

;=================================================
;●コマンド実行前(ターゲット・プレイヤー問わず)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_BEFORE_K17
RETURN 0

;=================================================
;●コマンド実行後(パラメータの変動処理が終わってから呼び出される)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_AFTER_K17
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF
;-------------------------------------------------
;初絶頂は使い回せそうなのでここに作成
;-------------------------------------------------
;-------------------------------------------------
;初めてＣ絶頂　メルラン、望まないセックスがあまり想像できないので素質で分ける必要あんまないな？
;-------------------------------------------------
IF NOWEX:Ｃ絶頂 > 0
	IF CFLAG:220 == 0
		CFLAG:220 = 1
			PRINTFORMW 「あっあっ、そのまま……んっ、いくっ、んん…❤」
			PRINTFORMW クリトリスへの愛撫で絶頂に達した%ANAME(TARGET)%の切なげな顔を見ていると…当然だが目が合った。
			PRINTFORMW 「……ふふっ、何ぃ？もうやめてよー、イってるのじっと見られるの恥ずかしいんだから……♪」
			PRINTFORMW 「キミって触るの上手だね……❤ふふっ、演技じゃないよーとっても気持ち良かった……もっとして❤」
	;二回目以降
	ELSE
		;何かＶに入ってればカット
		IF IS_V_HOLD(MTAR:0)
			;PRINTFORMW Ｖてすと
		;尻に入っててもカット
		ELSEIF IS_A_HOLD(MTAR:0)
			;PRINTFORMW Ａてすと
		;愛撫とクンニと日常クリ愛撫
		ELSEIF GROUPMATCH (SELECTCOM, 0, 2, 333)
			SELECTCASE PREVCOM
				;仕事中
				CASE 303 ,304
					PRINTFORMW 「ちょっと、んっ❤やっ、あっ……❤お仕事中、だってばぁ……❤」
				;警邏
				CASE 305
					PRINTFORMW 「こんなとこで……嘘っ、やっ、いっちゃう……❤」
				;猥談
				CASE 309
					PRINTFORMW 「あっあっ❤そう、そんな感じで……いかされちゃったの……❤」
				CASEELSE
				SELECTCASE RAND:4 
				CASE 0
					PRINTFORMW 「あっあっ、そのまま……んっ、いくっ、んん……❤」
				CASE 1
					PRINTFORMW 「あっ、あっ、ああっ！んっ……❤んっ、っああぁ……❤」
				CASE 2
					PRINTFORMW 「いっ！ひうっ、んっ……んん～……いっちゃったぁ……❤」
				CASE 3
					PRINTFORMW 「もっと……んぁ！あっ、ひうっ……❤きもちいぃ……❤」
				ENDSELECT
			ENDSELECT
		;ローター
		ELSEIF SELECTCOM == 60
			SELECTCASE RAND:3
			CASE 0
				PRINTFORMW 「ああっ…！っくぅ、いくっ、ああぁぁ…！はっ、はっ、あはぁぁ……❤」
			CASE 1
				PRINTFORMW 「ひっ！いっ、きゃあっ……❤それだめっ、トんじゃう、よぉ……❤」
			CASE 2
				PRINTFORMW 「んっ！んっ！んぁぁ……！もう、くるっ、いく、いくぅぅ……❤」
			ENDSELECT
		ENDIF
	ENDIF
ENDIF

;-------------------------------------------------
;初めてＶ絶頂
;-------------------------------------------------
IF NOWEX:Ｖ絶頂 > 0
	IF CFLAG:221 == 0
		CFLAG:221 = 1
		;バイブで
		IF IS_EQUIP_TARGET(MTAR:0, 61) || SELECTCOM == 61
			PRINTFORMW 「んっ……んぁ！あっあっ、いっ……くぅ……❤」
			PRINTFORMW 「これ……すごいんだねぇ……❤あぁ、あっ、中で動いてるぅ……❤」
		;指挿入れで
		ELSEIF SELECTCOM == 3
			PRINTFORMW 「んあっ！はっ、はぁぁ……❤そこ擦っていいよ、動かして……❤」
			PRINTFORMW 「あぁ～……気持ちいいよぉ……いっちゃった……❤」
		;プレイヤーの竿
		ELSEIF GROUPMATCH(SELECTCOM , 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 52, 55, 57, 160) || IS_EQUIP_TARGET(MTAR:0, 30) || IS_EQUIP_TARGET(MTAR:0, 31) || IS_EQUIP_TARGET(MTAR:0, 32) || IS_EQUIP_TARGET(MTAR:0, 33) || IS_EQUIP_TARGET(MTAR:0, 34) || IS_EQUIP_TARGET(MTAR:0, 35) || IS_EQUIP_TARGET(MTAR:0, 36) || IS_EQUIP_TARGET(MTAR:0, 37) || IS_EQUIP_TARGET(MTAR:0, 38) || IS_EQUIP_TARGET(MTAR:0, 39) || IS_EQUIP_TARGET(MTAR:0, 52) || IS_EQUIP_TARGET(MTAR:0, 55) || IS_EQUIP_TARGET(MTAR:0, 57) || IS_EQUIP_TARGET(MTAR:0, 160)
			PRINTFORMW 「あ～っ、あ～っ、もっと……ずんずんって……きてえっ❤」
			PRINTFORMW 「いいよぉ……あっあっいくっ、いくうっ……❤気持ちいいよっ、キミの……おちんちん……❤」
		ENDIF
	;二回目以降
	ELSE
		;プレイヤーの射精を伴うときはカット
		IF NOWEX:MASTER:射精 > 0
		;バイブ
		ELSEIF IS_EQUIP_TARGET(MTAR:0, 61) || SELECTCOM == 61
			;淫壺
			IF GETBIT(TALENT:淫乱系, 素質_淫乱_淫壷)
				;しおふき
				IF RAND:4 ==0 && NOWEX:潮吹き > 0
					PRINTFORML 「それ……ダメだからあっ！あっ、やっ！あっあっ、いっ……！いくっ、いくっ、ダメえっ…❤」
					PRINTFORML 「あっあっあっ！何回も……そんな、あんあぁあっ、いっちゃう、よぉ…❤」
					PRINTFORMW 浅い天井を狙ってバイブを擦り付けるとメルランは面白いように悶え、絶頂を繰り返した……
				ELSEIF RAND:3 ==0 && NOWEX:潮吹き > 0
					PRINTFORML 「あっあっやだっ❤でるっでっ、出ちゃうからっ❤抜いてっ、あっあっ、んああぁ❤」
					PRINTFORML 「やだぁぁ……止まんないよぉ…❤あぁ……はあぁ……もう……えっち……❤」
					PRINTFORMW 大きく肩を上下させて呼吸を整えているメルランの膣で、バイブがなおも振動音を上げている…
				ELSEIF RAND:2 == 0
					PRINTFORML 「ああ～っ❤いいよっ……そのままっ、そのまましてっ……❤」
					PRINTFORMW 「……っくうっ、いくっ、あはあぁぁ❤止めないでえっ、あんああっ、あぁーーー❤」
				ELSE
					PRINTFORML 「ふかい……とこっ、いいのっ……あっあっ、だめっ❤きもちいっ、いいっ、んああぁぁ……❤」
					PRINTFORMW 「ぐりぐりしてっ❤おくっ、そこ……❤ああぁぁ……いっちゃうよぉ、もうっ……やあぁ……❤」
				ENDIF
			ELSEIF RAND:2 == 0
				PRINTFORMW 「んあっ、あっああぁ……❤はあ、はあぁ……気持ちいいね、これ……えへへ…❤」
			ELSE
				PRINTFORMW 「んっ……んぁ！あっあっ、いっ……くぅ……❤」
				PRINTFORMW 「これ……すごいいいよぉ…❤あぁ、あっ、中で動いてるぅ……❤」
			ENDIF
		;指挿入れ
		ELSEIF SELECTCOM == 3
			;淫壺
			IF GETBIT(TALENT:淫乱系, 素質_淫乱_淫壷)
				;しおふき
				IF RAND:4 ==0 && NOWEX:潮吹き > 0
					PRINTFORML %ANAME(MASTER)%は膣の天井を執拗に刺激し、潮が出尽くすまで愛撫を続けた……
					PRINTFORML 「はぁ……はぁぁ……やだぁ……もぉ……❤すっごい飛び散っちゃってるよぉ……❤」
					PRINTFORMW 「でも……すごかったぁ……❤声おかしくなってなかった？あはは……すっごい良かったもん、ほんとに……❤」
				ELSEIF RAND:3 ==0 && NOWEX:潮吹き > 0
					PRINTFORML 「ああぁあぁ～～～❤あっあんっ、いっくぅ、ひうっ❤ああぁ……❤」
					PRINTFORML 「いっぱい……出ちゃった……❤はあっ、はあ……えへへ……えっち……なんだから…❤」
					PRINTFORMW メルランの尿道からは快感の余韻からか、未だに潮がぴゅっぴゅっ、と飛び出しているのが見える…
				ELSEIF RAND:2 == 0
					PRINTFORML 「いく……よぉっ…❤いいっ、ひっ、ああっ……んあぁ……❤」
					PRINTFORMW 「待って……まだ……抜かないでそのまま……あぁ……収まるまで、ね……❤」
				ELSE
					PRINTFORMW 「そこもっと……擦ってぇ❤あぁああっ、いくっいっ、いいっ、ひうぅ……❤」
					PRINTFORMW 「んん…❤いいの……まだ残ってるの……あんっ、んっ……ふふふ…❤」
				ENDIF
			ELSEIF RAND:2 == 0
				PRINTFORMW 「ふふ……ふぁ、ん、んん……❤イかされちゃった、ね……❤」
			ELSE
				PRINTFORMW 「んあっ！はっ、はぁぁ……❤そこそのまま……いいよっ、ん……動かして……❤」
				PRINTFORMW 「あぁ～……気持ちいいよぉ……いっちゃった……❤」
			ENDIF
		;プレイヤーの竿
		ELSEIF GROUPMATCH(SELECTCOM , 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 52, 55, 57, 160) || IS_EQUIP_TARGET(MTAR:0, 30) || IS_EQUIP_TARGET(MTAR:0, 31) || IS_EQUIP_TARGET(MTAR:0, 32) || IS_EQUIP_TARGET(MTAR:0, 33) || IS_EQUIP_TARGET(MTAR:0, 34) || IS_EQUIP_TARGET(MTAR:0, 35) || IS_EQUIP_TARGET(MTAR:0, 36) || IS_EQUIP_TARGET(MTAR:0, 37) || IS_EQUIP_TARGET(MTAR:0, 38) || IS_EQUIP_TARGET(MTAR:0, 39) || IS_EQUIP_TARGET(MTAR:0, 52) || IS_EQUIP_TARGET(MTAR:0, 55) || IS_EQUIP_TARGET(MTAR:0, 57) || IS_EQUIP_TARGET(MTAR:0, 160)
			;淫壺
			IF GETBIT(TALENT:淫乱系, 素質_淫乱_淫壷)
				;しおふき
				IF RAND:7 == 0 && NOWEX:潮吹き > 0
					PRINTFORML 「あーっ❤あーっ❤あぁーっ❤きもちいいよぉ❤……って……うそ、すっごい……こんなに出ちゃった……の？」
					PRINTFORMW 「あは、あははぁ～……❤イきっぱなしで……全然気づかなかったぁ…❤おちんちんすっごい……いいんだもん……❤」
				ELSEIF RAND:6 ==0 && NOWEX:潮吹き > 0
					PRINTFORML 「やだあぁ……❤おちんちん……私が出したのでもう……ぐちゃぐちゃにしちゃったぁ……❤」
					PRINTFORMW 「かけられて……嬉しいのぉ？もう、キミってば変態さんだぁ……❤ほらまた、中で硬くしてるもん……❤」
				ELSEIF RAND:5 == 0
					PRINTFORML 「いっ、いいっ、いく、よおっ❤んっんっ、あっ、ああぁ❤」
					PRINTFORMW 「キミのですっごく気持ちいいのっ❤好きっ、大好きだよおっ……❤」
				ELSEIF RAND:4 == 0
```
