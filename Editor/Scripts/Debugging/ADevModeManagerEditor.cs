using UnityEditor;

namespace Hex.UN.Editor.Scripts.Debugging
{
    [CanEditMultipleObjects]
    public abstract class ADevModeManagerEditor : UnityEditor.Editor
    {
        private SerializedProperty _devmode;
        private SerializedProperty _devMonobehaviours;

        private void OnEnable()
        {
            _devmode = serializedObject.FindProperty("_devmode");
            _devMonobehaviours = serializedObject.FindProperty("_devMonobehaviours");

            HandleOnEnable();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_devmode);

            if (_devmode.boolValue)
            {
                EditorGUILayout.PropertyField(_devMonobehaviours, true);
            }

            HandleInspectorGUIAfterDevOptions();

            serializedObject.ApplyModifiedProperties();
        }

        protected abstract void HandleInspectorGUIAfterDevOptions();

        protected abstract void HandleOnEnable();
    }
}