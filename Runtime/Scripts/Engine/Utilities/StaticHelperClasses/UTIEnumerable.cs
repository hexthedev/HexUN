using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace Hex.UN.Runtime.Engine.Utilities
{
    /// <summary>
    /// Contains utilities for working with enumerables
    /// </summary>
    public static class UTIEnumerable
    {
        /// <summary>
        /// Perform an action on eachelement of the enumerable
        /// </summary>
        public static async UniTask DoAsync<T1>(this IEnumerable<T1> enumerable, Func<T1, UniTask> action)
        {
            foreach (T1 element in enumerable) await action(element);
        }
    }
}