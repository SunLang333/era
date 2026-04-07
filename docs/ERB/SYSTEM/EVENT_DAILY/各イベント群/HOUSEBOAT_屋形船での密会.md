# SYSTEM/EVENT_DAILY/各イベント群/HOUSEBOAT_屋形船での密会.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/HOUSEBOAT_屋形船での密会.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_HOUSEBOAT_RATE, EVENT_DAILY_HOUSEBOAT_DECISION, EVENT_DAILY_HOUSEBOAT_GENRE, EVENT_DAILY_HOUSEBOAT, SELECT_CHARA_LIST_SHOW_LOGIC_HOUSEBOAT, SELECT_CHARA_LIST_SELECT_LOGIC_HOUSEBOAT, HOUSEBOAT_RAPE, HOUSEBOAT_INSULT; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_HOUSEBOAT_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_HOUSEBOAT_DECISION()
RETURN DAY >= 12

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_HOUSEBOAT_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_HOUSEBOAT()
#DIM 対象
#DIM 金額

IF DVAR:屋形船_発生フラグ == 0
	PRINTFORML ある日、屋形船の招待状と着物が届いた
	PRINTFORML 地底の温泉街で妖怪が経営しているもので、粋な内装と幻想的な雰囲気が評判らしい
	PRINTFORMW 招待主は幻想郷各地でマフィアまがいの活動をしている野良妖怪集団の首領だ
	PRINTFORML …しかし招待といっても殆ど脅迫状の様なものだ
	PRINTFORML その内容は野盗に攫われた村娘を保護したので、その扱いについて話し合いがしたい、との事だ
	PRINTFORML 白々しい内容だ、本当は連中が攫ったのかもしれない
	PRINTFORMW だが無碍に断ったら彼女たちがどうなってしまうのかは想像に難くない
	DVAR:屋形船_発生フラグ = 1
ELSEIF DVAR:屋形船_発生フラグ == 2
	PRINTFORML %ANAME(MASTER)%の元に再び、屋形船の“招待状”が届いた
	PRINTFORML 前回やつらの首領を殺したはずだが、新たな妖怪が組織を引き継いだらしい
	PRINTFORMW 内容は前回と同じく、領民たちの扱いについての話し合いについてだ
ELSE
	PRINTFORML %ANAME(MASTER)%の元に再び、屋形船の“招待状”が届いた
	PRINTFORML 内容は前回と同じく、領民たちの扱いについての話し合いについてだ
	PRINTFORMW あんな連中とはもう関わりたくないのだが……
ENDIF
$ASK_LOOP
PRINTFORML どうしよう？
CALL ASK_MULTI("招待を受ける" ,"断る" ,"特殊部隊を送る")
IF RESULT == 2
	PRINTFORMW %ANAME(MASTER)%は屋形船に特殊部隊を送り込むことにした
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORML 特殊部隊は屋形船の首領を暗殺し、村娘を助け出した！
	PRINTFORMW これでしばらくは奴らの活動も収まるだろう……
	DVAR:屋形船_発生フラグ = 2
	RETURN 1
ELSEIF RESULT == 1
	PRINTFORML こんな奴の話を聞く必要はない
	PRINTFORMW %ANAME(MASTER)%は招待状を破り、着物と共に捨てた
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORML ・
	CALL COLOR_PRINT(@"%ANAME(MASTER)%の行為の代償として、攫われた娘たちが腹いせに妖怪達に凌辱されてしまったようだ……", カラー_警告)
	PRINTFORMW 
	CALL HOUSEBOAT_INSULT
	FOR LOCAL, 1, MAX_COUNTRY
		SIF IS_COUNTRY(LOCAL)
			CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:1, -50, 50)
	NEXT
	CALL COLOR_PRINT("領民を見捨てた事実は瞬く間に広がり、他国の評判が下がった……", カラー_注意)
	PRINTFORMW 
	DVAR:屋形船_発生フラグ = 1
	RETURN 1
ELSE
	PRINTFORML やむなく招待を受けることにした
	PRINTFORML 招待状には使者にはぜひ同封の着物を着て来て欲しいと書かれている
	PRINTFORMW 広げてみるとまるで花魁が着る様な煌びやかな豪奢な物だ
	PRINTFORML 罠等はなさそうだが…招待主の趣味なのだろうか
	PRINTFORML いずれにせよ、これを着ていかせるならば使者は女性になる
	PRINTFORMW 誰を送ろう？
	CALL SINGLE_DRAWLINE
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("HOUSEBOAT", "HOUSEBOAT")
	IF RESULT < 0
		PRINTFORML やはり考え直すことにした
		GOTO ASK_LOOP
	ENDIF
	対象 = RESULT
	IF 対象 == MASTER
		PRINTFORML %ANAME(対象)%自ら出向くことにした
	ELSE
		PRINTFORML %ANAME(対象)%を送り出した
	ENDIF
	PRINTFORMW %ANAME(対象)%は指定された着物に着替えると、地底へと向かった……
	PRINTFORML 
	PRINTFORML 待ち合わせ場所に向かうと手紙の差出人らしき妖怪が待っていた
	PRINTFORML 彼は着飾った%ANAME(対象)%を見ると口笛を吹いて満足そうに笑った
	PRINTFORMW 彼は慣れた手つきで%ANAME(対象)%の肩を抱くと、泊めてあった屋形船へ連れ込んだ
	PRINTFORML 多数の手下に囲まれるのを覚悟していたが、貸切られた屋台船で1対1の話し合いになった
	PRINTFORML 雅な装飾の中、豪華な食事と酒が並べられ、表向きは歓迎ムードだった
	PRINTFORMW しかし%ANAME(対象)%は彼の視線がいやらしく自分を品定めしているのを感じた
	PRINTFORML %ANAME(対象)%が適当に彼に付き合った後に本題を切り出すと、彼はニヤリと笑い口を開いた
	PRINTFORML 話の内容は手紙の通り、領内の娘を“保護”したので買い取ってほしいとの事だ
	PRINTFORML いくらだと訊ねると、彼は舌なめずりしながら顔をズイと近づけ
	PRINTFORMW 「金の代わりにお前の身体をよこせ」と告げてきた
	PRINTFORML そのねっとりとした言葉に%ANAME(対象)%は思わずゾクっと背筋を震わせる
	PRINTFORML 思わず拒絶の言葉を吐きそうになったが、娘たちの事を考えてぐっと堪えた
	PRINTFORMW …どうしよう？
	CALL ASK_MULTI("我慢して受け入れる" ,"金銭交渉に持ち込む" ,"斬りかかる")
	IF RESULT == 1
		PRINTFORML そんな要求には応じられない
		PRINTFORMW %ANAME(対象)%は努めて丁寧に断り、金銭での取引を持ち掛けた
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		IF ABL:対象:政治 * (RAND:5 + 1) > 30 * (RAND:9 + 1)
			PRINTFORMW 成功した！
			PRINTFORML 彼は%ANAME(対象)%の話に機嫌を良くして、取引に乗ってきた
			金額 = 10000 + 5000 * (RAND:5) + DAY * 400
			PRINTFORMW 娘たち全員の代金として、しめて金{金額}を要求してきた
			CALL ASK_MULTI_JUDGE("支払う", MONEY >= 金額,"断る", 1)
			IF RESULT == 0
				PRINTFORML 高いが娘たちの命には代えられない
				PRINTFORML 金を支払い彼女たちを買い戻した
				PRINTFORML 彼は金を受け取ると、下卑た笑みを浮かべながら去っていった
				PRINTFORMW %ANAME(対象)%は涙を流して感謝する娘たちを連れて帰った
				MONEY -= 金額
				CALL COLOR_PRINT(@"金{金額}を支払った", カラー_注意)
				PRINTFORMW 
			ELSE
				PRINTFORML そんな法外な金額は支払えない
				PRINTFORML 何とか値切ろうとしたが彼は頑なに断ってきた
				PRINTFORMW 結局村娘たちを解放させることはできなかった
				PRINTFORML ・
				PRINTFORML ・
				PRINTFORML ・
				CALL COLOR_PRINT(@"%ANAME(対象)%の行為の代償として、攫われた娘たちは妖怪共の慰み者に凌辱されてしまったようだ……", カラー_警告)
				PRINTFORMW 
				CALL HOUSEBOAT_INSULT
				FOR LOCAL, 1, MAX_COUNTRY
					SIF IS_COUNTRY(LOCAL)
						CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:1, -50, 50)
				NEXT
				CALL COLOR_PRINT("村娘たちがされた事は瞬く間に広がり、他国の評判が下がった……", カラー_注意)
				PRINTFORMW 
			ENDIF
		ELSE
			PRINTFORMW 失敗してしまった……
			PRINTFORML %ANAME(対象)%の回りくどい話に彼は痺れを切らし乱暴に押し倒してきた
			PRINTFORMW そして震える%ANAME(対象)%に対して下卑た笑みを浮かべ、凶暴なペニスを露出して襲い掛かってきた
			CALL HOUSEBOAT_RAPE(対象)
			PRINTFORML 彼は%ANAME(対象)%を散々犯された後、地底の入り口に放り出した
			PRINTFORMW %ANAME(対象)%は子宮に残り続ける彼の熱に身を震わせながら、ふらつく足取りで帰路についた
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORML ・
			CALL COLOR_PRINT(@"%ANAME(対象)%の行為の代償として、攫われた娘たちは見せしめに妖怪共に凌辱されてしまったようだ……", カラー_警告)
			PRINTFORMW 
			CALL HOUSEBOAT_INSULT
			FOR LOCAL, 1, MAX_COUNTRY
				SIF IS_COUNTRY(LOCAL)
					CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:1, -50, 50)
			NEXT
			CALL COLOR_PRINT(@"%ANAME(対象)%の軽率な行動の顛末は瞬く間に広がり、他国の評判が下がった……", カラー_注意)
			PRINTFORMW 
		ENDIF
		DVAR:屋形船_発生フラグ = 1
	ELSEIF RESULT == 2
		PRINTFORML あまりの無礼な要求に%ANAME(対象)%はカッとなり剣を抜いた
		PRINTFORMW しかし彼は怯む様子もなく不敵な笑みを浮かべて、襲い掛かってきた
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		SIF DVAR:屋形船_発生フラグ == 2
			LOCAL:2 = 20
		IF ABL:対象:武闘 * (RAND:5 + 1) > 30 * (RAND:9 + 1) + LOCAL:2
			PRINTFORMW 勝った！
			PRINTFORML 血濡れで倒れ伏す彼の姿にすっきりした%ANAME(対象)%だったが、娘たちの事を思い出し我に返った
			PRINTFORMW その後慌てて彼女たちを捜索したが、ついに見つけることはできなかった
			PRINTFORML ・
			PRINTFORML ・
			PRINTFORML ・
			CALL COLOR_PRINT(@"%ANAME(対象)%の行為の代償として、攫われた娘たちは報復に残党の妖怪共に凌辱されてしまったようだ……", カラー_警告)
			PRINTFORMW 
			CALL HOUSEBOAT_INSULT
			FOR LOCAL, 1, MAX_COUNTRY
				SIF IS_COUNTRY(LOCAL)
					CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:1, -50, 50)
			NEXT
			CALL COLOR_PRINT(@"%ANAME(対象)%の対応は波紋を呼んだ……", カラー_注意)
			PRINTFORMW 
			DVAR:屋形船_発生フラグ = 2
		ELSE
			PRINTFORMW 負けてしまった……
			PRINTFORML 彼は着物を乱れさせて柔肌を晒しながら倒れ込む%ANAME(対象)%を見下ろし
```
