# SYSTEM/ENDING.ERB — 自动生成文档

源文件: `ERB/SYSTEM/ENDING.ERB`

类型: .ERB

自动摘要: functions: ENDING_CHECK, DEAD_END, ENDING_TEXT, GET_UNIFY_COUNTRY, IS_NOENEMY, UNIFY_FREE_CITY, CAPTURE_WANDERER, CAPTURE_WANDERER_EACH; UI/print

前 200 行源码片段:

```text
﻿;エンディングに関する処理

;-------------------------------------------------
;エンディングのチェック
;-------------------------------------------------
@ENDING_CHECK
;天下を統一した国家の番号
#DIM 統治勢力
#DIM 統治君主
#DIM 分割統治フラグ

SIF FLAG:クリアフラグ
	RETURN

;主人公が死亡した場合
IF FLAG:強制エンドフラグ || FLAG:戦死エンドフラグ
	CALL DEAD_END
	RETURN
ENDIF

;天下を統一した国家の番号を取得
統治勢力 = GET_UNIFY_COUNTRY()

;国家関係マップの作成
CALL TMP_CREATE_RELATION_MAP

;分割統治エンド
IF !IS_COUNTRY(統治勢力) && CFLAG:MASTER:所属 >= 1 && IS_NOENEMY(CFLAG:MASTER:所属)
	統治勢力 = CFLAG:MASTER:所属
	分割統治フラグ = 1
ENDIF

SIF !IS_COUNTRY(統治勢力)
	RETURN

;無所属の都市の統合
CALL UNIFY_FREE_CITY(統治勢力)

統治君主 = GET_COUNTRY_BOSS(統治勢力)

PRINTL 
CALL COLOR_PRINTW(@"%ANAME(統治君主)%が天下を統一しました！", カラー_注意)
PRINTL 
CUSTOMDRAWLINE *-
WAIT

IF IS_SP_COUNTRY(統治勢力)
	TRYCCALLFORM %SP_COUNTRY_NAME_ENG:SP_COUNTRY_TO_CONST(統治勢力)%_ENDING
	CATCH
		CALL ENDING_TEXT(統治勢力)
	ENDCATCH
ELSE
	CALL ENDING_TEXT(統治勢力, 分割統治フラグ)
ENDIF

PRINTL
ALIGNMENT CENTER
PRINTL ――――― つづく ―――――
ALIGNMENT LEFT
PRINTL 
WAIT
FOR LOCAL:0, 0, 20
	PRINTL 
NEXT

;野盗を削除
SIF GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗)) != -1 && 統治勢力 != GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗))
	CALL DESTROY_COUNTRY(GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_野盗)))

;部隊を解散
FOR LOCAL:0, 1, MAX_COUNTRY
	IF IS_COUNTRY(LOCAL:0)
		;部隊を解散
		CALL CLEAR_ALL_UNIT(LOCAL:0)
	ENDIF
NEXT
;守将を解除
VARSET CITY_COMMANDER, 0

;残党の一斉検挙
CALL CAPTURE_WANDERER(統治勢力)

;クリアフラグを立てる
FLAG:クリアフラグ = 1

FOR LOCAL:0, 0, 10
	PRINTL
NEXT

SETCOLOR カラー_注意
PRINTFORMW 現時点でのデータを利用し、「周回用セーブ」を作ることができます
PRINTFORMW 周回用セーブをロードすることで、今の武将やアイテムを引き継いで新規にシナリオを開始できます
PRINTFORMW 周回用セーブを作れるのは今だけです（クリア後のおまけモードに入るともう作成できません)
RESETCOLOR

FLAG:クリア直後フラグ = 1

CALL SAVE_GAME

FLAG:クリア直後フラグ = 0

RETURN 0

;-------------------------------------------------
;死んだ場合
;-------------------------------------------------
@DEAD_END
CALL SINGLE_DRAWLINE

;処刑
IF FLAG:強制エンドフラグ
	PRINTFORMW 処刑を命じられた%ANAME(MASTER)%の首元に、ひんやりと冷たい鉄の刀が押し当てられる…
;戦死
ELSEIF FLAG:戦死エンドフラグ
	PRINTFORMW 戦いの中で致命傷を負った%ANAME(MASTER)%は、傷口から大量の血を噴き出し地面に倒れ伏していた
	PRINTFORMW 馬のいななきや刀が触れ合う金属音、悲鳴や狂喜の入り混じった歓声が響く中、%ANAME(MASTER)%の意識は薄れていく…
ENDIF

PRINTL 
PRINTW ………………
PRINTW …………
PRINTW ……
PRINTL 

;好感度が最も高いキャラとその好感度を求める
LOCAL:1 = 0
LOCAL:2 = -1
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):2 > LOCAL:1 && LOCAL:0 != MASTER && GROUPMATCH(CFLAG:(LOCAL:0):特殊状態, 0, 1) && !IS_ANIMAL(LOCAL)
		LOCAL:1 = CFLAG:(LOCAL:0):2
		LOCAL:2 = LOCAL:0
	ENDIF
NEXT

;好感度5000以上のキャラがいる場合
IF LOCAL:1 >= 5000
	;口上の専用エンディングがあれば呼び出す
	RESULT = 0
	CALL KOJO_DEAD_ENDING(LOCAL:2)
	IF !RESULT
		PRINTFORMW ここに、%ANAME(MASTER)%の歴史は幕を閉じた…
		PRINTFORMW                             - 終 -
		WAIT
	ENDIF
;好感度5000以上のキャラがいない場合
ELSE
	PRINTFORMW ここに、%ANAME(MASTER)%の歴史は幕を閉じた…
	PRINTFORMW                             - 終 -
	WAIT
ENDIF

FOR LOCAL:0, 0, 10
	PRINTL 
NEXT
;強制エンドフラグをたてる。TURNEND末にてBEGIN TITLEされる（そうしないとBEGIN SHOPに上書きされる）
FLAG:強制エンドフラグ = 1



;-------------------------------------------------
;エンディング用テキスト
;-------------------------------------------------
@ENDING_TEXT(統治国, 分割統治フラグ)
#DIM 統治国
#DIM 君主
#DIM 分割統治フラグ
君主 = GET_COUNTRY_BOSS(統治国)
PRINTFORML 幻想郷を焼き尽くさんばかりに燃え広がった戦乱の炎は、
IF 分割統治フラグ
	PRINTFORMW 一人の英雄の手によって打ち払われた。
ELSE
	PRINTFORMW 一人の英雄の手によって治められた
ENDIF
PRINTFORMW その英雄の名は%NAME_FORMAL(君主)%。
PRINTFORMW %PRONOUN(君主)%の偉業は、長く後世に語り継がれることとなるだろう。
PRINTFORMW ここに天下は定まり、幻想郷にしばしの平穏の時代が訪れたのであった……

SIF 統治国 != CFLAG:MASTER:所属
	RETURN

;主人公の所属する国家が統一した場合

;好感度が最も高いキャラとその好感度を求める
LOCAL:1 = 0
LOCAL:2 = -1
FOR LOCAL:0, 0, CHARANUM
	IF CFLAG:(LOCAL:0):2 > LOCAL:1 && LOCAL:0 != MASTER && CFLAG:(LOCAL:0):特殊状態 == 0 && CFLAG:(LOCAL:0):所属 == CFLAG:MASTER:所属 && !IS_ANIMAL(LOCAL)
		LOCAL:1 = CFLAG:(LOCAL:0):2
		LOCAL:2 = LOCAL:0
	ENDIF
NEXT

;好感度5000以上のキャラがいる場合
IF LOCAL:1 >= 5000
	;口上の専用エンディングがあれば呼び出す
	RESULT = 0
	CALL KOJO_SINGLE_ENDING(LOCAL:2)
	IF !RESULT
		PRINTFORMW ひっそりと祝賀の宴から抜け出した%ANAME(MASTER)%と%ANAME(LOCAL:2)%は、共に星空を見上げていた。
		PRINTFORMW ここに来るまで、二人で様々な苦難を乗り越えてきたが、今思えばあっという間だったような気もする。
```
