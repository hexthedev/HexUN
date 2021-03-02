namespace HexUN.Framework.Debugging
{
    /// <summary>
    /// Capable of logging messages
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Logs non-critical info
        /// </summary>
        void Info(string category, string message);

        /// <summary>
        /// Logs a warning that may need paying attention to
        /// </summary>
        void Warn(string category, string message);

        /// <summary>
        /// Logs errors in the applicaiton that break functionality
        /// </summary>
        void Error(string category, string message);
    }
}