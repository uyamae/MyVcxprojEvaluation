# Microsoft.Build 利用サンプル

## プロジェクトの作成

以下を実行 (cs ファイルの内容は自分で編集)
※コミットされているものは作成済みファイル

```powershell
dotnet new console --framework net7.0
dotnet new class -o Classes -n MyEvaluator
dotnet add package Microsoft.Build --version 17.7.0
dotnet add package Microsoft.Build.Utilities.Core --version 17.7.0
```
