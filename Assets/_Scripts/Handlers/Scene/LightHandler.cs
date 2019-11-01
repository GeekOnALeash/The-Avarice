using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Abstracts;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene
{
	[ExecuteInEditMode]
	public sealed class LightHandler : CachedTransformBase
	{
		[SerializeField] private Light2D lightObject;
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private Color color;
		[SerializeField] private bool pulseLight;

		[ShowWhen(nameof(pulseLight))]
		[SerializeField]
		private float maxIntensity = 1f;

		[ShowWhen(nameof(pulseLight))]
		[SerializeField]
		private float minIntensity;

		[ShowWhen(nameof(pulseLight))]
		[SerializeField]
		private float pulseSpeed = 1f; //here, a value of 0.5f would take 2 seconds and a value of 2f would take half a second

		private Color _oldColor;
		private float _targetIntensity = 1f;
		private float _currentIntensity;

		private void Awake()
		{
			_oldColor = lightObject.color;
			ChangeColor(color);

			if (Application.isPlaying)
			{
				DisableLight();
			}
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void LateUpdate()
		{
			if (_oldColor != color)
			{
				ChangeColor(color);
			}

			if (pulseLight)
			{
				_currentIntensity = Mathf.MoveTowards(lightObject.intensity, _targetIntensity, Time.deltaTime * pulseSpeed);
				if (_currentIntensity >= maxIntensity)
				{
					_currentIntensity = maxIntensity;
					_targetIntensity = minIntensity;
				} else if (_currentIntensity <= minIntensity)
				{
					_currentIntensity = minIntensity;
					_targetIntensity = maxIntensity;
				}

				lightObject.intensity = _currentIntensity;
			}
		}

		private void ChangeColor(Color newColor)
		{
			lightObject.color = newColor;
			_oldColor = newColor;

			if (spriteRenderer)
			{
				spriteRenderer.color = newColor;
			}
		}

		public void ChangeColorWithHex(string hex)
		{
			if (!ColorUtility.TryParseHtmlString(hex, out Color newColor))
			{
				Debug.Log($"Not hex string: {hex}");
				return;
			}

			color = newColor;
			ChangeColor(newColor);
		}

		public void DisableLight()
		{
			lightObject.enabled = false;
		}

		public void EnableLight()
		{
			lightObject.enabled = true;
		}
	}
}