# SLG/SLG_AI.ERB — 自动生成文档

源文件: `ERB/SLG/SLG_AI.ERB`

类型: .ERB

自动摘要: functions: AI_ACTION, SLG_AI_DECIDE_SOLDIER_NUM, SLG_AI_FORCE_CLEAR_UNIT, SLG_AI_RESCUE, AI_DEPLOY_ARMY, SLG_AI_CREATE_UNIT, SLG_AI_FILL_UNIT, SLG_AI_INVASION_SETTARGET, SLG_AI_DEFENSE, SLG_AI_DEVELOPMENT_SLOT, SLG_AI_TECHNOLOGY; UI/print

前 200 行源码片段:

```text
﻿;注意点
;この関数自体ループ内で呼ばれる前提なので、ループを使用するとO(n^2)になる。TMP化できるものはTMPを利用すること。
@AI_ACTION(勢力)
#DIM 勢力
#DIM 攻撃兵数
#DIM 都市
#DIM 部隊
#DIM 部隊作成失敗
#DIM キャラ
#DIM USETIME

SETCOLOR COUNTRY_COLOR:勢力
PRINTFORML %ANAME(GET_COUNTRY_BOSS(勢力))%思考中……
RESETCOLOR

;ユニット関連
CALL TMP_CREATE_UNIT_MAP

;ランダムキャラを使用している場合
IF FLAG:ランダムキャラ使用
	;士官数が足りなければ士官を募集
	CALL RECRUIT_AI(勢力)
ENDIF

;外交の処理
SIF DAY >= SLG_PP:0 && !IS_SP_COUNTRY(勢力)
	CALL SLG_AI_DIPLOMACY(勢力)

;建造物の建築
CALL SLG_AI_DEVELOPMENT_SLOT(勢力)

;都市をもたない（野盗など）ならスキップする
SIF TMP_OWN_CITY:勢力 < 1
	GOTO NORMAL_AI_THINK_ENDED

;こっから先軍事なので軍事開始してなければスキップ
SIF DAY < SLG_PP:1
	GOTO NORMAL_AI_THINK_ENDED

CALL AI_DEPLOY_ARMY(勢力)

;防衛を全て解除
FOR 都市, 1, GET_CITY_NUM() + 1
	IF CITY_OWNER:都市 == 勢力
		;敵部隊のいる都市は解除不可
		IF !TMP_IS_STAY_ENEMY_UNIT(都市, 勢力)
			COUNTRY_SOLDIER:勢力 += CITY_SOLDIER:都市
			CITY_SOLDIER:都市 = 0
			SIF GET_CITY_COMMANDER(都市, 0) != -1
				TMP_IS_FREE:GET_CITY_COMMANDER(都市, 0):0 = 0
			SIF GET_CITY_COMMANDER(都市, 1) != -1
				TMP_IS_FREE:GET_CITY_COMMANDER(都市, 1):0 = 0
			CITY_COMMANDER:都市 = 0
		ENDIF
	ENDIF
NEXT

;方針の設定
CALL SLG_AI_SETDOCTRINE(勢力)

;既存部隊のうち、おかしな状況に陥っちゃってるものを解体する
CALL SLG_AI_FORCE_CLEAR_UNIT(勢力)

;このターン攻撃にさく兵力と防御にさく兵力を決定する
CALL SLG_AI_DECIDE_SOLDIER_NUM(勢力)
攻撃兵数 = RESULT:0

;救出
CALL SLG_AI_RESCUE(勢力, 攻撃兵数)
攻撃兵数 = RESULT

部隊作成失敗 = 0
;部隊の侵攻判定
FOR 部隊, 0, MAX_UNIT
	;既存部隊の場合、移動できない連中は飛ばす
	IF UNIT_SOLDIER:勢力:部隊 > 0
		;敵がいるなら飛ばす
		SIF TMP_IS_STAY_ENEMY_UNIT(UNIT_POSITION:勢力:部隊, 勢力)
			CONTINUE
		;すでに目的地があるなら飛ばす
		SIF UNIT_TARGET:勢力:部隊
			CONTINUE
		;敵の土地にいるなら飛ばす
		SIF TMP_COUNTRY_RELATION:勢力:(CITY_OWNER:(UNIT_POSITION:勢力:部隊)) == 0
			CONTINUE
		CALL GET_UNIT_COMMANDER_ALL(勢力, 部隊)
		;最低兵数割ってるなら解体
		;余剰兵力を攻撃に振り分ける
		IF UNIT_SOLDIER:勢力:部隊 < AI_ARMY_PROPERTY:(COUNTRY_AI_TYPE:勢力):AI_最低兵数 / MAX(MATCH(RESULT, -1, 0, 3) * 3, 1)
			;DEBUGPRINTFORML 兵数割り　解体
			攻撃兵数 += UNIT_SOLDIER:勢力:部隊
			CALL CLEAR_UNIT(勢力, 部隊, 1)
			CONTINUE
		;許容疲労度を超えていたら解体
		;余剰兵力は攻撃に振り分ける
		ELSEIF UNIT_TIRED_COUNT:勢力:部隊 > AI_ARMY_PROPERTY:(COUNTRY_AI_TYPE:勢力):AI_許容疲労度
			;DEBUGPRINTFORML  %ANAME(GET_COUNTRY_BOSS(勢力))%の{部隊}部隊　疲労度限界越えにつき解体 疲労度:{UNIT_TIRED_COUNT:勢力:部隊} 許容:{AI_ARMY_PROPERTY:(COUNTRY_AI_TYPE:勢力):AI_許容疲労度}
			攻撃兵数 += UNIT_SOLDIER:勢力:部隊
			CALL CLEAR_UNIT(勢力, 部隊, 1)
			CONTINUE
		ENDIF

		CALL SLG_AI_FILL_UNIT(勢力, 部隊)
	ELSEIF UNIT_SOLDIER:勢力:部隊 <= 0 && 部隊作成失敗 == 0
		;既存部隊でなければ、部隊の作成を試みる
		CALL SLG_AI_CREATE_UNIT(勢力, 部隊, 攻撃兵数)
		;作れなかったら飛ばす
		IF 攻撃兵数 == RESULT
			部隊作成失敗 = 1
			CONTINUE
		ENDIF
		攻撃兵数 = RESULT
	ENDIF
	;最終的に部隊ができてたら攻撃先の決定
	SIF UNIT_SOLDIER:勢力:部隊 > 0
		CALL SLG_AI_INVASION_SETTARGET(勢力, 部隊)
NEXT

;;#;FOR 部隊, 0, MAX_UNIT
;;#;	SIF UNIT_SOLDIER:勢力:部隊 > 0
;;#;			DEBUGPRINTFORML %ANAME(GET_COUNTRY_BOSS(勢力))%の{部隊}部隊 兵数{UNIT_SOLDIER:勢力:部隊} 現在地%GET_CITYNAME(UNIT_POSITION:勢力:部隊)% 目的地%GET_CITYNAME(UNIT_TARGET:勢力:部隊)%
;;#;NEXT


CALL SLG_AI_DEFENSE(勢力)
;通常のAI思考終了
$NORMAL_AI_THINK_ENDED


;クールタイム減少処理と、このターンに割り当てたフラグ削除処理
IF 勢力 != CFLAG:MASTER:所属
	FOR キャラ, 0, CHARANUM
		IF CFLAG:キャラ:所属 == 勢力
			COOLTIME:キャラ:0 = MAX(COOLTIME:キャラ:0 - 1 , 0)
			ASSIGNED_THIS_TURN:キャラ:0 = 0
		ENDIF
	NEXT
ENDIF

CALL SINGLE_EMPTY_LINE()

;-----------------------------------------------
;残存兵数における、攻撃兵にまわす兵数・防御にまわす兵数を決定する処理
;-----------------------------------------------
@SLG_AI_DECIDE_SOLDIER_NUM(勢力)
#DIM 勢力
#DIM 都市
#DIM 攻撃スコア倍率
#DIM 攻撃都市数
#DIM 防衛都市数
#DIM 攻撃スコア合計
#DIM 防衛スコア合計
#DIM 比率
#DIM 攻撃兵数
#DIM 防衛兵数
VARSET 攻撃スコア合計
VARSET 防衛スコア合計
VARSET 攻撃都市数
VARSET 防衛都市数
攻撃スコア倍率 = 100
攻撃スコア倍率 += MIN(10 * (TMP_OWN_CITY:勢力 / 5), 1)
攻撃スコア倍率 += MAX((20 - DAY) * 10, 0)

FOR 都市, 1, GET_CITY_NUM() + 1
	;そこが敵の都市で、かつ自勢力と接続しているなら、攻撃スコアに加算
	IF TMP_IS_INVADABLE:勢力:都市
		攻撃スコア合計 += TMP_OFFENSIVE_IMPORTANCE:勢力:都市 * 攻撃スコア倍率 / 100
		攻撃都市数 ++
	ENDIF
	;そこが自勢力の都市で、敵から殴られうるなら、防衛スコアに加算
	IF CITY_OWNER:都市 == 勢力 && TMP_CITY_RISK:勢力:都市 >= 2
		防衛スコア合計 += TMP_DEFFENSIVE_IMPORTANCE:勢力:都市
		防衛都市数 ++
	ENDIF
NEXT

;AIタイプに
攻撃スコア合計 = 攻撃スコア合計 * AI_ARMY_PROPERTY:(COUNTRY_AI_TYPE:勢力):AI_攻防バランス / 100

攻撃スコア合計 /= MAX(攻撃都市数, 1)
防衛スコア合計 /= MAX(防衛都市数, 1)

;攻撃スコアが0なら攻めるべき場所がないので、すべて防衛に回しておく
;唯一隣接している勢力と停戦した場合、これがないとエラー落ちする
IF 攻撃スコア合計 == 0
	RETURN 0, COUNTRY_SOLDIER:勢力
ENDIF

;DEBUGPRINTFORML %ANAME(GET_COUNTRY_BOSS(勢力))%の攻撃スコア{攻撃スコア合計} 防衛スコア{防衛スコア合計}
比率 = 攻撃スコア合計 * 1000 / (攻撃スコア合計 + 防衛スコア合計)

攻撃兵数 = MIN(COUNTRY_SOLDIER:勢力 * 比率 / 1000, COUNTRY_SOLDIER:勢力)
防衛兵数 = COUNTRY_SOLDIER:勢力 - 攻撃兵数
;DEBUGPRINTFORML %ANAME(GET_COUNTRY_BOSS(勢力))%の比率{比率}, 攻撃都市{攻撃都市数, 2} 防衛都市{防衛都市数}
;DEBUGPRINTFORML %ANAME(GET_COUNTRY_BOSS(勢力))%の攻撃兵{攻撃兵数, 5} 防衛兵{防衛兵数, 5} 兵数{COUNTRY_SOLDIER:勢力, 7}
RETURN 攻撃兵数, 防衛兵数

;-----------------------------------------------
;変なことになってる部隊を解体する
;-----------------------------------------------
```
