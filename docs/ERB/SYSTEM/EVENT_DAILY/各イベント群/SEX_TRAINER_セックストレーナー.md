# SYSTEM/EVENT_DAILY/各イベント群/SEX_TRAINER_セックストレーナー.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/SEX_TRAINER_セックストレーナー.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_SEX_TRAINER_RATE, EVENT_DAILY_SEX_TRAINER_DECISION, EVENT_DAILY_SEX_TRAINER_GENRE, EVENT_DAILY_SEX_TRAINER; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@EVENT_DAILY_SEX_TRAINER_RATE()
RETURN 30


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@EVENT_DAILY_SEX_TRAINER_DECISION()
RETURN DAY >= 15

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@EVENT_DAILY_SEX_TRAINER_GENRE()
RETURN デイリー_ジャンル_トレーナー

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@EVENT_DAILY_SEX_TRAINER()
#DIM 消去行
#DIM 対象
#DIM 表示位置
#DIM 表示ページ
#DIM 総ページ数
#DIM キャラ数
#DIM キャラカウンタ
#DIM 表示開始位置
#DIM 表示終了位置

IF DVAR:セックストレーナー_発生フラグ == 0
	PRINTFORML %ANAME(MASTER)%が仕事をしていると、侍従が来客を告げた
	PRINTFORML なんでも「やけになまめかしい女性が来た」のだそうだ
	PRINTFORMW 何のことやらと思った%ANAME(MASTER)%は、会うことにしてみた
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW 「あなたが%ANAME(MASTER)%？　噂通りの\@ IS_FEMALE(MASTER) ? かわいい子 # いい男 \@ね」
	PRINTFORMW 待っていた女は、なるほど確かになまめかしかった
	PRINTFORML 目鼻立ちの整った美貌に、豊満でありながら引き締まった身体が透けるほど薄い衣装を身に纏っている
	PRINTFORML そこにいるだけで回りのものを興奮させるような性的魅力を振りまいていた
	PRINTFORMW まるで淫魔の類のようだ……あるいは、本当にそのものかもしれない
	PRINTFORML 「ねぇあなた、夜の生活は潤っているかしら？」
	PRINTFORML 「私は色んな人に、性の手ほどきをして回っているの。性の悦びを知ってもらいたくてね」
ELSE
	PRINTFORML 「こんにちは、また来たわよ」
	PRINTFORMW 「性の手ほどき、受けてみないかしら」
	PRINTFORMW 例の妖艶な女性がまた訪ねてきた
ENDIF
CALL ICPRINT("「どう？　金<20000>で手ほどきしてあげられるけど」", "L", カラー_注意)
PRINTFORML 女性の艶やかさに思わず即決しそうになったが、慌てて首を振り冷静になる
PRINTFORMW 提示されたのは決して安くない額だ。落ちついて考えるべきだろう
PRINTFORMW さて、どうするか……
PRINTFORML
CALL SINGLE_DRAWLINE
PRINTFORML 現在の金:{MONEY}
CALL ASK_MULTI_JUDGE("手ほどきしてもらう", MONEY >= 20000, "やめておく", 1)

IF RESULT == 1
	PRINTFORML 「あら、そう……それなら仕方ないわね」
	PRINTFORMW 「また来るわ、そのときはいいお返事を期待してるわね？」
	PRINTFORMW 女性は去って行った……
	DVAR:セックストレーナー_発生フラグ = 1
	RETURN 1
ENDIF
PRINTFORML 「そう言ってくれると思ってたわ」
PRINTFORML 「それじゃあ……、誰に手ほどきしようかしら？」
CALL SINGLE_DRAWLINE
PRINTFORML 「そうそう、もう十分に敏感なトコロは、これ以上手ほどきできないわ、ごめんなさいね」
CALL SINGLE_DRAWLINE
PRINTFORML %TOSTR_SPACE(23)%   Ｃ|  Ｖ|  Ａ|  Ｂ|  Ｍ %TOSTR_SPACE(26)%   Ｃ|  Ｖ|  Ａ|  Ｂ|  Ｍ 

VARSET キャラ数
FOR LOCAL, 0, CHARANUM
	SIF CFLAG:(LOCAL:0):所属 == CFLAG:MASTER:所属
		キャラ数 ++
NEXT

総ページ数 = (キャラ数 - 1) / 40 + 1
表示ページ = 1
CALL TMP_CREATE_IS_FREE_MAP

$SHOW_LOOP
VARSET 消去行
VARSET 表示位置
VARSET キャラカウンタ
表示開始位置 = (表示ページ - 1) * 40
表示終了位置 = 表示ページ * 40

FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):所属 == CFLAG:MASTER:所属 && !CFLAG:(LOCAL:0):捕虜先
		IF 表示開始位置 <= キャラカウンタ && キャラカウンタ < 表示終了位置
			IF 表示位置 % 2 != 0
				PRINT 　　
			ELSEIF 表示位置 >= 1
				PRINTL 
				消去行 ++
			ENDIF
			PRINTFORM [{LOCAL:0 + 99, 4}]%ANAME(LOCAL:0), 16, RIGHT%
			PRINTFORM   
			IF TALENT:(LOCAL:0):Ｃ敏感
				PRINTFORM   
				CALL COLOR_PRINT("敏", カラー_注意)
			ELSEIF TALENT:(LOCAL:0):Ｃ鈍感
				PRINTFORM   
				CALL COLOR_PRINT("鈍", カラー_警告)
			ELSE
				PRINTFORM    
				CALL COLOR_PRINT("-", カラー_選択不可)
			ENDIF
			PRINTFORM |
			IF TALENT:(LOCAL:0):Ｖ敏感
				PRINTFORM   
				CALL COLOR_PRINT("敏", カラー_注意)
			ELSEIF TALENT:(LOCAL:0):Ｖ鈍感
				PRINTFORM   
				CALL COLOR_PRINT("鈍", カラー_警告)
			ELSE
				PRINTFORM    
				CALL COLOR_PRINT("-", カラー_選択不可)
			ENDIF
			PRINTFORM |
			IF TALENT:(LOCAL:0):Ａ敏感
				PRINTFORM   
				CALL COLOR_PRINT("敏", カラー_注意)
			ELSEIF TALENT:(LOCAL:0):Ａ鈍感
				PRINTFORM   
				CALL COLOR_PRINT("鈍", カラー_警告)
			ELSE
				PRINTFORM    
				CALL COLOR_PRINT("-", カラー_選択不可)
			ENDIF
			PRINTFORM |
			IF TALENT:(LOCAL:0):Ｂ敏感
				PRINTFORM   
				CALL COLOR_PRINT("敏", カラー_注意)
			ELSEIF TALENT:(LOCAL:0):Ｂ鈍感
				PRINTFORM   
				CALL COLOR_PRINT("鈍", カラー_警告)
			ELSE
				PRINTFORM    
				CALL COLOR_PRINT("-", カラー_選択不可)
			ENDIF
			PRINTFORM |
			IF TALENT:(LOCAL:0):Ｍ敏感
				PRINTFORM   
				CALL COLOR_PRINT("敏", カラー_注意)
			ELSEIF TALENT:(LOCAL:0):Ｍ鈍感
				PRINTFORM   
				CALL COLOR_PRINT("鈍", カラー_警告)
			ELSE
				PRINTFORM    
				CALL COLOR_PRINT("-", カラー_選択不可)
			ENDIF
			表示位置++
		ENDIF
		キャラカウンタ ++
	ENDIF
NEXT

PRINTL
CALL SINGLE_DRAWLINE

IF 総ページ数 >= 2
	消去行 += 2
	IF 表示ページ > 1
		PRINT [  8] 前のページ            
	ELSE
		PRINT                             
	ENDIF
	LOCALS:0 = ページ{表示ページ}/{総ページ数}
	PRINTPLAINFORM %LOCALS:0, 28, LEFT%
	IF 表示ページ < 総ページ数
		PRINT [  9] 後のページ
	ENDIF
	PRINTL 
	CALL SINGLE_DRAWLINE
ENDIF

PRINTL [  0] 戻る

REDRAW 0

消去行 += 4

INPUT

IF RESULT == 8 && 表示ページ > 1
	表示ページ --
	CLEARLINE 消去行
	GOTO SHOW_LOOP
```
