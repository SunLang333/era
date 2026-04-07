# SYSTEM/SP_COUNTRY/VIGILANTE/VIGILANTE_FUNCTIONS.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/VIGILANTE/VIGILANTE_FUNCTIONS.ERB`

类型: .ERB

自动摘要: functions: TURNEND_VIGILANTE, VIGILANTE_DESTROY_MSG, START_TRAIN_COMMON_VIGILANTE, VIGILANTE_INIT, VIGILANTE_SPECIAL_REQRUITMENT, SELECT_CHARA_RANDOM_LOGIC_VIGILANTE_SPECIAL_REQRUITMENT, VIGILANTE_KIDNAP, SELECT_CHARA_RANDOM_LOGIC_VIGILANTE_KIDNAP, MASTER_CAPTURED_VIGILANTE, VIGILANTE_ENDING; UI/print

前 200 行源码片段:

```text
﻿;--------------------------------------
;ターンエンド時の自警団の処理
;--------------------------------------
@TURNEND_VIGILANTE
#DIM 自警団
自警団 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_自警団)

;兵力の増える処理
IF DAY % 3 == 0
	CALL SINGLE_DRAWLINE
	LOCAL:0 = MAX(RAND:4000, 1000)
	LOCAL:0 += RAND:500 * SP_COUNTRY_RANK:(特殊勢力_自警団)
	PRINTFORML 自警団が徴兵を行っているようです……
	PRINTFORML 自警団の兵力が{LOCAL:0}増加した
	COUNTRY_SOLDIER:(自警団) += LOCAL:0
ENDIF
;4ターンに1回、特別な徴兵
CALL VIGILANTE_SPECIAL_REQRUITMENT(DAY % 4 == 0)
CALL VIGILANTE_KIDNAP(DAY % 5 == 0)
;--------------------------------------
;滅亡時の処理
;--------------------------------------
@VIGILANTE_DESTROY_MSG
CALL SINGLE_DRAWLINE
SETCOLOR カラー_注意
PRINTFORML
PRINTFORML
PRINTFORML
PRINTFORMW 壊滅的な被害を受けた自警団は、活動を継続することができなくなったようです……
PRINTFORMW 彼らは解散してしまいました
PRINTFORM
PRINTFORML
PRINTFORML
RESETCOLOR

;-------------------------------------------------
;DESC  :自警団所属時に閨・捕虜調教前にアイテムを追加する処理
;-------------------------------------------------
@START_TRAIN_COMMON_VIGILANTE()
ITEM:A_縄 = 1
ITEM:A_鞭 = 1
ITEM:A_針 = 1
ITEM:A_縄 = 1
ITEM:A_目隠し = 1
ITEM:A_口枷 = 1
ITEM:A_鼻フック = 1
ITEM:A_浣腸 = 1
ITEM:A_利尿剤 = 99

;--------------------------------------
;自警団の初期化処理
;--------------------------------------
@VIGILANTE_INIT(ARG:0)
#DIM LCOUNT
VARSET LOCAL

SIF GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_自警団) != -1
	RETURN 0

SIF SP_COUNTRY_RANK:特殊勢力_自警団 == 0
	RETURN 0

SIF GET_NEW_COUNTRY() == -1
	RETURN 0

CALL CREATE_SP_COUNTRY(特殊勢力_自警団)
LOCAL = RESULT
CALL INIT_SP_COUNTRY(LOCAL)

RETURN LOCAL

;--------------------------------------
;自警団の定期イベント。
;陥落済みキャラを使って兵数を増やす
;--------------------------------------
@VIGILANTE_SPECIAL_REQRUITMENT(条件 = 1)
#DIM 自警団
#DIM 条件
#DIM 対象
#DIM メッセージ

自警団 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_自警団))

;自警団勢力があり、条件を満たしている
SIF 自警団 == -1 || !条件
	RETURN -1

CALL SELECT_CHARA_RANDOM("VIGILANTE_SPECIAL_REQRUITMENT")

対象 = RESULT
SIF 対象 == -1
	RETURN

LOCAL = MAX(RAND:3000, 1000)
CALL SINGLE_DRAWLINE
SETCOLOR カラー_ピンク
SELECTCASE RAND:3
	CASE 0
		PRINTFORMW 自警団は勧誘活動を行っている……
		PRINTFORMW ……その中には、%ANAME(対象)%の姿もあった
		PRINTFORML %ANAME(対象)%は何人もの男性に声をかけては、笑顔とトークで拠点へと誘う
		PRINTFORML 拠点に連れ込んだ男達の前で、%ANAME(対象)%は自ら衣服を脱ぎ捨てる
		PRINTFORML 仰天する男達をよそに、%ANAME(対象)%は彼らの前に跪き、口や手でもって肉棒に奉仕する
		PRINTFORMW %ANAME(対象)%にとって「勧誘」とは、つまりこういう行為のことだった
		PRINTFORML 戸惑う男達だったが、ぐぷぐぷという唾液の音と股間の快楽には逆らえない
		PRINTFORML 一人が%ANAME(対象)%を押し倒し、既に濡れそぼっていた肉穴を貫くと、あとはあっという間だった
		PRINTFORML 一人が射精してはまた別の男がと、彼らは次々%ANAME(対象)%の身体に精を放っていく
		PRINTFORMW %ANAME(対象)%も悦んで、自ら口や手、乳房に両穴を捧げてみせた
		PRINTFORML たっぷりと精を解き放ち、%ANAME(対象)%の肉体に夢中になった男達は、二つ返事で入団を了承する
		PRINTFORML 満足した彼らが拠点を後にすると、同期の団員が「おかわり」を連れてくる
		PRINTFORML 全身精液にまみれた淫らな姿で、%ANAME(対象)%が自ら秘唇を割り開く
		PRINTFORMW 今度の男達は事情を把握していたらしく、下卑た笑みを浮かべながら%ANAME(対象)%を貫いていった……
		PRINTFORMW %ANAME(対象)%の努力により、入団希望者はずいぶんと増えたようだ……
		CALL FUCK_SP(対象, "欲望, 精愛, 性交, Ａ, Ｖ, Ｂ, Ｃ, Ｍ, 輪姦, 口淫, Ｖ性交, Ａ性交", "膣内射精, 処女喪失, Ａ処女喪失, キス喪失, 腸内射精, 口内射精", 自警団, GET_SPERM_ID("行きずりの男"), @"行きずりの男の\@ RAND:2 ? 唇 # ペニス \@", "行きずりの男", "", "輪姦")
	CASE 1
		PRINTFORMW 自警団は地元の有力者と会合を開いている……
		PRINTFORMW ……代表者は、%ANAME(対象)%だった
		PRINTFORML 肥満体の男と%ANAME(対象)%は、ベッドの上で肌を重ねている
		PRINTFORML そり勃つペニスに音をたててしゃぶりつきながら、自ら秘貝を彼の顔面に押しつける
		PRINTFORML ねっとりとした舌が陰核をこねくり回すと、%ANAME(対象)%は甘い声をあげてよがってみせる
		PRINTFORMW 男が耐えきれず精を放つと、%ANAME(対象)%は瞳を蕩かせ、音を立てて白濁を飲み下していく
		PRINTFORML 呼吸を整える彼の前で、%ANAME(対象)%は淫具を手に取り、自らオナニーショーを披露する
		PRINTFORML ぐちゅぐちゅと淫らな音を立ててバイブで秘裂を掻き回す様に、男もすぐに元気を取り戻したようだ
		PRINTFORML もっといい物をあげようとのしかかってくる男を前に、%ANAME(対象)%は自らの秘貝を手で隠した
		PRINTFORML もっといいことがしたいなら、私たちに協力してください
		PRINTFORML %ANAME(対象)%がそのように要求すると、焦れた男は二つ返事で了承する
		PRINTFORMW ヒクつく雌穴に勃起した一物が挿入されると、%ANAME(対象)%はたまらないという声をあげてよがった
		PRINTFORMW %ANAME(対象)%はその後も、丸々一夜をかけ、その身体でもって男からあらゆる支援の約束を取り付けた……
		CALL FUCK_SP(対象, "欲望, 精愛, 性交, Ａ, Ｖ, Ｂ, Ｃ, Ｍ, 輪姦, 口淫, Ｖ性交, Ａ性交, 売春", "膣内射精, 処女喪失, Ａ処女喪失, キス喪失, 腸内射精, 口内射精", 自警団, GET_SPERM_ID("富豪"), @"富豪の\@ RAND:2 ? 唇 # ペニス \@", "富豪", "", "売春")
	CASE 2
		PRINTFORMW 自警団は地元のごろつき達と会合を開いている……
		PRINTFORMW ……代表者は、%ANAME(対象)%だ
		PRINTFORMW 悪事をやめ、自警団に参加するよう、%ANAME(対象)%は彼らに説いている
		PRINTFORMW もちろんそれだけではない。%ANAME(対象)%自身がセットでついていた
		PRINTFORMW ごろつきの頭に命じられ、%ANAME(対象)%は自ら衣服を脱ぎ捨てる
		PRINTFORMW 彼の下衣を口でずらし、肉棒を露出させると、艶やかな唇で迎え入れる
		PRINTFORMW 音をたてて扱き下ろし、音をたてて白濁を嚥下する様は、極めて淫らだった
		PRINTFORMW その後、%ANAME(対象)%はねそべる男に自らまたがり、%STR_BODY("膣：欲情：感度", 対象)%でもってペニスを悦ばせ始める
		PRINTFORMW 男が精を解き放つと、悦びの声をあげながら、粘つく濁液を子宮で受け止めて見せた
		PRINTFORMW もちろんそれで終わりではない
		PRINTFORMW 頭目が%ANAME(対象)%を顎でしゃくり、周囲を取り囲む部下達にも奉仕するように命じる
		PRINTFORMW %ANAME(対象)%は瞳を蕩かせ、口や手、乳房に両穴でもって、丸一日かけて何人もの男達の欲望を受け止めていった……
		CALL FUCK_SP(対象, "欲望, 精愛, 性交, Ａ, Ｖ, Ｂ, Ｃ, Ｍ, 輪姦, 口淫, Ｖ性交, Ａ性交", "膣内射精, 処女喪失, Ａ処女喪失, キス喪失, 腸内射精, 口内射精", 自警団, GET_SPERM_ID("ごろつき"), @"ごろつきの\@ RAND:2 ? 唇 # ペニス \@", "ごろつき", "", "輪姦")
ENDSELECT
PRINTFORML 
PRINTFORMW 自警団の兵数が{LOCAL}増加した

RESETCOLOR

COUNTRY_SOLDIER:自警団 += LOCAL

RETURN 1

@SELECT_CHARA_RANDOM_LOGIC_VIGILANTE_SPECIAL_REQRUITMENT(対象)
#DIM 対象
RETURN IS_FEMALE(対象) && CFLAG:対象:所属 == GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_自警団) && !CFLAG:対象:捕虜先 && !IS_SP_CHARA(対象)


;--------------------------------------
;自警団の定期イベント。
;キャラを「勧誘」する
;--------------------------------------
@VIGILANTE_KIDNAP(条件 = 1)
#DIM 対象
#DIM 条件
#DIM 自警団
自警団 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_自警団))

;自警団勢力があり、条件を満たしている
SIF 自警団 == -1 || !条件
	RETURN -1

CALL SELECT_CHARA_RANDOM("VIGILANTE_KIDNAP")

対象 = RESULT

SIF 対象 == -1
	RETURN

CALL SINGLE_DRAWLINE()
SETCOLOR カラー_ピンク
PRINTFORML 突然、%ANAME(対象)%は得体の知れない男達に取り囲まれた！
PRINTFORML 口を塞がれ、すぐ近くの建物に連れ込まれた
PRINTFORMW ……そこは自警団の拠点だった
PRINTFORML 君は見込みがありそうだ、我々の一員として教育してあげようと、異様に瞳をキラキラさせた男達は言う
PRINTFORMW そして%ANAME(対象)%の服を剥ぎ取ると、思想教育とセットで陵辱しはじめた……
PRINTFORML 
PRINTFORML 
PRINTFORML 
CALL FUCK_SP(対象, "欲望, 精愛, 性交, Ａ, Ｖ, Ｂ, Ｃ, Ｍ, 輪姦, 口淫, Ｖ性交, Ａ性交", "膣内射精, 処女喪失, Ａ処女喪失, キス喪失, 腸内射精, 口内射精", 自警団, GET_SPERM_ID("自警団員"), @"自警団員の\@ RAND:2 ? 唇 # ペニス \@", "自警団員", "", "輪姦")

PRINTFORMW 激しい陵辱で、%ANAME(対象)%はすっかり体力を使い果たしてしまった
PRINTFORMW 今日はこれくらいにしておこう、明日からも研修は続くから準備しておくようにと、男達は%ANAME(対象)%を室内に閉じ込めた……

CALL COLOR_PRINTW(@"%ANAME(対象)%が自警団に囚われました", カラー_警告)
RESETCOLOR
CALL CAPTURE(対象, 自警団)

RETURN 1

```
