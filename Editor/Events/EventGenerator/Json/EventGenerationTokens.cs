using System;
using UnityEngine;

namespace TobiasUN.Core.Events
{
    /// <summary>
    /// Represents a collection of events that need generating
    /// </summary>
    [Serializable]
    public class EventGenerationTokens
    {
        public EventGenerationToken[] Tokens;
    }
}