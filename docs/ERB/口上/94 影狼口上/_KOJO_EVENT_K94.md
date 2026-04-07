# 口上/94 影狼口上/_KOJO_EVENT_K94.ERB — 自动生成文档

源文件: `ERB/口上/94 影狼口上/_KOJO_EVENT_K94.ERB`

类型: .ERB

自动摘要: functions: KOJO_EVENT_K94; UI/print

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
@KOJO_EVENT_K94(ARG)

;-------------------------------------------------
;ファーストキス実行
;-------------------------------------------------
IF ARG == 1
	;恋慕
	IF TALENT:恋慕
		PRINTFORMW 唇を離すと甘い吐息がかかった
		PRINTFORMW うっとりした表情の影狼と目が合う
		PRINTFORMW 「ふふっ…ファーストキスよ」
		PRINTFORMW 恥ずかしさを誤魔化すようにあなたに寄りかかってきた
		PRINTFORMW 尻尾がふりふりと揺れている
	;服従
	ELSEIF TALENT:服従
		PRINTFORMW 唇を離すと甘い吐息がかかった
		PRINTFORMW うっとりした表情の影狼と目が合う
		PRINTFORMW 「あぅぅ…」
		PRINTFORMW じっと見つめていると恥ずかしそうに視線をそらしてしまった
		PRINTFORMW しかし尻尾がふりふりと揺れているのを見過ごさなかった
	;それ以外
	ELSE
		PRINTFORMW 唇を離すと甘い吐息がかかった
		PRINTFORMW うっとりした表情の影狼と目が合う
		PRINTFORMW 「なんだか、恥ずかしいわね…」
		PRINTFORMW じっと見つめていると恥ずかしそうに視線をそらしてしまった
		PRINTFORMW しかし尻尾がふりふりと揺れているのを見過ごさなかった
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白成功
;-------------------------------------------------
IF ARG == 2
	;恋慕
	IF TALENT:恋慕
		PRINTFORMW あなたは今日こそ彼女に想いを伝えると決めていた
		PRINTFORMW 「…？なぁに%ANAME(MASTER)%？」
		PRINTFORMW 彼女の名を呼ぶとこちらを振り向く
		PRINTFORMW その顔を見るだけで顔が上気してしまい、言うべき言葉が出てこない
		PRINTFORMW あなたが喉から次の言葉を絞り出すのに苦労していると
		PRINTFORMW 首をかしげ、耳をピクピクと動かしながらあなたを覗き込んできた
		PRINTFORMW ここでひいては男がすたると意を決すると
	;服従
	ELSEIF TALENT:服従
		PRINTFORMW あなたは今日こそ彼女に想いを伝えると決めていた
		PRINTFORMW 「…？なんですかご主人様？」
		PRINTFORMW 彼女の名を呼ぶとこちらを振り向く
		PRINTFORMW その顔を見るだけで顔が上気してしまい、言うべき言葉が出てこない
		PRINTFORMW あなたが喉から次の言葉を絞り出すのに苦労していると
		PRINTFORMW 首をかしげ、耳をピクピクと動かしながら不安そうにあなたを覗き込んできた
		PRINTFORMW ここでひいては男がすたると意を決すると
	;それ以外
	ELSE
		PRINTFORMW あなたは今日こそ彼女に想いを伝えると決めていた
		PRINTFORMW 「…？なにかしら？」
		PRINTFORMW 彼女の名を呼ぶとこちらを振り向く
		PRINTFORMW その顔を見るだけで顔が上気してしまい、言うべき言葉が出てこない
		PRINTFORMW あなたが喉から次の言葉を絞り出すのに苦労していると
		PRINTFORMW 首をかしげ、耳をピクピクと動かしながらあなたを覗き込んできた
		PRINTFORMW ここでひいては男がすたると意を決すると
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;告白失敗
;-------------------------------------------------
IF ARG == 3
	PRINTFORMW あなたは今日こそ彼女に想いを伝えると決めていた
	PRINTFORMW 「…？なにかしら？」
	PRINTFORMW 彼女の名を呼ぶとこちらを振り向く
	PRINTFORMW その顔を見るだけで顔が上気してしまい、言うべき言葉が出てこない
	PRINTFORMW あなたが喉から次の言葉を絞り出すのに苦労していると
	PRINTFORMW 首をかしげ、耳をピクピクと動かしながらあなたを覗き込んできた
	PRINTFORMW ここでひいては男がすたると意を決すると
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(酒酔いの影響・合意は得られない)
;-------------------------------------------------
IF ARG == 4
	PRINTFORMW そろそろ日が暮れる頃だ
	PRINTFORMW あなたは隣にいる影狼の様子を見た
	PRINTFORMW 「ふにゃあ…ひっく…」
	PRINTFORMW どうやら酔いが回ってきたようで、フラフラしている
	PRINTFORMW あなたはニヤリと笑みを浮かべると
	PRINTFORMW フラフラで抵抗できない影狼を恋人のように抱えると
	PRINTFORMW 手ごろな場所に連れ込んだ
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(合意を取得)
;-------------------------------------------------
IF ARG == 5
	;恋慕
	IF TALENT:恋慕
		PRINTFORMW そろそろ日が暮れる頃だ
		PRINTFORMW あなたは隣にいる影狼の様子を見た
		PRINTFORMW 「…？」
		PRINTFORMW 影狼と目が合う
		PRINTFORMW どうかしたのかと顔を近づけてくる彼女の肩に手をかける
		PRINTFORMW 「あっ…」
		PRINTFORMW 影狼は一瞬戸惑ったような表情を見せたが
		PRINTFORMW すぐにあなたの意図を察したのか、顔を真っ赤にしてあなたを見つめてきた
		PRINTFORMW そのままゆっくりと押し倒すが、あなたを受け入れた様にされるがままだ
		PRINTFORMW 影狼に覆いかぶさる姿勢で、彼女と見つめ合う
		PRINTFORMW 「うん…えへへ…しよ？」
		PRINTFORMW 頬を染めながら微笑む影狼の服をゆっくりと脱がした
	;服従
	ELSEIF TALENT:服従
		PRINTFORMW そろそろ日が暮れる頃だ
		PRINTFORMW あなたは隣にいる影狼の様子を見た
		PRINTFORMW 「…？」
		PRINTFORMW 影狼と目が合う
		PRINTFORMW どうかしたのかと顔を近づけてくる彼女の肩に手をかける
		PRINTFORMW 「あっ…」
		PRINTFORMW 影狼は一瞬戸惑ったような表情を見せたが
		PRINTFORMW すぐにあなたの意図を察したのか、上目遣いであなたを見つめてきた
		PRINTFORMW そのままゆっくりと押し倒すが、微かに身体を震わせながらもされるがままだ
		PRINTFORMW 影狼に覆いかぶさる姿勢で、彼女と見つめ合う
		PRINTFORMW 「…あの…優しく、してください…」
		PRINTFORMW 影狼の服に手をかけると、ビクッと身体を震わせた
	;それ以外
	ELSE
		PRINTFORMW そろそろ日が暮れる頃だ
		PRINTFORMW あなたは隣にいる影狼の様子を見た
		PRINTFORMW 「…？」
		PRINTFORMW 影狼と目が合う
		PRINTFORMW どうかしたのかと顔を近づけてくる彼女の肩に手をかける
		PRINTFORMW 「あっ…」
		PRINTFORMW 影狼は一瞬戸惑ったような表情を見せたが
		PRINTFORMW すぐにあなたの意図を察したのか、顔を真っ赤にしてあなたを見つめてきた
		PRINTFORMW そのままゆっくりと押し倒すが、あなたを受け入れた様にされるがままだ
		PRINTFORMW 影狼に覆いかぶさる姿勢で、彼女と見つめ合う
		PRINTFORMW 「うん…いいよ…」
		PRINTFORMW 微かに声を震わせながら微笑む影狼の服をゆっくりと脱がした
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し失敗
;-------------------------------------------------
IF ARG == 6
	;服従
	IF TALENT:服従
		PRINTFORMW 辺りに人影が無いのを確認し
		PRINTFORMW 影狼の服に手を賭けようと手を伸ばすと
		PRINTFORMW さっと避けられた
		PRINTFORMW 「…今は、そんな気分じゃないの」
		PRINTFORMW それだけ告げると影狼はさっさと立ち去って行ってしまった
	;それ以外
	ELSE
		PRINTFORMW 辺りに人影が無いのを確認し
		PRINTFORMW 影狼の服に手を賭けようと手を伸ばすと
		PRINTFORMW むっとした表情で払いのけられた
		PRINTFORMW 「…触らないでって言ったでしょ」
		PRINTFORMW それだけ告げると影狼はさっさと立ち去って行ってしまった
	ENDIF
	RETURN 0
ENDIF

;-------------------------------------------------
;押し倒し成功(既に合意あり)
;-------------------------------------------------
IF ARG == 7
	;恋慕
	IF TALENT:恋慕
		SELECTCASE RAND:5
			CASE 0
				PRINTFORMW 「えへへ、…しよっか？」
				PRINTFORMW 雌の表情でこちらを覗きこんでくる影狼に、我慢できずに押し倒した
			CASE 1
				PRINTFORMW 「うん、いっぱいしよ」
				PRINTFORMW 肩に手をかけると、嬉しそうに尻尾を振った
			CASE 2
				PRINTFORMW 「いっぱい気持ち良く、してぇ」
				PRINTFORMW 抱き寄せると、甘えるようにあなたに身を任せてきた
			CASE 3
				PRINTFORMW 「ん…」
				PRINTFORMW 蕩けたような表情であなたを見つめている影狼を優しく押し倒した
			CASE 4
				PRINTFORMW 「あん、えへぇ…またするのね…」
				PRINTFORMW 乱暴に影狼を押し倒すと、嬉しそうにされるがままになっている
		ENDSELECT
	;服従
	ELSEIF TALENT:服従
```
