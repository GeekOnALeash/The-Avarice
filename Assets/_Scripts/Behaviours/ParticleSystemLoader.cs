using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class ParticleSystemLoader : BaseBehaviour
	{
		[SerializeField] internal GameObject particle;

		private SpriteRenderer _spriteRenderer;

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
