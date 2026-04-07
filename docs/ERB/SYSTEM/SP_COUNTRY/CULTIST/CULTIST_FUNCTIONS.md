# SYSTEM/SP_COUNTRY/CULTIST/CULTIST_FUNCTIONS.ERB — 自动生成文档

源文件: `ERB/SYSTEM/SP_COUNTRY/CULTIST/CULTIST_FUNCTIONS.ERB`

类型: .ERB

自动摘要: functions: TURNEND_CULTIST, CULTIST_DESTROY_MSG, START_TRAIN_COMMON_CULTIST, CULTIST_INIT, MASTER_CAPTURED_CULTIST, CULTIST_ENDING, SELECT_CHARA_RANDOM_LOGIC_CULTIST_RITUAL, CULTIST_RITUAL; UI/print

前 200 行源码片段:

```text
﻿;--------------------------------------
;ターンエンド時の外来兵の処理
;--------------------------------------
@TURNEND_CULTIST
#DIM 狂信者

狂信者 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_狂信者)

;8ターンに1回、儀式
CALL CULTIST_RITUAL(DAY % 8 == 0)

;--------------------------------------
;滅亡時の処理
;--------------------------------------
@CULTIST_DESTROY_MSG
CALL SINGLE_DRAWLINE
SETCOLOR カラー_注意
PRINTFORML
PRINTFORML
PRINTFORML
PRINTFORMW 滅びを悟った狂信者たちの教祖は、自らの肉体を捨て去り魂を次のステージへと踏み出したようです
PRINTFORMW 狂信者たちも後を追ったため、彼らは解散しました！
PRINTFORML
PRINTFORML
PRINTFORML
RESETCOLOR
CALL SINGLE_DRAWLINE

;-------------------------------------------------
;DESC  :狂信者所属時に閨・捕虜調教前にアイテムを追加する処理
;-------------------------------------------------
@START_TRAIN_COMMON_CULTIST()
ITEM:A_バイブ = 1
ITEM:A_アナルバイブ = 1
ITEM:A_縄 = 1
ITEM:A_目隠し = 1
ITEM:A_搾乳機 = 1
ITEM:A_媚薬 = 99
ITEM:A_排卵誘発剤 = 99
ITEM:A_桃源香 = 99
ITEM:A_おもちゃの注射器 = 1
ITEM:A_コンドーム = 99

;--------------------------------------
;外来勢力の初期化処理
;--------------------------------------
@CULTIST_INIT(ARG:0)
#DIM LCOUNT
VARSET LOCAL

SIF GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_狂信者) != -1
	RETURN 0

SIF SP_COUNTRY_RANK:特殊勢力_狂信者 == 0
	RETURN 0

SIF GET_NEW_COUNTRY() == -1
	RETURN 0

CALL CREATE_SP_COUNTRY(特殊勢力_狂信者)
LOCAL = RESULT
CALL INIT_SP_COUNTRY(LOCAL)

RETURN LOCAL

;-----------------------------------
;外来勢力に捕らえられたときのイベント
;-----------------------------------
@MASTER_CAPTURED_CULTIST(ARG:0)
PRINTFORMW 捕らえられた%ANAME(MASTER)%は狂信者たちに取り囲まれた
IF GETBIT(TALENT:MASTER:特殊勢力陥落系, 特殊勢力_狂信者)
	PRINTFORML 君は我々の仲間ではないか、どうして異端者どもに加わっていたんだ
	PRINTFORMW さあ、また神に仕えようではないか
	PRINTFORMW 狂信者たちは当然のように、%ANAME(MASTER)%を仲間に加えようとしてくるが……
	CALL ASK_YN("受け入れる", "拒否する")
	IF RESULT == 0
		PRINTFORMW もちろん、神に逆らおうなどと考えるはずもない
		PRINTFORMW %ANAME(MASTER)%の身体は疼き、自ら彼らに加わることに同意した
		PRINTFORMW 彼らの用意した法衣を身にまとうと、深い悦びが%ANAME(MASTER)%を包む
		PRINTFORMW 俗世の穢れた空気を吸わぬよう誂えられた覆面をかぶり、%ANAME(MASTER)%は再び彼らの一員となった……
		SETCOLOR カラー_注意
		PRINTFORMW %ANAME(MASTER)%は再び、狂信者たちに加わりました
		RESETCOLOR
	ELSE
		PRINTFORMW 思想を押し付けるな。%ANAME(MASTER)%は主張した
		PRINTFORMW 狂信者たちにはその態度が理解できないようだった
		PRINTFORMW 異端者に紛れて毒されたか、我々の正しい教義を教え込んでやらねばならない
		PRINTFORMW わきたつ狂信者たちは、%ANAME(MASTER)%を取り押さえ、枷で縛り、牢獄へと放り込んだ……
	ENDIF
ELSE
	PRINTFORML 異端者は本来、牢に放り込み、我々の教義を爪先から頭のてっぺんまで刷り込むことになっている
	PRINTFORMW だがお前は見どころがありそうだと呟いた
	PRINTFORMW 自ら教義を受け入れるというのなら、異端者であった罪を許し、牢獄行きは免除するとのことだが……
	PRINTFORMW 受け入れますか？
	CALL ASK_YN("受け入れる", "拒否する")
	IF RESULT == 0
		PRINTFORMW 投獄されるよりはマシだろう。%ANAME(MASTER)%が頷くと、狂信者たちは満足げに頷いた
		PRINTFORMW では法衣を身にまとえといわれ、%ANAME(MASTER)%はおとなしく従う
		PRINTFORMW 俗世の穢れた空気を吸わぬよう誂えられた覆面をかぶり、%ANAME(MASTER)%は彼らの一員となった……
		SETCOLOR カラー_注意
		PRINTFORMW %ANAME(MASTER)%は再び、狂信者たちに加わりました
		RESETCOLOR
	ELSE
		PRINTFORMW お前達になど手を貸すか。%ANAME(MASTER)%は毅然として言い放つ	
		PRINTFORMW その業を牢獄で清めるがよいと、彼らはそのまま%ANAME(MASTER)%を投獄した……
	ENDIF
ENDIF
IF RESULT == 0
	SETBIT TALENT:MASTER:特殊勢力陥落系, 特殊勢力_狂信者
	CFLAG:MASTER:所属 = ARG:0
	CALL PLAYER_FALLEN_TO_SP_COUNTRY(ARG:0)
	CALL CULTIST_FALLEN_LEAVE_MARK(MASTER)
	RETURN 0
ELSE
	CALL CAPTURE(MASTER, ARG:0)
	RETURN 2
ENDIF

;--------------------------------------
;エンディング
;--------------------------------------
@CULTIST_ENDING
PRINTFORML 狂信者たちは布教に成功した
PRINTFORMW 方法はどうあれ、彼らはその思想を幻想郷の隅々にまで浸透させたのだ
PRINTFORML 今日も彼らの儀式は行われている
PRINTFORML あちこちで男と女が交わり、人ならざるものが呼び出されては、贄の少女に神聖な種を植え付けていく
PRINTFORML これこそが、彼らの望んでいた楽園だった……
IF CFLAG:MASTER:所属 == GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_狂信者) && IS_FEMALE(MASTER)
	PRINTFORMW 
	PRINTFORMW 信者たちの中に、%ANAME(MASTER)%の姿もあった
	PRINTFORMW 模範的な信者ということで名を馳せ、今や幹部にまで上り詰めている
	PRINTFORMW ……そして、女信者として最高の名誉、神との交わりの栄誉を賜るに至った
	PRINTFORMW 特殊な排卵誘発剤を飲んだ%ANAME(MASTER)%は、神の子を宿す悦びに下腹を疼かせている
	PRINTFORML 儀式より呼び出された巨大な肉塊――彼らの「神」が、%ANAME(MASTER)%に覆い被さり、肉穴にグロテスクなモノをねじ込む
	PRINTFORMW %ANAME(MASTER)%は、たまらないといった声をあげ、何度も放たれる精液を肉穴で受け止めていく 
	PRINTFORMW 信者たちは神聖なる「儀式」を前に恭しくひれ伏し、神の子の誕生を寿いでいる……
	CALL FUCK_SP(MASTER, "触手, 欲望, 奉仕, 性技, 性交, 精愛, Ｖ, Ａ, Ｖ性交, Ａ性交, 口淫", "処女喪失, 膣内射精, Ａ処女喪失, 腸内射精, キス喪失", GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:特殊勢力_狂信者), GET_SPERM_ID("触手"), "触手", "触手", "触手", "強姦")
ENDIF
PRINTFORML 
PRINTFORMW 誰も不幸などではない。もはや幻想郷に、彼らの教えに背く者などいないのだから……

@SELECT_CHARA_RANDOM_LOGIC_CULTIST_RITUAL(対象)
#DIM 対象
#DIM 狂信者

狂信者 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_狂信者))

SIF IS_SP_CHARA(対象)
	RETURN 0
SIF !IS_FEMALE(対象)
	RETURN 0
SIF 対象 == GET_COUNTRY_BOSS(CFLAG:対象:所属)
	RETURN 0
SIF CFLAG:対象:所属 != 狂信者
	RETURN 0
SIF CFLAG:対象:捕虜先
	RETURN 0
SIF TALENT:対象:幼児
	RETURN 0
RETURN 1


;--------------------------------------
;定期イベント
;--------------------------------------
@CULTIST_RITUAL(条件)
#DIM 狂信者
#DIM 条件
#DIM 対象, 3
#DIM 対象数
#DIM メッセージ

VARSET 対象, -1
狂信者 = GET_COUNTRY_FROM_ID(SP_COUNTRY_ID:(特殊勢力_狂信者))

;狂信者勢力が存在し、条件を満たしている
SIF 狂信者 == -1 || !条件
	RETURN -1

CALL SELECT_CHARA_RANDOM_MULTI(VARSIZE("対象"), "CULTIST_RITUAL")

SIF SELECTED_CHARA_NUM <= 0
	RETURN -1

対象数 = 0
FOR LOCAL, 0, MIN(SELECTED_CHARA_NUM, VARSIZE("対象"))
	対象:LOCAL = SELECTED_CHARA:LOCAL
	対象数 ++
NEXT

LOCALS = 

FOR LOCAL, 0, 対象数
	SIF LOCAL > 0
		LOCALS = %LOCALS%、
	LOCALS = %LOCALS%%ANAME(対象:LOCAL)%
NEXT

SIF 対象数 > 1
	LOCALS = %LOCALS%ら
```
