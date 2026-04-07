# SHOP/SHOP_LIFE/領地探索/領地探索_通常/VISIT_TO_GRAVE_墓参り.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_LIFE/領地探索/領地探索_通常/VISIT_TO_GRAVE_墓参り.ERB`

类型: .ERB

自动摘要: functions: TERRITORY_EVENT_VISIT_TO_GRAVE_EXISTS, TERRITORY_EVENT_VISIT_TO_GRAVE_DECISION, TERRITORY_EVENT_VISIT_TO_GRAVE; UI/print

前 200 行源码片段:

```text
﻿;-------------------
;存在判定
;なにもさせないこと
;-------------------
@TERRITORY_EVENT_VISIT_TO_GRAVE_EXISTS()
#DIM 対象
RETURN 1

;-------------------
;発生判定
;-------------------
@TERRITORY_EVENT_VISIT_TO_GRAVE_DECISION(対象)
#DIM 対象
RETURN 1

;-------------------
;本体
;-------------------
@TERRITORY_EVENT_VISIT_TO_GRAVE(対象)
#DIM 対象
PRINTFORML ろくに人気もない墓場に、女性が立っているのに気づいた
PRINTFORML なんでも、この墓に彼女の夫が入っているとのことだ
PRINTFORML 粗末な墓だが、立派な墓を立てる余裕はないらしい

PRINTL
CALL ASK_MULTI_JUDGE("なにもしない", 1,"まともな墓を立ててやる", MONEY >= 3000)

IF RESULT == 0
	PRINTFORML %ANAME(対象)%にはどうすることもできない話だ
	PRINTFORML せめて女性に慰めの言葉をかけ、拠点に帰った
ELSEIF RESULT == 1
	PRINTFORML 自分が死んだらこんな墓に入れられるのだろうか
	PRINTFORML 一抹の虚しさを感じた%ANAME(対象)%は私財を投じ、墓をきちんとしたものにしてやった
	MONEY -= 3000
	CALL COLOR_PRINTW("金3000を支払った", カラー_注意)
ENDIF


RETURN 1
```
