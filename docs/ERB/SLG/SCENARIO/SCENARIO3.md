# SLG/SCENARIO/SCENARIO3.ERB — 自动生成文档

源文件: `ERB/SLG/SCENARIO/SCENARIO3.ERB`

类型: .ERB

自动摘要: functions: SCENARIO_NAME_3, SCENARIO_MAPSELECT_3, SCENARIO_INTRO_3, SCENARIO_PLACEMENT_3, SCENARIO_EVENT_3; assigns RESULTS; UI/print

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;シナリオ3
;妖精大戦争（仮）
;ver0.127
;手を入れてくださってありがとうございます＆更新サボって申し訳ない
;マップ拡大に対応して初期領地を5個づつに変更
;ランダムでゲストキャラが少しの間だけ参戦するイベントを追加
;ver0.120
;登場キャラを全員からシナリオの雰囲気に合ったものだけに変更
;上記変更による登場キャラ数大幅減少に伴い、ランダムキャラの登場を選択式に
;序盤の展開を早めるために初期領地を2つに変更
;-------------------------------------------------
@SCENARIO_NAME_3
RESULTS '= "妖精大戦争"
RETURN

@SCENARIO_MAPSELECT_3
PRINTFORML
PRINTFORML このシナリオでは規模の小さなマップが利用できます。
PRINTFORML 小さなマップを利用した場合には、通常マップより高速な展開が見込まれます。
CALL SINGLE_DRAWLINE
PRINTBUTTON "[1] 小さなマップでプレイする",1
PRINT      
PRINTBUTTON "[0] 普通のマップでプレイする",0
PRINTFORML
$INPUT_LOOP
INPUT
IF RESULT > 1 || RESULT < 0
	CLEARLINE 1
	GOTO INPUT_LOOP
ENDIF

IF RESULT
	SCVAR:10 = 1
	MAPID '= "FAIRY"
ELSE
	SCVAR:10 = 0
ENDIF


@SCENARIO_INTRO_3


PRINTFORML
PRINTFORMW
PRINTFORMW 「一番強い妖精ってチルノらしいけど
PRINTFORMW 　一番賢い妖精って誰なのかな？」
PRINTFORMW 誰かが口にしたこの疑問が、幻想郷を巻き込む一大事変の幕開けとなった
PRINTFORMW 博麗神社の庭で、紅魔館の廊下で、人里の裏路地で、妖怪の山の隅っこで
PRINTFORMW 今、妖精たちの知略の限りを尽くした戦争（ごっこ）が幕を開ける
PRINTFORML 

PRINTFORML ＊注意
PRINTFORML このシナリオでは大幅に登場キャラが削減されています
PRINTFORML 仕官が足りない勢力が頻出するため、ランダムキャラの使用を推奨します
PRINTFORMW



;ランダムキャラは選択に委ねる
FLAG:OPランダムキャラ使用 = 0

@SCENARIO_PLACEMENT_3

;勢力設定
COUNTRY_BOSS:0 = 0
COUNTRY_COLOR:0 = GETDEFCOLOR()

IF SCVAR:10
	;;--------サニーミルク;--------
	COUNTRY_BOSS:1 = GET_ID(NAME_TO_CHARA("サニーミルク"))
	COUNTRY_COLOR:1 = 0xFA5882
	CITY_OWNER:GET_CITYNUMBER("悪戯しがいのある道") = 1
	CITY_OWNER:GET_CITYNUMBER("ミズナラの木") = 1
	;
	CFLAG:(NAME_TO_CHARA("サニーミルク")):1 = 1

	;;--------ルナチャイルド;--------
	COUNTRY_BOSS:2 = GET_ID(NAME_TO_CHARA("ルナチャイルド"))
	COUNTRY_COLOR:2 = 0xFFF999
	CITY_OWNER:GET_CITYNUMBER("紅魔館の門前") = 2
	CITY_OWNER:GET_CITYNUMBER("霧の湖の北側") = 2
	;
	CFLAG:(NAME_TO_CHARA("ルナチャイルド")):1 = 2

	;;--------スターサファイア;--------
	COUNTRY_BOSS:3 = GET_ID(NAME_TO_CHARA("スターサファイア"))
	COUNTRY_COLOR:3 = 0x778CFF
	CITY_OWNER:GET_CITYNUMBER("妖精の遊び場") = 3
	CITY_OWNER:GET_CITYNUMBER("茸が沢山生える森") = 3
	;
	CFLAG:(NAME_TO_CHARA("スターサファイア")):1 = 3

	;;--------リリーホワイト;--------
	COUNTRY_BOSS:4 = GET_ID(NAME_TO_CHARA("リリーホワイト"))
	COUNTRY_COLOR:4 = 0xF5A9F2
	CITY_OWNER:GET_CITYNUMBER("神社裏の桜が綺麗な場所") = 4
	CITY_OWNER:GET_CITYNUMBER("春の小経") = 4
	;
	CFLAG:(NAME_TO_CHARA("リリーホワイト")):1 = 4

	;;--------リリーブラック;--------
	COUNTRY_BOSS:5 = GET_ID(NAME_TO_CHARA("リリーブラック"))
	COUNTRY_COLOR:5 = 0x757575
	CITY_OWNER:GET_CITYNUMBER("獣道") = 5
	CITY_OWNER:GET_CITYNUMBER("八つ目鰻の屋台") = 5
	;
	CFLAG:(NAME_TO_CHARA("リリーブラック")):1 = 5

	;;--------チルノ;--------
	COUNTRY_BOSS:6 = GET_ID(NAME_TO_CHARA("チルノ"))
	COUNTRY_COLOR:6 = 0x00FFF7
	CITY_OWNER:GET_CITYNUMBER("チルノのかまくら") = 6
	CITY_OWNER:GET_CITYNUMBER("霧の湖の南側") = 6
	;
	CFLAG:(NAME_TO_CHARA("チルノ")):1 = 6

	;;--------大妖精;--------
	COUNTRY_BOSS:7 = GET_ID(NAME_TO_CHARA("大妖精"))
	COUNTRY_COLOR:7 = 0x79FF4B
	CITY_OWNER:GET_CITYNUMBER("運松爺がよく釣りに来る岬") = 7
	CITY_OWNER:GET_CITYNUMBER("香霖堂") = 7
	;
	CFLAG:(NAME_TO_CHARA("大妖精")):1 = 7
ELSE
	;;--------サニーミルク;--------
	;博麗神社スタート　赤いし主人公っぽいから
	COUNTRY_BOSS:1 = GET_ID(NAME_TO_CHARA("サニーミルク"))
	COUNTRY_COLOR:1 = 0xFA5882
	CITY_OWNER:GET_CITYNUMBER("博麗神社") = 1
	CITY_OWNER:GET_CITYNUMBER("ミズナラの木") = 1
	CITY_OWNER:GET_CITYNUMBER("裏手の池") = 1
	CITY_OWNER:GET_CITYNUMBER("裏山の道") = 1
	CITY_OWNER:GET_CITYNUMBER("裏山の湖") = 1
	;
	CFLAG:(NAME_TO_CHARA("サニーミルク")):1 = 1

	;;--------ルナチャイルド;--------
	;新聞を読んだりするので図書館のある紅魔館スタート
	COUNTRY_BOSS:2 = GET_ID(NAME_TO_CHARA("ルナチャイルド"))
	COUNTRY_COLOR:2 = 0xFFF999
	CITY_OWNER:GET_CITYNUMBER("紅魔館") = 2
	CITY_OWNER:GET_CITYNUMBER("霧の湖") = 2
	CITY_OWNER:GET_CITYNUMBER("地下図書館") = 2
	CITY_OWNER:GET_CITYNUMBER("妖精の森") = 2
	CITY_OWNER:GET_CITYNUMBER("霧の湖の畔") = 2

	;
	CFLAG:(NAME_TO_CHARA("ルナチャイルド")):1 = 2

	;;--------スターサファイア;--------
	;永遠亭スタート　たぶんモブ妖精とお姫様ごっこしてる
	COUNTRY_BOSS:3 = GET_ID(NAME_TO_CHARA("スターサファイア"))
	COUNTRY_COLOR:3 = 0x778CFF
	CITY_OWNER:GET_CITYNUMBER("永遠亭") = 3
	CITY_OWNER:GET_CITYNUMBER("迷いの竹林西部") = 3
	CITY_OWNER:GET_CITYNUMBER("迷いの竹林東部") = 3
	CITY_OWNER:GET_CITYNUMBER("素兎の集落") = 3
	CITY_OWNER:GET_CITYNUMBER("筍の里") = 3
	;
	CFLAG:(NAME_TO_CHARA("スターサファイア")):1 = 3

	;;--------リリーホワイト;--------
	;春っぽく桜のあるところ
	COUNTRY_BOSS:4 = GET_ID(NAME_TO_CHARA("リリーホワイト"))
	COUNTRY_COLOR:4 = 0xF5A9F2
	CITY_OWNER:GET_CITYNUMBER("白玉楼") = 4
	CITY_OWNER:GET_CITYNUMBER("七千階段") = 4
	CITY_OWNER:GET_CITYNUMBER("西行妖") = 4
	CITY_OWNER:GET_CITYNUMBER("八雲屋敷") = 4
	CITY_OWNER:GET_CITYNUMBER("マヨヒガ") = 4
	;
	CFLAG:(NAME_TO_CHARA("リリーホワイト")):1 = 4

	;;--------リリーブラック;--------
	;ホワイトを放っておけないのでそばにいる
	COUNTRY_BOSS:5 = GET_ID(NAME_TO_CHARA("リリーブラック"))
	COUNTRY_COLOR:5 = 0x757575
	CITY_OWNER:GET_CITYNUMBER("是非曲直庁") = 5
	CITY_OWNER:GET_CITYNUMBER("彼岸") = 5
	CITY_OWNER:GET_CITYNUMBER("幽霊待機場所") = 5
	CITY_OWNER:GET_CITYNUMBER("渡し舟処") = 5
	CITY_OWNER:GET_CITYNUMBER("三途の川") = 5
	;
	CFLAG:(NAME_TO_CHARA("リリーブラック")):1 = 5

	;;--------チルノ;--------
	;高いところが好き
	COUNTRY_BOSS:6 = GET_ID(NAME_TO_CHARA("チルノ"))
	COUNTRY_COLOR:6 = 0x00FFF7
	CITY_OWNER:GET_CITYNUMBER("桃園") = 6
	CITY_OWNER:GET_CITYNUMBER("天人の都") = 6
	CITY_OWNER:GET_CITYNUMBER("比那名居家屋敷") = 6
	CITY_OWNER:GET_CITYNUMBER("竜宮の遣い専用宿舎") = 6
	CITY_OWNER:GET_CITYNUMBER("有頂天") = 6
	;
	CFLAG:(NAME_TO_CHARA("チルノ")):1 = 6

	;;--------大妖精;--------
	;チルノを放っておけないのでそばにいる
```
