# SYSTEM/EVENT_DAILY/各イベント群/TERRITORY_WALKING_領内ぶらりエロの旅.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/TERRITORY_WALKING_領内ぶらりエロの旅.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_TERRITORY_WALKING_RATE, EVENT_DAILY_TERRITORY_WALKING_DECISION, EVENT_DAILY_TERRITORY_WALKING_GENRE, EVENT_DAILY_TERRITORY_WALKING_SETTARGET, EVENT_DAILY_TERRITORY_WALKING; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_TERRITORY_WALKING_RATE()
RETURN 50


;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_TERRITORY_WALKING_DECISION()

;勢力に所属していないか捕虜だと駄目
SIF CFLAG:MASTER:所属 == 0 || CFLAG:MASTER:捕虜先 != 0
	RETURN 0
	
SIF DAY < 7
	RETURN 0
	
SIF !HAS_PENIS(MASTER)
	RETURN 0
	
RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_TERRITORY_WALKING_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_TERRITORY_WALKING_SETTARGET()
;遭遇キャラの選出、該当キャラが見つからない場合はキャンセル
FOR LOCAL, 0, CHARANUM
	;同勢力に所属しているキャラ
	IF LOCAL != MASTER && CFLAG:(LOCAL):所属 == CFLAG:MASTER:所属 && !CFLAG:(LOCAL):捕虜先 && !IS_ANIMAL(LOCAL)
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
		DAILY_TARGET_NUM ++
	ENDIF
NEXT
SIF DAILY_TARGET_NUM < 1
	RETURN 0

RETURN 1
;---------------------
;本体
;---------------------
@EVENT_DAILY_TERRITORY_WALKING()
#DIM 対象

対象 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)

PRINTFORMW とある日。特にすることも無くて退屈な休日だ……
PRINTFORMW %ANAME(MASTER)%は暇つぶしも兼ねて、視察がてら領内をぶらりと見て回ることにした
PRINTFORMW さて、どこに行こう……
PRINTFORML 
CALL ASK_MULTI("酒場", "歓楽街", "町中をぶらぶら", "夜の繁華街", "色町", "スラム街", "止めておく")
SELECTCASE RESULT
	;酒場（人妻ルート）
	CASE 0
		PRINTFORMW 酒場に行ってみよう
		PRINTFORML …
		PRINTFORMW ……
		;1/4で酒場で飲んでるキャラと遭遇
		IF !RAND:4
			PRINTFORMW 酒場に着くと、店の奥で%ANAME(対象)%が飲んでいた
			SIF CFLAG:対象:面識 == 0
				CFLAG:対象:面識 = 1
			PRINTFORMW …はて。たしか%ANAME(対象)%は今、勤務中のはずでは……
			PRINTFORML %ANAME(対象)%が%ANAME(MASTER)%の姿を見つけると
			PRINTFORMW こっちに来なよ、とばかりに手招きされる
			PRINTFORML どうやら完全に酔っ払っているようだ
			PRINTFORMW %ANAME(MASTER)%は%ANAME(対象)%の絡み酒に付き合わされた……
			CALL PRINT_ADD_EXP(MASTER, "肝臓経験値", RAND(5, 15), 1)
			CALL PRINT_ADD_EXP(対象, "肝臓経験値", RAND(10, 30), 1)
			CALL TRAIN_AUTO_ABLUP(MASTER)
			CALL TRAIN_AUTO_ABLUP(対象)
			CFLAG:対象:好感度 += 80
			RETURN
		ENDIF
		;愛人化以降
		IF DVAR:領内ぶらりエロの旅_人妻 >= 4
			PRINTFORML %ANAME(MASTER)%の愛人となった人妻が、今日も飲んでいた
			PRINTFORMW 声をかけてみると、彼女はとても嬉しそうな顔で%ANAME(MASTER)%を迎えてくれた
			PRINTFORML しばし彼女との他愛無い会話を楽しんだ…
			PRINTFORMW そして日が落ち始めた頃に、彼女は%ANAME(MASTER)%に抱きつき、　また自分を抱いてほしい　と熱っぽく囁いてきた
			PRINTFORML どうやら%ANAME(MASTER)%に抱かれることを期待して、毎日ここで待っていたようだ
			PRINTFORML そんな健気な彼女の要望に応えるべく、%ANAME(MASTER)%は彼女を抱き寄せ、連れ込み宿で愛し合うことにした
			PRINTFORMW そして%ANAME(MASTER)%との行為の前に、彼女は薬指のリングを外した……
			PRINTFORML 
			SELECTCASE RAND:4
				CASE 0
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室でベッドを軋ませながら獣の様に激しく愛し合っている
					PRINTFORML 彼女は瞳に♥を浮かべながら激しく腰を振り、%ANAME(MASTER)%の名前を何度も呼び求めてくる
					PRINTFORMW 激しく巧みな腰つきに一物を刺激され、思わず彼女の腰を強くつかんで深く肉壷を抉る
					PRINTFORML 女としての悦びを満たしてくれる%ANAME(MASTER)%のとセックスに、彼女は幸せを感じているようで
					PRINTFORMW いざ射精の瞬間、彼女は%ANAME(MASTER)%にぎゅっと抱きつき、%ANAME(MASTER)%の子種を子宮で受け止めた……
				CASE 1
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室で互いに唇を深く交わらせながら激しく愛し合っている
					PRINTFORML 自分を女として見なかった男より、自分の淫らな本性を満たしてくれる%ANAME(MASTER)%とのセックスに、
					PRINTFORMW 彼女は至上の幸福を感じ、その幸福感が肉体をさらに敏感にしていく
					PRINTFORMW %ANAME(MASTER)%もまた、一人の女が夫より自分を選んだという背徳的な事実に肉棒を漲らせ、彼女をいっそう求めていく
					PRINTFORMW 二人は互いに求め合うまま、何度も腰を打ち付け背徳の快楽を貪った……
				CASE 2
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室にてベッドを軋ませながら騎乗位で激しく愛し合っている
					PRINTFORML 彼女は愛する%ANAME(MASTER)%のお腹に手を置き、はしたなく喘ぎ声を漏らしながら激しく腰を上下に打ち付ける
					PRINTFORMW 自分の淫らな雌の本性を受け止めてくれる%ANAME(MASTER)%とのセックスが彼女の心を幸せで満たしていく
					PRINTFORMW その顔は快感に蕩けきっており、夫ではなく%ANAME(MASTER)%の名を何度も呼びながら何度も絶頂する
					PRINTFORMW その後も%ANAME(MASTER)%に跨り情熱的なキスを交わしながら、二人はなお激しく交わっていく……
				CASE 3
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室にて正常位で激しく愛し合っている
					PRINTFORML 彼女は%ANAME(MASTER)%とのセックスに幸せを感じているようで、愛する人にしかしないような情熱的なキスを交わす
					PRINTFORMW 女としてのはしたない欲求を満たしてくれる%ANAME(MASTER)%のことを、彼女は心から愛しているようだ
					PRINTFORML %ANAME(MASTER)%がペニスを突きこむたび、彼女は脚を%ANAME(MASTER)%の腰に絡め、より膣内深くまでペニスを迎える
					PRINTFORMW そして絶頂の瞬間、彼女は%ANAME(MASTER)%に力いっぱい抱きついて密着し、その子種を子宮で受け止めた……
			ENDSELECT
			CALL FUCK(MASTER, "性技, 性交, Ｃ, 射精", "童貞喪失, キス喪失, Ｖ挿入", 0, "愛人の女の唇", "", "愛人の女の膣", "和姦")
			PRINTFORML 
			PRINTFORML たっぷり楽しんだ後、夜明け前に宿を出た
			PRINTFORMW 彼女は%ANAME(MASTER)%に長いキスをして「また、私を抱いてください」と告げ、手を振って%ANAME(MASTER)%を見送った……

		;4回目で愛人になる
		ELSEIF DVAR:領内ぶらりエロの旅_人妻 == 3
			PRINTFORML 何度か関係を持った人妻が、今日も飲んでいた
			PRINTFORMW 声をかけてみると、彼女は嬉しそうな顔で%ANAME(MASTER)%を迎えてくれた
			PRINTFORML 今回はほろ酔い程度のようで、穏やかな会話を楽しんだ…
			PRINTFORMW 楽しい一時が終わると、彼女は%ANAME(MASTER)%に抱きつき、　自分を抱いてくれ　と熱っぽく囁いてきた
			PRINTFORML
			PRINTFORML いわく、%ANAME(MASTER)%と関係を持ってから肉体の欲求不満が満たされたおかげか、
			PRINTFORMW 夫との喧嘩もめっきり少なくなり、表向きの関係は良好になった
			PRINTFORMW でも、自分を女として抱いてくれるのは%ANAME(MASTER)%の方だ。自分を満たしてくれるのは%ANAME(MASTER)%だけだ
			PRINTFORMW だから自分を、%ANAME(MASTER)%の女にしてほしい　と……
			PRINTFORML
			PRINTFORMW 彼女は潤んだ瞳で%ANAME(MASTER)%を見上げる。その表情は恋する乙女そのものだった
			PRINTFORML ･･･
			PRINTFORMW こんな魅力的な女性が、女として見られないというのは残酷なことだ
			PRINTFORMW 望みどおり、彼女を自分の女にしてやろう
			PRINTFORML %ANAME(MASTER)%は彼女を抱き寄せ、連れ込み宿で愛し合うことにした
			PRINTFORMW そして%ANAME(MASTER)%との行為の前に、彼女は薬指のリングを外した……
			PRINTFORML 
			SELECTCASE RAND:4
				CASE 0
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室でベッドを軋ませながら獣の様に激しく愛し合っている
					PRINTFORML 彼女は瞳に♥を浮かべながら激しく腰を振り、%ANAME(MASTER)%の名前を何度も呼び求めてくる
					PRINTFORMW 激しく巧みな腰つきに一物を刺激され、思わず彼女の腰を強くつかんで深く肉壷を抉る
					PRINTFORML 女としての悦びを満たしてくれる%ANAME(MASTER)%のとセックスに、彼女は幸せを感じているようで
					PRINTFORMW いざ射精の瞬間、彼女は%ANAME(MASTER)%にぎゅっと抱きつき、%ANAME(MASTER)%の子種を子宮で受け止めた……
				CASE 1
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室で互いに唇を深く交わらせながら激しく愛し合っている
					PRINTFORML 自分を女として見なかった男より、自分の淫らな本性を満たしてくれる%ANAME(MASTER)%とのセックスに、
					PRINTFORMW 彼女は至上の幸福を感じ、その幸福感が肉体をさらに敏感にしていく
					PRINTFORMW %ANAME(MASTER)%もまた、一人の女が夫より自分を選んだという背徳的な事実に肉棒を漲らせ、彼女をいっそう求めていく
					PRINTFORMW 二人は互いに求め合うまま、何度も腰を打ち付け背徳の快楽を貪った……
				CASE 2
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室にてベッドを軋ませながら騎乗位で激しく愛し合っている
					PRINTFORML 彼女は愛する%ANAME(MASTER)%のお腹に手を置き、はしたなく喘ぎ声を漏らしながら激しく腰を上下に打ち付ける
					PRINTFORMW 自分の淫らな雌の本性を受け止めてくれる%ANAME(MASTER)%とのセックスが彼女の心を幸せで満たしていく
					PRINTFORMW その顔は快感に蕩けきっており、夫ではなく%ANAME(MASTER)%の名を何度も呼びながら何度も絶頂する
					PRINTFORMW その後も%ANAME(MASTER)%に跨り情熱的なキスを交わしながら、二人はなお激しく交わっていく……
				CASE 3
					PRINTFORMW %ANAME(MASTER)%達は、宿の一室にて正常位で激しく愛し合っている
					PRINTFORML 彼女は%ANAME(MASTER)%とのセックスに幸せを感じているようで、愛する人にしかしない情熱的なキスを交わす
					PRINTFORMW 女としてのはしたない欲求を満たしてくれる%ANAME(MASTER)%のことを、彼女は心から愛しているようだ
					PRINTFORML %ANAME(MASTER)%がペニスを突きこむたび、彼女は脚を%ANAME(MASTER)%の腰に絡め、より膣内深くまでペニスを迎える
					PRINTFORMW そして絶頂の瞬間、彼女は%ANAME(MASTER)%に力いっぱい抱きついて密着し、その子種を子宮で受け止めた……
			ENDSELECT
			CALL FUCK(MASTER, "性技, 性交, Ｃ, 射精", "童貞喪失, キス喪失, Ｖ挿入", 0, "愛人の女の唇", "", "愛人の女の膣", "和姦")
			PRINTFORML 
			PRINTFORML たっぷり楽しんだ後、夜明け前に宿を出た
			PRINTFORMW 彼女は%ANAME(MASTER)%に長いキスをして「また、私を抱いてください」と告げ、手を振って%ANAME(MASTER)%を見送った……
			PRINTFORMW 人妻は%ANAME(MASTER)%の愛人になった
			DVAR:領内ぶらりエロの旅_人妻 += 1
			
		;2回目以降	
		ELSEIF DVAR:領内ぶらりエロの旅_人妻 >= 1
			PRINTFORMW そういえば、前に関係を持った人妻が連絡先を渡してくれた
			PRINTFORML そこに書かれている酒場に行ってみると、彼女はそこで飲んでいた
			PRINTFORML 今日も一緒に飲もうかと、ちょっと声をかけてみた
			PRINTFORMW 今回も既に酔っ払っており、またも絡み酒につき合わされた
			PRINTFORML 以前の%ANAME(MASTER)%とのセックスで、身体を重ねる快感を再確認したとのことだが
			PRINTFORML 彼女の夫は夜の生活に関心が薄いらしく、セックスレス気味で不満がたまっているようだ
			PRINTFORMW 今日も喧嘩をしてやけ酒をしているところ、との事だ
			PRINTFORMW 泥酔する彼女に抱きつかれた%ANAME(MASTER)%は、今回も一緒に飲む事にした
			PRINTFORML ･･･
			PRINTFORMW ･･････
			PRINTFORMW %ANAME(MASTER)%は酔いが回った彼女に今回も求められ、流されるまま連れ込み宿で身体を重ねることにした……
			PRINTFORML 
			SELECTCASE RAND:4
				CASE 0
					PRINTFORML %ANAME(MASTER)%達は、宿の一室でベッドを軋ませながら獣の様に交わりあっている
					PRINTFORMW 彼女は髪を振り乱しながら激しく腰を振り、%ANAME(MASTER)%の名前を呼んで求めて来る
					PRINTFORMW 激しく巧みな腰つきに一物を刺激され、たまらず彼女の腰を強くつかんでしまう
					PRINTFORMW 我慢できずに彼女に求められるままに腰を打ち付け、何度もその中に精を放った……
				CASE 1
					PRINTFORML %ANAME(MASTER)%達は、宿の一室で互いにキスの雨を降らしながら激しく交わりあっている
					PRINTFORMW 夫を差し置き、他の男を誘って抱かれるという不義が、彼女に強い興奮をもたらし、身体の感度を上げていく
```
