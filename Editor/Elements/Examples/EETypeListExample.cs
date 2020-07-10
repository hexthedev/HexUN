using System;
using System.Reflection;
using TobiasCSStandard.Core;
using TobiasCSStandard.Reflection;
using HexUN.App;
using UnityEditor;
using UnityEngine;

namespace HexUN.EditorElements
{ 
    /// <summary>
    /// Example InteractableList
    /// </summary>
    public class EETypeListExample : EditorWindow
    {
        EETypeList _list;

        string _console;

        // Add menu item named "My Window" to the Window menu
        [MenuItem("Tobias/Examples/Elements/TypeList")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            GetWindow(typeof(EETypeListExample));
        }
        private void OnEnable()
        {
            Predicate<Type> test = UTType.Test_Or(
                UTType.ETypeTest.ABSTRACT,
                UTType.ETypeTest.ANONYMOUS,
                UTType.ETypeTest.GENERIC,
                UTType.ETypeTest.SEALED
            );


            _list = new EETypeList(new Assembly[] { typeof(int).Assembly, typeof(UTArray).Assembly, typeof(AppLifecycle).Assembly }, 2, test);
        }

        private void OnGUI()
        {
            _list.Render_Basic();

            _list.OnTypeSelected += _list_OnTypeInteracted;

            GUI.enabled = false;
            EditorGUILayout.TextArea(_console);
            GUI.enabled = true;
        }

        private void _list_OnTypeInteracted(Type arg1)
        {
            _console = $"The type {arg1.Name} was selected";
        }
    }
}