using com.ArkAngelApps.TheAvarice.Scriptable.System;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class ColliderIgnore : MonoBehaviour
	{
		private void OnCollisionEnter2D([NotNull] Collision2D other)
		{
			if (other.gameObject.CompareTag(SystemVariables.Instance.tagNames.Player))
			{
				Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
			}
		}
	}
}