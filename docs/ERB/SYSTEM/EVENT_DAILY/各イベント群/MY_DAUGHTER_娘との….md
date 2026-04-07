# SYSTEM/EVENT_DAILY/各イベント群/MY_DAUGHTER_娘との….ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/MY_DAUGHTER_娘との….ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_MY_DAUGHTER_RATE, EVENT_DAILY_MY_DAUGHTER_DECISION, EVENT_DAILY_MY_DAUGHTER_GENRE, EVENT_DAILY_MY_DAUGHTER_SETTARGET, EVENT_DAILY_MY_DAUGHTER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_MY_DAUGHTER_RATE()
RETURN 50


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_MY_DAUGHTER_DECISION()
SIF !HAS_PENIS(MASTER)
	RETURN 0
;同勢力で捕虜でないあなたの娘がいる
LOCAL:1 = 0
FOR LOCAL:0, 0, CHARANUM
	SIF (CFLAG:(LOCAL:0):所属 == CFLAG:MASTER:所属 && !CFLAG:(LOCAL:0):捕虜先) && (ID_TO_CHARA(CFLAG:(LOCAL:0):父親) == MASTER && CFLAG:(LOCAL:0):特殊状態 == 0 && CFLAG:(LOCAL:0):行動不能状態 == 0 && !IS_MALE(LOCAL:0))
		LOCAL:1 ++
NEXT
SIF LOCAL:1 < 1
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_MY_DAUGHTER_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_MY_DAUGHTER_SETTARGET()

;同勢力で捕虜でないあなたの娘からランダム、対象がいない場合はイベントキャンセル
FOR LOCAL, 0, CHARANUM
	IF (CFLAG:(LOCAL:0):所属 == CFLAG:MASTER:所属 && !CFLAG:(LOCAL:0):捕虜先) && (ID_TO_CHARA(CFLAG:(LOCAL:0):父親) == MASTER && CFLAG:(LOCAL:0):特殊状態 == 0 && CFLAG:(LOCAL:0):行動不能状態 == 0 && !IS_MALE(LOCAL:0))
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL 
		DAILY_TARGET_NUM ++
	ENDIF
NEXT

SIF DAILY_TARGET_NUM == 0
	RETURN 0

RETURN 1

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_MY_DAUGHTER()
#DIM 対象

LOCAL = 0

対象 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)

CFLAG:対象:面識 = 1


IF TALENT:対象:合意
	;普通の恋人ックスルート。合意あり
	PRINTFORML 夜遅く、%ANAME(MASTER)%の部屋を誰かが訪ねてきた…
	PRINTFORML 扉を開けると、薄手のネグリジェだけを纏った、%ANAME(MASTER)%の娘である%ANAME(対象)%が立っていた
	PRINTFORML %ANAME(対象)%は潤んだ瞳で%ANAME(MASTER)%を見つめながら裾を捲り上げ、何も身に着けていない秘所を見せつけ、
	SELECTCASE RAND:3
		CASE 0
			PRINTFORML 情欲を持て余して火照った身体を%ANAME(MASTER)%の手で鎮めて欲しい、とおねだりしてきた…
		CASE 1
			PRINTFORML 淫らに育ってしまった身体を%ANAME(MASTER)%の手で躾けて欲しい、とおねだりしてきた…
		CASE 2
			PRINTFORML %ANAME(MASTER)%を欲して疼く雌穴を責任をもって調教し直して欲しい、とおねだりしてきた…
	ENDSELECT 
	PRINTFORML %ANAME(MASTER)%は――
	CALL ASK_YN("受け入れる" ,"拒否する")
	IF RESULT == 0
		PRINTFORML 世話の焼ける子だ、と思いながら%ANAME(MASTER)%は娘を部屋に招き入れ、扉を閉じた
		PRINTFORML %ANAME(MASTER)%は自分から欲しがる淫らな娘を優しく叱りながら、立ったまま雌穴を奥までほじくり返した
		PRINTFORML 感じる所を刺激され、%ANAME(対象)%は甘く蕩けた声で何度も謝りながらがくがくと腰を震わせる…
		PRINTFORMW 指を引き抜いた%ANAME(MASTER)%は、すっかり硬くなったペニスを取り出して娘に突きつけた
		PRINTFORML 
		PRINTFORML %ANAME(対象)%は恭しく跪いて母を孕ませた剛直にむしゃぶりつき、唇と舌で丹念な奉仕を始めた
		PRINTFORML %ANAME(MASTER)%は良く出来た娘の姿に満足感を得ながら、頭を掴んで喉奥まで無遠慮にペニスをねじ込んだ
		PRINTFORML %ANAME(対象)%は苦しそうにしつつも%ANAME(MASTER)%の要求に応え、喉奥をすぼめてペニスをしごき射精を導いた
		PRINTFORML %ANAME(MASTER)%はすっかり淫らな奉仕が板についた娘の姿に背徳的な悦びを覚えつつ、
		PRINTFORML こみ上げる射精感のままに%ANAME(対象)%の口内に白濁をぶち撒けてやった
		PRINTFORML %ANAME(対象)%は長々とした射精を受け止めると、喉を鳴らして精液を飲み込み、%ANAME(MASTER)%に口内を見せつけた
		PRINTFORMW 頭を撫でてやると%ANAME(対象)%は嬉しげに目を細めた…
		PRINTFORML 
		PRINTFORML 無論その程度の行為では、お互い昂ぶりは収まらない
		PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%をベッドに寝かせ、ゆっくりと覆い被さった
		PRINTFORML %ANAME(対象)%は自分から指で陰唇を広げて、物欲しげにひくつく肉襞を%ANAME(MASTER)%に見せつけおねだりした
		PRINTFORML %ANAME(MASTER)%は求めに応じ、ガチガチに勃起したペニスを娘の奥に沈めていった…
		PRINTFORMW …
		PRINTFORML 
		SELECTCASE RAND:3
			CASE 0
				PRINTFORML 仰向けになった%ANAME(MASTER)%に%ANAME(対象)%が跨がり、蕩けた声を上げながら自ら腰を振っている…
				PRINTFORML %ANAME(MASTER)%のペニスの形に合わせて躾けられた膣肉は淫らに蠢き、物欲しげにむしゃぶりついてくる
				PRINTFORML 射精が近いことを敏感に察した%ANAME(対象)%は%ANAME(MASTER)%の胸に倒れ込み、艶かしく腰を揺らしながら子種をせがんだ
				PRINTFORML 可愛らしい娘のおねだりに応え、%ANAME(MASTER)%は尻を鷲掴みにして激しく突き上げると同時に射精した
				PRINTFORML 子宮に沸騰する白濁を叩きつけられた%ANAME(対象)%は激しく悶え、父の子を孕む未来を幻視しながら絶頂した…
			CASE 1
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%に、壁に手をついて尻を向けさせ、出来る限りいやらしくおねだりするよう命じた
				PRINTFORML さすがに恥じらっていた%ANAME(対象)%だったが、入り口を亀頭でぬちぬちと撫でてやると我慢できなくなったのか、
				PRINTFORML 「淫乱に育ってしまった娘の雌穴を、お父様のペニスで奥まで犯して躾けて下さい♥」と叫んだ
				PRINTFORML 淫らに育った娘の姿に%ANAME(MASTER)%はぞくぞくと背筋を震わせつつ、いきり立ったペニスを突き込んだ
				PRINTFORML 最奥まで一気に貫かれた%ANAME(対象)%は獣じみた嬌声を上げつつ、びくびくと背筋を震わせてイキ狂った…
			CASE 2
				PRINTFORML %ANAME(MASTER)%は仰向けに寝かせた%ANAME(対象)%に覆い被さり、子宮を押し潰すような勢いで責め立てた
				PRINTFORML ごりゅごりゅと膣肉を掘削する剛直に、%ANAME(対象)%は声にならない叫びを上げながらイキ狂い続けている
				PRINTFORML オナホのように乱暴に使われている雌穴は、それでも健気により深く迎え入れようと吸い付いてくる
				PRINTFORML 緩んだ子宮口に先端をめり込ませると、%ANAME(対象)%は全身で%ANAME(MASTER)%に抱きつき呂律の回らない舌で中出しをせがんだ
				PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を強く抱き締め、その日一番濃い精液で子宮内を隅から隅まで陵辱した…
			ENDSELECT 
		PRINTFORMW …
		PRINTFORML 
		PRINTFORML その後も一晩中%ANAME(MASTER)%は%ANAME(対象)%と交わり続けた子宮を子種でたっぷりと満たしてやった
		PRINTFORML 愛欲の赴くままに、%ANAME(対象)%は父の肉棒を咥え込み、%ANAME(MASTER)%は娘の身体を貪った
		PRINTFORMW 血の繋がりなど二人の前では何の意味も持たず、貪るようにお互いを求め合った…
		PRINTFORML 
		CALL FUCK_MAKELOVE(対象, GET_ID(MASTER), @"%ANAME(MASTER)%の唇", ANAME(MASTER))
		CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失", 0, "", "", @"%ANAME(対象)%の膣")
		CFLAG:対象:好感度 += 300
		CFLAG:対象:従属度 += 100
		CFLAG:対象:依存度 += 100
	ELSEIF RESULT == 1
		PRINTFORML %ANAME(MASTER)%は、今日はもう遅いから、と理由をつけて%ANAME(対象)%を帰らせた
		PRINTFORML %ANAME(対象)%は頬を膨らませながらも、%ANAME(MASTER)%の言うことに従った
	ENDIF
	PRINTFORMW 
	RETURN 1
	
ELSEIF CFLAG:対象:好感度 < 2500
	;普通の夜会話ルート。好感度が一定値以下(恋慕ありであっても)
	PRINTFORML 夜遅く、%ANAME(MASTER)%の部屋を誰かが訪ねてきた…
	PRINTFORML 扉を開けると、%ANAME(MASTER)%の娘である%ANAME(対象)%が立っていた。寝付けないので、雑談しに来たようだ
	PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を部屋に招き入れた
	PRINTFORMW …
	PRINTFORML 
	SELECTCASE RAND:6
		CASE 0
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%から武術の鍛錬についての質問を受けた
			PRINTFORML 折角なので、%ANAME(MASTER)%と%ANAME(対象)%は練兵場に移動して組手を行い、充実した時間を送った…
			CALL PRINT_ADD_EXP(対象, "武闘経験値", RAND:10 + 1, 1)
			CALL TRAIN_AUTO_ABLUP
		CASE 1
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%から拠点の守り方について質問を受けた
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%に、模型を使いながら拠点防衛の心得を説いた…
			CALL PRINT_ADD_EXP(対象, "防衛経験値", RAND:10 + 1, 1)
			CALL TRAIN_AUTO_ABLUP
		CASE 2
			PRINTFORML %ANAME(MASTER)%と%ANAME(対象)%は将棋を指すことにした
			PRINTFORML 勝負を通じて、%ANAME(対象)%は知略に対する理解をより深めたようだ…
			CALL PRINT_ADD_EXP(対象, "知略経験値", RAND:10 + 1, 1)
			CALL TRAIN_AUTO_ABLUP
		CASE 3
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%と最近の市井の様子について話した
			PRINTFORML 会話を通じて、%ANAME(対象)%は政治に対する理解をより深めたようだ…
			CALL PRINT_ADD_EXP(対象, "政治経験値", RAND:10 + 1, 1)
			CALL TRAIN_AUTO_ABLUP
		CASE 4
			PRINTFORML %ANAME(MASTER)%は%ANAME(対象)%を誘って拠点を抜け出し、夜遅くまで営業している贔屓の屋台に連れていった
			PRINTFORML 秘密の夜遊びで味わう夜食に、%ANAME(対象)%は目を輝かせ、舌鼓を打った…
			CALL PRINT_ADD_EXP(対象, "料理経験値", RAND:10 + 1, 1)
			CALL TRAIN_AUTO_ABLUP
		CASE 5
			PRINTFORML %ANAME(MASTER)%と%ANAME(対象)%は、最近市井で流行っている流行曲について話をした
			PRINTFORML 年頃の娘だけあってそういう話は好きなのか、%ANAME(対象)%は楽しげに言葉を弾ませた…
			CALL PRINT_ADD_EXP(対象, "歌唱経験値", RAND:10 + 1, 1)
			CALL TRAIN_AUTO_ABLUP
	ENDSELECT 
	
	IF IS_LOVER(対象)
		PRINTFORML %ANAME(対象)%は熱っぽい視線を%ANAME(MASTER)%に送っている…
		CFLAG:対象:好感度 += 200
		CFLAG:対象:依存度 += 100
		ELSE
		CFLAG:対象:好感度 += 100
		CFLAG:対象:依存度 += 50
	ENDIF
	PRINTFORMW 
	RETURN 1
ENDIF

;ここに来るのは好感度一定以上かつ合意なし
;通常は恋慕取得済みであることを想定する
;好感度だけ高く依存度が低い場合は恋慕なしでも通るかもしれないがそれも一応許容する

;前段：ルート決定

```
