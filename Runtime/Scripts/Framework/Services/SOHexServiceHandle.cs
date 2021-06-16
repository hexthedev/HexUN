using UnityEngine;

namespace HexUN.Framework.Services
{
    /// <summary>
    /// SOWrapper for common service functions. Acts as a way to do
    /// hex service related commands as UnityEventResponses
    /// </summary>
    public class SOHexServiceHandle : ScriptableObject
    {
        #region API
        /// <summary>
        /// Quits the applicaiton via the IAppControl interface
        /// </summary>
        public void IAppControl_Quit()
        {
            NgHexServices.Instance.AppControl.Quit();
        }
        #endregion
    }
}