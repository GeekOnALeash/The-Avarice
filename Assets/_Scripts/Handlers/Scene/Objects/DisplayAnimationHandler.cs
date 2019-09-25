using System.Collections;
using com.ArkAngelApps.TheAvarice.Helpers;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public sealed class DisplayAnimationHandler : MonoBehaviour
	{
		private bool _isOn = true;

		public bool IsOn
		{
			get => _isOn;
			set
			{
				if (!value)
				{
					_isOn = false;
					return;
				}

				if (!_isOn)
				{
					_isOn = true;
					_sIndex = 0;
					StartCoroutine(Animator());
				} else
				{
					_isOn = true;
				}
			}
		}

		public float timeBetweenFrames = 4f;
		public SpriteRenderer spriteRenderer;
		public GameObject screenGlow;
		public Sprite[] onSprites;

		private int _sIndex;

		private void Start()
		{
			if (IsOn)
			{
				StartCoroutine(Animator());
			} else
			{
				spriteRenderer.enabled = false;
				if (screenGlow != null)
				{
					screenGlow.SetActive(false);
				}
			}
		}

		private IEnumerator Animator()
		{
			if (screenGlow != null)
			{
				screenGlow.SetActive(true);
			}

			spriteRenderer.enabled = true;

			while (IsOn)
			{
				spriteRenderer.sprite = onSprites[_sIndex];
				_sIndex++;
				if (_sIndex == onSprites.Length)
				{
					_sIndex = 0;
				}

				yield return new WaitForSeconds(timeBetweenFrames);
			}

			yield return YieldHelper.EndOfFrame;

			spriteRenderer.enabled = false;

			if (screenGlow != null)
			{
				screenGlow.SetActive(false);
			}
		}
	}
}