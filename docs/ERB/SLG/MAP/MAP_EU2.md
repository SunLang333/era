# SLG/MAP/MAP_EU2.ERB — 自动生成文档

源文件: `ERB/SLG/MAP/MAP_EU2.ERB`

类型: .ERB

自动摘要: functions: DRAWMAP_EU2, SET_CITY_NUM_EU2, SET_SHORTCITYNAME_EU2, SET_CITYNAME_EU2, SET_CITY_TYPE_EU2, SET_MAP_ROUTE_EU2, MAP_INIT_EU2; UI/print

前 200 行源码片段:

```text
﻿;マップ関係
[SKIPSTART]
DRAWMAPの内容を分かりやすく提示するためのコメントブロック
;-------------------------------------------------

中マップ
PRINTL :::::: Edi┓:::::::::::::::Osl━┳Sto━Hel  ;;StP━┳━Ark
PRINTL ;;;;  ;┃Yor;;◇;;;;;;;;;; Jut━Kpn;;◇;;;┏Rig┛ Nov━┓       SCYTHIA 
PRINTL ;;; Dub┛ ┃;;;;;;;;;;;;;;;┃ ;;;;;;;;;Kla┻Vil        ┃
PRINTL ;;;;;┗━Lon;;;;;;;;┏Ams━Ham     Gds┳┛    ┗┓     Msc━━Kaz━┓
PRINTL ;;;;;;;;;;┗Nrm  ┏Ant     ┗━Ber━┛┃    ┏━Min━Smo╋Rya      ┃  ┏━━┓
PRINTL ;;;;;;;;;;; ┣Par┛ ┗Kol       ┣━━War┳Lub  ┃     Kur━┓  ┏Stv┳┛;;;Nog
PRINTL ;;;;;;;; Nan┛ ┣Dij   ┗Frk━Pra     ┏Kkw━━Kie━━┓;; Rsv━┛  Ast;;;;  ┃
PRINTL ;;;◇;;;;;┃  Orl┗┳Brn━┳Mun┻Wie━Bda━┳Tra┓ ;;;Feo━┻━┓    ┗┓;;; ○
PRINTL ;;;;;;;;;;Bor    ┏Lyn    Mlo━Ven┻━━┓ ┃   ┃;;;;;;;;;;;;;┃      ○ ;; ┃
PRINTL ;;;;;;;;;;┃┗Tou┻Pro━Gen┫   ┃;;;   ┃ Beo━Buc┓;;;◇;;;; Bat━Tbi┛  ; ┃
PRINTL ;;;;;San━Nav     ┏┛;;;;;Pis┳Lav ;;; Rag┓┃┏━Byz ┏━━Trb┛   ┃   ;; ┗┓
PRINTL ;;;;;┃   ┣Ara━Bcl ;;;;;;;;;Rom━┓ ;;;;;┃┣The;;┗Ank  Siv┛    Yva┓ ;;  Khi
PRINTL ;;;;;┣━Mad━━┳┛;;;;Crs;;;;;;;Nap┓  ;;Epi;;;;;   ┃   ┃         Tab ;;   ┃
PRINTL ;;;;;Lis  ┗┓  Val;Mjc;Sar;;;;;;;;;;┃;; ;;┗Ath;;;  Iko━┻┓Ale━Mos┻Teh ○┛
PRINTL ;;;;;┗━┳Col┳┛ ;;;;;◇;;;;;;;;Sic┛;;;;;;;;;;;;;;;;;;;;;;Ant┛   ┃   ┃ ┃
PRINTL ;;;;;;   Sev━Gra ;;;;;;;;;;;;;;;;;;;;;;;;;;◇;;;Crt;;;Cyp;;; ┃Dam━┫   Isf┫
PRINTL ;;;;;;;;;┃;;;;;;;┏━━━Tun  ;;;Mal;;;;;;;;;;;;;;;;;;;;;;;┏┻┛   Bag┓   ┃
PRINTL ;;;┏━━Ceu━○━Alg       ┃;;;;;;;;MEDITERRANEM;;;;;;;;;;Jer┓┏○┛ Bas;;Hor
PRINTL ; Mor                       ┃ ;;;;;;;;;;;;;;;;;Bgz━Alx┳Sue┛○┫     ┗Mas┛;;;
PRINTL ;                           ┗━━Trp━━━━━━┛ ○━Cai  ;;  Mec┓ ○┛;;◇;;;
PRINTL                   TERRA INCOGNITA                   ┗Axm━Dbt;;◇;;Ade┛;;;;;;;;;

PRINTL :::::: 001┓:::::::::::::::002━┳003━004  ;;005━┳━006
PRINTL ;;;;  ;┃007;;◇;;;;;;;;;; 008━009;;◇;;;┏010┛ 011━┓       SCYTHIA 
PRINTL ;;; 012┛ ┃;;;;;;;;;;;;;;;┃ ;;;;;;;;;013┻014        ┃
PRINTL ;;;;;┗━015;;;;;;;;┏016━017     018┳┛    ┗┓     019━━020━┓
PRINTL ;;;;;;;;;;┗021  ┏022     ┗━023━┛┃    ┏━024━025╋026      ┃  ┏━━┓
PRINTL ;;;;;;;;;;; ┣027┛ ┗028       ┣━━029┳030  ┃     031━┓  ┏032┳┛;;;033
PRINTL ;;;;;;;; 034┛ ┣035   ┗036━037     ┏038━━039━━┓;; 040━┛  041;;;;  ┃
PRINTL ;;;◇;;;;;┃  042┗┳043━┳044┻045━046━┳047┓ ;;;048━┻━┓    ┗┓;;;200
PRINTL ;;;;;;;;;;049    ┏050    051━052┻━━┓ ┃   ┃;;;;;;;;;;;;;┃     121 ;; ┃
PRINTL ;;;;;;;;;;┃┗053┻054━055┫   ┃;;;   ┃ 056━057┓;;;◇;;;; 058━059┛  ;122
PRINTL ;;;;;060━061     ┏┛;;;;;062┳063 ;;; 064┓┃┏━065 ┏━━066┛   ┃   ;; ┗┓
PRINTL ;;;;;┃   ┣067━068 ;;;;;;;;;069━┓ ;;;;;┃┣070;;┗071  072┛    073┓ ;;  074
PRINTL ;;;;;┣━075━━┳┛;;;;076;;;;;;;077┓  ;;078;;;;;   ┃   ┃         079 ;;   ┃
PRINTL ;;;;;080  ┗┓  081;082;083;;;;;;;;;;┃;; ;;┗084;;;  085━┻┓086━087┻088123┛
PRINTL ;;;;;┗━┳089┳┛ ;;;;;◇;;;;;;;;090┛;;;;;;;;;;;;;;;;;;;;;;091┛   ┃   ┃ ┃
PRINTL ;;;;;;   092━093 ;;;;;;;;;;;;;;;;;;;;;;;;;;◇;;;094;;;095;;; ┃096━┫   097┫
PRINTL ;;;;;;;;;┃;;;;;;;┏━━━098  ;;;099;;;;;;;;;;;;;;;;;;;;;;;┏┻┛   100┓   ┃
PRINTL ;;;┏━━101━124━102      ┃;;;;;;;;MEDITERRANEM;;;;;;;;;;103┓┏125┛104;;105
PRINTL ; 106                       ┃ ;;;;;;;;;;;;;;;;;107━108┳109┛126┫    ┗110┛;;;
PRINTL ;                           ┗━━111━━━━━━┛127━112  ;;  113┓128┛;;◇;;;
PRINTL                   TERRA INCOGNITA                   ┗114━115;;◇;;116┛;;;;;;;;;


[SKIPEND]


;-------------------------------------------------
;マップの描画 ARG:0に1を指定すると軍事画面用のボタンを生成
;-------------------------------------------------
@DRAWMAP_EU2(ARG:0 = 0, ARG:1 = 0)
;メニューバー上
FOR LOCAL, 0, 3
	SIF ARG:0
		CALL COLUMN_LEFT_MENU_SHOW_SLG(LOCAL)
	PRINTL 
NEXT

;マップ描写1行目
IF ARG:0
	CALL COLUMN_LEFT_MENU_SHOW_SLG(3)
ENDIF
PRINT :::::: 
CALL DRAWCITY_BUTTON(1)
PRINT ┓:::::::::::::::
CALL DRAWCITY_BUTTON(2)
PRINT ━┳
CALL DRAWCITY_BUTTON(3)
PRINT ━
CALL DRAWCITY_BUTTON(4)
PRINT   ::
CALL DRAWCITY_BUTTON(5)
PRINT ━┳━
CALL DRAWCITY_BUTTON(6)
PRINTL 

;マップ描写2行目
IF ARG:0
	CALL COLUMN_LEFT_MENU_SHOW_SLG(4)
ENDIF
PRINT ::::  :┃
CALL DRAWCITY_BUTTON(7)
PRINT ::
CALL DRAWCITY_BUTTON(141)
PRINT :::::::::: 
CALL DRAWCITY_BUTTON(8)
PRINT ━
CALL DRAWCITY_BUTTON(9)
PRINT ::
CALL DRAWCITY_BUTTON(143)
PRINT :::┏
CALL DRAWCITY_BUTTON(10)
PRINT ┛ 
CALL DRAWCITY_BUTTON(11)
PRINT ━┓       SCYTHIA 
PRINTL 

;マップ描写3行目
IF ARG:0
	CALL COLUMN_LEFT_MENU_SHOW_SLG(5)
ENDIF
PRINT ::: 
CALL DRAWCITY_BUTTON(12)
PRINT ┛ ┃:::::::::::::::┃ :::::::::
CALL DRAWCITY_BUTTON(13)
PRINT ┻
CALL DRAWCITY_BUTTON(14)
PRINT         ┃
PRINTL 

;マップ描写4行目
IF ARG:0
	CALL COLUMN_LEFT_MENU_SHOW_SLG(6)
ENDIF
PRINT :::::┗━
CALL DRAWCITY_BUTTON(15)
PRINT ::::::::┏
CALL DRAWCITY_BUTTON(16)
PRINT ━
CALL DRAWCITY_BUTTON(17)
PRINT      
CALL DRAWCITY_BUTTON(18)
PRINT ┳┛    ┗┓     
CALL DRAWCITY_BUTTON(19)
PRINT ━━
CALL DRAWCITY_BUTTON(20)
PRINT ━┓
PRINTL 

;マップ描写5行目
IF ARG:0
	CALL COLUMN_LEFT_MENU_SHOW_SLG(7)
ENDIF
PRINT ::::::::::┗
CALL DRAWCITY_BUTTON(21)
PRINT   ┏
CALL DRAWCITY_BUTTON(22)
PRINT      ┗━
CALL DRAWCITY_BUTTON(23)
PRINT ━┛┃    ┏━
CALL DRAWCITY_BUTTON(24)
PRINT ━
CALL DRAWCITY_BUTTON(25)
PRINT ╋
CALL DRAWCITY_BUTTON(26)
PRINT       ┃  ┏━━┓
PRINTL 

;マップ描写6行目
IF ARG:0
	CALL COLUMN_LEFT_MENU_SHOW_SLG(8)
ENDIF
PRINT ::::::::::: ┣
CALL DRAWCITY_BUTTON(27)
PRINT ┛ ┗
CALL DRAWCITY_BUTTON(28)
PRINT        ┣━━
CALL DRAWCITY_BUTTON(29)
PRINT ┳
CALL DRAWCITY_BUTTON(30)
PRINT   ┃     
CALL DRAWCITY_BUTTON(31)
PRINT ━┓  ┏
CALL DRAWCITY_BUTTON(32)
PRINT ┳┛:::
CALL DRAWCITY_BUTTON(33)
PRINTL 

;マップ描写7行目
IF ARG:0
	CALL COLUMN_LEFT_MENU_SHOW_SLG(9)
ENDIF
PRINT :::::::: 
CALL DRAWCITY_BUTTON(34)
PRINT ┛ ┣
CALL DRAWCITY_BUTTON(35)
PRINT    ┗
CALL DRAWCITY_BUTTON(36)
PRINT ━
CALL DRAWCITY_BUTTON(37)
PRINT      ┏
CALL DRAWCITY_BUTTON(38)
PRINT ━━
CALL DRAWCITY_BUTTON(39)
PRINT ━━┓:: 
CALL DRAWCITY_BUTTON(40)
PRINT ━┛  
CALL DRAWCITY_BUTTON(41)
PRINT ::::  ┃
PRINTL 


;マップ描写8行目
```
