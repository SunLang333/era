# ERB -> Pseudocode 文档（自动生成）

概览：
- 已为仓库内 `ERB/` 整个目录自动生成逐文件伪代码/片段文档，输出到 `DOCS/ERB/`，结构与 `ERB/` 保持镜像。
- 生成器脚本：`tools/generate_docs.py`（可用于按子目录生成），另有 `tools/generate_cloth_docs.py`（示例）与校验脚本 `tools/validate_calls.py` 与 `tools/check_pairing.py`。

快速统计（已验证）：
- ERB 源文件数量：2638
- 为每个 ERB 源文件生成对应 Markdown 文档（已配对）

验证：
- 已运行静态验证（`tools/validate_calls.py`），得到：
	- 已定义函数数：13768
	- 被调用函数数：1402
	- 在源码中被调用但未在 ERB 源内找到定义的函数：159（多数为引擎/动态生成或以特殊方式注册的回调，需要人工复查）。
	- 若需，我可把未匹配的函数列表另存为 `DOCS/ERB/validation_unknown_calls.txt`。

如何重现文档生成：
1. 在仓库根目录运行（需要 Python 3）:

```powershell
python tools/generate_docs.py ERB
```

2. 指定子目录，例如只为 `ERB/CLOTH` 生成：

```powershell
python tools/generate_docs.py ERB/CLOTH
```

下一步建议：
- 若目标是“可重现游戏”，我可以：
	1. 把伪代码集合整理成一个实现蓝图（例如 C# 项目骨架或 Python 原型），并生成接口/数据结构定义（Character, Config, ABL/EXP mapping 等）；或
	2. 针对 `tools/validate_calls.py` 列出的 159 个未匹配调用，逐个跟踪出处并补充文档/映射。

已完成：ERB 全目录文档化与基础验证。若要我继续把伪代码转成可编译的骨架（例如 C# 类型+方法），请告诉我目标语言与优先模块（例如 `Character/Config/Train`）。
