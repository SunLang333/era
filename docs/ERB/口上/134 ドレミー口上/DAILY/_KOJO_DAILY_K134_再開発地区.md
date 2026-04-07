# 口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_再開発地区.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/DAILY/_KOJO_DAILY_K134_再開発地区.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K134_SAIKAIHATU_RATE, KOJO_DAILY_K134_SAIKAIHATU_DECISION, KOJO_DAILY_K134_SAIKAIHATU_GENRE, KOJO_DAILY_K134_SAIKAIHATU, EVENTTRAIN_KOJO_DAILY_K134_SAIKAIHATU, EVENTEND_KOJO_DAILY_K134_SAIKAIHATU; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K134_SAIKAIHATU_RATE(対象)
#DIM 対象
RETURN 50

;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K134_SAIKAIHATU_DECISION(対象)
#DIM 対象

;ドレミーと面識があり、所属がおなじ、5%

;終わってたら発生しない
SIF KDVAR:対象:ドレミー_再開発 == -1
	RETURN 0

RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0, 1)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K134_SAIKAIHATU_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K134_SAIKAIHATU(対象)
#DIM 対象
#DIM 必要額


SELECTCASE KDVAR:対象:ドレミー_再開発
	CASE 0
		PRINTFORMW 仕事がひと段落し、%ANAME(MASTER)%は警邏という名目で城下町を散歩している
		PRINTFORML 周囲を見渡すと、活気のある店が立ち並ぶ大通りに様々な役人職人がけたたましく働いている
		PRINTFORMW しばらく歩き回っていると、メモを取りながら廃墟の傍を歩く%ANAME(対象)%の姿が見えた……
		PRINTFORMW 「うーん……前の戦いで完全にダメにされちゃったわね。　これは再開発対象ねぇ」
		PRINTFORMW やる事も特に無かった%ANAME(MASTER)%は、%ANAME(対象)%に声を掛けた
		PRINTFORML
		PRINTFORML 「あら%ANAME(MASTER)%、どうしたのこんなところで？」
		PRINTFORMW 「私？　仕事中よ、城下町の再開発地区計画の構想を練ってる所ね」
		PRINTFORMW %ANAME(対象)%のメモを覗くと、今いる場所周辺が再開発地区の対象のようだ
		PRINTFORMW 「ここ一帯をどうしようか決めかねてるのよね、飲食街にするか住宅街にするか……」
		PRINTFORMW どうやら%ANAME(対象)%は、この付近の施設をどのようなものにするか決めかねているようだ……
		KDVAR:対象:ドレミー_再開発 = 1
		PRINTFORML 
		CALL ASK_MULTI("飲食街なんて良いんじゃないのか", "住宅街を増やそう", "ここは娼婦街だろう！")
		SELECTCASE RESULT
			CASE 0
				PRINTFORMW 「う～ん良いですねぇ、美味しい料理は人を元気にしてくれますからね、これは人であっても妖怪であっても一緒です」
				PRINTFORMW 「えっ？　私の主食は確かに悪夢ですが……いや甘味は別腹です。　えぇ別腹なので」
				PRINTFORMW %ANAME(MASTER)%はそのあとも%ANAME(対象)%と食べてみたい料理を語りながら視察を続けた……
				KDVAR:対象:ドレミー_再開発イベント = 0
			CASE 1
				PRINTFORMW 「そうねぇ……人が多く住めれば確かに働き手も多くなる。　それに私個人としても食源も増えて願ったり叶ったり」
				PRINTFORMW 「ふむふむ、そう考えれば娯楽よりも衣食住の確保は大事ですから適案かしら」
				PRINTFORMW %ANAME(MASTER)%はそのあとも%ANAME(対象)%と新たな働き手の確保について相談しながら視察を続けた……
				KDVAR:対象:ドレミー_再開発イベント = 1
			CASE 2
				;恋慕と合意を持っていると発動(タイミング的に周回プレイで維持じゃないと厳しいかも&この選択肢を選ぶ覚悟)
				IF TALENT:対象:恋慕 && TALENT:対象:合意
					PRINTFORMW 「おやおや、それはつまり……」
					PRINTFORML そう提案した%ANAME(MASTER)%に、%ANAME(対象)%は笑みを浮かべた
					PRINTFORMW 「畏まりました、そういうプレイがお好きでしたなら次までに準備しておくわ……」
					PRINTFORMW 「ふふっ、楽しみにしてて♥」
					PRINTFORMW %ANAME(MASTER)%達は視察を続けたが妖艶な女の表情になった%ANAME(対象)%のせいか集中出来なかった……
					KDVAR:対象:ドレミー_再開発イベント = 2
				ELSE
					PRINTFORMW 「……はぁ、そういう冗談はあまり好きじゃないわ」
					PRINTFORMW 「ったく、真面目に考えてくださいねー」
					PRINTFORMW %ANAME(MASTER)%達は視察を続けたが%ANAME(対象)%は不機嫌な様子だった……
					;強制的に飲食街を選んだ結果となる
					KDVAR:対象:ドレミー_再開発イベント = 0
				ENDIF
		ENDSELECT
	;---------------------------------------------------------------------------------------------------------------------------------------------------------------------
	CASE 1
	;先にイベントで必要な金額を決める
		必要額 = RAND(DAY *100, DAY * 300)
	;前のイベントで選んだ選択肢によってイベントが変わる
		PRINTFORMW 仕事が一段落し、%ANAME(MASTER)%は城下町に訪れている
		PRINTFORML そういえば前回、再開発について話した場所はどうなっただろうか
		PRINTFORMW %ANAME(MASTER)%は再開発地区へ向かうことにした……
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORML ・
		SELECTCASE KDVAR:対象:ドレミー_再開発イベント
			;飲食街を選んだ場合
			CASE 0
				PRINTFORML 再開発地区は民達で賑わう飲食街となっているようだ
				PRINTFORMW 店のほとんどは立ち食いの軽食だが賑わっている
				PRINTFORML 一部の店では労役者のための炊き出しも行われている
				PRINTFORMW 時々ピンク髪の仙人や亡霊による大食いで賑わうなんて噂も聞こえてくる
				PRINTFORMW ……いやそれは問題な気がするが
				PRINTFORMW %ANAME(MASTER)%は辺りから匂う香ばしい料理の匂いにつられ軽食を取る事にした
				PRINTFORML どの店にしようか歩いていると%ANAME(MASTER)%は%ANAME(対象)%と出会った
				PRINTFORML 「今からごはん？　なら私も一緒して良いかしら？」
				PRINTFORMW 「さっき仕事がひと段落してねー。　折角だし民の皆様と同じものを食べていきたいなぁーってね」
				PRINTFORMW 飲食街を歩く二人はある程度気になる店をピックアップしていった
				PRINTFORMW さてどこにしようか……？
				PRINTFORML
				CALL ASK_MULTI("団子屋", "おでん屋", "焼き鳥屋")
				SELECTCASE RESULT
					CASE 0
						PRINTFORMW 「お団子！　イイわ、行きましょ！」
						PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%に連れられ団子屋に向かった……
						PRINTFORML ・
						PRINTFORML ・
						PRINTFORML ・
						PRINTFORMW %ANAME(対象)%に案内され着いた場所には団子屋が二軒並んでた
						PRINTFORML 「そういえばここの団子屋さん、二つに分かれてるのよね」
						PRINTFORMW 「三食団子とずんだ団子、みたらし団子と黒胡麻団子……どれも食べたいけど4本は多いわね」
						PRINTFORMW 団子の食べ過ぎに注意するあまり悩む%ANAME(対象)%、%ANAME(MASTER)%は目の前で4種類の団子を買って見せた
						PRINTFORMW %ANAME(MASTER)%は1本に4つ刺さっているのなら%ANAME(対象)%と自分で分け合えば全部少しずつ食べられるだろうと提案した
						IF TALENT:対象:恋慕
							PRINTFORMW 「それは……良いですねぇ。　そうしましょうか」
							PRINTFORML %ANAME(対象)%は笑みを浮かべ%ANAME(MASTER)%の手を引いて席に着いた
							PRINTFORMW 「ほら口開けて、食べさせてあげるわ。　あーん」
							PRINTFORMW 団子を食べさせてくる%ANAME(対象)%に%ANAME(MASTER)%は答える様に団子を頬張った
							PRINTFORMW 「ほら、もう一口」
							PRINTFORMW 更に一口と食べさせてくる%ANAME(対象)%、妙に周囲の目線が気になる……
							PRINTFORMW 「それで……その団子は私が貰っちゃおうかしら？」
							PRINTFORMW 団子を咀嚼する%ANAME(MASTER)%の顎に手を当てて顔を近づける%ANAME(対象)%
							PRINTFORMW %ANAME(MASTER)%は驚いた勢いで咽てしまった……
							PRINTFORMW 「ふふっ冗談よ、冗談」
							PRINTFORMW そう言って%ANAME(対象)%は残った団子を食べている
						ELSE
							PRINTFORMW 「……あぁ、また貴方はそうやって恥ずかしい事を平然と」
							PRINTFORMW 「いえいえ、良いですとも。　ただ少し周りの目が……」
							PRINTFORML %ANAME(対象)%と%ANAME(MASTER)%席に着いて団子を食べ始めた
							PRINTFORMW 「今の私達って……まるで恋人みたいね」
							PRINTFORMW 「べっ、別にうれしいとかそういうのじゃありませんしー」
							PRINTFORMW 「あーもう、周りの目が気になって味が分からないわ……」
							PRINTFORMW 「……でも美味しいわね、%ANAME(MASTER)%」
							PRINTFORMW %ANAME(対象)%は美味しそうに団子を頬張っている
						ENDIF
						PRINTFORMW 二人はその後も団子を楽しんだ……
						CALL COLOR_PRINTW("好感度が 200上がった", カラー_注意)
						CFLAG:対象:好感度 += 200
					CASE 1
						PRINTFORMW 「なかなか渋い選択ね。　%ANAME(MASTER)%のそういうところ好きですよ」
						PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%に連れられ団子屋に向かった……
						PRINTFORML ・
						PRINTFORML ・
						PRINTFORML ・
						PRINTFORML 出汁の香りを漂わせる屋台の元では騒がしい屈強な男たちがおでんを肴に酒を飲んでいる
						PRINTFORMW ここはどうやら非番の兵士や労役者たちの憩いの場のようだ
						PRINTFORMW さっそく%ANAME(MASTER)%と%ANAME(対象)%は適当に注文した
						PRINTFORMW 「……」
						PRINTFORMW 料理が来るのを待っていると%ANAME(対象)%が怪訝な顔で他の客を見ていた
						PRINTFORMW %ANAME(MASTER)%はどうかしたのか？と尋ねた
						PRINTFORML 「向こうの彼、確か今日は非番じゃないのに真昼間からお酒を飲んでるのよね」
						PRINTFORMW 「やれやれ情けない部下ね、少し説教しに行こうかしら」
						PRINTFORMW 席を立とうとする%ANAME(対象)%に%ANAME(MASTER)%は……
						PRINTFORML
						CALL ASK_YN("無視すれば良い", "説教なら任せろ")
						IF RESULT == 0
							PRINTFORML 『無視すれば良い』
							PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%に諭した
							PRINTFORML 「……そうね、今は"私たちの"休憩時間ですからね」
							PRINTFORMW 「叱るのはあとにして、今は二人の時間を満喫するべきね」
							PRINTFORMW しばらくすると注文した料理が届いた……が
							PRINTFORML 「……ねぇところで」
							PRINTFORMW 「なんで%ANAME(MASTER)%までお酒を頼んでいるのかしら？」
							PRINTFORMW 美味しそうに酒を飲む彼等を見ていたら自分も飲みたくなったからだ
							PRINTFORML 「あぁ……そうやって貴方はそう」
							PRINTFORMW 「私にも一杯貰いますからね」
							PRINTFORMW %ANAME(MASTER)%よりも先に酒を注いで飲む%ANAME(対象)%
							PRINTFORML 「……はぁ～美味いわ、こうやって仕事の合間に飲むお酒は格別ね」
							PRINTFORMW 「ははぁん、あとで再開発の打ち合わせあるのにお酒を飲む……この背徳感、最高ね～ぇ」
							PRINTFORMW 一人でにややハイペースで飲む%ANAME(対象)%、%ANAME(MASTER)%は少し心配になり酒を飲まずに相槌を打った
							PRINTFORML ・
							PRINTFORML ・
							PRINTFORML ・
							PRINTFORMW 『えっ、今日は%ANAME(対象)%様の体調が優れないのですか？』
							PRINTFORMW ……だから今日は%ANAME(対象)%代理で来た
							PRINTFORMW 『そうでしたか。　では%ANAME(MASTER)%様、この開発地図を――』
							PRINTFORMW %ANAME(MASTER)%は丸一日酒に潰れた%ANAME(対象)%の代わりに仕事をこなす羽目になった
							CALL COLOR_PRINTW("好感度が 300上がった", カラー_注意)
							CALL ADD_COOLTIME(MASTER, 1)
							CALL ADD_COOLTIME(対象, 1)
							CFLAG:対象:好感度 += 300
						ELSE
							PRINTFORML 『説教なら任せろ』
							PRINTFORMW そう言って%ANAME(MASTER)%は立ち上がり酒を飲む%ANAME(対象)%の部下の元へ向かった
							PRINTFORML 『ｱﾚ！？　%ANAME(MASTER)%様！？　ﾁｮﾘｨｨｨｽｯｯｯ！』
							PRINTFORML 『えっ？　オレッスか？　いえいえ、今日も仕事バリバリっすよ！』
							PRINTFORML 『いやいや！　この程度のお酒じゃオレは酔わないッスよ！』
							PRINTFORML 『それより%ANAME(MASTER)%様も飲みましょうぜ！』
```
