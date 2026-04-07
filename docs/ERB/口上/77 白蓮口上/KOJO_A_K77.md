# 口上/77 白蓮口上/KOJO_A_K77.ERB — 自动生成文档

源文件: `ERB/口上/77 白蓮口上/KOJO_A_K77.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_A1_K77, KOJO_TRAIN_END_A1_K77, KOJO_TRAIN_START_A2_K77, KOJO_TRAIN_END_A2_K77, KOJO_COM_BEFORE_TARGET_A_K77, KOJO_COM_BEFORE_PLAYER_A_K77, KOJO_COM_A_K77, KOJO_COM_TARGET_A_K77, KOJO_COM_PLAYER_A_K77, KOJO_COM_AFTER_A_K77; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「会いに行く」「閨に呼ぶ」「子育て」「捕虜会話」の口上
;-------------------------------------------------
;
;Tips
;もしちょっとでも編集したいと思った好き者へ
;たまーに書いていても忘れる勘違いし易いもの系列……
;わからなくなったらココを見よう
;
;IS_COMFIRST()
;　コマンドそのものに対する初めて(設定された主導権毎)を記録。
;　……面倒ならそもそも使わなくてもいいし書かなくてもいいもの
;　()に1を入れると@関数内においての主導権等々は考慮せず、片方でも発動したらもう片方は弾いている筈
;
;IS_INITIATIVE()
;[★]、主導権。INITIATIVE側が命令権を持つ
;   <主導権>
;  男 [  ] <実行>
;
;具体的に実行画面でどうなるのかは以下のコメント行で再確認すべし
;
;[実行される側]
;【@KOJO_COM_TARGET_??】
;以下口上コマンド系統流れ
;IF　SELECTCOM == ??
;
;	;[命令する側]
;	;TARGETがMASTERに~~をねだる
;	IF IS_INITIATIVE(TARGET)
;
;	;[命令される側]
;	;MASTERがTARGETに~~をする
;	ELSE
;
;	ENDIF
;ENDIF
;
;[実行する側]
;【@KOJO_COM_PLAYER_??】
;以下口上コマンド系統流れ
;IF　SELECTCOM == ??
;
;	;[命令する側]
;	;TARGETがMASTERに~~をする
;	IF IS_INITIATIVE(TARGET)
;
;	;[命令される側]
;	;MASTERがTARGETに~~にねだる
;	ELSE
;
;	ENDIF
;ENDIF

;=================================================
;●「会いに行く」の開始時のセリフ
;=================================================
@KOJO_TRAIN_START_A1_K77
#DIM 命蓮
命蓮 = NAME_TO_CHARA("命蓮")

;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:200 == 0
	CFLAG:200 = 1
	PRINTFORML 
	;初対面の場合
	;(初対面軟禁)(修正済み)
	IF !CFLAG:面識 && CFLAG:軟禁中
		PRINTFORML 「――……こんにちは。本日はどの様なご用件で参られたのでしょうか？」
		PRINTFORMW  
		PRINTFORML  %ANAME(MASTER)%が部屋に訪れると、座敷牢の中心で背を向けた%ANAME(TARGET)%が、坐して祈りを捧げていた。
		PRINTFORML
		PRINTFORML  袈裟を纏う%NOUN_SEX(TARGET)%は、呟く言葉に重みを込め、数珠を幾度も鳴らしては韻を踏む。
		PRINTFORMW  ただそれだけの行為が、不相応なこの場に%PRONOUN(TARGET)%だけの“院”を建てていた。
		PRINTFORML
		PRINTFORML  見目を疑う%NOUN_SEX(TARGET)%らしさは欠片と霞み、
		PRINTFORMW  培われてきたと思われる威厳を%PRONOUN(TARGET)%は纏っていた。
		PRINTFORML 
		PRINTFORML 「少々驚かせてしまいましたね……？」
		PRINTFORMW  
		PRINTFORML  ……それがふと、ぷつりと祝詞が途切れると、
		PRINTFORMW  さきほどまでの不乱な姿は為りを潜め、呆気にとられてしまうほど明朗で、柔らかい声だった。
		PRINTFORML 
		PRINTFORML 「することが無いというのは困ったもので、何をするべきかを改めて考えていたのですが、
		PRINTFORMW   ――……何をした所で、今の私にはここで苦しむ人々の為に、祈りを捧げる事しか出来なかったのです」
		PRINTFORML  
		PRINTFORMW  そして、少しだけ顔を傾け振り向いた%PRONOUN(TARGET)%の、寂しげな微笑を%ANAME(MASTER)%は覗き見る。
		PRINTFORML 
		PRINTFORML 「ですが仮に、今此処で私を解放して下されば……
		PRINTFORMW   私は、私が成すべき人々の為に、これからも変わりなく尽くす事ができるでしょう」
		PRINTFORML 
		PRINTFORMW 「しかしそれはきっと……あなた方にとっての敵となるかもしれません」
		IF MASTER == 命蓮
			PRINTFORML 
			PRINTFORML  ――――え……？
			PRINTFORMW 
			PRINTFORML  その光景に、%PRONOUN(TARGET)%はありえないものを見たと言わんばかりに凍りついた。
			PRINTFORMW  %PRONOUN(TARGET)%にとってのそれは、見開いた片目越しに映る記憶の彼方に焼きつく、瓜二つと思しき人の姿。
			PRINTFORML  
			PRINTFORML  %ANAME(TARGET)%にとって生涯を共にした半身は、どうあっても取り戻すことの出来ない過去の時間。
			PRINTFORMW  それでも――……いや、だからこそ目の前にいる人物が誰かなどと、止まってしまった頭でも気づいてしまう。
			PRINTFORML  
			PRINTFORML  倒れかける半身に手をつき掛け、冷静になればなるほどよく分る。
			PRINTFORMW  似ているだけ……ちゃんと顔を突き会わせて話せば嫌でもわかる。それは違う、私ならわかる、と半濁する。
			PRINTFORML  
			PRINTFORMW  乾いてゆく口の中を、唾液を飲み下して潤し%PRONOUN(TARGET)%は覚悟を決めた。
			PRINTFORML
			PRINTFORML  
			PRINTFORML  ――――……姉さん。
			PRINTFORML 
			PRINTFORMW
			PRINTFORML 「%ANAME(MASTER)%っっっっ……！！」
			PRINTFORMW 
			PRINTFORML  転がる様に走り出していた。
			PRINTFORMW  それが蘇った人かどうかなど、今の%ANAME(TARGET)%にとってそれらは全てどうでもよくなってしまった一言。
			PRINTFORML  
			PRINTFORML  嘘ならそれでも構わない――……一時の夢であっても構わない。
			PRINTFORMW  %ANAME(MASTER)%を腕の中に抱きしめた%ANAME(TARGET)%は、ただ溢れる涙を流さずにはいられなかったのだった...
			CFLAG:TARGET:好感度 += 1000
			CFLAG:TARGET:依存度 += 500
		ELSE
			PRINTFORML  そして%PRONOUN(TARGET)%は姿勢を正して振り返った。
			PRINTFORMW  初めましてですね、と前置きすると、改めて%ANAME(MASTER)%に向き直る。
			PRINTFORML 
			PRINTFORML 「――――……私、命蓮寺の住職をしております、%NAME_FORMAL(TARGET)%と申します。
			PRINTFORMW   不要な争いに決着と、犠牲者をこれ以上増やさない為に……あなた方に反目した不逞の輩の一人です」
			PRINTFORML 
			PRINTFORMW  そして自己紹介を終えた%ANAME(TARGET)%は、深く長いため息を吐いたのだった...
		ENDIF
	;(初対面)
	ELSEIF !CFLAG:面識
		IF MASTER == 命蓮
			PRINTFORML 「――――え……？」
			PRINTFORMW 
			PRINTFORML  これはきっと、白昼夢の様なもの。
			PRINTFORMW  目の前の現実は、私にとって簡単に受け入れられるような事ではありません。
			PRINTFORML  
			PRINTFORML  目の前に突然現れた何処か見覚えのある立ち姿は、
			PRINTFORMW  幻想卿では珍しい……私達以外には纏う事も少ない編み笠に、袈裟衣装。
			PRINTFORML 
			PRINTFORMW  だからこそ微かに漂う香の匂いは、“あちら”から迷い込むにしては、落ち着ついた様に何処か違和感すら覚えていました。
			PRINTFORML  
			PRINTFORMW  それがまさか、傘に隠れて見えることの無い面の下から、“　　”が現れたとは思えず、私は息をする事が出来なかったのです。
			PRINTFORML  
			PRINTFORML  手に届くはずの無い場所へと旅立った、生涯の大半を供に過ごした半身。
			PRINTFORMW  仏の道を志す道半ばの、あの頃の、あの姿で……ここに立つ%PRONOUN(MASTER)%は、見紛う事無く“%ANAME(MASTER)%”だったのですから。
			PRINTFORML  
			PRINTFORMW  それが立て続けに――――“姉さん”だなんて、呼ばれてしまった私は、
			PRINTFORML 
			PRINTFORML 「――――ああ、%ANAME(MASTER)%、%ANAME(MASTER)%っ……？！
			PRINTFORMW   ああ、なんで？　でも、どうして？！　でも……ずっと、ずっと会いたかったの……！　会いたかったわ%ANAME(MASTER)%……！」
			PRINTFORML 
			PRINTFORMW  上り詰めてしまった感情に、今更歯止めなんてものは……利く筈がなかったのです。
			CFLAG:TARGET:好感度 += 1000
			CFLAG:TARGET:依存度 += 500
		ELSE
			PRINTFORML 「――――こんにちは。何か……お困りですか？」
			PRINTFORMW 
			PRINTFORML  目的の%NOUN_SEX(TARGET)%を探して%ANAME(MASTER)%が歩き回っていると、背中越しに掛けられた声に振り返る。
			PRINTFORMW  どこか人懐っこそうな、穏やかで柔らかな微笑みが、%ANAME(MASTER)%に向けられていた。
			PRINTFORML 
			PRINTFORML 「お困りのご様子でしたので、声を掛けさせていただきましたが……ご迷惑でしたか？」
			PRINTFORMW 
			PRINTFORML  先ほどから気に掛けていたのですが、と%PRONOUN(TARGET)%は言葉を付け足し、気遣う顔色を覗かせる。
			PRINTFORMW  どうしたものかと考えていた所で、%ANAME(MASTER)%は人を探していることを伝えようとし……ふと気付く。
			PRINTFORML  
			PRINTFORML  珍しい衣服に、鮮やかなグラデーションを伴う長い髪。
			PRINTFORMW  その一方で、編み笠に丈を携える姿は、探していた人物に合致しないかとそう思う。
			PRINTFORML 
			PRINTFORML 「もしお困りでしたら、お力になれることもあるかもしれません……差し支えなければ、教えていただけませんか？」
			PRINTFORMW 
			PRINTFORMW  %ANAME(MASTER)%が探していた人物は、もう探すまでも無く……%PRONOUN(TARGET)%であった。
			PRINTFORML 
			PRINTFORML 「――……そう言えば、ご挨拶が申し遅れました。
			PRINTFORMW   私、命蓮寺にて住職をしております、%NAME_FORMAL(TARGET)%と申します」
			PRINTFORML 
			PRINTFORMW  再度微笑みかけた%NOUN_SEX(TARGET)%は、その後、改めて柔らかな笑顔で%ANAME(MASTER)%を出迎えた...
		ENDIF
	;既に会ったことがある場合
	ELSE
		PRINTFORML 「――――ああ、困りました……本当に困りました……」
		PRINTFORMW 
		IF MASTER == 命蓮
			PRINTFORML 
			PRINTFORML 「あら%ANAME(MASTER)%、どうしたの？　え、私に？
			PRINTFORMW   ふふっ、最近顔を見せてくれないから心配していましたが、あまり変わりなくて良かったわ……」
			PRINTFORML 
			PRINTFORML 「え？　あ、ええまあ……大変な事に、各地でまた争い事が始まってしまったようでして……
			PRINTFORMW   でも……折角顔を見せてくれたのですから、まずはお姉ちゃんとゆっくりお話ししませんか？　ねっ♪」
		ELSE
			IF TALENT:正妻
				IF SEXUAL_LAST_EXPERIENCE:MASTER:初体験_キス != "%ANAME(TARGET)%の唇" || SEXUAL_LAST_EXPERIENCE:MASTER:初体験_処女 != "%ANAME(TARGET)%" || SEXUAL_LAST_EXPERIENCE:MASTER:初体験_アナル処女 != "%ANAME(TARGET)%"
					PRINTFORML 
					PRINTFORML 「…………あら%ANAME(MASTER)%ですか、お帰りなさい。
```
