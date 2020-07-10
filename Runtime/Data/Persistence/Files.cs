namespace HexUN.Data
{
    /// <summary>
    /// Manages path to a central folder used to store configuration files.
    /// </summary>
    public static class Files
    {
        /// <summary>
        /// Returns a UnityPath representing a folder based on the type and file. Files
        /// can be saved in these folders
        /// </summary>
        /// <param name="location"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static UnityPath GetPath(EFileLocationType location, ECommonFileType file)
        {
            return UTEFileLocationType.GetFileLocation(location).AddStep(file.ToString());
        }
    }
}