# SLG/SCENARIO/SCENARIO_DEFAULT.ERB — 自动生成文档

源文件: `ERB/SLG/SCENARIO/SCENARIO_DEFAULT.ERB`

类型: .ERB

自动摘要: functions: SCENARIO_PLACEMENT_DEFAULT

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;シナリオ側で配置関数を記述していない場合のデフォルト配置
;-------------------------------------------------
@SCENARIO_PLACEMENT_DEFAULT

;勢力設定
COUNTRY_BOSS:0 = 0
COUNTRY_COLOR:0 = GETDEFCOLOR()


;;--------霊夢;--------
COUNTRY_BOSS:1                                = GET_ID(NAME_TO_CHARA("霊夢"))
COUNTRY_COLOR:1                               = 0x757575
CFLAG:NAME_TO_CHARA("霊夢"):所属              = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CFLAG:NAME_TO_CHARA("萃香"):所属              = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CFLAG:NAME_TO_CHARA("サニーミルク"):所属      = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CFLAG:NAME_TO_CHARA("ルナチャイルド"):所属    = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CFLAG:NAME_TO_CHARA("スターサファイア"):所属  = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CFLAG:NAME_TO_CHARA("菫子"):所属              = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CFLAG:NAME_TO_CHARA("あうん"):所属            = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CITY_OWNER:GET_CITYNUMBER("博麗大結界")       = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CITY_OWNER:GET_CITYNUMBER("博麗神社")         = GET_COUNTRY_FROM_BOSS_NAME("霊夢")
CITY_OWNER:GET_CITYNUMBER("ミズナラの木")     = GET_COUNTRY_FROM_BOSS_NAME("霊夢")

;--------レミリア--------
COUNTRY_BOSS:2                                = GET_ID(NAME_TO_CHARA("レミリア"))
COUNTRY_COLOR:2                               = 0xFF0000
CFLAG:NAME_TO_CHARA("美鈴"):所属              = GET_COUNTRY_FROM_BOSS_NAME("レミリア")
CFLAG:NAME_TO_CHARA("小悪魔"):所属            = GET_COUNTRY_FROM_BOSS_NAME("レミリア")
CFLAG:NAME_TO_CHARA("パチュリー"):所属        = GET_COUNTRY_FROM_BOSS_NAME("レミリア")
CFLAG:NAME_TO_CHARA("咲夜"):所属              = GET_COUNTRY_FROM_BOSS_NAME("レミリア")
CFLAG:NAME_TO_CHARA("レミリア"):所属          = GET_COUNTRY_FROM_BOSS_NAME("レミリア")
CFLAG:NAME_TO_CHARA("フランドール"):所属      = GET_COUNTRY_FROM_BOSS_NAME("レミリア")
CITY_OWNER:GET_CITYNUMBER("紅魔館")           = GET_COUNTRY_FROM_BOSS_NAME("レミリア")
CITY_OWNER:GET_CITYNUMBER("地下図書館")       = GET_COUNTRY_FROM_BOSS_NAME("レミリア")

;--------魔理沙--------
COUNTRY_BOSS:3                                = GET_ID(NAME_TO_CHARA("魔理沙"))
COUNTRY_COLOR:3                               = 0xE1D200
CFLAG:NAME_TO_CHARA("魔理沙"):所属            = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CFLAG:NAME_TO_CHARA("アリス"):所属            = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CFLAG:NAME_TO_CHARA("上海人形"):所属          = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CFLAG:NAME_TO_CHARA("蓬莱人形"):所属          = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CFLAG:NAME_TO_CHARA("大江戸人形"):所属        = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CFLAG:NAME_TO_CHARA("ゴリアテ人形"):所属      = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CITY_OWNER:GET_CITYNUMBER("魔法の森北部")     = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CITY_OWNER:GET_CITYNUMBER("マーガトロイド邸") = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CITY_OWNER:GET_CITYNUMBER("霧雨魔法店")       = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")
CITY_OWNER:GET_CITYNUMBER("魔法の森南部")     = GET_COUNTRY_FROM_BOSS_NAME("魔理沙")

;--------幽々子--------
COUNTRY_BOSS:4                                = GET_ID(NAME_TO_CHARA("幽々子"))
COUNTRY_COLOR:4                               = 0xF5A9F2
CFLAG:NAME_TO_CHARA("リリカ"):所属            = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CFLAG:NAME_TO_CHARA("メルラン"):所属          = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CFLAG:NAME_TO_CHARA("ルナサ"):所属            = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CFLAG:NAME_TO_CHARA("妖夢"):所属              = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CFLAG:NAME_TO_CHARA("幽々子"):所属            = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CFLAG:NAME_TO_CHARA("半霊"):所属              = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CFLAG:NAME_TO_CHARA("妖忌"):所属              = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CITY_OWNER:GET_CITYNUMBER("白玉楼")           = GET_COUNTRY_FROM_BOSS_NAME("幽々子")
CITY_OWNER:GET_CITYNUMBER("西行妖")           = GET_COUNTRY_FROM_BOSS_NAME("幽々子")

;--------紫--------
COUNTRY_BOSS:5                                = GET_ID(NAME_TO_CHARA("紫"))
COUNTRY_COLOR:5                               = 0x792B90
CFLAG:NAME_TO_CHARA("橙"):所属                = GET_COUNTRY_FROM_BOSS_NAME("紫")
CFLAG:NAME_TO_CHARA("藍"):所属                = GET_COUNTRY_FROM_BOSS_NAME("紫")
CFLAG:NAME_TO_CHARA("紫"):所属                = GET_COUNTRY_FROM_BOSS_NAME("紫")
CITY_OWNER:GET_CITYNUMBER("八雲屋敷")         = GET_COUNTRY_FROM_BOSS_NAME("紫")
CITY_OWNER:GET_CITYNUMBER("マヨヒガ")         = GET_COUNTRY_FROM_BOSS_NAME("紫")

;--------永琳--------
COUNTRY_BOSS:6                                = GET_ID(NAME_TO_CHARA("永琳"))
COUNTRY_COLOR:6                               = 0x778CFF
CFLAG:NAME_TO_CHARA("てゐ"):所属              = GET_COUNTRY_FROM_BOSS_NAME("永琳")
CFLAG:NAME_TO_CHARA("鈴仙"):所属              = GET_COUNTRY_FROM_BOSS_NAME("永琳")
CFLAG:NAME_TO_CHARA("永琳"):所属              = GET_COUNTRY_FROM_BOSS_NAME("永琳")
CFLAG:NAME_TO_CHARA("輝夜"):所属              = GET_COUNTRY_FROM_BOSS_NAME("永琳")
CITY_OWNER:GET_CITYNUMBER("永遠亭")           = GET_COUNTRY_FROM_BOSS_NAME("永琳")
CITY_OWNER:GET_CITYNUMBER("素兎の集落")       = GET_COUNTRY_FROM_BOSS_NAME("永琳")

;--------映姫--------
COUNTRY_BOSS:7                                = GET_ID(NAME_TO_CHARA("四季映姫"))
COUNTRY_COLOR:7                               = 0x088A08
CFLAG:NAME_TO_CHARA("小町"):所属              = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CFLAG:NAME_TO_CHARA("四季映姫"):所属          = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CFLAG:NAME_TO_CHARA("リリーブラック"):所属    = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CFLAG:NAME_TO_CHARA("久侘歌"):所属            = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CFLAG:NAME_TO_CHARA("瓔花"):所属              = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CFLAG:NAME_TO_CHARA("潤美"):所属              = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CITY_OWNER:GET_CITYNUMBER("是非曲直庁")       = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CITY_OWNER:GET_CITYNUMBER("渡し舟処")         = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CITY_OWNER:GET_CITYNUMBER("彼岸")             = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")
CITY_OWNER:GET_CITYNUMBER("賽の河原")         = GET_COUNTRY_FROM_BOSS_NAME("四季映姫")

;--------文--------
COUNTRY_BOSS:8                                = GET_ID(NAME_TO_CHARA("文"))
COUNTRY_COLOR:8                               = 0xce2c00
CFLAG:NAME_TO_CHARA("文"):所属                = GET_COUNTRY_FROM_BOSS_NAME("文")
CFLAG:NAME_TO_CHARA("にとり"):所属            = GET_COUNTRY_FROM_BOSS_NAME("文")
CFLAG:NAME_TO_CHARA("椛"):所属                = GET_COUNTRY_FROM_BOSS_NAME("文")
CFLAG:NAME_TO_CHARA("はたて"):所属            = GET_COUNTRY_FROM_BOSS_NAME("文")
CITY_OWNER:GET_CITYNUMBER("九天の滝")         = GET_COUNTRY_FROM_BOSS_NAME("文")
CITY_OWNER:GET_CITYNUMBER("未踏の渓谷")       = GET_COUNTRY_FROM_BOSS_NAME("文")
CITY_OWNER:GET_CITYNUMBER("玄武の沢")         = GET_COUNTRY_FROM_BOSS_NAME("文")
CITY_OWNER:GET_CITYNUMBER("妖怪の山麓")       = GET_COUNTRY_FROM_BOSS_NAME("文")

;--------神奈子--------
COUNTRY_BOSS:9                                = GET_ID(NAME_TO_CHARA("神奈子"))
COUNTRY_COLOR:9                               = 0x79FF4B
CFLAG:NAME_TO_CHARA("早苗"):所属              = GET_COUNTRY_FROM_BOSS_NAME("神奈子")
CFLAG:NAME_TO_CHARA("神奈子"):所属            = GET_COUNTRY_FROM_BOSS_NAME("神奈子")
CFLAG:NAME_TO_CHARA("諏訪子"):所属            = GET_COUNTRY_FROM_BOSS_NAME("神奈子")
CITY_OWNER:GET_CITYNUMBER("風神の湖")         = GET_COUNTRY_FROM_BOSS_NAME("神奈子")
CITY_OWNER:GET_CITYNUMBER("守矢神社")         = GET_COUNTRY_FROM_BOSS_NAME("神奈子")

;--------天子--------
COUNTRY_BOSS:10                               = GET_ID(NAME_TO_CHARA("天子"))
COUNTRY_COLOR:10                              = 0x002FFF
CFLAG:NAME_TO_CHARA("衣玖"):所属              = GET_COUNTRY_FROM_BOSS_NAME("天子")
CFLAG:NAME_TO_CHARA("天子"):所属              = GET_COUNTRY_FROM_BOSS_NAME("天子")
CFLAG:NAME_TO_CHARA("紫苑"):所属              = GET_COUNTRY_FROM_BOSS_NAME("天子")
CITY_OWNER:GET_CITYNUMBER("比那名居家屋敷")   = GET_COUNTRY_FROM_BOSS_NAME("天子")
CITY_OWNER:GET_CITYNUMBER("有頂天")           = GET_COUNTRY_FROM_BOSS_NAME("天子")
CITY_OWNER:GET_CITYNUMBER("天人の都")         = GET_COUNTRY_FROM_BOSS_NAME("天子")

;--------さとり--------
COUNTRY_BOSS:11                               = GET_ID(NAME_TO_CHARA("さとり"))
COUNTRY_COLOR:11                              = 0xFA5882
CFLAG:NAME_TO_CHARA("さとり"):所属            = GET_COUNTRY_FROM_BOSS_NAME("さとり")
CFLAG:NAME_TO_CHARA("燐"):所属                = GET_COUNTRY_FROM_BOSS_NAME("さとり")
CFLAG:NAME_TO_CHARA("空"):所属                = GET_COUNTRY_FROM_BOSS_NAME("さとり")
CFLAG:NAME_TO_CHARA("こいし"):所属            = GET_COUNTRY_FROM_BOSS_NAME("さとり")
CITY_OWNER:GET_CITYNUMBER("地霊殿")           = GET_COUNTRY_FROM_BOSS_NAME("さとり")
CITY_OWNER:GET_CITYNUMBER("灼熱地獄跡")       = GET_COUNTRY_FROM_BOSS_NAME("さとり")
CITY_OWNER:GET_CITYNUMBER("血の池地獄")       = GET_COUNTRY_FROM_BOSS_NAME("さとり")

;--------白蓮--------
COUNTRY_BOSS:12                               = GET_ID(NAME_TO_CHARA("白蓮"))
COUNTRY_COLOR:12                              = 0xDF01D7
CFLAG:NAME_TO_CHARA("ナズーリン"):所属        = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CFLAG:NAME_TO_CHARA("一輪"):所属              = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CFLAG:NAME_TO_CHARA("雲山"):所属              = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CFLAG:NAME_TO_CHARA("水蜜"):所属              = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CFLAG:NAME_TO_CHARA("星"):所属                = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CFLAG:NAME_TO_CHARA("白蓮"):所属              = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CFLAG:NAME_TO_CHARA("女苑"):所属              = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CITY_OWNER:GET_CITYNUMBER("墓地")             = GET_COUNTRY_FROM_BOSS_NAME("白蓮")
CITY_OWNER:GET_CITYNUMBER("命蓮寺")           = GET_COUNTRY_FROM_BOSS_NAME("白蓮")

;--------神子--------
COUNTRY_BOSS:13                               = GET_ID(NAME_TO_CHARA("神子"))
COUNTRY_COLOR:13                              = 0xFF8000
CFLAG:NAME_TO_CHARA("芳香"):所属              = GET_COUNTRY_FROM_BOSS_NAME("神子")
CFLAG:NAME_TO_CHARA("青娥"):所属              = GET_COUNTRY_FROM_BOSS_NAME("神子")
CFLAG:NAME_TO_CHARA("屠自古"):所属            = GET_COUNTRY_FROM_BOSS_NAME("神子")
CFLAG:NAME_TO_CHARA("布都"):所属              = GET_COUNTRY_FROM_BOSS_NAME("神子")
CFLAG:NAME_TO_CHARA("神子"):所属              = GET_COUNTRY_FROM_BOSS_NAME("神子")
CITY_OWNER:GET_CITYNUMBER("夢殿大祀廟")       = GET_COUNTRY_FROM_BOSS_NAME("神子")
CITY_OWNER:GET_CITYNUMBER("神霊廟")           = GET_COUNTRY_FROM_BOSS_NAME("神子")

;--------針妙丸--------
COUNTRY_BOSS:14                               = GET_ID(NAME_TO_CHARA("針妙丸"))
COUNTRY_COLOR:14                              = 0x00BFFF
CFLAG:NAME_TO_CHARA("わかさぎ姫"):所属        = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CFLAG:NAME_TO_CHARA("赤蛮奇"):所属            = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CFLAG:NAME_TO_CHARA("影狼"):所属              = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CFLAG:NAME_TO_CHARA("弁々"):所属              = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CFLAG:NAME_TO_CHARA("八橋"):所属              = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CFLAG:NAME_TO_CHARA("正邪"):所属              = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CFLAG:NAME_TO_CHARA("針妙丸"):所属            = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CFLAG:NAME_TO_CHARA("雷鼓"):所属              = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CITY_OWNER:GET_CITYNUMBER("輝針城")           = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CITY_OWNER:GET_CITYNUMBER("迷いの竹林南部")   = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")
CITY_OWNER:GET_CITYNUMBER("筍の里")           = GET_COUNTRY_FROM_BOSS_NAME("針妙丸")

;--------慧音（人里）--------
COUNTRY_BOSS:15                               = GET_ID(NAME_TO_CHARA("慧音"))
COUNTRY_COLOR:15                              = 0x974E00
CFLAG:NAME_TO_CHARA("慧音"):所属              = GET_COUNTRY_FROM_BOSS_NAME("慧音")
CFLAG:NAME_TO_CHARA("妹紅"):所属              = GET_COUNTRY_FROM_BOSS_NAME("慧音")
CFLAG:NAME_TO_CHARA("阿求"):所属              = GET_COUNTRY_FROM_BOSS_NAME("慧音")
CFLAG:NAME_TO_CHARA("小鈴"):所属              = GET_COUNTRY_FROM_BOSS_NAME("慧音")
CITY_OWNER:GET_CITYNUMBER("人里住宅街")       = GET_COUNTRY_FROM_BOSS_NAME("慧音")
CITY_OWNER:GET_CITYNUMBER("阿求屋敷")         = GET_COUNTRY_FROM_BOSS_NAME("慧音")
CITY_OWNER:GET_CITYNUMBER("寺子屋")           = GET_COUNTRY_FROM_BOSS_NAME("慧音")

;--------依姫--------
COUNTRY_BOSS:16                               = GET_ID(NAME_TO_CHARA("依姫"))
COUNTRY_COLOR:16                              = 0xFFF999
CFLAG:NAME_TO_CHARA("豊姫"):所属              = GET_COUNTRY_FROM_BOSS_NAME("依姫")
CFLAG:NAME_TO_CHARA("依姫"):所属              = GET_COUNTRY_FROM_BOSS_NAME("依姫")
CFLAG:NAME_TO_CHARA("レイセン"):所属          = GET_COUNTRY_FROM_BOSS_NAME("依姫")
CFLAG:NAME_TO_CHARA("サグメ"):所属            = GET_COUNTRY_FROM_BOSS_NAME("依姫")
CFLAG:NAME_TO_CHARA("月の門番"):所属          = GET_COUNTRY_FROM_BOSS_NAME("依姫")
CITY_OWNER:GET_CITYNUMBER("綿月亭")           = GET_COUNTRY_FROM_BOSS_NAME("依姫")
CITY_OWNER:GET_CITYNUMBER("桃源郷")           = GET_COUNTRY_FROM_BOSS_NAME("依姫")

;--------チルノ--------
```
