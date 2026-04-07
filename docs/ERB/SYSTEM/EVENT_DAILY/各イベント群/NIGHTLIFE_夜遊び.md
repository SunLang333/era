# SYSTEM/EVENT_DAILY/各イベント群/NIGHTLIFE_夜遊び.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/NIGHTLIFE_夜遊び.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_NIGHTLIFE_RATE, EVENT_DAILY_NIGHTLIFE_DECISION, EVENT_DAILY_NIGHTLIFE_SETTARGET, EVENT_DAILY_NIGHTLIFE_GENRE, EVENT_DAILY_NIGHTLIFE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_NIGHTLIFE_RATE()
RETURN 40
;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_NIGHTLIFE_DECISION()
SIF DAY < 5
	RETURN 0
;MASTERがペニスを持っている
SIF !(HAS_PENIS(MASTER))
	RETURN 0

RETURN 1


;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_NIGHTLIFE_SETTARGET()

FOR LOCAL, 0, CHARANUM
	SIF !IS_FEMALE(LOCAL)
		CONTINUE
	;自国所属かつ捕虜でない、かつ「恋慕か親愛か服従・隷属・烙印」で、2/3
	IF CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && CFLAG:LOCAL:面識 && !CFLAG:LOCAL:捕虜先 && (IS_LOVER(LOCAL) || IS_SLAVE(LOCAL))
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
		DAILY_TARGET_NUM ++
	;主人公が特殊勢力におらず、対象が特殊勢力に所属 + 陥落済み、かつ面識がある
	ELSEIF !IS_SP_COUNTRY(CFLAG:MASTER:所属) && CFLAG:LOCAL:面識 && IS_SP_COUNTRY(CFLAG:LOCAL:所属) && IS_FALLEN_TO_SP_COUNTRY(LOCAL) && CFLAG:LOCAL:所属 != GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_自警団) && !CFLAG:LOCAL:捕虜先
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
		DAILY_TARGET_NUM ++
	ENDIF
NEXT

SIF DAILY_TARGET_NUM < 1
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_NIGHTLIFE_GENRE()
RETURN デイリー_ジャンル_エロ


;夜遊び
@EVENT_DAILY_NIGHTLIFE
#DIM 対象
#DIM 野盗
#DIM ゴブリン
#DIM 外来

野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))
ゴブリン = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_ホフゴブリン))
外来 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_外来人))


対象 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)

;恋慕パターン
IF IS_LOVER(対象)
	PRINTFORMW 仕事をしていると、%ANAME(対象)%が部屋に訪れてきた……
	PRINTFORML たまには夜の散歩でもしないか、ということだそうだ
	CALL ASK_YN("出歩いてみる", "いや仕事あるから……")
	;お前マジそれはないわ
	IF RESULT == 1
		PRINTFORMW 悪いけど仕事がある……そう告げると、%ANAME(対象)%は残念そうに帰って行った
		RETURN 1
	ELSE
		;なんだこの平和な分岐　オラこんなの書くのはじめてよ
		PRINTFORMW %ANAME(対象)%を連れ、夜の街に繰り出した……
		PRINTFORML 
		LOCAL = RAND:11
		SELECTCASE LOCAL
			CASE 0
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を、最近はやりのレストランに連れて行った
				PRINTFORMW 料理に舌鼓を打ちながら、二人で楽しい時間を過ごした……
			CASE 1
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を、劇場に連れて行った
				PRINTFORMW 人気の演劇を二人で楽しんだ……
			CASE 2
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%に、買い物へ連れて行かれた
				PRINTFORMW あれやこれやと話しながら、色々なものを見て回った……
			CASE 3
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を、星のよく見える丘に連れて行った
				PRINTFORMW 二人で星を見ながら、ゆっくりとした時間を過ごした……
			CASE 4
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%と一緒に、温泉に浸かりにいった
				PRINTFORMW %ANAME(対象)%の湯上がり姿にどきりとしたりしつつ、リフレッシュした……
			;1/10くらいの確率で花火大会って、どんだけ花火好きなのきみたち
			CASE 5
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%と一緒に、花火大会を見に行った
				PRINTFORMW 浴衣姿の%ANAME(対象)%にどきりとさせられた……
			CASE 6
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を、サーカスへ連れて行った
				PRINTFORMW 二人で楽しい時間を過ごした……
			CASE 7
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を、バーへと連れて行った
				PRINTFORMW 二人で大人な時間を過ごした……
			CASE 8
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%と一緒に、弾幕ごっこを見に行った
				PRINTFORMW 他の観客に混じって賭博しようとする%ANAME(対象)%を一生懸命止めた……
			CASE 9
				PRINTFORML %ANAME(対象)%が、行きつけの飲み屋へ連れていってくれた
				PRINTFORMW ほろ酔いで頬を赤らめる%ANAME(対象)%がなんとも素敵だった……
			CASE 10
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%と一緒に夜景を見に行った
				PRINTFORMW %ANAME(対象)%の肩を抱きながら、二人の時間を過ごした……
		ENDSELECT
		;何あげりゃいいんだよこんなの
		CFLAG:対象:好感度 += 200
		CFLAG:対象:依存度 += 200
	ENDIF


ELSEIF IS_SLAVE(対象)
	PRINTFORMW 仕事をしていると、%ANAME(対象)%が部屋に訪れてきた……
	PRINTFORML 疼いて仕方ないので、自分を「夜遊び」に「使って」くれないかということだ……
	CALL ASK_YN("使ってやる", "いや仕事あるから……")
	IF RESULT == 1
		PRINTFORMW 悪いけど仕事がある……そう告げると、%ANAME(対象)%は残念そうに帰って行った
		RETURN 1
	ELSE
		PRINTFORMW %ANAME(対象)%を連れ、夜の街に繰り出した……
		PRINTFORML 
		LOCAL = RAND:5
		SELECTCASE LOCAL
			CASE 0
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を路地裏に連れ込むと、服を脱ぐよう命令した
				PRINTFORMW %ANAME(対象)%は躊躇いつつも、%ANAME(MASTER)%の言うことには逆らえず、その肌を夜風に晒す
				PRINTFORML %ANAME(MASTER)%は強い口調で%ANAME(対象)%に命じ、誰が来るとも分からないこの場所で自慰をさせる
				PRINTFORMW 見られるかもしれないという意識が後押ししたのか、%ANAME(対象)%はいつも以上に激しく感じていたようだ
				PRINTFORMW その後、%ANAME(MASTER)%は昂ぶる%ANAME(対象)%の身体を、たっぷりと味わってやった……
				CALL FUCK_MAKELOVE(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の\@ RAND:2 ? ペニス # 唇\@", @"%ANAME(MASTER)%")
				CALL FUCK(MASTER, "Ｃ, 性交, 射精, 奉仕", "キス喪失, 童貞喪失", 0, @"%ANAME(対象)%の\@ RAND:2 ? 秘貝 # 唇\@", "", @"%ANAME(対象)%の膣")
			CASE 1
				PRINTFORML %ANAME(MASTER)%と%ANAME(対象)%が歩いていると、浮浪者に出くわした
				PRINTFORML いかにも女日照りで、欲望を溜めていそうな見た目をしている
				PRINTFORML こいつに%ANAME(対象)%を抱かせるというのも面白いか……
				CALL ASK_YN("浮浪者に抱かせる", "自分で使う")
				LOCAL:1 = RESULT
				IF RESULT == 0
					PRINTFORMW 浮浪者に声をかけ、%ANAME(対象)%を差し出した
					PRINTFORMW 男は大興奮で、嬉々として%ANAME(対象)%を己のねぐらに迎え入れた
					PRINTFORMW そこらで拾ってきたのだろう布一枚隔てて、男の激しい息遣いと、%ANAME(対象)%の嬌声が聞こえてくる
					PRINTFORMW コトが終わったら戻ってくるよう伝えると、%ANAME(MASTER)%はその場を後にした……
					PRINTFORML
					PRINTFORML しばらくして、%ANAME(対象)%は何事もなかったかのように戻ってきた
					PRINTFORMW しかしその頬は上気し、下着を奪われた秘部から垂れる黄ばんだ精液が、太腿をつう、と伝っていた……
					CALL FUCK_RAPE(対象, GET_SPERM_ID("浮浪者"), @"浮浪者の\@ RAND:2 ? ペニス # 唇\@", @"浮浪者")
				ELSE
					PRINTFORMW 浮浪者に声をかけ、自分が%ANAME(対象)%を使うところを見ているよう伝えた
					PRINTFORMW 彼女の身体を弄り、奉仕させ、そして穴を抉ってやると、男は血走った目でこちらを見つめてくる
					PRINTFORMW その手は己の汚らしいモノをゴシゴシと扱き上げていた
					PRINTFORMW %ANAME(MASTER)%が精を放ち、%ANAME(対象)%が絶頂すると同時に、彼もまた己のモノから黄ばんだ精子を吐き出した……
					CALL FUCK_TRAIN(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の\@ RAND:2 ? ペニス # 唇\@", @"%ANAME(MASTER)%")
					CALL FUCK(MASTER, "Ｃ, 性交, 射精, 奉仕", "キス喪失, 童貞喪失", 0, @"%ANAME(対象)%の\@ RAND:2 ? 秘貝 # 唇\@", "", @"%ANAME(対象)%の膣")
				ENDIF
			CASE 2
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%の服を全て奪った上で、治安の悪い地区を一人で歩かせた
				PRINTFORML %ANAME(対象)%のような女がそのような場所を裸で歩いて、男どもが放っておくはずもない
				PRINTFORML %ANAME(対象)%は早速、男どもに路地裏に連れ込まれそうになっている……
				CALL ASK_YN("眺める", "追い払う")
				LOCAL:1 = RESULT
				IF RESULT == 0
					PRINTFORML ……どうせこうなると踏んで送り出したのだ。別に構わない
					PRINTFORML %ANAME(MASTER)%が遠巻きに眺めていると、やがて%ANAME(対象)%は本当に路地裏に連れ込まれてしまった
					PRINTFORMW しばらくの後、獣のような嬌声が、路地の奥の方から反響して聞こえてきた……
					PRINTFORML 
					PRINTFORML しばらくして、%ANAME(MASTER)%は%ANAME(対象)%を回収しに行った
					PRINTFORMW 全身白濁にまみれ、両穴からも子種をこぼす%ANAME(対象)%が、生ゴミの袋の山に放り捨てられていた……
					CALL FUCK_GANGBANG(対象, GET_SPERM_ID("ごろつき"), @"ごろつきの\@ RAND:2 ? ペニス # 唇\@", @"ごろつき")
				ELSE
					PRINTFORMW その場に乱入し、男達を追い払った
					PRINTFORML 感謝する%ANAME(対象)%を、お前を使うのは自分だと言い、路地裏へ連れ込む
					PRINTFORMW そしてそこで、たっぷりと%ANAME(対象)%を使ってやった……
					PRINTFORMW 疲弊しぐったりとする%ANAME(対象)%は、どこか幸せそうだった
					CALL FUCK_TRAIN(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の\@ RAND:2 ? ペニス # 唇\@", @"%ANAME(MASTER)%")
					CALL FUCK(MASTER, "Ｃ, 性交, 射精, 奉仕", "キス喪失, 童貞喪失", 0, @"%ANAME(対象)%の\@ RAND:2 ? 秘貝 # 唇\@", "", @"%ANAME(対象)%の膣")
				ENDIF
			CASE 3
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%と酒を飲みに出かけた
				PRINTFORML この店がいわゆるハプニングバーであることは黙っておいたが……
				PRINTFORML ……スケベ親父が声をかけてきた。綺麗な女を連れている
				PRINTFORML どうやらスワッピングに興味があるようだが……
				CALL ASK_YN("自分も興味がある", "断る")
				LOCAL:1 = RESULT
				IF RESULT == 0
					PRINTFORML 自分も興味がある……%ANAME(MASTER)%が許可を出すと、親父は早速%ANAME(対象)%の身体を弄り始める
					PRINTFORML 最初は驚いていた%ANAME(対象)%だったが、親父のねちっこい指技に、すぐ顔を蕩かせ始めた
					PRINTFORMW その一方で、%ANAME(MASTER)%も、親父の連れていた女をたっぷりと可愛がってやる
					PRINTFORMW %ANAME(MASTER)%の目の前だということと、他の女に%ANAME(MASTER)%をとられているという嫉妬が、より彼女を昂ぶらせたようだ
					PRINTFORMW その後、%ANAME(MASTER)%と親父はホテルの別々の部屋に相手のパートナーを連れ込み、普段と違うセックスをそれぞれ楽しんだ……
					PRINTFORML
```
