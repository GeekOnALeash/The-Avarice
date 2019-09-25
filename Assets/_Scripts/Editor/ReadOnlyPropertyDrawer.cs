using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEditor;
using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Editor
{
	[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	public sealed class ReadOnlyDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			GUI.enabled = false;
			EditorGUI.PropertyField(position, property, label, true);
			GUI.enabled = true;
		}
	}
}