using UnityEngine;

namespace TobiasUN.Core.Data
{
    public class PersistenceExampleController : MonoBehaviour
    {
        public void GetRuntimeFileLogsDirectory()
        {
            UnityPath path = Files.GetPath(EFileLocationType.RuntimeFiles, ECommonFileType.Logs);

            Debug.Log($"Created the project logs path {path.ToString()}");

            Debug.Log($"Created a Unity Path for Unity utilities. {path.Path}");
            Debug.Log($"AbsolutePath is {path.AbsolutePath}");
            Debug.Log($"Asset Relative Path is {path.AssetRelativePath}");
            Debug.Log($"Resource Relative Path is {path.ResourceRelativePath}");
        }

        public void GetRuntimeFileLogsFile()
        {
            UnityPath path = Files.GetPath(EFileLocationType.RuntimeFiles, ECommonFileType.Logs).Path.AddStep("log.txt");

            Debug.Log($"Created the file at the path {path.ToString()}");

            Debug.Log($"Created a Unity Path for Unity utilities. {path.Path}");
            Debug.Log($"AbsolutePath is {path.AbsolutePath}");
            Debug.Log($"Asset Relative Path is {path.AssetRelativePath}");
            Debug.Log($"Resource Relative Path is {path.ResourceRelativePath}");
        }
    }
}