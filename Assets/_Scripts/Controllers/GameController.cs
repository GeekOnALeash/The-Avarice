using com.ArkAngelApps.TheAvarice.Managers;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Controllers
{
	public sealed class GameController : GenericSingletonClass<GameController>
	{
		[SerializeField] private UnityEvent onApplicationQuit;

		internal static bool isPaused;
		internal static bool isQuiting;
		private static float __timeScaleRef = 1f;
		private static float __volumeRef = 1f;

		private void Start()
		{
			SystemVariables.Instance.cursors.SetDefaultCursor();
		}

		private void OnApplicationQuit()
		{
			isQuiting = true;
			onApplicationQuit.Invoke();
		}

		internal static void Quit()
		{
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			UnityEngine.Application.Quit();
#endif
		}

		internal static void PauseGame()
		{
			__timeScaleRef = ClockController.GetTimeScale();
			ClockController.SetTimeScale(0.0f);

			__volumeRef = AudioController.GetVolume();
			AudioController.SetVolume(0f);

			isPaused = true;
			GarbageManager.Collect();
		}

		internal static void UnPauseGame()
		{
			if (!isPaused)
			{
				return;
			}

			ClockController.SetTimeScale(__timeScaleRef);
			AudioController.SetVolume(__volumeRef);
			isPaused = false;
			GarbageManager.Collect();
		}
	}
}