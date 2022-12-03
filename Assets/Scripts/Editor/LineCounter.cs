using System.Diagnostics;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LineCounter : EditorWindow
{
    private string filesPath;
    
    [MenuItem("blazeDev/Line Counter")]
    private static void ShowWindow()
    {
        var window = GetWindow<LineCounter>();
        window.titleContent = new GUIContent("Line Counter");
        window.Show();
    }

    private void Awake()
    {
        UpdateStats();
    }

    private void OnProjectChange()
    {
        UpdateStats();
    }

    private void OnGUI()
    {
        var process = new Process();
        process.StartInfo.FileName = "wc";
        process.StartInfo.Arguments = $"-l {filesPath}";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        foreach (var str in output.Split('\n'))
        {
            if (str.EndsWith("total"))
            {
                int.TryParse(str[..^"total".Length].Trim(), out var number);
                GUILayout.Label($" Lines: {number - 56} of 100", new GUIStyle
                {
                    fontSize = 32,
                    fontStyle = FontStyle.Bold
                });
            }
        }
    }
    
    private void UpdateStats()
    {
        var assetPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".cs"));
        filesPath = string.Join(" ", assetPaths);
    }
}