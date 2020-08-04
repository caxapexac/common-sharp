// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using Caxapexac.Common.Sharp.Editor.Attributes;
using UnityEditor;
using UnityEngine;


namespace LeopotamGroup.EditorHelpers.Editor {
    /// <summary>
    /// Helper for custom flags selector.
    /// </summary>
    [CustomPropertyDrawer (typeof (EnumFlagsAttribute))]
    internal sealed class EnumFlagsAttributeInspector : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            property.intValue = EditorGUI.MaskField (position, label, property.intValue, property.enumNames);
        }
    }
}