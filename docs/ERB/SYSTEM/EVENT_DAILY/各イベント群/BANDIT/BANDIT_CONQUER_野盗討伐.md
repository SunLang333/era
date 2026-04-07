# SYSTEM/EVENT_DAILY/各イベント群/BANDIT/BANDIT_CONQUER_野盗討伐.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/BANDIT/BANDIT_CONQUER_野盗討伐.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_BANDIT_CONQUER_RATE, EVENT_DAILY_BANDIT_CONQUER_DECISION, EVENT_DAILY_BANDIT_CONQUER_GENRE, EVENT_DAILY_BANDIT_CONQUER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_BANDIT_CONQUER_RATE()
RETURN 40


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_BANDIT_CONQUER_DECISION()
#DIM 野盗
野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))
SIF 野盗 == -1
	RETURN 0
SIF IS_SP_COUNTRY(CFLAG:MASTER:所属)
	RETURN 0
SIF BANDIT_POP_SUSPENDED > 0
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_BANDIT_CONQUER_GENRE()
RETURN デイリー_ジャンル_特殊勢力

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_BANDIT_CONQUER
#DIM 野盗
#DIM 候補, 3
#DIM 人数
#DIM 武闘合計
#DIM 知略合計
VARSET 人数
VARSET 候補
VARSET 武闘合計
VARSET 知略合計

野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))


IF DVAR:野盗討伐_発生フラグ == 0
	PRINTFORML ある日、%ANAME(MASTER)%の元に報告が入った
	PRINTFORMW なんと、あのにくき野盗どものアジトの場所を掴んだというのだ！
ELSEIF DVAR:野盗討伐_発生フラグ == 1
	PRINTFORML 以前ボコボコにしてやった野盗どもだが、どうも最近、また現れているらしい
	PRINTFORMW そろそろ、もう一度討伐してやるべきか……
ELSEIF DVAR:野盗討伐_発生フラグ == 2
	PRINTFORML 以前潜入に失敗してから行方をくらましていた野盗だが、新たなアジトの場所が判明した
	PRINTFORMW あのときの恨みを、今こそ晴らすときだ……
ENDIF
PRINTFORML 卑怯な奴らのことだから、あまり大勢でいくと逃げられてしまう
PRINTFORMW ごく小数の精鋭を送って討伐する作戦が適しているように思われる
PRINTFORM ここは
CALL COLOR_PRINT("3", カラー_注意)
PRINTFORML 人程度の部下を送り、一暴れしてきてもらうのがよいだろう
PRINTFORMW 問題は、誰を送るかだが……
CALL SELECT_CHARA_LIST_MULTI_SLG(3)

IF SELECTED_CHARA_NUM == 0
	PRINTFORML ……いや、むやみに部下を危険にさらすこともないだろう
	PRINTFORMW そう考え直した%ANAME(MASTER)%は、誰も派遣しないことにした
	RETURN 1
ENDIF

FOR LOCAL, 0, SELECTED_CHARA_NUM
	候補:LOCAL = SELECTED_CHARA:LOCAL
	武闘合計 += ABL:(候補:LOCAL):武闘
	知略合計 += ABL:(候補:LOCAL):知略
	人数 ++
NEXT

PRINTFORM %ANAME(候補:0)%
SIF 候補:1 >= 0
	PRINTFORM 、%ANAME(候補:1)%
SIF 候補:2 >= 0
	PRINTFORM 、%ANAME(候補:2)%
SIF 人数 > 1
	PRINTFORM たち
PRINTFORMW を、野盗どもの根城に送り出した……
PRINTFORML
CALL SINGLE_DRAWLINE
;1/3で重視されるのが知略になる
LOCAL:1 = RAND:3 ? (武闘合計 * 2 + 知略合計) # (武闘合計 + 知略合計 * 2)
;判定値は100から600、大体300辺りに寄るように工夫
;ついでに野盗なので野盗の強さ設定を判定に反映するように(最弱を基準値としてランクごとに＋10%)
LOCAL:2 = MAX(RAND:201 + RAND:201 + RAND:201, 100) * (SP_COUNTRY_RANK:(特殊勢力_野盗) + 9) / 10
;成功パターン、なお同数は失敗
IF LOCAL:1 > LOCAL:2
	PRINTFORMW 潜入はうまくいったようだ
	SELECTCASE RAND:5
		CASE 0
			PRINTFORML %ANAME(候補:(RAND:(人数)))%は根城にうまく侵入し、彼らを一網打尽にした
			PRINTFORML 囚われていた近場の村娘などのことも解放してやった
		CASE 1
			PRINTFORML %ANAME(候補:(RAND:(人数)))%は音もなく見張りを排除し、気づかれることなく侵入した
			PRINTFORML そして奇襲を続け、誰にも気づかれることなく、根城を壊滅させた
		CASE 2
			PRINTFORML %ANAME(候補:(RAND:(人数)))%は旅の大道芸人に化け、彼らの宴会に混ざり込んだ
			PRINTFORML 彼らが異常に気づくのは、酒に混ぜられた痺れ薬が効いてきたころになってからだった……
		CASE 3
			PRINTFORML %ANAME(候補:(RAND:(人数)))%は娼婦に化け、彼らの首領に取り入ったようだ
			PRINTFORML 閨で首領が服を脱いだ途端に襲いかかり、彼を見事に討ち取った……
		CASE 4
			PRINTFORML %ANAME(候補:(RAND:(人数)))%は彼らの貢ぎものになる予定だった村娘に化けた
			PRINTFORML 彼らが異常に気づいたのは、鋭い一撃を食らい地に倒れ伏した後のことだった……
	ENDSELECT
	CALL SINGLE_DRAWLINE
	PRINTFORMW これでしばらく野盗はあらわれないだろう
	PRINTFORMW 野盗に頭を悩ませていた他の勢力も、この働きを肯定的にみているようだ……
	SETCOLOR カラー_注意
	PRINTFORMW 野盗がしばらく出現しなくなった
	PRINTFORMW 他の勢力との関係が大きく改善した
	RESETCOLOR
	;野盗部隊を全て解体、サスペンド期間追加、関係改善
	DVAR:野盗討伐_発生フラグ = 1
	CALL CLEAR_ALL_UNIT(野盗)
	BANDIT_POP_SUSPENDED = 10
	FOR LOCAL, 0, MAX_COUNTRY
		SIF IS_COUNTRY(LOCAL) && LOCAL != 野盗
			CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, 500, -300)
	NEXT
	RETURN 1
;失敗パターン
ELSE
	DVAR:野盗討伐_発生フラグ = 2
	SETCOLOR カラー_注意
	PRINTFORML 潜入作戦は失敗してしまったようだ……
	RESETCOLOR


	FOR LOCAL, 0 , 人数
		PRINTFORML
		IF IS_FEMALE(候補:LOCAL)
			LOCAL:1 = RAND:22
			SELECTCASE LOCAL:1
				CASE 0
					PRINTFORML 誰にも気づかれないよう潜入した%ANAME(候補:LOCAL)%だったが、見つかってしまった
					PRINTFORMW 応援を呼ばれ多数の野盗に囲まれた%ANAME(候補:LOCAL)%は、抵抗もむなしく組み伏せられる
					PRINTFORML 刃物を振りかざしたが、そこで%ANAME(候補:LOCAL)%がかなりの「上玉」であることに気づく
					PRINTFORMW 彼らの目的は、%ANAME(候補:LOCAL)%に暴行を加えることから、陵辱することへと変わった
					PRINTFORML 太い手が%ANAME(候補:LOCAL)%の%STR_BODY("身体", 候補:LOCAL)%を這い、その服を剥ぎ取っていく
					PRINTFORMW そして前戯もそこそこに、暴れる%ANAME(候補:LOCAL)%を押さえつけ、その秘部へ肉棒をねじ込んだ
					PRINTFORML 初めは嫌悪していた%ANAME(候補:LOCAL)%も、性交の快楽の前に、次第に声を蕩かしていく
					PRINTFORMW それは、彼らが怪しげな注射を%ANAME(候補:LOCAL)%に打ったことで、決定的になった
					PRINTFORML 男は自分勝手に腰を振って%ANAME(候補:LOCAL)%の膣内を味わい、%ANAME(候補:LOCAL)%も腰をくねらせそれを受け入れる
					PRINTFORMW やがて%ANAME(候補:LOCAL)%の膣内に濃厚な白濁が放たれると、彼女は思いきり背を反らして絶頂する
					PRINTFORML だが、それで終わりなどはしなかった 
					PRINTFORMW 彼女に課せられたのは、このアジト全員の相手なのだから……
				CASE 1
					PRINTFORML まずは見張りを排除しようとした%ANAME(候補:LOCAL)%だったが、感づかれてしまった
					PRINTFORMW 見張りは応援を呼ばない代わりにコレを悦ばせろと、己の一物を露出した
					PRINTFORML なぜこんなものを……と、嫌悪する%ANAME(候補:LOCAL)%だったが、背に腹は代えられない
					PRINTFORMW えづきながらもそれを咥え込み、ゆっくりとながらしゃぶりはじめた
					PRINTFORML 口内に雄の味と臭いが広がる。それは快いものではないはずだというのに、彼女の奥底を疼かせる
					PRINTFORMW 女の本能が、否応なしに反応してしまっているのだ
					PRINTFORML やがて男は、%ANAME(候補:LOCAL)%の口内にたっぷりと白濁をまき散らす
					PRINTFORMW 命じられてもいないというのに、%ANAME(候補:LOCAL)%は、気づけば吐き出された子種を自ら嚥下していた
					PRINTFORML ともあれ、これで侵入できるはずだ……安心する%ANAME(候補:LOCAL)%だったが、甘かった
					PRINTFORML 見張りの男は約束を守らなかった。大声を上げ、応援を集めたのだ
					PRINTFORMW あっという間に囲まれ、組み敷かれた%ANAME(候補:LOCAL)%を、彼らは次々と陵辱していった……
				CASE 2
					PRINTFORML %ANAME(候補:LOCAL)%は大道芸人に化け、彼らの宴会に混ざり込んだ
					PRINTFORMW 酒に痺れ薬を盛るつもりだったのだが、逆に怪しげな薬を盛られてしまった
					PRINTFORML 酩酊し、前後不覚に陥った%ANAME(候補:LOCAL)%の服を、野盗どもは剥ぎ取っていく
					PRINTFORML そしてその%STR_BODY("胸", 候補:LOCAL)%を乱暴に揉みしだき、秘部に指をねじ込んで弄ぶ
					PRINTFORMW 睡眠薬と媚薬と酒の効果で、%ANAME(候補:LOCAL)%は大した抵抗もできずただ喘がされるしかない
					PRINTFORML やがて彼らの頭が、その長大な一物を%ANAME(候補:LOCAL)%の%STR_BODY("陰唇：処女確認", 候補:LOCAL)%に押し当てる
					PRINTFORML 快楽に蕩かされ何も分からなくなっている%ANAME(候補:LOCAL)%は、恥も外聞もなくそれを求めた
					PRINTFORMW お望みならばと、男はげらげら笑いながら、凶悪なモノを彼女の濡れた穴にねじ込んだ
					PRINTFORML 脳天を突き抜けるような快楽に、%ANAME(候補:LOCAL)%は乱れきった雌の表情を浮かべた
					PRINTFORML やがて頭領が呻き射精すると、%ANAME(候補:LOCAL)%は腹の中から蕩かされるような快感に、
					PRINTFORMW 何度も法悦を迎えた……
					PRINTFORMW その後、%ANAME(候補:LOCAL)%は部下どもに「提供」され、酒の肴に何度もいただかれてしまった……
					CFLAG:(候補:LOCAL):薬物依存 += 100
				CASE 3
					PRINTFORML %ANAME(候補:LOCAL)%は大道芸人に化け、彼らの宴会に混ざり込んだ
					PRINTFORMW 酒に痺れ薬を盛るつもりだったのだが、逆に怪しげな薬を盛られてしまった
					PRINTFORML 前後不覚に陥った%ANAME(候補:LOCAL)%に、野盗どもは本当に大道芸をするよう命じた
					PRINTFORMW テーブルの上に上って、即席のストリップショーをしろというのだ
					PRINTFORML 普通ならば拒否するところだろうが、今の%ANAME(候補:LOCAL)%にまともな思考は存在しない
					PRINTFORML 自らテーブルに登り、彼らが囃すのに合わせて踊りながら、その肌を晒していく
					PRINTFORMW 最後の一枚、下着が取り払われ、その肢体の美しさに彼らは息を呑んだ
					PRINTFORML 男達はそのまま、%ANAME(候補:LOCAL)%に自慰をするよう命じる
					PRINTFORMW %ANAME(候補:LOCAL)%は言われるがまま、大きく脚を広げ、はしたない声をあげて己を慰める
					PRINTFORML そのうちに、我慢のできなくなった男達は、彼女をテーブルから引きずりおろして組み敷く
					PRINTFORMW そして、己の長大な一物を濡れそぼつ%STR_BODY("陰唇：処女確認：修飾", 候補:LOCAL)%秘裂にねじ込んだ
					PRINTFORML さらには、口内にも菊穴にも、同じようにペニスが入り込んでくる
					PRINTFORMW あらゆる穴を激しく抉り返され、白く染められながら、%ANAME(候補:LOCAL)%は何度も絶頂してしまった……
					CFLAG:(候補:LOCAL):薬物依存 += 100
```
