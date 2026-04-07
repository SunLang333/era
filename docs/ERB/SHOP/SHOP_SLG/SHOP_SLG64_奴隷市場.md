# SHOP/SHOP_SLG/SHOP_SLG64_奴隷市場.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_SLG/SHOP_SLG64_奴隷市場.ERB`

类型: .ERB

自动摘要: functions: SHOP_SLG_NAME64, SHOP_SLG_CHECK64, SHOP_SLG_EVENTBUY64, SLAVEMARKET, SLAVEMARKET_SELL_CHARA, SELECT_CHARA_LIST_SHOW_LOGIC_SLAVEMARKET_SELL_CHARA, SELECT_CHARA_LIST_SELECT_LOGIC_SLAVEMARKET_SELL_CHARA, SLAVEMARKET_SHOW_INFO, IS_SLAVEMARKET_AVAILABLE, SLAVEMARKET_CALC_PRICE, SLAVEMARKET_PREPARE_GOODS, SELECT_CHARA_RANDOM_LOGIC_SLAVEMARKET_PREPARE_GOODS, CLEARN_SLAVE_MARKET_MOB, CREATE_SLAVE_MARKET_MOB; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「奴隷市場」の名称
;-------------------------------------------------
@SHOP_SLG_NAME64
RESULTS:0 '= "奴隷市場"

;-------------------------------------------------
;「奴隷市場」の選択可否
;-------------------------------------------------
@SHOP_SLG_CHECK64
SIF CFLAG:MASTER:所属 == 0
	RETURN 0
RETURN 1

;-------------------------------------------------
;「奴隷市場」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_SLG_EVENTBUY64
CALL SLAVEMARKET
RETURN 1

;-------------------------------------------------
;「奴隷市場」本体
;-------------------------------------------------
@SLAVEMARKET
#DIM 対象
#DIM 対象添え字
#DIM 売却可能
#DIM FIRST_LINE


;売却には特殊勢力な勢力が必要(主人公の所属していないところで)
売却可能 = 0
FOR LOCAL, 0, MAX_COUNTRY
	SIF IS_SP_COUNTRY(LOCAL) && CFLAG:MASTER:所属 != LOCAL
		売却可能 = 1
NEXT


FIRST_LINE = LINECOUNT

CALL SINGLE_DRAWLINE
PRINTFORML 「よぉ～こそ！　イキのいいのを揃えてますよぉ？」
PRINTFORML %ANAME(MASTER)%は奴隷市場を訪れた
PRINTFORML ボロボロの服を着た女達が檻に入れられ、並べられている
PRINTFORML 係の者は、使えそうな奴隷のリストを渡してきた……
PRINTFORML 所持金:{MONEY}
CALL SINGLE_DRAWLINE

VARSET SHOP_CHARA_LIST, -1
FOR LOCAL, 0, VARSIZE("SLAVEMARKET_GOODS")
	SHOP_CHARA_LIST:LOCAL = ID_TO_CHARA(SLAVEMARKET_GOODS:LOCAL)
NEXT

FOR LOCAL, 0, VARSIZE("SLAVEMARKET_GOODS")
	LOCAL:1 = ID_TO_CHARA(SLAVEMARKET_GOODS:LOCAL)
	SIF LOCAL:1 == -1
		CONTINUE
	;人質解放要求などにより既に捕虜でなくなっている場合、パージ
	IF !TALENT:(LOCAL:1):奴隷市場モブ && !IS_SP_COUNTRY(CFLAG:(LOCAL:1):捕虜先) && !IS_SP_COUNTRY(CFLAG:(LOCAL:1):所属)
		SLAVEMARKET_GOODS:LOCAL = 0
		CONTINUE
	ENDIF
	CALL SLAVEMARKET_SHOW_INFO(LOCAL:1, LOCAL)
	CALL SINGLE_DRAWLINE
NEXT

PRINTL 
SIF 売却可能
	PRINTFORML [98] 売却
PRINTFORML [99] 戻る

$INPUT_LOOP
INPUT

IF RESULT == 99
	RETURN 0
ELSEIF RESULT == 98
	IF !売却可能
		CLEARLINE 1
		GOTO INPUT_LOOP
	ENDIF
	CALL SLAVEMARKET_SELL_CHARA
	CLEARLINE FIRST_LINE - LINECOUNT
	RESTART
ENDIF

IF RESULT < 0
	CLEARLINE 1
	GOTO INPUT_LOOP
ELSEIF 100 <= RESULT && RESULT < VARSIZE("SLAVEMARKET_GOODS") + 100
	対象添え字 = RESULT - 100
	対象 = ID_TO_CHARA(SLAVEMARKET_GOODS:対象添え字)
	IF 対象 == -1
		CLEARLINE 1
		GOTO INPUT_LOOP
	ENDIF
	CALL SINGLE_DRAWLINE
	CALL SHOW_INFO_WITH_UI(対象, 1)
	CLEARLINE LINECOUNT - FIRST_LINE
	RESTART
ELSEIF VARSIZE("SLAVEMARKET_GOODS") <= RESULT || MONEY < SLAVEMARKET_PRICE:RESULT
	CLEARLINE 1
	GOTO INPUT_LOOP
ENDIF

対象 = ID_TO_CHARA(SLAVEMARKET_GOODS:RESULT)
対象添え字 = RESULT


IF 対象 == -1
	CLEARLINE 1
	GOTO INPUT_LOOP
ENDIF

対象 = ID_TO_CHARA(SLAVEMARKET_GOODS:RESULT)
対象添え字 = RESULT
PRINTFORML 「へへ、そいつぁ%NAME_FORMAL(対象)%ってぇ奴隷でさ」
PRINTFORML 「今なら{SLAVEMARKET_PRICE:対象添え字}でお譲りいたしやすよ」
SIF 対象添え字 == SLAVEMARKET_SPECIALGOODS
	PRINTFORML 「ちょっと"訳あり"でしてね、特売ってことで値引きさせていただいてやす」
IF IS_LOVER(対象)
	PRINTFORML 「……ん？　高いって？」
	PRINTFORML 「そりゃもちろん、コイツがアンタの"コレ"だって知ってるからに決まってんでしょォ？」
	PRINTFORML 「高いってんなら、自分のオンナが他のオトコに売られるとこでも見てるんだなァ、ヒヒッ！」
ENDIF
PRINTFORML 「で？　どうされます？」
PRINTL
CALL ASK_MULTI_JUDGE(@"%ANAME(対象)%を買う", MONEY >= SLAVEMARKET_PRICE:対象添え字, "やめておく", 1)
IF RESULT == 1
	CLEARLINE LINECOUNT - FIRST_LINE
	RESTART
ENDIF

MONEY -= SLAVEMARKET_PRICE:対象添え字
PRINTFORMW 「ひひ、じゃあ商談成立だ」
PRINTFORMW 「じゃ、持ってってくんなせぇ」

;確率でエロイベント　特売なら確定
IF IS_TOHO_CHARA(対象) && IS_FEMALE(対象) && (20 > RAND:100 || 対象添え字 == SLAVEMARKET_SPECIALGOODS)
	PRINTFORML
	PRINTFORMW ……男が連れてきた%ANAME(対象)%の姿を見、%ANAME(MASTER)%は目を疑った
	PRINTFORML 丸裸の%ANAME(対象)%は目隠しをされ、手足には枷が嵌められている
	PRINTFORMW 剥き出しの身体には、痛々しいピアスが取り付けられている
	PRINTFORML 全身白濁にまみれており、穴からも粘つく汁がどろどろと零れている
	PRINTFORMW あちこちに書かれた正の字が、%ANAME(対象)%のされたことを物語っていた
	PRINTFORMW そんな悲惨な様だというのに、%ANAME(対象)%はえへらえへらと笑っている
	PRINTFORMW ……これは楽しくて笑っているのではない。何か怪しげな薬の作用だ……
	PRINTFORML
	PRINTFORML 「あ～、市場に並べてる間も、奴隷としてあっしらが使わせていただいてますんでね」
	PRINTFORML 「洗浄はセルフサービスですんで、すいやせんけどね」
	PRINTFORMW 「おっと、返品は受け付けませんよ、残念ですけどねぇ」
	SIF 対象 == SLAVEMARKET_SPECIALGOODS
		PRINTFORMW 「ま、特売になるにはそれなりの理由があるってことですよ、へへへ」
	IF IS_LOVER(対象)
		PRINTFORMW 「別に構わんでしょ～？　恋人とカンドーノサイカイができたんだから」
		PRINTFORMW 「これに懲りたら、もっと大事にしてやることですな、げひゃひゃひゃ！」
	ENDIF
	PRINTFORMW 男を斬り捨ててやりたいが、この市場には多くの衛兵がいる。暴れれば自分が危ない
	PRINTFORMW 歯を噛みしめながら、%ANAME(MASTER)%は%ANAME(対象)%を受け取った……
	CALL FUCK_GANGBANG(対象, GET_SPERM_ID("奴隷商人"), @"奴隷商人の\@RAND:2 ? ペニス # 唇\@", "奴隷商人")
	CFLAG:対象:薬物依存 += RAND(30, 50)
	CALL SET_PIERCE_RANDOM(対象, 0)
ENDIF

IF IS_LOVER(対象)
	PRINTFORMW 「ひひ、これに懲りたら、もっと大事にしてやることですな、ひゃひゃひゃ！」
ELSE
	PRINTFORML 「えっへへへ、毎度ォ」
	PRINTFORMW 「そのオモチャと仲良くやることですな！　げへへへ」
ENDIF



PRINTFORMW %ANAME(対象)%を受け取り、市場を後にした……
;別勢力に所属（特殊勢力以外）
IF IS_COUNTRY(CFLAG:対象:所属) && !IS_SP_COUNTRY(CFLAG:対象:所属) && CFLAG:対象:所属 != CFLAG:MASTER:所属
	PRINTFORMW ……%ANAME(対象)%は%ANAME(GET_COUNTRY_BOSS(CFLAG:対象:所属))%の所属だ
	PRINTFORMW 返してやるのが人の道であるように思えるが……
	PRINTFORML どうしますか？
	CALL SINGLE_DRAWLINE
	CALL ASK_MULTI("返してやる", "士官として働いてもらう", "奴隷として監禁する")
	IF RESULT == 0
		PRINTFORMW %ANAME(対象)%を%ANAME(GET_COUNTRY_BOSS(CFLAG:対象:所属))%に返してやることにした
		PRINTFORMW %ANAME(GET_COUNTRY_BOSS(CFLAG:対象:所属))%から深く感謝された……
		CALL CHANGE_RELATION_C_TO_C(CFLAG:対象:所属, CFLAG:MASTER:所属, 600, -600)
		CFLAG:対象:好感度 = MAX(500, CFLAG:対象:好感度 + 500)
		CFLAG:対象:従属度 = MAX(500, CFLAG:対象:従属度 + 500)
		CFLAG:対象:依存度 = MAX(100, CFLAG:対象:依存度 + 100)
		CALL CAPTURE(対象, 0)
	ELSEIF RESULT == 1
		PRINTFORMW %ANAME(GET_COUNTRY_BOSS(CFLAG:対象:所属))%にせっかく買ったものをただで返してやるほどの義理はない
		PRINTFORMW 士官としての待遇を条件に、%ANAME(対象)%に協力を約束させた……
		CALL CHANGE_COUNTRY(対象, CFLAG:MASTER:所属, 1)
		CFLAG:対象:好感度 = MAX(0, CFLAG:対象:好感度 + 500)
		CFLAG:対象:従属度 = MAX(0, CFLAG:対象:従属度 + 500)
		CFLAG:対象:依存度 = MAX(0, CFLAG:対象:依存度 + 100)
	ELSE
		PRINTFORMW いやいや、金を出して買ったのだから、もう%ANAME(対象)%は自分のものだ
		PRINTFORMW どのように使ってやろうか考えながら、%ANAME(MASTER)%は市場を後にした……
```
