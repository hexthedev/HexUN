using System;
using TobiasCSStandard.Data.Persistence;
using TobiasUN.Core.Data;
using UnityEditor;
using UnityEngine;

namespace TobiasUN.Core.Events
{
    public static class EMEventGeneratorJson
    {
        [MenuItem("Assets/TobiasUN/GenerateEventsJson", false, 20)]
        public static void EMGenerateEventsJson(MenuCommand command)
        {
            UnityEngine.Object obj = Selection.activeObject;
            TextAsset asset = obj as TextAsset;
            EventGenerationTokens tokens = JsonUtility.FromJson<EventGenerationTokens>(asset.text);

            PathString path = AssetDatabase.GetAssetPath(obj.GetInstanceID());
            PathString folder = path.RemoveStep();

            for (int i = 0; i < tokens.Tokens.Length; i++)
            {
                EventGenerationToken to = tokens.Tokens[i];

                EditorUtility.DisplayProgressBar(
                    "Generating Events",
                    $"Generating {to.Type} Event to {to.Path}",
                    (float)i / tokens.Tokens.Length
                );

                PathString p = UTEFileLocationType.GetFileLocation(EFileLocationType.Assets) + to.Path;

                UTEventGeneration.GenerateEventsOfAllTypes(
                    UTEFileLocationType.GetFileLocation(EFileLocationType.Assets) + to.Path,
                    to.Type,
                    to.Namespace,
                    to.MenuPath,
                    to.EventTypeNamespace
                );
            }

            EditorUtility.DisplayProgressBar(
                "Generating Events",
                $"Finalizing and Compiling",
                1f
            );

            AssetDatabase.Refresh();
            EditorUtility.ClearProgressBar();
        }
        
        [MenuItem("Assets/TobiasUN/GenerateEventsJson", true)]
        public static bool EMGenerateEventsJsonValidator()
        {
            TextAsset asset = Selection.activeObject as TextAsset;
            if (asset == null) return false;

            try
            {
                EventGenerationTokens token = JsonUtility.FromJson<EventGenerationTokens>(asset.text);
                if (token == null || token.Tokens == null || token.Tokens.Length == 0) return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}