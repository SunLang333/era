# SYSTEM/EVENT_DAILY/各イベント群/TENTACLE_BREEDING_触手の繁殖期.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/TENTACLE_BREEDING_触手の繁殖期.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_TENTACLE_BREEDING_RATE, EVENT_DAILY_TENTACLE_BREEDING_DECISION, EVENT_DAILY_TENTACLE_BREEDING_SETTARGET, EVENT_DAILY_TENTACLE_BREEDING_GENRE, EVENT_DAILY_TENTACLE_BREEDING, SELECT_CHARA_LIST_SHOW_LOGIC_TENTACLE_BREEDING_CAPTIVE, SELECT_CHARA_LIST_SHOW_LOGIC_TENTACLE_BREEDING_SEEDBED, SELECT_CHARA_LIST_SELECT_LOGIC_TENTACLE_BREEDING_SEEDBED, TENTACLE_BREEDING_RAPE; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;発生確率(1000分率 100で10%)
;---------------------
@EVENT_DAILY_TENTACLE_BREEDING_RATE()
RETURN 25

;---------------------
;確率以外の発生判定
;---------------------
@EVENT_DAILY_TENTACLE_BREEDING_DECISION()
#DIM 触手

触手 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_触手))
SIF 触手 == -1
	RETURN 0
SIF CFLAG:MASTER:所属 != 触手
	RETURN 0
SIF CFLAG:MASTER:捕虜先 != 0
	RETURN 0

RETURN 1

;---------------------
;特定の条件を満たすキャラをランダムに選択する場合に利用
;他の関数は必須だが、これだけはなくてもよい　というかパフォーマンスへ影響するので不要なら作ってはならない
;対象が存在せずデイリーを開始できない場合は0を返すことでデイリーの発生をキャンセルする
;---------------------
@EVENT_DAILY_TENTACLE_BREEDING_SETTARGET()

FOR LOCAL, 0, CHARANUM
	;男かつ触手かつ自国所属かつ捕虜でなくかつ動物でない
	IF IS_MALE(LOCAL) && TALENT:LOCAL:特殊勢力素質 == 特殊勢力_触手 && CFLAG:LOCAL:所属 == CFLAG:MASTER:所属 && !CFLAG:LOCAL:捕虜先 && !IS_ANIMAL(LOCAL)
		DAILY_TARGET:DAILY_TARGET_NUM = LOCAL
		DAILY_TARGET_NUM ++
	ENDIF
NEXT

SIF DAILY_TARGET_NUM < 1
	RETURN 0

RETURN 1

;---------------------
;ジャンル
;---------------------
@EVENT_DAILY_TENTACLE_BREEDING_GENRE()
RETURN デイリー_ジャンル_特殊勢力

;---------------------
;本体
;---------------------
@EVENT_DAILY_TENTACLE_BREEDING
#DIM 対象触手
#DIM 対象

対象触手 = DAILY_TARGET:(RAND:DAILY_TARGET_NUM)

PRINTFORMW %ANAME(対象触手)%が繁殖期に入り興奮している様だ
$SELECT_LOOP
PRINTFORML どうしよう？
CALL ASK_MULTI("村娘を捧げる" ,"捕虜を使わせる" ,"苗床を使わせる", "放置！")
IF RESULT == 3
	PRINTFORMW 取り合う必要もあるまい
	PRINTFORMW 放っておくことにした
	RETURN 0
ELSEIF RESULT == 0
	PRINTFORMW 領民から適当な娘を捧げる事にした
	PRINTFORMW …丁度良く健康的な少女が見つかった
	SELECTCASE RAND:5
		CASE 0
			PRINTFORMW 怯える彼女を繁殖部屋に放り込むと、無数の触手が彼女に襲い掛かった……
		CASE 1
			PRINTFORMW %ANAME(対象触手)%は興奮した様に波打つと逃げる彼女を捕らえて繁殖部屋に連れ込んだ……
		CASE 2
			PRINTFORMW 雌の匂いに興奮した%ANAME(対象触手)%は彼女に麻酔すると繁殖部屋に引きずり込んだ……
		CASE 3
			PRINTFORMW 繁殖部屋に娘を放り込むと中から悲鳴が響いたがすぐに聞こえなくなった……
		CASE 4
			PRINTFORMW 生贄にされた少女は初めの内泣き叫んでいたが、やがて笑うだけになった……
	ENDSELECT
	PRINTFORML 
	PRINTFORML しばらくのちに少女は解放された
	PRINTFORMW その体と心はすっかり壊され、立派な苗床に生まれ変わっていた
	PRINTFORML 
	FOR LOCAL, 1, MAX_COUNTRY
		CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -30, 30)
	NEXT
	CALL COLOR_PRINT("領民へのこの仕打ちは他国から非難された", カラー_注意)
	PRINTFORMW 
ELSEIF RESULT == 1
	PRINTFORML 丁度良いので捕虜を使わせることにした
	CALL SINGLE_DRAWLINE
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("TENTACLE_BREEDING_CAPTIVE", "NONE")
	IF RESULT == -1
		PRINTFORMW 彼女たちは交渉材料にもなる、やめておこう
		PRINTFORML 
		GOTO SELECT_LOOP
	ELSE
		対象 = RESULT
		PRINTFORMW %ANAME(対象)%に決めた
		PRINTFORML 必死で抵抗する%ANAME(対象)%を特製の繁殖部屋に放り込む
		PRINTFORMW すると興奮しきった%ANAME(対象触手)%がすぐさま彼女に襲い掛かった
		CALL TENTACLE_BREEDING_RAPE(対象)
		PRINTFORML 
		IF CFLAG:対象:所属 != 0
			FOR LOCAL, 1, MAX_COUNTRY
				SIF CFLAG:対象:所属 == LOCAL
					CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -300, 300)
			NEXT
			CALL COLOR_PRINT(@"%ANAME(対象)%への仕打ちは所属国をとても怒らせたようだ", カラー_注意)
			PRINTFORMW 
		ELSE
			FOR LOCAL, 1, MAX_COUNTRY
				CALL CHANGE_RELATION_C_TO_C(LOCAL, CFLAG:MASTER:所属, -30, 30)
			NEXT
			CALL COLOR_PRINT("捕虜へのこの仕打ちは他国から非難された", カラー_注意)
			PRINTFORMW 
		ENDIF
	ENDIF
ELSEIF RESULT == 2
	PRINTFORML ここには苗床になっている女がいる
	PRINTFORMW 彼女たちは喜んで触手の為に身を捧げるだろう
	PRINTFORML 誰を選ぼう？
	CALL SELECT_CHARA_LIST_ONLY_LOGIC_SEX("TENTACLE_BREEDING_SEEDBED", "TENTACLE_BREEDING_SEEDBED")
	対象 = RESULT
	IF RESULT < 0
		PRINTFORMW やはり大事な戦力を使うのはもったいない、別の女にしよう
		PRINTFORML 
		GOTO SELECT_LOOP
	ELSEIF RESULT == MASTER
		PRINTFORMW %ANAME(対象)%自身が苗床になることにした
	ELSE
		PRINTFORMW %ANAME(対象)%に決めた
	ENDIF
	PRINTFORML %ANAME(対象)%はこれからされる事に胸を高鳴らせながら繁殖部屋に向かう
	PRINTFORMW %ANAME(対象)%が繁殖部屋に入るとすぐさま無数の触手に襲い掛かられた
	CALL TENTACLE_BREEDING_RAPE(対象)
	CALL ADD_COOLTIME(対象, 1)
ENDIF

IF RAND:6 == 0
	PRINTFORMW %ANAME(対象触手)%と少女の相性は抜群に良かったようだ
	PRINTFORMW %ANAME(対象触手)%の能力が大幅に強化された
	CALL PRINT_ADD_EXP(対象触手, "武闘経験値", 10 + RAND:15, 1)
	CALL PRINT_ADD_EXP(対象触手, "防衛経験値", 10 + RAND:15, 1)
	CALL PRINT_ADD_EXP(対象触手, "知略経験値", 10 + RAND:15, 1)
	CALL TRAIN_AUTO_ABLUP(対象触手)
ELSE
	PRINTFORMW %ANAME(対象触手)%はたっぷりと繁殖を繰り返し強くなったようだ
	CALL PRINT_ADD_EXP(対象触手, "武闘経験値", 5 + RAND:10, 1)
	CALL PRINT_ADD_EXP(対象触手, "防衛経験値", 5 + RAND:10, 1)
	CALL PRINT_ADD_EXP(対象触手, "知略経験値", 5 + RAND:10, 1)
	CALL TRAIN_AUTO_ABLUP(対象触手)
ENDIF

RETURN 1

@SELECT_CHARA_LIST_SHOW_LOGIC_TENTACLE_BREEDING_CAPTIVE(対象)
#DIM 対象
RETURN !IS_MALE(対象) && CFLAG:対象:捕虜先 == CFLAG:MASTER:所属

@SELECT_CHARA_LIST_SHOW_LOGIC_TENTACLE_BREEDING_SEEDBED(対象)
#DIM 対象
RETURN CFLAG:対象:行動不能状態 != 行動不能_子供 && CFLAG:対象:所属 == CFLAG:MASTER:所属 && !IS_ANIMAL(対象) && !IS_MALE(対象)

@SELECT_CHARA_LIST_SELECT_LOGIC_TENTACLE_BREEDING_SEEDBED(対象)
#DIM 対象
RETURN CFLAG:対象:捕虜先 == 0

@TENTACLE_BREEDING_RAPE(ARG:0)

PRINTFORML 
PRINTFORMW 繁殖部屋の中から微かに%ANAME(ARG:0)%の声が漏れてくる……
PRINTFORML 
SELECTCASE RAND:20
	CASE 0
		PRINTFORML %ANAME(ARG:0)%は無数の触手で体内を蹂躙されて悲鳴に近い喘ぎを上げる
		PRINTFORML 触手たちは%ANAME(ARG:0)%の悲鳴など意に介さずその雌穴がはち切れんばかりに侵入して蠢く
		PRINTFORML ぐちゅぐちゅといやらしい蜜音が鳴り響き愛液が飛び散り四肢がガクガクと痙攣する
		PRINTFORMW やがて大量の種が放たれると、%ANAME(ARG:0)%は意識を飛ばしながら強烈な絶頂に達した
	CASE 1
		PRINTFORML %ANAME(ARG:0)%は尻穴から体内を貫通した触手が口から飛び出た状態で吊られている
		PRINTFORML 文字通り触手に串刺しにされた%ANAME(ARG:0)%は白目を剥いてガクガクと全身を痙攣させる
		PRINTFORML 苦痛とそれ以上の快楽が全身を駆け巡り、%ANAME(ARG:0)%はたまらず潮を吹いて絶頂する
		PRINTFORMW %ANAME(ARG:0)%は体内全てを触手と彼の種で満たされながら悦びのままに気を失った
	CASE 2
		PRINTFORML 触手に拘束された%ANAME(ARG:0)%は激しい突き上げを食らいながらヨガリ狂っている
		PRINTFORML 巨大すぎる触手を奥深くまでねじ込まれて子宮が口から飛び出る様な衝撃を受ける
		PRINTFORML 一突き毎に%ANAME(ARG:0)%の身体は絶頂させられ、雌の本能のままに触手を締め付けていく
		PRINTFORMW 彼の肉欲は収まる事を知らず壊されるほどの衝撃の波と共に数日に渡り犯された
	CASE 3
		PRINTFORML %ANAME(ARG:0)%は大の字で吊られた状態でタコ足のような触手に犯され痙攣している
		PRINTFORML 吸盤で膣肉を吸引しながらのピストンによる暴力的な快楽にヨガリ狂ってしまう
		PRINTFORML 不意にぷちゅ♥っと子宮口に吸い付かれ、情けない声を漏らしながら大きく仰け反った
		PRINTFORMW 味わったことのない未知の快感に%ANAME(ARG:0)%は気づけば夢中になって腰を振っていた
	CASE 4
		PRINTFORML %ANAME(ARG:0)%は逆さ吊りで容赦ないピストンで責め立てられイキっぱなしになっている
		PRINTFORML ぐちゅるぐちゅる！と触手が%ANAME(ARG:0)%の雌穴に殺到して挿入射精を繰り返し蹂躙する
		PRINTFORML 有無を言わさぬ圧倒的な快感の波に%ANAME(ARG:0)%はヒィヒィとヨガって身悶えるしか出来ない
		PRINTFORMW %ANAME(ARG:0)%は絶頂気絶覚醒を繰り返しながらひたすら彼の底なしの性欲で犯され尽した
```
