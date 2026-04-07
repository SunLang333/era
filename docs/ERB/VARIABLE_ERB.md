# VARIABLE.ERH（ERB 下）—— 全局变量与常量说明（可复现级别）

目的：把 `ERB/VARIABLE.ERH` 中对游戏运行至关重要的全局数组、常量与语义注释成文档，方便把这些数据结构在其他语言中一一复现。

> 注：文件量大，下面按主题分组列出所有重要结构（数组大小、语义、使用场景）。完整源文件仍保留在仓库中，文档以便于实现为目的。

---

## 1. 系统/状态相关
- `TRAIN_PLACE`（标量）：当前调教/训练地点（字符串或 ID）。
- `MTAR[100]`, `MTAR_TMP[100]`（int 列表）：多目标 ID 列表，建议实现为动态数组或定长列表并维护 `MTAR_NUM`。
- `MTAR_NUM`, `MTAR_NUM_TMP`：当前多目标数量。
- `MPLY[100]`, `MPLY_TMP[100]`, `MPLY_NUM`：多玩家（操作者）列表及数量。
- `PRISONER_TARGET[3]`：捕虜调教目标的保存区（3 个槽）。
- `MASTER_ID`：当前选中/注册角色 ID（主角索引）。
- `COM_ABLE_FLAG[1000]`：命令能否被 USERCOM 使用（布尔或位标记）。
- `COM_CONFLICT_FLAG[1000]`：冲突命令标志，用于自动取消互斥命令。
- `COM_ENABLE`（标量）：全局开关，0 则禁止显示/执行所有 USERCOM。
- `SELECTCOM_NAME`, `PREVCOM_NAME`：当前与上次命令名（字符串）。
- `COS_LIST[360]`：预计算的 cos 值缓存（用于三角、角度近似或绘图）。
- `SHOP_CHARA_LIST[MAX_CHARA_NUM]`：商店或选择界面显示用的角色序列（长度 = MAX_CHARA_NUM）。
- `SELECTCOM_TYPE`, `PREVCOM_TYPE`：命令执行主体类型（0 主角、1 目标、2 第三方）。
- `ABL_MIN[100], ABL_MAX[100]`：每项能力的允许最小/最大值。

实现建议：在复现时把上面全局数组封装在一个 `GameState` 或 `World` 对象中，便于序列化/反序列化和单元测试。

---

## 2. 命令/经验/喜好
- `COM_EXP`（CHARADATA, 维度 3000）：记录各命令的执行次数（索引规则：0-999 玩家、1000-1999 目标、2000-2999 第三者）。
- `COM_KNOWLEDGE[1000]`：命令知识等级存储。（CHARADATA）
- `COM_TENDENCY[3000]`：命令偏好度（0-3），影响成瘾与自动执行概率。

实现细节：`CHARADATA` 在工程中是按角色为主键的二维存储；复现时可使用 `charData[charIndex].comExp[commandIndex]` 的形式。

---

## 3. 性向与性经历（重要）
- `SEXUAL_PREFERENCE`/`SEXUAL_PREFERENCE_EXP[64]`：性向位掩码与扩展位数组（长度 64），支持按位运算查询与添加。
- 常量 `性的嗜好_*`：列举所有性向的索引（例如 `性的嗜好_愛撫したい = 0` ...）。
- `SEXUAL_PREFERENCE_STR[]`：与上面常量对应的字符串数组，便于 UI 展示。

- 初体験记录：
  - `SEXUAL_EXPERIENCE[4]`：记录第一次发生的对象编号（0: キス, 1: 童貞, 2: 処女, 3: アナル処女）。
  - `SEXUAL_LAST_EXPERIENCE[4]`：记录最近一次的对象。
  - 相应的 `_SITUATION` 数组保存情境描述（字符串或索引）。

实现要点：初体验类数据对剧情发展与触发事件十分关键，复现时必须保持数据类型与默认值一致（例如未发生使用 null/0/特殊标记）。

---

## 4. 精液槽（CUM）
- `CUM_SLOT_NUM = 16`；槽名称 `CUM_SLOT_NAME[]`（如 "膣内", "アナル" 等）映射到整数常量。
- 每角色保存：
  - `CUM_GET_COUNT[CUM_SLOT_NUM]`, `CUM_GET_AMOUNT[CUM_SLOT_NUM]`（被射精计数与总量）
  - `CUM_CUR_AMOUNT[CUM_SLOT_NUM]`（当前场次内的量，支持被吞/被清除等机制）
  - `CUM_TO_COUNT`, `CUM_TO_AMOUNT`（该角色射出的计数/量）

实现说明：槽内量需要被事件逻辑读取/修改；复现时可将其放在 `Character.cumSlots[]` 结构下。

---

## 5. 自动/配置保存（Autosave / Config）
- `AUTOSAVE_DOMAIN_NUM = 5`, `AUTOSAVE_DOMAIN[]`：自动保存槽。
- `CONFIG[1000]`：全局配置数组，索引分配：0-299 一般设置、300-499 SLG 设置、500+ 预留。
- `COM_FILTER[1000]`：命令过滤器。
- `G_CONFIG`, `G_FILTER`：用于保存多个配置集（例如用于快速切换的 5 个配置槽）。
- `G_CONFIG_NAME[]`, `G_CONFIG_FILTER_NAME[]`, `G_CONFIG_DAILY_NAME[]`：配置名字符串数组。

实现建议：使用命名常量或枚举对 CONFIG 索引做封装（例如 CONFIG.RANDOM_MALE_PERCENT = 3），避免魔法数。

---

## 6. 会议与事件（EVENTTRAIN / EVENTEND）
- `EVENTTRAIN_CALLEE[10]`, `EVENTTRAIN_CALLEE_NUM`：用于在训练事件期调用的回调函数名列表（字符串数组）。
- `EVENTEND_CALLEE[10]`, `EVENTEND_CALLEE_NUM`：事件结束时调用的回调。

复现：在实现时将这些字符串转换为函数指针或注册回调 lambda 列表。

---

## 7. 强制命令队列（TRAIN_FORCED_COM）
- `TRAIN_FORCED_COM[100]`：强制的训练命令编号队列
- `TRAIN_FORCED_COM_EQUIP[100]`, `TRAIN_FORCED_COM_INITIATOR[100]`：命令装备和发起者相关信息
- `TRAIN_FORCED_COM_MPLY[100][10]`, `TRAIN_FORCED_COM_MTAR[100][10]`：对应每个强制命令的 MPLY/MTAR 列表，最大 10
- `TRAIN_FORCED_COM_NUM`, `TRAIN_FORCED_COM_CUR`：总数与当前执行游标

实现：队列应支持追加（ADD）、执行（DO_...）、清空和序列化。

---

## 8. 体型/素质/标签/常量（摘录）
- `MAX_CHARA_NUM = 3000`：最大角色数。
- `MAX_MASTER = 30`：最大注册主角数。
- `RANK` 等能力等级、`TAG_NAME[]` 标签列表（比如 "人間", "妖怪" 等），用于 UI 与筛选。
- 素質（TALENT）相关常量大量存在（例如 淫乱 素質系列），建议将这些常量在目标语言中声明为枚举（enum）以便语义清晰。

---

## 9. 难点与复现注意事项
- `CHARADATA` 体系：源码中大量使用 `CHARADATA SAVEDATA ...` 语法表示按角色保存的多维数组。复现时建议把 `Character` 作为类，内部包含多个数组，如 `exp[]`, `talent[]`, `comExp[]` 等，避免平面化索引导致混乱。
- 初体验/SEXUAL_* 与 TALENT 的交互非常多，强烈建议在实现时先完成 `Character` 数据模型与常量映射，再实现影响性的函数（如 VIRGIN_COMMON、KISS_COMMON 等）。
- 版本迁移代码（`UPDATE.ERB`）依赖于这些常量与数组精确位置；复现时先以源码为准实现数据布局，再实现迁移脚本。

---

## 10. 下一步
- 我可以把 `VARIABLE.ERH` 中每一段常量块（例如性嗜好、CUM、TALENT、TAG）单独导出为 `DOCS/ERB/VARIABLE_*` 子文档并生成对应的 enum/struct 代码片段（C#、TypeScript、Python 任意一种）。

