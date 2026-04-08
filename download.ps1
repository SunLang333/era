<#
download.ps1

使用 Hugging Face 的 `hf` 命令下载指定的 GGUF 文件到 ./DotNet10Refactor/src，并输出详细日志。

用法:
  .\download.ps1            # 若文件不存在则下载
  .\download.ps1 -Force     # 强制重新下载（覆盖已存在文件）
#>

Param(
    [switch]$Force
)

$ErrorActionPreference = 'Stop'

function Write-Log {
    param([string]$Message)
    $time = (Get-Date).ToString('yyyy-MM-dd HH:mm:ss')
    Write-Host "[download.ps1] [$time] $Message"
}

$repoRoot = (Get-Location).ProviderPath
$destDir = Join-Path -Path $repoRoot -ChildPath 'DotNet10Refactor\src'
New-Item -ItemType Directory -Force -Path $destDir | Out-Null

# 配置（如需其他 model，可修改以下三项）
$repoId = 'mlabonne/Qwen3-0.6B-abliterated-GGUF'
$revision = 'main'
$fileName = 'qwen3-0.6b-abliterated.q4_k_m.gguf'
$destPath = Join-Path -Path $destDir -ChildPath $fileName

if (Test-Path $destPath -PathType Leaf) {
    if (-not $Force) {
        Write-Log "文件已存在: $destPath 。使用 -Force 强制重新下载。"
        return
    }
    Write-Log "检测到已存在文件，因 -Force 参数将删除: $destPath"
    Remove-Item -Path $destPath -Force
}

function Download-UsingHF {
    param(
        [Parameter(Mandatory=$true)][string]$RepoId,
        [Parameter(Mandatory=$true)][string]$Filename,
        [string]$Revision = 'main',
        [Parameter(Mandatory=$true)][string]$OutDir
    )

    Write-Log "检查 'hf' CLI 是否可用..."
    $hfCmd = Get-Command hf -ErrorAction SilentlyContinue
    if (-not $hfCmd) {
        Write-Log "未在 PATH 中找到 'hf' 可执行文件。"
        return $false
    }
    Write-Log "发现 'hf': $($hfCmd.Path)"

    $expectedOutFile = Join-Path -Path $OutDir -ChildPath $Filename

    # 尝试若干常见的 hf 子命令用法（不同版本的 hf 可能不同）
    $candidateArgs = @(
        @('repo','download',$RepoId,'--filename',$Filename,'--revision',$Revision,'--dir',$OutDir),
        @('hub','download',$RepoId,'--filename',$Filename,'--revision',$Revision,'--dir',$OutDir),
        @('download',$RepoId,'--filename',$Filename,'--revision',$Revision,'--dir',$OutDir)
    )

    foreach ($args in $candidateArgs) {
        $argsDisplay = $args -join ' '
        Write-Log "尝试命令: hf $argsDisplay"
        try {
            $output = & hf @args 2>&1
            $exit = $LASTEXITCODE
        } catch {
            $output = $_.Exception.Message
            $exit = 1
        }
        if ($output) { Write-Log "hf 输出:`n$output" }

        if ($exit -eq 0) {
            Write-Log "hf 子命令执行成功（退出码 0）。检查下载文件..."
            if (Test-Path $expectedOutFile) {
                Write-Log "文件已下载到: $expectedOutFile"
                return $true
            }
            # 有些版本的 hf 会将文件放在不同目录，尝试查找
            $found = Get-ChildItem -Path $OutDir -Filter $Filename -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
            if ($found) {
                if ($found.FullName -ne $expectedOutFile) {
                    Move-Item -Path $found.FullName -Destination $expectedOutFile -Force
                    Write-Log "移动文件 $($found.FullName) -> $expectedOutFile"
                } else {
                    Write-Log "找到文件: $expectedOutFile"
                }
                return $true
            }
            Write-Log "hf 子命令返回成功但未在预期位置找到文件，继续尝试其它用法。"
        } else {
            Write-Log "hf 子命令失败（退出码 $exit），继续尝试其它用法。"
        }
    }

    Write-Log "所有 hf 子命令尝试失败。"
    return $false
}

function Download-Fallback {
    param(
        [Parameter(Mandatory=$true)][string]$Url,
        [Parameter(Mandatory=$true)][string]$OutFile
    )

    Write-Log "开始后备下载：$Url -> $OutFile"

    # BITS 优先（Windows，支持断点续传）
    if (Get-Command Start-BitsTransfer -ErrorAction SilentlyContinue) {
        try {
            Write-Log "使用 Start-BitsTransfer 下载..."
            Start-BitsTransfer -Source $Url -Destination $OutFile -ErrorAction Stop
            Write-Log "Start-BitsTransfer 完成。"
            return
        } catch {
            Write-Log "Start-BitsTransfer 失败: $_"
        }
    }

    # Invoke-WebRequest 回退
    try {
        Write-Log "使用 Invoke-WebRequest 下载..."
        Invoke-WebRequest -Uri $Url -OutFile $OutFile -ErrorAction Stop
        Write-Log "Invoke-WebRequest 完成。"
        return
    } catch {
        Write-Log "Invoke-WebRequest 失败: $_"
    }

    # HttpClient 流式下载为最终回退方案
    try {
        Write-Log "使用 HttpClient 流式下载..."
        $client = [System.Net.Http.HttpClient]::new()
        $response = $client.GetAsync($Url, [System.Net.Http.HttpCompletionOption]::ResponseHeadersRead).Result
        $response.EnsureSuccessStatusCode()
        $stream = $response.Content.ReadAsStreamAsync().Result
        $fileStream = [System.IO.File]::Open($OutFile, [System.IO.FileMode]::Create, [System.IO.FileAccess]::Write, [System.IO.FileShare]::None)
        $buffer = New-Object byte[] 81920
        while (($read = $stream.Read($buffer, 0, $buffer.Length)) -gt 0) {
            $fileStream.Write($buffer, 0, $read)
        }
        $fileStream.Close()
        $stream.Dispose()
        $client.Dispose()
        Write-Log "HttpClient 流式下载完成。"
        return
    } catch {
        Write-Log "HttpClient 下载失败: $_"
    }

    throw "所有下载方法均失败: $Url"
}

try {
    $hfOk = Download-UsingHF -RepoId $repoId -Filename $fileName -Revision $revision -OutDir $destDir
    if ($hfOk) {
        Write-Log "通过 hf 下载成功: $destPath"
        exit 0
    }

    Write-Log "hf 下载未成功，改为使用 URL 回退下载。"
    $url = 'https://huggingface.co/mlabonne/Qwen3-0.6B-abliterated-GGUF/resolve/main/qwen3-0.6b-abliterated.q4_k_m.gguf?download=true'
    Download-Fallback -Url $url -OutFile $destPath
    Write-Log "回退下载完成: $destPath"
} catch {
    Write-Log "下载失败: $_"
    exit 1
}
