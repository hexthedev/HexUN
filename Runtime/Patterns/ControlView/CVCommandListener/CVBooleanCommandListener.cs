using System;
using TobiasUN.Core.Events;
using UnityEngine;

namespace TobiasUN.Core.Patterns
{
    [AddComponentMenu("TobiasUN/Core/Patterns/CommandView/CommandListener/CVBooleanCommandListener")]
    public class CVBooleanCommandListener : CVCommandListener<Boolean, BooleanUnityEvent> {}
}