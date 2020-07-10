﻿using UnityEngine;
using HexUN.Data;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HexUN.Utilities
{
    public static class UTScriptableObject
    {

#if UNITY_EDITOR
        /// <summary>
        //	This makes it easy to create, name and place unique new ScriptableObject asset files.
        /// </summary>
        public static T CreateAsset<T>(string name, UnityPath directory, bool autoRefresh = true) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(asset, directory.AssetRelativePath.AddStep($"{name}.asset"));
            AssetDatabase.SaveAssets();
            if (autoRefresh)
            {
                AssetDatabase.Refresh();
            }

            return asset;
        }
#endif
    }
}