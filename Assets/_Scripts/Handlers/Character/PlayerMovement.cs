using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Interfaces;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries.Extensions;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class PlayerMovement : Movable, IMovement
	{
		private void Update()
		{
			if (!movementEnabled)
			{
				return;
			}

			if (!SystemVariables.Instance.keybinds)
			{
				return;
			}

			if (SystemVariables.Instance.keybinds.Left())
			{
				horizontal = -1.0f;
			} else if (SystemVariables.Instance.keybinds.Right())
			{
				horizontal = 1.0f;
			} else
			{
				horizontal = 0.0f;
			}

			if (SystemVariables.Instance.keybinds.Up())
			{
				vertical = 1.0f;
			} else if (SystemVariables.Instance.keybinds.Down())
			{
				vertical = -1.0f;
			} else
			{
				vertical = 0.0f;
			}

			isMoving = !horizontal.IsEqual(0.0f) || !vertical.IsEqual(0.0f);
		}

		private void LateUpdate()
		{
			if (isMoving)
			{
				SystemVariables.Instance.mainCamera.FollowTarget();
			}
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		public override void DoMovement()
		{
			if (!rb2D || (!moveSpeed.UseConstant && moveSpeed.Variable == null))
			{
				return;
			}

			movement.x = horizontal;
			movement.y = vertical;

			movement = moveSpeed.Value * Time.deltaTime * movement;

			var position = transform.position;
			pos.x = position.x;
			pos.y = position.y;

			rb2D.MovePosition(pos + movement);
		}
	}
}