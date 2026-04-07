# SLG/SCENARIO/SCENARIO8.ERB — 自动生成文档

源文件: `ERB/SLG/SCENARIO/SCENARIO8.ERB`

类型: .ERB

自动摘要: assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;シナリオ8
;第二次幻想郷大戦
;-------------------------------------------------
;@SCENARIO_NAME_8
;RESULTS = 第二次幻想郷大戦
;RETURN
;
;@SCENARIO_INTRO_8
;PRINTFORML
;PRINTFORMW 幻想郷大戦の後、幻想郷は再び群雄割拠となった！
;PRINTFORMW 悲惨な大戦の結果、人里周辺は様々な勢力が入り乱れている！
;PRINTFORMW しかしこれで諦める奴らじゃない、虎視眈々と復活の時を待っていた！
;PRINTFORMW 一方で大戦を経験しなかった辺境の者達は力を貯め、新たな時代の覇権を狙っている！
;PRINTFORMW 幻想郷の行く末はどっちだ！？
;PRINTL
;PRINTL
;PRINTFORML 勢力数を減らしてプレイしますか？
;PRINTFORML （重たすぎる、旗揚げプレイしたい、などの場合はこちらを）
;CALL ASK_YN
;SIF RESULT == 0
;	SETBIT SCVAR:2 , 0
;;PRINTL
;;PRINTFORML 各派閥に主要都市を設けますか？（未実装)
;;PRINTFORML （一部の都市が大きく強化され、ミニイベントが追加されます）
;;CALL ASK_YN
;;SIF RESULT == 0
;	SETBIT SCVAR:2 , 1
;PRINTL
;PRINTFORML 派閥ごとに色を際立たせますか？
;PRINTFORML （初期に同盟を組んでいる勢力間はほぼ同じ色になります）
;CALL ASK_YN
;SIF RESULT == 0
;	SETBIT SCVAR:2 , 2
;
;
;;ランダムキャラは選択に委ねる
;FLAG:OPランダムキャラ使用 = 0
;
;@SCENARIO_PLACEMENT_8
;
;SIF GETBIT(SCVAR:2,2)
;;勢力設定
;COUNTRY_BOSS:0 = 0
;COUNTRY_COLOR:0 = GETDEFCOLOR()
;
;;;--------チーム博麗の巫女;--------
;COUNTRY_BOSS:1 = GET_ID(NAME_TO_CHARA("霊夢"))
;COUNTRY_COLOR:1 = 0x808080
;COUNTRY_AI_TYPE:1 = AI_外交
;
;CITY_OWNER:GET_CITYNUMBER("博麗神社") = 1
;CITY_OWNER:GET_CITYNUMBER("裏手の池") = 1
;CITY_OWNER:GET_CITYNUMBER("博麗神社") = 1
;
;CFLAG:(NAME_TO_CHARA("霊夢")):1 = 1
;;あたしゃここにいるよ
;CFLAG:(NAME_TO_CHARA("魅魔")):1 = 1
;CFLAG:(NAME_TO_CHARA("萃香")):1 = 1
;
;SIF GETBIT(SCVAR:2,0)
;	CFLAG:(NAME_TO_CHARA("華扇")):1 = 15
;
;;;--------チーム紅魔館;--------
;COUNTRY_BOSS:2 = GET_ID(NAME_TO_CHARA("レミリア"))
;COUNTRY_COLOR:2 = 0xFF0000
;COUNTRY_AI_TYPE:2 = AI_好戦
;
;CITY_OWNER:GET_CITYNUMBER("紅魔館") = 2
;CITY_OWNER:GET_CITYNUMBER("地下図書館") = 2
;CFLAG:(NAME_TO_CHARA("レミリア")):1 = 2
;CFLAG:(NAME_TO_CHARA("美鈴")):1 = 2
;CFLAG:(NAME_TO_CHARA("咲夜")):1 = 2
;CFLAG:(NAME_TO_CHARA("フランドール")):1 = 2
;CFLAG:(NAME_TO_CHARA("パチュリー")):1 = 2
;CFLAG:(NAME_TO_CHARA("小悪魔")):1 = 2
;
;;;--------チーム地下図書館;--------
;COUNTRY_BOSS:3 = GET_ID(NAME_TO_CHARA("魔理沙"))
;COUNTRY_COLOR:3 = 0x00ced1
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:3 = 0x66ffff
;CITY_OWNER:GET_CITYNUMBER("霧雨魔法店") = 3
;CITY_OWNER:GET_CITYNUMBER("マーガトロイド邸") = 3
;
;CFLAG:(NAME_TO_CHARA("魔理沙")):1 = 3
;CFLAG:(NAME_TO_CHARA("アリス")):1 = 3
;
;;--------チーム白玉楼;--------
;COUNTRY_BOSS:4 = GET_ID(NAME_TO_CHARA("幽々子"))
;COUNTRY_COLOR:4 = 0xffb6c1
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:4 = 0xff66ff
;COUNTRY_AI_TYPE:4 = AI_内政
;
;CITY_OWNER:GET_CITYNUMBER("白玉楼") = 4
;CITY_OWNER:GET_CITYNUMBER("七千階段") = 4
;CITY_OWNER:GET_CITYNUMBER("西行妖") = 4
;
;CFLAG:(NAME_TO_CHARA("幽々子")):1 = 4
;CFLAG:(NAME_TO_CHARA("妖夢")):1 = 4
;CFLAG:(NAME_TO_CHARA("半霊")):1 = 4
;CFLAG:(NAME_TO_CHARA("妖忌")):1 = 4
;
;
;;--------チーム幽霊楽団;--------
;COUNTRY_BOSS:5= GET_ID(NAME_TO_CHARA("ルナサ"))
;COUNTRY_COLOR:5 = 0xe6e6fa
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:5 = 0xffffcc
;CITY_OWNER:GET_CITYNUMBER("廃洋館") = 5
;
;CFLAG:(NAME_TO_CHARA("リリカ")):1 = 5
;CFLAG:(NAME_TO_CHARA("メルラン")):1 = 5
;CFLAG:(NAME_TO_CHARA("ルナサ")):1 = 5
;
;;--------チームマヨヒガ;--------
;COUNTRY_BOSS:6 = GET_ID(NAME_TO_CHARA("紫"))
;COUNTRY_COLOR:6 = 0xff00f
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:6 = 0xff33ff
;COUNTRY_AI_TYPE:6 = AI_外交
;
;CITY_OWNER:GET_CITYNUMBER("マヨヒガ") = 6
;CITY_OWNER:GET_CITYNUMBER("八雲屋敷") = 6
;
;CFLAG:(NAME_TO_CHARA("紫")):1 = 6
;CFLAG:(NAME_TO_CHARA("藍")):1 = 6
;CFLAG:(NAME_TO_CHARA("橙")):1 = 6
;
;;--------チーム永遠亭--------
;COUNTRY_BOSS:7 = GET_ID(NAME_TO_CHARA("輝夜"))
;COUNTRY_COLOR:7 = 0x4b0082
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:7 = 0x003399
;COUNTRY_AI_TYPE:7 = AI_内政
;
;CITY_OWNER:GET_CITYNUMBER("永遠亭") = 7
;CITY_OWNER:GET_CITYNUMBER("素兎の集落") = 7
;
;CFLAG:(NAME_TO_CHARA("輝夜")):1 = 7
;CFLAG:(NAME_TO_CHARA("永琳")):1 = 7
;CFLAG:(NAME_TO_CHARA("てゐ")):1 = 7
;CFLAG:(NAME_TO_CHARA("鈴仙")):1 = 7
;
;;--------チーム是非曲直庁--------
;COUNTRY_BOSS:8 = GET_ID(NAME_TO_CHARA("四季映姫"))
;COUNTRY_COLOR:8 = 0x05ff82 
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:8 = 0x33ff33
;COUNTRY_AI_TYPE:8 = AI_内政
;
;CITY_OWNER:GET_CITYNUMBER("是非曲直庁") = 8
;CITY_OWNER:GET_CITYNUMBER("彼岸") = 8
;
;CFLAG:(NAME_TO_CHARA("四季映姫")):1 = 8
;CFLAG:(NAME_TO_CHARA("小町")):1 = 8
;CFLAG:(NAME_TO_CHARA("リリーブラック")):1 = 8
;
;;--------チーム守矢神社--------
;COUNTRY_BOSS:9 = GET_ID(NAME_TO_CHARA("神奈子"))
;COUNTRY_COLOR:9 = 0x228b22
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:9 = 0x00cc00
;COUNTRY_AI_TYPE:9 = AI_好戦
;
;CITY_OWNER:GET_CITYNUMBER("守矢神社") = 9
;CITY_OWNER:GET_CITYNUMBER("風神の湖") = 9
;
;CFLAG:(NAME_TO_CHARA("神奈子")):1 = 9
;CFLAG:(NAME_TO_CHARA("諏訪子")):1 = 9
;CFLAG:(NAME_TO_CHARA("早苗")):1 = 9
;
;
;IF !GETBIT(SCVAR:2,0)
;;--------チーム野良神様--------
;	COUNTRY_BOSS:10 = GET_ID(NAME_TO_CHARA("華扇"))
;	COUNTRY_COLOR:10 = 0x808000
;	SIF GETBIT(SCVAR:2,2)
;		COUNTRY_COLOR:10 = 0x669900
;	COUNTRY_AI_TYPE:10 = AI_防衛
;
;	CITY_OWNER:GET_CITYNUMBER("妖怪の山麓") = 10
;	CITY_OWNER:GET_CITYNUMBER("妖怪の山樹海") = 10
;	CITY_OWNER:GET_CITYNUMBER("茨華仙の屋敷") = 10
;
;	CFLAG:(NAME_TO_CHARA("静葉")):1 = 10
;	CFLAG:(NAME_TO_CHARA("穣子")):1 = 10
;	CFLAG:(NAME_TO_CHARA("華扇")):1 = 10
;;------------------------------
;ENDIF
;
;;--------チーム天狗--------
;COUNTRY_BOSS:11 = GET_ID(NAME_TO_CHARA("文"))
;COUNTRY_COLOR:11 = 0xbdb76b
;SIF GETBIT(SCVAR:2,2)
;	COUNTRY_COLOR:11 = 0x66cc33
;COUNTRY_AI_TYPE:11 = AI_外交
;
;CITY_OWNER:GET_CITYNUMBER("九天の滝") = 11
```
