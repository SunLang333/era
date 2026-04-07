# SLG/MAP/MAP_ARMAGEDDON.ERB — 自动生成文档

源文件: `ERB/SLG/MAP/MAP_ARMAGEDDON.ERB`

类型: .ERB

自动摘要: functions: DRAWMAP_ARMAGEDDON, SET_CITY_NUM_ARMAGEDDON, SET_SHORTCITYNAME_ARMAGEDDON, SET_CITYNAME_ARMAGEDDON, SET_CITY_TYPE_ARMAGEDDON, SET_MAP_ROUTE_ARMAGEDDON, MAP_INIT_ARMAGEDDON; UI/print

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
PRINTL ;;;;;;;;;;;  ┏╋Nor;;;;;;;;;;;;;;;;;;  ┃;;;;;;;;;;;;;Kau━Rig┛  ┃ ┃   ┃ 　  ",  26,  27,  28)
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
@DRAWMAP_ARMAGEDDON(ARG:0 = 0, ARG:1 = 0)

CALL DRAWMAP_INIT(ARG:0, 0)

CALL DRAWMAP_LINE("░░░░░░░░░░░░░ Sca┓░░░░░░░░░░░░░░░░░░░░░░Nar━Kir━Gav░░░┏━┳Joe┓░░Ark┓       ",   1,   2,   3,   4,  5,  6)
CALL DRAWMAP_LINE("░░░░┏Blf░░Gla┛ Edi░░░░░░░░Nos░░░░░░Brg┻Osl┓┗┳┛░░Vaa ┏Vip┓ Pet┛ ┗┓　   ",   7,   8,   9, 141,  10,  11, 12, 13, 14)
CALL DRAWMAP_LINE("░░░Gal┃░░░░░┗Dum┛░░░░░░░░░░░░░░░░░░░░░░░░Mal━Sto░░┗Hel┛░░┏Lng┻┓  Krv     ",  15,  16,  17,  18,  19, 20, 21)
CALL DRAWMAP_LINE("░░░┗Dub░░░░░  ┣┓░░░░░░░░░░░░░░░░░░░░░Kpn░░░░░░░░Blt░░░░░░░░░Tll ┃ Gor┛┃     ",  22,  23, 142,  24,  25)
CALL DRAWMAP_LINE("░░░░░░░░░░░  ┏╋Nor░░░░░░░░░░░░░░░░░░  ┃░░░░░░░░░░░░░Kau━Rig┛  ┃ ┃   ┃ 　  ",  26,  27,  28)
CALL DRAWMAP_LINE("░░░░░░░░Pre━┻Lon┛░Dov░┏Rot┳Ams━Kil┻Ros━Gds━Kor┫┗┓┗━━┻Msc┓ ┗┓   ",  29,  30, 144,  31,  32,  33,  34,  35,  36,  37)
CALL DRAWMAP_LINE("░░Clt░░░░░░░░░░░░░░░░░┏Bru━Nam━Fri╋Mag┻Ber┫ ┏┻Pin━╋━Smo━┛  ┗━Ryz   ", 143,  38,  39,  40,  41,  42,  43,  44,  45)
CALL DRAWMAP_LINE("░░░░░░░░Bre━━Nrm━Dan┳┻Lux╋Col┫┃ ┃     ┣Wrc┓ ┃  ┃   ┗┓     ┏┛┃   ",  46,  47,  48,  49,  50,  51)
CALL DRAWMAP_LINE("░░░░░░░░░░┃ ┏┛┗━╋Par┳━Met━╋Frk┻┳━Cot━Krw━Tal┻Luc┳┻━━Smr━Vlg  ",  52,  53,  54,  55,  56,  57,  58,  59,  60)
CALL DRAWMAP_LINE("░░░░░░░░░░┣Ang    ┏┛┏Wer━┫ ┏┛┃ ┏Dre┓    ┃   ┃   ┃ ┃      ┃　　┃　",  61,  62,  63)
CALL DRAWMAP_LINE("░░░░░░░░░░┃ ┗━━╋━┫     ┣Str━Nur╋━Pra━Tes━Pre━Kiv━Rsv━━Stl┓　┃　",  64,  65,  66,  67,  68,  69,  70,  71)
CALL DRAWMAP_LINE("░░░░░░░░░░┗┓  ┏Vic  ┣━┓Gnv┓      ┣Mun┫  ┗┓┏┛   ┃   ┃    ┃ ┗━Ast ",  72,  150,  73,  74)
CALL DRAWMAP_LINE("░░░Vcy░░░░░Bor━┛ ┣━┫ Lyn━Bln   ┏Inb━Win━━Deb━┳━┛   ┃┏━Srk    ┃  ", 145,  75,  76,  77,  78,  79,  80,  81)
CALL DRAWMAP_LINE("░░░░░░░░░░░░┃   ┏┛  ┃  ┗┓ ┗Mln┻━┓  ┣Bda━┻┳Jas┓┏━Sev░░░┗┓   ┃  ",  82,  83,  84,  85)
CALL DRAWMAP_LINE("░░░░░░░░░░░░┣━Mls━Tou━━━Gen━┛ ┏Vnc┓┃ ┃    ┗Bcr╋Con░░░░Bls░ Bat  ┃  ",  86,  87,  88,  89,  90,  91, 146, 92)
CALL DRAWMAP_LINE("░░░░Len━Ovi┛   ┃░░░░░░░░░░░┗Psa━Bol░░░Zgr━Bgr┳Sof╋Bug░░░░░░░░░░░░┃┗Bak  ",  93,  94,  95,  151,  96,  97,  98, 99, 100)
CALL DRAWMAP_LINE("░░░░┃   ┃    ┏Bcl░░░░░░░░░░░░░┗┓ ┃░░░░┗Cet╋Nis━┻━Isb░┏━━Trb┛ ┏┛  ", 101, 102, 103, 104, 105)
CALL DRAWMAP_LINE("░░░Pol━Mad━Val░░░░░░░░░░░░░░░░░░░Rom┫░░░░░░┗Tir ┃ ░░░░░┗Anc     ┗┓  ┃    ", 106, 107, 108, 109, 110, 111)
CALL DRAWMAP_LINE("░░░░┃  ┃   ┃░░░░░░░░░Sdn░░░░░░░░┗Npl ░░░░░░░┗━Per░░░░░░░░┗━Sis┓┃┏Erz   ", 147, 112, 113, 114, 115)
CALL DRAWMAP_LINE("░░░Lsb━Col━Mur░░░░░░░░░░░░░░░░░░░░░┗Trn░░░░░░░░░  ┃ ░░░░░░░░░░░░░░░Gaz┛┃    ", 116, 117, 118, 119, 120)
CALL DRAWMAP_LINE("░░░░░┗━Grn┛░░░░░░░░░░░░░░░░░░░░░░Pal┛░░░░░░░░░░░ Atn░░░░░░░░░░░░░░░░┃ Mos 　 ", 121, 122, 123, 124)
CALL DRAWMAP_LINE("░░░░░░┏Gib┛░░░░░░░░┏━━Tun░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░Scs░░░░░░░░Jer┛┗┓ ", 125, 126, 148, 127)
CALL DRAWMAP_LINE("░░ ┏━Fez━━━━Alg┛     ┃░░░░░░░░░Ion░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░┃    Bgd ", 128, 129, 149, 130)
CALL DRAWMAP_LINE("░Cas                        ┃ ░░░░░░░░░░░░░░░░░Bng━━━━Ela━━Alx━Sue━Amm┛ ", 131, 132, 133, 134, 135, 136)
CALL DRAWMAP_LINE("░┃                         ┗━━━━Trp━━━━┛         ┗Cir━┻┓ ░░░       ", 137, 138)
CALL DRAWMAP_LINE("░Dak                                                                 Add░░░░      ", 139, 140)

CALL DRAWMAP_END()


;-------------------------------------------------
;全都市数を返す関数
;-------------------------------------------------
@SET_CITY_NUM_ARMAGEDDON()
CITY_NUM = 151
;-------------------------------------------------
;短縮都市名を設定
;-------------------------------------------------
@SET_SHORTCITYNAME_ARMAGEDDON()
CITY_NAME_SHORT:1 = Sca
CITY_NAME_SHORT:2 = Nar
CITY_NAME_SHORT:3 = Kir
CITY_NAME_SHORT:4 = Gav
CITY_NAME_SHORT:5 = Joe
CITY_NAME_SHORT:6 = Ark
CITY_NAME_SHORT:7 = Blf
CITY_NAME_SHORT:8 = Gla
CITY_NAME_SHORT:9 = Edi
CITY_NAME_SHORT:10 = Brg
CITY_NAME_SHORT:11 = Osl
CITY_NAME_SHORT:12 = Vaa
CITY_NAME_SHORT:13 = Vip
CITY_NAME_SHORT:14 = Pet
CITY_NAME_SHORT:15 = Gal
CITY_NAME_SHORT:16 = Dum
CITY_NAME_SHORT:17 = Mal
CITY_NAME_SHORT:18 = Sto
CITY_NAME_SHORT:19 = Hel
CITY_NAME_SHORT:20 = Lng
CITY_NAME_SHORT:21 = Krv
CITY_NAME_SHORT:22 = Dub
CITY_NAME_SHORT:23 = Kpn
CITY_NAME_SHORT:24 = Tll
CITY_NAME_SHORT:25 = Gor
CITY_NAME_SHORT:26 = Nor
CITY_NAME_SHORT:27 = Kau
CITY_NAME_SHORT:28 = Rig
CITY_NAME_SHORT:29 = Pre
CITY_NAME_SHORT:30 = Lon
CITY_NAME_SHORT:31 = Rot
CITY_NAME_SHORT:32 = Ams
CITY_NAME_SHORT:33 = Kil
CITY_NAME_SHORT:34 = Ros
CITY_NAME_SHORT:35 = Gds
CITY_NAME_SHORT:36 = Kor
CITY_NAME_SHORT:37 = Msc
CITY_NAME_SHORT:38 = Bru
CITY_NAME_SHORT:39 = Nam
CITY_NAME_SHORT:40 = Fri
CITY_NAME_SHORT:41 = Mag
CITY_NAME_SHORT:42 = Ber
CITY_NAME_SHORT:43 = Pin
CITY_NAME_SHORT:44 = Smo
CITY_NAME_SHORT:45 = Ryz
CITY_NAME_SHORT:46 = Bre
CITY_NAME_SHORT:47 = Nrm
CITY_NAME_SHORT:48 = Dan
CITY_NAME_SHORT:49 = Lux
CITY_NAME_SHORT:50 = Col
CITY_NAME_SHORT:51 = Wrc
CITY_NAME_SHORT:52 = Par
CITY_NAME_SHORT:53 = Met
CITY_NAME_SHORT:54 = Frk
CITY_NAME_SHORT:55 = Cot
CITY_NAME_SHORT:56 = Krw
CITY_NAME_SHORT:57 = Tal
CITY_NAME_SHORT:58 = Luc
CITY_NAME_SHORT:59 = Smr
CITY_NAME_SHORT:60 = Vlg
CITY_NAME_SHORT:61 = Ang
CITY_NAME_SHORT:62 = Wer
CITY_NAME_SHORT:63 = Dre
CITY_NAME_SHORT:64 = Str
CITY_NAME_SHORT:65 = Nur
CITY_NAME_SHORT:66 = Pra
CITY_NAME_SHORT:67 = Tes
CITY_NAME_SHORT:68 = Pre
CITY_NAME_SHORT:69 = Kiv
CITY_NAME_SHORT:70 = Rsv
CITY_NAME_SHORT:71 = Stl
CITY_NAME_SHORT:72 = Vic
CITY_NAME_SHORT:73 = Mun
CITY_NAME_SHORT:74 = Ast
CITY_NAME_SHORT:75 = Bor
CITY_NAME_SHORT:76 = Lyn
CITY_NAME_SHORT:77 = Bln
CITY_NAME_SHORT:78 = Inb
CITY_NAME_SHORT:79 = Win
CITY_NAME_SHORT:80 = Deb
CITY_NAME_SHORT:81 = Srk
CITY_NAME_SHORT:82 = Mln
CITY_NAME_SHORT:83 = Bda
CITY_NAME_SHORT:84 = Jas
CITY_NAME_SHORT:85 = Sev
CITY_NAME_SHORT:86 = Mls
CITY_NAME_SHORT:87 = Tou
CITY_NAME_SHORT:88 = Gen
CITY_NAME_SHORT:89 = Vnc
CITY_NAME_SHORT:90 = Bcr
CITY_NAME_SHORT:91 = Con
```
