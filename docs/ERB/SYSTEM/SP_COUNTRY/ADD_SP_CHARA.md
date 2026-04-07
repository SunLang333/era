# SYSTEM/SP_COUNTRY/ADD_SP_CHARA.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/ADD_SP_CHARA.ERB`

类型: .ERB

自动摘要: functions: SP_COUNTRY_ABL_MODIFIER, ADD_SP_CHARA, SP_COUNTRY_CHARA_SET_TECHNOLOGY; definition/data

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;渡された勢力定数の勢力の強さから、SLG能力への補正値を決定する
;-------------------------------------------------	
@SP_COUNTRY_ABL_MODIFIER(勢力定数)
#FUNCTION
#DIM 勢力定数
SELECTCASE SP_COUNTRY_RANK:勢力定数
    CASE 5
        RETURNF 8
    CASE 4
        RETURNF 6
    CASE 3
        RETURNF 4
    CASE 2
        RETURNF 3
    CASE 1
        RETURNF 2
ENDSELECT


;-------------------------------------------------
;desc  :特殊勢力キャラのひな型を追加する。ADD_VOID_CHARAのラッパー。
;param :勢力:勢力番号
;param :ボス:ボスを生成する
;param :ループ:通常キャラ生成時、FORループのループ変数を渡す（野盗A, BのAとかBとかの部分の処理用）
;return:生成したキャラ番号
;-------------------------------------------------
@ADD_SP_CHARA(勢力, ボス, ループ)
#DIM 勢力
#DIM 勢力定数
#DIM ボス
#DIM ループ
#DIM 対象

勢力定数 = SP_COUNTRY_TO_CONST(勢力)

CALL ADD_VOID_CHARA()
対象 = RESULT

IF ボス
    IF SP_COUNTRY_GENDER:勢力定数 >= 0
        TALENT:対象:性別 = SP_COUNTRY_GENDER:勢力定数
    ELSEIF GROUPMATCH(勢力定数, 特殊勢力_サキュバス)
        TALENT:対象:性別 = 2
    ELSE
        TALENT:対象:性別 = 0
    ENDIF
ELSEIF SP_COUNTRY_GENDER:勢力定数 >= 0
    TALENT:対象:性別 = SP_COUNTRY_GENDER:勢力定数
ELSE
    IF 勢力定数 == 特殊勢力_サキュバス
        SELECTCASE RAND:100
            CASE IS < 40
                TALENT:対象:性別 = 1
            CASE IS < 80
                TALENT:対象:性別 = 2
            CASE IS < 90
                TALENT:対象:性別 = 4
            CASE IS < 100
                TALENT:対象:性別 = 5
        ENDSELECT
    ELSEIF GROUPMATCH(勢力定数, 特殊勢力_外来人, 特殊勢力_自警団, 特殊勢力_触手, 特殊勢力_狂信者)
        SELECTCASE RAND:100
            CASE IS < 60
                TALENT:対象:性別 = 0
            CASE IS < 90
                TALENT:対象:性別 = 1
            CASE IS < 100
                TALENT:対象:性別 = 2
        ENDSELECT
    ENDIF
ENDIF

;名前設定
IF ボス
    SELECTCASE SP_COUNTRY_BOSSNAME:勢力定数
        CASE 0
            SELECTCASE 勢力定数
                CASE 特殊勢力_野盗
                    NAME:対象     = 野盗
                    CALLNAME:対象 = 野盗
                    CSTR:対象:1   = 野盗
                    CSTR:対象:3   = ヤトウ
                    CSTR:対象:4   = ヤトウ
                    CSTR:対象:6   = ヤトウ
                CASE 特殊勢力_ホフゴブリン
                    NAME:対象     = ホフゴブリン
                    CALLNAME:対象 = ホフゴブリン
                    CSTR:対象:1   = ホフゴブリン
                    CSTR:対象:3   = ホフゴブリン
                    CSTR:対象:4   = ホフゴブリン
                    CSTR:対象:6   = ホフゴブリン
                CASE 特殊勢力_外来人
                    NAME:対象     = 外来人
                    CALLNAME:対象 = 外来人
                    CSTR:対象:1   = 外来人
                    CSTR:対象:3   = ガイライジン
                    CSTR:対象:4   = ガイライジン
                    CSTR:対象:6   = ガイライジン
                CASE 特殊勢力_触手
                    NAME:対象     = 触手兵
                    CALLNAME:対象 = 触手兵
                    CSTR:対象:1   = 触手兵
                    CSTR:対象:3   = ショクシュヘイ
                    CSTR:対象:4   = ショクシュヘイ
                    CSTR:対象:6   = ショクシュヘイ
                CASE 特殊勢力_自警団
                    NAME:対象     = 自警団員
                    CALLNAME:対象 = 自警団員
                    CSTR:対象:1   = 自警団員
                    CSTR:対象:3   = ジケイダンイン
                    CSTR:対象:4   = ジケイダンイン
                    CSTR:対象:6   = ジケイダンイン
                CASE 特殊勢力_サキュバス
                    IF IS_MALE(対象)
                        NAME:対象     = インキュバス
                        CALLNAME:対象 = インキュバス
                        CSTR:対象:1   = インキュバス
                        CSTR:対象:3   = インキュバス
                        CSTR:対象:4   = インキュバス
                        CSTR:対象:6   = インキュバス
                    ELSE
                        NAME:対象     = サキュバス
                        CALLNAME:対象 = サキュバス
                        CSTR:対象:1   = サキュバス
                        CSTR:対象:3   = サキュバス
                        CSTR:対象:4   = サキュバス
                        CSTR:対象:6   = サキュバス
                    ENDIF
                CASE 特殊勢力_狂信者
                    NAME:対象     = 狂信者
                    CALLNAME:対象 = 狂信者
                    CSTR:対象:1   = 狂信者
                    CSTR:対象:3   = キョウシンシャ
                    CSTR:対象:4   = キョウシンシャ
                    CSTR:対象:6   = キョウシンシャ
            ENDSELECT
        CASE 1
            SELECTCASE 勢力定数
                CASE 特殊勢力_野盗
                    NAME:対象     = 野盗首領
                    CALLNAME:対象 = 野盗首領
                    CSTR:対象:1   = 野盗首領
                    CSTR:対象:3   = ヤトウシュリョウ
                    CSTR:対象:4   = ヤトウシュリョウ
                    CSTR:対象:6   = ヤトウシュリョウ
                CASE 特殊勢力_ホフゴブリン
                    NAME:対象     = ゴブリンキング
                    CALLNAME:対象 = ゴブリンキング
                    CSTR:対象:1   = ゴブリンキング
                    CSTR:対象:3   = ゴブリンキング
                    CSTR:対象:4   = ゴブリンキング
                    CSTR:対象:6   = ゴブリンキング
                CASE 特殊勢力_外来人
                    NAME:対象     = 研究室長
                    CALLNAME:対象 = 研究室長
                    CSTR:対象:1   = 研究室長
                    CSTR:対象:3   = ケンキュウシツチョウ
                    CSTR:対象:4   = ケンキュウシツチョウ
                    CSTR:対象:6   = ケンキュウシツチョウ
                CASE 特殊勢力_触手
                    NAME:対象     = 触手兵長
                    CALLNAME:対象 = 触手兵長
                    CSTR:対象:1   = 触手兵長
                    CSTR:対象:3   = ショクシュヘイチョウ
                    CSTR:対象:4   = ショクシュヘイチョウ
                    CSTR:対象:6   = ショクシュヘイチョウ
                CASE 特殊勢力_自警団
                    NAME:対象     = 自警団長
                    CALLNAME:対象 = 自警団長
                    CSTR:対象:1   = 自警団長
                    CSTR:対象:3   = ジケイダンチョウ
                    CSTR:対象:4   = ジケイダンチョウ
                    CSTR:対象:6   = ジケイダンチョウ
                CASE 特殊勢力_サキュバス
                    IF IS_MALE(対象)
                        NAME:対象     = エルダーインキュバス
                        CALLNAME:対象 = エルダーインキュバス
                        CSTR:対象:1   = エルダーインキュバス
                        CSTR:対象:3   = エルダーインキュバス
                        CSTR:対象:4   = エルダーインキュバス
                        CSTR:対象:6   = エルダーインキュバス
                    ELSE
                        NAME:対象     = サキュバスクイーン
                        CALLNAME:対象 = サキュバスクイーン
                        CSTR:対象:1   = サキュバスクイーン
                        CSTR:対象:3   = サキュバスクイーン
                        CSTR:対象:4   = サキュバスクイーン
                        CSTR:対象:6   = サキュバスクイーン
                    ENDIF
                CASE 特殊勢力_狂信者
                    NAME:対象     = 教祖
                    CALLNAME:対象 = 教祖
                    CSTR:対象:1   = 教祖
                    CSTR:対象:3   = キョウソ
                    CSTR:対象:4   = キョウソ
                    CSTR:対象:6   = キョウソ
            ENDSELECT
        CASE 2
            TARGET = 対象
```
