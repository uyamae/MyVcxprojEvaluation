using Microsoft.Build.Evaluation;

namespace MyEvaluator;

/// <summary>
/// プロジェクトを読み込むクラス
/// </summary>
public class MyEvaluator
{
    /// <summary>
    /// プロジェクト読み込み時に使用するプロパティ
    /// </summary>
    private Dictionary<string, string> Properties = new Dictionary<string, string>()
    {
        { "VSInstallDir", @"C:\Program Files\Microsoft Visual Studio\2022\Community\" },
        { "VCTargetsPath", @"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Microsoft\VC\v170\" }
    };
    /// <summary>
    /// ツールセットのパス
    /// </summary>
    private string ToolsPath = @"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\";
    /// <summary>
    /// プロジェクトを読み込む
    /// </summary>
    /// <param name="projectPath">存在するvcxproj のファイルパス</param>
    public void Load(string projectPath)
    {
        // 読み込みに使用するプロジェクトコレクション
        ProjectCollection projColl = new ProjectCollection();
        // props, targets を使用するためのツールセット
        Toolset toolset = new Toolset("Current", ToolsPath, projColl, null);
        // ツールセットをプロジェクトコレクションに追加
        projColl.AddToolset(toolset);
        // プロジェクトを読み込む
        Project proj;
        try
        {
            proj = projColl.LoadProject(projectPath, Properties, null);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
            return;
        }
        // 評価されたプロパティの内容を表示する
        foreach (var prop in proj.AllEvaluatedProperties)
        {
            // 特定文字列を含むものだけを表示する
            bool hit = false;
            if (prop.Name.Contains("includepath", StringComparison.OrdinalIgnoreCase))
            {
                hit = true;
            }
            else if (prop.Name.Contains("llvminstalldir", StringComparison.OrdinalIgnoreCase))
            {
                hit = true;
            }
            else if (prop.Name.Contains("vsinstallroot", StringComparison.OrdinalIgnoreCase))
            {
                hit = true;
            }
            if (!hit)
            {
                continue;
            }
            Console.WriteLine($"{prop.Name}:{prop.UnevaluatedValue}");
            Console.WriteLine($"-> {prop.EvaluatedValue}");
        }
    }
}
