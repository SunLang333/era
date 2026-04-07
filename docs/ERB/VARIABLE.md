# VARIABLE.ERH — 自动生成文档

源文件: `ERB/VARIABLE.ERH`

类型: .ERH

自动摘要: —

前 200 行源码片段:

```text
﻿;全般的に使用する変数を定義(SLG部分のみで使用する変数は SLG\SLG_VARIABLE.ERH へ)

;-------------------------------------------------
;■システムに関する変数
;-------------------------------------------------
;調教の行われている場所
#DIMS TRAIN_PLACE

;マルチターゲット、ターゲットを複数取るために導入する変数
;※ターゲットを追加・削除するときは必ずADD_MTAR、DEL_MTAR関数を使うこと
#DIM MTAR, 100
#DIM MTAR_TMP, 100

;現在のターゲット数
#DIM MTAR_NUM
#DIM MTAR_NUM_TMP

;マルチプレイヤー、プレイヤーを複数取るために導入する変数
;※プレイヤーを追加・削除するときは必ずADD_MPLY、DEL_MPLY関数を使うこと
#DIM MPLY, 100
#DIM MPLY_TMP, 100

;現在のプレイヤー数
#DIM MPLY_NUM
#DIM MPLY_NUM_TMP

;捕虜調教のターゲット
#DIM SAVEDATA PRISONER_TARGET, 3

;選んだ登録キャラID
#DIM MASTER_ID

;USERCOMでこのコマンドが使用できるか
#DIM COM_ABLE_FLAG, 1000
;排他的なコマンドの自動キャンセルをするようにしている際、
;当該コマンドをマークするためのリスト
#DIM COM_CONFLICT_FLAG, 1000

;これが0だと全てのコマンドが無効になる(USERCOMにおけるコマンドの自動表示・実行を防止)
#DIM COM_ENABLE

;今回選択したコマンドの名称
#DIMS SELECTCOM_NAME

;前回選択したコマンドの名称
#DIMS PREVCOM_NAME

;COSの値を保存する関数(処理の高速化のため事前に計算)
#DIM COS_LIST, 360

;SHOP画面におけるキャラクタの表示順
#DIM SHOP_CHARA_LIST, MAX_CHARA_NUM

;それぞれ今回・前回のコマンドの実行状態(0=主人公がプレイヤー、1=主人公がターゲット、2=どちらでもない)
#DIM SELECTCOM_TYPE
#DIM PREVCOM_TYPE

;それぞれ能力値の最小と最大を定義する変数
#DIM ABL_MIN, 100
#DIM ABL_MAX, 100

;各コマンドを実行した回数
;0～999=プレイヤー 1000～1999=ターゲット 2000-2999=第三者
#DIM SAVEDATA CHARADATA COM_EXP, 3000

;各コマンドの知識
#DIM SAVEDATA CHARADATA COM_KNOWLEDGE, 1000

;各コマンドの好み度(0～3、高いほど中毒充足＋＆おまかせ実行率アップ)
;0～999=プレイヤー 1000～1999=ターゲット 2000-2999=第三者
#DIM SAVEDATA CHARADATA COM_TENDENCY, 3000

;コマンドがどのタイミングで使用できるかを示す定数
#DIM コマンド_ウフフ = 0
#DIM コマンド_日常   = 1
#DIM コマンド_育児   = 2
#DIM コマンド_共通   = 3

;性的嗜好の値がどういう嗜好を示すかを対応づける定数

#DIM SAVEDATA CHARADATA SEXUAL_PREFERENCE
;有無をビット演算で処理するので64ぶん確保
#DIM SAVEDATA CHARADATA SEXUAL_PREFERENCE_EXP, 64

#DIM CONST 性的嗜好_愛撫したい = 0
#DIM CONST 性的嗜好_奉仕したい = 1
#DIM CONST 性的嗜好_性交したい = 2
#DIM CONST 性的嗜好_道具を使いたい = 3
#DIM CONST 性的嗜好_虐げたい = 4
#DIM CONST 性的嗜好_辱めたい = 5
#DIM CONST 性的嗜好_触手で犯したい = 6
#DIM CONST 性的嗜好_愛撫されたい = 7
#DIM CONST 性的嗜好_奉仕されたい = 8
#DIM CONST 性的嗜好_性交されたい = 9
#DIM CONST 性的嗜好_道具を使われたい = 10
#DIM CONST 性的嗜好_虐げられたい = 11
#DIM CONST 性的嗜好_辱められたい = 12
#DIM CONST 性的嗜好_触手で犯されたい = 13
#DIM CONST 性的嗜好_縛られたい = 14
#DIM CONST 性的嗜好_獣と交わりたい = 15
#DIM CONST 性的嗜好_露出したい = 16
#DIM CONST 性的嗜好_催眠をかけられたい = 17
#DIM CONST 性的嗜好_春を売りたい = 18
#DIM CONST 性的嗜好_撮影されたい = 19
#DIM CONST 性的嗜好_汚されたい = 20
#DIM CONST 性的嗜好_調教されたい = 21
#DIM CONST 性的嗜好_輪姦されたい = 22
#DIM CONST 性的嗜好_妊娠したい = 23
#DIM CONST 性的嗜好_近親相姦したい = 24
#DIM CONST 性的嗜好_同性と交わりたい = 25
{
	#DIMS CONST SEXUAL_PREFERENCE_STR = 
		"愛撫したい", "奉仕したい", "性交したい", "道具を使いたい", "虐げたい", 
		"辱めたい", "触手で犯したい", "愛撫されたい", "奉仕されたい", "性交されたい", 
		"道具を使われたい", "虐げられたい", "辱められたい", "触手で犯されたい", "縛られたい", 
		"獣と交わりたい", "露出したい", "催眠をかけられたい", "春を売りたい", "撮影されたい", "汚されたい", 
		"調教されたい", "輪姦されたい", "妊娠したい", "近親相姦したい", "同性と交わりたい"
		
}


;日常フェーズのコマンド実行回数
#DIM SAVEDATA SHOP_TIME, 1

;日常フェーズの労働実行回数
#DIM SAVEDATA SHOP_WORK_COUNT, 1

;配列の読み込み順をランダムにするための配列。FISHER_YATES_SHAFFLEにてシャッフルします
#DIM SHAFFLE_ARRAY, 5000

;SELECT_CHARA_LIST_MULTIで利用する
#DIM SELECTED_CHARA, MAX_CHARA_NUM
#DIM SELECTED_CHARA_NUM

;一番長い名前の長さを意味する定数　とりあえず名前の長さで表示が崩れてるのを見つけたらこれに置き換えてみよう
#DIM CONST MAX_CHARANAME_LENGTH = STRLENS("スターサファイア") + 1

;「あてがう」時、好感度やら従属度やらを待避させておく領域。
#DIM TMP_MASTER
#DIM TMP_参加者, 10
#DIM TMP_好感度, 10
#DIM TMP_従属度, 10
#DIM TMP_依存度, 10

#DIM ランク閾値, 4, 9
#DIM CONST ランク_無 = 8
#DIM CONST ランク_G = 7
#DIM CONST ランク_F = 6
#DIM CONST ランク_E = 5
#DIM CONST ランク_D = 4
#DIM CONST ランク_C = 3
#DIM CONST ランク_B = 2
#DIM CONST ランク_A = 1
#DIM CONST ランク_S = 0
#DIM CONST ランク_ＳＬＧ = 0
#DIM CONST ランク_その他 = 1
#DIM CONST ランク_部隊 = 2
#DIM CONST ランク_性知識 = 3
#DIMS CONST ランク文字列 = "S", "A", "B", "C", "D", "E", "F", "G", "-"

;ファーストキス、処女、童貞を奪った相手を記録
#DIMS SAVEDATA CHARADATA SEXUAL_EXPERIENCE, 4
#DIMS SAVEDATA CHARADATA SEXUAL_LAST_EXPERIENCE, 4
#DIM CONST 初体験_キス = 0
#DIM CONST 初体験_童貞 = 1
#DIM CONST 初体験_処女 = 2
#DIM CONST 初体験_アナル処女 = 3

#DIMS SAVEDATA CHARADATA SEXUAL_EXPERIENCE_SITUATION, 4
#DIMS SAVEDATA CHARADATA SEXUAL_LAST_EXPERIENCE_SITUATION, 4

;賭場の資金
#DIM SAVEDATA GAMBLE_MONEY

#DIM CONST CUM_SLOT_NUM = 16
;射精部位
#DIM CONST 射精部位_無駄 = 0
#DIM CONST 射精部位_膣内 = 1
#DIM CONST 射精部位_アナル = 2
#DIM CONST 射精部位_手 = 3
#DIM CONST 射精部位_口 = 4
#DIM CONST 射精部位_胸 = 5
#DIM CONST 射精部位_足 = 6
#DIM CONST 射精部位_尻尾 = 7
#DIM CONST 射精部位_顔 = 8
#DIM CONST 射精部位_髪 = 9
#DIM CONST 射精部位_腋 = 10
#DIM CONST 射精部位_尻 = 11
#DIM CONST 射精部位_オナホ = 12
#DIM CONST 射精部位_触手 = 13
#DIM CONST 射精部位_ゴム = 14
#DIM CONST 射精部位_尿道 = 15

;その調教で射精された回数
#DIM CHARADATA CUM_GET_COUNT, CUM_SLOT_NUM
#DIM CHARADATA CUM_GET_AMOUNT, CUM_SLOT_NUM

;Mod - tracks current amount of cum instead of 'total taken this session'. Allows it to be swallowed etc. 
#DIM CHARADATA CUM_CUR_AMOUNT, CUM_SLOT_NUM

```
