using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class PlayerAnimation : CharacterAnimation
	{
		private void UpdateMovementAnimations()
		{
			//animator.SetFloat(__Horizontal, PlayerRuntimeData.Instance.character.movement.horizontal);
			//animator.SetFloat(__Vertical, PlayerRuntimeData.Instance.character.movement.vertical);

			//spriteAnimator.Play("WalkRight");
		}

		private void FixedUpdate()
		{
//			if (!PlayerRuntimeData.Instance.character.movement.isMoving)
//			{
//				DoIdle();
//			}

			if (SystemVariables.Instance.keybinds.Left())
			{
				Play(anims.walkLeft);
			} else if (SystemVariables.Instance.keybinds.Right())
			{
				Play(anims.walkRight);
			} else if (SystemVariables.Instance.keybinds.Up())
			{
				Play(anims.walkUp);
			} else if (SystemVariables.Instance.keybinds.Down())
			{
				Play(anims.walkDown);
			} else if (!PlayerRuntimeData.Instance.character.movement.isMoving)
			{
				Play(GetDefaultIdle());
			}
		}
	}
}