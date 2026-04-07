# SYSTEM/EVENT_DAILY/各イベント群/RESCUE_救出作戦.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/RESCUE_救出作戦.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_RESCUE_RATE, EVENT_DAILY_RESCUE_DECISION, EVENT_DAILY_RESCUE_GENRE, EVENT_DAILY_RESCUE, SELECT_CHARA_LIST_SHOW_LOGIC_RESCUE, SELECT_CHARA_LIST_SELECT_LOGIC_RESCUE, RESCUE_RAPE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_RESCUE_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_RESCUE_DECISION()
LOCAL:1 = 0

FOR LOCAL, 0, CHARANUM
	SIF CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && CFLAG:LOCAL:捕虜先 != 0 && CFLAG:LOCAL:捕虜先 != CFLAG:MASTER:所属
		RETURN 1
NEXT

RETURN 0

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_RESCUE_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_RESCUE()
#DIM 対象
#DIM 実行者
#DIM 捕虜番号, MAX_CHARA_NUM

PRINTFORML 敵国に捕まった仲間を救出する作戦を提案された
PRINTFORML どうしよう？
CALL ASK_YN("実行する", "やめておく")
IF RESULT == 1
	PRINTFORMW 危険だ、今は機を窺おう
	RETURN 1
ELSE
	PRINTFORMW 仲間を見捨てることはできない、救出作戦を行うことにした
	$RESCUE_LOOP 
	PRINTFORML 誰を救出に向かおうか？
	CALL SINGLE_DRAWLINE
	FOR LOCAL, 0, CHARANUM
		IF CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && CFLAG:LOCAL:捕虜先 != 0 && CFLAG:LOCAL:捕虜先 != CFLAG:MASTER:所属
			捕虜番号:(LOCAL:1) = LOCAL
			PRINTFORM [{LOCAL:1}]%ANAME(LOCAL)%
			PRINTL
			LOCAL:1 ++
		ENDIF
	NEXT
	CALL SINGLE_DRAWLINE
	PRINTFORML [1000] やめておく
	$INPUT_LOOP
	INPUT
	IF RESULT == 1000
		$CANCEL
		PRINTFORMW やはり危険だ、今は機を窺おう
		RETURN 1
	ELSEIF RESULT < 0 || RESULT >= LOCAL:1
		GOTO INPUT_LOOP
	ELSE
		対象 = 捕虜番号:(RESULT)
		PRINTFORMW %ANAME(対象)%を救出することにした
		PRINTFORML 誰が救出に向かおうか？
		CALL SELECT_CHARA_LIST_ONLY_LOGIC_SLG("RESCUE", "RESCUE")
		SIF RESULT == -1
			GOTO CANCEL
		実行者 = RESULT
		IF 実行者 == MASTER
			PRINTFORMW %ANAME(実行者)%自ら向かうことにした
		ELSE
			PRINTFORMW %ANAME(実行者)%を向かわせることにした
		ENDIF
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		IF (ABL:実行者:武闘 + ABL:実行者:知略 + ABL:実行者:政治) / 10 >= RAND:30 + DAY / 10
			PRINTFORML やった！
			PRINTFORML 救出作戦は成功した！
			PRINTFORMW 捕まっていた%ANAME(対象)%を連れ戻した
			CFLAG:対象:捕虜先 = 0
			IF 実行者 == MASTER
				PRINTFORMW %ANAME(対象)%の%ANAME(実行者)%への評価が大きく上がった
				CFLAG:対象:好感度 += 500
			ENDIF
		ELSE
			PRINTFORML しまった！
			PRINTFORMW 作戦に失敗した……
			IF IS_MALE(実行者)
				PRINTFORML %ANAME(実行者)%は命からがら逃げ帰った
				CALL ADD_COOLTIME(実行者, 3)
			ELSE
				PRINTFORML %ANAME(実行者)%はスパイとして敵兵に捕まってしまった
				PRINTFORMW 気丈に睨み付ける%ANAME(実行者)%に対し、彼らはニヤニヤと笑いながら尋問の為に連れて行った……
				PRINTFORML 
				CALL RESCUE_RAPE(実行者)
				PRINTFORML 
				IF RAND:3 == 0
					PRINTFORMW その後、%ANAME(実行者)%も%ANAME(対象)%同様、捕虜にされてしまった
					CFLAG:実行者:捕虜先 = CFLAG:対象:捕虜先
				ELSE
					PRINTFORML 散々凌辱されたが、%ANAME(実行者)%は何とか逃げ帰った
					CALL ADD_COOLTIME(実行者, 3)
				ENDIF
			ENDIF
		ENDIF
	ENDIF
ENDIF

RETURN 1

@SELECT_CHARA_LIST_SHOW_LOGIC_RESCUE(対象)
#DIM 対象
RETURN CFLAG:対象:行動不能状態 != 行動不能_子供 && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !IS_ANIMAL(対象) && !TALENT:対象:妊娠 && GET_COUNTRY_BOSS(CFLAG:対象:所属) != 対象

@SELECT_CHARA_LIST_SELECT_LOGIC_RESCUE(対象)
#DIM 対象
RETURN CFLAG:対象:捕虜先 == 0


;-----------------------------------------------
;潜入失敗
;-----------------------------------------------
@RESCUE_RAPE(ARG:0)

PRINTFORMW 捕まった%ANAME(ARG:0)%が凌辱を受けている……
SELECTCASE RAND:40
	CASE 0
		PRINTFORML 寝台に大の字で拘束された%ANAME(ARG:0)%が、ピクピクと身を震わせながら顔を仰け反らせて息を荒げている
		PRINTFORML %ANAME(ARG:0)%は尋問と称して兵士たちの慰み者にされ、休むことも許されずにひたすらその体を好き放題に使われた
		PRINTFORML 真っ赤に腫れたその秘所からは大量の白濁液がとめどなくあふれており、だらしなく開きっぱなしになってしまっている
		PRINTFORML 絶え間ない凌辱による苦痛と快楽の波で%ANAME(ARG:0)%の頭は惚けきっており、時折身体を痙攣させながら喉から甘い吐息を漏らす
		PRINTFORMW 女日照りの兵士たちにとって%ANAME(ARG:0)%は極上の肉便器であり、その後も容赦ない種付けレイプが繰り返された
	CASE 1
		PRINTFORML とある町の一角から%ANAME(ARG:0)%の悲痛な喘ぎ声とそれを囲う男たちの野次が聞こえてくる
		PRINTFORML なかなか口を割らない%ANAME(ARG:0)%は、見せしめとしてさらし台に拘束されて町中に設置されることになった
		PRINTFORML 多数の兵士や住民たちによってひっきりなしにその体を好き放題に使われ汚され、%ANAME(ARG:0)%の全身はドロドロになっていく
		PRINTFORML 無数のペニスをねじこまれ続けたヴァギナとお尻は真っ赤にはれ上がり、全身は白濁液でドロドロになってしまっている
		PRINTFORML 一人の男に犯されながら不意に激しくお尻を叩かれ、%ANAME(ARG:0)%は思わず嬌声をあげてしまい、周囲から嘲りの声が上がった
		PRINTFORMW その宴は夜まで続き、解放される頃には%ANAME(ARG:0)%は身体の奥深くまですっかり快楽を刻み込まれていた
	CASE 2
		PRINTFORML 薄暗い牢獄の中からくぐもった%ANAME(ARG:0)%の呻き声と卑猥な蜜音、そして肉の打ち合う音が響いている
		PRINTFORML 極上の牝である%ANAME(ARG:0)%を前に兵士たちは我慢できず、尋問と称して彼らの肉便器として休みなく犯し続けている
		PRINTFORML 最初は抵抗していた%ANAME(ARG:0)%も、何度も殴られ脅された結果、すっかり従順に彼らに奉仕するようになっていた
		PRINTFORML 一人の兵士にまたがり自ら腰を振りながら、両手と口を使って周囲の兵士たちへも懸命に満足させ、その度にドロドロにされる
		PRINTFORMW その%ANAME(ARG:0)%の艶めかしい奉仕に兵士たちの肉欲は収まらず、彼らの尋問は深夜遅くまで続くことになった
	CASE 3
		PRINTFORML 牢獄の中、尋問官たちに囲まれた%ANAME(ARG:0)%は、深々とペニスをねじ込まれながら嬌声をあげている
		PRINTFORML 好き放題に犯されているにもかかわらず%ANAME(ARG:0)%はエヘエヘと笑って自ら腰を振り、両手で熱心にペニスをしごく
		PRINTFORML 尋問の為に薬漬けにされた%ANAME(ARG:0)%の頭の中は快楽で埋め尽くされ、ペニスを銜え込むことしか考えられなくなっている
		PRINTFORML ペニスで一突きされる毎に身体をはねさせ、クリトリスを弾かれるとだらしなくよだれをまき散らして悦びの声をあげる
		PRINTFORMW %ANAME(ARG:0)%は彼らの気が済むまで延々と犯され続けて体の奥深くまで快楽を覚えこまされることになった
	CASE 4
		PRINTFORML 地下深くのとある拷問部屋の中から、%ANAME(ARG:0)%の喘ぎ声交じりの悲鳴が響いてくる
		PRINTFORML 鎖で吊るされた%ANAME(ARG:0)%はガクガクと体を震わせ髪を振り乱し、口からは泡を吐きながら言葉にならない言葉を叫ぶ
		PRINTFORML その両穴には激しく震える極太バイブが合計５つもねじ込まれており、みちみちと音を立てながら愛液や体液が溢れ出ている
		PRINTFORML 悲鳴と共に汗や愛液や潮などの体液が周囲に飛び散り、%ANAME(ARG:0)%のその無様な姿を見て、兵士たちはニヤニヤと笑っている
		PRINTFORML 周囲には大量のバイブやローター、ブラシが転がっており、%ANAME(ARG:0)%がされてきた尋問の形跡を物語っている
		PRINTFORMW その後も悲鳴を上げて痙攣する%ANAME(ARG:0)%にも容赦なく尋問は続き、解放された頃には身も心もボロボロにされていた
	CASE 5
		PRINTFORML 尋問部屋の中で%ANAME(ARG:0)%は一人の目麗しい女性と絡みあいながらあられもない嬌声をあげている
		PRINTFORML 尋問官である彼女の股間には立派な男根が生えており、同じ女だからわかる%ANAME(ARG:0)%の弱点を的確に責め立てている
		PRINTFORML 彼女のねっとりとした責めは、堪えようとする%ANAME(ARG:0)%の理性をドロドロに溶かしていき、無意識に腰を振りだしていた
		PRINTFORML 乳首を弄られながら太いカリ首で膣肉を抉られると、%ANAME(ARG:0)%は大きく身体を反らしながら悦びとともに絶頂してしまう
		PRINTFORMW もはや女同士という背徳感も忘れ、%ANAME(ARG:0)%は彼女に与えられる快楽に夢中になってひたすら快楽に身をゆだねだした
	CASE 6
		PRINTFORML %ANAME(ARG:0)%はお尻を突き出す格好で壁に埋め込まれて兵たちの肉便器として使用されている
		PRINTFORML 赤く腫れたお尻には無数の正の字が書かれており、がくがくと震える足元には白濁の水たまりができている
		PRINTFORML 今も一人の兵士が%ANAME(ARG:0)%の腰をつかみながら激しくペニスを打ち付け、その度にぶちゅんぶちゅんと卑猥な音が響く
		PRINTFORML 苦痛と屈辱で顔を歪めていた%ANAME(ARG:0)%も、絶え間なく媚肉を抉られ続けた結果、今やだらしない牝の顔を見せている
		PRINTFORMW やがて何十発目かの膣内射精を放たれると共に、%ANAME(ARG:0)%はあられもない声をあげて絶頂してしまった
	CASE 7
		PRINTFORML 裸に剥かれて首輪をつけられた%ANAME(ARG:0)%が巨大な犬にまたがられて、まるで獣の様に犯されている
		PRINTFORML その犬は捕虜尋問用に躾けられた特別製であり、その凶悪なペニスで的確かつ容赦なく%ANAME(ARG:0)%の膣肉を抉ってくる
		PRINTFORML 泣きわめいて逃げようとしていた%ANAME(ARG:0)%も暴力的な交尾に、腰砕けになっておりもはや彼にされるがままになっている
		PRINTFORML 畜生に犯されることに嫌悪感を覚えながらも、否応なく雌を自覚させられる圧倒的快楽に、%ANAME(ARG:0)%は目を白黒させてヨガる
		PRINTFORMW その後も%ANAME(ARG:0)%はアヘ顔で泣きながら痙攣する様を兵士たちに笑われながら、容赦なく夜通し種付け交尾をされ続けた
	CASE 8
		PRINTFORML 捕まり散々凌辱された%ANAME(ARG:0)%は風呂場に担ぎ込まれてシャワーを浴びせられている
		PRINTFORML もちろんただ親切でそんなことをされるはずもなく、監視という名目の兵士たちに湯を浴びながら体中を弄繰り回される
		PRINTFORML 乱暴にされて赤く腫れた身体は熱い湯を浴びてますます敏感となり、軽い愛撫でもたまらない快楽が走り思わず声を漏らしてしまう
		PRINTFORML 羞恥で真っ赤になり身をよじらせるその反応は彼らの雄を刺激し、次第に%ANAME(ARG:0)%への愛撫は激しくなっていく
		PRINTFORMW やがて我慢できなくなった彼らによってその場で第二ラウンドが始まり、すぐに風呂場から%ANAME(ARG:0)%の大きな嬌声が響きだした
	CASE 9
		PRINTFORML %ANAME(ARG:0)%は秘部の露出した卑猥なボンデージを着せられて女尋問官に攻められながら、艶めかしい声をあげている
		PRINTFORML 彼女は熱っぽい視線を%ANAME(ARG:0)%に向けると、いきなり唇を奪い、露出している恥部をしなやかな指先で激しく責め立ててきた
		PRINTFORML 突然のことに戸惑い身もだえていた%ANAME(ARG:0)%だったが、彼女の巧みな指使いで的確に雌を刺激され無意識に腰をくねらせる
		PRINTFORML 堪えようとしても、耳元でねっとりと囁かれながらクリクリと突起を抓まれると、あまりの快楽に喉から情けない声を漏らしてしまう
		PRINTFORMW 普通とは違うその尋問に、%ANAME(ARG:0)%の理性は次第に溶かされていき、一晩中たっぷりとレズ調教で可愛がられることになった
	CASE 10
		PRINTFORML %ANAME(ARG:0)%は地下牢で他の女囚たちと鎖で繋げられた状態で兵士たちの尋問を受けている
```
