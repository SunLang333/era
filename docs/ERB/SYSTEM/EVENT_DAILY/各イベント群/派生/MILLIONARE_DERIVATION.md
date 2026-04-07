# SYSTEM/EVENT_DAILY/各イベント群/派生/MILLIONARE_DERIVATION.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_DAILY/各イベント群/派生/MILLIONARE_DERIVATION.ERB`

类型: .ERB

自动摘要: functions: EVENT_DAILY_DERIVATION_MILLIONAIRE_REVENGE_DISABLE, EVENT_DAILY_DERIVATION_MILLIONAIRE_REVENGE_DECISION, EVENT_DAILY_DERIVATION_MILLIONAIRE_REVENGE, EVENTTRAIN_MILLIONAIRE_REVENGE, EVENTEND_MILLIONAIRE_REVENGE_A, EVENTEND_MILLIONAIRE_REVENGE_B, EVENT_DAILY_DERIVATION_MILLIONAIRE_TRAIN_DISABLE, EVENT_DAILY_DERIVATION_MILLIONAIRE_TRAIN_DECISION, EVENT_DAILY_DERIVATION_MILLIONAIRE_TRAIN_SETTARGET, EVENT_DAILY_DERIVATION_MILLIONAIRE_TRAIN, EVENTTRAIN_MILLIONAIRE_TRAIN, EVENTEND_MILLIONAIRE_TRAIN, EVENTEND_MILLIONAIRE_TRAIN_B, EVENT_DAILY_DERIVATION_MILLIONAIRE_SLAVE_DISABLE, EVENT_DAILY_DERIVATION_MILLIONAIRE_SLAVE_DECISION, EVENT_DAILY_DERIVATION_MILLIONAIRE_SLAVE_SETTARGET, EVENT_DAILY_DERIVATION_MILLIONAIRE_SLAVE, EVENT_DAILY_DERIVATION_MILLIONAIRE_AFTER_DISABLE, EVENT_DAILY_DERIVATION_MILLIONAIRE_AFTER_DECISION, EVENT_DAILY_DERIVATION_MILLIONAIRE_AFTER_SETTARGET; UI/print

前 200 行源码片段:

```text
﻿@MILLIONAIRE_DERIVATION_CREATE_MILLIONAIRE
#DIM 対象

CALL CREATE_RANDOM_CHARA(0, -1, 0)
FLAG:汎用武将カウント --
対象 = RESULT
IF LOCAL == -1
	RETURN -1
ENDIF

NO:対象 = GET_EMPTY_NO()
NAME:対象 = 富豪
CALLNAME:対象 = 富豪
CSTR:対象:0 =
CSTR:対象:1 =
TALENT:対象:性別 = 0
MAXBASE:対象:体力 = 99999999
MAXBASE:対象:気力 = 99999999
MAXBASE:対象:精神力 = 1500
BASE:対象:体力 = MAXBASE:対象:体力
BASE:対象:気力 = MAXBASE:対象:気力
BASE:対象:精神力 = MAXBASE:対象:精神力
ABL:対象:性知識 = 5
ABL:対象:Ｃ感 = 5
ABL:対象:Ｖ感 = 3
ABL:対象:Ａ感 = 3
ABL:対象:Ｂ感 = 3
ABL:対象:Ｍ感 = 5
ABL:対象:欲望 = 15
ABL:対象:性技 = 20
ABL:対象:性知識 = 5
ABL:対象:奉仕 = 1
ABL:対象:性交 = 15
ABL:対象:レズ = 0
ABL:対象:精愛 = 3
ABL:対象:露出 = 2
ABL:対象:射精 = 15
ABL:対象:排泄 = 3
ABL:対象:サド = 5
ABL:対象:主導度Ｕ = RAND(300, 600)
ABL:対象:主導度Ｎ = RAND(300, 600)
ABL:対象:倒錯度 = RAND(300, 500)
EXP:対象:絶頂経験 = 500
ABL:対象:武闘 = 60
ABL:対象:防衛 = 30
ABL:対象:知略 = 30
ABL:対象:政治 = 30
ABL:対象:料理 = 10
ABL:対象:肝臓 = 3
IF HAS_PENIS(対象)
	FOR LOCAL, 30, 50
		SIF GROUPMATCH(LOCAL, 36, 46)
			CONTINUE
		COM_TENDENCY:対象:LOCAL = RAND:2
	NEXT
ENDIF

TALENT:対象:絶倫 = 1
TALENT:対象:陰毛現在値 = 陰毛_標準
TALENT:対象:陰毛目標値 = 陰毛_標準
TALENT:対象:Ｖ締まり = GET_DEFAULT_TIGHTNESS("普通")
TALENT:対象:Ａ締まり = GET_DEFAULT_TIGHTNESS("普通")
TALENT:(対象):処女 = 0
TALENT:(対象):キス未経験 = 0
TALENT:(対象):童貞 = 0
TALENT:(対象):アナル処女 = 1
SEXUAL_EXPERIENCE:(対象):初体験_処女 = 不明
SEXUAL_LAST_EXPERIENCE:(対象):初体験_処女 = 不明
SEXUAL_EXPERIENCE:(対象):初体験_キス = 不明
SEXUAL_LAST_EXPERIENCE:(対象):初体験_キス = 不明
SEXUAL_EXPERIENCE:(対象):初体験_童貞 = 不明
SEXUAL_LAST_EXPERIENCE:(対象):初体験_童貞 = 不明
SEXUAL_EXPERIENCE:(対象):初体験_アナル処女 = ----
SEXUAL_LAST_EXPERIENCE:(対象):初体験_アナル処女 = ----
CFLAG:対象:慰安参加者 = 1
CFLAG:対象:慰安モブ = 1
CFLAG:対象:調教参加フラグ  = 1
CFLAG:対象:強制友好化 = 1


;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@EVENT_DAILY_DERIVATION_MILLIONAIRE_REVENGE_DISABLE()
RETURN DAILY_GET_DISABLE_CONFIG("MILLIONAIRE")

;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;対応するデイリーのDISABLEチェックを規約として必須とする
;---------------------
@EVENT_DAILY_DERIVATION_MILLIONAIRE_REVENGE_DECISION()
#DIM 対象

SIF DVAR:富豪_誘拐カウンタ == 0
	RETURN 0

対象 = ID_TO_CHARA(DVAR:富豪_誘拐対象)
SIF 対象 == -1
	RETURN 0

SIF !IS_FEMALE(対象)
	RETURN 0

SIF GET_COUNTRY_BOSS(CFLAG:対象:所属) == 対象
	RETURN 0

SIF 対象 == MASTER
	RETURN 0

SIF CFLAG:対象:特殊状態 == 特殊状態_死亡
	RETURN 0

DVAR:富豪_誘拐カウンタ --
SIF DVAR:富豪_誘拐カウンタ == 0
	RETURN 1

RETURN 0

;---------------------
;本体
;---------------------
@EVENT_DAILY_DERIVATION_MILLIONAIRE_REVENGE()
#DIM 対象

対象 = ID_TO_CHARA(DVAR:富豪_誘拐対象)

TALENT:対象:Ｃ鈍感 = 0
TALENT:対象:Ｖ鈍感 = 0
TALENT:対象:Ａ鈍感 = 0
TALENT:対象:Ｂ鈍感 = 0
TALENT:対象:Ｍ鈍感 = 0
TALENT:対象:Ｃ敏感 = 1
TALENT:対象:Ｖ敏感 = 1
TALENT:対象:Ａ敏感 = 1
TALENT:対象:Ｂ敏感 = 1
TALENT:対象:Ｍ敏感 = 1
TALENT:対象:快感の否定 = 0

PRINTFORMW 深夜……
PRINTFORMW 拠点を見まわっていた%ANAME(対象)%は、怪しげな男が物陰に隠れているのを発見した
PRINTFORMW どうやら街のごろつきのようだ。おおかた、金目のものでも求めて忍び込んだのだろう
PRINTFORMW 尋問するため近づこうとした%ANAME(対象)%だったが、後頭部を鋭い痛みが襲った！
PRINTFORMW 応戦する間もなく、%ANAME(対象)%は昏倒させられてしまった……
PRINTFORMW ・
PRINTFORMW ・
PRINTFORMW ・
PRINTFORMW 冷たく硬い感触に、%ANAME(対象)%は目を覚ました
PRINTFORMW 頭がひどく痛み、身体も軋んでいる
PRINTFORMW 大酒でもして、酔い潰れてしまったのだろうか。うんざりしながら起き上がり、気づく
PRINTFORMW 服を脱がされ、床に寝転がされていた。両手足には枷がはめられている
PRINTFORMW さらにここは自室ではない。見知らぬ薄暗い部屋、おそらく牢屋だ
PRINTFORMW 緊張感で意識が一気に覚醒した。一体何があったか、鈍い頭を回し思い出す
PRINTFORMW あのとき、ごろつきに気をとられたのはうかつだった
PRINTFORMW あれは囮で、「本命」の者が後ろから一撃を加える、そういう手はずだったに違いない
PRINTFORMW まったくの不覚だ。だが、悔いていても仕方ない。今は脱出せねばならない。
PRINTFORMW 「ようやくお目覚めか。よくもまぁあれだけグースカ寝ていられることだ。田舎女は感覚が麻痺しているのか？」
PRINTFORMW ねっとりした、いやらしい声だった。%ANAME(対象)%はその声に聞き覚えがある
PRINTFORMW 以前%ANAME(MASTER)%の不興を買った富豪だ……
PRINTFORMW 「ふん、連中も、猿にしては役に立つ。金さえ払えば何にでも手を染めるのだからな」
PRINTFORMW この男が%ANAME(対象)%を拉致した主犯であるに違いなかった。今すぐ解放するよう、%ANAME(対象)%は要求する
PRINTFORMW 「おいおい、なんだその目は？　雌穴風情が、この私にそんな目を向けて良いとでも？」
PRINTFORMW 「恨む相手が違うだろう。あの野蛮な猿がもう少しまともなら、お前もこんなことにはならなかったのだ」
PRINTFORMW 「いいか？　この私が牢に放り込まれることの重大さに比べたら、貴様ごときがここにいようと大したことではない」
PRINTFORMW 「だが奴が最も嫌がるのは、お前を連れて行かれることだろうからな。望み通りにしてやったのさ」
PRINTFORMW 「そして私は、牢に放り込まれた甲斐のあったといえるだけのものを得るわけだ」
PRINTFORMW 腕が動けば殴っているし、足が動けば蹴っている
PRINTFORMW どちらもできないため、思い切り睨み付けた
PRINTFORMW 「ははは！　強気なことだな。大いに結構。それがいつまで続くか見物だな」
PRINTFORMW 「……さて、お前は何回犯されたら、誰が絶対的な支配者か学ぶかな？」
PRINTFORMW 「自分の存在が、しょせんは性処理のための『穴』に過ぎんと、何日目で学ぶだろうなぁ？」
PRINTFORMW 言いながら、男は%ANAME(対象)%に覆い被さる
PRINTFORMW 下衆な手つきで、%ANAME(対象)%の身体に手を伸ばす
PRINTFORMW 抵抗する%ANAME(対象)%だったが、縛り上げられていてはどうにもならなかった……

FLAG:ターンエンド調教 = 3
FLAG:慰安場所 = 慰安_行き先_貴族の居住地
TRAIN_PLACE = 貴族の屋敷
CVARSET CFLAG, GETNUM(CFLAG, "慰安参加者") , 0
CVARSET CFLAG, GETNUM(CFLAG, "調教参加フラグ") , 0
CFLAG:対象:調教参加フラグ = 1
CALL MILLIONAIRE_DERIVATION_CREATE_MILLIONAIRE()
CALL ADD_EVENTTRAIN_CALLEE("MILLIONAIRE_REVENGE")
CALL ADD_EVENTEND_CALLEE("MILLIONAIRE_REVENGE_A")
DAILY_CANCEL = 1

@EVENTTRAIN_MILLIONAIRE_REVENGE
TFLAG:56 = 30

@EVENTEND_MILLIONAIRE_REVENGE_A
#DIM 対象
対象 = ID_TO_CHARA(DVAR:富豪_誘拐対象)

PRINTFORML
PRINTFORMW 「さて、そろそろ身の程をわきまえたんじゃぁないか？」
PRINTFORMW にやにやと笑いながら、富豪は言ってくる
PRINTFORMW その顔につばを吐きかけてやった
PRINTFORMW 「……それはそれは。……なら、もっと学ばせてやろうじゃあないか」
PRINTFORMW 富豪は再び、%ANAME(対象)%に覆い被さった……
PRINTFORML
```
