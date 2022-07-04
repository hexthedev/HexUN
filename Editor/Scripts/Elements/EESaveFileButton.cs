﻿using System;
using Hex.UN.Editor.Scripts.Elements._abstract;
using Hex.UN.Editor.Scripts.Elements._struct;
using Hex.UN.Runtime.Framework.Data.Persistence;
using HexCS.Core;
using UnityEditor;
using UnityEngine;

namespace Hex.UN.Editor.Scripts.Elements
{
    /// <summary>
    /// Editor Element containing render functions for buttons
    /// </summary>
    public class EESaveFileButton : ALabeledEditorElement
    {
        private UnityPath _lastSavePath = UnityPath.AssetsPath;

        /// <summary>
        /// Invoked when the user choses a path
        /// </summary>
        public event Action<UnityPath> OnPathChosen;

        /// <summary>
        /// Construct a button
        /// </summary>
        /// <param name="label"></param>
        public EESaveFileButton(SLabel label) => Label = label;

        /// <summary>
        /// Renders the SaveFileButton
        /// </summary>
        /// <param name="defaultName">The default name of the file</param>
        /// <param name="extention">The extenstion of the file</param>
        /// <param name="options"></param>
        public void Render_Basic(string defaultName, string extention, params GUILayoutOption[] options)
        {
            if (GUILayout.Button(Content, options))
            {
                UnityPath path = new PathString(EditorUtility.SaveFilePanel(Content.text, _lastSavePath, defaultName, extention));

                if (path != null)
                {
                    OnPathChosen?.Invoke(path);
                }
            }
        }
    }
}