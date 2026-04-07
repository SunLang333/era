# SYSTEM/EVENT_DAILY/各イベント群/ASSASSIN_CHALLENGE_闇討ち.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/ASSASSIN_CHALLENGE_闇討ち.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_ASSASINATION_RATE, EVENT_DAILY_ASSASINATION_DECISION, EVENT_DAILY_ASSASINATION_GENRE, EVENT_DAILY_ASSASINATION, SELECT_CHARA_LIST_SHOW_LOGIC_ASSASINATION_ASSASIN, SELECT_CHARA_LIST_SELECT_LOGIC_ASSASINATION_ASSASIN, SELECT_CHARA_LIST_SHOW_LOGIC_ASSASINATION_TARGET, SELECT_CHARA_LIST_SELECT_LOGIC_ASSASINATION_TARGET, RAPE_ASSASSIN; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_ASSASINATION_RATE()
RETURN 25


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_ASSASINATION_DECISION()
SIF !IS_COUNTRY(CFLAG:MASTER:所属) || CFLAG:MASTER:捕虜先
	RETURN 0
SIF FLAG:クリアフラグ
	RETURN 0
RETURN DAY >= 15

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_ASSASINATION_GENRE()
RETURN デイリー_ジャンル_その他

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_ASSASINATION()
#DIM 暗殺者
#DIM 対象
#DIM 暗殺成否

IF DVAR:闇討ち提案_発生フラグ == 0
	PRINTFORMW ある日、部下から敵将を闇討ちしてはどうかと提案された
	PRINTFORMW 上手く怪我を負わせて一時的にでも戦力を削ぐことが出来れば、こちらにとって大きな利益となるだろう
	PRINTFORMW しかし、失敗した場合は当然その国との関係は大きく悪化するのは間違いない
	DVAR:闇討ち提案_発生フラグ = 1
ELSE
	PRINTFORMW 戦況を打破する為に、再び敵将の闇討ちを提案された
ENDIF
PRINTFORMW どうしようか……
CALL ASK_YN("暗殺を試みる", "やめておく")
IF RESULT == 1
	PRINTFORMW やはり危険だ、やめておこう
	RETURN 1
ELSE
	PRINTFORMW 確かに危険もあるが、その価値はある
	PRINTFORMW その分人選は慎重にする必要がある、誰に任せようか……
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("ASSASINATION_ASSASIN", "ASSASINATION_ASSASIN")
	暗殺者 = RESULT
	IF RESULT == -1
		PRINTFORMW いや、やはり危険だ、やめておこう
		RETURN 1
	ENDIF
ENDIF
IF 暗殺者 == MASTER
	PRINTFORMW 危険な仕事だ、自らやる事にしよう
ELSE
	PRINTFORMW %ANAME(暗殺者)%に任せる事にしよう
ENDIF
PRINTFORMW それでは、誰を標的にしようか……
CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("ASSASINATION_TARGET", "ASSASINATION_TARGET")
IF RESULT == -1
	PRINTFORMW いや、やはり危険だ、やめておこう
	RETURN 1
ENDIF
対象 = RESULT
PRINTFORMW %ANAME(対象)%に闇討ちを試みることにした
PRINTFORMW 任務を受けた%ANAME(暗殺者)%は敵地へと向かった
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
;暗殺持ちで武闘が10以上高いなら7/8、暗殺持ちなら5/8、武闘が10以上高いなら3/8、素ならば1/8で成功する
暗殺成否 = RAND:400
IF ABL:暗殺者:武闘 > ABL:対象:武闘 + 10
	暗殺成否 += 100
ENDIF
IF 暗殺成否 < 350
	PRINTFORMW 闇討ちに失敗してしまった！
	PRINTFORMW %ANAME(暗殺者)%は敵兵士に捕まってしまった
	SIF !(IS_MALE(暗殺者))
		CALL RAPE_ASSASSIN(暗殺者)
	PRINTFORML 
	PRINTFORML %ANAME(暗殺者)%は何とか隙をついて逃げ帰ってきた
	PRINTFORM しかし
	CALL COLOR_PRINT(@"%ANAME(GET_COUNTRY_BOSS(CFLAG:対象:所属))%勢力との関係は悪化してしまった", カラー_注意)
	PRINTFORMW
	CALL CHANGE_RELATION_C_TO_C(CFLAG:対象:所属, CFLAG:MASTER:所属, -500, 500)
ELSE
	PRINTFORML 闇討ちに成功した！
	CALL ADD_COOLTIME(対象, 3)
ENDIF
RETURN 1

@SELECT_CHARA_LIST_SHOW_LOGIC_ASSASINATION_ASSASIN(対象)
#DIM 対象
RETURN GET_COUNTRY_BOSS(CFLAG:対象:所属) != 対象 && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !IS_ANIMAL(対象) && CFLAG:対象:行動不能状態 != 行動不能_子供

@SELECT_CHARA_LIST_SELECT_LOGIC_ASSASINATION_ASSASIN(対象)
#DIM 対象
RETURN IS_FREE(対象) && CFLAG:対象:捕虜先 == 0

@SELECT_CHARA_LIST_SHOW_LOGIC_ASSASINATION_TARGET(対象)
#DIM 対象
RETURN IS_COUNTRY(CFLAG:対象:所属) && CFLAG:対象:所属 != CFLAG:MASTER:所属 && !IS_ANIMAL(対象) && CFLAG:対象:行動不能状態 != 行動不能_子供

@SELECT_CHARA_LIST_SELECT_LOGIC_ASSASINATION_TARGET(対象)
#DIM 対象
RETURN CFLAG:対象:捕虜先 == 0

;---------------------------------------------
;暗殺失敗
;---------------------------------------------
@RAPE_ASSASSIN(ARG:0)

PRINTFORML 
PRINTFORMW 捕えられた%ANAME(ARG:0)%が凌辱されている…
PRINTFORML 
SELECTCASE RAND:40
	CASE 0
		PRINTFORML %ANAME(ARG:0)%は大の字の格好でベッドに固定されながら兵士に犯されている
		PRINTFORML 兵士が腰を振る度に、結合部から下品な音と共に大量の白濁液が溢れ出る
		PRINTFORML 多数の兵士達に絶え間なく犯され続け、%ANAME(ARG:0)%はもはや喘ぎ続ける事しか出来なくなっており
		PRINTFORMW 兵士が低く唸りながら射精すると、%ANAME(ARG:0)%は何度目かの絶頂と共に大きく背を反らした
	CASE 1
		PRINTFORML %ANAME(ARG:0)%は見せしめとして裸で晒し台に固定されている
		PRINTFORML その全身は兵士たちの精液で見るも無残に汚されており、ところどころ落書きもされている
		PRINTFORML 今も兵士に犯されており、%ANAME(ARG:0)%は涙を流しながら歯をくいしばって耐えている
		PRINTFORMW しかし身体はすっかり躾けられており、膣出しされると全身を痙攣させつつ望まぬ絶頂に達するのだった
	CASE 2
		PRINTFORML 牢屋の中、%ANAME(ARG:0)%は万歳の格好で宙吊りにされて多数の兵士に囲まれている
		PRINTFORML 下腹部と尻には多数の　正　の字が書かれており、足元の水たまりと合わせて散々凌辱されたのが分かる
		PRINTFORML そして今もまた両穴を深く抉られながら射精され、%ANAME(ARG:0)%は獣が吠える様な嬌声を上げて絶頂した
		PRINTFORMW 女日照りの兵士たちがこのぐらいで満足するはずもなく、その後も延々と彼らの性処理に使われ続けた
	CASE 3
		PRINTFORML %ANAME(ARG:0)%は目隠しをされ全身を縄で縛られた状態で犯されている
		PRINTFORML %ANAME(ARG:0)%の身体に目を付けた将校によって直接“尋問”されているのだ
		PRINTFORML ペニスの形を覚えてしまう程に犯され続け、%ANAME(ARG:0)%の喉からは呻き声ではなく喘ぎ声が漏れ出している
		PRINTFORMW 尋問は一晩中続き、%ANAME(ARG:0)%はすっかり男のペニスと一体化するような錯覚に陥ってしまった
	CASE 4
		PRINTFORML 薄暗い牢屋の中、%ANAME(ARG:0)%は虚ろな表情で兵士達に奉仕している
		PRINTFORML 薬を打たれ意識が朦朧としている%ANAME(ARG:0)%は、従順に彼らのペニスを咥えこみ扱いている
		PRINTFORML 膣内でペニスが膨れ上がるのを感じると、優しく彼のペニスを締め付けて一滴残らず精液を受け入れる
		PRINTFORMW 子宮を焦がされる程の熱を感じ身震いしつつ絶頂しながらも、%ANAME(ARG:0)%は次の兵士への奉仕へと移った
		CFLAG:(ARG:0):薬物依存 += RAND(20, 50)
	CASE 5
		PRINTFORML %ANAME(ARG:0)%は兵士たちによって散々嬲られ、息も絶え絶えに床に倒れている
		PRINTFORML 体をガクガクと震わせながら横たわる%ANAME(ARG:0)%の周囲には、様々な器具が転がっている
		PRINTFORML 耳元でこのまま続けるのと自分から体を開くのと、どちらが良いかと囁かれた%ANAME(ARG:0)%はビクッと震える
		PRINTFORML そしておずおずと秘貝を両手で割り開いて見せ、優しく犯してくださいと兵士達に“おねだり”をした
		PRINTFORMW おねだりする%ANAME(ARG:0)%の姿に満足した兵士たちは、すっかり従順になった彼女を散々可愛がった
	CASE 6
		PRINTFORML %ANAME(ARG:0)%は首輪とリードをつけられ、四つん這いのまま連行されている
		PRINTFORML その尻穴には尻尾つきのビーズがハメられており、歩く度に尻をふりふりと尻尾を揺らす姿はまさに犬の様だ
		PRINTFORML 時折兵士に尻を叩かれたり乳首を捻られたりするが、%ANAME(ARG:0)%は顔を真っ赤にして体を震わせる事しかできない
		PRINTFORMW やがて我慢できなくなった兵士たちによって、犬にふさわしい姿勢のまま散々犯された
	CASE 7
		PRINTFORML %ANAME(ARG:0)%は兵士達の慰み者として犯されている
		PRINTFORML 一人の兵士の上で腰を振らされながら、口と両手を使いペニスをしごいている
		PRINTFORML 少しでも奉仕を緩めると罵声と暴力が飛んでくるため、%ANAME(ARG:0)%は必死で奉仕を続ける
		PRINTFORML 兵士が限界を迎え%ANAME(ARG:0)%の中に濃い精液を放つと、%ANAME(ARG:0)%は引き攣った笑顔でそれを受け入れる
		PRINTFORMW もちろんそれで終わりではなく、すぐまた次の兵士によってペニスをねじ込まれて犯される事を繰り返した
	CASE 8
		PRINTFORML %ANAME(ARG:0)%は兵士達の酒場の一角で鎖につなげられ、見世物にされている
		PRINTFORML 娼婦のような卑猥な衣装を身につけさせられ、身体を隠そうとすれば罰と称して犯された
		PRINTFORML 酔った兵士によって体を弄られても抵抗は許されず、弄ばれるままに喘ぐしかなかった
		PRINTFORMW やがて兵士達のボルテージが最高潮に達すると、机の上に運ばれて多数の兵士によって輪姦された
	CASE 9
		PRINTFORML %ANAME(ARG:0)%は兵士達の慰安要員として水浴び場で働かされている
		PRINTFORML 汚れた兵士達の体を自らの体を使って隅々まで洗わされる
		PRINTFORML %ANAME(ARG:0)%の様な女にそんなことをされれば兵士も我慢できず、彼らの肉棒は限界までそそり立つ
		PRINTFORML それを鎮めるのもまた%ANAME(ARG:0)%の仕事であり、膣で咥えこんで一人一人の精を受け止めていく
		PRINTFORMW 奉仕は日が暮れるまで続き、その頃には%ANAME(ARG:0)%の雌穴からは収まりきらなかった精液が垂れ流しになっていた
	CASE 10
		PRINTFORML %ANAME(ARG:0)%は優れた戦果を挙げた兵士への報償にされた
		PRINTFORML 彼は多数の兵が見ている前で、抵抗する%ANAME(ARG:0)%を押さえつけて無理矢理ペニスをねじ込んだ
		PRINTFORML そのあまりの逞しさと激しい抽送に%ANAME(ARG:0)%はすぐに痙攣して絶頂してしまい、兵士達に笑われる
		PRINTFORMW しかし数度絶頂する頃にはすっかり彼の一物の虜になってしまい、自ら腰を振って種をねだっていた
	CASE 11
		PRINTFORML %ANAME(ARG:0)%は特設肉便器として宿舎に繋がれている
		PRINTFORML しばしば兵士がやって来ては%ANAME(ARG:0)%を好き放題に犯し、無遠慮に膣出しをしては去っていく
		PRINTFORML すっかり汚された%ANAME(ARG:0)%は兵士にホースで水をかけて洗われ、余りの惨めさに泣いてしまう
		PRINTFORMW その表情が兵士の加虐心を刺激し、綺麗になったばかりの体を再び犯され汚されてしまった
	CASE 12
		PRINTFORML %ANAME(ARG:0)%は牢屋の中で兵士達に廻されている
		PRINTFORML イボイボ付きの巨大なペニスで膣肉をゴリゴリと抉られる度に呻き声が漏れ、口で咥えたペニスを刺激する
		PRINTFORML 喉奥まで乱暴にペニスをねじ込まれると、窒息感と雄の臭いできゅっと膣を締め付けペニスを刺激する
		PRINTFORMW そうやって兵士達はまるで%ANAME(ARG:0)%を具合の良い玩具のように乱暴に使い続けた
	CASE 13
		PRINTFORML 牢屋で繋がれている%ANAME(ARG:0)%の前に一匹の犬が連れてこられた
		PRINTFORML 犬は血走った目で%ANAME(ARG:0)%を見つめ、そのペニスははち切れんばかりに勃起している
		PRINTFORML 恐怖で体をこわばらせる%ANAME(ARG:0)%に兵士が自分たちと犬、どちらに犯されたいかと問う
		PRINTFORML %ANAME(ARG:0)%は涙を流しながら恐る恐る体を開き、どうかわたしを犯してくださいと兵士達に懇願した
		PRINTFORMW しかし彼らは%ANAME(ARG:0)%を散々犯しつくした後、無慈悲にも犬を%ANAME(ARG:0)%にけしかけ種付けさせた
	CASE 14
```
