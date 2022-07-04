using Hex.UN.Runtime.Framework.Debugging;
using UnityEditor;

namespace Hex.UN.Editor.Scripts.Debugging
{
    [CustomEditor(typeof(DevModeManager))]
    [CanEditMultipleObjects]
    public class DevModeManagerEditor : ADevModeManagerEditor
    {
        protected override void HandleInspectorGUIAfterDevOptions() { }

        protected override void HandleOnEnable() { }
    }
}