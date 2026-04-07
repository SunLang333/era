# 口上/10 レミリア口上/COMF_K10/NOON_K10/KOJO_NOON_PLAYER_K10.ERB — 自动生成文档

源文件: `ERB/口上/10 レミリア口上/COMF_K10/NOON_K10/KOJO_NOON_PLAYER_K10.ERB`

类型: .ERB

自动摘要: functions: KOJO_K10_NOON_BEFORE_PLAYER, KOJO_K10_NOON_AFTER_PLAYER; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;■日常_実行_実行前
;─────────────────────────────────────── 
@KOJO_K10_NOON_BEFORE_PLAYER(レミリア_対象)
#DIM レミリア
#DIM レミリア_対象
#DIMS レミリア機嫌

IF !レミリア_対象
	レミリア_対象 = MASTER
ENDIF

レミリア = NAME_TO_CHARA("レミリア")
レミリア機嫌 '= TOSTR_EMOTION(レミリア)

;─────────────────────────────────────── 
;●機嫌が悪ければ通常のコマンド口上は喋らない
;─────────────────────────────────────── 
SELECTCASE レミリア機嫌
	CASE "恨", "怒", "憤"
		IF PALAM:レミリア:怒主 <= PALAM:レミリア:怒外
			PRINTDATAL
				DATAFORM 「なんだかいらいらしていたの。くっついていて」
				DATAFORM 「いらいらしているの。%CALLNAME_K10(レミリア_対象)%に怒ってるのとは違うわ。聞いてくれる？」
				DATAFORM 「気に入らないことがあるのよ。聞いて」
			ENDDATA
		ELSE
			PRINTDATAL
				DATAFORM 「気にいらないわ」
				DATAFORM 「譲ってあげる気分じゃないの」
			ENDDATA
		ENDIF
		RETURN 0

	CASE "鬱", "悲", "憂"
		IF PALAM:レミリア:哀主 <= PALAM:レミリア:哀外
			PRINTDATAL
				DATAFORM 「なんだか悲しい気持ちだったの。くっついていて」
				DATAFORM 「つまんなかったの。一緒に遊んで」
				DATAFORM 「いっぱい抱きついていい？　悲しいことがあったの」
			ENDDATA
		ELSE
			PRINTDATAL
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
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%、ちゃんと撫でて」
				DATAFORM 「%CALLNAME_K10(レミリア_対象)%、私を助けてくれるでしょう？」
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
;●同一コマンド
;─────────────────────────────────────── 
IF SELECTCOM == PREVCOM && RAND:10 == 0
	;レミリアに主導権なし
	IF !IS_INITIATIVE(レミリア)
		PRINTDATAL
			DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいでしょう」
			DATAFORM 「もっと？　そうね。いいわ」
			DATAFORM 「まだ？　いいわよ。%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%ましょう」
			DATAFORM 「%CALLNAME_K10(レミリア_対象)%以外に主導権は絶対に握らせないわ」
		ENDDATA
	;レミリアに主導権あり
	ELSE
		PRINTDATAL
			DATAFORM 「もっと%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%ましょう」
			DATAFORM 「もっと」
			DATAFORM 「主導権は握らせないわ」
			DATAFORM 「もっと%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいでしょう？」
		ENDDATA
	ENDIF
;─────────────────────────────────────── 
;●同一コマンドでない
;─────────────────────────────────────── 
ELSEIF RAND:10 == 0
	;レミリアに主導権なし
	IF !IS_INITIATIVE(レミリア)
		PRINTDATAL
			DATAFORM 「%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいのね。いいわ」
			DATAFORM 「そうね。%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%ましょう。わかってるじゃない」
		ENDDATA
	;レミリアに主導権あり
	ELSE
		PRINTDATAL
			DATAFORM 「%KOJO_COM_NAME_PLAYER_K10(SELECTCOM)%ましょう。いいわよね？」
			DATAFORM 「%KOJO_COM_NAME_TARGET_K10(SELECTCOM)%たいでしょう？」
		ENDDATA
	ENDIF
ENDIF

;─────────────────────────────────────── 
;●スキンシップ・背中を洗う
;─────────────────────────────────────── 
IF GROUPMATCH(SELECTCOM, 320, 358)
	;レミリアに主導権なし
	IF !IS_INITIATIVE(レミリア)
		PRINTDATAL
			DATAFORM 「こう？　……くすぐったいの？　このくらい我慢なさい」
			DATAFORM 「こうね。……落ち着くわ」
			DATAFORM 「こんな感じかしらね」
		ENDDATA
	;レミリアに主導権あり
	ELSE
		PRINTDATAL
			DATAFORM 「くすぐったいの？　このくらい我慢なさい」
			DATAFORM 「もっと傍に来て」
			DATAFORM 「もっとくっついてなさい」
			DATAFORM 「遠いわ。もっとこっちよ」
			DATAFORM 「お人形さん遊びさせてぇ」
		ENDDATA
	ENDIF
	RETURN 0
ENDIF

;─────────────────────────────────────── 
;●頭を撫でる
;─────────────────────────────────────── 
IF GROUPMATCH(SELECTCOM, 321)
	;レミリアに主導権なし
	IF !IS_INITIATIVE(レミリア)
		PRINTDATAL
			DATAFORM 「いいわ。もっと屈んで？」
			DATAFORM 「ふふ。よくできたわね。偉いわ」
			DATAFORM 「いいわ。褒めてあげる。いい子よ」
			DATAFORM 「そうなの。偉かったわね」
		ENDDATA
	;レミリアに主導権あり
	ELSE
		PRINTDATAL
			DATAFORM 「もっと屈んで？　撫でにくいわ」
			DATAFORM 「褒めてあげる。いい子、偉いわ」
			DATAFORM 「頑張ったのね。偉かったわね」
		ENDDATA
	ENDIF
	RETURN 0
ENDIF

;─────────────────────────────────────── 
;●髪を梳く・櫛で梳かす
;─────────────────────────────────────── 
IF GROUPMATCH(SELECTCOM, 322, 323)
	;初回かつスキンヘッドならマッサージの流れを作っておく
	;IS_COM_FIRST(1)はターゲット側の確認のためフラグを用意/一回限りなのでクリックあり
	IF !レミリア_髪梳き初回 && TALENT:レミリア_対象:髪の長さ < 25
		IF !IS_INITIATIVE(レミリア)
			PRINTFORML 「磨いて欲しいの？　%CALLNAME_K10(レミリア_対象)%、剃ってるじゃない」
			PRINTFORMDW %ANAME(レミリア)%は呆気にとられている
			PRINTL 
			PRINTFORML 「梳いてあげられないわ。撫でてあげる」
		ELSE
			PRINTFORML 「髪をとかしてあげ……られなかったわ、つまんない」
			PRINTFORMDW %ANAME(レミリア)%は首を傾げて考え込んでいる
			PRINTL 
			PRINTFORML 「そうだわ。撫でてあげる」
			PRINTFORMDL やがて得心がいったようにひとつ頷き、%ANAME(レミリア_対象)%に手を伸ばしてきた
		ENDIF
	;初回でないor初回だがスキンヘッドではない
	ELSE
		;スキンヘッド
		IF TALENT:レミリア_対象:髪の長さ == 1
			IF !IS_INITIATIVE(レミリア)
				PRINTFORML 「もうその冗談はいいわよ。いいわ。解してあげる」
			ELSE
				PRINTFORML 「疲れているでしょう？　解してあげるわ」
			ENDIF
			PRINTDATAL
				DATAFORM 「どう？　気持ちいいでしょう。……強過ぎた？」
				DATAFORM 「どう？　気持ちいいでしょう」
				DATAFORM 「えい……とんとん。こうかしら？」
			ENDDATA
		;スキンヘッドではない
		ELSE
			IF !IS_INITIATIVE(レミリア)
				PRINTFORML 「%CALLNAME_K10(レミリア_対象)%って、%KOJO_HAIR_NAME(レミリア_対象)%ね」
				PRINTFORMDW %ANAME(レミリア_対象)%は%ANAME(レミリア)%に頼んで、髪を梳かしてもらった
			ELSE
				PRINTFORML 「%KOJO_HAIR_NAME(レミリア_対象)%ね。触っていて気持ちがいいの」
				PRINTFORMDW %ANAME(レミリア)%は%ANAME(レミリア_対象)%の髪を梳かした
			ENDIF
			PRINTDATAL
```
