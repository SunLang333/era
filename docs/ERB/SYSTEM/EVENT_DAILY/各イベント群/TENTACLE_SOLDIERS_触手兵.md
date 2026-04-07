# SYSTEM/EVENT_DAILY/各イベント群/TENTACLE_SOLDIERS_触手兵.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/TENTACLE_SOLDIERS_触手兵.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_TENTACLE_SOLDIERS_RATE, EVENT_DAILY_TENTACLE_SOLDIERS_DECISION, EVENT_DAILY_TENTACLE_SOLDIERS_GENRE, EVENT_DAILY_TENTACLE_SOLDIERS; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_TENTACLE_SOLDIERS_RATE()
RETURN 20


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_TENTACLE_SOLDIERS_DECISION()
;触手部屋が必要
SIF !ITEM:触手部屋
	RETURN 0
RETURN DAY >= 10

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_TENTACLE_SOLDIERS_GENRE()
RETURN デイリー_ジャンル_エロ


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_TENTACLE_SOLDIERS()
#DIM 兵数
#DIM 兵数2


CALL COLOR_PRINT("飼っている触手が繁殖期を向かえています", カラー_注意)
PRINTFORML
PRINTFORMW 今日は飼っている触手の調子が良いようだ……
PRINTFORMW 丁度良い女性を与えれば彼らの子で増兵が見込めるかもしれない
PRINTL 
CALL COLOR_PRINT("適当な女性を捕まえて触手部屋に与えることが出来ます", カラー_緑)
PRINTFORML
CALL COLOR_PRINT("営みで産まれた触手を使って兵数を増やす事が出来ますが", カラー_緑)
PRINTFORML
CALL COLOR_PRINT("非道な行為なので周りの評判が下がります", カラー_緑)
PRINTFORML
PRINTFORML

CALL ASK_YN("適当な女を放り込む", "やめておく")
IF RESULT == 0
	;実行コスト
	FOR LOCAL:0, 0, MAX_COUNTRY
		CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -20, 20)
	NEXT
	;適当な女子を放り込む(触手おみくじ
	PRINTFORMW %ANAME(MASTER)%は兵士に命じて、適当な女を連れて来させた
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
				;人間だと上限が高い、妖怪だと下限が高い
				;妖精は上限も下限も低いけど評判が下がりにくい
	SELECTCASE RAND:13
		CASE 0
				;里娘
			PRINTFORML まだ幼い、黒髪の綺麗な里娘を兵士は連れてきた
			PRINTFORMW 怯えている里娘を触手部屋へ放り込むと、あっという間に触手が群がった
			PRINTFORML 怖い！やだぁ！と苦痛な叫びを上げる里娘の処女は、大きな触手によって一瞬で破られた
			PRINTFORML 痛みに震える足元には赤と白の混ざった液体が、ぼたぼたと流れて染みを作っている……
			PRINTFORMW 
			PRINTFORML その後里娘は毎日犯され続け、綺麗な黒髪は吐き出された精子でデコレートされていった
			PRINTFORMW 何度も触手を孕み、絶頂を繰り返した里娘は、触手の繁殖期が終わる頃は全身を性感帯に開発されていた……
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW ・
			SELECTCASE RAND:5
				CASE 0 TO 2
					兵数 = RAND(2000, 5000)
					PRINTFORML 触手の繁殖期が終わり、里娘は解放されたようだ
					PRINTFORM 里娘は期間中に
					CALL COLOR_PRINT(@"兵{兵数}に相当する触手", カラー_緑)
					PRINTFORMW を産み出しました！
				CASEELSE
					兵数 = RAND(3000, 8000)
					PRINTFORML 与えた里娘と触手の相性が良く、強靭な触手が産まれたようだ
					PRINTFORM 里娘は期間中に
					CALL COLOR_PRINT(@"兵{兵数}に相当する触手", カラー_緑)
					PRINTFORMW を産み出しました！！
			ENDSELECT
			PRINTFORML 
			SELECTCASE RAND:5
				CASE 0 TO 2
					PRINTFORML 里娘には触手によってしっかり女の幸せを覚えさせてから家に帰してあげました
					PRINTFORM 当然のように%ANAME(MASTER)%の勢力の
					CALL COLOR_PRINT(@"評判が下がりました", カラー_注意)
					PRINTFORMW
					FOR LOCAL:0, 0, MAX_COUNTRY
						SIF IS_COUNTRY(LOCAL)
							CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -150, 100)
					NEXT
				CASEELSE
					兵数2 = RAND(1000, 3500)
					COUNTRY_SOLDIER:(CFLAG:MASTER:所属) += 兵数2
					PRINTFORML 里娘は解放された後も疼きが止まらず、触手部屋に通うようになったようです
					PRINTFORM 追加で
					CALL COLOR_PRINT(@"兵{兵数2}に相当する触手", カラー_緑)
					PRINTFORMW を里娘は産み出しました！！
			ENDSELECT
		CASE 1
				;里娘
			PRINTFORML 貧しそうな、そばかすのある里娘を兵士は連れてきた
			PRINTFORMW 怯えている里娘を触手部屋へ放り込むと、あっという間に触手が群がった
			PRINTFORML 触手達は里娘の手足をがっちり拘束してから、精液で濡れた太い触棒を膣にあてがい
			PRINTFORML ここから出して！と涙を流して抵抗をする細身をたっぷりと犯しぬいた……
			PRINTFORMW 
			PRINTFORML 数日後、命の素を幾晩に渡って注ぎ込まれた里娘の腹部は小さく膨れていた
			PRINTFORMW 新しい命を産み出す為に貧相だった身体は触手に整えられ、声も身体も艶やかになっていた……
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW ・
			SELECTCASE RAND:5
				CASE 0 TO 2
					兵数 = RAND(2000, 5000)
					PRINTFORML 触手の繁殖期が終わり、里娘は解放されたようだ
					PRINTFORM 里娘は期間中に
					CALL COLOR_PRINT(@"兵{兵数}に相当する触手", カラー_緑)
					PRINTFORMW を産み出しました！
				CASEELSE
					兵数 = RAND(3000, 8000)
					PRINTFORML 触手と与えた里娘の相性が良く、強靭な触手が産まれたようだ
					PRINTFORM 里娘は期間中に
					CALL COLOR_PRINT(@"兵{兵数}に相当する触手", カラー_緑)
					PRINTFORMW を産み出しました！！
			ENDSELECT
			PRINTFORML 
			SELECTCASE RAND:5
				CASE 0 TO 2
					PRINTFORML 里娘は触手の力で健康体にしてから家に帰してあげました
					PRINTFORM しかし残念な事に%ANAME(MASTER)%の勢力の
					CALL COLOR_PRINT("評判が下がりました", カラー_注意)
					PRINTFORMW
					FOR LOCAL:0, 0, MAX_COUNTRY
						SIF IS_COUNTRY(LOCAL)
							CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -150, 100)
					NEXT
				CASEELSE
					兵数2 = RAND(1000, 3500)
					COUNTRY_SOLDIER:(CFLAG:MASTER:所属) += 兵数2
					PRINTFORML 里娘は触手に魅了され、解放された後も部屋に通うようになったようです
					PRINTFORM 追加で
					CALL COLOR_PRINT(@"兵{兵数2}に相当する触手", カラー_緑)
					PRINTFORMW を里娘は産み出しました！！
			ENDSELECT
		CASE 2
				;里娘(心綺楼)
			PRINTFORML 胸の大きな、売子姿の里娘を兵士は連れてきた
			PRINTFORMW 呆然とする里娘を触手部屋へ放り込むと、あっという間に触手が群がった
			PRINTFORML 閉じられた扉を叩く獲物の服へと触手は入り込み、媚薬を分泌しながら立派な胸や尻をこねくり廻した
			PRINTFORML そして数刻に渡って絶頂をさせ続けた後に、びしょびしょの膣を触手が一気に貫いていった……
			PRINTFORMW 
			PRINTFORML その後里娘はずっと触手に抱きかかえられて何度も犯され、子種を注ぎこまれ続けた
			PRINTFORMW そして数日後、触手の性欲が収まる頃には自ら精子を欲しがる様になっていた……
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORMW ・
			SELECTCASE RAND:5
				CASE 0 TO 2
					兵数 = RAND(2000, 5000)
					PRINTFORML 触手の繁殖期が終わり、里娘は解放されたようだ
					PRINTFORM 里娘は期間中に
					CALL COLOR_PRINT(@"兵{兵数}に相当する触手", カラー_緑)
					PRINTFORMW を産み出しました！
				CASEELSE
					兵数 = RAND(3000, 8000)
					PRINTFORML 触手と与えた里娘の相性が良く、強靭な触手が産まれたようだ
					PRINTFORM 里娘は期間中に
					CALL COLOR_PRINT(@"兵{兵数}に相当する触手", カラー_緑)
					PRINTFORMW を産み出しました！！
			ENDSELECT
			PRINTFORML 
			SELECTCASE RAND:5
				CASE 0 TO 2
					PRINTFORML 里娘は触手によって奉仕の心を教育されてから家に帰してあげました
					PRINTFORM しかし周りの受けが良くなかったのか%ANAME(MASTER)%の勢力の
					CALL COLOR_PRINT("評判が下がりました", カラー_注意)
					PRINTFORMW
					FOR LOCAL:0, 0, MAX_COUNTRY
						SIF IS_COUNTRY(LOCAL)
							CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -150, 100)
					NEXT
				CASEELSE
					兵数2 = RAND(1000, 3500)
					COUNTRY_SOLDIER:(CFLAG:MASTER:所属) += 兵数2
					PRINTFORML 里娘は解放された後も疼きが止まらず、触手部屋に通うようになったようです
					PRINTFORM 追加で
					CALL COLOR_PRINT(@"兵{兵数2}に相当する触手", カラー_緑)
					PRINTFORMW を里娘は産み出しました！！
			ENDSELECT
		CASE 3
```
