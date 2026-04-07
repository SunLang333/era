# 口上/111 幻月口上/_KOJO_EVENT_K111.ERB — 自动生成文档

源文件: `ERB/口上/111 幻月口上/_KOJO_EVENT_K111.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K111; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;イベント口上
;-------------------------------------------------

;=================================================
;●各種イベント
;※ARGにイベント番号が入る。詳しくは資料フォルダの「era恋姫 イベント表」を参照
;※RETURNの値を0→1に変えると、デフォルトのメッセージが表示されなくなる
;=================================================
@KOJO_EVENT_K111(ARG)
#DIM 幻月
#DIM 幻月_対象
#DIM CONST 体力限界 = 230
#DIM CONST 総妊娠数 = 231
#DIM CONST 妊娠数_人 = 232
#DIM CONST 妊娠数_触手 = 233
#DIM CONST 総出産数 = 234
#DIM CONST 出産数_人 = 235
#DIM CONST 出産数_触手 = 236

;名前の定義
幻月 = NAME_TO_CHARA("幻月")
幻月_対象 = MASTER

;=================================================
;●●口上開発用テンプレ●●
;PRINTFORMW クリック待ち
;PRINTFORML クリック待たない
;%ANAME(幻月)%
;%ANAME(幻月_対象)%
;SETCOLOR COLOR("XXX") 色指定
; 色指定解除

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;烙印・服従
	IF TALENT:烙印 || TALENT:服従
		PRINTFORMW 幻月との距離が0になる...
		PRINTFORMW 
		PRINTFORMW 「ん...好きでもない人に接吻して何が楽しいのかしら...」

		PRINTFORMW 強がる幻月だったが、顔を赤くしているのを%ANAME(幻月_対象)%は見逃さなかった
	;恋慕
	ELSEIF TALENT:恋慕
		PRINTFORMW 幻月との距離が0になる...

		PRINTFORMW 「ん...初めて...ね」

		PRINTFORMW 幻月は耳まで真っ赤にして、もう一度接吻を求めてきた...
	;それ以外
	ELSE
		PRINTFORMW 幻月との距離が0になる...

		PRINTFORMW 「ん...」

		PRINTFORMW 幻月は顔を赤らめ、もう一度接吻を求めてきた...
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕
	IF TALENT:恋慕
		PRINTFORMW %ANAME(幻月_対象)%は幻月に告白すると決意したものの
		PRINTFORML いざ彼女を前にすると頭に血が上り挙動不審と自分でも思うほどそわそわ
		PRINTFORMW してしまうのを感じる

		PRINTFORMW 「...どうかした？」

		PRINTFORMW 幻月は不思議そうに%ANAME(幻月_対象)%を見ている
	;服従
	ELSEIF TALENT:服従
		PRINTFORMW %ANAME(幻月_対象)%は幻月に告白すると決意したものの
		PRINTFORML いざ彼女を前にすると頭に血が上り挙動不審と自分でも思うほどそわそわ
		PRINTFORMW してしまうのを感じる

		PRINTFORMW 「...どうかした？」

		PRINTFORMW 幻月は不審そうに%ANAME(幻月_対象)%を見ている
	;それ以外
	ELSE
		PRINTFORMW %ANAME(幻月_対象)%は幻月に告白すると決意したものの
		PRINTFORML いざ彼女を前にすると頭に血が上り挙動不審と自分でも思うほどそわそわ
		PRINTFORMW してしまうのを感じる

		PRINTFORMW 「...どうかした？」

		PRINTFORMW 幻月は不思議そうに%ANAME(幻月_対象)%を見ている
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTFORMW %ANAME(幻月_対象)%は幻月に告白すると決意したものの
	PRINTFORML いざ彼女を前にすると頭に血が上り挙動不審と自分でも思うほどそわそわ
	PRINTFORMW してしまうのを感じる

	PRINTFORMW 「...どうかした？」

	PRINTFORMW 幻月は不思議そうに%ANAME(幻月_対象)%を見ている
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTFORMW あなたは泥酔した幻月を人通りの少ない場所へ運んだ
	PRINTFORML 殆ど酔わない幻月がここまでつぶれる事はそうそうないので
	PRINTFORMW なかなか楽しめそうだ
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕・烙印
	IF TALENT:恋慕 || TALENT:烙印
		PRINTFORML 日々戦闘の合間に幻月と遊び、親密な関係になった%ANAME(幻月_対象)%と幻月。
		PRINTFORMW より深い関係になろうと%ANAME(幻月_対象)%は幻月を押し倒す事にした。

		PRINTFORMW 「どうしたの？」

		PRINTFORMW %ANAME(幻月_対象)%は幻月と唇を重ねながら一緒に倒れこんだ...

	;服従
	ELSEIF TALENT:服従
		PRINTFORML %ANAME(幻月_対象)%の隷下となった幻月。
		PRINTFORMW より深い関係になろうと%ANAME(幻月_対象)%は幻月を押し倒す事にした。

		PRINTFORMW 「...どうかしたの？」

		PRINTFORMW %ANAME(幻月_対象)%は幻月と唇を重ねながら一緒に倒れこんだ...
	;それ以外
	ELSE
		PRINTFORML 日々戦闘の合間に幻月と遊び、親密な関係になった%ANAME(幻月_対象)%と幻月。
		PRINTFORMW より深い関係になろうと%ANAME(幻月_対象)%は幻月を押し倒す事にした。

		PRINTFORMW 「どうしたの？」

		PRINTFORMW %ANAME(幻月_対象)%は幻月と唇を重ねながら一緒に倒れこんだ... 
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	;恋慕・烙印
	IF TALENT:恋慕 || TALENT:烙印
		PRINTFORML 日々戦闘の合間に幻月と遊び、親密な関係になった%ANAME(幻月_対象)%と幻月。
		PRINTFORMW より深い関係になろうと%ANAME(幻月_対象)%は幻月を押し倒す事にした。

		PRINTFORMW 「どうしたの？」

		PRINTFORMW %ANAME(幻月_対象)%は幻月と唇を重ねながら一緒に倒れこもうとしたが...

		PRINTFORMW 「今、そういう気分じゃないのよ」
		PRINTFORMW 「この埋め合わせはまた今度...ね」

		PRINTFORMW 気まずい雰囲気の中幻月と別れた

	;服従 
	ELSEIF TALENT:服従
		PRINTFORML %ANAME(幻月_対象)%の隷下となった幻月。
		PRINTFORMW より深い関係になろうと%ANAME(幻月_対象)%は幻月を押し倒す事にした。

		PRINTFORMW 「...どうしたの？」

		PRINTFORMW %ANAME(幻月_対象)%は幻月と唇を重ねながら一緒に倒れこもうとしたが...

		PRINTFORMW 「今、そういう気分じゃないの...」

		PRINTFORMW 抵抗こそされなかったものの、気まずい雰囲気のなか目を逸らしてしまう
		PRINTFORMW 振り返るとそこに幻月は居なかった

	;それ以外
	ELSE
		PRINTFORML 日々戦闘の合間に幻月と遊び、親密な関係になった%ANAME(幻月_対象)%と幻月。
		PRINTFORMW より深い関係になろうと%ANAME(幻月_対象)%は幻月を押し倒す事にした。

		PRINTFORMW 「どうしたの？」

		PRINTFORMW %ANAME(幻月_対象)%は幻月と唇を重ねながら一緒に倒れこもうとしたが...

		PRINTFORMW 「今、そういう気分じゃないのよ」
		PRINTFORMW 「この埋め合わせはまた今度...ね」

		PRINTFORMW 気まずい雰囲気の中幻月と別れた
	ENDIF
```
