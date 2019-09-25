using UnityEditor;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice._Scripts.Editor
{
	public class FindMissingScriptsRecursively : EditorWindow
	{
		private static int __goCount, __componentsCount, __missingCount;

		[MenuItem("Tools/Find/FindMissingScriptsRecursively")]
		public static void ShowWindow()
		{
			GetWindow(typeof(FindMissingScriptsRecursively));
		}

		public void OnGUI()
		{
			if (GUILayout.Button("Find Missing Scripts in selected GameObjects"))
			{
				FindInSelected();
			}
		}

		private static void FindInSelected()
		{
			GameObject[] go = Selection.gameObjects;
			__goCount = 0;
			__componentsCount = 0;
			__missingCount = 0;
			foreach (GameObject g in go)
			{
				FindInGO(g);
			}

			Debug.Log($"Searched {__goCount.ToString()} GameObjects, {__componentsCount.ToString()} components, found {__missingCount.ToString()} missing");
		}

		private static void FindInGO(GameObject g)
		{
			__goCount++;
			Component[] components = g.GetComponents<Component>();
			for (int i = 0; i < components.Length; i++)
			{
				__componentsCount++;
				if (components[i] != null)
				{
					continue;
				}

				__missingCount++;
				string s = g.name;
				Transform t = g.transform;
				while (t.parent != null)
				{
					var parent = t.parent;
					s = $"{parent.name}/{s}";
					t = parent;
				}

				Debug.Log($"{s} has an empty script attached in position: {i.ToString()}", g);
			}

			// Now recurse through each child GO (if there are any):
			foreach (Transform childT in g.transform)
			{
				FindInGO(childT.gameObject);
			}
		}
	}
}