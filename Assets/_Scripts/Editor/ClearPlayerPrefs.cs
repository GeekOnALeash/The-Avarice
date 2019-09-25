#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// ReSharper disable once CheckNamespace
public class ClearPlayerPrefs : Editor
{
	[MenuItem("Edit/Custom/Clear All PlayerPrefs")]
	private static void ClearAll()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs cleared");
	}
}