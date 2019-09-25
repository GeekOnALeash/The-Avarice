using System.Collections;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public enum FadeType
	{
		In,
		Out
	}

	public class Overlay : MonoBehaviour
	{
		public bool keepDisplayed;

		[ShowWhen(nameof(keepDisplayed))]
		public float displayTime;

		public bool fade;

		[ShowWhen(nameof(fade))]
		public float fadeTime;

		[Range(0, 1)]
		public float maxAlpha;

		private IEnumerator _fadeAlpha;
		private Color _originalColor;
		private Image _image;
		private FadeType _fadeType;

		private void Awake()
		{
			_image = GetComponent<Image>();
			Assert.IsNotNull(_image, "_image is null");
		}

		public void SetAlpha(FadeType fadeType)
		{
			_fadeType = fadeType;
			
			if (_fadeAlpha != null)
			{
				StopCoroutine(_fadeAlpha);
			}

			_fadeAlpha = FadeAlpha();
			StartCoroutine(_fadeAlpha);
		}

		private IEnumerator FadeAlpha()
		{
			Color resetColor = _image.color;
			resetColor.a = _fadeType == FadeType.Out ? maxAlpha : 0;
			_image.color = resetColor;
			
			yield return new WaitForSecondsRealtime(displayTime);

			while (AlphaCheck())
			{
				if (_fadeType == FadeType.Out)
				{
					FadeOut();
				} else
				{
					FadeIn();
				}

				yield return null;
			}

			if (_fadeType == FadeType.Out && _image.color.a >= 0)
			{
				gameObject.SetActive(false);
			}
			
			yield return null;
		}

		private bool AlphaCheck()
		{
			if (_fadeType == FadeType.Out)
			{
				return _image.color.a >= 0;
			}

			return _image.color.a <= maxAlpha;
		}

		private void FadeIn()
		{
			Color displayColor = _image.color;

			displayColor.a += Time.unscaledDeltaTime / fadeTime;

			_image.color = displayColor;
		}

		private void FadeOut()
		{
			Color displayColor = _image.color;

			displayColor.a -= Time.unscaledDeltaTime / fadeTime;

			_image.color = displayColor;
		}
	}
}