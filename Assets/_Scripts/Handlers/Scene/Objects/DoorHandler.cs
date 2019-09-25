using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public sealed class DoorHandler : BarrierHandler
	{
		[SerializeField] private bool closeOnExit;

		[SerializeField] private PolygonCollider2D[] colliders;
		private int _currentColliderIndex;

		[SuppressMessage("ReSharper", "InvertIf")]
		private void LateUpdate()
		{
			if (withinProximity)
			{
				if (SystemVariables.Instance.keybinds.Interact())
				{
					if (_barrierInteractionType.Equals(BarrierInteractionType.Interaction)
					    || _barrierInteractionType.Equals(BarrierInteractionType.Locked)
					    && PlayerRuntimeData.Instance.itemContainer.HasKey(keyType))
					{
						if (barrierOpen)
						{
							CloseBarrier();
						} else
						{
							OpenBarrier();
						}
					}
				}
			}
		}

		[UsedImplicitly] // By Animation
		public void SetColliderForSprite(int spriteNum)
		{
			colliders[_currentColliderIndex].enabled = false;
			_currentColliderIndex = spriteNum;
			colliders[_currentColliderIndex].enabled = true;

			// These 2 lines are for hiding the shadow while door is not fully open.
			barrierOpen = spriteNum == 2; // This is set by animation
			ToggleBarrierWallShadows();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			if (!other.CompareTag(TagNames.Instance.Player) || other.isTrigger)
			{
				return;
			}

			if (_barrierInteractionType.Equals(BarrierInteractionType.Interaction))
			{
				withinProximity = true;
			} else if (_barrierInteractionType.Equals(BarrierInteractionType.Locked))
			{
				withinProximity = true;
			} else if (_barrierInteractionType.Equals(BarrierInteractionType.Trigger))
			{
				OpenBarrier();
			}
		}

		private void OnTriggerExit2D([NotNull] Collider2D other)
		{
			if (!other.CompareTag(TagNames.Instance.Player) || other.isTrigger || !closeOnExit)
			{
				return;
			}

			CloseBarrier();

			if (_barrierInteractionType.Equals(BarrierInteractionType.Interaction))
			{
				withinProximity = false;
			}
		}
	}
}