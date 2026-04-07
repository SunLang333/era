# SHOP/SHOP_SLG/SHOP_SLG52_能力一覧.ERB — 自动生成文档

源文件: `ERB/SHOP/SHOP_SLG/SHOP_SLG52_能力一覧.ERB`

类型: .ERB

自动摘要: functions: SHOP_SLG_NAME52, SHOP_SLG_CHECK52, SHOP_SLG_EVENTBUY52; assigns RESULTS

前 200 行源码片段:

```text
﻿;-------------------------------------------------
;「能力一覧」の名称
;-------------------------------------------------
@SHOP_SLG_NAME52
RESULTS:0 '= "能力一覧"

;-------------------------------------------------
;「能力一覧」の選択可否
;-------------------------------------------------
@SHOP_SLG_CHECK52
RETURN 1

;-------------------------------------------------
;「能力一覧」の左カラムメニューの入力処理
;-------------------------------------------------
@SHOP_SLG_EVENTBUY52
;観戦中は全てで
SIF FLAG:観戦モード
	FLAG:能力表示フィルタ = 3
CALL CREATE_SELECTOR_SORT_LIST
CALL SHOP_LIFE_CHARA_TABLE
RETURN 1

```
