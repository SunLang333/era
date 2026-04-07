# TRAIN/COMF/COM_AUTOSELECT/COM_AUTOSELECT_3_カテゴリの優先度設定リスト.ERB — 自动生成文档

源文件: `ERB/TRAIN/COMF/COM_AUTOSELECT/COM_AUTOSELECT_3_カテゴリの優先度設定リスト.ERB`

类型: .ERB

自动摘要: functions: COM_AUTOSELECT_SET_CATEGORY_PRIORITY_1, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_2, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_3, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_4, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_5, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_6, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_7, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_8, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_9, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_10, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_11, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_12, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_13, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_14, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_15, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_16, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_17, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_18, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_19, COM_AUTOSELECT_SET_CATEGORY_PRIORITY_20; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;# 01 COM_CATEGORY_NUM 愛撫する
;-------------------------------------------------
@COM_AUTOSELECT_SET_CATEGORY_PRIORITY_1(MAIN_PLAYER, MAIN_TARGET)
#DIM MAIN_PLAYER
#DIM MAIN_TARGET

;-------------------------------------------------
;## 基礎
;-------------------------------------------------
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += GET_INITIATIVE_U_RANK(MAIN_PLAYER) * 5
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += AUTO_N_TYPE_活発(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += AUTO_N_TYPE_大人しい(MAIN_PLAYER, 0)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += AUTO_N_TYPE_クール(MAIN_PLAYER, 0)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += AUTO_N_TYPE_凛とした(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += AUTO_N_TYPE_遊び人(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += AUTO_N_TYPE_魅了(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する += AUTO_N_TYPE_魅了(MASTER, 0)
;-------------------------------------------------
;## 性的嗜好補正
;-------------------------------------------------
IF COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する && (GETBIT(SEXUAL_PREFERENCE:MAIN_PLAYER:0, 性的嗜好_愛撫したい) || GETBIT(SEXUAL_PREFERENCE:MAIN_PLAYER:0, 性的嗜好_奉仕したい))
	COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する *= 3
ENDIF
;-------------------------------------------------
;## 陥落傾向補正
;-------------------------------------------------
IF COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する && TALENT:MAIN_PLAYER:恋慕
	COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する *= 2
ENDIF
;-------------------------------------------------
;## 特殊勢力補正
;-------------------------------------------------
IF COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する && TALENT:MAIN_PLAYER:特殊勢力素質 == 特殊勢力_自警団
	TIMES COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_愛撫する, 1.3
ENDIF

RETURN 0

;-------------------------------------------------
;# 02 COM_AUTO_CATEGORY_NUM_性交する
;-------------------------------------------------
@COM_AUTOSELECT_SET_CATEGORY_PRIORITY_2(MAIN_PLAYER, MAIN_TARGET)
#DIM MAIN_PLAYER
#DIM MAIN_TARGET
#DIM COM_AUTO_CHECK_FLAG_IS_CATEGORY	;可否フラグ
#DIM FALLEN_FLAG

FALLEN_FLAG = IS_FALLEN_TO_SP_COUNTRY(MAIN_PLAYER) && FLAG:調教モード == 調教_逆調教特殊

;-------------------------------------------------
;## 基礎
;-------------------------------------------------
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += GET_INITIATIVE_U_RANK(MAIN_PLAYER) * 5
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += AUTO_N_TYPE_活発(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += AUTO_N_TYPE_大人しい(MAIN_PLAYER, 0)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += AUTO_N_TYPE_クール(MAIN_PLAYER, 0)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += AUTO_N_TYPE_凛とした(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += AUTO_N_TYPE_遊び人(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += AUTO_N_TYPE_魅了(MAIN_PLAYER, 1)
COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する += AUTO_N_TYPE_魅了(MASTER, 0)
;-------------------------------------------------
;## 可否チェック
;-------------------------------------------------
;可否チェックリセット
VARSET COM_AUTO_CHECK_FLAG_IS_CATEGORY
;潤滑追加チェックリセット
VARSET COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH
;-------------------------------------------------
;### 対象が慰安モブや特殊勢力
;	特殊勢力の場合、サキュバスや自警団は除く
;-------------------------------------------------
IF CHECK_SP_SADIST_CHARA(MAIN_PLAYER) || GROUPMATCH(TALENT:MAIN_PLAYER:慰安モブ, 慰安_キャラ_犬, 慰安_キャラ_豚,  慰安_キャラ_馬, 慰安_キャラ_猿)
	;---------------------------------------------
	;対象男性・実行女性
	;---------------------------------------------
	IF IS_MALE(MAIN_TARGET) && IS_FEMALE(MAIN_PLAYER)
		;対象の潤滑・実行の倒錯度800以上・実行の主導度Ｕ800以上・実行のサドが必要
		IF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 800  - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 800 - FALLEN_FLAG * 300 && GETBIT(TALENT:MAIN_PLAYER:淫乱系, 素質_淫乱_サド)
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件を達成する
		ELSEIF ABL:MAIN_PLAYER:倒錯度 >= 800 && ABL:MAIN_PLAYER:主導度Ｕ >= 800 - FALLEN_FLAG * 300 && GETBIT(TALENT:MAIN_PLAYER:淫乱系, 素質_淫乱_サド)
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	;---------------------------------------------
	;対象男性・実行男性
	;---------------------------------------------
	ELSEIF IS_MALE(MAIN_TARGET) && IS_MALE(MAIN_PLAYER)
		;対象の潤滑・実行の倒錯度500以上・実行の主導度Ｕ500以上
		IF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 500 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 500 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件を達成する
		ELSEIF ABL:MAIN_PLAYER:倒錯度 >= 500 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 500 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	;---------------------------------------------
	;対象女性・実行女性　
	;---------------------------------------------
	ELSEIF IS_FEMALE(MAIN_TARGET) && IS_FEMALE(MAIN_PLAYER)
		;対象の潤滑・実行の倒錯度100以上・実行の主導度Ｕ100以上
		IF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 100 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 300 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件を達成する
		ELSEIF ABL:MAIN_PLAYER:倒錯度 >= 100 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	;---------------------------------------------
	;対象女性・実行男性
	;---------------------------------------------
	ELSEIF IS_FEMALE(MAIN_TARGET) && IS_MALE(MAIN_PLAYER)
		;対象の潤滑
		IF  COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) 
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件を達成する
		ELSE
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	ENDIF
;-------------------------------------------------
;### 対象が慰安モブや特殊勢力でない
;	または特殊勢力であってもサキュバスや自警団
;-------------------------------------------------
ELSE
	;---------------------------------------------
	;対象男性＆実行女性 逆転するので最も倒錯度と主導度Ｕを要する
	;---------------------------------------------
	IF IS_MALE(MAIN_TARGET) && IS_FEMALE(MAIN_PLAYER)
		;対象の潤滑が不十分ならサド気が必要
		IF !COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 500 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 500 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑が充分なら、実行の倒錯度300以上・実行の主導度Ｕ300以上
		ELSEIF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 300 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 300 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件が達成される
		ELSEIF ABL:MAIN_PLAYER:倒錯度 >= 300 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 300 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	;---------------------------------------------
	;対象男性＆実行男性 男役を好む
	;---------------------------------------------
	ELSEIF IS_MALE(MAIN_TARGET) && IS_MALE(MAIN_PLAYER)
		;対象の潤滑が不十分ならサド気が必要
		IF !COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 100 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 300 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑が充分なら、実行の主導度Ｕ-100以上
		ELSEIF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:主導度Ｕ >= -100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件が達成される
		ELSEIF ABL:MAIN_PLAYER:主導度Ｕ >= -100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	;---------------------------------------------
	;対象女性＆実行女双 男役を好む
	;---------------------------------------------
	ELSEIF IS_FEMALE(MAIN_TARGET) && IS_FEMALE(MAIN_PLAYER) && HAS_PENIS(MAIN_PLAYER)
		;対象の潤滑が不十分ならサド気が必要
		IF !COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 100 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 300 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑が充分なら、実行の主導度Ｕ-100以上
		ELSEIF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:主導度Ｕ >= -100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件が達成される
		ELSEIF ABL:MAIN_PLAYER:主導度Ｕ >= -100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	;---------------------------------------------
	;対象女性＆実行女性 女役を好む
	;---------------------------------------------
	ELSEIF IS_FEMALE(MAIN_TARGET) && IS_FEMALE(MAIN_PLAYER)
		;対象の潤滑が不十分ならサド気が必要
		IF !COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 300 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 500 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑が充分なら、実行の倒錯度100以上・実行の主導度Ｕ100以上
		ELSEIF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 100 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件が達成される
		ELSEIF ABL:MAIN_PLAYER:倒錯度 >= 100 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	;---------------------------------------------
	;対象女性＆実行男性
	;---------------------------------------------
	ELSEIF IS_FEMALE(MAIN_TARGET) && IS_MALE(MAIN_PLAYER)
		;対象の潤滑が不十分なら、実行の倒錯度100以上・実行の主導度Ｕ100以上
		IF !COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET) && ABL:MAIN_PLAYER:倒錯度 >= 100 - FALLEN_FLAG * 300 && ABL:MAIN_PLAYER:主導度Ｕ >= 100 - FALLEN_FLAG * 300
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑が充分なら無条件
		ELSEIF COM_AUTOSELECT_IS_WET_ENOUGH(MAIN_TARGET)
			COM_AUTO_CHECK_FLAG_IS_CATEGORY = 1
		;対象の潤滑を満たせば条件が達成される
		ELSE
			COM_AUTO_CHECK_FLAG_IS_WET_ENOUGH = 1
		ENDIF
	ENDIF
ENDIF
;-------------------------------------------------
;## 性的嗜好補正
;-------------------------------------------------
IF COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する > 0 && GETBIT(SEXUAL_PREFERENCE:MAIN_PLAYER:0, 性的嗜好_性交したい)
	COM_AUTO_CATEGORY_PRIORITY:COM_AUTO_CATEGORY_NUM_性交する *= 3
```
