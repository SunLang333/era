# SHOP/SHOP_LIFE/SHOP_LIFE11_会いに行く.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/SHOP_LIFE11_会いに行く.ERB`

类型: .ERB

自动摘要: functions: SHOP_LIFE_NAME11, SHOP_LIFE_CHECK11, SHOP_LIFE_CHECKCHARA11, SHOP_LIFE_EVENTBUY11, SHOP_LIFE_EVENTBUY_SHOW11, SHOP_LIFE_EVENTBUY_SUB11, SHOP_LIFE_USERSHOP11; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;「会いに行く」はFLAG:拠点フェイズ選択コマンドが選択不可のとき
;　指定されるデフォルトのメニュー番号（DEFAULT_MENU_NUM）になっている
;「会いに行く」のみ使用しない関数もコメントアウトで配置した
;　どんな関数が既に存在しているかわからなくなった時の確認用やテンプレート代わりに
;-------------------------------------------------
;「会いに行く」の名称
;　名称の有無はメニューの存在判定にも使用される
;-------------------------------------------------
@SHOP_LIFE_NAME11
IF CFLAG:MASTER:行動不能状態 == 行動不能_育児
	RESULTS:0 '= "子育てする"
ELSE
	RESULTS:0 '= "会いに行く"
ENDIF

;-------------------------------------------------
;「会いに行く」の選択可否
;　メニューの選択可否判定は@CHECK_CHECKCHARA_SAVEで行われ
;　SHOP_AVAIL:(メニュー番号)に 0:選択不可 1:選択可 で保存される
;　選択可能キャラ存在判定で 1:選択可 のキャラが存在し
;　この判定でも 1:選択可 なら SHOP_AVAIL:(メニュー番号)=1:選択可
;
;　RETURN 0:選択不可（キャラ存在判定に上書きして表示を阻止する）
;　RETURN 1:選択可
;-------------------------------------------------
@SHOP_LIFE_CHECK11
SIF CFLAG:MASTER:捕虜先
	RETURN 0
SIF CFLAG:MASTER:行動不能状態 == 行動不能_臨月 || COOLTIME:MASTER:0 > 1
	RETURN 0
RETURN 1

;-------------------------------------------------
;「会いに行く」の選択可能キャラ存在判定リスト１（上）
;　RETURN 0:このキャラは選択不可でリストに載らない
;　RETURN 1:このキャラは選択可
;　RETURN 2:このキャラは灰色でリストに載るが選択不可
;-------------------------------------------------
@SHOP_LIFE_CHECKCHARA11(ARG:0)
;※使用前に TMP_CREATE_RELATION_MAP 関数を呼び出す必要あり
;　現在 TMP_CREATE_RELATION_MAP は SHOP.ERB で呼び出されている
LOCAL:0 = TMP_COUNTRY_RELATION:(CFLAG:MASTER:所属):(CFLAG:(ARG:0):所属)
;捕虜として捕まえている場合
IF CFLAG:(ARG:0):捕虜先
	;非主人公、主人公勢力の捕虜かつ軟禁中
	RETURN CHECK91(ARG:0, 2, ARG:0 != MASTER && CFLAG:(ARG:0):捕虜先 == CFLAG:MASTER:所属 && CFLAG:(ARG:0):軟禁中 == 1 && !IS_ANIMAL(ARG:0) && SHOP_LIFE_11_GET_FILTER(ARG:0))
ENDIF

;放浪時
IF !CFLAG:MASTER:所属
	;捕虜でない、非主人公、放浪中
	RETURN CHECK91(ARG:0, 2, ARG:0 != MASTER && CFLAG:(ARG:0):特殊状態 == 特殊状態_放浪 && !IS_ANIMAL(ARG:0) && SHOP_LIFE_11_GET_FILTER(ARG:0))
ELSE
	;捕虜でない、非主人公、同一勢力or共闘勢力or放浪中で候補リストにいる
	RETURN CHECK91(ARG:0, 2, ARG:0 != MASTER && (LOCAL:0 >= 2 || FINDELEMENT(MEET_CANDIDATES, GET_ID(ARG:0)) != -1) && !IS_ANIMAL(ARG:0) && SHOP_LIFE_11_GET_FILTER(ARG:0))
ENDIF
;-------------------------------------------------
;「会いに行く」の選択可能キャラ存在判定リスト２（下・補佐）
;　リスト２（下）が存在する場合、こちらで判定を行う
;　ただし下段は助手の指定などに使われることが多く
;　助手はいなくても行動できることが多いため
;　この判定で選択不可が返ってもメニュー表示をオフにしない
;-------------------------------------------------
;@SHOP_LIFE_CHECKCHARA_SUB11(ARG:0)

;-------------------------------------------------
;「会いに行く」の左カラムメニューの入力処理
;　RETURN 0:CLEARLINE LINECOUNT - LINES_SHOPする
;　RETURN 1:CLEARLINE LINECOUNT - LINES_SHOPしない
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY11
FLAG:拠点フェイズページ = 1
FLAG:夜這い = 0
RETURN 0

;-------------------------------------------------
;「会いに行く」の右カラムオフ判定
;　通常は右カラムに何らかの表示があるが
;　右カラムに何も表示しないメニューならこの関数をセットしておく
;　するとメイン画面に戻ったとき最新の右カラム（ひとつ前に選択したメニュー等）を表示する
;-------------------------------------------------
;@SHOP_LIFE_EVENTBUY_COLUMN_RIGHT_OFF_CHECK11

;-------------------------------------------------
;「会いに行く」の右カラムボタン入力値をキャラ番号に変換する処理のオフ判定
;　入力値をそのまま指定したいときに使用
;　これを使用すると入力値がキャラ番号の範囲外でも退避処理を通らない
;　そのため入力値からキャラ番号をとる場合は退避処理を自作することになる
;-------------------------------------------------
;@SHOP_LIFE_USERSHOP_COLUMN_RIGHT_CONVERT_CHARANUM_OFF_CHECK11

;-------------------------------------------------
;「会いに行く」の右カラムキャラリスト１（上）のボタン
;　キャラリストのデフォルトのボタンは選択中色がない（トグル式でない）
;　トグル式のボタンを使いたいときや、ボタンをいくつも羅列したいとき等
;　キャラリストにデフォルトのボタン以外を使用したいメニューならこれを用意する
;
;　ボタン番号に追加する数値はSHOP_LIFE_LIST1_ADD_INPUT=100
;　ARG:1はリスト関数からCHECKCHARAの判定結果が渡されているのでそのまま返せばＯＫ
;-------------------------------------------------
;@SHOP_LIFE_LIST1_BUTTON11(ARG:0, ARG:1)
;CALL COLUMN_RIGHT_CHARALIST_BUTTON(キャラ（ARG:0）, 選択中カラー表示フラグ, ボタン番号に追加する数値（SHOP_LIFE_LIST1_ADD_INPUT）, CHECKCHARAの戻り値（ARG:1）, 行動済みマークをオフにするフラグ)
;RETURN 0

;-------------------------------------------------
;「会いに行く」の右カラムキャラリスト２（下）のボタン
;　上に同じ。下段のリストに使用される
;　ボタン番号に追加する数値はSHOP_LIFE_LIST2_ADD_INPUT=1100
;-------------------------------------------------
;@SHOP_LIFE_LIST2_BUTTON11(ARG:0, ARG:1)
;CALL COLUMN_RIGHT_CHARALIST_BUTTON(キャラ（ARG:0）, 選択中カラー表示フラグ, ボタン番号に追加する数値（SHOP_LIFE_LIST2_ADD_INPUT）, CHECKCHARAの戻り値（ARG:1）, 行動済みマークをオフにするフラグ)
;RETURN 0

;-------------------------------------------------
;「会いに行く」の右カラムキャラリスト１（上）のボタンに追尾させる情報
;　「投獄する」や「娯楽担当」等のように
;　デフォルトのボタンでは表示されない能力値を添えたい場合や
;　自動的に表示される情報が不要なときこれを用意する
;
;　RETURN 0　ボタンにデフォルトの情報を付与する
;　RETURN 1　ボタンにデフォルトの情報を付与しない
;-------------------------------------------------
;@SHOP_LIFE_BUTTON_ADD_TOP11(ARG:0)
;ここにボタンの後ろに表示したい情報
;RETURN 1

;-------------------------------------------------
;「会いに行く」の右カラムキャラリスト２（下）ボタンに追尾させる情報
;-------------------------------------------------
;@SHOP_LIFE_BUTTON_ADD_BOTTOM11(ARG:0)
;ここにボタンの後ろに表示したい情報
;RETURN 1

;-------------------------------------------------
;「会いに行く」の右カラム表示処理
;　ここは右カラムに表示する情報のメイン部分
;　左カラムのボタン表示と右カラムのリスト表示を交互に指定する必要があったが
;　指定が大変なので、改行や区切り線の指定に以下の関数を使用する
;
;　CALL COLUMN_RIGHT_PRINTL　改行と行番号の指定と左カラムボタン表示
;　CALL COLUMN_RIGHT_LINE　　右カラム用の幅に設定されたラインを表示
;
;　ループ処理では改行されないほうが処理しやすいので線は改行していない
;　線を表示したら改行（CALL COLUMN_RIGHT_PRINTL）する必要あり
;
;　リスト呼び出し関数は以下
;　１．CALL COLUMN_RIGHT_CHARALIST 　　　　基本のキャラリスト（リスト１）
;　２．CALL COLUMN_RIGHT_CHARALIST_TOP 　　２段組キャラリスト上（リスト１）
;　　　CALL COLUMN_RIGHT_CHARALIST_BOTTOM　２段組キャラリスト下（リスト２）
;　２はセットで使う
;
;　それぞれARG:0（１行に並べるボタン数）と
;　ARG:1（１ボタン指定で何行とるか）を指定できる
;　ボタンの情報量や行数によっては表示が崩れるので確認は必要
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SHOW11
;タイトル表示
CALL COLUMN_RIGHT_TITLE("対象者選択", "0", "1", "1", "0")
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL
PRINTBUTTON @"[%SHOP_LIFE_11_GET_FILTER_MODE(), MAX_CHARANAME_LENGTH, LEFT%]", 1
PRINTPLAIN   
PRINTBUTTON @"[%"フィルタ設定", MAX_CHARANAME_LENGTH, LEFT%]", 2
CALL COLUMN_RIGHT_PRINTL
CALL COLUMN_RIGHT_LINE
CALL COLUMN_RIGHT_PRINTL
;標準的なキャラリストとページ移動
CALL COLUMN_RIGHT_CHARALIST
RETURN 0

;-------------------------------------------------
;「会いに行く」の右カラムボタンの入力処理補佐
;　入力値0～9を想定している
;　RETURN 0:CLEARLINE LINECOUNT - LINES_SHOPする
;　RETURN 1:CLEARLINE LINECOUNT - LINES_SHOPしない
;-------------------------------------------------
@SHOP_LIFE_EVENTBUY_SUB11(ARG:0)
;表示フィルタ切り替え
IF ARG:0 == 1
	SHOP_LIFE_11_FILTER_MODE = ROUND_INCREMENT(SHOP_LIFE_11_FILTER_MODE, 0, VARSIZE("SHOP_LIFE_11_FILTER", 0) - 1)
	RETURN 0
;表示フィルタ設定
ELSEIF ARG:0 == 2
	CALL SHOP_LIFE_11_SET_FILTER
ENDIF

;-------------------------------------------------
;「会いに行く」のリスト１（上）入力処理
;　ARG:0=NO_TO_CHARA(入力値-SHOP_LIFE_LIST1_ADD_INPUT)されている
;-------------------------------------------------
@SHOP_LIFE_USERSHOP11(ARG:0)

;SHOW_INFOの初期画面を基本情報にする
FLAG:能力表示モード = 0

$SHOW_LOOP_INFO_A

;対象キャラの情報を表示
CALL SINGLE_DRAWLINE
```
