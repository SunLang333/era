# 口上/75 水蜜口上/DAILY/_KOJO_DAILY_K75_DERIVATION_ダミー.ERB — 自动生成文档

源文件: `ERB/口上/75 水蜜口上/DAILY/_KOJO_DAILY_K75_DERIVATION_ダミー.ERB`

类型: .ERB

自动摘要: functions: KOJO_DAILY_K75_DERIVATION_DUMMY1_DISABLE, KOJO_DAILY_K75_DERIVATION_DUMMY1_DECISION, KOJO_DAILY_K75_DERIVATION_DUMMY1

前 200 行源码片段:

```text
﻿;---------------------
;対応するデイリーのDISABLEを返す。設定しない場合、イベントは発生しない。
;---------------------
@KOJO_DAILY_K75_DERIVATION_DUMMY1_DISABLE(対象)
#DIM 対象
RETURN KOJO_DAILY_GET_DISABLE_CONFIG(対象, "FROM_THE_DEEP")


;---------------------
;発生判定
;〇期以降になると発生するとか、デイリー側で利用している変数が-1だったら起こさない　みたいなはじき方をするときに使う
;---------------------
@KOJO_DAILY_K75_DERIVATION_DUMMY1_DECISION(対象)
#DIM 対象
#DIM 白蓮

白蓮 = NAME_TO_CHARA("白蓮")
SIF 白蓮 == -1
	RETURN 0

;開始イベント、終了イベント後ならだめ
SIF GROUPMATCH(KDVAR:対象:水蜜_仄暗い水の底から, 1, 2)
	RETURN 0
;白蓮が同じ勢力ならカウントは抑えられる
IF CFLAG:白蓮:所属 == CFLAG:対象:所属 && CFLAG:白蓮:捕虜先 == 0
	KDVAR:対象:水蜜_水底爆発カウント = 0
	RETURN 0
ENDIF

KDVAR:対象:水蜜_水底爆発カウント ++


RETURN 0

;---------------------
;本体
;---------------------
@KOJO_DAILY_K75_DERIVATION_DUMMY1(対象)
#DIM 対象
;なにもしない
RETURN 1
```
