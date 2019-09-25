using com.ArkAngelApps.TheAvarice.Behaviours;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	public sealed class CollisionHandler : ColliderHelper
	{
		private void OnCollisionEnter2D([NotNull] Collision2D other)
		{
			if (CheckColision(other.collider))
			{
				OnEnter();
			}
		}

		private void OnCollisionStay2D([NotNull] Collision2D other)
		{
			if (CheckColision(other.collider))
			{
				OnStay();
			}
		}

		private void OnCollisionExit2D([NotNull] Collision2D other)
		{
			if (CheckColision(other.collider))
			{
				OnExit();
			}
		}
	}
}