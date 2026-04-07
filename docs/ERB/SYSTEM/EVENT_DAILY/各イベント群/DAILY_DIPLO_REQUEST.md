# SYSTEM/EVENT_DAILY/各イベント群/DAILY_DIPLO_REQUEST.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/DAILY_DIPLO_REQUEST.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_REQUEST_CHARA_RATE, EVENT_DAILY_REQUEST_CHARA_DECISION, EVENT_DAILY_REQUEST_CHARA_GENRE, EVENT_DAILY_REQUEST_CHARA, EVENT_DAILY_REQUEST_MONEY_RATE, EVENT_DAILY_REQUEST_MONEY_DECISION, EVENT_DAILY_REQUEST_MONEY_GENRE, EVENT_DAILY_REQUEST_MONEY; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_REQUEST_CHARA_RATE()
RETURN 30

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_REQUEST_CHARA_DECISION()
SIF DVAR:士官要求_発生禁止カウンタ > 0
	RETURN 0
SIF FLAG:クリアフラグ
	RETURN 0

RETURN DAY >= SLG_PP:0

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_REQUEST_CHARA_GENRE()
RETURN デイリー_ジャンル_外交

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_REQUEST_CHARA()
#DIM 自国経済値
#DIM 各国経済値, MAX_COUNTRY
#DIM 候補国, MAX_COUNTRY
#DIM 候補数
#DIM 結果国
#DIM 結果君主
#DIM 候補キャラ, MAX_CHARA_NUM
#DIM 結果キャラ
#DIM 野盗
VARSET 自国経済値
VARSET 各国経済値
VARSET 候補国
VARSET 候補キャラ
VARSET 候補数
VARSET 野盗

;あらかじめ、野盗の勢力番号を保存
野盗 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))


;------------ここから国の選出-----------------

;まず各国の経済値を保存
FOR LOCAL, 0, MAX_COUNTRY
	IF CFLAG:MASTER:所属 == LOCAL
		自国経済値 = GET_SUM_ECONOMY(LOCAL)
	ELSEIF IS_COUNTRY(LOCAL)
		各国経済値:LOCAL = GET_SUM_ECONOMY(LOCAL)
	ENDIF
NEXT

;野盗勢力に所属していない場合、野盗勢力の経済値は自国経済値の倍ということにしておく
SIF 野盗 > 0 && CFLAG:MASTER:所属 != 野盗
	各国経済値:野盗 = 自国経済値 * 2


;自国より経済値が大きい国家を候補として記録
FOR LOCAL, 0, MAX_COUNTRY
	IF 自国経済値 < 各国経済値:LOCAL
		候補国:候補数 = LOCAL
		候補数 ++
	ENDIF
NEXT

;候補がなかったらおわる
IF 候補数 == 0
	RETURN 0
ENDIF

;候補が存在するなら、ランダムで選出したものを結果国とする
CALL FISHER_YATES_SHAFFLE(候補数)
結果国 = 候補国:(SHAFFLE_ARRAY:0)
結果君主 = GET_COUNTRY_BOSS(結果国)

;3割の確率で強制的に野盗になる
IF 野盗 > 0 && CFLAG:MASTER:所属 != 野盗 && RAND:100 < 30
	結果国 = 野盗
	結果君主 = GET_COUNTRY_BOSS(野盗)
ENDIF

;------------ここからキャラの選出-----------------

;候補数をゼロクリア
VARSET 候補数

;キャラの選出
FOR LOCAL, 0, CHARANUM
	;MASTERではなく、MASTER所属勢力の君主でもなく、同じ国に所属。もし結果国が野盗なら女であること。動物はだめ。
	IF LOCAL != MASTER && !IS_SP_CHARA(LOCAL) && LOCAL != GET_COUNTRY_BOSS(CFLAG:MASTER:所属) && CFLAG:(LOCAL):所属 == CFLAG:MASTER:所属 && !CFLAG:(LOCAL):捕虜先 && (結果国 != 野盗 || IS_FEMALE(LOCAL)) && !IS_ANIMAL(LOCAL)
		;0 ~ 「四能力の10倍と、好感度・従属度・依存度の1/10の総和」　の乱数を保存
		候補キャラ:LOCAL = RAND(0, MAX((ABL:LOCAL:武闘 + ABL:LOCAL:防衛 + ABL:LOCAL:知略 + ABL:LOCAL:政治) * 10 + (CFLAG:LOCAL:好感度 + CFLAG:LOCAL:従属度 + CFLAG:LOCAL:依存度 + CFLAG:(LOCAL):支配度) / 10, 1))
		候補数 ++
	ENDIF
NEXT

;候補がなかったら終わる
IF 候補数 == 0
	PRINTFORMW 人材の提供を要求しようとした勢力があったようだが、こちらの人材が枯渇していると知りあきらめたようだ……
	RETURN 0
ENDIF

;先ほど得た乱数が最大だったキャラを取得
結果キャラ = FINDELEMENT(候補キャラ, MAXARRAY(候補キャラ))

;ないはずだけど、結果キャラがみつからなかったら終わる
SIF 結果キャラ <= 0
	RETURN 0

;ここからメッセージと各種処理
;野盗の場合は特殊パターン
IF 結果国 != 野盗
	PRINTFORML %ANAME(MASTER)%が政務を行っていると、部下が来客を告げた
	CALL COLOR_PRINT(@"%ANAME(結果君主)%", カラー_注意)
	PRINTFORMW が使いをよこしてきたのだという
	PRINTFORML %ANAME(結果君主)%といえば、こちらより強力な勢力を率いている君主だ
	PRINTFORMW むげに扱うわけにはいかないので、%ANAME(MASTER)%は早速会うことにした……
	PRINTFORML
	PRINTFORML
	PRINTFORML
	PRINTFORMW %ANAME(結果君主)%の使いが持ってきた話は、こういうことだった
	PRINTFORML
	PRINTFORML 昨今は戦いが激しくなり、国は有望な人材を求めてやまない
	PRINTFORM ついては、%ANAME(MASTER)%のところにいる
	CALL COLOR_PRINT(@"%ANAME(結果キャラ)%", カラー_注意)
	PRINTFORMW を譲ってくれないか
	PRINTFORMW こちらから出せるものは特にないが、両勢力の友好関係にとって大変有意義な取引である……
	PRINTFORML
	PRINTFORML むろん、こちらの勢力の弱さにつけ込んだ、足下を見た要求だ
	PRINTFORML 怒りを覚える%ANAME(MASTER)%だが、いかんせん向こうの方が立場が強いのは事実
	PRINTFORML 断れば相手は心証を悪くするだろうし、それは%ANAME(MASTER)%の勢力の将来を危うくしかねない
	PRINTFORMW かといって、そんな人質のような役目を%ANAME(結果キャラ)%に負わせられるだろうか……
	CALL SINGLE_DRAWLINE
	CALL ASK_YN(@"%ANAME(結果キャラ)%を送り出す", "断る")
	LOCAL = RESULT
	IF RESULT == 0
		PRINTFORMW ここは従うしかない。そう考えた%ANAME(MASTER)%は、%ANAME(結果キャラ)%を送り出すことにした……
		PRINTFORMW 要求に従ったことで、%ANAME(結果君主)%は大いに気を良くしたようだ
		CALL CHANGE_RELATION_C_TO_C(結果国, CFLAG:MASTER:所属, 500, -300)
		CALL CHANGE_COUNTRY(結果キャラ, 結果国, 1)
		CFLAG:結果キャラ:好感度 /= 2
		CFLAG:結果キャラ:依存度 /= 2
		CFLAG:結果キャラ:従属度 /= 2
		CFLAG:結果キャラ:支配度 /= 2
	ELSEIF RESULT == 1
		PRINTFORMW やはりそんなことはできない。そう伝え、%ANAME(結果君主)%の使いを送り返した
		PRINTFORMW 要求を生意気にも断ってきたと、%ANAME(結果君主)%は立腹しているようだ……
		CALL CHANGE_RELATION_C_TO_C(結果国, CFLAG:MASTER:所属, -300, 300)
	ENDIF
	DVAR:士官要求_発生禁止カウンタ = 10
ELSE
	PRINTFORML %ANAME(MASTER)%が政務を行っていると、部下が来客を告げた
	CALL COLOR_PRINT(@"%ANAME(結果君主)%", カラー_注意)
	PRINTFORMW が使いをよこしてきたのだという
	PRINTFORML %ANAME(結果君主)%といえば、各国が頭を悩ましている相手だ
	PRINTFORMW 一体何を伝えに来たのだと、%ANAME(MASTER)%は早速会うことにした……
	PRINTFORML
	PRINTFORML
	PRINTFORML
	PRINTFORMW %ANAME(結果君主)%の使いが持ってきた話は、こういうことだった
	PRINTFORML
	PRINTFORML 最近、勢力圏内の村々を狩りつくしてしまい、ろくな娘がいなくなってしまった
	PRINTFORML 最近いい女を抱けていない男連中は餓えており、士気にも影響がでている
	PRINTFORM そんなとき、%ANAME(MASTER)%のところにいる
	CALL COLOR_PRINT(@"%ANAME(結果キャラ)%", カラー_注意)
	PRINTFORMW が上玉だと聞いた
	PRINTFORML そこで頼み事なのだが、%ANAME(結果キャラ)%を「捕虜として」「貸して」くれないか
	PRINTFORMW さもなくば、何らかの「不利益」が%ANAME(MASTER)%に生ずることになるだろう
	PRINTFORML 昨今、我々は力をつけ、今や各国と対等に渡り合える関係にある
	PRINTFORMW 報復は必ず実行されることを忘れるな
	PRINTFORMW %ANAME(結果キャラ)%のことは丁重に扱ってやるから、安心してくれてかまわない……
	PRINTFORML
	PRINTFORML 貸してくれ、丁重に扱うなどと言ってこそいるが、奴らが%ANAME(結果キャラ)%を性奴隷代わりにすることは間違いない
	PRINTFORMW 賊ふぜいが、なんとふざけた要求か！
	PRINTFORML 怒りを覚える%ANAME(MASTER)%だが、奴らが厄介で、言ったことを実行する執念深さがあるのも事実
	PRINTFORML 断れば、相手が何らかの嫌がらせ――それも血も涙もないような――にでるのは確実だろう
	PRINTFORMW かといって、こんな人を人とも思わない連中に%ANAME(結果キャラ)%を渡していいのだろうか……
	CALL SINGLE_DRAWLINE
	CALL ASK_MULTI(@"%ANAME(結果キャラ)%を送り出す", "刺激しないよう、丁重に断る", "使いの者を斬り捨てる")
	LOCAL = RESULT
	IF RESULT == 0
		PRINTFORMW ここは従うしかない。そう考えた%ANAME(MASTER)%は、%ANAME(結果キャラ)%を送り出すことにした……
		PRINTFORMW 使いの者は、皆の見ている前で%ANAME(結果キャラ)%の服を剥ぎ取り、首輪と手足の枷を嵌め、鎖をひいて連れて行った……
		PRINTFORMW 野盗どものアジトに連れ帰られた%ANAME(結果キャラ)%は、野盗全員の前で新たな奴隷としてお披露目された
		PRINTFORMW そしてそのまま、奴隷として初めての「お仕事」に従事させられたようだ……
		CALL FORCE_FREE(結果キャラ)
		CALL FUCK_GANGBANG(結果キャラ, GET_SPERM_ID("野盗"), @"野盗の\@ RAND:2 ? ペニス # 唇\@", "野盗")

```
