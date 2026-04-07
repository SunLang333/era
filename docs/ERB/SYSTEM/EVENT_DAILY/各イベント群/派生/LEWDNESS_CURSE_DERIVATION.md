# SYSTEM/EVENT_DAILY/各イベント群/派生/LEWDNESS_CURSE_DERIVATION.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/LEWDNESS_CURSE_DERIVATION.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTION_DISABLE, EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTION_DECISION, EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTION, EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTED_DISABLE, EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTED_DECISION, EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTED_SETTARGET, EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTED; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTION_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("LEWDNESS_CURSE")



;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTION_DECISION()

IF DVAR:淫紋_浸食中キャラID > 0 && ID_TO_CHARA(DVAR:淫紋_浸食中キャラID) == -1
	DVAR:淫紋_浸食中キャラID = 0
	RETURN 0
ELSEIF DVAR:淫紋_浸食中キャラID > 0
	RETURN 1
ENDIF

RETURN 0

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_LEWDNESS_CURSE_CORRUPTION()
#DIM 対象
#DIM あなたへの想い ;追加分
#DIM 霊夢 ;追加分
#DIM パチュリー ;追加分
#DIM ヘカーティア ;追加分
対象 = ID_TO_CHARA(DVAR:淫紋_浸食中キャラID)
;追加分
霊夢 = NAME_TO_CHARA("霊夢")
パチュリー = NAME_TO_CHARA("パチュリー")
ヘカーティア = NAME_TO_CHARA("ヘカーティア")
あなたへの想い = CFLAG:対象:好感度 + CFLAG:対象:依存度 + CFLAG:対象:従属度

IF CFLAG:対象:捕虜先 != 0
	PRINTFORMW 悪魔に淫紋を刻まれた%ANAME(対象)%は、牢獄の中で悶々と過ごしている……
	RETURN 1
ELSEIF CFLAG:対象:特殊状態 == 特殊状態_死亡
	PRINTFORMW %ANAME(対象)%が死亡してしまったので、悪魔は別のターゲットを探す事にした様だ
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_淫紋
	DVAR:淫紋_浸食中キャラID = 0
	DVAR:淫紋_浸食値 = 0
	DVAR:淫紋_純愛フラグ = 0
	RETURN 1
ELSEIF CFLAG:対象:特殊状態 == 特殊状態_放浪
	PRINTFORMW %ANAME(対象)%は放浪中、悪魔祓いに出会い淫紋を解呪してもらったようだ
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_淫紋
	DVAR:淫紋_浸食中キャラID = 0
	DVAR:淫紋_浸食値 = 0
	DVAR:淫紋_純愛フラグ = 0
	RETURN 1
ELSEIF CFLAG:対象:所属 != CFLAG:MASTER:所属
	PRINTFORMW 他国に移った%ANAME(対象)%は、悪魔祓いに淫紋を解呪してもらったようだ
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_淫紋
	DVAR:淫紋_浸食中キャラID = 0
	DVAR:淫紋_浸食値 = 0
	DVAR:淫紋_純愛フラグ = 0
	RETURN 1
ELSEIF !IS_FEMALE(対象)
	PRINTFORMW %ANAME(対象)%が女ではなくなったので、悪魔は別のターゲットを探す事にした様だ
	CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_淫紋
	DVAR:淫紋_浸食中キャラID = 0
	DVAR:淫紋_浸食値 = 0
	DVAR:淫紋_純愛フラグ = 0
	RETURN 1
ENDIF

;消去させるパターン
IF RAND:8 == 0
	PRINTFORML %ANAME(対象)%のところに旅の悪魔祓いがやってきた
	PRINTFORML 彼は一目で%ANAME(対象)%に憑いた悪魔の呪いを見抜き、解呪を申しでてきた
	PRINTFORML どうしようか……
	CALL ASK_YN("頼む", "疑わしい……")
	IF RESULT == 1
		PRINTFORMW いや、やはり何か疑わしい
		PRINTFORMW やめておくことにした……
		RETURN 1
	ELSE
		PRINTFORMW 多少疑いつつも、子宮の疼きを鎮められるのなら、と%ANAME(対象)%は彼に解呪を頼んだ
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		IF RAND:2 == 0
			PRINTFORML 解呪に成功した！
			PRINTFORML %ANAME(対象)%の身体から淫紋は跡形もなく消え去り、子宮の疼きも静まった
			PRINTFORMW 彼はもう二度と悪魔が現れることはないだろうと告げると去って行った
			CLEARBIT TALENT:対象:デイリー系, 素質_デイリー_淫紋
			DVAR:淫紋_浸食中キャラID = 0
			DVAR:淫紋_浸食値 = 0
			DVAR:淫紋_純愛フラグ = 0
			DVAR:淫紋_発生フラグ = -1
		ELSE
			PRINTFORML 「おら！おら！悪魔付きの淫乱め！こいつが欲しかったんだろうが！」
			PRINTFORMW 悪魔祓いを名乗った男は%ANAME(対象)%をベッドに組み伏せて、激しく犯している
			PRINTFORML %ANAME(対象)%は男に乱暴に犯され獣の様な喘ぎ声を上げながら全身を痙攣させ跳ねさせる
			PRINTFORMW 淫紋の影響で身体はすっかり屈服しており、抵抗どころか膣を締め付けちんぽを受け入れる
			PRINTFORML 「くっ、生意気に締め付けがやって！おら！イキ狂え！犯されるのを望んでたんだろ！」
			PRINTFORMW ゴスゴスッと膣奥を小突かれる度に視界が弾け、%ANAME(対象)%は涎と愛液を飛び散らしてヨガる
			PRINTFORML 「いくぞ！俺様のザーメンで浄化してやるよ！子宮でありがたく受け取れぇ！おらぁ！」
			PRINTFORML 一際深くねじ込まれたペニスから勢いよくザーメンが放たれると%ANAME(対象)%は大きく身を仰け反らせた
			PRINTFORML びゅるる♥どびゅるる♥と胎内に注がれる圧倒的な熱に半狂乱になって身悶え連続でアクメする
			PRINTFORMW …彼が射精を終えペニスを引き抜くと、雌穴からは大量の白濁液が下品な音と共にあふれ出た
			PRINTFORML 「…っはぁ！なかなか使い心地の良い穴じゃねーか……ん？なんだ、まだ欲しいのか？」
			PRINTFORMW %ANAME(対象)%は絶頂の余韻も冷めやらぬうちに再び腰を振って雌穴を割り開き次をおねだりする
			PRINTFORML 「へへっ、こりゃまだまだお祓いが必要だな！」
			PRINTFORMW 男は下卑た笑みを浮かべると%ANAME(対象)%の股を開かせ、再びいきり立った一物をねじ込んできた……
			CALL FUCK_RAPE(対象, GET_SPERM_ID("悪魔祓い"), "悪魔祓いの\@ RAND:2 ? ペニス # 唇\@", "悪魔祓い")
			PRINTFORML 
			PRINTFORML 男は散々%ANAME(対象)%を弄んだ後、さっさと立ち去った
			PRINTFORMW あとに残された%ANAME(対象)%は騙された屈辱よりもまた彼に犯されたい期待で頬を赤らめていた
		ENDIF
		RETURN 1
	ENDIF
ELSEIF DVAR:淫紋_浸食値 < 16
	;淫紋イベント純愛ルート
	IF DVAR:淫紋_純愛フラグ && あなたへの想い >= 10000 && DVAR:淫紋_あなた依存 >= 0 && !(対象 == MASTER) 
		PRINTFORM %ANAME(対象)%に刻まれた
		CALL COLOR_PRINT(@"淫紋", カラー_ピンク)
		PRINTFORML が妖しく輝き、彼女に強烈な情欲をもたらす……
		SELECTCASE RAND:5
			CASE 0
				PRINTFORMW 子宮の疼きは耐えがたく、気を抜くと秘所に指を這わせてしまいそうになっている……
			CASE 1
				PRINTFORMW 必死で平静を装っているも、足はガクガクと震え、今にも崩れ落ちそうになっている……
			CASE 2
				PRINTFORMW 息を荒げ頬で染めるその姿は、周囲の男たちに雌のフェロモンをまき散らしている……
			CASE 3
				PRINTFORMW 下腹部から全身に広がる熱に、頭が惚けてしまいまるで仕事に手がつけられなくなっている……
			CASE 4
				PRINTFORMW もじもじと内股をこすらせながら、思い切りこの性欲を解き放ちたい衝動に駆られている……
		ENDSELECT
		PRINTFORML 
		PRINTFORML だが%ANAME(対象)%は鋼の意思で、己の沸き起こる劣情に耐えて夜まで乗り切り、自分の部屋で思う存分自慰に耽った
		PRINTFORMW ……しかし、どれだけ慰めようと%ANAME(対象)%の情欲は一向に治まらず、ついに理性の限界が来ようとしていた
		PRINTFORMW 淫紋が与える耐え難い性欲に襲われる中で、彼女の頭に浮かんだのは%ANAME(MASTER)%の姿だった
		PRINTFORML %ANAME(MASTER)%に抱かれたらこの耐え難い衝動を止められると、半ば確信めいて考えた彼女は
		PRINTFORMW その火照った身体を震わせながら、%ANAME(MASTER)%の部屋に向かった…
		PRINTFORMW ･･･
		IF DVAR:淫紋_あなた依存 >= 1
			PRINTFORMW %ANAME(対象)%があられもない格好で再び%ANAME(MASTER)%の部屋を訪れた
			PRINTFORML 淫紋によって発情し、「自分を犯してくれ」と雌の顔で%ANAME(MASTER)%に詰め寄る…
		ELSE
			PRINTFORMW %ANAME(MASTER)%は、自らの部屋を訪ねてきた%ANAME(対象)%の異様な雰囲気を感じた
			PRINTFORML 一目で分かるほど発情し、雌の顔で%ANAME(MASTER)%を見つめてくる
			PRINTFORMW おそらくは自分があの夜、悪魔との契約を交わしたことによるものだろう
		ENDIF
		PRINTFORMW %ANAME(MASTER)%は……
		PRINTFORML
		;断ると新ルート終了
		CALL ASK_YN("彼女を抱く", "断る")
		IF RESULT == 1
			PRINTFORML %ANAME(MASTER)%は、売女の如き様子の%ANAME(対象)%を抱く気になれなかった
			PRINTFORMW %ANAME(MASTER)%に断られた%ANAME(対象)%は一人部屋に戻り、自らを慰めるしかなかった
			PRINTFORMW しかし淫紋による疼きは、どれだけ自分で慰めようと治まることはなかった……
			DVAR:淫紋_あなた依存 = -1
		ELSE
			PRINTFORMW 彼女がこうなったのは自分の責任だ
			PRINTFORML %ANAME(MASTER)%は責任を持って、彼女の情欲を受け止めることにした
			PRINTFORMW ･･･
			SELECTCASE RAND:12
				CASE 0
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%に犯されながら腰をくねらせ大きな嬌声を上げる
					PRINTFORMW 刻まれた淫紋が彼女に異常な快感を与え、いつも以上に乱れさせる
					PRINTFORML %ANAME(MASTER)%がペニスでポルチオをグリグリ攻めると、%ANAME(対象)%はたまらず甘い声で喘ぎ身体を跳ねさせる
					PRINTFORML %ANAME(対象)%は絶頂しながら目をハートにしながら%ANAME(MASTER)%を見つめて、大きく手を広げて誘う
					PRINTFORMW %ANAME(MASTER)%にぎゅぅっと抱きしめられながら子種を注がれ、%ANAME(対象)%は足をピンと伸ばしながら激しく絶頂した
				CASE 1
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%に背後から両腕を掴まれ、立ちバックの姿勢で激しく小突かれている
					PRINTFORMW 普段より乱暴なセックスにも%ANAME(対象)%は淫紋の作用により興奮し、一突き毎に悦びの声を上げてペニスを受け入れる
					PRINTFORML %ANAME(対象)%の反応に気を良くした%ANAME(MASTER)%は、更に激しく子宮内に響くようなストロークを繰り出し彼女を責める
					PRINTFORMW 精をねだるような膣の締め付けに我慢できなくなった%ANAME(MASTER)%が射精すると、%ANAME(対象)%は体を跳ね上げながら絶頂した
				CASE 2
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%に正常位で激しく犯されている
					PRINTFORMW %ANAME(MASTER)%が腰を振りペニスで膣内をなぞられる度、%ANAME(対象)%はたまらないといった表情で体をくねらせる
					PRINTFORML 淫紋により、いっそう淫らな表情と仕草で精をねだる%ANAME(対象)%
					PRINTFORML その乱れぶりに%ANAME(MASTER)%の興奮も一層昂ぶり、更に激しく腰を打ちつけ快楽を貪りあう
					PRINTFORMW やがて%ANAME(MASTER)%が低く唸り膣奥に射精すると、%ANAME(対象)%もまただらしなく涎を垂らしながら絶頂した
				CASE 3
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%に犯されながら艶めかしく体をくねらせている
					PRINTFORMW 淫紋によって敏感になった肉体は、いつも以上に過敏に快感を感じ、絶頂の波が%ANAME(対象)%を飲み込む
					PRINTFORML %ANAME(対象)%はその快楽の虜になり、すっかり惚けてしまっている
					PRINTFORML 普段の%ANAME(対象)%からは想像も出来ないような淫靡な表情で淫らな言葉を紡ぎ%ANAME(MASTER)%を求める
					PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%に与えられる快楽に陶酔しながら、犯されるままに犯され、雌の悦びを魂に刻み込んだ
				CASE 4
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%に犯されながら腰をくねらせ大きな嬌声を上げる
					PRINTFORMW 刻まれた淫紋が彼女に異常な快感を与え、いつも以上に乱れさせている
					PRINTFORML %ANAME(MASTER)%がペニスでポルチオをグリグリ攻めると、%ANAME(対象)%はたまらず甘い声で喘ぎ身体を跳ねさせる
					PRINTFORML %ANAME(対象)%は絶頂しながら目をハートにしながら%ANAME(MASTER)%を見つめて、大きく手を広げて誘う
					PRINTFORMW %ANAME(MASTER)%にぎゅぅっと抱きしめられながら子種を注がれ、%ANAME(対象)%は足をピンと伸ばしながら激しく絶頂した
				CASE 5
					PRINTFORML %ANAME(対象)%は%ANAME(MASTER)%の指使いで攻められると、すぐに虜になってしまった
					PRINTFORML ぼんやりと光る淫紋が、彼女に過剰なほどの快感を与え、雌として扱われる悦びを刻んでいる
					PRINTFORML 我慢できなくなった%ANAME(対象)%は服従のポーズになり、とろとろになった秘裂を割れ開いて%ANAME(MASTER)%におねだりする
					PRINTFORML %ANAME(MASTER)%は望みどおり肉棒を取り出すと、%ANAME(対象)%の視線は釘付けになり口から涎を垂らして挿入を待ち望んでいる
```
