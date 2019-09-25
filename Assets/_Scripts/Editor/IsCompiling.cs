using UnityEditor;
using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Editor
{
	public class IsCompiling : EditorWindow
	{
		private const int WindowWidth = 100;
		private static EditorWindow __window;
		private static GUIStyle __style;

		[MenuItem("Debug/Is compiling?")]
		private static void Init()
		{
			__window = GetWindowWithRect(typeof(IsCompiling), new Rect(0, 0, WindowWidth, 200));
			__window.titleContent = new GUIContent("Is Compiling?");
			__window.Show();
		}

		private void OnGUI()
		{
			__style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter};
			EditorGUILayout.LabelField("Compiling:", EditorApplication.isCompiling ? "Yes" : "No", __style, GUILayout.ExpandWidth(true));

			Repaint();
		}
	}
}