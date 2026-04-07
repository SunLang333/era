# SYSTEM/EVENT_DAILY/各イベント群/RECEPTION_貴族への接待.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/RECEPTION_貴族への接待.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_RECEPTION_RATE, EVENT_DAILY_RECEPTION_DECISION, EVENT_DAILY_RECEPTION_GENRE, EVENT_DAILY_RECEPTION, SELECT_CHARA_LIST_SHOW_LOGIC_RECEPTION; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_RECEPTION_RATE()
RETURN 20

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_RECEPTION_DECISION()
;主人公が君主ではない場合
SIF GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == MASTER
	RETURN 0

RETURN DAY >= 5

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_RECEPTION_GENRE()
RETURN デイリー_ジャンル_エロ


@EVENT_DAILY_RECEPTION()
#DIM 対象
#DIM 兵数

IF DVAR:接待_発生フラグ == 0
	PRINTFORMW %ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%から呼び出しを受けた
	PRINTFORMW %ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%の元へ行くと、苦い表情でこんな話をされた
	PRINTFORMW 何でも近々とある貴族を接待することになったが、その貴族というのは女好きで有名な男だ
	PRINTFORMW 当然、そっちの接待も求められるだろうが、無下に断ることもできない相手だ
	PRINTFORMW だから他の者との交流が多い%ANAME(MASTER)%に接待させるのに適任な者を選んでほしい、と
	PRINTFORMW こんな接待の相手を自らの一存で選ばなければならないとは頭が痛い話だ
	PRINTFORMW しかし%ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%も同じだろう
	PRINTFORMW %ANAME(MASTER)%は複雑な表情でリストを眺めた……
ELSEIF GETBIT(TALENT:MASTER:デイリー系, 素質_デイリー_貴族の愛人)
	PRINTFORMW あの方が再び訪れるらしい
	PRINTFORMW また楽しんで頂くために、しっかりと接待の準備をしなくては
	PRINTFORMW %ANAME(MASTER)%は誰に任せようかとリストを眺めた……
ELSEIF DVAR:接待_発生フラグ == 1
	PRINTFORMW 例の貴族が再び訪れるらしい
	PRINTFORMW どうやら前回の接待がことのほか好評だったようだ
	PRINTFORMW 正直もう関わりたくはないのだが、やはり接待相手を選ぶ様に言われた
	PRINTFORMW さて、誰を選ぶべきか……
ELSEIF DVAR:接待_発生フラグ == 2
	PRINTFORMW 例の貴族が再び訪れるらしい
	PRINTFORMW 今回こそはちゃんともてなしてくれよ、と釘を刺されたようだ
	PRINTFORMW 正直もう関わりたくはないのだが、やはり接待相手を選ぶ様に言われた
	PRINTFORMW さて、誰を選ぶべきか……
ENDIF
CALL SINGLE_DRAWLINE
CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("RECEPTION", "NONE")

対象 = RESULT

IF  対象 == -1
	IF GETBIT(TALENT:MASTER:デイリー系, 素質_デイリー_貴族の愛人)
		PRINTFORMW 今はとても忙しい時期だ、将を使っての接待は見送ってもらうしかない
		PRINTFORMW %ANAME(MASTER)%は彼に今回は通常の接待で許してほしいと伝えた
	ELSE
		PRINTFORMW やはりそんなことは出来ないと告げた
		PRINTFORMW %ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%もそれに頷き、今回は通常の接待だけで済ませることにした
	ENDIF
	PRINTFORML
	PRINTFORMW 貴族は接待の内容が不満だったようだ
	PRINTFORM ある事ない事を言いふらされ、
	CALL COLOR_PRINT(@"%ANAME(GET_COUNTRY_BOSS(CFLAG:MASTER:所属))%の評判を下げられました", カラー_注意)
	PRINTFORMW
	FOR LOCAL, 1, MAX_COUNTRY
		SIF IS_COUNTRY(LOCAL)
			CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -(50 + ((DVAR:接待_連続で断った回数) * 25)), 50 + ((DVAR:接待_連続で断った回数) * 25))
	NEXT
	;評判を下げる処理
	DVAR:接待_発生フラグ = 2
	DVAR:接待_連続で断った回数 += 1
	RETURN 1
ELSEIF 対象 == MASTER
	IF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の愛人)
		PRINTFORMW もちろん%ANAME(対象)%自身がやることにした
		PRINTFORMW あの方にまた可愛がってもらえると思うだけで体の奥が熱くなるのを感じた
	ELSEIF GETBIT(TALENT:MASTER:デイリー系, 素質_デイリー_貴族の虜)
		PRINTFORMW 仕方ない、また自分がやることにしよう
		PRINTFORMW %ANAME(対象)%は自分の身体の奥が熱くなるのに気付かなかった
	ELSEIF GETBIT(TALENT:MASTER:淫乱系, 素質_淫乱_精液便女)　|| GETBIT(TALENT:MASTER:淫乱系, 素質_淫乱_淫乱)
		PRINTFORMW そういう仕事ならば自分がやることしよう
		PRINTFORMW %ANAME(対象)%は僅かに頬を緩ませながらそう答えた
	ELSE
		PRINTFORMW 他の子にこんなことはさせられない
		PRINTFORMW %ANAME(対象)%は意を決して自ら接待を行うことにした
	ENDIF
ELSE
	PRINTFORMW 一番の適任は、彼女だろう
	PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%を呼びだすと接待の仕事を伝えた
	IF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の愛人)
		PRINTFORMW 彼女は積極的に仕事を引き受けると、いそいそと準備を始めた
	ELSEIF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の虜)
		PRINTFORMW 彼女はやや頬を染めながら、仕方なさそうに仕事を引き受けた
	ELSEIF GETBIT(TALENT:対象:淫乱系, 素質_淫乱_精液便女)　|| GETBIT(TALENT:対象:淫乱系, 素質_淫乱_淫乱)
		PRINTFORMW 彼女は命令を聞くと嫌な表情一つ見せずに二つ返事で引き受けた
	ELSE
		PRINTFORMW 彼女は命令を聞くと嫌そうな表情を見せたが、渋々と引き受けた
	ENDIF
ENDIF
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
PRINTFORMW 貴族がやってきた
IF GETBIT(TALENT:MASTER:デイリー系, 素質_デイリー_貴族の愛人)
	PRINTFORML 彼を見るなり%ANAME(MASTER)%は頬を染め、恋人が甘える様にすり寄る
	PRINTFORML ようこそいらっしゃいました、また貴方に楽しんで貰える様に準備しました
	PRINTFORMW %ANAME(MASTER)%は尻を撫でられながら、彼を案内した
ELSEIF GETBIT(TALENT:MASTER:デイリー系, 素質_デイリー_貴族の虜)
	PRINTFORML 相変わらずの風貌の男だが、%ANAME(MASTER)%はもはや不快感もなかった
	PRINTFORMW 微かに熱のこもった視線を彼に送りながら、%ANAME(MASTER)%は男を案内した
ELSEIF DVAR:接待_発生フラグ == 0
	PRINTFORML 見るからに裕福そうに丸々と太り脂ぎった男だ
	PRINTFORMW 一件柔和な笑みを浮かべているが、細めた目の奥からねっとりとした視線が覗いているのを感じた
ELSE
	PRINTFORML やはり何度見ても好きになれそうにない男だ
	PRINTFORMW しかし仕事だと割り切り、男を案内した
ENDIF
IF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の愛人)
	PRINTFORML 
	PRINTFORML 今日もたっぷりと可愛がってくださいね
	PRINTFORML 男の身体に自らの身体を擦り付けながら、%ANAME(対象)%は熱い吐息を漏らして甘える
	PRINTFORMW 早速濃厚な口付けを交わしながら、二人は用意された部屋へと入っていった
ELSEIF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の虜)
	PRINTFORML 
	PRINTFORML ねっとりとした目つきで体中を視姦され、%ANAME(対象)%は思わず身震いする
	PRINTFORML その表情には微かに嫌悪の色があるものの、それ以上に期待の色が勝っているようだ
	PRINTFORMW %ANAME(対象)%は男に体を弄られながらも抵抗せずに、彼と共に用意された部屋へと入っていった
ELSEIF 対象 == MASTER
	PRINTFORML 
	PRINTFORML 本日は私がお相手させていただきます、よろしくお願いします
	PRINTFORML %ANAME(対象)%が深々と頭を下げ挨拶すると、男は豚の鳴き声のような興奮した声を上げた
	PRINTFORMW ねっとりと絡みつくような視線を投げられ、肩に手を回されながら用意された部屋へと連れ込まれた
ELSE
	PRINTFORML 
	PRINTFORML %ANAME(対象)%を紹介すると、男は豚の鳴き声のような興奮した声を上げた
	PRINTFORML もはや%ANAME(MASTER)%の事など邪魔だと言わんばかりに押しのけると
	PRINTFORMW 無遠慮に%ANAME(対象)%の腰に手を回し、用意された部屋へと入っていった
ENDIF
PRINTFORML
PRINTFORMW
SELECTCASE RAND:43
CASE 0
	PRINTFORMW 男の巨大なペニスを挿入され、%ANAME(対象)%の膣ははち切れんばかりになっている
	PRINTFORMW ぐりぐりと刺激される%ANAME(対象)%の子宮は、その圧倒的な存在感と熱さであっと言う間に躾けられてしまった
	PRINTFORMW 膣を男の物と一体化したような感覚に陥りながら、男の腰の動きに合わせ%ANAME(対象)%は喘ぐ
	PRINTFORMW やがて常人の何倍もの量と濃さの精液を放たれると、%ANAME(対象)%はあられもない悦びの声を上げた
CASE 1
	PRINTFORMW 男は部屋に入るなり%ANAME(対象)%を押し倒すと、その上にのっしと覆いかぶさった
	PRINTFORMW 興奮して息を荒げ、%ANAME(対象)%の服を乱暴に剥ぎ取りながら、彼女の頬を舌でねろぉと舐め上げる
	IF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の虜)
		PRINTFORMW 思わず蕩けた表情になる%ANAME(対象)%のことなどお構いなしに一物を取りだすと、勢いよく挿入した
	ELSE
		PRINTFORMW 嫌悪感で顔を引きつらせる%ANAME(対象)%のことなどお構いなしに一物を取りだすと、勢いよく挿入した
	ENDIF
	PRINTFORMW 全体重を乗せた激しいピストンを受け、%ANAME(対象)%は呻き声を上げながら必死で男を抱きしめる他なかった
CASE 2
	PRINTFORMW 男はふん！ふん！と激しく息を荒げながら、%ANAME(対象)%に覆いかぶさる格好で腰を打ち付けている
	PRINTFORMW ドスドスと勢いよく抽送され、その度に子宮を小突かれている%ANAME(対象)%は息も絶え絶えになっている
	PRINTFORMW しかし男は一向に勢いを弱めることなく、%ANAME(対象)%を更に激しく犯し続ける
	PRINTFORMW やがて男が勢いよく射精すると、それを子宮で受け止めながら%ANAME(対象)%は背筋と足をピンと伸ばして絶頂した
CASE 3
	PRINTFORMW くちゅくちゅと粘膜が触れあう淫らな音が部屋に響く
	PRINTFORMW 男は胡坐をかいた上に%ANAME(対象)%を跨らせ、対面座位の格好で彼女とねっとりと唾液を交換している
	IF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の虜)
		PRINTFORMW 積極的に舌を絡ませている%ANAME(対象)%は、この瞬間を少しでも長く味わおうと、腰を動かさない様に我慢している
	ELSE
		PRINTFORMW 嫌悪感で男から少しでも逃れようとする%ANAME(対象)%だが、雌穴に男の巨根を深々と挿入されており、それもかなわない
	ENDIF
	PRINTFORMW 男はあえて激しく動かずに、%ANAME(対象)%が自ら腰を動かしだすまで、ねっとりとその柔肌を堪能し続けた
CASE 4
	PRINTFORMW %ANAME(対象)%は男と一戦を終え、布団の上で息も絶え絶えに転がっている
	PRINTFORMW その雌穴からはどろりと大量の白濁液が垂れており、ぱくぱくと広がってしまっている
	PRINTFORMW もう少し休ませてと懇願する%ANAME(対象)%に、男はニンマリと笑うと、どちゅん！とその巨大な一物をねじりこんだ
	PRINTFORMW 悲鳴を上げ身体をビクンと震わせる彼女に構うことなく、男は再び激しいピストンで攻め始めた
CASE 5
	PRINTFORMW %ANAME(対象)%は男によりべろんべろんに酔わされてしまった
	PRINTFORMW 朦朧としている%ANAME(対象)%を布団の上に寝かせ服を脱がせると、汗でしっとりとしている肌にむしゃぶりつく
	PRINTFORMW 男の巧みな指と舌の動きに、酒の作用で敏感になっている%ANAME(対象)%は、何度も嬌声をあげ潮を吹かされる
	PRINTFORMW %ANAME(対象)%の肌を存分に堪能した男はガチガチに勃起した一物を取りだすと、今度は%ANAME(対象)%の中を味わいだした
CASE 6
	PRINTFORMW %ANAME(対象)%は男によってメイド服を着せられている
	PRINTFORMW その恰好のまま、仰向けに寝転ぶ男に跨り奉仕させられている
	PRINTFORMW スカートをたくし上げ接合部を見せつけながら、腰を上下し男のペニスをしごく姿を見て、男は舌なめずりをする
	IF GETBIT(TALENT:対象:デイリー系, 素質_デイリー_貴族の虜)
		PRINTFORMW 恰好だけとは分かっていても、束の間本当にご主人様に奉仕できている悦びに打ち震えながら、%ANAME(対象)%は喘ぎ続けた
	ELSE
		PRINTFORMW 恰好だけとは分かっていても、次第に本当のご主人様に奉仕しているような錯覚に陥りながら、%ANAME(対象)%は喘ぎ続けた
	ENDIF
CASE 7
	PRINTFORMW 男は%ANAME(対象)%を連れて風呂場へ向かった
	PRINTFORMW 肌を密着したまま湯船につかっていると、やがて男の手が%ANAME(対象)%の敏感な箇所に伸びる
	PRINTFORMW 初めは身をこわばらせていた%ANAME(対象)%だが、男の的確なテクニックにより次第にのぼせた様な甘い声を漏らしだした
	PRINTFORMW %ANAME(対象)%の反応にすっかりご機嫌になった男は、湯船につかったまま存分に%ANAME(対象)%の身体を愉しみ始めた
CASE 8
	PRINTFORMW %ANAME(対象)%は四つん這いの格好で腰をつかまれ、激しく犯されている
```
