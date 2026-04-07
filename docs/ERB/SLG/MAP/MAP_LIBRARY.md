# SLG/MAP/MAP_LIBRARY.ERH — 自动生成文档

源文件: `ERB/SLG/MAP/MAP_LIBRARY.ERH`

类型: .ERH

自动摘要: —

前 200 行源码片段:

```text
﻿;戦略画面のマップ表示の際にメニューを表示するため行数を記録する
;todo:ほかの処理を調べてそれらと変数を共通化したい
#DIM DRAWMAP_LINECOUNT

;マップを表示するときに左側に表示するMENUBARを選択する変数
#DIM DRAWMAP_MENUBARTYPE
#DIM CONST DRAWMAP_MENUBARTYPE_SLGMENU = 1
#DIM CONST DRAWMAP_MENUBARTYPE_DEBUGMENU = 2

;マップを表示するとき都市名から自動で地図を補完する変数
#DIM DRAWMAP_AUTO_READ_CITYNAMES
```
