# SHOP/SHOP_SLG/SHOP_SLG41_外交2_友好_会談_性的.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_SLG/SHOP_SLG41_外交2_友好_会談_性的.ERB`

类型: .ERB

自动摘要: functions: SELECT_CHARA_LIST_SHOW_LOGIC_DIPLOMACY_TALK_SEX, SELECT_CHARA_LIST_SELECT_LOGIC_DIPLOMACY_TALK_SEX, DIPLOMACY_TALK_SEX, TALK_CAN_GIVE_SEX, SELECT_PLAY_LIST; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;会談性的
;-------------------------------------------------
@SELECT_CHARA_LIST_SHOW_LOGIC_DIPLOMACY_TALK_SEX(対象)
#DIM 対象
RETURN CFLAG:対象:行動不能状態 != 行動不能_子供 && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !IS_ANIMAL(対象)

@SELECT_CHARA_LIST_SELECT_LOGIC_DIPLOMACY_TALK_SEX(対象)
#DIM 対象
RETURN IS_FREE(対象) && CFLAG:対象:捕虜先 == 0 && TALK_CAN_GIVE_SEX(対象)

;---------------------------
;会談にて女を用意した場合
;---------------------------
@DIPLOMACY_TALK_SEX(提供先)
#DIM プレイ内容
#DIM 提供先
#DIM 提供元
#DIM 満足度
#DIM FIRST_LINE
#DIM CONST 相互フェラ = 0
#DIM CONST 相互挿入 = 1
#DIM CONST 相互アナルセックス = 2
#DIM CONST フェラする = 3
#DIM CONST フェラされる = 4
#DIM CONST セックスする = 5
#DIM CONST セックスされる = 6
#DIM CONST アナルセックスする = 7
#DIM CONST アナルセックスされる = 8
#DIM CONST クンニする = 9
#DIM CONST クンニされる = 10
#DIM CONST 貝合わせ = 11
#DIM CONST キス = 12
#DIM CONST 乱交 = 13
#DIM CONST 兵士に提供される = 14
#DIM CONST 踊りを披露する = 15
#DIM CONST 汎用 = 16
VARSET 満足度
$SELECT_CHARA
CALL SINGLE_DRAWLINE
PRINTFORML %ANAME(MASTER)%は「楽しみ」を提供することにした
PRINTFORML あるていどの性知識がないとそもそも話にならないし、
PRINTFORML 命じれば他人に身体を開くくらい屈服している必要もある
PRINTFORML あるいは、他人に身体を開くことに抵抗のないあばずれでもいいが……
PRINTFORML さて、誰にすべきか……
CALL SINGLE_DRAWLINE
CALL SELECT_CHARA_LIST("DIPLOMACY_TALK_SEX", "DIPLOMACY_TALK_SEX", "DEFAULT", "欲望", "性技", "奉仕", "性交", "政治")
SIF RESULT == -1
	RETURN -1
提供元 = RESULT
CALL SELECT_PLAY_LIST(提供元, 提供先)
SIF RESULT == -1
	GOTO SELECT_CHARA
プレイ内容 = RESULT
SELECTCASE プレイ内容
	CASE 相互フェラ
		IF HAS_PENIS(提供先) && HAS_PENIS(提供元)
			PRINTFORML %ANAME(提供先)%はさっそく、%ANAME(提供元)%の服を脱がせ、自らも服を脱いだ
			PRINTFORML 二人の股座にある逸物は、快楽への期待で早くもいきり勃っている……
			PRINTFORML %ANAME(提供先)%は自らの逸物を%ANAME(提供元)%のソレに押しつけ、軽く腰を動かす
			PRINTFORML 二人のペニスからは、既に先走りがとろとろと零れている……
			PRINTFORML やがて%ANAME(提供先)%は%ANAME(提供元)%を仰向けにさせると、その上に互い違いに覆い被さった
			PRINTFORML そして%ANAME(提供元)%に奉仕させながら、自らも%ANAME(提供元)%のペニスをしゃぶりたてた……
			CALL FUCK(提供先, "欲望, 奉仕, 性技, Ｃ, 射精, 口淫, 精愛", "キス喪失, 口内射精", 0, @"%ANAME(提供元)%のペニス", "", "", "外交関係維持のための和姦")
			CALL FUCK(提供元, "欲望, 奉仕, 性技, Ｃ, 射精, 口淫, 精愛", "キス喪失, 口内射精", 0, @"%ANAME(提供先)%のペニス", "", "", "外交関係維持のための和姦")
			PRINTFORML 行為は二人が何度も射精し、互いの顔面が互いの汁まみれになるまで続いた……
		ELSE
			GOTO SELECT_CHARA
		ENDIF
	CASE 相互挿入
		IF HAS_VAGINA(提供先) && HAS_PENIS(提供先) && HAS_VAGINA(提供元) && HAS_PENIS(提供元)
			PRINTFORML %ANAME(提供先)%はさっそく、%ANAME(提供元)%の服を脱がせ、自らも服を脱いだ
			PRINTFORML 二人の股座にある逸物は、快楽への期待で早くもいきり勃っている……
			PRINTFORML %ANAME(提供先)%は自らの逸物を%ANAME(提供元)%のソレに押しつけ、軽く腰を動かす
			PRINTFORML 二人のペニスからは、既に先走りがとろとろと零れている……
			SELECTCASE RAND:7
				CASE 0
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%を四つん這いにさせ、後ろからその雌穴を貫いた
				CASE 1
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%を仰向けにさせ、覆い被さって上から何度も雌穴を突いた
				CASE 2
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%に壁に手をついて尻を向けさせ、後ろからその雌穴を貫いた
				CASE 3
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%と向かい合い、立ったまま雌穴を貫いた
				CASE 4
					PRINTFORML 続いて%ANAME(提供先)%は座り、%ANAME(提供元)%を向かい合った体勢で跨がらせ、下から何度も突き上げた
				CASE 5
					PRINTFORML 続いて%ANAME(提供先)%は座り、%ANAME(提供元)%を後ろ向きの体勢で跨がらせ、下から何度も突き上げた
				CASE 6
					PRINTFORML 続いて%ANAME(提供先)%は仰向けに寝ると、%ANAME(提供元)%を己の上に跨がらせ、自ら腰を振らせた
			ENDSELECT
			PRINTFORML やがて%ANAME(提供先)%は、%ANAME(提供元)%の膣内にたっぷりと射精した
			SELECTCASE RAND:7
				CASE 0
					PRINTFORML そして今度は自ら%ANAME(提供元)%に尻を向け、腰をくねらせて性交をねだった
				CASE 1
					PRINTFORML そして今度は自ら仰向けに横たわり、股を開き秘裂を指で開いて性交をねだった
				CASE 2
					PRINTFORML そして今度は自ら壁に手をついて%ANAME(提供元)%に尻を向け、後ろから雌穴を貫くようねだった
				CASE 3
					PRINTFORML そして今度は%ANAME(提供元)%と向かい合い、立ったままの姿勢で犯すよう命じた
				CASE 4
					PRINTFORML 続いて%ANAME(提供先)%は%ANAME(提供元)%を座らせ、向かい合った体勢で跨がると、下から突き上げるようねだった
				CASE 5
					PRINTFORML 続いて%ANAME(提供先)%は%ANAME(提供元)%を座らせ、後ろ向きの体勢で跨がると、下から何度も突き上げるようねだった
				CASE 6
					PRINTFORML 続いて%ANAME(提供先)%は%ANAME(提供元)%を仰向けに寝かせ、その上に跨がると、亀頭に己の雌穴の入り口を擦りつける
			ENDSELECT
			PRINTFORML 膣内射精で欲望に火の付いた%ANAME(提供元)%が、その誘惑に逆らえるはずもなかった……
			CALL FUCK(提供先, "欲望, Ｃ, Ｖ, 性交, 精愛, 射精,　Ｖ性交, Ｖ挿入", "処女喪失, 童貞喪失, 膣内射精", GET_ID(提供元), "", ANAME(提供元), @"%ANAME(提供元)%の膣", "外交関係維持のための和姦")
			CALL FUCK(提供元, "欲望, Ｃ, Ｖ, 性交, 精愛, 射精,　Ｖ性交, Ｖ挿入", "処女喪失, 童貞喪失, 膣内射精", GET_ID(提供先), "", ANAME(提供元), @"%ANAME(提供先)%の膣", "外交関係維持のための和姦")
			PRINTFORML 行為が終わる頃には、互いの身体は真っ白になっていた……
		ELSE
			GOTO SELECT_CHARA
		ENDIF
	CASE 相互アナルセックス
		IF HAS_PENIS(提供先) && HAS_PENIS(提供元)
			PRINTFORML %ANAME(提供先)%はさっそく、%ANAME(提供元)%の服を脱がせ、自らも服を脱いだ
			PRINTFORML 二人の股座にある逸物は、快楽への期待で早くもいきり勃っている……
			PRINTFORML %ANAME(提供先)%は自らの逸物を%ANAME(提供元)%のソレに押しつけ、軽く腰を動かす
			PRINTFORML 二人のペニスからは、既に先走りがとろとろと零れている……
			SELECTCASE RAND:7
				CASE 0
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%を四つん這いにさせ、後ろからその菊穴を貫いた
				CASE 1
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%を仰向けにさせ、覆い被さって上から何度も菊穴を突いた
				CASE 2
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%に壁に手をついて尻を向けさせ、後ろからその菊穴を貫いた
				CASE 3
					PRINTFORML 続いて%ANAME(提供先)%は、%ANAME(提供元)%と向かい合い、立ったまま菊穴を貫いた
				CASE 4
					PRINTFORML 続いて%ANAME(提供先)%は座り、%ANAME(提供元)%を向かい合った体勢で跨がらせ、下から何度も尻穴を突き上げた
				CASE 5
					PRINTFORML 続いて%ANAME(提供先)%は座り、%ANAME(提供元)%を後ろ向きの体勢で跨がらせ、下から何度も尻穴を突き上げた
				CASE 6
					PRINTFORML 続いて%ANAME(提供先)%は仰向けに寝ると、%ANAME(提供元)%を己の上に跨がらせ、自ら腰を振らせた
			ENDSELECT
			PRINTFORML やがて%ANAME(提供先)%は、%ANAME(提供元)%の肛内にたっぷりと射精した
			PRINTFORML そして今度は自ら%ANAME(提供元)%に尻を向け、性交をねだった
			SELECTCASE RAND:7
				CASE 0
					PRINTFORML そして今度は自ら%ANAME(提供元)%に尻を向け、腰をくねらせて肛門性交をねだった
				CASE 1
					PRINTFORML そして今度は自ら仰向けに横たわり、股を開き尻穴を指で開いて肛門性交をねだった
				CASE 2
					PRINTFORML そして今度は自ら壁に手をついて%ANAME(提供元)%に尻を向け、後ろからアナルを犯すようねだった
				CASE 3
					PRINTFORML そして今度は%ANAME(提供元)%と向かい合い、立ったままの姿勢でアナルを犯すよう命じた
				CASE 4
					PRINTFORML 続いて%ANAME(提供先)%は%ANAME(提供元)%を座らせ、向かい合った体勢で跨がると、下から菊穴を突き上げるようねだった
				CASE 5
					PRINTFORML 続いて%ANAME(提供先)%は%ANAME(提供元)%を座らせ、後ろ向きの体勢で跨がると、下から菊穴を何度も突き上げるようねだった
				CASE 6
					PRINTFORML 続いて%ANAME(提供先)%は%ANAME(提供元)%を仰向けに寝かせ、その上に跨がると、亀頭に己の尻穴の入り口を擦りつける
			ENDSELECT
			PRINTFORML 肛内射精で欲望に火の付いた%ANAME(提供元)%が、その誘惑に逆らえるはずもなかった……
			CALL FUCK(提供先, "欲望, Ｃ, Ａ, 性交, 精愛, 射精, Ａ性交, Ａ挿入", "Ａ処女喪失, 童貞喪失, 腸内射精", 0, "", ANAME(提供元), @"%ANAME(提供元)%のアナル", "外交関係維持のための和姦")
			CALL FUCK(提供元, "欲望, Ｃ, Ａ, 性交, 精愛, 射精, Ａ性交, Ａ挿入", "Ａ処女喪失, 童貞喪失, 腸内射精", 0, "", ANAME(提供元), @"%ANAME(提供先)%のアナル", "外交関係維持のための和姦")
			PRINTFORML 行為が終わる頃には、互いの身体は真っ白になっていた……
		ELSE
			GOTO SELECT_CHARA
		ENDIF
	CASE 乱交
		IF HAS_VAGINA(提供先) && HAS_PENIS(提供先) && HAS_VAGINA(提供元) && HAS_PENIS(提供元)
			PRINTFORML %ANAME(提供先)%はさっそく、%ANAME(提供元)%の服を脱がせ、自らも服を脱いだ
			PRINTFORML 二人の股座にある逸物は、快楽への期待で早くもいきり勃っている……
			PRINTFORML %ANAME(提供先)%は自らの逸物を%ANAME(提供元)%のソレに押しつけ、軽く腰を動かす
			PRINTFORML 二人のペニスからは、既に先走りがとろとろと零れている……
			PRINTFORML 不意に、%ANAME(提供先)%はぱんぱんと手を叩いた
			PRINTFORML すると、淫らな衣装を纏った男女がぞろぞろと部屋に入ってきた。%ANAME(提供先)%が囲っているのだという
			PRINTFORML 彼ら・彼女らも交え、二人は延々、文字通り精魂尽き果てるまで何度も、誰とでも交わった……
			CALL FUCK(提供先, "欲望, 性技, Ｃ, Ｖ, Ａ, Ｂ, Ｍ, Ｖ拡張, Ａ拡張, 性交, 自慰, 精愛, 露出, 排泄, 射精, 苦痛快楽, 緊縛, マゾ, キス, 口淫, 輪姦, Ｖ挿入, Ａ挿入, Ｖ性交, Ａ性交", "キス喪失, 処女喪失, Ａ処女喪失, 童貞喪失, 膣内射精, 腸内射精, 口内射精", (RAND:2 ? GET_SPERM_ID("兵士") # GET_ID(提供元)), @"\@ RAND:2 ?%ANAME(提供元)%のペニス # %ANAME(提供先)%の私兵のペニス\@", @"\@ RAND:2 ?%ANAME(提供元)% # %ANAME(提供先)%の私兵\@", @"\@ RAND:2 ?%ANAME(提供元)% # %ANAME(提供先)%の私兵\@の\@ RAND:2 ? 膣 # アナル \@", "外交関係維持のための輪姦")
			CALL FUCK(提供元, "欲望, 性技, Ｃ, Ｖ, Ａ, Ｂ, Ｍ, Ｖ拡張, Ａ拡張, 性交, 自慰, 精愛, 露出, 排泄, 射精, 苦痛快楽, 緊縛, マゾ, キス, 口淫, 輪姦, Ｖ挿入, Ａ挿入, Ｖ性交, Ａ性交", "キス喪失, 処女喪失, Ａ処女喪失, 童貞喪失, 膣内射精, 腸内射精, 口内射精", (RAND:2 ? GET_SPERM_ID("兵士") # GET_ID(提供先)), @"\@ RAND:2 ?%ANAME(提供先)%のペニス # %ANAME(提供先)%の私兵のペニス\@", @"\@ RAND:2 ?%ANAME(提供先)% # %ANAME(提供先)%の私兵\@", @"\@ RAND:2 ?%ANAME(提供先)% # %ANAME(提供先)%の私兵\@の\@ RAND:2 ? 膣 # アナル \@", "外交関係維持のための輪姦")
			PRINTFORML 宴が終わる頃には、二人とも真っ白に染め上げられていた
		ELSEIF HAS_VAGINA(提供元) && HAS_VAGINA(提供先)
			PRINTFORML %ANAME(提供先)%はさっそく、%ANAME(提供元)%の服を脱がせ、自らも服を脱いだ
			PRINTFORML 二人の秘裂は、快楽への期待でとろとろになっている……
			PRINTFORML 不意に、%ANAME(提供先)%はぱんぱんと手を叩いた
			PRINTFORML すると、屈強な兵士達がぞろぞろとなだれ込んできた
			PRINTFORML そのまま、%ANAME(提供先)%と%ANAME(提供元)%は、慰安と称して兵士達と乱交に及んだ……
			PRINTFORML やがてコトが終わると、そこには全身あらゆる穴から種を零す%ANAME(提供元)%と%ANAME(提供先)%が残されていた
			CALL FUCK(提供先, "欲望, 性技, Ｃ, Ｖ, Ａ, Ｂ, Ｍ, Ｖ拡張, Ａ拡張, 性交, 自慰, 精愛, 露出, 排泄, 射精, 苦痛快楽, 緊縛, マゾ, キス, 口淫, 輪姦, Ｖ性交, Ａ性交", "キス喪失, 処女喪失, Ａ処女喪失, 童貞喪失, 膣内射精, 腸内射精, 口内射精", (RAND:2 || !HAS_PENIS(提供元) ? GET_SPERM_ID("兵士") # GET_ID(提供元)), @"%ANAME(提供先)%の私兵のペニス", @"%ANAME(提供先)%の私兵", "", "外交関係維持のための輪姦")
			CALL FUCK(提供元, "欲望, 性技, Ｃ, Ｖ, Ａ, Ｂ, Ｍ, Ｖ拡張, Ａ拡張, 性交, 自慰, 精愛, 露出, 排泄, 射精, 苦痛快楽, 緊縛, マゾ, キス, 口淫, 輪姦, Ｖ性交, Ａ性交", "キス喪失, 処女喪失, Ａ処女喪失, 童貞喪失, 膣内射精, 腸内射精, 口内射精", (RAND:2 || !HAS_PENIS(提供先) ? GET_SPERM_ID("兵士") # GET_ID(提供先)), @"%ANAME(提供先)%の私兵のペニス", @"%ANAME(提供先)%の私兵", "", "外交関係維持のための輪姦")
		ELSE
			GOTO SELECT_CHARA
		ENDIF
	CASE フェラする
		IF HAS_PENIS(提供先)
			PRINTFORML %ANAME(提供先)%はさっそく、%ANAME(提供元)%の服を脱がせ、自らも服を脱いだ
			PRINTFORML %ANAME(提供先)%の股座にある逸物は、快楽への期待で早くもいきり勃っている……
			PRINTFORML %ANAME(提供先)%は%ANAME(提供元)%を跪かせると、自らの逸物を%ANAME(提供元)%の頬に押しつける
			PRINTFORML 何をせよと言われているか察した%ANAME(提供元)%は、早速%ANAME(提供先)%のペニスに奉仕を始めた
			SELECTCASE RAND:3
				CASE 0
					PRINTFORML 濃厚な雄の匂いが、味覚に、嗅覚に充満する……
				CASE 1
					PRINTFORML ぢゅぶ、ぢゅぼ、ぐぽと、ねっとりした水音が室内に充満する……
				CASE 2
					PRINTFORML 脳を蕩かすような雄のフェロモンに、%ANAME(提供元)%の目尻は垂れ下がっている……
			ENDSELECT
```
