using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

namespace HexUN.Framework.Debugging
{
    [CreateAssetMenu(fileName = "HexLog", menuName = "HexUN/Services/HexLog")]
    public class SOHexLog : ScriptableObject, ILog
    {
        private const string cOpenBrack = "[";
        private const string cCloseBrack = "]";
        private const string cSep = " - ";

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
        public void Error(string category, string message, Exception e)
        {
            string log = WriteLog(category, $"{message}\n Exception: {e.Message}\nStack Trace:\n {e.StackTrace}");
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
            
        }
    }
}