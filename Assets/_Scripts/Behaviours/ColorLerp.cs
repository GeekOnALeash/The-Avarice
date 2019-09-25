using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	[RequireComponent(typeof(SpriteRenderer))]
	public sealed class ColorLerp : MonoBehaviour
	{
		public Color startColor;
		public Color endColor;
		public float duration = 5; // duration in seconds

		private float _time; // lerp control variable
		private SpriteRenderer _spriteRenderer;

		private void Start()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			_spriteRenderer.color = Color.Lerp(startColor, endColor, _time);
			if (_time < 1)
			{
				// while t below the end limit...
				// increment it at the desired rate every update:
				_time += Time.deltaTime / duration;
			}
		}
	}
}
