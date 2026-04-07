# 口上/23 萃香口上/DAILY/_KOJO_DAILY_K23_子鬼は声を抑えたい.ERB — 自动生成文档

源文件: `ERB/口上/23 萃香口上/DAILY/_KOJO_DAILY_K23_子鬼は声を抑えたい.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K23_SILENT_SEX_RATE, KOJO_DAILY_K23_SILENT_SEX_DECISION, KOJO_DAILY_K23_SILENT_SEX_GENRE, KOJO_DAILY_K23_SILENT_SEX; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K23_SILENT_SEX_RATE(対象)
#DIM 対象
RETURN (KDVAR:対象:萃香_声を抑えて > 0 ? 200 # 50)


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K23_SILENT_SEX_DECISION(対象)
#DIM 対象

;終わってたら発生しない
SIF KDVAR:対象:萃香_声を抑えて == -1
	RETURN 0

;好感度5000以下だと駄目
SIF CFLAG:対象:好感度 <= 5000
	RETURN 0

;合意が無いと駄目
SIF !TALENT:対象:合意
	RETURN 0

;対象が女でないとだめ
SIF !IS_FEMALE(対象)
	RETURN 0

;主人公と同一勢力で捕虜でなく、主人公がペニス持ち
RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0) && HAS_PENIS(MASTER)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K23_SILENT_SEX_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_その他


;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K23_SILENT_SEX(対象)
#DIM 対象


SELECTCASE KDVAR:対象:萃香_声を抑えて
	CASE 0
		PRINTFORMW 深夜、%ANAME(対象)%が%ANAME(MASTER)%の部屋を訪ねてきた
		PRINTFORML 「あ、あのさ…ちょっといいかな？　折り入って相談があるんだけど……」
		PRINTFORMW 普段の快活とした様子ではない。そして顔が赤い。普段の酒酔いによる赤ら顔とは明らかに違うものだった
		PRINTFORML 一体どうしたのか、話を聞いてみると
		PRINTFORMW 「えーと…、その……、あのさ、私って……%ANAME(MASTER)%とまぐわってる時、声大きいかな？」
		PRINTFORMW ……ちょっと予想外な相談が返ってきた
		PRINTFORML 「い、いやね！？　他の子に言われたんだけど…%ANAME(MASTER)%とシてる時、私の声…、周りに聞こえてるみたいで…」
		PRINTFORMW 「他の子はそんなでも無いみたいなんだけど…。私の喘ぎ声、そんなに大きいかなって…ね」
		PRINTFORML %ANAME(対象)%は顔を赤くしながら%ANAME(MASTER)%に悩みを打ち明けた
		PRINTFORMW さて、どう答えよう……
		PRINTFORML
		CALL ASK_YN("…確かに大きいかも", "気にする必要は無い")
		PRINTFORML
		IF RESULT == 1
			PRINTFORMW 別にそんなことは無い。気にする必要はないと伝えた
			PRINTFORML 「ほ、ほんとに？　抑えたりしなくていい？」
			PRINTFORMW むしろ%ANAME(対象)%は思うまま声を上げている方が魅力的だ、と伝えた
			PRINTFORML 「も、もう！　%ANAME(MASTER)%ったら調子いい事言っちゃって～♪」
			PRINTFORMW %ANAME(対象)%は%ANAME(MASTER)%の腰をバンバン叩きながらも、口元を緩ませている
			PRINTFORML 「そんなこと言うから……、ガラにも無く身体が疼いてきちゃったじゃないか…♥」
			PRINTFORMW %ANAME(対象)%は切なげに身体をくねらせながら%ANAME(MASTER)%に擦りよる
			PRINTFORMW 彼女が求める期待に応えて%ANAME(対象)%を抱き寄せ、可愛い喘ぎ声を聞くための交わりを始めた……
			CALL FUCK_MAKELOVE(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の唇", ANAME(MASTER))
			CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣")
			CFLAG:対象:好感度 += 800
			CFLAG:対象:従属度 += 500
			CFLAG:対象:依存度 += 300
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が800上がった", カラー_シアン)
			CALL COLOR_PRINTL(@"%ANAME(対象)%の従属度が500上がった", カラー_シアン)
			CALL COLOR_PRINTL(@"%ANAME(対象)%の依存度が300上がった", カラー_シアン)
			KDVAR:対象:萃香_声を抑えて = -1
		ELSE
			PRINTFORMW 確かにちょっと…大きいかも、と伝えた
			PRINTFORML 「や、やっぱり、そうなんだ……。ああっもう！　恥ずかしいっ！　今まで周りに聞こえていたなんて！」
			PRINTFORMW %ANAME(対象)%は耳まで真っ赤にして顔を隠す。普段は豪快単純だが、こういう所はやっぱり恥ずかしいようだ
			PRINTFORML 自分の嬌声が周囲に丸聞こえだったという羞恥に悶える%ANAME(対象)%に、%ANAME(MASTER)%はとある提案をした
			PRINTFORMW だったらこれから声を抑えるように練習をしよう、と
			PRINTFORML 「へ？　声を抑える練習？　どういうこと？」
			PRINTFORMW 要はエッチの時に大声で喘がなければいいだけだ
			PRINTFORMW だからしばらく、声を出さないよう意識しながら少しずつ快感に慣らしていこう、と伝えた
			PRINTFORML 「…そうか、少しずつ慣らしていけば恥ずかしい声を聞かれることも無くなるかも…」
			PRINTFORMW 「うん、ちょっとやってみるよ」
			PRINTFORML %ANAME(対象)%はその提案に乗った。善は急げだ。%ANAME(MASTER)%はさっそく%ANAME(対象)%の身体を抱き寄せた
			PRINTFORMW いきなり性交はせず、今日は軽い愛撫だけで試してみよう、と告げる
			PRINTFORMW 「う、うん…あの、声出さないよう、一応は頑張るから……優しくしてね……」
			PRINTFORML 普段と勝手が違う行為に、%ANAME(対象)%はしおらしい態度で%ANAME(MASTER)%に身をゆだねた…
			PRINTFORML
			PRINTFORMW ･･･
			PRINTFORML 「ふ…っ！　…♥…ん、…んん…っ…！　…♥」
			PRINTFORMW %ANAME(対象)%はなるべく声を上げないように、きつく口をつぐみ快感に耐えている
			PRINTFORMW その反応から、普段よりも敏感になっているように感じた
			PRINTFORML 一般的に、ある事をしてはいけない、と意識すると逆にそれらに対して過敏に反応してしまうようになるという
			PRINTFORMW 今の%ANAME(対象)%もそれと同じだった
			PRINTFORML 声を上げないように、快感を感じないように意識すればするほど
			PRINTFORMW %ANAME(対象)%の肉体はいつもより敏感に、%ANAME(MASTER)%の愛撫の手触りを感じ取ってしまっていた
			PRINTFORML 「んんっ♥…ふあっ…！　…あっ♥…んっ♥……っ！」
			PRINTFORMW %ANAME(MASTER)%は、声を抑えて可愛く喘ぐ%ANAME(対象)%を存分に撫で上げ、快感に慣らしていった…
			PRINTFORML ……
			PRINTFORMW 行為が終わったあと、%ANAME(対象)%はまぐわったわけでもないのに恍惚の表情で蕩けていた
			PRINTFORMW 「%ANAME(MASTER)%……また、これに…付き合ってね…♥」
			CALL FUCK(MASTER, "奉仕, 性技", "キス喪失")
			CALL FUCK(対象, "Ｂ, Ｃ, 欲望")
			CFLAG:対象:好感度 += 200
			CFLAG:対象:従属度 += 200
			CFLAG:対象:依存度 += 100
			CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が200上がった", カラー_シアン)
			CALL COLOR_PRINTL(@"%ANAME(対象)%の従属度が200上がった", カラー_シアン)
			CALL COLOR_PRINTL(@"%ANAME(対象)%の依存度が100上がった", カラー_シアン)
			KDVAR:対象:萃香_声を抑えて = 1
		ENDIF
		PRINTFORML
	;乳首責め
	CASE 1
		PRINTFORMW 深夜、%ANAME(対象)%がまた%ANAME(MASTER)%の部屋を訪ねてきた
		PRINTFORMW 「あ、あのさ…。また…、例の練習に付き合って欲しいんだけど……」
		PRINTFORML どうやらまた、セックス時に声を抑える練習をしたいようだ
		PRINTFORMW しおらしい態度で%ANAME(MASTER)%を見上げる%ANAME(対象)%は歳相応の少女に見える
		PRINTFORML %ANAME(MASTER)%は前回の続きをするため、%ANAME(対象)%を優しく抱き寄せた
		PRINTFORMW 「あ、あの……声出さないよう、頑張るから……優しくしてね……」
		PRINTFORML 
		PRINTFORMW ･･･
		PRINTFORMW 「ん…っ！　…♥…んん、…ふ…っ…あ…っ！…♥」
		PRINTFORMW %ANAME(対象)%はなるべく声を上げないように、きつく口をつぐみながら快感に耐えている
		PRINTFORML 前回は身体全体への愛撫だけで終わったが、今回は胸を中心にした責めを行っている
		PRINTFORMW %ANAME(MASTER)%は、小ぶりな%ANAME(対象)%の胸を掌全体でゆっくり撫でつけるように愛撫する
		PRINTFORML %ANAME(対象)%が声を上げないように意識するほどに、身体はいつもより敏感に愛撫の手触りを感じ取ってしまっていた
		PRINTFORMW やがて、小粒な乳首を中心に指先でなぞる様に、しかし決して乳首には触れないよう責める
		PRINTFORML 「…んっ♥…あ…っ…！　…ふっ♥…っ♥…っ！」
		PRINTFORMW %ANAME(対象)%は切なげな吐息を漏らす。あえて乳首を触らない焦らすような愛撫が、確実に快感を与えている
		PRINTFORML 「ん…っ…%ANAME(MASTER)%……っ」
		PRINTFORMW 潤んだ瞳で%ANAME(対象)%はその先を懇願する。今までずっとおあずけ状態だったのだ
		PRINTFORMW その乳先はすでにぷっくりと膨れ、綺麗な薄紅色の乳首が触られることを待ち望むように尖り勃っている
		PRINTFORML %ANAME(MASTER)%はついにその乳首を責める。激しくないよう、クニクニと優しくねじり転がすように摘む
		PRINTFORMW 「んっ！　んふぅうぅんっ…！　っ♥♥」
		PRINTFORMW けして強く摘んではいないが、今まで焦らしに焦らされた%ANAME(対象)%の乳首は、いつも以上に過敏になっていた
		PRINTFORML 優しくねじられる度、甘く痺れるような快感が乳先からじんわりと全身に広がり、身体を震わせる
		PRINTFORMW その淫靡な様に、%ANAME(MASTER)%は嗜虐的な感情が鎌首をもたげ、%ANAME(対象)%の乳首を摘む力を少し強くする
		PRINTFORMW 「はっ！　…んんんっ♥……ふっ…♥　%ANAME(MASTER)%…いいよ……もっとして…♥」
		PRINTFORML %ANAME(対象)%は、ついに触れられた乳首への快感に蕩けきり、さらなる責めを求めてきた
		PRINTFORMW その期待に応えるため、%ANAME(MASTER)%は%ANAME(対象)%の乳首を口に含めて舐め転がす
		PRINTFORML %ANAME(対象)%の乳首は%ANAME(MASTER)%の舌が触れるとさらに硬さを増し、乳輪も柔らかく盛り上がる
		PRINTFORMW コリコリした感触を味わうように、可愛らしく勃起した乳首を甘噛みしその先っぽを舌で存分に舐め転がし責め立てる
		PRINTFORML 「んひぃっ！　はっ♥…それっ…♥いいよぉ…っ♥」
		PRINTFORMW %ANAME(MASTER)%は、声を抑えて可愛く喘ぐ%ANAME(対象)%の胸を存分に責め、快感に慣らしていった…
		PRINTFORML
		PRINTFORMW ･･･
		PRINTFORMW 行為が終わったあと、%ANAME(対象)%は責められた乳首を自らこね回しながら恍惚の表情で蕩けていた……
		PRINTFORMW 「%ANAME(MASTER)%……また、これに…付き合ってね…♥」
		PRINTFORML
		CALL COLOR_PRINTW(@"%ANAME(対象)%の胸が敏感になりました", カラー_注意)
		TALENT:対象:Ｂ敏感 = 1
		CALL FUCK(MASTER, "奉仕, 性技", "キス喪失")
		CALL FUCK(MASTER, "奉仕, 性技", "キス喪失")
		CALL FUCK(対象, "Ｂ, 欲望")
		CALL FUCK(対象, "Ｂ, 欲望")
		CFLAG:対象:好感度 += 400
		CFLAG:対象:従属度 += 400
		CFLAG:対象:依存度 += 200
		CALL COLOR_PRINTL(@"%ANAME(対象)%の好感度が400上がった", カラー_シアン)
		CALL COLOR_PRINTL(@"%ANAME(対象)%の従属度が400上がった", カラー_シアン)
		CALL COLOR_PRINTL(@"%ANAME(対象)%の依存度が200上がった", カラー_シアン)
		KDVAR:対象:萃香_声を抑えて ++
		PRINTFORML
	;クリ責め
	CASE 2
		PRINTFORMW 深夜、%ANAME(対象)%がまた%ANAME(MASTER)%の部屋を訪ねてきた
		PRINTFORMW 「あ、あのさ…。また…、例の練習に付き合って欲しいんだけど……」
		PRINTFORML どうやらまた、セックス時に声を抑える練習をしたいようだ
		PRINTFORMW しおらしい態度で%ANAME(MASTER)%を見上げる%ANAME(対象)%は歳相応の少女に見える
		PRINTFORML %ANAME(MASTER)%は前回の続きをするため、%ANAME(対象)%を優しく抱き寄せた
		PRINTFORMW 「あ、あの……声出さないよう、頑張るから……優しくしてね……♥」
		PRINTFORML 
		PRINTFORMW ･･･
		PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%の股間に顔を埋め、秘部を舌でゆっくり舐め上げている
		PRINTFORMW 「んん～っ♥…！　…♥…ふーっ！　…っ♥…んんっ♥…っ…！！　…ふっ！　…んん～♥♥」
		PRINTFORMW %ANAME(対象)%は自らの両手で口を塞ぎながら必死に快感に耐え、できるだけ声を上げないようにしている
		PRINTFORML しかし、ただでさえ敏感なクリトリスが声を上げてはならない制約により、
		PRINTFORMW いっそう過敏に快感を感じ取ってしまう
		PRINTFORML 両手で強く口を塞いでいないと、大きな嬌声が響き渡ってしまうことだろう
		PRINTFORMW 「ンくっ…～っ！　♥♥んふぅぅっ♥…っ！！　っ♥♥」
		PRINTFORML %ANAME(MASTER)%はゆっくり優しく、%ANAME(対象)%のラビアのヒダを丁寧に舐めている
		PRINTFORMW %ANAME(対象)%の陰裂は綺麗なピンク色で、舌が触れるたび膣口が%ANAME(MASTER)%を求めるようにひくつく
		PRINTFORML そして目の前でクリトリスが自己主張するように膨れ上がる
		PRINTFORMW こっちも責めて欲しい　と言わんばかりに…
```
