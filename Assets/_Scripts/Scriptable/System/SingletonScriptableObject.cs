/************************************************************
 * Better Singleton by David Darias
 * Use as you like - credit where due would be appreciated :D
 * Licence: WTFPL V2, Dec 2014
 * Tested on Unity v5.6.0 (should work on earlier versions)
 * 03/02/2017 - v1.1 
 * **********************************************************/

using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable
{
	public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		//Private reference to the scriptable object
		private static T __instance;
		private static bool __instantiated;

		internal static T Instance
		{
			get
			{
				if (__instantiated)
				{
					return __instance;
				}

				var singletonName = typeof(T).Name;

				//Look for the singleton on the resources folder
				var assets = Resources.LoadAll<T>("");

				if (assets.Length > 1)
				{
					Debug.LogError($"Found multiple {singletonName}s on the resources folder. It is a Singleton ScriptableObject, there should only be one.");
				}

				if (assets.Length == 0)
				{
					__instance = CreateInstance<T>();
					Debug.LogError($"Could not find a {singletonName} on the resources folder. It was created at runtime, therefore it will not be visible on the assets folder and it will not persist.");
				} else
				{
					__instance = assets[0];
				}

				__instantiated = true;

				return __instance;
			}
		}
	}
}