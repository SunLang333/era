# SLG/SCENARIO/SCENARIO21.ERB — 自动生成文档

源文件: `ERB/SLG/SCENARIO/SCENARIO21.ERB`

类型: .ERB

自动摘要: functions: SCENARIO_NAME_21, SCENARIO_INTRO_21, SCENARIO_MAPSELECT_21, SCENARIO_PLACEMENT_21, SCENARIO_EVENT_21, SCENARIO_21_RESET_SCVARS, SCENARIO_21_AFTERSELECT, SCENARIO_21_COLOR_LINE, SCENARIO_21_SELECT_RBOSS; assigns RESULTS; UI/print; references CSV; definition/data

前 200 行源码片段:

```text
﻿;============================================================================== 
;■シナリオ21
;　傾城乱遊の記憶
;　eraTohloveKHのシナリオ3を他人が移植
;============================================================================== 
;============================================================================== 
;◆初期設定
;============================================================================== 
@SCENARIO_NAME_21
RESULTS = 傾城乱遊の記憶
RETURN

@SCENARIO_INTRO_21
PRINTFORML
PRINTFORMW 幻想郷は分裂した！
PRINTFORMW 各々が様々な思惑を絡め、争いあう！
PRINTFORMW 争いの原因は……プレイヤー自身！？
PRINTFORMW 何か呪いのような物をかけられたらしい……
PRINTFORML
PRINTFORML ※ランダム系シナリオです
PRINTFORML ※ヤンデレが苦手な方はスルーしたほうが良いかもしれません
PRINTFORML ※ヤンデレが好きな方には嬉しいシナリオ、かどうかは定かではありません
PRINTFORMW
PRINTL

;ランダムキャラは選択に委ねる
FLAG:OPランダムキャラ使用 = 0

@SCENARIO_MAPSELECT_21
PRINTFORML
PRINTFORML どのマップでプレイしますか？
CALL ASK_MULTI("デフォルト", "日本", "ヨーロッパ")
SELECTCASE RESULT
	CASE 0
		MAPID '= "DEFAULT"
	CASE 1
		MAPID '= "JAPAN"
	CASE 2
		MAPID '= "EU"
ENDSELECT

@SCENARIO_PLACEMENT_21
;◇勢力設定

;●空勢力
COUNTRY_BOSS:0 = 0
COUNTRY_COLOR:0 = GETDEFCOLOR()
;全国空勢力
FOR LOCAL:0, 0, MAX_CITY
	;空勢力
	CITY_OWNER:(LOCAL:0) = 0
	;空勢力国への兵配備（500～5000）
	CITY_SOLDIER:(LOCAL:0) = RAND:4500 + 4000
NEXT

;全員無所属・放浪
FOR LOCAL:0, 1, CHARANUM
	IF CSTR:(LOCAL:0):99 != "あなた"
		;所属勢力
		CFLAG:(LOCAL:0):所属 = 0
		;特殊状態
		CFLAG:(LOCAL:0):特殊状態 = 特殊状態_放浪
	ENDIF
NEXT

;◇経済規模の設定
;CALL SHARED_SETTING_ECONOMY

;◇防衛倍率の設定
;CALL SHARED_SETTING_GUARD

;◇兵力の初期配置
CALL INIT_ARMY

;◇関係設定
CALL SHARED_SETTING_RELATION

; ホントはシナリオ開始後に建国してほしいけど、１つも勢力が無い状態で[ランダム]を選ぶとエラー落ちするっぽいので回避
CALL SCENARIO_21_SELECT_RBOSS(7, 12)


;============================================================================== 
;◆定例イベント
;　ターンエンド時に呼び出される
;============================================================================== 
@SCENARIO_EVENT_21
#DIM 対象士官番号
#DIM 闇堕ち君主番号

対象士官番号 = ID_TO_CHARA(SCVAR:3)
闇堕ち君主番号 = ID_TO_CHARA(SCVAR:4)

IF SCVAR:2 && (対象士官番号 < 0 || 闇堕ち君主番号 < 0)
	; エラー落ちしないことを最優先にする
	CALL SCENARIO_21_RESET_SCVARS
ENDIF

;IF DAY == 1
;	CALL SCENARIO_21_SELECT_RBOSS(7, 12)
;ENDIF

;───────────────────────────────────── 
;◇傾城(SCVAR:2 SCVAR:3 SCVAR:4 使用)
;●概要
;○使用しているシナリオ用変数
;　▼SCVAR:2……イベント進行度
;　▼SCVAR:3……対象士官ID
;　▼SCVAR:4……闇堕ち君主ID
;イベントの概要：
;○進行度０……毎ターン陥落持ちは確率で自分より主人公への好感度が高いキャラに友好度-敵対度+。
;　　　　　　　親愛だと敵対度の上がり方がより大きくなる。
;　　　　　　　自軍士官と他軍でそれぞれ、最も主人公への好意が高い者は友好度・敵対度を表示する。
;○進行度１……自軍君主が自軍士官に敵対度が高まると警告する。
;　　　　　　　▼「君主が大切」「仲間が大切」……で好感度+敵対度-。
;　　　　　　　▼「士官が大切」……進行度２のフラグオン。
;○進行度２……主人公勢力の君主に睨まれた同勢力士官が独立に誘ってくる。
;　　　　　　　▼「ついていく」……独立
;　　　　　　　▼「ひきとめる」……進行度３のフラグオン。
;○進行度３……主人公勢力の君主に睨まれた同勢力士官が地方派遣され放浪する
;　　　　　　　内部的には未登場扱いとなり地方派遣と同様に能力に応じて兵追加される。
;　　　　　　　▼「後を追う」……自軍君主に監禁されて捕虜になる。
;　　　　　　　▼「黙り込む」……現状維持になる。進行度４のフラグオン。
;○進行度４　　状況が大きく変化したら、それに応じて対象を生き返し、状況に応じた処理をする。
;　　　　　　　▼主人公の斬首……対象を生き返す（斬首口上を表示できるようにするだけ）
;　　　　　　　▼主人公の独立……対象を生き返して主人公勢力に士官させる。
;　　　　　　　▼主人公の士官先変更……対象を生き返して主人公勢力に士官させる。
;　　　　　　　▼主人公の無所属化・捕虜でない（滅亡）……対象を生き返して最大勢力から国を一つ貰って独立、主人公がそこへ士官。
;　　　　　　　▼上記にあてはまらない場合、２ターン経過後、対象が生きていると噂に聞く。この段階では内部的には死んだまま。
;　　　　　　　▼３ターン経過後、対象を生き返して選択肢を表示する。
;　　　　　　　▼「独立する」……対象を生き返して最大軍から国を一つ貰って独立、主人公がそこへ士官。
;　　　　　　　▼「他勢力へ誘う」……対象を生き返して他軍の支配国数を表示したリンクを出し、選択した先に対象と主人公が二人で仕官。
;　　　　　　　▼「ここに残る」……対象を生き返して対象を地方派遣した君主への敵対度が最も高い君主のいる軍へ士官。
;　　　　　　　主人公は無所属なら自分を監禁した君主に士官して捕虜状態を解除。無所属でなければ現状維持。
;───────────────────────────────────── 
;●イベント１～２のリセット
;───────────────────────────────────── 
;警告・逃避行独立まではリセット可
;３・４・５・６は後に引けない状況なのでリセットしない
IF DAY % 1 == 0 && SCVAR:2 >= 1 && SCVAR:2 < 3
	;○主人公が放浪、または捕虜、または妊娠などの行動不能
	IF CFLAG:MASTER:所属 == 0 || CFLAG:MASTER:捕虜先 || CFLAG:MASTER:行動不能状態
		CALL SCENARIO_21_RESET_SCVARS
	;主人公の君主が変わっている
	ELSEIF 闇堕ち君主番号 != GET_COUNTRY_BOSS(CFLAG:MASTER:所属)
		CALL SCENARIO_21_RESET_SCVARS
	ENDIF
	;○対象が特殊状況（放浪または死亡）または捕虜、または妊娠などの行動不能
	IF CFLAG:対象士官番号:特殊状態 || CFLAG:対象士官番号:捕虜先 || CFLAG:対象士官番号:行動不能状態
		CALL SCENARIO_21_RESET_SCVARS
	;対象の君主が変わっている
	ELSEIF 闇堕ち君主番号 != GET_COUNTRY_BOSS(CFLAG:対象士官番号:所属)
		CALL SCENARIO_21_RESET_SCVARS
	ENDIF
	;○闇堕ち君主特殊状況（放浪または死亡）または捕虜、または妊娠などの行動不能
	IF CFLAG:闇堕ち君主番号:特殊状態 || CFLAG:闇堕ち君主番号:捕虜先 || CFLAG:闇堕ち君主番号:行動不能状態
		CALL SCENARIO_21_RESET_SCVARS
	;闇堕ち君主が君主でなくなっている
	ELSEIF 闇堕ち君主番号 != GET_COUNTRY_BOSS(CFLAG:闇堕ち君主番号:所属)
		CALL SCENARIO_21_RESET_SCVARS
	ENDIF
	;○好感度逆転（闇堕ちしそうな君主の好感度＞対象の好感度）
	IF CFLAG:闇堕ち君主番号:好感度 > CFLAG:対象士官番号:好感度
		CALL SCENARIO_21_RESET_SCVARS
	ENDIF
ENDIF

;───────────────────────────────────── 
;●傾城進行度４監禁または日常からの救出
;───────────────────────────────────── 
;発生条件：
;イベント進行度が３以上
;特に何事もなければ地方派遣が起きてから２期続き、３期目に終了する
IF DAY % 1 == 0 && SCVAR:2 >= 3
	対象士官番号 = ID_TO_CHARA(SCVAR:3)
	闇堕ち君主番号 = ID_TO_CHARA(SCVAR:4)
	;---------------------------------------------------------------------- 
	;○途中・主人公が斬首された
	;---------------------------------------------------------------------- 
	IF FLAG:強制エンドフラグ
		;主人公処刑時の口上を出すために生き返す
		CALL CHANGE_COUNTRY(対象士官番号, 0, 1, 0)
	;---------------------------------------------------------------------- 
	;○途中・主人公が独立した
	;---------------------------------------------------------------------- 
	ELSEIF CFLAG:MASTER:所属 && GET_COUNTRY_BOSS(CFLAG:MASTER:所属) == MASTER
		;対象が未登場状態から通常状態になる
		;主人公の勢力に対象が士官
		CALL CHANGE_COUNTRY(対象士官番号, CFLAG:MASTER:所属, 1, 0)
		CALL SCENARIO_21_COLOR_LINE
		SETCOLOR カラー_オレンジ
		PRINTFORMW 放浪していた%ANAME(対象士官番号)%が我が陣に士官した！
		RESETCOLOR
		CALL SCENARIO_21_COLOR_LINE
		PRINTFORMW %ANAME(MASTER)%は小走りになって%ANAME(対象士官番号)%を出迎えた
		PRINTFORML 
		PRINTFORMW %ANAME(対象士官番号)%は%ANAME(闇堕ち君主番号)%の兵に追われて身を潜めていたらしい
		PRINTFORMW %ANAME(MASTER)%の独立を知って居ても立っても居られず、士官しに来たことを話した
		PRINTFORML 
		IF TALENT:対象士官番号:自制心 || TALENT:対象士官番号:一線越えない
			PRINTFORMW %ANAME(対象士官番号)%は黙って%ANAME(MASTER)%を抱き締めて落ち着くまで背中を撫で続けた…
```
