# SYSTEM/EVENT_DAILY/各イベント群/ZEGEN_人攫いの組織.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/ZEGEN_人攫いの組織.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_ZEGEN_RATE, EVENT_DAILY_ZEGEN_DECISION, EVENT_DAILY_ZEGEN_GENRE, EVENT_DAILY_ZEGEN, SELECT_CHARA_LIST_SHOW_LOGIC_ZEGEN, SELECT_CHARA_LIST_SELECT_LOGIC_ZEGEN, ZEGEN_SEXWORK; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_ZEGEN_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_ZEGEN_DECISION()
RETURN 12 <= DAY && !FLAG:クリアフラグ

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_ZEGEN_GENRE()
RETURN デイリー_ジャンル_エロ



;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_ZEGEN()
#DIM 対象
#DIM 金額
#DIM 対象都市
#DIM 捕虜番号, MAX_CHARA_NUM
VARSET LOCAL
VARSET 捕虜番号

PRINTFORML 人攫い組織の情報を掴んだ
PRINTFORML この組織は国々をまたにかけて暗躍しているらしい
PRINTFORMW どうしよう？
CALL ASK_MULTI("捜査する" ,"取引する" ,"無視する")
IF RESULT == 2
	PRINTFORMW 無視した
ELSEIF RESULT == 1
	PRINTFORML 取引することにした
	PRINTFORMW 組織に使いを出した
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
	PRINTFORML 組織の者がやってきた
	PRINTFORMW どうしよう？
	CALL ASK_MULTI_JUDGE("村娘を売る", 1,"他国の捕虜を買う", 1,"自分を売る", IS_FEMALE(MASTER) && !TALENT:MASTER:処女)
	IF RESULT == 0
		PRINTFORMW 村娘を売った
		金額 = 3000 + 1000 * (DAY / 5)
		MONEY += 金額 
		FOR LOCAL, 1, MAX_COUNTRY
			CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:1, -50, 50)
		NEXT
		CALL COLOR_PRINT(@"金{金額}を手に入れた", カラー_シアン)
		PRINTFORML 
		CALL COLOR_PRINT("噂が広がり他国の評判が下がった", カラー_警告)
		PRINTFORMW 
	ELSEIF RESULT == 1
		PRINTFORML 他国の捕虜を攫ってきてもらうことにした
		$SHOW_LOOP
		PRINTFORMW 誰を捕ってきてもらおうか？
		FOR LOCAL, 0, CHARANUM
			IF CFLAG:LOCAL:捕虜先 != 0 && CFLAG:LOCAL:捕虜先 != CFLAG:MASTER:所属 && !IS_SP_CHARA(LOCAL)
				捕虜番号:(LOCAL:1) = LOCAL
				IF SLAVE_TRADER_PRICE(LOCAL) <= MONEY
					PRINTFORM [{LOCAL:1}]%ANAME(LOCAL), 16, RIGHT% - 金{SLAVE_TRADER_PRICE(LOCAL), 6, RIGHT}
				ELSE
					SETCOLOR カラー_選択不可
					PRINTPLAINFORM [{LOCAL:1}]%ANAME(LOCAL), 16, RIGHT% - 金{SLAVE_TRADER_PRICE(LOCAL), 6, RIGHT}
					RESETCOLOR
				ENDIF
				PRINTL
				LOCAL:1 ++
			ENDIF
		NEXT
		CALL SINGLE_DRAWLINE
		PRINTFORML [1000] やめておく
		$INPUT_LOOP
		INPUT
		IF RESULT == 1000
			PRINTFORML やはりやめておこう
			PRINTFORMW 人攫いは肩をすくめて去っていった
			RETURN 1
		ELSEIF RESULT < 0 || RESULT >= LOCAL:1 || SLAVE_TRADER_PRICE(捕虜番号:RESULT) > MONEY
			GOTO INPUT_LOOP
		ELSE
			対象 = 捕虜番号:(RESULT)
			PRINTFORMW 「%ANAME(対象)%を捕まえてくればいいのですね？」
			CALL ASK_YN("頼む", "考え直す")
			IF RESULT == 1
				PRINTFORMW いや、やはりもう一度考え直そう
				CALL SINGLE_DRAWLINE
				GOTO SHOW_LOOP
			ELSE
				PRINTFORMW 人攫いを頼んだ
				PRINTFORML ・
				PRINTFORML ・
				PRINTFORMW ・
				PRINTFORML 彼らは見事に%PRONOUN(対象)%を攫ってきてくれた
				PRINTFORMW 高い買い物だったがあなたは満足して%PRONOUN(対象)%を見下ろした
				IF CFLAG:MASTER:所属 == CFLAG:対象:所属
					CALL CAPTURE(対象, 0)
				ELSE
					CALL CAPTURE(対象, CFLAG:MASTER:所属)
				ENDIF
				MONEY -= SLAVE_TRADER_PRICE(対象)
				CALL COLOR_PRINT(@"金{SLAVE_TRADER_PRICE(対象)}を支払った", カラー_注意)
				PRINTFORML 
				IF CFLAG:対象:所属 != CFLAG:MASTER:所属
					FOR LOCAL, 1, MAX_COUNTRY
						SIF IS_COUNTRY(LOCAL)
							CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -100, 100)
					NEXT
					CALL COLOR_PRINT("人攫い組織とのつながりがばれて他国の評判が下がった", カラー_警告)
					PRINTFORMW
				ENDIF
			ENDIF
		ENDIF
	ELSE
		PRINTFORML 自分を売ることにした
		PRINTFORMW 遊郭で働かされた
		CALL ZEGEN_SEXWORK(MASTER)
		金額 = 1000 + (ABL:MASTER:性交 + ABL:MASTER:性技 + ABL:MASTER:奉仕 + ABL:MASTER:Ｖ感) * 500
		MONEY += 金額 
		CALL COLOR_PRINT(@"金{金額}を手に入れた", カラー_シアン)
		PRINTFORMW
	ENDIF
ELSE
	PRINTFORML 捜査することにした
	PRINTFORML 怪しまれないように女性一人に任せよう
	PRINTFORMW 誰にする？
	CALL SINGLE_DRAWLINE
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("ZEGEN", "ZEGEN")
	対象 = RESULT
	IF RESULT == -1
		PRINTFORMW ……いや、やはり危険だ
		PRINTFORMW やめておくことにしよう……
		RETURN 1
	ELSEIF 対象 == MASTER
		PRINTFORMW %ANAME(対象)%自ら捜査することにした
	ELSE
		PRINTFORMW %ANAME(対象)%を捜査に向かわせた
	ENDIF
	CALL DAILY_EVENT_RAND_CITYSELECT(0)
	対象都市 = RESULT
	PRINTFORML 村娘に紛れて潜入に成功した
	PRINTFORML 他の娘と共に遊郭に連れていかれた
	PRINTFORMW どうしよう？
	CALL ASK_MULTI("武力制圧する" ,"客から情報を得る" ,"娘たちを逃がす")
	IF RESULT == 0
		PRINTFORMW 武力で制圧を試みた
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		IF ABL:対象:武闘 * (RAND:5 + 1) > 40 * (RAND:9 + 1)
			PRINTFORML 拠点を制圧した！
			PRINTFORMW これで国内での連中の活動は減るだろう
			IF 対象都市 > 0
				CITY_GUARD:対象都市 += 20
				CALL COLOR_PRINT(@"%CITY_NAME:対象都市%の防衛率が20上昇し、{CITY_GUARD:対象都市}になった", カラー_シアン)
				PRINTFORMW 
			ENDIF
		ELSE
			PRINTFORML 失敗してしまった……
			PRINTFORMW 薬を打たれて夢見心地になった%ANAME(対象)%は、客の相手をさせられることになった
			CALL ZEGEN_SEXWORK(対象)
			CFLAG:対象:薬物依存 += RAND(30, 60)
			PRINTFORMW その後、%ANAME(対象)%は何とか逃げ出した
		ENDIF
	ELSEIF RESULT == 2
		PRINTFORMW 娘たちを逃がすことにした
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		IF ABL:対象:知略 * (RAND:5 + 1) > 40 * (RAND:9 + 1)
			PRINTFORML 成功した！
			PRINTFORMW 救出した娘たちは家族たちと再会出来て泣いて喜んでいた
			FOR LOCAL, 1, MAX_COUNTRY
				SIF IS_COUNTRY(LOCAL)
					CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:1, 50, -50)
			NEXT
			CALL COLOR_PRINT("娘たちを助けたことで他国の評判が上がった", カラー_シアン)
			PRINTFORMW 
		ELSE
			PRINTFORML 失敗してしまった……
			PRINTFORMW 薬を打たれて夢見心地になった%ANAME(対象)%は、客の相手をさせられることになった
			CALL ZEGEN_SEXWORK(対象)
			CFLAG:対象:薬物依存 += RAND(30, 60)
			PRINTFORMW その後、%ANAME(対象)%は何とか逃げ出した
		ENDIF
	ELSE
		PRINTFORMW 客の相手をして情報を得ることにした
		CALL ZEGEN_SEXWORK(対象)
```
