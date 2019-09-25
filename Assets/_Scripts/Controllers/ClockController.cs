using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Controllers
{
	internal static class ClockController
	{
		internal static void SetTimeScale(float timeScale) => Time.timeScale = timeScale;

		internal static float GetTimeScale() => Time.timeScale;
	}
}