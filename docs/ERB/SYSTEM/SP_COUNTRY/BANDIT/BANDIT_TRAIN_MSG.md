# SYSTEM/SP_COUNTRY/BANDIT/BANDIT_TRAIN_MSG.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/BANDIT/BANDIT_TRAIN_MSG.ERB`

类型: .ERB

自动摘要: functions: BANDIT_TRAIN_MSG; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;調教メッセージ
;-------------------------------------------------
@BANDIT_TRAIN_MSG(対象, 士官フラグ)
#DIM 対象
#DIM プレイ番号
#DIM 勢力番号
#DIM 士官フラグ


勢力番号 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_野盗)

IF HAS_VAGINA(対象) && HAS_PENIS(対象)
	SELECTCASE RAND:100
		CASE IS < 10
			プレイ番号 = 0
		CASEELSE
			プレイ番号 = 2
	ENDSELECT
ELSEIF HAS_VAGINA(対象)
	プレイ番号 = 2
ELSEIF HAS_PENIS(対象)
	プレイ番号 = 1
ELSE
	プレイ番号 = 3
ENDIF

SELECTCASE プレイ番号
	;-------------------------ここからふたなり専用-------------------------
	CASE 0
		SELECTCASE RAND:8
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は娼婦として娼館で働いている
					PRINTFORML 自ら春を売ることで、それを野盗達の軍資金にしようというのだ
					PRINTFORML 下着と言うにも無理がある、ほとんど透けたような衣装を着て、%PRONOUN(対象)%は客を待っている
					PRINTFORML そしてやって来た客に、口や%STR_BODY("胸：長", 対象)%、%STR_BODY("膣：処女確認：時間経過", 対象)%や肉棒でもって、たっぷりと奉仕をした……
					PRINTFORML 珍しいふたなりの娼婦に、客はずいぶん満足したようだ……
				ELSE
					PRINTFORML %ANAME(対象)%は娼婦として娼館で働かされている
					PRINTFORML 野盗達は捕らえた女に春を売らせ、それを資金としているのだ
					PRINTFORML 下着と言うにも無理がある、ほとんど透けたような衣装を着て、%PRONOUN(対象)%は客を待っている
					PRINTFORML そして現れた客に、口や%STR_BODY("胸：長", 対象)%、%STR_BODY("膣：処女確認：時間経過", 対象)%や肉棒でもって、たっぷりと奉仕をさせられた
					PRINTFORML 珍しいふたなりの娼婦に、客はずいぶん満足したようだ……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性技, 性交, 奉仕, 精愛, 射精, Ｖ, Ｂ, Ｃ, Ｍ, キス, 口淫, 売春, Ｖ性交, 売春", "処女喪失, キス喪失, 膣内射精, 口内射精", 勢力番号, GET_SPERM_ID("娼館の客"), @"娼館の客の\@ RAND:2 ? 唇 # ペニス \@", "娼館の客", "", "売春")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は野盗に輪姦されている
					PRINTFORML お前みたいなチンポ女は売り物にもならねぇなどと罵られ、犯され、%ANAME(対象)%は歓喜の声をあげる
					PRINTFORML 膣や尻穴、口内に種を植え付けられるたび、%ANAME(対象)%のペニスも精を吐き出していく
					PRINTFORML その浅ましい様を野盗たちは嘲笑い、%PRONOUN(対象)%をさらに激しく犯していった……
				ELSE
					PRINTFORML %ANAME(対象)%は野盗に輪姦されている
					PRINTFORML お前みたいなチンポ女は売り物にもならねぇなどと罵られ、犯され、%ANAME(対象)%は歯を食いしばる
					PRINTFORML %STR_BODY("膣", 対象)%や%STR_BODY("アナル", 対象)%、口内に種を植え付けられるたび、%ANAME(対象)%のペニスも精を吐き出してしまう
					PRINTFORML その浅ましい様を野盗たちは嘲笑い、%PRONOUN(対象)%をさらに激しく犯していった……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性技, 性交, 奉仕, 精愛, 射精, Ｖ, Ｂ, Ｃ, Ａ, Ｍ, キス, 口淫, 輪姦, Ｖ性交, Ａ性交", "処女喪失, キス喪失, 膣内射精, Ａ処女喪失, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("野盗"), @"野盗の\@ RAND:2 ? 唇 # ペニス \@", "野盗", "", "輪姦")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は見知らぬ男に抱かれている
					PRINTFORML 世にも珍しい肉棒の生えた女ということで、好事家に貸し出されたのだ
					PRINTFORML 好事家は%ANAME(対象)%を穿ちながら、%PRONOUN(対象)%のペニスを弄くり回し、何度も射精させる
					PRINTFORML 絶頂するたび、%ANAME(対象)%は歓喜の声をあげて悶え狂った……
				ELSE
					PRINTFORML %ANAME(対象)%は見知らぬ男に抱かれている
					PRINTFORML 世にも珍しい肉棒の生えた女ということで、好事家に貸し出されたのだ
					PRINTFORML 好事家は%ANAME(対象)%を穿ちながら、%PRONOUN(対象)%のペニスを弄くり回し、何度も射精させる
					PRINTFORML 何度も絶頂させられた%ANAME(対象)%に、抵抗するだけの体力など残っていなかった……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 性技, 奉仕, 精愛, 射精, Ｖ, Ｂ, Ｃ, Ｍ, Ａ, キス, 口淫, 売春, Ｖ性交, Ａ性交, 売春", "処女喪失, Ａ処女喪失, キス喪失,　膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("貴族"), @"貴族の\@ RAND:2 ? 唇 # ペニス \@", "貴族", "", "売春")
			CASE 3
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は見世物小屋で働いている
					PRINTFORML 世にも珍しい肉棒の生えた女ということで売られたのだ
					PRINTFORML %PRONOUN(対象)%はステージの上で、腕のように太いモノをもつという男に後ろから貫かれている
					PRINTFORML 自らモノを扱き、観客席に見せつけるように射精すると、観客からは歓声があがった……
				ELSE
					PRINTFORML %ANAME(対象)%は見世物小屋で働かされている
					PRINTFORML 世にも珍しい肉棒の生えた女ということで売られたのだ
					PRINTFORML %PRONOUN(対象)%はステージの上で、腕のように太いモノをもつという男に後ろから貫かれている
					PRINTFORML 貫かれる快感で射精してしまうと、観客からは歓声があがった……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 性技, 奉仕, 精愛, 射精, Ｖ拡張, Ｖ, Ｂ, Ｃ, Ｍ, キス, 口淫, 苦痛快楽, マゾ, 売春, Ｖ性交, 売春", "処女喪失, キス喪失, 膣内射精, 口内射精", 勢力番号, GET_SPERM_ID("野盗"), @"野盗の\@ RAND:2 ? 唇 # ペニス \@", "野盗", "", "売春")
			CASE 4
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は野盗とセックスしている
					PRINTFORML %STR_BODY("胸：愛撫", 対象)%を揉みしだかれながら後ろから突き上げられ、%ANAME(対象)%は快楽に悶えている
					PRINTFORML %PRONOUN(対象)%が自ら一物をガシガシと扱き上げ快楽を貪ると、野盗はその浅ましい様をげらげらと笑いたてる
					PRINTFORML 解放されるころには、%STR_BODY("膣：処女確認：時間経過", 対象)%からはどろどろと白いものが溢れていた……
				ELSE
					PRINTFORML %ANAME(対象)%は野盗とセックスしている
					PRINTFORML %STR_BODY("胸：愛撫", 対象)%を揉みしだかれながら後ろから突き上げられ、%ANAME(対象)%は感じまいと唇を噛みしめている
					PRINTFORML %PRONOUN(対象)%が突き上げられる刺激に射精してしまうと、野盗はその浅ましい様をげらげらと笑いたてる
					PRINTFORML 解放されるころには、%STR_BODY("膣：処女確認：時間経過", 対象)%からはどろどろと白いものが溢れていた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 奉仕, 精愛, 射精, Ｖ, Ｂ, Ｃ, Ｖ性交", "処女喪失, 膣内射精", 勢力番号, GET_SPERM_ID("野盗"), @"野盗の\@ RAND:2 ? 唇 # ペニス \@", "野盗", "", "強姦")
			CASE 5
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は野盗の資金稼ぎのため、街娼をしている
					PRINTFORML 声をかけてきた男と連れ立ち、宿に入った
					PRINTFORML 男は%ANAME(対象)%の股に生えたモノに驚いていたようだが、すぐにその%STR_BODY("身体", 対象)%に夢中になり、%STR_BODY("陰唇：処女確認：時間経過", 対象)%を貫く
					PRINTFORML たっぷりと楽しんだ後、%ANAME(対象)%は男と連絡先を交換して帰った……
				ELSE
					PRINTFORML %ANAME(対象)%は野盗の資金稼ぎのため、街娼をさせられている
					PRINTFORML 声をかけてきた男に、宿へと連れ込まれた
					PRINTFORML 男は%ANAME(対象)%の股に生えたモノに驚いていたようだが、すぐにその%STR_BODY("身体", 対象)%に夢中になり、%STR_BODY("陰唇：処女確認：時間経過", 対象)%を貫く
					PRINTFORML 「お楽しみ」が終わる頃には、%ANAME(対象)%は男にメロメロにされていた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 奉仕, 精愛, 射精, Ｖ, Ｂ, Ｃ, Ｍ, キス, 口淫, 売春, Ｖ性交, 売春", "キス喪失, 膣内射精, 処女喪失, 口内射精", 勢力番号, GET_SPERM_ID("行きずりの男"), @"行きずりの男の\@ RAND:2 ? 唇 # ペニス \@", "行きずりの男", "", "売春")
			CASE 6
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は怪しげな酒場でダンサーとして働いている
					PRINTFORML 面積などあってないきわどい衣装は激しい踊りの中で簡単にずれ、%ANAME(対象)%の%STR_BODY("身体", 対象)%を露わにする
					PRINTFORML "サービス"の一環として、%ANAME(対象)%が股座から伸びるモノを自ら扱いてみせると、客席からは卑猥なヤジが飛んだ
					PRINTFORML ダンスが終わる頃には、その%STR_BODY("陰唇", 対象)%は汗でない液体で濡れそぼっていた……
				ELSE
					PRINTFORML %ANAME(対象)%は怪しげな酒場でダンサーとして働いている
					PRINTFORML 面積などあってないきわどい衣装は激しい踊りの中で簡単にずれ、%ANAME(対象)%の%STR_BODY("身体", 対象)%を露わにする
					PRINTFORML 強い羞恥に襲われているはずだというのに、%ANAME(対象)%のモノは知らず知らずの内にいきりたっている
					PRINTFORML ダンスが終わる頃には、その%STR_BODY("陰唇", 対象)%は汗でない液体で濡れそぼっていた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 欲望, 露出, 露出, 露出, 売春", "", 勢力番号, GET_SPERM_ID("野盗"), @"野盗の\@ RAND:2 ? 唇 # ペニス \@", "野盗", "", "売春")
			CASE 7
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はオークションにかけられた
					PRINTFORML 野盗の資金稼ぎのため、自ら商品になることを志願したのだ
					PRINTFORML "出品"された女の中でも特に美しく、しかもふたなりである%ANAME(対象)%には高値が付けられた
					PRINTFORML 落札した男の腕に抱かれるとき、%ANAME(対象)%の%STR_BODY("陰唇", 対象)%は既にとろとろに濡れそぼっていた
					PRINTFORML %ANAME(対象)%は興奮した男に、一晩かけてたっぷりと躾けられた……
				ELSE
					PRINTFORML %ANAME(対象)%はオークションにかけられた
					PRINTFORML 野盗の資金稼ぎのため、無理矢理売られたのだ
					PRINTFORML "出品"された女の中でも特に美しく、しかもふたなりである%ANAME(対象)%には高値が付けられた
					PRINTFORML 落札した男のテクニックに、%ANAME(対象)%の%STR_BODY("陰唇", 対象)%は濡れそぼってしまう
					PRINTFORML %ANAME(対象)%は興奮した男に、一晩かけてたっぷりと躾けられた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性技, 性交, 奉仕, 精愛, 射精, Ｖ, Ｂ, Ｃ, Ａ, Ｍ, キス, 口淫, 売春, Ｖ性交, Ａ性交, 売春", "処女喪失, Ａ処女喪失, キス喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("貴族"), @"貴族の\@ RAND:2 ? 唇 # ペニス \@", "貴族", "", "売春")
		ENDSELECT
	;-------------------------ここから要ペニス-------------------------
	CASE 1
		SELECTCASE RAND:1
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は野盗の兵士として、近くの集落を襲撃した
					PRINTFORML 彼らが好みそうな美しい娘を見つけては、さらってアジトへと連行する
					PRINTFORML まずは奴隷としての躾が必要だと、%ANAME(対象)%はさらった娘を野盗とともに輪姦した……
				ELSE
					PRINTFORML %ANAME(対象)%は野盗の兵士として、近くの集落を襲撃させられた
					PRINTFORML 彼らが好みそうな美しい娘を見つけては、さらってアジトへと連行する
					PRINTFORML 良心の呵責に襲われる%ANAME(対象)%だが、それだけでは済まなかった
					PRINTFORML 野盗は%ANAME(対象)%に、さらった娘を陵辱するよう命じたのだ……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性技, 性交, 射精, Ｃ, Ｖ挿入, Ａ挿入", "童貞喪失", 勢力番号, GET_SPERM_ID("野盗"), @"野盗の\@ RAND:2 ? 唇 # ペニス \@", "野盗", "村娘の膣", "輪姦")
		ENDSELECT
	;-------------------------ここから要Ｖ-------------------------
	CASE 2
		SELECTCASE RAND:28
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は娼婦として娼館で働いている
					PRINTFORML 自ら春を売ることで、それを野盗達の軍資金にしようというのだ
					PRINTFORML 下着と言うにも無理がある、ほとんど透けたような衣装を着て、%PRONOUN(対象)%は客を待っている
					PRINTFORML そしてやって来た客に、口や乳房、膣穴でもって、たっぷりと奉仕をした……
					PRINTFORML %ANAME(対象)%が彼らのアジトに戻ると、%PRONOUN(対象)%は稼いだ金を野盗に全て献上した
				ELSE
					PRINTFORML %ANAME(対象)%は娼婦として娼館で働かされている
					PRINTFORML 野盗達は捕らえた女に春を売らせ、それを資金としているのだ
					PRINTFORML 下着と言うにも無理がある、ほとんど透けたような衣装を着て、%PRONOUN(対象)%は客を待っている
					PRINTFORML そして現れた客に、口や乳房、膣穴でもって、たっぷりと奉仕をさせられた
					PRINTFORML %ANAME(対象)%が彼らのアジトに戻ると、彼らは稼いだ金を全て取り上げた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性技, 性交, 奉仕, 精愛, Ｖ, Ｂ, Ｃ, 口淫, 売春, Ｖ性交, 売春", "処女喪失, キス喪失, 膣内射精, 口内射精", 勢力番号, GET_SPERM_ID("娼館の客"), @"娼館の客の\@ RAND:2 ? 唇 # ペニス \@", "娼館の客", "", "売春")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は野盗が関わる怪しげな店で給仕をしている
					PRINTFORML 隠すべきところをろくに隠さないような衣装は客の興奮を煽る
					PRINTFORML 客は%ANAME(対象)%の身体に手を伸ばしては、乳房や秘部を愛撫する
					PRINTFORML その後、%ANAME(対象)%は酔っ払った客と便所へ連れ立ち、たっぷりと躾けてもらった……
				ELSE
					PRINTFORML %ANAME(対象)%は野盗が関わる怪しげな店で給仕をしている
					PRINTFORML 隠すべきところをろくに隠さないような衣装と、それを恥じる態度が、客の興奮を煽る
					PRINTFORML 客は%ANAME(対象)%の身体に手を伸ばしては、乳房や秘部を愛撫する
					PRINTFORML その後、%ANAME(対象)%は酔っ払った客に便所に連れ込まれ、たっぷりと躾けられた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 奉仕, 精愛, Ｖ, Ｂ, Ｃ, 口淫, 売春, Ｖ性交, 売春", "処女喪失, キス喪失, 膣内射精, 口内射精", 勢力番号, GET_SPERM_ID("ごろつき"), @"ごろつきの\@ RAND:2 ? 唇 # ペニス \@", "ごろつき", "", "売春")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は野盗に輪姦してもらっている
					PRINTFORML 床には注射器やらなにやらが散乱し、%ANAME(対象)%はへらへら笑っている
					PRINTFORML もっと薬が欲しけりゃチンポに奉仕しろよと言い、野盗は%PRONOUN(対象)%の目の前に突き出す
					PRINTFORML 薬の魔力などなくとも結果は同じだったろうが、ともかく%PRONOUN(対象)%は一も二もなくソレを咥え込んだ
					PRINTFORML じゅぼ、ぐぼと音を立てて口淫する%PRONOUN(対象)%を、淫乱だ雌犬だと男達は笑いたてる
					PRINTFORML そして%ANAME(対象)%の身体に群がり、何度も何度も犯していった……
				ELSE
					PRINTFORML %ANAME(対象)%は野盗に輪姦されている
					PRINTFORML 床には注射器やらなにやらが散乱し、%ANAME(対象)%はへらへら笑っている
					PRINTFORML もっと薬が欲しけりゃチンポに奉仕しろよと言い、野盗は%PRONOUN(対象)%の目の前に突き出す
					PRINTFORML 薬の魔力の前に屈した%PRONOUN(対象)%は、一も二もなくソレを咥え込んだ
```
