# SLG/SCENARIO/SCENARIO16.ERB — 自动生成文档

源文件: `ERB/SLG/SCENARIO/SCENARIO16.ERB`

类型: .ERB

自动摘要: functions: SCENARIO_NAME_16, SCENARIO_MAPSELECT_16, SCENARIO_INTRO_16, SCENARIO_PLACEMENT_16, SCENARIO_EVENT_16; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;シナリオ16
;
;-------------------------------------------------
@SCENARIO_NAME_16
RESULTS = ゆかりんの野望～The Girl in the High Castle～
RETURN

@SCENARIO_MAPSELECT_16

MAPID '= "PACIFICWAR"



@SCENARIO_INTRO_16
PRINTFORML

PRINTFORML
SETCOLOR 0xFFFF00
PRINTFORML 1933年にフランクリン・D・ルーズベルトが暗殺されアメリカ合衆国は混乱の渦に叩き込まれた。
PRINTFORML 後任の大統領らは有効な手を打てず、それを好機と言わんばかりに極東情勢は悪化していってしまう。
PRINTFORML しかしロスアラモスに降り立ったUFOの一団がそれを収めることになった。
PRINTFORML サンフランシスコの戦いを経てサクラメントに本拠地を置いた彼女らの手によってアメリカ再建計画が整えられていく。
PRINTFORML しかしアジアではこれに先手を打つことを企図している者達がいた…
RESETCOLOR
PRINTFORML
PRINTFORMW どこかで見たようなアジア・太平洋っぽい世界線で複雑怪奇な情勢を打破するのは誰か。
PRINTFORMW 1936年当時（第二次世界大戦直前）の国境線と同時期に独立していた国家を再現しています。
PRINTFORMW 南進するも良し、北伐するも良し世界の命運は貴方の手にあるのだ
PRINTFORMW
	SELECTCASE RAND:25
	CASE 0
		SETCOLOR 0x65318e
		PRINTFORMW 「美しく残酷にこの大地から住ね！」
		RESETCOLOR
	CASE 1
		SETCOLOR 0x554738
		PRINTFORMW 「ふむ、エイリアンの方が通りが良いのならそれでいいわ」
		RESETCOLOR
	CASE 2
		SETCOLOR 0Xeae5e3
		PRINTFORMW 「意地悪」
		RESETCOLOR
	CASE 3
		SETCOLOR 0x00FF99
		PRINTFORMW 「……もしかして可能性があるというのか……」
		RESETCOLOR
	CASE 4
		SETCOLOR 0x9f563a
		PRINTFORMW 「必ず復讐に行くからな、満月の夜に気を付けるんじゃな」
		RESETCOLOR
	CASE 5
		SETCOLOR 0Xe49e61
		PRINTFORMW 「随分と余裕だ事、妖怪に怯えながら行動する人間の癖に」
		RESETCOLOR
	CASE 6
		SETCOLOR 0Xec5d71
		PRINTFORMW 「油断してはなりませんが、余裕が無いと戦いは危険です」
		RESETCOLOR
	CASE 7
		SETCOLOR 0x0B610B
		PRINTFORMW 「神の信仰を邪魔する者は一つ一つ排除しなければいけません」
		RESETCOLOR
	CASE 8
		SETCOLOR 0Xefefef
		PRINTFORMW 「迷うと言う事は、生きた人間らしい行為よね」
		RESETCOLOR
	CASE 9
		SETCOLOR 0Xd7cf3a
		PRINTFORMW 「もしもーし。私、今ねぇ、貴方の目の前にいるの！」
		RESETCOLOR
	CASE 10
		SETCOLOR 0Xfcc801
		PRINTFORMW 「あの世に無くても、今の地上の花は、死の香りがぷんぷんするわ」
		RESETCOLOR
	CASE 11
		SETCOLOR 0X96514d
		PRINTFORMW 「お言葉ですが……やなこった！誰が降伏なんかするもんか」
		RESETCOLOR
	CASE 12
		SETCOLOR 0x974E00
		PRINTFORMW 「ここには何も無かった、そう見えるだろう？」
		RESETCOLOR
	CASE 13
		SETCOLOR 0xc1ab05
		PRINTFORMW 「まだまだ力が有り余っているわ！」
		RESETCOLOR
	CASE 14
		SETCOLOR 0Xefefef
		PRINTFORMW 「独自ルールを追加しているのは我々だけだと思っていた、まさか外の世界でも同じような事が行われているとは、少し悔しい」
		RESETCOLOR
	CASE 15
		SETCOLOR 0X736d71
		PRINTFORMW 「私より強い者はいないわ」
		RESETCOLOR
	CASE 16
		SETCOLOR 0xB40404
		PRINTFORMW 「みんなまだまだね！四千年の歴史から見ればみんな子供のようだわ。」
		RESETCOLOR
	CASE 17
		SETCOLOR 0Xeddc44
		PRINTFORMW 「……どのみち、貴方はコテンパンにしないといけないようね」
		RESETCOLOR
	CASE 18
		SETCOLOR 0xc1ab05
		PRINTFORMW 「とてつもないパワーでお前をやっつけちゃうぞー！」
		RESETCOLOR
	CASE 19
		SETCOLOR 0Xe6eae6
		PRINTFORMW 「私が眠らせてあげるわ、安らかな春眠」
		RESETCOLOR
	CASE 20
		SETCOLOR 0X26499d
		PRINTFORMW 「これからお前をぎったんぎたんにしてやる！」
		RESETCOLOR
	CASE 21
		SETCOLOR 0X8491c3
		PRINTFORMW 「……少しお灸を据えた方が良いかも知れませんね」
		RESETCOLOR
	CASE 22
		SETCOLOR 0x2ca9e1
		PRINTFORMW 「誰も得をしない、誰も幸せにならない、全員が等しく不幸の世界を見せてやる！」
		RESETCOLOR
	CASE 23
		SETCOLOR 0x31B404
		PRINTFORMW 「ふぅ、貴方は罪の念を持ち続けて生きるしかなさそうね……」
		RESETCOLOR
	CASE 24
		SETCOLOR 0x848350
		PRINTFORMW 「真なる秘神の力、全て味わい尽くすが良い！」
		RESETCOLOR
	ENDSELECT

;ランダムキャラは選択に委ねる
FLAG:OPランダムキャラ使用 = 0


@SCENARIO_PLACEMENT_16

;勢力設定
COUNTRY_BOSS:0 = 0
COUNTRY_COLOR:0 = GETDEFCOLOR()

;;--------大日本帝国;--------

COUNTRY_BOSS:1 = GET_ID(NAME_TO_CHARA("紫"))
COUNTRY_COLOR:1 = 0x65318e
COUNTRY_AI_TYPE:1 = AI_好戦

CITY_OWNER:GET_CITYNUMBER("札幌") = 1
CITY_OWNER:GET_CITYNUMBER("秋田") = 1
CITY_OWNER:GET_CITYNUMBER("東京") = 1
CITY_OWNER:GET_CITYNUMBER("横濱") = 1
CITY_OWNER:GET_CITYNUMBER("金澤") = 1
CITY_OWNER:GET_CITYNUMBER("大阪") = 1
CITY_OWNER:GET_CITYNUMBER("廣島") = 1
CITY_OWNER:GET_CITYNUMBER("四國") = 1
CITY_OWNER:GET_CITYNUMBER("長崎") = 1
CITY_OWNER:GET_CITYNUMBER("鹿兒島") = 1
CITY_OWNER:GET_CITYNUMBER("沖繩") = 1
CITY_OWNER:GET_CITYNUMBER("豊原") = 1

CITY_OWNER:GET_CITYNUMBER("硫黄島") = 1
CITY_OWNER:GET_CITYNUMBER("クエゼリン") = 1
CITY_OWNER:GET_CITYNUMBER("パラオ") = 1
CITY_OWNER:GET_CITYNUMBER("サイパン島") = 1
CITY_OWNER:GET_CITYNUMBER("トラック島") = 1

CITY_OWNER:GET_CITYNUMBER("釜山（プサン）") = 1
CITY_OWNER:GET_CITYNUMBER("平壌（ピョンヤン）") = 1

CITY_OWNER:GET_CITYNUMBER("大連（ダーリェン）") = 1
CITY_OWNER:GET_CITYNUMBER("台湾") = 1

CITY_OWNER:GET_CITYNUMBER("ベーリング海") = 1
CITY_OWNER:GET_CITYNUMBER("オホーツク海") = 1
CITY_OWNER:GET_CITYNUMBER("黄海") = 1
CITY_OWNER:GET_CITYNUMBER("マリアナトラフ") = 1
CITY_OWNER:GET_CITYNUMBER("伊豆海溝") = 1
CITY_OWNER:GET_CITYNUMBER("西太平洋") = 1
CITY_OWNER:GET_CITYNUMBER("日本海") = 1


;妖々夢組
CFLAG:(NAME_TO_CHARA("紫")):1 = 1
CFLAG:(NAME_TO_CHARA("藍")):1 = 1
CFLAG:(NAME_TO_CHARA("橙")):1 = 1
CFLAG:(NAME_TO_CHARA("幽々子")):1 = 1
CFLAG:(NAME_TO_CHARA("妖夢")):1 = 1
CFLAG:(NAME_TO_CHARA("半霊")):1 = 1

;神霊廟組
CFLAG:(NAME_TO_CHARA("神子")):1 = 1
CFLAG:(NAME_TO_CHARA("青娥")):1 = 1
CFLAG:(NAME_TO_CHARA("屠自古")):1 = 1
CFLAG:(NAME_TO_CHARA("芳香")):1 = 1
CFLAG:(NAME_TO_CHARA("布都")):1 = 1

;;--------アメリカ合衆国;--------
COUNTRY_BOSS:2 = GET_ID(NAME_TO_CHARA("ぬえ"))
```
