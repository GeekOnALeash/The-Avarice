using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Helpers.InputSystem
{
	internal sealed class InputManager
	{
		private readonly Action<InputAction.CallbackContext> _started;
		private readonly Action<InputAction.CallbackContext> _performed;
		private readonly Action<InputAction.CallbackContext> _canceled;

		private readonly GameInputActions _gameInputActions;
		private readonly InputAction _inputAction;

		public InputManager(
			string actionName,
			[CanBeNull] Action<InputAction.CallbackContext> started = null,
			[CanBeNull] Action<InputAction.CallbackContext> performed = null,
			[CanBeNull] Action<InputAction.CallbackContext> canceled = null)
		{
			_started = started;
			_performed = performed;
			_canceled = canceled;

			_gameInputActions = new GameInputActions();
			_inputAction = _gameInputActions.Player.Get().FindAction(actionName);

			if (_inputAction == null)
			{
				Debug.Log("InputAction string name incorrect within constructor");
			}
		}

		public void Enable()
		{
			if (_started != null)
			{
				_inputAction.started += _started;
			}

			if (_performed != null)
			{
				_inputAction.performed += _performed;
			}

			if (_canceled != null)
			{
				_inputAction.canceled += _canceled;
			}

			_gameInputActions.Enable();
		}

		public void Disable()
		{
			if (_started != null)
			{
				_inputAction.started -= _started;
			}

			if (_performed != null)
			{
				_inputAction.performed -= _performed;
			}

			if (_canceled != null)
			{
				_inputAction.canceled -= _canceled;
			}

			_gameInputActions.Disable();
		}
	}
}