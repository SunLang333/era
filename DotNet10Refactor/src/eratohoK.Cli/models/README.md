在这个目录里放 **且仅放 1 个** `.gguf` 模型文件，然后再执行 AOT publish。

- 发布时，`eratohoK.Cli.csproj` 会把 `models/*.gguf` 嵌入到 exe。
- 运行时，程序会自动把嵌入资源解包到 `%LOCALAPPDATA%\eratohoK\model-cache\`。
- 如果这里放了多个 `.gguf`，程序会拒绝启动，避免加载错模型。

建议：

1. 把真实模型文件复制到本目录。
2. 确保目录中只有一个 `.gguf`。
3. 再运行 `dotnet publish --project .\DotNet10Refactor\src\eratohoK.Cli\eratohoK.Cli.csproj -c Release -r win-x64 -p:PublishAot=true`。