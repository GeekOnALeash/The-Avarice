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
		public Light2D lightObject;
		public SpriteRenderer spriteRenderer;
		public Color color;
		public LightGroupHandler lightGroupHandler;
		public bool pulseLight;

		[ShowWhen(nameof(pulseLight))]
		public float maxIntensity = 1f;

		[ShowWhen(nameof(pulseLight))]
		public float minIntensity;

		[ShowWhen(nameof(pulseLight))]
		public float pulseSpeed = 1f; //here, a value of 0.5f would take 2 seconds and a value of 2f would take half a second

		private Color _oldColor;
		private float _targetIntensity = 1f;
		private float _currentIntensity;
		private bool _isSpriteRendererNotNull;

		private void Awake()
		{
			_isSpriteRendererNotNull = spriteRenderer != null;

			_oldColor = lightObject.color;
			ChangeColor(color);
		}

		private void Start()
		{
			if (lightGroupHandler == null)
			{
				lightGroupHandler = GetComponentInParent<LightGroupHandler>();

				if (lightGroupHandler == null)
				{
					Debug.LogWarning($"Missing {nameof(lightGroupHandler)} script on {gameObject.transform.parent.name}");
				}
			} else
			{
				lightGroupHandler.lightsInGroup.Add(this);
			}
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Update()
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
			color = newColor;
			lightObject.color = newColor;

			if (_isSpriteRendererNotNull)
			{
				spriteRenderer.color = newColor;
			}

			_oldColor = newColor;
		}

		public void ChangeColorWithHex(string hex)
		{
			if (!ColorUtility.TryParseHtmlString(hex, out Color newColor))
			{
				Debug.Log($"Not hex string: {hex}");
				return;
			}

			ChangeColor(newColor);
		}
	}
}