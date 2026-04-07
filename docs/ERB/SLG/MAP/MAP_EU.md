# SLG/MAP/MAP_EU.ERB — 自动生成文档

源文件: `ERB/SLG/MAP/MAP_EU.ERB`

类型: .ERB

自动摘要: functions: DRAWMAP_EU, SET_CITY_NUM_EU, SET_SHORTCITYNAME_EU, SET_CITYNAME_EU, SET_CITY_TYPE_EU, SET_MAP_ROUTE_EU, MAP_INIT_EU; UI/print

前 200 行源码片段:

```text
﻿;マップ関係
[SKIPSTART]
DRAWMAPの内容を分かりやすく提示するためのコメントブロック
;-------------------------------------------------
;マップの外観(ダミー関数)
;-------------------------------------------------

PRINTL :::::: Edi┓::::::::::Gtb::Kil━Kpn;◇;;Lap;;;;;;  Nbg━┓                                 1 2 3 4 5 6
PRINTL ;;;;Dub┛;Yok;;◇;;;;;;;;  ┃;;;;;;;;;;;;;;;;Rig━┛    ┃         SCYTHIA 　　  　        7 8 9
PRINTL ;;;;;;┗Lon┛;;;;;;;;;;┏━Hum   Pzn━Gds━┓┃┗┓    Msc━Kzn┓                 　　　 　10 11 12 13 14 15　　 　
PRINTL ;;;;;;;;;;┃;;;; ;┏━Fri   ┗Brd┛┃┏┛ Pin┛ Min━Smo┛   ┃Che━Ryz┓　　　　　　　    16 17 18 19 20 21 22 
PRINTL ;;;;;;;;; Nrm  ┏Ant   ┃  Frk┛   Wrc┓   ┃   ┃   ┗Ksk   ┃  　┏┛┃　　　             23 24 25 26 27 
PRINTL ;;;;;;;;  ┃┗Par┓　　Nan┛ ┗Bay┛  Krw━Lbl━Luc━┓ ┗┓┏Bor━Smr━Vlg      ;;　       28 29 30 31 32 33 34 35 36 
PRINTL ;;;;;;;;;;┃  ┃ Djn ┏┛┗┓   ┃    ┃    ┗Lib━━Kiv━Rsv┃    ┃  ┗━Ast┓ ;　　　　 37 38 39 40 41
PRINTL ;;;;◇;;;;;Bor┛ ┃┗Lyn━Bln┏Vie━━Win┏━━┛    ┃      ┃┏━Srk       ;;kyz    　   42 43 44 45 46 47 48
PRINTL ;;;;;;;;;;;;┃   ┃   ┗┓┗Mln━┓   ┗Bda━┓   ┏Jas┓┏━Cfa ;; ┗┓    ;;;;┃　　　   49 50 51 52
PRINTL ;;;;;;;;;;;;Tls━Mls━━Gen━┛ Vnc━┓  ┃ Bgr━Bcr━━Bar;;;;;;◇;; Bat    ;;;○         53 54 55 56 57 58 59 60 131
PRINTL ;;;;Len━Zgz┛   ┃;;;;;;┗Psa┓┃　Rgs━Zgr ┗Spi┛    ┃;;;;;;;;;;;;┃┗Bak::;┃         62 63 64 65 66 67 68
PRINTL ;;;;┃   ┃    ┏┛;;;;Crs;; ┏Lvn;;;;┗┓┗Tes┛┗Edi━Cns ┏Snp━Trb┛   ┃;;Kzl         69 70 71 72 73 74 75 76
PRINTL ;;;;Pol━Tld━Bcl;;;;;;;;;;;;Rom  ;;;;;;Tir  ┃ ;;;;;;;;;┗Anc┗┓ ┗┓    Tab;;┃    　   77 78 79 80 81 82 83
PRINTL ;;;; ┃   ┃   ┃;;Plm;;Sar;;;┗Npl ;;;;;┗━Per;;;;;;;;;;;;┗━Sis┓┃┏Mos┛  ┃         84 85 86 87 88 89
PRINTL ;;;;Lsb   ┗Col┛;;;;;◇;;;;;;;;┗Trn ;;;;;;;  ┃ ;;;;;;Rod;;;;;;;;;Ant┛┃┗Ham┛         90 91 92 93 94 95
PRINTL ;;;;;┗━Grn┛;;;;;;;;;;;;;;;;;Src┛;;;;;;;;;; Atn;;;;;;;;;;;;;Cyp;;;┃Dam 　┗Jsf　　     96 97 98 99 100 101
PRINTL ;;;;;;;;;┃;;;;;;;;┏━━Tun;;;;;;;;;;;;;;;;;;;;;;;;;;◇;;;;;;;;;;;;Jer┛┗┓  ┃          102 103 
PRINTL ;;;┏━━Fez━○━Alg     ┃;;;MEDITERRANEM;;;;;;;;;;;;;;;;;;;;;;;;;┃    Bgd━Srz         104 132 106 107 108  
PRINTL ;;Mur                     ┃ ;;;;;;;;;;;;;;;;;Brc━━━Mtr━━Alx━Aqb━Kfa┛  ;;;          109 110 111 112 113 114
PRINTL ;;                        ┗━━Trp━━━━━━┛       ┗Cir┛     ;;; ┃     ;;;         115 116
PRINTL ;                 TERRA INCOGNITA                          ┗○━Axm;◇;Mec     ;;         133 118



PRINTL ;;;;;; E1b┓;;;;;;;;;;G2b;;K3l━K4n;;;;;L5p;;;;;;  N6g━┓                                 1 2 3 4 5 6
PRINTL ;;;;D7b┛;Y8k;;;;;;;;;;;;  ┃;;;;;;;;;;;;;;;;R9g━┛    ┃         SCYTHIA 　　  　        7 8 9
PRINTL ;;;;;;┗L10┛;;;;;;;;;;┏━H11   P12━G13━┓┃┗┓    M14━K15┓                 　　　 　10 11 12 13 14 15　　 　
PRINTL ;;;;;;;;;┃ ;;;; ;┏━F16   ┗B17┛┃┏┛ P18┛ M19━S20┛   ┃C21━R22┓　　　　　　　    16 17 18 19 20 21 22 
PRINTL ;;;;;;;;; N23  ┏A24   ┃  F25┛   W26┓   ┃   ┃   ┗K27   ┃  　┃  ┃　　　            23 24 25 26 27 
PRINTL ;;;;;;;;  ┃┗P28┓　　N29┛ ┗B30┛  K31━L32━M33━┓┗┓┏34━━35  V36      ;;　       28 29 30 31 32 33 34 35 36 
PRINTL ;;;;;;;;;;┃  ┃ D37 ┏┛┗┓   ┃    ┃    ┗L38━━K39━R40┃    ┃  ┗━A41┓ ;　　　　 37 38 39 40 41
PRINTL ;;;;;;;;;;;B42┛ ┃┗L43━B44┏V45━━W46┏━━┛    ┃      ┃┏━S47       ;;k48    　   42 43 44 45 46 47 48
PRINTL ;;;;;;;;;;;;┃   ┃   ┗┓┗M49━┓   ┗B50━┓   ┏J51┓┏━C52 ;; ┗┓    ;;;;┃　　　   49 50 51 52
PRINTL ;;;;;;;;;;;;T53━M54━━G55━┛ V56━┓  ┃ B57━B58━━B59;;;;;;;;;; B60    ;;;131         53 54 55 56 57 58 59 60 131
PRINTL ;;;;L62━Z63┛   ┃;;;;;;┗P64┓┃　R65━Z66 ┗S67┛    ┃;;;;;;;;;;;;┃┗B68::;┃         62 63 64 65 66 67 68
PRINTL ;;;;┃   ┃    ┏┛;;;;C69;; ┏L70;;;;┗┓┗T71┛┗E72━C73 ┏S74━T75┛   ┃;;K76         69 70 71 72 73 74 75 76
PRINTL ;;;;P77━T78━B79;;;;;;;;;;;;R80  ;;;;;;T81  ┃ ;;;;;;;;;┗A82┗┓ ┗┓    T83;;┃    　   77 78 79 80 81 82 83
PRINTL ;;;; ┃   ┃   ┃;;P84;;S85;;;┗N86 ;;;;;┗━P87;;;;;;;;;;;;┗━S88┓┃┏M89┛  ┃         84 85 86 87 88 89
PRINTL ;;;;L90   ┗C91┛;;;;;;;;;;;;;;;┗T92 ;;;;;;;  ┃ ;;;;;;R93;;;;;;;;;A94┛┃┗H95┛         90 91 92 93 94 95
PRINTL ;;;;;┗━G96┛;;;;;;;;;;;;;;;;S97┛;;;◇;;;;; A98;;;;;;;;;;;;;;C99;;;┃100 　┗101　　     96 97 98 99 100 101
PRINTL ;;;;;;;;;┃;;;;;;;;┏━━102;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;103┛┗┓  ┃          102 103 
PRINTL ;;;┏━━104━132━106    ┃;;;MEDITERRANEM;;;;;;;;;;;;;;;;;;;;;;;;;┃    107━108         104 132 106 107 108  
PRINTL ;;109                     ┃ ;;;;;;;;;;;;;;;;;110━━━111━━112━113━114┛  ;;;          109 110 111 112 113 114
PRINTL ;;                        ┗━━115━━━━━━┛       ┗116┛      ;; ┃     ;;;         115 116
PRINTL ;                 TERRA INCOGNITA                         ┗133━118  ;;119     ;;         133 118

[SKIPEND]

;-------------------------------------------------
;マップの描画 ARG:0に1を指定すると軍事画面用のボタンを生成
;-------------------------------------------------
@DRAWMAP_EU(ARG:0 = 0, ARG:1 = 0)

CALL DRAWMAP_INIT(ARG:0, 0)

CALL DRAWMAP_LINE("░░░░░░ Edi┓░░░░░░░░░░Gtb░░Kil━Kpn░◇░░Lap░░░░░░  Nbg━┓                        ",   1,   2,   3,   4, 143,   5,  6)
CALL DRAWMAP_LINE("░░░░Dub┛░Yok░░◇░░░░░░░░  ┃░░░░░░░░░░░░░░░░Rig━┛    ┃         SCYTHIA 　　   ",   7,   8, 141,   9)
CALL DRAWMAP_LINE("░░░░░░┗Lon┛░░░░░░░░░░┏━Hum   Pzn━Gds━┓┃┗┓    Msc━Kzn┓                 ",  10,  11,  12,  13,  14,  15)
CALL DRAWMAP_LINE("░░░░░░░░░░┃░░░░ ░┏━Fri   ┗Brd┛┃┏┛ Pin┛ Min━Smo┛   ┃Che━Ryz┓　　　　 ",  16,  17,  18,  19,  20,  21, 22)
CALL DRAWMAP_LINE("░░░░░░░░░ Nrm  ┏Ant   ┃  Frk┛   Wrc┓   ┃   ┃   ┗Ksk   ┃  　┏┛┃　　　   ",  23,  24,  25,  26,  27)
CALL DRAWMAP_LINE("░░░░░░░░  ┃┗Par┓　　Nan┛ ┗Bay┛  Krw━Lbl━Luc━┓ ┗┓┏Bor━Smr━Vlg     ░░",  28,  29,  30,  31,  32,  33, 34, 35, 36)
CALL DRAWMAP_LINE("░░░░░░░░░░┃  ┃ Djn ┏┛┗┓   ┃    ┃    ┗Lib━━Kiv━Rsv┃    ┃  ┗━Ast┓ ░",  37,  38,  39,  40,  41)
CALL DRAWMAP_LINE("░░░░◇░░░░░Bor┛ ┃┗Lyn━Bln┏Vie━━Win┏━━┛    ┃      ┃┏━Srk       ░░Kyz", 142,  42,  43,  44,  45,  46,  47, 48)
CALL DRAWMAP_LINE("░░░░░░░░░░░░┃   ┃   ┗┓┗Mln━┓   ┗Bda━┓   ┏Jas┓┏━Cfa ░░ ┗┓    ░░░░┃",  49,  50,  51,  52)
CALL DRAWMAP_LINE("░░░░░░░░░░░░Tls━Mls━━Gen━┛ Vnc━┓  ┃ Bgr━Bcr━━Bar░░░░░░◇░░ Bat    ░░░●",  53,  54,  55,  56,  57,  58, 59, 146, 60, 131)
CALL DRAWMAP_LINE("░░░░Len━Zgz┛   ┃░░░░░░┗Psa┓┃　Rgs━Zgr ┗Spi┛    ┃░░░░░░░░░░░░┃┗Bak░░░┃",  61,  62,  63,  64,  65,  66, 67)
CALL DRAWMAP_LINE("░░░░┃   ┃    ┏┛░░░░Crs░░ ┏Lvn░░░░┗┓┗Tes┛┗Edi━Cns ┏Snp━Trb┛   ┃░░Kzl",  68,  69,  70,  71,  72,  73, 74, 75)
CALL DRAWMAP_LINE("░░░░Pol━Tld━Bcl░░░░░░░░░░░░Rom  ░░░░░░Tir  ┃ ░░░░░░░░░┗Anc┗┓ ┗┓    Tab░░┃",  76,  77,  78,  79,  80,  81, 82)
CALL DRAWMAP_LINE("░░░░ ┃   ┃   ┃░░Plm░░Sar░░░┗Npl ░░░░░┗━Per░░░░░░░░░░░░┗━Sis┓┃┏Mos┛  ┃",  83,  84,  85,  86,  87,  88)
CALL DRAWMAP_LINE("░░░░Lsb   ┗Col┛░░░░░◇░░░░░░░░┗Trn ░░░░░░░  ┃ ░░░░░░Rod░░░░░░░░░Ant┛┃┗Ham┛",  89,  90, 144,  91,  92,  93,  94)
CALL DRAWMAP_LINE("░░░░░┗━Grn┛░░░░░░░░░░░░░░░░░Src┛░░░░◇░░░░ Atn░░░░░░░░░░░░░Cyp░░░┃Dam 　┗Jsf",  95,  96, 148,  97, 98,  99, 100)
CALL DRAWMAP_LINE("░░░░░░░░░┃░░░░░░░░┏━━Tun░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░◇░░░░░░░Jer┛┗┓  ┃ ", 101, 145, 102)
CALL DRAWMAP_LINE("░░░┏━━Fez━●━Alg     ┃░░░MEDITERRANEM░░░░░░░░░░░░░░░░░░░░░░░░░┃    Bgd━Srz", 103, 132, 104, 105, 106)
CALL DRAWMAP_LINE("░░Mur                     ┃ ░░░░░░░░░░░░░░░░░Brc━━━Mtr━━Alx━Aqb━Kfa┛  ░░░", 107, 108, 109, 110, 111, 112)
CALL DRAWMAP_LINE("░░                        ┗━━Trp━━━━━━┛       ┗Cir┛     ░░░ ┃     ░░░", 113, 114)
CALL DRAWMAP_LINE("░                 TERRA INCOGNITA                          ┗●━Axm░◇░Mec     ░░", 133, 115, 147, 116)

CALL DRAWMAP_END()


;-------------------------------------------------
;全都市数を返す関数
;-------------------------------------------------
@SET_CITY_NUM_EU()
CITY_NUM = 116
;-------------------------------------------------
;短縮都市名を設定
;-------------------------------------------------
@SET_SHORTCITYNAME_EU()
CITY_NAME_SHORT:1 = Edi
CITY_NAME_SHORT:2 = Gtb
CITY_NAME_SHORT:3 = Kil
CITY_NAME_SHORT:4 = Kpn
CITY_NAME_SHORT:5 = Lap
CITY_NAME_SHORT:6 = Nbg
CITY_NAME_SHORT:7 = Dub
CITY_NAME_SHORT:8 = Yok
CITY_NAME_SHORT:9 = Rig
CITY_NAME_SHORT:10 = Lon
CITY_NAME_SHORT:11 = Hum
CITY_NAME_SHORT:12 = Pzn
CITY_NAME_SHORT:13 = Gds
CITY_NAME_SHORT:14 = Msc
CITY_NAME_SHORT:15 = Kzn
CITY_NAME_SHORT:16 = Fri
CITY_NAME_SHORT:17 = Brd
CITY_NAME_SHORT:18 = Pin
CITY_NAME_SHORT:19 = Min
CITY_NAME_SHORT:20 = Smo
CITY_NAME_SHORT:21 = Che
CITY_NAME_SHORT:22 = Ryz
CITY_NAME_SHORT:23 = Nrm
CITY_NAME_SHORT:24 = Ant
CITY_NAME_SHORT:25 = Frk
CITY_NAME_SHORT:26 = Wrc
CITY_NAME_SHORT:27 = Ksk
CITY_NAME_SHORT:28 = Par
CITY_NAME_SHORT:29 = Nan
CITY_NAME_SHORT:30 = Bay
CITY_NAME_SHORT:31 = Krw
CITY_NAME_SHORT:32 = Lbl
CITY_NAME_SHORT:33 = Luc
CITY_NAME_SHORT:34 = Bor
CITY_NAME_SHORT:35 = Smr
CITY_NAME_SHORT:36 = Vlg
CITY_NAME_SHORT:37 = Djn
CITY_NAME_SHORT:38 = Lib
CITY_NAME_SHORT:39 = Kiv
CITY_NAME_SHORT:40 = Rsv
CITY_NAME_SHORT:41 = Ast
CITY_NAME_SHORT:42 = Bor
CITY_NAME_SHORT:43 = Lyn
CITY_NAME_SHORT:44 = Bln
CITY_NAME_SHORT:45 = Vie
CITY_NAME_SHORT:46 = Win
CITY_NAME_SHORT:47 = Srk
CITY_NAME_SHORT:48 = Kyz
CITY_NAME_SHORT:49 = Mln
CITY_NAME_SHORT:50 = Bda
CITY_NAME_SHORT:51 = Jas
CITY_NAME_SHORT:52 = Cfa
CITY_NAME_SHORT:53 = Tls
CITY_NAME_SHORT:54 = Mls
CITY_NAME_SHORT:55 = Gen
CITY_NAME_SHORT:56 = Vnc
CITY_NAME_SHORT:57 = Bgr
CITY_NAME_SHORT:58 = Bcr
CITY_NAME_SHORT:59 = Bar
CITY_NAME_SHORT:60 = Bat
CITY_NAME_SHORT:61 = Len
CITY_NAME_SHORT:62 = Zgz
CITY_NAME_SHORT:63 = Psa
CITY_NAME_SHORT:64 = Rgs
CITY_NAME_SHORT:65 = Zgr
CITY_NAME_SHORT:66 = Spi
CITY_NAME_SHORT:67 = Bak
CITY_NAME_SHORT:68 = Crs
CITY_NAME_SHORT:69 = Lvn
CITY_NAME_SHORT:70 = Tes
CITY_NAME_SHORT:71 = Edi
CITY_NAME_SHORT:72 = Cns
CITY_NAME_SHORT:73 = Snp
CITY_NAME_SHORT:74 = Trb
CITY_NAME_SHORT:75 = Kzl
CITY_NAME_SHORT:76 = Pol
CITY_NAME_SHORT:77 = Tld
CITY_NAME_SHORT:78 = Bcl
CITY_NAME_SHORT:79 = Rom
CITY_NAME_SHORT:80 = Tir
CITY_NAME_SHORT:81 = Anc
CITY_NAME_SHORT:82 = Tab
CITY_NAME_SHORT:83 = Plm
CITY_NAME_SHORT:84 = Sar
CITY_NAME_SHORT:85 = Npl
CITY_NAME_SHORT:86 = Per
CITY_NAME_SHORT:87 = Sis
CITY_NAME_SHORT:88 = Mos
CITY_NAME_SHORT:89 = Lsb
CITY_NAME_SHORT:90 = Col
CITY_NAME_SHORT:91 = Trn
CITY_NAME_SHORT:92 = Rod
CITY_NAME_SHORT:93 = Ant
CITY_NAME_SHORT:94 = Ham
CITY_NAME_SHORT:95 = Grn
CITY_NAME_SHORT:96 = Src
CITY_NAME_SHORT:97 = Atn
CITY_NAME_SHORT:98 = Cyp
CITY_NAME_SHORT:99 = Dam
CITY_NAME_SHORT:100 = Jsf
CITY_NAME_SHORT:101 = Tun
CITY_NAME_SHORT:102 = Jer
CITY_NAME_SHORT:103 = Fez
CITY_NAME_SHORT:104 = Alg
```
