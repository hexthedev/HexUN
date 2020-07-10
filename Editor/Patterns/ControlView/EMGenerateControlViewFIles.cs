using System;
using System.Text;
using TobiasCSStandard.Data.Persistence;
using UnityEditor;
using UnityEngine;

namespace HexUN.Patterns
{
    /// <summary>
    /// Menu items for generating ControlViewPatternFiles
    /// </summary>
    public static class EMGenerateControlViewFiles
    {
        [MenuItem("Assets/HexUN/Patterns/GenerateControlView", false, 20)]
        public static void EMGenerateControlView(MenuCommand menuCommand)
        {
            UnityEngine.Object obj = Selection.activeObject;
            TextAsset asset = obj as TextAsset;
            ControlViewGenerationToken token = JsonUtility.FromJson<ControlViewGenerationToken>(asset.text);

            PathString path = AssetDatabase.GetAssetPath(obj.GetInstanceID());
            PathString folder = path.RemoveStep();

            StringBuilder sb = new StringBuilder();
            EditorUtility.DisplayProgressBar("Generating ControlView Files", $"Provider Interface", 0);
            token.GenerateProviderInterface(sb, folder.AddStep("Provider"));
            sb.Clear();

            EditorUtility.DisplayProgressBar("Generating ControlView Files", $"Provider Interface Event Listener", 0.2f);
            token.GenerateEventListenerBase(sb, folder.AddStep("Provider"));
            sb.Clear();

            EditorUtility.DisplayProgressBar("Generating ControlView Files", $"Control Interface", 0.4f);
            token.GenerateControlInterface(sb, folder.AddStep("Control"));
            sb.Clear();

            EditorUtility.DisplayProgressBar("Generating ControlView Files", $"Control Base", 0.6f);
            token.GenerateControlBase(sb, folder.AddStep("Control"));
            sb.Clear();

            EditorUtility.DisplayProgressBar("Generating ControlView Files", $"View Base", 0.8f);
            token.GenerateViewBase(sb, folder.AddStep("View"));

            EditorUtility.DisplayProgressBar(
                "Generating ControlView Files",
                $"Finalizing and Compiling",

                1f
            );

            AssetDatabase.Refresh();
            EditorUtility.ClearProgressBar();
        }

        [MenuItem("Assets/HexUN/Patterns/GenerateControlView", true)]
        public static bool EMGenerateControlViewValidator()
        {
            TextAsset asset = Selection.activeObject as TextAsset;
            if (asset == null) return false;

            try
            {
                ControlViewGenerationToken token = JsonUtility.FromJson<ControlViewGenerationToken>(asset.text);
                if (token.Data == null || token.Data.Length == 0) return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}