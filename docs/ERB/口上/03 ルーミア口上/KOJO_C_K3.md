# 口上/03 ルーミア口上/KOJO_C_K3.ERB — 自动生成文档

源文件: `ERB/口上/03 ルーミア口上/KOJO_C_K3.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_C_K3, KOJO_TRAIN_END_C_K3, KOJO_COM_BEFORE_TARGET_C_K3, KOJO_COM_BEFORE_PLAYER_C_K3, KOJO_COM_C_K3, KOJO_COM_TARGET_C_K3, KOJO_COM_PLAYER_C_K3, KOJO_COM_AFTER_C_K3, SEX_VOICEK03_EV0, SEX_VOICEK03_EV1; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜逆調教(通常)」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_C_K3
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:204 == 0
	CFLAG:204 = 1
	;PRINTFORMW 

;-------------------------------------------------
;2回目以降
;-------------------------------------------------
ELSE
	;PRINTFORMW 
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_C_K3
#DIM 霊夢
霊夢 = NAME_TO_CHARA("霊夢")
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;デイリーイベント用処理
IF KDVAR:ルーミア_EXルーミアとセックス中 == 1
	;イベント初回終了時
	IF KDVAR:ルーミア_EXルーミア == 0
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		PRINTFORML 「あはぁ♥　もっとぉ♥　%ANAME(MASTER)%を食べさせてぇ♥♥」
		PRINTFORMW 豹変した%ANAME(TARGET)%は凄まじい性欲の持ち主だった
		PRINTFORMW あれほど精を搾り取ったにも拘らず、まだ%ANAME(MASTER)%に跨り次の精をねだっている
		IF CFLAG:霊夢:所属 == CFLAG:MASTER:所属 &&  !(MASTER == NAME_TO_CHARA("霊夢"))
			PRINTFORML
			CALL SINGLE_DRAWLINE
			PRINTFORML 
			PRINTFORML 　　…封印されるって事は、つまりそういうことよ…
			PRINTFORMW
			CALL SINGLE_DRAWLINE
			PRINTFORML
			PRINTFORML どこからともなく、博麗の巫女のありがたい言葉が聞こえた気がした
			PRINTFORMW そして、何ゆえ%ANAME(TARGET)%が封印されていたのか、理由が分かった気がした
		ELSE
			PRINTFORMW …何となく、%ANAME(TARGET)%に封印が施されていた理由が分かった気がした
		ENDIF
		PRINTFORMW あのお札は、%ANAME(TARGET)%の闇の力ではなく、底なしの肉欲を抑えていた封印だったのだ
		PRINTFORMW 今も%ANAME(MASTER)%の上で淫らに腰を振る%ANAME(TARGET)%。その情欲はまだまだ収まりそうに無い
		PRINTFORML このままでは本当に搾り殺されるかもしれない
		PRINTFORML 命の危険を感じた%ANAME(MASTER)%は何とか%ANAME(TARGET)%を封印していたお札を手に取り
		PRINTFORMW 子宮の奥で%ANAME(MASTER)%の精を受けて恍惚とする%ANAME(TARGET)%の隙を見てお札を取り付けた！
		PRINTFORMW お札のリボンを取り付けると、%ANAME(TARGET)%はゆっくりと意識を失い、%ANAME(MASTER)%に倒れこんだ
		PRINTFORML …寝息を立てている。どうやら封印は成功したようだ
		PRINTFORMW …
		PRINTFORMW ……
		PRINTFORML しばらくして%ANAME(TARGET)%が目を覚ました時、さっきまでのことは忘れていた
		PRINTFORMW 部屋に遊びに来たところまでは覚えていたようだが、その後の記憶が無くなっている
		PRINTFORMW どうやら封印が解けている間のことは覚えていないようだ
		PRINTFORML 危うく搾り殺されそうなところだった%ANAME(MASTER)%は、
		PRINTFORMW 今後彼女のリボンに気をつけて生活しようと誓った
		PRINTFORML そんな様子の%ANAME(MASTER)%を見て
		PRINTFORMW %ANAME(TARGET)%は頭に　？　を浮かべていた
		PRINTFORML 
		KDVAR:ルーミア_EXルーミア = 1
		KDVAR:ルーミア_EXルーミアとセックス中 = 0
	;イベント２回目以降終了時
	ELSE
		PRINTFORML ・
		PRINTFORML ・
		PRINTFORMW ・
		PRINTFORML 「あはぁ♥　もっとぉ♥　%ANAME(MASTER)%を♥もっと食べさせてぇ♥♥」
		PRINTFORMW 封印が解けた%ANAME(TARGET)%は、相変わらずの凄まじい性欲だった
		PRINTFORMW あれほど精を搾り取ったにも拘らず、まだ%ANAME(MASTER)%に跨り次の精をねだっている
		PRINTFORML 前回同様、このままでは本当に搾り殺されるかもしれない…
		PRINTFORML 危険を感じた%ANAME(MASTER)%は何とか%ANAME(TARGET)%を封印していたお札を手に取り、
		PRINTFORMW 子宮の奥で%ANAME(MASTER)%の精を受けて恍惚とする%ANAME(TARGET)%の隙を見てお札を取り付けた！
		PRINTFORMW お札のリボンを取り付けると、%ANAME(TARGET)%はゆっくりと意識を失い、%ANAME(MASTER)%に倒れこんだ
		PRINTFORML …寝息を立てている。どうやら今回も封印は成功したようだ
		PRINTFORMW …
		PRINTFORMW ……
		PRINTFORML しばらくして%ANAME(TARGET)%が目を覚ました時、さっきまでのことは忘れていた
		PRINTFORMW 部屋に遊びに来たところまでは覚えていたようだが、その後の記憶が無いとのことだ
		PRINTFORMW それは%ANAME(MASTER)%にとっては好都合なことだった。また、こういうことが出来るかもしれないのだから…
		PRINTFORML 危うく搾り殺されそうになるほどの%ANAME(TARGET)%との交わりは、
		PRINTFORMW %ANAME(MASTER)%の身体の奥底に強い快楽への依存を刻んでいた
		PRINTFORML そんな、どこか浮ついた様子の%ANAME(MASTER)%を見て
		PRINTFORMW %ANAME(TARGET)%は頭に　？　を浮かべていた……
		PRINTFORML 
		KDVAR:ルーミア_EXルーミアとセックス中 = 0
	ENDIF
ENDIF
;-------------------------------------------------
;行動不能の場合
;-------------------------------------------------
;酒酔いによる行動不能
IF TCVAR:53 == 1
	;PRINTFORMW 
;快感のあまり気絶
ELSEIF TCVAR:52
	;PRINTFORMW 
;疲労による行動不能
ELSEIF TCVAR:51
	;PRINTFORMW 
;主人公が酒酔いによる行動不能
ELSEIF TCVAR:MASTER:53 == 1
	;PRINTFORMW 
;主人公が快感のあまり気絶
ELSEIF TCVAR:MASTER:52
	;PRINTFORMW 
;主人公が疲労による行動不能
ELSEIF TCVAR:MASTER:51
	;PRINTFORMW 

;-------------------------------------------------
;初回
;-------------------------------------------------
ELSEIF CFLAG:205 < 1
	;PRINTFORMW 

;-------------------------------------------------
;2回目以降
;-------------------------------------------------
ELSE
	;PRINTFORMW 
ENDIF

;-------------------------------------------------
;初回なら進行度を増加
;-------------------------------------------------
IF CFLAG:205 < 1
	CFLAG:205 = 1
ENDIF

;=================================================
;●コマンド実行前(このキャラがターゲット側のとき)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;=================================================
@KOJO_COM_BEFORE_TARGET_C_K3
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

RETURN 0

;=================================================
;●コマンド実行前(このキャラがプレイヤー側のとき)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_PLAYERの代わりに使う
;=================================================
@KOJO_COM_BEFORE_PLAYER_C_K3
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF

RETURN 0

;=================================================
;●コマンド実行時(このキャラがプレイヤーでもターゲットでも呼び出される)
;  プレイヤー・ターゲットの区別がないコマンドはここに口上を記述する
;=================================================
@KOJO_COM_C_K3
#DIM 対象
;[虚ろ]状態の場合、口が塞がっている場合は口上を表示しない
IF TALENT:虚ろ || IS_EQUIP_CONTINUE(TARGET, "口装着")
	RETURN 0
ENDIF
;デイリーイベント用処理
IF KDVAR:ルーミア_EXルーミアとセックス中
	BASE:対象:体力 = MAXBASE:対象:体力
	BASE:対象:気力 = MAXBASE:対象:気力
ENDIF
;-------------------------------------------------
;キス
;-------------------------------------------------
IF SELECTCOM == 20
	;ファーストキス
	IF TALENT:キス未経験
		;PRINTFORMW 
	;キス経験済み
	ELSE
		IF KDVAR:ルーミア_EXルーミアとセックス中
			SELECTCASE RAND:3
```
