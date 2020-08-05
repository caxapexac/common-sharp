// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using Caxapexac.Common.Sharp.Editor.Attributes;
using UnityEditor;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Editor.Property
{
    [CustomPropertyDrawer(typeof(HtmlColorAttribute))]
    internal sealed class HtmlColorAttributeInspector : PropertyDrawer
    {
        private const int HtmlLineWidth = 280;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var htmlRect = position;
            htmlRect.width = HtmlLineWidth;
            var colorRect = position;
            colorRect.x += HtmlLineWidth;
            colorRect.width = position.width - HtmlLineWidth;
            var htmlValue = EditorGUI.TextField(htmlRect, label, "#" + ColorUtility.ToHtmlStringRGBA(property.colorValue));
            Color color;
            if (ColorUtility.TryParseHtmlString(htmlValue, out color))
            {
                property.colorValue = color;
            }
            property.colorValue = EditorGUI.ColorField(colorRect, property.colorValue);
        }
    }
}