# MSBuild API によるvcxproj 読み込みテスト

C# でMicrosoft.Build パッケージを利用してvcxproj ファイルを読み込むテストです。

- **MyEvaluator**
  vcxproj ファイルを読み込むC# プロジェクトです
- **testproj**
  MyEvaluator で読み込むためのC++ プロジェクトです

## 環境について

Visual Studio 2022 Community, .NET SDK 7 を使用しています。

## 実行方法

```
> powershell -ExecutionPolicy RemoteSigned .\testproj\makeproj.ps1
> cd MyEvaluator
> dotnet run ..\testproj\build\testapp\testapp.vcxproj
```

## プログラム解説

vcxproj の評価はMyEvaluator\Classes\MyEvaluator.cs のMyEvaluator クラスで行っています。

NuGet パッケージのMicrosoft.Build とMicrosoft.Build.Utilities.Core を追加しています。
Microsoft.Build.Utilities.Core はMicrosoft.Build をインストールしても自動的にはインストールされず、別途明示的に追加する必要があります。

Microsoft.Build.Evaluation.ProjectCollection クラスでvcxproj ファイルを読み込んで評価しますが、最低限のプロパティとしてVCInstallDir とVCTargetsPath を渡す必要があります。また、Microsoft.Build パッケージにはprops, targets ファイルが含まれていないため、MSBuild のパスを指定したMicrosoft.Build.Evaluation.Toolset インスタンスを用意する必要があります。

### C# プロジェクトの解説

C# 10/.NET 6 の"最上位レベルのステートメント" を使用しています。

csproj と同じ階層には唯一のcs ファイルがあり、Main メソッドを含むクラスは定義されていません。

追加のクラスはサブディレクトリに配置する必要があります。
