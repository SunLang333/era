# SYSTEM/EVENT_DAILY/各イベント群/REPAYMENT_通い妻.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/REPAYMENT_通い妻.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_REPAYMENT_RATE, EVENT_DAILY_REPAYMENT_DECISION, EVENT_DAILY_REPAYMENT_GENRE, EVENT_DAILY_REPAYMENT, EVENT_DAILY_REPAYMENT_0, EVENT_DAILY_REPAYMENT_1, EVENT_DAILY_REPAYMENT_2, EVENT_DAILY_REPAYMENT_3, EVENT_DAILY_REPAYMENT_4; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_REPAYMENT_RATE()
RETURN (DVAR:恩返し_発生フラグ || DVAR:恩返し_通い妻フラグ > 0 ? 250 # 30)


;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_REPAYMENT_DECISION()
SIF DVAR:恩返し_発生フラグ == -1
	RETURN 0
SIF DAY < 10
	RETURN 0
SIF !HAS_PENIS(MASTER)
	RETURN 0
RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_REPAYMENT_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体　ハブとして扱う
;---------------------
@EVENT_DAILY_REPAYMENT()
#DIM 対象

TRYCALLFORM EVENT_DAILY_REPAYMENT_%TOSTR(DVAR:恩返し_発生フラグ)%
SIF RESULT
	DVAR:恩返し_発生フラグ ++
RETURN 1

;---------------------
;初回
;---------------------
@EVENT_DAILY_REPAYMENT_0()
#DIM 対象
対象 = RAND(1, VARSIZE("恩返し_種類"))
PRINTFORMW 久々の休日
PRINTFORMW 森林を散歩中、%ANAME(MASTER)%は微かな呻き声を耳にした
PRINTFORMW 誰かが怪我でもしているのだろうか？
PRINTFORM 茂みをかき分けて声のした方に進むと、罠にかかった%恩返し_種類:対象%を見つけた
PRINTFORMW %恩返し_種類:対象%は%ANAME(MASTER)%を見ると、警戒する様に身構えた
PRINTFORMW 罠はがっちりと%恩返し_種類:対象%を捕まえており、自力では抜け出せそうにはない
PRINTFORMW よく見るとだいぶ古い罠で、誰かが仕掛けたまま忘れてしまった物の様だ
PRINTFORMW どうしようか……
CALL ASK_MULTI("助けてやる", "放っておく", "晩御飯にする")
SELECTCASE RESULT
	CASE 0
		PRINTFORMW %ANAME(MASTER)%は%恩返し_種類:対象%を哀れに思い、助けてやることにした
		PRINTFORMW %恩返し_種類:対象%は罠から解放されると、ジッと%ANAME(MASTER)%を見つめていたが
		PRINTFORMW やがて踵を返し、一目散に逃げて行った
		PRINTFORMW 良い事をすると気分が良い、%ANAME(MASTER)%は機嫌よく散歩に戻った
		DVAR:恩返し_動物番号 = 対象
	CASE 1
		PRINTFORMW 下手に関わることもないだろう
		PRINTFORMW %ANAME(MASTER)%はその場を後にした
		DVAR:恩返し_発生フラグ = -1
		RETURN 0
	CASE 2
		PRINTFORMW %ANAME(MASTER)%はとどめを刺すと持ち帰り、部下に振る舞った
		CALL PRINT_ADD_EXP(MASTER, EXPNAME:(GET_EXP(GETNUM(ABL, "料理"))), 5, 1)
		CALL TRAIN_AUTO_ABLUP(MASTER)
		DVAR:恩返し_発生フラグ = -1
		RETURN 0
ENDSELECT
RETURN 1

;---------------------
;2回目
;---------------------
@EVENT_DAILY_REPAYMENT_1()
PRINTFORMW 仕事をしていると来客を告げられた
PRINTFORMW 会ってみるとどこにでもいそうな村娘だった
PRINTFORMW 「…初めまして、以前こちらの兵の方に助けていただいた者です」
PRINTFORMW 「その節はとても助かりました、なので何か恩返しができないかと伺いました」
PRINTFORMW 礼儀正しく良い娘だと感心する
PRINTFORMW しかし民を助けるのは兵としては当然の事だ、気にしないで良いと告げる
PRINTFORMW 「でも…それでは私の気持ちがおさまりません、きっとお役にたちますから、お願いします！」
PRINTFORMW 娘は真剣な表情で%ANAME(MASTER)%に食い下がる
PRINTFORMW ここまで意思が固いならば、気が済むようにさせた方が良いかもしれない
PRINTFORMW どうしようか……
CALL ASK_YN("仕事を手伝ってもらう", "やはり断る")
IF RESULT == 1
	PRINTFORMW やはり部外者に手伝ってもらう訳にもいかないだろう
	PRINTFORMW 気持ちだけ受け取っておくと言うと、少女は暫く食い下がっていたが
	PRINTFORMW やがて名残惜しそうに%ANAME(MASTER)%を見つめると、肩を落として帰って行った
	DVAR:恩返し_発生フラグ = -1
	RETURN 0
ENDIF

PRINTFORMW それなら簡単な仕事を手伝ってもらうとしよう
PRINTFORMW 「ありがとうございます！頑張ります！」
PRINTFORMW 少女の顔がパァと明るくなり、勢いよく%ANAME(MASTER)%に抱きついてきた
PRINTFORMW 「あっ、ご、ごめんなさい…嬉しくてつい、えへへ…」
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
PRINTFORMW 少女のおかげで仕事が捗った
SELECTCASE RAND:3
	CASE 0
		SETCOLOR カラー_オレンジ
		PRINTFORML 兵数が500人増えた！
		RESETCOLOR
		COUNTRY_SOLDIER:(CFLAG:MASTER:所属) += 500
	CASE 1
		SETCOLOR カラー_オレンジ
		PRINTFORML 資金が1000増えた！
		RESETCOLOR
		MONEY += 500
	CASE 2
		SETCOLOR カラー_オレンジ
		PRINTFORML 評判が少し上がった！
		RESETCOLOR
		FOR LOCAL, 1, MAX_COUNTRY
			SIF IS_COUNTRY(LOCAL)
				CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, 30, 0)
		NEXT
ENDSELECT
PRINTFORMW 少女に礼を告げると、嬉しそうに笑った
PRINTFORMW 「えへへ、%ANAME(MASTER)%のお役にたててよかったです…」
PRINTFORMW はて、助けたのは兵の者で自分ではなかったと思うが
PRINTFORMW しかしそんな疑問を投げかける前に、彼女は元気よく手を振って去って行った
RETURN 1

;---------------------
;3回目
;---------------------
@EVENT_DAILY_REPAYMENT_2()
PRINTFORMW 休日、%ANAME(MASTER)%の家に客が訪れた
PRINTFORMW 「こんにちは、またお手伝いに来ました」
PRINTFORMW 以前手伝いに来た娘だった、どうしてこの家がわかったのだろうか
PRINTFORMW 「えっと、宮殿に行ったらお休みだと言われて、お家を教えてもらいました」
PRINTFORMW 我が軍の個人情報は軽すぎやしないか、ふとそんなことを思う
PRINTFORMW しかしお礼ならこの前の手伝いで充分だと遠慮すると、しょんぼりとしてしまった
PRINTFORMW 「それじゃあ、えと…お食事を作ります！お願いします！」
PRINTFORMW 自分がそんな事までしてもらう理由もないが、少女の気持ちを無下に断るのもどうかと悩む
PRINTFORMW どうしようか……
CALL ASK_YN("御飯を作ってもらう", "断る")
IF RESULT == 1
	PRINTFORMW 気持ちだけ受け取っておくと言うと、少女は暫く食い下がっていたが
	PRINTFORMW やがて名残惜しそうに%ANAME(MASTER)%を見つめると、肩を落として帰って行った
	DVAR:恩返し_発生フラグ = -1
	RETURN 0
ENDIF

PRINTFORMW それで彼女の気が済むのならばいいだろう
PRINTFORMW 「はい、腕によりをかけて作りますね！」
PRINTFORMW 彼女は嬉しそうに顔をほころばせると、張り切って台所へ向かった
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
PRINTFORMW 娘の料理は素朴な味付けながらも中々のものだった
PRINTFORMW 張り切り過ぎたのか、少々量が多かったが
PRINTFORMW 「えへへ…お口にあったみたいで、嬉しいです」
PRINTFORML 「えと、食後にお酒を用意しました、お酌しますね…どうぞ」
PRINTFORMW 断りきれずに酌をされるままに酒を飲んでいると、気づけばすっかり暗くなっていた
PRINTFORMW そろそろ家に帰らなくていいのか訪ねると、何やら言葉を濁される
PRINTFORMW 家まで送っていこうと立ち上がろうとしたら、いきなり彼女に縋り付かれた
PRINTFORML 「いきなりごめんなさい……でも、帰りたくないんです……」
PRINTFORMW 突然の事に戸惑っていると、%ANAME(MASTER)%に縋り付いたまま瞳を潤ませ見上げてきた
PRINTFORML 「…お願いします…私を抱いてくださいませんか？」
PRINTFORMW 急に何を言い出すのか、%ANAME(MASTER)%は彼女を落ち着かせようとする
PRINTFORML 「あ、あの、私、%ANAME(MASTER)%の事が…あの時から、その…」
PRINTFORML 顔を真っ赤にしながら絞り出すような声で訴えてくる
PRINTFORMW 真剣な彼女の言葉に、%ANAME(MASTER)%は少々訝しみながらも黙って話を聞くしかなかった
PRINTFORML 「迷惑ですか…？それとも、私、魅力がないですか…？」
PRINTFORMW しばし彼女と目を合わせる
PRINTFORMW …その瞳に、嘘偽りはないようだ
PRINTFORML 女の子にここまで迫られて、断ることもできない
PRINTFORMW %ANAME(MASTER)%は縋り付く彼女の手を優しく握ると、唇を重ねた
PRINTFORML 「んっ……！」
PRINTFORMW 彼女はピクッと微かに身を震わせながらも、受け入れる
PRINTFORMW 緊張をほぐす為に服の上から、努めて優しく彼女の身体を愛撫する
PRINTFORML 「んっ、んんっ…ぁっ……はぁ……」
PRINTFORMW 重ねた唇の間から微かに甘い吐息が漏れ、%ANAME(MASTER)%の頬にかかる
PRINTFORML 「んっ！あん…あっ、んっ……くぅん……っ！」
PRINTFORMW 服の中に手をもぐりこませ、指で秘所をなぞると、微かに湿っていた
PRINTFORMW それを確かめた%ANAME(MASTER)%は唇を重ねたまま、優しく彼女を押し倒した
CALL FUCK(MASTER, "Ｃ, 射精, Ｖ挿入", "童貞喪失, キス喪失", 0, "村娘の唇", "", "村娘の膣")
PRINTFORML ・
PRINTFORML ・
PRINTFORMW ・
PRINTFORMW 翌朝、目が覚めると彼女の姿はなかった
PRINTFORMW 枕元にまだ温かい朝食が準備されている、どうやら彼女が作っていったらしい
PRINTFORMW まだ眠気の残る頭を無理矢理起こし、冷める前に食事をいただくことにした
RETURN 1


;---------------------
;4回目
;---------------------
@EVENT_DAILY_REPAYMENT_3()

PRINTFORMW 「あっ…こ、こんにちは…」
PRINTFORMW 彼女が再びやってきた、やや照れくさそうにしている
```
