# SYSTEM/EVENT_DAILY/各イベント群/SMUGGLER_薬売りの来訪.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/SMUGGLER_薬売りの来訪.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_SMUGGLER_RATE, EVENT_DAILY_SMUGGLER_DECISION, EVENT_DAILY_SMUGGLER_GENRE, EVENT_DAILY_SMUGGLER; UI/print

前 200 行源码片段:

```text
﻿
@EVENT_DAILY_SMUGGLER_RATE()
RETURN 80


@EVENT_DAILY_SMUGGLER_DECISION()
;斬ってたらダメ
SIF DVAR:薬売り_発生フラグ == -1
	RETURN 0
;調教中のキャラがいるならダメ
SIF ID_TO_CHARA(DVAR:薬売り_調教対象ID) != -1
	RETURN 0
RETURN 1

@EVENT_DAILY_SMUGGLER_GENRE()
RETURN デイリー_ジャンル_エロ

;密売人イベント
@EVENT_DAILY_SMUGGLER()
#DIM 料金
#DIM 対象
#DIM 能力計
#DIM 失敗率
#DIM 成功率
#DIM 高能力フラグ
#DIM 結果フラグ
#DIM 対象能力
#DIM 変化量
VARSET 高能力フラグ

料金 = RAND(10000, 30000)
IF GETBIT(TALENT:MASTER:デイリー系, 素質_デイリー_薬売りの性奴隷)
	PRINTFORMW 「よう性奴隷、ご主人様がきてやったぞ」
	PRINTFORMW %ANAME(MASTER)%の元へ、"ご主人様"が薬を売りに訪ねてきたようだ
	PRINTFORM 「お値段なんと、金
	CALL COLOR_PRINT(@"{料金}", カラー_注意)
	PRINTFORMW ポッキリ！　おら、とっとと払えや雌豚」
	PRINTFORMW さて、どうしようか……
ELSEIF DVAR:薬売り_陥落報告済み
	PRINTFORMW 「やぁやぁ%ANAME(MASTER)%さんよ、ワタクシが参りましたよ！」
	PRINTFORMW 「ほれ、また俺に女ァ差し出すために、クスリ買って下さいよ？」
	PRINTFORM 「お値段なんと、金
	CALL COLOR_PRINT(@"{料金}", カラー_注意)
	PRINTFORMW ポッキリ！　ほれ、買え」
	PRINTFORMW またあの男だ。薬を売りに来たようだ。どうしようか……
ELSEIF DVAR:薬売り_発生フラグ == 0
	PRINTFORML %ANAME(MASTER)%が仕事をしていると、侍従が来客を告げた
	PRINTFORML なんでも「いかにも怪しげな男が来た」のだそうだ
	PRINTFORMW いかにも怪しげ、というのがどれくらい怪しげなのかと思った%ANAME(MASTER)%は、会うことにしてみた
	PRINTFORML 
	PRINTFORML 
	PRINTFORML 
	PRINTFORMW 「いやぁこれはこれは！　%ANAME(MASTER)%様でございますね？　本日はお日柄もよく……」
	PRINTFORMW 揉み手をしながら現れたのは、なるほど確かに胡散臭い、小柄で痩せぎすの男だった。
	PRINTFORML 「申し遅れました、ワタクシ薬を売って歩いてまして。実は本日、とっておきの薬をお目にかけたく」
	PRINTFORM 「お値段なんと、金
	CALL COLOR_PRINT(@"{料金}", カラー_注意)
	PRINTFORMW ポッキリ。どうです？」
	PRINTFORM 金
	CALL COLOR_PRINT(@"{料金}", カラー_注意)
	PRINTFORML 。ポッキリどころかぼったくりだ。見せられないというのも疑わしい。
	PRINTFORMW 露骨に怪しいのは怪しいのだが、どうしようか……
ELSEIF DVAR:薬売り_発生フラグ == 1 || DVAR:薬売り_発生フラグ == 2
	PRINTFORMW 「やぁやぁ%ANAME(MASTER)%さま！　ワタクシが参りましたよ！」
	PRINTFORMW 「当たるも八卦・当たらぬも八卦の、すんばらしい薬でございます！」
	PRINTFORM 「お値段なんと、金
	CALL COLOR_PRINT(@"{料金}", カラー_注意)
	PRINTFORMW ポッキリ！　いかがですか！？」
	PRINTFORMW またあの男だ。薬を売りに来たようだ。どうしようか……
ENDIF
CALL SINGLE_DRAWLINE
PRINTFORML 現在の金:{MONEY}
CALL ASK_MULTI_JUDGE("買ってみる", MONEY >= 料金, "やめておく", 1, "うざいので斬る", 1)
IF RESULT == 1
	$DENIED
	PRINTFORMW 当然、買うわけがない。どうせ詐欺に決まっているのだから
	PRINTFORMW 「あーそうですか。ならこんな辛気くさいとこに用はない。サヨナラだサヨナラ。けっ」
	PRINTFORMW 男が早々に立ち去った後、%ANAME(MASTER)%は塩をまいておいた……
	RETURN 1
ELSEIF RESULT == 2
	PRINTFORMW 「イヤーッ！」
	PRINTFORMW 「アバーッ！」
	PRINTFORMW ……つい勢いで斬ってしまった。まだ息があるようだがどうしてくれよう。
	CALL ASK_MULTI_JUDGE("晒し首にする", 1, "性奴隷にする", 1, "触手のおやつにする", ITEM:触手部屋 && ID_TO_CHARA(FLAG:触手部屋管理者) != -1)
	SELECTCASE RESULT
		CASE 0
			PRINTFORMW こんな男を生かしておく理由もあるまい
			PRINTFORMW %ANAME(MASTER)%は悪徳商人の末路として男を晒し首にした
			PRINTFORMW 他の勢力からの評価が少しだけ上がった
			FOR LOCAL, 1, MAX_COUNTRY
				CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, 20)
			NEXT
		CASE 1
			PRINTFORMW %ANAME(MASTER)%は男を手当てして性奴隷に回すよう命じた
			PRINTFORMW 驚いたことに兵士から好評を博し、{料金 / 20}の兵力が集まった
			COUNTRY_SOLDIER:(CFLAG:MASTER:所属) += 料金 / 20

		CASE 2
			PRINTFORMW %ANAME(MASTER)%は男を触手部屋に放り込んだ
			PRINTFORMW かわいい触手たちが腹を下さないか少し心配だったが杞憂だったようだ。
			CALL PRINT_ADD_EXP(ID_TO_CHARA(FLAG:触手部屋管理者), "妖術経験値", 料金 / 1000)
			CALL TRAIN_AUTO_ABLUP(ID_TO_CHARA(FLAG:触手部屋管理者))
	ENDSELECT
	DVAR:薬売り_発生フラグ = -1
	RETURN 1
ELSE
	PRINTFORMW 「いやぁ～～さすが！　お目が高い！　すばらしい！　いよっ！　幻想郷イチ！」
	PRINTFORMW むやみと調子のいい男だ……
ENDIF
CALL SINGLE_DRAWLINE
PRINTFORMW 「ささ、誰が服用するんで？」
PRINTFORMW さて、誰に飲ませよう……
CALL SINGLE_DRAWLINE

CALL SELECT_CHARA_LIST_SLG

IF RESULT == -1
	GOTO DENIED
ENDIF

対象 = RESULT


IF MONEY >= 料金 * 2
	料金 *= 2
	PRINTFORM 「おっと、悪いけどこの薬は立った今値上げしたよ。今じゃ金
	CALL COLOR_PRINT(@"{料金}", カラー_注意)
	PRINTFORMW する貴重品さ」
	PRINTFORMW 「イヒヒッ、というわけでこの金はいただいていくよ」
	PRINTFORM 法外じゃないかという暇すら与えず、男は本当に金
	CALL COLOR_PRINT(@"{料金}", カラー_注意)
	PRINTFORMW をもっていってしまった……
ENDIF


MONEY -= 料金


;効果選択
;------------成功率・変化量算出----------------
能力計 = ABL:対象:武闘 + ABL:対象:知略 + ABL:対象:政治 + ABL:対象:防衛
;失敗率は3能力の1/5
失敗率 = 能力計 / 5
;能力計に応じ、失敗率に補正
SELECTCASE 能力計
	CASE IS < 200
		失敗率 -= 10
	CASE IS > 250
		失敗率 += 5
ENDSELECT
;80以上ある能力を保存
IF ABL:(対象):武闘 >= 80
	SETBIT 高能力フラグ, 0
	失敗率 += 5
ENDIF
IF ABL:対象:防衛 >= 80
	SETBIT 高能力フラグ , 1
	失敗率 += 5
ENDIF
IF ABL:(対象):知略 >= 80
	SETBIT 高能力フラグ, 2
	失敗率 += 5
ENDIF
IF ABL:(対象):政治 >= 80
	SETBIT 高能力フラグ, 3
	失敗率 += 5
ENDIF
;失敗
IF RAND:100 < 失敗率
	;対象能力を決定する
	;80以上のものがあればそれらの中から選択する
	FOR LOCAL:0, 0, 4
		;80より小さければ上の処理でビットが立っていないので、GETBITの返値が0
		;RANDが(100 * 0, 100 * 0 + 100)となるので、RAND(0, 100)になる。80より大きければ左右で100 * 1となり、RAND(100, 200)になる
		;結果、80以上が確実に選出される
		LOCAL:(LOCAL + 1) = RAND(GETBIT(高能力フラグ, LOCAL:0) * 100, GETBIT(高能力フラグ, LOCAL:0) * 100 + 100)
	NEXT
	対象能力 = FINDELEMENT(LOCAL, MAXARRAY(LOCAL, 1, 5), 1, 5) + 49
	;変化量は5 ~ 10
	変化量 = RAND(5, 11)
	結果フラグ = 0
;成功
ELSE
	;対象能力を決定する
	;80以上のものがあればそれは回避しようとする
	FOR LOCAL:0, 0, 3
		;失敗パターンとは逆。80以上だとRAND(-100, 0)で、80より小さければRAND(0, 100)
		;結果、80以上は回避される（全部80以上ならともかく）
		LOCAL:(LOCAL + 1) = RAND(GETBIT(高能力フラグ, LOCAL:0) * -100, GETBIT(高能力フラグ, LOCAL:0) * -100 + 100)
	NEXT
	対象能力 = FINDELEMENT(LOCAL, MAXARRAY(LOCAL, 1, 5), 1, 5) + 49
	;変化量は10~15
	;能力計が250以上あると5～10になる
	変化量 = RAND(10, 16)
	SIF 能力計 >= 250
		変化量 -= 5
	結果フラグ = 1
ENDIF

;成功パターン
```
