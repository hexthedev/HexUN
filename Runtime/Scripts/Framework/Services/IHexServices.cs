using HexUN.App;
using HexUN.Framework.Input;
using HexUN.Framework.Debugging;
using ILog = HexUN.Framework.Debugging.ILog;

namespace HexUN.Framework.Services
{
    public interface IHexServices
    {
        /// <summary>
        /// Provides access to application control singleton
        /// </summary>
        public IAppControl AppControl { get; }

        /// <summary>
        /// Returns the loggin mechanism for the framework
        /// </summary>
        public ILog Log { get; }

        /// <summary>
        /// Provides access to mono behaviour callbacks
        /// </summary>
        public IMonoCallbacks MonoCallbacks { get; }
        /// <summary>
        /// Provides access to mono behaviour callbacks
        /// </summary>
        public IInput Input { get; }
    }
}