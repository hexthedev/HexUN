using System;

namespace Hex.UN.Editor.Scripts.Events.EventGenerator.Json
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