# SLG/SLG_AI_DIPLOMACY.ERB — 自动生成文档

源文件: `ERB/SLG/SLG_AI_DIPLOMACY.ERB`

类型: .ERB

自动摘要: functions: CREATE_AI_DIPLOMACY_PLAN, SLG_DIPLOMACY_CONFERENCE, SLG_DIPLOMACY_CEASE_FIRE, SLG_DIPLOMACY_ALLIANCE, SLG_DIPLOMACY_CREATE_SCANDAL, SLG_DIPLOMACY_REQUEST, SLG_AI_DIPLOMACY_DOES_CREATE_UNION, SLG_AI_DIPLOMACY_DOES_PARTICIPATE_UNION, SLG_DIPLOMACY_CREATE_UNION, CHECK_AI_DIPLOMACY_PLAN, CLEAR_AI_DIPLOMACY_PLAN, CHANGE_AI_DIPLOMACY_PLAN, SLG_DIPLOMACY_TO_PLAYER; UI/print

前 200 行源码片段:

```text
﻿@SLG_AI_DIPLOMACY(勢力)
#DIM 勢力
#DIM 計画

;暫定対処
;プレイヤーは自分で外交できるので。
SIF 勢力 == CFLAG:MASTER:所属 && CONFIG:302
	RETURN


SIF COUNTRY_IS_CLOSED:勢力
	RETURN

AI_DIPLOMACY_TERM:勢力 --

;期限切れなら外交計画更新
IF AI_DIPLOMACY_TERM:勢力 <= 0
	CALL CREATE_AI_DIPLOMACY_PLAN(勢力)
ENDIF

FOR 計画, 0, AI_DIPLOMACY_PROPERTY:(COUNTRY_AI_TYPE:勢力):AI_外交_行動回数
	SIF AI_DIPLOMACY_PLAN:勢力:計画 == -1
		CONTINUE
	SIF !IS_COUNTRY(AI_DIPLOMACY_TARGET:勢力:計画)
		CONTINUE
	SIF COUNTRY_IS_CLOSED:(AI_DIPLOMACY_TARGET:勢力:計画)
		CONTINUE
	SELECTCASE AI_DIPLOMACY_PLAN:勢力:計画
		CASE AI_外交計画_会談
			CALL SLG_DIPLOMACY_CONFERENCE(勢力, AI_DIPLOMACY_TARGET:勢力:計画)
		CASE AI_外交計画_同盟
			CALL SLG_DIPLOMACY_ALLIANCE(勢力, AI_DIPLOMACY_TARGET:勢力:計画)
		CASE AI_外交計画_停戦
			CALL SLG_DIPLOMACY_CEASE_FIRE(勢力, AI_DIPLOMACY_TARGET:勢力:計画)
		CASE AI_外交計画_悪評
			CALL SLG_DIPLOMACY_CREATE_SCANDAL(勢力, AI_DIPLOMACY_TARGET:勢力:計画)
		CASE AI_外交計画_連合
			CALL SLG_DIPLOMACY_CREATE_UNION(勢力, AI_DIPLOMACY_TARGET:勢力:計画)
		CASE AI_外交計画_要求
			CALL SLG_DIPLOMACY_REQUEST(勢力, AI_DIPLOMACY_TARGET:勢力:計画)
	ENDSELECT
NEXT

;------------------------
;外交計画を作成する
;------------------------
@CREATE_AI_DIPLOMACY_PLAN(勢力)
#DIM 勢力
#DIM 君主
#DIM 相手勢力
#DIM 勢力インデックス
#DIM 勢力数
#DIM 相手勢力君主
#DIM 勢力リスト, MAX_COUNTRY
#DIM 関係性リスト, MAX_COUNTRY
#DIM 逆関係性リスト, MAX_COUNTRY
#DIM 経済力リスト, MAX_COUNTRY
#DIM 難易度補正
#DIM 計画
#DIM 理由
#DIM CONST 理由_好き = 0
#DIM CONST 理由_嫌い = 1
#DIM CONST 理由_好かれ = 2
#DIM CONST 理由_嫌われ = 3
#DIM CONST 理由_経済強い = 4
#DIM CONST 理由_経済弱い = 5
VARSET 勢力リスト
VARSET 関係性リスト, 1500
VARSET 逆関係性リスト, 1500
VARSET 経済力リスト, __INT_MIN__

君主 = GET_COUNTRY_BOSS(勢力)

AI_DIPLOMACY_TERM:勢力 = RAND(3, 6)

;外交計画をリセットする
FOR 計画, 0, VARSIZE("AI_DIPLOMACY_PLAN", 1)
	AI_DIPLOMACY_PLAN:勢力:計画 = -1
	AI_DIPLOMACY_TARGET:勢力:計画 = 0
NEXT

勢力数 = 0
FOR 相手勢力, 0, MAX_COUNTRY
	SIF !IS_COUNTRY(相手勢力)
		CONTINUE
	SIF COUNTRY_IS_CLOSED:相手勢力
		CONTINUE
	SIF 勢力 == 相手勢力
		CONTINUE
	勢力リスト:勢力数 = 相手勢力
	相手勢力君主 = GET_COUNTRY_BOSS(相手勢力)

	関係性リスト:勢力数 = 1500 + REL_LIKE:君主:相手勢力君主 - REL_HATE:君主:相手勢力君主 - DIPLOMACY_HATE:相手勢力 * (相手勢力 == CFLAG:MASTER:所属 ? 50 # 30)


	SIF TECHNOLOGY_STATUS:相手勢力:TECHNOLOGY_DIPLOMACY >= 5
		関係性リスト:勢力数 += 100
	SIF TECHNOLOGY_STATUS:相手勢力:TECHNOLOGY_DIPLOMACY >= 5
		関係性リスト:勢力数 += 200

	逆関係性リスト:勢力数 = 1500 + REL_LIKE:相手勢力君主:君主 - REL_HATE:相手勢力君主:君主 - DIPLOMACY_HATE:勢力 * (勢力 == CFLAG:MASTER:所属 ? 50 # 30)
	経済力リスト:勢力数 = TMP_SUM_ECONOMY:相手勢力
	IF 相手勢力 == CFLAG:MASTER:所属
		難易度補正 = GET_DIFFICULTY_CORRECTION()
		関係性リスト:勢力数 = 関係性リスト:勢力数 * 100 / 難易度補正
	ENDIF
	勢力数 ++
NEXT

SIF 勢力数 <= 0
	RETURN

FOR 計画, 0, MIN(AI_DIPLOMACY_PROPERTY:(COUNTRY_AI_TYPE:勢力):AI_外交_行動回数, AI_DIPLOMACY_MAX_PLAN)
	SIF 勢力数 <= 0
		BREAK
	SELECTCASE RAND:100
		CASE IS < 10
			勢力インデックス = FINDELEMENT(逆関係性リスト, MAXARRAY(逆関係性リスト, 0, 勢力数), 0, 勢力数 + 1)
			理由 = 理由_好かれ
		CASE IS < 30
			勢力インデックス = FINDELEMENT(逆関係性リスト, MINARRAY(逆関係性リスト, 0, 勢力数), 0, 勢力数 + 1)
			理由 = 理由_嫌われ
		CASE IS < 50
			勢力インデックス = FINDELEMENT(関係性リスト, MAXARRAY(関係性リスト, 0, 勢力数), 0, 勢力数 + 1)
			理由 = 理由_好き
		CASE IS < 75
			勢力インデックス = FINDELEMENT(関係性リスト, MINARRAY(関係性リスト, 0, 勢力数), 0, 勢力数 + 1)
			理由 = 理由_嫌い
		CASE IS < 90
			勢力インデックス = FINDELEMENT(経済力リスト, MAXARRAY(経済力リスト, 0, 勢力数), 0, 勢力数 + 1)
			理由 = 理由_経済強い
		CASEELSE
			勢力インデックス = FINDELEMENT(経済力リスト, MAXARRAY(経済力リスト, 0, 勢力数), 0, 勢力数 + 1)
			理由 = 理由_経済弱い
	ENDSELECT

	相手勢力 = 勢力リスト:勢力インデックス
	AI_DIPLOMACY_TARGET:勢力:計画 = 相手勢力

	SELECTCASE 理由
		CASE 理由_好かれ
			SELECTCASE IFRAND("0TO74", 1, "75TO89", 逆関係性リスト:勢力インデックス > 1500 && TMP_COUNTRY_RELATION:勢力:相手勢力 == 0  && 勢力数 >= 2, "90TO99", 逆関係性リスト:勢力インデックス > 1800 && TMP_COUNTRY_RELATION:勢力:相手勢力 <= 2 && 勢力数 >= 2)
				CASE IS < 75
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_会談
				CASE IS < 90
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_停戦
				CASEELSE
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_同盟
			ENDSELECT
		CASE 理由_嫌われ
			SELECTCASE RAND:100
				CASE IS < 80
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_会談
				CASE IS < 99
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_悪評
			ENDSELECT
		CASE 理由_好き
			SELECTCASE IFRAND("0TO74", 1, "75TO89", 逆関係性リスト:勢力インデックス > 1500 && TMP_COUNTRY_RELATION:勢力:相手勢力 == 0  && 勢力数 >= 2, "90TO99", 逆関係性リスト:勢力インデックス > 1800 && TMP_COUNTRY_RELATION:勢力:相手勢力 <= 2 && 勢力数 >= 2)
				CASE IS < 75
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_会談
				CASE IS < 90
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_停戦
				CASEELSE
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_同盟
			ENDSELECT
		CASE 理由_嫌い
			IF SLG_AI_DIPLOMACY_DOES_CREATE_UNION(勢力, 相手勢力)
				AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_連合
			ELSE
				IF 関係性リスト:勢力インデックス < RAND:3000 && DIPLOMACY_HATE:勢力 <= RAND(10, 15) && (相手勢力 != CFLAG:MASTER:所属 || (!IS_LOVER(君主) && !IS_SLAVE(君主)))
					AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_悪評
				ELSE
					CALL CLEAR_AI_DIPLOMACY_PLAN(勢力, 相手勢力)
				ENDIF
			ENDIF
		CASE 理由_経済強い
			IF REL_HATE:GET_COUNTRY_BOSS(勢力):GET_COUNTRY_BOSS(相手勢力) > REL_LIKE:GET_COUNTRY_BOSS(勢力):GET_COUNTRY_BOSS(相手勢力) + 300 && SLG_AI_DIPLOMACY_DOES_CREATE_UNION(勢力, 相手勢力)
				AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_連合
			ELSE
				IF RAND:3000 < 関係性リスト:勢力インデックス
					SELECTCASE IFRAND("0TO74", 1, "75TO89", 逆関係性リスト:勢力インデックス > 1500 && TMP_COUNTRY_RELATION:勢力:相手勢力 == 0  && 勢力数 >= 2, "90TO99", 逆関係性リスト:勢力インデックス > 1800 && TMP_COUNTRY_RELATION:勢力:相手勢力 <= 2 && 勢力数 >= 2)
						CASE IS < 75
							AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_会談
						CASE IS < 90
							AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_停戦
						CASEELSE
							AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_同盟
					ENDSELECT
				ELSE
					IF DIPLOMACY_HATE:勢力 <= RAND(10, 15) && (相手勢力 != CFLAG:MASTER:所属 || (!IS_LOVER(君主) && !IS_SLAVE(君主)))
						AI_DIPLOMACY_PLAN:勢力:計画 = AI_外交計画_悪評
					ELSE
						CALL CLEAR_AI_DIPLOMACY_PLAN(勢力, 相手勢力)
					ENDIF
				ENDIF
			ENDIF
		CASE 理由_経済弱い
;				IF RAND:3000 < 関係性リスト:勢力インデックス
;					SELECTCASE IFRAND("0TO74", 1, "75TO89", 逆関係性リスト:勢力インデックス > 1500 && TMP_COUNTRY_RELATION:勢力:相手勢力 == 0  && 勢力数 >= 2, "90TO99", 逆関係性リスト:勢力インデックス > 1800 && TMP_COUNTRY_RELATION:勢力:相手勢力 <= 2 && 勢力数 >= 2)
;						CASE IS < 75
```
