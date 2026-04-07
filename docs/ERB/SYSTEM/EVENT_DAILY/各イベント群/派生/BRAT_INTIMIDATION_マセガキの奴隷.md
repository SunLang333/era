# SYSTEM/EVENT_DAILY/各イベント群/派生/BRAT_INTIMIDATION_マセガキの奴隷.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/BRAT_INTIMIDATION_マセガキの奴隷.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_BRAT_INTIMIDATION_DISABLE, EVENT_DAILY_DERIVATION_BRAT_INTIMIDATION_DECISION, EVENT_DAILY_DERIVATION_BRAT_INTIMIDATION, EVENT_DAILY_DERIVATION_BRAT_AFTER_DISABLE, EVENT_DAILY_DERIVATION_BRAT_AFTER_DECISION, EVENT_DAILY_DERIVATION_BRAT_AFTER_SETTARGET, EVENT_DAILY_DERIVATION_BRAT_AFTER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_BRAT_INTIMIDATION_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("PRECOCIOUS_BRAT")

;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_BRAT_INTIMIDATION_DECISION()

RETURN DVAR:マセガキ_発生フラグ > 0 && RAND:100 < 40

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_BRAT_INTIMIDATION
#DIM 対象

対象 = ID_TO_CHARA(DVAR:マセガキ_奴隷ID)

IF 対象 == -1
	DVAR:マセガキ_発生フラグ = 0
	DVAR:マセガキ_奴隷ID = 0
	DVAR:マセガキ_調教深度 = 0
	RETURN 1
ENDIF


IF CFLAG:MASTER:所属 != CFLAG:対象:所属
	PRINTFORMW %ANAME(対象)%と%ANAME(MASTER)%が別陣営に分かれたため、その後の様子はわからなくなった……
	DVAR:マセガキ_発生フラグ = 0
	DVAR:マセガキ_奴隷ID = 0
	DVAR:マセガキ_調教深度 = 0
	RETURN 1
ENDIF

;ターゲットが女じゃなくなっていたらやめる
IF !IS_FEMALE(対象)
	PRINTFORMW %ANAME(対象)%が女をやめたので、マセガキは興味を失ってしまったようだ……
	DVAR:マセガキ_発生フラグ = 0
	DVAR:マセガキ_奴隷ID = 0
	DVAR:マセガキ_調教深度 = 0
	RETURN 1
ENDIF

;ターゲットが捕虜になったらやめる
IF CFLAG:対象:捕虜先
	PRINTFORMW %ANAME(対象)%が捕らえられたので、マセガキはこれ以上の調教をあきらめたようだ……
	DVAR:マセガキ_発生フラグ = 0
	DVAR:マセガキ_奴隷ID = 0
	DVAR:マセガキ_調教深度 = 0
	RETURN 1
ENDIF

IF CFLAG:対象:特殊状態 == 特殊状態_死亡
	PRINTFORMW %ANAME(対象)%が死亡したので、マセガキはこれ以上の調教を諦めたようだ……
	DVAR:マセガキ_発生フラグ = 0
	DVAR:マセガキ_奴隷ID = 0
	DVAR:マセガキ_調教深度 = 0
	RETURN 1
ENDIF

PRINTFORMW %ANAME(対象)%は今日も"ご主人様"に呼び出された
IF DVAR:マセガキ_調教深度 >= 7
	PRINTFORML しかしその足取りはいつもと違う
	PRINTFORML 度重なる調教でもはや%ANAME(対象)%はすっかり彼にオトされていた
	PRINTFORMW 今日も幼いご主人様に好き放題される事を想像して%ANAME(対象)%はブルッと身震いする
	PRINTFORML %ANAME(対象)%の表情を見た彼は自分の所有物になれ、と何時ものエラそうな態度で命令する
	PRINTFORML その言葉だけで軽くイった%ANAME(対象)%は、瞳に♥を浮かべながら彼へ忠誠を誓った
	PRINTFORMW 彼は満足気に笑うと、期待に胸を高鳴らせる%ANAME(対象)%を地下へと連れ込んだ
	PRINTFORMW 奴隷になった記念日としていつも以上に激しく彼に調教され%ANAME(対象)%は何度も悦びに達した
	CALL COLOR_PRINT(@"%ANAME(対象)%は心の底からご主人様の奴隷に成り下がった", カラー_警告)
	SETBIT TALENT:対象:デイリー系, 素質_デイリー_マセガキの奴隷
	CALL LOSE_RELATION_TALENT(対象)
	DVAR:マセガキ_発生フラグ = 0
	DVAR:マセガキ_奴隷ID = 0
	DVAR:マセガキ_調教深度 = 0
	PRINTFORMW
	RETURN
ENDIF
PRINTFORMW 逃げたくとも逃げられず、大人しく屋敷に出向くしかなかった………
PRINTFORML 
SELECTCASE RAND:30
	CASE 0
		PRINTFORML %ANAME(対象)%は彼の要望でメイドの格好をさせられた
		PRINTFORML 専属のメイドとして身の回りの世話をさせられながら、しばしば彼の気分で好き勝手に犯されてしまう
		PRINTFORML 掃除中、洗濯中、料理中…とにかくところ構わず手を出されては当り前の様に種付けされ汚されていく
		PRINTFORMW もちろん夜はベッドの中に連れ込まれ、満足するまで"ご奉仕"をさせられた
	CASE 1
		PRINTFORML %ANAME(対象)%は裸に剥かれると首輪をつけられてしまう
		PRINTFORML ペットとしてのふるまいを強要された%ANAME(対象)%は四つん這いで歩きワンと鳴く事しか許されない
		PRINTFORML %ANAME(対象)%が粗相や抵抗をする度に彼はしつけと称して激しく尻を叩き雌穴にペニスをねじ込んでくる
		PRINTFORMW 繰り返しの調教に気づけば%ANAME(対象)%は演技ではなく本心から彼のペットとしてふるまっていた
	CASE 2
		PRINTFORML 屋敷の地下室から%ANAME(対象)%のくぐもった呻き声が響いてくる
		PRINTFORML 機嫌が悪かった彼は%ANAME(対象)%を縛り上げて吊るし、八つ当たりとばかりに激しく犯してきた
		PRINTFORML 目隠しと口枷をされたまま荒々しく突き上げられ、%ANAME(対象)%はビクンビクンと身体を跳ねさせる
		PRINTFORMW 彼の怒りが静まるまで一晩中つき合わされ、解放された頃には全身が真っ赤に腫れあがっていた
	CASE 3
		PRINTFORML %ANAME(対象)%は四つん這いの格好で彼に犯されながら獣の様にヨガっている
		PRINTFORML 彼は飢えた獣の様に%ANAME(対象)%に抱きついて夢中で腰を振り、身体の奥深くまで蹂躙してくる
		PRINTFORML 妊娠上等の野性的なセックスに子宮は否応なく反応し、%ANAME(対象)%は強烈な疼きを感じ身悶えてしまう
		PRINTFORMW 行為を終える頃には%ANAME(対象)%は一匹の雌となり下がりだらしないアヘ顔を晒していた
	CASE 4
		PRINTFORML %ANAME(対象)%はベッドに腰かける彼に跪いて一物をお掃除している
		PRINTFORML 射精直後のそれは濃厚な雄の匂いを放ち、雌を刺激されて%ANAME(対象)%は頭がクラクラしてしまう
		PRINTFORML 先程までこれに犯されていたと思うだけで子宮が疼き、気づけば無我夢中でむしゃぶりついていた
		PRINTFORMW 丹念な奉仕に満足した彼は再び%ANAME(対象)%を押し倒すと、二回戦へと突入した
	CASE 5
		PRINTFORML ドロドロになった%ANAME(対象)%がベッドの上でアヘ顔のまま痙攣している
		PRINTFORML 周囲には散々%ANAME(対象)%を虐め尽したご主人様のコレクションが愛液まみれで散らばっている
		PRINTFORML 玩具を存分に使えた彼は満足気にサディスティックな笑みを浮かべ、%ANAME(対象)%のあそこを指で穿る
		PRINTFORMW 悲鳴を上げてビクビクと痙攣する%ANAME(対象)%の反応を見て、彼は一物を滾らせ覆い被さって来た
	CASE 6
		PRINTFORML ビュー♥ビュー♥と勢いよく精液が放たれながら%ANAME(対象)%はヒィヒィと喘ぐ
		PRINTFORML 若い彼の性欲はすさまじく、すでに%ANAME(対象)%の子宮は何発もの膣出しでぱんぱんに満たされている
		PRINTFORML 始めはこらえていた%ANAME(対象)%ももはや子宮の熱に抗えず、彼にしがみついて子種を受け入れている
		PRINTFORMW 射精を終えた彼がペニスを引き抜くと、ゴポッ♥と大量のザーメンが溢れ出てきた
	CASE 7
		PRINTFORML %ANAME(対象)%は彼の命令で裸エプロンで過ごさせられている
		PRINTFORML 少し動くだけで恥部が丸出しになり赤面する%ANAME(対象)%を彼はニヤついて眺めたりセクハラしてくる
		PRINTFORML もちろん彼がそれだけで満足するはずもなく、我慢できなくなる度に"ご奉仕"を命ぜられてしまう
		PRINTFORMW 事後、ドロリと彼のザーメンが溢れるのを見て%ANAME(対象)%は息を荒げながら身を震わせた
	CASE 8
		PRINTFORML 薬をのまされ発情しきった%ANAME(対象)%はしかし鎖で繋がれ地下室に放置されている
		PRINTFORML 圧倒的な官能の波に襲われながらも自らを慰める事も出来ない%ANAME(対象)%は発狂寸前で身悶える
		PRINTFORML しばらくして彼が姿を現した時、%ANAME(対象)%はもはや恥も外聞も投げ捨てて犯してくれと叫んでいた
		PRINTFORMW その夜は一晩中、地下室からあられもない女の喘ぎ声が響き渡って来た
	CASE 9
		PRINTFORML だらしないアヘ顔を晒した%ANAME(対象)%が我を忘れてオナニーしている
		PRINTFORML 通常の５倍の濃厚な発情薬を打たれた%ANAME(対象)%は快楽の事しか考えられない雌犬になってしまった
		PRINTFORML 指だけでは満足できない%ANAME(対象)%は、ニヤニヤと眺めていた彼に縋り付き股間に頬ずりして慈悲を乞う
		PRINTFORMW その姿に彼は満足そうに笑うと%ANAME(対象)%をベッドに押し倒し奥深くまでペニスをねじ込んできた
	CASE 10
		PRINTFORML ベッドの上で%ANAME(対象)%はだらしない雌の顔で彼に跨り身をくねらせている
		PRINTFORML 子供に似合わぬ逞しい一物は奥深くまで%ANAME(対象)%を抉り、放たれるザーメンは子宮を焦がしてくる
		PRINTFORML 胎を灼く精液の感触にどうしようもなく女を刺激され、無意識に彼の子供を求めて腰を振っていた
		PRINTFORMW 事後、大量の精液を吐き出された%ANAME(対象)%は妊娠の恐怖よりも期待に胸を昂らせていた
	CASE 11
		PRINTFORML %ANAME(対象)%はペットとして彼の友人の屋敷へと連れて行かれた
		PRINTFORML 彼の友人もまた同じような"ペット"を従えており、互いのペットの紹介と自慢をしだした
		PRINTFORML 彼女の雌犬らしい表情に%ANAME(対象)%は眉を顰めるが、自分も同じ様な表情をしていると気づかなかった
		PRINTFORMW 紹介が終わった二人は首輪で繋げられて、並べられたままたっぷりと調教されることになった
	CASE 12
		PRINTFORML 彼の欲望のままに散々虐められた後、%ANAME(対象)%は一緒にシャワーを浴びている
		PRINTFORML 腫れ上がった肌を丹念に洗われる心地よい刺激に、思わず身震いと共に甘い吐息を漏らしてしまう
		PRINTFORML 彼はその反応を気に入った様で、悶える%ANAME(対象)%の全身隅々まで指を這わせねっとりと洗い出した
		PRINTFORMW 艶めかしい%ANAME(対象)%の様子に彼が我慢できるはずもなく、その場で再びお楽しみが始まった
	CASE 13
		PRINTFORML 彼は%ANAME(対象)%を裸で引ん剝くとコート一枚で外に連れ出した
		PRINTFORML %ANAME(対象)%は人に見られる恐怖と羞恥で真っ赤となり足をガクガク震わせながら街中を練り歩かされる
		PRINTFORML 時折浮浪者や町人に遭遇する度に強制的にコートをはだけさせられ、変態の真似事をさせられる
		PRINTFORMW たっぷりと%ANAME(対象)%で遊んだ後はもちろんその火照り切った身体を彼直々に凌辱された
	CASE 14
		PRINTFORML ベッドに縛り付けられた%ANAME(対象)%がカメラに撮られながら犯されている
		PRINTFORML %ANAME(対象)%は必死で抵抗しようとするが、すっかり弱点を把握されておりあられもなくヨガってしまう
		PRINTFORML その痴態を耳元で実況され、羞恥と快楽で%ANAME(対象)%は真っ赤となりながらその反動で何度かイってしまう
		PRINTFORMW もはや開発済みの%ANAME(対象)%はその後もろくに抵抗できず痴態を余すことなくカメラに収められた
	CASE 15
		PRINTFORML %ANAME(対象)%は卑猥な衣装を着せられ大勢の子供達の前で犯されている
		PRINTFORML 彼は集めた友達の前で%ANAME(対象)%の抱き心地がいかに優れているかを自慢しながら激しく腰を振る
		PRINTFORML まるでオナホ自慢の様な扱いをされながらも%ANAME(対象)%は抵抗できず歯を鳴らして身悶えるしかできない
		PRINTFORMW そして大勢の子供達の視線に晒されながら、無様なアヘ顔絶頂に達してしまった
	CASE 16
		PRINTFORML メイド服を着せられた%ANAME(対象)%は彼の街中探索につき合わされている
		PRINTFORML 一見普通のメイドに見えるが、服の下にはローターやバイブをいくつも突っ込まれており足が震えている
		PRINTFORML 彼は息を荒げつつも堪える%ANAME(対象)%の様子を見てニヤつき、意地悪く人気の多い場所ばかり見て回る
		PRINTFORMW 帰宅後、一日中連れ回されすっかり火照り切った身体を乱暴に犯されてしまった
	CASE 17
		PRINTFORML %ANAME(対象)%は早速地下屋に連れ込まれて彼の調教を受けている
		PRINTFORML 半日に渡り薬や玩具で散々弄ばれ続けた%ANAME(対象)%はすっかりだらしない雌の顔を晒して痙攣している
		PRINTFORML 軽く恥部を弄られるだけでくちゅくちゅといやらしい蜜音が響き、喘ぎ声が上げて身悶えてしまう
		PRINTFORMW 出来上がり具合に満足した彼がいよいよペニスを取り出すと、%ANAME(対象)%は期待に子宮を疼かせた
	CASE 18
		PRINTFORML 今日も%ANAME(対象)%は彼に押し倒され、問答無用の種付けレイプをされる
		PRINTFORML 必死で避妊を要求しても彼がそれを受け入れるはずもなく、最も深い所に雄の証を放たれてしまう
		PRINTFORML ぎゅーっと抱きしめられながらの強烈な射精に、%ANAME(対象)%は無我夢中でご主人様にしがみついて身悶えた
		PRINTFORMW 彼の若き性欲は当然一度や二度では収まらず、その後も気を失うまで散々虐められることになった
	CASE 19
		PRINTFORML 寝室に連れ込まれるなり早速彼に押し倒され、何時もの様に激しく犯される
		PRINTFORML まだ幼くとも立派な雄の昂りを体の奥深くに叩きつけられ、自然と%ANAME(対象)%の喘ぎには色気が混ざっていた
		PRINTFORML 口ではもちろん抵抗するも、身体はむしろ積極的に彼に縋り付き快楽のままに艶めかしくくねらせていた
		PRINTFORMW 小一時間も立ったころには%ANAME(対象)%の瞳には♥が浮かびすっかり雌の顔にされていた
	CASE 20
		PRINTFORML %ANAME(対象)%は一日メイドとして彼の身の回りの世話を命じられた
		PRINTFORML メイドというより娼婦の様な格好での奉仕を強要され%ANAME(対象)%は顔を赤らめつつ彼を睨みつける
		PRINTFORML もちろん世話の中には下の世話も含まれており、仕事中もたびたび彼に求められてはその場で犯された
		PRINTFORMW 犯される度に太ももに書き加えられる正の字を見て、%ANAME(対象)%は顔を真っ赤にした
	CASE 21
		PRINTFORML 屋敷の最奥にあるご主人様の寝室から激しい男女のまぐわう音が響いてくる
		PRINTFORML 雌の味を覚えた若い彼はまさに猿の様に%ANAME(対象)%を求め、朝から晩まで暇さえあればセックスを繰り返す
		PRINTFORML その若さに任せた雄々しい腰遣いに%ANAME(対象)%の身体は否応なく雌として従わされ、たまらず喘いでしまう
		PRINTFORMW 屋敷を後にする頃には%ANAME(対象)%の子宮は溢れんばかりのザーメンでいっぱいにされていた
	CASE 22
		PRINTFORML 屋敷の一角で首輪をつけた%ANAME(対象)%が背後から激しく犯され喘いでいる
		PRINTFORML 彼はすっかり%ANAME(対象)%の弱点を把握しており、ペットを躾ける様に乱暴かつ的確に攻め立てて来る
		PRINTFORML 子供にいいようにされる屈辱と背徳感が%ANAME(対象)%の官能を刺激し気づかぬうちに激しくヨガっていた
```
