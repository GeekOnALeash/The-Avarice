using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Controllers
{
	public sealed class ScreenController : GenericSingletonClass<ScreenController>
	{
		[ReadOnly] [SerializeField] private int currentScreenWidth;
		[ReadOnly] [SerializeField] private int currentScreenHeight;

		public UnityEvent screenSizeChangedEvent;

		private float _horizExtent;
		private float _vertExtent;

		private void Start()
		{
			if (SystemVariables.Instance.mainCamera != null)
			{
				_vertExtent = SystemVariables.Instance.mainCamera.camera.orthographicSize;

				_horizExtent = _vertExtent * Screen.width / Screen.height;
				currentScreenWidth = Screen.width;
				currentScreenHeight = Screen.height;

				InvokeRepeating(nameof(CheckForSizeChange), 0f, 0.3F);
			} else
			{
				Debug.LogError("Camera.main is null");
			}
		}

		private void CheckForSizeChange()
		{
			if (Screen.width == currentScreenWidth && Screen.height == currentScreenHeight) {
				return;
			}

			_vertExtent = SystemVariables.Instance.mainCamera.camera.orthographicSize;
			_horizExtent = _vertExtent * Screen.width / Screen.height;

			screenSizeChangedEvent.Invoke();
		}
	}
}