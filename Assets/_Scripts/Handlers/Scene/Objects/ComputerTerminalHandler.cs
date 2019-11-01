using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Helpers.InputSystem;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using JetBrains.Annotations;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public sealed class ComputerTerminalHandler : MonoBehaviour
	{
		public int code;
		public ContextMessageData contextMessage;
		public UnityEvent onEnableEvent;

		private bool _withinTrigger;

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
			if (_withinTrigger)
			{
				_input.Enable();
			} else
			{
				_input.Disable();
			}
		}

		[UsedImplicitly]
		public void TriggerEnter()
		{
			if (!enabled)
			{
				return;
			}

			_withinTrigger = true;
			Controller.UI.contextMessageUI.ShowMessage(contextMessage.GetContextMessage());
		}

		[UsedImplicitly]
		public void TriggerExit()
		{
			_withinTrigger = false;
			Controller.UI.contextMessageUI.HideUI();
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		private void OnInteract(InputAction.CallbackContext ctx)
		{
			if (_withinTrigger)
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

		internal void CodeCorrect()
		{
			onEnableEvent.Invoke();
			Controller.UI.contextMessageUI.HideUI();
		}
	}
}
