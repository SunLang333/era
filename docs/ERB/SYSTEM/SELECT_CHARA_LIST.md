# SYSTEM/SELECT_CHARA_LIST.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SELECT_CHARA_LIST.ERB`

类型: .ERB

自动摘要: functions: SELECT_CHARA_LIST, SELECT_CHARA_LIST_MULTI, SELECT_CHARA_LIST_SHOW_LOGIC_DEFAULT, SELECT_CHARA_LIST_SHOW_LOGIC_NONE, SELECT_CHARA_LIST_SELECT_LOGIC_DEFAULT, SELECT_CHARA_LIST_SELECT_LOGIC_NONE, SELECT_CHARA_LIST_COLOR_LOGIC_DEFAULT, SELECT_CHARA_LIST_SLG, SELECT_CHARA_LIST_ONLY_LOGIC_SLG, SELECT_CHARA_LIST_SEX, SELECT_CHARA_LIST_ONLY_LOGIC_SEX, SELECT_CHARA_LIST_MULTI_SLG, SELECT_CHARA_LIST_MULTI_ONLY_LOGIC_SLG, SELECT_CHARA_LIST_MULTI_SEX, SELECT_CHARA_LIST_MULTI_ONLY_LOGIC_SEX; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :キャラリストを表示する関数
;param :表示関数名:キャラクタをリストに表示するかを判定する関数の名前 SELECT_CHARA_LIST_SHOW_LOGIC_●●(ARG:0)の●●の部分
;param :選択関数名:キャラクタをリストで選択できるようにするかを判定する関数の名前 SELECT_CHARA_LIST_SHOW_LOGIC_●●(ARG:0)の●●の部分
;param :色指定関数名:キャラクタが選択できる場合、リストでどんな色でできるようにするかを判定する関数の名前 SELECT_CHARA_LIST_COLOR_LOGIC_●●(ARG:0)の●●の部分
;param :表示文字:各カラムの要素 ABLの名前
;-------------------------------------------------
@SELECT_CHARA_LIST(表示関数名 = "", 選択関数名="", 色指定関数名="", 表示文字:0 = "", 表示文字:1 = "", 表示文字:2 = "", 表示文字:3 = "", 表示文字:4 = "", 表示文字:5 = "", 表示文字:6 = "")
#DIMS 表示関数名
#DIMS 選択関数名
#DIMS 色指定関数名
#DIMS 表示文字, 7
#DIM 表示数値, 7
#DIM FIRST_LINE
#DIM 対象
#DIM 表示位置
#DIM 表示ページ
#DIM 総ページ数
#DIM キャラ数
#DIM キャラカウンタ
#DIM 表示開始位置
#DIM 表示終了位置
#DIM ランク種別
#DIM 直前総ページ数
#DIMS 直前表示関数名
#DIMS 直前選択関数名

VARSET キャラ数
VARSET 表示数値, -1

;ガード節
TRYCCALLFORM SELECT_CHARA_LIST_SHOW_LOGIC_%表示関数名%(MASTER)
CATCH
	THROW 指定された関数SELECT_CHARA_LIST_SHOW_LOGIC_%表示関数名%が存在しません
ENDCATCH

TRYCCALLFORM SELECT_CHARA_LIST_SELECT_LOGIC_%選択関数名%(MASTER)
CATCH
	THROW 指定された関数SELECT_CHARA_LIST_SELECT_LOGIC_%選択関数名%が存在しません
ENDCATCH

TRYCCALLFORM SELECT_CHARA_LIST_COLOR_LOGIC_%色指定関数名%(MASTER)
CATCH
	THROW 指定された関数SELECT_CHARA_LIST_COLOR_LOGIC_%色指定関数名%が存在しません
ENDCATCH


;一行目を用意
FOR LOCAL, 0, VARSIZE("表示文字")
	FOR LOCAL:1, 0, VARSIZE("ABL")
		SIF ABLNAME:(LOCAL:1) == ""
			CONTINUE
		IF 表示文字:LOCAL == ABLNAME:(LOCAL:1)
			表示文字:LOCAL = %TOSTR_SPACE(2)%%SUBSTRINGU(ABLNAME:(LOCAL:1), 0, 1)%\@ LOCAL == VARSIZE("表示文字") - 1 ?   # | \@
			表示数値:LOCAL = LOCAL:1
			BREAK
		ENDIF
	NEXT
	SIF LOCAL:1 == VARSIZE("ABL")
		表示文字:LOCAL = %TOSTR_SPACE(5)%
NEXT

;ページ数計算
FOR LOCAL, 0, CHARANUM
	CALLFORM SELECT_CHARA_LIST_SHOW_LOGIC_%表示関数名%(LOCAL)
	SIF RESULT
		キャラ数 ++
NEXT

総ページ数 = (キャラ数 - 1) / 40 + 1

;直前の呼び出しとページ数、表示する関数、選択する関数名が同一であれば連続した呼び出しと判断しページを切り替えない
SIF 総ページ数 != 直前総ページ数 || 表示関数名 != 直前表示関数名 || 選択関数名 != 直前選択関数名
	表示ページ = 1

直前総ページ数  = 総ページ数
直前表示関数名 '= 表示関数名
直前選択関数名 '= 選択関数名

;ヘッダ表示
PRINTFORM %TOSTR_SPACE(15)%
FOR LOCAL:1, 0, VARSIZE("表示文字")
	PRINTFORM %表示文字:(LOCAL:1)%
NEXT
PRINTFORM %TOSTR_SPACE(20)%
FOR LOCAL:1, 0, VARSIZE("表示文字")
	PRINTFORM %表示文字:(LOCAL:1)%
NEXT

PRINTL
FIRST_LINE = LINECOUNT

CALL CREATE_SELECTOR_SORT_LIST(0)

;本体部分の表示
$SHOW_LOOP

VARSET 表示位置
VARSET キャラカウンタ

表示開始位置 = (表示ページ - 1) * 40
表示終了位置 = 表示ページ * 40


FOR LOCAL:0, 0, CHARANUM
	LOCAL:1 = SHOP_CHARA_LIST:LOCAL
	SIF LOCAL:1 == -1
		CONTINUE
	;表示ロジックにあてはまらないなら飛ばす
	CALLFORM SELECT_CHARA_LIST_SHOW_LOGIC_%表示関数名%(LOCAL:1)
	SIF !RESULT
		CONTINUE
	IF 表示開始位置 <= キャラカウンタ && キャラカウンタ < 表示終了位置
		IF 表示位置 % 2 != 0
			PRINT   
		ELSEIF 表示位置 > 0
			PRINTL 
		ENDIF
		;選択ロジックに当てはまるキャラだけ通常表示
		;あてはまらなければ灰色表示
		CALLFORM SELECT_CHARA_LIST_SELECT_LOGIC_%選択関数名%(LOCAL:1)
		IF RESULT
			CALLFORM SELECT_CHARA_LIST_COLOR_LOGIC_%色指定関数名%(LOCAL:1)
			CALL COLOR_PRINT(@"[{LOCAL:1 + 99, 4}]%SNAME(LOCAL:1), MAX_CHARANAME_LENGTH/2, RIGHT%", RESULT)
			PRINTFORM %TOSTR_SPACE(1)%
			FOR LOCAL:2, 0, VARSIZE("表示数値")
				IF 表示数値:(LOCAL:2) != -1
					SELECTCASE 表示数値:(LOCAL:2)
						CASE GETNUM(ABL, "武闘"), GETNUM(ABL, "防衛"), GETNUM(ABL, "知略"), GETNUM(ABL, "政治"), GETNUM(ABL, "妖術"), GETNUM(ABL, "料理"), GETNUM(ABL, "歌唱")
							ランク種別 = ランク_ＳＬＧ
						CASE GETNUM(ABL, "性知識")
							ランク種別 = ランク_性知識
						CASEELSE
							ランク種別 = ランク_その他
					ENDSELECT
					CALL PRINT_ALPHABET_RANK(ランク種別, ABL:(LOCAL:1):(表示数値:(LOCAL:2)))
					PRINTFORM {ABL:(LOCAL:1):(表示数値:(LOCAL:2)), 3}
					SIF LOCAL:2 != VARSIZE("表示数値") -1
						PRINT |
				ELSE
					PRINTFORM %TOSTR_SPACE(5)%
				ENDIF
			NEXT
			PRINTBUTTON " 情", LOCAL:1 + 10099
		ELSE
			LOCALS:0 = [{NO:(LOCAL:1) + 99, 4}]%SNAME(LOCAL:1), MAX_CHARANAME_LENGTH/2, RIGHT%%TOSTR_SPACE(1)%
			FOR LOCAL:2, 0, VARSIZE("表示数値")
				IF 表示数値:(LOCAL:2) != -1
					SELECTCASE 表示数値:(LOCAL:2)
						CASE GETNUM(ABL, "武闘"), GETNUM(ABL, "防衛"), GETNUM(ABL, "知略"), GETNUM(ABL, "政治"), GETNUM(ABL, "妖術"), GETNUM(ABL, "料理"), GETNUM(ABL, "歌唱")
							ランク種別 = ランク_ＳＬＧ
						CASE GETNUM(ABL, "性知識")
							ランク種別 = ランク_性知識
						CASEELSE
							ランク種別 = ランク_その他
					ENDSELECT
					LOCALS:0 = %LOCALS:0%%ALPHABET_RANK(ランク種別, ABL:(LOCAL:1):(表示数値:(LOCAL:2)))%{ABL:(LOCAL:1):(表示数値:(LOCAL:2)), 3}
					SIF LOCAL:2 != VARSIZE("表示数値") -1
						LOCALS:0 = %LOCALS:0%|
				ELSE
					LOCALS:0 = %LOCALS:0%%TOSTR_SPACE(5)%
				ENDIF
			NEXT
			SETCOLOR カラー_選択不可
			PRINTPLAINFORM %LOCALS:0%
			PRINTPLAINFORM    
			RESETCOLOR
		ENDIF
		表示位置 ++
	ENDIF
	キャラカウンタ ++
NEXT

PRINTL 
CALL COLOR_LINE

;フッタ部分
IF 総ページ数 >= 2
	PRINT [  1] 最初のページ    
	PRINT [  2] 前のページ        
	PRINTPLAINFORM ページ{表示ページ}/{総ページ数}        
	PRINT [  8] 後のページ    
	PRINT [  9] 最後のページ
	PRINTL 
	CALL COLOR_LINE
ENDIF
PRINTBUTTON "<<", 20000
PRINT  
PRINTBUTTON @"[%STR_NOW_SORTKEY:ソートキー, 4, LEFT%]", 20001
PRINT  
PRINTBUTTON ">>", 20002
PRINT  
PRINTBUTTON @"[\@ 降順ソート ? 降順 # 昇順\@]", 20003
PRINTL
CALL SINGLE_DRAWLINE
PRINTL [  0] やっぱりやめる

REDRAW 0


```
