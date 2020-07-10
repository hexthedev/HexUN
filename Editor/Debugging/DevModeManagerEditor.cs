using UnityEditor;
using TobiasUN.Core.Debugging;

namespace TobiasUN.Core.Debugging
{
    [CustomEditor(typeof(DevModeManager))]
    [CanEditMultipleObjects]
    public class DevModeManagerEditor : ADevModeManagerEditor
    {
        protected override void HandleInspectorGUIAfterDevOptions() { }

        protected override void HandleOnEnable() { }
    }
}