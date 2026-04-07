# SYSTEM/EVENT_DAILY/各イベント群/ADULTFILM_将校への取材.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/ADULTFILM_将校への取材.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_ADULTFILM_RATE, EVENT_DAILY_ADULTFILM_DECISION, EVENT_DAILY_ADULTFILM_GENRE, EVENT_DAILY_ADULTFILM, SELECT_CHARA_LIST_SHOW_LOGIC_ADULTFILM, SELECT_CHARA_LIST_SELECT_LOGIC_ADULTFILM; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_ADULTFILM_RATE()
RETURN (DVAR:AV撮影_進行度 > 0 ? 330 # 30)

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_ADULTFILM_DECISION()
#DIM 対象

対象 = 0

SIF DAY < 10
	RETURN 0
SIF DVAR:AV撮影_進行度 == 10
	RETURN 0
FOR LOCAL, 0, CHARANUM
	;捕虜でなく、死んでおらず、AV女優未所持者の女が自国にいるかどうか判定
	SIF !CFLAG:LOCAL:捕虜先 && CFLAG:LOCAL:特殊状態 != 特殊状態_死亡 && !(GETBIT(TALENT:LOCAL:淫乱系, 素質_淫乱_ＡＶ女優)) && IS_FEMALE(LOCAL)
		対象 ++
NEXT
SIF 対象 < 1
	RETURN 0
RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_ADULTFILM_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;---------------------
@EVENT_DAILY_ADULTFILM
#DIM 対象

IF DVAR:AV撮影_進行度 > 0
	対象 = ID_TO_CHARA(DVAR:AV撮影_対象ID)
	IF 対象 == -1 || CFLAG:対象:特殊状態 == 特殊状態_死亡
		DVAR:AV撮影_対象ID = 0
		DVAR:AV撮影_中毒進行度 = 0
		DVAR:AV撮影_進行度 = 0
	ENDIF
ENDIF

IF DVAR:AV撮影_進行度 == 0
	;%ANAME(MASTER)%が堕ちている場合
	IF GETBIT(TALENT:MASTER:淫乱系, 素質_淫乱_ＡＶ女優) && IS_FEMALE(MASTER) && DVAR:AV撮影_発生フラグ == 1
		PRINTFORML 再びAV撮影のプロデューサーがやって来た
		PRINTFORMW 彼は%ANAME(MASTER)%を見るとニヤニヤと笑いながら当り前の様に尻を揉みしだいてきた
		PRINTFORML %ANAME(MASTER)%は嬉しそうに喘ぎ声を上げ身動ぎしながらも抵抗せずに受け入れる
		PRINTFORML 「またお世話になりますよぉ、視聴者は常に新しいアイドルを求めているんです」
		PRINTFORMW 耳元で囁かれた%ANAME(MASTER)%はブルッと背筋を震わせた
	;２回目以降
	ELSEIF DVAR:AV撮影_発生フラグ == 1
		PRINTFORMW 再び密着ドキュメンタリーの撮影を申し込まれた
		PRINTFORML 「この企画は当たりますよ！そうすれば軍のアピールにもなるでしょう！」
		PRINTFORMW プロデューサーを名乗る男は笑顔でそう力説するが…
	;初めての場合
	ELSE 
		PRINTFORML ある日取材の申し込みが来た
		PRINTFORML なんでも将校に密着したドキュメンタリーを撮りたいらしい
		PRINTFORML 「この企画は当たりますよ！そうすれば軍のアピールにもなるでしょう！」
		PRINTFORMW プロデューサーを名乗る男は笑顔でそう力説するが…
	ENDIF
	PRINTFORML どうしよう？
	CALL ASK_YN("引き受ける" ,"断る")
	IF RESULT == 1
		$OKOTOWARI
		;%ANAME(MASTER)%が堕ちている場合
		IF GETBIT(TALENT:MASTER:淫乱系, 素質_淫乱_ＡＶ女優) && DVAR:AV撮影_発生フラグ == 1
			PRINTFORML しかし今は戦争に忙しく、協力するのは難しい
			PRINTFORML %ANAME(MASTER)%が申し訳なさそうに断ると、彼は露骨に舌打ちをした
			IF HAS_VAGINA(MASTER)
				PRINTFORMW そして腹いせとばかりに%ANAME(MASTER)%を寝室に連れ込むと、無責任に何度も種付けをしていった
				CALL FUCK(MASTER, "Ｃ, Ｖ, Ｂ, Ｍ, 性交, 精愛, 奉仕, 口淫, Ｖ性交", "キス喪失, 処女喪失, 膣内射精, 口内射精, CFLAG減少", GET_SPERM_ID("AV男優"), @"男優の\@RAND:2 ? ペニス # 唇\@", "AV男優", "", "強姦")
			ENDIF
		ELSE
			PRINTFORML 軍事機密を漏らされるかもしれない
			PRINTFORMW やはり今回は断らせてもらう事にした
			SIF DVAR:AV撮影_発生フラグ != 1
				DVAR:AV撮影_発生フラグ = 1
		ENDIF
		RETURN
	ELSEIF RESULT == 0
		;%ANAME(MASTER)%が堕ちている場合
		IF GETBIT(TALENT:MASTER:淫乱系, 素質_淫乱_ＡＶ女優) && DVAR:AV撮影_発生フラグ == 1
			PRINTFORMW もちろん引き受けさせてもらう事にした
			PRINTFORML 誰を選ぼうか？
		ELSE
			PRINTFORML その笑顔に多少うさん臭さを感じたものの協力する事にした
			PRINTFORML 「素晴らしい！きっとそう言ってくださると思ってましたよ！」
			PRINTFORML 「それでは取材をさせてもらえる方を紹介してくださいね
			PRINTFORMW 「女性の方でお願いしますね！そちらの方が視聴者の受けがいいのですよ、えぇ！」
			PRINTFORML 誰を選ぼうか？
		ENDIF
		CALL SINGLE_DRAWLINE
		CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("ADULTFILM", "ADULTFILM")
		対象 = RESULT
		IF RESULT < 0
			GOTO OKOTOWARI
		ELSEIF 対象 == MASTER
			PRINTFORMW %ANAME(対象)%自身が取材を受ける事にした
		ELSE
			PRINTFORMW %ANAME(対象)%に取材を受けさせる事にした
		ENDIF
		PRINTFORML 彼は%ANAME(対象)%を値踏みする様に眺めた後ニンマリと笑った
		PRINTFORMW %ANAME(対象)%は早速男に促されるままに取材へと向かった
	ENDIF
	PRINTFORML 
	PRINTFORMW …緊張していたが、変哲もない普通の取材だった
	PRINTFORML 彼等は軍や私生活に関する質問をいくつかした後
	PRINTFORML 日常の業務や訓練の様子を熱心に撮影していった
	PRINTFORML 取材中、クルーとの会話が弾み仲良くなれた
	PRINTFORMW %ANAME(対象)%は次の取材日の確認をして彼らと別れた
	PRINTFORML 
	FOR LOCAL, 1, MAX_COUNTRY
		CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, 15, -15)
	NEXT
	CALL COLOR_PRINTW("その日の取材内容が放送されると他国の評価が上がった", カラー_注意)
	MONEY += 5000
	CALL COLOR_PRINTW("出演料として金5000を受け取った", カラー_注意)
	DVAR:AV撮影_進行度 ++
	DVAR:AV撮影_対象ID = GET_ID(対象)
	DVAR:AV撮影_発生フラグ = 1
ELSEIF DVAR:AV撮影_進行度 == 1
	PRINTFORMW 再び密着取材がやって来た
	PRINTFORML 今回も前回と同じようにいくつかの質問をされる
	PRINTFORML 「ところでこういったところにいると、女性としては色々と不便ではないでしょうか？」
	PRINTFORML 流ちょうに受け答えしていた%ANAME(対象)%だが、突然の毛色が違う質問に一瞬戸惑った
	PRINTFORMW 「つまり男性からの視線とか、あるいはそう、生理などについての話ですな」
	PRINTFORML 直球の質問に%ANAME(対象)%は思わず顔が赤くなるのを感じた
	CALL ASK_YN("冷静に答える" ,"怒って怒鳴りつける")
	IF RESULT == 0
		PRINTFORML しかし%ANAME(対象)%は努めて冷静に答えた
		PRINTFORML 「そうですか、なるほど…女性としての悩みもやはりあるようですねぇ」
		PRINTFORMW どことなく彼の言葉に蔑みを感じながらも%ANAME(対象)%は平静を装った
	ELSEIF RESULT == 1
		PRINTFORML セクハラまがいの質問に%ANAME(対象)%は怒って彼を怒鳴りつけた
		PRINTFORML 「いえいえ、誤解しないでください！」
		PRINTFORML 「これも女性向けのちゃんとした取材ですよ、ほら皆さんももっと女性の任官が増えると嬉しいでしょう？」
		PRINTFORMW 「その為にもこうした生の声を届けることが大切なんですよ、えぇ」
		PRINTFORML 彼は愛想笑いを浮かべながらそう説明する
		PRINTFORML …確かに彼の言葉にも一理あるかもしれない
		PRINTFORMW %ANAME(対象)%は怒ったことを謝罪すると、若干言葉に詰まりながら彼の質問に答えた
	ENDIF
	PRINTFORML …その後もいくつか"女性向け"の質問が続いた
	PRINTFORML 中にはかなりきわどく感じるものもあったが一度引き受けた手前、%ANAME(対象)%はすべて正直に答えた
	PRINTFORML …取材後、今回はかなり良い画が取れたとプロデューサーから絶賛された
	PRINTFORMW %ANAME(対象)%は複雑な感情を抱きながらも次の取材日の確認をして彼らと別れた
	PRINTFORML 
	COUNTRY_SOLDIER:(CFLAG:対象:所属) += 500 + 100 * (RAND:10 + RAND:10 + 6)
	CALL COLOR_PRINTW("その日の取材内容が放送されると志願兵が増えた", カラー_注意)
	MONEY += 5000
	CALL COLOR_PRINTW("出演料として金5000を受け取った", カラー_注意)
	DVAR:AV撮影_進行度 ++
ELSEIF DVAR:AV撮影_進行度 == 2
	PRINTFORMW 再び密着取材がやって来た
	PRINTFORML プロデューサーは相変わらずの笑顔で%ANAME(対象)%に近づいてくる
	PRINTFORML 前回の事で警戒しながらも%ANAME(対象)%は仕事として切り替え対応した
	PRINTFORMW …しかしその日の取材は特に何もなかった
	PRINTFORML 前回の事などなかったかのような普通の取材に%ANAME(対象)%はやや拍子抜けとなる
	PRINTFORML 質疑応答を終え、%ANAME(対象)%が仕事の為に着替えようと部屋に向かうと彼らもついてきた
	PRINTFORML 「密着取材ですからねぇ、将校をより知る為にも部屋の中や軍の備品、生活の様子も映しておかないと」
	PRINTFORMW 「大丈夫ですって、ちゃんと編集しますから、プライベートには注意しますよ、えぇ」
	PRINTFORML %ANAME(対象)%の抗議に対しても彼は聞く耳を持たず当り前の様にそう答える
	PRINTFORML 結局のらりくらりとした彼の態度に%ANAME(対象)%の方が折れ、部屋の中に入られてしまった
	PRINTFORML 撮影という名目で部屋の隅々まで取られてしまい、%ANAME(対象)%は羞恥でめまいがした
	PRINTFORMW さらに追い打ちの様に彼らは%ANAME(対象)%にいつも通りに着替えをするように催促してきた
	PRINTFORML それは流石に断ろうとしたが、足元しか映さないと一点張りの彼らに再び折れてしまった
	PRINTFORML 結局%ANAME(対象)%は部屋の隅で着替えをする羽目になった
	PRINTFORML 彼らの視線を背中に感じながらもじもじと着替える%ANAME(対象)%は、カメラに全て撮られている事にも気づかなかった
	PRINTFORMW …その日の取材はいつもより過激に密着され、色々と恥かしい場面まで取られてしまった
	PRINTFORML 
	COUNTRY_SOLDIER:(CFLAG:対象:所属) += 500 + 100 * (RAND:10 + RAND:10 + 6)
	CALL COLOR_PRINTW("その日の取材内容が放送されると志願兵が増えた", カラー_注意)
	MONEY += 5000
	CALL COLOR_PRINTW("出演料として金5000を受け取った", カラー_注意)
	CALL PRINT_ADD_EXP(対象, "露出経験値", RAND:20 + 1, 1)
	CALL TRAIN_AUTO_ABLUP(対象)
	DVAR:AV撮影_進行度 ++
ELSEIF DVAR:AV撮影_進行度 == 3
	PRINTFORMW 再び密着取材がやって来た
	PRINTFORML プロデューサーは相変わらずの笑顔で%ANAME(対象)%に近づいてくる
	PRINTFORMW しかし今までの事を思い出した%ANAME(対象)%はこのまま続けていいのかと不安になる
	PRINTFORML どうしよう？
	CALL ASK_YN("続ける" ,"やめる")
	IF RESULT == 1
		PRINTFORML これ以上取材には協力できない
		PRINTFORML %ANAME(対象)%がそう告げると先程まで笑顔だったプロデューサーは態度を急変させた
		PRINTFORMW 「契約違反だ！そちらがそういうつもりなら今まで撮った恥ずかしい映像も全て流出させるぞ！」
		PRINTFORML 彼は青筋を立てながら%ANAME(対象)%に迫って来る
		CALL ASK_YN("続ける" ,"それでもやめる")
		IF RESULT == 1
			PRINTFORML やはり続けることは出来ない
			PRINTFORML %ANAME(対象)%の決意が固いと見るや彼は唾を吐いて去って行った
			PRINTFORMW %ANAME(対象)%は彼らが去るのを見届けるとホッと一息を突いた
```
