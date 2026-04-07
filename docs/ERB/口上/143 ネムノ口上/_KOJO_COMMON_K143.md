# 口上/143 ネムノ口上/_KOJO_COMMON_K143.ERB — 自动生成文档

源文件: `ERB/口上/143 ネムノ口上/_KOJO_COMMON_K143.ERB`

类型: .ERB

自动摘要: functions: KOJO_EXIST_K143, KOJO_TRAIN_START_K143, KOJO_TRAIN_END_K143, KOJO_COM_TARGET_K143, KOJO_COM_PLAYER_K143, KOJO_COM_BEFORE_K143, KOJO_COM_AFTER_K143, KOJO_SINGLE_ENDING_K143, KOJO_DEAD_ENDING_K143; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;共通部分
;-------------------------------------------------

;=================================================
;●口上の存在判定
;=================================================
@KOJO_EXIST_K143

;=================================================
;●開始時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_START_K143

;=================================================
;●終了時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_END_K143

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_TARGET_K143

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_PLAYER_K143

;=================================================
;●コマンド実行前(ターゲット・プレイヤー問わず)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_BEFORE_K143

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
@KOJO_COM_AFTER_K143
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

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
			PRINTFORMW 「やっ、そこっ！　だめぇッッ♥」
		;それ以外
		ELSE
			PRINTFORMW 「あんっ♥」
		ENDIF
	;二回目以降
	ELSE
		;最強絶頂時
		IF NOWEX:Ｃ絶頂 > 4
			;常に表示されると多重絶頂時にうるさいので、以下適当に無言を織り交ぜておく
			SELECTCASE RAND:8
				CASE 0
					PRINTFORML 「やっ♥♥あっ♥　あ゛あっ♥あぁあ―z___ッ♥♥♥」
				CASE 1
					;PRINTFORML 
				CASE 2
					PRINTFORML 「はッ♥♥　あッ♥♥ッッ―♥♥―z___♥♥ッ♥♥」
				CASE 3
					;PRINTFORML 
				CASE 4
					PRINTFORML 「ひあ♥あッ♥♥　はあぁあぁッッ♥♥♥♥」
				CASE 5
					;PRINTFORML 
				CASE 6
					PRINTFORML 「♥♥はっ♥♥　あぁあっッ♥♥♥ッ♥♥」
				CASE 7
					;PRINTFORML 
			ENDSELECT
		;恋慕 or 服従 or 親友
		ELSEIF TALENT:恋慕 || TALENT:服従 || TALENT:親友
			;常に表示されると多重絶頂時にうるさいので無言を織り交ぜておく
			SELECTCASE RAND:8
				CASE 0
					PRINTFORML 「はっ♥　あっ♥あぁあ～～～っ♥」
				CASE 1
					;PRINTFORML 
				CASE 2
					;PRINTFORML 
				CASE 3
					PRINTFORML 「やっ♥　イっくぅっ♥」
				CASE 4
					;PRINTFORML 
				CASE 5
					;PRINTFORML 
				CASE 6
					PRINTFORML 「んんっ♥　はぁあ～っっ♥♥」
				CASE 7
					;PRINTFORML 
			ENDSELECT
		;それ以外
		ELSE
			SELECTCASE RAND:6
				CASE 0
					PRINTFORML 「んんっ～～～！っ！っ！」
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
		IF TALENT:恋慕 || TALENT:服従 
			PRINTFORMW 「あっ♥　ああっっ♥♥　…♥……ひ、久しぶりにイ、イカされたべ…♥」
		;それ以外
		ELSE
			PRINTFORMW 「んんっ～～～！っ！っ！」
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
					PRINTFORML 「あッ♥きっ♥♥　あ゛っ♥あ゛あ゛♥♥ぁあ―ッ♥♥♥♥」
				CASE 2
					;PRINTFORML 
				CASE 3
					PRINTFORML 「おひッ♥♥♥♥　ッ♥♥ひあッ♥ッ♥ああッッ♥♥♥」
				CASE 4
					;PRINTFORML 
				CASE 5
					PRINTFORML 「イッ♥イクッ♥　イッ♥♥…っクぅうう♥♥っっ♥♥♥」
				CASE 6
					;PRINTFORML 
				CASE 7
					PRINTFORML 「ああっ♥♥♥♥　はあぁああぁああっっ♥♥♥♥♥」」
				CASE 8
					;PRINTFORML 
				CASE 9
					PRINTFORML 「っあ♥♥ああっ♥♥　あ゛っ♥あ゛♥んぁああぁ♥♥♥♥」
			ENDSELECT
		;恋慕 or 服従 or 親友
		ELSEIF TALENT:恋慕 || TALENT:服従 || TALENT:親友
			SELECTCASE RAND:8
				CASE 0
					PRINTFORML 「あっ♥ああ♥　イクうぅっっ♥♥」
				CASE 1
					;PRINTFORML 
				CASE 2
					;PRINTFORML 
				CASE 3
					PRINTFORML 「もっとっ♥　気持ちよくしてけれっ♥♥」
```
