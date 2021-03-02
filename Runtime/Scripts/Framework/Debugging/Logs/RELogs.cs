using HexUN.Framework.SharedResource;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace HexUN.Framework.Debugging
{
    /// <summary>
    /// Shared resource for cahching logs
    /// </summary>
    [CreateAssetMenu(fileName = "RELogs", menuName = "HexUN/Framework/SharedResources/Logs")]
    public class RELogs : ASOSharedResource
    {
        [SerializeField]
        [Tooltip("The maximum number of logs that will be stored")]
        private int _max;

        private Queue<string> _logs = new Queue<string>();

        /// <summary>
        /// Adds a log to the logs
        /// </summary>
        public void AddLog(string log)
        {
            _logs.Enqueue(log);

            if(_logs.Count > _max)
            {
                _logs.Dequeue();
            }
        }
    }
}