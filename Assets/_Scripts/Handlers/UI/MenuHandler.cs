using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Helpers;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries.Extensions;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.UI
{
	public sealed class MenuHandler : MonoBehaviour
	{
		[SerializeField] private Overlay overlay;
		[SerializeField] private PauseMenuHandler pauseMenu;
		private bool _overlayShown;

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Update()
		{
			if (SystemVariables.Instance.keybinds.Pause())
			{
				if (Controller.UI.window.AreWindowsDisplayed() && !GameController.isPaused)
				{
					// If windows are displayed close top most window and return false.
					Controller.UI.window.CloseNearestWindow();
				}

				if (!_overlayShown)
				{
					overlay.SetAlpha(FadeType.In);
					_overlayShown = true;
				} else
				{
					overlay.SetAlpha(FadeType.Out);
					_overlayShown = false;
				}

				pauseMenu.gameObject.ToggleActive();
			}
		}
	}
}
