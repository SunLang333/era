# 口上/148 隠岐奈口上/_KOJO_COMMON_K148.ERB — 自动生成文档

源文件: `ERB/口上/148 隠岐奈口上/_KOJO_COMMON_K148.ERB`

类型: .ERB

自动摘要: functions: KOJO_EXIST_K148, KOJO_TRAIN_START_K148, KOJO_TRAIN_END_K148, KOJO_COM_TARGET_K148, KOJO_COM_PLAYER_K148, KOJO_COM_BEFORE_K148, KOJO_COM_AFTER_K148, KOJO_SINGLE_ENDING_K148, KOJO_DEAD_ENDING_K148; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;共通部分
;-------------------------------------------------
;=================================================
;●口上の存在判定
;=================================================
@KOJO_EXIST_K148

;=================================================
;●開始時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_START_K148

;=================================================
;●終了時
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_TRAIN_END_K148

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_TARGET_K148

;=================================================
;●コマンド実行時(このキャラがプレイヤー側のとき)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_PLAYER_K148

;=================================================
;●コマンド実行前(ターゲット・プレイヤー問わず)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_BEFORE_K148
RETURN 0

;=================================================
;●コマンド実行後(パラメータの変動処理が終わってから呼び出される)
;※状況にかかわらず常に実行される。取り扱い注意※
;=================================================
@KOJO_COM_AFTER_K148
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF
;-------------------------------------------------
;初絶頂は使い回せそうなのでここに作成
;-------------------------------------------------
;-------------------------------------------------
;初めてＣ絶頂
;-------------------------------------------------
IF NOWEX:Ｃ絶頂 > 0
PRINTFORML 
	IF CFLAG:220 == 0
		CFLAG:220 = 1
			PRINTFORML 「ふぁぁっ♥ あ……ぁ………こ、こんな…………」
			PRINTFORML 隠岐奈は初めてイかされた羞恥に身もだえしている。
	;2回目以降
	ELSE
		IF GETBIT(TALENT:淫乱系, 素質_淫乱_淫核)
			SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「あぁあああっ♥ もっとぉ、もっとさわってぇぇっ♥♥」
				PRINTFORML 隠岐奈はクリトリスで感じる快楽に悶え狂っている。
			CASE 1
				PRINTFORML 「ひうぅっ、きもちいっ♥♥ さきっぽ きもちぃぃっ♥♥♥」
				PRINTFORML クリトリスでの快楽に隠岐奈はすっかり虜になっている。
			CASE 2
				PRINTFORML 「だめぇっ♥♥ そんな触られたらぁぁっ♥♥♥♥」
				PRINTFORML 隠岐奈はビクンと大きく体を跳ねさせ、カクカクと腰を浮かせた。
			ENDSELECT
		;捕虜調教時
		ELSEIF FLAG:12 == 2
			IF TALENT:恋慕 || TALENT:服従
				SELECTCASE RAND:3
				CASE 0
					PRINTFORML 「あああぁっ……！！はぁっ……はぁっ……！ 」
					PRINTFORML 隠岐奈は腰をカクカクさせている……。
				CASE 1
					PRINTFORML 「あうぅ…イカされちゃった……」
					PRINTFORML 隠岐奈は絶頂に耐えきれず、ビクビクと震えている…。
				CASE 2
					PRINTFORML 「っっっ♥ はあっ、はぁぁ……み、見るなぁ……」
					PRINTFORML 隠岐奈は絶頂で緩んだ顔を手で隠そうとしている。
				ENDSELECT
			ELSE
				SELECTCASE RAND:2
				CASE 0
					PRINTFORML 「あっ！ はぁっ……はぁっ……！」
					PRINTFORML 隠岐奈は絶頂に耐えきれず、ビクビクと震えている…。
				CASE 1
					PRINTFORML 「っ♥ くっ、見るなぁ…」
					PRINTFORML 隠岐奈は絶頂で緩んだ顔を手で隠そうとしている。
				ENDSELECT
			ENDIF
		ELSE
			SELECTCASE RAND:3
			CASE 0
				PRINTFORML 「あああぁっ……！！はぁっ……はぁっ……！」
				PRINTFORML 隠岐奈は腰をカクカクさせている……。
			CASE 1
				PRINTFORML 「も、もう、お前が触りすぎるから………」
				PRINTFORML 隠岐奈は絶頂に耐えきれず、ビクビクと震えている…。
			CASE 2
				PRINTFORML 「っっっ♥ はあっ、はぁぁ………は、恥ずかしいから、見るなぁ……」
				PRINTFORML 隠岐奈は絶頂で緩んだ顔を手で隠そうとしている。
			ENDSELECT
		ENDIF
	ENDIF
ENDIF

;-------------------------------------------------
;初めてＶ絶頂
;-------------------------------------------------
IF NOWEX:Ｖ絶頂 > 0
PRINTFORML 
	IF CFLAG:221 == 0
		CFLAG:221 = 1
			PRINTFORML 「やっ、な、何かくるぅっ！？ひぁぁっっ…♥♥」
			PRINTFORML 隠岐奈は初めてのナカでの絶頂に大きく目を見開いている。
	;2回目以降
	ELSE
		;捕虜調教時
		IF FLAG:12 == 2
			IF TALENT:恋慕 || TALENT:服従
				SELECTCASE RAND:2
				CASE 0
					PRINTFORML 「――――っっ」
					PRINTFORML 隠岐奈は目をぎゅっとつむって絶頂の快楽を噛み締めている。
				CASE 1
					PRINTFORML 「わ、我ながらはしたない……うぅ……」
					PRINTFORML 隠岐奈は荒い息を吐きながら、絶頂の余韻に浸っている……
				ENDSELECT
			ELSE
				SELECTCASE RAND:2
				CASE 0
					PRINTFORML 「こ、腰が、がくがくして……やだぁ……」
				CASE 1
					PRINTFORML 「い、いってなんかないぃ……」
					PRINTFORML 隠岐奈は屈辱と快楽の板挟みになり、顔を真っ赤にして悶えている。
				ENDSELECT
			ENDIF
		ELSEIF GETBIT(TALENT:淫乱系, 素質_淫乱_淫壷)
			IF RAND:3 == 0
				PRINTFORML 「あっ、はぁッ♥♥ イっくぅぅッ♥♥♥」
				;セックス時
				IF SELECTCOM == 30 || SELECTCOM == 31 || SELECTCOM == 32 || SELECTCOM == 33 || SELECTCOM == 34 || SELECTCOM == 35 || SELECTCOM == 36 || SELECTCOM == 37 || SELECTCOM == 38 || SELECTCOM == 39 || SELECTCOM == 55 || SELECTCOM == 57
					PRINTFORML 絶頂と同時に、隠岐奈の膣が%ANAME(MASTER)%の精を求めて強く締めつけてきた…。
				ELSE
					PRINTFORML 隠岐奈は叫び声をあげて絶頂し、だらしないイキ顔を晒している…。
				ENDIF
			ELSEIF RAND:2 == 0
				;セックス時
				IF SELECTCOM == 30 || SELECTCOM == 31 || SELECTCOM == 32 || SELECTCOM == 33 || SELECTCOM == 34 || SELECTCOM == 35 || SELECTCOM == 36 || SELECTCOM == 37 || SELECTCOM == 38 || SELECTCOM == 39 || SELECTCOM == 55 || SELECTCOM == 57
					IF NOWEX:MASTER:射精 > 0
						PRINTFORML 「くっ、はぁっ、はあっ♥」
						PRINTFORML 「私より先にイくのは許さんぞ……っ♥」
					ELSE
						PRINTFORML 「はぁぁ……ま、まだまだやれるぞ…？ふふふっ♥」
						PRINTFORML 隠岐奈はにやにやと笑いながら、再び腰を動かし始めた…。
					ENDIF
				ELSE
					;指
					IF SELECTCOM == 3
						PRINTFORML 「あぁぁっ♥ ゆ、指だけでなんてぇぇ……っ♥♥♥」
						PRINTFORML 隠岐奈は屈辱と欲情をないまぜにした表情を浮かべている。
					;道具
					ELSEIF SELECTCOM == 22 || SELECTCOM == 61
						PRINTFORML 「あ、あああっ♥ 玩具ごときでっ、だめぇっ、イっくぅ…ッ♥」
						PRINTFORML 絶頂後、隠岐奈は焦点の合わない目で自身を辱める道具を見つめていた…。
					ENDIF
				ENDIF
			ELSE 
				IF RAND:3 == 0
					PRINTFORML 「うあああぁッ♥ はぁっはぁっ♥ 」
					PRINTFORML 「っ、ふぅぅ……気持ちいいぃ…♥♥♥」
					PRINTFORML 隠岐奈はあまりの快楽で無意識に腰をカクカクさせている……。
				ELSEIF RAND:2 == 0
					PRINTFORML 「だめぇっ、おっ、おかしくなるぅッ♥ へ、変になっちゃうぅぅッ♥♥♥」
					PRINTFORML 隠岐奈は叫び声をあげて絶頂し、秘神らしからぬだらしない表情を浮かべている。
				ELSE 
					PRINTFORML 「ひっ、あぁぁ～～ッ♥ はあッ…あ、はああぁ………っ♥♥」
					PRINTFORML 「ああぁ……♥ だ、だめだ……きもちよすぎるぅ……♥」
				ENDIF
			ENDIF
		ELSE
			IF RAND:3 == 0
				PRINTFORML 「ああっ♥ い、いくっ、うぅぅ……ッ♥♥」
				;セックス時
				IF SELECTCOM == 30 || SELECTCOM == 31 || SELECTCOM == 32 || SELECTCOM == 33 || SELECTCOM == 34 || SELECTCOM == 35 || SELECTCOM == 36 || SELECTCOM == 37 || SELECTCOM == 38 || SELECTCOM == 39 || SELECTCOM == 55 || SELECTCOM == 57
					PRINTFORML 絶頂と同時に、隠岐奈の膣がきゅんきゅんと締め付けてきた…。
				ELSE
					PRINTFORML 隠岐奈は快楽のあまり涎を零しながら、ビクビクと体を震わせている。
				ENDIF
			ELSEIF RAND:2 == 0
```
