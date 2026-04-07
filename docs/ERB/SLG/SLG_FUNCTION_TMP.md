# SLG/SLG_FUNCTION_TMP.ERB — 自动生成文档

源文件: `ERB/SLG/SLG_FUNCTION_TMP.ERB`

类型: .ERB

自动摘要: functions: TMP_CREATE_RELATION_MAP, TMP_CREATE_UNIT_MAP, TMP_MODIFY_UNIT_MAP, TMP_CREATE_COUNTRY_BOSS_MAP, TMP_CREATE_COUNTRY_NEIBORING_MAP, TMP_CREATE_UNION_TARGET_MAP, TMP_IS_STAY_ENEMY_UNIT, TMP_CREATE_IS_FREE_MAP, TMP_GET_IS_FREE_NUM, TMP_GET_POLITICS_POWER, TMP_GET_COOKING_POWER, TMP_CREATE_POLITICS_POWER_MAP, TMP_CREATE_COOKING_POWER_MAP, TMP_CHANGE_LINE_ONGET, TMP_CHANGE_LINE_ONLOSE, TMP_PREPARE_COUNTRY_STARS, TMP_PRINT_COUNTRY_STARS, TMP_PREPARE_CHARA_STARS, TMP_PRINT_CHARA_STARS, TMP_PRINT_CHARA_STARS_NUM; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;SLG関数の中でも、特に高速化用の特殊変数
;状況次第で意図した結果が得られないことも多いため、取り扱いは控えるのが無難

;-------------------------------------------------
;現在の国家関係マップを作成する関数
;-------------------------------------------------
@TMP_CREATE_RELATION_MAP
VARSET TMP_COUNTRY_RELATION, 0
VARSET COUNTRY_TREATY_NO
FOR LOCAL:0, 1, MAX_COUNTRY
	IF IS_COUNTRY(LOCAL:0)
		TMP_COUNTRY_RELATION:(LOCAL:0):(LOCAL:0) = 5
		FOR LOCAL:1, LOCAL:0 + 1, MAX_COUNTRY
			IF IS_COUNTRY(LOCAL:1)
				CALL CHECK_COUNTRY_RELATION(LOCAL:0, LOCAL:1)
				TMP_COUNTRY_RELATION:(LOCAL:0):(LOCAL:1) = RESULT:0
				TMP_COUNTRY_RELATION:(LOCAL:1):(LOCAL:0) = RESULT:0
				TMP_COUNTRY_RELATION_TERM:(LOCAL:0):(LOCAL:1) = RESULT:1
				TMP_COUNTRY_RELATION_TERM:(LOCAL:1):(LOCAL:0) = RESULT:1
				SELECTCASE RESULT:0
					CASE 1
						COUNTRY_TREATY_NO:(LOCAL:0):1 ++
						COUNTRY_TREATY_NO:(LOCAL:1):1 ++
					CASE 3, 4
						COUNTRY_TREATY_NO:(LOCAL:0):0 ++
						COUNTRY_TREATY_NO:(LOCAL:1):0 ++
				ENDSELECT
			ENDIF
		NEXT
	ENDIF
NEXT

;-------------------------------------------------
;現在の部隊マップを作成する関数
;-------------------------------------------------
@TMP_CREATE_UNIT_MAP
VARSET TMP_UNIT_ONCITY_CNT, 0
VARSET TMP_UNIT_ONCITY_NUM, 0

FOR LOCAL:0, 1, MAX_COUNTRY
	IF IS_COUNTRY(LOCAL:0)
		FOR LOCAL:1, 0, 10
			IF UNIT_SOLDIER:(LOCAL:0):(LOCAL:1) > 0
				LOCAL:3 = UNIT_POSITION:(LOCAL:0):(LOCAL:1)
				FOR LOCAL:2, 0, 20
					IF TMP_UNIT_ONCITY_CNT:(LOCAL:3):(LOCAL:2) == 0
						TMP_UNIT_ONCITY_CNT:(LOCAL:3):(LOCAL:2) = LOCAL:0
						TMP_UNIT_ONCITY_NUM:(LOCAL:3):(LOCAL:2) = LOCAL:1
						BREAK
					ENDIF
				NEXT
			ENDIF
		NEXT
	ENDIF
NEXT

;-------------------------------------------------
;部隊マップをする関数
;-------------------------------------------------
@TMP_MODIFY_UNIT_MAP(勢力, 部隊, 移動元, 移動先 = 0)
#DIM 勢力
#DIM 部隊
#DIM 移動元
#DIM 移動先
#DIM 挿入位置
#DIM 削除位置
#DIM シフト

SIF 移動元 == 0
	GOTO DELETE_SKIPPED

FOR 削除位置, 0, VARSIZE("TMP_UNIT_ONCITY_CNT", 1)
	SIF TMP_UNIT_ONCITY_CNT:移動元:削除位置 != 勢力
		CONTINUE
	SIF TMP_UNIT_ONCITY_NUM:移動元:削除位置 != 部隊
		CONTINUE
	;ARRAY系命令が多次元配列に対応してないのほんまクソ
	;おかげさまでこういうゴミみたいなコードがうまれる
	FOR シフト, 削除位置, VARSIZE("TMP_UNIT_ONCITY_CNT", 1) - 1
		TMP_UNIT_ONCITY_CNT:移動元:シフト = TMP_UNIT_ONCITY_CNT:移動元:(シフト + 1)
		TMP_UNIT_ONCITY_NUM:移動元:シフト = TMP_UNIT_ONCITY_NUM:移動元:(シフト + 1)
	NEXT
	BREAK
NEXT

SIF 削除位置 == VARSIZE("TMP_UNIT_ONCITY_CNT")
	THROW TMP_MODIFY_UNIT_MAPにて、該当都市に存在しない勢力/部隊を指定しました

TMP_UNIT_ONCITY_CNT:移動元:(VARSIZE("TMP_UNIT_ONCITY_CNT", 1) - 1) = 0
TMP_UNIT_ONCITY_NUM:移動元:(VARSIZE("TMP_UNIT_ONCITY_NUM", 1) - 1) = 0

$DELETE_SKIPPED

SIF 移動元 == 0
	RETURN

FOR 挿入位置, 0, VARSIZE("TMP_UNIT_ONCITY_CNT", 1)
	SIF TMP_UNIT_ONCITY_CNT:移動先:挿入位置
		CONTINUE
	TMP_UNIT_ONCITY_CNT:移動先:挿入位置 = 勢力
	TMP_UNIT_ONCITY_NUM:移動先:挿入位置 = 部隊
	BREAK
NEXT


;-------------------------------------------------
;君主のキャラ番号と略名マップを作成する関数
;ARG:0 略名を1文字にするフラグ
;-------------------------------------------------
@TMP_CREATE_COUNTRY_BOSS_MAP
VARSET TMP_COUNTRY_BOSS_NUMBER, -1
VARSET TMP_COUNTRY_BOSS_NAME_SHORT, ""
FOR LOCAL:0, 0, MAX_COUNTRY
	IF COUNTRY_BOSS:(LOCAL:0) >= 1
		TMP_COUNTRY_BOSS_NUMBER:(LOCAL:0) = ID_TO_CHARA(COUNTRY_BOSS:(LOCAL:0))
		SUBSTRING NAME:(TMP_COUNTRY_BOSS_NUMBER:(LOCAL:0)), 0, 2
		TMP_COUNTRY_BOSS_NAME_SHORT:(LOCAL:0) = %RESULTS:0%
	ENDIF
NEXT

;-------------------------------------------------
;国家同士の隣接関係マップを作成する関数
;LOCAL 0:起点となる都市 , 1:起点都市側のCITY_ROUTE参照用カウンタ
;      2:起点都市に隣接する中継点のCITY_ROUTE参照用カウンタ
;      5:参照先の都市番号 , 6:起点都市に隣接する中継点に隣接する都市の番号
;-------------------------------------------------
@TMP_CREATE_COUNTRY_NEIBORING_MAP
VARSET TMP_COUNTRY_IS_NEIBORING, 0
;FOR LOCAL:0 , 1 , MAX_CITY
;	SIF CITY_TYPE:(LOCAL:0) != 0 || CITY_OWNER:(LOCAL:0) == 0
;		CONTINUE
;	;中継点ではなく無所属都市でもない
;	FOR LOCAL:1 , 0 , 10
;		;CITY_ROUTEから隣接している都市を参照
;		LOCAL:5 = CITY_ROUTE:(LOCAL:0):(LOCAL:1)
;		;中継点ではなく中立都市でもない
;		IF CITY_TYPE:(LOCAL:5) == 0 && CITY_OWNER:(LOCAL:5)
;		;両都市の支配勢力が異なる
;			IF CITY_OWNER:(LOCAL:0) != CITY_OWNER:(LOCAL:5)
;				;起点側の勢力から見て対象都市の支配勢力との隣接フラグだけを立てる
;				TMP_COUNTRY_IS_NEIBORING:(CITY_OWNER:(LOCAL:0)):(CITY_OWNER:(LOCAL:5)) = 1
;;					DEBUGPRINTFORML 接続 {LOCAL:0} , {LOCAL:5}
;			ENDIF
;		;中継点であれば更にループを展開
;		ELSEIF CITY_TYPE:(LOCAL:5) == 1
;			FOR LOCAL:2 , 0 , 10
;				;CITY_ROUTEから隣接している都市を参照
;				LOCAL:6 = CITY_ROUTE:(LOCAL:5):(LOCAL:2)
;				;中継点ではなく中立都市でもない
;				IF CITY_TYPE:(LOCAL:6) == 0 && CITY_OWNER:(LOCAL:6)
;				;両都市の支配勢力が異なる
;					IF CITY_OWNER:(LOCAL:0) != CITY_OWNER:(LOCAL:6)
;						;起点側の勢力から見て対象都市の支配勢力との隣接フラグだけを立てる
;						TMP_COUNTRY_IS_NEIBORING:(CITY_OWNER:(LOCAL:0)):(CITY_OWNER:(LOCAL:6)) = 1
;;							DEBUGPRINTFORML 中継 {LOCAL:0} , {LOCAL:6}
;					ENDIF
;				ENDIF
;			NEXT
;		ENDIF
;	NEXT
;NEXT

;幻想郷春の都市総当り方式。IS_ROUTEが複数の中継点に対応しだしたらこちらのほうが安全に運用できます
;変更点は最初に勢力別で回すのではなく、別勢力でつながっている都市があれば両都市の支配勢力を見て処理をする感じです
;起点となる都市
FOR LOCAL:0 , 1 , MAX_CITY
	;中継点ではなく中立都市でもない
	IF CITY_TYPE:(LOCAL:0) == 0 && CITY_OWNER:(LOCAL:0)
		;隣接を確認する都市
		FOR LOCAL:1 , 1 , MAX_CITY
			;中継点ではなく中立都市でもない
			IF CITY_TYPE:(LOCAL:0) == 0 && CITY_OWNER:(LOCAL:1)
			;両都市の支配勢力が異なり、かつ２都市が接続している
				IF CITY_OWNER:(LOCAL:0) != CITY_OWNER:(LOCAL:1) && IS_ROUTE(LOCAL:0, LOCAL:1)
					;起点側の勢力から見て対象都市の支配勢力との隣接フラグだけを立てる
					TMP_COUNTRY_IS_NEIBORING:(CITY_OWNER:(LOCAL:0)):(CITY_OWNER:(LOCAL:1)) = 1
				ENDIF
			ENDIF
		NEXT
	ENDIF
NEXT

;-------------------------------------------------
;連合による討伐対象のマップを作成する関数
;-------------------------------------------------
@TMP_CREATE_UNION_TARGET_MAP
VARSET TMP_COUNTRY_UNION_TARGET, -1
FOR LOCAL:0, 0, MAX_COUNTRY
	IF COUNTRY_BOSS:(LOCAL:0) >= 1
		TMP_COUNTRY_UNION_TARGET:(LOCAL:0) = GET_UNION_TARGET(LOCAL:0)
	ENDIF
NEXT

;-------------------------------------------------
;ARG:0番の都市上に敵勢力部隊が存在するかどうかを判定する関数
;-------------------------------------------------
@TMP_IS_STAY_ENEMY_UNIT(ARG:0, ARG:1)
#FUNCTION
IF ARG:0 < 0 || ARG:0 >= MAX_CITY
	RETURNF 0
```
