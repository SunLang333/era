# ERB 文件索引与文档计划

来源：本索引基于仓库 `ERB/` 目录扫描结果（共计 2638 个条目，含子目录与文件）。

## 总览
- 总文件数（扫描结果）：2638
- 主要子目录（已发现）：
  - `ABL/`
  - `CLOTH/` 及其子目录（TOP, BOTTOM, SOCKS, ...）
  - `DEBUGMENU/`
  - `LIBRARY/`
  - `R_CHARA/`
  - `SHOP/`（含 `SHOP_LIFE/`、`SHOP_SLG/`）
  - `SKILLS/`（大量以角色 ID 分组）
  - `SLG/`
  - `SYSTEM/`
  - `TRAIN/`
  - `口上/`（口上与日常文案，按角色或编号分组）
  - 以及若干根目录脚本：`SORT.ERB`、`UPDATE.ERB`、`VARIABLE.ERH`、`SHOP.ERB` 等

## 文档结构（生成计划）
- `DOCS/ERB/INDEX.md`（本文件）
- `DOCS/ERB/<folder>/` 每个子目录下将生成：
  - `README.md`：目录总体说明 + 主要函数/数据结构列表
  - 对应目录下每个 `.ERB` / `.ERH` 文件生成 `<原名>.md`，内容为：
    - 简短说明（目的）
    - 参数与依赖（全局变量/常量/CSV）
    - 完整伪代码（以函数为单位）
    - 复现注意事项与测试建议

## 当前进度
- 已完成：扫描 `ERB/` ，并为部分重要文件生成伪代码文档：
  - `DOCS/ERB/SORT.md`
  - `DOCS/ERB/UPDATE.md`
  - `DOCS/ERB/VARIABLE_ERB.md`
- 接下来：按优先级（核心逻辑 → 玩法模块 → 文案/口上）逐目录生成文档。

## 优先级建议（将按此顺序生成文档）
1. `SYSTEM/`（核心函数库：`_FUNCTION.ERB`, `CONFIG.ERB`, `HELP.ERH`, 等）
2. `ABL/`（能力与成长规则）
3. `SKILLS/`（技能模板与通用技能函数）
4. `SHOP/`（生活/SLG 的交互与事件）
5. `TRAIN/`（调教流程）
6. `R_CHARA/`、`CLOTH/`（角色生成与着装）
7. `口上/`（口上/日常文案，量大但多为数据/模板）

## 说明
- 本索引为自动初始步骤生成，后续会为每个目录生成更细致的 README 与按文件的伪代码文档。
- 由于文件规模巨大，文档将分批生成；我会先完成核心功能模块（`SYSTEM/`, `ABL/`, `TRAIN/`, `SKILLS/`），再处理文案性内容（`口上/`）以保持可用性。

