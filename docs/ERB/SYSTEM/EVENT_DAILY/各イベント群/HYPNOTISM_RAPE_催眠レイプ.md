# SYSTEM/EVENT_DAILY/各イベント群/HYPNOTISM_RAPE_催眠レイプ.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/HYPNOTISM_RAPE_催眠レイプ.ERB`

类型: .ERB

自动摘要: assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;;---------------------
;;発生確率(1000分率 100で10%)
;;---------------------
;@EVENT_DAILY_HYPNOTISM_RAPE_RATE()
;RETURN (DVAR:催眠術 == 2 ? 150 # 30)
;
;;---------------------
;;確率以外の発生判定
;;---------------------
;@EVENT_DAILY_HYPNOTISM_RAPE_DECISION()
;SIF DAY < 10
;	RETURN 0
;;MASTERが男
;SIF !(IS_MALE(MASTER))
;	RETURN 0
;SIF DVAR:催眠術 == -1
;	RETURN 0 
;
;RETURN 1
;
;;---------------------
;;ジャンル
;;---------------------
;@EVENT_DAILY_HYPNOTISM_RAPE_GENRE()
;RETURN デイリー_ジャンル_エロ
;
;;---------------------
;;本体
;;---------------------
;@EVENT_DAILY_HYPNOTISM_RAPE
;#DIM 対象
;
;;催眠術を学んでおり、実行したことがあり、確率でシスターがくる
;IF DVAR:催眠術 == 2 && DVAR:催眠経験値 > 0 && RAND:8 == 0
;	CALL HYPNOTISM_RAPE_SISTER
;;ELSEIF DVAR:催眠経験値 + RAND:30 > 100
;;	CALL HYPNOTISM_RAPE_FUMBLE
;ELSEIF GROUPMATCH(DVAR:催眠術, 0, 1)
;	CALL HYPNOTISM_RAPE_CONTRACT
;	SIF RESULT == 0
;		RETURN 1
;	CALL HYPNOTISM_RAPE_PRACTICE(1)
;ELSEIF DVAR:催眠術 == 2
;	CALL HYPNOTISM_RAPE_PRACTICE(0)
;ENDIF
;
;RETURN 1
;
;
;;---------------------
;;シスターがくるイベント
;;---------------------
;@HYPNOTISM_RAPE_SISTER
;PRINTFORML ある日、シスターがやってきた
;PRINTFORML 彼女は%ANAME(MASTER)%が悪魔と契約して催眠術を手に入れたのを知っていた
;PRINTFORMW そのままでは%ANAME(MASTER)%はいつかとんでもない目に合うと忠告される
;PRINTFORML どうしよう？
;CALL ASK_MULTI("忠告に従う" ,"催眠レイプ" ,"追い払う")
;IF RESULT == 2
;	PRINTFORML 大きなお世話だ
;	PRINTFORMW 彼女を追い払った
;ELSEIF RESULT == 0
;	PRINTFORML 彼女の言葉に嘘はなさそうだ
;	PRINTFORML 忠告に従う事にした
;	PRINTFORMW %ANAME(MASTER)%と悪魔との契約は破棄し、催眠術を失った
;	DVAR:催眠術 = -1
;	DVAR:催眠経験値 = 0
;ELSE
;	IF DVAR:シスター == 0
;		PRINTFORML 長々とした説教にイラついていた%ANAME(MASTER)%だが
;		PRINTFORMW 彼女が中々良いボディラインをしているのに気付いた
;		PRINTFORML %ANAME(MASTER)%は彼女の言葉に感銘を受け従う振りをして近づき、催眠術を掛けた
;		PRINTFORMW …なんとも呆気なく彼女は催眠状態に陥った
;	ELSE
;		PRINTFORML %ANAME(MASTER)%は前回彼女が晒した醜態を思い出し笑ってしまった
;		PRINTFORML 怒って詰め寄ってくる彼女に対し、再び催眠術を掛けた
;		PRINTFORMW …やはり呆気なく催眠状態に陥った
;	ENDIF
;	PRINTFORML 抱き寄せて身体をまさぐると、彼女は熱っぽく喘いだ
;	PRINTFORMW %ANAME(MASTER)%はほくそ笑むと彼女を寝室に連れ込んだ
;	PRINTFORML 
;	SELECTCASE RAND:5
;		CASE 0
;			PRINTFORMW 彼女の身体は聖職者にあるまじき豊満さと感度で%ANAME(MASTER)%をとても楽しませてくれた
;		CASE 1
;			PRINTFORMW ビッチの様な台詞を彼女に吐かせ、その様を嘲りながらたっぷりと犯してやった
;		CASE 2
;			PRINTFORMW 変わらずに説教を続ける彼女に生返事をしながら、存分に種付けレイプを楽しんだ
;		CASE 3
;			PRINTFORMW 雌犬の様に発情し種付けをおねだりする彼女に応えて一晩じゅう調教を続けた
;		CASE 4
;			PRINTFORMW 身体の感度を何倍にも引き上げると、彼女は何度も無様に潮吹きアクメを繰り返した
;	ENDSELECT
;	CALL FUCK(MASTER, "性技, 性交, Ｃ, 射精", "童貞喪失, キス喪失", 0, "シスターの唇", "", @"シスターの膣", "催眠")
;	PRINTFORML 
;	PRINTFORMW 彼女は翌日、何事もなかったかのように%ANAME(MASTER)%に別れを告げた
;	PRINTFORMW 帰り際にたっぷりと射精した下腹部を撫でたが、彼女はキョトンとするだけだった
;	DVAR:催眠経験値 += RAND:5 + 1
;	DVAR:シスター = 1
;ENDIF
;RETURN 1
;
;;---------------------
;;確率で発動する喪失イベント
;;---------------------
;@HYPNOTISM_RAPE_FUMBLE
;PRINTFORML ある日、普通の催眠レイプにも飽きた%ANAME(MASTER)%は派手な事をしようと思いついた
;PRINTFORMW %ANAME(MASTER)%は女性達でごった返す銭湯に乗り込み、その場の全員に催眠を掛けた！
;PRINTFORML …しかしなぜか催眠術は発動しなかった
;PRINTFORMW 戸惑いながら何度も発動させようとするが何も起きない
;PRINTFORML そんなことをしている内に女性たちに囲まれ、捕まってしまった
;PRINTFORMW どんな弁明も意味をなさず、彼女たちに袋叩きにされてしまった………
;CALL ADD_COOLTIME(MASTER, 3)
;CALL COLOR_PRINT(@"これ以降、%ANAME(MASTER)%は一切の催眠術を失ってしまった…", カラー_注意)
;PRINTFORMW 
;DVAR:催眠術 = -1
;DVAR:催眠経験値 = 0
;RETURN 1
;
;;---------------------
;;契約
;;---------------------
;@HYPNOTISM_RAPE_CONTRACT
;
;IF DVAR:催眠術 == 0
;	PRINTFORML ある日、夢の中に悪魔が現れた
;	PRINTFORMW 彼は巨額と引き換えに、あらゆるものを従えうる強力な催眠術を授けてくれるという
;	CALL ICPRINT("具体的には、金<30000>をよこせとのことだ", "W", カラー_注意)
;ELSEIF DVAR:催眠術 == 1
;	PRINTFORML 再びあの悪魔が現れ契約を迫って来た
;	PRINTFORMW 契約内容は同じく金30000と引き換えに催眠術を授けてくれるというものだ
;ENDIF
;PRINTFORML どうしよう？
;CALL ASK_MULTI_JUDGE("取引する", MONEY >= 30000, "追い払う", 1)
;IF RESULT == 1
;	PRINTFORML 流石に悪魔と契約するつもりなどない
;	PRINTFORMW 追い払った
;	DVAR:催眠術 = 1
;	RETURN 0
;ENDIF
;PRINTFORML 悪魔の力の魅力に負けた%ANAME(MASTER)%は契約することにした
;PRINTFORMW 悪魔はニヤリと笑うと%ANAME(MASTER)%に手をかざした
;PRINTFORMW すると%ANAME(MASTER)%は力が湧いてくる感覚と、催眠術を使えるのだという確信を得た
;CALL COLOR_PRINTW(@"%ANAME(MASTER)%は【催眠術】を手に入れた", カラー_注意)
;CALL COLOR_PRINTW("金30000を支払った", カラー_注意)
;PRINTFORMW 
;DVAR:催眠術 = 2
;PRINTFORMW 悪魔は不気味に笑いながら霧の様に消え去った…
;PRINTFORMW 後になって調べると、財布から金がなくなっていた
;RETURN 1
;
;;---------------------
;;催眠実行
;;---------------------
;@HYPNOTISM_RAPE_PRACTICE(契約後)
;#DIM 契約後
;#DIM 実行メニュー
;#DIM 対象
;IF 契約後 == 1
;	PRINTFORMW 早速試しに行こうか？
;ELSE
;	PRINTFORML 仕事が一段落した
;	PRINTFORMW 今日も催眠に行こうか？
;ENDIF
;
;CALL ASK_YN("催眠に行く", "やめておく")
;
;IF RESULT == 1
;	PRINTFORMW 今日は疲れているのでやめておいた
;	RETURN
;ENDIF
;
;PRINTFORML もちろん催眠術を楽しませてもらおう
;PRINTFORMW さて、誰を狙おうか？
;CALL SINGLE_DRAWLINE
;CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("HYPONOTISM_RAPE", "NONE")
;IF RESULT == -1
;	PRINTFORMW やはり今日は疲れているのでやめておいた
;	RETURN
;ENDIF
;対象 = RESULT
;PRINTFORML %ANAME(対象)%にしよう
;PRINTFORMW %ANAME(MASTER)%は標的を定めると早速出かけた
;PRINTFORML ・
;PRINTFORML ・
;PRINTFORMW ・
;PRINTFORML 上手い具合に彼女が一人の時に遭遇した
;PRINTFORMW %ANAME(MASTER)%は彼女に親しげに話しかけると、催眠術を仕掛けた
;PRINTFORML すると彼女の瞳から光が消え、呆然としてその場で立ち尽くした
;PRINTFORMW どうやら催眠状態になったらしい
;PRINTFORML どうしよう？
;CALL ASK_MULTI("肉体開発する", "レイプする", "隷属させる")
;SELECTCASE RESULT
;	CASE 0
;		CALL HYPNOTISM_RAPE_PRACTICE_INVESTMENT(対象)
;	CASE 1
;		CALL HYPNOTISM_RAPE_PRACTICE_RAPE(対象)
;	CASE 2
;		CALL HYPONOTISM_RAPE_PRACTICE_ENSLAVEMENT(対象)
;ENDSELECT
```
