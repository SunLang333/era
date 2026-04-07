# 口上/77 白蓮口上/KOJO_B_K77.ERB — 自动生成文档

源文件: `ERB/口上/77 白蓮口上/KOJO_B_K77.ERB`

类型: .ERB

自动摘要: functions: KOJO_TRAIN_START_B_K77, KOJO_TRAIN_END_B_K77, KOJO_COM_BEFORE_TARGET_B_K77, KOJO_COM_BEFORE_PLAYER_B_K77, KOJO_COM_B_K77, KOJO_COM_TARGET_B_K77, KOJO_COM_PLAYER_B_K77, KOJO_COM_AFTER_B_K77; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「捕虜調教」の口上
;-------------------------------------------------

;=================================================
;●開始時のセリフ
;=================================================
@KOJO_TRAIN_START_B_K77
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
ENDIF

;-------------------------------------------------
;初回
;-------------------------------------------------
IF CFLAG:202 == 0
	CFLAG:202 = 1
	PRINTFORML 
	;初対面の場合
	IF !CFLAG:面識 ;投獄初回
		IF MASTER == NAME_TO_CHARA("命蓮")
			PRINTFORML 「――――まさか本当に……本当に%ANAME(MASTER)%なのですか？！
			PRINTFORMW   しかしどうしてあなたがこの様なことを……？！　だって……あなたはもう……」
			PRINTFORML 
			PRINTFORML  獄に繋がれた%NOUN_SEX(TARGET)%の驚きは、荒い息遣いを伴いながら、微かに部屋の中を響かせていた。
			PRINTFORMW  目を見開き、息を呑む%ANAME(TARGET)%は、ありえないと言いたげな眼差しで%ANAME(MASTER)%を見つめ続けている。
			PRINTFORML 
			PRINTFORMW  その一方で感じていた大きな落胆と幻滅に嘆き、肩を落とす%ANAME(TARGET)%に対し、
			PRINTFORML 
			PRINTFORML 「……な、何を言っているのですか%ANAME(MASTER)%！？　これの何処が修行だと言うのですか！！」
			PRINTFORMW 
			PRINTFORML  修行の内だと言い切った%ANAME(MASTER)%は、
			PRINTFORMW  動揺を隠せない%ANAME(TARGET)%の声を無視して覆い被さったのだった...
		ELSE
			PRINTFORMW 「――――私には、この様な場所に連れて来られてしまった人々の怨嗟の声が聞こえてきます」
			PRINTFORML 
			PRINTFORMW  鎖に繋がれた%NOUN_SEX(TARGET)%は、%ANAME(MASTER)%が部屋に入るなり言い放つと、
			PRINTFORML
			PRINTFORML 「少しでもあなたに良心が残っているのであれば、この様な非道は今直ぐやめるべきです。
			PRINTFORMW   どうかこれ以上、罪を重ねないでください……」
			PRINTFORML 
			PRINTFORMW  微かな哀れみを交えつつも、抑揚を抑えた声で%ANAME(MASTER)%を諭し始めたのだった。
			PRINTFORML 
			PRINTFORML  ――――暴れた痕跡が残る生傷の数々。
			PRINTFORMW 
			PRINTFORML  本来の力を奪われたまま抵抗した名残なのか、嵌められた手枷の隙間――――
			PRINTFORMW  ダラリと垂れ下がった両腕から覗く白い手首には、色濃く青痣が浮かびあがっていた。
			PRINTFORML 
			PRINTFORMW  煤けた衣服に汚れた肌を拭う事も出来ずにいる%PRONOUN(TARGET)%は、居心地が悪そうに苦悶に顔を歪ませる。
			PRINTFORML 
			PRINTFORML 「……その手で触れようなどとは思わないでください……、仏の顔も、三度までと申します。
			PRINTFORMW   何よりもその様な事をされて黙っていられるほど、私もお人好しでもありません――――……ですから」
			PRINTFORML 
			PRINTFORMW  未だその場から動かない%ANAME(MASTER)%に焦れた%PRONOUN(TARGET)%の声も、罰が悪そうに鋭く尖らせた視線も、
			PRINTFORML 
			PRINTFORMW 「！？　や、やめなさい！」
			PRINTFORML 
			PRINTFORMW  無視した%ANAME(MASTER)%は、とうとうその手を伸ばしていた...
		ENDIF

	;既に会ったことがある場合
	ELSE
		PRINTFORML 「――――この様な場所に連れて来られてしまった人々の怨嗟の声が、私には聞こえてきます……
		PRINTFORMW   ですがその相手があなただなんて…………あなたには……この様な姿を見られたくありませんでした……」
		PRINTFORML 
		PRINTFORML  牢で鎖に繋がれた%NOUN_SEX(TARGET)%は、抑揚を抑えた声で%ANAME(MASTER)%に問いかけると、
		PRINTFORMW  目を合わせたと同時に戸惑いに顔色を曇らせた。
		PRINTFORML 
		PRINTFORML  ――――暴れた痕跡が残る生傷の数々。
		PRINTFORMW 
		PRINTFORML  本来の力を奪われたまま抵抗した名残なのか、嵌められた手枷の隙間――――
		PRINTFORMW  ダラリと垂れ下がった両腕から覗く白い手首には、色濃く青痣が浮かびあがっていた。
		PRINTFORML 
		IF TALENT:恋慕 ;(意訳：まんざらでもない or 誘い受け)
			PRINTFORMW 「……あの…………考え直しては、いただけませんか……？」
			PRINTFORML 
			PRINTFORML  そして未だ動かない%ANAME(MASTER)%に焦れた、%PRONOUN(TARGET)%は声を上げる。
			PRINTFORMW  微かに赤らみ汗ばむ肌、居心地の悪さから姿勢を変える隙間に、白い肌が浮き彫りになっていた。
			PRINTFORML 
			PRINTFORMW 「ま、待ってください……いけませんっ……ダメですっ……！　い、いやぁっ……！」
			PRINTFORML 
			PRINTFORMW  %ANAME(MASTER)%はいつの間にか、その手を伸ばしていたのだった...
		ELSE
			PRINTFORML 「ち、近寄らないでください！
			PRINTFORMW   ……幾ら顔馴染みだからと言って、そこまで許せる程の寛容を持ち合わせているわけではありません！」
			PRINTFORML 
			PRINTFORML  身じろぐ%PRONOUN(TARGET)%の目に灯る怒り、薄っすら光に反射して光る雫は微かな恐怖に震えているかのようにも見える。
			PRINTFORMW  そして%ANAME(MASTER)%が一歩と踏み込む度にジャラリと鳴る鎖の音に、
			PRINTFORML 
			PRINTFORMW 「や、やめなさい！　考え直しなさい……！」
			PRINTFORML 
			PRINTFORMW  戸惑いに荒げる声を無視して、%ANAME(MASTER)%はその手を伸ばしていた...
		ENDIF
	ENDIF
	PRINTFORML 
;-------------------------------------------------
;開始時(1回のみ)
;-------------------------------------------------
;恋慕または服従を獲得した
ELSEIF CFLAG:202 < 3 && (TALENT:恋慕 || TALENT:服従)
	CFLAG:202 = 3
	PRINTFORMW 「……お願いです……やめませんか……？」

;依存度が300以上になった
ELSEIF CFLAG:202 < 2 && CFLAG:依存度 >= 300
	CFLAG:202 = 2
	;PRINTFORMW 

;-------------------------------------------------
;開始時(2回目以降)
;-------------------------------------------------
;恋慕
ELSEIF TALENT:恋慕
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW 「お願いですっ……もうこんな哀しい事はやめてください……！」
		CASE 1
			PRINTFORMW 「こんなことをなされなくても貴方のことは……」
		CASE 2
			PRINTFORMW 「お願い……もう、やめてください……」
	ENDSELECT
	;依存度が300以上
ELSEIF CFLAG:依存度 >= 300
	;PRINTFORMW 
;それ以外
ELSE
	SELECTCASE RAND:3
		CASE 0
			PRINTFORMW 「……………………」
		CASE 1
			PRINTFORMW 「いずれ仏罰が、いえ……私が下しましょう……」
		CASE 2
			PRINTFORMW 「…………最低です…………」
	ENDSELECT
ENDIF

;=================================================
;●終了時のセリフ
;=================================================
@KOJO_TRAIN_END_B_K77
;[虚ろ]状態なら口上を表示しない
IF TALENT:虚ろ
	RETURN
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
ENDIF

;-------------------------------------------------
;終了時(1回のみ)
;-------------------------------------------------
;初めて依存度が300以上になった
IF CFLAG:203 < 2 && CFLAG:好感度 >= 300
	CFLAG:203 = 2
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF
;初回
ELSEIF CFLAG:203 < 1
	CFLAG:203 = 1
	;行動不能ならフラグだけ立てて表示はしない
	IF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
		;PRINTFORMW 
	ENDIF

;-------------------------------------------------
;終了時(2回目以降)
;-------------------------------------------------
;行動不能なら非表示
ELSEIF !(TCVAR:51 || TCVAR:52 || TCVAR:53)
	;恋慕 or 服従
	IF TALENT:恋慕 || TALENT:服従
		;PRINTFORMW 
	;依存度が300以上
	ELSEIF CFLAG:依存度 >= 300
		;PRINTFORMW 
	;それ以外
	ELSE
		;PRINTFORMW 
	ENDIF
ENDIF

;=================================================
;●コマンド実行前(このキャラがターゲット側のとき)
;※地の文が表示される前に実行される。戻り値に1を設定する(RETURN 1)と地の文がカットされる
;  必要に応じてKOJO_COM_TARGETの代わりに使う
;=================================================
```
