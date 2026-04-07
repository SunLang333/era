# SYSTEM/EVENT_DAILY/各イベント群/BLAIN_WASH_謎の催眠術師.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/BLAIN_WASH_謎の催眠術師.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_BLAIN_WASH_RATE, EVENT_DAILY_BLAIN_WASH_DECISION, EVENT_DAILY_BLAIN_WASH_GENRE, EVENT_DAILY_BLAIN_WASH, SELECT_CHARA_LIST_SHOW_LOGIC_BLAIN_WASH, SELECT_CHARA_LIST_SELECT_LOGIC_BLAIN_WASH; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_BLAIN_WASH_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_BLAIN_WASH_DECISION()
;斬り捨てていたら発動しない
SIF DVAR:催眠_発生フラグ == -1
	RETURN 0

RETURN DAY >= 10

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_BLAIN_WASH_GENRE()
RETURN デイリー_ジャンル_エロ

@EVENT_DAILY_BLAIN_WASH()
#DIM 対象

;1回目
IF DVAR:催眠_発生フラグ == 0
	PRINTFORMW
	PRINTFORML 近頃領内で不審人物の目撃情報が出ている
	PRINTFORML 深夜、街中に現れては出会った娘に声をかけていくらしい
	PRINTFORMW 今のところ具体的な被害はないようだが、領民の安心の為に夜回りを行ってもいいかもしれない
;2回目以降
ELSEIF DVAR:催眠_発生フラグ == 1
	PRINTFORMW
	PRINTFORML 再び不審人物の目撃情報が出た
	PRINTFORML やはり夜中に現れ、出歩く娘に声をかけているようだ
	PRINTFORMW 以前の夜回りは不発に終わったが、このまま放置していいものだろうか
ENDIF

PRINTFORML 夜周りを行うならば不審人物をおびき出す為に一人、それも少女にしたほうが良いだろう
PRINTFORML さて、どうしようか……
CALL SINGLE_DRAWLINE
CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("BLAIN_WASH", "BLAIN_WASH")

対象 = RESULT

IF 対象 == -1
	PRINTFORML ……いや、被害が出ていないならば過敏になる必要もないだろう
	PRINTFORMW そう考え直した%ANAME(MASTER)%は、夜回りを行わないことにした
	RETURN 1
ELSE
	IF 対象 == MASTER
		PRINTFORMW %ANAME(対象)%自ら夜回りを行うことにした
	ELSE
		PRINTFORMW %ANAME(対象)%を夜回りに送りだした
	ENDIF

	PRINTFORML ・
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW %ANAME(対象)%は深夜の町中を見回っている
	PRINTFORML 歓楽街や住宅街などを歩き回るが、しばらくは怪しい人物も見当たらなかった
	PRINTFORMW しかし日付が変わる頃、街外れの人気が少ない地区で一人の怪しげな男を見かけた。フードを目深にかぶった長身の男だ
	PRINTFORML 見るからに怪しい、そう思った%ANAME(対象)%は男を呼び止め尋問を行った
	PRINTFORMW 呼び止められた男は素直に尋問に応じたが、それを逆に怪しいと思った%ANAME(対象)%は男にフードを取るように命じた
	PRINTFORML すると男はニヤリと笑いフードを取った
	PRINTFORML フードの下はどこにでもいるような顔だったが、その瞳は怪しげな光を放っていた
	PRINTFORMW 男と目が合うと%ANAME(対象)%は吸い込まれるような不思議な印象を受けた……
	CALL ASK_YN("尋問を続ける", "咄嗟に瞳をつぶった")
	IF RESULT == 1
		PRINTFORML この男の瞳を視てはいけない！
		PRINTFORMW そう直感した%ANAME(対象)%は目をつぶると問答無用で男を斬り捨てた！
		PRINTFORML 男は悲鳴を上げる間もなくその場に崩れ落ちた
		PRINTFORML 亡骸を調べるとなんとそれは巨大な瞳の妖怪であった！
		PRINTFORML 何を企んでいたのかはわからないが、恐らく良からぬことだったのだろう
		PRINTFORMW %ANAME(対象)%は妖怪の亡骸を近くの詰め所に運び込むと宮殿へと帰還した
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		PRINTFORML あれから不審人物の目撃情報も出なくなった
		PRINTFORML やはりあの妖怪が件の不審人物だったようだ
		IF 対象 == MASTER
			PRINTFORMW %ANAME(対象)%は領民の不安を取り除くことが出来、満足した
		ELSE
			PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%を労った
		ENDIF
		DVAR:催眠_発生フラグ = -1
		RETURN 1
	ELSE
		SELECTCASE RAND:40
			CASE 0
				PRINTFORMW 男の瞳を見つめていると一瞬くらっと来たが、頭を振り、尋問を続けた
				PRINTFORML %ANAME(対象)%の尋問に適当な生返事をしつつ、男はおもむろに%ANAME(対象)%の身体に手を触れた
				PRINTFORMW しかし%ANAME(対象)%は何も反応を示さず、何事も無いかのように尋問を続けている
				PRINTFORML 男はニヤリと笑うと、更に%ANAME(対象)%の胸や恥部をまさぐり出した
				PRINTFORMW 男の催眠術により、%ANAME(対象)%は男の行為を何でもない行為だと思い込んでいるのだ
				PRINTFORML 男は%ANAME(対象)%の身体をひとしきり弄ぶと己のはちきれんばかりの肉棒を取り出した
				PRINTFORML そして%ANAME(対象)%の片足を持ち上げるとすっかり濡れている雌穴に思いきり肉棒をねじ込んだ
				PRINTFORMW 無反応の思考と異なり、身体はビクンと震える
				PRINTFORML 肉棒を膣で受け入れ密着するほど顔を近づけながら、まるでそれが普通の事のように振る舞っている
				PRINTFORML 男は%ANAME(対象)%を馬鹿にするように下卑た笑いを上げながら腰を振りだした
				PRINTFORMW 意識はせずとも身体は与えられる刺激に素直に反応し、男の肉棒をぎゅうっと締め付けだした
				PRINTFORML そのうち男の腰の動きが早まり、膣奥で思い切り熱い精液を吐き出された
				PRINTFORMW 男の精液を子宮で受け止めつつ、%ANAME(対象)%はやや頬を赤らめながらも先ほどと同じく尋問を続けている
				PRINTFORML 
				PRINTFORMW その後も何度も膣出しされ、子宮が汚い精液で満たされるまで男の行為は続いた
			CASE 1
				PRINTFORMW 男の瞳を見つめていると一瞬くらっと来たが、頭を振り、尋問を続けた
				PRINTFORML 怪しい物を持っていないかという%ANAME(対象)%の問いに男はニヤリと笑い、おもむろに己の肉棒をさらけ出した
				PRINTFORMW %ANAME(対象)%は突然の事にも動じることなく、ひざまづき「調べさせてもらいます」と言うと、男の一物を咥えこんだ
				PRINTFORML 男の催眠術により、%ANAME(対象)%はそれが当たり前の事だと思い込んでいるのだ
				PRINTFORML 熱心に肉棒をしゃぶっている%ANAME(対象)%を男は下卑た笑みで見下ろしている
				PRINTFORMW その程度じゃ駄目だぜと告げる男の指示に従い、%ANAME(対象)%は懸命に肉棒を調査(奉仕)している
				PRINTFORML 次第に肉棒は固くなり、男が低く呻き%ANAME(対象)%の頭を強く押さえつけると、その口内に熱いザーメンを注ぎ込んだ
				PRINTFORML ビクビクと震え、えづきながらも%ANAME(対象)%は男のザーメンを一滴残らず飲みこんだ
				PRINTFORMW 一物から口を離した%ANAME(対象)%は涙目でせき込みながら、「これなら問題ないですね」と男を見る
				PRINTFORML しかし男はどうせ調べるならこっちでも調べたほうが良いんじゃないか？と%ANAME(対象)%の股間に肉棒を擦り付ける
				PRINTFORML %ANAME(対象)%は男と目を合わせると一瞬硬直したが、その通りだと服を脱ぎ、男に向かって尻を突き出す格好になり
				PRINTFORMW 誘うように尻を振りながら「肉棒を挿入してください、精液を調査する為に子宮に注いでください」と淡々と告げた
				PRINTFORML 男は馬鹿にしたような笑い声をあげると、腰をつかみ恥部に肉棒をあてがうと一気に%ANAME(対象)%の奥へとねじ込んだ
				PRINTFORML 乱暴な衝撃にビクビクと身体を震わせながらも%ANAME(対象)%は抵抗せずに男に犯され続けた
				PRINTFORML 
				PRINTFORMW その後、%ANAME(対象)%の望んだとおり何度も膣出しをした後、男は凶器など持っていないということで解放された
			CASE 2
				PRINTFORMW 男の瞳を見つめていると一瞬くらっと来たが、頭を振り、尋問を続けた
				PRINTFORML しかし男はニヤニヤしながら曖昧な答えしか返さず、%ANAME(対象)%は男を怪しみ、連行して取り調べる事にした
				PRINTFORMW 男の腕を引き%ANAME(対象)%は尋問をする場所……歓楽街にあるラブホテルへと入っていった
				PRINTFORML 頭を溶かすような芳香の漂う部屋に入ると%ANAME(対象)%は躊躇いなく服を脱ぎさり、男にも裸になるように命令する
				PRINTFORML 男の催眠術により、%ANAME(対象)%はそれが当たり前の事だと思い込んでいるのだ
				PRINTFORMW 男はやはりニヤケ面のまま大人しく服を脱ぎ、ベッドの上に寝転がる
				PRINTFORML %ANAME(対象)%は全身をローションで濡らすと、そのまま男の上に倒れ込み身体検査と称して男の全身にローションを塗り始めた
				PRINTFORML 肌と肌とがこすれ合わさる感覚と部屋に満ちた芳香で次第に%ANAME(対象)%の息が荒くなっていく
				PRINTFORMW やがて天を突くほどに勃起した男の一物を握ると、その上に跨り秘部にあてがった
				PRINTFORML 肉棒を股間に擦り付けながら「素直に答えないなら罰を与えます、答えるなら今のうちですよ」と真剣な表情で告げる
				PRINTFORML 男がなおも笑っていると、%ANAME(対象)%は男の胸に手を当てながら肉棒を秘所に咥えこみゆっくりと腰を下ろしていく
				PRINTFORMW そして子宮口に肉棒がこつんと当たると%ANAME(対象)%はビクンと大きく背中を反らした
				PRINTFORML 肉棒を深々と咥えこんだ姿勢になり、自分では気づかない震える声で男に自白を命じながらゆっくりと腰を振りだした
				PRINTFORML 次第に%ANAME(対象)%の口からは喘ぎ声が漏れだし腰の動きが早まりだす
				PRINTFORML そして男の大きな一突きと共に熱いザーメンを注ぎ込まれると、一際大きな嬌声を上げながら背中を反らして絶頂した
				PRINTFORMW 絶頂の余韻で震えながら喉から甘えた声を絞りだし、%ANAME(対象)%は尋問の続行を告げた
				PRINTFORML 
				PRINTFORMW その後男への尋問は空が白むまで続いた
			CASE 3
				PRINTFORMW 尋問の途中、不意に眩暈を起こし倒れ掛かった%ANAME(対象)%を男がとっさに支えた
				PRINTFORML %ANAME(対象)%は気遣う男に礼を言うと、夜回りに戻る為に男に別れを告げた
				PRINTFORML 男が%ANAME(対象)%を呼びとめ手伝いを申し出ると、%ANAME(対象)%は少し考えた後に提案を受け入れた
				PRINTFORML そして%ANAME(対象)%はおもむろに服を脱ぎだし全裸になると、男と共に夜回りを再開した
				PRINTFORMW 月明かりの元に%ANAME(対象)%の裸体が照らし出される。男の催眠術により裸こそが今の%ANAME(対象)%の制服になっているのだ
				PRINTFORML やがて真っ暗な路地裏に差し掛かると、そこからみすぼらしい格好の浮浪者が現れた
				PRINTFORML %ANAME(対象)%の姿に驚き固まっている彼に対して%ANAME(対象)%は先ほど男にしたように職務質問を始めた
				PRINTFORML 男は浮浪者の姿を見てニヤリと笑うと、%ANAME(対象)%の背後に近づき、当然のように胸と秘所を弄りだした
				PRINTFORMW ピンと立った乳首と愛液が垂れ流される秘所を弄ると、%ANAME(対象)%は無表情のままビクンビクンと小さく絶頂する
				PRINTFORML 明らかに異常な光景を前に浮浪者は戸惑いながらも、股間を膨らませながら目を見開き釘付けになっている
				PRINTFORMW 彼の反応を見ると男は口角を上げ、%ANAME(対象)%の腰を掴むと、ズン！と一気にペニスを突き入れた
				PRINTFORML 男はビクンと跳ね上がり尋問が止まる%ANAME(対象)%を気遣うこともなく、浮浪者に見せつけるように激しく腰を打ち付ける
				PRINTFORMW 浮浪者は目を血走らせ生唾を呑みながらその光景から目を逸らさずにいる
				PRINTFORML 男が肉棒を差し込んだまま%ANAME(対象)%と向き合う姿勢になり、尻穴を浮浪者の方に差し出すと
				PRINTFORMW もはや我慢の限界になった彼は恥垢まみれの一物を取りだし、%ANAME(対象)%の尻穴に肉棒を突き刺した
				PRINTFORMW 雌穴と尻穴を同時に挿入されながらも、%ANAME(対象)%は喘ぎ声一つ上げずにされるままに犯され汚されていった
				PRINTFORML 
				PRINTFORMW やがて彼らの汚い精液でたっぷりと汚された%ANAME(対象)%は路地裏にごみのように放置された
			CASE 4
				PRINTFORMW 男の瞳を見つめていると一瞬くらっと来たが、頭を振り、尋問を続けた
				PRINTFORML 男にいくつかの質問をした後、問題ないと判断した%ANAME(対象)%は男と別れ夜回りに戻ろうとした
				PRINTFORMW すると男に腕をつかまれ、ちゃんと仕事を果たせと詰め寄られる
				PRINTFORML %ANAME(対象)%が戸惑っていると、男は膨らんだ股間を%ANAME(対象)%に押し付けて鎮めるように要求してきた
				PRINTFORMW %ANAME(対象)%は頬を赤らめ、苦虫をかみ殺したような表情で男を睨む
				PRINTFORML しかし確かにそれが自分の仕事だ。男の魔羅を昂ぶらせてしまった以上、それを鎮めるのが“夜回りの仕事”だ
				PRINTFORML にやにやと笑う男を路地裏に引っ張ると、男の前にひざまづき勃起したペニスを露出させる
				PRINTFORML こんなもの見たくもないがこれも仕事だと自分に言い聞かせると
				PRINTFORMW %ANAME(対象)%は男の肉棒を手で包み込むと、男のペニスに舌を亀頭に這わせだした
				PRINTFORML 奉仕させながら卑猥な笑みを浮かべる男を睨みつけ、嘔吐しそうな感覚と嫌悪感に耐えながら懸命に仕事を続ける
				PRINTFORML やがて男が低く呻くとともにペニスがビクビクと震えると、%ANAME(対象)%の口内に精子が勢いよく放たれた
				PRINTFORML 火傷しそうな感覚を我慢しながら%ANAME(対象)%は懸命に男の精子を残さずに飲みこむ
				PRINTFORMW しかし男のペニスは衰えることを知らずに未だに硬くそそり立っている
				PRINTFORML 笑う男を睨みつけながら、%ANAME(対象)%は今度は裸になり
				PRINTFORML 地面に寝転がると自らの秘所を男に向かって差し出し、肉棒を挿入するように男に催促した
				PRINTFORML 男が%ANAME(対象)%に覆いかぶさり肉棒を膣へとねじ込むと
				PRINTFORMW %ANAME(対象)%はぐうっと低く唸りながらも、ペニスが抜けないように両手両足で男をしっかりと抱きしめた
				PRINTFORML 嫌悪感を露わにしながらも%ANAME(対象)%は男の為に必死で腰を振り、卑猥な言葉を連呼して男の射精を促す
				PRINTFORML やがて%ANAME(対象)%から喘ぎ声が漏れ出してくる頃に、男は%ANAME(対象)%の最奥へと己の欲望をぶちまけた
				PRINTFORMW %ANAME(対象)%は子宮への熱い感触で絶頂しながら男にぎゅうっと密着した
				PRINTFORML 
				PRINTFORMW その後、男が満足するまで夜通し%ANAME(対象)%の仕事は続いた
			CASE 5
				PRINTFORMW 男の瞳を見つめていると一瞬くらっと来たが、頭を振り、正気に戻った
				PRINTFORML 目の前には男がニヤニヤしながら立っており、その手には首輪とリードがある
				PRINTFORMW %ANAME(対象)%はふと思い出した……そうだ、この男は私のご主人様だった、今は夜の散歩の最中だったではないか
				PRINTFORML 途端に%ANAME(対象)%は服を全て脱ぎ捨て、ご主人様に飛びついた
				PRINTFORML 男が%ANAME(対象)%の身体を撫でまわすと、%ANAME(対象)%は媚びるような表情でくぅんと甘く喉を鳴らした
				PRINTFORMW 男は悪趣味な笑みを浮かべると、%ANAME(対象)%に首輪をつけ、“散歩”に出かけた
				PRINTFORML …夜風に触れた乳首をピンと立たせながら、%ANAME(対象)%は四つん這いで街を散歩している
				PRINTFORML 時折ご主人様に胸や秘所、尻穴を弄られると、その度に悦びの声を上げる
				PRINTFORMW 小一時間ほど散歩を楽しみ、近くの公園で休む頃にはすでに蜜穴から愛液が垂れ流しになっていた
				PRINTFORML すっかり盛りのついた雌犬のように舌を出し息を荒げる%ANAME(対象)%を見下ろし、男は一物をその眼前に曝け出した
				PRINTFORML 強烈な雄の匂いに刺激され、今にも肉棒に飛びかかりそうな%ANAME(対象)%に向かって男はおねだりするように命ずる
				PRINTFORML %ANAME(対象)%は男に向かって尻を突きだす格好になると、命ぜられるままに卑猥な言葉を繰り返し種付けをねだった
				PRINTFORML 満足した男は%ANAME(対象)%の尻を鷲掴みにすると、愛液を垂らすまんこにペニスを押し当てぐりぐりとねじ込んだ
				PRINTFORML わぉん！あぉぉん！と%ANAME(対象)%が歓喜で打ち震えながら男の肉棒を受け入れる
```
