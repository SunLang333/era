# SYSTEM/SP_COUNTRY/GAIRAI/GAIRAI_TRAIN_MSG.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/GAIRAI/GAIRAI_TRAIN_MSG.ERB`

类型: .ERB

自动摘要: UI/print

前 200 行源码片段:

```text
﻿@GAIRAI_TRAIN_MSG(対象, 士官フラグ)
#DIM 対象
#DIM プレイ番号
#DIM 勢力番号
#DIM 士官フラグ

勢力番号 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_外来人)

IF HAS_VAGINA(対象) && HAS_PENIS(対象)
	SELECTCASE RAND:100
		CASE IS < 10
			プレイ番号 = 0
		CASE IS < 20
			プレイ番号 = 1
		CASEELSE
			プレイ番号 = 2
	ENDSELECT
ELSEIF HAS_VAGINA(対象)
	SELECTCASE RAND:100
		CASE IS < 10
			プレイ番号 = 3
		CASEELSE
			プレイ番号 = 2
	ENDSELECT
ELSEIF HAS_PENIS(対象)
	プレイ番号 = RAND_POCKET(4, 0, 2)
ELSE
	プレイ番号 = 3
ENDIF

SELECTCASE プレイ番号
	;-------------------------ここからふたなり専用-------------------------
	CASE 0
		SELECTCASE RAND:4
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は自ら生殖の実験に協力している
					PRINTFORML %ANAME(対象)%のペニスにはオナホールが取り付けられ、容赦なく精液を搾り取っていく
					PRINTFORML 吐き出された白濁は細い管を通り、他ならぬ%ANAME(対象)%自身の%STR_BODY("膣：感度", 対象)%へと注がれていく
					PRINTFORML 孕ませ、孕ませられる快感に、%ANAME(対象)%は身悶えしている……
				ELSE
					PRINTFORML %ANAME(対象)%は生殖の実験台にされている
					PRINTFORML %ANAME(対象)%のペニスにはオナホールが取り付けられ、容赦なく精液を搾り取っていく
					PRINTFORML 吐き出された白濁は細い管を通り、他ならぬ%ANAME(対象)%自身の%STR_BODY("膣：感度", 対象)%へと注がれていく
					PRINTFORML 孕ませ、孕ませられる快感に、%ANAME(対象)%は身悶えしている……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 精愛, 射精, Ｃ, Ｖ, Ｖ性交", "膣内射精, 処女喪失", 勢力番号, GET_ID(対象), "", "実験器具", "", "強姦")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は肉体感度のテストに協力している
					PRINTFORML %STR_BODY("乳首：欲情", 対象)%にはニプルキャップ、両穴にはバイブがねじ込まれ、ペニスにオナホールの取り付けられた状態で拘束されている
					PRINTFORML 最強強度で動くそれぞれの器具は、容赦なく%ANAME(対象)%の身体を弄び、%PRONOUN(対象)%を絶頂へと導いていく……
					PRINTFORML 解放されるころには、%ANAME(対象)%は気絶してしまっていた
				ELSE
					PRINTFORML %ANAME(対象)%は肉体感度のテストにかけられている
					PRINTFORML %STR_BODY("乳首：欲情", 対象)%にはニプルキャップ、両穴にはバイブがねじ込まれ、ペニスにオナホールの取り付けられた状態で拘束されている
					PRINTFORML 最強強度で動くそれぞれの器具は、容赦なく%ANAME(対象)%の身体を弄び、%PRONOUN(対象)%を絶頂へと導いていく……
					PRINTFORML 解放されるころには、%ANAME(対象)%は気絶してしまっていた
				ENDIF
				CALL FUCK_SP(対象, "欲望, 欲望, 射精, Ｃ, Ｖ, Ｂ, Ａ, Ｍ, 緊縛, マゾ", "処女喪失, Ａ処女喪失", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "バイブ", "", "強姦")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は新型ヘッドギアデバイスのテストに協力している
					PRINTFORML ヘッドギアから流れる電流が%ANAME(対象)%の肉体を操り、秘部や肉棒を容赦なく弄らせる
					PRINTFORML 自慰でありながら自慰でない全く新しい感覚に、%ANAME(対象)%は何度も絶頂し射精している
				ELSE
					PRINTFORML %ANAME(対象)%は新型ヘッドギアデバイスの実験台にされている
					PRINTFORML ヘッドギアから流れる電流が%ANAME(対象)%の肉体を操り、秘部や肉棒を容赦なく弄らせる
					PRINTFORML 自慰でありながら自慰でない得体の知れない感覚に、%ANAME(対象)%は何度も絶頂し射精してしまう
				ENDIF
				PRINTFORML やがて%ANAME(対象)%は解放されたが、後遺症なのか、いつまでもその身体を弄り続けていた……
				CALL FUCK_SP(対象, "欲望, 自慰, 自慰, 射精, Ｃ, Ｖ, Ｂ", "", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
			CASE 3
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は新型生物のテストに協力している
					PRINTFORML 触手生物の吐き出す粘液に肌を、そして体内をも汚されながら、%ANAME(対象)%は目をハートにしてそれにしゃぶりつく
					PRINTFORML ブラシ状の触手にペニスを扱かれ、%ANAME(対象)%はみっともなく射精する……
				ELSE
					PRINTFORML %ANAME(対象)%は新型生物の実験台にされている
					PRINTFORML 触手生物の吐き出す粘液に肌を、そして体内をも汚され、おぞましさに%ANAME(対象)%は震えている
					PRINTFORML だというのに、ブラシ状の触手にペニスを扱かれ、%ANAME(対象)%はみっともなく射精する……
				ENDIF
				PRINTFORML 解放されるころには、%ANAME(対象)%は爪先から頭頂までどろどろになっていた
				CALL FUCK_SP(対象, "欲望, 精愛, 奉仕, 性技, 性交, 射精, Ｖ, Ａ, Ｂ, Ｃ, Ｍ, 触手, 口淫, Ｖ性交, Ａ性交", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "", "強姦")

		ENDSELECT
	;-------------------------ここから要ペニス-------------------------
	CASE 1
		SELECTCASE RAND:2
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は自ら生殖機能のテストに協力している
					PRINTFORML 取り付けられたオナホールが、%ANAME(対象)%から容赦なく精液を搾り取る
					PRINTFORML 吐き出された白濁は細い管を通り、「実験動物」と書かれた瓶に溜められていく
					PRINTFORML 限界を超えた射精に、%ANAME(対象)%は身悶えしている……
				ELSE
					PRINTFORML %ANAME(対象)%は生殖機能のテストにかけられている
					PRINTFORML 取り付けられたオナホールが、%ANAME(対象)%から容赦なく精液を搾り取る
					PRINTFORML 吐き出された白濁は細い管を通り、「実験動物」と書かれた瓶に溜められていく
					PRINTFORML 限界を超えた射精に、%ANAME(対象)%は身悶えしている……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 射精, Ｃ", "", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は自ら生殖の実験に協力している
					PRINTFORML 「実験動物」と烙印の押された、縛られた少女に、%ANAME(対象)%は腰を打ちつけている
					PRINTFORML 少女の膣の締まりに、%ANAME(対象)%はへこへこと腰を振り、何度も種を植え付けていく
					PRINTFORML 優秀な「実験動物」と化した%ANAME(対象)%は、限界を超えて射精し続ける……
				ELSE
					PRINTFORML %ANAME(対象)%は生殖機能のテストにかけられている
					PRINTFORML 「実験動物」と烙印の押された少女と、%ANAME(対象)%は交わらされている
					PRINTFORML 抵抗しようとするのだが、少女の巧みな腰使いに結局は何度も射精してしまう
					PRINTFORML 優秀な「実験動物」である少女に、%ANAME(対象)%は何度も搾り取られた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 射精, Ｃ, 性交, Ｖ挿入, Ａ挿入", "童貞喪失", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "少女", "強姦")

		ENDSELECT
	;-------------------------ここから要Ｖ-------------------------
	CASE 2
		SELECTCASE RAND:19
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は自ら生殖機能のテストに協力している
					PRINTFORML %STR_BODY("膣", 対象)%に差し込まれた管から、何かの精液が子宮に直接注がれていく
					PRINTFORML 性交という行為すらなしに孕まされる異常な経験に、%ANAME(対象)%は興奮を隠しきれない
					PRINTFORML 注入が終わるころには、%ANAME(対象)%の子宮は精液で妊婦のように膨らんでいた……
				ELSE
					PRINTFORML %ANAME(対象)%は生殖機能のテストにかけられている
					PRINTFORML %STR_BODY("膣", 対象)%に差し込まれた管から、何かの精液が子宮に直接注がれていく
					PRINTFORML 性交という行為すらなしに孕まされる恐怖に、%ANAME(対象)%は青ざめている
					PRINTFORML 注入が終わる頃には、%ANAME(対象)%の子宮は精液で妊婦のように膨らんでいた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 精愛, Ｖ", "膣内射精, 処女喪失", 勢力番号, GET_SPERM_ID("不明"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "外来人", "", "強姦")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は自ら生殖の実験に協力している
					PRINTFORML 「実験動物」と烙印の押された、縛られた男の上で、%ANAME(対象)%は腰を振っている
					PRINTFORML 男のモノのよさに%ANAME(対象)%の腰はくねり、何度も精を搾り取っていく
					PRINTFORML 優秀な「実験動物」と化した%ANAME(対象)%は、限界を超えて性交し続ける……
				ELSE
					PRINTFORML %ANAME(対象)%は生殖機能のテストにかけられている
					PRINTFORML 「実験動物」と烙印の押された男にのしかかられ、%STR_BODY("膣", 対象)%を犯されている
					PRINTFORML 抵抗しようとするも、男のモノのよさに、結局は何度も絶頂してしまう
					PRINTFORML 優秀な「実験動物」である男の精を、%ANAME(対象)%は何度も注がれてしまった……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 精愛, 性交, Ｖ, Ｖ性交", "膣内射精, 処女喪失", 勢力番号, GET_SPERM_ID("「実験動物」"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "「実験動物」", "", "強姦")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は自ら生殖の実験に協力している
					PRINTFORML 散々犯されたあとの%ANAME(対象)%に、プラグつきの貞操帯が取り付けられる
					PRINTFORML 子宮内に精液を留めておくことで、受精確率を引き上げられるか調査するというのだ
					PRINTFORML 逃げ場などなく妊娠するしかないことを悟った%ANAME(対象)%は、恍惚に震えている……
				ELSE
					PRINTFORML %ANAME(対象)%は生殖の実験にかけられている
					PRINTFORML 散々犯されたあとの%ANAME(対象)%に、プラグつきの貞操帯が取り付けられる
					PRINTFORML 子宮内に精液を留めておくことで、受精確率を引き上げられるか調査するというのだ
					PRINTFORML 逃げ場などなく妊娠するしかないことを悟った%ANAME(対象)%は、恐怖に震えている……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 精愛, 性交, Ｖ, 輪姦, Ｖ性交", "膣内射精, 処女喪失", 勢力番号, GET_SPERM_ID("「実験動物」"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "「実験動物」", "", "強姦")
			CASE 3
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は肉体感度のテストに協力している
					PRINTFORML %STR_BODY("乳首：欲情", 対象)%と%STR_BODY("クリ：感度", 対象)%にはキャップ、両穴にはバイブがねじ込まれた状態で拘束されている
					PRINTFORML 最強強度で動くそれぞれの器具は、容赦なく%ANAME(対象)%の身体を弄び、%PRONOUN(対象)%を絶頂へと導いていく……
					PRINTFORML 解放されるころには、%ANAME(対象)%は気絶してしまっていた
				ELSE
					PRINTFORML %ANAME(対象)%は肉体感度のテストにかけられている
					PRINTFORML %STR_BODY("乳首：欲情", 対象)%と%STR_BODY("クリ：感度", 対象)%にはキャップ、両穴にはバイブがねじ込まれた状態で拘束されている
					PRINTFORML 最強強度で動くそれぞれの器具は、容赦なく%ANAME(対象)%の身体を弄び、%PRONOUN(対象)%を絶頂へと導いていく……
					PRINTFORML 解放されるころには、%ANAME(対象)%は気絶してしまっていた
				ENDIF
				CALL FUCK_SP(対象, "欲望, 欲望, Ｃ, Ｖ, Ｂ, Ａ, Ｍ, 緊縛, マゾ", "処女喪失, Ａ処女喪失", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "バイブ", "", "強姦")
			CASE 4
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は体力のテストに協力している
					PRINTFORML 「実験動物」の烙印を押された大量の男達に、代わる代わる、休む暇も無く犯されている
					PRINTFORML 初めは悦びの声をあげていた%ANAME(対象)%も、それが三日三晩絶え間なくともなれば、もはや声をあげる元気もない
					PRINTFORML それでもなお実験は続き、丸一週間を経てようやく終了した……
				ELSE
					PRINTFORML %ANAME(対象)%は体力のテストにかけられている
					PRINTFORML 「実験動物」の烙印を押された大量の男達に、代わる代わる、休む暇も無く犯されている
					PRINTFORML 初めは抵抗していた%ANAME(対象)%も、それが三日三晩絶え間なくともなれば、もはやただの人形と化している
					PRINTFORML それでもなお実験は続き、丸一週間を経てようやく終了した……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 精愛, Ｃ, Ｖ, Ｂ, Ａ, Ｍ, 輪姦, 輪姦, Ｖ性交, Ａ性交", "膣内射精, 膣内射精, 膣内射精, キス喪失, 処女喪失, Ａ処女喪失, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("「実験動物」"), @"「実験動物」の\@ RAND:2 ? 唇 # ペニス \@", "「実験動物」", "", "輪姦")
			CASE 5
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は苦痛耐性のテストに協力している
					PRINTFORML 大人の腕ほどもある巨大な張り型が、%ANAME(対象)%の両穴にねじ込まれている
					PRINTFORML そのあまりの圧迫感と痛みに、%ANAME(対象)%は腰をくねらせ快楽を覚えている……
					PRINTFORML テストが終わるころには、%ANAME(対象)%は体力の限界を迎えていた
				ELSE
					PRINTFORML %ANAME(対象)%は苦痛耐性のテストにかけられている
					PRINTFORML 大人の腕ほどもある巨大な張り型が、%ANAME(対象)%の両穴にねじ込まれている
					PRINTFORML そのあまりの圧迫感と痛みに、%ANAME(対象)%は涙をこぼし悲鳴をあげている……
					PRINTFORML テストが終わるころには、%ANAME(対象)%は体力の限界を迎えていた
				ENDIF
				CALL FUCK_SP(対象, "欲望, Ｖ, Ａ, Ｖ拡張, Ａ拡張, 緊縛, 苦痛快楽, マゾ", "処女喪失, Ａ処女喪失", 勢力番号, GET_SPERM_ID("外来人"), @"外来人の\@ RAND:2 ? 唇 # ペニス \@", "バイブ", "", "強姦")
			CASE 6
				IF 士官フラグ
```
