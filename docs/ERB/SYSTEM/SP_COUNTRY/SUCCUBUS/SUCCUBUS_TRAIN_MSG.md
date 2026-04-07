# SYSTEM/SP_COUNTRY/SUCCUBUS/SUCCUBUS_TRAIN_MSG.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/SUCCUBUS/SUCCUBUS_TRAIN_MSG.ERB`

类型: .ERB

自动摘要: UI/print

前 200 行源码片段:

```text
﻿@SUCCUBUS_TRAIN_MSG(対象, 士官フラグ)
#DIM 対象
#DIM プレイ番号
#DIM 勢力番号
#DIM 士官フラグ



勢力番号 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_サキュバス)

IF HAS_VAGINA(対象) && HAS_PENIS(対象)
	プレイ番号 = RAND:4
ELSEIF HAS_VAGINA(対象)
	プレイ番号 = RAND_POCKET(4, 0, 1)
ELSEIF HAS_PENIS(対象)
	プレイ番号 = RAND_POCKET(4, 0, 2)
ELSE
	プレイ番号 = RAND_POCKET(4, 0, 1, 2)
ENDIF

勢力番号 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_サキュバス))

SELECTCASE プレイ番号
	;-------------------------ここからふたなり専用-------------------------
	CASE 0
		SELECTCASE RAND:10
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は半陰陽のサキュバスと交わっている
					PRINTFORML 相手を貫き、貫かれては、お互いのモノをしゃぶりあう
					PRINTFORML 意識を夢に蕩けさせながら、%ANAME(MASTER)%は快楽を貪り続ける
					PRINTFORML 行為は二人の身体が真っ白になるまで続いた……
				ELSE
					PRINTFORML %ANAME(対象)%は半陰陽のサキュバスに押し倒されている
					PRINTFORML 貫かれ、貫かされては、モノをしゃぶられ、しゃぶらされる
					PRINTFORML 耐えなければならないとは知っていても、サキュバスの技術の前に屈してしまいそうになる
					PRINTFORML 行為は%ANAME(対象)%が文字通り精根尽き果てるまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 性交, 射精, 精愛, レズ, キス, 口淫, Ｃ, Ｖ, Ｍ, Ｖ挿入, Ｖ性交", "童貞喪失, 処女喪失, キス喪失, 口内射精", 勢力番号, GET_SPERM_ID("サキュバス"), "サキュバスのペニス", "サキュバス", "サキュバスの膣", "強姦")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスたちと乱交している
					PRINTFORML 誰もが羨むような極上の肉体を相手に、貫いては貫かれ、舐め、舐められ、しゃぶりしゃぶられる
					PRINTFORML 夢の世界では時間すら無限になる。%ANAME(対象)%は文字通り「ずっと」、快楽に溺れ続けた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスたちの乱交に巻き込まれている
					PRINTFORML 何もかも彼女らの思い通りになる夢の世界では、%ANAME(対象)%のささやかな抵抗など無意味でしかない
					PRINTFORML 極上の肉体と極上の技術の前に、%ANAME(対象)%は何度も絶頂させられる
					PRINTFORML 夢の世界では時間すら無限で、%ANAME(対象)%は文字通り「ずっと」、快楽に晒され続けた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 性交, 射精, 精愛, レズ, キス, 口淫, Ｃ, Ｖ, Ａ, Ｂ, Ｍ, 輪姦, Ｖ性交, Ａ性交, Ｖ挿入, Ａ挿入", "童貞喪失, 処女喪失, Ａ処女喪失, キス喪失, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("サキュバス"), "サキュバスのペニス", "サキュバス", "サキュバスの膣", "乱交")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は幾人ものサキュバスに弄ばれている
					PRINTFORML 誰もが羨むような極上の肉体を相手に、貫いては貫かれ、舐め、舐められ、しゃぶりしゃぶられる
					PRINTFORML 夢の世界では時間すら無限になる。%ANAME(対象)%は文字通り「ずっと」、快楽に溺れ続けた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスたちの乱交に巻き込まれている
					PRINTFORML 何もかも彼女らの思い通りになる夢の世界では、%ANAME(対象)%のささやかな抵抗など無意味でしかない
					PRINTFORML 極上の肉体と極上の技術の前に、%ANAME(対象)%は何度も絶頂させられる
					PRINTFORML 夢の世界では時間すら無限で、%ANAME(対象)%は文字通り「ずっと」、快楽に晒され続けた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 性交, 射精, 精愛, レズ, キス, 口淫, Ｃ, Ｖ, Ａ, Ｂ, Ｍ, 輪姦, Ｖ性交, Ａ性交, Ｖ挿入, Ａ挿入", "童貞喪失, 処女喪失, Ａ処女喪失, キス喪失, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("サキュバス"), "サキュバスのペニス", "サキュバス", "サキュバスの膣", "乱交")
			CASE 3
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は後ろからサキュバスに貫かれながら、自らも別のサキュバスを貫いている
					PRINTFORML 女の部分と男の部分の両方で与えられる快楽に、%ANAME(対象)%の意識は蕩けている
					PRINTFORML やがてサキュバスが%ANAME(対象)%の中に精を放つと、その刺激に%ANAME(対象)%も射精する
					PRINTFORML 行為は夢が覚めるまで続いた……
				ELSE
					PRINTFORML %ANAME(対象)%は後ろからサキュバスに貫かれながら、自らも別のサキュバスを貫かされている
					PRINTFORML 女の部分と男の部分両方から快楽を与えられ、%ANAME(対象)%の抗う意志が削がれていく
					PRINTFORML やがてサキュバスが%ANAME(対象)%の中に精を放つと、その刺激に%ANAME(対象)%も射精してしまう
					PRINTFORML 行為は夢が覚めるまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 性交, 精愛, 射精, レズ, Ｃ, Ｖ, 輪姦, Ｖ性交, Ｖ挿入", "童貞喪失, 処女喪失", 勢力番号, GET_SPERM_ID("サキュバス"), "", "サキュバス", "サキュバスの膣", "乱交")
			CASE 4
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスとお互いのモノを愛撫しあっている
					PRINTFORML 互いに口で、胸で、手で、何度も精を搾り取り、互いの身体を白く染めていく
					PRINTFORML 濃厚な口づけをかわし、口腔に溜めた白濁を混ぜ合う
					PRINTFORML 行為は%ANAME(対象)%の意識が夢に溶けるまで続いた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスに愛撫され、愛撫させられている
					PRINTFORML 口や胸、手で精を搾り取り、搾らされ、身体は白く染まっている
					PRINTFORML 堪えなくてはという意志も、サキュバスの人ならざる技術によって削がれていく
					PRINTFORML 行為は%ANAME(対象)%の意識が夢に溶けるまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 精愛, 射精, レズ, Ｃ, キス, 口淫", "キス喪失, 口内射精", 勢力番号, GET_SPERM_ID("不明"), @"サキュバスの\@ RAND:2 ? ペニス # 唇 \@", "", "", "調教")
			CASE 5
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスと貝合わせをしている
					PRINTFORML お互いに腰を揺すり、敏感な粘膜を擦り合わせていく
					PRINTFORML その快感に、勃起した一物からはびゅるびゅると精が放たれていく
					PRINTFORML 行為は互いの身体が白濁で真っ白になるまで続いた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスと貝合わせをしている
					PRINTFORML 抵抗せねばと思っていても、夢魔ならではの性技は堪えがたいものだった
					PRINTFORML 快感に、勃起した一物からびゅるびゅると精を放ってしまう
					PRINTFORML 行為は互いの身体が白濁で真っ白になるまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 射精, レズ, Ｃ", "", 勢力番号, GET_SPERM_ID("サキュバス"), "", "", "", "調教")
			CASE 6
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスに秘部とペニスの両方を弄くり回されている
					PRINTFORML 敏感な棒を裏側から擦られ、白濁をびゅるびゅると吐き出される
					PRINTFORML 蛇口のように吐き出される種を夢魔は音をたてて啜り、吸収していく……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスに秘部とペニスの両方を弄くり回されている
					PRINTFORML 敏感な棒を裏側から擦られ、意志と関わらず射精してしまう
					PRINTFORML 蛇口のように吐き出される種を夢魔は音をたてて啜り、吸収していく……
					PRINTFORML 
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 射精, レズ, Ｃ, Ｖ", "", 勢力番号, GET_SPERM_ID("サキュバス"), "", "", "", "調教")
			CASE 7
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は張り型とオナホールで責められている
					PRINTFORML サキュバスは巧みな技で道具を操り、%ANAME(対象)%に快楽を与える
					PRINTFORML %ANAME(対象)%は背を反りかえらせながら絶頂し、白濁を何度も放っている
					PRINTFORML %ANAME(対象)%が気絶するまで、サキュバスは許さなかった……
				ELSE
					PRINTFORML %ANAME(対象)%は張り型とオナホールで責められている
					PRINTFORML サキュバスは巧みな技で道具を操り、%ANAME(対象)%に快楽を与える
					PRINTFORML 耐えなくてはという意志も蕩かされ、%ANAME(対象)%は何度も絶頂している
					PRINTFORML %ANAME(対象)%が気絶するまで、サキュバスは許さなかった……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性技, 射精, レズ, Ｃ, Ｖ", "処女喪失", 勢力番号, GET_SPERM_ID("サキュバス"), "", "バイブ", "", "調教")
			CASE 8
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は半陰陽のサキュバスに目隠しをされ、縛られ、後ろから突き上げられている
					PRINTFORML 巧みな腰使いに、%ANAME(対象)%は激しく絶頂している
					PRINTFORML さらにはペニスを優しく扱かれ、%ANAME(対象)%は壊れた蛇口のように種を垂れ流している
					PRINTFORML 行為は%ANAME(対象)%が気絶しても続いた……
				ELSE
					PRINTFORML %ANAME(対象)%は半陰陽のサキュバスに目隠しをされ、縛られ、後ろから突き上げられている
					PRINTFORML 巧みな腰使いに、%ANAME(対象)%は意志にかかわらず絶頂してしまう
					PRINTFORML さらにはペニスを優しく扱かれ、耐えようと思いながらも何度も射精する
					PRINTFORML %ANAME(対象)%が気絶するまで、サキュバスは%ANAME(対象)%を嬲り続けた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性技, 精愛, 性交, 射精, レズ, Ｃ, Ｖ, 緊縛, 苦痛快楽, マゾ, Ｖ性交", "処女喪失, 膣内射精", 勢力番号, GET_SPERM_ID("サキュバス"), "", "", "", "調教")
			CASE 9
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスたちに徹底して搾り取られている
					PRINTFORML 束縛された状態でしゃぶられ、扱かれ、%ANAME(対象)%は悦びの声をあげる
					PRINTFORML そのモノが勃たなくなると、彼女らは%ANAME(対象)%の膣や尻穴を弄び、強引に勃たせていく
					PRINTFORML 行為は彼女ら全員が満足するまで続けられた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスたちに徹底して搾り取られている
					PRINTFORML 束縛された状態でしゃぶられ、扱かれ、%ANAME(対象)%は噛みしめた歯の奥からくぐもった快楽の声をあげる
					PRINTFORML そのモノが勃たなくなると、彼女らは%ANAME(対象)%の膣や尻穴を弄び、強引に勃たせていく
					PRINTFORML 行為は彼女ら全員が満足するまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 射精, 射精, 射精, レズ, Ｃ, Ｃ, 緊縛, 苦痛快楽, マゾ", "", 勢力番号, GET_SPERM_ID("サキュバス"), "", "", "", "乱交")
		ENDSELECT
	CASE 1
		;-------------------------ここから要ペニス-------------------------
		SELECTCASE RAND:13
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスと交わっている
					PRINTFORML 女としての理想にあるようなサキュバスの身体を貫いては、何度も種を放っていく
					PRINTFORML 夢の世界に「弾切れ」などはない。二人はただひたすらに快楽を貪っていく
					PRINTFORML 行為は一晩中続いた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスに押し倒されている
					PRINTFORML 女としての理想にあるようなサキュバスの肉体のせいで、意志と関わらず射精してしまう
					PRINTFORML 夢の世界に「弾切れ」などはなく、%ANAME(対象)%は無限に精を搾り取られていく
					PRINTFORML 行為は%ANAME(対象)%が文字通り精魂尽き果てるまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性交, 射精, レズ, Ｃ, Ｖ挿入", "童貞喪失", 勢力番号, 0, "", "", "サキュバスの膣", "調教")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスを後ろから突き上げている
					PRINTFORML 極上の肉体を腰から抱え、ただペニスの快楽を求めて猛然と突き上げる
					PRINTFORML びゅるびゅると精を放つたび、サキュバスはそれを吸収し、己の力としていく
					PRINTFORML 性交は夜が白むまで続いた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスを後ろから突き上げさせられている
					PRINTFORML 従ってたまるかとは思いつつも、その雌穴の極上の締まりに、思わず腰が動いてしまう
					PRINTFORML 意志とは関わらず射精してしまうたび、サキュバスはその精を吸収し己の力とする
					PRINTFORML 性交は夜が白むまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 性技, 射精, Ｃ, Ｖ挿入", "童貞喪失", 勢力番号, GET_SPERM_ID("サキュバス"), "", "", "サキュバスの膣", "調教")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスと共に、とある少女の夢に舞い降りた
					PRINTFORML 夢魔の魅力で少女を魅了し、うぶだったその身体を女に育て上げていく
					PRINTFORML 初めはぎこちなかった少女も、最後には娼婦のように淫らに、二人と交わるようになっていた
					PRINTFORML 少女が体力の限界を迎えたあとも、%ANAME(対象)%はサキュバスと交わり続けた……
				ELSE
					PRINTFORML %ANAME(対象)%はサキュバスに、とある少女の夢へと連れて行かれた
					PRINTFORML 夢魔の魅力で魅了された少女は、%ANAME(対象)%を押し倒し、己の純潔を捧げる
					PRINTFORML %ANAME(対象)%の静止も聞かず娼婦顔向けの腰使いを見せる少女に、%ANAME(対象)%は耐えきれず種を放ってしまう
					PRINTFORML 淫らな宴は、少女が朝になって目覚めるまで続いた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 奉仕, 性交, 射精, レズ, Ｃ, Ｖ挿入", "童貞喪失", 勢力番号, 0, "", "", "少女の膣", "調教")
			CASE 3
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はサキュバスにしゃぶってもらっている
					PRINTFORML 夢魔以外には真似ることのできない極上の舌技に、%ANAME(対象)%は何度も種を放っている
```
