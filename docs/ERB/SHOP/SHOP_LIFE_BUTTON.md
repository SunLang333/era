# SHOP/SHOP_LIFE_BUTTON.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE_BUTTON.ERB`

类型: .ERB

自动摘要: functions: COLUMN_RIGHT_CHARALIST_BUTTON, SHOP_LIFE_BUTTON_ADD_TOP_PRISONER, SHOP_LIFE_BUTTON_ADD_BOTTOM_PRISONER, SHOP_LIFE_BUTTON_ADD_ABL_INFO; UI/print

前 200 行源码片段:

```text
﻿;共有しているボタンやボタンに追尾させる情報

;-------------------------------------------------
;右カラムキャラリスト用のキャラボタン
;
;ボタン表示対象キャラ=キャラ番号
;選択中色表示フラグ=0:通常カラー 1:選択中色で表示
;ボタン番号加算値=NO + ボタン番号加算値（100～）
;キャラ表示可否判定結果
;	@SHOP_LIFE_CHECKCHARA～系の返り値を代入
;	メニューファイル内のボタン指定である
;	@SHOP_LIFE_LIST1_BUTTON{メニュー番号}(ARG:0, ARG:1)や
;	@SHOP_LIFE_LIST1_BUTTON{メニュー番号}(ARG:0, ARG:1)から指定するときは
;	リスト関数内で既に判定され、結果（PRINTOPTION）がARG:1に保存されている
;	ので、そのままARG:1を返すだけでいい
;行動済表示フラグ=0:行動済みマークをつける 1:行動済みマークをつけない
;上下=今上のリストか下のリストかを指定する
;	メニューファイルでボタンの追尾情報を上下のリストで分けたいときに操作
;
;メニューファイルでの使用例）
;	CALL COLUMN_RIGHT_CHARALIST_BUTTON(ARG:0, CFLAG:(ARG:0):閨に呼ぶで選択中, SHOP_LIFE_LIST2_ADD_INPUT, ARG:1, "BOTTOM")
;リスト内での使用例）
;	CALL COLUMN_RIGHT_CHARALIST_BUTTON(NOW_CHECK_CHARA, 0, SHOP_LIFE_LIST1_ADD_INPUT, PRINTOPTION)
;-------------------------------------------------
@COLUMN_RIGHT_CHARALIST_BUTTON(ボタン表示対象キャラ, 選択中色表示フラグ = 0, ボタン番号加算値 = SHOP_LIFE_LIST1_ADD_INPUT, キャラ表示可否判定結果 = 1, 行動済表示フラグ = 0, 上下 = "")
#DIM ボタン表示対象キャラ
#DIM 選択中色表示フラグ
#DIM ボタン番号加算値
#DIM キャラ表示可否判定結果
#DIM 行動済表示フラグ
#DIMS 上下
#DIMS 名前

;CHECKCHARAの戻り値が０なら表示しない
SIF キャラ表示可否判定結果 <= 0
	RETURN 0

PRINT 

SIF 選択中色表示フラグ
	SETCOLOR カラー_選択中

IF STRLENS(ANAME(ボタン表示対象キャラ)) >= MAX_CHARANAME_LENGTH
	名前 = %SNAME(ボタン表示対象キャラ)%
ELSE
	名前 = %ANAME(ボタン表示対象キャラ)%
ENDIF

;通常表示
IF キャラ表示可否判定結果 == 1
	CALL PRINTBUTTON_CENTER(@"[%名前, MAX_CHARANAME_LENGTH, LEFT%]", NO:(ボタン表示対象キャラ) + ボタン番号加算値, 0)
;グレー表示
ELSEIF キャラ表示可否判定結果 == 2
	CALL PRINTBUTTON_CENTER(@"[%名前, MAX_CHARANAME_LENGTH, LEFT%]", NO:(ボタン表示対象キャラ) + ボタン番号加算値, 0, 0)
ENDIF

SIF 選択中色表示フラグ
	RESETCOLOR

;行動済みマーク表示
IF !行動済表示フラグ
	CALL PRINT_RESTMARK(ボタン表示対象キャラ)
	PRINT  
ENDIF

;ボタンに追加の情報を表示する指定があれば
RESULT = 0
IF 上下 == "TOP"
	TRYCCALLFORM SHOP_LIFE_BUTTON_ADD_TOP{FLAG:拠点フェイズ選択コマンド}(ボタン表示対象キャラ)
	CATCH
		TRYCALLFORM SHOP_LIFE_BUTTON_ADD{FLAG:拠点フェイズ選択コマンド}(ボタン表示対象キャラ)
	ENDCATCH
ELSEIF 上下 == "BOTTOM"
	TRYCCALLFORM SHOP_LIFE_BUTTON_ADD_BOTTOM{FLAG:拠点フェイズ選択コマンド}(ボタン表示対象キャラ)
	CATCH
		TRYCALLFORM SHOP_LIFE_BUTTON_ADD{FLAG:拠点フェイズ選択コマンド}(ボタン表示対象キャラ)
	ENDCATCH
ELSE
	TRYCALLFORM SHOP_LIFE_BUTTON_ADD{FLAG:拠点フェイズ選択コマンド}(ボタン表示対象キャラ)
ENDIF
;戻り値が１なら他の情報は表示しない
SIF RESULT
	RETURN 0

CALL IS_KOJO(NO:(ボタン表示対象キャラ))
IF RESULT
	PRINT *
ELSE
	PRINT  
ENDIF

CALL PRINT_SEX(ボタン表示対象キャラ, 1, 0, 2)

IF ボタン表示対象キャラ == MASTER
	PRINT   
ELSEIF CFLAG:(ボタン表示対象キャラ):所属 == CFLAG:MASTER:所属
	SETCOLOR 0x97f8e8
	PRINT 自
ELSEIF CFLAG:(ボタン表示対象キャラ):所属 != 0
	SETCOLOR 0x28cc28
	PRINT 他
ELSEIF CFLAG:(ボタン表示対象キャラ):特殊状態 == 特殊状態_放浪
	SETCOLOR 0x874b4e
	PRINT 浪
ELSE
	SETCOLOR 0x808080
	PRINT 無
ENDIF
RESETCOLOR
PRINT  

CALL TMP_PRINT_CHARA_STARS_NUM(ボタン表示対象キャラ)
PRINT  

IF ボタン表示対象キャラ == MASTER
	PRINT   
ELSEIF CFLAG:(ボタン表示対象キャラ):捕虜先
	IF CFLAG:(ボタン表示対象キャラ):捕虜先 == CFLAG:MASTER:所属
		IF CFLAG:(ボタン表示対象キャラ):軟禁中 == 0
			SETCOLOR 0x4434E5
			PRINT 監
		ELSE
			SETCOLOR 0xA39ED7
			PRINT 軟
		ENDIF
	ELSE
		SETCOLOR 0xdf0000
		PRINT 囚
	ENDIF
ELSEIF CFLAG:(ボタン表示対象キャラ):外交調教中
	IF CFLAG:(ボタン表示対象キャラ):外交要求成功フラグ == 2
		SETCOLOR カラー_女
		PRINT 虜
	ELSE
		SETCOLOR 0x489200
		PRINT 脅
	ENDIF
ELSEIF CFLAG:(ボタン表示対象キャラ):面識
	SETCOLOR 0xD0D0D0
	PRINT 会
ELSE
	SETCOLOR 0x404040
	PRINT 会
ENDIF
RESETCOLOR
PRINT  
IF TALENT:(ボタン表示対象キャラ):崩壊
	SETCOLOR カラー_警告
	PRINT 崩
ELSEIF TALENT:(ボタン表示対象キャラ):虚ろ
	SETCOLOR カラー_警告
	PRINT 虚
ELSEIF ID_TO_CHARA(FLAG:お気に入り指定キャラ) == ボタン表示対象キャラ
	SETCOLOR カラー_注意
	PRINT 推
ELSEIF TALENT:(ボタン表示対象キャラ):特殊勢力陥落系
	SETCOLOR カラー_警告
	PRINT 堕
ELSEIF TALENT:(ボタン表示対象キャラ):親愛
	SETCOLOR 0xF5CE13
	PRINT 愛
ELSEIF TALENT:(ボタン表示対象キャラ):恋慕
	SETCOLOR 0xFF4080
	PRINT 慕
ELSEIF TALENT:(ボタン表示対象キャラ):親友
	SETCOLOR 0xFF8000
	PRINT 友
ELSEIF TALENT:(ボタン表示対象キャラ):隷属
	SETCOLOR 0x00FFFF
	PRINT 隷
ELSEIF TALENT:(ボタン表示対象キャラ):服従
	SETCOLOR 0x00D0D0
	PRINT 服
ELSEIF TALENT:(ボタン表示対象キャラ):所有者
	SETCOLOR 0xc40055
	PRINT 所
ELSEIF TALENT:(ボタン表示対象キャラ):主人
	SETCOLOR 0xc40055
	PRINT 主

ELSE
	PRINT   
ENDIF
RESETCOLOR

IF TALENT:(ボタン表示対象キャラ):正妻
	SETCOLOR 0xF5CE13
	PRINT 妻
ELSEIF TALENT:(ボタン表示対象キャラ):妾
	SETCOLOR 0xF56000
	PRINT 妾
ELSEIF TALENT:(ボタン表示対象キャラ):恋人
	SETCOLOR 0xFF80C0
	PRINT 恋
ELSEIF TALENT:(ボタン表示対象キャラ):烙印
	SETCOLOR 0x00FF80
	PRINT 印
ELSE
	PRINT   
ENDIF
```
