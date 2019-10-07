using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class ParticleSystemLoader : MonoBehaviour
	{
		[SerializeField] internal GameObject particle;

		private SpriteRenderer _spriteRenderer;

		private Transform _thisTransform;

		// ReSharper disable once InconsistentNaming
		private new Transform transform
		{
			get
			{
				if (_thisTransform == null)
				{
					_thisTransform = base.transform;
				}

				return _thisTransform;
			}
		}

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Play(GameObject go)
		{
			var pos = _spriteRenderer ? _spriteRenderer.bounds.center : transform.position;

			ParticleSystem ps = Instantiate(go, pos, Quaternion.identity).GetComponent<ParticleSystem>();

			if (ps)
			{
				ps.Play();
			}

			Debug.Log($"{particle} field gameObject does not contain a ParticleSystem component.");
		}
	}
}
