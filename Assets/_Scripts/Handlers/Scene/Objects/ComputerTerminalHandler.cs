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
	using com.ArkAngelApps.TheAvarice.Managers;

	public sealed class ComputerTerminalHandler : MonoBehaviour
	{
		public int code;
		public ContextMessageData contextMessage;
		public UnityEvent onEnableEvent;

		private bool _withinTrigger;

		private bool _keypadVisible;
		private bool _codeCorrect;
		private bool _keypadDisabled;
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
			if (_keypadDisabled)
			{
				return;
			}

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
			if (!enabled || _keypadDisabled)
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
			HideKeypad();
			HideUI();
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		private void OnInteract(InputAction.CallbackContext ctx)
		{
			if (_withinTrigger && !_keypadDisabled)
			{
				DisplayKeypad();
			}
		}

		private void DisplayKeypad()
		{
			if (_keypadVisible || _keypadDisabled)
			{
				return;
			}

			Controller.UI.window.EnableKeypad(code, this);
			_keypadVisible = true;
		}

		internal void CodeCorrect()
		{
			onEnableEvent.Invoke();
			HideKeypad();
			DisableKeypad();
		}

		internal void HideKeypad()
		{
			_keypadVisible = false;
		}

		internal void DisableKeypad()
		{
			HideKeypad();
			HideUI();
			_keypadDisabled = true;
		}

		private void HideUI()
		{
			Controller.UI.contextMessageUI.HideUI();
		}
	}
}
