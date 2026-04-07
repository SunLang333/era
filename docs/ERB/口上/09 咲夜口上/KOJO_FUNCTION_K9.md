# 口上/09 咲夜口上/KOJO_FUNCTION_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/KOJO_FUNCTION_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_ASK_RESET_K9, CALLNAME_K9, CHECK_K9, POLITE_K9, BREAK_K9, CALL_DIRTY_K9, CAKE_K9; UI/print

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●咲夜口上の使用可否・初期化
;─────────────────────────────────────── 
@KOJO_ASK_RESET_K9
#DIM SAVE_REDRAW
#DIM SAVE_COLOR
#DIM SAVE_LINE
#DIM 咲夜

CURRENTREDRAW
SAVE_REDRAW = RESULT
REDRAW 0
GETCOLOR
SAVE_COLOR = RESULT
RESETCOLOR

咲夜 = NAME_TO_CHARA("咲夜")

;咲夜口上用のデータを初期化
;0=未設定 1=使用しない 2=使用する
咲夜_口上デイリー入力系使用 = 0
;入力系デイリー親しい呼びかた用
咲夜_主人公への呼称 '= ""
咲夜_主人公への呼称フリガナ '= ""
;入力系デイリーえっちな呼びかた用
咲夜_淫語Ｐ '= "あれ"
咲夜_淫語Ｖ '= "なか"
咲夜_淫語Ｃ '= "そこ"
咲夜_淫語Ａ '= "そこ"
咲夜_淫語Ｂ '= "そこ"
;0=未設定 1=低頻度 2=高頻度
咲夜_淫語頻度 = 0
;プレイヤー側の初回実行判定（スキンヘッドチェック用）
咲夜_髪梳き初回 = 0
;おもいで語りデイリー用
咲夜_告白成功期 = 0
咲夜_告白成功場所 = 0
咲夜_告白成功したキャラ = 0

RESETCOLOR
PRINTL 

PRINTFORML 咲夜口上使用の設定
CALL KOJO_ASK("使用しない", "使用する")
PRINTFORMW 咲夜口上の使用を設定した

;使用しない
IF RESULT == 0
	CFLAG:咲夜:400 = 1
;使用する
ELSEIF RESULT == 1
	CFLAG:咲夜:400 = 2
	PRINTL 
	PRINTFORM 咲夜口上デイリー入力系使用の設定
	SETCOLOR カラー_選択不可
	PRINTFORML  - あなたへの優先呼称やあなた好みの淫語を入力するイベント
	RESETCOLOR
	CALL KOJO_ASK("使用しない", "使用する")
	PRINTFORMW 咲夜口上デイリー入力系使用を設定した
	;使用しない
	IF RESULT == 0
		咲夜_口上デイリー入力系使用 = 1
	;使用する
	ELSEIF RESULT == 1
		咲夜_口上デイリー入力系使用 = 2
	ENDIF
ENDIF

PRINTL 

REDRAW SAVE_REDRAW
SETCOLOR SAVE_COLOR
RETURN 0


;─────────────────────────────────────── 
;●咲夜の呼称（咲夜から咲夜_対象へ）
;　使い方：%CALLNAME_K9(咲夜_対象)%　%CALLNAME_K9(咲夜_対象, "ぁ")%
;　覚書　：第二引数に"ぁ"とつけると
;　フリガナ（CSTR:MASTER:6や咲夜_主人公への呼称フリガナや君主等への特殊呼称）がある場合
;　対応する小書き母音をつける（甘え感を出す）
;─────────────────────────────────────── 
@CALLNAME_K9(咲夜_対象, 小書き)
#FUNCTIONS
#DIM 咲夜
#DIM 咲夜_対象
#DIMS 小書き
#DIMS 表示テキスト
#DIMS 表示テキストフリガナ

;リセット
咲夜 = NAME_TO_CHARA("咲夜")
表示テキスト '= ""

;主人公で呼称指定済み
IF 咲夜_対象 == MASTER && KDVAR:咲夜:咲夜_親しい呼びかた && 咲夜_主人公への呼称 != ""
	表示テキスト '= 咲夜_主人公への呼称
	表示テキストフリガナ '= 咲夜_主人公への呼称フリガナ

;同一勢力君主の男対象
ELSEIF GET_COUNTRY_BOSS(CFLAG:咲夜:所属) == 咲夜_対象 && IS_MALE(咲夜_対象)
	表示テキスト '= "ご主人様"
	表示テキストフリガナ '= "ゴシュジンサマ"

;咲夜_対象が主人公＆咲夜が服従系陥落＆対象が男
ELSEIF 咲夜_対象 == MASTER && IS_SLAVE(咲夜) && IS_MALE(咲夜_対象)
	IF ANAME(咲夜_対象) == "あなた"
		表示テキスト '= "ご主人様"
		表示テキストフリガナ '= "ゴシュジンサマ"
	ELSE
		表示テキスト '= ANAME(咲夜_対象) + "様"
		IF CSTR:咲夜_対象:6 != ""
			表示テキストフリガナ '= CSTR:咲夜_対象:6 + "サマ"
		ELSE
			表示テキストフリガナ '= ""
		ENDIF
	ENDIF

;同一勢力君主の女対象
ELSEIF GET_COUNTRY_BOSS(CFLAG:咲夜:所属) == 咲夜_対象 && IS_FEMALE(咲夜_対象)
	IF ANAME(咲夜_対象) == "あなた"
		表示テキスト '= "お嬢様"
		表示テキストフリガナ '= "オジョウサマ"
	ELSE
		表示テキスト '= ANAME(咲夜_対象) + "様"
		IF CSTR:咲夜_対象:6 != ""
			表示テキストフリガナ '= CSTR:咲夜_対象:6 + "サマ"
		ELSE
			表示テキストフリガナ '= ""
		ENDIF
	ENDIF

;咲夜_対象が主人公＆咲夜が服従系陥落＆対象が女
ELSEIF 咲夜_対象 == MASTER && IS_SLAVE(咲夜) && IS_FEMALE(咲夜_対象)
	IF ANAME(咲夜_対象) == "あなた"
		表示テキスト '= "お嬢様"
		表示テキストフリガナ '= "オジョウサマ"
	ELSE
		表示テキスト '= ANAME(咲夜_対象) + "様"
		IF CSTR:咲夜_対象:6 != ""
			表示テキストフリガナ '= CSTR:咲夜_対象:6 + "サマ"
		ELSE
			表示テキストフリガナ '= ""
		ENDIF
	ENDIF

ELSEIF ANAME(咲夜_対象) == "レミリア"
	表示テキスト '= "お嬢様"
	表示テキストフリガナ '= "オジョウサマ"

ELSEIF ANAME(咲夜_対象) == "フラン" 
	表示テキスト '= "妹様"
	表示テキストフリガナ '= "イモウトサマ"

ELSEIF ANAME(咲夜_対象) == "パチュリー" 
	表示テキスト '= "パチュリー様"
	表示テキストフリガナ '= "パチュリーサマ"

;慰安中モブ相手
ELSEIF FLAG:調教モード == 調教_慰安 && CFLAG:(咲夜_対象):慰安モブ
	表示テキスト '= "皆様"
	表示テキストフリガナ '= "ミナサマ"

;慰安中でモブ以外のキャラには様をつけて呼ぶ
ELSEIF FLAG:調教モード == 調教_慰安 && CFLAG:(咲夜_対象):慰安参加者
	表示テキスト '= ANAME(咲夜_対象) + "様"
	IF CSTR:咲夜_対象:6 != ""
		表示テキストフリガナ '= CSTR:咲夜_対象:6 + "サマ"
	ELSE
		表示テキストフリガナ '= ""
	ENDIF

ELSEIF ANAME(咲夜_対象) == "霖之助" 
	表示テキスト '= "店主"
	表示テキストフリガナ '= "テンシュ"

;敬語の場合
ELSEIF CHECK_K9("敬語", 咲夜_対象)
	IF ANAME(咲夜_対象) == "あなた"
		IF IS_MALE(咲夜_対象)
			表示テキスト '= "貴方"
			表示テキストフリガナ '= "アナタ"
		ELSE
			表示テキスト '= "貴女"
			表示テキストフリガナ '= "アナタ"
		ENDIF
	ELSE
		表示テキスト '= ANAME(咲夜_対象) + "様"
		IF CSTR:咲夜_対象:6 != ""
			表示テキストフリガナ '= CSTR:咲夜_対象:6 + "サマ"
		ELSE
			表示テキストフリガナ '= ""
		ENDIF
	ENDIF

;それ以外
ELSE
	IF ANAME(咲夜_対象) == "あなた"
		IF IS_MALE(咲夜_対象)
			表示テキスト '= "貴方"
```
