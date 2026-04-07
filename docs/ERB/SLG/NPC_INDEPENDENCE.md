# SLG/NPC_INDEPENDENCE.ERB — 自动生成文档

源文件: `ERB/SLG/NPC_INDEPENDENCE.ERB`

类型: .ERB

自动摘要: functions: NPC_INDEPENDENCE, CAN_INDEPENDENCE, INDEPENDENCE_STEAL_CITY_NUM, NPC_INDEPENDENCE_EVENT, STEAL_CITIES, STEAL_SOLDIER; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;desc  :NPCの独立の処理
;param :離反者:離反するキャラの番号
;param :奪取都市数:奪う都市の数（補正が入る可能性がある）
;param :奪取都市数固定:上記補正を切るフラグ　オンにする場合呼び出し側でチェックすること
;param :イベント発生禁止:説得イベントの発生を禁止するフラグ
;return:戻り値:戻り値説明
;-------------------------------------------------
@NPC_INDEPENDENCE(離反者, 奪取都市数 = 0, 奪取都市数固定 = 0, イベント発生禁止 = 0)
#DIM 離反者
#DIM 奪取都市数
#DIM 奪取都市数固定
#DIM 離反元君主
#DIM 離反元勢力
#DIM 新勢力
#DIM 新勢力カラー
#DIM プレイヤー対応
#DIM イベント発生禁止
#DIM CONST 対応_怒り = 3
#DIM CONST 対応_拒否 = 2
#DIM CONST 対応_受諾 = 1
#DIM CONST 対応_無関係 = 0

#DIM 武将数
#DIM 奪取武将数
#DIM 奪取武将

;離反元君主のキャラ番号
離反元君主 = GET_COUNTRY_BOSS(CFLAG:(離反者):所属)
;離反元国家の番号
離反元勢力 = CFLAG:(離反者):所属
;新しい勢力を取得
新勢力 = GET_NEW_COUNTRY()

SIF !CAN_INDEPENDENCE(離反者, 離反元勢力)
	RETURN -1

;奪取都市数を補正する
奪取都市数 = INDEPENDENCE_STEAL_CITY_NUM(離反元勢力, 奪取都市数, 奪取都市数固定)

SIF 奪取都市数 <= 0
	RETURN -1

;国家色は関数にて自動決定

;プレイヤーの態度をプレイヤー対応に格納
プレイヤー対応 = 対応_無関係

;プレイヤーが離反者の所属国家の君主でなく、かつ離反者の同僚である
IF 離反元君主 != MASTER && CFLAG:MASTER:所属 == CFLAG:(離反者):所属 && !イベント発生禁止
	CALL NPC_INDEPENDENCE_EVENT(離反者, 離反元君主, 新勢力)
	SIF RESULT == -1
		RETURN
	プレイヤー対応 = RESULT
ENDIF


CALL SINGLE_DRAWLINE
CALL COLOR_PRINTW(@"%NAME_FORMAL(離反者)%が挙兵し、%NAME_FORMAL(離反元君主)%の勢力から独立しました！", カラー_警告)

新勢力カラー = CHARA_COUNTRY_COLOR(離反者)

COUNTRY_COLOR:新勢力 = 新勢力カラー
COUNTRY_BOSS:新勢力  = GET_ID(離反者)
CALL CHANGE_COUNTRY(離反者, 新勢力, 1)

INDEPENDENCE_COUNTER:新勢力 = 10
DIPLOMACY_HATE:新勢力 += 10

CALL SET_COUNTRY_AI_TYPE(新勢力)

;離反元勢力の都市の守将を解除
FOR LOCAL:0, 0, MAX_CITY
	IF CITY_OWNER:(LOCAL:0) == 離反元勢力
		CITY_COMMANDER:(LOCAL:0) = 0
	ENDIF
NEXT

;都市をかすめ取る
CALL STEAL_CITIES(離反元勢力, 新勢力, 奪取都市数)

;兵力をかすめ取る
CALL STEAL_SOLDIER(離反元勢力, 新勢力)

;ぜんぜんとれなかったときのことを考慮して最低限のこづかい
COUNTRY_SOLDIER:新勢力 += MIN(DAY * 200, 5000)

;武将数をカウントする
武将数 = 0
FOR LOCAL:0, 0, CHARANUM
	;離反元所属でないとだめ
	SIF CFLAG:(LOCAL:0):所属 != 離反元勢力
		CONTINUE
	;捕虜ならだめ
	SIF CFLAG:(LOCAL:0):捕虜先
		CONTINUE
	;主人公、離反者、君主はだめ
	SIF GROUPMATCH(LOCAL:0, MASTER, 離反者, 離反元君主)
		CONTINUE
	;特殊キャラもダメ
	SIF IS_SP_CHARA(LOCAL:0)
		CONTINUE
	武将数 ++
NEXT

SIF 武将数 <= 0
	GOTO STEAL_COMMANDER_END

;25～50%の武将を奪う。最大10
奪取武将数 = MIN(武将数 * RAND(25, 50) / 100, 10)
CALL FISHER_YATES_SHAFFLE(CHARANUM)
FOR LOCAL, 0, CHARANUM
	SIF 奪取武将数 == 0
		BREAK
	奪取武将 = SHAFFLE_ARRAY:LOCAL
	;離反元所属でないとだめ
	SIF CFLAG:(奪取武将):所属 != 離反元勢力
		CONTINUE
	;捕虜ならだめ
	SIF CFLAG:(奪取武将):捕虜先
		CONTINUE
	;主人公、離反者、君主はだめ
	SIF GROUPMATCH(奪取武将, MASTER, 離反者, 離反元君主)
		CONTINUE
	;特殊キャラもダメ
	SIF IS_SP_CHARA(奪取武将)
		CONTINUE
	;プレイヤーがかかわる場合の陥落済みキャラの扱い
	IF IS_FALLEN(奪取武将) && プレイヤー対応 != 対応_無関係
		;裏切る場合、陥落済みキャラはついてくる
		IF プレイヤー対応 == 対応_受諾
			CALL CHANGE_COUNTRY(奪取武将, 新勢力, 1)
			奪取武将数 --
		;怒らせた場合は拉致してくる
		ELSEIF プレイヤー対応 == 対応_怒り
			CALL CAPTURE(奪取武将, 新勢力)
			奪取武将数 --
		ENDIF
		;拒否した場合はなにもしてこない
	;1/2の確率で同調OR拉致
	ELSEIF RAND:2
		IF REL_LIKE:奪取武将:離反元君主 - REL_HATE:奪取武将:離反元君主 > 0
			CALL CAPTURE(奪取武将, 新勢力)
		ELSE
			CALL CHANGE_COUNTRY(奪取武将, 新勢力, 1)
		ENDIF
		奪取武将数 --
	ENDIF
NEXT

$STEAL_COMMANDER_END

;離反元勢力の部隊を解散
CALL CLEAR_ALL_UNIT(離反元勢力, 1)
;仲はまぁ、悪くもなりますわな
CALL CHANGE_RELATION_C_TO_C(離反元勢力, 新勢力, -200, 600)
CALL CHANGE_RELATION_C_TO_C(新勢力, 離反元勢力, -200, 600)

CALL COUNTRY_SET_TECHNOLOGY(新勢力)

;離反元から技術を盗む
FOR LOCAL, 0, TECHNOLOGY_MAX_GENRE
	TECHNOLOGY_STATUS:新勢力:LOCAL = MAX(TECHNOLOGY_STATUS:離反元勢力:LOCAL - RAND(0, 2), 0)
NEXT

;反乱勢力の都市を表示
FOR LOCAL:0, 0, MAX_CITY
	IF CITY_OWNER:(LOCAL:0) == 新勢力
		PRINTFORML %GET_CITYNAME(LOCAL:0)%が%ANAME(離反者)%の支配下におかれました
	ENDIF
NEXT
;反乱勢力に流れた人材
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):所属 == 新勢力 && LOCAL:0 != 離反者
		PRINTFORML %ANAME(LOCAL:0)%が%ANAME(離反者)%の下につきました
	ELSEIF CFLAG:(LOCAL:0):9 == 新勢力
		SETCOLOR カラー_警告
		PRINTFORML %ANAME(LOCAL:0)%が%ANAME(離反者)%に拉致されました
		RESETCOLOR
	ENDIF
NEXT

;-------------------------------------------------
;desc  :ある離反者が離反できるかの判定
;param :離反者
;param :奪取都市数:奪う都市の数(補整が入る可能性あり)
;param :奪取都市数固定:奪う都市の数を固定するかのフラグ
;return:離反が可能なら1
;-------------------------------------------------
@CAN_INDEPENDENCE(離反者, 奪取都市数, 奪取都市数固定)
#FUNCTION
#DIM 離反者
#DIM 奪取都市数
#DIM 奪取都市数固定
#DIM 離反元君主
#DIM 離反元勢力
#DIM 新勢力

;離反元君主のキャラ番号
離反元君主 = GET_COUNTRY_BOSS(CFLAG:(離反者):所属)
```
