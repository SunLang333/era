# SYSTEM/EVENT_DAILY/各イベント群/派生/YAKUZA_AFTER_やくざとその後….ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/YAKUZA_AFTER_やくざとその後….ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_YAKUZA_AFTER_DISABLE, EVENT_DAILY_DERIVATION_YAKUZA_AFTER_DECISION, EVENT_DAILY_DERIVATION_YAKUZA_AFTER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_YAKUZA_AFTER_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("YAKUZA")

;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_YAKUZA_AFTER_DECISION()
RETURN DVAR:やくざ_発生フラグ > 0 && RAND:2 == 0

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_YAKUZA_AFTER()
#DIM 対象

対象 = ID_TO_CHARA(DVAR:やくざ_肉便器対象ID)

;ターゲットが女じゃなくなっていたらやめる
IF !IS_FEMALE(対象)
	PRINTFORMW %ANAME(対象)%が女をやめたので、やくざは興味を失ってしまったようだ……
	DVAR:やくざ_発生フラグ = 0
	DVAR:やくざ_肉便器対象ID = 0
	DVAR:やくざ_妊娠 = 0
	RETURN 1
ENDIF

;ターゲットが捕虜になったらやめる
IF CFLAG:対象:捕虜先
	PRINTFORMW %ANAME(対象)%が捕らえられたので、やくざはこれ以上の付き合いを諦めたようだ……
	DVAR:やくざ_発生フラグ = 0
	DVAR:やくざ_肉便器対象ID = 0
	DVAR:やくざ_妊娠 = 0
	RETURN 1
ENDIF

IF CFLAG:対象:特殊状態 == 特殊状態_死亡
	PRINTFORMW %ANAME(対象)%が死亡したので、やくざはこれ以上の付き合いを諦めたようだ……
	DVAR:やくざ_発生フラグ = 0
	DVAR:やくざ_肉便器対象ID = 0
	DVAR:やくざ_妊娠 = 0
	RETURN 1
ENDIF

IF DVAR:やくざ_妊娠 == 1 && !(CFLAG:(対象):行動不能状態 == 行動不能_臨月)
	PRINTFORML 出産後、やくざから子供に関して脅された
	PRINTFORMW 「ガキの身の安全を保障してほしければ……」
	PRINTFORML 一度堕ちてしまった%ANAME(対象)%はもはや彼から逃れることは出来なかった
	PRINTFORMW これからの一生を彼らの言いなりにならざるを得なかった……
	CALL COLOR_PRINTW(@"%ANAME(対象)%は<ソープ嬢>となった", カラー_ピンク)
	SETBIT TALENT:対象:デイリー系, 素質_デイリー_ソープ嬢
	CALL LOSE_RELATION_TALENT(対象)
	CFLAG:対象:好感度 = LIMIT(CFLAG:対象:好感度, -1000, 0)
	CFLAG:対象:依存度 = LIMIT(CFLAG:対象:依存度, -1000, 0)
	CFLAG:対象:従属度 = LIMIT(CFLAG:対象:従属度, -1000, 0)
	CFLAG:対象:支配度 = LIMIT(CFLAG:対象:支配度, -1000, 0)
	DVAR:やくざ_発生フラグ = 0
	DVAR:やくざ_肉便器対象ID = 0
	DVAR:やくざ_妊娠 = 0
	RETURN 1
ENDIF

IF CFLAG:(対象):行動不能状態 == 行動不能_臨月
	IF DVAR:やくざ_妊娠 == 0
		PRINTFORML 妊娠を確認された%ANAME(対象)%はやくざ共が経営するソープで勤める事になった
		PRINTFORML 何でも妊娠している女を抱くと言うのはそれだけで一定の需要があるらしい
		PRINTFORMW 悪趣味さに嫌悪感を感じながらももはや身重の%ANAME(対象)%には抵抗するすべはなかった
		DVAR:やくざ_妊娠 = 1
	ELSE
		PRINTFORML 家で休んでいるとやくざの手下がやって来た
		PRINTFORML ボテ腹になっても彼らは休ませてくれない
		PRINTFORMW %ANAME(対象)%は大きなお腹を抱えながら仕事に向かった……
	ENDIF
	PRINTFORML 
	SELECTCASE RAND:5
		CASE 0
			PRINTFORML 今日の客は鬼だった
			PRINTFORMW その逞しさに%ANAME(対象)%は激しいセックスを想像して生唾を飲んだ
		CASE 1
			PRINTFORML 今日の客は野良妖怪だった
			PRINTFORMW その醜さに思わず引きつりそうになるのを堪えて笑顔で迎えた
		CASE 2
			PRINTFORML 今日の客はゴブリンだった
			PRINTFORMW 彼は涎を垂らし下卑た笑みを浮かべながら既に勃起していた
		CASE 3
			PRINTFORML 今日の客は天狗だった
			PRINTFORMW 一見軽快に話しかけてきたが女を見下す態度が見え隠れしていた
		CASE 4
			PRINTFORML 今日の客は獣人だった
			PRINTFORMW まさに獣の様に興奮していた彼は早速%ANAME(対象)%に迫って来た
	ENDSELECT
	PRINTFORML 
	SELECTCASE RAND:20
		CASE 0
			PRINTFORML 彼は妊婦とセックス出来て興奮しているのか夢中で腰を振っている
			PRINTFORML 執拗に膣の奥深くをちんぽで抉りながら%ANAME(対象)%のお腹を撫でまわしてくる
			PRINTFORML %ANAME(対象)%はその仕草にゾワっとしながらも努めて笑顔を見せ喘ぎ声を上げた
			PRINTFORMW 彼のねちっこいセックスは時間いっぱい続き、何度も精を注がれ続けた……
		CASE 1
			PRINTFORML %ANAME(対象)%は四つん這いで容赦なく突かれてヒィヒィとヨガらされている
			PRINTFORML 極太チンポでガツンガツンと子宮まで小突かれる度に胸が揺れ母乳が滲む
			PRINTFORML 内臓を引きずり出される様な激しいピストンに頭が真っ白になっていった
			PRINTFORMW そして灼熱の精液を勢いよく放たれると本気アクメに達してしまった……
		CASE 2
			PRINTFORML %ANAME(対象)%は彼に跨って膨らんだお腹を揺らしながら腰を振っている
			PRINTFORML 彼は%ANAME(対象)%のお腹をガン見して息を荒げガツンガツンと突き上げて来る
			PRINTFORML 子宮が潰れそうな一撃に思わず呻くと彼は興奮した様に腰を加速させた
			PRINTFORMW 妊婦とのセックスに興奮した彼につき合わされたっぷりと可愛がられた……
		CASE 3
			PRINTFORML %ANAME(対象)%は彼と向かい合い舌を絡ませながら腰を打ち付け合っている
			PRINTFORML 濃厚なベロチューセックスは少しずつ%ANAME(対象)%の頭と体を惚けさせていく
			PRINTFORML 不意にゴリッと子宮口を抉られて%ANAME(対象)%が軽くイくと彼はニヤリと笑った
			PRINTFORMW ねっとりと可愛がられた%ANAME(対象)%は妊婦にあるまじきイキ顔を晒した……
		CASE 4
			PRINTFORML %ANAME(対象)%は彼にされるがままに犯されながらヨガリ狂ってしまっている
			PRINTFORML 彼は想定以上にテクニシャンで直ぐにイかされてしまい主導権を奪われた
			PRINTFORML 巧みな愛撫と腰遣いで%ANAME(対象)%は仕事を忘れて雌となってあられもなく喘ぐ
			PRINTFORMW 彼の濃いザーメンを注がれると二重に孕んでしまいそうな気になった……
		CASE 5
			PRINTFORML 彼は%ANAME(対象)%に覆い被さると全身にむしゃぶりつきながら犯してきた
			PRINTFORML 容赦のない激しいセックスに%ANAME(対象)%は本能的にお腹をかばいながらヨガる
			PRINTFORML 不意に乳首をきつく吸い上げられ、たまらず嬌声を上げ仰け反ってしまう
			PRINTFORMW 彼は遠慮なく子宮まで届く程の射精を繰り返し体内を汚していった……
		CASE 6
			PRINTFORML %ANAME(対象)%は彼と風呂場に向かい全身をスポンジ代わりに奉仕している
			PRINTFORML 大きな胸とお腹を泡立てて洗う様に要望されると躊躇したものの従った
			PRINTFORML 彼は%ANAME(対象)%の必死の奉仕に興奮した様ですぐに一物を雄々しく勃起させた
			PRINTFORMW 奉仕の後はもちろん彼を鎮める為にそのまま風呂場で激しく犯された……
		CASE 7
			PRINTFORML 客の要望でバニーガールの格好で彼のチンポをしゃぶらされている
			PRINTFORML 雄臭い匂いが口いっぱいに広がるとたまらず雌の本能が反応してしまう
			PRINTFORML 不意に彼が射精すると%ANAME(対象)%は驚きつつも一滴残らず飲み干していった
			PRINTFORMW 濃厚なザーメンを咀嚼していると軽くイってしまい子宮が疼いた……
		CASE 8
			PRINTFORML %ANAME(対象)%は大きなお腹を揺らしながら彼と激しくまぐわっている
			PRINTFORML 彼のちんぽと%ANAME(対象)%の体は相性抜群で、先ほどからイかされまくっている
			PRINTFORML もはや仕事の事もお腹の赤子の事も忘れてただの雌の顔で腰を振っていた
			PRINTFORMW 二重に孕みそうな程の濃い精液を何度も注がれ雌の悦びを味わった……
		CASE 9
			PRINTFORML %ANAME(対象)%は彼に抱かれながらあられもないアヘ顔を晒している
			PRINTFORML 彼の女泣かせのテクによって%ANAME(対象)%は主導権を奪われガチイキさせられる
			PRINTFORML どびゅるるる！と何度目かの膣出しで%ANAME(対象)%は悲鳴混じりの嬌声を上げる
			PRINTFORMW すっかり蕩け切った身体は精液の熱だけで何度も絶頂してしまった……
		CASE 10
			PRINTFORML %ANAME(対象)%は彼に激しいガン突きを喰らいながらアヘりまくっている
			PRINTFORML 彼のペニスは逞しく%ANAME(対象)%は一撃で屈服させられメロメロになっていた
			PRINTFORML 脳みそがドロドロに溶けそうになる程の快楽に%ANAME(対象)%はアヒアヒと笑う
			PRINTFORMW %ANAME(対象)%は仕事も忘れてお腹を揺らしながらセックスに没頭した……
		CASE 11
			PRINTFORML %ANAME(対象)%は彼と一緒にゆったりとスローセックスを楽しんでいる
			PRINTFORML 執拗までにねっとりとしたセックスに思わず%ANAME(対象)%は甘い吐息を漏らす
			PRINTFORML 優しくお腹を撫でられながら愛を囁かれ雌の本能が疼きイってしまった
			PRINTFORMW 時間いっぱいまでまるで恋人の様に甘いセックスで可愛がられた……
		CASE 12
			PRINTFORML %ANAME(対象)%は両足を抱えられながら激しく突き上げられ身悶えている
			PRINTFORML コツンコツンと子供のいる子宮を刺激されるとたまらずに跳ねてしまう
			PRINTFORML 妊婦なのにいやらしいなと囁かれた%ANAME(対象)%はゾクゾクと背筋を震わせる
			PRINTFORMW 子宮口にピッタリと密着したまま射精され激しくイってしまった……
		CASE 13
			PRINTFORML ベッドに横たえられた%ANAME(対象)%が腰を掴まれながら突かれて喘ぐ
			PRINTFORML 脳天まで貫く様な衝撃に%ANAME(対象)%はお腹の子供の事も忘れアヘってしまう
			PRINTFORML 彼は遠慮なく%ANAME(対象)%の中へと秘所から溢れる程の大量のザーメンを放った
			PRINTFORMW %ANAME(対象)%は惚けた思考で大量の精液が子供に影響がないか考えていた……
		CASE 14
			PRINTFORML ピンクのベッドの上で%ANAME(対象)%は客に跨り艶めかしく踊っている
			PRINTFORML %ANAME(対象)%が腰を振る度にお腹が上下に揺れ、胸からは母乳が溢れ出ている
			PRINTFORML 彼に母乳を吸い上げられたまらず甘い嬌声を上げて身震いしてしまった
			PRINTFORMW %ANAME(対象)%はお返しとばかりにたっぷりとおチンポミルクを注がれた……
		CASE 15
			PRINTFORML %ANAME(対象)%は背後から彼に抱えられて激しく突き上げられている
			PRINTFORML 強烈なピストンで膨れたお腹と胸をゆさゆさと揺らしながら身悶える
			PRINTFORML そして敏感な子宮口を小突かれる度にあられもない嬌声を響かせた
			PRINTFORMW 普段と違うボテ腹セックスに%ANAME(対象)%は無意識にいつも以上に乱れた……
		CASE 16
			PRINTFORML 早速押し倒された%ANAME(対象)%は激しいバック突きで悶絶している
			PRINTFORML 彼は妊婦相手にも容赦なく膣の奥深くまで強烈なピストンを繰り返す
			PRINTFORML 母性本能で子供を守ろうとするも逃げられず激しく蹂躙されてしまった
			PRINTFORMW 雄々しい交尾で雌へと変えられた%ANAME(対象)%は抗えない絶頂に達した……
		CASE 17
			PRINTFORML %ANAME(対象)%は裸エプロンの格好で壁に寄たれながら犯されている
			PRINTFORML 新婚夫婦の様に濃厚に舌を絡ませてのセックスに喘ぎ身をくねらせる
			PRINTFORML 不意に彼に膨れたお腹を撫でられると本能が疼きキュンとしてしまう
			PRINTFORMW "旦那様"に射精宣言された%ANAME(対象)%は彼にしがみついて受け入れた……
		CASE 18
			PRINTFORML %ANAME(対象)%は彼に跨り卑猥な言葉と共に身をくねらせている
			PRINTFORML 彼の逞しいペニスに雌の本能が目覚めた%ANAME(対象)%はあられもなく乱れ狂う
			PRINTFORML 突き上げと共に乳首を抓られると、たまらないシビレが全身に走った
			PRINTFORMW %ANAME(対象)%は自らおねだりして絶倫妖怪チンポで散々可愛がられた……
		CASE 19
			PRINTFORML %ANAME(対象)%は彼に覆い被さられながら激しいピストンを受けている
			PRINTFORML 野太い一物が出入りする度にパチュバチュといやらしい蜜音と嬌声が響く
			PRINTFORML 絶倫妖怪チンポで既にイかされまくった%ANAME(対象)%は雌の顔で喘いでいる
			PRINTFORMW 延長料金を支払った彼に%ANAME(対象)%は一晩中気を失うまで虐められた……
	ENDSELECT
	CALL FUCK(対象, "Ｃ, Ｂ, Ｖ, Ｍ, Ａ, Ｖ性交, Ａ性交, 性交, 性技, 奉仕, 精愛, 口淫, 欲望, 売春", "キス喪失, 処女喪失, Ａ処女喪失, 膣内射精, 腸内射精, 口内射精, CFLAG減少", GET_SPERM_ID("娼館の客"), "妖怪の客の唇", "妖怪の客", "", "売春")
	PRINTFORML 
```
