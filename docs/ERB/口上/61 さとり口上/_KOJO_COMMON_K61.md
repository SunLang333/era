# 口上/61 さとり口上/_KOJO_COMMON_K61.ERB — 自动生成文档

源文件: `ERB/口上/61 さとり口上/_KOJO_COMMON_K61.ERB`

类型: .ERB

自动摘要: functions: KOJO_EXIST_K61, KOJO_TRAIN_START_K61, KOJO_TRAIN_END_K61, KOJO_COM_TARGET_K61, KOJO_COM_PLAYER_K61, KOJO_COM_BEFORE_K61, KOJO_COM_AFTER_K61, KOJO_SINGLE_ENDING_K61; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;共通部分
;-------------------------------------------------

;=================================================
;●口上の存在判定
;=================================================
@KOJO_EXIST_K61
;=================================================
;●開始時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_START_K61

;=================================================
;●終了時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_END_K61

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_TARGET_K61

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_PLAYER_K61

;=================================================
;●コマンド実行前(ターゲット・プレイヤー問わず)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_BEFORE_K61

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
@KOJO_COM_AFTER_K61
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
			PRINTFORMW 「はあぁっ♥　クリっ、イ、イっちゃッぅぅっ♥」
		;それ以外
		ELSE
			PRINTFORMW 「ふあぁぁっ！」
		ENDIF
	;二回目以降
	ELSE
		;最強絶頂時
		IF NOWEX:Ｃ絶頂 > 4
			;常に表示されると多重絶頂時にうるさいので、以下適当に無言を織り交ぜておく
			SELECTCASE RAND:8
				CASE 0
					PRINTFORML 「ひやぁっ♥♥　あっ♥　あ゛あっ♥　あぁあ―z___ッ♥♥♥」
				CASE 1
					;PRINTFORML 
				CASE 2
					PRINTFORML 「はひぃッ♥クリでっイっ、ちゃっ♥♥　はあッ♥♥　ッッ―♥♥―z___♥♥ッ♥♥」
				CASE 3
					;PRINTFORML 
				CASE 4
					PRINTFORML 「ひあ♥　あッ♥♥　はあぁあぁッッ♥♥♥♥」
				CASE 5
					;PRINTFORML 
				CASE 6
					PRINTFORML 「♥♥ひぁ♥♥　あぁ～～あっッ♥♥♥　ぁッ♥♥」
				CASE 7
					;PRINTFORML 
			ENDSELECT
		;恋慕 or 服従 or 主人
		ELSEIF TALENT:恋慕 || TALENT:服従 || TALENT:主人
			SELECTCASE RAND:6
				CASE 0
					PRINTFORML 「ひあっ！　はっ！　ぁあぁっッ♥」
				CASE 1
					;PRINTFORML 
				CASE 2
					PRINTFORML 「ひやぁっ♥　だッだめぇっ♥あッはぁ―z___♥ぁッッ♥」
				CASE 3
					;PRINTFORML 
				CASE 4
					PRINTFORML 「はぁっ、あっ！　イっ、イっちゃうぅっ♥」
				CASE 5
					;PRINTFORML 
			ENDSELECT
		;それ以外
		ELSE
			SELECTCASE RAND:6
				CASE 0
					PRINTFORML 「んんっ～～～！　っ！っ！」
				CASE 1
					;PRINTFORML 
				CASE 2
					PRINTFORML 「やあっ！　イっちゃ…っ！」
				CASE 3
					;PRINTFORML 
				CASE 4
					;PRINTFORML 
				CASE 5
					PRINTFORML 「んんっ！　ん……っ！」
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
		IF TALENT:恋慕 || TALENT:服従 || TALENT:主人  
			PRINTFORML 「アッ、なっなにかッ来るっ♥　くッ♥　あっ♥　はあぁぁーーぁあッッ♥♥」
			PRINTFORML %ANAME(TARGET)%の肢体が弓なりにしなり、その膣内から白濁した愛液が噴き出してくる
			PRINTFORMW 「はあぁぁ…これ、すごいぃ……こんなぁ……♥♥」
		;それ以外
		ELSE
			PRINTFORML 「あッ！　ひあぁッっ！」
			PRINTFORML %ANAME(TARGET)%の膣内から白濁した愛液が噴き出してくる
			PRINTFORMW 「はあぁぁ……。みっともない姿をさらしてしまったわ…」
		ENDIF
	;二回目以降
	ELSE
		;最強絶頂時
		IF NOWEX:Ｖ絶頂 > 4
			;常に表示されると多重絶頂時にうるさいので、以下適当に無言を織り交ぜておく
			SELECTCASE RAND:10
				CASE 0
					;PRINTFORML 
				CASE 1
					PRINTFORML 「あッ♥　きっ♥♥　はあ゛っ♥　あ゛ぁあ゛ぁあ―ッ♥♥♥♥」
				CASE 2
					;PRINTFORML 
				CASE 3
					PRINTFORML 「おひッ♥いいっ♥ッ♥♥　いいぃぃ―z__ィッ♥ッ♥ッ♥♥♥」
				CASE 4
					;PRINTFORML 
				CASE 5
					PRINTFORML 「イッ♥　イクッ♥　イッ♥♥　…っクぅうう♥♥っっ♥♥♥」
				CASE 6
					;PRINTFORML 
				CASE 7
					PRINTFORML 「はきゃあっ♥♥　はあ゛ぁああぁあ゛あっっ♥♥♥♥♥」」
				CASE 8
					;PRINTFORML 
				CASE 9
					PRINTFORML 「はひぃっ♥♥　とけりゅぅッ♥♥　私のおまんことけりゅぅうぅッッ♥♥♥」
			ENDSELECT
		;恋慕 or 服従 or 主人
		ELSEIF TALENT:恋慕 || TALENT:服従 || TALENT:主人
			SELECTCASE RAND:7
				CASE 0
					PRINTFORML 「ふあっ♥　ああ♥　キちゃうぅっっ♥♥」
				CASE 1
					;PRINTFORML 
```
