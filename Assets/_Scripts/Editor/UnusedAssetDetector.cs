using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class UnusedAssetDetector : EditorWindow
{
	private struct AssetHolder
	{
		public string name;
		public int instanceId;

		public AssetHolder(string path, int instanceId)
		{
			name = Path.GetFileName(path);
			this.instanceId = instanceId;
		}
	}

	private const string META_EXTENSION = ".meta";

	private List<AssetHolder> unusedAssets = null;

	private static GUIStyle m_boxGUIStyle; // GUIStyle used to draw the results of the search

	public static GUIStyle boxGUIStyle
	{
		get
		{
			if (m_boxGUIStyle == null)
			{
				m_boxGUIStyle = new GUIStyle(EditorStyles.helpBox);
				m_boxGUIStyle.alignment = TextAnchor.MiddleCenter;
				m_boxGUIStyle.font = EditorStyles.label.font;
			}

			return m_boxGUIStyle;
		}
	}

	private Vector2 scrollPosition = Vector2.zero;

	[MenuItem("Tools/Asset Usage/Unused Asset Detector")]
	private static void Init()
	{
		var window = GetWindow<UnusedAssetDetector>();
		window.titleContent = new GUIContent("Unused Asset Detector");
		window.Show();
	}

	private void OnGUI()
	{
		if (unusedAssets == null)
		{
			GUILayout.Box("Only 'Scenes In Build' in Build Settings are searched for dependencies!",
			              GUILayout.ExpandWidth(true));

			if (GUILayout.Button("Find unused assets", GUILayout.Height(25)))
			{
				FindUnusedAssets();
			}
		} else
		{
			GUILayout.BeginVertical();

			GUILayout.Box($"{unusedAssets.Count.ToString()} possibly unused asset(s) found",
			              GUILayout.ExpandWidth(true));

			if (GUILayout.Button("Search Again", GUILayout.Height(25)))
			{
				FindUnusedAssets();
			}

			GUILayout.Space(10);

			scrollPosition = GUILayout.BeginScrollView(scrollPosition);

			for (var i = 0; i < unusedAssets.Count; i++)
			{
				if (GUILayout.Button(unusedAssets[i].name, boxGUIStyle))
				{
					Selection.activeInstanceID = unusedAssets[i].instanceId;
					EditorGUIUtility.PingObject(unusedAssets[i].instanceId);
				}
			}

			GUILayout.EndScrollView();

			GUILayout.EndVertical();
		}
	}

	private void OnDestroy()
	{
		unusedAssets = null;
	}

	private void FindUnusedAssets()
	{
		if (unusedAssets == null)
		{
			unusedAssets = new List<AssetHolder>(128);
		} else
		{
			unusedAssets.Clear();
		}

		// Get all scenes in build settings (ticked)
		var scenesTemp = EditorBuildSettings.scenes;
		var targetSceneCount = 0;
		for (var i = 0; i < scenesTemp.Length; i++)
		{
			if (scenesTemp[i].enabled)
			{
				targetSceneCount++;
			}
		}

		if (targetSceneCount == 0)
		{
			return;
		}

		var targetScenes = new Object[targetSceneCount];
		for (int i = 0, j = 0; i < scenesTemp.Length; i++)
		{
			if (scenesTemp[i].enabled)
			{
				targetScenes[j++] = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenesTemp[i].path);
			}
		}

		var dependencies = EditorUtility.CollectDependencies(targetScenes);
		var usedAssets = new HashSet<string>();

		for (var i = 0; i < dependencies.Length; i++)
		{
			usedAssets.Add(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(dependencies[i])));
		}

		for (var i = 0; i < targetSceneCount; i++)
		{
			usedAssets.Add(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(targetScenes[i])));
		}

		var projectDir = Directory.GetParent(Application.dataPath).FullName;
		if (projectDir[projectDir.Length - 1] != '/' && projectDir[projectDir.Length - 1] != '\\')
		{
			projectDir = $"{projectDir}/";
		}

		var substrIndex = projectDir.Length;

		var files = Directory.GetFiles(Application.dataPath, "*", SearchOption.AllDirectories);
		for (var i = 0; i < files.Length; i++)
		{
			if (!files[i].EndsWith(META_EXTENSION))
			{
				var relativePath = files[i].Substring(substrIndex);
				if (!usedAssets.Contains(AssetDatabase.AssetPathToGUID(relativePath)))
				{
					TryAddUnusedAsset(relativePath);
				}
			}
		}
	}

	private void TryAddUnusedAsset(string path)
	{
		var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
		if (asset == null)
		{
			return;
		}

		if (!IsTypeDerivedFrom(asset.GetType(), typeof(MonoScript)))
		{
			var instanceId = asset.GetInstanceID();
			unusedAssets.Add(new AssetHolder(path, instanceId));
		}
	}

	// Check if "child" is a subclass of "parent" (or if their types match)
	private bool IsTypeDerivedFrom(System.Type child, System.Type parent)
	{
		if (child.IsSubclassOf(parent) || child == parent)
		{
			return true;
		}

		return false;
	}
}