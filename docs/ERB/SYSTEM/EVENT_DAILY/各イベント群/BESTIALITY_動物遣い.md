# SYSTEM/EVENT_DAILY/各イベント群/BESTIALITY_動物遣い.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/BESTIALITY_動物遣い.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_BESTIALITY_RATE, EVENT_DAILY_BESTIALITY_DECISION, EVENT_DAILY_BESTIALITY_SETTARGET, SELECT_CHARA_RANDOM_LOGIC_DAILY_BEASTALITY, SELECT_CHARA_RANDOM_BIAS_DAILY_BEASTALITY, EVENT_DAILY_BESTIALITY_GENRE, EVENT_DAILY_BESTIALITY, SELECT_CHARA_LIST_SHOW_LOGIC_BEASTALITY_A, SELECT_CHARA_LIST_SHOW_LOGIC_BEASTALITY_B, SELECT_CHARA_LIST_SELECT_LOGIC_BEASTALITY, SELECT_CHARA_LIST_COLOR_LOGIC_BEASTALITY; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_BESTIALITY_RATE()
RETURN 30

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_BESTIALITY_DECISION()

SIF DVAR:動物遣い_発生フラグ == 3
	RETURN 0

LOCAL:1 = 0

;捕虜か仲間に女がいるか判定、いない場合はキャンセル
FOR LOCAL, 0, CHARANUM
	IF (CFLAG:LOCAL:捕虜先 == CFLAG:MASTER:所属 && IS_FEMALE(LOCAL)) || (CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && IS_FEMALE(LOCAL))
		LOCAL:1 ++
	ENDIF
NEXT

SIF LOCAL:1 == 0
	RETURN 0

RETURN 1

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_BESTIALITY_SETTARGET()
#DIM 対象

CALL SELECT_CHARA_RANDOM("DAILY_BEASTALITY", "DAILY_BEASTALITY")

SIF RESULT == -1
	RETURN 0

DAILY_TARGET:0 = RESULT

RETURN 1

@SELECT_CHARA_RANDOM_LOGIC_DAILY_BEASTALITY(対象)
#DIM 対象
;女、かつ「所属がMASTERと同一で、捕虜でない」か「」
RETURN IS_FEMALE(対象) && ((CFLAG:対象:所属 == CFLAG:MASTER:所属 && !CFLAG:対象:捕虜先) || (CFLAG:対象:捕虜先 == CFLAG:MASTER:所属))

@SELECT_CHARA_RANDOM_BIAS_DAILY_BEASTALITY(対象)
#DIM 対象
;好感度をベースに決定
RETURN CFLAG:対象:好感度 + IS_LOVER(対象) * 1000


;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_BESTIALITY_GENRE()
RETURN デイリー_ジャンル_エロ

;---------------------
;本体
;---------------------
@EVENT_DAILY_BESTIALITY
#DIM 対象

IF DVAR:動物遣い_発生フラグ == 0
	PRINTFORMW 調教師を名乗る男がやってきた
	PRINTFORML 彼は獣姦用の動物を調教することを生業としているらしい
	PRINTFORML ここには調教の土台としてうってつけの女がいると聞いてやって来たと告げる
	PRINTFORMW 男は不敵に笑うと動物の調教の為に女を使わせてもらえれば謝礼をすると言ってきた
	DVAR:動物遣い_発生フラグ = 1
ELSEIF DVAR:動物遣い_発生フラグ > 0
	PRINTFORMW 再び調教師がやってきた
	IF DVAR:動物遣い_発生フラグ == 2
		PRINTFORML %ANAME(MASTER)%は前回この男にされた仕打ちを思い出しきつく睨み付ける
		PRINTFORMW しかし彼は不敵に笑うだけで、また女を調教に使用させてくれと言ってきた
	ELSEIF DVAR:動物遣い_発生フラグ == 1
		PRINTFORMW 彼は相変わらず不敵に笑い、また女を調教に使用させてくれと言ってきた
	ENDIF
ENDIF
PRINTFORML どうしよう？
CALL ASK_MULTI("取引する", "追い払う", "斬りつける")
IF RESULT == 1
	PRINTFORML そんなことはさせられない
	PRINTFORMW %ANAME(MASTER)%は男を追い払った
	DVAR:動物遣い_発生フラグ = 1
	RETURN
ELSEIF RESULT == 2
	PRINTFORML %ANAME(MASTER)%は男を斬りつけた！
	PRINTFORMW しかし男は華麗に剣を躱すと、では勝負して決めましょうと告げかかってきた
	PRINTFORML ・
	PRINTFORML ・
	PRINTFORMW ・
	IF ABL:MASTER:武闘 * (RAND:8 + 1) >= 50 * (RAND:9 + 1)
		PRINTFORMW 勝った！
		PRINTFORMW 男は地に伏せている
		PRINTFORML どうしよう？
		CALL ASK_YN("さらし首にする", "国外追放")
		IF RESULT == 0
			PRINTFORMW 二度と同じ様な輩が出ないように首を晒した
			PRINTFORMW %ANAME(MASTER)%の行為に他国の評判が上がった
			FOR LOCAL, 1, MAX_COUNTRY
				CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, 20)
			NEXT
		ELSEIF RESUlT == 1
			PRINTFORMW 国外に追放した
			PRINTFORMW 二度と会うこともないだろう…
		ENDIF
		DVAR:動物遣い_発生フラグ = 3
		RETURN 1
	ELSE
		対象 = DAILY_TARGET:0
		PRINTFORMW 負けてしまった…
		PRINTFORMW 男は勝負の代償だと言うと%ANAME(対象)%を連れて行った
		DVAR:動物遣い_発生フラグ = 2
	ENDIF
ELSEIF RESULT == 0
	PRINTFORMW 取引することにした
	PRINTFORML 仲間と捕虜、どちらを提供しようか？
	CALL ASK_YN("仲間", "捕虜")
	IF RESULT == 0
		PRINTFORML 誰を使わせようか？
		CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("BEASTALITY_A", "BEASTALITY", "BEASTALITY")
		対象 = RESULT
		IF RESULT < 0
			PRINTFORMW やはりやめておいた
			DVAR:動物遣い_発生フラグ = 1
			RETURN
		ELSEIF RESULT == MASTER
			PRINTFORMW %ANAME(対象)%はゴクリと生唾を飲むと、自ら名乗り出た
		ELSE
			PRINTFORMW %ANAME(対象)%を指定した
			IF GETBIT(TALENT:対象:淫乱系, 素質_淫乱_雌犬)
				PRINTFORMW %ANAME(対象)%は指名されると舌なめずりをしながら頷いた
			ELSEIF GETBIT(TALENT:対象:淫乱系, 素質_淫乱_淫乱)
				PRINTFORMW %ANAME(対象)%は指名されると驚きつつもその瞳には期待の色が見えた
			ELSEIF IS_SLAVE(対象)
				PRINTFORMW %ANAME(対象)%は指名されると泣きそうになりながらも%ANAME(MASTER)%の強い言葉に小さく頷いた
			ELSE
				PRINTFORML %ANAME(対象)%は指名されると激しく抵抗した
				PRINTFORMW しかし男は無理矢理彼女を引きずって行った
				CFLAG:対象:好感度 -= 1000
			ENDIF
		ENDIF
	ELSEIF RESULT == 1
		PRINTFORML 誰を使わせようか？
		CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("BEASTALITY_B", "NONE", "BEASTALITY")
		対象 = RESULT
		IF RESULT < 0
			PRINTFORMW やはりやめておいた
			DVAR:動物遣い_発生フラグ = 1
			RETURN
		ELSE
			PRINTFORML %ANAME(対象)%は指名されると激しく抵抗した
			PRINTFORMW しかし男は無理矢理彼女を引きずって行った
			CFLAG:対象:好感度 -= 1000
		ENDIF
	ENDIF
ENDIF
PRINTFORML 
PRINTFORM %ANAME(対象)%は
SELECTCASE RAND:3
	CASE 0
		PRINTFORMW 豚に犯されている……
		SELECTCASE RAND:5
			CASE 0
				PRINTFORML 目が血走った豚が%ANAME(対象)%に伸し掛かり、嘶きながら腰を振る
				PRINTFORML %ANAME(対象)%はドリルちんぽを子宮にねじ込まれ、衝撃で目を白黒させて痙攣している
				PRINTFORML 豚がカクカクと腰を振る度に子宮内をペニスで舐め上げられ、獣の様に喘いでしまう
				PRINTFORML %ANAME(対象)%は人外のセックスに抗えずに何度もイかされ、たっぷりと種付けされてしまった
			CASE 1
				PRINTFORML 一匹の豚が嘶きながら%ANAME(対象)%の中にビュービューと射精している
				PRINTFORML こってりザーメンで子宮の隅々まで犯されていく感覚に%ANAME(対象)%は白目を剥いてヨガり狂う
				PRINTFORML 豚は射精しながら腰を振り、その衝撃に%ANAME(対象)%は無様なアヘ顔で連続絶頂してしまう
				PRINTFORML やがて満足した豚から解放された時には、%ANAME(対象)%の下腹部はぽっこりと膨れ上がっていた
			CASE 2
				PRINTFORML 太った豚が%ANAME(対象)%の子宮までちんぽをねじ込みながら勢いよく射精している
				PRINTFORML どぷんどぷんと大量の精液を流し込まれ、あまりの熱量に%ANAME(対象)%はヒィヒィと喘がされる
				PRINTFORML 豚の射精はとてつもなく長く、%ANAME(対象)%は何度も絶頂させられてしまいひたすら身悶える
				PRINTFORML ようやく射精が終わった頃には頭の中までザーメンに浸されたような感覚に陥っていた
			CASE 3
				PRINTFORML 性欲旺盛な豚たちは次々と%ANAME(対象)%に伸し掛かってはドリルちんぽをねじ込んでくる
				PRINTFORML 畜生に種付けされる%ANAME(対象)%は涙を流して悲鳴を上げるが豚たちは容赦なく交尾を続ける
				PRINTFORML %ANAME(対象)%のお腹はすでにボテッと膨れ上がり、秘所からは大量の精液が漏れ出している
				PRINTFORML 豚たちの饗宴は夜通し続けられ、すっかり%ANAME(対象)%に彼らの匂いが染み込んでしまっていた
			CASE 4
				PRINTFORML 仰向けになった%ANAME(対象)%に巨大な豚が伸し掛かり激しく腰を振っている
				PRINTFORML 子宮まで突き刺さったペニスのせいで禄に抵抗も出来ず%ANAME(対象)%は涙を流して喘ぐしかない
				PRINTFORML やがて豚が嘶くとどろりとしたザーメンが胎内に放たれ、%ANAME(対象)%は涙を流してアクメした
				PRINTFORML 射精を終えた豚は%ANAME(対象)%を確実に孕ませるべくスライム状の粘液で秘所に蓋をしていった
		ENDSELECT
		CALL FUCK(対象, "欲望, 奉仕, 精愛, 性技, 性交, Ｃ, Ｖ, Ｍ, 獣姦, 獣姦, Ｖ性交, Ｖ拡張", "処女喪失, 膣内射精, CFLAG減少", GET_SPERM_ID("豚"), @"豚の\@RAND:2 ? ペニス # 唇\@", @"豚", "", "調教")
	CASE 1
		PRINTFORML 馬に犯されている……
		SELECTCASE RAND:5
			CASE 0
				PRINTFORML 巨大なペニスで膣肉をギチギチに圧迫されている%ANAME(対象)%はビクンビクンと痙攣する
```
