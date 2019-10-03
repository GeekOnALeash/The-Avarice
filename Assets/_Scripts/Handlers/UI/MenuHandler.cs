using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Helpers;
using com.ArkAngelApps.TheAvarice.Helpers.InputSystem;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Handlers.UI
{
	public sealed class MenuHandler : MonoBehaviour
	{
		[SerializeField] private Overlay overlay;
		[SerializeField] private PauseMenuHandler pauseMenu;
		private bool _overlayShown;
		private InputManager _input;

		private void OnEnable()
		{
			_input = new InputManager("Escape", started: OnEscape, performed: OnEscape, canceled: OnEscape);
			_input.Enable();
		}

		private void OnDisable()
		{
			_input.Disable();
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		private void OnEscape(InputAction.CallbackContext ctx)
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

			pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
		}
	}
}
