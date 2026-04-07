# SYSTEM/EVENT_PRISONER_TEXT.ERB — 自动生成文档

源文件: `ERB/SYSTEM/EVENT_PRISONER_TEXT.ERB`

类型: .ERB

自动摘要: functions: EVENT_PRISONER_TEXT0, EVENT_PRISONER_TEXT2, EVENT_PRISONER_TEXT3, EVENT_PRISONER_TEXT4, EVENT_PRISONER_TEXT5, EVENT_PRISONER_TEXT6, EVENT_PRISONER_TEXT7, EVENT_PRISONER_TEXT8; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;拘留
;-------------------------------------------------
@EVENT_PRISONER_TEXT0(ARG:0)

IF TALENT:(ARG:0):崩壊 || TALENT:(ARG:0):虚ろ
	PRINTFORML %ANAME(ARG:0)%は牢の中で虚ろに視線を彷徨わせている
ELSE
	IF RAND:4
		IF ABL:(ARG:0):知略 >= 70
			PRINTFORML %ANAME(ARG:0)%は牢の中で大人しくしている…
		ELSEIF ABL:(ARG:0):武闘 >= 70
			PRINTFORML %ANAME(ARG:0)%は牢の中で暴れているようだ…
		ELSEIF ABL:(ARG:0):政治 >= 70
			PRINTFORML %ANAME(ARG:0)%は牢の外にいる看守と話し込んでいる…
		ELSE
			PRINTFORML %ANAME(ARG:0)%は牢の中で不安そうにしている…
		ENDIF
	ELSE
		SELECTCASE RAND:4
			CASE 0
				PRINTFORML %ANAME(ARG:0)%は牢の中でじっとしている…
			CASE 1
				PRINTFORML %ANAME(ARG:0)%は牢の中で文句を言っている…
			CASE 2
				PRINTFORML %ANAME(ARG:0)%は牢の中で心細そうにしている…
			CASEELSE
				PRINTFORML %ANAME(ARG:0)%は牢の中で不安そうにしている…
		ENDSELECT
	ENDIF
ENDIF

;-------------------------------------------------
;拷問
;-------------------------------------------------
@EVENT_PRISONER_TEXT2(ARG:0)
SELECTCASE RAND:10
	CASE 0
		PRINTFORML %ANAME(ARG:0)%は裸にされて手首を縄で縛られ、天井に吊り下げられている…
		PRINTFORML 鞭を持った屈強な兵士が、パァンという高い音とともにその肌に無数の痣を刻んでいく
	CASE 1
		PRINTFORML %ANAME(ARG:0)%は縛り上げられ、口にじょうごをセットされている
		PRINTFORML じょうごに次から次へ水が注がれ、その胃袋は膨らんでいる……
	CASE 2
		PRINTFORML %ANAME(ARG:0)%は裸にされて柱にくくりつけられている……
		PRINTFORML 屈強な兵士が、何度も何度もその腹を殴りつけている
	CASE 3
		PRINTFORML %ANAME(ARG:0)%は裸にされ、三角木馬に乗せられている
		PRINTFORML 両足には重石がつけられており、重みが彼女の脚と股間へダメージを与えていく
	CASE 4
		PRINTFORML %ANAME(ARG:0)%は丸腰のまま、何人もの武装した兵士と組み手をさせられている
		PRINTFORML 当然かなうはずもなく、組み手はすぐ私刑へと変わった……
	CASE 5
		PRINTFORML %ANAME(ARG:0)%は爆音の中で生活させられている
		PRINTFORML 頭の割れるような音の中、%ANAME(ARG:0)%は過ごしている……
	CASE 6
		PRINTFORML %ANAME(ARG:0)%は眠ることを許されていない
		PRINTFORML まぶたが降りた途端、監視役の兵士が顔面に水をぶちまけたたき起こす……
	CASE 7
		PRINTFORML %ANAME(ARG:0)%は手足に縄をくくりつけられ、それぞれを違う方向に引っ張られている……
		PRINTFORML 身体の引きちぎれる寸前で、力を緩めるのを、拷問官は何度も繰り返している……
	CASE 8
		PRINTFORML %ANAME(ARG:0)%にはもう何日も食べ物が与えられていない
		PRINTFORML さすがの%ANAME(ARG:0)%も、もう腕一本上げる体力すら残されていないようだ……
	CASE 9
		PRINTFORML %ANAME(ARG:0)%は鉄の柱に身体をくくりつけられている……
		PRINTFORML 柱の内では火が燃えている。柱はどんどんと熱くなり、%ANAME(ARG:0)%の肉を焦がす……
ENDSELECT

;-------------------------------------------------
;身体開発
;-------------------------------------------------
@EVENT_PRISONER_TEXT3(ARG:0)
PRINTFORML %ANAME(ARG:0)%は裸にされて拘束台に固定されている…

IF HAS_PENIS(ARG:0)
	PRINTFORML 命じられた女官達は指や舌を使い、%ANAME(ARG:0)%のペニスに射精しない程度の緩やかな刺激を与え続けた…
	RETURN 0
ELSE
	SELECTCASE RAND:4
		CASE 0
			SELECTCASE RAND:5
				CASE 0
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%のクリを手や舌でひたすら苛め続けた…
					RETURN 0
				CASE 1
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の乳房にローターを押し当て、ひたすら絶頂させた……
				CASE 2
					PRINTFORML 女官は%ANAME(ARG:0)%の股にバターを塗り、犬にクリトリスを何度も舐めさせた……
				CASE 3
					PRINTFORML 命じられた女官達は%ANAME(ARG:0)%が自らおねだりするまで徹底的に焦らし続けた……
				CASE 4
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%が体力の限界を迎えてもひたすらに絶頂させた……
			ENDSELECT
			RETURN 0
		CASE 1
			SELECTCASE RAND:5
				CASE 0
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の両の胸を揉みしだき、乳首を舌で優しく舐め回した…
				CASE 1
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の乳首にローターを押し当て、ひたすら絶頂させた……
				CASE 2
					PRINTFORML 女官は%ANAME(ARG:0)%の乳房に搾乳機を取り付け、ひたすらに搾り続けた……
				CASE 3
					PRINTFORML 命じられた女官達は%ANAME(ARG:0)%が自らおねだりするまで徹底的に焦らし続けた……
				CASE 4
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%が体力の限界を迎えてもひたすらに絶頂させた……
			ENDSELECT
			RETURN 1
		CASE 2
			SELECTCASE RAND:3
				CASE 0
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の膣口浅くを弄くり回し、何度も絶頂させた……
				CASE 1
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の子宮を腹の上から刺激し、何度も絶頂させた……
				CASE 2
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の陰唇を執拗に責め、何度も絶頂させた……
				CASE 3
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の膣を指や舌でひたすら苛め続けた……
			ENDSELECT
			RETURN 2
		CASE 3
			SELECTCASE RAND:3
				CASE 0
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%の肛門浅くを弄くり回し、何度も絶頂させた……
				CASE 1
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%のアヌスに指を抜き差しし、何度も絶頂させた……
				CASE 2
					PRINTFORML 命じられた女官達は、%ANAME(ARG:0)%のアヌスを執拗に責め、何度も絶頂させた……
			ENDSELECT
			RETURN 3
	ENDSELECT
ENDIF

;-------------------------------------------------
;説得
;-------------------------------------------------
@EVENT_PRISONER_TEXT4(ARG:0)
PRINTFORML %ANAME(ARG:0)%は文官達に説得を受けている……

;-------------------------------------------------
;性処理
;-------------------------------------------------
@EVENT_PRISONER_TEXT5(ARG:0)
IF IS_MALE(ARG:0)
	PRINTFORML 屈強な兵士達が%ANAME(ARG:0)%の尻穴を次々に犯していく
	PRINTFORML さらに、男達は%ANAME(ARG:0)%の口に竿を押し込んで、強引に腰を突き込んでいく
	PRINTFORML %ANAME(ARG:0)%は途中で何度も意識を飛ばしながら、延々と男達の欲望に曝され続けた
	RETURN
ENDIF

SELECTCASE RAND:30
	CASE 0
		PRINTFORML %ANAME(ARG:0)%は裸にされ、柱に腕を固定されている……
		PRINTFORML 屈強な兵士達が強引に股を開かせ、%ANAME(ARG:0)%の両方の穴に次々に男性器を挿入していく
		PRINTFORML さらに、男達は%ANAME(ARG:0)%の口に竿を押し込んで、強引に腰を突き込んでいく
		IF HAS_PENIS(ARG:0)
			PRINTFORML いきり勃つモノは何度も扱かれ、精をまき散らしている
		ENDIF
		PRINTFORML %ANAME(ARG:0)%は途中で何度も意識を飛ばしながら、延々と男達の欲望に曝され続けた
	CASE 1
		PRINTFORML %ANAME(ARG:0)%は裸にされ、兵士たちに奉仕をさせられている……
		PRINTFORML 何人もの兵士が%ANAME(ARG:0)%を取り囲み、ペニスを突き出している
		PRINTFORML %ANAME(ARG:0)%はそれらを代わる代わる咥えさせられた……
		PRINTFORML 当然、たった一人のそれも口だけでそれだけの数のペニスを満足させられるはずもない
		PRINTFORML %ANAME(ARG:0)%は結局組み敷かれ、乱暴に犯された……
	CASE 2
		PRINTFORML %ANAME(ARG:0)%は裸にされ、寝台に大の字でくくりつけられている……
		PRINTFORML 何人もの兵士が代わる代わる%ANAME(ARG:0)%に覆い被さり、両方の穴に次々と男性器を挿入する
		PRINTFORML さらに、別の兵士が%ANAME(ARG:0)%の顔に乗っかり、\@ RAND:2 ? 無理矢理口で奉仕させる # 尻穴を舐めさせている \@
		IF HAS_PENIS(ARG:0)
			PRINTFORML %ANAME(ARG:0)%があさましくも勃起していることを兵士達はあざ笑い、激しく扱いて何度も無理矢理射精させる
		ENDIF
		PRINTFORML %ANAME(ARG:0)%は一晩中、数えられないほどの男の慰み者にされた……
	CASE 3
		PRINTFORML %ANAME(ARG:0)%は裸に首輪をつけられ、兵舎を引き回された……
		PRINTFORML 無数の下卑た視線をその肌に注がれ、%ANAME(ARG:0)%は身を硬くしている
		IF HAS_PENIS(ARG:0)
			PRINTFORML その股間の「汚らしいモノ」を、兵士達は特にあざ笑う
		ENDIF
		PRINTFORML そして食堂の中央、何人もの兵士が見ている中で、%ANAME(ARG:0)%はオナニーを強要された
		PRINTFORML %ANAME(ARG:0)%が絶頂した後、興奮した兵士たちは彼女に群がっていった……
	CASE 4
		PRINTFORML %ANAME(ARG:0)%は裸にされ、四つん這いの姿勢から何度も犯されている……
		PRINTFORML 尻穴を犯したばかりの汚れたペニスが、今度は膣穴を容赦なく陵辱する
		PRINTFORML 抽送のたび、既に何発も放たれた精液が、彼女の両穴から音を立てて噴きだしている
		PRINTFORML 無慈悲な抽送の間にも、彼女は口での奉仕を強要されている……
		IF HAS_PENIS(ARG:0)
			PRINTFORML 彼女のペニスは犯される快楽で何度も射精し、床を汚している……
		ENDIF
		PRINTFORML %ANAME(ARG:0)%が意識を飛ばしそうになると、兵士は容赦なく彼女を叩いて目覚めさせた……
	CASE 5
		PRINTFORML %ANAME(ARG:0)%は兵士に取り囲まれ、彼らに刃向かったことを土下座で謝罪させられている
		PRINTFORML 屈辱に震える彼女の頭を、兵士はあざ笑いながら踏みつけた
		PRINTFORML さらに、その身体に容赦なく尿をかけはじめた……
		PRINTFORML その後、彼らはそのままの姿勢で%ANAME(ARG:0)%を何度も犯していった……
		IF HAS_PENIS(ARG:0)
			PRINTFORML 陵辱の最中で放たれた%ANAME(ARG:0)%の子種を、兵士達は彼女自身に舐め取らせた
		ENDIF
	CASE 6
```
