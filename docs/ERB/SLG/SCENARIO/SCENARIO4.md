# SLG/SCENARIO/SCENARIO4.ERB — 自动生成文档

源文件: `ERB/SLG/SCENARIO/SCENARIO4.ERB`

类型: .ERB

自动摘要: assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;シナリオ4
;作品対抗幻想郷大戦（暫定）
;-------------------------------------------------
;@SCENARIO_NAME_4
;RESULTS = 幻想郷内戦
;RETURN
;
;@SCENARIO_INTRO_4
;PRINTFORML
;PRINTFORMW 幻想郷は分裂した！
;PRINTFORMW 各勢力が様々な思惑を絡め、争いあう！
;PRINTFORMW こんどのスローガンは「忠誠心？　なにそれおいしいの？」
;PRINTFORMW 幻想郷は野心家がいっぱい！　隙あらば自分が覇権を握ろうとしているぞ！
;PRINTFORMW 君はこの戦いを生き残り、幻想郷の覇者となれるのか！
;PRINTL
;
;;ランダムキャラは選択に委ねる
;FLAG:OPランダムキャラ使用 = 0
;
;
;@SCENARIO_PLACEMENT_4
;
;;勢力設定
;COUNTRY_BOSS:0 = 0
;COUNTRY_COLOR:0 = GETDEFCOLOR()
;
;
;
;;;--------霊夢;--------
;COUNTRY_BOSS:1 = GET_ID(NAME_TO_CHARA("霊夢"))
;COUNTRY_COLOR:1 = 0x757575
;COUNTRY_AI_TYPE:1 = AI_外交
;
;CITY_OWNER:GET_CITYNUMBER("博麗神社") = 1
;CITY_OWNER:GET_CITYNUMBER("博麗大結界") = 1
;CITY_OWNER:GET_CITYNUMBER("ミズナラの木") = 1
;CITY_OWNER:GET_CITYNUMBER("裏手の池") = 1
;;三妖精に萃香 あと華扇
;;おーい誰か魅魔様の行方を(ry
;CFLAG:(NAME_TO_CHARA("霊夢")):1 = 1
;CFLAG:(NAME_TO_CHARA("サニーミルク")):1 = 1
;CFLAG:(NAME_TO_CHARA("ルナチャイルド")):1 = 1
;CFLAG:(NAME_TO_CHARA("スターサファイア")):1 = 1
;CFLAG:(NAME_TO_CHARA("萃香")):1 = 1
;CFLAG:(NAME_TO_CHARA("華扇")):1 = 1
;CFLAG:(NAME_TO_CHARA("菫子")):1 = 1
;
;;--------レミリア--------
;COUNTRY_BOSS:2 = GET_ID(NAME_TO_CHARA("レミリア"))
;COUNTRY_COLOR:2 = 0xFF0000
;COUNTRY_AI_TYPE:2 = AI_好戦
;
;CITY_OWNER:GET_CITYNUMBER("紅魔館") = 2
;CITY_OWNER:GET_CITYNUMBER("地下図書館") = 2
;;紅魔館組
;CFLAG:(NAME_TO_CHARA("レミリア")):1 = 2
;CFLAG:(NAME_TO_CHARA("美鈴")):1 = 2
;CFLAG:(NAME_TO_CHARA("咲夜")):1 = 2
;CFLAG:(NAME_TO_CHARA("小悪魔")):1 = 2
;CFLAG:(NAME_TO_CHARA("パチュリー")):1 = 2
;CFLAG:(NAME_TO_CHARA("フランドール")):1 = 2
;
;;--------魔理沙--------
;COUNTRY_BOSS:3 = GET_ID(NAME_TO_CHARA("魔理沙"))
;COUNTRY_COLOR:3 = 0xE1D200
;CITY_OWNER:GET_CITYNUMBER("マーガトロイド邸") = 3
;CITY_OWNER:GET_CITYNUMBER("霧雨魔法店") = 3
;;アリスと人形たち　あと朱鷺子
;CFLAG:(NAME_TO_CHARA("魔理沙")):1 = 3
;CFLAG:(NAME_TO_CHARA("アリス")):1 = 3
;CFLAG:(NAME_TO_CHARA("上海人形")):1 = 3
;CFLAG:(NAME_TO_CHARA("蓬莱人形")):1 = 3
;CFLAG:(NAME_TO_CHARA("大江戸人形")):1 = 3
;CFLAG:(NAME_TO_CHARA("ゴリアテ人形")):1 = 3
;CFLAG:(NAME_TO_CHARA("朱鷺子")):1 = 3
;CFLAG:(NAME_TO_CHARA("霖之助")):1 = 3
;;--------幽々子--------
;COUNTRY_BOSS:4 = GET_ID(NAME_TO_CHARA("幽々子"))
;COUNTRY_COLOR:4 = 0xF5A9F2
;COUNTRY_AI_TYPE:4 = AI_内政
;
;CITY_OWNER:GET_CITYNUMBER("白玉楼") = 4
;CITY_OWNER:GET_CITYNUMBER("七千階段") = 4
;CITY_OWNER:GET_CITYNUMBER("西行妖") = 4
;;アリスと橙以外の妖々夢組
;CFLAG:(NAME_TO_CHARA("幽々子")):1 = 4
;CFLAG:(NAME_TO_CHARA("妖夢")):1 = 4
;CFLAG:(NAME_TO_CHARA("半霊")):1 = 4
;
;
;;--------紫--------
;COUNTRY_BOSS:5 = GET_ID(NAME_TO_CHARA("紫"))
;COUNTRY_COLOR:5 = 0x792B90
;COUNTRY_AI_TYPE:5 = AI_内政
;
;CITY_OWNER:GET_CITYNUMBER("八雲屋敷") = 5
;CITY_OWNER:GET_CITYNUMBER("マヨヒガ") = 5
;;八雲家
;CFLAG:(NAME_TO_CHARA("紫")):1 = 5
;CFLAG:(NAME_TO_CHARA("藍")):1 = 5
;CFLAG:(NAME_TO_CHARA("橙")):1 = 5
;CFLAG:(NAME_TO_CHARA("妖忌")):1 = 5
;
;;--------永琳--------
;COUNTRY_BOSS:6 = GET_ID(NAME_TO_CHARA("永琳"))
;COUNTRY_COLOR:6 = 0x4466FF
;COUNTRY_AI_TYPE:6 = AI_防衛
;
;CITY_OWNER:GET_CITYNUMBER("永遠亭") = 6
;CITY_OWNER:GET_CITYNUMBER("素兎の集落") = 6
;CITY_OWNER:GET_CITYNUMBER("迷いの竹林東部") = 6
;CITY_OWNER:GET_CITYNUMBER("迷いの竹林西部") = 6
;
;;永遠亭組
;CFLAG:(NAME_TO_CHARA("永琳")):1 = 6
;CFLAG:(NAME_TO_CHARA("てゐ")):1 = 6
;CFLAG:(NAME_TO_CHARA("鈴仙")):1 = 6
;CFLAG:(NAME_TO_CHARA("輝夜")):1 = 6
;
;
;;--------映姫--------
;COUNTRY_BOSS:7 = GET_ID(NAME_TO_CHARA("四季映姫"))
;COUNTRY_COLOR:7 = 0x088A08
;CITY_OWNER:GET_CITYNUMBER("彼岸") = 7
;CITY_OWNER:GET_CITYNUMBER("是非曲直庁") = 7
;CITY_OWNER:GET_CITYNUMBER("渡し舟処") = 7
;;ヅカ組
;CFLAG:(NAME_TO_CHARA("四季映姫")):1 = 7
;CFLAG:(NAME_TO_CHARA("小町")):1 = 7
;
;
;
;;--------神奈子--------
;COUNTRY_BOSS:8 = GET_ID(NAME_TO_CHARA("神奈子"))
;COUNTRY_COLOR:8 = 0x79FF4B
;COUNTRY_AI_TYPE:8 = AI_好戦
;
;CITY_OWNER:GET_CITYNUMBER("守矢神社") = 8
;CITY_OWNER:GET_CITYNUMBER("風神の湖") = 8
;CITY_OWNER:GET_CITYNUMBER("間欠泉地下センター") = 8
;;風神録組とはたて
;
;CFLAG:(NAME_TO_CHARA("早苗")):1 = 8
;CFLAG:(NAME_TO_CHARA("諏訪子")):1 = 8
;CFLAG:(NAME_TO_CHARA("神奈子")):1 = 8
;
;;--------天子--------
;COUNTRY_BOSS:9 = GET_ID(NAME_TO_CHARA("天子"))
;COUNTRY_COLOR:9 = 0x002FFF
;COUNTRY_AI_TYPE:9 = AI_好戦
;
;CITY_OWNER:GET_CITYNUMBER("桃園") = 9
;CITY_OWNER:GET_CITYNUMBER("天人の都") = 9
;CITY_OWNER:GET_CITYNUMBER("有頂天") = 9
;CITY_OWNER:GET_CITYNUMBER("竜宮の遣い専用宿舎") = 9
;CITY_OWNER:GET_CITYNUMBER("比那名居家屋敷") = 9
;;天子衣玖
;CFLAG:(NAME_TO_CHARA("天子")):1 = 9
;CFLAG:(NAME_TO_CHARA("衣玖")):1 = 9
;
;
;;--------さとり--------
;COUNTRY_BOSS:10 = GET_ID(NAME_TO_CHARA("さとり"))
;COUNTRY_COLOR:10 = 0xFA5882
;COUNTRY_AI_TYPE:10 = AI_防衛
;
;CITY_OWNER:GET_CITYNUMBER("地霊殿") = 10
;CITY_OWNER:GET_CITYNUMBER("灼熱地獄跡") = 10
;CITY_OWNER:GET_CITYNUMBER("旧都温泉街") = 10
;;地霊殿組
;CFLAG:(NAME_TO_CHARA("さとり")):1 = 10
;CFLAG:(NAME_TO_CHARA("燐")):1 = 10
;CFLAG:(NAME_TO_CHARA("空")):1 = 10
;CFLAG:(NAME_TO_CHARA("こいし")):1 = 10
;
;
;;--------白蓮--------
;COUNTRY_BOSS:11 = GET_ID(NAME_TO_CHARA("白蓮"))
;COUNTRY_COLOR:11 = 0xDF01D7
;COUNTRY_AI_TYPE:11 = AI_外交
;
;CITY_OWNER:GET_CITYNUMBER("命蓮寺") = 11
;CITY_OWNER:GET_CITYNUMBER("墓地") = 11
;;響子と小傘含む寺
;CFLAG:(NAME_TO_CHARA("響子")):1 = 11
;CFLAG:(NAME_TO_CHARA("ナズーリン")):1 = 11
;CFLAG:(NAME_TO_CHARA("一輪")):1 = 11
;CFLAG:(NAME_TO_CHARA("雲山")):1 = 11
;CFLAG:(NAME_TO_CHARA("水蜜")):1 = 11
;CFLAG:(NAME_TO_CHARA("星")):1 = 11
;CFLAG:(NAME_TO_CHARA("白蓮")):1 = 11
;
;;--------神子--------
;COUNTRY_BOSS:12 = GET_ID(NAME_TO_CHARA("神子"))
;COUNTRY_COLOR:12 = 0xFF8000
;COUNTRY_AI_TYPE:12 = AI_外交
;
;CITY_OWNER:GET_CITYNUMBER("夢殿大祀廟") = 12
;CITY_OWNER:GET_CITYNUMBER("神霊廟") = 12
```
