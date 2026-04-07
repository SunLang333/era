# SYSTEM/STR_BODY.ERB — 自动生成文档

源文件: `ERB/SYSTEM/STR_BODY.ERB`

类型: .ERB

自动摘要: functions: STR_BODY, STR_BODY_MOD, NUM_STRBODY, FLAG_STRBODY, RSELECT_STRBODY, CHECK_STRBODY, CHECK_STRBODY_OR, CHECK_STRBODY_ADD, SPLIT_R

前 200 行源码片段:

```text
﻿
;--------------------------------------------------------
;@STR_BODY
;指定した部位についての描写を返す
;--------------------------------------------------------
@STR_BODY(ARGS , ARG)
#FUNCTIONS
#DIM 長さ
#DIMS 部位
#DIM 属性
#DIM 文末指定

文末指定 = 0

VARSET 長さ
VARSET 属性
VARSET 文末指定
VARSET LOCAL
VARSET LOCALS

属性 = FLAG_STRBODY(ARGS)
部位 = %RSELECT_STRBODY(ARGS)%

VARSET LOCALS

IF CHECK_STRBODY("長：短：処女確認", 属性)
	長さ = RAND(1, 3)
ELSEIF CHECK_STRBODY("長", 属性)
	長さ = 2
ELSEIF CHECK_STRBODY("短", 属性)
	長さ = 1
ENDIF

SELECTCASE 部位
	CASE "胸"
		IF IS_MALE(ARG)
			IF !CHECK_STRBODY("修飾", 属性)
				IF GROUPMATCH(TALENT:(ARG:0):体格, 体格_子供, 体格_小柄)
					LOCALS:0 = %SPLIT_R("胸")%
				ELSE
					LOCALS:0 = %SPLIT_R("胸：胸板")%
				ENDIF
			ENDIF
		ELSEIF 長さ == 0
			IF IS_PIERCED(ARG, ピアス_乳首) && CHECK_STRBODY("ピアス", 属性)
				LOCALS:0 = %LOCALS:0%%SPLIT_R("ピアスで飾られている：ピアスの付いた")%
			ELSEIF IS_TATTOOED(ARG, タトゥー_胸) && CHECK_STRBODY("タトゥー", 属性)
				LOCALS:0 = %STR_BODY_MOD("タトゥー", ARG, 属性, "胸")%
			ELSEIF CHECK_STRBODY("感度", 属性)
				SELECTCASE ABL:(ARG:0):Ｂ感 + TALENT:(ARG:0):Ｂ敏感 * 5 - TALENT:(ARG:0):Ｂ鈍感 * 5 + GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_淫乳) * 15
					CASE IS > 30
						LOCALS:0 = %LOCALS:0%%SPLIT_R("異常な感度の：快感に逆らえない：調教されつくした")%
					CASE IS > 20
						LOCALS:0 = %LOCALS:0%%SPLIT_R("過敏すぎる：快感に弱い：弱点そのものの")%
					CASE IS > 10
						LOCALS:0 = %LOCALS:0%%SPLIT_R("感度の良すぎる：刺激に弱い：弱点の")%
					CASE IS > 4
						LOCALS:0 = %LOCALS:0%%SPLIT_R("感じやすい：刺激に敏感な：反応のいい：性感帯の")%
					CASE IS > 1
						LOCALS:0 = %LOCALS:0%%SPLIT_R("開発途中の：感度良好な")%
				ENDSELECT
			ELSEIF (CHECK_STRBODY("精液汚れ", 属性) || CUM_CUR_AMOUNT:ARG:射精部位_胸 ) && !RAND:2
				IF CHECK_STRBODY("輪姦", 属性)
					LOCALS:0 = %LOCALS:0%%SPLIT_R("精液まみれの：白濁まみれの：白く染まった")%
				ELSE
					LOCALS:0 = %LOCALS:0%%SPLIT_R("精液で汚れた：白濁で汚れた")%
				ENDIF
			ELSEIF CHECK_STRBODY("性交", 属性)
				IF GET_BUSTSIZE(ARG:0) == 2
					IF CHECK_STRBODY_OR("騎乗位：背面騎乗位：背面座位", 属性) && !RAND:2
						LOCALS:0 = %LOCALS:0%%SPLIT_R("上下に弾む：上下に暴れる：跳ね回る：大きく弾む")%
					ELSE
						LOCALS:0 = %LOCALS:0%%SPLIT_R("激しく揺れる：ぶるぶると弾む：ゆさゆさと揺れる：ぶるんぶるんと暴れる：跳ね回る")%
					ENDIF
				ELSEIF GET_BUSTSIZE(ARG:0) == 1
					IF CHECK_STRBODY_OR("騎乗位：背面騎乗位：背面座位", 属性) && !RAND:2
						LOCALS:0 = %LOCALS:0%%SPLIT_R("上下に弾む：跳ね回る：大きく弾む")%
					ELSE
						LOCALS:0 = %LOCALS:0%%SPLIT_R("揺れる：激しく揺れる：ぶるぶると弾む：ゆさゆさと揺れる")%
					ENDIF
				ELSEIF GET_BUSTSIZE(ARG:0) == -1
					LOCALS:0 = %LOCALS:0%%SPLIT_R("震える：ふるふると震える：ぷるぷると揺れる")%
				ELSEIF GET_BUSTSIZE(ARG:0) != -2
					IF CHECK_STRBODY_OR("騎乗位：背面騎乗位：背面座位", 属性) && !RAND:2
						LOCALS:0 = %LOCALS:0%%SPLIT_R("上下に弾む")%
					ELSE
						LOCALS:0 = %LOCALS:0%%SPLIT_R("揺れる：ぷるぷると揺れる")%
					ENDIF
				ENDIF
			ENDIF
			IF CHECK_STRBODY("愛撫", 属性) && !RAND:2
				IF GET_BUSTSIZE(ARG:0) == 2
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手に収まらないほどの：抱えるほどの")%%STR_BODY_MOD("胸＿末尾", ARG, 属性)%
				ELSEIF GET_BUSTSIZE(ARG:0) == 1
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手から零れるほどの")%%STR_BODY_MOD("胸＿末尾", ARG, 属性)%
				ELSEIF GET_BUSTSIZE(ARG:0) == -1
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手にすっぽり収まる")%%STR_BODY_MOD("胸＿末尾", ARG, 属性)%
				ELSEIF GET_BUSTSIZE(ARG:0) == 0
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手ごろな大きさの")%%STR_BODY_MOD("胸＿末尾", ARG, 属性)%
				ENDIF
			ELSEIF CHECK_STRBODY("感触", 属性)
				IF GET_BUSTSIZE(ARG:0) > 0
					LOCALS:0 = %LOCALS:0%%SPLIT_R("柔らかな：吸い付くような：重量感のある：むっちりとした：もっちりとした：餅のように柔らかな：マシュマロのような")%%STR_BODY_MOD("胸＿末尾", ARG, 属性, "短")%
				ELSEIF GET_BUSTSIZE(ARG:0) == -1
					LOCALS:0 = %LOCALS:0%%SPLIT_R("柔らかな：張りのある：脂肪の薄い：ふにふにした")%%STR_BODY_MOD("胸＿末尾", ARG, 属性, "短")%
				ELSEIF GET_BUSTSIZE(ARG:0) == -2
					LOCALS:0 = %LOCALS:0%%SPLIT_R("膨らみの感じられない：脂肪の薄い")%%STR_BODY_MOD("胸＿末尾", ARG, 属性, "短")%
				ELSE
					LOCALS:0 = %LOCALS:0%%SPLIT_R("柔らかな")%%STR_BODY_MOD("胸＿末尾", ARG, 属性, "短")%
				ENDIF
			ELSE
				LOCALS:0 = %LOCALS:0%%STR_BODY_MOD("胸＿末尾", ARG, 属性)%
			ENDIF
		ELSE
			IF 長さ > 1
				IF CHECK_STRBODY("性交", 属性) && !RAND:2
					IF GET_BUSTSIZE(ARG:0) == 2
						IF CHECK_STRBODY_OR("騎乗位：背面騎乗位：背面座位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("突き上げに合わせて揺れる：派手に上下する：上下に暴れ回る")%
						ELSEIF CHECK_STRBODY("後背位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("うつ伏せで潰れた：激しく前後に揺れる")%
						ELSEIF CHECK_STRBODY("対面座位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("密着して潰れた：押し付けられて潰れた")%
						ELSE
							LOCALS:0 = %LOCALS:0%%SPLIT_R("抽挿に合わせて揺れる：ぶるんぶるんと暴れる：激しく跳ね回る：だぷんだぷんと跳ねる")%
						ENDIF
					ELSEIF GET_BUSTSIZE(ARG:0) == 1
						IF CHECK_STRBODY_OR("騎乗位：背面騎乗位：背面座位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("突き上げに合わせて揺れる：派手に上下する")%
						ELSEIF CHECK_STRBODY("後背位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("うつ伏せで潰れた：激しく前後に揺れる")%
						ELSEIF CHECK_STRBODY("対面座位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("密着して潰れた：押し付けられて潰れた")%
						ELSE
							LOCALS:0 = %LOCALS:0%%SPLIT_R("抽挿に合わせて揺れる：ぶるんぶるんと暴れる：ゆさゆさと揺れる：激しく揺れる：派手に揺れる")%
						ENDIF
					ELSEIF GET_BUSTSIZE(ARG:0) == -1
						LOCALS:0 = %LOCALS:0%%SPLIT_R("抽挿に合わせて揺れる：ふるふると震える：ぷるぷると揺れる")%
					ELSEIF GET_BUSTSIZE(ARG:0) != -2
						IF CHECK_STRBODY_OR("騎乗位：背面騎乗位：背面座位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("突き上げに合わせて揺れる：上下に弾む")%
						ELSEIF CHECK_STRBODY("後背位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("前後に揺れる")%
						ELSEIF CHECK_STRBODY("対面座位", 属性) && !RAND:2
							LOCALS:0 = %LOCALS:0%%SPLIT_R("密着した：押し付けられた")%
						ELSE
							LOCALS:0 = %LOCALS:0%%SPLIT_R("抽挿に合わせて揺れる：ぷるぷると揺れる")%
						ENDIF
					ENDIF
				ELSEIF TALENT:(ARG:0):母乳体質 && !RAND:3
					LOCALS:0 = %SPLIT_R("母乳の染み出す：ミルクを蓄えた")%
				ENDIF
			ENDIF
			IF IS_PIERCED(ARG, ピアス_乳首) && (CHECK_STRBODY("ピアス", 属性) || 長さ > 1 && !RAND:5)
				LOCALS:0 = %LOCALS:0%%SPLIT_R("ピアスで飾られている：ピアスの付いた")%%STR_BODY_MOD("胸＿末尾長", ARG, 属性)%
			ELSEIF IS_TATTOOED(ARG, タトゥー_胸) && !CHECK_STRBODY("性交", 属性) && 長さ > 1 && !RAND:5
				LOCALS:0 = %STR_BODY_MOD("タトゥー", ARG, 属性, "胸")%%STR_BODY_MOD("胸＿末尾長", ARG, 属性)%
			ELSEIF CHECK_STRBODY("感度", 属性) || !CHECK_STRBODY_OR("外見：感触", 属性) && CHECK_STRBODY_OR("愛撫", 属性) && (ABL:(ARG:0):Ｂ感 > 4 || TALENT:(ARG:0):Ｂ敏感) && !RAND:4
				IF ABL:(ARG:0):Ｂ感 == 0 && !TALENT:(ARG:0):Ｂ敏感
					LOCALS:0 = %LOCALS:0%%SPLIT_R("未開発の：開発されていない")%
				ELSE
					SELECTCASE ABL:(ARG:0):Ｂ感 + TALENT:(ARG:0):Ｂ敏感 * 5 - TALENT:(ARG:0):Ｂ鈍感 * 5 + GETBIT(TALENT:(ARG:0):淫乱系, 素質_淫乱_淫乳) * 15
						CASE IS > 30
							LOCALS:0 = %LOCALS:0%%SPLIT_R("淫らに開発されきった：異常な感度の：快感に逆らえない：調教されつくした")%
						CASE IS > 20
							LOCALS:0 = %LOCALS:0%%SPLIT_R("快楽を教え込まれた：過敏すぎる：快感に弱い：弱点そのものの")%
						CASE IS > 10
							LOCALS:0 = %LOCALS:0%%SPLIT_R("十分に開発された：感度の良すぎる：刺激に弱い：弱点の")%
						CASE IS > 4
							LOCALS:0 = %LOCALS:0%%SPLIT_R("快感を覚えた：感じやすい：刺激に敏感な：反応のいい")%
						CASE IS > 1
							LOCALS:0 = %LOCALS:0%%SPLIT_R("快感を覚えつつある：感度良好な")%
					ENDSELECT
				ENDIF
				LOCALS:0 = %LOCALS:0%%STR_BODY_MOD("胸＿末尾", ARG, 属性)%
			ELSEIF CHECK_STRBODY("愛撫", 属性) && GET_BUSTSIZE(ARG:0) != -2 && !RAND:3
				IF GET_BUSTSIZE(ARG:0) == 2
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手に収まらないほどの：抱えるほどの：ぐにゃぐにゃと歪む")%
				ELSEIF GET_BUSTSIZE(ARG:0) == 1
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手から零れるほどの：手に合わせて歪む")%
				ELSEIF GET_BUSTSIZE(ARG:0) == -1
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手にすっぽり収まる")%
				ELSE
					LOCALS:0 = %LOCALS:0%%SPLIT_R("手ごろな大きさの")%
				ENDIF
				LOCALS:0 = %LOCALS:0%%STR_BODY_MOD("胸＿末尾", ARG, 属性, "短")%
			ELSEIF CHECK_STRBODY("接触", 属性) && !RAND:3 || CHECK_STRBODY("感触", 属性)
				IF GET_BUSTSIZE(ARG:0) > 0
					LOCALS:0 = %LOCALS:0%%SPLIT_R("柔らかな：吸い付くような：重量感のある：むっちりとした：もっちりとした：餅のように柔らかな：マシュマロのような")%
				ELSEIF GET_BUSTSIZE(ARG:0) == -1
					LOCALS:0 = %LOCALS:0%%SPLIT_R("柔らかな：張りのある：脂肪の薄い：ふにふにした")%
				ELSEIF GET_BUSTSIZE(ARG:0) == -2
					LOCALS:0 = %LOCALS:0%%SPLIT_R("膨らみの感じられない：脂肪の薄い")%
				ELSE
					LOCALS:0 = %LOCALS:0%%SPLIT_R("柔らかな")%
				ENDIF
				LOCALS:0 = %LOCALS:0%%STR_BODY_MOD("胸＿末尾", ARG, 属性, "短")%
			ELSE
				IF GET_BUSTSIZE(ARG:0) == -2
					IF TALENT:(ARG:0):体格 == 体格_子供 && !RAND:3
```
