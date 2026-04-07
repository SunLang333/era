# SYSTEM/EVENT_DAILY/各イベント群/HYPNOTISM_TRAINER_催眠トレーナー.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/HYPNOTISM_TRAINER_催眠トレーナー.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_HYPNOTISM_TRAINER_RATE, EVENT_DAILY_HYPNOTISM_TRAINER_DECISION, EVENT_DAILY_HYPNOTISM_TRAINER_GENRE, EVENT_DAILY_HYPNOTISM_TRAINER, SELECT_CHARA_LIST_SHOW_LOGIC_HYPNOTISM_TRAINER, SELECT_CHARA_LIST_COLOR_LOGIC_HYPNOTISM_TRAINER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_HYPNOTISM_TRAINER_RATE()
RETURN (DVAR:催眠トレーナー_前回対象者ID > 0 ? 150 # 30)

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_HYPNOTISM_TRAINER_DECISION()
SIF DAY < 10
	RETURN 0
SIF DVAR:催眠トレーナー_発生フラグ == 2
	RETURN 0
SIF MONEY < 20000
	RETURN 0
RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_HYPNOTISM_TRAINER_GENRE()
RETURN デイリー_ジャンル_トレーナー

;---------------------
;本体
;---------------------
@EVENT_DAILY_HYPNOTISM_TRAINER
#DIM 対象
#DIM 対象素質
#DIMS TN

IF DVAR:催眠トレーナー_発生フラグ == 1
	PRINTFORMW 再び例の催眠術師がやって来た
ELSE
	PRINTFORML 催眠術師を名乗る男がやって来た
	PRINTFORMW 金と引き換えに仲間の人格や素質を変えてくれると言う
	CALL COLOR_PRINTL("料金は一回につき金", ,"<20000>", カラー_注意, "だ")
	PRINTFORML 確実では無い様だが、回数を重ねれば成功しやすくなるらしい
	PRINTFORMW 見るからに胡散臭い男だがどことなく説得力を感じる
ENDIF
IF ID_TO_CHARA(DVAR:催眠トレーナー_前回対象者ID) == MASTER && IS_FEMALE(MASTER)
	PRINTFORMW %ANAME(MASTER)%は彼の顔を見るとなぜか胸の奥が疼くのを感じた
ENDIF
PRINTFORML どうしよう？
CALL ASK_MULTI_JUDGE("催眠を頼む", MONEY >= 20000,"追い出す", 1,"切り捨てる", 1)
IF RESULT == 2
	PRINTFORML そんな危ない男を放置はできない
	PRINTFORMW %ANAME(MASTER)%は催眠術師を剣を抜いて男に斬りかかった！
	PRINTFORML 
	IF GETBIT(TALENT:MASTER:デイリー系, 素質_デイリー_催眠中毒)
		PRINTFORML …しかし次の瞬間%ANAME(MASTER)%の思考は停止し、剣を落とし呆然とその場に立ち尽くした
		PRINTFORMW すっかり男の催眠にハメられている%ANAME(MASTER)%はもはや彼に逆らうことは出来なくなっていたのだ
		PRINTFORML 彼は冷汗をぬぐうと腹いせとばかりに%ANAME(MASTER)%に裸になるように命令する
		PRINTFORML %ANAME(MASTER)%はただその命令に従い服を脱ぎすてると、男によく見える様にその裸体を露にした
		PRINTFORMW 催眠術師は下卑た笑みを浮かべると尻を揉みながら%ANAME(MASTER)%を寝室へと連れ込んだ
		PRINTFORML ・
		PRINTFORML ・・
		PRINTFORMW ・・・
		PRINTFORML 数時間後、%ANAME(MASTER)%は男を見送っていた
		PRINTFORML はて、彼と何をしていたのだったか？
		PRINTFORMW 首をひねりながら仕事に戻る%ANAME(MASTER)%の太ももに、つつーっと精液が伝っていた
	ELSE
		PRINTFORML 男は悲鳴を上げながら倒れ伏した
		PRINTFORMW 男の懐を漁ったが特に金目のものも怪しいものも見つからなかった
		PRINTFORMW %ANAME(MASTER)%は男の死体を兵士に始末させ仕事に戻った
		DVAR:催眠トレーナー_発生フラグ = 2
	ENDIF
	RETURN
ELSEIF RESULT == 1
	PRINTFORML 生憎だが今そんなことは必要ない
	PRINTFORMW 男は怪しげな笑みを浮かべて去って行った
	DVAR:催眠トレーナー_前回対象者ID = 0
	DVAR:催眠トレーナー_発生フラグ = 1
	RETURN
ENDIF

PRINTFORML 催眠を頼むことにした
PRINTFORMW 誰にしてもらおう？
CALL SINGLE_DRAWLINE
;対象を決める
CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("HYPNOTISM_TRAINER", "NONE", "HYPNOTISM_TRAINER")
対象 = RESULT
IF 対象 == -1
	PRINTFORMW やはりやめておいた
	DVAR:催眠トレーナー_発生フラグ = 1
	RETURN 1
ENDIF
IF 対象 == MASTER
	PRINTFORMW 自分に施してもらう事にした
ELSE
	PRINTFORMW %ANAME(対象)%に施してもらう事にした
ENDIF

IF 対象 == ID_TO_CHARA(DVAR:催眠トレーナー_前回対象者ID) && IS_FEMALE(対象)
	SIF 対象 != MASTER
		PRINTFORMW %ANAME(対象)%は彼と瞳を合わせるとなにやらもじもじしだした
	DVAR:催眠トレーナー_深度 ++
ELSE
	IF IS_FEMALE(対象)
		DVAR:催眠トレーナー_前回対象者ID = GET_ID(対象)
	ELSE
		DVAR:催眠トレーナー_前回対象者ID = 0
	ENDIF
	DVAR:催眠トレーナー_深度 = 1
	DVAR:催眠トレーナー_レイプ回数 = 0
ENDIF

PRINTFORMW さて、どのように変えてもらおうか？
CALL SINGLE_DRAWLINE
;種類を決める
LOCAL:3 = 0
FOR LOCAL:0, 3, 300
	TN = %TALENTNAME:(LOCAL:0)%
	IF TN != ""
		;非表示素質のスキップ
		IF GROUPMATCH(TN, "バストサイズ", "ペニスサイズ")
			CONTINUE
		ELSEIF LOCAL:0 >= 150 && LOCAL:0 <= 179 && !GROUPMATCH(TN, "合意", "母性")
			CONTINUE
		ELSEIF LOCAL:0 >= 295 && LOCAL:0 <= 299
			CONTINUE
		ENDIF
		LOCAL:3 ++
	ENDIF
NEXT
LOCAL:3 = 0
LOCAL:5 = 0
FOR LOCAL:0, 3, 300
	TN = %TALENTNAME:(LOCAL:0)%
	IF TN != ""
		;非表示素質のスキップ
		IF GROUPMATCH(TN, "キス未経験", "アナル処女", "バストサイズ", "ペニスサイズ")
			CONTINUE
		ELSEIF LOCAL:0 > 85
			CONTINUE
		ENDIF
		;改行判定
		IF LOCAL:5 % 4 == 0
			IF LOCAL:5 >= 1
				PRINTL 
			ENDIF
			PRINT   
		ENDIF
		LOCAL:5 ++
		IF TALENT:対象:(LOCAL:0)
			SETCOLOR カラー_選択中
		ENDIF
		PRINTBUTTON @"{LOCAL:0, 3}\{%TN, 14%\}", LOCAL:0
		RESETCOLOR
		PRINT    
		LOCAL:3 ++
	ENDIF
NEXT
PRINTFORML [0] キャンセル
CALL SINGLE_DRAWLINE

$INPUT_LOOP
INPUT

IF RESULT == 0
	PRINTFORMW やはりやめておいた
	RETURN
ELSEIF  RESULT < 10 || RESULT > 85
	GOTO INPUT_LOOP
ELSE
	対象素質 = RESULT
	TN = %TALENTNAME:対象素質%
	PRINTFORMW [%TN%]を頼んだ
ENDIF

PRINTFORMW 彼は早速%ANAME(対象)%を使われていない部屋へ連れ込んだ
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・

IF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_催眠中毒)
	PRINTFORML 部屋に連れ込まれた%ANAME(対象)%はいつも通り催眠状態で男に犯されている
	PRINTFORML ペニスで膣肉を抉られる度に%ANAME(対象)%の理性がブチブチと音を立てて破壊され快楽で上書きされる
	PRINTFORML もはや身体は彼の玩具に成り下がり、乳首も陰核もビキビキに勃起しながらあられもなくイキ狂う
	PRINTFORMW そして彼のザーメンが子宮に放たれると、待望の熱に獣の様な嬌声を上げて絶頂するのだった
	DVAR:催眠トレーナー_深度 ++

ELSEIF DVAR:催眠トレーナー_深度 >= 3 && IS_FEMALE(対象)
	SELECTCASE DVAR:催眠トレーナー_レイプ回数
		CASE 0
			PRINTFORML 「ぐぅぅ！なんてすばらしい雌穴だ！想像以上だぜ！」
			PRINTFORML 男が覆い被さりながら激しく腰を振って%ANAME(対象)%を犯している
			PRINTFORML ぐっちゅぐっちゅと卑猥な音を立てながら彼のペニスが%ANAME(対象)%の秘所を出入りする
			PRINTFORMW 催眠状態の%ANAME(対象)%は朦朧とした表情で彼にしがみつきながらただ快楽のままに喘ぐ
			PRINTFORML 「おら！このドスケベ雌穴が！もっと締め付けろ！」
			PRINTFORML 上書きされる命令に%ANAME(対象)%は思考をチカチカさせながらもぎゅうっと膣を締め付ける
			PRINTFORML 「おっ！おっ！いいぞ！くそっ、ご褒美に種付けしてやるぞ！子宮開けろ！おら！孕めぇ！」
			PRINTFORMW 彼が大きく腰を突き出すと、びゅるるる！と大量の精液が%ANAME(対象)%の中へと放たれた
			PRINTFORML すっかり調教されきっていた%ANAME(対象)%の身体はその一発で意識毎吹き飛ぶ様な快楽を受け、絶頂した
			PRINTFORML %ANAME(対象)%は痙攣しながらも全身で彼にしがみついて、どくん♥どくん♥と胎内に注がれる子種を感じた
			PRINTFORML 「ふぅ、たまらねぇぜ…なんだお前もまだ欲しいのか？へへっ、まだまだたっぷり可愛がってやるよ」
			PRINTFORMW すっかり意識の底まで快楽を刻み込まれた%ANAME(対象)%は、自らおねだりしてその後も何度も彼に抱かれた
			DVAR:催眠トレーナー_レイプ回数 ++
		CASE 1
```
