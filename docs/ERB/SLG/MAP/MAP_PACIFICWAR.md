# SLG/MAP/MAP_PACIFICWAR.ERB — 自动生成文档

源文件: `ERB/SLG/MAP/MAP_PACIFICWAR.ERB`

类型: .ERB

自动摘要: functions: DRAWMAP_PACIFICWAR, SET_CITY_NUM_PACIFICWAR, SET_SHORTCITYNAME_PACIFICWAR, SET_CITYNAME_PACIFICWAR, SET_CITY_TYPE_PACIFICWAR, SET_MAP_ROUTE_PACIFICWAR, MAP_INIT_PACIFICWAR; UI/print

前 200 行源码片段:

```text
﻿;マップ関係
[SKIPSTART]
DRAWMAPの内容を分かりやすく提示するためのコメントブロック
;-------------------------------------------------
;マップの外観(ダミー関数)
;-------------------------------------------------

PRINTL ;;;;;;;;;;;;; Sca┓;;;;;;;;;;;;;;;;;;;;;;Nar━Kir━Gav;;;┏━┳Joe┓;;Ark┓       ",   1,   2,   3,   4,  5,  6)
PRINTL ;;;;┏Blf;;Gla┛ Edi;;;;;;;;Nos;;;;;;Brg┻Osl┓┗┳┛;;Vaa ┏Vip┓ Pet┛ ┗┓　   ",   7,   8,   9, 141,  10,  11, 12, 13, 14)
PRINTL ;;;Gal┃;;;;;┗Dum┛;;;;;;;;;;;;;;;;;;;;;;;;Mal━Sto;;┗Hel┛;;┏Lng┻┓  Krv     ",  15,  16,  17,  18,  19, 20, 21)
PRINTL ;;;┗Dub;;;;;  ┣┓;;;;;;;;;;;;;;;;;;;;;Kpn;;;;;;;;Blt;;;;;;;;;Tll ┃ Gor┛┃     ",  22,  23, 142,  24,  25)
PRINTL ;;;;;;;;;;;  ┏╋Nor;;;;;;;;;;;;;;;;;;  ┃;;;;;;;;;;;;;Kla━Rig┛  ┃ ┃   ┃ 　  ",  26,  27,  28)
PRINTL ;;;;;;;;Pre━┻Lon┛;Dov;┏Rot┳Ams━Kil┻Ros━Gds━Kor┫┗┓┗━━┻Msc┓ ┗┓   ", 143,  29,  30, 144,  31,  32,  33,  34,  35,  36,  37)
PRINTL ;;Clt;;;;;;;;;;;;;;;;;┏Bru━Nam━Fri╋Mag┻Ber┫ ┏┻Pin━╋━Smo━┛  ┗━Ryz   ",  38,  39,  40,  41,  42,  43,  44,  45)
PRINTL ;;;;;;;;Bre━━Nrm━Dan┳┻Lux╋Col┫┃ ┃     ┣Wrc┓ ┃  ┃   ┗┓     ┏┛┃   ",  46,  47,  48,  49,  50,  51)
PRINTL ;;;;;;;;;;┃ ┏┛┗━╋Par┳━Met━╋Frk┻┳━Cot━Krw━Tal┻Luc┳┻━━Smr━Vlg  ",  52,  53,  54,  55,  56,  57,  58,  59,  60)
PRINTL ;;;;;;;;;;┣Ang    ┏┛┏Wer━┫ ┏┛┃ ┏Dre┓    ┃   ┃   ┃ ┃      ┃　　┃　",  61,  62,  63)
PRINTL ;;;;;;;;;;┃ ┗━━╋━┫     ┣Str━Nur╋━Pra━Tes━Pre━Kiv━Rsv━━Stl┓　┃　",  64,  65,  66,  67,  68,  69,  70,  71)
PRINTL ;;;;;;;;;;┗┓  ┏Vic  ┣━┓Gnv┓      ┣Mun┫  ┗┓┏┛   ┃   ┃    ┃ ┗━Ast ",  72,  150, 73,  74)
PRINTL ;;;Vcy;;;;;Bor━┛ ┣━┫ Lyn━Bln   ┏Inb━Win━━Deb━┳━┛   ┃┏━Srk    ┃  ", 145,  75,  76,  77,  78,  79,  80,  81)
PRINTL ;;;;;;;;;;;;┃   ┏┛  ┃  ┗┓ ┗Mln┻┓    ┣Bda━┻┳Jas┓┏━Sev;;;┗┓   ┃  ",  82,  83,  84,  85)
PRINTL ;;;;;;;;;;;;┣━Mls━Tou━━━Gen━┛ ┏Vnc┓┃ ┃    ┗Bcr╋Con;;;;Bls; Bat  ┃  ",  86,  87,  88,  89,  90,  91, 146, 92)
PRINTL ;;;;Len━Ovi┛   ┃;;;;;;;;;;;┗Psa━Bol;;;Zgr━Bgr┳Sof╋Bug;;;;;;;;;;;;┃┗Bak  ",  93,  94,  95,  151,  96,  97,  98, 99, 100)
PRINTL ;;;;┃   ┃    ┏Bcl;;;;;;;;;;;;;┗┓ ┃;;;;┗Cet╋Nis━┻━Isb;┏━━Trb┛ ┏┛  ", 101, 102, 103, 104, 105)
PRINTL ;;;Pol━Mad━Val;;;;;;;;;;;;;;;;;;:Rom┫;;;;;;┗Tir ┃ ;;;;;┗Anc     ┗┓  ┃    ", 106, 107, 108, 109, 110, 111)
PRINTL ;;;;┃  ┃   ┃;;;;;;;;;Sdn;;;;;;;;┗Npl ;;;;;;;┗━Per;;;;;;;;┗━Sis┓┃┏Erz   ", 147, 112, 113, 114, 115)
PRINTL ;;;Lsb━Col━Mur;;;;;;;;;;;;;;;;;;;;;┗Trn;;;;;;;;;  ┃ ;;;;;;;;;;;;;;;Gaz┛┃    ", 116, 117, 118, 119, 120)
PRINTL ;;;;;┗━Grn┛;;;;;;;;;;;;;;;;;;;;;;Pal┛;;;;;;;;;;; Atn;;;;;;;;;;;;;;;;┃ Mos 　 ", 121, 122, 123, 124)
PRINTL ;;;;;;┏Gib┛;;;;;;;;┏━━Tun;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;Scs;;;;;;;;;Jer┛┗┓ ", 125, 126, 148, 127)
PRINTL ;; ┏━Fez━━━━Alg┛     ┃;;;;;;;;;Ion;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;┃    Bgd ", 128, 129, 149, 130)
PRINTL ;Cas                        ┃ ;;;;;;;;;;;;;;;;;Bng━━━━Ela━━Alx━Sue━Amm┛ ", 131, 132, 133, 134, 135, 136)
PRINTL ;┃                         ┗━━━━Trp━━━━┛         ┗Cir━┻┓ ;;;       ", 137, 138)
PRINTL ;Dak                                                                 Add;;;;      ", 139, 140)


PRINTL ;;;;;;;;;;;;; S1a┓;;;;;;;;;;;;;;;;;;;;;;N2r━K3r━G4v;;;┏━┳J5e┓;;A6k┓       ",   1,   2,   3,   4,  5,  6)
PRINTL ;;;;┏B7f;;G8a┛ E9i;;;;;;;;141;;;;;;B10┻O11┓┗┳┛;;V12 ┏V13┓ P14┛ ┗┓　   ",   7,   8,   9, 141,  10,  11, 12, 13, 14)
PRINTL ;;;G15┃;;;;;┗D16┛;;;;;;;;;;;;;;;;;;;;;;;;M17━S18;;┗H19┛;;┏L20┻┓  K21     ",  15,  16,  17,  18,  19, 20, 21)
PRINTL ;;;┗D22;;;;;  ┣┓;;;;;;;;;;;;;;;;;;;;;K23;;;;;;;142;;;;;;;;;;T24 ┃ G25┛┃     ",  22,  23, 142,  24,  25)
PRINTL ;;;;;;;;;;;  ┏╋N26;;;;;;;;;;;;;;;;;;  ┃;;;;;;;;;;;;;K27━R28┛  ┃ ┃   ┃ 　  ",  26,  27,  28)
PRINTL ;;;;;;;;P29━┻L30┛144;;┏R31┳A32━K33┻R34━G35━K36┫┗┓┗━━┻M37┓ ┗┓   ", 143,  29,  30, 144,  31,  32,  33,  34,  35,  36,  37)
PRINTL ;143;;;;;;;;;;;;;;;;;;┏B38━N39━F40╋M41┻B42┫ ┏┻P43━╋━S44━┛  ┗━R45   ",  38,  39,  40,  41,  42,  43,  44,  45)
PRINTL ;;;;;;;;B46━━N47━D48┳┻L49╋C50┫┃ ┃     ┣W51┓ ┃  ┃   ┗┓     ┏┛┃   ",  46,  47,  48,  49,  50,  51)
PRINTL ;;;;;;;;;;┃ ┏┛┗━╋P52┳━M53━╋F54┻┳━C55━K56━T57┻L58┳┻━━S59━V60  ",  52,  53,  54,  55,  56,  57,  58,  59,  60)
PRINTL ;;;;;;;;;;┣A61    ┏┛┏W62━┫ ┏┛┃ ┏D63┓    ┃   ┃   ┃ ┃      ┃　　┃　",  61,  62,  63)
PRINTL ;;;;;;;;;;┃ ┗━━┫  ┃     ┣S64━N65╋━P66━T67━P68━K69━R70━━S71┓　┃　",  64,  65,  66,  67,  68,  69,  70,  71)
PRINTL ;;;;;;;;;;┗┓  ┏V72━╋━┓150┓      ┣M73┫  ┗┓┏┛   ┃   ┃    ┃ ┗━A74 ",  72,  150,  73,  74)
PRINTL ;;;145;;;;;B75━┛ ┃  ┃ L76━B77   ┏I78━W79━━D80━┳━┛   ┃┏━S81    ┃  ", 145,  75,  76,  77,  78,  79,  80,  81)
PRINTL ;;;;;;;;;;;;┃   ┏┛  ┃  ┗┓ ┗M82┻┓    ┣B83━┻┳J84┓┏━S85;;;┗┓   ┃  ",  82,  83,  84,  85)
PRINTL ;;;;;;;;;;;;┣━M86━T87━━━G88━┛ ┏V89┓┃ ┃    ┗B90╋C91;;;146;; B92  ┃  ",  86,  87,  88,  89,  90,  91, 146, 92)
PRINTL ;;;;L93━O94┛   ┃;;;;;;;;;;;┗P95━151　;Z96━B97┳S98╋B99;;;;;;;;;;;;┃┗100  ",  93,  94,  95,  151,  96,  97,  98, 99, 100)
PRINTL ;;;;┃   ┃    ┏101;;;;;;;;;;;;;┗┓ ┃;;;;┗102╋103━┻━104;┏━━105┛ ┏┛  ", 101, 102, 103, 104, 105)
PRINTL ;;;106━107━108;;;;;;;;;;;;;;;;;;:109┫;;;;;;┗110 ┃ ;;;;;┗111     ┗┓  ┃    ", 106, 107, 108, 109, 110, 111)
PRINTL ;;;;┃  ┃   ┃;;;;;;;;;147;;;;;;;;┗112 ;;;;;;;┗━113;;;;;;;;┗━114┓┃┏115   ", 147, 112, 113, 114, 115)
PRINTL ;;;116━117━118;;;;;;;;;;;;;;;;;;;;;┗119;;;;;;;;;  ┃ ;;;;;;;;;;;;;;;120┛┃    ", 116, 117, 118, 119, 120)
PRINTL ;;;;;┗━121┛;;;;;;;;;;;;;;;;;;;;;;122┛;;;;;;;;;;; 123;;;;;;;;;;;;;;;;┃ 124 　 ", 121, 122, 123, 124)
PRINTL ;;;;;;┏125┛;;;;;;;;┏━━126;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;148;;;;;;;;;127┛┗┓ ", 125, 126, 148, 127)
PRINTL ;; ┏━128━━━━129┛     ┃;;;;;;;;;149;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;┃    130 ", 128, 129, 149, 130)
PRINTL ;131                        ┃ ;;;;;;;;;;;;;;;;;132━━━━133━━134━135━136┛ ", 131, 132, 133, 134, 135, 136)
PRINTL ;┃                         ┗━━━━137━━━━┛         ┗138━┻┓ ;;;       ", 137, 138)
PRINTL ;139                                                                 140;;;;      ", 139, 140)
[SKIPEND]

;-------------------------------------------------
;マップの描画 ARG:0に1を指定すると軍事画面用のボタンを生成
;-------------------------------------------------
@DRAWMAP_PACIFICWAR(ARG:0 = 0, ARG:1 = 0)

CALL DRAWMAP_INIT(ARG:0, 0)

CALL DRAWMAP_LINE("                                       Okh░░░░░░Oxa░░░░░░░░░░░░░░░░░░░░░░░░░░░░Moa━┓      ",   1,   2,   3)
CALL DRAWMAP_LINE(" Oms━━━Nov━━┳━━Irk━━━Ykt━━╋━Kha░░┃ ░░░░░░░Brs░░░░░░░Ksk░░Ats░░░░░░░░┃      ",   4,   5,   6, 7,  8,  9, 10, 11)
CALL DRAWMAP_LINE(" ┗┓     ┃     Kzl┳┛              Hbn   ┃░░Tyh░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░┃      ",  12,  13,  14)
CALL DRAWMAP_LINE("   ┣━━Arm━━┫  Mor┳Ula━Mkd━Hnc╋┳━Vla░░░░░░░░░Ohs░░░░  ░░░░░░░░░░░░░░░░░░░┃      ",  15,  16,  17,  18,  19,  20,  125)
CALL DRAWMAP_LINE("  Frn     ┃    ┃  ┃┏Hht┳┛ ┃  ░Dln┃ ░░░░░Soj░░░░░░░░░░░ Spr ░░░░░░░░░░░░░░░░░Sat━Cye",  21, 133,  22,  23,  24,  25,  26)
CALL DRAWMAP_LINE("   ┣Uru━Glm━Pln━Yan━━Tyn━Bgn ░░░ Pyn ░░░░░░░░░░░░░░░░░░░┃░░░░░░░░░░░░░░░░░░░░┃   ┃",  27,  38,  28,  29,  30,  31,  32)
CALL DRAWMAP_LINE("  Slb      ┃   ┃   ┗┓   ┃   ┃ ░░░░ ┃ ░░░░░       ┏Kzw━Akt░░░░Pco░░░░░░░░░░░░Sfc  ┃",  33,  34,  35,  36,  37)
CALL DRAWMAP_LINE("   ┣━━━Xnn━Lnz┳━Xia━Jin┳Qgn░░░░Bus ░Ngs━Hsm┳Osk┓  ┃┃░░░░░░░░░░░░░░░░░░░┣Sam┫", 131,  39,  40,  41,  42,  43,  44,  45,  46,  47)
CALL DRAWMAP_LINE("   Kab┓   ┃     Chg   ┃     ┃ ░░░░░░░░░░░┃ ░░┃░┃░┗Ykh━Tky░░░░░░░░░░░░Phb░░░Los  Lam",  48,  49,  50,  51,  52,  53,  54)
CALL DRAWMAP_LINE("  ┃  Sng━Lha━Kum┻Cng╋Njn━Shh░░░░░░░░░░░Kgs░░Skk┛░░░░░░░░░░░░░░░░░░░░Mid░░░░░░░┃  ┃ ", 132,  55,  56,  57,  58,  59,  60,  61,  62)
CALL DRAWMAP_LINE(" Hrt  ┃   ┃   ┃      ┃┗┓ ┃░░░Yls░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░Wki░░░░░░░░░░░░Sde┛ ",  63,  64,  65,  66)
CALL DRAWMAP_LINE(" ┃   ┣Kat┻Thi╋Gli┳Gug━Fuz┛░░░░░░░░░░Okn░░░░░░░░░░░░░░░░░░Iou░░░░░░░░░░░░░░░░░░░      ",  67,  68,  69,  70,  71,  72,  73)
CALL DRAWMAP_LINE(" ┣Del┫┗Imp┛ ┃░░Hnd░┃░░░░░░░░░░Tai░░░░░░░░░░░░░░Iot░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    ",  74, 128, 127,  75,  76)
CALL DRAWMAP_LINE(" ┃   Kol ┃┗┓┣Hni░░░Hgk░░░░░░░░░   ░░░░░░░░░░░░░░░░░░░░░Spn░░░░░░░░░░░░░░░Jns░░░░░░░░░  ",  77,  78,  79,  80,  81)
CALL DRAWMAP_LINE("Kar┓  ┣Ran━Bkk ┃░░░░░░░░░░░Cfi░░░░░░░░░░░░░░░Mrt░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░",  82,  83,  84,  85,  86)
CALL DRAWMAP_LINE("░░Bmb  ┃░░░ ┃░┗Sgn░░░Spi░░░░░┃░░░░Pps░░░░░░░░░░░░░░░░░░░Gua░░░░░░░░░░░Kjl░░░░░░░░░░░░░░░",  87,  88,  93,  89,  90,  91)
CALL DRAWMAP_LINE("░░░┗┳┛░░░ Tnb░░░░░░░░░░░Srk░Man░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░Trk░░░░░░░░░░░░░░░░░░░░░",  92, 129,  94,  95)
CALL DRAWMAP_LINE("░░░░░Koc░░░░░ ┃░░░░░Got░░░ ┃░░┗Let░░ Mnd ░░░░Plu░Ngn┓  ░░░Rbl░░░░░░░░░░░░░░░░░░░░░░░░░░░",  96, 126,  97, 104,  98,  99, 100)
CALL DRAWMAP_LINE("░░░░░░░░░Cln░░Sin░░░░░░░░░  Kmt░░░░░░░  ░░░░░░░░░░░░░  ┗Pmb░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░", 101, 102, 130, 103)
CALL DRAWMAP_LINE("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ░░░░░░░░Afs░░░░░░░░░░Gdc░░░░░░░░░░░░░░░░░░░░░░░░░░░", 105, 106)
CALL DRAWMAP_LINE("░░░░░░░░░░░░░░░Ohv━━Btv━━Sby░░Bls░░░░░┏Dar░░░░░░░░Car░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░", 107, 108, 109, 110, 111, 112)
CALL DRAWMAP_LINE("░░░░░░░░░Ids░░░░░░░░░░░░░░░░░░░░░░░░░░░░┏┛  ┗┳━┳┛┃░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░", 113)
CALL DRAWMAP_LINE("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░┃      ┃ Hhd━Syd░░░░░Auc░░░░░░░░░░░░░░░░░░░░░░░░░", 114, 115, 116)
CALL DRAWMAP_LINE("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░┃     Ali━┻┓ ┃░Tms░┃░░░░░░░░░░░░░░░░░░░░░░░░░░", 117, 118)
CALL DRAWMAP_LINE("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░┃      ┃    ┗Can░░░░Wel░░░░░░░░░░░░░░░░░░░░░░░░░░", 119, 120)
CALL DRAWMAP_LINE("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░┃┏━━┻━Ade ┃░░░░░┃░░░░░░░░░░░░░░░░░░░░░░░░░░░", 121)
CALL DRAWMAP_LINE("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░Prt░░░░░░░░░░░┗Mel░░░Crc░░░░░░░░░░░░░░░░░░░░░░░░░░░", 122, 123, 124)

CALL DRAWMAP_END()


;-------------------------------------------------
;全都市数を返す関数
;-------------------------------------------------
@SET_CITY_NUM_PACIFICWAR()
CITY_NUM = 133
;-------------------------------------------------
;短縮都市名を設定
;-------------------------------------------------
@SET_SHORTCITYNAME_PACIFICWAR()
CITY_NAME_SHORT:1 = Okh
CITY_NAME_SHORT:2 = Oxa
CITY_NAME_SHORT:3 = Moa
CITY_NAME_SHORT:4 = Oms
CITY_NAME_SHORT:5 = Nov
CITY_NAME_SHORT:6 = Irk
CITY_NAME_SHORT:7 = Ykt
CITY_NAME_SHORT:8 = Kha
CITY_NAME_SHORT:9 = Brs
CITY_NAME_SHORT:10 = Ksk
CITY_NAME_SHORT:11 = Ats
CITY_NAME_SHORT:12 = Kzl
CITY_NAME_SHORT:13 = Hbn
CITY_NAME_SHORT:14 = Tyh
CITY_NAME_SHORT:15 = Arm
CITY_NAME_SHORT:16 = Mor
CITY_NAME_SHORT:17 = Ula
CITY_NAME_SHORT:18 = Mkd
CITY_NAME_SHORT:19 = Hnc
CITY_NAME_SHORT:20 = Vla
CITY_NAME_SHORT:21 = Frn
CITY_NAME_SHORT:22 = Dln
CITY_NAME_SHORT:23 = Soj
CITY_NAME_SHORT:24 = Spr
CITY_NAME_SHORT:25 = Sat
CITY_NAME_SHORT:26 = Cye
CITY_NAME_SHORT:27 = Uru
CITY_NAME_SHORT:28 = Pln
CITY_NAME_SHORT:29 = Yan
CITY_NAME_SHORT:30 = Tyn
CITY_NAME_SHORT:31 = Bgn
CITY_NAME_SHORT:32 = Pyn
CITY_NAME_SHORT:33 = Slb
CITY_NAME_SHORT:34 = Kzw
CITY_NAME_SHORT:35 = Akt
CITY_NAME_SHORT:36 = Pco
CITY_NAME_SHORT:37 = Sfc
CITY_NAME_SHORT:38 = Glm
CITY_NAME_SHORT:39 = Lnz
CITY_NAME_SHORT:40 = Xia
CITY_NAME_SHORT:41 = Jin
CITY_NAME_SHORT:42 = Qgn
CITY_NAME_SHORT:43 = Bus
CITY_NAME_SHORT:44 = Ngs
CITY_NAME_SHORT:45 = Hsm
CITY_NAME_SHORT:46 = Osk
CITY_NAME_SHORT:47 = Sam
CITY_NAME_SHORT:48 = Kab
CITY_NAME_SHORT:49 = Chg
CITY_NAME_SHORT:50 = Ykh
CITY_NAME_SHORT:51 = Tky
CITY_NAME_SHORT:52 = Phb
CITY_NAME_SHORT:53 = Los
CITY_NAME_SHORT:54 = Lam
CITY_NAME_SHORT:55 = Lha
CITY_NAME_SHORT:56 = Kum
CITY_NAME_SHORT:57 = Cng
CITY_NAME_SHORT:58 = Njn
CITY_NAME_SHORT:59 = Shh
CITY_NAME_SHORT:60 = Kgs
CITY_NAME_SHORT:61 = Skk
CITY_NAME_SHORT:62 = Mid
CITY_NAME_SHORT:63 = Hrt
CITY_NAME_SHORT:64 = Yls
CITY_NAME_SHORT:65 = Wki
CITY_NAME_SHORT:66 = Sde
CITY_NAME_SHORT:67 = Kat
CITY_NAME_SHORT:68 = Thi
CITY_NAME_SHORT:69 = Gli
CITY_NAME_SHORT:70 = Gug
CITY_NAME_SHORT:71 = Fuz
CITY_NAME_SHORT:72 = Okn
CITY_NAME_SHORT:73 = Iou
CITY_NAME_SHORT:74 = Del
CITY_NAME_SHORT:75 = Tai
CITY_NAME_SHORT:76 = Iot
CITY_NAME_SHORT:77 = Kol
CITY_NAME_SHORT:78 = Hni
CITY_NAME_SHORT:79 = Hgk
CITY_NAME_SHORT:80 = Spn
CITY_NAME_SHORT:81 = Jns
CITY_NAME_SHORT:82 = Kar
CITY_NAME_SHORT:83 = Ran
CITY_NAME_SHORT:84 = Bkk
CITY_NAME_SHORT:85 = Cfi
CITY_NAME_SHORT:86 = Mrt
CITY_NAME_SHORT:87 = Bmb
CITY_NAME_SHORT:88 = Sgn
CITY_NAME_SHORT:89 = Pps
CITY_NAME_SHORT:90 = Gua
```
