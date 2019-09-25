using System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Managers
{
	internal static class GarbageManager
	{
		internal static void Collect()
		{
			Resources.UnloadUnusedAssets();
			GC.Collect();
		}
	}
}