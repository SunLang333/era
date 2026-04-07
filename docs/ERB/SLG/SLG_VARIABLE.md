# SLG/SLG_VARIABLE.ERH — 自动生成文档

源文件: `ERB/SLG/SLG_VARIABLE.ERH`

类型: .ERH

自动摘要: —

前 200 行源码片段:

```text
﻿;SLG部分に使用する変数を定義(全般的に使用する変数は VARIABLE.ERH へ)

;-------------------------------------------------
;■定数
;-------------------------------------------------
;都市の最大数
#DIM CONST MAX_CITY = 170

;勢力の最大数
#DIM CONST MAX_COUNTRY = 40

;各勢力が持つ部隊の最大数
#DIM CONST MAX_UNIT = 10

;各部隊につける武将の最大数
;全部がきちんと定数化されてる保証はないからこれだけを変更しても武将の最大数を増やせたりしないよ 定数関係は全部同じだよ
#DIM CONST MAX_UNIT_COMMANDER = 3

;各都市につける武将の最大数
#DIM CONST MAX_CITY_COMMANDER = 2

;同盟条約の最大数
#DIM CONST MAX_TREATY_A = 70

;連合の最大数
#DIM CONST MAX_TREATY_U = 5

;停戦条約の最大数
#DIM CONST MAX_TREATY_C = 100

;条約に含まれる国家の最大数
#DIM CONST MAX_TREATY_COUNTRY = MAX_COUNTRY

;シナリオの最大数
#DIM CONST SCENARIO_NUMBER = 20

;-------------------------------------------------
;■システムに関する変数
;-------------------------------------------------
;情報表示の対象となっている都市
#DIM SHOWN_CITY

;開始からの外交・編成禁止期間
#DIM CONST SLG_PP = 3, 7, 10

;使用するマップ
#DIMS SAVEDATA MAPID = "DEFAULT"

;現在のシナリオID
#DIMS SAVEDATA SCENARIOID = ""

;マップ準備済み
#DIM MAPREADY = 0

;シナリオのIDと選択用数値
#DIMS SCENARIO_ID,     SCENARIO_NUMBER
#DIM  SCENARIO_SELECT, SCENARIO_NUMBER

;そのターンの投資回数
#DIM SAVEDATA NOW_INVEST


;-------------------------------------------------
;■都市に関する変数 ※0番の都市は未定義で固定
;-------------------------------------------------
;都市から直接繋がる他の都市・中継点を設定する変数
#DIM CITY_ROUTE, MAX_CITY, 10

;都市のタイプ 0=都市 1=中継点
#DIM CITY_TYPE, MAX_CITY

;都市の経済規模(内部数値・表示の100倍の値)
#DIM SAVEDATA CITY_ECONOMY, MAX_CITY

;都市の経済規模の上限値(内部数値・表示の100倍の値)
#DIM SAVEDATA CITY_ECONOMY_LIMIT, MAX_CITY

;都市の防衛兵力
#DIM SAVEDATA CITY_SOLDIER,      MAX_CITY
#DIM SAVEDATA CITY_SOLDIER_PREV, MAX_CITY

;都市の防御倍率(内部数値・表示の100倍の値)
#DIM SAVEDATA CITY_GUARD, MAX_CITY

;都市を所持する勢力
#DIM SAVEDATA CITY_OWNER, MAX_CITY

;都市の守将ID(16bitずつ2人まで)
#DIM SAVEDATA CITY_COMMANDER, MAX_CITY

;都市の建造物
#DIM SAVEDATA CITY_DEVELOPMENT, MAX_CITY
;都市のカラー設定(一時的なもの)
#DIM CITY_COLOR, MAX_CITY

;都市の疲労度。都市上での戦闘・攻撃で増える
#DIM SAVEDATA CITY_TIRED_COUNT, MAX_CITY

;都市がこのターン攻撃を受けたか
#DIM CITY_IS_ATTACKED, MAX_CITY

;都市上で直前までのターンの疲労度。
#DIM SAVEDATA PAST_CITY_TIRED_COUNT, MAX_CITY

;都市の名前
#DIMS CITY_NAME, MAX_CITY
#DIMS CITY_NAME_SHORT, MAX_CITY

;都市（非抜け道）の数
#DIM CITY_NUM

;そのターン都市に投資したフラグ
#DIM CITY_INVESTED, MAX_CITY

;建造物の建造物ID
#DIM CONST 建造物_兵舎 = 1
#DIM CONST 建造物_独占市場 = 2
#DIM CONST 建造物_弓櫓 = 3
#DIM CONST 建造物_武芸塾 = 4
#DIM CONST 建造物_戦略塾 = 5
#DIM CONST 建造物_知略塾 = 6
#DIM CONST 建造物_湯治場 = 7
#DIM CONST 建造物_研究所 = 8
#DIM CONST 建造物_本拠地 = 9
#DIM CONST 建造物_忍びの里 = 10
#DIM CONST 建造物_集積所 = 11
#DIM CONST 建造物_税務署 = 12
#DIM CONST 建造物_大宴会場 = 13
#DIM CONST 建造物_醸造所 = 14



;-------------------------------------------------
;■勢力に関する変数 ※0番の勢力は無所属で固定
;-------------------------------------------------
;頭首のキャラID(勢力の存在判定にも使用)
#DIM SAVEDATA COUNTRY_BOSS, MAX_COUNTRY

;勢力のカラー
#DIM SAVEDATA COUNTRY_COLOR, MAX_COUNTRY

;勢力の政策
#DIM SAVEDATA COUNTRY_POLICY, MAX_COUNTRY

;遊撃兵力
#DIM SAVEDATA COUNTRY_SOLDIER, MAX_COUNTRY

;連合の討伐対象にならない期間
#DIM SAVEDATA COUNTRY_NOTARGET_TERM, MAX_COUNTRY

;防衛部隊を作成したことを示すフラグ
#DIM IS_PROTECTED

;外交禁止フラグ。このフラグを立てると互いに一切の外交が不可能になる
;放浪状態での士官も不可。統一後のエンディングメッセージも表示されない
#DIM SAVEDATA COUNTRY_IS_CLOSED, MAX_COUNTRY

;イベント国家の識別フラグ
#DIM SAVEDATA COUNTRY_EVENT_ID, MAX_COUNTRY

;部隊兵力
#DIM SAVEDATA UNIT_SOLDIER,      MAX_COUNTRY, MAX_UNIT
#DIM SAVEDATA UNIT_SOLDIER_PREV, MAX_COUNTRY, MAX_UNIT

;部隊の所在都市番号
#DIM SAVEDATA UNIT_POSITION, MAX_COUNTRY, MAX_UNIT

;部隊の移動目標都市番号
#DIM SAVEDATA UNIT_TARGET, MAX_COUNTRY, MAX_UNIT

;部隊の将ID(16bitずつ3人まで)
#DIM SAVEDATA UNIT_COMMANDER, MAX_COUNTRY, MAX_UNIT


;部隊の連戦カウント
#DIM SAVEDATA UNIT_TIRED_COUNT, MAX_COUNTRY, MAX_UNIT

;部隊の都市占領フラグ
#DIM SAVEDATA UNIT_CAPTURE_CITY, MAX_COUNTRY, MAX_UNIT

;対象国家を選択するための一時的なフラグ
#DIM COUNTRY_IS_SELECTED, MAX_COUNTRY

;連合に参加する予定の勢力の記録用
#DIM COUNTRY_IS_UNION, MAX_COUNTRY

;各国家の同盟候補勢力の記録用
#DIM COUNTRY_PROSPECT_A, MAX_COUNTRY, MAX_COUNTRY

;各国家の停戦候補勢力の記録用
#DIM COUNTRY_PROSPECT_C, MAX_COUNTRY, MAX_COUNTRY

;同盟成否判定。成否の理由と必要な要求の重さも記録
;0=不成立、1=無条件、2=要求(軽)、3=要求(中)、4=要求(重)、5=無条件(友好)、6=不成立(非隣接)
#DIM COUNTRY_REQUEST_RATE_A, MAX_COUNTRY, MAX_COUNTRY

;停戦成否判定。成否の理由と必要な要求の重さも記録
;0=不成立、1=無条件、2=要求(軽)、3=要求(中)、4=要求(重)、5=無条件(友好)、6=不成立(非隣接)
#DIM COUNTRY_REQUEST_RATE_C, MAX_COUNTRY, MAX_COUNTRY

```
