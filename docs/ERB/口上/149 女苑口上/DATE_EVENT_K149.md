# 口上/149 女苑口上/DATE_EVENT_K149.ERB — 自动生成文档

源文件: `ERB/口上/149 女苑口上/DATE_EVENT_K149.ERB`

类型: .ERB

自动摘要: functions: DATE_EVENT_K149, DATE_EVENT_K149_mizuumi, DATE_EVENT_K149_yama, DATE_EVENT_K149_mori, DATE_EVENT_K149_hitozato, DATE_EVENT_K149_hanabatake, DATE_EVENT_K149_zitaku; UI/print

前 200 行源码片段:

```text
﻿;--------------------------------------------------------
;そのキャラのデートイベント本体を呼び出すハブとなる関数
;--------------------------------------------------------
@DATE_EVENT_K149(場所)
#DIM 場所
#DIM 湖
#DIM 山
#DIM 森
#DIM 人里
#DIM 花畑
#DIM 自宅
#DIM 女苑
#DIM 紫苑
女苑 = NAME_TO_CHARA("女苑")
紫苑 = NAME_TO_CHARA("紫苑")

;面識がないとデートイベントは発生しない
SIF CFLAG:女苑:面識 == 0
	RETURN 0
	
;--------------------------
;デートに誘ったときの反応	
;--------------------------

;好感度10000以上
IF CFLAG:女苑:好感度 >= 10000
	;恋慕ルート
	IF TALENT:女苑:恋慕
		PRINTDATAL
		DATAFORM 「…私と、デート？　…ふふ♥　ありがとう。とっても楽しみよ」
		DATAFORM 「私とデートしてくれるの？　えへへ、嬉しいなぁ♥　…ちゃんとエスコート、してね？」
		DATAFORM 「デートに誘ってくれるなんて嬉しいなぁ…♥　%ANAME(MASTER)%と一緒なら、何処へでも付いて行くわ♥」
		ENDDATA
		PRINTFORMW %ANAME(女苑)%は愛する%ANAME(MASTER)%にデートに誘われて、嬉しさに顔を綻ばせている
	;それ以外
	ELSE
		PRINTDATAL
		DATAFORM 「デートのお誘い？　あははっ、行く行くー♪　何処にでもついて行くわ♪」
		DATAFORM 「私とデートを？　えへへっ♪　良いわよ。ちゃーんとエスコートしてね♥」
		DATAFORM 「疫病神の私をデートに誘ってくれるのなんて%ANAME(MASTER)%くらいなの。だからいっぱい楽しませてねっ♪」
		ENDDATA
		PRINTFORMW %ANAME(女苑)%は思いを寄せている%ANAME(MASTER)%にデートに誘われて嬉しそうだ
	ENDIF
	;自軍に紫苑がいたら1/3の確率で表示される
	IF CFLAG:紫苑:所属 == CFLAG:MASTER:所属 &&  !(MASTER == NAME_TO_CHARA("紫苑")) && !RAND:3
		PRINTFORML ・
		PRINTFORML ・・
		PRINTFORMW ・・・
		CALL SINGLE_DRAWLINE
		PRINTFORML 
		PRINTFORMW そして約束の日の朝
		PRINTFORML 「あ、%ANAME(女苑)%。デートにでも行くの？」
		PRINTFORMW 見るからにめかし込んだ様子の%ANAME(女苑)%に%ANAME(紫苑)%が声を掛ける
		PRINTFORML 「ああ、姉さん。そうよ、今から%ANAME(MASTER)%とのデートなの♪」
		PRINTFORMW 嬉しさで緩んだ表情で、%ANAME(女苑)%が惚気る
		PRINTFORML 「はあ…、疫病神である妹がこんなに幸せそうな顔するなんて…。羨ましいよー、私にも幸せ分けてよー」
		PRINTFORMW 「もう、仕方ないわね。じゃあ帰ったら一緒に焼肉でも行きましょう？　それでいい？」
		PRINTFORML 「やったー！　流石は自慢の妹だわー！　それじゃあ行ってらっしゃーい」
		PRINTFORMW 調子のいい%ANAME(紫苑)%に苦笑しつつ、%ANAME(女苑)%はスキップしながら%ANAME(MASTER)%とのデートに向かった
		PRINTFORML 
		CALL SINGLE_DRAWLINE
		PRINTFORMW 
	ENDIF
	
;好感度5000以上
ELSEIF CFLAG:女苑:好感度 >= 5000
	;恋慕ルート
	IF TALENT:女苑:恋慕
		PRINTDATAL
		DATAFORM 「デートのお誘い？　あははっ、行く行くー♪　何処で遊ぶの？」
		DATAFORM 「私とデートしたい？　ふふんっ♪　良いわよ。ちゃーんとエスコートしてよね♥」
		DATAFORM 「疫病神の私を誘ってくれるのなんて%ANAME(MASTER)%くらいだわ。だからちゃんと楽しませてよねっ♪」
		ENDDATA
		PRINTFORMW %ANAME(女苑)%は思いを寄せている%ANAME(MASTER)%にデートに誘われてとても嬉しそうだ
	;それ以外
	ELSE
		PRINTDATAL
		DATAFORM 「私とデートしてくれるのなんて%ANAME(MASTER)%くらいよね…。もちろんついて行くわ」
		DATAFORM 「私と遊びたいの？　ふふんっ♪　良いわよ。どこ行くの？」
		DATAFORM 「疫病神の私と遊びたがる人なんて%ANAME(MASTER)%くらいよね。ま、それも面白そうだから良いけど♪」
		ENDDATA
		PRINTFORMW %ANAME(MASTER)%にデートに誘われて、%ANAME(女苑)%は満更でもない様子だ
	ENDIF
	;自軍に紫苑がいたら1/3の確率で表示される
	IF CFLAG:紫苑:所属 == CFLAG:MASTER:所属 &&  !(MASTER == NAME_TO_CHARA("紫苑")) && !RAND:3
		PRINTFORML ・
		PRINTFORML ・・
		PRINTFORMW ・・・
		CALL SINGLE_DRAWLINE
		PRINTFORML 
		PRINTFORMW そして約束の日の朝
		PRINTFORML 「あ、%ANAME(女苑)%。そんなめかし込んで、誰かとデートにでも行くの？」
		PRINTFORMW %ANAME(MASTER)%とのデートに向けて気合を入れて準備をしている様子の%ANAME(女苑)%に%ANAME(紫苑)%が話しかける
		PRINTFORML 「ゲッ、姉さん。…べ、別に何でもないわよ。ちょっと出かけてくるだけ」
		PRINTFORMW 「いいや、絶対ウソ。ただのお出かけでそんな浮かれる妹じゃないわ。ていうかゲッ、って何よ！」
		PRINTFORML （うぐぐ…、よりによってこんな時に姉さんに絡まれるとは…）
		PRINTFORMW （アイツとのデートのことを知られたらどんなウザ絡みをされるか分かったものじゃないわ、ここは一つ……）
		PRINTFORML 「あっ！　あんなところに噂の天人様が！！」
		PRINTFORML 「えっ、天人様！？　どこどこっ！？　……って誰もいないじゃない。あれ？　%ANAME(女苑)%もいない？」
		PRINTFORML 「…………我が姉ながら心配になるレベルのチョロさね。まあいいわ、今の内に、っと」
		PRINTFORMW ……%ANAME(女苑)%は実に古典的な方法で%ANAME(紫苑)%を撒くことに成功したのだった
		PRINTFORML 
		CALL SINGLE_DRAWLINE
		PRINTFORMW 
	ENDIF
	
;好感度1500以上
ELSEIF CFLAG:女苑:好感度 >= 1500
	;恋慕ルート
	IF TALENT:女苑:恋慕
		PRINTDATAL
		DATAFORM 「疫病神とデートしたいとか…変わり者にも程があるでしょ。…ま、しょうがないから付き合ってあげるわ。感謝しなさいよー？」
		DATAFORM 「私と遊びたいの？　ふふんっ♪　良いわよ。どこ行くの？」
		DATAFORM 「疫病神の私と遊びたがる人なんて%ANAME(MASTER)%くらいよね。ま、それも面白そうだから良いけどさ♪」
		ENDDATA
		PRINTFORMW %ANAME(女苑)%は思いを寄せている%ANAME(MASTER)%にデートに誘われて嬉しそうだ
	;それ以外
	ELSE
		PRINTDATAL
		DATAFORM 「遊びに？　いいわよ。美味しい物奢ってよねー」
		DATAFORM 「アンタとデート？　ふーん、せいぜい楽しませてよねー♪」
		DATAFORM 「疫病神をデートに誘うって、ホント変わり者よね%ANAME(MASTER)%は」
		ENDDATA
		PRINTFORMW %ANAME(MASTER)%に遊びに誘われ、%ANAME(女苑)%は満更でもない様子だ
	ENDIF
	;自軍に紫苑がいたら1/3の確率で表示される
	IF CFLAG:紫苑:所属 == CFLAG:MASTER:所属 &&  !(MASTER == NAME_TO_CHARA("紫苑")) && !RAND:3
		PRINTFORML ・
		PRINTFORML ・・
		PRINTFORMW ・・・
		CALL SINGLE_DRAWLINE
		PRINTFORML 
		PRINTFORMW そして約束の日の朝
		PRINTFORML 「あ、%ANAME(女苑)%。そんなに浮かれてどこ行くの？」
		PRINTFORMW %ANAME(MASTER)%とのデートの準備に勤しむ%ANAME(女苑)%に%ANAME(紫苑)%が話しかける
		PRINTFORML 「あ、姉さん。…別に浮かれてなんか無いわよ。ちょっと出かけてくるだけ」
		PRINTFORMW 「えー、本当？　浮かれてるように見えたけど…。何か美味しい物食べに行くの？　私も連れてってよー」
		PRINTFORML （あー、よりによって面倒な時に姉さんに絡まれたわね…）
		PRINTFORMW （今更アイツとのデートだから、何て言ったら絶対からかわれるわね、ここは一つ……）
		PRINTFORML 「あっ！　あんなところにお供え物の大福がいっぱい！！」
		PRINTFORMW 「え！？　どこどこっ！？　私にもお供え物ちょうだいっ！」
		PRINTFORML %ANAME(紫苑)%は指を指された方向へ一目散に向かっていった…
		PRINTFORML 「……我が姉ながら心配になるレベルのチョロさね。まあいいわ、今の内に、っと」
		PRINTFORMW %ANAME(女苑)%は実に古典的な方法で%ANAME(紫苑)%を撒くことに成功した
		PRINTFORML 
		CALL SINGLE_DRAWLINE
		PRINTFORMW 
	ENDIF
	
;好感度500以上
ELSEIF CFLAG:女苑:好感度 >= 500
	PRINTDATAL
	DATAFORM 「デート？　私と？　…疫病神なのに誘ってくれるんだ…、ふーん…っ♪」
	DATAFORM 「アンタとデート？　ふーん、せいぜい楽しませてよね」
	DATAFORM 「疫病神と遊びたいって…。何ていうか、変わり者よね%ANAME(MASTER)%は」
	ENDDATA
	PRINTFORMW %ANAME(MASTER)%に遊びに誘われ、%ANAME(女苑)%は満更でもない様子だ
	
;好感度0以上
ELSEIF CFLAG:女苑:好感度 >= 0
	PRINTDATAL
	DATAFORM 「デート？　この私と？　…私が疫病神だってお分かり？」
	DATAFORM 「アンタとデートぉ？　……まあ、奢ってくれるのならいいか」
	DATAFORM 「疫病神と遊びたいって…。本当何ていうか…アレね、アンタ」
	ENDDATA
	PRINTFORMW まだ付き合いの浅い%ANAME(MASTER)%に誘われて、%ANAME(女苑)%は戸惑い気味のようだ…
	
;好感度マイナス状態
ELSE
	PRINTDATAL
	DATAFORM 「……よりにもよってアンタとデートだなんて……。気が滅入るわ」
	DATAFORM 「アンタとデートぉ？　……冗談も程ほどにして欲しいもんだわ……」
	DATAFORM 「お金貰ったって嫌なぐらいだけど……。これも仕事の内だと思って我慢ね」
	ENDDATA
	PRINTFORMW %ANAME(MASTER)%に悪印象を持っている%ANAME(女苑)%は、露骨に嫌そうにしている…
ENDIF
PRINTFORML …
PRINTFORML ……
PRINTFORML ………
PRINTFORML

;--------------------------
;デートイベント本体へ
;--------------------------
SELECTCASE 場所
	CASE 1
		;湖に行く
		CALL DATE_EVENT_K149_mizuumi(湖)
	CASE 2
		;山に行く
		CALL DATE_EVENT_K149_yama(山)
	CASE 3
		;森に行く
		CALL DATE_EVENT_K149_mori(森)
	CASE 4
		;人里に行く
		CALL DATE_EVENT_K149_hitozato(人里)
	CASE 5
		;花畑に行く
		CALL DATE_EVENT_K149_hanabatake(花畑)
```
