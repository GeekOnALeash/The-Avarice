using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	[RequireComponent(typeof(Collider2D))]
	public sealed class IgnoreCollisionByTag : MonoBehaviour
	{
		private Collider2D _collider;
		[SerializeField] private bool ignoreAllExcept;
		[SerializeField] private string tagToIgnore;

		// Use this for initialization
		private void Start()
		{
			_collider = GetComponent<Collider2D>();
			Assert.IsNotNull(_collider, "_collider is null");
		}

		private void OnCollisionEnter2D([NotNull] Collision2D other)
		{
			if (ignoreAllExcept)
			{
				if (!other.gameObject.CompareTag(tagToIgnore))
				{
					Physics2D.IgnoreCollision(other.collider, _collider);
				}
			} else
			{
				if (other.gameObject.CompareTag(tagToIgnore))
				{
					Physics2D.IgnoreCollision(other.collider, _collider);
				}
			}
		}
	}
}