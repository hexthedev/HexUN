using System;
using HexUN.Events;
using UnityEngine;

namespace HexUN.Patterns
{
    [AddComponentMenu("HexUN.Patterns/CommandView/CommandListener/CVBooleanCommandListener")]
    public class CVBooleanCommandListener : CVCommandListener<Boolean, BooleanUnityEvent> {}
}