# SYSTEM/EVENT_DAILY/各イベント群/ARBEIT_アルバイト.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/ARBEIT_アルバイト.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_ARBEIT_RATE, EVENT_DAILY_ARBEIT_DECISION, EVENT_DAILY_ARBEIT_GENRE, EVENT_DAILY_ARBEIT, EVENT_DAILY_ARBEIT_ALLOW_WHEN_WANDERING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_ARBEIT_RATE()
RETURN (DVAR:アルバイト_発生フラグ > 0 ? 500 # 50)

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_ARBEIT_DECISION()
SIF !IS_FEMALE(MASTER)
	RETURN 0
SIF CFLAG:MASTER:捕虜先 != 0
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_ARBEIT_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;---------------------
@EVENT_DAILY_ARBEIT

IF DVAR:アルバイト_発生フラグ == 0
	PRINTFORML ある日、寄った酒場でアルバイトをしないかと誘われた
	IF CFLAG:MASTER:所属 == 0
		PRINTFORML 今の%ANAME(MASTER)%はフリーで収入の当てもない
		PRINTFORMW 路銀を稼ぐのに丁度いいかもしれない
	ELSE
		PRINTFORML %ANAME(MASTER)%がこの国の将校だと知らないらしい
		PRINTFORMW だが副収入としていいかもしれない
	ENDIF
	PRINTFORML どうしよう？
	CALL ASK_YN("やってみる", "やめておく")
	IF RESULT == 1
		PRINTFORMW 店の怪しげな雰囲気が気になったのでやめておいた
		RETURN
	ELSEIF RESULT == 0
		PRINTFORML やってみる事にした
		PRINTFORML 契約書にサインをすると店の奥に案内された
		PRINTFORML 店の奥には地下へと続く階段があった
		PRINTFORMW 訝しみながらも店長について行くと別の酒場に出た
		PRINTFORML 薄暗い店内に騒がしい音楽が鳴っている
		PRINTFORML 舞台の上ではスポットライトを浴びた踊り子やダンサーたちが卑猥な衣装で踊っていた
		PRINTFORMW ウェイトレスたちは普通の酒場とは違うまるで娼婦の様な衣装で接客をしている
		PRINTFORML 予想外の光景に%ANAME(MASTER)%が唖然としていると店の裏に連れて行かれ制服を手渡された
		PRINTFORML こんなところで働かされるとは聞いてないと抗議すると先程の契約書を突き出された
		PRINTFORMW 店長は先程と打って変わって低い声で契約を破るなら訴えると脅してきた
		PRINTFORML どうしよう？
		CALL ASK_YN("渋々着替える", "逃げだす")
		IF RESULT == 0
			PRINTFORML 何とか逃れようとしたができなかった
			PRINTFORML %ANAME(MASTER)%は嫌々ながら着替えるしかなかった
			PRINTFORMW 衣装は他の店員に負けず劣らず卑猥なものだった
		ELSEIF RESULT == 1
			PRINTFORMW %ANAME(MASTER)%はとっさに逃げだした！
			PRINTFORML 
			IF ABL:MASTER:防衛 / 10 + RAND:5 > RAND:10
				PRINTFORMW …何とか逃げ切る事が出来た
				RETURN
			ELSE
				PRINTFORML しかし逃げ切れずに捕まってしまった
				PRINTFORML 怒った男たちに殴られ蹴られ、観念して着替えるしかなかった
				PRINTFORMW 衣装は他の店員に負けず劣らず卑猥なものだった
			ENDIF
		ENDIF
		PRINTFORML 恥ずかしさのあまり真っ赤になってしまう
		PRINTFORML 彼はねっとりとした視線で眺め下卑た笑みを浮かべてきた
		PRINTFORMW そして研修を行うと告げ、%ANAME(MASTER)%を強引に店長室に連れ込んだ
		PRINTFORML 
		PRINTFORML 卑猥な衣装を乱れさせた%ANAME(MASTER)%が店長に跨り腰を振っている
		PRINTFORML %ANAME(MASTER)%は強力な媚薬を飲まされ、すっかりトロけた様な表情で艶めかしく喘ぐ
		PRINTFORML ペニスで膣肉を擦り上げられる度に強烈な快楽で脳天までシビれ、ビクビクと痙攣する
		IF TALENT:MASTER:処女 == 1
			PRINTFORMW 先程まで処女だったとは思えない程快楽にドはまりした%ANAME(MASTER)%はあられもなくヨガる
		ELSE
			PRINTFORMW 圧倒的な快楽の波に%ANAME(MASTER)%は抗う事を忘れ、汗だくになりながら激しくヨガる狂う
		ENDIF
		PRINTFORML 巧みな腰遣いで弱点を抉られると、%ANAME(MASTER)%はたまらず身を仰け反らせて絶頂してしまった
		PRINTFORML 男は絶頂する%ANAME(MASTER)%を見て「これぐらいで参っていたら接客は出来ないぞ」と叱りつける
		PRINTFORML 絶頂したまま震える声で謝罪する%ANAME(MASTER)%の表情は、もはや理性を失った雌犬のモノになっていた
		PRINTFORMW %ANAME(MASTER)%は一晩中店長の教育を受け、身体の奥深くまでしっかりと雄を覚え込まされる事になった
		CALL FUCK(MASTER, "欲望, 性交, 精愛, 性技, 性技, 奉仕, Ｖ, Ｂ, Ｍ, Ｃ, Ｖ性交", "処女喪失, 膣内射精, キス喪失, 口内射精, CFLAG減少", GET_SPERM_ID("ならず者"), @"店長の\@RAND:2 ? ペニス # 唇\@", @"店長", "", "敗北した末の強姦")
		PRINTFORMW 
		PRINTFORML 研修を終えた%ANAME(MASTER)%は一旦解放された
		PRINTFORML しかしレイプ写真を撮られてしまっていた
		PRINTFORMW ばら撒かれたくなければ今後も来るように脅された…
		DVAR:アルバイト_発生フラグ = 1
	ENDIF
ELSE
	PRINTFORML %ANAME(MASTER)%はアルバイトに向かった…
	PRINTFORMW 店長は%ANAME(MASTER)%を見ると下卑た笑みを浮かべながら腰に手を回してきた
	IF DVAR:アルバイト_発生フラグ >= 5
		PRINTFORML 「ずいぶん慣れてきたな、そろそろ従業員にならないか？」とねっとりと囁かれる
		PRINTFORML その言葉に思わず子宮がきゅんと疼き、ゾクゾクと背筋を震わせてしまう
		PRINTFORML しかし%ANAME(MASTER)%はグッと堪えると声を震わせながらも拒絶の言葉を吐いた
		PRINTFORMW 彼は肩をすくませながら%ANAME(MASTER)%に仕事に就くように命じた
	ELSEIF DVAR:アルバイト_発生フラグ >= 3
		PRINTFORML 「前回の接客は好評だったぞ、なかなか接客向きじゃないか？」とねっとりと囁かれる
		PRINTFORML その言葉に前回の事を思い出してしまい、たまらず羞恥で俯いてしまう
		PRINTFORML しかし%ANAME(MASTER)%はあくまで写真の為だと拒否の言葉を呟いて首を振った
		PRINTFORMW 彼はニヤニヤ笑いのまま%ANAME(MASTER)%に仕事に就くように命じた
	ELSE
		PRINTFORML 「相変わらずいい身体だよ、客に抱かせるのは惜しいねぇ」とねっとりと囁かれる
		PRINTFORML その言葉に%ANAME(MASTER)%はカッとなったが写真の事を思い出してグッとこらえる
		PRINTFORML %ANAME(MASTER)%の様子に彼はニヤニヤと笑いながら執拗に体を撫でまわしてきた
		PRINTFORMW しばらくそうしてセクハラを受けた後、彼は%ANAME(MASTER)%に仕事に就くように命じた
	ENDIF
	PRINTFORML 
	SELECTCASE RAND:16
		CASE 0
			PRINTFORMW %ANAME(MASTER)%はバニーガール衣装で接客をさせられている
			PRINTFORML 客は一様にいやらしい目つきで%ANAME(MASTER)%の胸元やお尻を見つめてくる
			PRINTFORML その視線と酒場の空気に当てられ、次第に%ANAME(MASTER)%も体が火照って来るのを感じた
			PRINTFORMW 熱っぽい吐息を吐きながら仕事をしていると、ひどく酔っぱらった客に絡まれた
			PRINTFORML 他の店員にヘルプを求めても見て見ぬふりをされ、酷く絡まれ続けてしまう
			PRINTFORML 彼は勃起した一物を押し当てながら酒臭い息と共に下品に誘ってくる
			PRINTFORMW 何とか逃れようとしたがそれも叶わず、なし崩しにトイレに連れ込まれてしまった
			PRINTFORML やがて個室からは艶めかしい%ANAME(MASTER)%の嬌声が漏れだしてきた
			PRINTFORMW 客が満足するころには%ANAME(MASTER)%はドロドロにされてしまっていた
		CASE 1
			PRINTFORMW スポットライトの元で%ANAME(MASTER)%はポールダンスをしている
			PRINTFORML %ANAME(MASTER)%はきわどい衣装に頬を染めながらぎこちなく踊る
			PRINTFORML その初々しさは逆に客の興奮させ、罵声と歓声が飛び交う
			PRINTFORMW 空気に当てられた%ANAME(MASTER)%は無意識になまめかしく腰を振りだしていた
			PRINTFORML 客の要求はどんどんと過激になっていき、やがて脱衣コールが発生しだした
			PRINTFORML すっかりプロダンサーになり切っている%ANAME(MASTER)%はそのコールに笑顔で答える
			PRINTFORMW 身をくねらせながら脱衣していく%ANAME(MASTER)%の姿に場はますます盛り上がっていく
			PRINTFORML %ANAME(MASTER)%が全裸になるとボルテージは頂点に達し、客が舞台に躍り出てきた
			PRINTFORML そして疲れ果てた%ANAME(MASTER)%を捕らえるとそのまま公開レイプショーに移行した
			PRINTFORMW 閉店まで絶え間なく興奮した男たちの相手をさせられドロドロにされてしまった
		CASE 2
			PRINTFORMW %ANAME(MASTER)%はキャバクラの様に客の相手をさせられている
			PRINTFORML きわどい衣装がボディラインを際立たせいやらしい目つきで眺められる
			PRINTFORML %ANAME(MASTER)%はその視線に気づきつつも笑顔で客の相手をせざるを得ない
			PRINTFORMW ある太った中年男性が%ANAME(MASTER)%を気に入った様でしつこく絡んできた
			PRINTFORML 何とか逃げようとしても肩を掴まれ彼の酒臭い息を浴びせられ口説かれる
			PRINTFORML スキンシップは徐々に過激になりデリケートな場所にまで指が伸びてきた
			PRINTFORMW 店員に助けを求めようとしたが一様に見て見ぬふりをされてしまう
			PRINTFORML そして無理矢理唇を奪われると、そのまま座席に押し倒されてしまった
			PRINTFORMW 薄暗い店の隅で%ANAME(MASTER)%は性欲の塊のような彼が満足するまで犯されてしまった
		CASE 3
			PRINTFORMW %ANAME(MASTER)%は人のごった返している酒場で給仕をしている
			PRINTFORML 店は大勢のならず者で大騒ぎであり%ANAME(MASTER)%も接客に追われる
			PRINTFORML 一人のならず者の客に絡まれ思わず強めに抵抗してしまった
			PRINTFORMW 反動でビールが思い切りかかった彼は%ANAME(MASTER)%に向けて詰め寄って来た
			PRINTFORML 何とか謝罪して逃れようとするも彼の仲間が集まってきて逃げられなくなる
			PRINTFORML 彼らは口々に%ANAME(MASTER)%に誠意を求めてきて%ANAME(MASTER)%はつい頷いてしまう
			PRINTFORMW %ANAME(MASTER)%は下卑た笑みを浮かべるならず者たちに店の裏手に連行された
			PRINTFORMW 夜が明ける頃路地裏に凌辱されつくしてボロボロになった%ANAME(MASTER)%が転がっていた
		CASE 4
			PRINTFORMW %ANAME(MASTER)%はウェイトレスをさせられている
			PRINTFORML 卑猥な衣装にもじもじしながら接客していると容赦なくセクハラされてしまう
			PRINTFORML 薄暗い店内のいたるところでいやらしいサービスが行われている
			PRINTFORMW %ANAME(MASTER)%もまた一人の客の相手をさせられることになった
			PRINTFORML 酷く酔っている彼は%ANAME(MASTER)%を隣に座らせると体のあちこちをねっとりと触ってきた
			PRINTFORML 何とか逃れようとしたが客の勧めは断れず、無理矢理飲まされ泥酔させられた
			PRINTFORMW 前後不覚になった%ANAME(MASTER)%は火照り切り客のセクハラにも抵抗できず喘いでしまう
			PRINTFORML 彼は%ANAME(MASTER)%の様子に舌なめずりをすると店の奥に用意された個室に連行した
			PRINTFORMW %ANAME(MASTER)%は朦朧とした意識の中で夜通し彼に調教され続けた
		CASE 5
			PRINTFORMW 軽快な音楽が鳴っている酒場で%ANAME(MASTER)%は踊っている
			PRINTFORML セクシーな踊り子衣装に身を包み艶めかしく踊る姿に客は釘つけになっている
			PRINTFORML 汗で光るぷりぷりの肌と極上のボディラインが揺れる度に、男達は喉を鳴らす
			PRINTFORML %ANAME(MASTER)%が近くに来ると客はボディタッチついでにチップを服の隙間に挟んでくる
			PRINTFORMW 慣れない行為にもかかわらず%ANAME(MASTER)%は不思議な高揚感に包まれ熱心に踊った
			PRINTFORML その姿は一人の上客の目に留まることになりダンスの後に誘われた
			PRINTFORML 火照りきっていた%ANAME(MASTER)%は彼の口説き文句に胸と子宮を疼かせ思わず頷く
			PRINTFORMW %ANAME(MASTER)%は彼に恋人の様に寄り添いながらＶＩＰルームへ向かった
			PRINTFORMW そこで%ANAME(MASTER)%は一晩中彼専用の踊り子として艶めかしく踊ることになった
		CASE 6
			PRINTFORMW %ANAME(MASTER)%は給仕の仕事をさせられている
			PRINTFORML 今日の衣装は一段と過激で、少し動くだけで下着やその下が丸見えになってしまう
			PRINTFORML 卑猥な視線に晒されながら何とか仕事をしていた%ANAME(MASTER)%は一人の客に酌を要求された
			PRINTFORMW 他に手の空いている者もおらず仕方なく仕方なく彼の隣に座り接客する
			PRINTFORML 他の客と違いセクハラも過激な要求もされず%ANAME(MASTER)%は少し彼に気を許す
			PRINTFORML しかし酒にはひそかに媚薬が混ぜられており徐々に%ANAME(MASTER)%は息を荒げだした
			PRINTFORMW 理由もわからず子宮から湧き上がる熱に%ANAME(MASTER)%はうなされた様な表情でもじもじしてしまう
			PRINTFORML 酒も手伝い理性が惚けてしまった%ANAME(MASTER)%は彼のお持ち帰り要求を理解せず了承してしまった
			PRINTFORMW %ANAME(MASTER)%はホテルに連れ込まれて一晩中逞しい一物で虐められてしまった
		CASE 7
			PRINTFORMW %ANAME(MASTER)%はポールダンサーの仕事を任され踊っている
			PRINTFORML 羞恥により他の子たちに比べて明らかに動きが鈍い%ANAME(MASTER)%に卑猥なヤジが飛ぶ
			PRINTFORML %ANAME(MASTER)%は涙目になりながらも客に言われるままに必死でポールに身体をこすりつけ腰を振る
			PRINTFORMW その表情が客に受けたようでさらに野次は過激になって行き%ANAME(MASTER)%を煽る
			PRINTFORML 気づけば%ANAME(MASTER)%は客に向けて股間を大股開きにしながら身体をくねらせていた
			PRINTFORML その胸元やガーターベルトには大量のおひねりが挟まれていた
			PRINTFORMW 求められる事に%ANAME(MASTER)%は知らぬうちに雌としての快感を覚えすっかり出来上がっていた
			PRINTFORML 踊りを終えても体の疼きが収まらない%ANAME(MASTER)%は当然客の誘いにも断れなかった
			PRINTFORMW %ANAME(MASTER)%は店のすぐ裏手で何人もの男に求められ使われ雌の悦びで何度も絶頂した
		CASE 8
			PRINTFORMW %ANAME(MASTER)%はバニーガールの格好で接客をさせられている
			PRINTFORML 給仕中、客は次々と%ANAME(MASTER)%にセクハラをしてくる
			PRINTFORML 胸や尻を揉まれ、太ももを撫でられ、わざとビールを谷間にこぼされる
			PRINTFORMW セクハラはどんどんエスカレートしていき次第に%ANAME(MASTER)%も息を荒げ頬を染めだす
```
