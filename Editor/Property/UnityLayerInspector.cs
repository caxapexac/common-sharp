using Caxapexac.Common.Sharp.Editor.Attributes;
using UnityEditor;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Editor.Property {
    /// <summary>
    /// Helper for single layer selector.
    /// </summary>
    [CustomPropertyDrawer (typeof (UnityLayerAttribute))]
    internal sealed class UnityLayerAttributeInspector : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            property.intValue = EditorGUI.LayerField (position, label, property.intValue);
        }
    }
}