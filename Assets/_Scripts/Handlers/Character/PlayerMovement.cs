using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.InputSystem;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class PlayerMovement : Movable, GameInputActions.IPlayerActions
	{
		private GameInputActions _gameInputActions;
		private InputAction _inputAction;

		private void Awake()
		{
			_gameInputActions = new GameInputActions();
		}

		private void OnEnable()
		{
			_inputAction = _gameInputActions.Player.Move;
			_inputAction.started += OnMove;
			_inputAction.performed += OnMove;
			_inputAction.canceled += OnMove;
			_gameInputActions.Enable();
		}

		private void OnDisable()
		{
			_inputAction = _gameInputActions.Player.Move;
			_inputAction.started -= OnMove;
			_inputAction.performed -= OnMove;
			_inputAction.canceled -= OnMove;
			_gameInputActions.Disable();
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		public override void DoMovement()
		{
			if (!rb2D || !moveSpeed.UseConstant && moveSpeed.Variable == null)
			{
				return;
			}

			if (!isMoving)
			{
				return;
			}

			movement = moveSpeed.Value * Time.deltaTime * moveAxis;

			var position = transform.position;
			pos.x = position.x;
			pos.y = position.y;

			rb2D.MovePosition(pos + movement);
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		public void OnMove(InputAction.CallbackContext context)
		{
			moveAxis = context.ReadValue<Vector2>();

			isMoving = moveAxis != Vector2.zero;
		}

		public void OnLook(InputAction.CallbackContext context) { }

		public void OnFire(InputAction.CallbackContext context) { }
	}
}