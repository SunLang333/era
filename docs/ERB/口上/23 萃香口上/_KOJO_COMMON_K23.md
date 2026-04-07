# 口上/23 萃香口上/_KOJO_COMMON_K23.ERB — 自动生成文档

源文件: `ERB/口上/23 萃香口上/_KOJO_COMMON_K23.ERB`

类型: .ERB

自动摘要: functions: KOJO_EXIST_K23, KOJO_TRAIN_START_K23, KOJO_TRAIN_END_K23, KOJO_COM_TARGET_K23, KOJO_COM_PLAYER_K23, KOJO_COM_BEFORE_K23, KOJO_COM_AFTER_K23, KOJO_SINGLE_ENDING_K23, KOJO_DEAD_ENDING_K23; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;共通部分
;-------------------------------------------------

;=================================================
;●口上の存在判定
;=================================================
@KOJO_EXIST_K23

;=================================================
;●開始時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_START_K23

;=================================================
;●終了時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_END_K23

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_TARGET_K23

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_PLAYER_K23

;=================================================
;●コマンド実行前(ターゲット・プレイヤー問わず)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_BEFORE_K23

;ファーストキスフラグ（キス未経験だったらCFLAG:255を1にセット）
SIF TALENT:キス未経験
	CFLAG:255 = 1
;処女フラグ（処女だったらCFLAG:260を1にセット）
SIF TALENT:処女
	CFLAG:260 = 1
;主人公が童貞フラグ（主人公が童貞だったらCFLAG:261を1にセット）
SIF TALENT:MASTER:童貞
	CFLAG:261 = 1
	
RETURN 0

;=================================================
;●コマンド実行後(パラメータの変動処理が終わってから呼び出される)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_AFTER_K23
#DIM 対象
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

;ファーストキスフラグ（コマンド終了時にキス未経験じゃ無かったらCFLAG:255を0にセット）
SIF !TALENT:キス未経験
	CFLAG:255 = 0
;処女フラグ（コマンド終了時に処女じゃ無かったらCFLAG:260を0にセット）
SIF !TALENT:処女
	CFLAG:260 = 0
;主人公が童貞フラグ（コマンド終了時に主人公が童貞じゃ無かったらCFLAG:261を0にセット）
SIF !TALENT:MASTER:童貞
	CFLAG:261 = 0
	
	PRINTL

;-------------------------------------------------
;初絶頂は使い回せそうなのでここに作成
;-------------------------------------------------
;-------------------------------------------------
;初めてＣ絶頂
;-------------------------------------------------
IF NOWEX:Ｃ絶頂 > 0
	IF CFLAG:220 == 0
		CFLAG:220 = 1
		;恋慕
		IF TALENT:恋慕 || TALENT:服従 
			PRINTFORML 「ふあッ♥　あッ♥　あぁあ～～～～～～♥ッ♥ッ♥♥」
			PRINTFORML 陰核への刺激に限界を迎えた%ANAME(TARGET)%は絶頂し、全身を痙攣させた
			PRINTFORMW 「…そこ…イジられるの…好きぃ♥　…もッと触っておくれ…♥」
		;それ以外
		ELSE
			PRINTFORML 「～～～～～～～～～～！ッ！ッ！」
			PRINTFORMW 「ッはぁ……凄く……気持ちよかったぁ……♥」
		ENDIF
	;二回目以降
	ELSE
		;最強絶頂時
		IF NOWEX:Ｃ絶頂 > 4
			FONTSTYLE 1
			;常に表示されると多重絶頂時にうるさいので、以下適当に無言を織り交ぜておく
			SELECTCASE RAND:8
				CASE 0
					PRINTFORML 「へひッ♥　あ゛あ゛ッ♥　あ゛ーッ♥♥　あ゛ーッ♥♥♥」
				CASE 1
					;PRINTFORML 
				CASE 2
					PRINTFORML 「ッ―♥♥―♥ッッ―♥♥――z_________♥♥ッ♥♥」
				CASE 3
					;PRINTFORML 
				CASE 4
					PRINTFORML 「ひあ♥　あーッ♥♥　あ゛ーッ♥♥　ああぁッ♥♥　あッ♥♥」
				CASE 5
					;PRINTFORML 
				CASE 6
					PRINTFORML 「♥ふやゃッ♥　あぁッ♥あッ♥♥　はッ♥♥　あ゛ッ♥♥ッ♥♥」
				CASE 7
					;PRINTFORML 
			ENDSELECT
			FONTSTYLE 0
		;恋慕 or 服従 or 親友
		ELSEIF TALENT:恋慕 || TALENT:服従 || TALENT:親友
			SELECTCASE RAND:8
				CASE 0
					PRINTFORML 「ふあッ♥　あッ♥あぁあ～～～ッ♥」
				CASE 1
					;PRINTFORML 
				CASE 2
					;PRINTFORML 
				CASE 3
					PRINTFORML 「ひあぁッ♥　あーーッ♥♥」
				CASE 4
					;PRINTFORML 
				CASE 5
					;PRINTFORML 
				CASE 6
					PRINTFORML 「ふやゃあぁあ～ッッ♥♥」
				CASE 7
					;PRINTFORML 
			ENDSELECT
		;それ以外
		ELSE
			SELECTCASE RAND:6
				CASE 0
					PRINTFORML 「～～～～～～！ッ！ッ！」
				CASE 1
					;PRINTFORML 
				CASE 2
					PRINTFORML 「あッ！　んんーッ！」
				CASE 3
					;PRINTFORML 
				CASE 4
					;PRINTFORML 
				CASE 5
					PRINTFORML 「んんッ！　ん……ッ！」
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
		;恋慕
		IF TALENT:恋慕 || TALENT:服従 
			PRINTFORML 「ああッ！　なんかッ！　来るッ！　来ちゃ……ぁああああああ♥♥」
			PRINTFORML 絶頂により%ANAME(TARGET)%の膣肉が激しく脈動し、奥から白濁した愛液が溢れ出してくる
			PRINTFORMW 「あぁ…これ、すごいよぉ♥　……酔っぱらっちゃいそうだ……♥♥」
		;それ以外
		ELSE
			PRINTFORML 「ああッ！　なんかッ！　来るッ！　来ちゃ……ぁあああああッ！」
			PRINTFORML %ANAME(TARGET)%の膣内から白濁した愛液が噴き出してくる
			PRINTFORMW 「ッはあぁ……こっちでイくなんて久しぶりだよ……♥」
		ENDIF
	;二回目以降
	ELSE
		;最強絶頂時
		IF NOWEX:Ｖ絶頂 > 4
			FONTSTYLE 1
			SELECTCASE RAND:11
				CASE 0
					;PRINTFORML 
				CASE 1
					CALL COLOR_PRINTL("「ああ゛ッ♥♥　あ゛あ゛♥♥―♥―ッ♥♥♥♥」", カラー_オレンジ)
				CASE 2
					;PRINTFORML 
				CASE 3
					CALL COLOR_PRINTL("「ッ―♥♥―♥――♥♥ッッ――♥―z_____♥ッ♥♥♥」", カラー_オレンジ)
				CASE 4
					;PRINTFORML 
				CASE 5
					CALL COLOR_PRINTL("「イ゛くっ♥♥　イ゛っちゃ♥♥　へぁっ♥♥　あ゛♥♥ひッ♥♥　ひぁああぁあっっ♥♥♥」", カラー_オレンジ)
				CASE 6
					;PRINTFORML 
				CASE 7
					CALL COLOR_PRINTL("「きッ♥はッ♥♥　ああ゛ぁッ♥♥ーッ♥ッ♥♥」", カラー_オレンジ)
				CASE 8
```
