# SYSTEM/SP_COUNTRY/TENTACLE/TENTACLE_TRAIN_MSG.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/TENTACLE/TENTACLE_TRAIN_MSG.ERB`

类型: .ERB

自动摘要: UI/print

前 200 行源码片段:

```text
﻿@TENTACLE_TRAIN_MSG(対象, 士官フラグ)
#DIM 対象
#DIM プレイ番号
#DIM 勢力番号
#DIM 士官フラグ


勢力番号 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_触手)

IF HAS_VAGINA(対象) && HAS_PENIS(対象)
	SELECTCASE RAND:100
		CASE IS < 10
			プレイ番号 = 0
		CASE IS < 50
			プレイ番号 = 1
		CASEELSE
			プレイ番号 = 2
	ENDSELECT
ELSEIF HAS_VAGINA(対象)
	プレイ番号 = 2
ELSEIF HAS_PENIS(対象)
	プレイ番号 = 1
ELSE
	RETURN
ENDIF

勢力番号 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_触手))



LOCALS = 寄生された\@ HAS_PENIS(対象) ? 女 # 男 \@
FOR LOCAL, 0, CHARANUM
	SIF COUNTRY_EVENT_ID:(CFLAG:LOCAL:所属) == SP_COUNTRY_ID:特殊勢力_触手 && !IS_SAMESEX(対象, LOCAL) && !IS_SP_CHARA(LOCAL) && !RAND:3
		LOCALS = %ANAME(LOCAL)%
NEXT

SELECTCASE プレイ番号
	;-------------------------ここからふたなり専用-------------------------
	CASE 0
		SELECTCASE RAND:3
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手に精液を搾り取られている
					PRINTFORML 触手に寄生され強化された肉体は、すさまじい量の白濁を吐き出す
					PRINTFORML 触手はそれだけでは飽き足らず、膣や尻穴を弄り、%ANAME(対象)%の射精量を強引に増やす
					PRINTFORML その快楽に、%ANAME(対象)%は身もだえしていた
					PRINTFORML ようやく解放された頃には、%ANAME(対象)%は腰が立たなくなっていた……
				ELSE
					PRINTFORML %ANAME(対象)%は触手に精液を搾り取られている
					PRINTFORML %PRONOUN(対象)%が限界を迎えようともお構いなしに、触手は白濁を搾り取っていく
					PRINTFORML 触手はそれだけでは飽き足らず、膣や尻穴を弄り、%ANAME(対象)%の射精量を強引に増やす
					PRINTFORML 限界を超えた射精の苦痛に、%ANAME(対象)%は身もだえしている
					PRINTFORML ようやく解放された頃には、%ANAME(対象)%は腰が立たなくなっていた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 射精, 精愛, Ｃ, Ｖ, Ａ, 触手, Ｖ性交, Ａ性交", "童貞喪失, 処女喪失, Ａ処女喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手に精液を搾り取られている
					PRINTFORML 搾られた白濁は細い管状の触手を通り、%ANAME(対象)%自身の膣へと注がれていく
					PRINTFORML その快楽に、%ANAME(対象)%は身悶えしている
					PRINTFORML ようやく解放された頃には、%ANAME(対象)%は腰が立たなくなっていた……
				ELSE
					PRINTFORML %ANAME(対象)%は触手に精液を搾り取られている
					PRINTFORML 搾られた白濁は細い管状の触手を通り、%ANAME(対象)%自身の膣へと注がれていく
					PRINTFORML 限界を超えた射精の苦痛に、%ANAME(対象)%は身悶えしている
					PRINTFORML ようやく解放された頃には、%ANAME(対象)%は腰が立たなくなっていた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 射精, 精愛, Ｃ, Ｖ, 触手, Ｖ性交", "処女喪失, 童貞喪失, 膣内射精", 勢力番号, GET_ID(対象), "触手", "触手", "触手", "強姦")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手に口や二穴を犯されている
					PRINTFORML さらに、ペニスにブラシ状の触手が纏わり付き、激しく扱き上げている
					PRINTFORML すさまじい快楽に、%ANAME(対象)%は狂ったような嬌声をあげている
					PRINTFORML %ANAME(対象)%は気絶するまで犯され続けた……
				ELSE
					PRINTFORML %ANAME(対象)%は触手に二穴を犯されている
					PRINTFORML さらに、ペニスにブラシ状の触手が纏わり付き、激しく扱き上げている
					PRINTFORML すさまじい快楽に、%ANAME(対象)%は絶頂を堪えきれない
					PRINTFORML %ANAME(対象)%は気絶するまで犯され続けた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 性交, 射精, 精愛, Ｃ, Ｖ, Ｂ, Ａ, Ｍ, 触手, Ｖ性交, Ａ性交", "処女喪失, 童貞喪失, キス喪失, Ａ処女喪失, 膣内射精, 腸内射精, 口内射精", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
		ENDSELECT
	;-------------------------ここから要ペニス-----------------------------
	CASE 1
		SIF HAS_VAGINA(対象)
			LOCALS:0 = 寄生された女
		SELECTCASE RAND:5
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手に精液を搾り取られている
					PRINTFORML 触手に寄生され強化された肉体は、すさまじい量の白濁を吐き出す
					PRINTFORML その快楽に、%ANAME(対象)%は身もだえしていた
					PRINTFORML ようやく解放された頃には、%ANAME(対象)%は腰が立たなくなっていた……
				ELSE
					PRINTFORML %ANAME(対象)%は触手に精液を搾り取られている
					PRINTFORML %PRONOUN(対象)%が限界を迎えようともお構いなしに、触手は白濁を搾り取っていく
					PRINTFORML 限界を超えた射精の苦痛に、%ANAME(対象)%は身もだえしている
					PRINTFORML ようやく解放された頃には、%ANAME(対象)%は腰が立たなくなっていた……
				ENDIF
				CALL FUCK_SP(対象, "欲望, 射精, Ｃ, 触手", "童貞喪失", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は捕らえた女を犯している
					PRINTFORML 泣き叫ぶ女を抑えつけながら、口やペニスから己に寄生した触手を移していく
					PRINTFORML そのうちに女は大人しく、従順になり始めた。寄生が成功したのだ
					PRINTFORML %ANAME(対象)%はさっそく、触手の繁栄のために女を使い始めた……
				ELSE
					PRINTFORML %ANAME(対象)%は%LOCALS:0%に押し倒され、犯されている
					PRINTFORML 彼女は口や秘部を通じて、体内に巣くう触手を移してくる
					PRINTFORML %ANAME(対象)%は抵抗しようとするが、女の腰使いはそれをいなし、%PRONOUN(対象)%を悶えさせる
					PRINTFORML 結局%PRONOUN(対象)%は、何度も女の膣内で果ててしまった……
				ENDIF
				CALL FUCK_SP(対象, "触手, 欲望, 性交, 性技, 奉仕, 射精, Ｃ, Ｖ挿入, Ａ挿入", "童貞喪失", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手に肉体改造を受けている
					PRINTFORML 体内に寄生した触手が%PRONOUN(対象)%の身体を内側から造り替えていく
					PRINTFORML 筋力・精力ともに増強され、自我も書き換えられていく
					PRINTFORML 改造の終わった%ANAME(対象)%は早速、自らを触手の繁栄のために提供し始めた……
				ELSE
					PRINTFORML %ANAME(対象)%は触手に肉体を改造されている
					PRINTFORML 体内に入り込んだ触手に、肉体を造り替えられていく
					PRINTFORML 筋力・精力の増強とともに、自我も彼らに従順なものに変えられる
					PRINTFORML 改造の終わった%ANAME(対象)%はすぐ、触手に捕らえられ、その精を搾取されていく……
				ENDIF
				CALL FUCK_SP(対象, "触手, 欲望, 射精, Ｃ", "童貞喪失", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 3
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は%LOCALS:0%と交わっている
					PRINTFORML 互いに口づけあい、交わることで、互いの体内に寄生する触手を交換しているのだ
					PRINTFORML 交換が進むにつれ、互いの腰使いも激しくなっていく
					PRINTFORML やがて%ANAME(対象)%は、%LOCALS:0%の膣内にたっぷりと精を放った……
				ELSE
					PRINTFORML %ANAME(対象)%は%LOCALS:0%に犯されている
					PRINTFORML 彼女は口や秘部を通じて、体内に巣くう触手を移してくる
					PRINTFORML %ANAME(対象)%は抵抗しようとするが、%LOCALS:0%の腰使いはそれをいなし、%PRONOUN(対象)%を悶えさせる
					PRINTFORML 結局%PRONOUN(対象)%は、何度も彼女の膣内で果ててしまった……
				ENDIF
				CALL FUCK_SP(対象, "触手, 欲望, 性技, 性交, 奉仕, 射精, Ｃ, Ｖ挿入, Ａ挿入", "童貞喪失", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 4
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手の手駒として、近くの村落を襲撃した
					PRINTFORML 母体になれそうな若い娘を見つけては、口づけ、犯し、自らに寄生する触手を移す
					PRINTFORML 触手の尖兵となり果て自我を失った%ANAME(対象)%に、良心の呵責などあるはずもない
					PRINTFORML 拠点に戻った%ANAME(対象)%は、捕らえた女達を犯し、自らの触手をさらに寄生させていった……
				ELSE
					PRINTFORML %ANAME(対象)%は触手の手駒として、近くの村落を襲撃させられた
					PRINTFORML 母体になれそうな若い娘を見つけては捕らえ、拠点に送っていく
					PRINTFORML 良心の呵責を覚えながらも、寄生されている%ANAME(対象)%は逆らうことができない
					PRINTFORML 拠点に戻った%ANAME(対象)%は、戦闘で減った触手の補充のため、精を提供させられた……
				ENDIF
				CALL FUCK_SP(対象, "触手, 欲望, 性交, 性技, 奉仕, 射精, Ｃ, Ｖ挿入, Ａ挿入", "童貞喪失", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
		ENDSELECT
	;-------------------------ここから要マンコ-----------------------------
	CASE 2
		SELECTCASE RAND:28
			CASE 0
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手に逆さづりにされ、自ら大股を開いている
					PRINTFORML 毒々しい色の触手が、剥き出しの秘部に音を勃てて出入りしている
					PRINTFORML 異形のものに犯されているというのに、彼らに従順になった%ANAME(対象)%はひどく悦んでいる
					PRINTFORML やがて触手が白濁色の粘液を注ぎ込むと、%ANAME(対象)%は声を上げてよがり狂った……
				ELSE
					PRINTFORML %ANAME(対象)%は触手に逆さづりにされ、足を開かされている
					PRINTFORML 毒々しい色の触手に、剥き出しの秘部を犯されていた
					PRINTFORML 異形のものに犯される恐怖に、%ANAME(対象)%はただ震えている
					PRINTFORML やがて触手が白濁色の粘液を注ぎ込むと、%ANAME(対象)%は声にならない悲鳴をあげた……
				ENDIF
				CALL FUCK_SP(対象, "触手, 欲望, 性交, 精愛, Ｖ, Ｖ性交", "処女喪失, 膣内射精", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 1
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%は触手に絡みつかれ、両穴を抉られている
					PRINTFORML 奥の奥を触手が小突くと、%ANAME(対象)%はえげつない、たまらなさげな声をあげてよがる
					PRINTFORML 二穴の最奥に白濁が注がれると、%ANAME(対象)%は髪を振り乱して絶頂した……
				ELSE
					PRINTFORML %ANAME(対象)%は触手に絡みつかれ、両穴を抉られている
					PRINTFORML 奥の奥を触手に小突かれ、嫌だと思いながらも快感を感じずにはいられない
					PRINTFORML 二穴の最奥に白濁が注がれると、%ANAME(対象)%は自らの意志と関わらず絶頂してしまった……
				ENDIF
				CALL FUCK_SP(対象, "触手, 欲望, 性交, 精愛, Ｖ, Ａ, Ｖ性交, Ａ性交", "処女喪失, 膣内射精, Ａ処女喪失, 腸内射精", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 2
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はブラシのような形状の触手に、全身を擦り上げられている
					PRINTFORML 性感帯を特に念入りに擦り上げられ、%ANAME(対象)%はだらしない喘ぎ声をあげる
					PRINTFORML 全身くまなく綺麗になった%ANAME(対象)%は、自ら脚を開き、行為の続きをねだった……
				ELSE
					PRINTFORML %ANAME(対象)%はブラシのような形状の触手に、全身を擦り上げられている
					PRINTFORML 唇を噛んで堪えようとしているが、性感帯を擦られると甘い声が漏れてしまう
					PRINTFORML 全身くまなく綺麗にされた後、%aname(対象)%は彼らの繁殖に「利用」された……
				ENDIF
				CALL FUCK_SP(対象, "触手, 欲望, Ｖ, Ａ, Ｂ, Ｃ, Ｍ", "", 勢力番号, GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
			CASE 3
				IF 士官フラグ
					PRINTFORML %ANAME(対象)%はゴーヤのような触手を両穴にねじ込まれている
					PRINTFORML %ANAME(対象)%の穴は悲鳴をあげているが、本人はたまらないと言わんばかりの嬌声をあげている
					PRINTFORML 濃厚な種がつけられ触手が引き抜かれると、%ANAME(対象)%の両穴は緩んで閉じなくなっていた……
				ELSE
					PRINTFORML %ANAME(対象)%はゴーヤのような触手を両穴にねじ込まれている
					PRINTFORML 両穴を拡張される激痛に、%ANAME(対象)%はただ悲鳴をあげている
					PRINTFORML 濃厚な種がつけられ触手が引き抜かれると、%ANAME(対象)%の両穴は緩んで閉じなくなっていた……
```
