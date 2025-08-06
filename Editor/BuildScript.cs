using UnityEditor;

public class BuildScript
{
    public static void BuildAndroid()
    {
        string path = "build/app.aab";
        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/SampleScene.unity" },
            path,
            BuildTarget.Android,
            BuildOptions.None
        );
    }
}
