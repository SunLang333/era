# 口上/09 咲夜口上/COMF_K9/NOON_K9/KOJO_NOON_K9.ERB — 自动生成文档

源文件: `ERB/口上/09 咲夜口上/COMF_K9/NOON_K9/KOJO_NOON_K9.ERB`

类型: .ERB

自动摘要: functions: KOJO_K9_NOON

前 200 行源码片段:

```text
﻿;─────────────────────────────────────── 
;●コマンド実行前日常300～
;─────────────────────────────────────── 
@KOJO_K9_NOON(咲夜_対象,前後)
#DIM 咲夜
#DIM 咲夜_対象
#DIMS 前後
#DIMS 咲夜口上実対カテゴリ

IF !咲夜_対象
	咲夜_対象 = MASTER
ENDIF

;リセット
咲夜 = NAME_TO_CHARA("咲夜")
咲夜口上実対カテゴリ '= ""

;─────────────────────────────────────── 
;●詳細カテゴリ決定
;─────────────────────────────────────── 
IF IS_MPLY(咲夜)
	咲夜口上実対カテゴリ '= "実行"
ELSE
	咲夜口上実対カテゴリ '= "咲夜_対象"
ENDIF

;─────────────────────────────────────── 
;●詳細カテゴリによる分岐
;─────────────────────────────────────── 
IF 咲夜口上実対カテゴリ == "実行"
	;前文か後文か
	IF 前後 == "前"
		CALL KOJO_K9_NOON_BEFORE_PLAYER(咲夜_対象)
	ELSEIF 前後 == "後"
		CALL KOJO_K9_NOON_AFTER_PLAYER(咲夜_対象)
	ENDIF
ELSEIF 咲夜口上実対カテゴリ == "咲夜_対象"
	;前文か後文か
	IF 前後 == "前"
		CALL KOJO_K9_NOON_BEFORE_TARGET(咲夜_対象)
	ELSEIF 前後 == "後"
		CALL KOJO_K9_NOON_AFTER_TARGET(咲夜_対象)
	ENDIF
ENDIF

RESETCOLOR
RETURN RESULT

```
