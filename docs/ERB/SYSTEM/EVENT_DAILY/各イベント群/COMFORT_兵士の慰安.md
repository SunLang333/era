# SYSTEM/EVENT_DAILY/各イベント群/COMFORT_兵士の慰安.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/COMFORT_兵士の慰安.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_COMFORT_RATE, EVENT_DAILY_COMFORT_DECISION, EVENT_DAILY_COMFORT_GENRE, EVENT_DAILY_COMFORT, SELECT_CHARA_LIST_SHOW_LOGIC_COMFORT, SELECT_CHARA_LIST_SELECT_LOGIC_COMFORT, COMFORT_SEX, EVENT_DAILY_COMFORT_ALLOW_WHEN_WANDERING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_COMFORT_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_COMFORT_DECISION()
SIF !IS_COUNTRY(CFLAG:MASTER:所属) || CFLAG:MASTER:捕虜先
	RETURN 0
SIF IS_SP_COUNTRY(CFLAG:MASTER:所属)
	RETURN 0
RETURN DAY >= 12

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_COMFORT_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_COMFORT()
#DIM 対象
#DIM 金額
#DIM 対象都市

CALL DAILY_EVENT_RAND_CITYSELECT(0)
対象都市 = RESULT

金額 = 1000 + (500 * (RAND:8 + 1)) + (DAY * 100)

PRINTFORML 長引く戦いで%CITY_NAME:対象都市%の兵士の不満がたまっている
PRINTFORML このままでは士気に関わるかもしれない
PRINTFORMW どうしよう？
CALL ASK_MULTI_JUDGE("宴会を催す", MONEY >= 金額,"慰安する", 1,"何もしない", 1)
IF RESULT == 2
	$DO_NOTHING
	PRINTFORML この程度の疲労度なら平気だろう
	PRINTFORMW 何もしない事にした
	IF RAND:2 == 0
		CITY_GUARD:対象都市 = MAX(CITY_GUARD:対象都市 - 20, 1)
		CALL COLOR_PRINT(@"兵たちの不満が貯まり、%CITY_NAME:対象都市%の防衛率が下がった", カラー_注意)
		PRINTFORMW 
	ENDIF
ELSEIF RESULT == 0
	PRINTFORMW 兵達の為に盛大な宴を催す事にした
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
	IF RAND:4 != 0
		PRINTFORML 宴は成功に終わった！
		PRINTFORMW 彼らは久しぶりの息抜きに大いに飲み騒いだ
		MONEY -= 金額
		CITY_GUARD:対象都市 += 15
		CALL COLOR_PRINT(@"兵たちの不満が解消され、%CITY_NAME:対象都市%の防衛率が上がった", カラー_注意)
		PRINTFORML 
		CALL COLOR_PRINT(@"金{金額}を消費した", カラー_注意)
		PRINTFORMW 
	ELSE
		PRINTFORML 宴は大成功に終わった！
		PRINTFORML 彼らは久しぶりの息抜きに大いに飲み騒いだ
		PRINTFORMW また、%ANAME(MASTER)%も共に愉しませてもらった
		MONEY -= 金額
		CITY_GUARD:対象都市 += 25
		CALL COLOR_PRINT(@"兵たちの不満が解消され、%CITY_NAME:対象都市%の防衛率が大きく上がった", カラー_注意)
		PRINTFORML 
		CALL COLOR_PRINT(@"金{金額}を消費した", カラー_注意)
		PRINTFORMW 
	ENDIF
ELSE
	PRINTFORML 慰安する事にした
	PRINTFORMW 誰に行かせよう？
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("COMFORT", "COMFORT")
	対象 = RESULT
	IF RESULT == -1
		GOTO DO_NOTHING
	ELSEIF 対象 == MASTER
		PRINTFORMW %ANAME(対象)%自ら慰安に向かった
	ELSE
		PRINTFORMW %ANAME(対象)%を慰安に向かわせた
	ENDIF
	LOCAL = RAND:6 + 1
	SIF TALENT:対象:人気 == 1
		LOCAL += 1
	IF IS_FEMALE(対象)
		PRINTFORML 
		PRINTFORML 慰安活動をしていると兵の一人に話しかけられた
		PRINTFORMW 彼は%ANAME(対象)%に顔を近づけると、もっと“女らしい慰安”を頼んできた
		IF ABL:対象:性知識 == 0
			PRINTFORML %ANAME(対象)%には何の事かわからなかったが、兵達の為に了承した
			PRINTFORMW 彼は飛び上がるほどに喜ぶと、%ANAME(対象)%の腕を引いて兵舎へ連れ込んだ
			CALL COMFORT_SEX(対象)
			LOCAL += 2
			ABL:対象:性知識 = 1
		ELSE
			PRINTFORML %ANAME(対象)%は突然の言葉に一瞬固まってしまった
			PRINTFORML 怒ろうかと思ったが、彼の瞳は真剣そのものなのに気付く
			PRINTFORML 前線で戦っている彼の頼みを断るのもどうかと思いとどまった……
			PRINTFORMW どうしよう？
			CALL ASK_YN("引き受ける", "断る")
			IF RESULT == 1
				PRINTFORML しかしやはりそんな娼婦のような真似はできない
				PRINTFORMW 断ると兵は残念そうに去って行った
			ELSE
				PRINTFORML %ANAME(対象)%はしばし俯いて考えていたが
				PRINTFORML 彼の真剣なまなざしに負け、慰安を引き受ける事にした
				PRINTFORMW 彼は飛び上がるほどに喜ぶと、%ANAME(対象)%の腕を引いて兵舎へ連れ込んだ
				CALL COMFORT_SEX(対象)
				LOCAL += 2
			ENDIF
		ENDIF
	ENDIF
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
	IF LOCAL >= 6
		PRINTFORML 慰安は大成功に終わった！
		PRINTFORML 彼らは%ANAME(対象)%の催しに喝采して楽しんだ
		PRINTFORMW %ANAME(対象)%も彼らの喜ぶ顔を見て自然と笑顔になった
		CITY_GUARD:対象都市 += 25
		CALL COLOR_PRINT(@"兵たちの不満が解消され、%CITY_NAME:対象都市%の防衛率が大きく上がった", カラー_注意)
		PRINTFORML 
	ELSEIF LOCAL >= 4
		PRINTFORMW 
		PRINTFORML 慰安は成功に終わった！
		PRINTFORMW 彼らは%ANAME(対象)%の催しに喝采して楽しんだ
		CITY_GUARD:対象都市 += 15
		CALL COLOR_PRINT(@"兵たちの不満が解消され、%CITY_NAME:対象都市%の防衛率が上がった", カラー_注意)
		PRINTFORML 
	ELSE
		PRINTFORML 兵達の反応は今一だった
		PRINTFORMW %ANAME(対象)%は肩を落として帰った
		CITY_GUARD:対象都市 -= 20
		CALL COLOR_PRINT(@"兵たちの不満が貯まり、%CITY_NAME:対象都市%の防衛率が下がった", カラー_注意)
		PRINTFORMW 
	ENDIF
ENDIF

RETURN 1


@SELECT_CHARA_LIST_SHOW_LOGIC_COMFORT(対象)
#DIM 対象
RETURN CFLAG:対象:所属 == CFLAG:MASTER:所属 && !IS_ANIMAL(対象) && CFLAG:対象:行動不能状態 != 行動不能_子供

@SELECT_CHARA_LIST_SELECT_LOGIC_COMFORT(対象)
#DIM 対象
RETURN CFLAG:対象:捕虜先 == 0
;--------------------------------------------------------------------------------
;慰安活動
;--------------------------------------------------------------------------------
@COMFORT_SEX(ARG:0)

PRINTFORML 
PRINTFORMW %ANAME(ARG:0)%は慰安活動をしている……
PRINTFORML 
SELECTCASE RAND:20
	CASE 0
		PRINTFORML %ANAME(ARG:0)%は兵のペニスに跪きながら口で奉仕している
		PRINTFORML よほど溜まっていたのか、裏筋を舌で軽くなぞるだけで彼は小さく呻きペニスがビクビクと震える
		PRINTFORML あーんと口を開いてカリ首を頬張り、鈴口を舌で刺激してやると彼は身体を痙攣させながら射精した
		PRINTFORMW 濃い精液を全て飲み干してもペニスは一向に衰えず、彼はそのまま%ANAME(ARG:0)%を押し倒してきた
	CASE 1
		PRINTFORML %ANAME(ARG:0)%は彼の上に寝転び、お互いの性器を舐めあっている
		PRINTFORML はち切れんばかりのペニスを舌と指で丹念に奉仕してやると、ビクビクと跳ねて我慢汁を漏らす
		PRINTFORML 彼は夢中で%ANAME(ARG:0)%の秘所にむしゃぶりついてきて、%ANAME(ARG:0)%も思わず腰をくねらせる
		PRINTFORMW 火照りきった%ANAME(ARG:0)%が秘所を割れ開いて誘うと、彼はたまらずペニスをねじ込んできた
	CASE 2
		PRINTFORML %ANAME(ARG:0)%は彼の上に跨り、ベッドをギシギシ鳴らしている
		PRINTFORML 腰を振る度に逞しいペニスで膣肉を刺激されて、%ANAME(ARG:0)%は思わず甘い吐息を漏らしてしまう
		PRINTFORML 彼もまた%ANAME(ARG:0)%の腰を掴みながら低く呻き、射精を堪えながら子宮に届くほどに突き上げてくる
		PRINTFORMW お互いに無我夢中で肉欲を貪り続け、夜通し濃厚な交尾を繰り返して何度も果てた
	CASE 3
		PRINTFORML %ANAME(ARG:0)%は彼と両手を繋ぎながらセックスに没頭している
		PRINTFORML 彼はぎゅうっと%ANAME(ARG:0)%の手を握りながら、%ANAME(ARG:0)%の名を呼びながら夢中になって腰を打ちつけてくる
		PRINTFORML 彼の情熱的なピストンで蜜壺を掻き回され、%ANAME(ARG:0)%もたまらないといった声を上げて身悶える
		PRINTFORMW まるで恋人の様にお互いをしっかりと結びつきながら、二人で絶頂に昇って行った
	CASE 4
		PRINTFORML %ANAME(ARG:0)%は正常位の姿勢で彼に抱かれている
		PRINTFORML 彼は%ANAME(ARG:0)%の胸に顔をうずめてしがみ付きながら、我を忘れて夢中で腰を打ちつけてくる
		PRINTFORML その甘えるような仕草に%ANAME(ARG:0)%の母性本能が刺激されて子宮が疼き、彼の全身をぎゅっと抱きしめる
		PRINTFORMW やがて彼が我慢できずに大量の精を放つと、%ANAME(ARG:0)%は両脚で腰を押さえ込んで一滴残らず受け止め上げた
	CASE 5
		PRINTFORML 兵舎の一室で男女のまぐわう音とベッドのきしむ音が響いている
		PRINTFORML 彼は兵舎に入るなり%ANAME(ARG:0)%を押し倒し、すでにはち切れんばかりだったペニスをねじ込んできた
		PRINTFORML 初めは痛がっていた%ANAME(ARG:0)%だが、荒々しい腰遣いで子宮を小突かれ続け、すぐに喘ぎ声を漏らしだした
		PRINTFORMW やがて子宮へと大量の特濃精液を放たれると、%ANAME(ARG:0)%はあられもない声を上げて絶頂に達した
	CASE 6
		PRINTFORML 兵舎の一室にくちゅくちゅと粘膜の触れ合ういやらしい音が響いている
```
