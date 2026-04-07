# SYSTEM/COLORBAR.ERB — 自动生成文档

源文件: `ERB/SYSTEM/COLORBAR.ERB`

类型: .ERB

自动摘要: functions: PRINT_RATE_BAR, PRINT_RATE_BAR_EX, PRINT_RGB_SLIDER, PRINT_HSB_SLIDER, COLOR_PICKER; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿
;≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡
; カラーバー表示用関数群
;
;≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡


;================================================================
; ゲージ(割合カラーバー)の表示処理。
;  左端色から右端色へとグラデーションする。
;--------------------------------
;	nBarVol		: バー現在値
;	nBarVolMax	: バー最大値（0以下指定だとnBarVolと同値として扱う）
;	nScaleNum	: 目盛数（10000(0.01%*10000=100%)を割り切れる数で指定することを推奨）
;	nScaleWidht	: 一目盛の幅（PRINT_RECTの幅の値）
;					※ nScaleWidht*nScaleNumがバーの長さになる
;	colorLeft	: バーの色(左端のメモリの色)
;	colorRigth	: バーの色(右端(100%)のメモリの色)
;	colorEmpty	: バーの色(Empty部分)
;	flgExtra	: 特殊表示フラグ（ビット演算。）
;					0x0001:最大値を超えて表示する, 0x0002:太いバー, 0x0004:細いバー, 0x0008:極太バー
;					0x0010:BOTTOM表示, 0x0020:TOP表示
;					0x0100:, 
;					0x1000:メモリ区切りあり, 
;--------------------------------
; 注意点
;	メモリ区切りありの場合、メモリ幅が小さいときれいに表示されない模様。
;================================================================
@PRINT_RATE_BAR( nBarVol, nBarVolMax, nScaleNum, nScaleWidht, colorLeft, colorRigth, colorEmpty, flgExtra )
	#DIM nBarVol
	#DIM nBarVolMax
	#DIM nScaleNum
	#DIM nScaleWidht
	#DIM colorLeft
	#DIM colorRigth
	#DIM colorEmpty
	#DIM flgExtra

	CALL PRINT_RATE_BAR_EX( nBarVol, nBarVolMax, nScaleNum, nScaleWidht, colorLeft, colorRigth, colorEmpty, flgExtra, 0, 0x000000 )

	RETURN


;================================================================
; ゲージ(割合カラーバー)の表示処理。
;  左端色から右端色へとグラデーションする。
;--------------------------------
;	nBarVol		: バー現在値
;	nBarVolMax	: バー最大値（0以下指定だとnBarVolと同値として扱う）
;	nScaleNum	: 目盛数（10000(0.01%*10000=100%)を割り切れる数で指定することを推奨）
;	nScaleWidht	: 一目盛の幅（PRINT_RECTの幅の値）
;					※ nScaleWidht*nScaleNumがバーの長さになる
;	colorLeft	: バーの色(左端のメモリの色)
;	colorRigth	: バーの色(右端(100%)のメモリの色)
;	colorEmpty	: バーの色(Empty部分)
;	flgExtra	: 特殊表示フラグ（ビット演算。）
;					0x0001:最大値を超えて表示する, 0x0002:太いバー, 0x0004:細いバー, 0x0008:極太バー
;					0x0010:BOTTOM表示, 0x0020:TOP表示
;					0x0100:, 
;					0x1000:メモリ区切りあり, 
;	nBarVol2	: nBarVol ～ nBarVol2までの値をcolorEmptyとは別の色で処理するために使用する
;	colorVol2	: 
;--------------------------------
; 注意点
;	メモリ区切りありの場合、メモリ幅が小さいときれいに表示されない模様。
;================================================================
@PRINT_RATE_BAR_EX( nBarVol, nBarVolMax, nScaleNum, nScaleWidht, colorLeft, colorRigth, colorEmpty, flgExtra, nBarVol2, colorVol2 )
#LOCALSIZE 4
	#DIM nBarVol
	#DIM nBarVolMax
	#DIM nScaleNum
	#DIM nScaleWidht
	#DIM colorLeft
	#DIM colorRigth
	#DIM colorEmpty
	#DIM flgExtra
	#DIM nBarVol2
	#DIM colorVol2

	#DIM colorLeft_RGB, 3
	#DIM colorRigth_RGB, 3
	#DIM nPointX
	#DIM nPointY
	#DIM nHeight
	#DIM nRate
	#DIM nLimitOver
	#DIM nScaleRate
	#DIM colorMem
	#DIM nRate2

	colorMem = GETCOLOR()

	; nRate,nScaleRateは0.1%単位
	IF flgExtra & 0x0008
		nHeight = 90
	ELSEIF flgExtra & 0x0002
		nHeight = 40
	ELSEIF flgExtra & 0x0004
		nHeight = 12
	ELSE
		nHeight = 24
	ENDIF
	IF flgExtra & 0x1000
		nPointX = LIMIT( 12, nScaleWidht / 10, nScaleWidht / 3 )
	ELSE
		nPointX = 0
	ENDIF
	IF flgExtra & 0x0010
		nPointY = (100 - nHeight) * 4 / 5
	ELSEIF flgExtra & 0x0020
		nPointY = (100 - nHeight) * 1 / 5
	ELSE
		nPointY = (100 - nHeight) / 2
	ENDIF

	colorLeft_RGB:0 = colorLeft / 256 / 256
	colorLeft_RGB:1 = colorLeft / 256 % 256
	colorLeft_RGB:2 = colorLeft % 256
	colorRigth_RGB:0 = colorRigth / 256 / 256
	colorRigth_RGB:1 = colorRigth / 256 % 256
	colorRigth_RGB:2 = colorRigth % 256

	nLimitOver = ((flgExtra & 0x01) ? 1 # 0)

	IF nBarVolMax > 0
		nRate = MAX(10000 * nBarVol / nBarVolMax, 0)
		nRate2 = MAX(10000 * nBarVol2 / nBarVolMax, 0)
	ELSE
		nRate = 10000
		nRate2 = 10000
	ENDIF
	IF nLimitOver == 0
		nRate = LIMIT(nRate, 0, 10000)
		nRate2 = LIMIT(nRate2, 0, 10000)
	ENDIF

	; 1目盛で進むパーセンテージを算出
	nScaleRate = MAX(10000 / nScaleNum, 1)

	; ゲージの描画ループ（1目盛ずつ色をグラデーションさせながら描画する）
	FOR LOCAL, 0, nScaleNum
		IF nRate > 0
			LOCAL:1 = LIMIT( colorLeft_RGB:0 + (colorRigth_RGB:0 - colorLeft_RGB:0) * LOCAL / nScaleNum, 0, 0xFF )
			LOCAL:2 = LIMIT( colorLeft_RGB:1 + (colorRigth_RGB:1 - colorLeft_RGB:1) * LOCAL / nScaleNum, 0, 0xFF )
			LOCAL:3 = LIMIT( colorLeft_RGB:2 + (colorRigth_RGB:2 - colorLeft_RGB:2) * LOCAL / nScaleNum, 0, 0xFF )
			SETCOLOR ((LOCAL:1 * 256 * 256) + (LOCAL:2 * 256) + (LOCAL:3))
		ELSE
			IF nRate2 > 0
				SETCOLOR colorVol2
			ELSE
				; 現在値を超えたので空のゲージ表示になる
				SETCOLOR colorEmpty
			ENDIF
		ENDIF
		PRINT_RECT nPointX, nPointY, nScaleWidht - nPointX, nHeight
		nRate -= nScaleRate
		nRate2 -= nScaleRate
	NEXT

	IF nLimitOver
		; 最大値を超えて表示する場合の表示処理。もう色は変えない
		WHILE nRate > 0 || nRate2 > 0
			PRINT_RECT nPointX, nPointY, nScaleWidht - nPointX, nHeight
			nRate -= nScaleRate
			nRate2 -= nScaleRate
		WEND
	ENDIF

	; フォント色を元に戻す
	SETCOLOR colorMem

	RETURN


;================================================================
; RGBスライダーの生成。（バーっぽく見えるけど実際はボタンの集合体）
;--------------------------------
;	nBaseColor	: 基準となるカラー値
;================================================================
@PRINT_RGB_SLIDER( nBaseColor )
#LOCALSIZE 4
	#DIM nBaseColor

	#DIM nColorBuf
	#DIM color_RGB, 3
	#DIM nSelectMark
	#DIM loopColor
	#DIM loopRGB
	#DIM colorMem
	#DIMS strFontMem

	colorMem = GETCOLOR()
	strFontMem = %GETFONT()%
	nColorBuf = nBaseColor

	SIF LINEISEMPTY() == 0
		PRINTFORML

	color_RGB:0 = nColorBuf / 256 / 256
	color_RGB:1 = nColorBuf / 256 % 256
```
