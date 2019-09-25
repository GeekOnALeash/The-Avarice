using System.Collections;
using com.ArkAngelApps.TheAvarice.MyEditor.Extensions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.UI
{
	[RequireComponent(typeof(SpriteRenderer))]
	public sealed class OutlineHandler : MonoBehaviour
	{
		[Tooltip("Layers that will show outline if behind.")]
		[SerializeField]
		private LayerMask layers;

		[SerializeField] private float fadeDuration = 0.5f;

		[Range(0.0f, 1.0f)]
		[SerializeField]
		// ReSharper disable once RedundantDefaultMemberInitializer
		private float alphaMin = 0.0f;

		[Range(0.0f, 1.0f)]
		[SerializeField]
		private float alphaMax = 1.0f;

		private SpriteRenderer _outline;

		private void Reset()
		{
			fadeDuration = 0.5f;
			alphaMin = 0.0f;
			alphaMax = 1.0f;
		}

		private void Awake()
		{
			_outline = GetComponent<SpriteRenderer>();
			Assert.IsNotNull(_outline, "_outline is null");
		}

		public void ShowOutline()
		{
			StartCoroutine(Fade(_outline, alphaMax, fadeDuration));
		}

		public void HideOutline()
		{
			StartCoroutine(Fade(_outline, alphaMin, fadeDuration));
		}

		private static IEnumerator Fade([NotNull] SpriteRenderer spriteRenderer, float alphaValue, float duration)
		{
			float counter = 0.0f;

			//Get current color
			Color spriteColor = spriteRenderer.color;

			while (counter < duration)
			{
				counter += Time.deltaTime;

				float alpha = Mathf.Lerp(spriteColor.a, alphaValue, counter / duration);

				//Change alpha only
				spriteRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);

				//Wait for a frame
				yield return null;
			}
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			if (other.isTrigger)
			{
				return;
			}

			if (CheckColision(other))
			{
				ShowOutline();
			}
		}

		private void OnTriggerExit2D([NotNull] Collider2D other)
		{
			if (other.isTrigger)
			{
				return;
			}

			if (CheckColision(other))
			{
				HideOutline();
			}
		}

		// ReSharper disable once SuggestBaseTypeForParameter
		private bool CheckColision(Collider2D other) => enabled && layers.Contains(other.gameObject);
	}
}