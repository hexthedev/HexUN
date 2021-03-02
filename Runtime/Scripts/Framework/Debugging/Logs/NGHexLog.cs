using HexUN.MonoB;

using System.Text;

using UnityEngine;

namespace HexUN.Framework.Debugging
{
    /// <summary>
    /// Logs to the unity logger and to a shared resource object if avalable
    /// </summary>
    public class NGHexLog : HexBehaviour, ILog
    {
        private const string cOpenBrack = "[";
        private const string cCloseBrack = "]";
        private const string cSep = " - ";

        [SerializeField]
        [Tooltip("The logs shared resource")]
        private RELogs _logs;

        private StringBuilder _sb = new StringBuilder();

        #region API
        /// <inheritdoc />
        public void Error(string category, string message)
        {
            string log = WriteLog(category, message);
            Debug.LogError(log);
            PushLog(log);
        }

        /// <inheritdoc />
        public void Info(string category, string message)
        {
            string log = WriteLog(category, message);
            Debug.Log(log);
            PushLog(log);
        }

        /// <inheritdoc />
        public void Warn(string category, string message)
        {
            string log = WriteLog(category, message);
            Debug.LogWarning(log);
            PushLog(log);
        }
        #endregion

        private string WriteLog(string category, string message)
        {
            _sb.Clear();
            _sb.Append(cOpenBrack);
            _sb.Append(category);
            _sb.Append(cCloseBrack);
            _sb.Append(cSep);
            _sb.AppendLine(message);
            return _sb.ToString();
        }

        private void PushLog(string log)
        {
            if(_logs != null)
            {
                _logs.AddLog(log);
                _logs.PushUpdate();
            }
        }
    }
}
