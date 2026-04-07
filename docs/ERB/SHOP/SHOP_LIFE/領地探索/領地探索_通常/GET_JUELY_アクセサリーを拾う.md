# SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_JUELY_アクセサリーを拾う.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/GET_JUELY_アクセサリーを拾う.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_GET_JUERY_EXISTS, TERRITORY_EVENT_GET_JUERY_DECISION, TERRITORY_EVENT_GET_JUERY; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_GET_JUERY_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_GET_JUERY_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_GET_JUERY(対象)
#DIM 対象

PRINTFORML 探索中、落とし物を拾った
PRINTFORML キラリと光る素敵なアクセサリーだ
PRINTFORML 
CALL ASK_YN("店に売る", "衛兵に届ける")

IF RESULT == 0
	PRINTFORML 売り払って小遣いにしようと、近くの宝飾店に向かった
	PRINTFORML が、店主にすごい剣幕で怒鳴られた
	PRINTFORML まさにこの店から数日前に盗まれた品だったらしい
	PRINTFORML どうにか誤解を解いたが、疲れてしまった
	CALL ADD_COOLTIME(対象, 1)
ELSEIF RESULT == 1
	PRINTFORML ネコババはよくない
	PRINTFORML 衛兵に届けた
ENDIF

RETURN 1
```
