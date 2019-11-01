using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class HUDFPS : MonoBehaviour
	{
		[Serializable]
		public struct ValueTextUI
		{
			public Text fpsText;

			public Text fpsMinText;
			public Text fpsMaxText;
		}

		public ValueTextUI valueTextUI;

		[Serializable]
		public struct ColorsForValues
		{
			public Color lowColor;

			public Color mediumColor;
			public Color highColor;
		}

		public ColorsForValues colorsForValues;

		[Serializable]
		public struct FPSUpdateTimings
		{
			public float timeUntilMinCheck;

			public float updateInterval;
		}

		public FPSUpdateTimings updateTimings = new FPSUpdateTimings
		                                        {
			                                        timeUntilMinCheck = 10f,
			                                        updateInterval = 0.5f
		                                        };


		private float _accum; // FPS accumulated over the interval
		private int _frames; // Frames drawn over the interval
		private float _maxFPS;
		private float _minFPS = 1000; // This is set to a high value to ensure it is not 0
		private bool _minTimeReached;
		private float _timeleft; // Left time for current interval
		private float _timer;
		private float _fps;

		private void Start()
		{
			_timeleft = updateTimings.updateInterval;
			_timer = updateTimings.timeUntilMinCheck;

			valueTextUI.fpsText.text = "";
			valueTextUI.fpsMinText.text = "";
			valueTextUI.fpsMaxText.text = "";
		}

		private void Update()
		{
			if (!_minTimeReached)
			{
				_timer -= Time.deltaTime;

				_minTimeReached |= _timer <= 0;
			}

			_timeleft -= Time.deltaTime;
			_accum += Time.timeScale / Time.deltaTime;
			++_frames;

			// Interval ended - update GUI text and start new interval
			if (!(_timeleft <= 0.0))
			{
				return;
			}

			UpdateFPSText();

			_timeleft = updateTimings.updateInterval;
			_accum = 0.0F;
			_frames = 0;
		}

		private void UpdateFPSText()
		{
			_fps = _accum / _frames;
			valueTextUI.fpsText.text = _fps.ToString("F");
			ChangeColor(valueTextUI.fpsText);

			if (_fps > _maxFPS)
			{
				_maxFPS = _fps;
				valueTextUI.fpsMaxText.text = _fps.ToString("F");
				ChangeColor(valueTextUI.fpsMaxText);
			} else if (_fps < _minFPS)
			{
				if (!_minTimeReached)
				{
					return;
				}

				_minFPS = _fps;
				valueTextUI.fpsMinText.text = _fps.ToString("F");
				ChangeColor(valueTextUI.fpsMinText);

				_timer = 0;
			}
		}

		[SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
		private void ChangeColor([NotNull] Text text)
		{
			if (_fps >= 40 && _fps < 60)
			{
				text.color = colorsForValues.mediumColor;
			} else if (_fps < 40)
			{
				text.color = colorsForValues.lowColor;
			} else
			{
				text.color = colorsForValues.highColor;
			}
		}
	}
}