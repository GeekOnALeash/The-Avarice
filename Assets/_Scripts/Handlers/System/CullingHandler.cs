using com.ArkAngelApps.TheAvarice.Scriptable.System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	public sealed class CullingHandler : MonoBehaviour
	{
		[Header("To Enable/Disable")]
		public Rigidbody2D rb2D;

		public MonoBehaviour[] scripts;

		public Collider2D[] colliders;

		private void Start()
		{
			Enable(SystemVariables.Instance.mainCamera.IsVisibleToCamera(transform));
		}

		private void OnBecameInvisible()
		{
			Enable(false);
		}

		private void OnBecameVisible()
		{
			Enable(true);
		}

		private void Enable(bool value)
		{
			EnableColliders(value);
			EnableScripts(value);

			if (rb2D == null)
			{
				return;
			}

			if (value)
			{
				rb2D.WakeUp();
			} else
			{
				rb2D.Sleep();
			}
		}

		private void EnableScripts(bool value)
		{
			foreach (var s in scripts)
			{
				s.enabled = value;
			}
		}

		private void EnableColliders(bool value)
		{
			foreach (var c in colliders)
			{
				c.enabled = value;
			}
		}
	}
}