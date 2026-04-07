# 口上/149 女苑口上/DAILY/_KOJO_DAILY_K149_いただきストリート.ERB — 自动生成文档

源文件: `ERB/口上/149 女苑口上/DAILY/_KOJO_DAILY_K149_いただきストリート.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K149_ITASUTO_RATE, KOJO_DAILY_K149_ITASUTO_DECISION, KOJO_DAILY_K149_ITASUTO_GENRE, KOJO_DAILY_K149_ITASUTO; UI/print

前 200 行源码片段:

```text
﻿;---------------------
;基本的な発生確率(1000分率 100で10%)
;これにコンフィグ項目の発生頻度がかけられるので、必ずしもこの通りにはならない
;---------------------
@KOJO_DAILY_K149_ITASUTO_RATE(対象)
#DIM 対象
RETURN 40


;---------------------
;確率以外の発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K149_ITASUTO_DECISION(対象)
#DIM 対象
SIF FLAG:クリアフラグ
    RETURN 0
RETURN CHECK_KOJO_DAILY_HAPPEN(対象, 1, 0)

;---------------------
;ジャンル
;コンフィグ設定で使用
;---------------------
@KOJO_DAILY_K149_ITASUTO_GENRE(対象)
#DIM 対象
RETURN デイリー_ジャンル_その他

;---------------------
;本体
;イベントが発生した場合は1、発生しなかった場合は0を返す
;発生しなかったというのは例えば、特定条件を満たすキャラからランダムに一人選ぶデイリーで、そもそもその条件を満たすキャラが一人もいないみたいなとき
;旧仕様で作ったことある人向けにいうと「旧仕様のデイリー本体冒頭で-1を返すような状況」
;---------------------
@KOJO_DAILY_K149_ITASUTO(対象)
#DIM 対象

PRINTFORML 「あはは！　ちょろいもんだわ！」
PRINTFORMW %ANAME(対象)%がどこからか富を巻き上げてきたらしい……
LOCAL = RAND(3000, 5000)
MONEY:(CFLAG:MASTER:所属) += LOCAL
CALL COLOR_PRINTW(@"国庫の金が{LOCAL}増えた", カラー_注意)


RETURN 1
```
