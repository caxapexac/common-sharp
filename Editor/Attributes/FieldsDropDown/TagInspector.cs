using UnityEditor;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Editor.Attributes.Fields
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagInspector : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                if (!_checked) Warning(property);
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }

        private bool _checked;

        private void Warning(SerializedProperty property)
        {
            Debug.LogWarning(string.Format("Property <color=brown>{0}</color> in object <color=brown>{1}</color> is of wrong type. Expected: String",
                property.name, property.serializedObject.targetObject));
            _checked = true;
        }
    }
}