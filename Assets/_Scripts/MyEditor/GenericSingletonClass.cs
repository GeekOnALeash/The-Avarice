using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries
{
	[DisallowMultipleComponent]
	public class GenericSingletonClass<T> : MonoBehaviour where T : Component
	{
		private static T __instance;

		protected static T Instance
		{
			get
			{
				if (__instance != null)
				{
					return __instance;
				}

				__instance = FindObjectOfType<T>();

				if (__instance != null)
				{
					return __instance;
				}

				var obj = new GameObject {name = typeof(T).Name};
				__instance = obj.AddComponent<T>();

				return __instance;
			}
		}
	}
}