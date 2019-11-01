using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class ColorOverlay : MonoBehaviour
	{
		public Color injuredColor;
		public float injuredOverlayDuration;

		private Image _overlayImage;
		private Color _initialColor;

		private void Start()
		{
			_overlayImage = GetComponent<Image>();
			Assert.IsNotNull(_overlayImage, "_overlayImage is null");
			_initialColor = _overlayImage.color;
		}

		[UsedImplicitly]
		public void InjuredOverlayFlash() => StartCoroutine(ChangeColor(injuredColor));

		private IEnumerator ChangeColor(Color newColor)
		{
			_overlayImage.color = newColor;
			yield return new WaitForSeconds(injuredOverlayDuration);
			
			// ReSharper disable once Unity.InefficientPropertyAccess
			_overlayImage.color = _initialColor;
		}
	}
}
