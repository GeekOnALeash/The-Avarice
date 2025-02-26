﻿using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Helpers.InputSystem;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class PlayerMovement : Movable
	{
		private InputManager _input;

		private void OnEnable()
		{
			_input = new InputManager("Move", started: OnMove, performed: OnMove, canceled: OnMove);
			_input.Enable();
		}

		private void OnDisable()
		{
			_input.Disable();
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		public override void DoMovement()
		{
			if (!rb2D && moveSpeed._variable == null)
			{
				return;
			}

			movement = moveSpeed.Value * Time.deltaTime * moveAxis.Value;

			var position = transform.position;
			pos.x = position.x;
			pos.y = position.y;

			rb2D.MovePosition(pos + movement);
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		private void OnMove(InputAction.CallbackContext ctx)
		{
			moveAxis.Value = ctx.ReadValue<Vector2>();
		}
	}
}