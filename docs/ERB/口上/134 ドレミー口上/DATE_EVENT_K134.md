# 口上/134 ドレミー口上/DATE_EVENT_K134.ERB — 自动生成文档

源文件: `ERB/口上/134 ドレミー口上/DATE_EVENT_K134.ERB`

类型: .ERB

自动摘要: functions: DATE_EVENT_K134, DATE_EVENT_K134_mizuumi, DATE_EVENT_K134_mori, DATE_EVENT_K134_hitozato, DATE_EVENT_K134_hanabatake, DATE_EVENT_K134_zitaku; UI/print

前 200 行源码片段:

```text
﻿;CHECK_KOJO_DAILY_HAPPENの変更にともない一時停止中
;------------------------------------
;そのキャラのデートイベント本体を呼び出すハブとなる関数
;------------------------------------
@DATE_EVENT_K134(場所)
#DIM 場所
#DIM 湖
#DIM 人里
#DIM 森
#DIM 花畑
#DIM 自宅
#DIM 発生フラグ
発生フラグ = 0

;場所はSHOP_DATEを参考にしてね
SELECTCASE 場所
    CASE 1
		;湖口上
        CALL DATE_EVENT_K134_mizuumi(湖)
    CASE 2
		;森口上
        CALL DATE_EVENT_K134_mori(森)
    CASE 3
		;人里口上
        CALL DATE_EVENT_K134_hitozato(人里)
    CASE 3
		;洋服店に行こう
		;CALL DATE_EVENT_K134_youhuku(人里)
    CASE 4
		;花畑口上
        CALL DATE_EVENT_K134_hanabatake(花畑)
    CASE 5
		;自宅口上
        CALL DATE_EVENT_K134_zitaku(自宅)
    CASEELSE
ENDSELECT

;------------------------------------
;湖口上(イベントというよりセリフ集→間違った使い方かも)
;-----------------------------------
@DATE_EVENT_K134_mizuumi(湖)
#DIM ドレミ
#DIM 湖
#DIM キャラ名

ドレミ = NAME_TO_CHARA("ドレミー")

;ドレミーと所属が同じ、ドレミーが捕虜でなく、面識がある、今のところ100%発動
SIF !CHECK_KOJO_DAILY_HAPPEN(ドレミ, 1, 0, 1)
    RETURN 0


	;通常は4パターン、恋慕7パターン、正妻9パターン
SELECTCASE  IFRAND("0TO3", 1, "4TO7", TALENT:ドレミ:恋慕, "8TO9", TALENT:ドレミ:正妻)
		;通常反応
    CASE 0
        PRINTFORML 「はいっ！」
        PRINTFORML 「んっー、なかなか上手くいきませんね…」
        PRINTFORML 「%ANAME(MASTER)%もやってみます？　水切り」
    CASE 1
        PRINTFORML 「ここは静かで涼しくて、読書が捗りそうですね」
        PRINTFORML 「……なんですかその構って欲しそうな顔は」
    CASE 2
        PRINTFORML 「澄んでて綺麗な湖ですね。　……%ANAME(MASTER)%、泳ぐの？」
        PRINTFORML 「私は良いわ、水着持って来てないから」
    CASE 3
        PRINTFORML 「湖の周りを少し散歩しましょ」
		;こっから恋慕反応追加
    CASE 4
        PRINTFORML 「それにしても妖精や河童もいないわね」
        PRINTFORML 「これって二人っきりということですよね」
        PRINTFORML 「ふーん…」
    CASE 5
        PRINTFORML 「この付近は夜になると水面に綺麗な月が現れるそうよ」
        PRINTFORML 「また夜に来てみても良いかもしれないわね」
        PRINTFORML 「%ANAME(MASTER)%となら静かな月見酒も良いわね」
    CASE 6
        PRINTFORML 「さてそろそろお昼にしませんか？」
        PRINTFORML 「えぇ、今日はお弁当を作って来たのですよ」
        PRINTFORML 「どうぞ召し上がれ♪」
    CASE 7
        PRINTFORML 「澄んでて綺麗な湖ですね、少し泳ごうかしら」
        PRINTFORML 「ふふっ、ちゃんと水着と替えの下着は用意して来てますよ」
        PRINTFORML 「ささ%ANAME(MASTER)%、一緒に泳ぎましょ♪」
		;ここから正妻反応追加
    CASE 8
        PRINTFORML 「あなた～、そろそろお昼にしませんか？」
        PRINTFORML 「えぇ、今日はお弁当を作って来たのですよ」
        PRINTFORML 「どうぞ召し上がれ♪」
    CASE 9
        PRINTFORML 「…………ふふっ」
        PRINTFORML 「寄り添って歩いてるだけなのに笑っちゃった」
        PRINTFORML 「好きよ、%ANAME(MASTER)%」
ENDSELECT
IF RAND:3 == 0
    PRINTFORMW 相槌に合わせて%ANAME(ドレミ)%の尻尾がピコピコと揺れた……
ELSEIF RAND:2 == 0
    PRINTFORMW %ANAME(ドレミ)%は澄んだ湖の美しさと静けさを楽しんでる……
ELSE
    PRINTFORMW %ANAME(ドレミ)%の言葉は、%ANAME(MASTER)%をどこか誂うような声色を含んでいる……
ENDIF

;------------------------------------
;森口上
;一度きりのイベントを入れたかったけど綺麗な方法もといコードが思いつかなかったので超強引に入れた
;-----------------------------------
@DATE_EVENT_K134_mori(森)
#DIM ドレミ
#DIM 森
#DIM キャラ名

ドレミ = NAME_TO_CHARA("ドレミー")

;ドレミーと所属が同じ、ドレミーが捕虜でなく、面識がある、今のところ100%発動
SIF !CHECK_KOJO_DAILY_HAPPEN(ドレミ, 1, 0, 1)
    RETURN 0

SELECTCASE KDVAR:ドレミ:ドレミー_森口上
    CASE 0
	;通常は4パターン、恋慕7パターン、正妻9パターン
        SELECTCASE  IFRAND("0TO3", 1, "4TO7", TALENT:ドレミ:恋慕, "8TO9", TALENT:ドレミ:正妻)
			;通常反応
            CASE 0
                PRINTFORML 「帳簿の仕事？」
                PRINTFORML 「%ANAME(MASTER)%、今はデート中なのですよ仕事の話は厳禁です」
                PRINTFORML 「ほらほらっ、この先の丘に城下町を見下ろせるスポットがあるらしいですよっ」
            CASE 1
                PRINTFORML 「ここは静かで涼しくて、読書が捗りそうですね」
                PRINTFORML 「……なんですかその構って欲しそうな顔は」
            CASE 2
                PRINTFORML 「おやおや、%ANAME(MASTER)%ったらお疲れの様子で…」
                PRINTFORML 「では向こうの木陰でお眠りになっては如何でしょうか？」
                PRINTFORML 「最高の眠りと夢を保証しますよ～」
            CASE 3
                PRINTFORML 「はぁ～空気が澄んでいて気持ちが良いですねぇ」
                PRINTFORML 「たまには森林浴も悪くありませんね…」
                PRINTFORML 「おや…おやおや、今あくびしましたね…」
                PRINTFORML 「良いですよぉ、一旦どこかでお昼寝しましょうか？」
			;こっから恋慕反応追加
            CASE 4
                PRINTFORML 「ちょっと暑くなってきましたね…」
                PRINTFORML 「少し木陰で休みましょうか」
                PRINTFORML 「%ANAME(MASTER)%も…どう？」
            CASE 5
                PRINTFORML 「少し歩き疲れましたね…」
                PRINTFORML 「あの山小屋で休憩していきませんか？」
                PRINTFORML 「(ふふっ、あの山小屋はカップル御用達なのはリサーチ済みですよ…！)」
            CASE 6
                PRINTFORML 「さてそろそろお昼にしませんか？」
                PRINTFORML 「えぇ、今日はお弁当を作って来たのですよ」
                PRINTFORML 「どうぞ召し上がれ♪」
            CASE 7
                PRINTFORML 「それにしても妖精や河童もいないわね」
                PRINTFORML 「これって二人っきりということですよね」
                PRINTFORML 「ふふっ、いえなんでも～♪」
			;ここから正妻反応追加
            CASE 8
                PRINTFORML 「あなた～、そろそろお昼にしませんか？」
                PRINTFORML 「えぇ、今日はお弁当を作って来たのですよ」
                PRINTFORML 「どうぞ召し上がれ♪」
            CASE 9
                PRINTFORML 「…………ふふっ」
                PRINTFORML 「寄り添って歩いてるだけなのに笑っちゃった」
                PRINTFORML 「好きよ、%ANAME(MASTER)%」
        ENDSELECT
	;動作反応
        IF RAND:3 == 0
            PRINTFORMW 相槌に合わせて%ANAME(ドレミ)%の尻尾がピコピコと揺れた……
        ELSEIF RAND:2 == 0
            PRINTFORMW 汗まみれになった%ANAME(ドレミ)%の肌が服に吸い付いて体のラインが丸見えになっている……
        ELSE
            PRINTFORMW %ANAME(ドレミ)%の言葉は、%ANAME(MASTER)%をどこか誂うような声色を含んでいる……
        ENDIF
	;イベント判定
        IF RAND:1 == 0
            KDVAR:ドレミ:ドレミー_森口上 = 1
        ELSE
        ENDIF
	;イベント『狩りの帰り』口上
    CASE 1
        PRINTFORML ------------------------------------------------------------------------------------------------------------
        CALL COLOR_PRINTL(@"-デートイベント 『狩りの帰り』発生-", カラー_注意)
        PRINTFORML ------------------------------------------------------------------------------------------------------------
        PRINTFORMW 「……うーん、狩りに没頭し過ぎて迷ってしまいましたね」
        PRINTFORML 二人はこの日森で狩りをしていたが、没頭するあまり森の奥まで来てしまった……
        PRINTFORMW 「おや、向こうに火の光らしいものが見えますね……行きましょう」
        PRINTFORML %ANAME(ドレミ)%の提案で%ANAME(MASTER)%達は馬を走らせた
        PRINTFORML 
        PRINTFORMW 「おやおや、これは……？」
        PRINTFORML 二人が森を抜けるとそこは兵士が使う大型のテントが規則正しくズラリと並んでいた
        PRINTFORML テントの傍で飯盒を炊いている兵士達が%ANAME(MASTER)%達に気付く
        PRINTFORMW 『なんだなんだ、随分と身なりのえー方らが来たんで？』
        PRINTFORML 『もしかしてぇ、えれぇー人が見回りに来たんとちゃいますん？』
        PRINTFORML 『そりゃ大変だぁ、丁重に迎えねぇとなぁ！』
        PRINTFORMW 駐屯していた兵士達は自ずと集まり、%ANAME(MASTER)%が通る傍に出迎えるように整列した
        PRINTFORML 
        PRINTFORMW 「……ねぇ%ANAME(MASTER)%、もしかしてこの兵士達って」
        PRINTFORML 馬上で違和感を覚えた%ANAME(ドレミ)%が耳打ちをする、一方%ANAME(MASTER)%はその違和感の正体に気付いた様子である
        PRINTFORMW 『んでー、何でお偉いさん方がここにいるだぁ？』
        PRINTFORML 『んな事わかんねぇんよー』
```
