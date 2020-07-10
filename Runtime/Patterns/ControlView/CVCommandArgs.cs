using System;
using HexUN.Work;
using UnityEngine;

namespace HexUN.Patterns
{
    /// <summary>
    /// A command that comes from a Control calls in a ControlView command pattern
    /// </summary>
    public struct CVCommand
    {
        /// <summary>
        /// Token used by the control to check that all views have completed work
        /// based on command
        /// </summary>
        public WorkToken Token;

        /// <summary>
        /// Arguments associated with the command
        /// </summary>
        public object Args;

        public CVCommand(WorkToken token, object args = null)
        {
            Token = token;
            Args = args;
        }

        /// <summary>
        /// Try to get the command args as type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cast"></param>
        /// <returns></returns>
        public bool TryGet<T>(out T cast)
        {
            if (Args == null)
            {
                cast = default;
                return false;
            }

            try
            {
                cast = (T)Args;
            }
            catch(Exception e)
            {
                Debug.LogError($"Attempting to unpack CVCommand as type {typeof(T)} failed. {e}");
                cast = default;
                return false;
            }

            return true;
        }
    }
}