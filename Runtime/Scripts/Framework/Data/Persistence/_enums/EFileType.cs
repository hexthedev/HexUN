namespace HexUN.Data
{
    /// <summary>
    /// Used to organize files of various common types. 
    /// can be used as folder names
    /// </summary>
    public enum ECommonFileType : byte
    {
        /// <summary>
        /// Log files
        /// </summary>
        Logs = 0,

        /// <summary>
        /// Config files
        /// </summary>
        Configs = 1,

        /// <summary>
        /// Save files
        /// </summary>
        Saves = 2,

        /// <summary>
        /// Data fiels used in the game and stored
        /// </summary>
        Data = 3
    }
}