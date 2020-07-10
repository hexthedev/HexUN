using System.Collections;
using System.Collections.Generic;
using TobiasCSStandard.Core;
using UnityEngine;

namespace TobiasUN.Core.Work
{
    /// <summary>
    /// A completion token provides an event subscriber that can be used to subscribe
    /// to the completion of work
    /// </summary>
    public struct CompletionToken
    {
        public IEventSubscriber OnWorkComplete;
    }
}