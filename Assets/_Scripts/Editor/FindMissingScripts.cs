using UnityEditor;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice._Scripts.Editor
{
    public class FindMissingScripts : EditorWindow
    {
        [MenuItem("Tools/Find/FindMissingScripts")]
        public static void ShowWindow()
        {
            GetWindow(typeof(FindMissingScripts));
        }
 
        public void OnGUI()
        {
            if (GUILayout.Button("Find Missing Scripts in selected prefabs"))
            {
                FindInSelected();
            }
        }
        
        private static void FindInSelected()
        {
            GameObject[] go = Selection.gameObjects;
            int goCount = 0, componentsCount = 0, missingCount = 0;
            foreach (GameObject g in go)
            {
                goCount++;
                Component[] components = g.GetComponents<Component>();
                for (int i = 0; i < components.Length; i++)
                {
                    componentsCount++;
                    if (components[i] != null)
                    {
                        continue;
                    }

                    missingCount++;
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
            }
 
            Debug.Log($"Searched {goCount.ToString()} GameObjects, {componentsCount.ToString()} components, found {missingCount.ToString()} missing");
        }
    }
}