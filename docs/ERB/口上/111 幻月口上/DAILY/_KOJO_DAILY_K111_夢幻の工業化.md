# 口上/111 幻月口上/DAILY/_KOJO_DAILY_K111_夢幻の工業化.ERB — 自动生成文档

源文件: `ERB/口上/111 幻月口上/DAILY/_KOJO_DAILY_K111_夢幻の工業化.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K111_Industrialization_RATE, KOJO_DAILY_K111_Industrialization_DECISION, KOJO_DAILY_K111_Industrialization_GENRE, KOJO_DAILY_K111_Industrialization; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K111_Industrialization_RATE(対象)
#DIM 対象
RETURN 50


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K111_Industrialization_DECISION(対象)
#DIM 対象

;流れ的にはあなたが君主の場合であろう
SIF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) != MASTER
	RETURN 0


RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)
;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K111_Industrialization_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_その他

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K111_Industrialization(対象)
#DIM 対象
#DIM 対象_都市_経済
#DIM 経済要素
#DIM 対象_都市
#DIM 増減額
#DIM 失敗

;自国都市ランダム
CALL DAILY_EVENT_RAND_CITYSELECT(0)
対象_都市 = RESULT

;SHAFFLE_ARRAY
;MONEY:(CFLAG:MASTER:所属)

PRINTFORMW いつものように書類仕事をこなしていると、%ANAME(対象)%がやってきた

;初見
IF 幻月_DAILY_経済効果 == "初見"
	PRINTFORML 話を聞くと、現在の自国は他国に比べて工業力に劣っているらしい
	PRINTFORML 実際戦場に出ていても、相手国の武器と比べると自軍の武器は劣っているのは事実である
	PRINTFORML 戦場に出ているので、その話は痛いほどよく分かる。
	PRINTFORML 更に彼女の世界「夢幻世界」は、多くの時間を閉鎖的な環境で過ごしてきたため、設備も経験もないのが現状である。
	PRINTFORMW そこで、数少ない学者たちにより「　%GET_CITYNAME(対象_都市)%　」に工業化を見出したらしい。

ELSEIF 幻月_DAILY_経済効果 == "初見キャンセル"
	PRINTFORML 話を聞くと、前回計画していた「　%GET_CITYNAME(幻月_DAILY_指定都市)%　」の工業化を今度は「　%GET_CITYNAME(対象_都市)%　」に行ったという話であった。
	PRINTFORML 「やっぱり諦めきれないの...」
	PRINTFORML 「投資はリスクを伴うけれど、リスクを負わなければリターンは得られないと思うわ」
	PRINTFORMW 「だめ...かしら？」
	PRINTFORML

;既読
ELSEIF 幻月_DAILY_経済効果 == "成功" ||  幻月_DAILY_経済効果 == "大成功" || 幻月_DAILY_経済効果 == "失敗"

	;前回の都市と今回の都市が同一か？
	IF 対象_都市 == 幻月_DAILY_指定都市
		PRINTFORML 話を聞くと、前回同様「　%GET_CITYNAME(対象_都市)%　」の工業化に向けた話であった

	ELSE

		PRINTFORML 話を聞くと、前回「　%GET_CITYNAME(幻月_DAILY_指定都市)%　」の工業化を今度は「　%GET_CITYNAME(対象_都市)%　」に行おうという話であった。
	ENDIF

	PRINTFORML 実際戦場に出ていても、相手国の武器と比べると自軍の武器は劣っているのは事実である
	PRINTFORML 戦場に出ているので、その話は痛いほどよく分かる。
	;前回キャンセル
ELSE
	PRINTFORML 前回断った工業化の話であった。
	PRINTFORML あれから再調査をし、「　%GET_CITYNAME(対象_都市)%　」の工業化が可能とのこと
ENDIF

	;前回はどのような結果だった？
IF 幻月_DAILY_経済効果 == "キャンセル"
	PRINTFORML 「やっぱり諦めきれないの...」
	PRINTFORML 「投資はリスクを伴うけれど、リスクを負わなければリターンは得られないと思うわ」
	PRINTFORMW 「だめ...かしら？」

ELSEIF 幻月_DAILY_経済効果 == "成功"
	PRINTFORML 「また、なんだけれど」
	PRINTFORML 「正直言うと申し訳ないのだけれど、この予算では限定的な経済成長だったわ」
	PRINTFORMW 「無理に、とは言わないけれど...列強に追いつくにはまだ足りないわ」

ELSEIF 幻月_DAILY_経済効果 == "大成功"
	PRINTFORML 「この前はありがとう」
	PRINTFORML 「おかげで列強に近づく事ができたわ」
	PRINTFORML 「できれば、前回と同等かそれ以上の予算をもらえると嬉しいのだけれど」
	PRINTFORMW 「まだまだ足りないわ」

ELSEIF 幻月_DAILY_経済効果 == "失敗"
	PRINTFORML 「前回はごめん...」
	PRINTFORML 「言い訳になるけど、やっぱり経験が足りないわ」
	PRINTFORML 「こればかりは、お金じゃ買えないのよね～」
	PRINTFORML 「再開発や法整備に凄くお金がかかってるの」
	PRINTFORMW 「予算をあげて貰えれば、ね、頼むわ」

	;無いと思うけど
ELSE
	;PRINTFORML 
ENDIF

	;初回限定の選択肢
IF KDVAR:対象:幻月_夢幻の工業化 == 0
	PRINTFORMW 「初回はこれだけ見積もってみたんだけれど...」
	PRINTFORML 
	PRINTFORML 現在の国庫:"{MONEY:(CFLAG:MASTER:所属)}"
	CALL COLOR_PRINTW(@"「　%GET_CITYNAME(対象_都市)%　」の工業化には15,000かかります", カラー_注意)

	CALL ASK_MULTI_JUDGE("投資する", MONEY:(CFLAG:MASTER:所属) >= 15000, "やめておく", 1)
	IF RESULT == 1
		PRINTFORML 「あら、そう...残念だわ」

		SIF MONEY:(CFLAG:MASTER:所属) <= 15000
			PRINTFORMW 「今は資金の余裕が無いのかもしれないわね」

		PRINTFORMW 「ただ、また今度来るわ」
		PRINTFORMW 「我々は常に前に進まなければならないのだから」

		幻月_DAILY_指定都市 = 対象_都市
		幻月_DAILY_経済効果 = 初見キャンセル
			;デイリー終了
		RETURN 1

	ELSEIF RESULT == 0 && MONEY:(CFLAG:MASTER:所属) >= 15000
			;表示される数字の100倍がCITY_ECONOMYには保存されている　つまり下二桁は実質の小数点二桁
			;最初に100で割って100をかけるのは、実質のFLOOR
		対象_都市_経済 = RAND(CITY_ECONOMY_LIMIT:(対象_都市) / 100 * 100 / 10 , CITY_ECONOMY_LIMIT:(対象_都市) / 100 * 100 / 10 + 1000)
		対象_都市_経済 += 100
		CALL MODIFY_CITY_ECONOMY(対象_都市, 対象_都市_経済)

			;次回への持ち越し組
		幻月_DAILY_経済効果 = 成功
		幻月_DAILY_投資金額 = 15000
		KDVAR:対象:幻月_夢幻の工業化 = 1

		;ここまで来ないと思う
	ELSE
			;PRINTFORMW 
	ENDIF

	;初見以降
ELSE 
		;増減額計算
	増減額 = 1000 * KDVAR:対象:幻月_夢幻の工業化
	PRINTFORML さて、どうするか
	PRINTFORML 現在の国庫:"{MONEY:(CFLAG:MASTER:所属)}"
	PRINTFORML 投資額:"{幻月_DAILY_投資金額}"
	PRINTFORML 
	PRINTFORML 増減額:{増減額}
	PRINTFORML 
	PRINTFORML 増額後:{幻月_DAILY_投資金額 + 増減額}
	PRINTFORML 減額後:{幻月_DAILY_投資金額 - 増減額}
	CALL COLOR_PRINTW("※投資は10,000を下回る事は出来ない", カラー_注意)

	CALL ASK_MULTI_JUDGE("増額する", MONEY:(CFLAG:MASTER:所属) >= 幻月_DAILY_投資金額 + 増減額, "減額する", MONEY:(CFLAG:MASTER:所属) >= 幻月_DAILY_投資金額 + 増減額 && 10000 <= 幻月_DAILY_投資金額 + 増減額, "現状維持", MONEY:(CFLAG:MASTER:所属) >= 幻月_DAILY_投資金額, "投資を中断する", 4 )

	IF RESULT == 0
		KDVAR:対象:幻月_夢幻の工業化 += 1
		幻月_DAILY_投資金額 += 増減額

		幻月_DAILY_経済効果 = 成功
			;大成功判定、増額すると確率が上がる
		経済要素 = RAND:100

		SIF 経済要素 <=  10 + 2 * KDVAR:対象:幻月_夢幻の工業化
			幻月_DAILY_経済効果 = 大成功

		IF 幻月_DAILY_経済効果 == "大成功"
			CALL COLOR_PRINTW(@"%ANAME(MASTER)%の投資は%ANAME(対象)%によって適切に「　%GET_CITYNAME(対象_都市)%　」へ配分され予想以上の発展を遂げた！}", カラー_注意)
			経済要素 = 300
			経済要素 += 5 * KDVAR:対象:幻月_夢幻の工業化
			経済要素 += 増減額 / 10000

			;通常成功
		ELSE
			PRINTFORML ・・・・・・・・・
			PRINTFORML ・・・・・・
			PRINTFORML ・・・
			PRINTFORMW 「投資はうまくいったわ、これでまだ戦えるわよ」
			経済要素 = 200
			経済要素 += 増減額 / 10000
		ENDIF

	ELSEIF RESULT == 1
```
