using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	public static class GameObjectExtensions
	{
		public static void ToggleActive(this GameObject go)
		{
			go.SetActive(!go.activeSelf);
		}

		public static GameObject GetParent(this GameObject go)
		{
			Transform parent;
			return (parent = go.transform.parent) == null ? null : parent.gameObject;
		}
	}
}