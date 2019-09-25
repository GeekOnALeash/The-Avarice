using System;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene
{
	public sealed class AreaHandler : MonoBehaviour
	{
		[Header("Settings")] public bool showBackground;

		public UnityEvent showAreaEvents;
		public UnityEvent hideAreaEvents;

		private bool _isStarted;
		private bool _quiting;

		private void Start()
		{
			_isStarted = true;
		}

		private void OnEnable()
		{
			if (!_isStarted)
			{
				return;
			}

			ShowArea();
		}

		private void OnDisable()
		{
			if (_quiting)
			{
				return;
			}

			HideArea();
		}

		private void OnApplicationQuit()
		{
			_quiting = true;
		}

		private void ShowArea()
		{
			SystemVariables.Instance.mainCamera.EnableBackground(showBackground);
			showAreaEvents.Invoke();
		}

		private void HideArea()
		{
			hideAreaEvents.Invoke();
		}
	}
}
