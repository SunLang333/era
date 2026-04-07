# TRAIN/COMF/COM_AUTOSELECT/COM_AUTOSELECT_2_実行対象キャラ設定.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COM_AUTOSELECT/COM_AUTOSELECT_2_実行対象キャラ設定.ERB`

类型: .ERB

自动摘要: functions: COM_AUTOSELECT_DECIDE_PLAYER, COM_AUTOSELECT_DECIDE_TARGET, AUTO_SET_THIRD_PERSON, AUTO_SET_REMOVE_MAIN; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;# おまかせ時のプレイヤー選択
;-------------------------------------------------
@COM_AUTOSELECT_DECIDE_PLAYER
#DIM L_COUNTER
#DIM RETURN_CHARA_NUM
#DIM DECIDE_REFERENCE_VALUE					;重みの基準
#DIM MULTI_SITUATION_DECIDE_REFERENCE_VALUE	;状況による重みの乗算補正
#DIM CHECK_BEING_IAN_SERVE_FEMALE
#DIM CHECK_BEING_IAN_GUEST_FEMALE

DEBUGPRINTFORML 
DEBUGPRINTFORML #### DEBUG メインプレイヤー選択 

;-------------------------------------------------
;## リセット
;-------------------------------------------------
CALL COM_AUTO_RANDOMIZED_WEIGHTED_START

;-------------------------------------------------
;## 慰安時のキャラ性別チェック
;	FOR文軽量化のため先に確認して代入しておく
;-------------------------------------------------
IF FLAG:調教モード == 調教_慰安
	;慰安サービス側に女はいるか
	CHECK_BEING_IAN_SERVE_FEMALE = BEING_IAN_SERVE_FEMALE()
	;慰安客側に女はいるか
	CHECK_BEING_IAN_GUEST_FEMALE = BEING_IAN_GUEST_FEMALE()
ENDIF

;-------------------------------------------------
;## 候補設定
;-------------------------------------------------
FOR L_COUNTER, 0, CHARANUM
	;---------------------------------------------
	;### 不可候補
	;---------------------------------------------
	;参加者ではない
	SIF !CFLAG:L_COUNTER:調教参加フラグ
		CONTINUE
	;行動不可能
	SIF !IS_AUTOSELECT(L_COUNTER)
		CONTINUE
	;慰安モード、このキャラが男慰安客、サービス側に行動可能な女性がいない、客に行動可能な女性がいる
	SIF FLAG:調教モード == 調教_慰安 && IS_IAN_GUEST_MALE(L_COUNTER) && !CHECK_BEING_IAN_SERVE_FEMALE && CHECK_BEING_IAN_GUEST_FEMALE
		CONTINUE
	;---------------------------------------------
	;### 重みの基準
	;	主導度Ｕプラス量を元に10～100 +1は0除算回避用
	;---------------------------------------------
	DECIDE_REFERENCE_VALUE = MAX((1000 + ABL:L_COUNTER:主導度Ｕ + 1) / 20, 10)

	SIF FLAG:調教モード == 調教_逆調教特殊 && IS_FALLEN_TO_SP_COUNTRY(L_COUNTER)
		DECIDE_REFERENCE_VALUE += 30

	;---------------------------------------------
	;### 状況の補正
	;---------------------------------------------
	;慰安でないときは主人公に挿入している・されているキャラを優先
	IF FLAG:調教モード != 調教_慰安 && IS_INSERT_MUTUAL(MASTER, L_COUNTER) >= 1
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 100
	;挿入中ではないキャラ
	ELSE
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 50
	ENDIF

	;---------------------------------------------
	;### 重みの計算
	;---------------------------------------------
	DECIDE_REFERENCE_VALUE = DECIDE_REFERENCE_VALUE * MULTI_SITUATION_DECIDE_REFERENCE_VALUE

	;---------------------------------------------
	;### 候補の追加
	;---------------------------------------------
	CALL COM_AUTO_RANDOMIZED_WEIGHTED_VALUE(L_COUNTER, DECIDE_REFERENCE_VALUE)
	DEBUGPRINTFORML      %ANAME(L_COUNTER), MAX_CHARANAME_LENGTH, LEFT%  %TOSTR_SEX(TALENT:L_COUNTER:性別), 6%  重み {DECIDE_REFERENCE_VALUE, 10}
NEXT

;-------------------------------------------------
;## 結果取得
;-------------------------------------------------
RETURN_CHARA_NUM = COM_AUTO_RANDOMIZED_WEIGHTED_RESULT()
IF RETURN_CHARA_NUM < 0
	PRINTFORML ※おまかせ実行者が見つかりませんでした
	PRINTFORML ※ログをスレにエラー報告して頂けると助かります
	PRINTFORML ※@COM_AUTOSELECT_DECIDE_PLAYER @COM_AUTO_RANDOMIZED_WEIGHTED_RESULT 
	RETURN -1
ENDIF

RETURN RETURN_CHARA_NUM

;-------------------------------------------------
;# おまかせ時のターゲット選択
;-------------------------------------------------
@COM_AUTOSELECT_DECIDE_TARGET(プレイヤー)
#DIM L_COUNTER
#DIM プレイヤー
#DIM RETURN_CHARA_NUM
#DIM DECIDE_REFERENCE_VALUE					;重みの基準
#DIM MULTI_SEX_DECIDE_REFERENCE_VALUE		;性別による重みの乗算補正
#DIM MULTI_VIRGIN_DECIDE_REFERENCE_VALUE	;処女性による重みの乗算補正
#DIM MULTI_SITUATION_DECIDE_REFERENCE_VALUE	;状況による重みの乗算補正

DEBUGPRINTFORML 
DEBUGPRINTFORML #### DEBUG メインターゲット選択 

;-------------------------------------------------
;## リセット
;-------------------------------------------------
CALL COM_AUTO_RANDOMIZED_WEIGHTED_START

;-------------------------------------------------
;## 候補設定
;-------------------------------------------------
FOR L_COUNTER, 0, CHARANUM
	;---------------------------------------------
	;### 不可候補
	;---------------------------------------------
	;参加者ではない　MASTERが調教参加フラグ設定されるのは慰安系のみのようなのでMASTERを除外
	SIF !CFLAG:L_COUNTER:調教参加フラグ && !( FLAG:調教モード != 調教_慰安 && L_COUNTER == MASTER )
		CONTINUE
	;実行者
	SIF L_COUNTER == プレイヤー
		CONTINUE

	;---------------------------------------------
	;### 重みの基準
	;	主導度Ｕマイナス量を元に10～100
	;---------------------------------------------
	DECIDE_REFERENCE_VALUE = MAX((2000 - (1000 + ABL:L_COUNTER:主導度Ｕ)) / 20, 10)

	;---------------------------------------------
	;### 性別組の補正
	;---------------------------------------------
	;対象があなたで実行が浮気癖所持
	IF L_COUNTER == MASTER && GETBIT(TALENT:プレイヤー:淫乱系, 素質_淫乱_浮気癖)
		MULTI_SEX_DECIDE_REFERENCE_VALUE = 15
	;対象があなたで実行が陥落済み ただし特殊勢力逆調教を除く
	ELSEIF L_COUNTER == MASTER && ( TALENT:プレイヤー:恋慕 || TALENT:プレイヤー:服従 || TALENT:プレイヤー:主人 ) && !GROUPMATCH(FLAG:調教モード, 調教_逆調教特殊)
		MULTI_SEX_DECIDE_REFERENCE_VALUE = 100
	;両刀or実行ふたなりor対象ふたなり
	ELSEIF TALENT:プレイヤー:両刀 || (HAS_PENIS(プレイヤー) && HAS_VAGINA(プレイヤー)) || (HAS_PENIS(L_COUNTER) && HAS_VAGINA(L_COUNTER))
		MULTI_SEX_DECIDE_REFERENCE_VALUE = 70
	;異性
	ELSEIF (HAS_PENIS(プレイヤー) && HAS_VAGINA(L_COUNTER)) || (HAS_VAGINA(プレイヤー) && HAS_PENIS(L_COUNTER))
		MULTI_SEX_DECIDE_REFERENCE_VALUE = 70
	;同性
	ELSE
		MULTI_SEX_DECIDE_REFERENCE_VALUE = 1
	ENDIF

	;---------------------------------------------
	;### 処女系の補正
	;---------------------------------------------
	;マスターが対象で処女系素質を持つとき ただし浮気癖がある場合は除外
	IF L_COUNTER == MASTER && (TALENT:MASTER:キス未経験 || (HAS_VAGINA(MASTER) && TALENT:MASTER:処女) || (HAS_PENIS(MASTER) && TALENT:MASTER:童貞)) && !GETBIT(TALENT:プレイヤー:淫乱系, 素質_淫乱_浮気癖)
		MULTI_VIRGIN_DECIDE_REFERENCE_VALUE = 100
	;対象が処女系素質を持つとき
	ELSEIF TALENT:L_COUNTER:キス未経験 || (HAS_VAGINA(L_COUNTER) && TALENT:L_COUNTER:処女) || (HAS_PENIS(L_COUNTER) && TALENT:L_COUNTER:童貞)
		MULTI_VIRGIN_DECIDE_REFERENCE_VALUE = 100
	;処女系は持たないとき
	ELSE
		MULTI_VIRGIN_DECIDE_REFERENCE_VALUE = 1
	ENDIF

	;---------------------------------------------
	;### 状況の補正
	;---------------------------------------------
	;特殊勢力逆調教時の男あなた
	IF L_COUNTER == MASTER && GROUPMATCH(FLAG:調教モード, 調教_逆調教特殊) && IS_MALE(L_COUNTER)
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 20
	;特殊勢力逆調教かつ特殊キャラでない女
	ELSEIF !IS_SP_CHARA(L_COUNTER) && GROUPMATCH(FLAG:調教モード, 調教_逆調教特殊) && IS_FEMALE(L_COUNTER)
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 70
	;逆調教の主人公
	ELSEIF L_COUNTER == MASTER && GROUPMATCH(FLAG:調教モード, 調教_逆調教特殊, 調教_逆調教通常) && !GETBIT(TALENT:プレイヤー:淫乱系, 素質_淫乱_浮気癖)
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 100
	;逆調教以外の主人公
	ELSEIF L_COUNTER == MASTER && !GETBIT(TALENT:プレイヤー:淫乱系, 素質_淫乱_浮気癖)
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 70
	;捕虜調教のターゲット
	ELSEIF FLAG:調教モード == 調教_捕虜調教 && FINDELEMENT(PRISONER_TARGET, L_COUNTER)
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 70
	;慰安モードで主導者が慰安客のとき慰安客は確率低下
	ELSEIF FLAG:調教モード == 調教_慰安 && (TALENT:プレイヤー:慰安モブ || CFLAG:プレイヤー:慰安参加者) && (TALENT:L_COUNTER:慰安モブ || CFLAG:L_COUNTER:慰安参加者)
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 1
	;慰安モードで主導者がサービス側のときサービス側は確率低下
	ELSEIF FLAG:調教モード == 調教_慰安 && !TALENT:プレイヤー:慰安モブ && !CFLAG:プレイヤー:慰安参加者 && !TALENT:L_COUNTER:慰安モブ && !CFLAG:L_COUNTER:慰安参加者
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 15
	;それ以外
	ELSE
		MULTI_SITUATION_DECIDE_REFERENCE_VALUE = 30
	ENDIF

	;---------------------------------------------
	;### 重みの計算
	;---------------------------------------------
	DECIDE_REFERENCE_VALUE = DECIDE_REFERENCE_VALUE * MULTI_SEX_DECIDE_REFERENCE_VALUE * MULTI_VIRGIN_DECIDE_REFERENCE_VALUE * MULTI_SITUATION_DECIDE_REFERENCE_VALUE

	;---------------------------------------------
```
