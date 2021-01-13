using HexCS.Core;
using HexCS.Data.Persistence;

namespace HexUN.Data
{
    /// <summary>
    /// Enumeration containing label locations that map to common paths in unity projects
    /// </summary>
    public enum EFileLocationType : byte
    {
        /// <summary>
        /// The ProjectName/Assets folder
        /// </summary>
        Assets = 0,

        /// <summary>
        /// The ProjectName folder
        /// </summary>
        Project = 1,

        /// <summary>
        /// ProjectName/Assets/_EditorAssets. Used for editor configurations that
        /// need to be stored in the project. Saves for editor menus and what not
        /// </summary>
        EditorAssets = 2,

        /// <summary>
        /// The persistentDataPath/_RuntimeFiles used to save runtime files for
        /// the game
        /// </summary>
        RuntimeFiles = 3
    }

    public static class UTEFileLocationType
    {
        private const string cEditorAssetsFolderName = "_EditorAssets";
        private static UnityPath _editorAssetsUnityPath = null;
        private static UnityPath cEditorAssetsUnityPath
        {
            get
            {
                if(_editorAssetsUnityPath == null) _editorAssetsUnityPath = UnityPath.AssetsPath.Path.InsertAtEnd(cEditorAssetsFolderName);
                return _editorAssetsUnityPath;
            }
        }

        private const string cRuntimeFilesFolderName = "_RuntimeFiles";
        private static UnityPath _runtimeFilesUnityPath = null;
        private static UnityPath cRuntimeFilesUnityPath
        {
            get
            {
                if (_runtimeFilesUnityPath == null) _runtimeFilesUnityPath = UnityPath.PersistentDataPath.Path.InsertAtEnd(cRuntimeFilesFolderName);
                return _runtimeFilesUnityPath;
            }
        }

        /// <summary>
        /// Gets a PathString 
        /// </summary>
        /// <param name="gfl"></param>
        /// <returns></returns>
        public static PathString GetFileLocation(EFileLocationType gfl)
        {
            switch (gfl)
            {
                case EFileLocationType.Assets:
                    return UnityPath.AssetsPath;
                case EFileLocationType.Project:
                    return UnityPath.ProjectPath;
                case EFileLocationType.EditorAssets:
                    return cEditorAssetsUnityPath;
                case EFileLocationType.RuntimeFiles:
                    return cRuntimeFilesUnityPath;
            }

            return null;
        }
    }
}
