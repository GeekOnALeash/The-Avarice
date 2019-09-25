using System;
using com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int;
using UnityEngine;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Composites
{
	[Serializable]
	public sealed class SliderComposite : IComposite
	{
		[SerializeField] private IntVariable_Slider sliderData;

		[Serializable]
		public struct UI
		{
			public Slider slider;
			public Image fillImage;
		}

		public UI ui;

		[Serializable]
		public struct ColorValues
		{
			public Color low;
			public Color medium;
			public Color high;
		}

		public ColorValues colorValues;

		/// <summary>
		/// This value is the lowest value that is visble due to the pixel scale
		/// </summary>
		private const int LowestVisibleSliderValue = 7;

		private void Reset()
		{
			colorValues.low = Color.white;
			colorValues.medium = Color.white;
			colorValues.high = Color.white;
		}

		internal void UpdateSlider()
		{
			if (sliderData == null)
			{
				sliderData = ScriptableObject.CreateInstance<IntVariable_Slider>();
			}

			UpdateSlider(sliderData.Value);
		}

		public void UpdateSlider(int value)
		{
			if (value < LowestVisibleSliderValue && value != 0)
			{
				ui.slider.value = LowestVisibleSliderValue;
			} else
			{
				ui.slider.value = value;
			}

			OnSliderWasChanged();
		}

		private void OnSliderWasChanged()
		{
			if (ReferenceEquals(ui.fillImage, null))
			{
				return;
			}

			var sliderPercentage = ui.slider.value * 100 / ui.slider.maxValue;

			// ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
			if (sliderPercentage >= 50)
			{
				ui.fillImage.color = Color.Lerp(colorValues.medium,
				                                colorValues.high,
				                                (ui.slider.value / 2) / ui.slider.maxValue);
			} else
			{
				ui.fillImage.color = Color.Lerp(colorValues.low,
				                                colorValues.medium,
				                                (ui.slider.value / 2) / ui.slider.maxValue);
			}
		}
	}
}