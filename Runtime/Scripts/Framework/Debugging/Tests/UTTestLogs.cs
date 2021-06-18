using UnityEngine;

namespace HexUN.Framework.Debugging
{
    public static class UTTestLogs
    {
        /// <summary>
        /// Prints a generic test log to the unity log 
        /// </summary>
        public static void TestLog(string test, bool result)
        {
            if (result)
            {
                Debug.Log($"[SUCCESS] {test}");
            }
            else
            {
                Debug.LogWarning($"[FAIL] {test}");
            }
        }
    }
}