using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Helpers.InputSystem;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public sealed class KeypadHandler : ComputerTerminalHandler
	{
		public int code;

		private bool _keypadDisplayed;
		private bool _codeCorrect;

		private InputManager _input;

		public void OnEnable()
		{
			_input = new InputManager("Interact", performed: OnInteract);
			_input.Enable();
		}

		public void OnDisable()
		{
			_input.Disable();
		}

		private void LateUpdate()
		{
			if (withinTrigger)
			{
				_input.Enable();
			} else
			{
				_input.Disable();
			}
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		private void OnInteract(InputAction.CallbackContext ctx)
		{
			if (withinTrigger)
			{
				DisplayKeypad();
			}
		}

		private void DisplayKeypad()
		{
			if (_keypadDisplayed)
			{
				return;
			}

			Controller.UI.window.EnableKeypad(code, this);
			_keypadDisplayed = true;
		}

		public void CodeCorrect()
		{
			OnEvent(onEnableEvent);
		}
	}
}
